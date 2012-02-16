Imports DevExpress.Web.ASPxTreeList

Partial Public Class Wfm_Captura_Expediente_Serie
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        If container.Expanded Then
            Return container.GetValue("Imagen_Open")
        Else
            Return container.GetValue("Imagen_Close")
        End If
    End Function



    Protected Sub aspxguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxguardar.Click
        If aspxtreenivel.FocusedNode.DataItem("idNivel") < "5" Then
            MsgBox1.ShowMessage("Debe seleccionar una Serie o Subserie")
        Else
            'Response.Redirect("Wfm_Indices_Nuevo.aspx")
            Response.Redirect("Wfm_Captura_Expediente_Nuevo_Indices.aspx?idNorma=" & Request.QueryString("idNorma") & _
                "&idArchivo=" & aspxtreenivel.FocusedNode.GetValue("idArchivo") & _
                "&idSerie=" & cbSerie.SelectedItem.Value & _
                "&idSeriePadre=" & aspxtreenivel.FocusedNode.GetValue("idSerie") & _
                "&idNivel=8" & _
                "&idDescripcion=" & aspxtreenivel.FocusedNode.GetValue("idDescripcion") & "&Logico=-1")
        End If
    End Sub

    Protected Sub aspxCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxCancelar.Click
        Response.Redirect("Blank_Page.aspx")
    End Sub
End Class