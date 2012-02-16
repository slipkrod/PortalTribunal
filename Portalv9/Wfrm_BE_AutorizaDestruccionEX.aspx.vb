Imports Portalv9.SvrUsr
Partial Public Class Wfrm_BE_AutorizaDestruccionEX
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket
    Private Const estado As Integer = 110
    Private Const eventoOK As Integer = 111
    Private Const eventoNO As Integer = 113
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblerror.Text = ""
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
                lblfolio.Text = Request.QueryString("Folio_destruccion")
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Sub btnautorizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnautorizar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim intI As Integer
        Dim objGlobal As New clsGlobal
        Dim fecha As DateTime
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
            LogOff()
            Exit Sub
        End If
        fecha = Date.Now
        For intI = 0 To ASPxGridView1.VisibleRowCount - 1
            If ASPxGridView1.Selection.IsRowSelected(intI) Then
                svr.TransitarInstanciaDestruccion(ASPxGridView1.GetDataRow(intI).Item("instanciaID").ToString(), Request.QueryString("Folio_destruccion"), fecha, eventoOK, "", tTicket.UsrID)
            Else
                svr.TransitarInstanciaDestruccion(ASPxGridView1.GetDataRow(intI).Item("instanciaID").ToString(), 0, fecha, eventoNO, "", tTicket.UsrID)
            End If
        Next
        Response.Redirect("Wfrm_BE_FormatoDestruccion.aspx?Folio_destruccion=" & Request.QueryString("Folio_destruccion"))
    End Sub
End Class