Imports System.Web.Security
Imports Portalv9.SvrUsr

Partial Public Class Logoff
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not IsPostBack Then
            Salir()
        End If
    End Sub

    Private Sub Salir()
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

End Class