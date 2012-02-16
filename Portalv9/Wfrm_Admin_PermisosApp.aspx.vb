Imports Portalv9.SvrUsr

Partial Public Class PermisosApp

    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Private dvPermisosApp As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle.Text = "Permisos"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then
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

    Private Sub BindCombos()

        'Llenar el combo de Aplicaciones
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
            .RowFilter = "AplicacionID=" & intAppID
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

    Private ReadOnly Property SESSIONKEY_DATASOURCE() As String
        Get
            Return Me.UniqueID & "_DataSource"
        End Get
    End Property

    Private Sub SalesList_DataBind(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.DataBinding

        'if an InvalidCastException occurs in either of the next two lines, 
        'please make sure that you've set the TemplateDataMode to Table (because you want nested grids)
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)

        If (Not (TypeOf dgi.DataItem Is DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If

        Dim ds As DataSet = CType(dgi.DataItem, DataSet)
        DG1.DataSource = ds
        Session(SESSIONKEY_DATASOURCE) = ds

        BindData()

        ' Guardar el valor de la VersionAplicaciónID y no perderlo!
        Me.hiddenAplicacionID.Value = DG1.Items(0).Cells(5).Text

    End Sub

    Private Sub BindData()
        ''bind the DataSet to the HierarGrid
        DG1.DataSource = Cache("dsPermiso")
        DG1.DataMember = "Permiso"
        DG1.DataBind()
        Cache("dsPermiso").tables(0).rows.count()
    End Sub

    Private Sub DG1_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DG1.EditCommand
        If e.Item.ItemType = ListItemType.Pager OrElse _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        Try
            DG1.EditItemIndex = e.Item.ItemIndex
            BindData()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub DG1_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DG1.CancelCommand
        'Obentemos el datatow el cuál se estaba editando
        If DG1.Items(DG1.EditItemIndex).Cells(0).Text = "&nbsp;" OrElse _
            DG1.Items(DG1.EditItemIndex).Cells(0).Text = "" Then
            Session(SESSIONKEY_DATASOURCE).Tables("Permiso").DefaultView().Delete(Session(SESSIONKEY_DATASOURCE).Tables("Permiso").DefaultView().Count - 1)
        End If
        DG1.EditItemIndex = -1
        DG1.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub DG1_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DG1.DeleteCommand
        DeleteItem(e.Item.ItemIndex)
    End Sub

    Private Sub DeleteItem(ByVal strID As Integer)
        Try

            Dim str As String

            str = EjecutaAccion(strID, OperacionesABC.operBaja)

            If DG1.Items.Count = 1 AndAlso DG1.CurrentPageIndex > 0 Then
                DG1.CurrentPageIndex = DG1.CurrentPageIndex - 1
            End If

            'Actualizar grid
            CargaDS(Me.hiddenVersionID.Value)

            DG1.EditItemIndex = -1

        Catch exp As Exception
            Response.Write(exp.Message)
        End Try
    End Sub

    Private Sub DG1_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DG1.UpdateCommand

        Dim str As String

        'Validar que se haya capturado al menos el siguiente dato
        If CType(DG1.Items(e.Item.ItemIndex).Cells(1).Controls(0), TextBox).Text = "" Then
            MsgBox1.ShowMessage("El campo Nombre, es requerido.")
            Exit Sub
        End If

        'Llena el valor de VersionAplicacion       
        If DG1.Items(e.Item.ItemIndex).Cells(0).Text <> "" AndAlso _
            DG1.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" Then
            'Cambio
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else
            'Alta
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
        End If

        MsgBox1.ShowMessage(str)

        DG1.EditItemIndex = -1

        ' Refresca el DataSet
        CargaDS(CInt(Me.hiddenVersionID.Value))

    End Sub

    Private Sub CargaDS(ByVal pintVersionAplicacionID As Integer)

        'Introducir aquí el código de usuario para inicializar la página
        Dim tTicket As IDTicket
        Dim rRespuesta As Respuesta = Nothing
        Dim dsPermisoAplicacion As DataSet

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

        dsPermisoAplicacion = CargaPermiso(tTicket, pintVersionAplicacionID, rRespuesta)

        If dsPermisoAplicacion.Tables.Count > 0 Then

            dsPermisoAplicacion.Tables(0).TableName = "Permiso"
            Session(SESSIONKEY_DATASOURCE) = dsPermisoAplicacion

            'Cargar el grid
            CargaDG(dsPermisoAplicacion, False)

        ElseIf rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then

            Response.Write(rRespuesta.RespuestaToString)

        End If

        tTicket = Nothing

    End Sub

    Private Sub CargaDG(ByVal oDS As DataSet, ByVal blnExpandible As Boolean)
        'map the tables that are returned from the DB to the ones we will create in the dataset
        oDS.Tables(0).TableName = "Permiso"
        Cache("dsPermiso") = oDS
        BindData()
    End Sub

    Private Function CargaAplicaciones(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As DataSet
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

    Private Function CargaPermiso(ByRef ptTicket As IDTicket, ByVal pintVersionAplicacionID As Integer, ByRef prRespuesta As Respuesta) As DataSet
        Dim sv As Core = New Core
        Dim dsVersionesAplicaciones As DataSet
        Try
            dsVersionesAplicaciones = sv.ColPermisosVersionAplicacion(ptTicket, pintVersionAplicacionID, prRespuesta)
            If prRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                Throw New Exception(prRespuesta.DescripcionRespuesta)
            End If
            Return dsVersionesAplicaciones
        Catch ex As Exception
            Throw
        Finally
            dsVersionesAplicaciones = Nothing
            sv = Nothing
        End Try

    End Function

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String

        Dim aPermiso As Portalv9.SvrUsr.Permiso = Nothing
        Dim rRespuesta As New Portalv9.SvrUsr.Respuesta
        Dim sv As Portalv9.SvrUsr.Core
        Dim strMsg As String = String.Empty
        Dim tTicket As IDTicket

        Try

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Portalv9.SvrUsr.Core
            aPermiso = New Portalv9.SvrUsr.Permiso

            With aPermiso
                If op <> 0 Then
                    .PermisoID = DG1.Items(Index).Cells(0).Text
                End If
                If op <> 1 Then
                    .VersionAplicacionID = ddlVer.SelectedValue.ToString
                    .Nombre = CType(DG1.Items(Index).Cells(1).Controls(0), TextBox).Text
                    .Descripcion = CType(DG1.Items(Index).Cells(2).Controls(0), TextBox).Text
                End If
            End With

            sv.ABC_Permiso(tTicket, aPermiso, op, rRespuesta)
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
            If Not aPermiso Is Nothing Then
                aPermiso = Nothing
            End If
            rRespuesta = Nothing
        End Try
    End Function

    Private Sub btnAdPermiso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdPermiso.Click
        Try
            'Si no estan vacios los combos
            If ddlApp.SelectedValue.ToString <> "" And ddlVer.SelectedValue.ToString <> "" Then
                Agregar_Registro()
            Else
                MsgBox1.ShowMessage("Para agregar una versión, debe dar de alta primero una aplicación y una versión.")
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub Agregar_Registro()

        Dim tTicket As IDTicket

        ' ''Dim intTotalItemsGrid As Integer
        ' ''intTotalItemsGrid = DG1.Items.Count + DG1.PageSize * DG1.CurrentPageIndex

        'Si el número de registros en el grid es igual al límite de registros por página
        If DG1.Items.Count = DG1.PageSize Then
            'Cambia de página
            DG1.CurrentPageIndex = DG1.PageCount - 1
            'Actualiza el grid
            BindData()
        End If

        Dim intTotalItemsGrid As Integer
        intTotalItemsGrid = DG1.Items.Count + DG1.PageSize * DG1.CurrentPageIndex

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

        Dim dv As DataView = Session(SESSIONKEY_DATASOURCE).Tables("Permiso").DefaultView
        If dv.Count <= intTotalItemsGrid Then
            dv.AddNew()
        End If

        'Tiene que recorrer toda la lista hasta el final hasta que haya lugar
        'para meter el registro nuevo
        If DG1.Items.Count = DG1.PageSize Then
            'Debe agregar en la siguiente página, ésta ya se llenó
            DG1.CurrentPageIndex = DG1.CurrentPageIndex + 1
            DG1.EditItemIndex = 0
        Else
            DG1.EditItemIndex = DG1.Items.Count()
        End If

        With DG1
            .DataSource = dv
            .DataBind()
        End With

        dv = Nothing

    End Sub

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
                        server.transfer("Wfrm_CambiaPwd.aspx?index=0")
                        Exit Try
                    End If
                End If

                'Cargar el grid
                CargaDS(Me.hiddenVersionID.Value)

            End If

        Catch ex As Exception
            MsgBox1.ShowMessage(ex.ToString)
        End Try

    End Sub

    Protected Sub DG1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DG1.ItemDataBound
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
            l = CType(e.Item.Cells(4).Controls(0), LinkButton)
            l.Attributes.Add("onclick", "return getconfirm();")
        End If
    End Sub

    Private Sub DG1User_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DG1.PageIndexChanged
        Try
            DG1.CurrentPageIndex = e.NewPageIndex
            DG1.EditItemIndex = -1
            DG1.SelectedIndex = -1
            BindData()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

#Region "Comunes"

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

    Protected Sub ddlApp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlApp.SelectedIndexChanged

        If ddlApp.SelectedValue.ToString <> "" Then

            'Guardar el ID de la aplicación seleccionada
            Me.hiddenAplicacionID.Value = ddlApp.SelectedValue.ToString

            'Cargar el combo de versiones en base a la aplicación seleccionada
            BindVersion(Me.hiddenAplicacionID.Value)

            'Guardar el ID de la aplicación seleccionada
            Me.hiddenVersionID.Value = ddlVer.SelectedValue.ToString

            'Si no hay registros en el combo no carga los datos
            If ddlVer.SelectedValue.ToString <> "" Then
                Me.hiddenVersionID.Value = ddlVer.SelectedValue.ToString
                'Cargar el grid en base a la aplicación seleccionada
                CargaDS(Me.hiddenVersionID.Value)
            Else
                CargaDS(-1)
            End If

        End If

    End Sub

    Protected Sub ddlVer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlVer.SelectedIndexChanged
        'Si no hay registros en el combo no carga los datos
        If ddlVer.SelectedValue.ToString <> "" Then
            Me.hiddenVersionID.Value = ddlVer.SelectedValue.ToString
            CargaDS(Me.hiddenVersionID.Value)
        End If
    End Sub

End Class