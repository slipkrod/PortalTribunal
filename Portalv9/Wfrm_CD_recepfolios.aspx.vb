Imports Portalv9.SvrUsr
Imports System.Configuration
Partial Public Class Wfrm_CD_recepfolios
    Inherits System.Web.UI.Page

    Private Const estado As Integer = 4
    Private Const eventoOK As Integer = 5
    Private Const estado1 As Integer = 83
    Private Const eventoOK1 As Integer = 84
    Private Const estado2 As Integer = 52
    Private Const eventoOK2 As Integer = 52
    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As DataSet
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

    Protected Sub ibtnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnbuscar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim dsBolsa As DataSet
        lblerror.Text = ""
        Try

            lblSellada.Visible = False
            lblForaneo.Visible = False
            chkbolsasellada.Visible = False
            chkBolsaForanea.Visible = False

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                Logoff()
            End If
            lblerror.Text = ""
            dsBolsa = svr.BuscaInstanciaXBolsa(txtfoliobolsa.Text)
            If dsBolsa.Tables(0).Rows.Count = 0 Then
                lblerror.Text = "No existe ese folio de bolsa..."
                btnAceptar.Visible = False
                btnDevolver.Visible = False
            Else

                estadoactual.Text = dsBolsa.Tables(0).Rows(0).Item("EstadoID")
                Select Case dsBolsa.Tables(0).Rows(0).Item("EstadoID")
                    Case estado
                        lblSellada.Visible = True
                        lblForaneo.Visible = False
                        chkbolsasellada.Visible = True
                        chkBolsaForanea.Visible = False

                        btnAceptar.Visible = False
                        btnDevolver.Visible = True

                    Case estado1
                        lblSellada.Visible = True
                        lblForaneo.Visible = False
                        chkbolsasellada.Visible = True
                        chkBolsaForanea.Visible = False

                        btnAceptar.Visible = False
                        btnDevolver.Visible = True

                    Case estado2
                        lblSellada.Visible = False
                        lblForaneo.Visible = True
                        chkbolsasellada.Visible = False
                        chkBolsaForanea.Visible = True

                        btnAceptar.Visible = True
                        btnDevolver.Visible = False

                    Case Else
                        lblerror.Text = "La bolsa no se pude recibir en en centro de distribución..."
                End Select
            End If
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub chkbolsasellada_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkbolsasellada.CheckedChanged
        If chkbolsasellada.Checked Then
            btnaceptar.Visible = True
            btndevolver.Visible = False
        Else
            btnaceptar.Visible = False
            btndevolver.Visible = True
        End If
    End Sub

    Protected Sub btnaceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnaceptar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim dsBolsa As DataSet
        lblerror.Text = ""
        Try

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                LogOff()
            End If

            lblerror.Text = ""
            Select Case estadoactual.Text
                Case estado
                    svr.TransitaInstanciaxBolsa(txtfoliobolsa.Text, eventoOK, "", tTicket.UsrID)
                    lblSellada.Visible = False
                    lblForaneo.Visible = False
                    chkbolsasellada.Checked = False
                    chkBolsaForanea.Visible = False
                    chkbolsasellada.Visible = False
                    btndevolver.Visible = False
                    btnaceptar.Visible = False
                    Response.Redirect("Wfrm_TE_FormatoRecepcion.aspx?Folio_bolsa=" & txtfoliobolsa.Text)
                    txtfoliobolsa.Text = ""
                Case estado1
                    svr.TransitaInstanciaxBolsa(txtfoliobolsa.Text, eventoOK1, "", tTicket.UsrID)
                    lblSellada.Visible = False
                    lblForaneo.Visible = False
                    chkbolsasellada.Checked = False
                    chkBolsaForanea.Visible = False
                    chkbolsasellada.Visible = False
                    btndevolver.Visible = False
                    btnaceptar.Visible = False
                    Response.Redirect("Wfrm_TE_FormatoRecepcion.aspx?Folio_bolsa=" & txtfoliobolsa.Text)
                    txtfoliobolsa.Text = ""
                Case estado2
                    If chkBolsaForanea.Checked Then
                        svr.Actualiza_Foraneo_envio(txtfoliobolsa.Text, 1)
                    Else
                        svr.Actualiza_Foraneo_envio(txtfoliobolsa.Text, 0)
                    End If
                    svr.TransitaInstanciaxBolsa(txtfoliobolsa.Text, eventoOK2, "", tTicket.UsrID)
                    EnviaMail(eventoOK2, txtfoliobolsa.Text)
                    txtfoliobolsa.Text = ""
                    lblSellada.Visible = False
                    lblForaneo.Visible = False
                    chkBolsaForanea.Checked = False
                    chkBolsaForanea.Visible = False
                    chkbolsasellada.Visible = False
                    btndevolver.Visible = False
                    btnaceptar.Visible = False
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

                mensaje = "El folio de la bolsa de seguridad " & Folio_bolsa & " enviado por el operador de archivo al centro de distribución para el usuario " & dsDatosSolicitante.Tables(0).Rows(0).Item("NOMBRE") & " ha sido recibido con exito." & vbNewLine

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

    Protected Sub btndevolver_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btndevolver.Click
        lblerror.Text = ""
        Select Case estadoactual.Text
            Case estado
                Response.Redirect("Wfrm_TE_REchazoBolsaCD.aspx?FolioBolsa=" & txtfoliobolsa.Text & "&estado=" & estado & "&idArchivo=16")
            Case estado1
                Response.Redirect("Wfrm_RE_REchazoBolsaCD.aspx?FolioBolsa=" & txtfoliobolsa.Text & "&estado=" & estado1 & "&idArchivo=16")
            Case Else
                lblerror.Text = "La bolsa no se encuentra en entrega de folios a centro de distribución..."
        End Select
    End Sub
End Class