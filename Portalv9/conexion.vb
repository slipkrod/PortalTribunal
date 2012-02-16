Imports System
Imports System.Net

Public Class conexion
    Public Shared ReadOnly Property Dominios() As String
        Get
            Dim appSetting As String
            appSetting = ConfigurationManager.AppSettings("Dominios")
            Return appSetting
        End Get
    End Property
    Public Shared ReadOnly Property Autentificacion() As String
        Get
            Dim appSetting As String
            appSetting = ConfigurationManager.AppSettings("Autentificacion")
            Return appSetting
        End Get
    End Property
    Public Shared Function GetIP4Address() As String
        Dim IP4Address As String = String.Empty

        For Each IPA As IPAddress In Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress)
            If IPA.AddressFamily.ToString() = "InterNetwork" Then
                IP4Address = IPA.ToString()
                Exit For
            End If
        Next
        If IP4Address <> String.Empty Then
            Return IP4Address
        End If

        For Each IPA As IPAddress In Dns.GetHostAddresses(Dns.GetHostName())
            If IPA.AddressFamily.ToString() = "InterNetwork" Then
                IP4Address = IPA.ToString()
                Exit For
            End If
        Next

        Return IP4Address
    End Function

End Class
