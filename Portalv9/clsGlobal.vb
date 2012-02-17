Imports Portalv9.SvrUsr

Friend Class clsGlobal
    'Inherits System.Web.HttpApplication
	'Comentario de prueba
    Friend Function TicketValido(ByRef pTicket As IDTicket) As Boolean
        Dim db As New Core
        Dim rRespuesta As Respuesta = Nothing
        Try
            db.ActualizarTicket(pTicket, rRespuesta)
            Return rRespuesta.RespuestaID = GlobalDef.GSTR_RES_LOGIN_rlLoginOk
        Catch ex As Exception
            Return False
        End Try

    End Function

    Friend Function ClonarTicket(ByVal pticket As IDTicket) As WSConsultas.IDTicket
        Dim tRes As New WSConsultas.IDTicket
        Try
            With tRes
                .ClienteID = pticket.ClienteID
                .FechaHoraInicio = pticket.FechaHoraInicio
                .FechaHoraUltimoAcceso = pticket.FechaHoraUltimoAcceso
                .GrupoAdminID = pticket.GrupoAdminID
                .IP = pticket.IP
                .NoIdentidad = pticket.NoIdentidad
                .NombreCompleto = pticket.NombreCompleto
                .NombreUsuario = pticket.NombreUsuario
                .PerfilUsuarioID = pticket.PerfilUsuarioID
                .ProyectoID = pticket.ProyectoID
                .TicketID = pticket.TicketID
                .TiempoActualizoPwd = pticket.TiempoActualizoPwd
                .TiempoRestante = pticket.TiempoRestante
                .TiempoVida = pticket.TiempoVida
                .TiempoVidaPwd = pticket.TiempoVidaPwd
                .UsrID = pticket.UsrID
                .VersionAplicacionID = pticket.VersionAplicacionID
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return tRes
    End Function
    Friend Function ClonarTicketWS(ByVal pticket As IDTicket) As WsImg.IDTicket
        Dim tRes As New WsImg.IDTicket
        Try
            With tRes
                .ClienteID = pticket.ClienteID
                .FechaHoraInicio = pticket.FechaHoraInicio
                .FechaHoraUltimoAcceso = pticket.FechaHoraUltimoAcceso
                .GrupoAdminID = pticket.GrupoAdminID
                .IP = pticket.IP
                .NoIdentidad = pticket.NoIdentidad
                .NombreCompleto = pticket.NombreCompleto
                .NombreUsuario = pticket.NombreUsuario
                .PerfilUsuarioID = pticket.PerfilUsuarioID
                .ProyectoID = pticket.ProyectoID
                .TicketID = pticket.TicketID
                .TiempoActualizoPwd = pticket.TiempoActualizoPwd
                .TiempoRestante = pticket.TiempoRestante
                .TiempoVida = pticket.TiempoVida
                .TiempoVidaPwd = pticket.TiempoVidaPwd
                .UsrID = pticket.UsrID
                .VersionAplicacionID = pticket.VersionAplicacionID
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return tRes
    End Function

    ''' <summary>
    ''' Llena las propiedades correspondientes a los parámetros del archivo .config
    ''' </summary>
    ''' <param name="Archivo">instancia del objeto archivo por referencia</param>
    ''' <remarks></remarks>
    Shared Sub LlenaConfig(ByRef Archivo As RNArchivos.RNArchivo)
        Dim strBD_Size As String = ConfigurationManager.AppSettings.Get("BD_Size")
        Dim strBD_Maxsize As String = ConfigurationManager.AppSettings.Get("BD_Maxsize")
        Dim strBD_Filegrowth As String = ConfigurationManager.AppSettings.Get("BD_Filegrowth")
        Dim strLOG_Size As String = ConfigurationManager.AppSettings.Get("LOG_Size")
        Dim strLOG_Maxsize As String = ConfigurationManager.AppSettings.Get("LOG_Maxsize")
        Dim strLOG_Filegrowth As String = ConfigurationManager.AppSettings.Get("LOG_Filegrowth")

        With Archivo
            .BD_Size = strBD_Size
            .BD_Maxsize = strBD_Maxsize
            .BD_Filegrowth = strBD_Filegrowth
            .LOG_Size = strLOG_Size
            .LOG_Maxsize = strLOG_Maxsize
            .LOG_Filegrowth = strLOG_Filegrowth
        End With
    End Sub

    ''' <summary>
    ''' Llena las propiedades correspondientes a los parámetros del archivo .config
    ''' </summary>
    ''' <param name="Archivo">instancia del objeto archivo por referencia</param>
    ''' <remarks></remarks>
    Shared Sub LlenaConfig(ByRef Archivo As RNArchivos.RNArchivoOracle)
        Dim strBD_Size As String = ConfigurationManager.AppSettings.Get("BD_Size")
        Dim strBD_Maxsize As String = ConfigurationManager.AppSettings.Get("BD_Maxsize")
        Dim strBD_Filegrowth As String = ConfigurationManager.AppSettings.Get("BD_Filegrowth")
        Dim strLOG_Size As String = ConfigurationManager.AppSettings.Get("LOG_Size")
        Dim strLOG_Maxsize As String = ConfigurationManager.AppSettings.Get("LOG_Maxsize")
        Dim strLOG_Filegrowth As String = ConfigurationManager.AppSettings.Get("LOG_Filegrowth")

        With Archivo
            .BD_Size = strBD_Size
            .BD_Maxsize = strBD_Maxsize
            .BD_Filegrowth = strBD_Filegrowth
            .LOG_Size = strLOG_Size
            .LOG_Maxsize = strLOG_Maxsize
            .LOG_Filegrowth = strLOG_Filegrowth
        End With
    End Sub


    ''' <summary>
    ''' Método para convertir un tipo de dato de SQL string a dbType
    ''' </summary>
    ''' <param name="tipo">Cadena con el nombre del tipo</param>
    ''' <returns>Valor del enumerado dbType</returns>
    ''' <remarks></remarks>
    Shared Function ObtenerDBTipo(ByVal tipo As String) As System.Data.SqlDbType
        Dim tipoResultado As System.Data.SqlDbType

        If tipo <> String.Empty Then
            Try
                Do
                    If tipoResultado.ToString.ToLower = tipo.ToLower Then Exit Do
                    tipoResultado += 1
                    If tipoResultado > Data.SqlDbType.DateTimeOffset Then Exit Do
                Loop
            Catch ex As Exception
                tipoResultado = Data.SqlDbType.VarChar
            End Try
        End If
        Return tipoResultado
    End Function

End Class
