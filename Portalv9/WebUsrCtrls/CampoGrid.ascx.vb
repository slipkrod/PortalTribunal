Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Partial Public Class CampoGrid
    Inherits System.Web.UI.UserControl

    Public Show_Parents As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
        End If
    End Sub

    Public Property TextoCampo() As String
        Get
            Return Campo.Text
        End Get
        Set(ByVal value As String)
            Campo.Text = value
        End Set
    End Property

    Public Property Muestra_Campo() As Boolean
        Get
            Return tdCampo.Visible
        End Get
        Set(ByVal value As Boolean)
            tdCampo.Visible = value
        End Set
    End Property

    Public Property TextoPadres() As String
        Get
            Return Texto_Padres.Text
        End Get
        Set(ByVal value As String)
            Texto_Padres.Text = value
        End Set
    End Property

    Public Property Muestra_Padres() As Boolean
        Get
            Return Show_Parents
        End Get
        Set(ByVal value As Boolean)
            Show_Parents = value
            tdTexto_Padres.Visible = value
        End Set
    End Property

    Public Property Catalogo() As String
        Get
            Return lblCatalogo.Text
        End Get
        Set(ByVal value As String)
            lblCatalogo.Text = value
        End Set
    End Property

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

    Public Property idArea() As String
        Get
            Return lblidArea.Text
        End Get
        Set(ByVal value As String)
            lblidArea.Text = value
        End Set
    End Property

    Public Property idElemento() As String
        Get
            Return lblidElemento.Text
        End Get
        Set(ByVal value As String)
            lblidElemento.Text = value
        End Set
    End Property

    Public Property idIndice() As String
        Get
            Return lblidIndice.Text
        End Get
        Set(ByVal value As String)
            lblidIndice.Text = value
        End Set
    End Property

    Public Property idDescripcion() As String
        Get
            Return lblidDescripcion.Text
        End Get
        Set(ByVal value As String)
            lblidDescripcion.Text = value
        End Set
    End Property

    Public Property idNivel() As String
        Get
            Return lblidNivel.Text
        End Get
        Set(ByVal value As String)
            lblidNivel.Text = value
        End Set
    End Property

    Public Property Indice_Tipo() As String
        Get
            Return lblIndice_Tipo.Text
        End Get
        Set(ByVal value As String)
            lblIndice_Tipo.Text = value
        End Set
    End Property

    Protected Sub aspxGridCatalogoCampos_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs) Handles aspxGridCatalogoCampos.BeforePerformDataSelect
        Try
            dsValores.SelectParameters.Item("idNorma").DefaultValue=Request.QueryString("idNorma")
            dsValores.SelectParameters.Item("idArea").DefaultValue=lblidArea.Text
            dsValores.SelectParameters.Item("idElemento").DefaultValue=lblidElemento.Text
            dsValores.SelectParameters.Item("idIndice").DefaultValue=lblidIndice.Text
            dsValores.SelectParameters.Item("idArchivo").DefaultValue=Request.QueryString("idArchivo")
            dsValores.SelectParameters.Item("idDescripcion").DefaultValue=Request.QueryString("idDescripcion")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub aspxGridCatalogoCampos_HtmlEditFormCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewEditFormEventArgs) Handles aspxGridCatalogoCampos.HtmlEditFormCreated
        Try
            If aspxGridCatalogoCampos.IsEditing Then
                If aspxGridCatalogoCampos.IsNewRowEditing Then

                Else
                    'CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCampo"), ASPxComboBox).Items.Add("22", "1121")
                    Select Case lblTipoValor.Text
                        Case "6"
                            If CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbValor"), ASPxComboBox).SelectedIndex < 0 Then
                                CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbValor"), ASPxComboBox).Items.FindByValue( _
                                    Integer.Parse(CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("txtValor"), ASPxTextBox).Text)).Selected = True
                            End If
                        Case "2"
                            If CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("daeValor"), ASPxDateEdit).Date.ToString() = "01/01/0001 12:00:00 a.m." Then
                                CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("daeValor"), ASPxDateEdit).Date = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("txtValor"), ASPxTextBox).Text
                            End If
                        Case "7"
                            If CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("speValor"), ASPxSpinEdit).Number < 1 Then
                                CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("speValor"), ASPxSpinEdit).Number = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("txtValor"), ASPxTextBox).Text
                            End If
                    End Select
                End If
                CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCatalogos"), ASPxComboBox).Items.FindByValue(Integer.Parse(lblCatalogo.Text)).Selected = True
                CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("lblCatalogo"), Label).Text = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCatalogos"), ASPxComboBox).SelectedItem.Text
                CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("lblTipoValor"), ASPxLabel).Text = lblTipoValor.Text
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function GeneraValor(ByVal sValor As Object, ByVal sTipoDatos As Object)
        If sValor Is DBNull.Value Then sValor = ""
        Select Case sTipoDatos.ToString()
            Case "6"
                Return IIf(sValor = "0", "No", "Si")
            Case "2"
                Return Date.Parse(sValor).ToString("dd/mmm/yyyy")
            Case Else
                Return sValor
        End Select

    End Function

    Protected Sub dsCatalogoDatos_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsCatalogoDatos.Selected

    End Sub

    Protected Sub aspxGridCatalogoCampos_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxGridCatalogoCampos.RowInserting
        Try
            Dim bMovie As Boolean = False
            If e.NewValues("Valor") Is Nothing Then
                bMovie = True
            Else
                If String.IsNullOrEmpty(e.NewValues("Valor")) Then bMovie = True
            End If
            If bMovie Then
                Select Case lblTipoValor.Text
                    Case "6"
                        e.NewValues("Valor") = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbValor"), ASPxComboBox).SelectedItem.Value
                    Case "2"
                        e.NewValues("Valor") = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("daeValor"), ASPxDateEdit).Date
                    Case "7"
                        e.NewValues("Valor") = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("speValor"), ASPxSpinEdit).Number
                    Case Else
                        e.NewValues("Valor") = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("txtValor"), ASPxTextBox).Text
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub aspxGridCatalogoCampos_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles aspxGridCatalogoCampos.RowUpdating
        Try
            Select Case lblTipoValor.Text
                Case "6"
                    e.NewValues("Valor") = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbValor"), ASPxComboBox).SelectedItem.Value
                Case "2"
                    e.NewValues("Valor") = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("daeValor"), ASPxDateEdit).Date
                Case "7"
                    e.NewValues("Valor") = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("speValor"), ASPxSpinEdit).Number
                Case Else
                    e.NewValues("Valor") = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("txtValor"), ASPxTextBox).Text
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub aspxGridCatalogoCampos_HtmlCommandCellPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableCommandCellEventArgs) Handles aspxGridCatalogoCampos.HtmlCommandCellPrepared
    End Sub

    Protected Sub dsValores_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsValores.Selected
    End Sub

    Protected Sub dsCatalogoDatosAll_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsCatalogoDatosAll.Selected
        Try
            lblTipoValor.Text = DirectCast(DirectCast(e.ReturnValue, System.Object), System.Data.DataSet).Tables(0).Rows(0)("Tipo_Dato")
        Catch ex As Exception
        End Try
        Try
            lblValores_Aceptados.Text = DirectCast(DirectCast(e.ReturnValue, System.Object), System.Data.DataSet).Tables(0).Rows(0)("Valores_Aceptados")
            If lblValores_Aceptados.Text = -1 Then
                lblValores_Aceptados.Text = DirectCast(DirectCast(e.ReturnValue, System.Object), System.Data.DataSet).Tables(0).Rows.Count
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub aspxGridCatalogoCampos_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxGridCatalogoCampos.RowValidating
        Dim x As String
        Dim intI As Integer
        If e.IsNewRow Then
            x = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCampoAll"), ASPxComboBox).SelectedItem.Value
            For intI = 0 To aspxGridCatalogoCampos.VisibleRowCount - 1
                If CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCampoAll"), ASPxComboBox).SelectedItem.Value = aspxGridCatalogoCampos.GetRowValues(intI, "IDCatalogo_item") Then
                    e.Errors.Add(aspxGridCatalogoCampos.Columns("IDCatalogo_item"), "El tipo de campo ya existe.")
                End If
            Next
        End If


    End Sub


End Class