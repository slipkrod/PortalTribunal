Option Explicit On
Option Strict On

Imports System
Imports System.Reflection

Public Class Excepciones
    'clase para el manejo de excepciones y mensajes personalizados de las otras clases
    'de este componente
#Region " Constantes"
    Private Const mstrModName As String = "Excepciones"
#End Region
#Region " Propiedades y métodos públicos"
    Public Shared Function ConstruyeExcepcion(ByVal pstrModName As String, ByVal pstrProcName As String, ByVal pex As System.Exception, ByVal pstrIdMsg As String, ByVal ParamArray pParametros() As String) As System.Exception
        If pstrIdMsg <> String.Empty Then
            Return New Exception(pstrModName & "." & pstrProcName & ": " & CargaDescripcionExcepcionInterna(pstrIdMsg, pParametros) & vbCrLf & DevuelveStackExcepciones(pex))            
        Else
            Return New Exception(pstrModName & "." & pstrProcName & ": " & DevuelveStackExcepciones(pex))
        End If
    End Function
    Friend Shared Function DevuelveStackExcepciones(ByVal exExcepcion As System.Exception) As String
        If Not exExcepcion Is Nothing Then
            Return exExcepcion.Message & vbCrLf & DevuelveStackExcepciones(exExcepcion.InnerException)
        Else
            Return String.Empty
        End If
    End Function
    Friend Shared Function CargaDescripcionExcepcionInterna(ByVal pstrID As String, ByVal ParamArray pParametros() As String) As String
        Dim rmRecursos As System.Resources.ResourceManager
        Dim strDesc As String

        rmRecursos = New System.Resources.ResourceManager(gstrResFileRef, [Assembly].GetExecutingAssembly())
        strDesc = rmRecursos.GetString(pstrID)
        If pParametros.Length > 0 Then
            strDesc = String.Format(strDesc, pParametros)
        End If
        strDesc = "(" & pstrID & "). " & strDesc
        Return strDesc
    End Function
    Friend Shared Function CargaRecursoString(ByVal pstrID As String) As String
        Dim rmRecursos As System.Resources.ResourceManager
        Dim strDesc As String

        rmRecursos = New System.Resources.ResourceManager(gstrResFileRef, [Assembly].GetExecutingAssembly())
        strDesc = rmRecursos.GetString(pstrID)
        Return strDesc
    End Function
#End Region
End Class


