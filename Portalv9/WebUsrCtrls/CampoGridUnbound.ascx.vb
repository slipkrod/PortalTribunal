Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Partial Public Class CampoGridUnbound
    Inherits System.Web.UI.UserControl

    Public Show_Parents As Boolean = False
    Private Shared dtDatosGrid As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dtDatosGrid.Clear()
            If dtDatosGrid.Columns.Count = 0 Then
                Dim pkCampoIDFolio As DataColumn = dtDatosGrid.Columns.Add("idFolio", Type.GetType("System.Int32"))
                pkCampoIDFolio.AutoIncrement = True
                pkCampoIDFolio.AutoIncrementSeed = 1
                pkCampoIDFolio.AutoIncrementStep = 1

                dtDatosGrid.PrimaryKey = New DataColumn() {pkCampoIDFolio}
                dtDatosGrid.Columns.Add("idNorma", Type.GetType("System.Int32"))
                dtDatosGrid.Columns.Add("idArea", Type.GetType("System.Int32"))
                dtDatosGrid.Columns.Add("idElemento", Type.GetType("System.Int32"))
                dtDatosGrid.Columns.Add("idIndice", Type.GetType("System.Int32"))
                dtDatosGrid.Columns.Add("idArchivo", Type.GetType("System.Int32"))
                dtDatosGrid.Columns.Add("idDescripcion", Type.GetType("System.Int32"))
                dtDatosGrid.Columns.Add("idNivel", Type.GetType("System.Int32"))
                dtDatosGrid.Columns.Add("Indice_Tipo", Type.GetType("System.Int32"))
                dtDatosGrid.Columns.Add("relacion_con_normaPID", Type.GetType("System.Int32"))
                dtDatosGrid.Columns.Add("IDCatalogo_item", Type.GetType("System.Int32"))
                dtDatosGrid.Columns.Add("Valor", Type.GetType("System.Int32"))
                dtDatosGrid.Columns.Add("idSerie", Type.GetType("System.Int32"))
            End If


            If lblidDescripcion.Text = "-1" Then
            Else
                Dim dvValores As DataView
                Dim intI As Integer
                dsValores.SelectParameters("idNorma").DefaultValue = Request.QueryString("idNorma")
                dsValores.SelectParameters("idArea").DefaultValue = lblidArea.Text
                dsValores.SelectParameters("idElemento").DefaultValue = lblidElemento.Text
                dsValores.SelectParameters("idIndice").DefaultValue = lblidIndice.Text
                dsValores.SelectParameters("idArchivo").DefaultValue = Request.QueryString("idArchivo")
                dsValores.SelectParameters("idDescripcion").DefaultValue = lblidDescripcion.Text
                dvValores = dsValores.Select()
                For intI = 0 To dvValores.Table.Rows.Count - 1
                    Dim Row As DataRow = dtDatosGrid.NewRow()
                    Row.Item("idFolio") = dvValores.Table.Rows(intI).Item("idFolio")
                    Row.Item("IDCatalogo_item") = dvValores.Table.Rows(intI).Item("IDCatalogo_item")
                    Row.Item("Valor") = dvValores.Table.Rows(intI).Item("Valor")
                    dtDatosGrid.Rows.Add(Row)
                Next
                aspxGridCatalogoCampos.DataSource = dtDatosGrid
                aspxGridCatalogoCampos.DataBind()
            End If


            Session(Me.ID) = dtDatosGrid
        Else
            dtDatosGrid = Session(Me.ID)
        End If
    End Sub

    Public Shared Property SelectedItems() As DataTable
        Get
            Return dtDatosGrid
        End Get
        Set(ByVal value As DataTable)
            dtDatosGrid = value
        End Set
    End Property


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

    Private Sub dsValores_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsValores.Deleting

        If e.InputParameters("idDescripcion") Is Nothing Then
            e.InputParameters("idDescripcion") = 0
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
        If IsPostBack Or Page.IsCallback Then
            dtDatosGrid = CType(Session(Me.ID), DataTable)
            CType(sender, ASPxGridView).DataSource = dtDatosGrid
            CType(sender, ASPxGridView).KeyFieldName = "idFolio"
        End If
    End Sub


    Protected Sub aspxGridCatalogoCampos_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxGridCatalogoCampos.RowInserting
        Try
            dtDatosGrid = CType(Session(Me.ID), DataTable)
            Dim Row As DataRow = dtDatosGrid.NewRow()
            Row.Item("IDCatalogo_item") = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCampoAll"), ASPxComboBox).SelectedItem.Value
            Row.Item("Valor") = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("speValor"), ASPxSpinEdit).Number
            dtDatosGrid.Rows.Add(Row)
            CType(sender, ASPxGridView).CancelEdit()
            e.Cancel = True

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub aspxGridCatalogoCampos_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles aspxGridCatalogoCampos.RowUpdating
        dtDatosGrid = CType(Session(Me.ID), DataTable)
        Dim Row As DataRow = dtDatosGrid.Rows.Find(e.Keys(CType(sender, ASPxGridView).KeyFieldName))
        Row.Item("Valor") = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("speValor"), ASPxSpinEdit).Number
        CType(sender, ASPxGridView).CancelEdit()
        e.Cancel = True
    End Sub


    Protected Sub aspxGridCatalogoCampos_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxGridCatalogoCampos.RowValidating
        Dim x As String
        Dim intI As Integer
        If e.IsNewRow Then
            x = CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCampoAll"), ASPxComboBox).SelectedItem.Value
            For intI = 0 To aspxGridCatalogoCampos.VisibleRowCount - 1
                If CType(aspxGridCatalogoCampos.FindEditFormTemplateControl("cmbCampoAll"), ASPxComboBox).SelectedItem.Value = aspxGridCatalogoCampos.GetRowValues(intI, "IDCatalogo_item") Then
                    e.Errors.Add(aspxGridCatalogoCampos.Columns("IDCatalogo_item"), "El tipo de campo ya existe.")
                    e.RowError = "El tipo de campo ya existe."
                End If
            Next
        End If
    End Sub


    Protected Sub aspxGridCatalogoCampos_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles aspxGridCatalogoCampos.RowDeleting
        e.Cancel = True
        dtDatosGrid = CType(Session(Me.ID), DataTable)
        dtDatosGrid.Rows.Remove(dtDatosGrid.Rows.Find(e.Keys(CType(sender, ASPxGridView).KeyFieldName)))
    End Sub

    Protected Sub aspxGridCatalogoCampos_ParseValue(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxParseValueEventArgs) Handles aspxGridCatalogoCampos.ParseValue
        If e.FieldName = "idFolio" And e.Value = Nothing Then
            e.Value = 0
        End If
    End Sub

    Public Sub GrabaDatos_Archivo(ByVal idArchivo As Integer, ByVal idDescripcion As Integer, ByVal idNorma As Integer, ByVal idNivel As Integer, ByVal idSerie As Integer, ByVal idArea As Integer, ByVal idElemento As Integer, ByVal idIndice As Integer, ByVal idFolio As Integer, ByVal relacion_con_normaPID As Integer)
        Dim intI As Integer

        dsValores.DeleteParameters("op").DefaultValue = 3
        dsValores.DeleteParameters("idNorma").DefaultValue = idNorma
        dsValores.DeleteParameters("idArea").DefaultValue = idArea
        dsValores.DeleteParameters("idElemento").DefaultValue = idElemento
        dsValores.DeleteParameters("idIndice").DefaultValue = idIndice
        dsValores.DeleteParameters("idArchivo").DefaultValue = idArchivo
        dsValores.DeleteParameters("idDescripcion").DefaultValue = idDescripcion
        dsValores.DeleteParameters("idFolio").DefaultValue = idFolio
        dsValores.DeleteParameters("idNivel").DefaultValue = idNivel
        dsValores.DeleteParameters("idSerie").DefaultValue = idSerie
        dsValores.DeleteParameters("relacion_con_normaPID").DefaultValue = relacion_con_normaPID
        dsValores.DeleteParameters("Valor").DefaultValue = 0
        dsValores.DeleteParameters("Indice_Tipo").DefaultValue = lblIndice_Tipo.Text
        dsValores.DeleteParameters("IDCatalogo_item").DefaultValue = 0

        dsValores.Delete()


        dtDatosGrid = CType(Session(Me.ID), DataTable)
        For intI = 0 To dtDatosGrid.Rows.Count - 1
            dsValores.InsertParameters("op").DefaultValue = 0
            dsValores.InsertParameters("idArchivo").DefaultValue = idArchivo
            dsValores.InsertParameters("idDescripcion").DefaultValue = idDescripcion
            dsValores.InsertParameters("idNorma").DefaultValue = idNorma
            dsValores.InsertParameters("idNivel").DefaultValue = idNivel
            dsValores.InsertParameters("idSerie").DefaultValue = idSerie
            dsValores.InsertParameters("idArea").DefaultValue = idArea
            dsValores.InsertParameters("idElemento").DefaultValue = idElemento
            dsValores.InsertParameters("idIndice").DefaultValue = idIndice
            dsValores.InsertParameters("relacion_con_normaPID").DefaultValue = relacion_con_normaPID
            dsValores.InsertParameters("Indice_Tipo").DefaultValue = lblIndice_Tipo.Text

            dsValores.InsertParameters("idFolio").DefaultValue = dtDatosGrid.Rows(intI).Item("idFolio")
            dsValores.InsertParameters("IDCatalogo_item").DefaultValue = dtDatosGrid.Rows(intI).Item("IDCatalogo_item")
            dsValores.InsertParameters("Valor").DefaultValue = dtDatosGrid.Rows(intI).Item("Valor")

            dsValores.Insert()
        Next
    End Sub

    Protected Sub dsValores_Deleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsValores.Deleted
        If Not e.Exception Is Nothing Then
            Dim xerror As String
            xerror = e.Exception.Message
        End If
    End Sub

    Protected Sub dsValores_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsValores.Inserted
        If Not e.Exception Is Nothing Then
            Dim xerror As String
            xerror = e.Exception.Message
        End If
    End Sub

    Protected Sub dsValores_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsValores.Inserting

    End Sub
End Class