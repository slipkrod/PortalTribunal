Imports System.IO
Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports System.Collections.Generic
Imports DevExpress.Web.ASPxClasses
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls



Partial Public Class Wfrm_Archivo_Series
    Inherits System.Web.UI.Page

    Public tTicket As IDTicket

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

    Private Sub ASPxTreeList1_CommandColumnButtonInitialize(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListCommandColumnButtonEventArgs) Handles ASPxTreeList1.CommandColumnButtonInitialize
        If Not e.NodeKey Is Nothing Then
            If ASPxTreeList1.FindNodeByKeyValue(e.NodeKey).ParentNode.Key = ASPxTreeList1.RootNode.Key Then
                If e.ButtonType = TreeListCommandColumnButtonType.Delete Then
                    e.Visible = DevExpress.Web.ASPxClasses.DefaultBoolean.False
                End If
                If e.ButtonType = TreeListCommandColumnButtonType.Edit Then
                    e.Visible = DevExpress.Web.ASPxClasses.DefaultBoolean.False
                End If
            End If
        End If
    End Sub
    Private Sub ASPxTreeList1_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListCustomErrorTextEventArgs) Handles ASPxTreeList1.CustomErrorText
        ' Dim xError As String
        ' xError = e.Exception.InnerException.Message
    End Sub

    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        'Return "~/" & ASPxTreeList1.FindNodeByKeyValue(container.NodeKey).GetValue("imagen_close")
    End Function


    Protected Sub dsListaFondo_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsListaFondo.Selecting
        ' tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        ' Dim objGlobal As New clsGlobal
        ' If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
        ' LogOff()
        ' Exit Sub
        ' End If
        ' e.InputParameters("identidad") = tTicket.NoIdentidad

    End Sub

    Protected Sub ASPxTreeList1_VirtualModeNodeCreating1(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListVirtualModeNodeCreatingEventArgs) Handles ASPxTreeList1.VirtualModeNodeCreating
        Dim rowView As DataRowView = e.NodeObject
        If rowView Is Nothing Then Return
        e.NodeKeyValue = rowView("idDescripcion")
        e.SetNodeValue("idSerie", rowView("idSerie"))
        e.SetNodeValue("Descripcion", rowView("Descripcion"))
        e.SetNodeValue("idDocumentoPID", rowView("idDocumentoPID"))
        e.SetNodeValue("Imagen_open", rowView("Imagen_open"))
        e.SetNodeValue("Imagen_close", rowView("Imagen_close"))
    End Sub

    Protected Sub ASPxTreeList1_VirtualModeCreateChildren1(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListVirtualModeCreateChildrenEventArgs) Handles ASPxTreeList1.VirtualModeCreateChildren
        Dim children As DataView = Nothing
        Dim parent As DataRowView = e.NodeObject
        If parent Is Nothing Then
            children = CType(SqlDataSource2.Select(DataSourceSelectArguments.Empty), DataView)
        Else
            SqlDataSource1.SelectParameters("idDocumentoPID").DefaultValue = parent("idDescripcion").ToString()
            children = CType(SqlDataSource1.Select(DataSourceSelectArguments.Empty), DataView)
        End If
        e.Children = children
    End Sub
End Class
