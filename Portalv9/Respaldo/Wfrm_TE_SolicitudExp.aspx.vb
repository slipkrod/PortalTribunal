Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Partial Public Class Wfrm_TE_SolicitudExp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub dlTipoExpediente_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dlTipoExpediente.SelectedIndexChanged
    End Sub

    Protected Sub dsSeries_Indices_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsSeries_Indices.Selecting
    End Sub

    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        Select Case ASPxTreeList1.FindNodeByKeyValue(container.NodeKey).GetValue("idNivel")
            Case 219, 220
                Return "~/Images/separador.gif"
            Case Else
                Return "~/Images/Documento.gif"
        End Select
    End Function

    Protected Sub dsLista_SeriesModelo_Hijos_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsLista_SeriesModelo_Hijos.Selecting
        If Not IsPostBack Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ASPxTreeList1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxTreeList1.DataBound

        For Each nNodo As TreeListNode In ASPxTreeList1.FindNodesByFieldValue("idNivel", 220)
            nNodo.AllowSelect = False
        Next
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAceptar.Click
        Dim idSerie As Integer
        Dim svr As New WSArchivo.Service1
        Dim dsCampos As DataSet
        Dim intJ As Integer

        Dim dtChildren As New DataTable()
        dtChildren.TableName = "Campos"

        Dim pkCampoID As DataColumn = dtChildren.Columns.Add("CampoID", Type.GetType("System.Int32"))
        pkCampoID.AutoIncrement = True
        pkCampoID.AutoIncrementSeed = 1
        dtChildren.Columns.Add("idIndice", Type.GetType("System.Int32"))
        dtChildren.Columns.Add("Indice_Tipo", Type.GetType("System.String"))
        dtChildren.Columns.Add("Indice_descripcion", Type.GetType("System.String"))
        dtChildren.Columns.Add("Indice_LongitudMax", Type.GetType("System.Int32"))
        dtChildren.Columns.Add("Indice_Obligatorio", Type.GetType("System.Int32"))
        dtChildren.Columns.Add("Indice_Unico", Type.GetType("System.Int32"))
        dtChildren.Columns.Add("folio_norma", Type.GetType("System.Int32"))
        dtChildren.PrimaryKey = New DataColumn() {pkCampoID}



        For Each nNodo As TreeListNode In ASPxTreeList1.GetSelectedNodes()
            idSerie = nNodo.Key
            dsCampos = svr.ListaSeries_Indices(idSerie)
            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                Dim nFilaC As New HtmlTableRow
                Dim nCeldaC As New HtmlTableCell

                Dim xFila As New TableRow
                Dim xCelda As New TableCell

                Select Case dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                    Case 0
                        Dim nCampoT As New CampoTexto
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoTexto.ascx"), CampoTexto)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_Padres")
                        nCampoT.TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")

                        'nCeldaC.Controls.Add(nCampoT)
                        'nFilaC.Cells.Add(nCeldaC)
                        'TBCampos.Rows.Add(nFilaC)


                        xCelda.Controls.Add(nCampoT)
                        xFila.Cells.Add(xCelda)
                        Table1.Rows.Add(xFila)

                    Case 1
                        Dim nCampoT As New CampoTextoLargo
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoTextoLargo.ascx"), CampoTextoLargo)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_Padres")
                        nCampoT.TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    Case 2
                        Dim nCampoT As New CampoFecha
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoFecha.ascx"), CampoFecha)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)

                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_Padres")
                        nCampoT.TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    Case 3
                        Dim nCampoT As New CampoPeriodoFechas
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoFechas.ascx"), CampoPeriodoFechas)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_Padres")
                        nCampoT.TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    Case 4
                        Dim nCampoT As New CampoPeriodoMesAno
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoMesAno.ascx"), CampoPeriodoMesAno)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_Padres")
                        nCampoT.TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    Case 5
                        Dim nCampoT As New CampoPeriodoAno
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoPeriodoAno.ascx"), CampoPeriodoAno)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_Padres")
                        nCampoT.TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    Case 6
                        Dim nCampoT As New CampoSI_NO
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSI_NO.ascx"), CampoSI_NO)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_Padres")
                        nCampoT.TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    Case 7
                        Dim nCampoT As New CampoEntero
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoEntero.ascx"), CampoEntero)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_Padres")
                        nCampoT.TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    Case 8, 9, 10
                        Dim nCampoT As New CampoSlectura
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_Padres")
                        nCampoT.TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                    Case 11
                        Dim nCampoT As New CampoCatalogo
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoCatalogo.ascx"), CampoCatalogo)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_Padres")
                        nCampoT.TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                        nCampoT.Catalogo = dsCampos.Tables(0).Rows(intJ).Item("relacion_con_normaPID")

                    Case 12
                        Dim nCampoT As New CampoGrid
                        nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoGrid.ascx"), CampoGrid)
                        nCeldaC.Controls.Add(nCampoT)
                        nFilaC.Cells.Add(nCeldaC)
                        TBCampos.Rows.Add(nFilaC)
                        nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Muestra_Padres = dsCampos.Tables(0).Rows(intJ).Item("Muestra_Padres")
                        nCampoT.TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                        nCampoT.idArea = dsCampos.Tables(0).Rows(intJ).Item("idArea")
                        nCampoT.idElemento = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
                        nCampoT.idIndice = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                        nCampoT.Indice_Tipo = 12
                End Select

                Dim workRow As DataRow = dtChildren.NewRow()
                workRow("idIndice") = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                workRow("Indice_Tipo") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                workRow("Indice_descripcion") = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                workRow("Indice_LongitudMax") = dsCampos.Tables(0).Rows(intJ).Item("Indice_LongitudMax")
                workRow("Indice_Obligatorio") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                workRow("Indice_Unico") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Unico")
                workRow("folio_norma") = dsCampos.Tables(0).Rows(intJ).Item("folio_norma")
                dtChildren.Rows.Add(workRow)
            Next
        Next
        ASPxGridView1.DataSource = dtChildren
        ASPxGridView1.KeyFieldName = "CampoID"
        ASPxGridView1.DataBind()
    End Sub

    Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxButton1.Click
        Dim idSerie As Integer
        Dim svr As New WSArchivo.Service1
        Dim dsCampos As DataSet
        Dim intJ As Integer
        Dim valor As String

        For intJ = 0 To gdSeries.VisibleRowCount - 1            
            valor = CType(gdSeries.FindRowCellTemplateControl(intJ, gdSeries.Columns("Indice_descripcion"), "ASPxTextBox1"), ASPxTextBox).Text
        Next

        For intJ = 0 To ASPxGridView1.VisibleRowCount - 1
            valor = ASPxGridView1.GetRowValues(intJ, "idIndice")
            valor = CType(ASPxGridView1.FindRowCellTemplateControl(intJ, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).Text
        Next


        For Each nNodo As TreeListNode In ASPxTreeList1.GetSelectedNodes()
            idSerie = nNodo.Key
            dsCampos = svr.ListaSeries_Indices(idSerie)
            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                Select Case TBCampos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")).GetType.FullName
                    Case "CampoTexto"
                        valor = CType(TBCampos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoTexto).ValorCampo
                End Select
            Next
        Next
    End Sub

    Private Sub Wfrm_TE_SolicitudExp_SaveStateComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SaveStateComplete
        ViewState("Table1") = Table1
    End Sub
End Class