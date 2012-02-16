Imports Portalv9.SvrUsr

Partial Public Class Wfrm_ProyectosCli

    Inherits System.Web.UI.Page
    Public tTicket As IDTicket

    Private Sub Wfrm_ProyectosCli_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then

            lblTitle.Text = "Proyectos"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then
                LogOff()
                Exit Sub
            End If

            'Cargar combo de clientes
            CargaDSCat()

            'Si el combo no tiene datos no cargará datos
            If ddlCli.SelectedValue.ToString <> "" Then
                'Guardar el ID del cliente seleccionado
                Me.hiddenClienteID.Value = ddlCli.SelectedValue.ToString
                'LLamar a la función para cargar el grid 
                GetDataSource()
            End If
        End If
    End Sub

    Private Sub CargaDSCat()

        Dim rRespuesta As Respuesta = Nothing
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim strRes As String = Session("DebeCambiarPwd")
        If strRes <> String.Empty Then
            If CType(strRes, Boolean) Then
                server.transfer("Wfrm_CambiaPwd.aspx?index=0")
                'TODO: Asegurarse de que sale de la página
            End If
        ElseIf Not Session("REDIRECT_PAG") Is Nothing Then
            Dim strPag As String = Session("REDIRECT_PAG")
            Session.Remove("REDIRECT_PAG")
            server.transfer(strPag)
        End If

        'Carga catálogos de Clientes
        Cache("mdsClientes") = CargaCatalogos(tTicket, rRespuesta)
        Cache("mdsClientes").Tables(0).TableName = "Cliente"

        'Llenar combo
        BindCombos()

    End Sub

    Private Sub BindCombos()
        'bind the DataSet to the HierarGrid
        With Me.ddlCli
            .DataSource = Cache("mdsClientes")
            .DataMember = "Cliente"
            .DataTextField = "Nombre"
            .DataValueField = "ClienteID"
            .DataBind()
            .SelectedIndex = 0
        End With
    End Sub

    Private Function CargaCatalogos(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As DataSet
        ' Cargar los catálogos de Aplicaciones y VersionAplicación ligados entre ellos
        ' Guardar el número de VersionAplicacion actual
        Dim sv As Core = New Core
        Dim dsAplicaciones As DataSet
        Try
            dsAplicaciones = sv.ColClientes(ptTicket, prRespuesta)
            If prRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                Throw New Exception(prRespuesta.DescripcionRespuesta)
            End If
            Return dsAplicaciones
        Catch ex As Exception
            Throw
        Finally
            dsAplicaciones = Nothing
            sv = Nothing
        End Try

    End Function

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
                CargaDS(CInt(Me.hiddenClienteID.Value))
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.ToString)
        End Try
    End Sub

    ' ''Private Sub GetDataSource()
    ' ''    'Introducir aquí el código de usuario para inicializar la página
    ' ''    Dim strResult As String
    ' ''    Try
    ' ''        strResult = ObtieneResultado()
    ' ''        If strResult <> String.Empty Then
    ' ''            MsgBox1.ShowMessage(strResult)
    ' ''        End If
    ' ''        If Not IsPostBack Then
    ' ''            Dim strRes As String = Session("DebeCambiarPwd")
    ' ''            If strRes <> String.Empty Then
    ' ''                If CType(strRes, Boolean) = True Then
    ' ''                    server.transfer("Wfrm_CambiaPwd.aspx?index=0")
    ' ''                    Exit Try
    ' ''                End If
    ' ''            End If
    ' ''            CargaDS(Me.hiddenClienteID.Value)
    ' ''        End If
    ' ''    Catch ex As Exception
    ' ''        MsgBox1.ShowMessage(ex.ToString)
    ' ''    End Try
    ' ''End Sub

    Private ReadOnly Property SESSIONKEY_DATASOURCE() As String
        Get
            Return Me.UniqueID & "_DataSource"
        End Get
    End Property

    Private Sub CargaDS(ByVal pintClienteID As Integer)

        'Introducir aquí el código de usuario para inicializar la página
        Dim rRespuesta As Respuesta = Nothing
        Dim dsProys As DataSet = Nothing
        ''Dim nVersionAplicacionID As Integer = 0
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
            ''Dim intGrupoAdmin As Integer = tTicket.GrupoAdminID
            ''If intGrupoAdmin > 0 Then
            ''tTicket, intGrupoAdmin, 

            dsProys = sv.ColProyectos(pintClienteID, rRespuesta)
            If Not dsProys Is Nothing Then
                If dsProys.Tables.Count > 0 Then

                    dsProys.Tables(0).TableName = "Proyectos"
                    Session(SESSIONKEY_DATASOURCE) = dsProys

                    'Actualizar el cache del dataset completo
                    CargaDG(dsProys, False)

                ElseIf rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    Throw New Exception(rRespuesta.RespuestaToString)
                End If
            Else
                Throw New Exception(rRespuesta.RespuestaToString)
            End If
            ''End If
            sv = Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    ''Private Sub CargaDS(ByVal pintClienteID As Integer)
    ''    'Introducir aquí el código de usuario para inicializar la página
    ''    Dim rRespuesta As Respuesta = Nothing
    ''    Dim ds As DataSet

    ''    Dim strRes As String = Session("DebeCambiarPwd")
    ''    If strRes <> String.Empty Then
    ''        If CType(strRes, Boolean) Then
    ''            server.transfer("Wfrm_CambiaPwd.aspx?index=0")
    ''            'TODO: Asegurarse de que sale de la página
    ''        End If
    ''    ElseIf Not Session("REDIRECT_PAG") Is Nothing Then
    ''        Dim strPag As String = Session("REDIRECT_PAG")
    ''        Session.Remove("REDIRECT_PAG")
    ''        server.transfer(strPag)
    ''    End If

    ''    ds = CargaProyecto(pintClienteID, rRespuesta)
    ''    If ds.Tables.Count > 0 Then
    ''        ds.Tables(0).TableName = "Proyecto"
    ''        Session(SESSIONKEY_DATASOURCE) = ds
    ''        CargaDG(ds, False)
    ''        'Actualizar el cache del dataset completo
    ''    ElseIf rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
    ''        Response.Write(rRespuesta.RespuestaToString)
    ''    End If

    ''    tTicket = Nothing

    ''End Sub

    Private Sub CargaDG(ByVal oDS As DataSet, ByVal blnExpandible As Boolean)
        'map the tables that are returned from the DB to the ones we will create in the dataset
        oDS.Tables(0).TableName = "Proyectos"
        Cache("dsProys") = oDS
        grdProy.CurrentPageIndex = 0
        grdProy.EditItemIndex = -1
        grdProy.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub BindData()
        '[IEJ 20081021] Aplicar Filtro BUSQUEDA
        Dim dv As New DataView
        dv = Cache("dsProys").Tables(0).DefaultView
        ''dv.RowFilter = " (Nombre + ' ' + Descripcion) LIKE '%" & Me.txtBuscar.Text & "%'"
        'bind the DataSet to the HierarGrid
        grdProy.DataSource = dv
        grdProy.DataMember = "Proyectos"
        grdProy.DataBind()
        Cache("dsProys").tables(0).rows.count()
    End Sub

    Private Function Agregar_Registro()

        'Si el número de registros en el grid es igual al límite de registros por página
        If grdProy.Items.Count = grdProy.PageSize Then
            'Cambia de página
            grdProy.CurrentPageIndex = grdProy.PageCount - 1
            'Actualiza el grid
            BindData()
        End If

        Dim intTotalItemsGrid As Integer
        intTotalItemsGrid = grdProy.Items.Count + grdProy.PageSize * grdProy.CurrentPageIndex

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

        Dim dv As DataView = Cache("dsProys").Tables("Proyectos").DefaultView
        If dv.Count <= intTotalItemsGrid Then
            dv.AddNew()
        End If

        If grdProy.Items.Count = grdProy.PageSize Then
            'Debe agregar en la siguiente página, ésta ya se llenó
            grdProy.CurrentPageIndex = grdProy.CurrentPageIndex + 1
            grdProy.EditItemIndex = 0
        Else
            grdProy.EditItemIndex = grdProy.Items.Count()
        End If

        With grdProy
            .DataSource = dv
            .DataBind()
        End With

        dv = Nothing
        Return Nothing
    End Function

    Private Sub DeleteItem(ByVal strID As Integer)
        Try
            Dim str As String
            str = EjecutaAccion(strID, OperacionesABC.operBaja)
            If grdProy.Items.Count = 1 AndAlso grdProy.CurrentPageIndex > 0 Then
                grdProy.CurrentPageIndex = grdProy.CurrentPageIndex - 1
            End If
            CargaDS(CInt(Me.hiddenClienteID.Value))
            grdProy.EditItemIndex = -1
            BindData()
            Me.MsgBox1.ShowMessage(str)
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String
        Dim aProyecto As Proyecto
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty

        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Core

            '****************************************************************************'
            '*** Verificar si se habilita la validación de si ya existe la aplicación ***'
            '****************************************************************************'
            'Valida si que el nombre no este repetido
            Dim blnVal As Boolean = False
            ''If op = 0 Then
            ''    Dim dsVal As New DataSet
            ''    dsVal = sv.BuscaXNombreTabla(tTicket, rRespuesta, "G", CType(grdPGrupo.Items(Index).FindControl("TextNombre"), TextBox).Text)
            ''    If dsVal.Tables(0).Rows.Count > 0 Then
            ''        blnVal = True
            ''    End If
            ''    dsVal = Nothing
            ''End If
            '****************************************************************************'

            If blnVal Then
                strMsg = "El nombre del Proyecto """ & CType(grdProy.Items(Index).FindControl("TextNombre"), TextBox).Text & """ ya existe"
            Else
                aProyecto = New Proyecto
                Dim sDescripcion As String
                sDescripcion = DescripcionLog(Index, op)
                With aProyecto
                    If op <> 0 Then 'No es Alta
                        .ProyectoID = grdProy.Items(Index).Cells(0).Text
                    End If
                    If op <> 1 Then  'No poner valores para eliminar
                        .ClienteID = Me.hiddenClienteID.Value
                        .Siglas = CType(grdProy.Items(Index).FindControl("TextSiglas"), TextBox).Text
                        .Nombre = CType(grdProy.Items(Index).FindControl("TextNombre"), TextBox).Text
                        .Descripcion = IIf(CType(grdProy.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim = "", " ", CType(grdProy.Items(Index).FindControl("TextDescripcion"), TextBox).Text)
                    End If
                End With

                sv.ABC_Proyecto(tTicket, aProyecto, op, rRespuesta)
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
                    'valida si es una baja
                    If op = 1 Then
                        strMsg = "El registro no puede eliminarse ya que esta siendo utilizado en otra parte del sistema"
                    End If
                End If
            End If
            Return strMsg
        Catch ex As Exception
            'valida si es una baja
            If op = 1 Then
                strMsg = "El registro no puede eliminarse ya que esta siendo utilizado en otra parte del sistema"
            Else
                strMsg = ex.Message
            End If
            Throw
        Finally
            sv = Nothing
            aProyecto = Nothing
            rRespuesta = Nothing
        End Try

    End Function

    ''Private Function ObtieneDataView(ByVal Catalogo As String) As DataView
    ''    Dim sv As New Core
    ''    Dim dv As DataView = Nothing
    ''    Dim ds As DataSet = Nothing
    ''    Dim rRespuesta As Respuesta = Nothing

    ''    Try
    ''        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
    ''        Dim intGrupoAdmin As Integer = tTicket.GrupoAdminID
    ''        Select Case Catalogo
    ''            Case "Grupos"
    ''                ds = sv.ColGrupoAdminHijos(tTicket, intGrupoAdmin, rRespuesta)
    ''            Case "Usuarios"
    ''                ds = sv.ColResponsableAdministrar(tTicket, rRespuesta)
    ''            Case "Clientes"
    ''                ds = sv.ColClientes(tTicket, rRespuesta)
    ''        End Select
    ''        If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
    ''            dv = ds.Tables(0).DefaultView
    ''        End If
    ''    Catch exp As Exception
    ''        Me.MsgBox1.ShowMessage(exp.Message)
    ''    End Try
    ''    sv = Nothing
    ''    Return dv
    ''End Function

    Private Function CargaClientes(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As DataSet
        Dim sv As Core = New Core
        Dim ds As DataSet
        Try
            ds = sv.ColClientesProyectos(ptTicket, prRespuesta)
            If prRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                Throw New Exception(prRespuesta.DescripcionRespuesta)
            End If
            Return ds
        Catch ex As Exception
            Throw
        Finally
            ds = Nothing
            sv = Nothing
        End Try
    End Function

#End Region

#Region "Métodos públicos"

    ''Public Function ObtenerUsuarios() As DataView
    ''    'ICollection
    ''    Return ObtieneDataView("Usuarios")
    ''End Function

    ''Public Function ObtenerGrupos() As DataView
    ''    Return ObtieneDataView("Grupos")
    ''End Function

    ''Public Function ObtenerClientes() As DataView
    ''    Return ObtieneDataView("Clientes")
    ''End Function

#End Region

#Region "Eventos del DataGrid"
    Private Sub grdProy_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProy.ItemCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdProy)
        hiddenPProy.Value = Trim(e.Item.Cells(0).Text)
    End Sub

    Private Sub grdProy_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProy.EditCommand
        GlobalDef.VerIndiceFueradeRango(grdProy)
        If e.Item.ItemType = ListItemType.Pager Or _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        'Crea lista de datos para posteriormente describir los cambios realizados
        Me.HiddenField1.Value = CType(e.Item.FindControl("lblSiglas"), Label).Text
        Me.HiddenField2.Value = CType(e.Item.FindControl("lblNombre"), Label).Text
        Me.HiddenField3.Value = CType(e.Item.FindControl("lblDescripcion"), Label).Text
        Try
            grdProy.EditItemIndex = e.Item.ItemIndex
            BindData()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub grdProy_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProy.CancelCommand
        'Obentemos el datatow el cuál se estaba editando
        GlobalDef.VerIndiceFueradeRango(grdProy)
        If grdProy.Items(grdProy.EditItemIndex).Cells(1).Text = "&nbsp;" Then
            'Estaba en alta
            Session(SESSIONKEY_DATASOURCE).Tables("Proyectos").DefaultView().Delete(Session(SESSIONKEY_DATASOURCE).Tables("Proyectos").DefaultView().Count - 1)
        End If
        grdProy.CurrentPageIndex = 0
        grdProy.EditItemIndex = -1
        grdProy.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub grdProy_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProy.DeleteCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdProy)
        hiddenPProy.Value = e.Item.ItemIndex
        Me.MsgBox1.ShowConfirmation("Está seguro de eliminar el proyecto " + CType(e.Item.FindControl("lblSiglas"), Label).Text + " - " + CType(e.Item.FindControl("lblNombre"), Label).Text, "Delete", True, False)
    End Sub

    Private Sub grdProy_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdProy.PageIndexChanged
        Try
            grdProy.CurrentPageIndex = e.NewPageIndex
            grdProy.EditItemIndex = -1
            grdProy.SelectedIndex = -1
            BindData()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub grdProy_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProy.UpdateCommand

        Dim str As String

        'Validar datos
        If Trim(CType(grdProy.Items(e.Item.ItemIndex).FindControl("TextSiglas"), TextBox).Text) = "" Then
            MsgBox1.ShowMessage("El dato Siglas, es requerido.")
            Exit Sub
        End If
        If Trim(CType(grdProy.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text) = "" Then
            MsgBox1.ShowMessage("El dato Nombre, es requerido.")
            Exit Sub
        End If

        If grdProy.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" Then 'actualizar cambios
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else 'insertar
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
        End If
        If str <> String.Empty Then
            Me.MsgBox1.ShowMessage(str)
        End If

        MsgBox1.ShowMessage(str)

        'Refresca el DataSet
        grdProy.EditItemIndex = -1
        CargaDS(CInt(Me.hiddenClienteID.Value))

    End Sub

#End Region

#Region "Eventos MsgBox1 y btnAddNew"

    Private Sub MsgBox1_YesChoosed(ByVal sender As System.Object, ByVal Key As String) Handles MsgBox1.YesChoosed
        Select Case Key
            Case "Delete"
                DeleteItem(Me.hiddenPProy.Value)
        End Select
    End Sub

    Private Sub btnAddProy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProy.Click
        Try
            'Si el combo tiene datos permite agregar el registro
            If ddlCli.SelectedValue.ToString <> "" Then
                Agregar_Registro()
            Else
                MsgBox1.ShowMessage("Para agregar un proyecto, debe dar de alta primero a un cliente.")
            End If
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

    Private Sub grdProy_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdProy.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' BIND GRID DATA ITEMS: Handles HG1.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' Add events/alerts to grid items 
        '  Only applies to Item / Alt Items (ie: not header, footer rows)
        '  Adds Confirmation message to delete button
        '----------------------------------------------------------------------------------------------------------
        GlobalDef.VerIndiceFueradeRango(grdProy)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'Add confirm message box to Delete button
            Dim l As LinkButton
            l = CType(e.Item.Cells(5).Controls(0), LinkButton)
            'l.Attributes.Add("onclick", "return getconfirm();")
        End If
    End Sub

    Private Function DescripcionLog(ByVal Index As Long, ByVal op As String) As String
        DescripcionLog = String.Empty
        Select Case op
            Case OperacionesABC.operAlta
                DescripcionLog = "Creación del Proyecto: " & CType(grdProy.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim
            Case OperacionesABC.operCambio
                DescripcionLog = "Modificación del Proyecto: " & CType(grdProy.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim & " "
                If Me.HiddenField1.Value.Trim <> CType(grdProy.Items(Index).FindControl("TextSiglas"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Siglas. "
                End If
                If Me.HiddenField2.Value.Trim <> CType(grdProy.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Nombre "
                End If
                If Me.HiddenField3.Value.Trim <> CType(grdProy.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Desc. "
                End If
            Case OperacionesABC.operBaja
                DescripcionLog = "Eliminación del Proyecto: " & CType(grdProy.Items(Index).FindControl("lblSiglas"), Label).Text & " - " & CType(grdProy.Items(Index).FindControl("lblNombre"), Label).Text
        End Select

    End Function

    Private Sub ddlCli_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCli.SelectedIndexChanged
        'Si el combo no tiene datos no carga el grid
        If ddlCli.SelectedValue.ToString <> "" Then
            Me.hiddenClienteID.Value = ddlCli.SelectedValue.ToString
            CargaDS(CInt(Me.hiddenClienteID.Value))
        End If
    End Sub


End Class