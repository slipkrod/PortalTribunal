Imports Portalv9.SvrUsr

Partial Public Class Wfrm_Modulos

    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Private dvAplicaciones As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then

            Me.lblTitle.Text = "Módulos"

            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If

            'Cargar los catálogo de aplicación y versión
            CargaDSCat()

            'Si no hay datos en los combos no cargará nada en el grid
            If Me.ddlApp.SelectedValue.ToString <> "" And Me.ddlVer.SelectedValue.ToString <> "" Then

                'Guardar el ID del primer registro de la aplicación y versión
                Me.hiddenAplicacionID.Value = ddlApp.SelectedValue.ToString
                Me.hiddenVersionID.Value = Me.ddlVer.SelectedValue.ToString

                'Llamar a la función para cargar el grid
                GetDataSource()

            End If


        End If

    End Sub

#Region "Rutinas privadas"

    Private Sub GetDataSource()

        Try

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
                            server.transfer("Wfrm_CambiaPwd.aspx?index=0")
                            Exit Try
                        End If
                    End If

                    'Cargar el grid
                    CargaDS(Me.hiddenVersionID.Value)

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

    Private Function CargaCatalogos(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As DataSet
        ' Cargar los catálogos de Aplicaciones y VersionAplicación ligados entre ellos
        ' Guardar el número de VersionAplicacion actual

        Dim sv As Core = New Core
        Dim dsAplicaciones As DataSet = Nothing

        Try
            dsAplicaciones = sv.ColAplicacionVersionPermiso(ptTicket, prRespuesta)
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

    Private Sub CargaDS(ByVal pintVersionAplicacionID As Integer)

        Dim rRespuesta As Respuesta = Nothing
        Dim ds As DataSet

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

        ds = CargaModulos(tTicket, pintVersionAplicacionID, rRespuesta)
        If ds.Tables.Count > 0 Then
            ds.Tables(0).TableName = "Modulo"
            Session(SESSIONKEY_DATASOURCE) = ds
            'Cargar el grid
            CargaDG(ds, False)
        ElseIf rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            MsgBox1.ShowMessage(rRespuesta.RespuestaToString)
        End If

    End Sub

    Private ReadOnly Property SESSIONKEY_DATASOURCE() As String
        Get
            Return Me.UniqueID & "_DataSource"
        End Get
    End Property

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

        'Carga catálogos de Aplicación y Version
        Cache("mdsAplicaciones") = CargaCatalogos(tTicket, rRespuesta)
        Cache("mdsAplicaciones").Tables(0).TableName = "Aplicacion"
        Cache("mdsAplicaciones").Tables(1).TableName = "Version"

        'Llenar los combos
        BindCombos()

    End Sub

    Private Function CargaModulos(ByRef ptTicket As IDTicket, ByVal pintVersionAplicacionID As Integer, ByRef prRespuesta As Respuesta) As DataSet
        Dim sv As Core = New Core
        Dim ds As DataSet = Nothing
        Try
            ds = sv.ColModulosReqVersionAplicacion(ptTicket, pintVersionAplicacionID, prRespuesta)
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

    Private Sub CargaDG(ByVal oDS As DataSet, ByVal blnExpandible As Boolean)
        'map the tables that are returned from the DB to the ones we will create in the dataset
        oDS.Tables(0).TableName = "Modulo"
        Cache("ds") = oDS
        BindData()
    End Sub

    Private Sub BindData()
        'bind the DataSet to the HierarGrid
        HG1.DataSource = Cache("ds")
        HG1.DataMember = "Modulo"
        HG1.DataBind()
        Me.btnAddAplicacion.Visible = HG1.CurrentPageIndex = HG1.PageCount - 1
    End Sub

    Private Sub BindCombos()

        'bind the DataSet to the HierarGrid
        With Me.ddlApp
            .DataSource = Cache("mdsAplicaciones")
            .DataMember = "Aplicacion"
            .DataTextField = "Nombre"
            .DataValueField = "AplicacionID"
            .DataBind()
            .SelectedIndex = 0
        End With

        'Guardar el ID de la aplicación
        Me.hiddenAplicacionID.Value = ddlApp.SelectedValue.ToString

        If ddlApp.SelectedValue.ToString <> "" Then
            'Llenar el combo de versiones filtrado por aplicación
            BindVersion(Me.hiddenAplicacionID.Value)
        End If

    End Sub

    Private Sub BindVersion(ByVal intAppID As Integer)

        Dim dv As DataView = New DataView(Cache("mdsAplicaciones").Tables(1))
        With dv
            .AllowDelete = False
            .AllowNew = False
            .AllowEdit = False
            .RowFilter = "AplicacionID=" & ddlApp.SelectedValue.ToString
        End With

        With Me.ddlVer
            .SelectedIndex = -1
            .DataSource = dv
            .DataTextField = "Descripcion"
            .DataValueField = "VersionAplicacionID"
            .DataBind()
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With

    End Sub

    Private Sub DeleteItem(ByVal strID As Integer)

        Try

            Dim str As String

            str = EjecutaAccion(strID, OperacionesABC.operBaja)

            If HG1.Items.Count = 1 AndAlso HG1.CurrentPageIndex > 0 Then
                HG1.CurrentPageIndex = HG1.CurrentPageIndex - 1
            End If

            'Actualizar grid
            CargaDS(Me.hiddenVersionID.Value)

        Catch exp As Exception
            MsgBox1.ShowMessage(exp.Message)
        End Try

    End Sub

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String

        Dim aModulo As Portalv9.SvrUsr.Modulo = Nothing
        Dim rRespuesta As New Portalv9.SvrUsr.Respuesta
        Dim sv As Portalv9.SvrUsr.Core
        Dim strMsg As String = String.Empty

        Try

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Portalv9.SvrUsr.Core
            aModulo = New Portalv9.SvrUsr.Modulo

            With aModulo
                If op <> 0 Then
                    .ModuloID = HG1.Items(Index).Cells(1).Text
                End If
                If op <> 1 Then
                    .Descripcion = CType(HG1.Items(Index).Cells(3).Controls(0), TextBox).Text
                    .NbModulo = CType(HG1.Items(Index).Cells(2).Controls(0), TextBox).Text
                    .VersionAplicacionID = ddlVer.SelectedValue.ToString
                End If
            End With

            sv.ABC_Modulo(tTicket, aModulo, op, rRespuesta)
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                strMsg = "Se ejecutó correctamente la operacion de cambio solicitada. "
            Else
                strMsg = "Ocurrió un error al intentar la operación solicitada: " & rRespuesta.RespuestaToString
            End If
            Return strMsg
        Catch ex As Exception
            Throw
        Finally
            sv = Nothing
            If Not aModulo Is Nothing Then
                aModulo = Nothing
            End If
            rRespuesta = Nothing
        End Try

    End Function

    Private Sub Agregar_Registro()

        Dim intTotalItemsGrid As Integer
        intTotalItemsGrid = HG1.Items.Count + HG1.PageSize * HG1.CurrentPageIndex

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim dv As DataView = Cache("ds").Tables("Modulo").DefaultView
        If dv.Count <= intTotalItemsGrid Then
            dv.AddNew()
        End If
        If HG1.Items.Count = HG1.PageSize Then
            'Debe agregar en la siguiente página, ésta ya se llenó
            HG1.CurrentPageIndex = HG1.CurrentPageIndex + 1
            HG1.EditItemIndex = 0
        Else
            HG1.EditItemIndex = HG1.Items.Count()
        End If

        With HG1
            .DataSource = dv
            .DataBind()
        End With

        dv = Nothing

    End Sub

    Private Sub btnAddAplicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAplicacion.Click
        Try
            'Si no estan vacios los combos
            If ddlApp.SelectedValue.ToString <> "" And ddlVer.SelectedValue.ToString <> "" Then
                Agregar_Registro()
            Else
                MsgBox1.ShowMessage("Para agregar una versión, debe dar de alta primero una aplicación y una versión.")
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub ddlApp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlApp.SelectedIndexChanged
        If ddlApp.SelectedValue.ToString <> "" Then

            'Guardar el ID de la aplicación seleccionada
            Me.hiddenAplicacionID.Value = ddlApp.SelectedValue.ToString

            'Cargar el combo de versiones en base a la aplicación seleccionada
            BindVersion(Me.hiddenAplicacionID.Value)

            'Guardar el ID de la aplicación seleccionada
            Me.hiddenVersionID.Value = ddlVer.SelectedValue.ToString

            'Cargar el grid en base a la aplicación seleccionada
            CargaDS(Me.hiddenVersionID.Value)

        End If
    End Sub

    Private Sub ddlVer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlVer.SelectedIndexChanged
        'Si no hay registros en el combo no carga los datos
        If ddlVer.SelectedValue.ToString <> "" Then
            Me.hiddenVersionID.Value = ddlVer.SelectedValue.ToString
            CargaDS(Me.hiddenVersionID.Value)
        End If
    End Sub

#End Region

#Region "Eventos del DataGrid"

    Private Sub HG1_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles HG1.EditCommand
        If e.Item.ItemType = ListItemType.Pager OrElse _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        Try
            HG1.EditItemIndex = e.Item.ItemIndex
            BindData()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub HG1_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles HG1.CancelCommand
        'Obentemos el datatow el cuál se estaba editando
        If HG1.Items(HG1.EditItemIndex).Cells(0).Text = "&nbsp;" OrElse _
            HG1.Items(HG1.EditItemIndex).Cells(0).Text = "" Then
            Session(SESSIONKEY_DATASOURCE).Tables("Permiso").DefaultView().Delete(Session(SESSIONKEY_DATASOURCE).Tables("Permiso").DefaultView().Count - 1)
        End If
        HG1.EditItemIndex = -1
        HG1.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub HG1_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles HG1.UpdateCommand

        Dim str As String

        'Validar que se haya capturado al menos el siguiente dato
        If CType(HG1.Items(e.Item.ItemIndex).Cells(2).Controls(0), TextBox).Text = "" Then
            MsgBox1.ShowMessage("El campo Nombre, es requerido.")
            Exit Sub
        End If

        ' Verificar si se trata de un cambio o alta
        If HG1.Items(e.Item.ItemIndex).Cells(1).Text <> "&nbsp;" Then
            'Cambio
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else
            'Alta
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
        End If

        MsgBox1.ShowMessage(str)

        HG1.EditItemIndex = -1

        ' Refresca el DataSet
        CargaDS(CInt(Me.hiddenVersionID.Value))

    End Sub

    Private Sub HG1_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles HG1.DeleteCommand
        DeleteItem(e.Item.ItemIndex)
    End Sub

    Private Sub HG1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles HG1.ItemDataBound
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
            l = CType(e.Item.Cells(5).Controls(0), LinkButton)
            l.Attributes.Add("onclick", "return getconfirm();")
        End If
    End Sub

    Private Sub HG1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles HG1.ItemCommand
        'Agrega una nueva versión en el caso en que la aplicación no contiene alguna.
        If e.CommandName = "Agregar" Then
            'Agregar la versión.
            '0) Guardar el registro actual para expandirlo al final (e.Item.ItemIndex)
            '1) Agrega un registro nuevo a la tabla VersionAplicacion del DataSet con el índice correcto (AplicacionID)
            Dim dr As DataRow = Cache("ds").Tables("ReqModulo").NewRow
            'Poner datos de <registro nuevo>
            dr("ModuloID") = CInt(HG1.Items(e.Item.ItemIndex).Cells(1).Text)
            'TODO: cambia por el dropdown
            dr("RequerimientoID") = 1
            dr("Tag") = "http://localhost"
            dr("Descripcion") = "Descripción no editable"
            Cache("ds").Tables("ReqModulo").Rows.InsertAt(dr, 0)

            'Aqui puede guardarse el data set en una variable de sesion desde antes para luego
            '   regresarla en caso de cancelación, o bien, recargar el cache del dataset.
            '2) Relaciona nuevamente el grid 
            With HG1
                .DataSource = Cache("ds")
                .DataBind()
                '3) Expandir el nodo correspondiente
                .RowExpanded(e.Item.ItemIndex) = True
            End With
            '4) Poner el grid en modo edición, pero no se puede porque el grid está en otro módulo DataGrid1.EditItemIndex = 0
        End If
    End Sub

    Private Sub HG1_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles HG1.PageIndexChanged
        Try
            HG1.CurrentPageIndex = e.NewPageIndex
            HG1.EditItemIndex = -1
            HG1.SelectedIndex = -1
            BindData()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

#End Region

#Region "  Comunes"

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