Imports Portalv9.SvrUsr
'Imports DigiPro.IDIntranet.ControlPanel.Configuracion.ItemMenu

Partial Public Class Wfrm_Req
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle.Text = "Catálogo de Requerimientos"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            GetDataSource()
        End If
    End Sub

#Region "Metodos Privados"

    Private Sub GetDataSource()
        Try
            'Introducir aquí el código de usuario para inicializar la página
            Dim strResult As String
            Dim rRespuesta As Respuesta = Nothing
            Dim nReqID As Integer = 0

            Try
                strResult = ObtieneResultado()
                If strResult <> String.Empty Then
                    MsgBox1.ShowMessage(strResult)
                End If
                If Not IsPostBack Then
                    Dim strRes As String = Session("DebeCambiarPwd")
                    If strRes <> String.Empty Then
                        If CType(strRes, Boolean) = True Then
                            server.transfer("Wfrm_CambiaPwd.aspx?index=0")
                            Exit Try
                        End If
                    End If
                    nReqID = CargaRequerimientos(tTicket, rRespuesta)
                    If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                        MsgBox1.ShowMessage(rRespuesta.RespuestaToString)
                    End If
                End If
            Catch ex As Exception
                MsgBox1.ShowMessage(ex.Message)
            Finally
                tTicket = Nothing
            End Try
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Function CargaRequerimientos(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As Integer
        Dim sv As Core = New Core
        Dim ds As DataSet = sv.ColRequerimientosModulo(ptTicket, 0, "", prRespuesta)
        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            grdPSesion.DataSource = ds
            grdPSesion.DataBind()
            ds.Dispose()
        End If
        ds = Nothing
        sv = Nothing
    End Function

    Private Sub Agregar_newrow()
        'Dim strResult As String
        Dim rRespuesta As Respuesta = Nothing
        Dim sv As Core = New Core
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim ds As DataSet = sv.ColRequerimientosModulo(tTicket, 0, "", rRespuesta)
        If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            Dim dv As DataView = ds.Tables(0).DefaultView
            dv.AddNew()
            If grdPSesion.Items.Count = grdPSesion.PageSize Then
                grdPSesion.CurrentPageIndex = grdPSesion.CurrentPageIndex + 1
                grdPSesion.EditItemIndex = 0
            Else
                grdPSesion.EditItemIndex = grdPSesion.Items.Count()
            End If

            With grdPSesion
                .DataSource = dv
                .DataBind()
            End With
            ds.Dispose()
            dv = Nothing
        End If
        sv = Nothing
    End Sub

    Private Sub BindUser()
        Dim rRespuesta As Respuesta = Nothing
        Dim nReqID As Integer = 0
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            nReqID = CargaRequerimientos(tTicket, rRespuesta)
            If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                MsgBox1.ShowMessage(rRespuesta.RespuestaToString)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            tTicket = Nothing
        End Try
    End Sub

    Private Sub DeleteItem(ByVal strID As Integer)
        Try
            Dim str As String
            str = EjecutaAccion(strID, OperacionesABC.operBaja)
            If grdPSesion.Items.Count = 1 AndAlso grdPSesion.CurrentPageIndex > 0 Then
                grdPSesion.CurrentPageIndex = grdPSesion.CurrentPageIndex - 1
            End If
            BindUser()
        Catch exp As Exception
            Response.Write(exp.Message)
        End Try
    End Sub

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String
        Dim aRequerimiento As Portalv9.SvrUsr.Requerimiento
        Dim rRespuesta As New Portalv9.SvrUsr.Respuesta
        Dim sv As Portalv9.SvrUsr.Core
        Dim strMsg As String = String.Empty

        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            aRequerimiento = New Portalv9.SvrUsr.Requerimiento
            With aRequerimiento
                If op <> 0 Then 'No es Alta
                    .RequerimientoID = grdPSesion.Items(Index).Cells(0).Text
                End If
                If op <> 1 Then  'No poner valores para eliminar
                    .Nombre = CType(grdPSesion.Items(Index).FindControl("TextNombre"), TextBox).Text
                    .Descripcion = CType(grdPSesion.Items(Index).FindControl("TextDescripcion"), TextBox).Text
                End If
            End With

            sv = New Portalv9.SvrUsr.Core
            sv.ABC_Requerimiento(tTicket, aRequerimiento, op, rRespuesta)
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                strMsg = "Se ejecutó correctamente la operacion de cambio solicitada. "
            Else
                strMsg = "Ocurrió un error al intentar la operación solicitada: " & rRespuesta.RespuestaToString
            End If
        Catch ex As Exception
            strMsg = ex.Message
        Finally
            sv = Nothing
            aRequerimiento = Nothing
            rRespuesta = Nothing
        End Try
        EjecutaAccion = strMsg
    End Function

    Private Sub VerIndiceFueradeRango()
        If grdPSesion.CurrentPageIndex < 0 Or grdPSesion.CurrentPageIndex >= grdPSesion.PageCount Then
            grdPSesion.CurrentPageIndex = 0
        End If
    End Sub

    Private Sub btnAddPSesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPSesion.Click
        Try
            Agregar_newrow()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub MsgBox1_YesChoosed(ByVal sender As Object, ByVal Key As String) Handles MsgBox1.YesChoosed
        'Key contiene la clave introducida cuando se llama al método ShowConfirmation.
        Select Case Key
            Case "Delete"
                DeleteItem(hiddenPSesion.Value)
                MsgBox1.ShowMessage("Registro eliminado.")
        End Select
    End Sub

#End Region

#Region "Eventos del DataGrid"

    Private Sub grdPSesion_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPSesion.ItemCommand
        VerIndiceFueradeRango()
        hiddenPSesion.Value = Trim(e.Item.Cells(0).Text)
    End Sub

    Private Sub grdPSesion_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPSesion.EditCommand
        VerIndiceFueradeRango()
        If e.Item.ItemType = ListItemType.Pager Or _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        Try
            grdPSesion.SelectedIndex = -1
            grdPSesion.EditItemIndex = e.Item.ItemIndex
            BindUser()
            'Llenamos los campos a editar con los valores actuales en el grid
            CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text = CType(e.Item.FindControl("lblNombre"), Label).Text
            CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("TextDescripcion"), TextBox).Text = CType(e.Item.FindControl("lblDescripcion"), Label).Text

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub grdPSesion_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPSesion.CancelCommand
        'Obentemos el datatow el cuál se estaba editando
        VerIndiceFueradeRango()
        grdPSesion.EditItemIndex = -1
        grdPSesion.SelectedIndex = -1
        BindUser()
    End Sub

    Private Sub grdPSesion_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPSesion.DeleteCommand
        VerIndiceFueradeRango()
        hiddenPSesion.Value = e.Item.ItemIndex
        MsgBox1.ShowConfirmation("Está seguro de eliminar el usuario " + CType(e.Item.FindControl("lblNombre"), Label).Text, "Delete", True, False)
    End Sub

    Private Sub grdUser_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdPSesion.PageIndexChanged
        Try
            grdPSesion.CurrentPageIndex = e.NewPageIndex
            grdPSesion.EditItemIndex = -1
            grdPSesion.SelectedIndex = -1
            BindUser()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub grdPSesion_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPSesion.UpdateCommand

        Dim str As String

        'Validar que se haya capturado al menos los siguientes datos
        If CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text = "" Then
            MsgBox1.ShowMessage("El campo Nombre, es requerido.")
            Exit Sub
        End If
        If CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("TextDescripcion"), TextBox).Text = "" Then
            MsgBox1.ShowMessage("El campo Descripción, es requerido.")
            Exit Sub
        End If

        If grdPSesion.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" Then 'actualizar cambios
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else 'insertar
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
        End If

        MsgBox1.ShowMessage(str)

        grdPSesion.EditItemIndex = -1

        BindUser()

    End Sub

#End Region

#Region "Comunes"

    Private Sub LogOff()
        Server.Transfer("Logoff.aspx")
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

End Class