Imports Portalv9.SvrUsr
Imports System.Text
Imports System.Security.Cryptography

Partial Public Class Wfrm_Usuarios
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Private tTicket As IDTicket
    Private eGrupoAdminID As Integer
#End Region
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Asignar click al texto de buscar
        Me.txtBuscar.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Me.btnBuscar.UniqueID + "').click();return false;}} else {return true}; ")
        CreaObjetos()
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        '
        If Not Page.IsPostBack Then
            lblTitle.Text = "Usuarios"
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
            Dim nNoIdentidad As Integer = 0
            Dim rRespuesta As Respuesta = Nothing
            Dim strResult As String
            Try
                strResult = ObtieneResultado()
                If strResult <> String.Empty Then
                    Me.MsgBox1.ShowMessage(strResult)
                End If
                'If Not IsPostBack Then
                Dim strRes As String = Session("DebeCambiarPwd")
                If strRes <> String.Empty Then
                    If CType(strRes, Boolean) = True Then
                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                        Exit Try
                    End If
                End If
                nNoIdentidad = CargaIdentidadUsr(tTicket, rRespuesta)
                If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    Me.MsgBox1.ShowMessage(rRespuesta.RespuestaToString)
                End If

            Catch ex As Exception
                Me.MsgBox1.ShowMessage(ex.Message)
            Finally
                tTicket = Nothing
            End Try

        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub
    Private Function CargaGrupoAdminUsr(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As Integer
        Dim sv As Core = New Core
        Dim ds As DataSet
        ds = sv.ColIdentidadUsr(ptTicket, prRespuesta)
        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            CargaGrupoAdminUsr = ds.Tables(0).Rows(0).Item("GrupoAdminID")
        End If
        sv = Nothing
        ds = Nothing
    End Function
    Private Function CargaIdentidadUsr(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As Integer
        Dim sv As Core = New Core
        Dim dv As DataView
        Dim dsIdentidadUsr As DataSet = sv.ColUsuariosAdministrar(ptTicket, prRespuesta)
        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            dv = dsIdentidadUsr.Tables(0).DefaultView
            dv.Sort = htmlHiddenSortExpression.Value
            '[IEJ 20081021] Ingresar Filtro de la BUSQUEDA
            dv.RowFilter = " (ApellidoP + ' '  + ApellidoM + ' ' + Nombre + ' ' + UsrID) LIKE '%" & Me.txtBuscar.Text & "%'"
            grdUser.DataSource = dv
            grdUser.DataBind()
            dsIdentidadUsr.Dispose()
        End If
        dsIdentidadUsr = Nothing
        sv = Nothing
    End Function
    Private Sub BindUser()
        Dim rRespuesta As Respuesta = Nothing
        Dim nIdentidadUsrID As Integer = 0
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            nIdentidadUsrID = CargaIdentidadUsr(tTicket, rRespuesta)
            If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                Me.MsgBox1.ShowMessage(rRespuesta.RespuestaToString)
                Exit Sub
            End If
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        Finally
            tTicket = Nothing
        End Try
    End Sub
    Private Sub DeleteItem(ByVal strNoIdentidad As Integer)
        Try
            Dim str As String
            str = EjecutaAccion(strNoIdentidad, OperacionesABC.operBaja)
            If grdUser.Items.Count = 1 AndAlso grdUser.CurrentPageIndex > 0 Then
                grdUser.CurrentPageIndex = grdUser.CurrentPageIndex - 1
            End If
            BindUser()
            Me.MsgBox1.ShowMessage(str)
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try
    End Sub
    Private Function EjecutaAccion(ByVal iNoIdentidad As Long, ByVal op As Integer, Optional ByRef NoIdentidad As Integer = 0) As String
        Dim aIdentidadUsr As IdentidadUsr
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
                dsVal = sv.BuscaXNombreTabla(tTicket, rRespuesta, "U", txtLogin.Text)
                If dsVal.Tables(0).Rows.Count > 0 Then
                    blnVal = True
                End If
                dsVal = Nothing
            End If

            If blnVal Then
                strMsg = "El Login  """ & txtLogin.Text & """ ya existe para otro usuario"
            Else

                aIdentidadUsr = New IdentidadUsr
                Dim sDescripcion As String
                sDescripcion = DescripcionLog(1, op)
                With aIdentidadUsr
                    If op = 1 Then 'Si se va a elimnar
                        .UsrID = ""
                        .Nombre = ""
                        .ApellidoP = ""
                        .ApellidoM = ""
                        .Desactivado = 0
                        .DebeCambiarPwd = 0
                        .GrupoAdminID = 0
                        .IntentosFallidosConsec = 0
                        .LlavePublica = ""
                        .Pwd = ""
                        .FechaCreacionPwd = DateTime.Now
                    End If
                    If op <> 0 Then 'No es Alta
                        .NoIdentidad = iNoIdentidad
                    End If
                    If op <> 1 Then  'No poner valores para eliminar
                        If op = 0 Then 'Alta
                            '.Pwd = Request.Form("txtPwdMD5").ToString
                            '.Pwd = MD5Encrypt(Request.Form("txtPwd").ToString)
                            .Pwd = MD5Encrypt(Me.txtPwd.Text)
                            .FechaCreacionPwd = DateTime.Now
                        End If
                        .UsrID = txtLogin.Text
                        .Nombre = txtNombre.Text
                        .ApellidoP = txtApellidoP.Text
                        .ApellidoM = txtApellidoM.Text
                        .Desactivado = CheckDeshabilitar.Checked
                        .DebeCambiarPwd = CheckChangePwd.Checked
                        .GrupoAdminID = DropGrupoAdmin.SelectedValue
                        .IntentosFallidosConsec = 0
                        .LlavePublica = ""
                        '[BCC 20080506] Asignar el valor de email y domicilio indicados
                        .Email = Me.txtEmail.Text
                        .DomicilioID = 0
                        '[IEJ 20081021] Asignar el valor de IntentosFallidosDia y FechaDesacIntentosDia, ELIMINADO
                        .IntentosFallidosDia = 0
                        .FechaDesacIntentosDia = DateTime.Now
                        .Eliminado = False

                    End If
                End With

                NoIdentidad = sv.ABC_IdentidadUsr(tTicket, aIdentidadUsr, op, rRespuesta, sDescripcion)
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
            End If

        Catch ex As Exception
            strMsg = ex.Message
        Finally
            sv = Nothing
            aIdentidadUsr = Nothing
            rRespuesta = Nothing
        End Try
        EjecutaAccion = strMsg
    End Function

    Private Function MD5Encrypt(ByVal strInput As String) As String
        Dim HashVal As Byte() = New MD5CryptoServiceProvider().ComputeHash(ConvertStringToByteArray(strInput))
        Return BitConverter.ToString(HashVal).Replace("-", "")
    End Function

    Public Shared Function ConvertStringToByteArray(ByVal s As String) As Byte()
        Return (New ASCIIEncoding).GetBytes(s)
    End Function 'ConvertStringToByteArray

    Private Function EjecutaAccionPerfil(ByVal iNoIdentidad As Long, ByVal iPerfilID As Long, ByVal op As Integer) As String
        Dim aPerfilIdentidadUsr As PerfilUsuario
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty
        Dim iNoindentidadUsr As Integer

        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            aPerfilIdentidadUsr = New PerfilUsuario
            With aPerfilIdentidadUsr
                .NoIdentidad = iNoIdentidad
                .PerfilUsuarioID = iPerfilID
            End With
            sv = New Core
            iNoindentidadUsr = sv.ABC_PerfilIdentidadUsr(tTicket, aPerfilIdentidadUsr, op, rRespuesta)
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                strMsg = "Se ejecutó correctamente la operacion de cambio solicitada. "
            Else
                strMsg = "Ocurrió un error al intentar la operación solicitada: " & rRespuesta.RespuestaToString
            End If

        Catch ex As Exception
            strMsg = ex.Message
        Finally
            sv = Nothing
            aPerfilIdentidadUsr = Nothing
            rRespuesta = Nothing
        End Try
        EjecutaAccionPerfil = strMsg
    End Function

    Private Sub SaveItem(ByVal iNoIdentidad As Integer)
        Dim lr As ListItem
        'Dim varUsrid As Integer
        Try
            Dim str As String
            If btnSave.CommandArgument <> "Add" Then 'actualizar cambios
                str = EjecutaAccion(iNoIdentidad, OperacionesABC.operCambio)
            Else 'insertar 
                str = EjecutaAccion(0, OperacionesABC.operAlta, iNoIdentidad)
            End If
            If str <> String.Empty Then
                Me.MsgBox1.ShowMessage(str)
            End If
            For Each lr In ListPerfil.Items
                If lr.Value <> "" Then
                    If btnSave.CommandArgument <> "Add" Then 'Update PerfilIdentidadUsr
                        If lr.Selected = True Then
                            EjecutaAccionPerfil(iNoIdentidad, lr.Value, OperacionesABC.operAlta)
                        Else 'delete if existe
                            EjecutaAccionPerfil(iNoIdentidad, lr.Value, OperacionesABC.operBaja)
                        End If
                    Else
                        If lr.Selected = True Then
                            EjecutaAccionPerfil(iNoIdentidad, lr.Value, OperacionesABC.operAlta)
                        End If
                    End If
                End If
            Next

            '-------------------------------------------------------------------------------
            '[IEJ 20080813] 'Campos dinámicos
            'EMPIEZA Guardado de campos dinámicos

            'Carga los campos dinámicos
            Dim rRespuesta As Respuesta = Nothing
            Dim sv As Core = New Core
            Dim ds As DataSet = sv.ColDynamicUsr(tTicket, rRespuesta)
            Dim dt As DataTable = ds.Tables(0)

            Dim TipoOperacion As OperacionesABC

            'Valida que los registros de los ca´mpos dinámicos existan
            'En caso de no existir los crea
            Dim dsDynamicUsrData As DataSet = sv.ColDynamicUsrData(tTicket, rRespuesta, hiddenNoIdentidad.Value)

            Try
                'manda un error si no encuentra los registros
                Dim DynamicUsrData As DataTable = dsDynamicUsrData.Tables(0)
                TipoOperacion = OperacionesABC.operCambio
                DynamicUsrData = Nothing
                If dsDynamicUsrData.Tables(0).Rows.Count > 0 Then
                    TipoOperacion = OperacionesABC.operCambio
                Else
                    TipoOperacion = OperacionesABC.operAlta
                End If

            Catch ex As Exception

                'manda a ejecutar el alta de los registros
                TipoOperacion = OperacionesABC.operAlta

            End Try

            'Recorre los objetos dibujados en la pantalla
            If dt.Rows.Count > 0 Then
                Dim intFin As Integer
                If TipoOperacion = OperacionesABC.operCambio Then
                    intFin = dsDynamicUsrData.Tables(0).Rows.Count
                Else
                    intFin = dt.Rows.Count
                End If
                Dim i As Integer
                For i = 0 To intFin - 1
                    Dim nDynamicUsrIdentidad As Integer
                    Dim strDato As String

                    nDynamicUsrIdentidad = dt.Rows(i).Item("DynamicUsrID")

                    'Obtiene los valores a guardar
                    Dim MiText As New TextBox
                    MiText = Me.Form.FindControl("ContentPlaceHolder2").FindControl("ContentPlaceHolder1").FindControl("txtDynamicUsr" & nDynamicUsrIdentidad)
                    strDato = MiText.Text
                    MiText = Nothing

                    'Manda a guardar la información
                    If TipoOperacion = OperacionesABC.operCambio Then
                        Dim dv As DataView = dsDynamicUsrData.Tables(0).DefaultView
                        dv.RowFilter = " DYNAMICUSRID = " & nDynamicUsrIdentidad
                        If dv.Count > 0 Then
                            str = EjecutaAccionCampos(iNoIdentidad, nDynamicUsrIdentidad, strDato, OperacionesABC.operCambio)
                        Else
                            str = EjecutaAccionCampos(iNoIdentidad, nDynamicUsrIdentidad, strDato, OperacionesABC.operAlta)
                        End If
                        dv.RowFilter = " 1 = 1 "
                        dv = Nothing
                    Else
                        str = EjecutaAccionCampos(iNoIdentidad, nDynamicUsrIdentidad, strDato, TipoOperacion)
                    End If

                Next
                If TipoOperacion <> OperacionesABC.operAlta Then
                    If dt.Rows.Count > dsDynamicUsrData.Tables(0).Rows.Count Then
                        For i = dsDynamicUsrData.Tables(0).Rows.Count To dt.Rows.Count - 1
                            Dim nDynamicUsrIdentidad As Integer
                            Dim strDato As String

                            nDynamicUsrIdentidad = dt.Rows(i).Item("DynamicUsrID")

                            'Obtiene los valores a guardar
                            Dim MiText As New TextBox
                            MiText = Me.Form.FindControl("ContentPlaceHolder2").FindControl("ContentPlaceHolder1").FindControl("txtDynamicUsr" & nDynamicUsrIdentidad)
                            strDato = MiText.Text
                            MiText = Nothing

                            'Manda a guardar la información
                            str = EjecutaAccionCampos(iNoIdentidad, nDynamicUsrIdentidad, strDato, OperacionesABC.operAlta)
                        Next
                    End If
                End If
                
            End If

            'TERMINA Guardado de cmapos dinámicos
            '-------------------------------------------------------------------------------

            grdUser.EditItemIndex = -1
            BindUser()
            pnlFormUser.Visible = False
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Sub CreaDropAndList(ByVal DropList As Object, ByVal vDataValueField As String, ByVal vDataTextField As String, ByVal aGrupoAdminid As Integer, ByVal Tipop As Integer)
        Dim sv As New Core
        Dim dv As DataView = Nothing
        Dim ds As DataSet
        'Dim dsh As DataSet
        Dim rRespuesta As Respuesta = Nothing
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Tipop = 1 Then
                'ds = sv.ColGrupoAdmin(tTicket, aGrupoAdminid, rRespuesta)
                'If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                ds = sv.ColGrupoAdminHijos(tTicket, aGrupoAdminid, rRespuesta)
                If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    'ds.Merge(dsh)
                    dv = ds.Tables(0).DefaultView
                End If
                'End If
            Else
                'ds = sv.ColTodoslosPerfiles(tTicket, rRespuesta)
                'ColPerfilesUsr
                ds = sv.ColPerfilesUsr(tTicket, tTicket.UsrID, rRespuesta)
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
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try
        sv = Nothing
    End Sub

    Private Sub GuardarTicket(ByRef pTicket As IDTicket)
        If Session.Item("GSTR_TICKET") Is Nothing Then
            Session.Add("GSTR_TICKET", pTicket)
        Else
            Session.Item("GSTR_TICKET") = pTicket
        End If
        Session.Timeout = pTicket.TiempoRestante
    End Sub

#End Region

#Region "Eventos del DataGrid"

    Private Sub grdUser_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdUser.ItemCommand
        Dim sv As New Core
        'Dim dv As DataView
        Dim ds As DataSet
        Dim rRespuesta As Respuesta = Nothing

        If e.Item.ItemType = ListItemType.Pager Or _
                e.Item.ItemType = ListItemType.Header Then Exit Sub

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        'NoIdentidad
        hiddenNoIdentidad.Value = Trim(e.Item.Cells(11).Text)
        'Crear Drop de GrupoaAdmin
        CreaDropAndList(DropGrupoAdmin, "GrupoAdminID", "Nombre", tTicket.GrupoAdminID, 1)
        'Crea List de Perfiles
        CreaDropAndList(ListPerfil, "PerfilUsuarioID", "Nombre", 0, 2)

        Try
            If e.CommandName = "Editar" Then
                ' The values for each field in the edit form are taken from the Cells
                ' collection of e.Item.
                txtApellidoP.Text = Trim(e.Item.Cells(1).Text)
                txtApellidoM.Text = Trim(e.Item.Cells(2).Text)
                txtNombre.Text = Trim(e.Item.Cells(3).Text)
                txtLogin.Text = Trim(e.Item.Cells(4).Text)
                txtLogin.Enabled = False
                CheckDeshabilitar.Checked = e.Item.Cells(7).Text
                CheckChangePwd.Checked = e.Item.Cells(12).Text
                DropGrupoAdmin.SelectedValue = e.Item.Cells(13).Text
                Me.txtEmail.Text = Trim(e.Item.Cells(14).Text)
                txtPwd.Visible = False
                LabelPwd.Visible = False
                rfvpwd1.Visible = False
                Me.HiddenField1.Value = Trim(e.Item.Cells(3).Text)
                Me.HiddenField2.Value = Trim(e.Item.Cells(1).Text)
                Me.HiddenField3.Value = Trim(e.Item.Cells(2).Text)
                Me.HiddenField4.Value = Trim(e.Item.Cells(14).Text)
                Me.HiddenField5.Value = Trim(e.Item.Cells(4).Text)
                Me.HiddenField7.Value = e.Item.Cells(7).Text
                Me.HiddenField8.Value = e.Item.Cells(12).Text
                Me.HiddenField9.Value = e.Item.Cells(13).Text
                Me.HiddenField10.Value = ""
                Me.HiddenField11.Value = ""
                'Poner los perfiles a los que pertenece el usuario
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                ds = sv.ColPerfilesUsrPropio(tTicket, Trim(e.Item.Cells(4).Text), rRespuesta)
                If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    Dim lr As ListItem
                    Dim fila As DataRow
                    Dim ArrList As ArrayList = New ArrayList
                    For Each fila In ds.Tables(0).Rows
                        If Not ArrList.Contains(fila("PerfilUsuarioID")) Then
                            ArrList.Add(CType(fila("PerfilUsuarioID"), Integer))
                        End If
                    Next
                    For Each lr In ListPerfil.Items
                        If lr.Value <> "" Then
                            If ArrList.Contains(CType(lr.Value, Integer)) Then
                                lr.Selected = True
                                Me.HiddenField10.Value &= CType(lr.Value, Integer) & ";"
                            End If
                        End If
                    Next
                End If

                '-------------------------------------------------------------------------------
                '[IEJ 20081021] 'Campos dinámicos
                'EMPIEZA Cargar de campos dinámicos
                'Obtiene los campos dinámicos a dibujar en la pantalla
                Dim dsDynamicUsrData As DataSet = sv.ColDynamicUsrData(tTicket, rRespuesta, hiddenNoIdentidad.Value)
                Try
                    'Carga en blanco los campos dinámicos
                    LimpiarObjetos()
                    Dim dt As DataTable = dsDynamicUsrData.Tables(0)
                    'Dibuja los objetos en la pantalla
                    If dt.Rows.Count > 0 Then
                        'recorre todas las filas
                        Dim i As Integer
                        For i = 0 To dt.Rows.Count - 1
                            'Asigna el valor al campo
                            Dim strValor As String = String.Empty
                            Dim MiText As New TextBox
                            If Not dt.Rows(i).Item("Dato").ToString Is Nothing Then
                                strValor = dt.Rows(i).Item("Dato").ToString
                            End If
                            MiText = Me.Form.FindControl("ContentPlaceHolder2").FindControl("ContentPlaceHolder1").FindControl("txtDynamicUsr" & dt.Rows(i).Item("DynamicUsrID"))
                            MiText.Text = strValor
                            Me.HiddenField11.Value &= strValor & ";"
                            MiText = Nothing
                        Next
                    End If
                Catch ex As Exception
                    'Carga en blanco los campos dinámicos
                    LimpiarObjetos()
                End Try
                'TERMINA Cargar de cmapos dinámicos
                '-------------------------------------------------------------------------------
                pnlFormUser.Visible = True
            Else  ' Delete the user
                pnlFormUser.Visible = False
                Me.HiddenField1.Value = Trim(e.Item.Cells(3).Text)
                Me.HiddenField2.Value = Trim(e.Item.Cells(1).Text)
                Me.HiddenField3.Value = Trim(e.Item.Cells(2).Text)
                Me.MsgBox1.ShowConfirmation("Está seguro de eliminar el usuario " + Trim(e.Item.Cells(1).Text) & " " & Trim(e.Item.Cells(2).Text) & " " & Trim(e.Item.Cells(3).Text), "Delete", True, False)
            End If
            btnSave.CommandArgument = ""
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try

    End Sub

    Private Sub grdUser_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdUser.PageIndexChanged
        Try
            grdUser.CurrentPageIndex = e.NewPageIndex
            Me.pnlFormUser.Visible = False
            BindUser()
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try

    End Sub

    Private Sub grdUser_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdUser.SortCommand
        Try
            htmlHiddenSortExpression.Value = e.SortExpression
            'Rebind the DataGrid.
            BindUser()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try

    End Sub

#End Region

#Region "Eventos MsgBox1, btnAddNew y btnSave"

    Private Sub MsgBox1_YesChoosed(ByVal sender As System.Object, ByVal Key As String) Handles MsgBox1.YesChoosed
        'Key contiene la clave introducida cuando se llama al método ShowConfirmation.
        Select Case Key
            Case "Delete"
                DeleteItem(hiddenNoIdentidad.Value)
                'Me.MsgBox1.ShowMessage("Registro Desactivado.")
        End Select
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        'Dim rRespuesta As Respuesta
        Try
            hiddenNoIdentidad.Value = 0 ' no hay ninguno aún
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            'eGrupoAdminID = CargaGrupoAdminUsr(tTicket, rRespuesta)
            txtNombre.Text = ""
            txtApellidoP.Text = ""
            txtApellidoM.Text = ""
            txtLogin.Enabled = True
            txtLogin.Text = ""
            txtPwd.Text = ""
            Me.txtEmail.Text = ""
            CheckDeshabilitar.Checked = False
            CheckChangePwd.Checked = True
            'Crear Drop de GrupoaAdmin
            CreaDropAndList(DropGrupoAdmin, "GrupoAdminID", "Nombre", tTicket.GrupoAdminID, 1)
            'Crea List de Perfiles
            CreaDropAndList(ListPerfil, "PerfilUsuarioID", "Nombre", 0, 2)
            txtPwd.Visible = True
            LabelPwd.Visible = True
            rfvpwd1.Visible = True
            pnlFormUser.Visible = True
            LimpiarObjetos()
            btnSave.CommandArgument = "Add"
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If IsValid Then
                SaveItem(hiddenNoIdentidad.Value)
            Else
                Exit Sub
            End If
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        pnlFormUser.Visible = False
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

    Private Function EjecutaAccionCampos(ByVal pnUsrIdentidad As Integer, ByVal pnDynamicUsrIdentidad As Integer, ByVal psDato As String, ByVal op As Integer, Optional ByRef NoIdentidad As Integer = 0) As String
        Dim aDynamicUsrData As DynamicUsrData
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty

        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)



            aDynamicUsrData = New DynamicUsrData
            With aDynamicUsrData
                If op = 1 Then 'Si se va a elimnar
                    .Dato = ""
                End If
                If op <> 0 Then 'No es Alta
                    .UsrIdentidad = pnUsrIdentidad
                    .DynamicUsrIdentidad = pnDynamicUsrIdentidad
                End If
                If op <> 1 Then  'No poner valores para eliminar

                    .UsrIdentidad = pnUsrIdentidad
                    .DynamicUsrIdentidad = pnDynamicUsrIdentidad
                    .Dato = psDato

                End If
            End With

            sv = New Core
            NoIdentidad = sv.ABC_DynamicUsrData(tTicket, aDynamicUsrData, op, rRespuesta)
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                strMsg = "Se ejecutó correctamente la operacion solicitada. "
            Else
                strMsg = "Ocurrió un error al intentar la operación solicitada: " & rRespuesta.RespuestaToString
            End If

        Catch ex As Exception
            strMsg = ex.Message
        Finally
            sv = Nothing
            aDynamicUsrData = Nothing
            rRespuesta = Nothing
        End Try
        EjecutaAccionCampos = strMsg
    End Function

    Private Sub LimpiarObjetos()
        'Carga los campos dinámicos

        Dim rRespuesta As Respuesta = Nothing
        Dim sv As Core = New Core
        Dim ds As DataSet = sv.ColDynamicUsr(tTicket, rRespuesta)
        Dim dt As DataTable = ds.Tables(0)

        'Recorre los objetos dibujados en la pantalla
        If dt.Rows.Count > 0 Then

            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Dim nDynamicUsrIdentidad As Integer

                nDynamicUsrIdentidad = dt.Rows(i).Item("DynamicUsrID")

                'Obtiene los valores a guardar
                Dim MiText As New TextBox
                MiText = Me.Form.FindControl("ContentPlaceHolder2").FindControl("ContentPlaceHolder1").FindControl("txtDynamicUsr" & nDynamicUsrIdentidad)
                MiText.Text = ""
                MiText = Nothing

            Next

        End If
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        GetDataSource()
    End Sub
    Private Sub CreaObjetos()
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim rRespuesta As Respuesta = Nothing
        'Obtiene los campos dinámicos a dibujar en la pantalla
        Dim sv As Core = New Core
        Dim ds As DataSet = sv.ColDynamicUsr(tTicket, rRespuesta)
        Dim dt As DataTable = ds.Tables(0)
        'Dibuja los objetos en la pantalla
        If dt.Rows.Count > 0 Then
            'recorre todas las filas
            Dim i As Integer
            Dim strTipoDato As String
            Dim blnObligatorio As Boolean
            For i = 0 To dt.Rows.Count - 1
                'Agrega una fila a la tabla de la pantalla
                Dim trwFila As New TableRow
                Dim tcllCelda As TableCell
                'Obtiene el tipo de dato
                strTipoDato = IIf(dt.Rows(i).Item("TipoDato") Is System.DBNull.Value, "Texto", dt.Rows(i).Item("TipoDato"))
                blnObligatorio = IIf(dt.Rows(i).Item("Obligatorio") Is System.DBNull.Value, False, dt.Rows(i).Item("Obligatorio"))
                'Crea la etiqueta en la primer columna
                'Formatea la etiqueta
                'La agrega a la celda
                tcllCelda = New TableCell
                Dim MiLabel As New Label
                MiLabel.ID = "lblDynamicUsr" & dt.Rows(i).Item("DynamicUsrID")
                MiLabel.Text = dt.Rows(i).Item("Etiqueta")
                MiLabel.Font.Name = Label1.Font.Name
                MiLabel.Font.Size = Label1.Font.Size
                MiLabel.Font.Bold = Label1.Font.Bold
                MiLabel.Font.Italic = Label1.Font.Italic
                MiLabel.Font.Strikeout = Label1.Font.Strikeout
                tcllCelda.Controls.Add(MiLabel)
                tcllCelda.HorizontalAlign = HorizontalAlign.Left
                tcllCelda.Width = 90
                trwFila.Cells.Add(tcllCelda)
                MiLabel = Nothing
                tcllCelda = Nothing
                'Crea texto en la segunda columna
                'Formatea el texto
                'Lo agrega a la celda
                tcllCelda = New TableCell
                Dim MiText As New TextBox
                MiText.ID = "txtDynamicUsr" & dt.Rows(i).Item("DynamicUsrID")
                MiText.Text = ""
                MiText.Font.Name = txtNombre.Font.Name
                MiText.Font.Size = txtNombre.Font.Size
                MiText.Font.Bold = txtNombre.Font.Bold
                MiText.Font.Italic = txtNombre.Font.Italic
                MiText.Font.Strikeout = txtNombre.Font.Strikeout
                MiText.Height = txtNombre.Height
                If strTipoDato = "Fecha" Then
                    MiText.Width = txtNombre.Width.Value / 2
                Else
                    MiText.Width = txtNombre.Width
                End If
                'Longitud del campo
                If dt.Rows(i).Item("Maxlen") > 0 Then
                    MiText.MaxLength = dt.Rows(i).Item("Maxlen")
                End If
                'TabIndex
                MiText.TabIndex = 11 + (i + 1)
                tcllCelda.HorizontalAlign = HorizontalAlign.Left
                tcllCelda.Controls.Add(MiText)
                tcllCelda.Width = MiText.Width.Value + 20
                trwFila.Cells.Add(tcllCelda)
                tcllCelda = Nothing
                'Crear el LINK paea la fecha en caso de que aplique
                If strTipoDato = "Fecha" Then
                    tcllCelda = New TableCell
                    Dim Mihpl As New HyperLink
                    Mihpl.ID = "hplDynamicUsr" & dt.Rows(i).Item("DynamicUsrID")
                    Mihpl.NavigateUrl = "javascript:OpenCalendar('ctl00_ContentPlaceHolder1_" & MiText.ID & "',false)"
                    Mihpl.ImageUrl = "images/Icono.gif"
                    tcllCelda.HorizontalAlign = HorizontalAlign.Left
                    tcllCelda.Controls.Add(Mihpl)
                    trwFila.Cells.Add(tcllCelda)
                    tcllCelda = Nothing
                End If
                'Crea la el requirefield en caso de que aplique
                'La agrega a la celda
                If blnObligatorio Then
                    tcllCelda = New TableCell
                    Dim MiRF As New RequiredFieldValidator
                    MiRF.ErrorMessage = "*"
                    MiRF.ControlToValidate = MiText.ID
                    MiRF.Font.Size = rfvgrupoid.Font.Size
                    MiRF.Font.Bold = rfvgrupoid.Font.Bold
                    MiRF.Font.Italic = rfvgrupoid.Font.Italic
                    MiRF.Font.Strikeout = rfvgrupoid.Font.Strikeout
                    tcllCelda.Controls.Add(MiRF)
                    tcllCelda.HorizontalAlign = HorizontalAlign.Left
                    tcllCelda.Width = 20
                    trwFila.Cells.Add(tcllCelda)
                    MiRF = Nothing
                    tcllCelda = Nothing
                End If
                MiText = Nothing
                tblCampos.Rows.Add(trwFila)
                'Redimensiona el alto del panel
                Me.pnlFormUser.Height = Me.pnlFormUser.Height.Value + 23
                trwFila = Nothing
            Next
            'Tab index de los botones ACEPTAR/CANCELAR/BUSCAR
            Me.btnSave.TabIndex = Me.btnSave.TabIndex + (i + 1)
            Me.btnCancelar.TabIndex = Me.btnCancelar.TabIndex + (i + 1)
            Me.btnBuscar.TabIndex = Me.btnBuscar.TabIndex + (i + 1)
            Me.txtBuscar.TabIndex = Me.txtBuscar.TabIndex + (i + 1)
        End If
    End Sub
    Private Function DescripcionLog(ByVal Index As Long, ByVal op As String) As String
        Dim lr As ListItem
        Dim str10 As String = String.Empty
        Dim str11 As String = String.Empty
        Dim i As Integer
        Dim j As Integer = 0
        DescripcionLog = String.Empty
        Select Case op
            Case OperacionesABC.operAlta
                DescripcionLog = "Creación del Usuario: " & txtNombre.Text.Trim & " " & txtApellidoP.Text.Trim & " " & txtApellidoM.Text.Trim & ", "
                For Each lr In ListPerfil.Items
                    If lr.Value <> "" Then
                        If lr.Selected = True Then
                            If j > 0 Then
                                str10 &= ", "
                            End If
                            str10 &= lr.Text.Trim
                            j += 1
                        End If
                    End If
                Next
                DescripcionLog &= " con el Perfil: " & str10
            Case OperacionesABC.operCambio
                DescripcionLog = "Modificación del Usuario: " & txtNombre.Text.Trim & " " & txtApellidoP.Text.Trim & " " & txtApellidoM.Text.Trim
                If Me.HiddenField1.Value.Trim <> txtNombre.Text.Trim Then
                    DescripcionLog = DescripcionLog & ", Modifico el Nombre de '" & Me.HiddenField1.Value.Trim & "'  a  '" & txtNombre.Text.Trim & "'"
                End If
                If Me.HiddenField2.Value.Trim <> txtApellidoP.Text.Trim Then
                    DescripcionLog = DescripcionLog & ", Modifico el Apellido Paterno de '" & Me.HiddenField2.Value.Trim & "'  a  '" & txtApellidoP.Text.Trim & "'"
                End If
                If Me.HiddenField3.Value.Trim <> txtApellidoM.Text.Trim Then
                    DescripcionLog = DescripcionLog & ", Modifico el Apellido Materno de '" & Me.HiddenField3.Value.Trim & "'  a  '" & txtApellidoM.Text.Trim & "'"
                End If
                If Me.HiddenField4.Value.Trim <> Me.txtEmail.Text.Trim Then
                    DescripcionLog = DescripcionLog & ", En eMail. "
                End If
                If Me.HiddenField5.Value.Trim <> txtLogin.Text.Trim Then
                    DescripcionLog = DescripcionLog & ", En Login. "
                End If
                If Me.HiddenField7.Value.Trim <> CheckDeshabilitar.Checked Then
                    DescripcionLog = DescripcionLog & ", En Deshabilitar acceso. "
                End If
                If Me.HiddenField8.Value.Trim <> CheckChangePwd.Checked Then
                    DescripcionLog = DescripcionLog & ", En Debe cambiar el password. "
                End If
                If Me.HiddenField9.Value.Trim <> DropGrupoAdmin.SelectedValue Then
                    DescripcionLog = DescripcionLog & ", En Grupo. "
                End If
                For Each lr In ListPerfil.Items
                    If lr.Value <> "" Then
                        If lr.Selected = True Then
                            str10 &= CType(lr.Value, Integer) & ";"
                        End If
                    End If
                Next
                If Me.HiddenField10.Value.Trim <> str10.Trim Then
                    Dim arrStr1 As Array
                    Dim arrStr2 As Array
                    Dim lstStr1 As New List(Of String)
                    Dim lstStr2 As New List(Of String)
                    Dim strVal As String
                    arrStr1 = Split(Me.HiddenField10.Value, ";")
                    For i = 1 To arrStr1.Length - 1
                        lstStr1.Add(arrStr1(i - 1))
                    Next
                    arrStr2 = Split(str10, ";")
                    For i = 1 To arrStr2.Length - 1
                        lstStr2.Add(arrStr2(i - 1))
                    Next
                    For Each strVal In lstStr1
                        If strVal <> "" Then
                            If Not lstStr2.Contains(strVal) Then
                                j += 1
                                If j = 1 Then
                                    DescripcionLog &= " , Dió de baja perfil: " & ListPerfil.Items.FindByValue(strVal).Text
                                Else
                                    DescripcionLog &= " ," & ListPerfil.Items.FindByValue(strVal).Text
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
                                    DescripcionLog &= " , Agregó perfil: " & ListPerfil.Items.FindByValue(strVal).Text
                                Else
                                    DescripcionLog &= " ," & ListPerfil.Items.FindByValue(strVal).Text
                                End If
                            End If
                        End If
                    Next
                End If
                'Carga los campos dinámicos
                Dim rRespuesta As Respuesta = Nothing
                Dim sv As Core = New Core
                Dim ds As DataSet = sv.ColDynamicUsr(tTicket, rRespuesta)
                Dim dt As DataTable = ds.Tables(0)
                'Recorre los objetos dibujados en la pantalla
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        Dim nDynamicUsrIdentidad As Integer
                        Dim strDato As String
                        nDynamicUsrIdentidad = dt.Rows(i).Item("DynamicUsrID")
                        'Obtiene los valores a guardar
                        Dim MiText As New TextBox
                        MiText = Me.Form.FindControl("ContentPlaceHolder2").FindControl("ContentPlaceHolder1").FindControl("txtDynamicUsr" & nDynamicUsrIdentidad)
                        strDato = MiText.Text
                        str11 &= MiText.Text & ";"
                        MiText = Nothing
                    Next
                End If
                If Me.HiddenField11.Value.Trim <> str11.Trim Then
                    Dim arrStr1 As Array
                    Dim arrStr2 As Array
                    Dim lstStr1 As New List(Of String)
                    Dim lstStr2 As New List(Of String)
                    arrStr1 = Split(Me.HiddenField11.Value, ";")
                    For i = 1 To arrStr1.Length - 1
                        lstStr1.Add(arrStr1(i - 1))
                    Next
                    arrStr2 = Split(str11, ";")
                    For i = 1 To arrStr2.Length - 1
                        lstStr2.Add(arrStr2(i - 1))
                    Next
                    If dt.Rows.Count > 0 Then
                        For i = 0 To lstStr1.Count - 1
                            Dim strEtiqueta As String
                            strEtiqueta = dt.Rows(i).Item("Etiqueta")
                            If lstStr1(i) <> lstStr2(i) Then
                                DescripcionLog = DescripcionLog & "En " & strEtiqueta.Trim & ". "
                            End If
                        Next
                        If lstStr2.Count > lstStr1.Count Then
                            For i = lstStr1.Count To lstStr2.Count - 1
                                Dim strEtiqueta As String
                                strEtiqueta = dt.Rows(i).Item("Etiqueta")
                                If lstStr2(i).Trim <> "" Then
                                    DescripcionLog = DescripcionLog & "En " & strEtiqueta.Trim & ". "
                                End If
                            Next
                        End If
                    End If
                End If
            Case OperacionesABC.operBaja
                DescripcionLog = "Eliminación del Usuario: " & Me.HiddenField1.Value.Trim & " " & Me.HiddenField2.Value.Trim & " " & Me.HiddenField3.Value.Trim
        End Select
    End Function
End Class