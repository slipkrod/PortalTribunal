Imports Portalv9.SvrUsr
Imports Microsoft.VisualBasic
Partial Public Class Wfrm_Contenido
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                LogOff()
                Exit Sub
            End If
            Dim strRes As String = Session("DebeCambiarPwd")
            If strRes <> String.Empty Then
                If CType(strRes, Boolean) = True Then
                    Server.Transfer("Wfrm_CambiaPwd.aspx?index=0")
                End If
            End If
            'Carga los datos generales en la pantalla de bienvenida
            CargaDatos()
            'Carga permisos Accesos Directos
            CargaPermisos()
        End If

    End Sub
    Private Sub CargaPermisos()


    End Sub
    Private Sub CargaDatos()
        'Nombre: CargaDatos
        'Descripción: Carga los datos generales en la pantalla de bienvenida
        'Fecha: 28/10/2008
        'Programador: IEJ
        'Parámetros
        'IN
        '   Ninguno
        'OUT
        '   Ninguno 
        Dim tTicket As IDTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        'Nombre del usuario
        Me.lblNombre.Text = tTicket.NombreCompleto
        'Fecha del último Acceso
        Me.lblUltimoAcceso.Text = Now
        '**************
        'Manda a actualizar el último login
        '**************
        Dim svrusr As Core
        Dim rResult As Respuesta = Nothing
        Dim strMsg As String = String.Empty
        Dim ds As New DataSet
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            svrusr = New Core
            ds = svrusr.CambiarUltLogin(tTicket, rResult)
            If Not rResult.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                strMsg = "Ocurrió un error . " & rResult.RespuestaToString
            End If
        Catch ex As Exception
            strMsg = ex.ToString
        End Try
        '**************
        'Aviso de caducidad del password
        '**************
        'Fecha final
        Dim datFechaFinal As Date
        datFechaFinal = DateAdd(DateInterval.Day, tTicket.DuracionDias, tTicket.FechaCreacionPwd)
        'Obtiene los días restantes
        Dim intDiasRestantes As Integer
        intDiasRestantes = DateDiff(DateInterval.Day, Date.Now, datFechaFinal)
        'Valida si el aviso debe de enviar
        If tTicket.AvisoCaducidadPwdDias >= intDiasRestantes Then
            Me.lblAviso.Text = "Faltan " & intDiasRestantes & " días para que caduque la contraseña"
        End If
    End Sub
    Private Sub LogOff()
        Server.Transfer("Logoff.aspx")
    End Sub

End Class