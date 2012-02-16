Imports DevExpress.Web.ASPxEditors
Partial Public Class Wfm_Captura_Tipo_expediente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cbSerie_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles cbSerie.Callback
        Try
            Session("idNivel") = e.Parameter.ToString
            dsTipoDeExpediente.Select()
            CType(sender, ASPxComboBox).DataBindItems()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub aspxguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxguardar.Click
        Response.Redirect("Wfm_Indices_Nuevo.aspx?idNorma=" & Request.QueryString("idNorma") & _
                "&idArchivo=" & Request.QueryString("idArchivo") & _
                "&idSerie=" & cbSerie.SelectedItem.Value & _
                "&idNivel=" & dlNiveles.SelectedItem.Value & _
                "&idDescripcion=" & Request.QueryString("idDescripcion") & "&Logico=0" & "&idSeriePadre=" & Request.QueryString("idSerie"))
    End Sub

    Protected Sub aspxCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxCancelar.Click
        Response.Redirect("Wfm_Indices_Lectura.aspx?idNorma=" & Request.QueryString("idNorma") & _
                "&idArchivo=" & Request.QueryString("idArchivo") & _
                "&idSerie=" & Request.QueryString("idSerie") & _
                "&idNivel=" & Request.QueryString("idNivel") & _
                "&idDescripcion=" & Request.QueryString("idDescripcion"))
    End Sub
End Class