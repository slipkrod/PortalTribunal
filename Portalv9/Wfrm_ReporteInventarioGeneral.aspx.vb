Partial Public Class Wfrm_ReporteInventarioGeneral
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ReportInventario.Report = New RPT_InventarioGeneral(CType(Request("idArchivo"), Integer))

    End Sub

End Class