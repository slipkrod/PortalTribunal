Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxGridView

Partial Public Class Wfrm_ValorizacionArchivos
    Inherits System.Web.UI.Page
    Dim sv As New WSArchivo.Service1

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rsDatosArchivo As DataSet
        If Not Page.IsPostBack Then
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            lbltitulo.Text = "Transferencia Primaria"
            rsDatosArchivo = sv.ListaArchivo(Request.QueryString("idArchivo"))
            lblidNorma.Text = rsDatosArchivo.Tables(0).Rows(0).Item("idNorma")
            lblArchivo.Text = rsDatosArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub ObjectDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsExpedientesTraspaso.Selecting
        If Not IsPostBack Then
            e.Cancel = True
        End If
    End Sub

    Protected Sub butTransferir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butTransferir.Click
        If gdbuscadorresultado.Selection.Count + gdbuscadorBajas.Selection.Count > 0 Then
            Dim iRow As Integer
            Dim svr = New Portalv9.WSArchivo.Service1
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If

            For iRow = 0 To gdbuscadorresultado.VisibleRowCount - 1
                If gdbuscadorresultado.Selection.IsRowSelected(iRow) Then
                    svr.ABC_Transferencias_Primarias_Expedientes(3, Request.QueryString("idFolio"), gdbuscadorresultado.GetRowValues(iRow, "idFolioDetalle"), gdbuscadorresultado.GetRowValues(iRow, "idDescripcion"), gdbuscadorresultado.GetRowValues(iRow, "idDocumentoPID"), 1)
                Else
                    svr.ABC_Transferencias_Primarias_Expedientes(3, Request.QueryString("idFolio"), gdbuscadorresultado.GetRowValues(iRow, "idFolioDetalle"), gdbuscadorresultado.GetRowValues(iRow, "idDescripcion"), gdbuscadorresultado.GetRowValues(iRow, "idDocumentoPID"), 0)
                End If
            Next

            For iRow = 0 To gdbuscadorBajas.VisibleRowCount - 1
                If gdbuscadorBajas.Selection.IsRowSelected(iRow) Then
                    svr.ABC_Transferencias_Primarias_Expedientes(3, Request.QueryString("idFolio"), gdbuscadorBajas.GetRowValues(iRow, "idFolioDetalle"), gdbuscadorBajas.GetRowValues(iRow, "idDescripcion"), gdbuscadorBajas.GetRowValues(iRow, "idDocumentoPID"), 1)
                Else
                    svr.ABC_Transferencias_Primarias_Expedientes(3, Request.QueryString("idFolio"), gdbuscadorBajas.GetRowValues(iRow, "idFolioDetalle"), gdbuscadorBajas.GetRowValues(iRow, "idDescripcion"), gdbuscadorBajas.GetRowValues(iRow, "idDocumentoPID"), 0)
                End If
            Next


            svr.ABC_Transferencias_Primarias(3, Request.QueryString("idFolio"), 0, Now.Date, 0, 0, "", 1)
            Response.Redirect("Wfrm_ValorizacionSeleccionados.aspx?idArchivo=" & Request.QueryString("idArchivo") & _
                              "&idNorma=" & lblidNorma.Text & _
                              "&idFolio=" & Request.QueryString("idFolio") & _
                              "&sTitulo=Valoración primaria del archivo " & lblArchivo.Text)
        Else
            MsgBox1.ShowMessage("Debe seleccionar por lo menos un expediente.")
        End If
    End Sub

    Function getFasesTrasladosByVal(ByVal sVal As String) As String
        Dim svrStats = New Portalv9.WSArchivo.Service1
        Dim myStats As New ASPxComboBox
        myStats.ValueField = "IDCatalogo_item"
        myStats.TextField = "Descripcion"
        myStats.DataSource = svrStats.ListaCatalogo_Datos(15)
        myStats.DataBind()
        Return myStats.Items.FindByValue(sVal).Text
    End Function

    Function getFasesTrasladosByText(ByVal sDescripcion As String) As Integer
        Dim svrStats = New Portalv9.WSArchivo.Service1
        Dim myStats As New ASPxComboBox
        myStats.ValueField = "IDCatalogo_item"
        myStats.TextField = "Descripcion"
        myStats.DataSource = svrStats.ListaCatalogo_Datos(15)
        myStats.DataBind()
        Return myStats.Items.FindByText(sDescripcion).Value
    End Function


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        sv.Prepara_Vencimientos_Archivo_Tramite(Request.QueryString("idArchivo"), Request.QueryString("idFolio"), deFechaCorte.Date)
        dsExpedientesTraspaso.SelectParameters("idFolio").DefaultValue = Request.QueryString("idFolio")
        dsExpedientesTraspaso.SelectParameters("Baja").DefaultValue = 0
        dsExpedientesTraspaso.Select()
        gdbuscadorresultado.DataBind()

        dsExpedientesBaja.SelectParameters("idFolio").DefaultValue = Request.QueryString("idFolio")
        dsExpedientesBaja.SelectParameters("Baja").DefaultValue = 1
        dsExpedientesBaja.Select()
        gdbuscadorBajas.DataBind()
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback
        Select Case e.Parameter
            Case 1
                iframeIndices.Attributes("src") = "Wfm_Indices_Lectura.aspx?idNorma=" & gdbuscadorresultado.GetDataRow(gdbuscadorresultado.FocusedRowIndex)("idNorma") & _
                    "&idArchivo=" & gdbuscadorresultado.GetDataRow(gdbuscadorresultado.FocusedRowIndex)("idArchivo") & _
                    "&idSerie=" & gdbuscadorresultado.GetDataRow(gdbuscadorresultado.FocusedRowIndex)("idSerie") & _
                    "&idNivel=" & gdbuscadorresultado.GetDataRow(gdbuscadorresultado.FocusedRowIndex)("idNivel") & _
                    "&idDescripcion=" & gdbuscadorresultado.GetDataRow(gdbuscadorresultado.FocusedRowIndex)("idDescripcion") & "&Logico=-1"
            Case 2
                iframeIndices.Attributes("src") = "Wfm_Indices_Lectura.aspx?idNorma=" & gdbuscadorBajas.GetDataRow(gdbuscadorBajas.FocusedRowIndex)("idNorma") & _
                    "&idArchivo=" & gdbuscadorBajas.GetDataRow(gdbuscadorBajas.FocusedRowIndex)("idArchivo") & _
                    "&idSerie=" & gdbuscadorBajas.GetDataRow(gdbuscadorBajas.FocusedRowIndex)("idSerie") & _
                    "&idNivel=" & gdbuscadorBajas.GetDataRow(gdbuscadorBajas.FocusedRowIndex)("idNivel") & _
                    "&idDescripcion=" & gdbuscadorBajas.GetDataRow(gdbuscadorBajas.FocusedRowIndex)("idDescripcion") & "&Logico=-1"
        End Select
    End Sub
End Class
