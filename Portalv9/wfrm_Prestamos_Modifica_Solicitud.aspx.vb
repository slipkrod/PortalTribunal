Imports Portalv9.SvrUsr

Imports System.Collections


Partial Public Class wfrmPrestamosModificaSolicitud
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Public NombreArchivo As String
    Public folio As String
    Public descripcion As String
    Public codigoClasificacion As String
    Public idArchivo As Integer
    Public idDescripcion As Integer
    Public idSolicitud As Integer
    Public dias As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        Try
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            Dim strRes As String = Session("DebeCambiarPwd")
            If strRes <> String.Empty Then
                If CType(strRes, Boolean) = True Then
                    Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                End If
            End If

            idSolicitud = CType(Request("idSolicitud"), Integer)

            If idSolicitud > 0 Then
                Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1
                Dim expedienteDataSet As DataSet = sv.BuscarSolicitudPrestamo(idSolicitud)

                NombreArchivo = expedienteDataSet.Tables(0).Rows(0)("Archivo_Descripcion")
                descripcion = expedienteDataSet.Tables(0).Rows(0)("Descripcion")
                codigoClasificacion = expedienteDataSet.Tables(0).Rows(0)("Codigo_clasificacion")
                idArchivo = expedienteDataSet.Tables(0).Rows(0)("idArchivo")
                idDescripcion = expedienteDataSet.Tables(0).Rows(0)("idDescripcion")

                If Not IsPostBack Then
                    For Each kvp As KeyValuePair(Of Integer, String) In CargaEstatusDropDown(expedienteDataSet.Tables(0).Rows(0)("estatus"))
                        EstatusDropDown.Items.Add(New ListItem(kvp.Value, kvp.Key.ToString()))
                        EstatusDropDown.Items.FindByValue(expedienteDataSet.Tables(0).Rows(0)("estatus")).Selected = True
                    Next
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub Cancelar_Click(ByVal ob As Object, ByVal e As EventArgs)
        Response.Redirect("Wfrm_Prestamos_Lista_Solicitudes.aspx")
    End Sub


    Protected Sub GuardarButton_Click(ByVal ob As Object, ByVal e As EventArgs)

        idSolicitud = CType(Request("idSolicitud"), Integer)

        If idSolicitud > 0 Then
            Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1
            Dim expedienteDataSet As DataSet = sv.BuscarSolicitudPrestamo(idSolicitud)

            NombreArchivo = expedienteDataSet.Tables(0).Rows(0)("Archivo_Descripcion")
            descripcion = expedienteDataSet.Tables(0).Rows(0)("Descripcion")
            codigoClasificacion = expedienteDataSet.Tables(0).Rows(0)("Codigo_clasificacion")
            idArchivo = expedienteDataSet.Tables(0).Rows(0)("idArchivo")
            idDescripcion = expedienteDataSet.Tables(0).Rows(0)("idDescripcion")

            dias = expedienteDataSet.Tables(0).Rows(0)("dias")

            Dim fechaEstimadaDevolucion As Nullable(Of Date) = Nothing
            Dim fechaDevolucion As Nullable(Of Date) = Nothing

            If Not expedienteDataSet.Tables(0).Rows(0)("Fecha_Estimada_Devolucion").GetType().Equals(GetType(DBNull)) Then
                fechaEstimadaDevolucion = expedienteDataSet.Tables(0).Rows(0)("Fecha_Estimada_Devolucion")
            End If

            If Not expedienteDataSet.Tables(0).Rows(0)("Fecha_Devolucion").GetType().Equals(GetType(DBNull)) Then
                fechaDevolucion = expedienteDataSet.Tables(0).Rows(0)("Fecha_Estimada_Devolucion")
            End If

            Dim status As Integer = expedienteDataSet.Tables(0).Rows(0)("estatus")
            If EstatusDropDown.SelectedValue = 3 And status < 3 Then
                fechaEstimadaDevolucion = Date.Now.AddDays(dias)
            End If

            idSolicitud = 0

            If (EstatusDropDown.SelectedValue <> 3) Or (status = 2 And sv.CuentaSolicitudesExpedienteEstatus(idDescripcion, 3) = 0) Then
                idSolicitud = sv.ABC_Solicitud_Prestamos(WSArchivo.OperacionesABC.operCambio, expedienteDataSet.Tables(0).Rows(0)("idSolicitud_Prestamo"), idArchivo, idDescripcion, Nothing, 1, _
                                                     DateAndTime.Now, EstatusDropDown.SelectedValue, expedienteDataSet.Tables(0).Rows(0)("Usuario_Solicitante"), _
                                                     tTicket.UsrID, dias, fechaEstimadaDevolucion, _
                                                     fechaDevolucion)
            Else
                MensajeLabel.Text = "El expediente ya se encuentra prestado"
                MensajeLabel.Visible = True
                ImprimirButton.Visible = False
            End If

            If (idSolicitud > 0) Then
                MensajeLabel.Visible = True

                If Not status = EstatusDropDown.SelectedValue Then
                    GuardarButton.Enabled = False
                    ImprimirButton.Visible = True
                    EstatusDropDown.Enabled = False
                End If

            End If

        End If

    End Sub

    Private Function CargaEstatusDropDown(ByVal estatus As Integer) As Dictionary(Of Integer, String)
        Dim listaEstatus As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)

        Select Case estatus
            'Pendiente
            Case 0
                listaEstatus.Add(0, "Pendiente")
                listaEstatus.Add(2, "Aprobado")
                listaEstatus.Add(1, "Rechazado")
                listaEstatus.Add(5, "Cancelado")

            Case 1
                listaEstatus.Add(1, "Rechazado")
                listaEstatus.Add(2, "Aprobado")
                listaEstatus.Add(5, "Cancelado")
            Case 2
                listaEstatus.Add(2, "Aprobado")
                listaEstatus.Add(3, "Prestado")
                listaEstatus.Add(5, "Cancelado")
            Case 3
                listaEstatus.Add(3, "Prestado")
                listaEstatus.Add(4, "Devuelto")
            Case 4
                listaEstatus.Add(4, "Devuelto")

        End Select

        Return listaEstatus

    End Function


End Class