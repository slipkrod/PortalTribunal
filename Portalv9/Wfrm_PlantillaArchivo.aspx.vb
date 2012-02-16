Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Public Class wfrm_PlantillaArchivo
    Inherits System.Web.UI.Page

    Public tTicket As IDTicket
    Public AreaActiva As Integer

    Private Sub Wfrm_PlantillaArchivo_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        'CreaTablaElemento()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Page.IsPostBack Then
                'lblTitle.Text = "Normas->Plantilla Maestra   [" & Request.QueryString("Norma") & "]"
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    LogOff()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub CreaTablaElemento()
        Dim sv As New WSArchivo.Service1
        Dim dsElementos As DataSet
        Dim intI As Integer

        dsElementos = sv.ListaArchivo_Cat_Elementos()
        For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
            Dim DLCampos As New DataList
            Dim dsCampos As DataSet

            dsCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intI).Item("idElemento"))
            DLCampos.ID = "DLCampos" & dsElementos.Tables(0).Rows(intI).Item("idElemento")
            DLCampos.BorderColor = Drawing.Color.AliceBlue
            DLCampos.BorderWidth = 0.5
            DLCampos.BorderStyle = BorderStyle.Solid
            DLCampos.HeaderTemplate = Page.LoadTemplate("WebUsrCtrls/PlantillaHeaderCampo.ascx")
            DLCampos.ItemTemplate = Page.LoadTemplate("WebUsrCtrls/CamposElemento.ascx")
            DLCampos.ShowFooter = True
            DLCampos.ShowHeader = True
            DLCampos.GridLines = GridLines.Both

            DLCampos.DataSource = dsCampos
            DLCampos.DataKeyField = "idIndice"
            DLCampos.DataBind()
            DLCampos.Visible = True
            DLCampos.TabIndex = 0
            DLCampos.Width = 600
            DLCampos.BorderStyle = BorderStyle.Solid
            DLCampos.BorderWidth = 1
            DLCampos.BorderColor = Drawing.Color.AliceBlue


            If Not DLCampos.Controls(0).Controls(0).FindControl("Titulo") Is Nothing Then
                Dim titulo As ASPxLabel = CType(DLCampos.Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel)
                titulo.Text = dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")
            End If

            AddHandler DLCampos.EditCommand, AddressOf DLCampos_editCommand
            AddHandler DLCampos.ItemCommand, AddressOf DLCampos_ItemCommand
            AddHandler DLCampos.DeleteCommand, AddressOf DLCampos_DeleteCommand

            'PnlElementos.Controls.Add(DLCampos)

        Next
    End Sub

    Protected Sub DLCampos_editCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim sv As New WSArchivo.Service1
        Dim dsCampos As DataSet
        Dim nDatalist As DataList
        nDatalist = source
        ASPxError.Text = ""
        'PantallaCaptura.HeaderText = "Agregar campo en "
        lblElementoID.Text = nDatalist.ID.Substring(8)
        lblDataListID.Text = nDatalist.ID
        'lblElemento.Text = CType(nDatalist.Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text

        dsCampos = sv.ListaArchivo_Cat_Campo(lblElementoID.Text, e.CommandArgument)
        'Tipo.SelectedIndex = Tipo.Items.IndexOfValue(CType(dsCampos.Tables(0).Rows(0).Item("Indice_Tipo"), Integer))
        'Longitud.Value = dsCampos.Tables(0).Rows(0).Item("Indice_LongitudMax")
        'CampoNombre.Text = dsCampos.Tables(0).Rows(0).Item("Indice_descripcion")
        'Mascara.Text = dsCampos.Tables(0).Rows(0).Item("Indice_Mascara")
        'Obligatorio.Checked = dsCampos.Tables(0).Rows(0).Item("Indice_Obligatorio")
        'vVisible.Checked = dsCampos.Tables(0).Rows(0).Item("Indice_Visible")

        lblEstado.Text = "Editar"
        lblidIndice.Text = e.CommandArgument
        'PantallaCaptura.ShowOnPageLoad = True
    End Sub
    Protected Sub DLCampos_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim sv As New WSArchivo.Service1
        ASPxError.Text = ""
        Dim dsCampos As DataSet
        Dim dsvalorcampo As DataSet
        Dim Titulo As String
        Dim bandel As Boolean = False
        Dim nDatalist As DataList
        nDatalist = source
        lblElementoID.Text = nDatalist.ID.Substring(8)

        dsvalorcampo = sv.ListaArchivo_val_Campo_bus(lblElementoID.Text, e.CommandArgument)
        If dsvalorcampo.Tables(0).Rows.Count > 0 Then
            For Each valorcampo As DataRow In dsvalorcampo.Tables(0).Rows

                Dim valor As String = valorcampo("Valor")

                If Not valor Is DBNull.Value Then
                    If valor.ToString.Length > 0 Then
                        bandel = True
                        Exit For
                    End If
                End If
            Next
        End If
        If bandel Then
            ASPxError.Text = "La variable no puede ser eliminada ya que tiene valores"
        Else
            sv.ABC_Archivo_Elementos_Campos(WSArchivo.OperacionesABC.operBaja, lblElementoID.Text, e.CommandArgument, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
            ASPxError.Text = "Se ejecutó correctamente la operación de eliminar solicitada. "
        End If

        dsCampos = sv.ListaArchivo_Cat_Campos(lblElementoID.Text)
        Titulo = CType(nDatalist.Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text
        nDatalist.DataSource = dsCampos
        nDatalist.DataBind()
        CType(nDatalist.Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text = Titulo


    End Sub
    Protected Sub DLCampos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        ASPxError.Text = ""
        If e.CommandName = "Select" Then
            Dim nDatalist As DataList
            nDatalist = source

            'Longitud.Text = "0"
            'CampoNombre.Text = ""
            'Mascara.Text = ""
            'Obligatorio.Checked = False
            'vVisible.Checked = True

            lblElementoID.Text = nDatalist.ID.Substring(8)
            lblDataListID.Text = nDatalist.ID

            'lblElemento.Text = CType(nDatalist.Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text
            lblEstado.Text = "Add"
            'PantallaCaptura.ShowOnPageLoad = True
        End If
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    'Protected Sub Tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Tipo.SelectedIndexChanged
    '           Select Tipo.SelectedItem.Value
    '        Case 0
    '            'Longitud.Visible = True
    '            'lblLongitud.Visible = True
    '        Case Else
    '            'Longitud.Visible = False
    '            'lblLongitud.Visible = False
    '    End Select
    'End Sub

    'Protected Sub ASPxButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxButton2.Click
    'Dim sv As New WSArchivo.Service1
    'Dim dsCampos As DataSet
    'Dim Titulo As String
    'ASPxError.Text = ""
    ''If Longitud.Value = 0 Then
    ''    'Longitud.Value = 20
    ''End If
    '    Select lblEstado.Text
    '    Case "Editar"
    '        sv.ABC_Archivo_Elementos_Campos(WSArchivo.OperacionesABC.operCambio, lblElementoID.Text, lblidIndice.Text, CampoNombre.Text, Tipo.SelectedItem.Value, Longitud.Text, Mascara.Text, Obligatorio.Checked, 0, 1, 0, 0, 0, vVisible.Checked, 0)
    '        ASPxError.Text = "Se ejecutó correctamente la operación de editar solicitada. "
    '    Case "Add"
    '        sv.ABC_Archivo_Elementos_Campos(WSArchivo.OperacionesABC.operAlta, lblElementoID.Text, 0, CampoNombre.Text, Tipo.SelectedItem.Value, Longitud.Text, Mascara.Text, Obligatorio.Checked, 0, 1, 0, 0, 0, vVisible.Checked, 0)
    '        ASPxError.Text = "Se ejecutó correctamente la operación de añadir solicitada. "
    'End Select
    'dsCampos = sv.ListaArchivo_Cat_Campos(lblElementoID.Text)
    'If Not PnlElementos.FindControl(lblDataListID.Text) Is Nothing Then
    '    Titulo = CType(CType(PnlElementos.FindControl(lblDataListID.Text), DataList).Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text
    '    CType(PnlElementos.FindControl(lblDataListID.Text), DataList).DataSource = dsCampos
    '    CType(PnlElementos.FindControl(lblDataListID.Text), DataList).DataBind()
    '    CType(CType(PnlElementos.FindControl(lblDataListID.Text), DataList).Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text = Titulo
    'End If

    'PantallaCaptura.ShowOnPageLoad = False

    'End Sub

    Protected Sub aspxgdareas_CustomJSProperties(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs) Handles aspxgdareas.CustomJSProperties

    End Sub


    Protected Sub aspxgdareas_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxgdareas.RowInserting
        'e.NewValues.Item("Tipo") = 0
    End Sub
    Protected Sub aspxgdareas_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)

    End Sub

    Protected Sub aspxgdareas_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)

    End Sub

    Protected Sub aspxgdareas_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxgdareas.PageIndexChanged

    End Sub

    Private Sub aspxgdareas_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxgdareas.RowValidating
        If e.NewValues("Elemento_descripcion") = Nothing Then
            e.RowError = "El nombre del Elemento no puede ser nulo."
        End If
    End Sub

    Protected Sub aspxgdelementos_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("idElemento") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
    End Sub

    Protected Sub aspxgdelementos_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        e.NewValues.Item("idElemento") = Session("idElemento")
    End Sub

    Protected Sub aspxgdelementos_RowDeleted(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletedEventArgs)
        If Not e.Exception Is Nothing Then
            ASPxLabel1.Text = e.Exception.Message
        End If
    End Sub


End Class