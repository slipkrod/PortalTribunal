Imports Portalv9.SvrUsr
Partial Public Class Wfrm_CD_MonitoreoxRecibir
    Inherits System.Web.UI.Page
    Private Const estadoenvio As Integer = 4
    Private Const estadoconsulta As Integer = 52
    Private Const estadorecoleccion As Integer = 83
    Private Const eventoError As Integer = 6
    Private tTicket As IDTicket
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
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
                Me.lblerror.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Sub ObjectDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource1.Selecting
        e.InputParameters("pintEstadoID") = estadoenvio
    End Sub
    Protected Sub ObjectDataSource2_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource2.Selecting
        e.InputParameters("pintEstadoID") = estadoconsulta
    End Sub
    Protected Sub ObjectDataSource3_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource3.Selecting
        e.InputParameters("pintEstadoID") = estadorecoleccion
    End Sub
End Class