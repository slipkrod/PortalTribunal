Imports Portalv9.SvrUsr
Partial Public Class Wfrm_GrupoAdmin
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

#Region "Eventos de la forma"

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Asignar click al texto de buscar
        Me.txtBuscar.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Me.btnBuscar.UniqueID + "').click();return false;}} else {return true}; ")

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle.Text = "Grupos"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            GetDataSource()
        Else

        End If
    End Sub

#End Region

#Region "Métodos privados"

    Private Sub GetDataSource()

        'Introducir aquí el código de usuario para inicializar la página
        Dim strResult As String

        Try

            strResult = ObtieneResultado()

            If strResult <> String.Empty Then
                MsgBox1.ShowMessage(strResult)
            End If

            If Not IsPostBack Then
                Dim strRes As String = Session("DebeCambiarPwd")
                If strRes <> String.Empty Then
                    If CType(strRes, Boolean) = True Then
                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                        Exit Try
                    End If
                End If
                CargaDS()
            End If

        Catch ex As Exception
            MsgBox1.ShowMessage(ex.ToString)
        End Try

    End Sub

    Private ReadOnly Property SESSIONKEY_DATASOURCE() As String
        Get
            Return Me.UniqueID & "_DataSource"
        End Get
    End Property

    Private Sub CargaDS()

        'Introducir aquí el código de usuario para inicializar la página
        Dim rRespuesta As Respuesta = Nothing
        Dim dsGrupos As DataSet = Nothing
        Dim nVersionAplicacionID As Integer = 0
        Dim sv As Core = New Core

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

        Dim strRes As String = Session("DebeCambiarPwd")
        If strRes <> String.Empty Then
            If CType(strRes, Boolean) Then
                Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                'TODO: Asegurarse de que sale de la página
            End If
        ElseIf Not Session("REDIRECT_PAG") Is Nothing Then
            Dim strPag As String = Session("REDIRECT_PAG")
            Session.Remove("REDIRECT_PAG")
            Response.Redirect(strPag)
        End If

        Try
            Dim intGrupoAdmin As Integer = tTicket.GrupoAdminID
            If intGrupoAdmin > 0 Then

                dsGrupos = sv.ColGrupoAdminHijos(tTicket, intGrupoAdmin, rRespuesta)
                If Not dsGrupos Is Nothing Then
                    If dsGrupos.Tables.Count > 0 Then

                        dsGrupos.Tables(0).TableName = "Estaciones"
                        Session(SESSIONKEY_DATASOURCE) = dsGrupos

                        'Actualizar el cache del dataset completo
                        CargaDG(dsGrupos, False)

                    ElseIf rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                        Throw New Exception(rRespuesta.RespuestaToString)
                    End If
                Else
                    Throw New Exception(rRespuesta.RespuestaToString)
                End If
            End If
            sv = Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Private Sub CargaDG(ByVal oDS As DataSet, ByVal blnExpandible As Boolean)
        'map the tables that are returned from the DB to the ones we will create in the dataset
        oDS.Tables(0).TableName = "Grupos"
        Cache("dsGrupos") = oDS
        grdPGrupo.CurrentPageIndex = 0
        grdPGrupo.EditItemIndex = -1
        grdPGrupo.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub BindData()
        '[IEJ 20081021] Aplicar Filtro BUSQUEDA
        Dim dv As New DataView
        dv = Cache("dsGrupos").Tables(0).DefaultView
        dv.RowFilter = " (Nombre + ' ' + Descripcion) LIKE '%" & Me.txtBuscar.Text & "%'"
        'bind the DataSet to the HierarGrid
        grdPGrupo.DataSource = dv
        grdPGrupo.DataMember = "Grupos"
        grdPGrupo.DataBind()
        Cache("dsGrupos").tables(0).rows.count()
    End Sub

    'Private Sub GetDataSource()
    '    Try
    '        Dim strResult As String
    '        Dim rRespuesta As Respuesta

    '        Try
    '            strResult = ObtieneResultado()
    '            If strResult <> String.Empty Then
    '                Me.MsgBox1.ShowMessage(strResult)
    '            End If
    '            If Not IsPostBack Then
    '                Dim strRes As String = Session("DebeCambiarPwd")
    '                If strRes <> String.Empty Then
    '                    If CType(strRes, Boolean) = True Then
    '                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
    '                        Exit Try
    '                    End If
    '                End If
    '                CargaGruposAdmin(tTicket, rRespuesta)
    '                If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
    '                    Me.MsgBox1.ShowMessage(rRespuesta.RespuestaToString)
    '                End If
    '            End If
    '        Catch ex As Exception
    '            Me.MsgBox1.ShowMessage(ex.Message)
    '        Finally
    '            tTicket = Nothing
    '        End Try
    '    Catch ex As Exception
    '        Response.Write(ex.Message)
    '    End Try
    'End Sub

    'Private Sub CargaGruposAdmin(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta)
    '    Dim sv As Core = New Core
    '    Dim intGrupoAdmin As Integer = ptTicket.GrupoAdminID
    '    If intGrupoAdmin > 0 Then
    '        'Carga los grupos que este usuario puede administrar
    '        Dim ds As DataSet = sv.ColGrupoAdminHijos(ptTicket, intGrupoAdmin, prRespuesta)
    '        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
    '            grdPGrupo.DataSource = ds
    '            grdPGrupo.DataBind()
    '            ds.Dispose()
    '        End If
    '        ds = Nothing
    '    End If
    '    sv = Nothing
    'End Sub

    'Private Sub Agregar_newrow()
    '    'Dim strResult As String
    '    Dim rRespuesta As Respuesta
    '    Dim sv As Core = New Core
    '    tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
    '    Dim intGrupoAdmin As Integer = tTicket.GrupoAdminID

    '    If intGrupoAdmin > 0 Then
    '        Dim ds As DataSet = sv.ColGrupoAdminHijos(tTicket, intGrupoAdmin, rRespuesta)
    '        If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
    '            Dim dv As DataView = ds.Tables(0).DefaultView
    '            dv.AddNew()
    '            If grdPGrupo.Items.Count = grdPGrupo.PageSize Then
    '                grdPGrupo.CurrentPageIndex = grdPGrupo.CurrentPageIndex + 1
    '                grdPGrupo.EditItemIndex = 0
    '            Else
    '                grdPGrupo.EditItemIndex = grdPGrupo.Items.Count()
    '            End If
    '            With grdPGrupo
    '                .DataSource = dv
    '                .DataBind()
    '            End With
    '            ds.Dispose()
    '            dv = Nothing
    '        End If
    '    End If
    '    sv = Nothing
    'End Sub

    Private Function Agregar_Registro()

        'Si el número de registros en el grid es igual al límite de registros por página
        If grdPGrupo.Items.Count = grdPGrupo.PageSize Then
            'Cambia de página
            grdPGrupo.CurrentPageIndex = grdPGrupo.PageCount - 1
            'Actualiza el grid
            BindData()
        End If

        Dim intTotalItemsGrid As Integer
        intTotalItemsGrid = grdPGrupo.Items.Count + grdPGrupo.PageSize * grdPGrupo.CurrentPageIndex

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

        Dim dv As DataView = Cache("dsGrupos").Tables("Grupos").DefaultView
        If dv.Count <= intTotalItemsGrid Then
            dv.AddNew()
        End If

        If grdPGrupo.Items.Count = grdPGrupo.PageSize Then
            'Debe agregar en la siguiente página, ésta ya se llenó
            grdPGrupo.CurrentPageIndex = grdPGrupo.CurrentPageIndex + 1
            grdPGrupo.EditItemIndex = 0
        Else
            grdPGrupo.EditItemIndex = grdPGrupo.Items.Count()
        End If

        With grdPGrupo
            .DataSource = dv
            .DataBind()
        End With

        dv = Nothing
        Return Nothing
    End Function


    'Private Sub BindUser()
    '    Dim rRespuesta As Respuesta
    '    Try
    '        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
    '        CargaGruposAdmin(tTicket, rRespuesta)
    '        If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
    '            Me.MsgBox1.ShowMessage(rRespuesta.RespuestaToString)
    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '        Me.MsgBox1.ShowMessage(ex.Message)
    '    Finally
    '        tTicket = Nothing
    '    End Try
    'End Sub

    Private Sub DeleteItem(ByVal strID As Integer)
        Try
            Dim str As String
            str = EjecutaAccion(strID, OperacionesABC.operBaja)
            If grdPGrupo.Items.Count = 1 AndAlso grdPGrupo.CurrentPageIndex > 0 Then
                grdPGrupo.CurrentPageIndex = grdPGrupo.CurrentPageIndex - 1
            End If
            CargaDS()
            grdPGrupo.EditItemIndex = -1
            BindData()
            Me.MsgBox1.ShowMessage(str)
            'Dim str As String
            'str = EjecutaAccion(strID, OperacionesABC.operBaja)
            'If grdPGrupo.Items.Count = 1 AndAlso grdPGrupo.CurrentPageIndex > 0 Then
            '    grdPGrupo.CurrentPageIndex = grdPGrupo.CurrentPageIndex - 1
            'End If
            'BindUser()
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String
        Dim aGpoAdmin As GrupoAdmin
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
                dsVal = sv.BuscaXNombreTabla(tTicket, rRespuesta, "G", CType(grdPGrupo.Items(Index).FindControl("TextNombre"), TextBox).Text)
                If dsVal.Tables(0).Rows.Count > 0 Then
                    blnVal = True
                End If
                dsVal = Nothing
            End If

            If blnVal Then
                strMsg = "El nombre del Grupo """ & CType(grdPGrupo.Items(Index).FindControl("TextNombre"), TextBox).Text & """ ya existe"
            Else
                aGpoAdmin = New GrupoAdmin
                Dim sDescripcion As String
                sDescripcion = DescripcionLog(Index, op)
                With aGpoAdmin
                    If op <> 0 Then 'No es Alta
                        .GrupoAdminID = grdPGrupo.Items(Index).Cells(0).Text
                    End If
                    If op <> 1 Then  'No poner valores para eliminar
                        .Nombre = CType(grdPGrupo.Items(Index).FindControl("TextNombre"), TextBox).Text
                        .Descripcion = IIf(CType(grdPGrupo.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim = "", " ", CType(grdPGrupo.Items(Index).FindControl("TextDescripcion"), TextBox).Text)
                        .ResponsableID = CType(grdPGrupo.Items(Index).FindControl("ddResponsable"), DropDownList).SelectedValue
                        .GrupoAdminPID = CType(grdPGrupo.Items(Index).FindControl("ddgpopadre"), DropDownList).SelectedValue
                        .ClienteID = CType(grdPGrupo.Items(Index).FindControl("ddCliente"), DropDownList).SelectedValue
                    End If
                End With

                sv.ABC_GrupoAdmin(tTicket, aGpoAdmin, op, rRespuesta, sDescripcion)
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
            aGpoAdmin = Nothing
            rRespuesta = Nothing
        End Try
        EjecutaAccion = strMsg
    End Function

    Private Function ObtieneDataView(ByVal Catalogo As String) As DataView
        Dim sv As New Core
        Dim dv As DataView = Nothing
        Dim ds As DataSet = Nothing
        Dim rRespuesta As Respuesta = Nothing

        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            Dim intGrupoAdmin As Integer = tTicket.GrupoAdminID
            Select Case Catalogo
                Case "Grupos"
                    ds = sv.ColGrupoAdminHijos(tTicket, intGrupoAdmin, rRespuesta)
                Case "Usuarios"
                    ' ds = sv.ColUsuariosAdministrar(tTicket, rRespuesta)
                    ds = sv.ColResponsableAdministrar(tTicket, rRespuesta)
                Case "Clientes"
                    ds = sv.ColClientes(tTicket, rRespuesta)
            End Select
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                dv = ds.Tables(0).DefaultView
            End If
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try
        sv = Nothing
        Return dv
    End Function

#End Region

#Region "Métodos públicos"

    Public Function ObtenerUsuarios() As DataView
        'ICollection
        Return ObtieneDataView("Usuarios")
    End Function

    Public Function ObtenerGrupos() As DataView
        Return ObtieneDataView("Grupos")
    End Function

    Public Function ObtenerClientes() As DataView
        Return ObtieneDataView("Clientes")
    End Function

#End Region

#Region "Eventos del DataGrid"

    Private Sub grdPGrupo_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPGrupo.ItemCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdPGrupo)
        hiddenPGrupo.Value = Trim(e.Item.Cells(0).Text)
    End Sub

    Private Sub grdPGrupo_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPGrupo.EditCommand
        'GlobalDef.VerIndiceFueradeRango(Me.grdPGrupo)
        'If e.Item.ItemType = ListItemType.Pager Or _
        '    e.Item.ItemType = ListItemType.Header Then Exit Sub
        'Try
        '    grdPGrupo.SelectedIndex = -1
        '    grdPGrupo.EditItemIndex = e.Item.ItemIndex
        '    BindUser()
        '    'Llenamos los campos a editar con los valores actuales en el grid
        '    CType(grdPGrupo.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text = CType(e.Item.FindControl("lblNombre"), Label).Text
        '    CType(grdPGrupo.Items(e.Item.ItemIndex).FindControl("TextDescripcion"), TextBox).Text = CType(e.Item.FindControl("lblDescripcion"), Label).Text

        'Catch ex As Exception
        '    Me.MsgBox1.ShowMessage(ex.Message)
        'End Try
        GlobalDef.VerIndiceFueradeRango(grdPGrupo)
        If e.Item.ItemType = ListItemType.Pager Or _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        'Crea lista de datos para posteriormente describir los cambios realizados
        Me.HiddenField1.Value = CType(e.Item.FindControl("lblNombre"), Label).Text
        Me.HiddenField2.Value = CType(e.Item.FindControl("lblDescripcion"), Label).Text
        'ddResponsable
        Me.HiddenField4.Value = CType(e.Item.FindControl("lblGrupoPadre"), Label).Text
        Try
            grdPGrupo.EditItemIndex = e.Item.ItemIndex
            BindData()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try

    End Sub

    Private Sub grdPGrupo_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPGrupo.CancelCommand
        'GlobalDef.VerIndiceFueradeRango(Me.grdPGrupo)
        'grdPGrupo.EditItemIndex = -1
        'grdPGrupo.SelectedIndex = -1
        'BindUser()
        'Obentemos el datatow el cuál se estaba editando
        GlobalDef.VerIndiceFueradeRango(grdPGrupo)
        If grdPGrupo.Items(grdPGrupo.EditItemIndex).Cells(1).Text = "&nbsp;" Then
            'Estaba en alta
            Session(SESSIONKEY_DATASOURCE).Tables("Grupos").DefaultView().Delete(Session(SESSIONKEY_DATASOURCE).Tables("Grupos").DefaultView().Count - 1)
        End If
        grdPGrupo.CurrentPageIndex = 0
        grdPGrupo.EditItemIndex = -1
        grdPGrupo.SelectedIndex = -1
        BindData()

    End Sub

    Private Sub grdPGrupo_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPGrupo.DeleteCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdPGrupo)
        hiddenPGrupo.Value = e.Item.ItemIndex
        Me.MsgBox1.ShowConfirmation("Está seguro de eliminar el grupo " + CType(e.Item.FindControl("lblNombre"), Label).Text, "Delete", True, False)
        'GlobalDef.VerIndiceFueradeRango(grdPGrupo)
        'hiddenPGrupo.Value = e.Item.ItemIndex
        'DeleteItem(hiddenPGrupo.Value)
    End Sub

    Private Sub grdPGrupo_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdPGrupo.PageIndexChanged
        Try
            grdPGrupo.CurrentPageIndex = e.NewPageIndex
            grdPGrupo.EditItemIndex = -1
            grdPGrupo.SelectedIndex = -1
            'BindUser()
            BindData()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub grdPGrupo_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPGrupo.UpdateCommand

        Dim str As String

        'Validar datos
        If Trim(CType(grdPGrupo.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text) = "" Then
            MsgBox1.ShowMessage("El dato Nombre, es requerido.")
            Exit Sub
        End If
        If Trim(CType(grdPGrupo.Items(e.Item.ItemIndex).FindControl("ddResponsable"), DropDownList).SelectedValue) = "" Then
            MsgBox1.ShowMessage("El dato Responsable, es requerido.")
            Exit Sub
        End If
        If Trim(CType(grdPGrupo.Items(e.Item.ItemIndex).FindControl("ddCliente"), DropDownList).SelectedValue) = "" Then
            MsgBox1.ShowMessage("El dato Cliente, es requerido.")
            Exit Sub
        End If

        If grdPGrupo.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" Then 'actualizar cambios
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else 'insertar
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
        End If
        If str <> String.Empty Then
            Me.MsgBox1.ShowMessage(str)
        End If

        MsgBox1.ShowMessage(str)

        'Refresca el DataSet
        grdPGrupo.EditItemIndex = -1
        CargaDS()

        'BindUser()

    End Sub

#End Region

#Region "Eventos MsgBox1 y btnAddNew"

    Private Sub MsgBox1_YesChoosed(ByVal sender As System.Object, ByVal Key As String) Handles MsgBox1.YesChoosed
        Select Case Key
            Case "Delete"
                DeleteItem(hiddenPGrupo.Value)
        End Select
    End Sub

    Private Sub btnAddPGrupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPGrupo.Click
        Try
            'Agregar_newrow()
            Agregar_Registro()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
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

    Private Sub grdPGrupo_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdPGrupo.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' BIND GRID DATA ITEMS: Handles HG1.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' Add events/alerts to grid items 
        '  Only applies to Item / Alt Items (ie: not header, footer rows)
        '  Adds Confirmation message to delete button
        '----------------------------------------------------------------------------------------------------------
        GlobalDef.VerIndiceFueradeRango(grdPGrupo)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'Add confirm message box to Delete button
            Dim l As LinkButton
            l = CType(e.Item.Cells(7).Controls(0), LinkButton)
            'l.Attributes.Add("onclick", "return getconfirm();")
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        'Encontrar los grupos que cumplan con la condición de busqueda

        CargaDS()
    End Sub

    Public Function ObtenerValueUsuario(ByVal intIde As Integer) As Integer
        'Programó:  IEJ
        'Parametros
        'IN
        '   intIde -->  Ide del responsable
        'OUT
        '   ObtenerValueUsuario --> Ide del responsable a seleccionar en el DDL

        Me.HiddenField3.Value = intIde

        If intIde = -1 Then
            'En caso de ser un nuevo registro regresará el value del primer registro
            Dim dv As DataView
            dv = ObtieneDataView("Usuarios")
            If dv.Count > 0 Then
                Return dv(0).Row.Item(0)
            Else
                Return 2
            End If
            dv = Nothing
        Else
            Return intIde
        End If

    End Function
    Public Function ObtenerValueGrupo(ByVal intIde As Integer) As Integer
        'Programó:  IEJ
        'Parametros
        'IN
        '   intIde -->  Ide del responsable
        'OUT
        '   ObtenerValueUsuario --> Ide del responsable a seleccionar en el DDL

        Me.HiddenField4.Value = intIde

        If intIde = -1 Then
            'En caso de ser un nuevo registro regresará el value del primer registro
            Dim dv As DataView
            dv = ObtieneDataView("Grupos")
            If dv.Count > 0 Then
                Return dv(0).Row.Item(0)
            Else
                Return 2
            End If
            dv = Nothing
        Else
            Return intIde
        End If

    End Function

    Public Function ObtenerValueCliente(ByVal intIde As Integer) As Integer
        'Programó:  IEJ
        'Parametros
        'IN
        '   intIde -->  Ide del cliente
        'OUT
        '   ObtenerValueUsuario --> Ide del cliente a seleccionar en el DDL

        Me.HiddenField5.Value = intIde

        If intIde = -1 Then
            'En caso de ser un nuevo registro regresará el value del primer registro
            Dim dv As DataView
            dv = ObtieneDataView("Clientes")
            If dv.Count > 0 Then
                Return dv(0).Row.Item(0)
            Else
                Return 1
            End If
            dv = Nothing
        Else
            Return intIde
        End If

    End Function

    Private Function DescripcionLog(ByVal Index As Long, ByVal op As String) As String

        DescripcionLog = String.Empty


        Select Case op
            Case OperacionesABC.operAlta
                DescripcionLog = "Creación del Grupo: " & CType(grdPGrupo.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim
            Case OperacionesABC.operCambio
                DescripcionLog = "Modificación del Grupo: " & CType(grdPGrupo.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim & " "
                If Me.HiddenField1.Value.Trim <> CType(grdPGrupo.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Nombre. "
                End If
                If Me.HiddenField2.Value.Trim <> CType(grdPGrupo.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Desc. "
                End If
                If Me.HiddenField3.Value.Trim <> CType(grdPGrupo.Items(Index).FindControl("ddResponsable"), DropDownList).SelectedValue Then
                    DescripcionLog = DescripcionLog & "En Responsable. "
                End If
                If Me.HiddenField5.Value.Trim <> CType(grdPGrupo.Items(Index).FindControl("ddCliente"), DropDownList).SelectedValue Then
                    DescripcionLog = DescripcionLog & "En Cliente. "
                End If
            Case OperacionesABC.operBaja
                DescripcionLog = "Eliminación del Grupo: " & CType(grdPGrupo.Items(Index).FindControl("lblNombre"), Label).Text
        End Select

    End Function

    
End Class