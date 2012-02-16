Imports Portalv9.SvrUsr
Imports System.Data
Imports System.Web.UI.Control
Imports Portalv9.WSArchivo.Service1
Imports DevExpress.Web.ASPxPanel
Imports DevExpress.Web.ASPxTreeList

Public Class Funciones_Archivo
    Shared Sub CreaTablaElemento(ByVal PnlElementos As ASPxPanel, ByVal sourcePage As Page, ByVal idArchivo As Integer, ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idSerie As Integer)
        Dim sv As New WSArchivo.Service1
        Dim dsElementos As DataSet
        Dim intI As Integer
        Dim intJ As Integer

        dsElementos = sv.ListaNormas_ElementosxSeriexElemento_Visible(idNorma, idArea, idSerie)
        For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
            Dim TBCampos As New Table
            Dim dsCampos As DataSet

            dsCampos = sv.ListaNormas_Elementos_CamposxSeriexElemento_Visible(idSerie, dsElementos.Tables(0).Rows(intI).Item("idElemento"))
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
            nCelda.ForeColor = Drawing.Color.Black
            nCelda.BackColor = Drawing.Color.WhiteSmoke
            nCelda.Text = dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")
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
                Select Case dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                    Case 0
                        Dim nCampoT As New CampoTexto
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoTexto.ascx"), CampoTexto)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)

                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 1
                        Dim nCampoT As New CampoTextoLargo
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoTextoLargo.ascx"), CampoTextoLargo)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)

                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 2
                        Dim nCampoT As New CampoFecha
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoFecha.ascx"), CampoFecha)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)

                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 3
                        Dim nCampoT As New CampoPeriodoFechas
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoPeriodoFechas.ascx"), CampoPeriodoFechas)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 4
                        Dim nCampoT As New CampoPeriodoMesAno
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoPeriodoMesAno.ascx"), CampoPeriodoMesAno)
                        nCeldaC.Width = PnlElementos.Width

                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 5
                        Dim nCampoT As New CampoPeriodoAno
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoPeriodoAno.ascx"), CampoPeriodoAno)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 6
                        Dim nCampoT As New CampoSI_NO
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoSI_NO.ascx"), CampoSI_NO)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 7
                        Dim nCampoT As New CampoEntero
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoEntero.ascx"), CampoEntero)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 8, 9, 10
                        Dim nCampoT As New CampoSlectura
                        nCampoT.Visible = False
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 11
                        Dim nCampoT As New CampoCatalogo
                        nCampoT.Visible = False
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoCatalogo.ascx"), CampoCatalogo)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 12
                        Dim nCampoT As New CampoGrid
                        nCampoT.Visible = False
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoGrid.ascx"), CampoGrid)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 13
                        Dim nCampoT As New CampoCatalogoISAAR
                        nCampoT.Visible = False
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoCatalogoISAAR.ascx"), CampoCatalogoISAAR)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 14
                        Dim nCampoT As New CampoGridISAAR
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoGridISAAR.ascx"), CampoGridISAAR)
                        nCampoT.Visible = False
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 15
                        Dim nCampoT As New CampoMultiSelect
                        nCampoT.Visible = False
                        nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoMultiSelect.ascx"), CampoMultiSelect)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                End Select
            Next

            TBCampos.Width = PnlElementos.Width
            PnlElementos.Controls.Add(TBCampos)

            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                ''trMainH.Style("Height") = String.Concat((Integer.Parse(trMainH.Style("Height").Replace("px", "")) + 25).ToString(), "px")

                If Not PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then
                    Select Case dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                        Case 0
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoLongitud = Integer.Parse(dsCampos.Tables(0).Rows(intJ).Item("Indice_LongitudMax"))
                            If Not IsDBNull(dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")) Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoMascara = dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampoMascaraMsgDeError = "Formato incorrecto, recuerde que el formato es:<BR> " + dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")
                            End If
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                            If dsCampos.Tables(0).Rows(intJ).Item("IndiceReadOnly") = "1" Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).SoloLectura = True
                            End If
                        Case 1
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 2
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 3
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_IniCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_FinCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                Try
                                    CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(0)
                                Catch ex As Exception
                                End Try
                                Try
                                    CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(1)
                                Catch ex As Exception
                                End Try
                            End If
                        Case 4
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                Try
                                    CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(0).Split("/")(0)
                                    CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(0).Split("/")(1)
                                Catch ex As Exception
                                End Try
                                Try
                                    CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(1).Split("/")(0)
                                    CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(1).Split("/")(1)
                                Catch ex As Exception
                                End Try
                            End If
                        Case 5
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                Try
                                    CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).Año_Ini = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(0)
                                Catch ex As Exception
                                End Try
                                Try
                                    CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).Año_Fin = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString.Split("-")(1)
                                Catch ex As Exception
                                End Try
                            End If
                        Case 6
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 7
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Sistema") Then
                            Else
                            End If
                        Case 8, 9, 10
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And Not String.IsNullOrEmpty(dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString) Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).ValorCampo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                            End If
                        Case 11
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).ValorCampoObligatorio = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")

                            If dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID").ToString.Length > 0 Then
                                If dsCampos.Tables(0).Rows(intJ).Item("Asigned") = "1" And dsCampos.Tables(0).Rows(intJ).Item("Asigned_value").ToString <> "" Then
                                    CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogo).ValorCatalogo = dsCampos.Tables(0).Rows(intJ).Item("Asigned_value")
                                End If
                            End If
                        Case 12
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")

                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idArea = dsCampos.Tables(0).Rows(intJ).Item("idArea")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idElemento = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idIndice = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).Indice_Tipo = 12
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idNivel = dsCampos.Tables(0).Rows(intJ).Item("idNivel")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).idDescripcion = -1
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGrid).DataBind()
                        Case 13
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogoISAAR).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogoISAAR).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoCatalogoISAAR).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                        Case 14
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).TextoCampo = _
                                dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")

                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).idArea = dsCampos.Tables(0).Rows(intJ).Item("idArea")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).idElemento = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).idIndice = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoGridISAAR).Indice_Tipo = 14
                        Case 15
                            If dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio") Then
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoMultiSelect).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion") & " *" '<span style='color:Red;'>*</span>"
                            Else
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoMultiSelect).TextoCampo = _
                                    dsCampos.Tables(0).Rows(intJ).Item("Folio_norma").ToString & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            End If
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoMultiSelect).Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoMultiSelect).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")

                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoMultiSelect).idArchivo = idArchivo
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoMultiSelect).idDescripcion = -1
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoMultiSelect).Indice_Tipo = 15
                            CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoMultiSelect).DataBind()
                    End Select
                End If
            Next

        Next
    End Sub

    Shared Sub llenaCamposDefault(ByVal PnlElementos As ASPxPanel, ByVal idArchivo As Integer, ByVal idSerie As Integer)
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim dsFuncCampoValor As DataSet
        dsNomraCampos = sv.ListaNormas_Elementos_CamposxSerie_Defaults(idSerie)
        For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
            If Not dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value") Is DBNull.Value Then
                If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                    Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                        Case 0
                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value")
                        Case 1
                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value")
                        Case 2

                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value")
                        Case 3
                            Try
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = Split(dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value"), "-")(0)
                            Catch ex As Exception
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = "1/1900"
                            End Try
                            Try
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = Split(dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value"), "-")(1)
                            Catch ex As Exception
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = "1/1900"
                            End Try
                        Case 4
                            If Not dsNomraCampos.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                Try
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value").ToString.Split("-")(0).Split("/")(0)
                                Catch
                                End Try
                                Try
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value").ToString.Split("-")(0).Split("/")(1)
                                Catch
                                End Try
                                Try
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value").ToString.Split("-")(1).Split("/")(0)
                                Catch
                                End Try
                                Try
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value").ToString.Split("-")(1).Split("/")(1)
                                Catch
                                End Try
                            End If

                        Case 5
                            If Not dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = Split(dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value"), "-")(0)
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = Split(dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value"), "-")(1)
                            End If
                        Case 6
                            If Not dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value")
                            End If
                        Case 7

                            If Not dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value")
                            End If
                        Case 8

                            dsFuncCampoValor = sv.Func_Maximo_valor(idArchivo, dsNomraCampos.Tables(0).Rows(0).Item("idIndice"), dsNomraCampos.Tables(0).Rows(0).Item("idDescripcioncion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Maximo") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Maximo")
                                End If
                            End If
                        Case 9

                            dsFuncCampoValor = sv.Func_Minimo_valor(idArchivo, dsNomraCampos.Tables(0).Rows(0).Item("idIndice"), dsNomraCampos.Tables(0).Rows(0).Item("idDescripcioncion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Minimo") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Minimo")
                                End If
                            End If

                        Case 10

                            dsFuncCampoValor = sv.Func_Suma_valor_hijos(idArchivo, dsNomraCampos.Tables(0).Rows(0).Item("idIndice"), dsNomraCampos.Tables(0).Rows(0).Item("idDescripcioncion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Suma") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Suma")
                                End If
                            End If
                        Case 11
                            If Not dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo = dsNomraCampos.Tables(0).Rows(0).Item("Asigned_value")
                            End If
                        Case 12
                        Case 13
                        Case 14
                    End Select
                End If
            End If
        Next

    End Sub

    Shared Sub llenaCamposCodigo(ByVal PnlElementos As ASPxPanel, ByVal idArchivo As Integer, ByVal idSeriePadre As Integer, ByVal idDescripcioncion As Integer, ByVal idSerie As Integer, ByVal idNivel As Integer, ByVal idNorma As Integer)
        Dim sv As New WSArchivo.Service1
        Dim dsIndiceCodigo As DataSet
        Dim dsIndiceCodigoSerie As DataSet
        Dim dsIndiceSerie As DataSet

        dsIndiceSerie = sv.ListaSeries_Modelo_indice_sistema(1, idSerie)
        dsIndiceCodigoSerie = sv.ListaSeries_Modelo_indice_sistema(idArchivo, idSeriePadre)
        dsIndiceCodigo = sv.ListaArchivo_indicexidDescripcion_idIndice(idArchivo, idDescripcioncion, dsIndiceCodigoSerie.Tables(0).Rows(0).Item("idIndice"))
        Dim numeroElementosNivel As Integer = sv.CuentaElementosNivel(idArchivo, idDescripcioncion)

        If dsIndiceCodigo.Tables(0).Rows.Count > 0 Then
            If Not dsIndiceCodigo.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                Dim var1 As String = dsIndiceCodigo.Tables(0).Rows(0).Item("Valor")
                CType(PnlElementos.FindControl("C" & dsIndiceSerie.Tables(0).Rows(0).Item("idIndice")), CampoTexto).ValorCampo = dsIndiceCodigo.Tables(0).Rows(0).Item("Valor") & "-" & CType(numeroElementosNivel + 1, String)
            End If
        End If


        dsIndiceSerie = sv.ListaSeries_Modelo_indice_sistema(17, idSerie)
        dsIndiceCodigo = sv.ListaNorma_Nivel(idNorma, idNivel)

        If dsIndiceCodigo.Tables(0).Rows.Count > 0 Then
            If Not dsIndiceCodigo.Tables(0).Rows(0).Item("Nivel_Descripcion") Is DBNull.Value Then
                Dim valro As String = dsIndiceCodigo.Tables(0).Rows(0).Item("Nivel_Descripcion")
                CType(PnlElementos.FindControl("C" & dsIndiceSerie.Tables(0).Rows(0).Item("idIndice")), CampoTexto).ValorCampo = valro
            End If
        End If
    End Sub

    Shared Sub llenaCamposValor(ByVal PnlElementos As ASPxPanel, ByVal idArchivo As Integer, ByVal idNorma As Integer, ByVal idDescripcion As Integer, ByVal idSerie As Integer, ByVal idNivel As Integer)
        Dim sv As New WSArchivo.Service1
        Dim intI, intJ As Integer
        Dim dsNomraCampos As DataSet
        Dim dsCampoValor As DataSet
        Dim dsConcatenaPadres As DataSet
        Dim dsFuncCampoValor As DataSet
        dsNomraCampos = sv.ListaNormas_Elementos_CamposxSerie(idSerie)
        For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
            If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                    Case 0
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 1
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).TextoCampo.Trim = "Nivel de descripción" Then
                        End If
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 2
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 3
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                Try
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0)
                                Catch ex As Exception
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = "1/1900"
                                End Try
                                Try
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1)
                                Catch ex As Exception
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = "1/1900"
                                End Try
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 4
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                Try
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Split("-")(0).Split("/")(0)
                                Catch
                                End Try
                                Try
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Split("-")(0).Split("/")(1)
                                Catch
                                End Try
                                Try
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Split("-")(1).Split("/")(0)
                                Catch
                                End Try
                                Try
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Split("-")(1).Split("/")(1)
                                Catch
                                End Try
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If

                    Case 5
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0)
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1)
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 6
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 7
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 8
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Maximo_valor(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Maximo") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Maximo")
                                End If
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 9
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Minimo_valor(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Minimo") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Minimo")
                                End If
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 10
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Suma_valor_hijos(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Suma") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsFuncCampoValor.Tables(0).Rows(0).Item("Suma")
                                End If
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 11
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If

                    Case 12
                        dsCampoValor = sv.Func_Concatena_Indices_Grid(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            ''Session("idDescripcion") = iddescrip
                            ''Session("idNivel") = idNivel

                            ''If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).Muestra_Padres = True Then
                            ''    dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                            ''    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            ''End If
                        End If
                    Case 13
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                Dim dsidISAAR As DataSet
                                dsidISAAR = sv.ListaISAARxid(dsCampoValor.Tables(0).Rows(0).Item("Valor"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).EntidadValor = dsidISAAR.Tables(0).Rows(0).Item("Tipo_de_entidad")
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).Muestra_Padres = True Then
                                dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            End If
                        End If
                    Case 14

                        'If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoMultiSelect).Muestra_Padres = True Then
                        '    dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                        '    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGridISAAR).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                        'End If
                    Case 15
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoMultiSelect).idIndice = dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoMultiSelect).idDescripcion = idDescripcion
                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoMultiSelect).DataBind()

                        'dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        'For intJ = 0 To dsCampoValor.Tables(0).Rows.Count - 1
                        'Next

                End Select
            End If
        Next
    End Sub

    Shared Sub Actuliza_Codigo_Descripcion_Serie_Arbol(ByVal PnlElementos As ASPxPanel, ByVal idArchivo As Integer, ByVal idDescripcioncion As Integer, ByVal idSerie As Integer)
        Dim sv As New WSArchivo.Service1
        Dim dsIndiceCodigo As DataSet
        Dim dsIndiceSerie As DataSet
        Dim dsArchivoSerie As DataSet
        Dim Codigo As String
        Dim Descripcion As String
        dsIndiceSerie = sv.ListaSeries_Modelo_indice_sistema(1, idSerie)
        dsIndiceCodigo = sv.ListaArchivo_indicexidDescripcion_idIndice(idArchivo, idDescripcioncion, dsIndiceSerie.Tables(0).Rows(0).Item("idIndice"))
        If dsIndiceCodigo.Tables(0).Rows.Count > 0 Then

            dsArchivoSerie = sv.ListaArchivo_Descripciones_idDescripcion(idArchivo, idDescripcioncion)
            If dsArchivoSerie.Tables(0).Rows.Count > 0 Then
                Codigo = CType(PnlElementos.FindControl("C" & dsIndiceSerie.Tables(0).Rows(0).Item("idIndice")), CampoTexto).ValorCampo
            End If
        End If

        dsIndiceSerie = sv.ListaSeries_Modelo_indice_sistema(2, idSerie)
        dsIndiceCodigo = sv.ListaArchivo_indicexidDescripcion_idIndice(idArchivo, idDescripcioncion, dsIndiceSerie.Tables(0).Rows(0).Item("idIndice"))
        If dsIndiceCodigo.Tables(0).Rows.Count > 0 Then

            dsArchivoSerie = sv.ListaArchivo_Descripciones_idDescripcion(idArchivo, idDescripcioncion)
            If dsArchivoSerie.Tables(0).Rows.Count > 0 Then
                Descripcion = CType(PnlElementos.FindControl("C" & dsIndiceSerie.Tables(0).Rows(0).Item("idIndice")), CampoTexto).ValorCampo
            End If
        End If

        sv.ABC_Archivo_Descripciones(WSArchivo.OperacionesABC.operCambio, idArchivo, idDescripcioncion, Codigo, dsArchivoSerie.Tables(0).Rows(0).Item("idNivel"), dsArchivoSerie.Tables(0).Rows(0).Item("idSerie"), "", 0, Descripcion, dsArchivoSerie.Tables(0).Rows(0).Item("idTipoElemento"), dsArchivoSerie.Tables(0).Rows(0).Item("idDocumentoPID"))

    End Sub

    Shared Sub CreaTablaElemento_RO(ByVal PnlElementos As ASPxPanel, ByVal sourcePage As Page, ByVal idArchivo As Integer, ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idSerie As Integer)
        Dim sv As New WSArchivo.Service1
        Dim dsElementos As DataSet
        Dim intI As Integer
        Dim intJ As Integer

        dsElementos = sv.ListaNormas_ElementosxSeriexElemento_Visible(idNorma, idArea, idSerie)
        For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
            Dim TBCampos As New Table
            Dim dsCampos As DataSet

            dsCampos = sv.ListaNormas_Elementos_CamposxSeriexElemento_Visible(idSerie, dsElementos.Tables(0).Rows(intI).Item("idElemento"))
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
            nCelda.ForeColor = Drawing.Color.Black
            nCelda.BackColor = Drawing.Color.WhiteSmoke
            nCelda.Text = dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")
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
                nCampoTview = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
                nCampoTview.ID = "vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                nCeldaC.Width = PnlElementos.Width
                nCeldaC.Controls.Add(nCampoTview)
                nFilaC.Cells.Add(nCeldaC)
                TBCampos.Rows.Add(nFilaC)

            Next

            TBCampos.Width = PnlElementos.Width
            PnlElementos.Controls.Add(TBCampos)

            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                ''trMainH.Style("Height") = String.Concat((Integer.Parse(trMainH.Style("Height").Replace("px", "")) + 25).ToString(), "px")

                If Not PnlElementos.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then
                    CType(PnlElementos.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Folio_Norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    CType(PnlElementos.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
                End If
            Next

        Next
    End Sub
    Shared Sub llenaCamposValor_RO(ByVal PnlElementos As ASPxPanel, ByVal idArchivo As Integer, ByVal idSerie As Integer, ByVal idNorma As Integer, ByVal idDescripcion As Integer)
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim dsCampoValor As DataSet
        Dim dsFuncCampoValor As DataSet
        dsNomraCampos = sv.ListaNormas_Elementos_CamposxSerie_Visibles(idSerie)
        For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
            If Not CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura) Is Nothing Then
                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
            End If
            If Not PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                    Case 0
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                        End If
                    Case 1
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                        End If
                    Case 2
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                        End If
                    Case 3
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                        End If
                    Case 4
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                        End If

                    Case 5
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                        End If
                    Case 6
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                        End If
                    Case 7
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                        End If
                    Case 8
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Maximo_valor(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcioncion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Maximo") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                End If
                            End If
                        End If
                    Case 9
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Minimo_valor(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcioncion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Minimo") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                End If
                            End If
                        End If
                    Case 10
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            dsFuncCampoValor = sv.Func_Suma_valor_hijos(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idDescripcioncion"))
                            If dsFuncCampoValor.Tables(0).Rows.Count > 0 Then
                                If Not dsFuncCampoValor.Tables(0).Rows(0).Item("Suma") Is DBNull.Value Then
                                    CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                End If
                            End If
                        End If
                    Case 11
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                        End If
                    Case 12
                        dsCampoValor = sv.Func_Concatena_Indices_Grid(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            ''Session("idDescripcioncion") = idDescripcion
                            ''Session("idNivel") = idNivel

                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).MuestraValorHTML = True
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If

                            ''If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).Muestra_Padres = True Then
                            ''    dsConcatenaPadres = sv.Func_Concatena_padres(idArchivo, dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                            ''    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGrid).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                            ''End If
                        End If
                    Case 13
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                Dim dsidISAAR As DataSet
                                dsidISAAR = sv.ListaISAARxid(dsCampoValor.Tables(0).Rows(0).Item("Valor"))
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If
                        End If
                    Case 14
                        dsCampoValor = sv.ListaArchivo_indice(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                    Case 15
                        dsCampoValor = sv.Func_Concatena_Indices_Grid(idNorma, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), idArchivo, idDescripcion)
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).MuestraValorHTML = True
                                CType(PnlElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                            End If

                        End If
                End Select
            End If
        Next
    End Sub
End Class
