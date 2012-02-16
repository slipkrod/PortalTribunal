Public Partial Class Wfrm_ReporteCD
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim r As New RPT_CatalogoDisposicion
        Dim sv As New WSArchivo.Service1
        r.DataSource = sv.ListaCatalogo_disposicion(Request.QueryString("idArchivo"), 1, 12)
        r.DefaultPrinterSettingsUsing.UseLandscape = True
        r.PrintingSystem.ShowMarginsWarning = False
        r.PrintingSystem.PageSettings.Landscape = True
        r.PrintingSystem.PageSettings.PaperKind = Drawing.Printing.PaperKind.LetterRotated
        r.CreateDocument()
        Reportgs.Report = r
    End Sub

End Class