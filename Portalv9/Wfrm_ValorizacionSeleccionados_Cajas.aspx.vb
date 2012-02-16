Imports DevExpress.Web.ASPxTreeList

Partial Public Class Wfrm_ValorizacionSeleccionados_Cajas
    Inherits System.Web.UI.Page
    Dim sv As New WSArchivo.Service1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Regresar.NavigateUrl = "Wfrm_ValorizacionSeleccionados.aspx?idArchivo=" & Request.QueryString("idArchivo") & _
                      "&idNorma=" & lblidNorma.Text & _
                      "&idFolio=" & Request.QueryString("idFolio") & _
                      "&sTitulo=Valoración primaria del archivo " & lblidArchivoOrigen.Text

        End If
    End Sub
    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        If container.Expanded Then
            Return container.GetValue("Imagen_Open")
        Else
            Return container.GetValue("Imagen_Close")
        End If
    End Function

    Protected Sub btnSelCaja_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim CajasSel As DataSet
        Dim intI As Integer
        gdCajasSel.Selection.UnselectAll()
        CajasSel = sv.Lista_Transferencias_Primarias_Documentos_CajasxidFolioDetalleDocumento(aspxtreeDocumentos.FocusedNode.DataItem("idFolioDetalleDocumento"))
        For intI = 0 To CajasSel.Tables(0).Rows.Count - 1
            gdCajasSel.Selection.SelectRowByKey(CajasSel.Tables(0).Rows(intI).Item("idFolioCaja"))
        Next
        popCajas.ShowOnPageLoad = True

    End Sub

    Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxButton1.Click
        Dim iRow As Integer

        sv.ABC_Transferencias_Primarias_Documentos_Cajas(1, aspxtreeDocumentos.FocusedNode.DataItem("idFolio"), 0, aspxtreeDocumentos.FocusedNode.DataItem("idFolioDetalle"), aspxtreeDocumentos.FocusedNode.DataItem("idFolioDetalleDocumento"))
        For iRow = 0 To gdCajasSel.VisibleRowCount - 1
            If gdCajasSel.Selection.IsRowSelected(iRow) Then
                sv.ABC_Transferencias_Primarias_Documentos_Cajas(0, aspxtreeDocumentos.FocusedNode.DataItem("idFolio"), gdCajasSel.GetRowValues(iRow, "idFolioCaja"), aspxtreeDocumentos.FocusedNode.DataItem("idFolioDetalle"), aspxtreeDocumentos.FocusedNode.DataItem("idFolioDetalleDocumento"))
            End If
        Next
        gdCajasSel.Selection.UnselectAll()
        popCajas.ShowOnPageLoad = False

        dsExpedientesTransferir.Select()
        aspxtreeDocumentos.DataBind()
    End Sub

    Protected Sub aspxtreeDocumentos_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs) Handles aspxtreeDocumentos.HtmlRowPrepared
        If e.RowKind = TreeListRowKind.Data Then
            If e.Level = 1 Then
                aspxtreeDocumentos.FindDataCellTemplateControl(e.NodeKey, aspxtreeDocumentos.Columns("Meter en caja"), "btnSelCaja").Visible = False
            End If
        End If
    End Sub
End Class