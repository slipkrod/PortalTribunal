Imports Portalv9.SvrUsr

Partial Public Class Wfrm_TR_FormatoPerdida
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 105
    Private tTicket As IDTicket
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As DataSet
        Dim svr As New SAEX.ServiciosSAEX
        Dim intI As Integer

        'Introducir aquí el código de usuario para inicializar la página
        If Not IsPostBack Then
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
            ds = svr.BuscaCajaenEstado(Request.QueryString("Folio_caja"), estado)

            lblFecha.Text = Format(Now.Date, "dd/MM/yyyy")
            lblHora.Text = Now.ToShortTimeString

            lblFolio_transito.Text = Request.QueryString("Folio_transito")
            lblCaja.Text = Request.QueryString("Folio_caja")

            For intI = 0 To ds.Tables(0).Rows.Count - 1
                Dim nTableRow As New TableRow
                Dim nTableCell As New TableCell

                nTableCell.Text = ds.Tables(0).Rows(intI).Item("llave_expediente")
                nTableRow.Cells.Add(nTableCell)
                tblFolios.Rows.Add(nTableRow)
            Next
        End If

    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
End Class