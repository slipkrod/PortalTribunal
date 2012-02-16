Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxTabControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls


Partial Public Class Wfrm_PantallaCapturaISAAR
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim descarch As String
    Dim idISAAR As Integer
    Dim auxiliar As Integer = 2
    Dim mensaje As String
#End Region

    Private Sub Wfrm_PlantillaCaptura_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        CargaArchivo()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Organigrama ->Configuración->"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            ListaISAARxID.Select()
            FormView1.DataBind()
        End If
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
  
    Private Sub CargaArchivo()
        lblidNorma.Text = Request.QueryString("idNorma")
    End Sub

    Private Sub gdnivel_FocusedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdnivel.FocusedRowChanged
        ListaISAARxID.Select()
        FormView1.DataBind()
    End Sub


    Protected Sub btNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevo.Click
        Dim sv As New WSArchivo.Service1
        idISAAR = sv.ABC_ISAAR(0, 0, "", "", "", "", "", "", SqlTypes.SqlDateTime.Null, "", "", "", "", "", "", "", "", "", "", "", "", SqlTypes.SqlDateTime.Null, "", "", "")
        lblidISAAR.Text = idISAAR
        gdnivel.DataBind()
        gdnivel.FocusedRowIndex = 0
        ListaISAARxID.Select()
        FormView1.DataBind()
        FormView1.ChangeMode(FormViewMode.Edit)
    End Sub

    Protected Sub gdnivel_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gdnivel.RowDeleting
    End Sub

    'Private Sub aspxgdisaarrelacion_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxgdisaarrelacion.RowValidating
    '    If e.NewValues("Fechas_relación") = Nothing Then
    '        e.RowError = "El valor de la fecha no puede ser nulo."
    '    End If

    '    If e.NewValues("idISAAR_REL") = Nothing Then
    '        e.RowError = "El valor del nombre no puede ser nulo."
    '    End If

    '    If e.NewValues("IDCatalogo_item") = Nothing Then
    '        e.RowError = "El valor de la naturaleza de la relación no puede ser nulo."
    '    End If
    'End Sub


    Private Sub Relaciones_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles Relaciones.Deleting
        e.InputParameters("idISAAR") = gdnivel.GetDataRow(gdnivel.FocusedRowIndex).Item("idISAAR")
        e.InputParameters("idISAAR_REL") = 0
        e.InputParameters("IDCatalogo_item") = 0
        e.InputParameters("Descripción_relación") = ""
        e.InputParameters("Fechas_relación") = Now.Date
    End Sub

    Private Sub Relaciones_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles Relaciones.Inserting
        e.InputParameters("idISAAR") = gdnivel.GetDataRow(gdnivel.FocusedRowIndex).Item("idISAAR")
    End Sub


    Protected Sub ListaISAARxID_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ListaISAARxID.Selecting
        If gdnivel.FocusedRowIndex = -1 Then
            If gdnivel.VisibleRowCount = 0 Then
                e.Cancel = True
            End If
        Else
            e.InputParameters("idISAAR") = gdnivel.GetDataRow(gdnivel.FocusedRowIndex).Item("idISAAR")
        End If
    End Sub

    Protected Sub Relaciones_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles Relaciones.Selecting
        If gdnivel.FocusedRowIndex = -1 Then
            If gdnivel.VisibleStartIndex = -1 Then
                e.Cancel = True
            Else
                e.InputParameters("idISAAR") = gdnivel.GetDataRow(gdnivel.VisibleStartIndex).Item("idISAAR")
            End If
        Else
            e.InputParameters("idISAAR") = gdnivel.GetDataRow(gdnivel.FocusedRowIndex).Item("idISAAR")
        End If
    End Sub

    Private Sub gdnivel_StartRowEditing(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxStartRowEditingEventArgs) Handles gdnivel.StartRowEditing
        FormView1.ChangeMode(FormViewMode.Edit)
    End Sub


    Private Sub ListaISAARxID_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ListaISAARxID.Updating

        e.InputParameters("idISAAR") = CType(FormView1.FindControl("txtidISAAR"), ASPxTextBox).Text
        '1 identificación

        e.InputParameters("Tipo_de_entidad") = CType(FormView1.FindControl("pgareas").FindControl("txt11"), ASPxComboBox).Text
        e.InputParameters("Formas_autorizadas_nombre") = CType(FormView1.FindControl("pgareas").FindControl("txt12"), ASPxTextBox).Text
        e.InputParameters("Formas_paralelas_nombre") = CType(FormView1.FindControl("pgareas").FindControl("txt13"), ASPxTextBox).Text
        e.InputParameters("Formas_normalizadas_nombre") = CType(FormView1.FindControl("pgareas").FindControl("txt14"), ASPxTextBox).Text
        e.InputParameters("Otras_formas_nombre") = CType(FormView1.FindControl("pgareas").FindControl("txt15"), ASPxTextBox).Text
        e.InputParameters("Identificadores_para_instituciones") = CType(FormView1.FindControl("pgareas").FindControl("txt16"), ASPxTextBox).Text

        '2 bdescripción
        If CType(FormView1.FindControl("pgareas").FindControl("txt21"), ASPxDateEdit).Value Is Nothing Then
            e.InputParameters("Fechas_de_existencia") = SqlTypes.SqlDateTime.Null
        Else
            e.InputParameters("Fechas_de_existencia") = CType(FormView1.FindControl("pgareas").FindControl("txt21"), ASPxDateEdit).Value
        End If
        e.InputParameters("Historia") = CType(FormView1.FindControl("pgareas").FindControl("txt22"), ASPxMemo).Text
        e.InputParameters("Lugares") = CType(FormView1.FindControl("pgareas").FindControl("txt23"), ASPxTextBox).Text
        e.InputParameters("Estatuto_jurídico") = CType(FormView1.FindControl("pgareas").FindControl("txt24"), ASPxTextBox).Text
        e.InputParameters("Funciones_ocupaciones_actividades") = CType(FormView1.FindControl("pgareas").FindControl("txt25"), ASPxTextBox).Text
        e.InputParameters("Atribuciones_Fuentes_legales") = CType(FormView1.FindControl("pgareas").FindControl("txt26"), ASPxTextBox).Text
        e.InputParameters("Estructuras_internas_Genealogía") = CType(FormView1.FindControl("pgareas").FindControl("txt27"), ASPxTextBox).Text
        e.InputParameters("Contexto_general") = CType(FormView1.FindControl("pgareas").FindControl("txt28"), ASPxTextBox).Text

        '4 control
        e.InputParameters("Identificador_registro_autoridad") = CType(FormView1.FindControl("pgareas").FindControl("txt41"), ASPxTextBox).Text
        e.InputParameters("Identificadores_institución") = CType(FormView1.FindControl("pgareas").FindControl("txt42"), ASPxTextBox).Text
        e.InputParameters("Reglas_convenciones") = CType(FormView1.FindControl("pgareas").FindControl("txt43"), ASPxMemo).Text
        e.InputParameters("Estado_elaboración") = CType(FormView1.FindControl("pgareas").FindControl("txt44"), ASPxTextBox).Text
        e.InputParameters("Nivel_detalle") = CType(FormView1.FindControl("pgareas").FindControl("txt45"), ASPxMemo).Text

        If CType(FormView1.FindControl("pgareas").FindControl("txt46"), ASPxDateEdit).Value Is Nothing Then
            e.InputParameters("Fechas_creación_revisión_eliminación") = SqlTypes.SqlDateTime.Null
        Else
            e.InputParameters("Fechas_creación_revisión_eliminación") = CType(FormView1.FindControl("pgareas").FindControl("txt46"), ASPxDateEdit).Value
        End If
        e.InputParameters("Lenguas_escrituras") = CType(FormView1.FindControl("pgareas").FindControl("txt47"), ASPxTextBox).Text
        e.InputParameters("Fuentes") = CType(FormView1.FindControl("pgareas").FindControl("txt48"), ASPxMemo).Text
        e.InputParameters("Notas_de_mantenimiento") = CType(FormView1.FindControl("pgareas").FindControl("txt49"), ASPxMemo).Text

    End Sub

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As EventArgs)
        FormView1.ChangeMode(FormViewMode.ReadOnly)
        gdnivel.CancelEdit()
    End Sub

    Private Sub ListaISAAR_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ListaISAAR.Deleting
        e.InputParameters("idISAAR") = gdnivel.GetDataRow(gdnivel.FocusedRowIndex).Item("idISAAR")
        e.InputParameters("Fechas_de_existencia") = Now.Date
        e.InputParameters("Fechas_creación_revisión_eliminación") = Now.Date
    End Sub


    Protected Sub ListaISAARTipoExpediente_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ListaISAARTipoExpediente.Selecting
        If gdnivel.FocusedRowIndex = -1 Then
            If gdnivel.VisibleStartIndex = -1 Then
                e.Cancel = True
            Else
                e.InputParameters("idISAAR") = gdnivel.GetDataRow(gdnivel.VisibleStartIndex).Item("idISAAR")
            End If
        Else
            e.InputParameters("idISAAR") = gdnivel.GetDataRow(gdnivel.FocusedRowIndex).Item("idISAAR")
        End If
    End Sub

    Protected Sub ListaISAAREntidades_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ListaISAAREntidades.Selecting
        If gdnivel.FocusedRowIndex = -1 Then
            If gdnivel.VisibleStartIndex = -1 Then
                e.Cancel = True
            Else
                e.InputParameters("idISAAR") = gdnivel.GetDataRow(gdnivel.VisibleStartIndex).Item("idISAAR")
            End If
        Else
            e.InputParameters("idISAAR") = gdnivel.GetDataRow(gdnivel.FocusedRowIndex).Item("idISAAR")
        End If
    End Sub

    Protected Sub gdISAARExpedientes_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        e.NewValues("idISAAR") = gdnivel.GetDataRow(gdnivel.FocusedRowIndex).Item("idISAAR")
        e.NewValues("idNorma") = CType(CType(sender, ASPxGridView).FindEditRowCellTemplateControl(CType(sender, ASPxGridView).Columns("idSerie"), "cmbTipoExpediente"), ASPxComboBox).SelectedItem.GetValue("idNorma")
        e.NewValues("idNivel") = CType(CType(sender, ASPxGridView).FindEditRowCellTemplateControl(CType(sender, ASPxGridView).Columns("idSerie"), "cmbTipoExpediente"), ASPxComboBox).SelectedItem.GetValue("idNivel")
    End Sub

    Protected Sub gdISAARExpedientes_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        ListaISAARTipoExpediente.DeleteParameters("idISAAR").DefaultValue = e.Values("idISAAR")
        ListaISAARTipoExpediente.DeleteParameters("idNorma").DefaultValue = e.Values("idNorma")
        ListaISAARTipoExpediente.DeleteParameters("idNivel").DefaultValue = e.Values("idNivel")
        ListaISAARTipoExpediente.DeleteParameters("idSerie").DefaultValue = e.Values("idSerie")
    End Sub

    Protected Sub gdISAARExpedientes_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomErrorTextEventArgs)
        Dim xError As String
        xError = e.Exception.InnerException.Message
    End Sub

    Protected Sub gdISAAREntidades_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        e.NewValues("idISAAR") = gdnivel.GetDataRow(gdnivel.FocusedRowIndex).Item("idISAAR")
        e.NewValues("idArchivo") = CType(CType(sender, ASPxGridView).FindEditRowCellTemplateControl(CType(sender, ASPxGridView).Columns("idDescripcion"), "cmbSeries"), ASPxComboBox).SelectedItem.GetValue("idArchivo")

    End Sub

    Protected Sub gdISAAREntidades_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomErrorTextEventArgs)
        Dim xError As String
        xError = e.Exception.InnerException.Message
    End Sub

    Protected Sub gdISAAREntidades_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        ListaISAAREntidades.DeleteParameters("idISAAR").DefaultValue = e.Values("idISAAR")
        ListaISAAREntidades.DeleteParameters("idArchivo").DefaultValue = e.Values("idArchivo")
        ListaISAAREntidades.DeleteParameters("idDescripcion").DefaultValue = e.Values("idDescripcion")
    End Sub

    Protected Sub TiposExpediente_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles TiposExpediente.Selecting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim objGlobal As New clsGlobal
        If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
            LogOff()
            Exit Sub
        End If
        e.InputParameters("identidad") = tTicket.NoIdentidad
    End Sub
End Class