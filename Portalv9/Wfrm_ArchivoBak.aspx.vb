Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Partial Class Wfrm_ArchivoBak
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region
    Dim deldatos As Boolean = False

    Private Sub Wfrm_Archivo_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        CreaTablaElemento()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Archivos"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            aspxtreearchivo.DataBind()
            If aspxtreearchivo.Nodes.Count > 0 Then
                llenaCampos()
            End If
        End If


    End Sub

#Region "  Comunes"

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Private Function ObtieneResultado() As String
        Dim strResultado As String
        If Session.Item("GSTR_SESSION_RESULT") Is Nothing Then
            strResultado = String.Empty
        Else
            strResultado = Session.Item("GSTR_SESSION_RESULT")
            Session.Remove("GSTR_SESSION_RESULT")
        End If
        Return strResultado
    End Function


#End Region


    Private Sub CreaTablaElemento()
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


                Select Case dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                    Case 0
                        Dim nCampoT As New CampoTexto
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoTexto.ascx"), CampoTexto)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)


                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 1
                        Dim nCampoT As New CampoTextoLargo
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoTextoLargo.ascx"), CampoTextoLargo)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)

                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 2
                        Dim nCampoT As New CampoFecha
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoFecha.ascx"), CampoFecha)
                        nCeldaC.Width = PnlElementos.Width
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)

                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                    Case 3
                        Dim nCampoT As New CampoPeriodoFechas
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoFechas.ascx"), CampoPeriodoFechas)
                        nCeldaC.Width = PnlElementos.Width
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
                    End Select
                End If
            Next
        Next

    End Sub

    Protected Sub LimpiaCampos()
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

                    End Select
                End If
            Next
        Next
    End Sub


    Protected Sub llenaCampos()
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
                        End Select

                    End If
                Next
            Next
        End If
    End Sub

    Private Sub aspxtreearchivo_FocusedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxtreearchivo.FocusedNodeChanged
        ASPxError.Text = ""
        LimpiaCampos()
        llenaCampos()
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardar.Click
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim ValorCampo As String
        Dim dsElementos As DataSet

        Try
            dsElementos = sv.ListaArchivo_Cat_Elementos()
            For intJ = 0 To dsElementos.Tables(0).Rows.Count - 1
                dsNomraCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intJ).Item("idElemento"))
                For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                    If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                        Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                            Case 0
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo)
                            Case 1
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo)
                            Case 2
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo)
                            Case 3
                                ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, ValorCampo)
                            Case 4
                                ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini & "/" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin & "/" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, ValorCampo)
                            Case 5
                                ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, ValorCampo)
                            Case 6
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo)
                        End Select
                    End If
                Next

            Next
            ASPxError.Text = "Los datos se guardaron correctamente"
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        aspxtreearchivo.CancelEdit()
    End Sub

    Protected Sub btnActualizar_Click(ByVal sender As Object, ByVal e As EventArgs)
        aspxtreearchivo.UpdateEdit()
    End Sub
End Class
