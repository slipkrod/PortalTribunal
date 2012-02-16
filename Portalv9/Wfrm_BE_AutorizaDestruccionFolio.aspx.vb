Imports Portalv9.SvrUsr
Partial Public Class Wfrm_BE_AutorizaDestruccionFolio
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
                    LogOff()
                    Exit Sub
                End If
                Dim strRes As String = Session("DebeCambiarPwd")
                If strRes <> String.Empty Then
                    If CType(strRes, Boolean) = True Then
                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                    End If
                End If
                'CargaElementos()

            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

End Class