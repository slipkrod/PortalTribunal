Imports Portalv9.SvrUsr
Partial Public Class wfrm_EN_Digitaliza
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 50
    Private Const eventoOK As Integer = 50
    Private tTicket As IDTicket
    Private DocumentosOK As Integer
    Private Const Flujo As Integer = 2


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As DataSet
        Dim dsEnvio As DataSet
        Dim svr As New SAEX.ServiciosSAEX

        Label1.Text = "Contenido del Expediente"
        If Not IsPostBack Then
            Try
                'TBLDiferencias.Visible = False
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
                ds = svr.BuscaExpedientexFolio(Request.QueryString("idFolio"))

                dsEnvio = svr.Obten_EnviosExp(Request.QueryString("Folio_envio"))
                lblidSolicita.Text = dsEnvio.Tables(0).Rows(0).Item("idUsuario_Solicita")
                lblUsuarioSolicita.Text = dsEnvio.Tables(0).Rows(0).Item("Usuario_Solicita")
                lblFechaSolicitud.Text = dsEnvio.Tables(0).Rows(0).Item("Fecha_solicitud")


                ds = svr.BuscaInstancia(Request.QueryString("InstanciaPID"))

                If ds.Tables(0).Rows(0).Item("Confidencial") = "0" Then
                    Label1.Text = "Consulta->Archivo central/Préstamo de expedientes"
                Else
                    Label1.Text = "Consulta->Archivo central/Préstamo de expedientes confidenciales"
                End If

                If ds.Tables(0).Rows(0).Item("Confidencial") = 0 Then
                    lblConfidencial.Text = "No"
                Else
                    lblConfidencial.Text = "Si"
                End If
                lblTipoExpediente.Text = ds.Tables(0).Rows(0).Item("TipoExpediente")
                lblEntidad.Text = ds.Tables(0).Rows(0).Item("Entidad")
                lblidEntidad.Text = ds.Tables(0).Rows(0).Item("idEntidad")
                lblArea.Text = ds.Tables(0).Rows(0).Item("Area")
                lblidArea.Text = ds.Tables(0).Rows(0).Item("idArea")
                lblAno.Text = ds.Tables(0).Rows(0).Item("Anio")
                lblmes.Text = ds.Tables(0).Rows(0).Item("Mes")
                lbldia.Text = ds.Tables(0).Rows(0).Item("Dia")
                lblLlave.Text = ds.Tables(0).Rows(0).Item("Llave_expediente")
                lblIndice.Text = ds.Tables(0).Rows(0).Item("Indice_de_busqueda")
                lblIndiceCampos.Text = ds.Tables(0).Rows(0).Item("Indice_de_busqueda_Campos")
                lblInstancia.Text = ds.Tables(0).Rows(0).Item("InstanciaId")
                lblTipoDocumento.Text = ds.Tables(0).Rows(0).Item("idTipoDocumento")
                lblsecuencia.Text = ds.Tables(0).Rows(0).Item("Secuencia")
                If ds.Tables(0).Rows(0).Item("digitalizado") = 0 Then
                    lblDigitalizado.Text = "No"
                Else
                    lblDigitalizado.Text = "Si"
                End If

            Catch ex As Exception
                Me.lblError.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAceptar.Click
        Validate()
        If IsValid Then
            If GuardaDatos() Then
                If lblConfidencial.Text = "No" Then
                    EnviaMail(eventoOK, 1)
                Else
                    EnviaMail(eventoOK, 3)
                End If
                Response.Redirect("Wfrm_EN_FormatoRecepcion.aspx?Folio_bolsa=" & txtBolsa.Text)
            End If
        End If
    End Sub
    Private Function GuardaDatos() As Boolean
        Dim svr As New SAEX.ServiciosSAEX
        Dim nInstancia As New SAEX.clsInstancia
        GuardaDatos = False
        Try
            Validate()
            If IsValid Then

                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If tTicket Is Nothing Then
                    LogOff()
                End If

                svr.TransitarInstanciaxExpedienteEnvio(Request.QueryString("InstanciaPID"), eventoOK, "", tTicket.UsrID, lblidSolicita.Text, lblidEntidad.Text, lblidArea.Text, txtBolsa.Text, Request.QueryString("Folio_envio"))
                GuardaDatos = True

            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Function
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


            dsDatosSolicitante = svr.ObtieneDatosUsuario_solicitaFolio_envio(Request.QueryString("Folio_envio"))

            rsInstancia = svr.BuscaInstancia(Request.QueryString("InstanciaPID"))

            If rsInstancia.Tables(0).Rows(0).Item("Confidencial") = 1 Then
                Exp_doc = Exp_doc + 1
            End If

            dsMensaje = svr.ObtieneMensajexEvento(evento, Exp_doc)

            If dsMensaje.Tables(0).Rows.Count > 0 Then
                strSubject = dsMensaje.Tables(0).Rows(0).Item("Asunto")

                mensaje = "El folio de la bolsa de seguridad " & txtBolsa.Text & " con el expediente " & lblLLave.Text & " ha sido enviado por el operador de archivo al usuario " & dsDatosSolicitante.Tables(0).Rows(0).Item("NOMBRE") & " a oficina." & vbNewLine

                mensaje = mensaje + dsMensaje.Tables(0).Rows(0).Item("Mensaje")
                dsEnviar = svr.ObtieneMensajeEnviarxEvento(evento, Exp_doc)
                If dsEnviar.Tables(0).Rows.Count > 0 Then
                    dsEmailSolicita = svr.ObtieneDatosUsuario_solicitaFolio_envio(Request.QueryString("Folio_envio"))
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