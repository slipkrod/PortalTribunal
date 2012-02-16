Public Partial Class Wfrm_Archivo_Fisico_Detalle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ASPxTreeList2_NodeInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles ASPxTreeList2.NodeInserting
        e.NewValues("idArchivo_Fisico") = Request.QueryString("idArchivo_Fisico")
    End Sub


    Protected Sub ASPxTreeList2_NodeUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles ASPxTreeList2.NodeUpdating
    End Sub

    Protected Sub ASPxTreeList2_NodeUpdated(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatedEventArgs) Handles ASPxTreeList2.NodeUpdated
        Dim x As String
    End Sub
End Class