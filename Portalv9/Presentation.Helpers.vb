Imports Portalv9.SvrUsr
Imports System.Data
Imports System.Web.UI.Control
Imports Portalv9.WSArchivo.Service1
Imports DevExpress.Web.ASPxPanel
Imports DevExpress.Web.ASPxTreeList

Namespace Presentation
    Public Class Helpers

        Shared Sub CreaTablaElemento(ByVal PnlElementos As ASPxPanel, ByVal sourcePage As Page)
            Dim sv As New WSArchivo.Service1
            Dim dsElementos As DataSet
            Dim intI As Integer
            Dim intJ As Integer

            dsElementos = sv.ListaArchivo_Cat_Elementos()
            For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
                Dim TBCampos As New Table
                Dim dsCampos As DataSet

                dsCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intI).Item("idElemento"))
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
                    End Select
                Next

                TBCampos.Width = PnlElementos.Width
                PnlElementos.Controls.Add(TBCampos)

                For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                    If Not PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then
                        Select Case dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                            Case 0
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            Case 1
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTextoLargo).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            Case 2
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoFecha).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            Case 3
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoFechas).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            Case 4
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoMesAno).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            Case 5
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoPeriodoAno).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            Case 6
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSI_NO).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            Case 7
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoEntero).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                        End Select
                    End If
                Next
            Next
        End Sub

        Shared Sub LimpiaCampos(ByVal PnlElementos As ASPxPanel)
            Dim sv As New WSArchivo.Service1
            Dim dsElementos As DataSet
            Dim intI As Integer
            Dim intJ As Integer
            Dim dsNomraCampos As DataSet
            dsElementos = sv.ListaArchivo_Cat_Elementos()
            For intJ = 0 To dsElementos.Tables(0).Rows.Count - 1
                dsNomraCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intJ).Item("idElemento"))
                For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                    If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                        Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                            Case 0
                                Dim myCT As CampoTexto = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto)
                                myCT.ValorCampo = ""
                                myCT.ValorCampoLongitud = Integer.Parse(dsNomraCampos.Tables(0).Rows(intI).Item("Indice_LongitudMax"))
                                If Not IsDBNull(dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Mascara")) Then
                                    myCT.ValorCampoMascara = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Mascara")
                                    myCT.ValorCampoMascaraMsgDeError = "Formato incorrecto, recuerde que el formato es:<BR> " + dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Mascara")
                                End If
                                myCT.ValorCampoObligatorio = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Obligatorio")
                            Case 1
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = ""
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampoObligatorio = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Obligatorio")
                            Case 2
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = ""
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampoObligatorio = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Obligatorio")
                            Case 3
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = ""
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_IniCampoObligatorio = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Obligatorio")
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = ""
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_FinCampoObligatorio = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Obligatorio")
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
            Next
        End Sub

        Shared Sub llenaCampos(ByVal PnlElementos As ASPxPanel, ByVal aspxtreearchivo As ASPxTreeList)
            Dim sv As New WSArchivo.Service1
            Dim intI As Integer
            Dim dsNomraCampos As DataSet
            Dim dsCampoValor As DataSet
            Dim dsElementos As DataSet
            If Not aspxtreearchivo.FocusedNode Is Nothing Then
                dsElementos = sv.ListaArchivo_Cat_Elementos()
                For intJ = 0 To dsElementos.Tables(0).Rows.Count - 1
                    dsNomraCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intJ).Item("idElemento"))
                    For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                        If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                            Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                                Case 0
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = ""
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                        End If
                                    End If
                                Case 1
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = ""
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                        End If
                                    End If
                                Case 2
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = ""
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                        End If
                                    End If
                                Case 3
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = ""
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = ""
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
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
                                    End If
                                Case 4
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = "0"
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = "0"
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = "1"
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = "1"

                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = Split(Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0), "/")(0)
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = Split(Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0), "/")(1)
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = Split(Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1), "/")(0)
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = Split(Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1), "/")(1)
                                        End If
                                    End If
                                Case 5
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = "0"
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = "0"

                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0)
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1)
                                        End If
                                    End If
                                Case 6
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = "0"
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                        End If
                                    End If
                                Case 7
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = "0"
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                        End If
                                    End If
                            End Select

                        End If
                    Next
                Next
            End If
        End Sub

        Shared Sub verCreaTablaElemento(ByVal PnlViewElementos As ASPxPanel, ByVal sourcePage As Page)
            Dim sv As New WSArchivo.Service1
            Dim dsElementos As DataSet
            Dim intI As Integer
            Dim intJ As Integer

            dsElementos = sv.ListaArchivo_Cat_Elementos()
            For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
                Dim TBCampos As New Table
                Dim dsCampos As DataSet

                dsCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intI).Item("idElemento"))
                TBCampos.ID = "vTBCampos" & dsElementos.Tables(0).Rows(intI).Item("idElemento")
                TBCampos.BorderColor = Drawing.Color.AliceBlue
                TBCampos.BorderWidth = 0.5
                TBCampos.BorderStyle = BorderStyle.Solid
                TBCampos.Font.Size = 8
                TBCampos.Font.Name = "Arial"


                Dim nFila As New TableHeaderRow
                Dim nCelda As New TableHeaderCell
                nCelda.Width = PnlViewElementos.Width
                nCelda.Font.Size = 8
                nCelda.Font.Name = "Arial"
                nCelda.Font.Bold = False
                nCelda.CssClass = "DataList_Aqua"
                nCelda.ForeColor = Drawing.Color.Black
                nCelda.Text = dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")
                nFila.Cells.Add(nCelda)
                TBCampos.Rows.Add(nFila)

                For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                    Dim nFilaC As New TableRow
                    Dim nCeldaC As New TableCell
                    Dim nCampoT As New CampoSlectura
                    nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
                    nCeldaC.Width = PnlViewElementos.Width
                    nCeldaC.Controls.Add(nCampoT)
                    nFilaC.Cells.Add(nCeldaC)
                    TBCampos.Rows.Add(nFilaC)
                    nCampoT.ID = "vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                Next

                TBCampos.Width = PnlViewElementos.Width
                PnlViewElementos.Controls.Add(TBCampos)

                For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                    If Not PnlViewElementos.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then
                        CType(PnlViewElementos.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    End If
                Next
            Next
        End Sub

        Shared Sub verLlenaCampos(ByVal PnlViewElementos As ASPxPanel, ByVal idarchivo As Integer)
            Dim sv As New WSArchivo.Service1
            Dim intI As Integer
            Dim dsNomraCampos As DataSet
            Dim dsCampoValor As DataSet
            Dim dsElementos As DataSet

            dsElementos = sv.ListaArchivo_Cat_Elementos()
            For intJ = 0 To dsElementos.Tables(0).Rows.Count - 1
                dsNomraCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intJ).Item("idElemento"))
                For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                    If Not PnlViewElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                        CType(PnlViewElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                        CType(PnlViewElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Visible = False
                        dsCampoValor = sv.ListaArchivo_val_Campo(idarchivo, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                        If dsCampoValor.Tables(0).Rows.Count > 0 Then
                            If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                If dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Length > 0 Then
                                    CType(PnlViewElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                    CType(PnlViewElementos.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Visible = True
                                End If
                            End If
                        End If
                    End If
                Next
            Next

        End Sub

        Shared Sub CreaTablaIndices(ByVal PnlElementos As ASPxPanel, ByVal ASPxTreeList1 As ASPxTreeList, ByVal sourcePage As Page)
            Dim idSerie As Integer
            Dim dsCampos As DataSet
            Dim sv As New WSArchivo.Service1
            Dim intI As Integer
            Dim intJ As Integer

            'For Each nNodo As TreeListNode In ASPxTreeList1.GetSelectedNodes()
            If ASPxTreeList1.GetSelectedNodes().Count > 0 Then
                Dim TBCampos As New Table
                idSerie = ASPxTreeList1.GetSelectedNodes().Item(0).Key
                'dsCampos = sv.ListaSeries_Indices_padres(idSerie)
                'TBCampos.ID = "TBCampos" & dsCampos.Tables(0).Rows(intI).Item("idElemento")
                'TBCampos.BorderColor = Drawing.Color.AliceBlue
                'TBCampos.BorderWidth = 0.5
                'TBCampos.BorderStyle = BorderStyle.Solid
                'TBCampos.Font.Size = 8
                'TBCampos.Font.Name = "Arial"

                'Dim nFila As New TableHeaderRow
                'Dim nCelda As New TableHeaderCell
                'nCelda.Width = PnlElementos.Width
                'nCelda.Font.Size = 8
                'nCelda.Font.Name = "Arial"
                'nCelda.Font.Bold = False
                'nCelda.CssClass = "DataList_Aqua"
                'nCelda.ForeColor = Drawing.Color.Black
                'nCelda.Text = dsCampos.Tables(0).Rows(intI).Item("Elemento_descripcion")
                'nFila.Cells.Add(nCelda)
                'TBCampos.Rows.Add(nFila)
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
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)

                            TBCampos.Rows.Add(nFilaC)
                        Case 1
                            Dim nCampoT As New CampoTextoLargo
                            nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoTextoLargo.ascx"), CampoTextoLargo)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                        Case 2
                            Dim nCampoT As New CampoFecha
                            nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoFecha.ascx"), CampoFecha)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                        Case 3
                            Dim nCampoT As New CampoPeriodoFechas
                            nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoPeriodoFechas.ascx"), CampoPeriodoFechas)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                        Case 4
                            Dim nCampoT As New CampoPeriodoMesAno
                            nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoPeriodoMesAno.ascx"), CampoPeriodoMesAno)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                        Case 5
                            Dim nCampoT As New CampoPeriodoAno
                            nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoPeriodoAno.ascx"), CampoPeriodoAno)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                        Case 6
                            Dim nCampoT As New CampoSI_NO
                            nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoSI_NO.ascx"), CampoSI_NO)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                        Case 7
                            Dim nCampoT As New CampoEntero
                            nCampoT = CType(sourcePage.LoadControl("~/WebUsrCtrls/CampoEntero.ascx"), CampoEntero)
                            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            nCeldaC.Width = PnlElementos.Width
                            nCeldaC.Controls.Add(nCampoT)
                            nFilaC.Cells.Add(nCeldaC)
                            TBCampos.Rows.Add(nFilaC)
                    End Select
                Next
                '    If Row Is Nothing Then
                '        Dim IndiceRow As DataRow = dtIndicesDocumentos.NewRow()
                '        IndiceRow("idIndice") = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                '        IndiceRow("Indice_Tipo") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                '        IndiceRow("Indice_descripcion") = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                '        IndiceRow("Indice_LongitudMax") = dsCampos.Tables(0).Rows(intJ).Item("Indice_LongitudMax")
                '        IndiceRow("Indice_Obligatorio") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                '        IndiceRow("Indice_Unico") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Unico")
                '        IndiceRow("Indice_Mascara") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")
                '        IndiceRow("Serie_nombre") = dsCampos.Tables(0).Rows(intJ).Item("Serie_nombre")
                '        IndiceRow("idNorma") = dsCampos.Tables(0).Rows(intJ).Item("idNorma")
                '        IndiceRow("idArea") = dsCampos.Tables(0).Rows(intJ).Item("idArea")
                '        IndiceRow("idElemento") = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
                '        IndiceRow("idNivel") = dsCampos.Tables(0).Rows(intJ).Item("idNivel")
                '        IndiceRow("idSerie") = dsCampos.Tables(0).Rows(intJ).Item("idSerie")
                '        dtIndicesDocumentos.Rows.Add(IndiceRow)
                '    End If
                'Next
                'SelectParentNode(nNodo)
                'Next

                TBCampos.Width = PnlElementos.Width
                PnlElementos.Controls.Add(TBCampos)

                For intI = 0 To dsCampos.Tables(0).Rows.Count - 1
                    If Not PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                        Select Case dsCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                            Case 0
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).TextoCampo = dsCampos.Tables(0).Rows(intI).Item("Indice_descripcion")
                            Case 1
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).TextoCampo = dsCampos.Tables(0).Rows(intI).Item("Indice_descripcion")
                            Case 2
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).TextoCampo = dsCampos.Tables(0).Rows(intI).Item("Indice_descripcion")
                            Case 3
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).TextoCampo = dsCampos.Tables(0).Rows(intI).Item("Indice_descripcion")
                            Case 4
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).TextoCampo = dsCampos.Tables(0).Rows(intI).Item("Indice_descripcion")
                            Case 5
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).TextoCampo = dsCampos.Tables(0).Rows(intI).Item("Indice_descripcion")
                            Case 6
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).TextoCampo = dsCampos.Tables(0).Rows(intI).Item("Indice_descripcion")
                            Case 7
                                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).TextoCampo = dsCampos.Tables(0).Rows(intI).Item("Indice_descripcion")
                        End Select
                    End If
                    ' Next
                Next
            End If
        End Sub

        Shared Sub LimpiaCampos1(ByVal PnlElementos As ASPxPanel)
            Dim sv As New WSArchivo.Service1
            Dim dsElementos As DataSet
            Dim intI As Integer
            Dim intJ As Integer
            Dim dsNomraCampos As DataSet
            dsElementos = sv.ListaArchivo_Cat_Elementos()
            For intJ = 0 To dsElementos.Tables(0).Rows.Count - 1
                dsNomraCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intJ).Item("idElemento"))
                For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                    If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                        Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                            Case 0
                                Dim myCT As CampoTexto = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto)
                                myCT.ValorCampo = ""
                                myCT.ValorCampoLongitud = Integer.Parse(dsNomraCampos.Tables(0).Rows(intI).Item("Indice_LongitudMax"))
                                If Not IsDBNull(dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Mascara")) Then
                                    myCT.ValorCampoMascara = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Mascara")
                                    myCT.ValorCampoMascaraMsgDeError = "Formato incorrecto, recuerde que el formato es:<BR> " + dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Mascara")
                                End If
                                myCT.ValorCampoObligatorio = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Obligatorio")
                            Case 1
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = ""
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampoObligatorio = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Obligatorio")
                            Case 2
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = ""
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampoObligatorio = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Obligatorio")
                            Case 3
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = ""
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_IniCampoObligatorio = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Obligatorio")
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = ""
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_FinCampoObligatorio = dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Obligatorio")
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
            Next
        End Sub

        Shared Sub llenaCampos1(ByVal PnlElementos As ASPxPanel, ByVal aspxtreearchivo As ASPxTreeList)
            Dim sv As New WSArchivo.Service1
            Dim intI As Integer
            Dim dsNomraCampos As DataSet
            Dim dsCampoValor As DataSet
            Dim dsElementos As DataSet
            If Not aspxtreearchivo.FocusedNode Is Nothing Then
                dsElementos = sv.ListaArchivo_Cat_Elementos()
                For intJ = 0 To dsElementos.Tables(0).Rows.Count - 1
                    dsNomraCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intJ).Item("idElemento"))
                    For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                        If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                            Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                                Case 0
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = ""
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                        End If
                                    End If
                                Case 1
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = ""
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                        End If
                                    End If
                                Case 2
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = ""
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                        End If
                                    End If
                                Case 3
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini = ""
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin = ""
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
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
                                    End If
                                Case 4
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = "0"
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = "0"
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = "1"
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = "1"

                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini = Split(Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0), "/")(0)
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini = Split(Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0), "/")(1)
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin = Split(Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1), "/")(0)
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin = Split(Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1), "/")(1)
                                        End If
                                    End If
                                Case 5
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = "0"
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = "0"

                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(0)
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin = Split(dsCampoValor.Tables(0).Rows(0).Item("Valor"), "-")(1)
                                        End If
                                    End If
                                Case 6
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = "0"
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                        End If
                                    End If
                                Case 7
                                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = "0"
                                    dsCampoValor = sv.ListaArchivo_val_Campo(aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                        End If
                                    End If
                            End Select

                        End If
                    Next
                Next
            End If
        End Sub
    End Class
End Namespace