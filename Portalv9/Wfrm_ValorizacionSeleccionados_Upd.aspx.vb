﻿Imports Portalv9.SvrUsr
Partial Public Class Wfrm_ValorizacionSeleccionados_Upd
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
            rsDatosTransferencia = sv.ListaTransferencia_Primaria(Request.QueryString("idFolio"))
            lblFecha_Solicitud.Text = rsDatosTransferencia.Tables(0).Rows(0).Item("Fecha_Solicitud")
            rsDatosArchivo = sv.ListaArchivo(rsDatosTransferencia.Tables(0).Rows(0).Item("idArchivoDestino"))
            lblidArchivoDestino.Text = rsDatosArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")

            dsSeleccion = dsExpedientesTraspaso.Select()
            For intI = 0 To dsSeleccion.Table.Rows.Count - 1
                If dsSeleccion.Table.Rows(intI).Item("idStatus") = 1 Then
                    gdbuscadorresultado.Selection.SelectRowByKey(dsSeleccion.Table.Rows(intI).Item("idFolioDetalle"))
                End If
            Next

            Regresar.NavigateUrl = "Wfrm_ValorizacionSeleccionados.aspx?idArchivo=" & Request.QueryString("idArchivo") & _
                                  "&idNorma=" & lblidNorma.Text & _
                                  "&idFolio=" & Request.QueryString("idFolio") & _
                                  "&sTitulo=Valoración primaria del archivo " & lblArchivo.Text
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub butTransferir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butTransferir.Click
        If gdbuscadorresultado.Selection.Count > 0 Then
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

            svr.ABC_Transferencias_Primarias(3, Request.QueryString("idFolio"), 0, Now.Date, 0, 0, "", 1)
            Response.Redirect("Wfrm_ValorizacionSeleccionados.aspx?idArchivo=" & Request.QueryString("idArchivo") & _
                              "&idNorma=" & lblidNorma.Text & _
                              "&idFolio=" & Request.QueryString("idFolio") & _
                              "&sTitulo=Valoración primaria del archivo " & lblArchivo.Text)
        Else
            MsgBox1.ShowMessage("Debe seleccionar por lo menos un expediente.")
        End If
    End Sub
End Class