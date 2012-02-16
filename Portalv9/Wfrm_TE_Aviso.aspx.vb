Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_Aviso
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

        lblFecha.Text = Now.ToShortDateString & " " & Now.ToShortTimeString
        lblAviso.Text = Request.QueryString("Aviso")
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

End Class