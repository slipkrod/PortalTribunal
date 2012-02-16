Imports DevExpress.XtraReports.Web
Imports DevExpress.XtraReports.UI
Imports Portalv9.WSArchivo.Service1
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls


Partial Public Class Wfrm_ReporteCGCA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim r As New RPT_CuadroGenearal
        Dim sv As New WSArchivo.Service1
        r.DataSource = sv.Reportecgca_datos(Request.QueryString("idNorma"), Request.QueryString("idArchivo"))
        r.DefaultPrinterSettingsUsing.UseLandscape = True
        r.PrintingSystem.ShowMarginsWarning = False
        r.PrintingSystem.PageSettings.Landscape = True
        r.PrintingSystem.PageSettings.PaperKind = Drawing.Printing.PaperKind.LetterRotated
        r.Parameters("idNorma").Value = Request.QueryString("idNorma")
        r.CreateDocument()
        Reportcgca.Report = r
    End Sub


End Class