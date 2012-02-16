Imports Portalv9.SvrUsr
Partial Public Class Wfrm_Admin_CambiaPwd
    Inherits System.Web.UI.Page

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Asignar click al texto de buscar
        Me.txtUsrID.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Me.btnActualizar.UniqueID + "').click();return false;}} else {return true}; ")

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        Dim tTicket As IDTicket
        Dim strResult As String = ""
        Dim sv As New Core
        Dim strScript As String = ""
        Dim strScriptName As String = ""
        Dim rRespuesta As Respuesta

        Try
            lblTitle.Text = "Cambia Contraseña"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            If strResult <> String.Empty Then
                Me.dlgBoxExcepciones.ShowMessage(strResult)
            End If
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Me.txtUsrID.Text = String.Empty Then
                IniciaPagina(tTicket.UsrID)
            End If
            rRespuesta = sv.ScriptValidaPwd(tTicket, Me.txtUsrID.Text, strScript, strScriptName)
            If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                Me.dlgBoxExcepciones.ShowMessage(rRespuesta.RespuestaToString)
            Else
                'Page.RegisterClientScriptBlock(strScriptName, strScript)
                ClientScript.RegisterClientScriptBlock(ClientScript.GetType(), strScriptName, strScript)
            End If
        Catch ex As Exception
            LogOff()
        Finally
            tTicket = Nothing
        End Try
    End Sub

    Private Sub IniciaPagina(ByVal ParamArray paParams() As String)
        Me.txtUsrID.Text = paParams(0)
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Dim svrusr As Core
        Dim strUsrID As String
        Dim strPwdActual As String
        Dim strNvoPwd As String
        Dim tTicket As IDTicket
        Dim rResult As Respuesta
        Dim strMsg As String = String.Empty

        Try
            Dim sDescripcion As String
            sDescripcion = DescripcionLog()
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            strUsrID = Me.txtUsrID.Text
            strPwdActual = Request.Form("txtPwdMD5")
            strNvoPwd = Request.Form("txtPwdNuevoMD5")
            svrusr = New Core
            rResult = svrusr.CambiarPassword(tTicket, strUsrID, strPwdActual.ToUpper, strNvoPwd.ToUpper, sDescripcion)
            If rResult.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                strMsg = "La contraseña se ha cambiado con éxito para el usuario " & Me.txtUsrID.Text
                Session.Remove("DebeCambiarPwd")
                Session("GSTR_SESSION_RESULT") = String.Empty
                Response.Redirect("Wfrm_Contenido.aspx", False)
            Else
                strMsg = "Ocurrió un error al cambiar la contraseña de " & Me.txtUsrID.Text & ". " & rResult.RespuestaToString
            End If
        Catch ex As Exception
            strMsg = ex.ToString
            Throw
        Finally
            Me.dlgBoxExcepciones.ShowMessage(strMsg)
            svrusr = Nothing
            tTicket = Nothing
        End Try
    End Sub

#Region "  Comunes"

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
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



#End Region

    Private Function DescripcionLog() As String

        DescripcionLog = String.Empty

        Return "El usuario ha cambiado su contraseña"


    End Function

End Class