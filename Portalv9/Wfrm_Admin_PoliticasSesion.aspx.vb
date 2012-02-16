Imports Portalv9.SvrUsr

Partial Public Class Wfrm_PoliticasSesion
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Private dvPSesion As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aquí el código de usuario para inicializar la página

        If Not Page.IsPostBack Then
            lblTitle.Text = "Politicas de Sesión"
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
            Dim nPoliticaSesionID As Integer = 0

            Try
                strResult = ObtieneResultado()
                If strResult <> String.Empty Then
                    Me.MsgBox1.ShowMessage(strResult)
                End If
                If Not IsPostBack Then
                    Dim strRes As String = Session("DebeCambiarPwd")
                    If strRes <> String.Empty Then
                        If CType(strRes, Boolean) = True Then
                            Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                            Exit Try
                        End If
                    End If
                    nPoliticaSesionID = CargaPoliticasSesion(tTicket, rRespuesta)
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
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Function CargaPoliticasSesion(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As Integer
        Dim sv As Core = New Core
        Dim dsPoliticasSesion As DataSet = sv.ColPoliticasSesion(ptTicket, prRespuesta)
        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            grdPSesion.DataSource = dsPoliticasSesion
            grdPSesion.DataBind()
            dsPoliticasSesion.Dispose()
        End If
        dsPoliticasSesion = Nothing
        sv = Nothing
    End Function

    Private Sub Agregar_newrow()
        'Dim strResult As String
        Dim rRespuesta As Respuesta = Nothing
        Dim sv As Core = New Core
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim dsPoliticasSesion As DataSet = sv.ColPoliticasSesion(tTicket, rRespuesta)
        If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            Dim dvPSesion As DataView = dsPoliticasSesion.Tables(0).DefaultView
            dvPSesion.AddNew()
            If grdPSesion.Items.Count = grdPSesion.PageSize Then
                grdPSesion.CurrentPageIndex = grdPSesion.CurrentPageIndex + 1
                grdPSesion.EditItemIndex = 0
            Else
                grdPSesion.EditItemIndex = grdPSesion.Items.Count()
            End If

            With grdPSesion
                .DataSource = dvPSesion
                .DataBind()
            End With
            dsPoliticasSesion.Dispose()
        End If
        dvPSesion = Nothing
        sv = Nothing
    End Sub

    Private Sub BindUser()
        Dim rRespuesta As Respuesta = Nothing
        Dim nPoliticaSesionID As Integer = 0
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            nPoliticaSesionID = CargaPoliticasSesion(tTicket, rRespuesta)
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
            MsgBox1.ShowMessage(str)
        Catch exp As Exception
            MsgBox1.ShowMessage(exp.Message)
            'Response.Write(exp.Message)
        End Try
    End Sub

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String
        Dim aPoliticaSesion As Portalv9.SvrUsr.PoliticaSesion
        Dim rRespuesta As New Portalv9.SvrUsr.Respuesta
        Dim sv As Portalv9.SvrUsr.Core
        Dim strMsg As String = String.Empty

        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)


            sv = New Portalv9.SvrUsr.Core

            'Valida si que el nombre no este repetido
            Dim blnVal As Boolean = False
            If op = 0 Then
                Dim dsVal As New DataSet
                dsVal = sv.BuscaXNombreTabla(tTicket, rRespuesta, "S", CType(grdPSesion.Items(Index).FindControl("TextNombre"), TextBox).Text)
                If dsVal.Tables(0).Rows.Count > 0 Then
                    blnVal = True
                End If
                dsVal = Nothing
            End If

            If blnVal Then
                strMsg = "El nombre de la Politica de Sesión """ & CType(grdPSesion.Items(Index).FindControl("TextNombre"), TextBox).Text & """ ya existe"
            Else
                aPoliticaSesion = New Portalv9.SvrUsr.PoliticaSesion
                Dim sDescripcion As String
                sDescripcion = DescripcionLog(Index, op)
                With aPoliticaSesion
                    If op <> 0 Then 'No es Alta
                        .PoliticaSesionID = grdPSesion.Items(Index).Cells(0).Text
                    End If
                    If op <> 1 Then  'No poner valores para eliminar
                        .Nombre = CType(grdPSesion.Items(Index).FindControl("TextNombre"), TextBox).Text
                        .Descripcion = IIf(CType(grdPSesion.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim = "", " ", CType(grdPSesion.Items(Index).FindControl("TextDescripcion"), TextBox).Text)
                        .DuracionMinutos = IIf(Trim(CType(grdPSesion.Items(Index).FindControl("TextDuracion"), TextBox).Text) = "", 20, CType(grdPSesion.Items(Index).FindControl("TextDuracion"), TextBox).Text)
                        .IntentosFallidosConsecutivos = IIf(Trim(CType(grdPSesion.Items(Index).FindControl("TextFallidos"), TextBox).Text) = "", 5, CType(grdPSesion.Items(Index).FindControl("TextFallidos"), TextBox).Text)
                        .PermitirMultiSesion = CType(grdPSesion.Items(Index).FindControl("CheckEditMultisesion"), CheckBox).Checked()
                        '[IEJ 20081021] Asignar el valor de IntentosFallidosDia, PeriodoInhabCtaDias y PeriodoBorrarCtaDias
                        .IntentosFallidosDia = IIf(Trim(CType(grdPSesion.Items(Index).FindControl("TextfallidosDia"), TextBox).Text) = "", 5, CType(grdPSesion.Items(Index).FindControl("TextfallidosDia"), TextBox).Text)
                        .PeriodoInhabCtaDias = IIf(Trim(CType(grdPSesion.Items(Index).FindControl("TextInhabDias"), TextBox).Text) = "", 5, CType(grdPSesion.Items(Index).FindControl("TextInhabDias"), TextBox).Text)
                        .PeriodoBorrarCtaDias = IIf(Trim(CType(grdPSesion.Items(Index).FindControl("TextBorrarDias"), TextBox).Text) = "", 5, CType(grdPSesion.Items(Index).FindControl("TextBorrarDias"), TextBox).Text)
                    End If
                End With


                sv.ABC_PoliticaSesion(tTicket, aPoliticaSesion, op, rRespuesta, sDescripcion)
                If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    Select Case op
                        Case 0
                            strMsg = "Se ejecutó correctamente la operacion de agregar solicitada. "
                        Case 1
                            strMsg = "Se ejecutó correctamente la operacion de eliminar solicitada. "
                        Case 2
                            strMsg = "Se ejecutó correctamente la operacion de cambio solicitada. "
                    End Select
                Else
                    strMsg = "El registro no puede eliminarse ya que esta siendo utilizado en otra parte del sistema"
                End If
            End If

            
        Catch ex As Exception
            strMsg = "El registro no puede eliminarse ya que esta siendo utilizado en otra parte del sistema"
        Finally
            sv = Nothing
            aPoliticaSesion = Nothing
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
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub MsgBox1_YesChoosed(ByVal sender As Object, ByVal Key As String) Handles MsgBox1.YesChoosed
        'Key contiene la clave introducida cuando se llama al método ShowConfirmation.
        Select Case Key
            Case "Delete"
                DeleteItem(hiddenPSesion.Value)
                'MsgBox1.ShowMessage("Registro eliminado.")
        End Select
    End Sub

#End Region

#Region "Eventos de DataGrid"

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
            CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("TextDuracion"), TextBox).Text = CType(e.Item.FindControl("lblDuracion"), Label).Text
            CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("TextFallidos"), TextBox).Text = CType(e.Item.FindControl("lblFallidos"), Label).Text
            CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("CheckEditMultisesion"), CheckBox).Checked = CType(e.Item.FindControl("CheckMultisesion"), CheckBox).Checked
            CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("TextfallidosDia"), TextBox).Text = CType(e.Item.FindControl("lblFallidosDia"), Label).Text
            CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("TextInhabDias"), TextBox).Text = CType(e.Item.FindControl("lblInhabDias"), Label).Text
            CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("TextBorrarDias"), TextBox).Text = CType(e.Item.FindControl("lblBorrarDias"), Label).Text
            'Crea lista de datos para posteriormente describir los cambios realizados
            Me.HiddenField1.Value = CType(e.Item.FindControl("lblNombre"), Label).Text
            Me.HiddenField2.Value = CType(e.Item.FindControl("lblDescripcion"), Label).Text
            Me.HiddenField3.Value = CType(e.Item.FindControl("lblDuracion"), Label).Text
            Me.HiddenField4.Value = CType(e.Item.FindControl("lblFallidos"), Label).Text
            Me.HiddenField5.Value = CType(e.Item.FindControl("CheckMultisesion"), CheckBox).Checked
            Me.HiddenField6.Value = CType(e.Item.FindControl("lblFallidosDia"), Label).Text
            Me.HiddenField7.Value = CType(e.Item.FindControl("lblInhabDias"), Label).Text
            Me.HiddenField8.Value = CType(e.Item.FindControl("lblBorrarDias"), Label).Text

        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
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

        If grdPSesion.EditItemIndex = -1 Then
            Me.MsgBox1.ShowConfirmation("Está seguro de eliminar la Política de Sesión " + CType(e.Item.FindControl("lblNombre"), Label).Text, "Delete", True, False)
        Else
            Me.MsgBox1.ShowConfirmation("Está seguro de eliminar la Política de Sesión " + CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text, "Delete", True, False)
        End If
    End Sub

    Private Sub grdPSesion_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPSesion.UpdateCommand

        Dim str As String

        'Validar que se haya capturado al menos los siguientes datos
        If CType(grdPSesion.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text = "" Then
            MsgBox1.ShowMessage("El campo Nombre, es requerido.")
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

    Private Sub grdUser_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdPSesion.PageIndexChanged
        Try
            grdPSesion.CurrentPageIndex = e.NewPageIndex
            grdPSesion.EditItemIndex = -1
            grdPSesion.SelectedIndex = -1
            BindUser()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

#End Region

#Region "Comunes"

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

    Private Function DescripcionLog(ByVal Index As Long, ByVal op As String) As String
        DescripcionLog = String.Empty
        Select Case op
            Case OperacionesABC.operAlta
                DescripcionLog = "Creación de la Política de Sesión: " & CType(grdPSesion.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim
            Case OperacionesABC.operCambio
                DescripcionLog = "Modificación de la Política de Sesión: " & CType(grdPSesion.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim & " "
                If Me.HiddenField1.Value.Trim <> CType(grdPSesion.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Nombre. "
                End If
                If Me.HiddenField2.Value.Trim <> CType(grdPSesion.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Desc. "
                End If
                If Me.HiddenField3.Value.Trim <> CType(grdPSesion.Items(Index).FindControl("TextDuracion"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Duración. "
                End If
                If Me.HiddenField4.Value.Trim <> CType(grdPSesion.Items(Index).FindControl("TextFallidos"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Fallidos Totales. "
                End If
                If Me.HiddenField5.Value.Trim <> CType(grdPSesion.Items(Index).FindControl("CheckEditMultisesion"), CheckBox).Checked() Then
                    DescripcionLog = DescripcionLog & "En Acceso MultiSesión. "
                End If
                If Me.HiddenField6.Value.Trim <> CType(grdPSesion.Items(Index).FindControl("TextfallidosDia"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Fallidos Día. "
                End If
                If Me.HiddenField7.Value.Trim <> CType(grdPSesion.Items(Index).FindControl("TextInhabDias"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Inhab. Días. "
                End If
                If Me.HiddenField8.Value.Trim <> CType(grdPSesion.Items(Index).FindControl("TextBorrarDias"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Borrar Días. "
                End If
            Case OperacionesABC.operBaja
                If grdPSesion.EditItemIndex = -1 Then
                    DescripcionLog = "Eliminación de la Política de Sesión: " & CType(grdPSesion.Items(Index).FindControl("lblNombre"), Label).Text
                Else
                    DescripcionLog = "Eliminación de la Política de Sesión: " & CType(grdPSesion.Items(Index).FindControl("TextNombre"), TextBox).Text
                End If
        End Select
    End Function
End Class