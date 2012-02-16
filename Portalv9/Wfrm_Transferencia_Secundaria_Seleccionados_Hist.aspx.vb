Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxGridView

Partial Public Class Wfrm_Transferencia_Secundaria_Seleccionados_Hist
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
            rsDatosTransferencia = sv.ListaTransferencias_Primarias(1)
            lblFecha_Solicitud.Text = rsDatosTransferencia.Tables(0).Rows(0).Item("Fecha_Solicitud")
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





End Class