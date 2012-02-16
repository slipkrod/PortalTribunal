Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxGridView

Partial Public Class Wfrm_Transferencia_Secundaria_Seleccionados
    Inherits System.Web.UI.Page
    Dim sv As New WSArchivo.Service1
#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rsDatosArchivo As DataSet
        'Dim rsDatosTransferencia As DataSet
        If Not Page.IsPostBack Then
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            rsDatosArchivo = sv.ListaArchivo(Request.QueryString("idArchivo"))
            lblidNorma.Text = rsDatosArchivo.Tables(0).Rows(0).Item("idNorma")
            lblFolio.Text = Request.QueryString("idFolio")
            lblidArchivoOrigen.Text = rsDatosArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")
            'rsDatosTransferencia = sv.ListaTransferencias_Secunarias(1)
            'lblFecha_Solicitud.Text = rsDatosTransferencia.Tables(0).Rows(0).Item("Fecha_Solicitud")
        End If
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


    Protected Sub butRepAutorizacion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butRepAutorizacion.Click

        Dim iRow As Integer
        Session("idDescriptionRPTArray") = ""
        For iRow = 0 To gdbuscadorresultado.VisibleRowCount - 1
            Session("idDescriptionRPTArray") += gdbuscadorresultado.GetRowValues(iRow, "idDescripcion").ToString() & ","
        Next
        Session("idDescriptionRPTArray") = Session("idDescriptionRPTArray").ToString.Substring(0, Session("idDescriptionRPTArray").ToString.Length - 1)
        Response.Redirect("Wfrm_Traspasos_RptAutorizacion.aspx?idArchivo=" & Request.QueryString("idArchivo").ToString() & _
                          "&Tipo=" & Request.QueryString("Tipo") & _
                          "&sTitulo=" & "Valoración del archivo " & lblidArchivoOrigen.Text & " al archivo ")
    End Sub


    Protected Sub butAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butAceptar.Click
        Dim rsElementoArbol As DataSet
        Dim rsElementoPadre As DataSet
        Dim rsElementoPadreCaja As DataSet
        Dim rsElementoPadreCajaSerie As DataSet
        Dim rsTransferencia As DataSet
        Dim objGlobal As New clsGlobal
        Dim intI As Integer
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If Not objGlobal.TicketValido(tTicket) Then
            LogOff()
            Exit Sub
        End If
        For intI = 0 To gdbuscadorresultado.VisibleRowCount - 1
            rsElementoArbol = sv.ListaArchivo_Descripciones_idDescripcion(Request.QueryString("idArchivo"), gdbuscadorresultado.GetRowValues(intI, "idDescripcion"))
            rsElementoPadre = sv.ListaArchivo_Descripciones_idDescripcion(Request.QueryString("idArchivo"), rsElementoArbol.Tables(0).Rows(0).Item("idDocumentoPID"))
            If rsElementoPadre.Tables(0).Rows(0).Item("idNivel") = 7 Then
                If Busca_HijosCaja(rsElementoPadre.Tables(0).Rows(0).Item("idDescripcion")) = False Then
                    MsgBox1.ShowMessage("Existen expedientes dentro de la caja que no estan en la lista de expedientes a transferir...")
                    Exit Sub
                End If
            End If
        Next

        'Validamos que existan las series o cajas en el archivo de Concentración
        rsTransferencia = sv.ListaTransferencia_Secundaria(Request.QueryString("idFolio"))

        For intI = 0 To gdbuscadorresultado.VisibleRowCount - 1
            rsElementoArbol = sv.ListaArchivo_Descripciones_idDescripcion(Request.QueryString("idArchivo"), gdbuscadorresultado.GetRowValues(intI, "idDescripcion"))
            rsElementoPadre = sv.ListaArchivo_Descripciones_idDescripcion(Request.QueryString("idArchivo"), rsElementoArbol.Tables(0).Rows(0).Item("idDocumentoPID"))
            If rsElementoPadre.Tables(0).Rows(0).Item("idNivel") = 7 Then
                rsElementoPadreCaja = sv.ListaArchivo_Descripciones_idDescripcion(Request.QueryString("idArchivo"), rsElementoPadre.Tables(0).Rows(0).Item("idDocumentoPID"))
                rsElementoPadreCajaSerie = sv.ListaArchivo_Codigo_clasificacion(rsTransferencia.Tables(0).Rows(0).Item("idArchivoDestino"), rsElementoPadreCaja.Tables(0).Rows(0).Item("Codigo_clasificacion"))
                If rsElementoPadre.Tables(0).Rows.Count = 0 Then
                    MsgBox1.ShowMessage("No existe la serie en el archivo de concentración para transferir los expedientes...")
                    Exit Sub
                End If
            Else
                rsElementoPadre = sv.ListaArchivo_Codigo_clasificacion(rsTransferencia.Tables(0).Rows(0).Item("idArchivoDestino"), rsElementoPadre.Tables(0).Rows(0).Item("Codigo_clasificacion"))
                If rsElementoPadre.Tables(0).Rows.Count = 0 Then
                    MsgBox1.ShowMessage("No existe la serie en el archivo de concentración para transferir los expedientes...")
                    Exit Sub
                End If
            End If
        Next

        ' Realizamos la trasnferencia de cada expediente al archivo de concentración
        For intI = 0 To gdbuscadorresultado.VisibleRowCount - 1
            rsElementoArbol = sv.ListaArchivo_Descripciones_idDescripcion(Request.QueryString("idArchivo"), gdbuscadorresultado.GetRowValues(intI, "idDescripcion"))
            If rsElementoArbol.Tables(0).Rows.Count > 0 Then
                rsElementoPadre = sv.ListaArchivo_Descripciones_idDescripcion(Request.QueryString("idArchivo"), rsElementoArbol.Tables(0).Rows(0).Item("idDocumentoPID"))
                If rsElementoPadre.Tables(0).Rows.Count > 0 Then
                    If rsElementoPadre.Tables(0).Rows(0).Item("idNivel") = 7 Then
                        rsElementoPadreCaja = sv.ListaArchivo_Descripciones_idDescripcion(Request.QueryString("idArchivo"), rsElementoPadre.Tables(0).Rows(0).Item("idDocumentoPID"))
                        rsElementoPadreCajaSerie = sv.ListaArchivo_Codigo_clasificacion(rsTransferencia.Tables(0).Rows(0).Item("idArchivoDestino"), rsElementoPadreCaja.Tables(0).Rows(0).Item("Codigo_clasificacion"))
                        sv.Transfiere_Archivo_Descripciones_Secundarias(Request.QueryString("idArchivo"), rsElementoPadre.Tables(0).Rows(0).Item("idDescripcion"), rsTransferencia.Tables(0).Rows(0).Item("idArchivoDestino"), rsElementoPadreCajaSerie.Tables(0).Rows(0).Item("idDescripcion"), gdbuscadorresultado.GetRowValues(intI, "idFolioDetalle"))
                    Else
                        rsElementoPadre = sv.ListaArchivo_Codigo_clasificacion(rsTransferencia.Tables(0).Rows(0).Item("idArchivoDestino"), rsElementoPadre.Tables(0).Rows(0).Item("Codigo_clasificacion"))
                        sv.Transfiere_Archivo_Descripciones_Secundarias(Request.QueryString("idArchivo"), gdbuscadorresultado.GetRowValues(intI, "idDescripcion"), rsTransferencia.Tables(0).Rows(0).Item("idArchivoDestino"), rsElementoPadre.Tables(0).Rows(0).Item("idDescripcion"), gdbuscadorresultado.GetRowValues(intI, "idFolioDetalle"))
                    End If
                End If
            End If
        Next

        ' Marcamos los registros con su ultimo padre en caso de que se hayan metido en cajas
        For intI = 0 To gdbuscadorresultado.VisibleRowCount - 1
            sv.ABC_Transferencias_Secundarias_Expedientes(3, Request.QueryString("idFolio"), gdbuscadorresultado.GetRowValues(intI, "idFolioDetalle"), gdbuscadorresultado.GetRowValues(intI, "idDescripcion"), gdbuscadorresultado.GetRowValues(intI, "idDocumentoPID"), 2)
        Next
        sv.ABC_Transferencias_Secundarias(3, Request.QueryString("idFolio"), 0, Now.Date, 0, 0, "", 2)
        Response.Redirect("Wfrm_Transferencia_Secundaria_Seleccionados_OK.aspx")
    End Sub

    Protected Function Busca_HijosCaja(ByVal idDescripcion As Integer) As Boolean
        Dim rsHijos As DataSet
        Dim rsExisteHijo As DataSet
        Dim intI As Integer
        Busca_HijosCaja = True
        rsHijos = sv.ListaArchivo_Descripciones_idDescripcion_Hijos(Request.QueryString("idArchivo"), idDescripcion)
        For intI = 0 To rsHijos.Tables(0).Rows.Count - 1
            rsExisteHijo = sv.ListaVencimientos_Archivo_Concentracion_Seleccion_idDescripcion(Request.QueryString("idArchivo"), Request.QueryString("idFolio"), rsHijos.Tables(0).Rows(intI).Item("idDescripcion"))
            If rsExisteHijo.Tables(0).Rows.Count = 0 Then
                Busca_HijosCaja = False
                Exit Function
            End If
        Next
    End Function

    Protected Sub butCambiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butCambiar.Click
        Response.Redirect("Wfrm_Transferencia_Secundaria_Seleccionados_Upd.aspx?idArchivo=" & Request.QueryString("idArchivo") & _
                                  "&idNorma=" & lblidNorma.Text & _
                                  "&idFolio=" & Request.QueryString("idFolio"))
    End Sub


    Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Wfrm_Transferencia_Secundaria_Seleccionados_Cajas.aspx?idArchivo=" & Request.QueryString("idArchivo") & _
                          "&idNorma=" & lblidNorma.Text & _
                          "&idFolio=" & Request.QueryString("idFolio"))
    End Sub
End Class