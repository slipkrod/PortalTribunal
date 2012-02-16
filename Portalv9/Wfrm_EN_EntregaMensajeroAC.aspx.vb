Imports Portalv9.SvrUsr
Partial Public Class Wfrm_EN_EntregaMensajeroAC
    Inherits System.Web.UI.Page

    Private Const estado As Integer = 51
    Private Const eventoOK As Integer = 51
    Private tTicket As IDTicket
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        Me.lblerror.Text = ""
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
                txtmensajeria.Focus()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End If
    End Sub
    Protected Sub btagregar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btagregar.Click
        Dim nItem As ListItem
        Dim svr As New SAEX.ServiciosSAEX
        Dim dsBolsa As DataSet
        Dim newItem As New ListItem

        lblerror.Text = ""
        If txtFolioBolsa.Text <> "" Then
            nItem = lbbolsas.Items.FindByText(txtFolioBolsa.Text)
            If nItem Is Nothing Then
                dsBolsa = svr.BuscaInstanciaXBolsa(txtFolioBolsa.Text)
                If dsBolsa.Tables(0).Rows.Count = 0 Then
                    lblerror.Text = "No existe ese folio de bolsa..."
                Else
                    If dsBolsa.Tables(0).Rows(0).Item("EstadoID") = estado Then

                        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                        If tTicket Is Nothing Then
                            LogOff()
                        End If

                        newItem.Text = txtFolioBolsa.Text
                        newItem.Value = txtFolioBolsa.Text
                        lbbolsas.Items.Add(newItem)
                        txtFolioBolsa.Text = ""
                        SetFocus(txtFolioBolsa)
                    Else
                        lblerror.Text = "La bolsa no se encuentra con el usuario para entrega a mensajería..."
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Sub btquitar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btquitar.Click
        lbbolsas.Items.Remove(lbbolsas.SelectedItem)
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

    Protected Sub ibtnaceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnaceptar.Click
        Dim intI As Integer
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsAtributos As DataSet
        Dim nFila As DataRow
        Dim valores As String
        Dim NumValija As Integer
        Try
            lblerror.Text = ""

            If (txtmensajeria.Text <> "") Then
                Validate()
                If IsValid Then

                    If lbbolsas.Items.Count > 0 Then
                        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                        If tTicket Is Nothing Then
                            LogOff()
                        End If

                        rsAtributos = svr.Obten_Atributos(eventoOK, "Valija")
                        nFila = rsAtributos.Tables(0).NewRow
                        nFila.Item("NumValija") = 0
                        nFila.Item("Fecha") = Now.Date
                        nFila.Item("Mensajeria") = txtmensajeria.Text
                        nFila.Item("Observaciones") = ""
                        rsAtributos.Tables(0).Rows.Add(nFila)
                        NumValija = svr.SQLInsert_Campos_Atributos(rsAtributos, "Valija")

                        For intI = 0 To lbbolsas.Items.Count - 1
                            svr.Actualiza_ValijaxBolsa(tTicket.NoIdentidad, txtmensajeria.Text, NumValija, lbbolsas.Items(intI).Value)
                            svr.TransitaInstanciaxBolsa(lbbolsas.Items(intI).Value, eventoOK, "", tTicket.UsrID)
                            EnviaMail(eventoOK, lbbolsas.Items(intI).Value)
                        Next

                        For intI = 0 To lbbolsas.Items.Count - 1
                            valores = valores & lbbolsas.Items(intI).Text & ","
                        Next
                        valores = valores.Substring(0, valores.Length - 1)
                        Response.Redirect("Wfrm_EN_FormatoEntrega.aspx?Bolsas=" & valores & "&Mensajeria=" & Server.UrlEncode(txtmensajeria.Text) & "&Ubicacion=0" & "&Valija=" & NumValija)
                    Else
                        lblerror.Text = "No existen bolsas seleccionadas para entregar a la mensajería..."
                    End If
                End If

            Else
                lblerror.Text = "La mensajería no puede ir vacía..."
            End If
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub
End Class