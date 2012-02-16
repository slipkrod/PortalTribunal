Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_Bajabolsa
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket
    Private Const estado As Integer = 2
    Private Const eventoOK As Integer = 116

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

    Protected Sub ibtneliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtneliminar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim iRespuesta As SAEX.Respuesta
        Dim nInstancia As New SAEX.clsInstancia
        Dim idInstancia As Integer
        Dim rsEntidadArea As DataSet
        Dim rsExisteBolsa As DataSet
        Dim nRow As DataRow

        lblerror.Text = ""

        If (txtfolio.Text.Trim() = txtcfolio.Text.Trim()) Then
            Validate()
            If IsValid Then
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If tTicket Is Nothing Then
                    LogOff()
                End If
                rsExisteBolsa = svr.BuscaInstanciaXBolsa(txtfolio.Text.Trim())
                If rsExisteBolsa.Tables(0).Rows.Count > 0 Then
                    If rsExisteBolsa.Tables(0).Rows(0).Item("EstadoID") <> estado Then
                        lblerror.Text = "No es posible eliminar una bolsa sellada y enviada."
                    Else
                        TransitaBolsa()
                        Response.Redirect("Wfrm_TE_Aviso.aspx?Aviso=" & Server.UrlEncode("La bolsa  " & txtfolio.Text.Trim() & " ha sido eliminada exitosamente."))
                    End If
                Else
                    lblerror.Text = "La bolsa introducida no existe."
                End If
            End If
        Else
            lblerror.Text = "No son iguales los valores de folio"
        End If
    End Sub
    Private Function TransitaBolsa() As Boolean
        Dim svr As New SAEX.ServiciosSAEX
        Dim intI As Integer
        Dim Fila As DataRow
        Dim dsExpedientes As DataSet
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If tTicket Is Nothing Then
            LogOff()
        End If

        svr.TransitaInstanciaxBolsa(txtfolio.Text.Trim(), eventoOK, "", tTicket.UsrID)
        dsExpedientes = svr.BuscaExpedientedeDocumentosxBolsa(txtfolio.Text.Trim())

        If dsExpedientes.Tables(0).Rows.Count > 0 Then  'Alta de Bolsa
            For Each Fila In dsExpedientes.Tables(0).Rows
                Dim llave As String = Fila(4)
                svr.Actualiza_FolioBolsa_expediente("", llave, estado)
            Next
        End If
    End Function

End Class