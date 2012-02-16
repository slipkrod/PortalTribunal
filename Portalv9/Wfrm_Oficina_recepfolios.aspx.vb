Imports Portalv9.SvrUsr
Imports System.Configuration

Partial Public Class Wfrm_Oficina_recepfolios
    Inherits System.Web.UI.Page
    Private eventocoltrasofOK As Integer = 2
    Private eventoaperusuarioOK As Integer = 54
    Private eventorecoltrasofOK As Integer = 81
    Private Const eventoError As Integer = 4
    Private Const eventoreError As Integer = 83
    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblerror.Text = ""
        If Not IsPostBack Then
            Try
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
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub ibtnrecibir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnrecibir.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim dsBolsa As DataSet
        lblerror.Text = ""
        Try

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                LogOff()
            End If
            lblerror.Text = ""
            ' dsBolsa = svr.BuscaInstanciaXBolsa(txtFolioBolsa.Text)
            Select Case estadoactual.Text.Trim 'dsBolsa.Tables(0).Rows(0).Item("EstadoID")
                Case 2
                    svr.TransitaInstanciaxBolsa(txtfoliobolsa.Text, eventocoltrasofOK, "", tTicket.UsrID)
                    ibtnrecibir.Visible = False
                    'btnDevolver.Visible = False
                    Response.Redirect("Wfrm_TE_FormatoRecepcion.aspx?Folio_bolsa=" & txtFolioBolsa.Text)
                    'txtFolioBolsa.Text = ""
                Case 54
                    svr.TransitaInstanciaxBolsa(txtFolioBolsa.Text, eventoaperusuarioOK, "", tTicket.UsrID)
                    EnviaMail(eventoaperusuarioOK, txtFolioBolsa.Text)
                    txtFolioBolsa.Text = ""
                    ibtnrecibir.Visible = False
                    'btnDevolver.Visible = False
                Case 81
                    svr.TransitaInstanciaxBolsa(txtFolioBolsa.Text, eventorecoltrasofOK, "", tTicket.UsrID)
                    'txtFolioBolsa.Text = ""
                    ibtnrecibir.Visible = False
                    'btnDevolver.Visible = False
                    Response.Redirect("Wfrm_RE_FormatoRecepcion.aspx?Folio_bolsa=" & txtFolioBolsa.Text)
            End Select

        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub
    Private Sub EnviaMail(ByVal evento As Integer, ByVal Folio_bolsa As String)
        Dim dsMensaje As DataSet
        Dim dsEnviar As DataSet
        Dim dsEmails As DataSet
        Dim dsEmailSolicita As DataSet
        Dim dsDatosSolicitante As DataSet
        Dim svr As New SAEX.ServiciosSAEX
        Dim intI As Integer
        Dim strTo, strFrom, strSubject, mensaje As String
        Dim Exp_doc As Integer

        Try

            strFrom = ConfigurationManager.AppSettings("Cuenta_Email")

            If svr.ObtieneTipoTrasladoxBolsa(Folio_bolsa) > 0 Then      ' expediente
                If svr.ObtieneConfidencialidadxBolsa(Folio_bolsa) = 1 Then
                    Exp_doc = 1
                Else
                    Exp_doc = 2
                End If
            Else
                If svr.ObtieneConfidencialidadxBolsa(Folio_bolsa) = 1 Then
                    Exp_doc = 3
                Else
                    Exp_doc = 4
                End If
            End If

            dsDatosSolicitante = svr.ObtieneDatosUsuario_solicita(Folio_bolsa)

            dsMensaje = svr.ObtieneMensajexEvento(evento, Exp_doc)

            If dsMensaje.Tables(0).Rows.Count > 0 Then
                strSubject = dsMensaje.Tables(0).Rows(0).Item("Asunto")

                mensaje = "El folio de la bolsa de seguridad " & Folio_bolsa & " enviado por el operador de archivo a oficinas para el usuario " & dsDatosSolicitante.Tables(0).Rows(0).Item("NOMBRE") & " ha sido recibido con exito." & vbNewLine

                mensaje = mensaje + dsMensaje.Tables(0).Rows(0).Item("Mensaje")
                dsEnviar = svr.ObtieneMensajeEnviarxEvento(evento, Exp_doc)
                If dsEnviar.Tables(0).Rows.Count > 0 Then
                    dsEmailSolicita = svr.ObtieneEmailUsuario_solicita(Folio_bolsa)
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
    Protected Sub ibtnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnbuscar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim dsBolsa As DataSet
        lblerror.Text = ""
        Try

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                LogOff()
            End If
            lblerror.Text = ""
            dsBolsa = svr.BuscaInstanciaXBolsa(txtfoliobolsa.Text)
            If dsBolsa.Tables(0).Rows.Count = 0 Then
                lblerror.Text = "No existe ese folio de bolsa..."
                ibtnrecibir.Visible = False
                ' btnDevolver.Visible = False
            Else
                estadoactual.Text = dsBolsa.Tables(0).Rows(0).Item("EstadoID")
                Select Case dsBolsa.Tables(0).Rows(0).Item("EstadoID")
                    Case 2
                        ibtnrecibir.Visible = True
                        'btnDevolver.Visible = True
                    Case 54
                        ibtnrecibir.Visible = True
                        'btnDevolver.Visible = False
                    Case 81
                        ibtnrecibir.Visible = True
                        'btnDevolver.Visible = True
                    Case Else
                        lblerror.Text = "La bolsa no se pude recibir en oficinas..."
                End Select
            End If
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub
End Class