Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTabControl

Partial Public Class Wfrm_PantallaCaptura_conPlantillas
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim descarch As String
    Dim aux As Integer = 0
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sv As New WSArchivo.Service1
        Dim ds As DataSet
        aspxguardar.Visible = False
        If Not Page.IsPostBack Then
            CargaArchivo()
            aspxtreenivel.DataBind()
            If aspxtreenivel.Nodes.Count > 0 Then
                ds = sv.ListaNivel_Plantilla_captura(Request.QueryString("idNorma"), aspxtreenivel.FocusedNode.DataItem("idNivel"))
                If ds.Tables(0).Rows.Count > 0 Then
                    AddTab(ds.Tables(0).Rows(0).Item("idPlantilla"))
                    llenaCampostab(aspxtreenivel.FocusedNode.Key)
                End If
            End If
            lblTitle.Text = "Archivo->Fondos->" & descarch
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
        Else
            aspxguardar.Visible = False
            ds = sv.ListaNivel_Plantilla_captura(Request.QueryString("idNorma"), aspxtreenivel.FocusedNode.DataItem("idNivel"))
            If ds.Tables(0).Rows.Count > 0 Then
                AddTab(ds.Tables(0).Rows(0).Item("idPlantilla"))
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
        Dim nNodo As New TreeNode

        dsArchivo = sv.ListaArchivo(ConfigurationManager.AppSettings("Archivo"))
        If dsArchivo.Tables(0).Rows.Count > 0 Then
            lblidNorma.Text = dsArchivo.Tables(0).Rows(0).Item("idNorma")
            descarch = dsArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")
        End If
    End Sub

    Protected Sub aspxguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxguardar.Click
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim ValorCampo As String
        Dim nodo As TreeListNode = aspxtreenivel.FindNodeByKeyValue(aspxtreenivel.FocusedNode.Key)
        Dim idnivel = nodo.DataItem(3)
        Try
            dsNomraCampos = sv.ListaNormas_Campos(lblidNorma.Text)
            For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                If Not pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                    'Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                    '    Case 0
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 1
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 2
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 3
                    '        ValorCampo = CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini & "-" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 4
                    '        ValorCampo = CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini & "-" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 5
                    '        ValorCampo = CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini & "-" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 6
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 7
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 11
                    '        'If dlAreas.SelectedValue = dsNomraCampos.Tables(0).Rows(intI).Item("idArea") Then
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '        'End If
                    '    Case 13
                    '        If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).cambiovalor Then
                    '            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), aspxtreenivel.FocusedNode.Key, 0, idnivel, 0, CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '        End If
                    'End Select
                End If
            Next
            ASPxError.Text = "Los datos se guardaron correctamente"
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub aspxtreenivel_FocusedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxtreenivel.FocusedNodeChanged
        ASPxError.Text = ""

    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback
        Dim sv As New WSArchivo.Service1
        Dim ds As DataSet

        aspxguardar.Visible = False
        ds = sv.ListaNivel_Plantilla_captura(Request.QueryString("idNorma"), aspxtreenivel.FocusedNode.DataItem("idNivel"))
        ASPxError.Text = ""
        If ds.Tables(0).Rows.Count > 0 Then
            AddTab(ds.Tables(0).Rows(0).Item("idPlantilla"))
            llenaCampostab(aspxtreenivel.FocusedNode.Key)
        End If
    End Sub
    Protected Sub AddTab(ByVal idPlantilla As String)
        Dim sv As New WSArchivo.Service1
        Dim dsAreas As DataSet
        Dim intI As Integer
        pgareas.TabPages.Clear()
        If lblidNorma.Text <> "" Then
            dsAreas = sv.ListaNormas_Areas_Especial(lblidNorma.Text, idPlantilla)
            aspxguardar.Visible = True
            For intI = 0 To dsAreas.Tables(0).Rows.Count - 1
                Dim tab As New TabPage()
                tab.Text = dsAreas.Tables(0).Rows(intI).Item("Area_descripcion")
                tab.VisibleIndex = dsAreas.Tables(0).Rows(intI).Item("idArea")
                pgareas.TabPages.Add(tab)
                CreaTablaElementotab(lblidNorma.Text, dsAreas.Tables(0).Rows(intI).Item("idArea"), intI, idPlantilla)
            Next
        End If

    End Sub

    Private Sub CreaTablaElementotab(ByVal idNorma As Integer, ByVal idArea As Integer, ByVal i As Integer, ByVal idPlantilla As Integer)
        Dim sv As New WSArchivo.Service1
        Dim dsElementos As DataSet
        Dim intI As Integer
        Dim intJ As Integer
        dsElementos = sv.ListaNormas_Elementos_Especial(idNorma, idArea, idPlantilla)
        For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
            Dim TBCampos As New Table
            Dim dsCampos As DataSet
            Dim ancho As Integer = 500
            dsCampos = sv.ListaNormas_Elementos_Campos_Especial(idNorma, idArea, dsElementos.Tables(0).Rows(intI).Item("idElemento"), idPlantilla)
            TBCampos.ID = "TBCampos" & dsElementos.Tables(0).Rows(intI).Item("idElemento")
            TBCampos.BorderWidth = 0.5
            TBCampos.Font.Size = 8
            TBCampos.Font.Name = "Arial"
            Dim nFila As New TableHeaderRow
            Dim nCelda As New TableHeaderCell

            nCelda.Width = "500"
            nCelda.Font.Size = 8
            nCelda.Font.Name = "Arial"
            nCelda.Font.Bold = True ' false
            nCelda.ForeColor = Drawing.Color.Black
            nCelda.Text = dsElementos.Tables(0).Rows(intI).Item("folio_norma") & " " & dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")
            nCelda.HorizontalAlign = HorizontalAlign.Left
            nFila.Cells.Add(nCelda)
            TBCampos.Rows.Add(nFila)

            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                Dim nFilaC As New TableRow
                Dim nCeldaC As New TableCell

                Select Case dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                    Case 0
                        Dim nCampoT As New CampoTexto
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoTexto.ascx"), CampoTexto)
                        nCelda.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)

                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 1
                        Dim nCampoT As New CampoTextoLargo
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoTextoLargo.ascx"), CampoTextoLargo)
                        nCelda.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 2
                        Dim nCampoT As New CampoFecha
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoFecha.ascx"), CampoFecha)
                        nCelda.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)

                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 3
                        Dim nCampoT As New CampoPeriodoFechas
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoFechas.ascx"), CampoPeriodoFechas)
                        nCelda.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 4
                        Dim nCampoT As New CampoPeriodoMesAno
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoMesAno.ascx"), CampoPeriodoMesAno)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 5
                        Dim nCampoT As New CampoPeriodoAno
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoAno.ascx"), CampoPeriodoAno)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 6
                        Dim nCampoT As New CampoSI_NO
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSI_NO.ascx"), CampoSI_NO)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 7
                        Dim nCampoT As New CampoEntero
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoEntero.ascx"), CampoEntero)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 8, 9, 10
                        Dim nCampoT As New CampoSlectura
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 11
                        Dim nCampoT As New CampoCatalogo
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoCatalogo.ascx"), CampoCatalogo)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 12
                        Dim nCampoT As New CampoGrid
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoGrid.ascx"), CampoGrid)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 13
                        Dim nCampoT As New CampoCatalogoISAAR
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoCatalogoISAAR.ascx"), CampoCatalogoISAAR)
                        nCeldaC.Width = ancho
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 14
                        Dim nCampoT As New CampoGridISAAR
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoGridISAAR.ascx"), CampoGridISAAR)
                        nCeldaC.Width = ancho
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
            pgareas.TabPages(i).Controls.Add(contentControl)
            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1

                If Not pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then

                    Select Case dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                        Case 0
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        Case 1
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")

                        Case 2
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        Case 3
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        Case 4
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        Case 5
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        Case 6
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        Case 7
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        Case 8, 9, 10
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        Case 11
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")
                        Case 12
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")

                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idArea = dsCampos.Tables(0).Rows(intJ).Item("idArea")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idElemento = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idIndice = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Indice_Tipo = 12

                        Case 13
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogoISAAR).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogoISAAR).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")

                        Case 14
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")

                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).idArea = dsCampos.Tables(0).Rows(intJ).Item("idArea")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).idElemento = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).idIndice = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            CType(pgareas.TabPages(i).FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).Indice_Tipo = 14
                    End Select
                End If
            Next
        Next

    End Sub


    Protected Sub llenaCampostab(ByVal iddescrip As Integer)
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim dsCampoValor As DataSet
        Dim dsConcatenaPadres As DataSet
        Dim dsFuncCampoValor As DataSet

        dsNomraCampos = sv.ListaNormas_Campos(lblidNorma.Text)

        For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
            If Not pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                    Case 0
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)

                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 1
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).TextoCampo.Trim = "Nivel de descripción" Then
                        End If
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 2
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 3
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = ""
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0)
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1)
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 4
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = "0"
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = "0"
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = "1"
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = "1"

                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0).Substring(1, 4)
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1).Substring(1, 4)
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0).Substring(5, 2)
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1).Substring(5, 2)
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If

                    Case 5
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = "0"
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = "0"

                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0)
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1)
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 6
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = "0"
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 7
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = "0"
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 8
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Maximo_valor(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Maximo") Is DBNull.Value Then
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Maximo")
                                End If
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 9
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Minimo_valor(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Minimo") Is DBNull.Value Then
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Minimo")
                                End If
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 10
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Suma_valor_hijos(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Suma") Is DBNull.Value Then
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Suma")
                                End If
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 11
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo = "-1"
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 12
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        Session("idDescripcion") = iddescrip
                        Session("idNivel") = aspxtreenivel.FocusedNode.DataItem(2)

                        If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).Muestra_Padres = True Then
                            dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                        End If
                    Case 13
                        CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).ValorCampo = "-1"
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                Dim dsidISAAR As DataSet
                                dsidISAAR = sv.ListaISAARxid(dsCampoValor.Tables(0).Rows(0).Item("Valor"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).EntidadValor = dsidISAAR.Tables(0).Rows(0).Item("Tipo_de_entidad")
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")

                            End If
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 14
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        Session("idDescripcion") = iddescrip
                        Session("idNivel") = aspxtreenivel.FocusedNode.DataItem(2)

                        If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGridISAAR).Muestra_Padres = True Then
                            dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGridISAAR).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                        End If


                End Select

            End If
        Next

    End Sub

    Private Sub dsArchivo_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsArchivo.Inserting
        Dim idDocumentoPID As Integer
        If aspxtreenivel.NewNodeParentKey = "" Then
            idDocumentoPID = 0
        Else
            idDocumentoPID = aspxtreenivel.NewNodeParentKey
        End If
        e.InputParameters("idDocumentoPID") = idDocumentoPID
        e.InputParameters("idArchivo") = ConfigurationManager.AppSettings("Archivo")
    End Sub


    Protected Sub aspxtreenivel_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListCustomErrorTextEventArgs) Handles aspxtreenivel.CustomErrorText
        Dim xError As String
        xError = e.Exception.InnerException.Message
    End Sub
End Class