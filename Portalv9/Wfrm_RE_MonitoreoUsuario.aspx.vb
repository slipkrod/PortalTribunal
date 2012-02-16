Imports Portalv9.SvrUsr
Partial Public Class Wfrm_RE_MonitoreoUsuario
    Inherits System.Web.UI.Page

    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                lblnoid.Text = tTicket.NoIdentidad
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
                'Me.lblError.Text = ex.Message
            End Try
        Else
            If ASPxGridView2.Columns.Count > 0 Then
                ASPxGridView2.Visible = True
            Else
                ASPxGridView2.Visible = False
            End If
        End If

    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Sub ObjectDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource1.Selecting
        e.InputParameters("NoIdentidad") = lblnoid.Text
    End Sub

    Protected Sub ObjectDataSource2_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource2.Selecting
        e.InputParameters("NoIdentidad") = lblnoid.Text
    End Sub

End Class