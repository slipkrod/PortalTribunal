Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxGridView

Partial Public Class wfrmPrestamosListaSolicitudes
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket

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

            Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1
            Dim solicitudesDataSet As DataSet = sv.ListaSolicitudesPrestamos(EstatusDropDown.SelectedValue)

            If (EstatusDropDown.SelectedValue = 3) Then
                NotificacionButton.Visible = True
            Else
                NotificacionButton.Visible = False
            End If

            SolicitudesGrid.DataSource = solicitudesDataSet
            SolicitudesGrid.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


    Protected Sub SolicitudesGrid_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs) Handles SolicitudesGrid.HtmlRowPrepared
        If e.RowType = GridViewRowType.Data Then
            If Not e.GetValue("Fecha_Estimada_Devolucion").GetType().Equals(GetType(DBNull)) Then
                Dim fechaEntrega As Date = CType(e.GetValue("Fecha_Estimada_Devolucion"), Date)
                Dim status As Integer = CType(e.GetValue("Estatus"), Integer)
                If fechaEntrega < Date.Now And status = 3 Then
                    e.Row.ForeColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub

    Protected Sub NotificacionButton_Click(ByVal ob As Object, ByVal e As EventArgs)
        Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1

        'Obtiene todas las solicitudes de prestamo con estatus de prestado
        Dim solicitudesDataSet As DataSet = sv.ListaSolicitudesPrestamosPorVencer()

        Dim mensaje1DíaPorVencer As String = "{0}: El documento {1}/{2} prestado tiene que ser entregado el día de mañana"
        Dim mensajeVencimientoAlDia As String = "{0}: El documento {1}/{2} prestado tiene que ser entregado el día de hoy"
        Dim mensaje1DíaNDiasVencido As String = "{0}: El documento {1}/{2} prestado tiene {3} dias de atraso en su entrega"

        For Each row As DataRow In sv.ListaSolicitudesPrestamosPorVencer().Tables(0).Rows
            Dim diasVencimiento As Integer = Date.Now.Date.Subtract(CType(row("Fecha_Estimada_Devolucion"), Date).Date).Days
            If diasVencimiento = -1 Then
                mensaje1DíaPorVencer = String.Format(mensaje1DíaPorVencer, row("Usuario_Solicitante"), row("Codigo_clasificacion"), row("Descripcion"))
            ElseIf diasVencimiento = 0 Then
                mensajeVencimientoAlDia = String.Format(mensajeVencimientoAlDia, row("Usuario_Solicitante"), row("Codigo_clasificacion"), row("Descripcion"))
            Else
                mensaje1DíaNDiasVencido = String.Format(mensaje1DíaNDiasVencido, row("Usuario_Solicitante"), row("Codigo_clasificacion"), row("Descripcion"), diasVencimiento)
            End If
        Next


    End Sub

End Class