Imports Portalv9.SvrUsr
Imports System.Text
Imports System.Security.Cryptography

Partial Public Class Wfrm_AppProy
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Private tTicket As IDTicket
    Private eGrupoAdminID As Integer
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle.Text = "Cadenas de conexión Proyectos/Aplicación"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            GetDataSource()
        End If
    End Sub

#Region "Métodos privados"

    Private Sub GetDataSource()
        Try
            Dim rRespuesta As Respuesta = Nothing
            Dim strResult As String
            Try
                strResult = ObtieneResultado()
                If strResult <> String.Empty Then
                    Me.dlgBoxExcepciones.ShowMessage(strResult)
                End If
                If Not IsPostBack Then
                    Dim strRes As String = Session("DebeCambiarPwd")
                    If strRes <> String.Empty Then
                        If CType(strRes, Boolean) = True Then
                            Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                            Exit Try
                        End If
                    End If
                    CargaAppProy(tTicket, rRespuesta)
                    If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                        dlgBoxExcepciones.ShowMessage(rRespuesta.RespuestaToString)
                    End If

                End If

            Catch ex As Exception
                dlgBoxExcepciones.ShowMessage(ex.Message)
            Finally
                tTicket = Nothing
            End Try

        Catch ex As Exception
            dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Function CargaAppProy(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As Integer
        Try
            Dim sv As Core = New Core
            Dim dv As DataView
            Dim dsAppProy As DataSet = sv.ColAppProy(ptTicket, prRespuesta)
            If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                dv = dsAppProy.Tables(0).DefaultView
                dv.Sort = htmlHiddenSortExpression.Value
                grdAppProy.DataSource = dv
                grdAppProy.DataBind()
                dsAppProy.Dispose()
            End If
            dsAppProy = Nothing
            sv = Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub BindUser()
        Dim rRespuesta As Respuesta = Nothing
        Dim nIdentidadUsrID As Integer = 0
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            CargaAppProy(tTicket, rRespuesta)
            If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                dlgBoxExcepciones.ShowMessage(rRespuesta.RespuestaToString)
                Exit Sub
            End If
        Catch ex As Exception
            dlgBoxExcepciones.ShowMessage(ex.Message)
        Finally
            tTicket = Nothing
        End Try
    End Sub

    Private Sub DeleteItem(ByVal iProy As Integer, ByVal iApli As Integer, ByVal strID As Integer)
        Try
            Dim str As String
            str = EjecutaAccion(iProy, iApli, OperacionesABC.operBaja)
            If grdAppProy.Items.Count = 1 AndAlso grdAppProy.CurrentPageIndex > 0 Then
                grdAppProy.CurrentPageIndex = grdAppProy.CurrentPageIndex - 1
            End If
            'CargaDS(CInt(grdAppProy.Items(strID).Cells(6).Text))
            GetDataSource()
            grdAppProy.EditItemIndex = -1
            BindUser()
        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try

    End Sub

    Private Function EjecutaAccion(ByVal iProyecto As Long, ByVal iAplicacion As Long, ByVal op As Integer) As String
        Dim aAppProy As AppProy
        Dim rRespuesta As New Respuesta
        Dim reRespuesta As New Respuesta
        Dim sv As New Core
        Dim strMsg As String = String.Empty
        Dim strPwd As String = ""
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            aAppProy = New AppProy
            With aAppProy
                If op = 1 Then
                    .AplicacionID = iAplicacion
                    .ProyectoID = iProyecto
                End If
                If op <> 1 Then  'No poner valores para eliminar
                    .AplicacionID = iAplicacion
                    .ProyectoID = iProyecto
                    .User = Trim(Me.txtUser.Text)
                    .DNS = Trim(Me.txtDSN.Text)
                    .Driver = Trim(Me.txtDriver.Text)
                    .Server = Trim(Me.txtServidor.Text)
                    .BDNombre = Trim(Me.txtBD.Text)
                    .Argumento = IIf(Trim(Me.txtArgumento.Text) = "", 0, Me.txtArgumento.Text)
                    If Trim(Me.txtPwd.Text) <> "" Then
                        strPwd = sv.EncriptarPwd(Trim(Me.txtPwd.Text), reRespuesta)
                        If reRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                            .PWD = strPwd
                        Else
                            strMsg = reRespuesta.RespuestaToString
                            Exit Try
                        End If
                    Else
                        .PWD = strPwd
                    End If
                End If
            End With
            sv = New Core
            sv.ABC_AppProy(tTicket, aAppProy, op, rRespuesta)
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
                strMsg = "Ocurrió un error al intentar la operación solicitada: " & rRespuesta.RespuestaToString
            End If
            '       
        Catch ex As Exception
            strMsg = ex.Message
            Throw
        Finally
            sv = Nothing
            aAppProy = Nothing
            rRespuesta = Nothing
        End Try
        Return strMsg
    End Function

    Private Sub SaveItem(ByVal iProy As Integer, ByVal iApli As Integer)
        'Dim lr As ListItem
        'Dim varUsrid As Integer
        Try
            Dim str As String
            If btnSave.CommandArgument <> "Add" Then 'actualizar cambios
                str = EjecutaAccion(iProy, iApli, OperacionesABC.operCambio)
            Else 'insertar 
                str = EjecutaAccion(iProy, iApli, OperacionesABC.operAlta)
            End If
            If str <> String.Empty Then
                Me.dlgBoxExcepciones.ShowMessage(str)
            End If
            grdAppProy.EditItemIndex = -1

            BindUser()

            'Habilitar listas
            ListaProy.Enabled = True
            ListaAplicacion.Enabled = True

            'Ocultar panel
            pnlFormAppProy.Visible = False

        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Sub CreaDropAndList(ByVal DropList As Object, ByVal vDataValueField As String, ByVal vDataTextField As String, ByVal Tipop As Integer)
        Dim sv As New Core
        Dim dv As DataView = Nothing
        Dim ds As DataSet
        'Dim dsh As DataSet
        Dim rRespuesta As Respuesta = Nothing
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Tipop = 1 Then
                'todos los Proyectos
                ds = sv.ColProyectosMega(rRespuesta)
                If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    dv = ds.Tables(0).DefaultView
                End If
            Else
                'todas las aplicaciones
                ds = sv.ColAplicacion(tTicket, rRespuesta)
                If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    dv = ds.Tables(0).DefaultView
                End If
            End If
            'establecemos el origen de datos de las listas desplegables
            DropList.DataSource = dv
            DropList.DataValueField = vDataValueField
            DropList.DataTextField = vDataTextField
            DropList.DataBind()
            ds.Dispose()
            dv.Dispose()
        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try
        sv = Nothing
    End Sub

#End Region

#Region "Eventos del DataGrid"

    Private Sub grdAppProy_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdAppProy.DeleteCommand
        DeleteItem(hiddenProy.Value, hiddenApli.Value, e.Item.ItemIndex)
        'dlgBoxExcepciones.ShowMessage("Registro Desactivado.")
    End Sub

    Private Sub grdAppProy_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdAppProy.ItemCommand
        Dim sv As New Core
        'Dim dv As DataView
        'Dim ds As DataSet
        'Dim rRespuesta As Respuesta
        Dim reRespuesta As Respuesta = Nothing
        Dim strPWD As String
        '
        If e.Item.ItemType = ListItemType.Pager Or _
                e.Item.ItemType = ListItemType.Header Then Exit Sub
        '
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        'Crear Drop de GrupoaAdmin
        'CreaDropAndList(Me.ListaProy, "ProyectoId", "Nombre", 1)
        CreaDropAndList(Me.ListaProy, "ProyectoId", "NombreCompleto", 1)
        CreaDropAndList(Me.ListaAplicacion, "AplicacionID", "Nombre", 2)
        'NoIdentidad
        hiddenProy.Value = Trim(e.Item.Cells(1).Text)
        hiddenApli.Value = Trim(e.Item.Cells(2).Text)
        Try
            If e.CommandName = "Editar" Then

                ' The values for each field in the edit form are taken from the Cells
                ' collection of e.Item.
                ListaProy.SelectedValue = e.Item.Cells(1).Text
                ListaAplicacion.SelectedValue = e.Item.Cells(2).Text

                'Deshabilitar listas
                ListaProy.Enabled = False
                ListaAplicacion.Enabled = False

                'Asignar valores a los objetos
                Me.txtUser.Text = IIf(Trim(e.Item.Cells(3).Text) <> "&nbsp;", Trim(e.Item.Cells(3).Text), "")
                Me.txtDSN.Text = IIf(Trim(e.Item.Cells(5).Text) <> "&nbsp;", Trim(e.Item.Cells(5).Text), "")
                Me.txtDriver.Text = IIf(Trim(e.Item.Cells(6).Text) <> "&nbsp;", Trim(e.Item.Cells(6).Text), "")
                Me.txtServidor.Text = Trim(e.Item.Cells(7).Text)
                Me.txtBD.Text = Trim(e.Item.Cells(8).Text)
                Me.txtArgumento.Text = Trim(e.Item.Cells(9).Text)
                If Trim(e.Item.Cells(4).Text) <> "&nbsp;" Then
                    If Trim((e.Item.Cells(4).Text)) <> "" Then
                        strPWD = sv.DesencriptarPwd(Trim((e.Item.Cells(4).Text)), reRespuesta)
                        If reRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                            Me.txtPwd.Text = strPWD
                        Else
                            dlgBoxExcepciones.ShowMessage(reRespuesta.RespuestaToString)
                        End If
                    Else
                        Me.txtPwd.Text = ""
                    End If
                Else
                    Me.txtPwd.Text = ""
                End If
                'este atributo se agrega para editar el password en textmode password
                'porque de lo contrario a la hora de editar le pone ""
                Me.txtPwd.Attributes.Add("Value", txtPwd.Text)
                '
                Me.txtPwd.Visible = True
                pnlFormAppProy.Visible = True

            Else
                ' Delete the user
                pnlFormAppProy.Visible = False
                'dlgBoxExcepciones.ShowConfirmation("Está seguro de eliminar la cadena de conexión " + Trim(e.Item.Cells(1).Text) & " " & Trim(e.Item.Cells(2).Text) & " " & Trim(e.Item.Cells(3).Text), "Delete", True, False)
            End If

            btnSave.CommandArgument = ""

        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try

    End Sub

    Private Sub grdAppProy_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdAppProy.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' BIND GRID DATA ITEMS: Handles HG1.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' Add events/alerts to grid items 
        '  Only applies to Item / Alt Items (ie: not header, footer rows)
        '  Adds Confirmation message to delete button
        '----------------------------------------------------------------------------------------------------------
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'Add confirm message box to Delete button
            Dim l As LinkButton
            l = CType(e.Item.Cells(10).Controls(0), LinkButton)
            l.Attributes.Add("onclick", "return getconfirm();")
        End If
    End Sub

    Private Sub grdAppProy_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdAppProy.PageIndexChanged
        Try
            grdAppProy.CurrentPageIndex = e.NewPageIndex
            Me.pnlFormAppProy.Visible = False
            BindUser()
        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try

    End Sub

    Private Sub grdAppProy_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdAppProy.SortCommand
        Try
            htmlHiddenSortExpression.Value = e.SortExpression
            'Rebind the DataGrid.
            BindUser()
        Catch ex As Exception
            dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try

    End Sub

#End Region

#Region "Eventos dlgBoxExcepciones, btnAddNew y btnSave"

    'Private Sub dlgBoxExcepciones_YesChoosed(ByVal sender As System.Object, ByVal Key As String)
    '    'Key contiene la clave introducida cuando se llama al método ShowConfirmation.
    '    Select Case Key
    '        Case "Delete"
    '            DeleteItem(hiddenProy.Value, hiddenApli.Value)
    '            dlgBoxExcepciones.ShowMessage("Registro Desactivado.")
    '    End Select
    'End Sub

    Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        'Dim rRespuesta As Respuesta
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            hiddenProy.Value = 0 ' no hay ninguno aún
            hiddenApli.Value = 0
            Me.txtUser.Text = ""
            Me.txtPwd.Text = ""
            Me.txtDSN.Text = ""
            Me.txtDriver.Text = ""
            Me.txtServidor.Text = ""
            Me.txtBD.Text = ""
            Me.txtArgumento.Text = ""
            'Crear Drop de Proy
            'CreaDropAndList(Me.ListaProy, "ProyectoId", "Nombre", 1)
            CreaDropAndList(Me.ListaProy, "ProyectoId", "NombreCompleto", 1)
            'Crea List de aplic
            CreaDropAndList(ListaAplicacion, "AplicacionID", "Nombre", 2)
            txtPwd.Visible = True
            pnlFormAppProy.Visible = True
            btnSave.CommandArgument = "Add"
        Catch ex As Exception
            dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            If IsValid Then

                'Guardar el ID del proyecto y aplicación seleccionado
                hiddenProy.Value = Me.ListaProy.SelectedValue
                hiddenApli.Value = Me.ListaAplicacion.SelectedValue

                Dim sv As Core = New Core
                Dim rRespuesta As Respuesta = Nothing

                'Verificar si la combinación Proyecto-Aplicacion seleccionada no existe
                'para el caso de una alta
                Dim dsAppProy As DataSet = sv.ColBusAppProy(hiddenProy.Value, hiddenApli.Value, rRespuesta)
                'Si ocurrió error
                If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    dlgBoxExcepciones.ShowMessage(rRespuesta.RespuestaToString)
                Else
                    'Si se está editando
                    If btnSave.CommandArgument = "Add" Then
                        'Si el dataset trae registros
                        If dsAppProy.Tables(0).Rows.Count > 0 Then
                            'Indicar que ya existe la combinación Proyecto-Aplicación
                            dlgBoxExcepciones.ShowMessage("El Proyecto y la Aplicación seleccionados ya están registrados.")
                            'Limpiar variables
                            sv = Nothing
                            dsAppProy = Nothing
                            'Salir del procedimiento
                            Exit Sub
                        Else
                            'Limpiar variables
                            sv = Nothing
                            dsAppProy = Nothing
                            'Si no existe permite guardar
                            SaveItem(hiddenProy.Value, hiddenApli.Value)
                        End If
                    Else
                        'Altas guarda
                        SaveItem(hiddenProy.Value, hiddenApli.Value)
                    End If
                End If
            Else
                Exit Sub
            End If

        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.pnlFormAppProy.Visible = False
    End Sub

#End Region

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

End Class