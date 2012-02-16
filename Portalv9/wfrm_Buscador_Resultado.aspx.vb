Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxGridView

Partial Public Class wfrm_Buscador_Resultado
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim descarch As String
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargaArchivo()
            'lblTitle.Text = "Archivo->Fondos->" & descarch
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            gdbuscadorresultado.DataBind()
            'If gdbuscadorresultado.VisibleRowCount > 0 Then
            '    llenaCampos(gdbuscadorresultado.GetDataRow(0).Item("idDescripcion"))
            'End If
        End If
        CargaTabsAreas()
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Private Sub CargaArchivo()
        Dim sv As New WSArchivo.Service1
        Dim dsArchivo As DataSet
        Dim nNodo As New TreeNode

        dsArchivo = sv.ListaArchivo(Request.QueryString("idArchivo"))
        If dsArchivo.Tables(0).Rows.Count > 0 Then
            lblidNorma.Text = dsArchivo.Tables(0).Rows(0).Item("idNorma")
            descarch = dsArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")
        End If
    End Sub

    'Protected Sub ElementosVisibles(ByVal idArea As String)
    '    Dim intI As Integer
    '    For intI = 0 To PnlElementos.Controls.Count - 1
    '        If Not PnlElementos.Controls(intI).ID Is Nothing Then
    '            If PnlElementos.Controls(intI).ID.Substring(0, 8) = "TBCampos" Then
    '                CType(PnlElementos.Controls(intI), Table).Visible = False
    '                If CType(PnlElementos.Controls(intI), Table).TabIndex = idArea Then
    '                    CType(PnlElementos.Controls(intI), Table).Visible = True
    '                End If
    '            End If
    '        End If
    '    Next
    'End Sub
    'Protected Sub ElementosnoVisibles()
    '    Dim intI As Integer
    '    For intI = 0 To PnlElementos.Controls.Count - 1
    '        If Not PnlElementos.Controls(intI).ID Is Nothing Then
    '            If PnlElementos.Controls(intI).ID.Substring(0, 8) = "TBCampos" Then
    '                CType(PnlElementos.Controls(intI), Table).Visible = False
    '            End If
    '        End If
    '    Next
    'End Sub

    Private Sub gdbuscadorresultado_FocusedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdbuscadorresultado.FocusedRowChanged
        Dim row As Integer = gdbuscadorresultado.FocusedRowIndex
        If row >= 0 Then
            CargaTabsAreas()
        End If
    End Sub

#Region "Genera controles para Areas -> Elementos -> Indices"
    Protected Sub CargaTabsAreas()
        If gdbuscadorresultado.FocusedRowIndex > -1 Then
            Dim sv As New WSArchivo.Service1
            Dim dsAreas As DataSet
            Dim intI As Integer
            pgareas.TabPages.Clear()
            If lblidNorma.Text <> "" Then
                dsAreas = sv.ListaNormas_Elementos_CamposXArea_Serie(-1, Integer.Parse(gdbuscadorresultado.GetDataRow(gdbuscadorresultado.FocusedRowIndex)("idSerie")))
                For intI = 0 To dsAreas.Tables(0).Rows.Count - 1
                    CreaTablaElementotab(dsAreas.Tables(0).Rows(intI).Item("idArea"), _
                                         dsAreas.Tables(0).Rows(intI).Item("idSerie"), _
                                         dsAreas.Tables(0).Rows(intI).Item("Area_descripcion"))
                Next
            End If
            llenaCampostab(Integer.Parse(gdbuscadorresultado.GetDataRow(gdbuscadorresultado.FocusedRowIndex)("idDescripcion")), _
                           Integer.Parse(gdbuscadorresultado.GetDataRow(gdbuscadorresultado.FocusedRowIndex)("idSerie")), _
                           Integer.Parse(gdbuscadorresultado.GetDataRow(gdbuscadorresultado.FocusedRowIndex)("idNivel")))
            pgareas.Visible = True
        Else
            pgareas.Visible = False
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
                nCelda.Font.Bold = True
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

                Dim nCampoT As New CampoSlectura
                nCampoT.Visible = False
                nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
                nCeldaC.Width = ancho
                nCeldaC.Controls.Add(nCampoT)
                nFilaC.Cells.Add(nCeldaC)
                TBCampos.Rows.Add(nFilaC)
                nCampoT.ID = "vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
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
                'trMainH.Style("Height") = String.Concat((Integer.Parse(trMainH.Style("Height").Replace("px", "")) + 25).ToString(), "px")
                If Not tab.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then
                    CType(tab.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    CType(tab.FindControl("vC" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_padres")
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

        dsNomraCampos = sv.ListaNormas_Elementos_CamposxSerie(idlSerie)        
        For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
            CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
            If Not pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), iddescrip)
                If dsCampoValor.Tables(0).Rows.Count > 0 Then
                    If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                        Dim myPalabra As String = dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString
                        Dim iStart As Integer = myPalabra.ToLower().IndexOf(Request.QueryString("Palabra").ToLower())
                        If iStart > -1 Then
                            CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).MuestraValorHTML = True
                            myPalabra = myPalabra.Substring(0, iStart) + "<span style='font-family:Arial; font-size:10pt; color:black; background-color:Yellow;'>" + myPalabra.Substring(iStart, Len(Request.QueryString("Palabra"))) + "</span>" + myPalabra.Substring(iStart + Len(Request.QueryString("Palabra")), myPalabra.Length - (iStart + Len(Request.QueryString("Palabra"))))
                        End If
                        CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = myPalabra
                    End If
                    If CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Muestra_Padres = True Then
                        dsConcatenaPadres = sv.Func_Concatena_padres(Request.QueryString("idArchivo"), dsCampoValor.Tables(0).Rows(0).Item("idIndice"), dsCampoValor.Tables(0).Rows(0).Item("idFolio"))
                        CType(pgareas.FindControl("vC" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).TextoPadres = dsConcatenaPadres.Tables(0).Rows(0).Item("LLave_concatenada")
                    End If
                End If
            End If
        Next

    End Sub
    'Private Sub CargaAreas()
    '    Dim sv As New WSArchivo.Service1
    '    Dim dsAreas As DataSet
    '    Dim intI As Integer
    '    If lblidNorma.Text <> "" Then
    '        dsAreas = sv.ListaNormas_Areas(lblidNorma.Text)
    '        For intI = 0 To dsAreas.Tables(0).Rows.Count - 1
    '            CreaTablaElemento(lblidNorma.Text, dsAreas.Tables(0).Rows(intI).Item("idArea"))
    '        Next
    '        If dsAreas.Tables(0).Rows.Count > 0 Then
    '            If Not IsPostBack Then
    '                ElementosVisibles(dsAreas.Tables(0).Rows(0).Item("idArea"))
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub CreaTablaElemento(ByVal idNorma As Integer, ByVal idArea As Integer)
    '    Dim sv As New WSArchivo.Service1
    '    Dim dsElementos As DataSet
    '    Dim intI As Integer
    '    Dim intJ As Integer
    '    dsElementos = sv.ListaNormas_Elementos(idNorma, idArea)
    '    For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
    '        Dim TBCampos As New Table
    '        Dim dsCampos As DataSet

    '        dsCampos = sv.ListaNormas_Elementos_Campos(idNorma, idArea, dsElementos.Tables(0).Rows(intI).Item("idElemento"))
    '        TBCampos.ID = "TBCampos" & dsElementos.Tables(0).Rows(intI).Item("idElemento")
    '        TBCampos.BorderColor = Drawing.Color.AliceBlue
    '        TBCampos.BorderWidth = 0.5
    '        TBCampos.BorderStyle = BorderStyle.Solid
    '        TBCampos.Font.Size = 8
    '        TBCampos.Font.Name = "Arial"
    '        Dim nFila As New TableHeaderRow
    '        Dim nCelda As New TableHeaderCell

    '        nCelda.Width = PnlElementos.Width
    '        nCelda.Font.Size = 8
    '        nCelda.Font.Name = "Arial"
    '        nCelda.Font.Bold = False
    '        nCelda.CssClass = "DataList_Aqua"
    '        nCelda.ForeColor = Drawing.Color.Black
    '        nCelda.HorizontalAlign = HorizontalAlign.Left
    '        nCelda.Text = dsElementos.Tables(0).Rows(intI).Item("folio_norma") & " " & dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")
    '        nFila.Cells.Add(nCelda)
    '        TBCampos.Rows.Add(nFila)

    '        For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
    '            Dim nFilaC As New TableRow
    '            Dim nCeldaC As New TableCell

    '            Dim nCampoT As New CampoSlectura
    '            nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
    '            nCeldaC.Width = PnlElementos.Width
    '            nCeldaC.Controls.Add(nCampoT)
    '            nFilaC.Cells.Add(nCeldaC)
    '            TBCampos.Rows.Add(nFilaC)
    '            nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
    '        Next
    '        TBCampos.Visible = False
    '        TBCampos.TabIndex = idArea
    '        TBCampos.Width = PnlElementos.Width
    '        PnlElementos.Controls.Add(TBCampos)
    '        For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1

    '            If Not PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then
    '                CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("folio_norma") & " " & dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")

    '            End If
    '        Next
    '    Next

    'End Sub

    'Protected Sub llenaCampos(ByVal iddescrip As Integer)
    '    Dim sv As New WSArchivo.Service1
    '    Dim intI As Integer
    '    Dim dsNomraCampos As DataSet
    '    Dim dsCampoValor As DataSet
    '    dsNomraCampos = sv.ListaNormas_Campos(lblidNorma.Text)
    '    For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
    '        If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
    '            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
    '            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Visible = False
    '            dsCampoValor = sv.ListaArchivo_indice(lblidNorma.Text, dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), ConfigurationManager.AppSettings("Archivo"), iddescrip)
    '            If dsCampoValor.Tables(0).Rows.Count > 0 Then
    '                If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
    '                    If dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Length > 0 Then
    '                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
    '                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Visible = True
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Next
    'End Sub
#End Region

    Protected Sub ObjectDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource1.Selecting
        If Not Request.QueryString("idNiveles") Is Nothing And Request.QueryString("idNiveles").Length > 0 Then
            e.InputParameters("SQLString") = "Select Archivo_Descripciones_Archivisticas.idArchivo, Archivo_Descripcion, idDescripcion, " & _
                    "   Archivo_Descripciones_Archivisticas.idNivel, (Select Serie_nombre From Series_modelo where Series_modelo.idSerie = Archivo_Descripciones_Archivisticas.idSerie) As Serie_Nombre, " & _
                    "   Descripcion, Nivel, Nivel_Descripcion, Nivel_Logico_Fisico, idSerie,Imagen_open, Imagen_Close " & _
                    "From Archivo_Descripciones_Archivisticas, archivos, niveles " & _
                    "Where Archivo_Descripciones_Archivisticas.idArchivo = archivos.idArchivo and " & _
                    "   Archivo_Descripciones_Archivisticas.idNivel =  niveles.idNivel and " & _
                    "   (idDescripcion in (select idDescripcion from Archivo_Descripciones_Archivisticas where descripcion like '%" + Request.QueryString("Palabra") + "%')  " & _
                    "   or idDescripcion in (Select idDescripcion from archivo_indices Where indice_Tipo in (0,1) and convert(varchar(max), valor) Like '%" + Request.QueryString("Palabra") + "%') " & _
                    "   or idSerie In (Select idSerie From Series_modelo where Serie_nombre like '%" + Request.QueryString("Palabra") + "%') " & _
                    "   ) and Archivo_Descripciones_Archivisticas.idArchivo = " + Request.QueryString("idArchivo") + " " & _
                    "   and Archivo_Descripciones_Archivisticas.idNivel In (" + Request.QueryString("idNiveles").Replace("~", ",") + ") "
        Else
            e.InputParameters("SQLString") = "Select Archivo_Descripciones_Archivisticas.idArchivo, Archivo_Descripcion, idDescripcion, " & _
                    "   Archivo_Descripciones_Archivisticas.idNivel, (Select Serie_nombre From Series_modelo where Series_modelo.idSerie = Archivo_Descripciones_Archivisticas.idSerie) As Serie_Nombre, " & _
                    "   Descripcion, Nivel, Nivel_Descripcion, Nivel_Logico_Fisico, idSerie,Imagen_open, Imagen_Close " & _
                    "From Archivo_Descripciones_Archivisticas, archivos, niveles " & _
                    "Where Archivo_Descripciones_Archivisticas.idArchivo = archivos.idArchivo and " & _
                    "   Archivo_Descripciones_Archivisticas.idNivel =  niveles.idNivel and " & _
                    "   (idDescripcion in (select idDescripcion from Archivo_Descripciones_Archivisticas where descripcion like '%" + Request.QueryString("Palabra") + "%')  " & _
                    "   or idDescripcion in (Select idDescripcion from archivo_indices Where indice_Tipo in (0,1) and convert(varchar(max), valor) Like '%" + Request.QueryString("Palabra") + "%') " & _
                    "   or idSerie In (Select idSerie From Series_modelo where Serie_nombre like '%" + Request.QueryString("Palabra") + "%') " & _
                    "   ) and Archivo_Descripciones_Archivisticas.idArchivo = " + Request.QueryString("idArchivo")
        End If
    End Sub
End Class