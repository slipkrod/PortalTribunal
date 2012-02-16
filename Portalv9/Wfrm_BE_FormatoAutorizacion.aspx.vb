Imports Portalv9.SvrUsr
Partial Public Class Wfrm_BE_FormatoAutorizacion
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket
    Dim Estado As Integer = 110

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsExpedientes As DataSet

        If Not IsPostBack Then
            Dim txtBolsas() As String
            Dim intI As Integer
            Try

                'Dim objGlobal As New clsGlobal
                'tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
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

                lblfecha.Text = Format(Now.Date, "dd/MM/yyyy")
                lblhora.Text = Now.ToShortTimeString
                lblfolio.Text = Request.QueryString("Folio_destruccion")

                rsExpedientes = svr.BuscaInstanciaExpedientexEstadoDestruccion(Request.QueryString("Folio_destruccion"), Estado)

                For intI = 0 To rsExpedientes.Tables(0).Rows.Count - 1
                    Dim nTableRow As New TableRow
                    Dim nTableCell As New TableCell

                    nTableCell.Text = rsExpedientes.Tables(0).Rows(intI).Item("llave_expediente")
                    nTableRow.Cells.Add(nTableCell)
                    tblFolios.Rows.Add(nTableRow)
                Next

            Catch ex As Exception
                lblerror.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


End Class