Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_MCAltabolsa
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 21
    Private Const eventoOK As Integer = 27
    Private tTicket As IDTicket
    Private correo As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim svr As New SAEX.ServiciosSAEX
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                Logoff()
                Exit Sub
            End If
            Dim strRes As String = Session("DebeCambiarPwd")
            If strRes <> String.Empty Then
                If CType(strRes, Boolean) = True Then
                    Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                End If
            End If
        End If
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub ibaceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibaceptar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim iRespuesta As SAEX.Respuesta
        Dim nInstancia As New SAEX.clsInstancia
        Dim idInstancia As Integer
        Dim rsEntidadArea As DataSet
        Dim rsExisteBolsa As DataSet
        Dim nRow As DataRow

        Lblerror.Text = ""

        If (txtFolioBolsa.Text.trim() = txtFolioBolsaConf.Text.trim()) Then
            Validate()
            If IsValid Then
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If tTicket Is Nothing Then
                    LogOff()
                End If
                rsExisteBolsa = svr.BuscaInstanciaXBolsa(txtFolioBolsa.Text)
                If rsExisteBolsa.Tables(0).Rows.Count = 0 Then  'Alta de Bolsa
                    ASPxGridView1.Visible = True
                    Evaluar()
                Else 'Continuar con captura
                    If rsExisteBolsa.Tables(0).Rows(0).Item("EstadoID") = estado Then
                        Evaluar()
                        MarcaElementos(txtFolioBolsa.Text)
                    Else
                        Lblerror.Text = "No es posible actualizar una bolsa cerrada y enviada."
                    End If
                End If
            End If
        Else
            Lblerror.Text = "No son iguales los valores de folio"
        End If
    End Sub
    Private Function Evaluar() As Integer
        Try
            If ASPxGridView1.Columns.Count > 0 Then
                txtFolioBolsa.ReadOnly = True
                txtFolioBolsaConf.ReadOnly = True
                ibaceptar.Visible = False
                btncerrar.Visible = True
            Else
                txtFolioBolsa.ReadOnly = False
                txtFolioBolsaConf.ReadOnly = False
                ibaceptar.Visible = True
                btncerrar.Visible = False
            End If
        Catch ex As Exception
            Lblerror.Text = ex.Message
        End Try
    End Function
    Private Function MarcaElementos(ByVal Folio_Bolsa As String) As Integer
        Dim intI As Integer
        For intI = 0 To ASPxGridView1.VisibleRowCount - 1
            If ASPxGridView1.Selection.IsRowSelected(intI) Then
                ASPxGridView1.GetDataRow(intI).Item("Tipo_operacion") = "Exp"
                ASPxGridView1.Selection.SelectRow(intI)
            End If
        Next
    End Function

    Protected Sub ASPxGridView1_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxGridView1.DataBound
        Dim intI As Integer
        For intI = 0 To ASPxGridView1.VisibleRowCount - 1
            Select Case ASPxGridView1.GetDataRow(intI).Item("Tipo_operacion").ToString()
                Case 110
                    ASPxGridView1.GetDataRow(intI).Item("Tipo_operacion") = "Exp"
                Case 120
                    ASPxGridView1.GetDataRow(intI).Item("Tipo_operacion") = "Doc"
                Case Else
                    ASPxGridView1.GetDataRow(intI).Item("Tipo_operacion") = "Err"
            End Select
        Next
    End Sub

    Protected Sub btncerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btncerrar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Lblerror.Text = ""
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                LogOff()
            End If

            If ASPxGridView1.Selection.Count = 0 Then
                Lblerror.Text = "Solamente se puede cerrar una bolsa con expedientes"
            Else

                If HayExpconfynoconf() Then
                    Lblerror.Text = "No se puede mezclar expedientes confidenciales con no confidenciales en la misma bolsa"
                Else
                    If HayExpyDoc() Then
                        Lblerror.Text = "No se puede mezclar expedientes con documentos en la misma bolsa"
                    Else
                        TransitaBolsa()
                        If correo = "NC" Then
                            EnviaMail(eventoOK, 1, tTicket.NoIdentidad, tTicket.NombreCompleto)
                        Else
                            EnviaMail(eventoOK, 2, tTicket.NoIdentidad, tTicket.NombreCompleto)
                        End If
                        Response.Redirect("Wfrm_TE_Aviso.aspx?Aviso=" & Server.UrlEncode("Folio de bolsa de seguridad " & txtFolioBolsa.Text & " ha sido cerrado y registrado exitosamente."))

                    End If
                End If
            End If
        Catch ex As Exception
            Lblerror.Text = ex.Message
        End Try
    End Sub
    Private Function HayExpconfynoconf() As Boolean
        Dim intI As Integer
        Dim contc As Integer = 0
        Dim contnc As Integer = 0
        Dim confideincial As String
        HayExpconfynoconf = False
        correo = ""
        For intI = 0 To ASPxGridView1.VisibleRowCount - 1
            If ASPxGridView1.Selection.IsRowSelected(intI) Then
                confideincial = ASPxGridView1.GetDataRow(intI).Item("Confidencial").ToString()
                If confideincial = 0 Then
                    contnc += 1
                    correo = "NC"
                Else
                    contc += 1
                    correo = "C"
                End If

            End If
        Next
        If contc > 0 And contnc > 0 Then
            HayExpconfynoconf = True
        End If
    End Function
    Private Function HayExpyDoc() As Boolean
        Dim intI As Integer
        Dim contc As Integer = 0
        Dim contnc As Integer = 0
        Dim Tipo As String
        HayExpyDoc = False
        For intI = 0 To ASPxGridView1.VisibleRowCount - 1
            If ASPxGridView1.Selection.IsRowSelected(intI) Then
                Tipo = ASPxGridView1.GetDataRow(intI).Item("Tipo_operacion").ToString()
                If Tipo = "Exp" Then
                    contc += 1
                ElseIf Tipo = "Doc" Then
                    contnc += 1
                End If
            End If
        Next
        If contc > 0 And contnc > 0 Then
            HayExpyDoc = True
        End If
    End Function
    Private Sub EnviaMail(ByVal evento As Integer, ByVal Exp_doc As Integer, ByVal Noidentidad As Integer, ByVal NombreUsuario As String)
        Dim dsMensaje As DataSet
        Dim dsEnviar As DataSet
        Dim dsEmails As DataSet
        Dim rsEntidadArea As DataSet
        Dim svr As New SAEX.ServiciosSAEX
        Dim intI As Integer
        Dim strTo, strFrom, strSubject, mensaje As String
        Dim userID As New Portalv9.SvrUsr.IdentidadUsr

        Try

            strFrom = ConfigurationManager.AppSettings("Cuenta_Email")
            rsEntidadArea = svr.BuscaEntidad_Area(Noidentidad)
            dsMensaje = svr.ObtieneMensajexEvento(evento, Exp_doc)

            If dsMensaje.Tables(0).Rows.Count > 0 Then
                strSubject = dsMensaje.Tables(0).Rows(0).Item("Asunto")

                mensaje = "El usuario " & NombreUsuario & " pidió recolección del expediente "
                Dim columnas As Integer = ASPxGridView1.Attributes.Count

                mensaje = mensaje.Substring(0, mensaje.Length - 2) & vbNewLine

                mensaje = mensaje + dsMensaje.Tables(0).Rows(0).Item("Mensaje")
                dsEnviar = svr.ObtieneMensajeEnviarxEvento(evento, Exp_doc)
                If dsEnviar.Tables(0).Rows.Count > 0 Then
                    'strTo = userID.Email
                    strTo = ""
                    dsEmails = svr.BuscaResponsableAA(rsEntidadArea.Tables(0).Rows(0).Item("idAreaAdmin"), evento, Exp_doc)

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
            Lblerror.Text = ex.Message
        End Try
    End Sub
    Private Function TransitaBolsa() As Boolean
        Dim svr As New SAEX.ServiciosSAEX
        Dim intI As Integer

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If tTicket Is Nothing Then
            LogOff()
        End If
        For intI = 0 To ASPxGridView1.VisibleRowCount - 1
            If ASPxGridView1.Selection.IsRowSelected(intI) Then
                svr.Actualiza_FolioBolsa_expediente(txtFolioBolsa.Text, ASPxGridView1.GetDataRow(intI).Item("Llave_expediente").ToString(), estado)
            End If
        Next
        svr.TransitaInstanciaxBolsa(txtFolioBolsa.Text, eventoOK, "", tTicket.UsrID)
    End Function
End Class