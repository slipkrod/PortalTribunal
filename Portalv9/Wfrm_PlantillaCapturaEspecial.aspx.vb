Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls
Partial Public Class Wfrm_PlantillaCapturaEspecial
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim descarch As String
#End Region

    Private Sub Wfrm_PlantillaCapturaEspecial_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        CargaArchivo()
        CargaAreas()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Archivo->Fondos->" & descarch
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                Logoff()
                Exit Sub
            End If

            aspxtreenivel.DataBind()
            If aspxtreenivel.Nodes.Count > 0 Then
                llenaCampos()
            End If
        End If
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String

        If container.Expanded Then
            Return container.GetValue("Imagen_Open")
        Else
            Return container.GetValue("Imagen_Close")
        End If
    End Function

    Private Sub CargaArchivo()
        Dim sv As New WSArchivo.Service1
        Dim dsArchivo As DataSet
        dsArchivo = sv.ListaArchivo(Request.QueryString("idArchivo"))
        If dsArchivo.Tables(0).Rows.Count > 0 Then
            lblidNorma.Text = dsArchivo.Tables(0).Rows(0).Item("idNorma")
            descarch = dsArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")
            lblidArchivo.Text = Request.QueryString("idArchivo")
        End If

    End Sub

    Private Sub CargaAreas()
        Dim sv As New WSArchivo.Service1
        Dim dsAreas As DataSet
        Dim intI As Integer

        If lblidNorma.Text <> "" Then
            dsAreas = sv.ListaNormas_Areas_Especial(lblidNorma.Text, Request.QueryString("idplantilla"))

            For intI = 0 To dsAreas.Tables(0).Rows.Count - 1
                CreaTablaElemento(lblidNorma.Text, dsAreas.Tables(0).Rows(intI).Item("idArea"))
            Next
            If dsAreas.Tables(0).Rows.Count > 0 Then
                If Not IsPostBack Then
                    ElementosVisibles(dsAreas.Tables(0).Rows(0).Item("idArea"))
                End If
            End If
        End If
    End Sub

    Private Sub CreaTablaElemento(ByVal idNorma As Integer, ByVal idArea As Integer)
        Dim sv As New WSArchivo.Service1
        Dim dsElementos As DataSet
        Dim intI As Integer
        Dim intJ As Integer

        dsElementos = sv.ListaNormas_Elementos_Especial(idNorma, idArea, Request.QueryString("idPlantilla"))
        For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
            Dim TBCampos As New Table
            Dim dsCampos As DataSet
            dsCampos = sv.ListaNormas_Elementos_Campos_Especial(idNorma, idArea, dsElementos.Tables(0).Rows(intI).Item("idElemento"), Request.QueryString("idPlantilla"))
            TBCampos.ID = "TBCampos" & dsElementos.Tables(0).Rows(intI).Item("idElemento")
            TBCampos.BorderColor = Drawing.Color.AliceBlue
            TBCampos.BorderWidth = 0.5
            TBCampos.BorderStyle = BorderStyle.Solid
            TBCampos.Font.Size = 8
            TBCampos.Font.Name = "Arial"
            Dim nFila As New TableHeaderRow
            Dim nCelda As New TableHeaderCell
            nCelda.Width = PnlElementos.Width
            nCelda.Font.Size = 8
            nCelda.Font.Name = "Arial"
            nCelda.Font.Bold = False
            nCelda.CssClass = "DataList_Aqua"
            nCelda.ForeColor = Drawing.Color.Black
            nCelda.HorizontalAlign = HorizontalAlign.Left
            nCelda.Text = dsElementos.Tables(0).Rows(intI).Item("folio_norma") & " " & dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")
            nFila.Cells.Add(nCelda)
            TBCampos.Rows.Add(nFila)
            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                Dim nFilaC As New TableRow
                Dim nCeldaC As New TableCell
                Dim nCampoT As New CampoSlectura
                nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
                nCeldaC.Width = PnlElementos.Width
                nCeldaC.Controls.Add(nCampoT)
                nFilaC.Cells.Add(nCeldaC)
                TBCampos.Rows.Add(nFilaC)
                nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
            Next
            TBCampos.Visible = False
            TBCampos.TabIndex = idArea
            TBCampos.Width = PnlElementos.Width
            PnlElementos.Controls.Add(TBCampos)
            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                If Not PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then
                    CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                End If
            Next
        Next
    End Sub

    Protected Sub ElementosVisibles(ByVal idArea As String)
        Dim intI As Integer
        For intI = 0 To PnlElementos.Controls.Count - 1
            If Not PnlElementos.Controls(intI).ID Is Nothing Then
                If PnlElementos.Controls(intI).ID.Substring(0, 8) = "TBCampos" Then
                    CType(PnlElementos.Controls(intI), Table).Visible = False
                    If CType(PnlElementos.Controls(intI), Table).TabIndex = idArea Then
                        CType(PnlElementos.Controls(intI), Table).Visible = True
                    End If
                End If
            End If
        Next
    End Sub

    Protected Sub dlAreas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dlAreas.SelectedIndexChanged
        dlAreas.DataBind()
        ElementosVisibles(dlAreas.SelectedValue)
    End Sub
    Protected Sub llenaCampos()
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim dsCampoValor As DataSet
        dsNomraCampos = sv.ListaNormas_Campos(lblidNorma.Text)
        For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
            If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Visible = False
                dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), lblidArchivo.Text, aspxtreenivel.FocusedNode.Key)
                If dsCampoValor.Tables(0).Rows.Count > 0 Then
                    If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                        If dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Length > 0 Then
                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Visible = True
                        End If
                    End If
                End If
            End If
        Next
    End Sub



    Protected Sub aspxtreenivel_FocusedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxtreenivel.FocusedNodeChanged
        llenaCampos()
        ElementosVisibles(dlAreas.SelectedValue)
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sv As New WSArchivo.Service1
        Dim nNodo As New TreeNode
        Dim nNodoID As Integer
        Dim dsNivel As New DataSet
        Dim idnivel As String = CType(aspxtreenivel.FindEditFormTemplateControl("dlNiveles"), ASPxComboBox).SelectedItem.Value
        Dim descripcion As String = CType(aspxtreenivel.FindEditFormTemplateControl("txtDescripcion"), ASPxTextBox).Text.Trim
        Try
            Dim idDocumentoPID As Integer
            If aspxtreenivel.NewNodeParentKey = "" Then
                idDocumentoPID = 0
            Else
                idDocumentoPID = aspxtreenivel.NewNodeParentKey
            End If
            nNodoID = sv.ABC_Archivo_Descripciones(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idArchivo"), 0, "", idnivel, "", 0, descripcion, 0, idDocumentoPID, 0, 0, 0, 0, 0, 0, 0, "", "", "")
            dsNivel = sv.ListaNorma_Nivel(lblidNorma.Text, idnivel)
            'If dsNivel.Tables(0).Rows.Count > 0 Then
            '    'nNodo.ImageUrl = dsNivel.Tables(0).Rows(0).Item("Imagen")
            'End If
            aspxtreenivel.CancelEdit()
        Catch ex As Exception
            'MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub
    Private Sub aspxtreenivel_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs) Handles aspxtreenivel.HtmlRowPrepared
        If (e.RowKind = TreeListRowKind.EditForm) Then
            If (Not (e.NodeKey) Is Nothing) Then
                CType(aspxtreenivel.FindEditFormTemplateControl("dlNiveles"), ASPxComboBox).SelectedIndex = CType(aspxtreenivel.FindEditFormTemplateControl("dlNiveles"), ASPxComboBox).Items.FindByValue(e.GetValue("idNivel").ToString).Index
                CType(aspxtreenivel.FindEditFormTemplateControl("txtdescripcion"), ASPxTextBox).Text = e.GetValue("Descripcion").ToString
                CType(aspxtreenivel.FindEditFormTemplateControl("btnAceptar"), ASPxButton).Visible = False
            Else
                CType(aspxtreenivel.FindEditFormTemplateControl("btnActualizar"), ASPxButton).Visible = False
            End If
        End If
    End Sub

    Private Sub aspxtreenivel_NodeDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles aspxtreenivel.NodeDeleting
        If aspxtreenivel.FocusedNode.Level > 0 Then
            aspxtreenivel.FocusedNode.ParentNode.Focus()
        End If
    End Sub

    Private Sub aspxtreenivel_NodeInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxtreenivel.NodeInserting

    End Sub

    Private Sub ObjectDataSource1_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Updating
        Dim xValor As String
        e.InputParameters("Tipo") = 2
        xValor = e.InputParameters("idDescripcion")

    End Sub

    Protected Sub btnActualizar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sv As New WSArchivo.Service1
        Dim nNodoID As Integer
        Dim dsNivel As New DataSet
        Dim idnivel As String = CType(aspxtreenivel.FindEditFormTemplateControl("dlNiveles"), ASPxComboBox).SelectedItem.Value
        Dim descripcion As String = CType(aspxtreenivel.FindEditFormTemplateControl("txtDescripcion"), ASPxTextBox).Text.Trim
        Try
            nNodoID = sv.ABC_Archivo_Descripciones(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idArchivo"), aspxtreenivel.FocusedNode.Key, "", idnivel, "", 0, descripcion, 0, aspxtreenivel.FocusedNode.DataItem("idDocumentoPID"), 0, 0, 0, 0, 0, 0, 0, "", "", "")
            dsNivel = sv.ListaNorma_Nivel(lblidNorma.Text, idnivel)
            If dsNivel.Tables(0).Rows.Count > 0 Then
                'nNodo.ImageUrl = dsNivel.Tables(0).Rows(0).Item("Imagen")
            End If
            aspxtreenivel.CancelEdit()
        Catch ex As Exception
            'MsgBox1.ShowMessage(ex.Message)
        End Try

    End Sub

End Class