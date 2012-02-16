Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxTreeList
Partial Public Class Wfrm_TE_RechazoBolsaACDet
    Inherits System.Web.UI.Page

    Private Const estado As Integer = 8
    Private Const eventoFaltantes As Integer = 9
    Private Const eventoNoDiferencias As Integer = 11
    Private tTicket As IDTicket
    Private DocumentosOK As Integer
    Dim svr As New SAEX.ServiciosSAEX

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        Dim ds As DataSet
        Me.lblError.Text = ""
        'Call GetFocusRemesa()
        If Not IsPostBack Then
            Try
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
                If Request.QueryString("FolioBolsa") <> "" Then
                    lblFolioBolsa.Text = Request.QueryString("FolioBolsa")
                End If

                DocumentosOK = 0
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


    Private Sub btnValidaBolsa_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnValidaBolsa.Click
        Dim exp_doc As Integer
        Dim Fecha_aviso As DateTime
        Dim rsAtributos As DataSet
        Dim nFila As DataRow
        Try
            Fecha_aviso = Now
            If CType(lblDocumentos.Text, Integer) > ASPxTreeList1.GetSelectedNodes.Count And RadioButtonList1.SelectedItem.Value = 0 Then
                Me.lblError.Text = "Si no marca todos los documentos debe seleccionar hay inconsistencias..."
            Else
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    LogOff()
                    Exit Sub
                End If
                If svr.ObtenTipoTraslado(Request.QueryString("InstanciaID"), Request.QueryString("FolioBolsa")) > 0 Then
                    If RadioButtonList1.SelectedItem.Value = 0 Then
                        'Padre en caso de venir en la misma bolsa
                        rsAtributos = svr.Obten_Atributos(eventoNoDiferencias, "CorteInstancia")
                        nFila = rsAtributos.Tables(0).NewRow

                        nFila.Item("Variacion") = txtVariacion.Text
                        nFila.Item("Observaciones") = txtObservaciones.Text
                        nFila.Item("Status_Bolsa") = 1
                        nFila.Item("idStatus") = RadioButtonList1.SelectedItem.Value
                        nFila.Item("Folio_bolsa") = Request.QueryString("FolioBolsa")
                        nFila.Item("Confirmacion_recibido") = 1

                        rsAtributos.Tables(0).Rows.Add(nFila)
                        svr.SQLUpdate_Campos_Atributos(rsAtributos, "corteInstancia", Request.QueryString("InstanciaID"))
                        rsAtributos = Nothing

                        svr.TransitaInstancia(Request.QueryString("InstanciaID"), eventoNoDiferencias, "", tTicket.UsrID)
                    Else
                        'Padre en caso de venir en la misma bolsa
                        rsAtributos = svr.Obten_Atributos(eventoFaltantes, "CorteInstancia")
                        nFila = rsAtributos.Tables(0).NewRow

                        nFila.Item("Variacion") = txtVariacion.Text
                        nFila.Item("Observaciones") = txtObservaciones.Text
                        nFila.Item("Status_Bolsa") = 1
                        nFila.Item("idStatus") = RadioButtonList1.SelectedItem.Value
                        nFila.Item("Folio_bolsa") = Request.QueryString("FolioBolsa")
                        nFila.Item("Confirmacion_recibido") = 1
                        Fecha_aviso = Now
                        nFila.Item("Aviso1") = Fecha_aviso
                        nFila.Item("NoAvisos") = 1


                        rsAtributos.Tables(0).Rows.Add(nFila)
                        svr.SQLUpdate_Campos_Atributos(rsAtributos, "corteInstancia", Request.QueryString("InstanciaID"))
                        rsAtributos = Nothing

                        svr.TransitaInstancia(Request.QueryString("InstanciaID"), eventoFaltantes, "", tTicket.UsrID)
                    End If
                    exp_doc = 1
                Else
                    exp_doc = 3
                End If

                If RadioButtonList1.SelectedItem.Value = 0 Then
                    GuardaDocumentos_HijosInconsistencias(eventoNoDiferencias, Fecha_aviso)
                    EnviaMail(eventoNoDiferencias, exp_doc)
                    dlgBoxExcepciones.ShowConfirmation("Se ha enviado aviso por correo electrónico", "Aviso", True, True)
                Else
                    GuardaDocumentos_HijosInconsistencias(eventoFaltantes, Fecha_aviso)
                    EnviaMail(eventoFaltantes, exp_doc)
                    dlgBoxExcepciones.ShowConfirmation("Se ha enviado aviso por correo electrónico", "Aviso", True, True)
                End If


            End If

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try

    End Sub


    Private Sub GuardaDocumentos_HijosInconsistencias(ByVal nEvento As Integer, ByVal Fecha_aviso As DateTime)
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
                nFila.Item("Aviso1") = Fecha_aviso
                nFila.Item("NoAvisos") = 1
                rsDocumentos.Tables(0).Rows.Add(nFila)

                svr.SQLUpdate_Campos_Atributos(rsDocumentos, "corteInstancia", iterator.Current.GetValue("InstanciaID"))
                svr.TransitaInstancia(iterator.Current.GetValue("InstanciaID"), nEvento, "", tTicket.UsrID)

            End If
            iterator.GetNext()
        Loop

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

    Private Sub dlgBoxExcepciones_NoChoosed(ByVal sender As Object, ByVal Key As String) Handles dlgBoxExcepciones.NoChoosed
        Response.Redirect("Wfrm_TE_RechazoBolsaAC.aspx?FolioBolsa=" & Request.QueryString("FolioBolsa"))
    End Sub

    Private Sub dlgBoxExcepciones_YesChoosed(ByVal sender As Object, ByVal Key As String) Handles dlgBoxExcepciones.YesChoosed
        Response.Redirect("Wfrm_TE_RechazoBolsaAC.aspx?FolioBolsa=" & Request.QueryString("FolioBolsa"))
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


            dsDatosSolicitante = svr.ObtieneDatosUsuario_solicita(lblFolioBolsa.Text)


            rsInstancia = svr.BuscaInstancia(Request.QueryString("InstanciaID"))

            If rsInstancia.Tables(0).Rows(0).Item("Confidencial") Then
                Exp_doc = Exp_doc + 1
            End If


            dsMensaje = svr.ObtieneMensajexEvento(evento, Exp_doc)

            If dsMensaje.Tables(0).Rows.Count > 0 Then
                strSubject = dsMensaje.Tables(0).Rows(0).Item("Asunto")

                mensaje = "El folio de la bolsa de seguridad " & lblFolioBolsa.Text & " enviado por el usuario " & dsDatosSolicitante.Tables(0).Rows(0).Item("NOMBRE") & " al archivo central fué revisado en el achivo central por bolsa abierta." & vbNewLine


                If RadioButtonList1.SelectedItem.Value = 0 Then
                    mensaje = mensaje & "Sin faltantes en el expediente: " & lblLLave.Text & vbNewLine
                Else
                    mensaje = mensaje & "Con inconsistencias en el expediente: " & lblLLave.Text & vbNewLine & " Variación:" & txtVariacion.Text & vbNewLine
                End If

                mensaje = mensaje + dsMensaje.Tables(0).Rows(0).Item("Mensaje")
                dsEnviar = svr.ObtieneMensajeEnviarxEvento(evento, Exp_doc)
                If dsEnviar.Tables(0).Rows.Count > 0 Then
                    dsEmailSolicita = svr.ObtieneEmailUsuario_solicita(lblFolioBolsa.Text)
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

End Class
