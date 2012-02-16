Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxClasses
Imports DevExpress.Web.ASPxCallbackPanel

Partial Public Class Wfrm_TipoExpediente_Indices
    Inherits System.Web.UI.Page
    Dim svr As New WSArchivo.Service1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sv As New WSArchivo.Service1
        If sv.Func_Suma_IndicesSistemaXNorma(-1, Request.QueryString("idNorma")).Tables(0).Rows(0)(0) > 0 Then
            Response.Write("<SCRIPT language='JavaScript'>alert('Antes de accesar a esta seccion debe asignar todos los indices de sistemas');window.location='Wfrm_Normas.aspx';</SCRIPT>")
        Else
            If Not IsPostBack Then
                If Request.QueryString("TipoExp") = 0 Then
                    Regresar.NavigateUrl = "~/Wfrm_TipoExpediente.aspx?idNorma=" & Request.QueryString("idNorma") & "&idNivel=" & Request.QueryString("idNivel")
                Else
                    Regresar.NavigateUrl = "~/Wfrm_TipoExpediente_Series.aspx?idNorma=" & Request.QueryString("idNorma") & "&idNivel=" & Request.QueryString("idNivelP") & "&idSerie=" & Request.QueryString("idSerieP")
                End If
                Dim dsAreas As DataSet
                Dim dslElementos As DataSet
                Dim IntJ As Integer
                dsAreas = svr.ListaNormas_Areas(Request.QueryString("idNorma"))

                For IntJ = 0 To dsAreas.Tables(0).Rows.Count - 1
                    Dim nTabA As New DevExpress.Web.ASPxTabControl.Tab
                    nTabA.Text = dsAreas.Tables(0).Rows(IntJ).Item("folio_norma") & " " & dsAreas.Tables(0).Rows(IntJ).Item("Area_descripcion")
                    nTabA.Name = "TabA" & "_" & dsAreas.Tables(0).Rows(IntJ).Item("idNorma") & "_" & dsAreas.Tables(0).Rows(IntJ).Item("idArea") & "_" & dsAreas.Tables(0).Rows(IntJ).Item("folio_norma")
                    ASPxTabControlA.Tabs.Add(nTabA)
                Next
                ASPxTabControlA.DataBind()

                dslElementos = svr.ListaNormas_Elementos(Request.QueryString("idNorma"), dsAreas.Tables(0).Rows(0).Item("idArea"))
                aspxgdElementos.DataSource = dslElementos
                aspxgdElementos.DataBind()
                aspxgdElementos.DetailRows.ExpandAllRows()
            End If
        End If
    End Sub

    Protected Sub ASPxTabControlA_ActiveTabChanged(ByVal source As Object, ByVal e As DevExpress.Web.ASPxTabControl.TabControlEventArgs) Handles ASPxTabControlA.ActiveTabChanged
        Dim dslElementos As DataSet
        dslElementos = svr.ListaNormas_Elementos(Request.QueryString("idNorma"), Integer.Parse(e.Tab.Name.Split("_")(2)))
        aspxgdElementos.DataSource = dslElementos
        aspxgdElementos.DataBind()
        aspxgdElementos.DetailRows.ExpandAllRows()
    End Sub

    Protected Sub gdSeries_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles aspxgdElementos.RowUpdating
        If e.NewValues("Indice_Sistema") = "1" Then
            Dim cbpEC As ASPxCallbackPanel = CType(CType(sender, ASPxGridView).FindEditFormTemplateControl("cbpEC"), ASPxCallbackPanel)
            Dim cmbIndiceSistema As ASPxComboBox = CType(cbpEC.FindControl("idIndice_Sistema"), ASPxComboBox)

            'e.NewValues("Indice_descripcion") = cmbIndiceSistema.SelectedItem.Text
            'e.NewValues("idIndice_Sistema") = cmbIndiceSistema.SelectedItem.Value
            'e.NewValues("Indice_Tipo") = cmbIndiceSistema.SelectedItem.GetValue("Indice_Tipo")
            'e.NewValues("relacion_con_normaPID") = cmbIndiceSistema.SelectedItem.GetValue("relacion_con_normaPID")
            'e.NewValues("Indice_PK") = cmbIndiceSistema.SelectedItem.GetValue("Indice_PK")
            'e.NewValues("Indice_Unico") = cmbIndiceSistema.SelectedItem.GetValue("Indice_Unico")
            'e.NewValues("Asigned") = cmbIndiceSistema.SelectedItem.GetValue("Asigned")
            'e.NewValues("Asigned_value") = cmbIndiceSistema.SelectedItem.GetValue("Asigned_value")
            'e.NewValues("Indice_LongitudMax") = cmbIndiceSistema.SelectedItem.GetValue("Indice_LongitudMax")
            'e.NewValues("Indice_Mascara") = cmbIndiceSistema.SelectedItem.GetValue("Indice_Mascara")
            'e.NewValues("Indice_Obligatorio") = cmbIndiceSistema.SelectedItem.GetValue("Indice_Obligatorio")

            'Dim val1 As String = e.NewValues("Indice_Visible").ToString
            'Dim val2 As String = cmbIndiceSistema.SelectedItem.GetValue("Indice_Visible")

            'e.NewValues("Indice_Visible") = cmbIndiceSistema.SelectedItem.GetValue("Indice_Visible")
            'e.NewValues("Indice_Visible") = False
        Else
            e.NewValues("idIndice_Sistema") = 0
            Select Case e.NewValues("Indice_Tipo")
                Case 1
                    e.NewValues("Indice_Mascara") = "^\d+(\.\d\d)?$"
                Case 2
                    e.NewValues("Indice_Mascara") = "(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"
                Case 11, 12
                    e.NewValues("Asigned_value") = Session("CatalogoDefaultValue")
                    Session("CatalogoDefaultValue") = Nothing
            End Select
        End If
    End Sub

    Protected Sub gdSeries_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        e.NewValues("idElemento") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        e.NewValues("idArea") = CType(sender, ASPxGridView).GetMasterRowFieldValues("idArea")
        If e.NewValues("Indice_Sistema") = "1" Then
            Dim cbpEC As ASPxCallbackPanel = CType(CType(sender, ASPxGridView).FindEditFormTemplateControl("cbpEC"), ASPxCallbackPanel)
            Dim cmbIndiceSistema As ASPxComboBox = CType(cbpEC.FindControl("idIndice_Sistema"), ASPxComboBox)
            e.NewValues("Indice_descripcion") = cmbIndiceSistema.SelectedItem.Text
            e.NewValues("idIndice_Sistema") = cmbIndiceSistema.SelectedItem.Value
            e.NewValues("Indice_Tipo") = cmbIndiceSistema.SelectedItem.GetValue("Indice_Tipo")
            e.NewValues("relacion_con_normaPID") = cmbIndiceSistema.SelectedItem.GetValue("relacion_con_normaPID")
            e.NewValues("Indice_PK") = cmbIndiceSistema.SelectedItem.GetValue("Indice_PK")
            e.NewValues("Indice_Unico") = cmbIndiceSistema.SelectedItem.GetValue("Indice_Unico")
            e.NewValues("Asigned") = cmbIndiceSistema.SelectedItem.GetValue("Asigned")
            e.NewValues("Asigned_value") = cmbIndiceSistema.SelectedItem.GetValue("Asigned_value")
            e.NewValues("Indice_LongitudMax") = cmbIndiceSistema.SelectedItem.GetValue("Indice_LongitudMax")
            e.NewValues("Indice_Mascara") = cmbIndiceSistema.SelectedItem.GetValue("Indice_Mascara")
            e.NewValues("Indice_Obligatorio") = cmbIndiceSistema.SelectedItem.GetValue("Indice_Obligatorio")

            e.NewValues("Indice_Visible") = cmbIndiceSistema.SelectedItem.GetValue("Indice_Visible")
        Else
            Select Case e.NewValues("Indice_Tipo")
                Case 1
                    e.NewValues("Indice_Mascara") = "^\d+(\.\d\d)?$"
                Case 2
                    e.NewValues("Indice_Mascara") = "(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"
                Case 11, 12
                    e.NewValues("Asigned_value") = Session("CatalogoDefaultValue")
                    Session("CatalogoDefaultValue") = Nothing
            End Select
        End If
        e.NewValues("Indice_buscar") = False
        e.NewValues("Indice_CopiarValor") = False
        e.NewValues("Indice_EsAutoincremental") = False
        e.NewValues("IndiceReadOnly") = False
        e.NewValues("Muestra_padres") = False
        e.NewValues("Multi_valor") = False
    End Sub

    Protected Sub gdSeries_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomErrorTextEventArgs)
        Dim nError As String
        nError = e.Exception.Message
    End Sub

    Protected Sub gdSeries_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("idElemento") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
    End Sub

    Protected Sub cbpSetSes_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Session("CatalogoDefaultValue") = e.Parameter
    End Sub

    Protected Sub aspxgdElementos_HtmlEditFormCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewEditFormEventArgs)
        Dim gdSeries As ASPxGridView = CType(sender, ASPxGridView)
        If Not CType(e.EditForm.Controls(0).FindControl("Tipo"), ASPxComboBox).SelectedItem Is Nothing And gdSeries.IsNewRowEditing = False And gdSeries.IsEditing Then
            If CType(e.EditForm.Controls(0).FindControl("Tipo"), ASPxComboBox).SelectedItem.Value = "11" Then
                Dim myCampoValor As ASPxTextBox = CType(e.EditForm.Controls(0).FindControl("CampoValor"), ASPxTextBox)
                Dim mycmbCatalogoValues As ASPxComboBox = CType(e.EditForm.Controls(0).FindControl("cmbCatalogoValues"), ASPxComboBox)
                If myCampoValor.Text.Length > 0 Then
                    'CType(e.EditForm.Controls(0).FindControl("cmbCatalogos"), ASPxComboBox).Items.FindByValue(Integer.Parse(myCampoValor.Text.Split("|")(0))).Selected = True
                    dsCatalogoValues.SelectParameters(0).DefaultValue = CType(e.EditForm.Controls(0).FindControl("cmbCatalogos"), ASPxComboBox).SelectedItem.Value
                    mycmbCatalogoValues.DataBind()
                    mycmbCatalogoValues.Items.FindByValue(Integer.Parse(myCampoValor.Text)).Selected = True
                    myCampoValor.Text = ""
                End If
            End If
        End If
    End Sub

    Protected Sub cmbCatalogoValues_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        dsCatalogoValues.SelectParameters(0).DefaultValue = e.Parameter
        CType(sender, ASPxComboBox).DataBind()
    End Sub

    Protected Sub cbpEC_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Dim cmbIndiceSistema As ASPxComboBox = CType(CType(sender, ASPxCallbackPanel).FindControl("idIndice_Sistema"), ASPxComboBox)
        Dim lblIndiceSistema As Literal = CType(CType(sender, ASPxCallbackPanel).FindControl("lblIndiceSistema"), Literal)
        Dim txtIndiceSistema As Literal = CType(CType(sender, ASPxCallbackPanel).FindControl("txtIndiceSistema"), Literal)

        lblIndiceSistema.Text = "Area recomendada"
        txtIndiceSistema.Text = cmbIndiceSistema.SelectedItem.GetValue("Area_Recomendada")
        lblIndiceSistema.Text += "<BR>Elemento recomendado"
        txtIndiceSistema.Text += "<BR>" & cmbIndiceSistema.SelectedItem.GetValue("Elemento_Recomendado")
        lblIndiceSistema.Text += "<HR>Tipo de dato"
        txtIndiceSistema.Text += "<HR>" & getIndiceTipoById(Integer.Parse(cmbIndiceSistema.SelectedItem.GetValue("Indice_Tipo")))
        If cmbIndiceSistema.SelectedItem.GetValue("Indice_Tipo") = "11" Or cmbIndiceSistema.SelectedItem.GetValue("Indice_Tipo") = "12" Then
            lblIndiceSistema.Text += "<BR>Tipo de Catalogo"
            txtIndiceSistema.Text += "<BR>" & cmbIndiceSistema.SelectedItem.GetValue("relacion_con_normaPID").ToString()
        Else
            lblIndiceSistema.Text += "<BR>Llave primaria"
            txtIndiceSistema.Text += "<BR>" & cmbIndiceSistema.SelectedItem.GetValue("Indice_PK").ToString()
            lblIndiceSistema.Text += "<BR>Indice único"
            txtIndiceSistema.Text += "<BR>" & cmbIndiceSistema.SelectedItem.GetValue("Indice_Unico").ToString()
        End If
        If cmbIndiceSistema.SelectedItem.GetValue("Asigned") = "1" Or cmbIndiceSistema.SelectedItem.GetValue("Asigned") = "True" Then
            lblIndiceSistema.Text += "<BR>Valor por default"
            txtIndiceSistema.Text += "<BR>" & cmbIndiceSistema.SelectedItem.GetValue("Asigned_value").ToString()
        End If
        If cmbIndiceSistema.SelectedItem.GetValue("Indice_Tipo") = "0" Then
            lblIndiceSistema.Text += "<BR>Longitud"
            txtIndiceSistema.Text += "<BR>" & cmbIndiceSistema.SelectedItem.GetValue("Indice_LongitudMax").ToString()
            If Not cmbIndiceSistema.SelectedItem.GetValue("Indice_Mascara") Is Nothing Then
                lblIndiceSistema.Text += "<BR>Mascara"
                txtIndiceSistema.Text += "<BR>" & cmbIndiceSistema.SelectedItem.GetValue("Indice_Mascara").ToString()
            End If
            lblIndiceSistema.Text += "<BR>Obligatorio"
            txtIndiceSistema.Text += "<BR>" & cmbIndiceSistema.SelectedItem.GetValue("Indice_Obligatorio").ToString()
        End If
        lblIndiceSistema.Text += "<BR>Visible"
        txtIndiceSistema.Text += "<BR>" & cmbIndiceSistema.SelectedItem.GetValue("Indice_Visible").ToString()
        txtIndiceSistema.Text = txtIndiceSistema.Text.Replace("True", "Si").Replace("False", "No")
    End Sub

    Function getIndiceTipoById(ByVal iId As Integer) As String
        Select Case iId
            Case 7 : Return "Entero"
            Case 2 : Return "Fecha"
            Case 3 : Return "Periodo de fechas"
            Case 4 : Return "Periodo Mes Año"
            Case 5 : Return "Periodo Años"
            Case 1 : Return "Texto Largo"
            Case 6 : Return "Seleccion Si/No"
            Case 11 : Return "Catalogo"
            Case 12 : Return "Grid"
            Case 0 : Return "Texto"
            Case Else : Return ""
        End Select
    End Function

    Protected Sub gdSeries_HtmlCommandCellPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableCommandCellEventArgs)
        If e.Cell.Controls.Count > 0 Then
            If CType(sender, ASPxGridView).GetRowValues(e.VisibleIndex, "Indice_Sistema") = "true" Then
                e.Cell.Controls(0).Visible = True
                e.Cell.Controls(2).Visible = False
            Else
                e.Cell.Controls(0).Visible = True
                e.Cell.Controls(2).Visible = True
            End If
        End If
    End Sub

End Class
