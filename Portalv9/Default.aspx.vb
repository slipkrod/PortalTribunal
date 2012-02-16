

imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Web.Security
Imports Portalv9.GlobalDef
Imports Portalv9.SvrUsr
Imports System.Text

Partial Public Class _Default

    Inherits System.Web.UI.Page

    Protected WithEvents ibtnentrar As System.Web.UI.WebControls.ImageButton

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtUsrID As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Regularexpressionvalidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents btnLogin As System.Web.UI.WebControls.Button
    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()

    End Sub

#End Region

#Region "Eventos de controles"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tTicket As IDTicket
        Dim svrUsuario As Core
        Dim rRespuesta As Respuesta = Nothing
        Try
            'Introducir aquí el código de usuario para inicializar la página
            GetFocusLogin()
            If Not IsPostBack Then
                Dim strRes As String = ObtieneResultado()
                If strRes <> String.Empty Then
                    lblError.Text = strRes
                End If
            End If

        Catch ex As Exception
            lblError.Text = ex.ToString
            tTicket = Nothing
        Finally
            svrUsuario = Nothing
            tTicket = Nothing
        End Try
    End Sub
    Private Sub GetFocusLogin()
        'Dim strBuilder As StringBuilder = New StringBuilder
        'strBuilder.Append("<script language='javascript'>")
        'strBuilder.Append("document.getElementById('txtlogin').focus()")
        'strBuilder.Append("</script>")
        'Page.RegisterStartupScript("Focus", strBuilder.ToString)
        txtlogin.Focus()
    End Sub

#End Region

#Region "  Comunes"

    Private Sub GuardarTicket(ByRef pTicket As IDTicket)
        If Session.Item("GSTR_TICKET") Is Nothing Then
            Session.Add("GSTR_TICKET", pTicket)
        Else
            Session.Item("GSTR_TICKET") = pTicket
        End If
        Session.Timeout = pTicket.TiempoVida 'TiempoRestante
    End Sub


    Private Function ObtieneResultado() As String
        Dim strResultado As String
        If Session.Item("GSTR_SESSION_RESULT") Is Nothing Then
            strResultado = String.Empty
        Else
            strResultado = Session.Item("GSTR_SESSION_RESULT")
            Session.Remove("GSTR_SESSION_RESULT")
        End If
        Return strResultado
    End Function

    Private Sub GuardaResultado(ByVal pstrResultado As String)
        If Session.Item("GSTR_SESSION_RESULT") Is Nothing Then
            Session.Add("GSTR_SESSION_RESULT", pstrResultado)
        Else
            Session.Item("GSTR_SESSION_RESULT") = pstrResultado
        End If
    End Sub

    Private Sub GuardarSesion(ByRef psesion As String)
        If Session.Item("GSTR_SESION") Is Nothing Then
            Session.Add("GSTR_SESION", psesion)
        Else
            Session.Item("GSTR_SESION") = psesion
        End If
    End Sub

#End Region
    Protected Sub ibtn_entrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtn_entrar.Click
        'System.Threading.Thread.Sleep(1000)
        Dim tTicket As IDTicket
        Dim svrUsuario As Core
        Dim rRespuesta As Respuesta = Nothing
        'Dim strSessionId As String
        Try
            Dim ipv4 As String
            ipv4 = conexion.GetIP4Address
            svrUsuario = New Core
            '
            tTicket = svrUsuario.Login(txtlogin.Text, Request.Form("txtPwdMD5"), CType(Application("GN_VERSION_APLICACION_ID"), Integer), CType(Application("GN_PROYECTO_ID"), Integer), ipv4, rRespuesta)
            Select Case rRespuesta.RespuestaID
                Case GSTR_RES_LOGIN_rlLoginOk
                    GuardarTicket(tTicket)
                    CargaConexiones()
                    'FormsAuthentication.RedirectFromLoginPage(Me.txtlogin.Text, False)
                    Response.Redirect("Wfrm_Contenido.aspx")
                    'Server.Transfer("Wfrm_Contenido.aspx")
                Case GSTR_RES_LOGIN_rlUsrDebeCambiarPwd '(Application("GSTR_RESPUESTA_DEBE_CAMBIAR_PWD") Or Application("GSTR_RESPUESTA_DEBE_CAMBIAR_PWD1"))  '2050,2051
                    Session.Add("DebeCambiarPwd", "true")
                    GuardarTicket(tTicket)
                    CargaConexiones()
                    GuardaResultado(rRespuesta.RespuestaToString)
                    'FormsAuthentication.RedirectFromLoginPage(Me.txtlogin.Text, False)
                    lblError.Text = rRespuesta.RespuestaToString
                    Server.Transfer("Wfrm_Contenido.aspx")
                Case Else
                    lblError.Visible = True
                    lblError.Text = rRespuesta.RespuestaToString
            End Select
        Catch ex As Exception
            lblError.Text = ex.ToString
            tTicket = Nothing
        Finally
            svrUsuario = Nothing
            tTicket = Nothing
        End Try
    End Sub

    Private Sub CargaConexiones()
        Try
            Dim tTicket As IDTicket
            Dim rRespuesta As Respuesta = Nothing
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            Dim sv As Core
            sv = New Core
            sv.CargaConexiones(tTicket, rRespuesta, "")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class