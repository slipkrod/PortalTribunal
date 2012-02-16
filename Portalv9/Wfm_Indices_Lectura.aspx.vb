Imports DevExpress.Web.ASPxTabControl
Partial Public Class Wfm_Indices_Lectura
    Inherits System.Web.UI.Page

    Private Sub Page_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        AddTabs()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Funciones_Archivo.llenaCamposValor_RO(PnlElementos, Request.QueryString("idArchivo"), Request.QueryString("idSerie"), Request.QueryString("idNorma"), Request.QueryString("idDescripcion"))
            tableIndices.Visible = True
        End If
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        ASPxError.Text = ""
    End Sub

    Sub ShowViewStateControlsIndices()
        aspxEditar.Visible = True
    End Sub

    Protected Sub AddTabs()
        Dim sv As New WSArchivo.Service1
        Dim dsAreas As DataSet
        Dim intI As Integer
        'pgareas.TabPages.Clear()
        If Request.QueryString("idNorma") <> "" Then
            dsAreas = sv.ListaNormas_Elementos_CamposXArea_Serie(-1, Request.QueryString("idSerie"))
            For intI = 0 To dsAreas.Tables(0).Rows.Count - 1
                Funciones_Archivo.CreaTablaElemento_RO(PnlElementos, Page, Request.QueryString("idArchivo"), Request.QueryString("idNorma"), dsAreas.Tables(0).Rows(intI).Item("idArea"), _
                                     dsAreas.Tables(0).Rows(intI).Item("idSerie"))
            Next
        End If
    End Sub





    Protected Sub aspxEditar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxEditar.Click
        Response.Redirect("Wfm_Indices_Editar.aspx?idNorma=" & Request.QueryString("idNorma") & _
        "&idArchivo=" & Request.QueryString("idArchivo") & _
        "&idSerie=" & Request.QueryString("idSerie") & _
        "&idNivel=" & Request.QueryString("idNivel") & _
        "&idDescripcion=" & Request.QueryString("idDescripcion") & "&Logico=0")
    End Sub


End Class