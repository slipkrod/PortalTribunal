Public Partial Class Wfm_Captura_Expediente_Documentos
    Inherits System.Web.UI.Page
    Dim sv As New WSArchivo.Service1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rdExpediente As DataSet
        If Not IsPostBack Then
            rdExpediente = sv.ListaArchivo_Descripciones_idDescripcion(Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"))
            ASPxLabel1.Text = rdExpediente.Tables(0).Rows(0).Item("Codigo_Clasificacion").ToString
            ASPxLabel2.Text = rdExpediente.Tables(0).Rows(0).Item("Descripcion").ToString
        End If
    End Sub


    Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback

    End Sub

    Protected Sub btnSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalir.Click
        Response.Redirect("Wfrm_Contenido.aspx")
    End Sub

    Protected Sub btnAltaExp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAltaExp.Click
        iframeIndices.Attributes("src") = "Wfm_Captura_Tipo_documento.aspx?idArchivo=" & Request.QueryString("idArchivo") & "&idNorma=" & Request.QueryString("idNorma") & "&idNivel=9" & "&idDescripcion=" & Request.QueryString("idDescripcion") & "&idSerie=" & Request.QueryString("idSerie")
    End Sub
End Class