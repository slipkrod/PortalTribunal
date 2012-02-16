Imports DevExpress.Web.ASPxTabControl

Partial Public Class Wfm_CapturaIndices
    Inherits System.Web.UI.Page
    Private Sub Page_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        AddTabs()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            llenaCampostab(Request.QueryString("idDescripcion"), Request.QueryString("idSerie"), Request.QueryString("idNivel"))
            ShowHideControls(True)
            tableIndices.Visible = True
        End If
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
        Dim sv As New WSArchivo.Service1
        Dim dsAreas As DataSet
        Dim intI As Integer
        'pgareas.TabPages.Clear()
        If Request.QueryString("idNorma") <> "" Then
            dsAreas = sv.ListaNormas_Elementos_CamposXArea_Serie(-1, Request.QueryString("idSerie"))
            For intI = 0 To dsAreas.Tables(0).Rows.Count - 1
                CreaTablaElementotab(dsAreas.Tables(0).Rows(intI).Item("idArea"), _
                                     dsAreas.Tables(0).Rows(intI).Item("idSerie"), _
                                     dsAreas.Tables(0).Rows(intI).Item("Area_descripcion"))
            Next
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
        tab.Name = idArea
        If dsElementos.Tables(0).Rows.Count > 0 Then
            pgareas.TabPages.Add(tab)
        End If
        For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
            Dim TBCampos As New Table
            Dim dsCampos As DataSet
            Dim ancho As Integer = 650
            dsCampos = sv.ListaNormas_Elementos_Campo(Request.QueryString("idNorma"), idArea, dsElementos.Tables(0).Rows(intI).Item("idElemento"), dsElementos.Tables(0).Rows(intI).Item("idIndice"))
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
                        'nCampoT.CalendadioCompartido = "__ReferenceDateEdit"
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
            TBCampos.Width = ancho

            Dim contentControl As New Control
            contentControl.Controls.Add(TBCampos)

            Try
                tab.Controls.Add(contentControl)
            Catch ex As Exception
            End Try

            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                ''trMainH.Style("Height") = String.Concat((Integer.Parse(trMainH.Style("Height").Replace("px", "")) + 25).ToString(), "px")

                If Not tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then
                    CType(tab.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Folio_Norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    CType(tab.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                    Select Case dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                        Case 0
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoObligatorio = True
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            End If
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoLongitud = Integer.Parse(dsCampos.Tables(0).Rows(intJ).Item("Indice_LongitudMax"))
                            If Not IsDBNull(dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoMascara = dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoMascaraMsgDeError = "Formato incorrecto, recuerde que el formato es:<BR> " + dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")
                            End If
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 1
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).ValorCampoObligatorio = True
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            End If
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 2
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).ValorCampoObligatorio = True
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            End If
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 3
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_IniCampoObligatorio = True
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_FinCampoObligatorio = True
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_IniCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_FinCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            End If
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
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
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).ValorCampoObligatorio = True
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            End If
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
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).ValorCampoObligatorio = True
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            End If
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
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).ValorCampoObligatorio = True
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            End If
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 7
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).ValorCampoObligatorio = True
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            End If
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                            Else
                            End If
                        Case 8, 9, 10
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 11
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).ValorCampoObligatorio = True
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            End If
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")

                            If dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID").ToString.Length > 0 Then
                                If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString <> "" Then
                                    CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).ValorCatalogo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                                End If
                            End If
                        Case 12
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")

                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idArea = dsCampos.Tables(0).Rows(intJ).Item("idArea")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idElemento = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idIndice = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Indice_Tipo = 12
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idNivel = dsCampos.Tables(0).Rows(intJ).Item("idNivel")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idDescripcion = Request.QueryString("idDescripcion")
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).DataBind()
                        Case 13
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogoISAAR).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogoISAAR).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogoISAAR).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        Case 14
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).TextoCampo = _
                                dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(tab.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.Func_Concatena_Indices_Grid(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            ''Session("idDescripcion") = iddescrip
                            ''Session("idNivel") = idNivel

                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).MuestraValorHTML = True
                                CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If

                            ''If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).Muestra_Padres = True Then
                            ''    dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                            ''    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            ''End If
                        End If
                    Case 13
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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
                        dsCampoValor = sv.ListaArchivo_indice(Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
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

    Protected Sub aspxCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxCancelar.Click
        ShowViewStateControlsIndices()
    End Sub

    Protected Sub aspxguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxguardar.Click
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim dsElementos As DataSet
        Dim ValorCampo As String
        '' Dim nodo As TreeListNode = aspxtreenivel.FindNodeByKeyValue(Request.QueryString("idDescripcion"))
        Dim idnivel = Request.QueryString("idNivel")
        Try
            dsElementos = sv.ListaNormas_Elementos_CamposXArea_Serie(-1, Request.QueryString("idSerie"))
            dsNomraCampos = sv.ListaNormas_Elementos_CamposxSerie(Request.QueryString("idSerie"))
            For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                If Not pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                    Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                        Case 0
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 1
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 2
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 3
                            ValorCampo = CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini & "-" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 4
                            ValorCampo = CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini & "/" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini & "-" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin & "/" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 5
                            ValorCampo = CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini & "-" & CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 6
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 7
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 11
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), _
                                    dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), _
                                    Request.QueryString("idDescripcion"), 0, idnivel, 0, _
                                    dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo, _
                                    dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), _
                                    CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCatalogo)
                        Case 13
                            If CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).cambiovalor Then
                                sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                            End If
                    End Select
                End If
            Next
            MsgBox1.ShowMessage("Los datos se guardaron correctamente")
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
        ShowViewStateControlsIndices()
        llenaCampostab(Request.QueryString("idDescripcion"), Request.QueryString("idSerie"), Request.QueryString("idNivel"))
    End Sub

    Sub ShowHideControls(ByVal bVisible As Boolean)
        ''If aspxtreenivel.FocusedNode Is Nothing Then Return
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        ''Dim nodo As TreeListNode = aspxtreenivel.FindNodeByKeyValue(Request.QueryString("idDescripcion"))
        Dim idnivel = Request.QueryString("idNivel")
        Try
            dsNomraCampos = sv.ListaNormas_Elementos_CamposxSerie(Request.QueryString("idSerie"))
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
                        Case 12
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).Visible = Not bVisible
                        Case 13
                            CType(pgareas.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).Visible = Not bVisible
                    End Select
                End If
            Next
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub aspxEditar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxEditar.Click
        aspxEditar.Visible = False
        tableEditando.Visible = True
        ShowHideControls(False)
    End Sub
End Class