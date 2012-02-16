Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_ActasPerdida
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 11
    Private Const eventoLiberarApertura As Integer = 19
    Private Const eventoLiberarIntegra As Integer = 17
    Private Const eventoPerdida As Integer = 16
    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblError.Text = ""
        'Call GetFocusRemesa()
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
                'CargaElementos(estado)


            Catch ex As Exception
                Me.lblError.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub ASPxGridView1_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ASPxGridView1.RowCommand
        Dim svr As New SAEX.ServiciosSAEX
        Select Case e.CommandArgs.CommandName.ToString
            Case "Aceptar"
                If ASPxGridView1.GetRowValues(e.VisibleIndex, "Status_Bolsa").ToString() = "2" Then
                    If svr.ObtenTipoTraslado(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString()) > 0 Then
                        TransitaInstanciaPadre(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoPerdida)
                        TransitaInstanciaHijos(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoPerdida)
                        EnviaMail(eventoPerdida, 1, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), ASPxGridView1.GetRowValues(e.VisibleIndex, "Llave_expediente").ToString())
                    Else
                        TransitaInstanciaHijos(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoPerdida)
                        EnviaMail(eventoPerdida, 3, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), ASPxGridView1.GetRowValues(e.VisibleIndex, "Llave_expediente").ToString())
                    End If
                    ObjectDataSource1.Select()
                Else
                    If svr.ObtenTipoTraslado(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString()) > 0 Then
                        TransitaInstanciaPadre(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoLiberarApertura)
                        TransitaInstanciaHijosLiberacion(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoLiberarApertura)
                    Else
                        TransitaInstanciaHijosLiberacion(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoLiberarIntegra)
                    End If
                    ObjectDataSource1.Select()
                End If
        End Select
    End Sub

    Private Sub EnviaMail(ByVal evento As Integer, ByVal Exp_doc As Integer, ByVal Folio_bolsa As String, ByVal llave_expediente As String)
        Dim dsMensaje As DataSet
        Dim dsEnviar As DataSet
        Dim dsEmails As DataSet
        Dim dsEmailSolicita As DataSet
        Dim dsDatosSolicitante As DataSet
        Dim svr As New SAEX.ServiciosSAEX
        Dim intI As Integer
        Dim strTo, strFrom, strSubject, mensaje As String

        Try

            strFrom = ConfigurationManager.AppSettings("Cuenta_Email")


            dsDatosSolicitante = svr.ObtieneDatosUsuario_solicita(Folio_bolsa)

            If svr.ObtieneConfidencialidadxBolsa(Folio_bolsa) = 1 Then
                Exp_doc = Exp_doc + 1
            End If

            dsMensaje = svr.ObtieneMensajexEvento(evento, Exp_doc)

            If dsMensaje.Tables(0).Rows.Count > 0 Then
                strSubject = dsMensaje.Tables(0).Rows(0).Item("Asunto")

                mensaje = "Se ha generado el acta de perdida por los documentos del expediente " & llave_expediente & " enviado por el usuario " & dsDatosSolicitante.Tables(0).Rows(0).Item("NOMBRE") & "." & vbNewLine


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
    Private Sub TransitaInstanciaPadre(ByVal InstanciaId As Integer, ByVal Folio_bolsa As String, ByVal evento As Integer)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsHijos As DataSet
        Dim intI As Integer
        Dim TransitaPadre As Boolean

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If tTicket Is Nothing Then
            LogOff()
        End If

        TransitaPadre = False
        rsHijos = svr.BuscaSoloDocumentosInstancia(Folio_bolsa, InstanciaId)
        For intI = 0 To rsHijos.Tables(0).Rows.Count - 1
            If rsHijos.Tables(0).Rows(intI).Item("Confirmacion_recibido") = 1 Then
                TransitaPadre = True
            End If
        Next

        If TransitaPadre = False Then
            svr.TransitaInstancia(InstanciaId, evento, "", tTicket.UsrID)
        Else
            svr.TransitaInstancia(InstanciaId, eventoLiberarApertura, "", tTicket.UsrID)
        End If

    End Sub

    Private Sub TransitaInstanciaHijosLiberacion(ByVal InstanciaId As Integer, ByVal Folio_bolsa As String, ByVal evento As Integer)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsHijos As DataSet
        Dim intI As Integer
        Dim rsAtributos As DataSet
        Dim nFila As DataRow

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If tTicket Is Nothing Then
            LogOff()
        End If

        rsHijos = svr.BuscaSoloDocumentosInstancia(Folio_bolsa, InstanciaId)
        For intI = 0 To rsHijos.Tables(0).Rows.Count - 1

            rsAtributos = svr.Obten_Atributos(evento, "CorteInstancia")
            nFila = rsAtributos.Tables(0).NewRow
            nFila.Item("Confirmacion_recibido") = 1
            rsAtributos.Tables(0).Rows.Add(nFila)
            svr.SQLUpdate_Campos_Atributos(rsAtributos, "corteInstancia", rsHijos.Tables(0).Rows(intI).Item("InstanciaId"))
            rsAtributos = Nothing

            svr.TransitaInstancia(rsHijos.Tables(0).Rows(intI).Item("InstanciaId"), evento, "", tTicket.UsrID)
        Next

    End Sub

    Private Sub TransitaInstanciaHijos(ByVal InstanciaId As Integer, ByVal Folio_bolsa As String, ByVal evento As Integer)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsHijos As DataSet
        Dim intI As Integer

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If tTicket Is Nothing Then
            LogOff()
        End If


        rsHijos = svr.BuscaSoloDocumentosInstancia(Folio_bolsa, InstanciaId)
        For intI = 0 To rsHijos.Tables(0).Rows.Count - 1
            If rsHijos.Tables(0).Rows(intI).Item("Confirmacion_recibido") = 1 Then
                svr.TransitaInstancia(rsHijos.Tables(0).Rows(intI).Item("InstanciaId"), eventoLiberarApertura, "", tTicket.UsrID)
            Else
                svr.TransitaInstancia(rsHijos.Tables(0).Rows(intI).Item("InstanciaId"), evento, "", tTicket.UsrID)
            End If
        Next

    End Sub

    Protected Sub ASPxGridView2_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim svr As New SAEX.ServiciosSAEX
        Select Case e.CommandArgs.CommandName.ToString
            Case "Aceptar"
                If ASPxGridView1.GetRowValues(e.VisibleIndex, "Status_Bolsa").ToString() = "2" Then
                    If svr.ObtenTipoTraslado(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString()) > 0 Then
                        TransitaInstanciaPadre(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoPerdida)
                        TransitaInstanciaHijos(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoPerdida)
                        EnviaMail(eventoPerdida, 1, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), ASPxGridView1.GetRowValues(e.VisibleIndex, "Llave_expediente").ToString())
                    Else
                        TransitaInstanciaHijos(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoPerdida)
                        EnviaMail(eventoPerdida, 3, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), ASPxGridView1.GetRowValues(e.VisibleIndex, "Llave_expediente").ToString())
                    End If
                    ObjectDataSource2.Select()
                Else
                    If svr.ObtenTipoTraslado(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString()) > 0 Then
                        TransitaInstanciaPadre(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoLiberarApertura)
                        TransitaInstanciaHijosLiberacion(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoLiberarApertura)
                    Else
                        TransitaInstanciaHijosLiberacion(e.KeyValue, ASPxGridView1.GetRowValues(e.VisibleIndex, "Folio_bolsa").ToString(), eventoLiberarIntegra)
                    End If
                    ObjectDataSource2.Select()
                End If
        End Select
    End Sub
End Class