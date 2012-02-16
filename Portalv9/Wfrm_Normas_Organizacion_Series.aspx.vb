Imports Portalv9.SvrUsr
Partial Public Class Wfrm_Normas_Organizacion_Series1
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Administración->Unidad Documental Compuesta - Subserie"
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
            DataBind()
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Sub gdSeries_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomErrorTextEventArgs) Handles gdSeries.CustomErrorText
        'Dim xError As String
        'xError = e.Exception.InnerException.Message
    End Sub

    Private Sub dsLista_SeriesModelo_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsLista_SeriesModelo.Inserting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim objGlobal As New clsGlobal
        If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
            LogOff()
            Exit Sub
        End If
        e.InputParameters("identidad") = tTicket.PerfilUsuarioID
    End Sub

    Protected Sub dsLista_SeriesModelo_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsLista_SeriesModelo.Selecting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        e.InputParameters("identidad") = tTicket.NoIdentidad
    End Sub
End Class