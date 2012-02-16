Imports Portalv9.SvrUsr
Partial Public Class wfrmPrestamosAltaSolicitud
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Public NombreArchivo As String
    Public folio As String
    Public descripcion As String
    Public codigoClasificacion As String
    Public idArchivo As Integer
    Public idDescripcion As Integer
    Public idSolicitud As Integer

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

            Dim idExpediente As Integer = CType(Session("idExpediente"), Integer)
            NombreArchivo = CType(Session("NombreArchivo"), String)
            If idExpediente > 0 Then
                Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1
                Dim expedienteDataSet As DataSet = sv.BuscaExpedientePrestamos(idExpediente)

                NombreArchivo = CType(Session("NombreArchivo"), String)
                descripcion = expedienteDataSet.Tables(0).Rows(0)("Descripcion")
                codigoClasificacion = expedienteDataSet.Tables(0).Rows(0)("Codigo_clasificacion")
                idArchivo = expedienteDataSet.Tables(0).Rows(0)("idArchivo")
                idDescripcion = expedienteDataSet.Tables(0).Rows(0)("idDescripcion")

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub Cancelar_Click(ByVal ob As Object, ByVal e As EventArgs)
        Response.Redirect("Wfrm_Prestamos_Buscador.aspx")
    End Sub

    Protected Sub Confirmar_Click(ByVal ob As Object, ByVal e As EventArgs)
        Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1

        'Despues obtener el numero de dias para prestamo segun el expediente
        Dim dias As Integer = CType(TextBoxDias.Text, Integer)

        idSolicitud = sv.ABC_Solicitud_Prestamos(Portalv9.WSArchivo.OperacionesABC.operAlta, Nothing, idArchivo, idDescripcion, Nothing, False, Nothing, Nothing, _
                                                 tTicket.UsrID, Nothing, dias, Nothing, Nothing)

        If idSolicitud > 0 Then
            MensajeLabel.Visible = True
            ConfirmaButton.Enabled = False
            ImprimirButton.Visible = True

            Dim mensaje = String.Format("El usuario {0}({1}) ha solicitado el documento: {2}/{3}", tTicket.NombreCompleto, tTicket.UsrID, codigoClasificacion, descripcion)

            EnviaEmail("test@gmail.com", CType(ConfigurationManager.AppSettings("Cuenta_Email"), String), Nothing, "Solicitud de expediente", mensaje)
        End If

    End Sub

    Private Sub EnviaEmail(ByVal mailTo As String, ByVal mailFrom As String, ByVal cc As String, ByVal subject As String, ByVal content As String)
        If mailTo <> "" Then
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = ConfigurationManager.AppSettings("SMTP")
            smtp.Send(mailFrom, mailTo, subject, content)
        End If
    End Sub



End Class