Imports Portalv9.SvrUsr
Partial Public Class wfrmPrestamosImprimirSolicitud
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Public nombreArchivo As String
    Public folio As String
    Public descripcion As String
    Public codigoClasificacion As String
    Public fechaConsulta As Date
    Public usuarioSolicitante As String


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

            Dim idSolicitud As Integer = CType(Request("idSolicitud"), Integer)

            If idSolicitud > 0 Then
                Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1
                Dim resultado As DataSet = sv.BuscarSolicitudPrestamo(idSolicitud)

                nombreArchivo = resultado.Tables(0).Rows(0)("Archivo_Descripcion")
                folio = resultado.Tables(0).Rows(0)("idSolicitud_Prestamo")
                descripcion = resultado.Tables(0).Rows(0)("Descripcion")
                codigoClasificacion = resultado.Tables(0).Rows(0)("Codigo_clasificacion")
                fechaConsulta = resultado.Tables(0).Rows(0)("Fecha_Solicitud")
                usuarioSolicitante = resultado.Tables(0).Rows(0)("Usuario_Solicitante")

            End If

        Catch ex As Exception

        End Try
        'Else
        '            mostrar()

        'End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


End Class