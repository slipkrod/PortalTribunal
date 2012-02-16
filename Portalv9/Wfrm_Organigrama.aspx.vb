Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports DevExpress.Web.ASPxGridView
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls

Partial Public Class Wfrm_Organigrama
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim descarch As String
#End Region

    Private Sub Wfrm_PlantillaCaptura_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        CargaArchivo()
        CargaAreas()
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
            gdnivel.DataBind()
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
        lblidNorma.Text = Request.QueryString("idNorma")
    End Sub
    Private Sub CargaAreas()
        Dim sv As New WSArchivo.Service1
        Dim dsAreas As DataSet
        Dim intI As Integer
        If lblidNorma.Text <> "" Then
            dsAreas = sv.ListaNormas_Areas(lblidNorma.Text)

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
        dsElementos = sv.ListaNormas_Elementos(idNorma, idArea)
        Try

        
            For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
                Dim TBCampos As New Table
                Dim dsCampos As DataSet

                dsCampos = sv.ListaNormas_Elementos_Campos(idNorma, idArea, dsElementos.Tables(0).Rows(intI).Item("idElemento"))
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
                            nCelda.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)

                            TBCampos.Rows.Add(nFilaC)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        Case 1
                            Dim nCampoT As New CampoTextoLargo
                            nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoTextoLargo.ascx"), CampoTextoLargo)
                            nCelda.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        Case 2
                            Dim nCampoT As New CampoFecha
                            nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoFecha.ascx"), CampoFecha)
                            nCelda.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)

                            TBCampos.Rows.Add(nFilaC)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        Case 3
                            Dim nCampoT As New CampoPeriodoFechas
                            nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoFechas.ascx"), CampoPeriodoFechas)
                            nCelda.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        Case 4
                            Dim nCampoT As New CampoPeriodoMesAno
                            nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoMesAno.ascx"), CampoPeriodoMesAno)
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        Case 5
                            Dim nCampoT As New CampoPeriodoAno
                            nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoAno.ascx"), CampoPeriodoAno)
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        Case 6
                            Dim nCampoT As New CampoSI_NO
                            nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSI_NO.ascx"), CampoSI_NO)
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        Case 7
                            Dim nCampoT As New CampoEntero
                            nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoEntero.ascx"), CampoEntero)
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        Case 8, 9, 10
                            Dim nCampoT As New CampoSlectura
                            nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        Case 11
                            Dim nCampoT As New CampoCatalogo
                            nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoCatalogo.ascx"), CampoCatalogo)
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        Case 12
                            Dim nCampoT As New CampoGrid
                            nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoGrid.ascx"), CampoGrid)
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    End Select
                Next

                TBCampos.Visible = False
                TBCampos.TabIndex = idArea
                TBCampos.Width = PnlElementos.Width
                PnlElementos.Controls.Add(TBCampos)
                For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1

                    If Not PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then

                        Select Case dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                            Case 0
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            Case 1
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")

                            Case 2
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            Case 3
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            Case 4
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            Case 5
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            Case 6
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            Case 7
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            Case 8, 9, 10
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            Case 11
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")
                            Case 12
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        End Select
                    End If
                Next
            Next
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
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

        ASPxError.Text = ""
        dlAreas.DataBind()
        gdnivel.DataBind
        If gdnivel.VisibleRowCount > 0 Then
            ElementosVisibles(dlAreas.SelectedValue)
        Else
            ElementosnoVisibles()
        End If
    End Sub

    Protected Sub aspxguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxguardar.Click
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim ValorCampo As String
        Dim value As DataRowView = gdnivel.GetRow(gdnivel.FocusedRowIndex)
        Dim idnivel = value.Item(3)
        Try
            dsNomraCampos = sv.ListaNormas_Campos(lblidNorma.Text)
            For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                    'Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                    '    Case 0
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), value.Item(1), 0, idnivel, 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 1
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), value.Item(1), 0, idnivel, 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 2
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), value.Item(1), 0, idnivel, 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 3
                    '        ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), value.Item(1), 0, idnivel, 0, ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 4
                    '        ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), value.Item(1), 0, idnivel, 0, ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 5
                    '        ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), value.Item(1), 0, idnivel, 0, ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 6
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), value.Item(1), 0, idnivel, 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 7
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), value.Item(1), 0, idnivel, 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    '    Case 11
                    '        sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), value.Item(1), 0, idnivel, 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"))
                    'End Select
                End If
            Next
            ASPxError.Text = "Los datos se guardaron correctamente"
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub LimpiaCampos()
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet

        dsNomraCampos = sv.ListaNormas_Campos(lblidNorma.Text)
        For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
            If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                    Case 0
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = ""
                    Case 1
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = ""
                    Case 2
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = ""
                    Case 3
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = ""
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = ""
                    Case 4
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = "0"
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = "0"
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = "1"
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = "1"
                    Case 5
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = "0"
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = "0"
                    Case 6
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = "Si"
                    Case 7
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = "0"
                End Select
            End If
        Next
    End Sub


    Protected Sub llenaCampos(ByVal iddescrip As Integer)
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim dsCampoValor As DataSet
        Dim dsConcatenaPadres As DataSet
        Dim dsFuncCampoValor As DataSet
        Dim value As DataRowView = gdnivel.GetRow(gdnivel.FocusedRowIndex)
        dsNomraCampos = sv.ListaNormas_Campos(lblidNorma.Text)

        For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
            If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                    Case 0
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 1
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).TextoCampo.Trim = "Nivel de descripción" Then
                        End If
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 2
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 3
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = ""
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0)
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1)
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 4
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = "0"
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = "0"
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = "1"
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = "1"

                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0).Substring(1, 4)
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1).Substring(1, 4)
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0).Substring(5, 2)
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1).Substring(5, 2)
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If

                    Case 5
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = "0"
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = "0"

                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0)
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1)
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 6
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = "0"
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 7
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = "0"
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 8
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Maximo_valor(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Maximo") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Maximo")
                                End If
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 9
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Minimo_valor(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Minimo") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Minimo")
                                End If
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 10
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Suma_valor_hijos(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Suma") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Suma")
                                End If
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 11
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo = "-1"
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 12
                        dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
                        ' Dim nValores() As Integer = {lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip, value.Item(2), 12}
                        ' CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGridascx).CargaValores = nValores
                        If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).Muestra_Padres = True Then
                            dsConcatenaPadres = sv.Func_Concatena_padres(ConfigurationManager.AppSettings("Archivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                        End If

                End Select

            End If
        Next

    End Sub


    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sv As New WSArchivo.Service1
        Dim nNodoID As Integer
        Dim dsNivel As New DataSet
        Dim value As DataRowView = gdnivel.GetRow(gdnivel.FocusedRowIndex)

        Dim idnivel As String = CType(gdnivel.FindEditFormTemplateControl("cmbnivel"), ASPxComboBox).SelectedItem.Value
        Dim descripcion As String = CType(gdnivel.FindEditFormTemplateControl("txtDescripcion"), ASPxTextBox).Text.Trim
        Try
            Dim idDocumentoPID As Integer
            If value.Item(1).ToString = "" Then
                idDocumentoPID = 0
            Else
                idDocumentoPID = value.Item(12)
            End If
            nNodoID = sv.ABC_Archivo_Descripciones(WSArchivo.OperacionesABC.operAlta, ConfigurationManager.AppSettings("Archivo"), 0, "", idnivel, 0, "", 0, descripcion, 0, idDocumentoPID)
            dsNivel = sv.ListaNorma_Nivel(lblidNorma.Text, idnivel)
            gdnivel.CancelEdit()
            gdnivel.DataBind()
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
    End Sub


    Protected Sub Btnactualizar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sv As New WSArchivo.Service1
        Dim id As Integer
        Dim dsNivel As New DataSet
        Dim idnivel As String = CType(gdnivel.FindEditFormTemplateControl("cmbnivel"), ASPxComboBox).SelectedItem.Value
        Dim descripcion As String = CType(gdnivel.FindEditFormTemplateControl("txtDescripcion"), ASPxTextBox).Text.Trim
        Dim value As DataRowView = gdnivel.GetRow(gdnivel.FocusedRowIndex)

        Try
            id = sv.ABC_Archivo_Descripciones(WSArchivo.OperacionesABC.operCambio, ConfigurationManager.AppSettings("Archivo"), value.Item(1), "", idnivel, 0, "", 0, descripcion, 0, value.Item(12))
            dsNivel = sv.ListaNorma_Nivel(lblidNorma.Text, idnivel)
            gdnivel.CancelEdit()
            gdnivel.DataBind()
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
    End Sub



    Protected Sub ElementosnoVisibles()
        Dim intI As Integer
        For intI = 0 To PnlElementos.Controls.Count - 1
            If Not PnlElementos.Controls(intI).ID Is Nothing Then
                If PnlElementos.Controls(intI).ID.Substring(0, 8) = "TBCampos" Then
                    CType(PnlElementos.Controls(intI), Table).Visible = False

                End If
            End If
        Next
    End Sub



    Private Sub gdnivel_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdnivel.DataBound
        'If gdnivel.VisibleRowCount = 0 Then
        '    ElementosnoVisibles()
        'End If
    End Sub

    Private Sub gdnivel_FocusedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdnivel.FocusedRowChanged
        ASPxError.Text = ""
    End Sub

    Private Sub gdnivel_HtmlRowCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs) Handles gdnivel.HtmlRowCreated
        dlAreas.DataBind()
        If e.KeyValue <> Nothing Then
            ElementosVisibles(dlAreas.SelectedValue)
            If gdnivel.VisibleRowCount = 1 Then
                llenaCampos(e.KeyValue)
            Else
                Dim value As DataRowView = gdnivel.GetRow(gdnivel.FocusedRowIndex)

                If Not value Is Nothing Then
                    llenaCampos(value.Item(1))
                Else
                    llenaCampos(e.KeyValue)
                End If

            End If

        Else
            ElementosnoVisibles()
        End If

        Dim cmbnivel As ASPxComboBox = CType(gdnivel.FindEditFormTemplateControl("cmbnivel"), ASPxComboBox)
        If e.RowType = GridViewRowType.EditForm Then
            Dim btninsertargd As ASPxButton = CType(gdnivel.FindEditFormTemplateControl("btnAceptar"), ASPxButton)
            Dim btnactualizargd As ASPxButton = CType(gdnivel.FindEditFormTemplateControl("Btnactualizar"), ASPxButton)

            If gdnivel.IsNewRowEditing Then
                btnactualizargd.Visible = False
                btninsertargd.Visible = True
            Else
                Dim idNivel As String = e.GetValue("idNivel").ToString.Trim
                Dim i As Integer
                For i = 0 To cmbnivel.Items.Count - 1
                    If cmbnivel.Items(i).Value.ToString = idNivel Then
                        cmbnivel.SelectedIndex = cmbnivel.Items(i).Index
                    End If
                Next

                btnactualizargd.Visible = True
                btninsertargd.Visible = False
            End If
        End If

    End Sub
End Class