Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxGridView

Partial Public Class Wfrm_ValorizacionBajas_Seleccionados
    Inherits System.Web.UI.Page
    Dim sv As New WSArchivo.Service1
#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rsDatosArchivo As DataSet
        Dim rsDatosTransferencia As DataSet
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
            rsDatosTransferencia = sv.ListaBaja_Tramite(Request.QueryString("idFolio"))
            lblFecha_Solicitud.Text = rsDatosTransferencia.Tables(0).Rows(0).Item("Fecha_Solicitud")
        End If
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


    Protected Sub butRepAutorizacion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butRepAutorizacion.Click

        Dim iRow As Integer
        Session("idDescriptionRPTArray") = ""
        For iRow = 0 To gdbuscadorEliminar.VisibleRowCount - 1
            Session("idDescriptionRPTArray") += gdbuscadorEliminar.GetRowValues(iRow, "idDescripcion").ToString() & ","
        Next
        Session("idDescriptionRPTArray") = Session("idDescriptionRPTArray").ToString.Substring(0, Session("idDescriptionRPTArray").ToString.Length - 1)
        Response.Redirect("Wfrm_Traspasos_RptAutorizacion.aspx?idArchivo=" & Request.QueryString("idArchivo").ToString() & _
                          "&Tipo=" & Request.QueryString("Tipo") & _
                          "&sTitulo=" & "Valoración del archivo " & lblidArchivoOrigen.Text & " al archivo ")
    End Sub


    Protected Sub butAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butAceptar.Click
        Dim objGlobal As New clsGlobal
        Dim intI As Integer
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If Not objGlobal.TicketValido(tTicket) Then
            LogOff()
            Exit Sub
        End If
        For intI = 0 To gdbuscadorEliminar.VisibleRowCount - 1
            sv.ABC_Archivo_Descripciones(WSArchivo.OperacionesABC.operBaja, Request.QueryString("idArchivo"), gdbuscadorEliminar.GetRowValues(intI, "idDescripcion"), "", 0, 0, "", 0, "", 0, 0)
        Next

        sv.ABC_Transferencias_Primarias_Bajas(3, Request.QueryString("idFolio"), 0, Now.Date, 0, "", 2)
        Response.Redirect("Wfrm_ValorizacionBajas_Seleccionados_OK.aspx")
    End Sub


    Protected Sub butCambiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butCambiar.Click
        Response.Redirect("Wfrm_ValorizacionBajas_Seleccionados_Upd.aspx?idArchivo=" & Request.QueryString("idArchivo") & _
                                  "&idNorma=" & lblidNorma.Text & _
                                  "&idFolio=" & Request.QueryString("idFolio"))
    End Sub
End Class