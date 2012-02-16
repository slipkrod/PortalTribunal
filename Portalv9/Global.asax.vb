Imports System.Web.SessionState
Imports Portalv9.SvrUsr

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Public Const CfgKeyConnString As String = "ConnectionString"
    Public Const CfgKeyFirstDayOfWeek As String = "FirstDayOfWeek"

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        ' Se desencadena cuando se inicia la aplicación
        Application.Add("GN_APLICACION_ID", 1)
        Application.Add("GN_VERSION_APLICACION_ID", System.Configuration.ConfigurationManager.AppSettings("VersionAplicacionID"))
        Application.Add("GN_PROYECTO_ID", System.Configuration.ConfigurationManager.AppSettings("ProyectoID"))
        ' Permiso para modificar campos de captura
        Application.Add("GN_PERMISO_ACT_CAPTURA", 52)
        'cttes. de respuesta del servicio Usuario
        Application.Add("GSTR_RES_LOGIN_rlErrorInterno", "2100")
        Application.Add("GSTR_RESPUESTA_OK_DEFAULT", "0")
        Application.Add("GSTR_RESPUESTA_DEBE_CAMBIAR_PWD", "2050")
        Application.Add("GSTR_RESPUESTA_DEBE_CAMBIAR_PWD1", "2051")
        Application.Add("GSTR_RESPUESTA_1", "0")
        Application.Add("GSTR_RESPUESTA_2", "0")

        'Permiso para el Visor (Guardar e Imprimir)
        Application.Add("GN_PERMISO_VISOR_SAVE", "11")
        'Salvar todas las imagenes en un tiff multipagina se usa imagging
        Application.Add("GN_PERMISO_VISOR_PRINT", "12")
        'Ruta temporal para Almacenar Img. y crear ZIP (modulo: Exportar Expediente BANCOMER)
        'Application.Add("GN_PERMISO_EXPORTAR_EXPEDIENTE", "1002")
        '        Application.Add("GN_PERMISO_VISOR_SAVEALL", "1003")
        Application.Add("GN_PERMISO_SUPERVISOR_CALIDAD", "13")
        Application.Add("GN_PERMISO_VISOR_PDF", "14")
        Application.Add("GN_PERMISO_TIPIFICACION_DOCUMENTO", "15")
        Application.Add("GN_PERMISO_REMPLAZO_IMAGEN", "16")
        Application.Add("GN_PERMISO_DESBLOQUEO_IMAGEN", "17")
        Application.Add("GN_PERMISO_AGREGAR_DOCUMENTO", "18")

        'Application.Add("GN_PERMISO_TRANSITA_EXP_FIRMA", "1009")

        'Application.Add("GN_PATH_EXPORTAR_EXP", "c:\TempDir")
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
        'firma la salida en el servicio
        Dim tTicket As IDTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim svr As Core
        'Dim cerrarsesion As String
        '
        If Not tTicket Is Nothing Then
            svr = New Core
            svr.LogOff(tTicket)
            svr = Nothing
        End If
        'borra las cookies
        Response.Cookies.Clear()
        ' Invalidar las cookies
        Session.Clear()
        Session.Abandon()
        'cierra la sesión
        FormsAuthentication.SignOut()
        'redirige a la página de login desde el html con un javascript

    End Sub

    Public Shared Function GetApplicationPath(ByVal request As HttpRequest) As String
        Dim path As String = String.Empty
        Try
            If request.ApplicationPath <> "/" Then
                path = request.ApplicationPath
            End If
        Catch e As Exception
            Throw e
        End Try
        Return path
    End Function

End Class