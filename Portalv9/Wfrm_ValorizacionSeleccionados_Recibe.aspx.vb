Imports Portalv9.SvrUsr
Partial Public Class Wfrm_ValorizacionSeleccionados_Recibe
    Inherits System.Web.UI.Page
    Dim sv As New WSArchivo.Service1
#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub btnBuscaTransferencia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscaTransferencia.Click
        Dim rsDatosArchivo As DataSet
        Dim rsDatosTransferencia As DataSet
        rsDatosTransferencia = sv.ListaTransferencia_Primaria(txtTransferencia.Value)
        If rsDatosTransferencia.Tables(0).Rows.Count > 0 Then
            Select Case rsDatosTransferencia.Tables(0).Rows(0).Item("Status")
                Case -1
                    MsgBox1.ShowMessage("Ese folio de transferencia se encuentra cancelado")
                Case 0
                    MsgBox1.ShowMessage("El folio de transferencia se encuentra sin transferir")
                Case 1
                    MsgBox1.ShowMessage("El folio de transferencia se encuentra sin transferir")
                Case 2
                    rsDatosArchivo = sv.ListaArchivo(rsDatosTransferencia.Tables(0).Rows(0).Item("idArchivoOrigen"))
                    lblidNorma.Text = rsDatosArchivo.Tables(0).Rows(0).Item("idNorma")
                    lblFolio.Text = txtTransferencia.Text
                    lblidArchivoOrigen.Text = rsDatosArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")
                    lblFecha_Solicitud.Text = rsDatosTransferencia.Tables(0).Rows(0).Item("Fecha_Solicitud")
                    rsDatosArchivo = sv.ListaArchivo(rsDatosTransferencia.Tables(0).Rows(0).Item("idArchivoDestino"))
                    lblidArchivoDestino.Text = rsDatosArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")
                    dsExpedientes.SelectParameters("idFolio").DefaultValue = txtTransferencia.Value
                    dsExpedientes.Select()
                    gdbuscadorresultado.DataBind()

                    rpHeader.ClientVisible = True

                Case 3
                    MsgBox1.ShowMessage("Ese folio de transferencia ya fué aplicado")
            End Select

        Else
            MsgBox1.ShowMessage("No existe ese folio de transferencia....")
            rpHeader.ClientVisible = False
        End If

    End Sub

    Protected Sub butTransferir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butTransferir.Click
        Dim intI As Integer
        ' Marcamos los registros con su ultimo padre en caso de que se hayan metido en cajas
        For intI = 0 To gdbuscadorresultado.VisibleRowCount - 1
            sv.ABC_Transferencias_Primarias_Expedientes(3, txtTransferencia.Value, gdbuscadorresultado.GetRowValues(intI, "idFolioDetalle"), gdbuscadorresultado.GetRowValues(intI, "idDescripcion"), gdbuscadorresultado.GetRowValues(intI, "idDocumentoPID"), 3)
        Next
        sv.ABC_Transferencias_Primarias(3, txtTransferencia.Value, 0, Now.Date, 0, 0, "", 3)
        Response.Redirect("Wfrm_ValorizacionSeleccionados_OK.aspx")
    End Sub
End Class