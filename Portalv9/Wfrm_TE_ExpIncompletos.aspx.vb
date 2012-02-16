Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_ExpIncompletos
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket
    Private Const eventoOK As Integer = 100

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
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub btnexportar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnexportar.Click
        ASPxGridViewExporter1.GridViewID = "ASPxGridView1"
        ASPxGridViewExporter1.FileName = "ExpedientesIncompletos"
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub
End Class