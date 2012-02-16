Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxCallbackPanel

Partial Class Wfrm_Normas_Areas
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim mensaje As String
#End Region
    Dim deldatos As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Normas->Areas [" & Request.QueryString("Norma") & "]"
            Try
                Dim sv As New WSArchivo.Service1
                Dim iRows As Integer = sv.Func_Suma_IndicesSistemaXNorma(-1, Request.QueryString("idNorma")).Tables(0).Rows(0)(0)
                If iRows > 1 Then lblTitle.Text += " <span style='color:Red;'>Se encontraron " & iRows & " indices de sistema sin aplicar.</span>"
                If iRows = 1 Then lblTitle.Text += " <span style='color:Red;'>Se encontro 1 indice de sistema sin aplicar.</span>"
            Catch
            End Try
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            aspxgdareas.DetailRows.ExpandAllRows()
        End If
    End Sub

#Region "  Comunes"

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Private Function ObtieneResultado() As String
        Dim strResultado As String
        If Session.Item("GSTR_SESSION_RESULT") Is Nothing Then
            strResultado = String.Empty
        Else
            strResultado = Session.Item("GSTR_SESSION_RESULT")
            Session.Remove("GSTR_SESSION_RESULT")
        End If
        Return strResultado
    End Function

    Private Sub GetdataSource()

        Dim sv As New WSArchivo.Service1
        Dim dsAreas As DataSet
        Try

            dsAreas = sv.ListaNormas_Areas(Request.QueryString("idNorma"))
            aspxgdareas.DataSource = dsAreas
            aspxgdareas.databind()
            dsAreas.Dispose()
            dsAreas = Nothing
            sv = Nothing

        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try

    End Sub


#End Region

    Protected Sub aspxgdareas_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim Area_descripcion As String = ""
        Dim folio_norma As String = ""
        Dim IdNorma As String
        Dim key As Object = e.Keys(0)
        IdNorma = Request.QueryString("idNorma")
        Area_descripcion = e.NewValues.Item(1)
        folio_norma = e.NewValues(0)
        aspxgdareas.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_Normas_Areas(2, IdNorma, key, Area_descripcion, folio_norma)
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try

    End Sub

    Protected Sub aspxgdareas_CustomJSProperties(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs) Handles aspxgdareas.CustomJSProperties
        If deldatos Then
            e.Properties("cpdeletedflag") = "El área no puede ser eliminada ya que contiene elementos"
            deldatos = False
        Else
            e.Properties("cpdeletedflag") = String.Empty
        End If
    End Sub

    Protected Sub aspxgdareas_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxgdareas.RowInserting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim Area_descripcion As String = ""
        Dim folio_norma As String = ""
        Dim IdNorma As String
        IdNorma = Request.QueryString("idNorma")
        Area_descripcion = e.NewValues.Item(1)
        folio_norma = e.NewValues(0)
        aspxgdareas.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_Normas_Areas(0, IdNorma, 0, Area_descripcion, folio_norma)
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try

    End Sub

    Protected Sub aspxgdareas_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles aspxgdareas.RowDeleting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim Area_descripcion As String = ""
        Dim folio_norma As String = ""
        Dim IdNorma As String = Request.QueryString("idNorma")
        Dim key As Object = e.Keys(0)
        Dim dsElementos As DataSet
        dsElementos = sv.ListaNormas_Elementos(Request.QueryString("idNorma"), key)
        e.Cancel = True
        aspxgdareas.CancelEdit()
        Area_descripcion = e.Values.Item(1)
        folio_norma = e.Values(0)

        If dsElementos.Tables(0).Rows.Count > 0 Then
            deldatos = True
        Else
            Try
                sv.ABC_Normas_Areas(1, IdNorma, key, Area_descripcion, folio_norma)
            Catch ex As Exception
                MsgBox1.ShowMessage(ex.Message)
            Finally
                sv = Nothing
            End Try
        End If

    End Sub

    Protected Sub aspxgdareas_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)
        Try
            Select Case e.CommandArgs.CommandName.ToString
                Case "Elementos"
                    'Response.Redirect("Wfrm_Normas_Elementos.aspx?idArea=" & e.KeyValue & "&Norma=" & HttpUtility.UrlEncode(Request.QueryString("Norma")) & "&Area=" & e.CommandArgs.CommandArgument.ToString & "&idNorma=" & HttpUtility.UrlEncode(Request.QueryString("idNorma")))
            End Select
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Protected Sub aspxgdareas_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxgdareas.PageIndexChanged
        Try
            'GetdataSource()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub aspxgdareas_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxgdareas.RowValidating
        If e.NewValues("Area_descripcion") = Nothing Then
            e.RowError = "El nombre del área no puede ser nulo."
        End If

        If e.NewValues("folio_norma") = Nothing Then
            e.RowError = "El id del área no puede ser nulo."
        End If
    End Sub

    Protected Sub aspxgdelementos_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("idArea") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
    End Sub

    Protected Sub gdSeries_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("idArea") = (TryCast(sender, ASPxGridView)).GetMasterRowFieldValues("idArea")
        Session("idElemento") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
    End Sub

    Protected Sub gdSeries_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        If e.NewValues("Indice_Sistema") = "1" Then
            Dim sv As New WSArchivo.Service1
            If sv.Func_Suma_IndicesSistemaXNorma(-1, Request.QueryString("idNorma")).Tables(0).Rows(0)(0) > 0 Then
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
            End If
        Else
            e.NewValues("idIndice_Sistema") = 0
            Select Case e.NewValues("Indice_Tipo")
                Case 1
                    e.NewValues("Indice_Mascara") = "^\d+(\.\d\d)?$"
                Case 2
                    e.NewValues("Indice_Mascara") = "(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"
                Case 11
                    e.NewValues("Asigned_value") = Session("CatalogoDefaultValue")
                    Session("CatalogoDefaultValue") = Nothing
            End Select
        End If
    End Sub

    Protected Sub gdSeries_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        e.NewValues("idElemento") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Session("idArea") = CType(sender, ASPxGridView).GetMasterRowFieldValues("idArea")
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
                Case 11
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

    Protected Sub aspxgdareas_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles aspxgdareas.DataBound
        aspxgdareas.DetailRows.ExpandAllRows()
    End Sub

    Protected Sub aspxgdelementos_DataBound(ByVal sender As Object, ByVal e As EventArgs)
        CType(sender, ASPxGridView).DetailRows.ExpandAllRows()
    End Sub

    Protected Sub cbpSetSes_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Session("CatalogoDefaultValue") = e.Parameter
    End Sub

    Protected Sub gdSeries_HtmlEditFormCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewEditFormEventArgs)
        Dim gdSeries As ASPxGridView = CType(sender, ASPxGridView)
        If Not CType(e.EditForm.Controls(0).FindControl("Tipo"), ASPxComboBox).SelectedItem Is Nothing Then
            If gdSeries.IsNewRowEditing = False And gdSeries.IsEditing Then
                If CType(e.EditForm.Controls(0).FindControl("Tipo"), ASPxComboBox).SelectedItem.Value = "11" Then
                    Dim myCampoValor As ASPxTextBox = CType(e.EditForm.Controls(0).FindControl("CampoValor"), ASPxTextBox)
                    If myCampoValor.Text.Length > 0 Then
                        Dim mycmbCatalogoValues As ASPxComboBox = CType(e.EditForm.Controls(0).FindControl("cmbCatalogoValues"), ASPxComboBox)
                        'CType(e.EditForm.Controls(0).FindControl("cmbCatalogos"), ASPxComboBox).Items.FindByValue(Integer.Parse(myCampoValor.Text.Split("|")(0))).Selected = True
                        dsCatalogoValues.SelectParameters(0).DefaultValue = CType(e.EditForm.Controls(0).FindControl("cmbCatalogos"), ASPxComboBox).SelectedItem.Value
                        mycmbCatalogoValues.DataBind()
                        mycmbCatalogoValues.Items.FindByValue(Integer.Parse(myCampoValor.Text)).Selected = True
                        myCampoValor.Text = ""
                    End If
                End If
            End If
        End If
        If gdSeries.IsEditing And Not CType(CType(e.EditForm.Controls(0).FindControl("cbpEC"), ASPxCallbackPanel).FindControl("idIndice_Sistema"), ASPxComboBox) Is Nothing Then
            Dim sv As New WSArchivo.Service1
            If sv.Func_Suma_IndicesSistemaXNorma(-1, Request.QueryString("idNorma")).Tables(0).Rows(0)(0) < 1 Then
                If gdSeries.IsNewRowEditing Then
                    CType(e.EditForm.Controls(0).FindControl("Indice_Sistema"), ASPxComboBox).Items.Clear()
                    CType(e.EditForm.Controls(0).FindControl("Indice_Sistema"), ASPxComboBox).Items.Add("De Usuario", "False")
                Else
                    CType(e.EditForm.Controls(0).FindControl("Indice_Sistema"), ASPxComboBox).Enabled = False
                    CType(CType(e.EditForm.Controls(0).FindControl("cbpEC"), ASPxCallbackPanel).FindControl("idIndice_Sistema"), ASPxComboBox).Visible = False

                    Dim lblIndiceSistema As Literal = CType(CType(e.EditForm.Controls(0).FindControl("cbpEC"), ASPxCallbackPanel).FindControl("lblIndiceSistema"), Literal)
                    Dim txtIndiceSistema As Literal = CType(CType(e.EditForm.Controls(0).FindControl("cbpEC"), ASPxCallbackPanel).FindControl("txtIndiceSistema"), Literal)
                    CType(CType(e.EditForm.Controls(0).FindControl("cbpEC"), ASPxCallbackPanel).FindControl("lblHeadIndiceSistema"), ASPxLabel).Text = "Nombre del campo"
                    txtIndiceSistema.Text = CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Indice_descripcion")
                    lblIndiceSistema.Text = "<HR>Tipo de dato"
                    txtIndiceSistema.Text += "<HR>" & getIndiceTipoById(Integer.Parse(CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Indice_Tipo")))
                    If CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Indice_Tipo") = "11" Then
                        lblIndiceSistema.Text += "<BR>Tipo de Catalogo"
                        txtIndiceSistema.Text += "<BR>" & CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "relacion_con_normaPID")
                    Else
                        lblIndiceSistema.Text += "<BR>Llave primaria"
                        txtIndiceSistema.Text += "<BR>" & CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Indice_PK")
                        lblIndiceSistema.Text += "<BR>Indice único"
                        txtIndiceSistema.Text += "<BR>" & CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Indice_Unico")
                    End If
                    If CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Asigned") = "1" Or CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Asigned") = "True" Then
                        lblIndiceSistema.Text += "<BR>Valor por default"
                        txtIndiceSistema.Text += "<BR>" & CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Asigned_value")
                    End If
                    If CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Indice_Tipo") = "0" Then
                        lblIndiceSistema.Text += "<BR>Longitud"
                        txtIndiceSistema.Text += "<BR>" & CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Indice_LongitudMax")
                        If Not CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Indice_Mascara") Is Nothing Then
                            lblIndiceSistema.Text += "<BR>Mascara"
                            txtIndiceSistema.Text += "<BR>" & CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Indice_Mascara")
                        End If
                        lblIndiceSistema.Text += "<BR>Obligatorio"
                        txtIndiceSistema.Text += "<BR>" & CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Indice_Obligatorio")
                    End If
                    lblIndiceSistema.Text += "<BR>Visible"
                    txtIndiceSistema.Text += "<BR>" & CType(sender, ASPxGridView).GetRowValues(CType(sender, ASPxGridView).EditingRowVisibleIndex, "Indice_Visible")
                    txtIndiceSistema.Text = txtIndiceSistema.Text.Replace("True", "Si").Replace("False", "No")
                End If
            Else
                CType(e.EditForm.Controls(0).FindControl("Indice_Sistema"), ASPxComboBox).Enabled = True
            End If
            End If
    End Sub

    Protected Sub cmbCatalogoValues_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        dsCatalogoValues.SelectParameters(0).DefaultValue = e.Parameter
        CType(sender, ASPxComboBox).DataBind()
    End Sub

    Sub setIndiceSistem(ByVal Sender As Object)
        Dim cmbIndiceSistema As ASPxComboBox = CType(CType(sender, ASPxCallbackPanel).FindControl("idIndice_Sistema"), ASPxComboBox)
        Dim lblIndiceSistema As Literal = CType(CType(sender, ASPxCallbackPanel).FindControl("lblIndiceSistema"), Literal)
        Dim txtIndiceSistema As Literal = CType(CType(sender, ASPxCallbackPanel).FindControl("txtIndiceSistema"), Literal)

        lblIndiceSistema.Text = "Area recomendada"
        txtIndiceSistema.Text = cmbIndiceSistema.SelectedItem.GetValue("Area_Recomendada")
        lblIndiceSistema.Text += "<BR>Elemento recomendado"
        txtIndiceSistema.Text += "<BR>" & cmbIndiceSistema.SelectedItem.GetValue("Elemento_Recomendado")
        lblIndiceSistema.Text += "<HR>Tipo de dato"
        txtIndiceSistema.Text += "<HR>" & getIndiceTipoById(Integer.Parse(cmbIndiceSistema.SelectedItem.GetValue("Indice_Tipo")))
        If cmbIndiceSistema.SelectedItem.GetValue("Indice_Tipo") = "11" Then
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
    Protected Sub cbpEC_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        setIndiceSistem(sender)
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
            Case 0 : Return "Texto"
            Case Else : Return ""
        End Select
    End Function

    Protected Sub dsSeries_Indices_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsSeries_Indices.Inserting
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub aspxgdelementos_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub aspxgdelementos_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        Try
            e.NewValues("idArea") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dsElementos_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsElementos.Inserting
        Try

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub dsElementos_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsElementos.Deleting

    End Sub

    Protected Sub aspxgdelementos_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Try
            e.Values("idArea") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

        Catch ex As Exception

        End Try
    End Sub
End Class
