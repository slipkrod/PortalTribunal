Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors

Partial Public Class Wfrm_Normas_Organizacion_Series
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            DataBind()
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Private Sub ASPxTreeList1_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListCustomErrorTextEventArgs) Handles ASPxTreeList1.CustomErrorText
        'Dim xError As String
        'xError = e.Exception.InnerException.Message
    End Sub


    Private Sub ASPxTreeList1_NodeInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles ASPxTreeList1.NodeInserting
        e.NewValues("idNorma") = Request.QueryString("idNorma")
        If e.NewValues("idSeriePID") = 0 Then
            e.NewValues("idSeriePID") = Request.QueryString("idSerie")
        End If
    End Sub

    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        Return "~/" & ASPxTreeList1.FindNodeByKeyValue(container.NodeKey).GetValue("Imagen_close")
    End Function

    Private Sub dsLista_SeriesModelo_Hijos_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsLista_SeriesModelo_Hijos.Inserting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim objGlobal As New clsGlobal
        If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
            LogOff()
            Exit Sub
        End If
        e.InputParameters("identidad") = tTicket.PerfilUsuarioID
    End Sub

    Protected Sub dsLista_SeriesModelo_Hijos_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsLista_SeriesModelo_Hijos.Selecting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim objGlobal As New clsGlobal
        If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
            LogOff()
            Exit Sub
        End If
        e.InputParameters("identidad") = tTicket.NoIdentidad
    End Sub
End Class