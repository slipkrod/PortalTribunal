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

        End If
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
  
    Private Sub CargaArchivo()
        lblidNorma.Text = Request.QueryString("idNorma")
    End Sub

    Private Sub gdnivel_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdnivel.DataBound
        If gdnivel.VisibleRowCount < 0 Then
            pgareas.Visible = True
        End If
        If gdnivel.VisibleRowCount = 0 Then
            pgareas.Visible = False
        End If
    End Sub

    Private Sub gdnivel_FocusedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdnivel.FocusedRowChanged
        If gdnivel.FocusedRowIndex = -1 Then
            pgareas.Visible = False
            btnguardar.Visible = False
            Limpiaelementos()
            btnNuevo.Visible = True
        End If
        ASPxError.Text = ""
        If auxiliar = 0 Then
            habilitaelementos()
        Else
            deshabilitaelementos()
        End If
        gdnivel.CancelEdit()
    End Sub

    Private Sub gdnivel_HtmlRowCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs) Handles gdnivel.HtmlRowCreated

        If e.KeyValue <> Nothing Then
            pgareas.Visible = True
            Dim value As DataRowView
            If gdnivel.FocusedRowIndex <> -1 Then
                value = gdnivel.GetRow(gdnivel.FocusedRowIndex)
                CType(pgareas.FindControl("txt11"), ASPxComboBox).SelectedIndex = CType(pgareas.FindControl("txt11"), ASPxComboBox).Items.IndexOfText(value.Item(1))
                CType(pgareas.FindControl("txt12"), ASPxTextBox).Text = value.Item(2)
                CType(pgareas.FindControl("txt13"), ASPxTextBox).Text = value.Item(3)
                CType(pgareas.FindControl("txt14"), ASPxTextBox).Text = value.Item(4)
                CType(pgareas.FindControl("txt15"), ASPxTextBox).Text = value.Item(5)
                CType(pgareas.FindControl("txt16"), ASPxTextBox).Text = value.Item(6)
                CType(pgareas.FindControl("txt21"), ASPxDateEdit).Value = value.Item(7)
                CType(pgareas.FindControl("txt22"), ASPxMemo).Text = value.Item(8)
                CType(pgareas.FindControl("txt23"), ASPxTextBox).Text = value.Item(9)
                CType(pgareas.FindControl("txt24"), ASPxTextBox).Text = value.Item(10)
                CType(pgareas.FindControl("txt25"), ASPxTextBox).Text = value.Item(11)
                CType(pgareas.FindControl("txt26"), ASPxTextBox).Text = value.Item(12)
                CType(pgareas.FindControl("txt27"), ASPxTextBox).Text = value.Item(13)
                CType(pgareas.FindControl("txt28"), ASPxTextBox).Text = value.Item(14)

                CType(pgareas.FindControl("txt41"), ASPxTextBox).Text = value.Item(15)
                CType(pgareas.FindControl("txt42"), ASPxTextBox).Text = value.Item(16)
                CType(pgareas.FindControl("txt43"), ASPxMemo).Text = value.Item(17)
                CType(pgareas.FindControl("txt44"), ASPxTextBox).Text = value.Item(18)
                CType(pgareas.FindControl("txt45"), ASPxMemo).Text = value.Item(19)
                CType(pgareas.FindControl("txt46"), ASPxDateEdit).Value = value.Item(20)
                CType(pgareas.FindControl("txt47"), ASPxTextBox).Text = value.Item(21)
                CType(pgareas.FindControl("txt48"), ASPxMemo).Text = value.Item(22)
                CType(pgareas.FindControl("txt49"), ASPxMemo).Text = value.Item(23)
                Relaciones.SelectParameters.Item("idISAAR").DefaultValue = value.Item(0)
                aspxgdisaarrelacion.DataBind()
            End If


        End If


        If e.RowType = GridViewRowType.EditForm Then
            auxiliar = 1
            habilitaelementos()
            '1 identificación
            CType(pgareas.FindControl("txt11"), ASPxComboBox).SelectedIndex = CType(pgareas.FindControl("txt11"), ASPxComboBox).Items.IndexOfText(e.GetValue("Tipo_de_entidad"))
            CType(pgareas.FindControl("txt12"), ASPxTextBox).Text = e.GetValue("Formas_autorizadas_nombre")
            CType(pgareas.FindControl("txt13"), ASPxTextBox).Text = e.GetValue("Formas_paralelas_nombre")
            CType(pgareas.FindControl("txt14"), ASPxTextBox).Text = e.GetValue("Formas_normalizadas_nombre")
            CType(pgareas.FindControl("txt15"), ASPxTextBox).Text = e.GetValue("Otras_formas_nombre")
            CType(pgareas.FindControl("txt16"), ASPxTextBox).Text = e.GetValue("Identificadores_para_instituciones")
            CType(pgareas.FindControl("txt21"), ASPxDateEdit).Value = e.GetValue("Fechas_de_existencia")
            CType(pgareas.FindControl("txt22"), ASPxMemo).Text = e.GetValue("Historia")
            CType(pgareas.FindControl("txt23"), ASPxTextBox).Text = e.GetValue("Lugares")
            CType(pgareas.FindControl("txt24"), ASPxTextBox).Text = e.GetValue("Estatuto_jurídico")
            CType(pgareas.FindControl("txt25"), ASPxTextBox).Text = e.GetValue("Funciones_ocupaciones_actividades")
            CType(pgareas.FindControl("txt26"), ASPxTextBox).Text = e.GetValue("Atribuciones_Fuentes_legales")
            CType(pgareas.FindControl("txt27"), ASPxTextBox).Text = e.GetValue("Estructuras_internas_Genealogía")
            CType(pgareas.FindControl("txt28"), ASPxTextBox).Text = e.GetValue("Contexto_general")

            CType(pgareas.FindControl("txt41"), ASPxTextBox).Text = e.GetValue("Identificador_registro_autoridad")
            CType(pgareas.FindControl("txt42"), ASPxTextBox).Text = e.GetValue("Identificadores_institución")
            CType(pgareas.FindControl("txt43"), ASPxMemo).Text = e.GetValue("Reglas_convenciones")
            CType(pgareas.FindControl("txt44"), ASPxTextBox).Text = e.GetValue("Estado_elaboración")
            CType(pgareas.FindControl("txt45"), ASPxMemo).Text = e.GetValue("Nivel_detalle")
            CType(pgareas.FindControl("txt46"), ASPxDateEdit).Value = e.GetValue("Fechas_creación_revisión_eliminación")
            CType(pgareas.FindControl("txt47"), ASPxTextBox).Text = e.GetValue("Lenguas_escrituras")
            CType(pgareas.FindControl("txt48"), ASPxMemo).Text = e.GetValue("Fuentes")
            CType(pgareas.FindControl("txt49"), ASPxMemo).Text = e.GetValue("Notas_de_mantenimiento")

        End If

    End Sub


    Protected Sub btNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevo.Click
        btnNuevo.Visible = False
        Dim sv As New WSArchivo.Service1
        pgareas.Visible = True
        auxiliar = 0
        idISAAR = sv.ABC_ISAAR(0, 0, "", "", "", "", "", "", SqlTypes.SqlDateTime.Null, "", "", "", "", "", "", "", "", "", "", "", "", SqlTypes.SqlDateTime.Null, "", "", "")
        lblidISAAR.Text = idISAAR
        gdnivel.DataBind()
        gdnivel.FocusedRowIndex = 0
        Limpiaelementos()
        habilitaelementos()
    End Sub


    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnguardar.Click
        Dim sv As New WSArchivo.Service1
        Dim nID As Integer
        Dim dsNivel As New DataSet
        Dim value As DataRowView
        If aspxgdisaarrelacion.IsEditing Then
            aspxgdisaarrelacion.CancelEdit()
        End If
        If gdnivel.VisibleRowCount = 0 Then
            gdnivel.DataBind()
            value = gdnivel.GetRow(gdnivel.VisibleStartIndex)
        Else
            value = gdnivel.GetRow(gdnivel.FocusedRowIndex)
        End If
        Dim idisaar As Integer
        idisaar = value.Item(0)

        '1 identificación
        Dim txt11 As ASPxComboBox = CType(pgareas.FindControl("txt11"), ASPxComboBox)
        Dim txt12 As ASPxTextBox = CType(pgareas.FindControl("txt12"), ASPxTextBox)
        Dim txt13 As ASPxTextBox = CType(pgareas.FindControl("txt13"), ASPxTextBox)
        Dim txt14 As ASPxTextBox = CType(pgareas.FindControl("txt14"), ASPxTextBox)
        Dim txt15 As ASPxTextBox = CType(pgareas.FindControl("txt15"), ASPxTextBox)
        Dim txt16 As ASPxTextBox = CType(pgareas.FindControl("txt16"), ASPxTextBox)

        '2 bdescripción
        Dim txt21 As ASPxDateEdit = CType(pgareas.FindControl("txt21"), ASPxDateEdit)
        If txt21.Value Is Nothing Then
            txt21.Value = CType(SqlTypes.SqlDateTime.Null, Date)
        End If
        Dim txt22 As ASPxMemo = CType(pgareas.FindControl("txt22"), ASPxMemo)
        Dim txt23 As ASPxTextBox = CType(pgareas.FindControl("txt23"), ASPxTextBox)
        Dim txt24 As ASPxTextBox = CType(pgareas.FindControl("txt24"), ASPxTextBox)
        Dim txt25 As ASPxTextBox = CType(pgareas.FindControl("txt25"), ASPxTextBox)
        Dim txt26 As ASPxTextBox = CType(pgareas.FindControl("txt26"), ASPxTextBox)
        Dim txt27 As ASPxTextBox = CType(pgareas.FindControl("txt27"), ASPxTextBox)
        Dim txt28 As ASPxTextBox = CType(pgareas.FindControl("txt28"), ASPxTextBox)

        '4 control
        Dim txt41 As ASPxTextBox = CType(pgareas.FindControl("txt41"), ASPxTextBox)
        Dim txt42 As ASPxTextBox = CType(pgareas.FindControl("txt42"), ASPxTextBox)
        Dim txt43 As ASPxMemo = CType(pgareas.FindControl("txt43"), ASPxMemo)
        Dim txt44 As ASPxTextBox = CType(pgareas.FindControl("txt44"), ASPxTextBox)
        Dim txt45 As ASPxMemo = CType(pgareas.FindControl("txt45"), ASPxMemo)
        Dim txt46 As ASPxDateEdit = CType(pgareas.FindControl("txt46"), ASPxDateEdit)
        If txt46.Value Is Nothing Then
            txt46.Value = CType(SqlTypes.SqlDateTime.Null, Date)
        End If
        Dim txt47 As ASPxTextBox = CType(pgareas.FindControl("txt47"), ASPxTextBox)
        Dim txt48 As ASPxMemo = CType(pgareas.FindControl("txt48"), ASPxMemo)
        Dim txt49 As ASPxMemo = CType(pgareas.FindControl("txt49"), ASPxMemo)
        Try

            nID = sv.ABC_ISAAR(2, idisaar, txt11.SelectedItem.Text, txt12.Text.ToString, txt13.Text.ToString, txt14.Text.ToString, txt15.Text.ToString, txt16.Text.ToString, txt21.Value, txt22.Text.ToString, txt23.Text.ToString, txt24.Text.ToString, txt25.Text.ToString, txt26.Text.ToString, txt27.Text.ToString, txt28.Text.ToString, txt41.Text.ToString, txt42.Text.ToString, txt43.Text.ToString, txt44.Text.ToString, txt45.Text.ToString, txt46.Value, txt47.Text.ToString, txt48.Text.ToString, txt49.Text.ToString)
            gdnivel.DataBind()
            btnNuevo.Visible = True
            btnguardar.Visible = False
            deshabilitaelementos()
            gdnivel.CancelEdit()
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub gdnivel_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gdnivel.RowDeleting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty

        Dim idisaar As Integer = e.Keys(0)
        gdnivel.CancelEdit()
        e.Cancel = True
        Try
            If aspxgdisaarrelacion.VisibleRowCount > 0 Then
                For intI = 0 To aspxgdisaarrelacion.VisibleRowCount - 1
                    Dim value As DataRowView
                    value = aspxgdisaarrelacion.GetRow(aspxgdisaarrelacion.VisibleStartIndex)
                    Dim idrelacion As Integer = value.Item(0)
                    aspxgdisaarrelacion.DataBind()
                Next
            End If
            sv.ABC_ISAAR(WSArchivo.OperacionesABC.operBaja, idisaar, "", "", "", "", "", "", SqlTypes.SqlDateTime.Null, "", "", "", "", "", "", "", "", "", "", "", "", SqlTypes.SqlDateTime.Null, "", "", "")
            gdnivel.DataBind()

        Catch ex As Exception
            ASPxError.Text = ex.Message
        End Try
    End Sub


    Protected Sub Limpiaelementos()
        For intI = 12 To 16
            CType(pgareas.FindControl("txt" & intI), ASPxTextBox).Text = ""
        Next
        For intI = 23 To 28
            CType(pgareas.FindControl("txt" & intI), ASPxTextBox).Text = ""
        Next
        For intI = 41 To 47
            If intI <> 43 And intI <> 45 And intI <> 46 Then
                CType(pgareas.FindControl("txt" & intI), ASPxTextBox).Text = ""
            End If
        Next
        CType(pgareas.FindControl("txt21"), ASPxDateEdit).Value = ""
        CType(pgareas.FindControl("txt22"), ASPxMemo).Text = ""
        '4 control
        CType(pgareas.FindControl("txt43"), ASPxMemo).Text = ""
        CType(pgareas.FindControl("txt45"), ASPxMemo).Text = ""
        CType(pgareas.FindControl("txt46"), ASPxDateEdit).Value = ""
        CType(pgareas.FindControl("txt48"), ASPxMemo).Text = ""
        CType(pgareas.FindControl("txt49"), ASPxMemo).Text = ""
    End Sub

    Protected Sub deshabilitaelementos()
        For intI = 12 To 16
            CType(pgareas.FindControl("txt" & intI), ASPxTextBox).Enabled = False
        Next
        For intI = 23 To 28
            CType(pgareas.FindControl("txt" & intI), ASPxTextBox).Enabled = False
        Next
        For intI = 41 To 47
            If intI <> 43 And intI <> 45 And intI <> 46 Then
                CType(pgareas.FindControl("txt" & intI), ASPxTextBox).Enabled = False
            End If
        Next

        CType(pgareas.FindControl("txt11"), ASPxComboBox).Enabled = False
        CType(pgareas.FindControl("txt21"), ASPxDateEdit).Enabled = False
        CType(pgareas.FindControl("txt22"), ASPxMemo).Enabled = False
        '4 control
        CType(pgareas.FindControl("txt43"), ASPxMemo).Enabled = False
        CType(pgareas.FindControl("txt45"), ASPxMemo).Enabled = False
        CType(pgareas.FindControl("txt46"), ASPxDateEdit).Enabled = False
        CType(pgareas.FindControl("txt48"), ASPxMemo).Enabled = False
        CType(pgareas.FindControl("txt49"), ASPxMemo).Enabled = False
        aspxgdisaarrelacion.Enabled = False
        btnguardar.Visible = False
    End Sub

    Protected Sub habilitaelementos()
        For intI = 12 To 16
            CType(pgareas.FindControl("txt" & intI), ASPxTextBox).Enabled = True
        Next
        For intI = 23 To 28
            CType(pgareas.FindControl("txt" & intI), ASPxTextBox).Enabled = True
        Next
        For intI = 41 To 47
            If intI <> 43 And intI <> 45 And intI <> 46 Then
                CType(pgareas.FindControl("txt" & intI), ASPxTextBox).Enabled = True
            End If
        Next

        CType(pgareas.FindControl("txt11"), ASPxComboBox).Enabled = True
        CType(pgareas.FindControl("txt21"), ASPxDateEdit).Enabled = True
        CType(pgareas.FindControl("txt22"), ASPxMemo).Enabled = True
        '4 control
        CType(pgareas.FindControl("txt43"), ASPxMemo).Enabled = True
        CType(pgareas.FindControl("txt45"), ASPxMemo).Enabled = True
        CType(pgareas.FindControl("txt46"), ASPxDateEdit).Enabled = True
        CType(pgareas.FindControl("txt48"), ASPxMemo).Enabled = True
        CType(pgareas.FindControl("txt49"), ASPxMemo).Enabled = True
        aspxgdisaarrelacion.Enabled = True
        btnguardar.Visible = True
    End Sub

    Private Sub aspxgdisaarrelacion_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxgdisaarrelacion.RowValidating
        If e.NewValues("Fechas_relación") = Nothing Then
            e.RowError = "El valor de la fecha no puede ser nulo."
        End If

        If e.NewValues("idISAAR_REL") = Nothing Then
            e.RowError = "El valor del nombre no puede ser nulo."
        End If

        If e.NewValues("IDCatalogo_item") = Nothing Then
            e.RowError = "El valor de la naturaleza de la relación no puede ser nulo."
        End If
    End Sub


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

End Class