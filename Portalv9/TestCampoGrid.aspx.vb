Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Partial Public Class TestCampoGrid
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CampoMultiSelect1.Catalogo = 16
        CampoMultiSelect1.idArchivo = 1
        CampoMultiSelect1.idDescripcion = 4
    End Sub

    Private Sub ASPxGridView1_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomErrorTextEventArgs) Handles aspxGridCatalogoCampos.CustomErrorText
        Dim xError As String
        xError = e.Exception.Message
    End Sub

    Private Sub dsValores_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsValores.Deleting
        e.InputParameters("idArea") = lblidArea.Text
        e.InputParameters("idElemento") = lblidElemento.Text
        e.InputParameters("idIndice") = lblidIndice.Text
        e.InputParameters("Indice_Tipo") = lblIndice_Tipo.Text
        If e.InputParameters("idNivel") Is Nothing Then
            e.InputParameters("idNivel") = lblidNivel.Text
        End If
        If e.InputParameters("idDescripcion") Is Nothing Then
            e.InputParameters("idDescripcion") = lblidDescripcion.Text
        End If
    End Sub

    Private Sub dsValores_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsValores.Inserting
        e.InputParameters("idArea") = lblidArea.Text
        e.InputParameters("idElemento") = lblidElemento.Text
        e.InputParameters("idIndice") = lblidIndice.Text
        e.InputParameters("Indice_Tipo") = lblIndice_Tipo.Text
        If e.InputParameters("idNivel") Is Nothing Then
            e.InputParameters("idNivel") = lblidNivel.Text
        End If
        If e.InputParameters("idDescripcion") Is Nothing Then
            e.InputParameters("idDescripcion") = lblidDescripcion.Text
        End If
    End Sub
    Private Sub dsValores_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsValores.Updating
        e.InputParameters("idArea") = lblidArea.Text
        e.InputParameters("idElemento") = lblidElemento.Text
        e.InputParameters("idIndice") = lblidIndice.Text
        e.InputParameters("Indice_Tipo") = lblIndice_Tipo.Text
        e.InputParameters("Indice_Tipo") = lblidDescripcion.Text
        If e.InputParameters("idNivel") Is Nothing Then
            e.InputParameters("idNivel") = lblidNivel.Text
        End If
        If e.InputParameters("idDescripcion") Is Nothing Then
            e.InputParameters("idDescripcion") = lblidDescripcion.Text
        End If
    End Sub

    Protected Sub dsValores_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsValores.Selecting
        e.InputParameters("idArea") = lblidArea.Text
        e.InputParameters("idElemento") = lblidElemento.Text
        e.InputParameters("idIndice") = lblidIndice.Text
    End Sub

    Protected Sub dsCatalogoDatos_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsCatalogoDatos.Selecting
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub aspxGridCatalogoCampos_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs) Handles aspxGridCatalogoCampos.BeforePerformDataSelect
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub aspxGridCatalogoCampos_HtmlEditFormCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewEditFormEventArgs) Handles aspxGridCatalogoCampos.HtmlEditFormCreated
        Try
            If aspxGridCatalogoCampos.IsEditing Then
                If aspxGridCatalogoCampos.IsNewRowEditing Then
                    CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCatalogos"), ASPxComboBox).Items.FindByValue(Integer.Parse(lblCatalogo.Text)).Selected = True
                End If
                'If CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCatalogos"), ASPxComboBox).Items.Count < 1 Then
                '    CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCatalogos"), ASPxComboBox).DataBind()
                'End If
                CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("lblCatalogo"), Label).Text = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCatalogos"), ASPxComboBox).SelectedItem.Text
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Protected Sub aspxGridCatalogoCampos_HtmlRowCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs) Handles aspxGridCatalogoCampos.HtmlRowCreated
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub aspxGridCatalogoCampos_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs) Handles aspxGridCatalogoCampos.HtmlRowPrepared
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dsCatalogoDatos_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsCatalogoDatos.Selected
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class