Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxTreeList
Partial Public Class Wfrm_EN_RevUsuarioContenido
    Inherits System.Web.UI.Page

    Private Const estado As Integer = 55
    Private Const eventoOK As Integer = 55
    Private Const eventoFaltantes As Integer = 56
    Private tTicket As IDTicket
    Private DocumentosOK As Integer


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        Dim ds As DataSet
        Dim svr As New SAEX.ServiciosSAEX

        If Not IsPostBack Then
            Try
                TBLDiferencias.Visible = False
                Me.lblError.Text = ""

                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    LogOff()
                    Exit Sub
                End If
                Dim strRes As String = Session("DebeCambiarPwd")
                If strRes <> String.Empty Then
                    If CType(strRes, Boolean) = True Then
                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                    End If
                End If
                ds = svr.BuscaInstanciaExpedientexID(Request.QueryString("FolioBolsa"), Request.QueryString("InstanciaPID"))

                chkConfiddencial.Checked = ds.Tables(0).Rows(0).Item("Confidencial")
                lblTipoExpediente.Text = ds.Tables(0).Rows(0).Item("TipoExpediente")
                lblEntidad.Text = ds.Tables(0).Rows(0).Item("Entidad")
                lblArea.Text = ds.Tables(0).Rows(0).Item("Area")
                lblAno.Text = ds.Tables(0).Rows(0).Item("Anio")
                lblMes.Text = ds.Tables(0).Rows(0).Item("Mes")
                lblDia.Text = ds.Tables(0).Rows(0).Item("Dia")
                lblLLave.Text = ds.Tables(0).Rows(0).Item("Llave_expediente")
                lblIndice.Text = ds.Tables(0).Rows(0).Item("Indice_de_busqueda")
                lblInstancia.Text = ds.Tables(0).Rows(0).Item("InstanciaPID")

                DataBind()
                ASPxTreeList1.ExpandAll()

            Catch ex As Exception
                Me.lblError.Text = ex.Message
            End Try
        End If

    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAceptar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Try
            If CType(lblDocumentos.Text, Integer) = ASPxTreeList1.GetSelectedNodes.Count Then
                Validate()
                If IsValid Then
                    tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                    If tTicket Is Nothing Then
                        LogOff()
                    End If
                    If svr.ObtenTipoTraslado(lblInstancia.Text, Request.QueryString("FolioBolsa")) > 0 Then
                        GuardaDocumentos_Arbol(lblInstancia.Text, eventoOK)
                        GuardaDocumentos_Hijos(eventoOK)
                    Else
                        GuardaDocumentos_Hijos(eventoOK)
                    End If
                    Response.Redirect("Wfrm_EN_RevUsuario.aspx?FolioBolsa=" & Request.QueryString("FolioBolsa"))
                End If
            Else
                dlgBoxExcepciones.ShowMessage("Para poder recibir el expediente es necesario que todos los documentos esten seleccionados")
            End If
        Catch ex As Exception
            dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub GuardaDocumentos_Hijos(ByVal nEvento As Integer)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsDocumentos As DataSet
        Dim nFila As DataRow

        Dim iterator As TreeListNodeIterator = New TreeListNodeIterator(ASPxTreeList1.RootNode)
        Do While Not iterator.Current Is Nothing
            If iterator.Current.GetValue("Nivel") = 9 Then
                rsDocumentos = svr.Obten_Atributos(nEvento, "CorteInstancia")
                nFila = rsDocumentos.Tables(0).NewRow
                If iterator.Current.Selected Then
                    nFila.Item("Confirmacion_recibido") = 1
                Else
                    nFila.Item("Confirmacion_recibido") = 0
                End If
                nFila.Item("Variacion") = ""
                nFila.Item("Observaciones") = ""
                nFila.Item("idStatus") = 0
                nFila.Item("Status_Bolsa") = 0
                nFila.Item("Folio_bolsa") = ""
                nFila.Item("Tipo_operacion") = ""

                rsDocumentos.Tables(0).Rows.Add(nFila)

                svr.SQLUpdate_Campos_Atributos(rsDocumentos, "corteInstancia", iterator.Current.GetValue("InstanciaID"))
                svr.TransitaInstancia(iterator.Current.GetValue("InstanciaID"), nEvento, "", tTicket.UsrID)

            End If
            iterator.GetNext()
        Loop
    End Sub

    Private Sub GuardaDocumentos_Arbol(ByVal InstanciaId As Integer, ByVal nEvento As Integer)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsDocumentos As DataSet
        Dim nFila As DataRow


        rsDocumentos = svr.Obten_Atributos(eventoOK, "CorteInstancia")
        nFila = rsDocumentos.Tables(0).NewRow

        nFila.Item("Confirmacion_recibido") = 1
        nFila.Item("Variacion") = ""
        nFila.Item("Observaciones") = ""
        nFila.Item("idStatus") = 0
        nFila.Item("Status_Bolsa") = 0
        'nFila.Item("Folio_bolsa") = Request.QueryString("FolioBolsa")
        nFila.Item("Folio_bolsa") = ""
        nFila.Item("Tipo_operacion") = ""

        rsDocumentos.Tables(0).Rows.Add(nFila)
        svr.SQLUpdate_Campos_Atributos(rsDocumentos, "corteInstancia", InstanciaId)
        svr.TransitaInstancia(InstanciaId, nEvento, "", tTicket.UsrID)
    End Sub

    Private Sub GuardaDocumentos_ArbolInconsistencias(ByVal InstanciaId As Integer, ByVal nEvento As Integer, ByVal Fecha_aviso As DateTime)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsDocumentos As DataSet
        Dim nFila As DataRow

        rsDocumentos = svr.Obten_Atributos(nEvento, "CorteInstancia")

        nFila = rsDocumentos.Tables(0).NewRow

        nFila.Item("Confirmacion_recibido") = 1
        nFila.Item("Variacion") = txtVariacion.Text
        nFila.Item("Observaciones") = txtObservaciones.Text
        nFila.Item("idStatus") = RadioButtonList1.SelectedItem.Value
        nFila.Item("Status_Bolsa") = 1
        nFila.Item("Folio_bolsa") = Request.QueryString("FolioBolsa")
 
        rsDocumentos.Tables(0).Rows.Add(nFila)
        svr.SQLUpdate_Campos_Atributos(rsDocumentos, "corteInstancia", InstanciaId)
        svr.TransitaInstancia(InstanciaId, nEvento, "", tTicket.UsrID)
    End Sub

    Private Sub GuardaDocumentos_HijosInconsistencias(ByVal nEvento As Integer, ByVal Fecha_aviso As DateTime)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsDocumentos As DataSet
        Dim nFila As DataRow

        Dim iterator As TreeListNodeIterator = New TreeListNodeIterator(ASPxTreeList1.RootNode)
        Do While Not iterator.Current Is Nothing
            If iterator.Current.GetValue("Nivel") = 9 Then
                rsDocumentos = svr.Obten_Atributos(nEvento, "CorteInstancia")
                nFila = rsDocumentos.Tables(0).NewRow
                If iterator.Current.Selected Then
                    nFila.Item("Confirmacion_recibido") = 1
                Else
                    nFila.Item("Confirmacion_recibido") = 0
                End If
                nFila.Item("Variacion") = txtVariacion.Text
                nFila.Item("Observaciones") = txtObservaciones.Text
                nFila.Item("idStatus") = RadioButtonList1.SelectedItem.Value
                nFila.Item("Status_Bolsa") = 1
                nFila.Item("Folio_bolsa") = Request.QueryString("FolioBolsa")
                rsDocumentos.Tables(0).Rows.Add(nFila)

                svr.SQLUpdate_Campos_Atributos(rsDocumentos, "corteInstancia", iterator.Current.GetValue("InstanciaID"))
                svr.TransitaInstancia(iterator.Current.GetValue("InstanciaID"), nEvento, "", tTicket.UsrID)

            End If
            iterator.GetNext()
        Loop

    End Sub


    Private Sub btnDocumentosFaltantes_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDocumentosFaltantes.Click
        TBLDiferencias.Visible = True
        btnDocumentosFaltantes.Visible = False
        btnAceptar.Visible = False
    End Sub

    Private Sub btnValidaBolsa_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnValidaBolsa.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim exp_doc As Integer
        Dim seEnvioMail As Boolean
        Dim Fecha_aviso As DateTime

        seEnvioMail = False
        DocumentosOK = 0
        Fecha_aviso = Now
        If CType(lblDocumentos.Text, Integer) > ASPxTreeList1.GetSelectedNodes.Count And RadioButtonList1.SelectedItem.Value = 0 Then
            Me.lblError.Text = "Si no marca todos los documentos debe seleccionar hay inconsistencias..."
        Else
            If txtVariacion.Text.Trim = "" And txtObservaciones.Text.Trim = "" Then
                lblError.Text = "Debe capturar las causas de la inconsistencia o las observaciones"
            Else
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If tTicket Is Nothing Then
                    LogOff()
                End If
                If svr.ObtenTipoTraslado(lblInstancia.Text, Request.QueryString("FolioBolsa")) > 0 Then
                    If RadioButtonList1.SelectedItem.Value = 0 Then
                        GuardaDocumentos_Arbol(lblInstancia.Text, eventoOK)
                        GuardaDocumentos_Hijos(eventoOK)
                    Else
                        GuardaDocumentos_ArbolInconsistencias(lblInstancia.Text, eventoFaltantes, Fecha_aviso)
                        GuardaDocumentos_HijosInconsistencias(eventoFaltantes, Fecha_aviso)
                    End If
                Else
                    If RadioButtonList1.SelectedItem.Value = 0 Then
                        GuardaDocumentos_Hijos(eventoOK)
                    Else
                        GuardaDocumentos_HijosInconsistencias(eventoFaltantes, Fecha_aviso)
                    End If
                End If
                Response.Redirect("Wfrm_EN_RevUsuario.aspx?FolioBolsa=" & Request.QueryString("FolioBolsa"))
            End If
        End If
    End Sub

    Private Sub EnviaMail(ByVal evento As Integer, ByVal Exp_doc As Integer)
        Dim dsMensaje As DataSet
        Dim dsEnviar As DataSet
        Dim dsEmails As DataSet
        Dim dsEmailSolicita As DataSet
        Dim dsDatosSolicitante As DataSet
        Dim svr As New SAEX.ServiciosSAEX
        Dim intI As Integer
        Dim strTo, strFrom, strSubject, mensaje As String
        Dim rsInstancia As DataSet

        Try

            strFrom = ConfigurationManager.AppSettings("Cuenta_Email")


            dsDatosSolicitante = svr.ObtieneDatosUsuario_solicita(Request.QueryString("FolioBolsa"))


            rsInstancia = svr.BuscaInstancia(Request.QueryString("InstanciaPID"))

            If rsInstancia.Tables(0).Rows(0).Item("Confidencial") Then
                Exp_doc = Exp_doc + 1
            End If


            dsMensaje = svr.ObtieneMensajexEvento(evento, Exp_doc)

            If dsMensaje.Tables(0).Rows.Count > 0 Then
                strSubject = dsMensaje.Tables(0).Rows(0).Item("Asunto")

                mensaje = "El expediente " & lblLLave.Text & " enviado por el usuario " & dsDatosSolicitante.Tables(0).Rows(0).Item("NOMBRE") & " al archivo central fué revisado en el achivo central." & vbNewLine


                If RadioButtonList1.SelectedItem.Value = 0 Then
                    mensaje = mensaje & "Sin faltantes en el expediente: " & lblLLave.Text & vbNewLine
                Else
                    mensaje = mensaje & "Con inconsistencias en el expediente: " & lblLLave.Text & vbNewLine & " Variación: " & txtVariacion.Text & vbNewLine
                End If
                mensaje = mensaje + dsMensaje.Tables(0).Rows(0).Item("Mensaje")
                dsEnviar = svr.ObtieneMensajeEnviarxEvento(evento, Exp_doc)
                If dsEnviar.Tables(0).Rows.Count > 0 Then
                    dsEmailSolicita = svr.ObtieneEmailUsuario_solicita(Request.QueryString("FolioBolsa"))
                    If dsEmailSolicita.Tables(0).Rows.Count > 0 Then
                        strTo = dsEmailSolicita.Tables(0).Rows(0).Item("Email") & ";"
                    Else
                        strTo = ""
                    End If

                    dsEmails = svr.BuscaResponsableAA(dsDatosSolicitante.Tables(0).Rows(0).Item("idArea"), evento, Exp_doc)
                    For intI = 0 To dsEmails.Tables(0).Rows.Count - 1
                        strTo = strTo & dsEmails.Tables(0).Rows(intI).Item("email") & ";"
                    Next
                    dsEmails = svr.BuscaEnviar_usuarios(evento, Exp_doc)
                    For intI = 0 To dsEmails.Tables(0).Rows.Count - 1
                        strTo = strTo & dsEmails.Tables(0).Rows(intI).Item("email") & ";"
                    Next
                    If strTo <> "" Then
                        Dim smtp As New System.Net.Mail.SmtpClient
                        smtp.Host = ConfigurationManager.AppSettings("SMTP")
                        smtp.Send(strFrom, strTo, strSubject, mensaje)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub ASPxTreeList1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxTreeList1.DataBound
        Dim iterator As TreeListNodeIterator = New TreeListNodeIterator(ASPxTreeList1.RootNode)
        Do While Not iterator.Current Is Nothing
            If iterator.Current.GetValue("Nivel") = 9 Then
                iterator.Current.AllowSelect = True
                DocumentosOK = DocumentosOK + 1
            Else
                iterator.Current.AllowSelect = False
            End If
            iterator.GetNext()
        Loop

        lblDocumentos.Text = DocumentosOK
    End Sub

End Class