Imports Portalv9.SvrUsr

Partial Public Class Wfrm_ClientesProyecto

    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    'Private dvAplicaciones As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle.Text = "Clientes"
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
        Dim dsClientes As DataSet = Nothing
        'Dim nVersionAplicacionID As Integer = 0
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
            ''Dim intCliente As Integer = tTicket.ClienteID
            ''If intCliente > 0 Then

            dsClientes = sv.ColClientesProyectos(tTicket, rRespuesta)
            If Not dsClientes Is Nothing Then
                If dsClientes.Tables.Count > 0 Then

                    dsClientes.Tables(0).TableName = "Clientes"
                    Session(SESSIONKEY_DATASOURCE) = dsClientes

                    'Actualizar el cache del dataset completo
                    CargaDG(dsClientes, False)

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

    Private Sub CargaDG(ByVal oDS As DataSet, ByVal blnExpandible As Boolean)
        'map the tables that are returned from the DB to the ones we will create in the dataset
        oDS.Tables(0).TableName = "Clientes"
        Cache("dsClientes") = oDS        
        grdClienteP.CurrentPageIndex = 0
        grdClienteP.EditItemIndex = -1
        grdClienteP.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub BindData()
        '[IEJ 20081021] Aplicar Filtro BUSQUEDA
        Dim dv As New DataView
        dv = Cache("dsClientes").Tables(0).DefaultView
        ''dv.RowFilter = " (Nombre + ' ' + Descripcion) LIKE '%" & Me.txtBuscar.Text & "%'"
        'bind the DataSet to the HierarGrid
        grdClienteP.DataSource = dv
        grdClienteP.DataMember = "Clientes"
        grdClienteP.DataBind()
        Cache("dsClientes").tables(0).rows.count()
    End Sub

    Private Function Agregar_Registro()

        'Si el número de registros en el grid es igual al límite de registros por página
        If grdClienteP.Items.Count = grdClienteP.PageSize Then
            'Cambia de página
            grdClienteP.CurrentPageIndex = grdClienteP.PageCount - 1
            'Actualiza el grid
            BindData()
        End If

        Dim intTotalItemsGrid As Integer
        intTotalItemsGrid = grdClienteP.Items.Count + grdClienteP.PageSize * grdClienteP.CurrentPageIndex

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

        Dim dv As DataView = Cache("dsClientes").Tables("Clientes").DefaultView
        If dv.Count <= intTotalItemsGrid Then
            dv.AddNew()
        End If

        If grdClienteP.Items.Count = grdClienteP.PageSize Then
            'Debe agregar en la siguiente página, ésta ya se llenó
            grdClienteP.CurrentPageIndex = grdClienteP.CurrentPageIndex + 1
            grdClienteP.EditItemIndex = 0
        Else
            grdClienteP.EditItemIndex = grdClienteP.Items.Count()
        End If

        With grdClienteP
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
            If grdClienteP.Items.Count = 1 AndAlso grdClienteP.CurrentPageIndex > 0 Then
                grdClienteP.CurrentPageIndex = grdClienteP.CurrentPageIndex - 1
            End If
            CargaDS()
            grdClienteP.EditItemIndex = -1
            BindData()
            Me.MsgBox1.ShowMessage(str)
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String
        Dim aCliente As Cliente
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty

        Try

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Core

            '****************************************
            'Ver si esto va
            '****************************************
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

            If blnVal Then
                strMsg = "El nombre del Cliente """ & CType(grdClienteP.Items(Index).FindControl("TextNombre"), TextBox).Text & """ ya existe"
            Else
                aCliente = New Cliente
                Dim sDescripcion As String
                sDescripcion = DescripcionLog(Index, op)
                With aCliente
                    If op <> 0 Then 'No es Alta
                        .ClienteID = grdClienteP.Items(Index).Cells(0).Text
                    End If
                    If op <> 1 Then  'No poner valores para eliminar
                        .Nombre = CType(grdClienteP.Items(Index).FindControl("TextNombre"), TextBox).Text
                        .Descripcion = IIf(CType(grdClienteP.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim = "", " ", CType(grdClienteP.Items(Index).FindControl("TextDescripcion"), TextBox).Text)
                        .Direccion1 = IIf(CType(grdClienteP.Items(Index).FindControl("TextDireccion1"), TextBox).Text.Trim = "", " ", CType(grdClienteP.Items(Index).FindControl("TextDireccion1"), TextBox).Text)
                        .Direccion2 = IIf(CType(grdClienteP.Items(Index).FindControl("TextDireccion2"), TextBox).Text.Trim = "", " ", CType(grdClienteP.Items(Index).FindControl("TextDireccion2"), TextBox).Text)
                        .Telefono = IIf(CType(grdClienteP.Items(Index).FindControl("TextTelefono"), TextBox).Text.Trim = "", " ", CType(grdClienteP.Items(Index).FindControl("TextTelefono"), TextBox).Text)
                        .Email = IIf(CType(grdClienteP.Items(Index).FindControl("TextEmail"), TextBox).Text.Trim = "", " ", CType(grdClienteP.Items(Index).FindControl("TextEmail"), TextBox).Text)
                    End If
                End With

                sv.ABC_Cliente(tTicket, aCliente, op, rRespuesta)
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
            EjecutaAccion = strMsg
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
            aCliente = Nothing
            rRespuesta = Nothing
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
    Private Sub grdClienteP_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdClienteP.ItemCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdClienteP)
        hiddenCliente.Value = Trim(e.Item.Cells(0).Text)
    End Sub

    Private Sub grdClienteP_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdClienteP.EditCommand
        GlobalDef.VerIndiceFueradeRango(grdClienteP)
        If e.Item.ItemType = ListItemType.Pager Or _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        'Crea lista de datos para posteriormente describir los cambios realizados
        Me.HiddenField1.Value = CType(e.Item.FindControl("lblNombre"), Label).Text
        Me.HiddenField2.Value = CType(e.Item.FindControl("lblDescripcion"), Label).Text
        Me.HiddenField3.Value = CType(e.Item.FindControl("lblDireccion1"), Label).Text
        Me.HiddenField4.Value = CType(e.Item.FindControl("lblDireccion2"), Label).Text
        Me.HiddenField5.Value = CType(e.Item.FindControl("lblTelefono"), Label).Text
        Me.HiddenField6.Value = CType(e.Item.FindControl("lblEmail"), Label).Text

        Try
            grdClienteP.EditItemIndex = e.Item.ItemIndex
            BindData()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try

    End Sub

    Private Sub grdClienteP_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdClienteP.CancelCommand
        'Obentemos el datatow el cuál se estaba editando
        GlobalDef.VerIndiceFueradeRango(grdClienteP)
        If grdClienteP.Items(grdClienteP.EditItemIndex).Cells(1).Text = "&nbsp;" Then
            'Estaba en alta
            Session(SESSIONKEY_DATASOURCE).Tables("Clientes").DefaultView().Delete(Session(SESSIONKEY_DATASOURCE).Tables("Clientes").DefaultView().Count - 1)
        End If
        grdClienteP.CurrentPageIndex = 0
        grdClienteP.EditItemIndex = -1
        grdClienteP.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub grdClienteP_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdClienteP.DeleteCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdClienteP)
        hiddenCliente.Value = e.Item.ItemIndex
        Me.MsgBox1.ShowConfirmation("Está seguro de eliminar el cliente " + CType(e.Item.FindControl("lblNombre"), Label).Text, "Delete", True, False)
    End Sub

    Private Sub grdClienteP_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdClienteP.PageIndexChanged
        Try
            grdClienteP.CurrentPageIndex = e.NewPageIndex
            grdClienteP.EditItemIndex = -1
            grdClienteP.SelectedIndex = -1
            BindData()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub grdClienteP_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdClienteP.UpdateCommand

        Dim str As String

        'Validar datos
        If Trim(CType(grdClienteP.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text) = "" Then
            MsgBox1.ShowMessage("El dato Nombre, es requerido.")
            Exit Sub
        End If

        If grdClienteP.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" Then 'actualizar cambios
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else 'insertar
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
        End If
        If str <> String.Empty Then
            Me.MsgBox1.ShowMessage(str)
        End If

        MsgBox1.ShowMessage(str)

        'Refresca el DataSet
        grdClienteP.EditItemIndex = -1
        CargaDS()

    End Sub

#End Region

#Region "Eventos MsgBox1 y btnAddNew"

    Private Sub MsgBox1_YesChoosed(ByVal sender As System.Object, ByVal Key As String) Handles MsgBox1.YesChoosed
        Select Case Key
            Case "Delete"
                DeleteItem(Me.hiddenCliente.Value)
        End Select
    End Sub

    Private Sub btnAddAplicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAplicacion.Click
        Try
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

    Private Sub grdClienteP_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdClienteP.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' BIND GRID DATA ITEMS: Handles HG1.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' Add events/alerts to grid items 
        '  Only applies to Item / Alt Items (ie: not header, footer rows)
        '  Adds Confirmation message to delete button
        '----------------------------------------------------------------------------------------------------------
        GlobalDef.VerIndiceFueradeRango(grdClienteP)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'Add confirm message box to Delete button
            Dim l As LinkButton
            l = CType(e.Item.Cells(8).Controls(0), LinkButton)
            'l.Attributes.Add("onclick", "return getconfirm();")
        End If
    End Sub

    Private Function DescripcionLog(ByVal Index As Long, ByVal op As String) As String

        DescripcionLog = String.Empty

        Select Case op
            Case OperacionesABC.operAlta
                DescripcionLog = "Creación del Cliente: " & CType(grdClienteP.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim
            Case OperacionesABC.operCambio
                DescripcionLog = "Modificación del Cliente: " & CType(grdClienteP.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim & " "
                If Me.HiddenField1.Value.Trim <> CType(grdClienteP.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Nombre. "
                End If
                If Me.HiddenField2.Value.Trim <> CType(grdClienteP.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Desc. "
                End If
                If Me.HiddenField3.Value.Trim <> CType(grdClienteP.Items(Index).FindControl("TextDireccion1"), TextBox).Text Then
                    DescripcionLog = DescripcionLog & "En Dir1. "
                End If
                If Me.HiddenField4.Value.Trim <> CType(grdClienteP.Items(Index).FindControl("TextDireccion2"), TextBox).Text Then
                    DescripcionLog = DescripcionLog & "En Dir2. "
                End If
                If Me.HiddenField5.Value.Trim <> CType(grdClienteP.Items(Index).FindControl("TextTelefono"), TextBox).Text Then
                    DescripcionLog = DescripcionLog & "En Tel. "
                End If
                If Me.HiddenField5.Value.Trim <> CType(grdClienteP.Items(Index).FindControl("TextEmail"), TextBox).Text Then
                    DescripcionLog = DescripcionLog & "En Email. "
                End If

            Case OperacionesABC.operBaja
                DescripcionLog = "Eliminación del Cliente: " & CType(grdClienteP.Items(Index).FindControl("lblNombre"), Label).Text
        End Select

    End Function

End Class