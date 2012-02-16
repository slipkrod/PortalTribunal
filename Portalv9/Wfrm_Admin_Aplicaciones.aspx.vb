Imports Portalv9.SvrUsr

Partial Public Class Wfrm_Aplicaciones
    Inherits System.Web.UI.Page

    Public tTicket As IDTicket
    Private dvAplicaciones As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle.Text = "Aplicaciones"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then
                LogOff()
                Exit Sub
            End If
            'Llenar grid
            GetDataSource()
        End If
    End Sub

#Region "Rutinas privadas"

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
        Dim dsApp As DataSet = Nothing
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
            'Dim intAppAdmin As Integer = tTicket.VersionAplicacionID
            'If intAppAdmin > 0 Then

            dsApp = sv.ColAplicacionVersionPermiso(tTicket, rRespuesta)
            If Not dsApp Is Nothing Then
                If dsApp.Tables.Count > 0 Then

                    dsApp.Tables(0).TableName = "Aplicaciones"
                    Session(SESSIONKEY_DATASOURCE) = dsApp

                    'Actualizar el cache del dataset completo
                    CargaDG(dsApp, False)

                ElseIf rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    Throw New Exception(rRespuesta.RespuestaToString)
                End If
            Else
                Throw New Exception(rRespuesta.RespuestaToString)
            End If
            'End If
            sv = Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Private Sub CargaDG(ByVal oDS As DataSet, ByVal blnExpandible As Boolean)
        'map the tables that are returned from the DB to the ones we will create in the dataset
        oDS.Tables(0).TableName = "Aplicaciones"
        Cache("dsApp") = oDS
        grdApp.CurrentPageIndex = 0
        grdApp.EditItemIndex = -1
        grdApp.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub BindData()
        '[IEJ 20081021] Aplicar Filtro BUSQUEDA
        Dim dv As New DataView
        dv = Cache("dsApp").Tables(0).DefaultView
        'dv.RowFilter = " (Nombre + ' ' + Descripcion) LIKE '%" & Me.txtBuscar.Text & "%'"
        'bind the DataSet to the HierarGrid
        grdApp.DataSource = dv
        grdApp.DataMember = "Aplicaciones"
        grdApp.DataBind()
        Cache("dsApp").tables(0).rows.count()
    End Sub

    Private Function Agregar_Registro()

        'Si el número de registros en el grid es igual al límite de registros por página
        If grdApp.Items.Count = grdApp.PageSize Then
            'Cambia de página
            grdApp.CurrentPageIndex = grdApp.PageCount - 1
            'Actualiza el grid
            BindData()
        End If

        Dim intTotalItemsGrid As Integer
        intTotalItemsGrid = grdApp.Items.Count + grdApp.PageSize * grdApp.CurrentPageIndex

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

        Dim dv As DataView = Cache("dsApp").Tables("Aplicaciones").DefaultView
        If dv.Count <= intTotalItemsGrid Then
            dv.AddNew()
        End If

        If grdApp.Items.Count = grdApp.PageSize Then
            'Debe agregar en la siguiente página, ésta ya se llenó
            grdApp.CurrentPageIndex = grdApp.CurrentPageIndex + 1
            grdApp.EditItemIndex = 0
        Else
            grdApp.EditItemIndex = grdApp.Items.Count()
        End If

        With grdApp
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
            If grdApp.Items.Count = 1 AndAlso grdApp.CurrentPageIndex > 0 Then
                grdApp.CurrentPageIndex = grdApp.CurrentPageIndex - 1
            End If
            CargaDS()
            grdApp.EditItemIndex = -1
            BindData()
            Me.MsgBox1.ShowMessage(str)
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String
        Dim aAplicacion As Aplicacion
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
            ' ''If op = 0 Then
            ' ''    Dim dsVal As New DataSet
            ' ''    dsVal = sv.BuscaXNombreTabla(tTicket, rRespuesta, "G", CType(grdPGrupo.Items(Index).FindControl("TextNombre"), TextBox).Text)
            ' ''    If dsVal.Tables(0).Rows.Count > 0 Then
            ' ''        blnVal = True
            ' ''    End If
            ' ''    dsVal = Nothing
            ' ''End If
            '****************************************************************************'

            If blnVal Then
                strMsg = "El nombre de la Aplicación """ & CType(grdApp.Items(Index).FindControl("TextNombre"), TextBox).Text & """ ya existe"
            Else
                aAplicacion = New Aplicacion
                Dim sDescripcion As String
                sDescripcion = DescripcionLog(Index, op)
                With aAplicacion
                    If op <> 0 Then 'No es Alta
                        .AplicacionID = grdApp.Items(Index).Cells(0).Text
                    End If
                    If op <> 1 Then  'No poner valores para eliminar
                        .Nombre = CType(grdApp.Items(Index).FindControl("TextNombre"), TextBox).Text
                        .Descripcion = IIf(CType(grdApp.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim = "", " ", CType(grdApp.Items(Index).FindControl("TextDescripcion"), TextBox).Text)
                    End If
                End With

                sv.ABC_Aplicacion(tTicket, aAplicacion, op, rRespuesta)
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
                    If op = 1 Then
                        strMsg = "El registro no puede eliminarse ya que esta siendo utilizado en otra parte del sistema"
                    Else
                    End If
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
            aAplicacion = Nothing
            rRespuesta = Nothing
        End Try

    End Function

#End Region

#Region "Eventos del DataGrid"

    Private Sub grdApp_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdApp.ItemCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdApp)
        hiddenApp.Value = Trim(e.Item.Cells(0).Text)
    End Sub

    Private Sub grdApp_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdApp.EditCommand
        GlobalDef.VerIndiceFueradeRango(grdApp)
        If e.Item.ItemType = ListItemType.Pager Or _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        'Crea lista de datos para posteriormente describir los cambios realizados
        Me.HiddenField1.Value = CType(e.Item.FindControl("lblNombre"), Label).Text
        Me.HiddenField2.Value = CType(e.Item.FindControl("lblDescripcion"), Label).Text
        ' ''ddResponsable
        ''Me.HiddenField4.Value = CType(e.Item.FindControl("lblGrupoPadre"), Label).Text
        Try
            grdApp.EditItemIndex = e.Item.ItemIndex
            BindData()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try

    End Sub

    Private Sub grdApp_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdApp.CancelCommand
        'Obentemos el datatow el cuál se estaba editando
        GlobalDef.VerIndiceFueradeRango(grdApp)
        If grdApp.Items(grdApp.EditItemIndex).Cells(1).Text = "&nbsp;" Then
            'Estaba en alta
            Session(SESSIONKEY_DATASOURCE).Tables("Aplicaciones").DefaultView().Delete(Session(SESSIONKEY_DATASOURCE).Tables("Aplicaciones").DefaultView().Count - 1)
        End If
        grdApp.CurrentPageIndex = 0
        grdApp.EditItemIndex = -1
        grdApp.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub grdApp_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdApp.DeleteCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdApp)
        hiddenApp.Value = e.Item.ItemIndex
        Me.MsgBox1.ShowConfirmation("Está seguro de eliminar la Aplicación " + CType(e.Item.FindControl("lblNombre"), Label).Text, "Delete", True, False)
    End Sub

    Private Sub grdApp_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdApp.PageIndexChanged
        Try
            grdApp.CurrentPageIndex = e.NewPageIndex
            grdApp.EditItemIndex = -1
            grdApp.SelectedIndex = -1
            BindData()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub grdApp_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdApp.UpdateCommand

        Dim str As String

        'Validar datos
        If Trim(CType(grdApp.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text) = "" Then
            MsgBox1.ShowMessage("El dato Nombre, es requerido.")
            Exit Sub
        End If

        If grdApp.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" Then 'actualizar cambios
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else 'insertar
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
        End If
        If str <> String.Empty Then
            Me.MsgBox1.ShowMessage(str)
        End If

        MsgBox1.ShowMessage(str)
        'Refresca el DataSet
        grdApp.EditItemIndex = -1
        CargaDS()
    End Sub

#End Region

#Region "Eventos MsgBox1 y btnAddNew"

    Private Sub MsgBox1_YesChoosed(ByVal sender As System.Object, ByVal Key As String) Handles MsgBox1.YesChoosed
        Select Case Key
            Case "Delete"
                DeleteItem(hiddenApp.Value)
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

    Private Sub grdApp_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdApp.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' BIND GRID DATA ITEMS: Handles HG1.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' Add events/alerts to grid items 
        '  Only applies to Item / Alt Items (ie: not header, footer rows)
        '  Adds Confirmation message to delete button
        '----------------------------------------------------------------------------------------------------------
        GlobalDef.VerIndiceFueradeRango(grdApp)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'Add confirm message box to Delete button
            Dim l As LinkButton
            l = CType(e.Item.Cells(4).Controls(0), LinkButton)
            'l.Attributes.Add("onclick", "return getconfirm();")
        End If
    End Sub

    ''Public Function ObtenerValueCliente(ByVal intIde As Integer) As Integer
    ''    'Programó:  IEJ
    ''    'Parametros
    ''    'IN
    ''    '   intIde -->  Ide del cliente
    ''    'OUT
    ''    '   ObtenerValueUsuario --> Ide del cliente a seleccionar en el DDL

    ''    Me.HiddenField5.Value = intIde

    ''    If intIde = -1 Then
    ''        'En caso de ser un nuevo registro regresará el value del primer registro
    ''        Dim dv As DataView
    ''        dv = ObtieneDataView("Clientes")
    ''        If dv.Count > 0 Then
    ''            Return dv(0).Row.Item(0)
    ''        Else
    ''            Return 1
    ''        End If
    ''        dv = Nothing
    ''    Else
    ''        Return intIde
    ''    End If

    ''End Function

    Private Function DescripcionLog(ByVal Index As Long, ByVal op As String) As String

        DescripcionLog = String.Empty

        Select Case op
            Case OperacionesABC.operAlta
                DescripcionLog = "Creación de la Aplicación: " & CType(grdApp.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim
            Case OperacionesABC.operCambio
                DescripcionLog = "Modificación de la Aplicación: " & CType(grdApp.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim & " "
                If Me.HiddenField1.Value.Trim <> CType(grdApp.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Nombre. "
                End If
                If Me.HiddenField2.Value.Trim <> CType(grdApp.Items(Index).FindControl("TextDescripcion"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Desc. "
                End If
            Case OperacionesABC.operBaja
                DescripcionLog = "Eliminación de la Aplicación: " & CType(grdApp.Items(Index).FindControl("lblNombre"), Label).Text
        End Select

    End Function


End Class