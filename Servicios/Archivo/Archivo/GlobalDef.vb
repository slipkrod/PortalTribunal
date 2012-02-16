Option Explicit On
Option Strict On

Imports System
Imports System.Reflection
Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports System.Configuration
Imports System.Diagnostics



Public Module GlobalDef
    'nombre del archivo de recursos
    Public Const gstrResFileRef As String = "Trife.Recursos"
    Public Const GSTR_RESPUESTA_OK_DEFAULT As String = "0"

    Public Enum OperacionesABC
        operAlta = 0
        operBaja = 1
        operCambio = 2
    End Enum

#Region "    Cttes. de categorías para los tipos de respuesta de los servicios: 4000...4999"
    Public Const GSTR_CAT_RES_SERVICIO_INFORMACION As String = "4000"  'Información
    Public Const GSTR_CAT_RES_SERVICIO_ADVERTENCIA As String = "4001"  'Warning
    Public Const GSTR_CAT_RES_SERVICIO_ERROR As String = "4002"  'Error
#End Region
#Region "    Cttes. generales de error: 100...1999"
    Public Const GSTR_ERR_OBTENER_COL_ESTADOS_USUARIO As String = "101"
    Public Const GSTR_ERR_ABC_INSTANCIA As String = "102"
    Public Const GSTR_ERR_OBTENER_ULTIMA_REMESA As String = "103"
    Public Const GSTR_ERR_BUSCAR_INSTANCIA As String = "104"
    Public Const GSTR_ERR_ACTUALIZA_VALIJA As String = "105"
    Public Const GSTR_ERR_TRANSITA_INSTANCIA As String = "106"
    Public Const GSTR_ERR_BUSCA_REMESAS_VALIJA As String = "107"
    Public Const GSTR_ERR_BUSCA_EVENTOS_ESTADO As String = "108"
    Public Const GSTR_ERR_ASIGNA_VALIJA As String = "109"
    Public Const GSTR_ERR_OBTENER_REMESA As String = "110"
    Public Const GSTR_ERR_BUSCAR_INSTANCIAxVALIJA As String = "111"
    Public Const GSTR_ERR_ASIGNA_COMENTARIO_VALIJA As String = "112"
    Public Const GSTR_ERR_REPORTE As String = "113"
    Public Const GSTR_ERR_ASIGNA_COMENTARIO_RECLAMO As String = "114"
    Public Const GSTR_ERR_OBTENER_CAJA As String = "115"
    Public Const GSTR_ERR_ASIGNA_COMENTARIO_CAJA As String = "116"
    Public Const GSTR_ERR_BUSCAR_ELEMENTO As String = "1117"
    Public Const GSTR_ERR_BUSCAR_TIPOEXPEDIENTE As String = "1118"
    Public Const GSTR_ERR_BUSCAR_DOCUMENTOS As String = "1119"
    Public Const GSTR_ERR_BUSCAR_FRECUENCIA As String = "1120"
    Public Const GSTR_ERR_BUSCAR_TipoExpedientexid As String = "1121"
    Public Const GSTR_ERR_BuscaTipo_Expediente_indices As String = "1122"
    Public Const GSTR_ERR_BUSCAR_Entidad_Expediente As String = "1123"
    Public Const GSTR_ERR_ABC_Entidad_Expediente As String = "1124"


#End Region

    Public Function ObtenerCS() As String
        Return System.Configuration.ConfigurationManager.AppSettings("UsuarioCS")
    End Function
    Public Function ObtenerBDH() As String
        Return System.Configuration.ConfigurationManager.AppSettings("BDH")
    End Function
    Public Function ObtenerCS(ByVal strCC As String) As String
        Return System.Configuration.ConfigurationManager.AppSettings(strCC)
    End Function
    Public Function ObtenerTipoBD() As Persistencia.eTipoBD
        Dim strTipoBD As String = System.Configuration.ConfigurationManager.AppSettings("TipoBD")
        Dim intTipoBD As Integer
        Dim enTipoBD As Persistencia.eTipoBD
        If IsNumeric(strTipoBD) Then
            intTipoBD = CInt(strTipoBD)
            Select Case intTipoBD
                Case Persistencia.eTipoBD.Oracle
                    enTipoBD = Persistencia.eTipoBD.Oracle
                Case Persistencia.eTipoBD.SQLServer
                    enTipoBD = Persistencia.eTipoBD.SQLServer
                Case Else
                    enTipoBD = Persistencia.eTipoBD.Invalido
            End Select
        Else
            enTipoBD = Persistencia.eTipoBD.Invalido
        End If
        Return enTipoBD
    End Function

    Public Sub RegistraEventoLog(ByVal pstrFuente As String, ByVal peSeveridad As TraceEventType, ByVal pstrMensaje As String)
        Dim objLogEntry As New LogEntry
        Try
            objLogEntry.Title = pstrFuente
            objLogEntry.Priority = 1
            objLogEntry.Severity = peSeveridad
            objLogEntry.Categories.Add("General")
            objLogEntry.Message = pstrMensaje
            Logger.Write(objLogEntry)
        Catch ex As Exception
            Throw New Exception(ex.ToString)
        Finally
            objLogEntry = Nothing
        End Try
    End Sub
End Module


