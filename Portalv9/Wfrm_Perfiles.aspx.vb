Imports Portalv9.SvrUsr

Partial Public Class Wfrm_Perfiles
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Private tTicket As IDTicket
    Private mintPerfilUsuarioID As Integer
    Private Const strMenuDataSet As String = "strMenuDataSet"
#End Region

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Asignar click al texto de buscar
        Me.txtBuscar.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Me.btnBuscar.UniqueID + "').click();return false;}} else {return true}; ")

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle.Text = "Perfiles"
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
            Dim intPerfilID As Integer = 0
            Dim rRespuesta As Respuesta = Nothing
            Dim strResult As String

            Try
                strResult = ObtieneResultado()
                If strResult <> String.Empty Then
                    Me.dlgBoxExcepciones.ShowMessage(strResult)
                End If
                'If Not IsPostBack Then
                Dim strRes As String = Session("DebeCambiarPwd")
                If strRes <> String.Empty Then
                    If CType(strRes, Boolean) = True Then
                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                        Exit Try
                    End If
                End If
                intPerfilID = CargaPerfiles(tTicket, rRespuesta)
                If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    dlgBoxExcepciones.ShowMessage(rRespuesta.RespuestaToString)
                End If
                'End If

            Catch ex As Exception
                dlgBoxExcepciones.ShowMessage(ex.Message)
            Finally
                tTicket = Nothing
            End Try

        Catch ex As Exception
            dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Function CargaPerfiles(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As Integer
        Dim sv As Core = New Core
        Dim dv As DataView
        'sv.ColTodoslosPerfiles(ptTicket, prRespuesta)
        Dim dsPerfilUsr As DataSet = sv.ColPerfilesUsr(tTicket, tTicket.UsrID, prRespuesta)
        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            dv = dsPerfilUsr.Tables(0).DefaultView
            dv.Sort = htmlHiddenSortExpression.Value
            '[IEJ 20081021] Aplicar filtro BUSQUEDA
            dv.RowFilter = " (Nombre + ' ' + Descripcion) LIKE '%" & Me.txtBuscar.Text & "%'"
            grdPerfiles.DataSource = dv 'dsPerfilUsr
            grdPerfiles.DataBind()
            dsPerfilUsr.Dispose()
        End If
        dsPerfilUsr = Nothing
        sv = Nothing
    End Function

    Private Sub BindUser()
        Dim rRespuesta As Respuesta = Nothing
        Dim intPerfilUsuarioID As Integer = 0
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            intPerfilUsuarioID = CargaPerfiles(tTicket, rRespuesta)
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

    Private Sub DeleteItem(ByVal pintPerfilID As Integer)
        Try
            Dim str As String
            str = EjecutaAccion(pintPerfilID, OperacionesABC.operBaja)
            If grdPerfiles.Items.Count = 1 AndAlso grdPerfiles.CurrentPageIndex > 0 Then
                grdPerfiles.CurrentPageIndex = grdPerfiles.CurrentPageIndex - 1
            End If
            BindUser()
            dlgBoxExcepciones.ShowMessage(str)
        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Function EjecutaAccion(ByRef pintPerfilUsuarioID As Integer, ByVal op As Integer) As String
        Dim objPerfilUsuario As PerfilUsuario
        Dim objPoliticaSes As PoliticaSesion
        Dim objPoliticaPass As PoliticaPwd
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty

        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

            sv = New Core

            'Valida si que el nombre no este repetido
            Dim blnVal As Boolean = False
            If op = 0 Then
                Dim dsVal As New DataSet
                dsVal = sv.BuscaXNombreTabla(tTicket, rRespuesta, "P", txtNombre.Text)
                If dsVal.Tables(0).Rows.Count > 0 Then
                    blnVal = True
                End If
                dsVal = Nothing
            End If

            If blnVal Then
                strMsg = "El nombre del Perfil """ & txtNombre.Text & """ ya existe"
            Else

                objPerfilUsuario = New PerfilUsuario
                objPoliticaSes = New PoliticaSesion
                objPoliticaPass = New PoliticaPwd
                With objPerfilUsuario
                    If op = 1 Then 'Si se va a eliminar 
                        .Nombre = ""
                        .Descripcion = ""
                        .GrupoAdminID = 0
                        objPoliticaSes.PoliticaSesionID = 0
                        objPoliticaPass.PoliticaPwdID = 0
                        .ptrPoliticaSesion = objPoliticaSes
                        .ptrPoliticaPwd = objPoliticaPass
                    End If
                    If op <> 0 Then 'No es Alta
                        .PerfilUsuarioID = pintPerfilUsuarioID
                    End If
                    If op <> 1 Then  'No poner valores para eliminar
                        If op = 0 Then 'Alta
                            .PerfilUsuarioID = 0
                            'El grupo es quien lo crea
                            .GrupoAdminID = tTicket.GrupoAdminID
                            'TODO: Crear registros de Permisos y Proyectos
                            '(al parecer, esto se hace en otro procedimiento)
                        End If
                        objPoliticaSes.PoliticaSesionID = DropPolSesion.SelectedValue
                        objPoliticaPass.PoliticaPwdID = DropPolContra.SelectedValue
                        .Nombre = txtNombre.Text
                        .Descripcion = txtDescripcion.Text
                        .ptrPoliticaSesion = objPoliticaSes
                        .ptrPoliticaPwd = objPoliticaPass

                        'TODO: Modificar permisos y proyectos relacionados al perfil
                        '(al parecer, esto se hace en otro procedimiento)
                    End If
                End With

                Dim sDescripcion As String
                sDescripcion = DescripcionLog(1, op)

                pintPerfilUsuarioID = sv.ABC_PerfilUsuario(tTicket, objPerfilUsuario, op, rRespuesta, sDescripcion)
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
            'valida si es una baja
            If op = 1 Then
                strMsg = "El registro no puede eliminarse ya que esta siendo utilizado en otra parte del sistema"
            Else
                strMsg = ex.Message
            End If
        Finally
            sv = Nothing
            objPerfilUsuario = Nothing
            objPoliticaPass = Nothing
            objPoliticaSes = Nothing
            rRespuesta = Nothing
        End Try
        EjecutaAccion = strMsg
    End Function

    Private Function EjecutaAccionPermiso(ByVal pintPerfilUsuarioID As Integer, ByVal intPermisoID As Integer, ByVal op As Integer) As String
        Dim objPermiso As New Portalv9.SvrUsr.Permiso
        Dim rRespuesta As New Portalv9.SvrUsr.Respuesta
        Dim sv As Portalv9.SvrUsr.Core
        Dim strMsg As String = String.Empty
        Dim iPermisoID As Integer

        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            'objPermiso = New Permiso
            With objPermiso
                .PermisoID = intPermisoID
                .LlaveID = pintPerfilUsuarioID
            End With
            sv = New Core
            iPermisoID = sv.ABC_PermisoPerfilUsuario(tTicket, objPermiso, op, rRespuesta)
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                strMsg = "Se ejecutó correctamente la operacion de cambio solicitada. "
            Else
                strMsg = "Ocurrió un error al intentar la operación solicitada: " & rRespuesta.RespuestaToString
            End If

        Catch ex As Exception
            strMsg = ex.Message
        Finally
            sv = Nothing
            objPermiso = Nothing
            rRespuesta = Nothing
        End Try
        EjecutaAccionPermiso = strMsg
    End Function

    Private Function EjecutaAccionProyecto(ByVal pintPerfilUsuarioID As Integer, ByVal intProyectoID As Integer, ByVal op As Integer) As String
        Dim objProyecto As Portalv9.SvrUsr.Proyecto
        Dim rRespuesta As New Portalv9.SvrUsr.Respuesta
        Dim sv As Portalv9.SvrUsr.Core
        Dim strMsg As String = String.Empty
        Dim iProyectoID As Integer
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            objProyecto = New Portalv9.SvrUsr.Proyecto
            With objProyecto
                .ProyectoID = intProyectoID
                .LlaveID = pintPerfilUsuarioID
            End With
            sv = New Core
            iProyectoID = sv.ABC_PerfilUsuarioProyecto(tTicket, objProyecto, op, rRespuesta)
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                strMsg = "Se ejecutó correctamente la operacion de cambio solicitada. "
            Else
                strMsg = "Ocurrió un error al intentar la operación solicitada: " & rRespuesta.RespuestaToString
            End If

        Catch ex As Exception
            strMsg = ex.Message
        Finally
            sv = Nothing
            objProyecto = Nothing
            rRespuesta = Nothing
        End Try
        EjecutaAccionProyecto = strMsg
    End Function

    Private Sub SaveItem(ByVal pintPerfilUsuarioID As Integer)
        Dim lr As ListItem
        'Dim varUsrid As Integer
        Try
            Dim str As String
            If btnSave.CommandArgument <> "Add" Then 'actualizar cambios
                str = EjecutaAccion(pintPerfilUsuarioID, OperacionesABC.operCambio)
            Else 'insertar 
                pintPerfilUsuarioID = 0
                str = EjecutaAccion(pintPerfilUsuarioID, OperacionesABC.operAlta)
            End If
            If str <> String.Empty Then
                Me.dlgBoxExcepciones.ShowMessage(str)
            End If
            For Each lr In chklstPermisos.Items
                If lr.Value <> "" Then
                    If btnSave.CommandArgument <> "Add" Then 'Update PermisoPerfilUsuario
                        If lr.Selected Then
                            EjecutaAccionPermiso(pintPerfilUsuarioID, lr.Value, OperacionesABC.operAlta)
                        Else 'delete if exists
                            EjecutaAccionPermiso(pintPerfilUsuarioID, lr.Value, OperacionesABC.operBaja)
                        End If
                    Else
                        If lr.Selected Then
                            EjecutaAccionPermiso(pintPerfilUsuarioID, lr.Value, OperacionesABC.operAlta)
                        End If
                    End If
                End If
            Next
            For Each lr In ListProyectos.Items
                If lr.Value <> "" Then
                    If btnSave.CommandArgument <> "Add" Then 'Update PerfilUsuarioProyecto
                        If lr.Selected Then
                            EjecutaAccionProyecto(pintPerfilUsuarioID, lr.Value, OperacionesABC.operAlta)
                        Else 'delete if exists
                            EjecutaAccionProyecto(pintPerfilUsuarioID, lr.Value, OperacionesABC.operBaja)
                        End If
                    Else
                        If lr.Selected Then
                            EjecutaAccionProyecto(pintPerfilUsuarioID, lr.Value, OperacionesABC.operAlta)
                        End If
                    End If
                End If
            Next
            grdPerfiles.EditItemIndex = -1
            BindUser()
            pnlFormUser.Visible = False
        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Sub CreaDropAndList(ByVal DropList As Object, ByVal vDataValueField As String, ByVal vDataTextField As String, ByVal pintPerfilUsuarioID As Integer, ByVal Tipop As Integer)
        Dim sv As New Core
        Dim dv As DataView
        Dim ds As DataSet = Nothing
        Dim rRespuesta As Respuesta = Nothing
        'Dim dr As DataRow
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            Select Case DropList.ID
                Case "ListPermisos"
                    ds = sv.ColPermisosVersionAplicacion(tTicket, Application("GN_VERSION_APLICACION_ID"), rRespuesta)
                Case "chklstPermisos"
                    ds = sv.ColPermisosVersionAplicacion(tTicket, Application("GN_VERSION_APLICACION_ID"), rRespuesta)
                Case "ListProyectos"
                    ds = sv.ColProyectos(0, rRespuesta)
                Case "DropPolSesion"
                    ds = sv.ColPoliticasSesion(tTicket, rRespuesta)
                Case "DropPolContra"
                    ds = sv.ColPoliticasPwd(tTicket, rRespuesta)
            End Select
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                dv = ds.Tables(0).DefaultView
            Else
                Throw New Exception(rRespuesta.RespuestaToString)
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

    Private Sub grdPerfiles_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPerfiles.ItemCommand
        Dim sv As New Core
        'Dim dv As DataView
        Dim ds As DataSet
        Dim rRespuesta As Respuesta = Nothing

        If e.Item.ItemType = ListItemType.Pager Or _
                e.Item.ItemType = ListItemType.Header Then Exit Sub

        'PerfilUsuarioID
        hiddenPerfilID.Value = Trim(e.Item.Cells(7).Text)

        'TODO: Crear Drop de Sesion (verificar la celda correcta)
        CreaDropAndList(DropPolSesion, "PoliticaSesionID", "Nombre", e.Item.Cells(8).Text, 1)
        'TODO: Crear Drop de Políticas de contraseña
        CreaDropAndList(DropPolContra, "PoliticaPwdID", "Nombre", e.Item.Cells(7).Text, 1)
        'TODO: Crear List de Permisos
        ''''CreaDropAndList(ListPermisos, "PermisoID", "Nombre", 0, 2)
        CreaDropAndList(chklstPermisos, "PermisoID", "Nombre", 0, 2)
        'TODO: Crear List de Proyectos
        CreaDropAndList(ListProyectos, "ProyectoID", "Nombre", 0, 2)

        Try
            If e.CommandName = "Editar" Then
                'TODO: Verificar los valores reales de las celdas
                txtNombre.Text = Trim(e.Item.Cells(1).Text)
                txtDescripcion.Text = Trim(e.Item.Cells(2).Text)
                DropPolSesion.SelectedValue = e.Item.Cells(9).Text
                DropPolContra.SelectedValue = e.Item.Cells(8).Text
                Me.HiddenField1.Value = Trim(e.Item.Cells(1).Text)
                Me.HiddenField2.Value = Trim(e.Item.Cells(2).Text)
                Me.HiddenField3.Value = e.Item.Cells(9).Text
                Me.HiddenField4.Value = e.Item.Cells(8).Text
                Me.HiddenField5.Value = ""
                Me.HiddenField6.Value = ""
                'Poner los permisos que contiene el perfil
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                'El item de la celda debe ser el PerfilUsuarioID
                ds = sv.ColPermisosPerfil(tTicket, Trim(e.Item.Cells(7).Text), rRespuesta)
                If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    Dim lr As ListItem
                    Dim fila As DataRow
                    Dim ArrList As ArrayList = New ArrayList
                    For Each fila In ds.Tables(0).Rows
                        If Not ArrList.Contains(fila("PermisoID")) Then
                            ArrList.Add(CType(fila("PermisoID"), Integer))
                        End If
                    Next
                    'Marca permisos actuales
                    For Each lr In chklstPermisos.Items
                        If lr.Value <> "" Then
                            If ArrList.Contains(CType(lr.Value, Integer)) Then
                                lr.Selected = True
                                Me.HiddenField5.Value &= CType(lr.Value, Integer) & ";"
                            End If
                        End If
                    Next
                Else
                    dlgBoxExcepciones.ShowMessage(rRespuesta.DescripcionRespuesta)
                End If
                'El item de la celda debe ser el PerfilUsuarioID
                ds = sv.ColProyectosPerfil(tTicket, Trim(e.Item.Cells(7).Text), rRespuesta)
                If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    Dim lr As ListItem
                    Dim fila As DataRow
                    Dim ArrList As ArrayList = New ArrayList
                    For Each fila In ds.Tables(0).Rows
                        If Not ArrList.Contains(fila("ProyectoID")) Then
                            ArrList.Add(CType(fila("ProyectoID"), Integer))
                        End If
                    Next
                    'Marca proyectos actuales
                    For Each lr In ListProyectos.Items
                        If lr.Value <> "" Then
                            If ArrList.Contains(CType(lr.Value, Integer)) Then
                                lr.Selected = True
                                Me.HiddenField6.Value &= CType(lr.Value, Integer) & ";"
                            End If
                        End If
                    Next
                Else
                    dlgBoxExcepciones.ShowMessage(rRespuesta.DescripcionRespuesta)
                End If

                pnlFormUser.Visible = True

            Else ' Delete the user
                pnlFormUser.Visible = False
                Me.HiddenField1.Value = Trim(e.Item.Cells(1).Text)
                dlgBoxExcepciones.ShowConfirmation("Está seguro de eliminar el perfil " + Trim(e.Item.Cells(1).Text) & " " & Trim(e.Item.Cells(2).Text) & " " & Trim(e.Item.Cells(3).Text), "Delete", True, False)
            End If
            btnSave.CommandArgument = ""
        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Sub grdPerfiles_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdPerfiles.PageIndexChanged
        Try
            grdPerfiles.CurrentPageIndex = e.NewPageIndex
            Me.pnlFormUser.Visible = False
            BindUser()
        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try

    End Sub

    Private Sub grdPerfiles_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdPerfiles.SortCommand
        Try
            htmlHiddenSortExpression.Value = e.SortExpression
            ' Rebind the DataGrid.
            BindUser()
        Catch ex As Exception
            dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try

    End Sub

#End Region

#Region "Eventos dlgBoxExcepciones, btnAddNew y btnSave"

    Private Sub dlgBoxExcepciones_YesChoosed(ByVal sender As Object, ByVal Key As String) Handles dlgBoxExcepciones.YesChoosed
        'Key contiene la clave introducida cuando se llama al método ShowConfirmation.
        Select Case Key
            Case "Delete"
                DeleteItem(hiddenPerfilID.Value)
                'dlgBoxExcepciones.ShowMessage("Registro Desactivado.")
        End Select
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        'Dim rRespuesta As Respuesta
        Try
            hiddenPerfilID.Value = 0 ' no hay ninguno aún
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                LogOff()
                Exit Try
            End If
            txtNombre.Text = ""
            txtDescripcion.Text = ""
            'TODO: Crear Drop de Sesion
            CreaDropAndList(DropPolSesion, "PoliticaSesionID", "Nombre", 0, 1)
            'TODO: Crear Drop de Permisos
            CreaDropAndList(DropPolContra, "PoliticaPwdID", "Nombre", 0, 1)
            'TODO: Crear List de Permisos
            ''''CreaDropAndList(ListPermisos, "PermisoID", "Nombre", 0, 2)
            CreaDropAndList(chklstPermisos, "PermisoID", "Nombre", 0, 2)
            'TODO: Crear List de Proyectos
            CreaDropAndList(ListProyectos, "ProyectoID", "Nombre", 0, 2)
            pnlFormUser.Visible = True
            btnSave.CommandArgument = "Add"
        Catch ex As Exception
            dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If IsValid Then
                SaveItem(hiddenPerfilID.Value)
            Else
                Exit Sub
            End If
        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try

        ' Borra el menu para que se recargue.
        Session(strMenuDataSet) = Nothing

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.pnlFormUser.Visible = False
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


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        GetDataSource()
    End Sub


    Private Function DescripcionLog(ByVal Index As Long, ByVal op As String) As String

        Dim lr As ListItem
        Dim str5 As String = String.Empty
        Dim str6 As String = String.Empty
        Dim i As Integer
        Dim j As Integer = 0

        DescripcionLog = String.Empty

        Select Case op
            Case OperacionesABC.operAlta
                DescripcionLog = "Creación del Perfil: " & txtNombre.Text.Trim
            Case OperacionesABC.operCambio
                DescripcionLog = "Modificación del Perfil: " & txtNombre.Text.Trim & " "
                If Me.HiddenField1.Value.Trim <> txtNombre.Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Nombre. "
                End If
                If Me.HiddenField2.Value.Trim <> txtDescripcion.Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Desc. "
                End If
                If Me.HiddenField3.Value.Trim <> DropPolSesion.SelectedValue Then
                    DescripcionLog = DescripcionLog & "En PolSesión. "
                End If
                If Me.HiddenField4.Value.Trim <> DropPolContra.SelectedValue Then
                    DescripcionLog = DescripcionLog & "En PolContraseña. "
                End If
                For Each lr In chklstPermisos.Items
                    If lr.Value <> "" Then
                        If lr.Selected = True Then
                            str5 &= CType(lr.Value, Integer) & ";"
                        End If
                    End If
                Next
                If Me.HiddenField5.Value.Trim <> str5.Trim Then
                    Dim arrStr1 As Array
                    Dim arrStr2 As Array
                    Dim lstStr1 As New List(Of String)
                    Dim lstStr2 As New List(Of String)
                    Dim strVal As String
                    arrStr1 = Split(Me.HiddenField5.Value, ";")
                    For i = 1 To arrStr1.Length - 1
                        lstStr1.Add(arrStr1(i - 1))
                    Next
                    arrStr2 = Split(str5, ";")
                    For i = 1 To arrStr2.Length - 1
                        lstStr2.Add(arrStr2(i - 1))
                    Next
                    For Each strVal In lstStr1
                        If strVal <> "" Then
                            If Not lstStr2.Contains(strVal) Then
                                j += 1
                                If j = 1 Then
                                    DescripcionLog &= " Dió de baja permisos: " & chklstPermisos.Items.FindByValue(strVal).Text
                                Else
                                    DescripcionLog &= " ," & chklstPermisos.Items.FindByValue(strVal).Text
                                End If
                            End If
                        End If
                    Next
                    j = 0
                    For Each strVal In lstStr2
                        If strVal <> "" Then
                            If Not lstStr1.Contains(strVal) Then
                                j += 1
                                If j = 1 Then
                                    DescripcionLog &= " Agregó permisos: " & chklstPermisos.Items.FindByValue(strVal).Text
                                Else
                                    DescripcionLog &= " ," & chklstPermisos.Items.FindByValue(strVal).Text
                                End If
                            End If
                        End If
                    Next
                End If
                For Each lr In ListProyectos.Items
                    If lr.Value <> "" Then
                        If lr.Selected = True Then
                            str6 &= CType(lr.Value, Integer) & ";"
                        End If
                    End If
                Next
                If Me.HiddenField6.Value.Trim <> str6.Trim Then
                    Dim arrStr1 As Array
                    Dim arrStr2 As Array
                    Dim lstStr1 As New List(Of String)
                    Dim lstStr2 As New List(Of String)
                    Dim strVal As String
                    arrStr1 = Split(Me.HiddenField6.Value, ";")
                    For i = 1 To arrStr1.Length - 1
                        lstStr1.Add(arrStr1(i - 1))
                    Next
                    arrStr2 = Split(str6, ";")
                    For i = 1 To arrStr2.Length - 1
                        lstStr2.Add(arrStr2(i - 1))
                    Next
                    For Each strVal In lstStr1
                        If strVal <> "" Then
                            If Not lstStr2.Contains(strVal) Then
                                j += 1
                                If j = 1 Then
                                    DescripcionLog &= " Dió de baja proyecto: " & ListProyectos.Items.FindByValue(strVal).Text
                                Else
                                    DescripcionLog &= " ," & ListProyectos.Items.FindByValue(strVal).Text
                                End If
                            End If
                        End If
                    Next
                    j = 0
                    For Each strVal In lstStr2
                        If strVal <> "" Then
                            If Not lstStr1.Contains(strVal) Then
                                j += 1
                                If j = 1 Then
                                    DescripcionLog &= " Agregó proyectos: " & ListProyectos.Items.FindByValue(strVal).Text
                                Else
                                    DescripcionLog &= " ," & ListProyectos.Items.FindByValue(strVal).Text
                                End If
                            End If
                        End If
                    Next
                End If
            Case OperacionesABC.operBaja
                DescripcionLog = "Eliminación del Perfil: " & Me.HiddenField1.Value.Trim
        End Select


    End Function

    

End Class