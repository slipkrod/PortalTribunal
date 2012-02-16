Imports Portalv9.SvrUsr
Partial Public Class wfrmPrestamosBuscador
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            Catch ex As Exception

            End Try
        Else
            '            mostrar()

        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1
        If Not txtPalabra.Text Is Nothing Then
            dgExpedientes.DataSource = sv.BuscaExpedientesPrestamos(cmbArchivo.SelectedItem.Value, txtPalabra.Text)
            dgExpedientes.DataBind()
        End If

    End Sub

    Protected Sub detailGrid_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs)
        Dim idExpediente As Integer = dgExpedientes.GetRowValues(Convert.ToInt32(e.Parameters), "idDescripcion")
        If idExpediente > 0 Then
            Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1
            detailGrid.DataSource = sv.BuscaDocumentosPorExpedientesPrestamos(idExpediente)
            detailGrid.DataBind()
            Session("idExpediente") = idExpediente
            Session("nombreArchivo") = cmbArchivo.Text
        End If
    End Sub

    Protected Sub SolicitarPrestamoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("wfrm_Prestamos_Alta_Solicitud.aspx")
    End Sub

End Class