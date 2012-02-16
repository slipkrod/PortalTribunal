Imports Portalv9.SvrUsr

Partial Public Class Wfrm_PoliticasPassword

    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Private dvPPwd As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load

        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then

            lblTitle.Text = "Politicas de Contraseña"

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
            Dim nPoliticaPwdID As Integer = 0

            Try

                strResult = ObtieneResultado()
                If strResult <> String.Empty Then
                    MsgBox1.ShowMessage(strResult)
                End If

                If Not IsPostBack Then
                    tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                    If tTicket Is Nothing Then
                        LogOff()
                        Exit Try
                    End If
                    Dim strRes As String = Session("DebeCambiarPwd")
                    If strRes <> String.Empty Then
                        If CType(strRes, Boolean) = True Then
                            Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                            Exit Try
                        End If
                    End If
                    nPoliticaPwdID = CargaPoliticasPwd(tTicket, rRespuesta)
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

    Private Function CargaPoliticasPwd(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As Integer

        Dim sv As Core = New Core
        Dim dsPoliticasPwd As DataSet = sv.ColPoliticasPwd(ptTicket, prRespuesta)

        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            grdPPwd.DataSource = dsPoliticasPwd
            grdPPwd.DataBind()
            dsPoliticasPwd.Dispose()
        End If

        dsPoliticasPwd = Nothing
        sv = Nothing

    End Function

    Private Sub Agregar_newrow()

        Dim rRespuesta As Respuesta = Nothing
        Dim sv As Core = New Core
        Dim fila As DataRow

        Try

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

            Dim dsPoliticasPwd As DataSet = sv.ColPoliticasPwd(tTicket, rRespuesta)

            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                Dim dvPPwd As DataView = dsPoliticasPwd.Tables(0).DefaultView
                dvPPwd.AddNew()
                'Poner valores al grid, en la fila que se adicionó poner
                'los campos boolean a false para evitar error de no convertir dbnull a boolean
                fila = dvPPwd.Item(dvPPwd.Count - 1).Row()
                fila("Mayusculas") = 0
                fila("Minusculas") = 0
                fila("Simbolos") = 0
                fila("Numeros") = 0
                If grdPPwd.Items.Count = grdPPwd.PageSize Then
                    grdPPwd.CurrentPageIndex = grdPPwd.CurrentPageIndex + 1
                    grdPPwd.EditItemIndex = 0
                Else
                    grdPPwd.EditItemIndex = grdPPwd.Items.Count()
                End If
                With grdPPwd
                    .DataSource = dvPPwd
                    .DataBind()
                End With
                dsPoliticasPwd.Dispose()
            End If

        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
        dvPPwd = Nothing
        sv = Nothing
    End Sub

    Private Sub BindUser()
        Dim rRespuesta As Respuesta = Nothing
        Dim nPoliticaPwdID As Integer = 0
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            nPoliticaPwdID = CargaPoliticasPwd(tTicket, rRespuesta)
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

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String

        Dim aPoliticaPwd As Portalv9.SvrUsr.PoliticaPwd
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
                dsVal = sv.BuscaXNombreTabla(tTicket, rRespuesta, "C", CType(grdPPwd.Items(Index).FindControl("TextNombre"), TextBox).Text)
                If dsVal.Tables(0).Rows.Count > 0 Then
                    blnVal = True
                End If
                dsVal = Nothing
            End If

            If blnVal Then
                strMsg = "El nombre de la Política de Contraseña """ & CType(grdPPwd.Items(Index).FindControl("TextNombre"), TextBox).Text & """ ya existe"
            Else
                aPoliticaPwd = New Portalv9.SvrUsr.PoliticaPwd
                Dim sDescripcion As String
                sDescripcion = DescripcionLog(Index, op)
                With aPoliticaPwd
                    If op <> 0 Then 'No es Alta
                        .PoliticaPwdID = grdPPwd.Items(Index).Cells(0).Text
                    End If
                    If op <> 1 Then  'No poner valores para eliminar
                        .Nombre = CType(grdPPwd.Items(Index).FindControl("TextNombre"), TextBox).Text
                        .Descripcion = IIf(CType(grdPPwd.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim = "", " ", CType(grdPPwd.Items(Index).FindControl("TextDescripcion"), TextBox).Text)
                        .LongMin = IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextLongMin"), TextBox).Text()) = "", 3, CType(grdPPwd.Items(Index).FindControl("TextLongMin"), TextBox).Text())
                        .LongMax = IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextLongMax"), TextBox).Text()) = "", 20, CType(grdPPwd.Items(Index).FindControl("TextLongMax"), TextBox).Text())
                        .Mayusculas = CType(grdPPwd.Items(Index).FindControl("CheckEditMay"), CheckBox).Checked()
                        .Minusculas = CType(grdPPwd.Items(Index).FindControl("CheckEditMin"), CheckBox).Checked()
                        .IncluirSimbolos = CType(grdPPwd.Items(Index).FindControl("CheckEditSimb"), CheckBox).Checked()
                        .IncluirNumeros = CType(grdPPwd.Items(Index).FindControl("CheckEditNum"), CheckBox).Checked()
                        .Mascara = CType(grdPPwd.Items(Index).FindControl("TextMascara"), TextBox).Text()
                        .DuracionDias = IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextDuracionMin"), TextBox).Text()) = "", 20, CType(grdPPwd.Items(Index).FindControl("TextDuracionMin"), TextBox).Text())
                        .CantPwdHistorico = IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextCantHist"), TextBox).Text()) = "", 0, CType(grdPPwd.Items(Index).FindControl("TextCantHist"), TextBox).Text())
                        '[IEJ 20081021] Asignar el valor de CambioPwdResetMinutos y AvisoCaducidadPwdDias
                        .CambioPwdResetMinutos = IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextCamResMin"), TextBox).Text()) = "", 0, CType(grdPPwd.Items(Index).FindControl("TextCamResMin"), TextBox).Text())
                        .AvisoCaducidadPwdDias = IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextAviCadDias"), TextBox).Text()) = "", 0, CType(grdPPwd.Items(Index).FindControl("TextAviCadDias"), TextBox).Text())
                        '[IEJ 20081103] Cantidad de caracteres iguales y consecutivos
                        .CaracteresIguales = IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextCarIguales"), TextBox).Text()) = "", 0, CType(grdPPwd.Items(Index).FindControl("TextCarIguales"), TextBox).Text())
                        .CaracteresConsec = IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextCarConsecutivos"), TextBox).Text()) = "", 0, CType(grdPPwd.Items(Index).FindControl("TextCarConsecutivos"), TextBox).Text())
                    End If
                End With

                sv.ABC_PoliticaPwd(tTicket, aPoliticaPwd, op, rRespuesta, sDescripcion)
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
            aPoliticaPwd = Nothing
            rRespuesta = Nothing
        End Try

        EjecutaAccion = strMsg

    End Function

    Private Sub VerIndiceFueradeRango()
        If grdPPwd.CurrentPageIndex < 0 Or grdPPwd.CurrentPageIndex >= grdPPwd.PageCount Then
            Me.grdPPwd.CurrentPageIndex = 0
        End If
    End Sub

    Private Sub MsgBox1_YesChoosed(ByVal sender As Object, ByVal Key As String) Handles MsgBox1.YesChoosed
        'Key contiene la clave introducida cuando se llama al método ShowConfirmation.
        Select Case Key
            Case "Delete"
                DeleteItem(hiddenPPwd.Value)
                'MsgBox1.ShowMessage("Registro eliminado.")
        End Select
    End Sub

    ' This routine deletes an item from the database.
    Private Sub DeleteItem(ByVal strID As Integer)
        Try
            Dim str As String
            str = EjecutaAccion(strID, OperacionesABC.operBaja)
            If grdPPwd.Items.Count = 1 AndAlso grdPPwd.CurrentPageIndex > 0 Then
                grdPPwd.CurrentPageIndex = grdPPwd.CurrentPageIndex - 1
            End If
            BindUser()
            MsgBox1.ShowMessage(str)
        Catch exp As Exception
            MsgBox1.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Sub btnAddPPwd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPPwd.Click
        Try
            Agregar_newrow()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

#End Region

#Region "Eventos del Datagrid"

    Private Sub grdPPwd_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPPwd.ItemCommand
        VerIndiceFueradeRango()
        hiddenPPwd.Value = Trim(e.Item.Cells(0).Text)
    End Sub

    Private Sub grdPPwd_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPPwd.EditCommand
        VerIndiceFueradeRango()
        If e.Item.ItemType = ListItemType.Pager Or _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        Try
            grdPPwd.SelectedIndex = -1
            grdPPwd.EditItemIndex = e.Item.ItemIndex
            BindUser()
            'Llenamos los campos a editar con los valores actuales en el grid
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text = CType(e.Item.FindControl("lblNombre"), Label).Text
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextDescripcion"), TextBox).Text = CType(e.Item.FindControl("lblDescripcion"), Label).Text
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextLongMin"), TextBox).Text = CType(e.Item.FindControl("lblLongMin"), Label).Text
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextLongMax"), TextBox).Text = CType(e.Item.FindControl("lblLongMax"), Label).Text
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("CheckEditMay"), CheckBox).Checked = CType(e.Item.FindControl("CheckMay"), CheckBox).Checked
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("CheckEditMin"), CheckBox).Checked = CType(e.Item.FindControl("CheckMin"), CheckBox).Checked
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("CheckEditSimb"), CheckBox).Checked = CType(e.Item.FindControl("CheckSimb"), CheckBox).Checked
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("CheckEditNum"), CheckBox).Checked = CType(e.Item.FindControl("CheckNum"), CheckBox).Checked
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextMascara"), TextBox).Text = CType(e.Item.FindControl("lblMascara"), Label).Text
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextDuracionMin"), TextBox).Text = CType(e.Item.FindControl("lblduracionMin"), Label).Text
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextCantHist"), TextBox).Text = CType(e.Item.FindControl("lblCantHist"), Label).Text
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextCamResMin"), TextBox).Text = CType(e.Item.FindControl("lblCamResMin"), Label).Text
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextAviCadDias"), TextBox).Text = CType(e.Item.FindControl("lblAviCadDias"), Label).Text
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextCarIguales"), TextBox).Text = CType(e.Item.FindControl("lblCarIguales"), Label).Text
            CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextCarConsecutivos"), TextBox).Text = CType(e.Item.FindControl("lblCarConsecutivos"), Label).Text
            'Crea lista de datos para posteriormente describir los cambios realizados
            Me.HiddenField1.Value = CType(e.Item.FindControl("lblNombre"), Label).Text
            Me.HiddenField2.Value = CType(e.Item.FindControl("lblDescripcion"), Label).Text
            Me.HiddenField3.Value = CType(e.Item.FindControl("lblLongMin"), Label).Text
            Me.HiddenField4.Value = CType(e.Item.FindControl("lblLongMax"), Label).Text
            Me.HiddenField5.Value = CType(e.Item.FindControl("CheckMay"), CheckBox).Checked
            Me.HiddenField6.Value = CType(e.Item.FindControl("CheckMin"), CheckBox).Checked
            Me.HiddenField7.Value = CType(e.Item.FindControl("CheckSimb"), CheckBox).Checked
            Me.HiddenField8.Value = CType(e.Item.FindControl("CheckNum"), CheckBox).Checked
            Me.HiddenField9.Value = CType(e.Item.FindControl("lblMascara"), Label).Text
            Me.HiddenField10.Value = CType(e.Item.FindControl("lblduracionMin"), Label).Text
            Me.HiddenField11.Value = CType(e.Item.FindControl("lblCantHist"), Label).Text
            Me.HiddenField12.Value = CType(e.Item.FindControl("lblCamResMin"), Label).Text
            Me.HiddenField13.Value = CType(e.Item.FindControl("lblAviCadDias"), Label).Text
            Me.HiddenField14.Value = CType(e.Item.FindControl("lblCarIguales"), Label).Text
            Me.HiddenField15.Value = CType(e.Item.FindControl("lblCarConsecutivos"), Label).Text
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub grdPPwd_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPPwd.UpdateCommand

        Dim str As String

        'Validar que se haya capturado al menos los siguientes datos
        If CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text = "" Then
            MsgBox1.ShowMessage("El campo Nombre, es requerido.")
            Exit Sub
        End If

        If grdPPwd.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" Then 'actualizar cambios
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else 'insertar 
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
        End If

        MsgBox1.ShowMessage(str)

        grdPPwd.EditItemIndex = -1
        BindUser()

    End Sub

    Private Sub grdPPwd_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPPwd.CancelCommand
        VerIndiceFueradeRango()
        grdPPwd.EditItemIndex = -1
        grdPPwd.SelectedIndex = -1
        BindUser()
    End Sub

    Private Sub grdPPwd_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPPwd.DeleteCommand
        VerIndiceFueradeRango()
        hiddenPPwd.Value = e.Item.ItemIndex
        If grdPPwd.EditItemIndex = -1 Then
            MsgBox1.ShowConfirmation("Está seguro de eliminar la Política de contraseña " + CType(e.Item.FindControl("lblNombre"), Label).Text, "Delete", True, False)
        Else
            MsgBox1.ShowConfirmation("Está seguro de eliminar la Política de contraseña " + CType(grdPPwd.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text, "Delete", True, False)
        End If

    End Sub

    Private Sub grdPPwd_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdPPwd.PageIndexChanged
        Try
            grdPPwd.CurrentPageIndex = e.NewPageIndex
            grdPPwd.EditItemIndex = -1
            grdPPwd.SelectedIndex = -1
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

    Private Function DescripcionLog(ByVal Index As Long, ByVal op As String) As String

        DescripcionLog = String.Empty

        Select Case op
            Case OperacionesABC.operAlta
                DescripcionLog = "Creación de la Política de Contraseña: " & CType(grdPPwd.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim
            Case OperacionesABC.operCambio
                DescripcionLog = "Modificación de la Política de Contraseña: " & CType(grdPPwd.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim & " "
                If Me.HiddenField1.Value.Trim <> CType(grdPPwd.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En el Nombre. "
                End If
                If Me.HiddenField2.Value.Trim <> CType(grdPPwd.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En la Desc. "
                End If
                If Me.HiddenField3.Value.Trim <> IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextLongMin"), TextBox).Text()) = "", 3, CType(grdPPwd.Items(Index).FindControl("TextLongMin"), TextBox).Text()) Then
                    DescripcionLog = DescripcionLog & "En la LongMin. "
                End If
                If Me.HiddenField4.Value.Trim <> IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextLongMax"), TextBox).Text()) = "", 20, CType(grdPPwd.Items(Index).FindControl("TextLongMax"), TextBox).Text()) Then
                    DescripcionLog = DescripcionLog & "En la LongMax. "
                End If
                If Me.HiddenField5.Value.Trim <> CType(grdPPwd.Items(Index).FindControl("CheckEditMay"), CheckBox).Checked() Then
                    DescripcionLog = DescripcionLog & "En Check Mayús. "
                End If
                If Me.HiddenField6.Value.Trim <> CType(grdPPwd.Items(Index).FindControl("CheckEditMin"), CheckBox).Checked() Then
                    DescripcionLog = DescripcionLog & "En Check Minús. "
                End If
                If Me.HiddenField7.Value.Trim <> CType(grdPPwd.Items(Index).FindControl("CheckEditSimb"), CheckBox).Checked() Then
                    DescripcionLog = DescripcionLog & "En Check Simbol. "
                End If
                If Me.HiddenField8.Value.Trim <> CType(grdPPwd.Items(Index).FindControl("CheckEditNum"), CheckBox).Checked() Then
                    DescripcionLog = DescripcionLog & "En Check Num. "
                End If
                If Me.HiddenField9.Value.Trim <> CType(grdPPwd.Items(Index).FindControl("TextMascara"), TextBox).Text().Trim Then
                    DescripcionLog = DescripcionLog & "En Máscara. "
                End If
                If Me.HiddenField10.Value.Trim <> IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextDuracionMin"), TextBox).Text()) = "", 20, CType(grdPPwd.Items(Index).FindControl("TextDuracionMin"), TextBox).Text()) Then
                    DescripcionLog = DescripcionLog & "En DurDías. "
                End If
                If Me.HiddenField11.Value.Trim <> IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextCantHist"), TextBox).Text()) = "", 0, CType(grdPPwd.Items(Index).FindControl("TextCantHist"), TextBox).Text()) Then
                    DescripcionLog = DescripcionLog & "En CantHist. "
                End If
                If Me.HiddenField12.Value.Trim <> IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextCamResMin"), TextBox).Text()) = "", 0, CType(grdPPwd.Items(Index).FindControl("TextCamResMin"), TextBox).Text()) Then
                    DescripcionLog = DescripcionLog & "En ReseteoMin. "
                End If
                If Me.HiddenField13.Value.Trim <> IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextAviCadDias"), TextBox).Text()) = "", 0, CType(grdPPwd.Items(Index).FindControl("TextAviCadDias"), TextBox).Text()) Then
                    DescripcionLog = DescripcionLog & "En AviCadDias. "
                End If
                If Me.HiddenField14.Value.Trim <> IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextCarIguales"), TextBox).Text()) = "", 0, CType(grdPPwd.Items(Index).FindControl("TextCarIguales"), TextBox).Text()) Then
                    DescripcionLog = DescripcionLog & "En CarIguales. "
                End If
                If Me.HiddenField15.Value.Trim <> IIf(Trim(CType(grdPPwd.Items(Index).FindControl("TextCarIguales"), TextBox).Text()) = "", 0, CType(grdPPwd.Items(Index).FindControl("TextCarConsecutivos"), TextBox).Text()) Then
                    DescripcionLog = DescripcionLog & "En CarConse. "
                End If
            Case OperacionesABC.operBaja
                If grdPPwd.EditItemIndex = -1 Then
                    DescripcionLog = "Eliminación de la Política de Contraseña: " & CType(grdPPwd.Items(Index).FindControl("lblNombre"), Label).Text
                Else
                    DescripcionLog = "Eliminación de la Política de Contraseña: " & CType(grdPPwd.Items(Index).FindControl("TextNombre"), TextBox).Text
                End If


        End Select
        

    End Function

#End Region

End Class