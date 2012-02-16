Imports Portalv9.SvrUsr

Friend Class GlobalDef
    Public Const GSTR_RESPUESTA_OK_DEFAULT As String = "0"
    Public Const gEVENTO_INHABILITACUENTA As String = "Deshabilitación de cuenta"
    Public Const gEVENTO_DENEGADOXCUENTACONTRASEÑAINCORRECTA As String = "Intento Fallido de acceso por password o usuario incorrecto"
    Public Const gEVENTO_DENEGADOXCUENTAINHABILITADA As String = "Intento Fallido de acceso por cuenta inhabilitada o bloqueada"
    Public Const gEVENTO_DENEGADOXCONTRASEÑAEXPIRADA As String = "Intento Fallido de acceso por contraseña expirada"
    Public Const gEVENTO_DENEGADOXCUENTAINEXISTENTE As String = "Intento Fallido de acceso a cuenta no existente"

#Region "    Cttes. de categorías para los tipos de respuesta de los servicios: 4000...4999"
    Public Const GSTR_CAT_RES_SERVICIO_INFORMACION As String = "4000"  'Información
    Public Const GSTR_CAT_RES_SERVICIO_ADVERTENCIA As String = "4001"  'Warning
    Public Const GSTR_CAT_RES_SERVICIO_ERROR As String = "4002"  'Error
#End Region

#Region "    Cttes. de resultado de login: 2000...2999"
    Public Const GSTR_RES_LOGIN_rlLoginOk As String = GSTR_RESPUESTA_OK_DEFAULT ' Login exitoso (el usuario existe, su contraseña es correcta y tiene permisos sobre la versión de aplicación y sobre el proyecto)
    Public Const GSTR_RES_LOGIN_rlUsrInexistente As String = "2001" ' No existe el usuario
    Public Const GSTR_RES_LOGIN_rlPwdInvalido As String = "2002" ' No coincide la contraseña
    Public Const GSTR_RES_LOGIN_rlIPInvalida As String = "2005" ' La IP suministrada no es válida
    Public Const GSTR_RES_LOGIN_rlUsrDebeCambiarPwd As String = "2050" 'El usuario debe cambiar el password
    Public Const GSTR_SCRIPT_VAL_VISOR_IMG = "%%URLIMAGEN%%"
    Public Const GSTR_RES_SCRIPT_VISOR = "ScriptVisor"
    Public Const gstrResFileRef As String = "DigiPro.IDIntranet.ScriptVisor"
#End Region

    Friend Shared Sub VerIndiceFueradeRango(ByRef Grid As System.Web.UI.WebControls.DataGrid)
        If Grid.CurrentPageIndex < 0 Or Grid.CurrentPageIndex >= Grid.PageCount Then
            Grid.CurrentPageIndex = 0
        End If
    End Sub
    Friend Shared Sub VerIndiceFueradeRangoGridView(ByRef Grid As System.Web.UI.WebControls.GridView)
        If Grid.PageIndex < 0 Or Grid.PageIndex >= Grid.PageCount Then
            Grid.PageIndex = 0
        End If
    End Sub
    Friend Enum eTipoField As Integer
        vDefault
        vChar
        vInt
        vDatemmddaa
        vList
        vDateinterval
        vHiddenint
        vDateddmmaa
        vDatemmddaaaa
        vDateddmmaaaa
        vDatemmaaaa
        vHiddenchar
        vDynamicList
        vdatemmaa
        vDateddmmaaaaSimple
        vCheck
        Invalido = -1
    End Enum

End Class
