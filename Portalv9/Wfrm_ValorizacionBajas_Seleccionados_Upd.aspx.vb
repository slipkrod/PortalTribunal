Imports Portalv9.SvrUsr
Partial Public Class Wfrm_ValorizacionBajas_Seleccionados_Upd
    Inherits System.Web.UI.Page
    Dim sv As New WSArchivo.Service1

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rsDatosArchivo As DataSet
        Dim rsDatosTransferencia As DataSet
        If Not IsPostBack Then
            Dim dsSeleccion As DataView
            Dim intI As Integer
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                Logoff()
                Exit Sub
            End If
            rsDatosArchivo = sv.ListaArchivo(Request.QueryString("idArchivo"))
            lblidNorma.Text = rsDatosArchivo.Tables(0).Rows(0).Item("idNorma")
            lblFolio.Text = Request.QueryString("idFolio")
            lblidArchivoOrigen.Text = rsDatosArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")
            rsDatosTransferencia = sv.ListaBaja_Tramite(Request.QueryString("idFolio"))
            lblFecha_Solicitud.Text = rsDatosTransferencia.Tables(0).Rows(0).Item("Fecha_Solicitud")

            dsSeleccion = dsExpedientesBaja.Select()
            For intI = 0 To dsSeleccion.Table.Rows.Count - 1
                If dsSeleccion.Table.Rows(intI).Item("idStatus") = 1 Then
                    gdbuscadorBajas.Selection.SelectRowByKey(dsSeleccion.Table.Rows(intI).Item("idFolioDetalle"))
                End If
            Next

            Regresar.NavigateUrl = "Wfrm_ValorizacionBajas_Seleccionados.aspx?idArchivo=" & Request.QueryString("idArchivo") & _
                                  "&idNorma=" & lblidNorma.Text & _
                                  "&idFolio=" & Request.QueryString("idFolio") & _
                                  "&sTitulo=Valoración primaria del archivo " & lblArchivo.Text
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub butTransferir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butTransferir.Click
        If gdbuscadorBajas.Selection.Count > 0 Then
            Dim iRow As Integer
            Dim svr = New Portalv9.WSArchivo.Service1
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If

            For iRow = 0 To gdbuscadorBajas.VisibleRowCount - 1
                If gdbuscadorBajas.Selection.IsRowSelected(iRow) Then
                    svr.ABC_Transferencias_Primarias_Bajas_Documentos(3, Request.QueryString("idFolio"), gdbuscadorBajas.GetRowValues(iRow, "idFolioDetalle"), gdbuscadorBajas.GetRowValues(iRow, "idDescripcion"), gdbuscadorBajas.GetRowValues(iRow, "idDocumentoPID"), 1)
                Else
                    svr.ABC_Transferencias_Primarias_Bajas_Documentos(3, Request.QueryString("idFolio"), gdbuscadorBajas.GetRowValues(iRow, "idFolioDetalle"), gdbuscadorBajas.GetRowValues(iRow, "idDescripcion"), gdbuscadorBajas.GetRowValues(iRow, "idDocumentoPID"), 0)
                End If
            Next

            svr.ABC_Transferencias_Primarias_Bajas(3, Request.QueryString("idFolio"), 0, Now.Date, 0, "", 1)
            Response.Redirect("Wfrm_ValorizacionBajas_Seleccionados.aspx?idArchivo=" & Request.QueryString("idArchivo") & _
                              "&idNorma=" & lblidNorma.Text & _
                              "&idFolio=" & Request.QueryString("idFolio") & _
                              "&sTitulo=Baja documental del archivo " & lblArchivo.Text)
        Else
            MsgBox1.ShowMessage("Debe seleccionar por lo menos un expediente.")
        End If
    End Sub
End Class