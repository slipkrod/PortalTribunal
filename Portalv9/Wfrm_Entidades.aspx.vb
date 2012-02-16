Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors

Partial Public Class Wfrm_Entidades
    Inherits System.Web.UI.Page

    Public tTicket As IDTicket
    Private creado As String
    Private svr As New WSArchivo.Service1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            Dim strRes As String = Session("DebeCambiarPwd")
            If strRes <> String.Empty Then
                If CType(strRes, Boolean) = True Then
                    Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                End If
            End If
            DataBind()
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Private Sub ASPxTreeList1_CommandColumnButtonInitialize(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListCommandColumnButtonEventArgs) Handles ASPxTreeList1.CommandColumnButtonInitialize
        If Not e.NodeKey Is Nothing Then
            If ASPxTreeList1.FindNodeByKeyValue(e.NodeKey).ParentNode.Key = ASPxTreeList1.RootNode.Key Then
                If e.ButtonType = TreeListCommandColumnButtonType.Delete Then
                    e.Visible = DevExpress.Web.ASPxClasses.DefaultBoolean.False
                End If
                If e.ButtonType = TreeListCommandColumnButtonType.Edit Then
                    e.Visible = DevExpress.Web.ASPxClasses.DefaultBoolean.False
                End If
            End If
        End If
    End Sub
    Private Sub ASPxTreeList1_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListCustomErrorTextEventArgs) Handles ASPxTreeList1.CustomErrorText
        ' Dim xError As String
        ' xError = e.Exception.InnerException.Message
    End Sub

    Private Sub ASPxTreeList1_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs) Handles ASPxTreeList1.HtmlRowPrepared
        If (e.RowKind = TreeListRowKind.EditForm) Then

            If Not CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(3), "cmbTipodeElemento"), ASPxComboBox).Items.FindByValue(e.GetValue("idSerie")) Is Nothing Then
                CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(3), "cmbTipodeElemento"), ASPxComboBox).SelectedItem = CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(3), "cmbTipodeElemento"), ASPxComboBox).Items.FindByValue(e.GetValue("idSerie"))
                Dim dsCampoPK As DataSet
                dsCampoPK = svr.ListaArchivo_indices_PK(ConfigurationManager.AppSettings("Archivo"), e.NodeKey, 1)
                If dsCampoPK.Tables(0).Rows.Count > 0 Then
                    CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(5), "ValorClave"), ASPxTextBox).Text = dsCampoPK.Tables(0).Rows(0).Item("Valor")
                End If
            End If
        End If

    End Sub

    Private Sub ASPxTreeList1_NodeInserted(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertedEventArgs) Handles ASPxTreeList1.NodeInserted
        Dim dsCampoPK As DataSet
        dsCampoPK = svr.ListaNormas_Elementos_CampoxSerie_and_PK(CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(3), "cmbTipodeElemento"), ASPxComboBox).SelectedItem.GetValue("idSerie"))
        If dsCampoPK.Tables(0).Rows.Count > 0 Then
            'e.NewValues.Item("idDescripcion")
            Dim valor As String
            valor = CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(5), "ValorClave"), ASPxTextBox).Text
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsCampoPK.Tables(0).Rows(0).Item("idNorma"), dsCampoPK.Tables(0).Rows(0).Item("idArea"), dsCampoPK.Tables(0).Rows(0).Item("idElemento"), dsCampoPK.Tables(0).Rows(0).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), creado, 0, dsCampoPK.Tables(0).Rows(0).Item("idNivel"), dsCampoPK.Tables(0).Rows(0).Item("idSerie"), dsCampoPK.Tables(0).Rows(0).Item("relacion_con_normaPID"), valor, dsCampoPK.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If
    End Sub




    Private Sub ASPxTreeList1_NodeInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles ASPxTreeList1.NodeInserting
        e.NewValues("idArchivo") = ConfigurationManager.AppSettings("Archivo")
        e.NewValues("Codigo_clasificacion") = ""
        e.NewValues("idNivel") = CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(3), "cmbTipodeElemento"), ASPxComboBox).SelectedItem.GetValue("idNivel")
        e.NewValues("idSerie") = CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(3), "cmbTipodeElemento"), ASPxComboBox).SelectedItem.GetValue("idSerie")
        e.NewValues("valuePath") = ""
        e.NewValues("idUnidadInstalacion") = 0
        e.NewValues("idTipoElemento") = 0
        e.NewValues("Atributo") = CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(3), "cmbTipodeElemento"), ASPxComboBox).SelectedItem.GetValue("Atributo")
        e.NewValues("idArchivo_Fisico") = 0
        e.NewValues("idPlanta") = 0
        e.NewValues("idPasillo") = 0
        e.NewValues("idSeccion") = 0
        e.NewValues("idEstante") = 0
        e.NewValues("idBalda") = 0
        e.NewValues("unidad_Instalacion") = 0
        e.NewValues("unidad_instalacion_subdivision") = 0
        e.NewValues("unidad_instalacion_orden") = 0
        e.NewValues("Ano") = 0
        e.NewValues("Mes") = 0
        e.NewValues("Dia") = 0

    End Sub

    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        Select Case ASPxTreeList1.FindNodeByKeyValue(container.NodeKey).GetValue("idNivel")
            Case 219, 220
                Return "~/Images/separador.gif"
            Case Else
                Return "~/Images/Documento.gif"
        End Select
    End Function

    Protected Sub dsListaSeries_ModeloxRango_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsListaSeries_ModeloxRango.Selecting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim objGlobal As New clsGlobal
        If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
            LogOff()
            Exit Sub
        End If
        e.InputParameters("identidad") = tTicket.NoIdentidad
    End Sub

    Private Sub dsListaFondoxNivel_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsListaFondoxNivel.Deleting
        e.InputParameters("IdArchivo") = ConfigurationManager.AppSettings("Archivo")
    End Sub

    Private Sub dsListaFondoxNivel_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsListaFondoxNivel.Inserted
        creado = e.ReturnValue
    End Sub

    Protected Sub dsListaFondoxNivel_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsListaFondoxNivel.Selecting
        e.InputParameters("IdArchivo") = ConfigurationManager.AppSettings("Archivo")
    End Sub

    Private Sub ASPxTreeList1_NodeUpdated(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatedEventArgs) Handles ASPxTreeList1.NodeUpdated
        Dim dsCampoPK As DataSet
        dsCampoPK = svr.ListaArchivo_indices_PK(ConfigurationManager.AppSettings("Archivo"), e.NewValues("idDescripcion"), 1)
        If dsCampoPK.Tables(0).Rows.Count > 0 Then
            Dim valor As String
            valor = CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(5), "ValorClave"), ASPxTextBox).Text
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operCambio, dsCampoPK.Tables(0).Rows(0).Item("idNorma"), dsCampoPK.Tables(0).Rows(0).Item("idArea"), dsCampoPK.Tables(0).Rows(0).Item("idElemento"), dsCampoPK.Tables(0).Rows(0).Item("idIndice"), dsCampoPK.Tables(0).Rows(0).Item("idArchivo"), dsCampoPK.Tables(0).Rows(0).Item("idDescripcion"), dsCampoPK.Tables(0).Rows(0).Item("idFolio"), dsCampoPK.Tables(0).Rows(0).Item("idNivel"), dsCampoPK.Tables(0).Rows(0).Item("idSerie"), dsCampoPK.Tables(0).Rows(0).Item("relacion_con_normaPID"), valor, dsCampoPK.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If
    End Sub

    Private Sub ASPxTreeList1_NodeUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles ASPxTreeList1.NodeUpdating
        e.NewValues("idArchivo") = ConfigurationManager.AppSettings("Archivo")
        e.NewValues("idNivel") = CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(3), "cmbTipodeElemento"), ASPxComboBox).SelectedItem.GetValue("idNivel")
        e.NewValues("idSerie") = CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(3), "cmbTipodeElemento"), ASPxComboBox).SelectedItem.GetValue("idSerie")
        e.NewValues("Atributo") = CType(ASPxTreeList1.FindInlineEditCellTemplateControl(ASPxTreeList1.Columns(3), "cmbTipodeElemento"), ASPxComboBox).SelectedItem.GetValue("Atributo")
    End Sub
End Class