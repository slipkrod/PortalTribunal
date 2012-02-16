Partial Public Class Wfrm_ReporteExpurgos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub


    Protected Sub CargaReporteClick(ByVal sender As Object, ByVal e As EventArgs)

        ReportExpurgos.Report = New RPT_Expurgos(CType(Request("idArchivo"), Integer), CType(DateEditFechaDesde.Text, Date), CType(DateEditFechaHasta.Text, Date))

    End Sub

End Class