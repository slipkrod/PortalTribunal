Public Partial Class Wfm_Captura_Tipo_documento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub aspxguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxguardar.Click
        Response.Redirect("Wfm_Captura_Documento_Nuevo_Indices.aspx?idNorma=" & Request.QueryString("idNorma") & _
            "&idArchivo=" & Request.QueryString("idArchivo") & _
            "&idSerie=" & cbSerie.SelectedItem.Value & _
            "&idSeriePadre=" & Request.QueryString("idSerie") & _
            "&idNivel=9" & _
            "&idDescripcion=" & Request.QueryString("idDescripcion") & "&Logico=-1")
    End Sub

    Protected Sub aspxCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxCancelar.Click
        Response.Redirect("Blank_Page.aspx")
    End Sub
End Class