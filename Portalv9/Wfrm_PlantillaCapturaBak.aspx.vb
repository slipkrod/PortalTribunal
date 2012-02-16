Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxRoundPanel
Imports DevExpress.Web.ASPxCallbackPanel

Partial Public Class Wfrm_PlantillaCapturaBak
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim descarch As String
    Dim aux As Integer = 0
    Dim iValTemp As Integer
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargaArchivo()
            aspxtreenivel.DataBind()
            aspxtreenivel.ExpandAll()
            AddTabs()
            lblTitle.Text = "Archivo->Fondos->" & descarch
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
        Else
            'AddTabs()
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
        End If
    End Sub

    Protected Sub aspxguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxguardar.Click
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim dsElementos As DataSet
        Dim ValorCampo As String
        Dim nodo As TreeListNode = aspxtreenivel.FindNodeByKeyValue(aspxtreenivel.FocusedNode.Key)
        Dim idnivel = nodo.DataItem(3)
        Try
            dsElementos = sv.ListaNormas_Elementos_CamposXArea_Serie(-1, nodo.DataItem("idSerie"))
            dsNomraCampos = sv.ListaNormas_Elementos_CamposxSerie(nodo.DataItem("idSerie"))
            For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                If Not pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                    Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                        Case 0
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, iValTemp, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 1
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, iValTemp, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 2
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, iValTemp, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 3
                            ValorCampo = CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini & "-" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, iValTemp, ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 4
                            ValorCampo = CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini & "/" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini & "-" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin & "/" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, iValTemp, ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 5
                            ValorCampo = CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini & "-" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, iValTemp, ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 6
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, iValTemp, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 7
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, iValTemp, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 11
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, iValTemp, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 13
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).cambiovalor Then
                                sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, iValTemp, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                            End If
                    End Select
                End If
            Next
            MsgBox1.ShowMessage("Los datos se guardaron correctamente")
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
        ShowViewStateControlsIndices()
    End Sub

    Protected Sub aspxtreenivel_FocusedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxtreenivel.FocusedNodeChanged
        ASPxError.Text = ""
        AddTabs()
        ShowViewStateControlsIndices()
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        ASPxError.Text = ""
    End Sub

    Sub ShowViewStateControlsIndices()
        aspxEditar.Visible = True
        tableEditando.Visible = False
        ShowHideControls(True)
    End Sub

    Protected Sub AddTabs()
        If aspxtreenivel.IsNewNodeEditing Or aspxtreenivel.IsEditing Then Return
        If (aspxtreenivel.Nodes.Count > 0 And Not aspxtreenivel.FocusedNode Is Nothing) Then
            Dim sv As New WSArchivo.Service1
            Dim dsAreas As DataSet
            Dim intI As Integer
            pgareas.TabPages.Clear()
            If lblidNorma.Text <> "" Then
                dsAreas = sv.ListaNormas_Elementos_CamposXArea_Serie(-1, aspxtreenivel.FocusedNode.Item("idSerie"))
                For intI = 0 To dsAreas.Tables(0).Rows.Count - 1
                    CreaTablaElementotab(dsAreas.Tables(0).Rows(intI).Item("idArea"), dsAreas.Tables(0).Rows(intI).Item("idSerie"), dsAreas.Tables(0).Rows(intI).Item("Area_descripcion"))
                Next
            End If
            llenaCampostab(aspxtreenivel.FocusedNode.Key, aspxtreenivel.FocusedNode.Item("idSerie"), aspxtreenivel.FocusedNode.DataItem(2))
            ShowHideControls(True)
            tableIndices.Visible = True
        Else
            tableIndices.Visible = False
        End If
    End Sub

    Private Sub CreaTablaElementotab(ByVal idArea As Integer, ByVal idSerie As Integer, ByVal AreaDescripcion As String)
        Dim sv As New WSArchivo.Service1
        Dim dsElementos As DataSet
        Dim intI As Integer
        Dim intJ As Integer
        dsElementos = sv.ListaNormas_Elementos_CamposXArea_Serie(idArea, idSerie)
        Dim tab As New TabPage()
        tab.Text = AreaDescripcion
        tab.VisibleIndex = idArea
        If dsElementos.Tables(0).Rows.Count > 0 Then
            pgareas.TabPages.Add(tab)
        End If
        For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
            Dim TBCampos As New Table
            Dim dsCampos As DataSet
            Dim ancho As Integer = 700
            dsCampos = sv.ListaNormas_Elementos_Campo(lblidNorma.Text, idArea, dsElementos.Tables(0).Rows(intI).Item("idElemento"), dsElementos.Tables(0).Rows(intI).Item("idIndice"))
            TBCampos.ID = "TBCampos" & intI & "_" & dsElementos.Tables(0).Rows(intI).Item("idElemento")
            TBCampos.BorderWidth = 0.5
            TBCampos.Font.Size = 8
            TBCampos.Font.Name = "Arial"

            Dim nFila As New TableHeaderRow
            Dim nCelda As New TableHeaderCell

            If tab.FindControl((dsElementos.Tables(0).Rows(intI).Item("folio_norma") & dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")).ToString().Replace(" ", "")) Is Nothing Then
                nCelda.Width = ancho
                nCelda.Font.Size = 8
                nCelda.Font.Name = "Arial"
                nCelda.Font.Bold = True ' false
                nCelda.ForeColor = Drawing.Color.Black
                nCelda.Text = dsElementos.Tables(0).Rows(intI).Item("folio_norma") & " " & dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")
                nCelda.ID = (dsElementos.Tables(0).Rows(intI).Item("folio_norma") & dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")).ToString().Replace(" ", "")
                nCelda.HorizontalAlign = HorizontalAlign.Left
            End If
            nFila.Cells.Add(nCelda)
            TBCampos.Rows.Add(nFila)
            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                Dim nFilaC As New TableRow
                Dim nCeldaC As New TableCell

                If dsCampos.Tables(0).Rows(intJ).Item("Indice_Visible") = "1" Then
                    nFilaC.Visible = True
                Else
                    nFilaC.Visible = False
                End If

                Dim nCampoTview As New CampoSlectura
                nCampoTview = CType(LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
                nCampoTview.ID = "vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                Select Case dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                    Case 0
                        Dim nCampoT As New CampoTexto
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoTexto.ascx"), CampoTexto)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 1
                        Dim nCampoT As New CampoTextoLargo
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoTextoLargo.ascx"), CampoTextoLargo)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 2
                        Dim nCampoT As New CampoFecha
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoFecha.ascx"), CampoFecha)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)

                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 3
                        Dim nCampoT As New CampoPeriodoFechas
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoFechas.ascx"), CampoPeriodoFechas)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 4
                        Dim nCampoT As New CampoPeriodoMesAno
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoMesAno.ascx"), CampoPeriodoMesAno)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 5
                        Dim nCampoT As New CampoPeriodoAno
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoAno.ascx"), CampoPeriodoAno)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 6
                        Dim nCampoT As New CampoSI_NO
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSI_NO.ascx"), CampoSI_NO)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 7
                        Dim nCampoT As New CampoEntero
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoEntero.ascx"), CampoEntero)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 8, 9, 10
                        Dim nCampoT As New CampoSlectura
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 11
                        Dim nCampoT As New CampoCatalogo
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoCatalogo.ascx"), CampoCatalogo)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 12
                        Dim nCampoT As New CampoGrid
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoGrid.ascx"), CampoGrid)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 13
                        Dim nCampoT As New CampoCatalogoISAAR
                        nCampoT.Visible = False
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoCatalogoISAAR.ascx"), CampoCatalogoISAAR)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 14
                        Dim nCampoT As New CampoGridISAAR
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoGridISAAR.ascx"), CampoGridISAAR)
                        nCampoT.Visible = False
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoTview)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                End Select
            Next

            TBCampos.Visible = True
            TBCampos.TabIndex = idArea
            TBCampos.Width = ancho

            Dim contentControl As New Control
            contentControl.Controls.Add(TBCampos)
            Try
                tab.Controls.Add(contentControl)
            Catch ex As Exception
            End Try

            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                trMainH.Style("Height") = String.Concat((Integer.Parse(trMainH.Style("Height").Replace("px", "")) + 25).ToString(), "px")
                If Not tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then
                    CType(tab.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    CType(tab.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                    Select Case dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                        Case 0
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoLongitud = Integer.Parse(dsCampos.Tables(0).Rows(intJ).Item("Indice_LongitudMax"))
                            If Not IsDBNull(dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoMascara = dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoMascaraMsgDeError = "Formato incorrecto, recuerde que el formato es:<BR> " + dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")
                            End If
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 1
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 2
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 3
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_IniCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_FinCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                Try
                                    CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(0)
                                Catch ex As Exception
                                End Try
                                Try
                                    CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(1)
                                Catch ex As Exception
                                End Try
                            End If
                        Case 4
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                Try
                                    CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(0).Split("/")(0)
                                    CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(0).Split("/")(1)
                                Catch ex As Exception
                                End Try
                                Try
                                    CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(1).Split("/")(0)
                                    CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(1).Split("/")(1)
                                Catch ex As Exception
                                End Try
                            End If
                        Case 5
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                Try
                                    CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).Año_Ini = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(0)
                                Catch ex As Exception
                                End Try
                                Try
                                    CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).Año_Fin = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(1)
                                Catch ex As Exception
                                End Try
                            End If
                        Case 6
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 7
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 8, 9, 10
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 11
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")
                            If dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID").ToString.Length > 0 Then CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).ValorCatalogo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).ValorCatalogo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 12
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")

                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idArea = dsCampos.Tables(0).Rows(intJ).Item("idArea")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idElemento = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idIndice = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Indice_Tipo = 12
                        Case 13
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogoISAAR).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogoISAAR).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        Case 14
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")

                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).idArea = dsCampos.Tables(0).Rows(intJ).Item("idArea")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).idElemento = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).idIndice = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).Indice_Tipo = 14
                    End Select
                End If
            Next
        Next
    End Sub

    Protected Sub llenaCampostab(ByVal iddescrip As Integer, ByVal idlSerie As Integer, ByVal idNivel As Integer)
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim dsCampoValor As DataSet
        Dim dsConcatenaPadres As DataSet
        Dim dsFuncCampoValor As DataSet
        dsNomraCampos = sv.ListaNormas_Elementos_CamposxSerie(idlSerie)
        For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
            If Not CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura) Is Nothing Then
                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
            End If
            If Not pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                    Case 0
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 1
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).TextoCampo.Trim = "Nivel de descripción" Then
                        End If
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 2
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 3
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = ""
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                Try
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0)
                                Catch ex As Exception
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = "1/1900"
                                End Try
                                Try
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1)
                                Catch ex As Exception
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = "1/1900"
                                End Try
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 4
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                Try
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Split("-")(0).Split("/")(0)
                                Catch
                                End Try
                                Try
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Split("-")(0).Split("/")(1)
                                Catch
                                End Try
                                Try
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Split("-")(1).Split("/")(0)
                                Catch
                                End Try
                                Try
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Split("-")(1).Split("/")(1)
                                Catch
                                End Try
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If

                    Case 5
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = "0"
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = "0"

                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0)
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1)
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 6
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = "0"
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 7
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = "0"
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 8
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Maximo_valor(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Maximo") Is DBNull.Value Then
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Maximo")
                                    CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                End If
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 9
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Minimo_valor(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Minimo") Is DBNull.Value Then
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Minimo")
                                    CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                End If
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 10
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Suma_valor_hijos(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Suma") Is DBNull.Value Then
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Suma")
                                    CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                End If
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 11
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo = "-1"
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 12
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        Session("idDescripcion") = iddescrip
                        Session("idNivel") = idNivel

                        If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).Muestra_Padres = True Then
                            dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                        End If
                    Case 13
                        'CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).ValorCampo = "-1"
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                Dim dsidISAAR As DataSet
                                dsidISAAR = sv.ListaISAARxid(dsCampoValor.Tables(0).Rows(0).Item("Valor"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).EntidadValor = dsidISAAR.Tables(0).Rows(0).Item("Tipo_de_entidad")
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")

                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 14
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        Session("idDescripcion") = iddescrip
                        Session("idNivel") = idNivel

                        If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGridISAAR).Muestra_Padres = True Then
                            dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGridISAAR).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                        End If
                End Select
            End If
        Next

    End Sub

    Protected Sub dsTipoDeExpediente_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsTipoDeExpediente.Selecting
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            e.InputParameters("NoIdentidad") = tTicket.NoIdentidad
        Catch ex As Exception
            LogOff()
        End Try
    End Sub

    Private Sub aspxtreenivel_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs) Handles aspxtreenivel.HtmlRowPrepared
        Try
            If (e.RowKind = TreeListRowKind.EditForm) Then
                Dim rpIndicesEscenciales As ASPxRoundPanel = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("rpIndicesEscenciales"), ASPxRoundPanel)
                Dim panel As ASPxCallbackPanel = CType(rpIndicesEscenciales.FindControl("cbpEC"), ASPxCallbackPanel)
                Dim rpHeader As ASPxRoundPanel = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("rpHeader"), ASPxRoundPanel)
                Dim txtdescripcion As ASPxTextBox = CType(panel.FindControl("txtdescripcion"), ASPxTextBox)
                Dim cmbnivel As ASPxComboBox = CType(rpHeader.FindControl("dlNiveles"), ASPxComboBox)
                Dim cbSerie As ASPxComboBox = CType(rpHeader.FindControl("cbSerie"), ASPxComboBox)
                Dim Key As String = CType(sender, ASPxTreeList).IsNewNodeEditing

                If Not cmbnivel.SelectedItem Is Nothing Then
                    Session("idNivel") = cmbnivel.SelectedItem.Value
                    cbSerie.DataBind()
                End If
                If (Not (e.NodeKey) Is Nothing) Then
                    Dim nodo As TreeListNode = aspxtreenivel.FindNodeByKeyValue(aspxtreenivel.EditingNodeKey)
                    cmbnivel.SelectedIndex = cmbnivel.Items.FindByValue(e.GetValue("idNivel").ToString).Index
                    Session("idNivel") = cmbnivel.SelectedItem.Value
                    cbSerie.DataBind()
                    cbSerie.SelectedIndex = cbSerie.Items.FindByValue(e.GetValue("idSerie")).Index
                    txtdescripcion.Text = e.GetValue("Descripcion").ToString

                    Dim txtCodigo As ASPxTextBox = CType(panel.FindControl("txtCodigo"), ASPxTextBox)
                    Dim lblCodigo As ASPxLabel = CType(panel.FindControl("lblCodigo"), ASPxLabel)
                    txtCodigo.Text = e.GetValue("Codigo_clasificacion")
                    lblCodigo.Text = e.GetValue("Codigo_clasificacion")
                    Select Case e.GetValue("FormatoCodigo")
                        Case "1"
                            txtCodigo.Visible = True
                            lblCodigo.Visible = False
                        Case "2"
                            txtCodigo.Visible = True
                            lblCodigo.Visible = False
                        Case "3"
                            txtCodigo.Visible = False
                            lblCodigo.Visible = True
                        Case "4"
                            txtCodigo.Visible = False
                            lblCodigo.Visible = True
                        Case Else
                            txtCodigo.Visible = True
                            lblCodigo.Visible = False
                    End Select
                    CType(panel.FindControl("Periodo_guardaActivo"), ASPxSpinEdit).Value = e.GetValue("Periodo_guardaActivo")
                    If Not CType(panel.FindControl("idFrecuencia_guardaActivo"), ASPxComboBox).Items.FindByValue(e.GetValue("idFrecuencia_guardaActivo")) Is Nothing Then
                        CType(panel.FindControl("idFrecuencia_guardaActivo"), ASPxComboBox).Items.FindByValue(e.GetValue("idFrecuencia_guardaActivo")).Selected = True
                    End If

                    CType(panel.FindControl("Periodo_guardaInactivo"), ASPxSpinEdit).Value = e.GetValue("Periodo_guardaInactivo")
                    If Not CType(panel.FindControl("idFrecuencia_guardaInactivo"), ASPxComboBox).Items.FindByValue(e.GetValue("idFrecuencia_guardaInactivo")) Is Nothing Then
                        CType(panel.FindControl("idFrecuencia_guardaInactivo"), ASPxComboBox).Items.FindByValue(e.GetValue("idFrecuencia_guardaInactivo")).Selected = True
                    End If

                    CType(panel.FindControl("Valor_administrativo"), ASPxCheckBox).Value = e.GetValue("Valor_administrativo")
                    CType(panel.FindControl("Valor_legal"), ASPxCheckBox).Value = e.GetValue("Valor_legal")
                    CType(panel.FindControl("Valor_contable"), ASPxCheckBox).Value = e.GetValue("Valor_contable")

                    If Not CType(panel.FindControl("Metodo_Destruccion"), ASPxComboBox).Items.FindByValue(e.GetValue("Metodo_Destruccion")) Is Nothing Then
                        CType(panel.FindControl("Metodo_Destruccion"), ASPxComboBox).Items.FindByValue(e.GetValue("Metodo_Destruccion")).Selected = True
                    End If

                    If Not CType(panel.FindControl("Clasificacion_De_Informacion"), ASPxComboBox).Items.FindByValue(e.GetValue("Clasificacion_De_Informacion")) Is Nothing Then
                        CType(panel.FindControl("Clasificacion_De_Informacion"), ASPxComboBox).Items.FindByValue(e.GetValue("Clasificacion_De_Informacion")).Selected = True
                    End If

                    CType(panel.FindControl("Fecha_Alta"), ASPxLabel).Text = e.GetValue("Fecha_Alta")
                    CType(panel.FindControl("Fecha_Ultimo_Cambio"), ASPxLabel).Text = e.GetValue("Fecha_Ultimo_Cambio")

                End If
                ShowViewStateControlsIndices()
            End If
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
            ASPxError.Visible = True
        End Try
    End Sub

    Protected Sub cbSerie_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Session("idNivel") = e.Parameter.ToString
        CType(CType(CType(aspxtreenivel, ASPxTreeList).FindEditFormTemplateControl("rpHeader"), ASPxRoundPanel).FindControl("cbSerie"), ASPxComboBox).DataBind()
    End Sub

    Protected Sub aspxtreenivel_NodeInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxtreenivel.NodeInserting
        Try
            Dim rpHeader As ASPxRoundPanel = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("rpHeader"), ASPxRoundPanel)
            Dim rpIndicesEscenciales As ASPxRoundPanel = CType(CType(aspxtreenivel, ASPxTreeList).FindEditFormTemplateControl("rpIndicesEscenciales"), ASPxRoundPanel)
            Dim panel As ASPxCallbackPanel = CType(rpIndicesEscenciales.FindControl("cbpEC"), ASPxCallbackPanel)
            e.NewValues("idNivel") = CType(rpHeader.FindControl("dlNiveles"), ASPxComboBox).SelectedItem.Value
            e.NewValues("idSerie") = CType(rpHeader.FindControl("cbSerie"), ASPxComboBox).SelectedItem.Value
            e.NewValues("Descripcion") = CType(panel.FindControl("txtdescripcion"), ASPxTextBox).Text
            If aspxtreenivel.NewNodeParentKey = "" Then
                e.NewValues("idDocumentoPID") = 0
            Else
                e.NewValues("idDocumentoPID") = aspxtreenivel.NewNodeParentKey
            End If
            e.NewValues("FormatoCodigo") = CType(rpHeader.FindControl("cbSerie"), ASPxComboBox).SelectedItem.GetValue("Clave")
            Select Case e.NewValues("FormatoCodigo")
                Case "1"
                    e.NewValues("Codigo_clasificacion") = CType(panel.FindControl("txtCodigo"), ASPxTextBox).Text
                Case "2"
                    e.NewValues("Codigo_clasificacion") = CType(panel.FindControl("txtCodigo"), ASPxTextBox).Text
                Case "3"
                    'Obtener el codigo automaticamente global de nuevo por si cambio
                    Dim sv As New WSArchivo.Service1
                    e.NewValues("Codigo_clasificacion") = sv.Func_GeneraCodigoDeSeries(Request.QueryString("idArchivo"), 3, e.NewValues("idDocumentoPID"))
                Case "4"
                    Dim sv As New WSArchivo.Service1
                    'Obtener el codigo automaticamente por serie de nuevo por si cambio
                    e.NewValues("Codigo_clasificacion") = sv.Func_GeneraCodigoDeSeries(Request.QueryString("idArchivo"), 4, e.NewValues("idDocumentoPID"))
            End Select
            e.NewValues("idFrecuencia_guardaActivo") = CType(panel.FindControl("idFrecuencia_guardaActivo"), ASPxComboBox).SelectedItem.Value
            e.NewValues("Periodo_guardaActivo") = CType(panel.FindControl("Periodo_guardaActivo"), ASPxSpinEdit).Value
            e.NewValues("idFrecuencia_guardaInactivo") = CType(panel.FindControl("idFrecuencia_guardaInactivo"), ASPxComboBox).SelectedItem.Value
            e.NewValues("Periodo_guardaInactivo") = CType(panel.FindControl("Periodo_guardaInactivo"), ASPxSpinEdit).Value
            e.NewValues("Valor_administrativo") = CType(panel.FindControl("Valor_administrativo"), ASPxCheckBox).Value
            e.NewValues("Valor_legal") = CType(panel.FindControl("Valor_legal"), ASPxCheckBox).Value
            e.NewValues("Valor_contable") = CType(panel.FindControl("Valor_contable"), ASPxCheckBox).Value
            e.NewValues("Metodo_Destruccion") = CType(panel.FindControl("Metodo_Destruccion"), ASPxComboBox).SelectedItem.Value
            e.NewValues("Clasificacion_De_Informacion") = CType(panel.FindControl("Clasificacion_De_Informacion"), ASPxComboBox).SelectedItem.Value
            'e.NewValues("Fecha_Alta") = CType(panel.FindControl("Fecha_Alta"), ASPxLabel).Text
            e.NewValues("Fecha_Ultimo_Cambio") = Now
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
            ASPxError.Visible = True
        End Try
    End Sub

    Protected Sub aspxtreenivel_NodeDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles aspxtreenivel.NodeDeleting

    End Sub

    Protected Sub aspxtreenivel_NodeUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles aspxtreenivel.NodeUpdating
        Try
            Dim rpHeader As ASPxRoundPanel = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("rpHeader"), ASPxRoundPanel)
            Dim rpIndicesEscenciales As ASPxRoundPanel = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("rpIndicesEscenciales"), ASPxRoundPanel)
            Dim panel As ASPxCallbackPanel = CType(rpIndicesEscenciales.FindControl("cbpEC"), ASPxCallbackPanel)
            e.NewValues("idNivel") = CType(rpHeader.FindControl("dlNiveles"), ASPxComboBox).SelectedItem.Value
            e.NewValues("idSerie") = CType(rpHeader.FindControl("cbSerie"), ASPxComboBox).SelectedItem.Value
            e.NewValues("Descripcion") = CType(panel.FindControl("txtdescripcion"), ASPxTextBox).Text
            If CType(panel.FindControl("txtCodigo"), ASPxTextBox).Visible Then
                e.NewValues("Codigo_clasificacion") = CType(panel.FindControl("txtCodigo"), ASPxTextBox).Text
            End If
            e.NewValues("idFrecuencia_guardaActivo") = CType(panel.FindControl("idFrecuencia_guardaActivo"), ASPxComboBox).SelectedItem.Value
            e.NewValues("Periodo_guardaActivo") = CType(panel.FindControl("Periodo_guardaActivo"), ASPxSpinEdit).Value
            e.NewValues("idFrecuencia_guardaInactivo") = CType(panel.FindControl("idFrecuencia_guardaInactivo"), ASPxComboBox).SelectedItem.Value
            e.NewValues("Periodo_guardaInactivo") = CType(panel.FindControl("Periodo_guardaInactivo"), ASPxSpinEdit).Value
            e.NewValues("Valor_administrativo") = CType(panel.FindControl("Valor_administrativo"), ASPxCheckBox).Value
            e.NewValues("Valor_legal") = CType(panel.FindControl("Valor_legal"), ASPxCheckBox).Value
            e.NewValues("Valor_contable") = CType(panel.FindControl("Valor_contable"), ASPxCheckBox).Value
            e.NewValues("Metodo_Destruccion") = CType(panel.FindControl("Metodo_Destruccion"), ASPxComboBox).SelectedItem.Value
            e.NewValues("Clasificacion_De_Informacion") = CType(panel.FindControl("Clasificacion_De_Informacion"), ASPxComboBox).SelectedItem.Value
            'e.NewValues("Fecha_Alta") = CType(panel.FindControl("Fecha_Alta"), ASPxLabel).Text
            'e.NewValues("Fecha_Ultimo_Cambio") = CType(panel.FindControl("Fecha_Ultimo_Cambio"), ASPxLabel).Text
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub ObjectDataSource1_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Inserting
        Try
            If e.InputParameters("idArchivo") Is Nothing Then
                e.InputParameters("idArchivo") = Request.QueryString("idArchivo").ToString()
            End If
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub ObjectDataSource1_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Inserted
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub aspxtreenivel_EditingOperationCompleted(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListEditingOperationEventArgs) Handles aspxtreenivel.EditingOperationCompleted
        Try
            If e.Operation = TreeListEditingOperation.Update Then
                '                AddTabs()
            Else
                aspxtreenivel.FocusedNode.Selected = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub aspxCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxCancelar.Click
        ShowViewStateControlsIndices()
    End Sub

    Protected Sub aspxEditar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxEditar.Click
        aspxEditar.Visible = False
        tableEditando.Visible = True
        ShowHideControls(False)
    End Sub

    Sub ShowHideControls(ByVal bVisible As Boolean)
        If aspxtreenivel.FocusedNode Is Nothing Then Return
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim dsElementos As DataSet
        Dim nodo As TreeListNode = aspxtreenivel.FindNodeByKeyValue(aspxtreenivel.FocusedNode.Key)
        Dim idnivel = nodo.DataItem(3)
        Try
            dsElementos = sv.ListaNormas_Elementos_CamposXArea_Serie(-1, nodo.DataItem("idSerie"))
            dsNomraCampos = sv.ListaNormas_Elementos_CamposxSerie(nodo.DataItem("idSerie"))
            For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                If Not pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                    CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Visible = bVisible
                    Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                        Case 0
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).Visible = Not bVisible
                        Case 1
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).Visible = Not bVisible
                        Case 2
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).Visible = Not bVisible
                        Case 3
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Visible = Not bVisible
                        Case 4
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Visible = Not bVisible
                        Case 5
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Visible = Not bVisible
                        Case 6
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).Visible = Not bVisible
                        Case 7
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).Visible = Not bVisible
                        Case 11
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).Visible = Not bVisible
                        Case 13
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).Visible = Not bVisible
                    End Select
                End If
            Next
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub ObjectDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource1.Selecting
        If Request.QueryString("idDescripcion") Is Nothing Then
            Session("DSidDescripcion") = -1
        Else
            Session("DSidDescripcion") = Request.QueryString("idDescripcion").ToString()
        End If
    End Sub

    Protected Sub cbpEC_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Dim rpIndicesEscenciales As ASPxRoundPanel = CType(CType(aspxtreenivel, ASPxTreeList).FindEditFormTemplateControl("rpIndicesEscenciales"), ASPxRoundPanel)
        Dim panel As ASPxCallbackPanel = CType(rpIndicesEscenciales.FindControl("cbpEC"), ASPxCallbackPanel)
        Dim rpHeader As ASPxRoundPanel = CType(CType(aspxtreenivel, ASPxTreeList).FindEditFormTemplateControl("rpHeader"), ASPxRoundPanel)
        Dim cbSerie As ASPxComboBox = CType(rpHeader.FindControl("cbSerie"), ASPxComboBox)
        Dim txtCodigo As ASPxTextBox = CType(panel.FindControl("txtCodigo"), ASPxTextBox)
        Dim lblCodigo As ASPxLabel = CType(panel.FindControl("lblCodigo"), ASPxLabel)
        Select Case cbSerie.SelectedItem.GetValue("Clave")
            Case "1"
                txtCodigo.Visible = True
                lblCodigo.Visible = False
            Case "2"
                txtCodigo.Visible = True
                lblCodigo.Visible = False
            Case "3"
                txtCodigo.Visible = False
                lblCodigo.Visible = True
                'Obtener el codigo automaticamente global
                Dim sv As New WSArchivo.Service1
                lblCodigo.Text = sv.Func_GeneraCodigoDeSeries(Request.QueryString("idArchivo"), 3, IIf(aspxtreenivel.NewNodeParentKey = "", 0, aspxtreenivel.NewNodeParentKey))
                txtCodigo.Text = lblCodigo.Text
            Case "4"
                txtCodigo.Visible = False
                lblCodigo.Visible = True
                'Obtener el codigo automaticamente por serie
                Dim sv As New WSArchivo.Service1
                lblCodigo.Text = sv.Func_GeneraCodigoDeSeries(Request.QueryString("idArchivo"), 4, IIf(aspxtreenivel.NewNodeParentKey = "", 0, aspxtreenivel.NewNodeParentKey))
                txtCodigo.Text = lblCodigo.Text
            Case Else
                txtCodigo.Visible = True
                lblCodigo.Visible = False
        End Select

        CType(panel.FindControl("Periodo_guardaActivo"), ASPxSpinEdit).Value = cbSerie.SelectedItem.GetValue("Periodo_guardaActivo")
        If Not CType(panel.FindControl("idFrecuencia_guardaActivo"), ASPxComboBox).Items.FindByValue(cbSerie.SelectedItem.GetValue("idFrecuencia_guardaActivo")) Is Nothing Then
            CType(panel.FindControl("idFrecuencia_guardaActivo"), ASPxComboBox).Items.FindByValue(cbSerie.SelectedItem.GetValue("idFrecuencia_guardaActivo")).Selected = True
        End If

        CType(panel.FindControl("Periodo_guardaInactivo"), ASPxSpinEdit).Value = CType(cbSerie, ASPxComboBox).SelectedItem.GetValue("Periodo_guardaInactivo")
        If Not CType(panel.FindControl("idFrecuencia_guardaInactivo"), ASPxComboBox).Items.FindByValue(cbSerie.SelectedItem.GetValue("idFrecuencia_guardaInactivo")) Is Nothing Then
            CType(panel.FindControl("idFrecuencia_guardaInactivo"), ASPxComboBox).Items.FindByValue(cbSerie.SelectedItem.GetValue("idFrecuencia_guardaInactivo")).Selected = True
        End If

        CType(panel.FindControl("Valor_administrativo"), ASPxCheckBox).Value = cbSerie.SelectedItem.GetValue("Valor_administrativo")
        CType(panel.FindControl("Valor_legal"), ASPxCheckBox).Value = cbSerie.SelectedItem.GetValue("Valor_legal")
        CType(panel.FindControl("Valor_contable"), ASPxCheckBox).Value = cbSerie.SelectedItem.GetValue("Valor_contable")

        If Not CType(panel.FindControl("Clasificacion_De_Informacion"), ASPxComboBox).Items.FindByValue(cbSerie.SelectedItem.GetValue("Clasificacion_De_Informacion")) Is Nothing Then
            CType(panel.FindControl("Clasificacion_De_Informacion"), ASPxComboBox).Items.FindByValue(cbSerie.SelectedItem.GetValue("Clasificacion_De_Informacion")).Selected = True
        End If

        CType(panel.FindControl("Fecha_Alta"), ASPxLabel).Text = cbSerie.SelectedItem.GetValue("Fecha_Alta")
        CType(panel.FindControl("Fecha_Ultimo_Cambio"), ASPxLabel).Text = cbSerie.SelectedItem.GetValue("Fecha_Ultimo_Cambio")
    End Sub

    Protected Sub aspxtreenivel_NodeValidating(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListNodeValidationEventArgs) Handles aspxtreenivel.NodeValidating
        Try
            e.NodeError = ""
            Dim rpHeader As ASPxRoundPanel = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("rpHeader"), ASPxRoundPanel)
            Dim rpIndicesEscenciales As ASPxRoundPanel = CType(CType(aspxtreenivel, ASPxTreeList).FindEditFormTemplateControl("rpIndicesEscenciales"), ASPxRoundPanel)
            Dim panel As ASPxCallbackPanel = CType(rpIndicesEscenciales.FindControl("cbpEC"), ASPxCallbackPanel)
            If CType(rpHeader.FindControl("dlNiveles"), ASPxComboBox).SelectedItem Is Nothing Then e.NodeError += "Debe proporcionar el Tipo de Nivel.<br>"
            If CType(rpHeader.FindControl("cbSerie"), ASPxComboBox).SelectedItem Is Nothing Then
                e.NodeError += "Debe proporcionar el Tipo de Expediente.<br>"
            Else
                If CType(rpHeader.FindControl("cbSerie"), ASPxComboBox).SelectedItem.GetValue("Clave") = "1" And String.IsNullOrEmpty(CType(panel.FindControl("txtCodigo"), ASPxTextBox).Text) Then e.NodeError += "Debe proporcionar el Codigo de referencia.<br>"
                If CType(rpHeader.FindControl("cbSerie"), ASPxComboBox).SelectedItem.GetValue("Clave") = "2" And Not IsNumeric(CType(panel.FindControl("txtCodigo"), ASPxTextBox).Text) Then e.NodeError += "El Codigo de referencia debe ser numerico para este tipo de expediente.<br>"
            End If
            If String.IsNullOrEmpty(CType(panel.FindControl("txtdescripcion"), ASPxTextBox).Text) Then e.NodeError += "Debe proporcionar el Titulo.<br>"

            If CType(panel.FindControl("idFrecuencia_guardaActivo"), ASPxComboBox).SelectedItem Is Nothing Then e.NodeError += "Debe proporcionar el tipo de Período de guarda activo.<br>"
            If String.IsNullOrEmpty(CType(panel.FindControl("Periodo_guardaActivo"), ASPxSpinEdit).Value) Then e.NodeError += "Debe proporcionar el Período de guarda activo.<br>"
            If CType(panel.FindControl("idFrecuencia_guardaInactivo"), ASPxComboBox).SelectedItem Is Nothing Then e.NodeError += "Debe proporcionar el Período de guarda inactivo.<br>"
            If String.IsNullOrEmpty(CType(panel.FindControl("Periodo_guardaInactivo"), ASPxSpinEdit).Value) Then e.NodeError += "Debe proporcionar el tipo de Período de guarda inactivo .<br>"
            If CType(panel.FindControl("Metodo_Destruccion"), ASPxComboBox).SelectedItem Is Nothing Then e.NodeError += "Debe proporcionar el Metodo de destrucción.<br>"
            If CType(panel.FindControl("Clasificacion_De_Informacion"), ASPxComboBox).SelectedItem Is Nothing Then e.NodeError += "Debe proporcionar como se clasificara la informacion.<br>"
        Catch ex As Exception
            e.NodeError = ex.Message
        End Try
    End Sub

    Protected Sub ObjectDataSource1_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Updated
        Try

        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
            ASPxError.Visible = True
        End Try
    End Sub

    Protected Sub ObjectDataSource1_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Updating
        Try

        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
            ASPxError.Visible = True
        End Try
    End Sub

    Protected Sub aspxtreenivel_NodeUpdated(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatedEventArgs) Handles aspxtreenivel.NodeUpdated
        Try
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
            ASPxError.Visible = True
        End Try
    End Sub

End Class