Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_FormatoEntrega
    Inherits System.Web.UI.Page

    Private tTicket As IDTicket
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página

        If Not IsPostBack Then
            Dim txtBolsas() As String
            Dim intI As Integer
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

                If objGlobal.TicketValido(tTicket) Then  'Is Nothing Then
                    lblEntrega.Text = tTicket.NoIdentidad & " - " & tTicket.NombreCompleto
                End If

                If Request.QueryString("Ubicacion") = "0" Then
                    lblTitle.Text = "Formato de recepción de folios"
                    lblObservaciones.Text = "Para entrega a centro de distribución."
                Else
                    lblTitle.Text = "Formato de recepción de folios"
                    lblObservaciones.Text = "Para entrega a archivo central."
                End If

                lblFecha.Text = Format(Now.Date, "yyyyMMdd")
                lblHora.Text = Now.ToShortTimeString
                lblMensajeria.Text = Request.QueryString("Mensajeria").ToUpper

                txtBolsas = Split(Request.QueryString("Bolsas"), ",")

                For intI = 0 To UBound(txtBolsas)
                    Dim nTableRow As New TableRow
                    Dim nTableCell As New TableCell

                    nTableCell.Text = txtBolsas(intI)
                    nTableRow.Cells.Add(nTableCell)
                    tblFolios.Rows.Add(nTableRow)
                Next

            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


End Class