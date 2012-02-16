Imports Portalv9.SvrUsr

Partial Public Class Wfrm_RequerimentoMod
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Private dvReqMod As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            'lblTitle.Text = "Aplicaciones"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then
                Logoff()
                Exit Sub
            End If
            CargaDSCat()
            'Me.hiddenModuloID.Value = ddlMod.SelectedValue.ToString
            GetDataSource()
        End If
    End Sub

    Private ReadOnly Property SESSIONKEY_DATASOURCE() As String
        Get
            Return Me.UniqueID & "_DataSource"
        End Get
    End Property

    Private Sub ReqModulo_DataBind(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.DataBinding
        'if an InvalidCastException occurs in either of the next two lines, 
        'please make sure that you've set the TemplateDataMode to Table (because you want nested grids)
        DataBindingME()
    End Sub

    Private Sub DataBindingME()
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf (dgi.DataItem) Is DataSet)) Then
            Dim ex As ArgumentException = New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
            Throw ex
        End If
        Dim ds As DataSet = CType(dgi.DataItem, DataSet)

        DG1.DataSource = ds
        Session(SESSIONKEY_DATASOURCE) = ds
        BindData()
        ' Guardar el valor del ModuloID, y no perderlos!
        Me.hiddenModuloID.Value = DG1.Items(0).Cells(6).Text
    End Sub

    Private Sub BindData()
        'bind the DataSet to the HierarGrid
        DG1.DataSource = Session(SESSIONKEY_DATASOURCE).Tables("ReqModulo").DefaultView
        DG1.DataBind()
        Me.btnAddMod.Visible = DG1.CurrentPageIndex = DG1.PageCount - 1

    End Sub

    Private Sub DeleteItem(ByVal strID As Integer)
        Try
            Dim str As String
            str = EjecutaAccion(strID, OperacionesABC.operBaja)
            If DG1.Items.Count = 1 AndAlso DG1.CurrentPageIndex > 0 Then
                DG1.CurrentPageIndex = DG1.CurrentPageIndex - 1
            End If
            CargaDS(CInt(DG1.Items(strID).Cells(6).Text))
            DG1.EditItemIndex = -1
            BindData()
        Catch exp As Exception
            Response.Write(exp.Message)
        End Try
    End Sub

    Private Sub CargaDS(ByVal pintModuloID As Integer)
        'Introducir aquí el código de usuario para inicializar la página
        Dim tTicket As IDTicket
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

        ds = CargaReqModulo(tTicket, pintModuloID, rRespuesta)
        If ds.Tables.Count > 0 Then
            ds.Tables(0).TableName = "ReqModulo"
            Session(SESSIONKEY_DATASOURCE) = ds
            CargaDG(ds, False)
            'Actualizar el cache del dataset completo
        ElseIf rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            Response.Write(rRespuesta.RespuestaToString)
        End If
    End Sub

    Private Function CargaReqModulo(ByRef ptTicket As IDTicket, ByVal pintModuloID As Integer, ByRef prRespuesta As Respuesta) As DataSet
        Dim sv As Core = New Core
        Dim ds As DataSet
        Try
            ds = sv.ColRequerimientosXModuloID(ptTicket, pintModuloID, prRespuesta)
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

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String
        Dim aReq As Portalv9.SvrUsr.ReqModulo = Nothing
        Dim rRespuesta As New Portalv9.SvrUsr.Respuesta
        Dim sv As Portalv9.SvrUsr.Core
        Dim strMsg As String = String.Empty
        Dim tTicket As IDTicket

        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Portalv9.SvrUsr.Core
            aReq = New Portalv9.SvrUsr.ReqModulo
            With aReq
                If op <> 0 Then
                    .ReqModuloID = DG1.Items(Index).Cells(0).Text
                End If
                If op <> 1 Then
                    .ModuloID = Me.hiddenModuloID.Value
                    .RequerimientoID = CType(DG1.Items(Index).Cells(1).Controls(1), DropDownList).SelectedValue
                    .Tag = CType(DG1.Items(Index).Cells(2).Controls(0), TextBox).Text
                    .Descripcion = DG1.Items(Index).Cells(3).Text
                End If
            End With
            sv.ABC_ReqModulo(tTicket, aReq, op, rRespuesta)
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                strMsg = "Se ejecutó correctamente la operacion de cambio solicitada. "
            Else
                strMsg = "Ocurrió un error al intentar la operación solicitada: " & rRespuesta.RespuestaToString
            End If
            Return strMsg
        Catch ex As Exception
            strMsg = ex.Message
            Throw
        Finally
            sv = Nothing
            If Not aReq Is Nothing Then
                aReq = Nothing
            End If
            rRespuesta = Nothing
        End Try

    End Function

    Private Sub Agregar_Registro()
        Dim intTotalItemsGrid As Integer

        intTotalItemsGrid = DG1.Items.Count + DG1.PageSize * DG1.CurrentPageIndex

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim dv As DataView = Session(SESSIONKEY_DATASOURCE).Tables("ReqModulo").DefaultView
        If dv.Count <= intTotalItemsGrid Then
            dv.AddNew()
        End If
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

    Private Sub DG1_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DG1.EditCommand
        '        VerIndiceFueradeRango()
        If e.Item.ItemType = ListItemType.Pager OrElse _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        Try
            'e.Item.Cells(1).Controls(0).ID()
            'Dim ddl As DropDownList = CType(e.Item.Cells(1).FindControl("ddReq"), DropDownList)
            DG1.EditItemIndex = e.Item.ItemIndex
            BindData()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub DG1_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DG1.CancelCommand
        '        VerIndiceFueradeRango()
        If DG1.Items(DG1.EditItemIndex).Cells(0).Text = "&nbsp;" OrElse _
            DG1.Items(DG1.EditItemIndex).Cells(0).Text = "" Then
            'Estaba en alta
            Session(SESSIONKEY_DATASOURCE).Tables("ReqModulo").DefaultView().Delete(Session(SESSIONKEY_DATASOURCE).Tables("ReqModulo").DefaultView().Count - 1)
        End If
        DG1.EditItemIndex = -1
        DG1.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub DG1_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DG1.DeleteCommand
        'VerIndiceFueradeRango()
        DeleteItem(e.Item.ItemIndex)
    End Sub

    Private Sub DG1_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DG1.UpdateCommand
        Dim str As String

        'Validar datos
        If Trim(CType(DG1.Items(e.Item.ItemIndex).Cells(1).Controls(1), DropDownList).SelectedValue) = "" Then
            MsgBox1.ShowMessage("El dato Requerimiento, es requerido.")
            Exit Sub
        End If

        If DG1.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" AndAlso _
            DG1.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" Then
            'Cambio
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else
            'Alta
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
            ' Refresca el DataSet
            CargaDS(CInt(Me.hiddenModuloID.Value))
        End If
        'Refresca el Dataset
        Dim row As DataRow = Session(SESSIONKEY_DATASOURCE).Tables("ReqModulo").Rows(e.Item.ItemIndex)

        row("RequerimientoID") = CType(e.Item.Cells(1).Controls(1), DropDownList).SelectedValue.ToString
        row("Tag") = CType(e.Item.Cells(2).Controls(0), TextBox).Text

        DG1.EditItemIndex = -1
        BindData()

    End Sub

    Protected Sub DG1_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DG1.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' BIND GRID DATA ITEMS: Handles DG1.ItemDataBound
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

    Public Function ObtenerRequerimientos() As DataTable
        'Sección para cargar el combo box
        Dim sv As Core = New Core
        Dim tTicket As IDTicket
        Dim rRespuesta As Respuesta = Nothing
        Dim ds As DataSet
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            ds = sv.ColRequerimientosModulo(tTicket, 0, "", rRespuesta)
            Return ds.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

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
        'Carga catálogos de Modulos
        Cache("mdsModulos") = CargaCatalogos(tTicket, rRespuesta)
        Cache("mdsModulos").Tables(0).TableName = "Modulos"
        ''Cache("mdsAplicaciones").Tables(1).TableName = "Version"
        BindCombos()

    End Sub

    Private Sub BindCombos()
        'bind the DataSet to the HierarGrid
        With Me.ddlMod
            .DataSource = Cache("mdsModulos")
            .DataMember = "Modulos"
            .DataTextField = "NbModulo"
            .DataValueField = "ModuloID"
            .DataBind()
            .SelectedIndex = 0
        End With

        Me.hiddenModuloID.Value = ddlMod.SelectedValue.ToString

        GetDataSource()

    End Sub

    Private Function CargaCatalogos(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As DataSet
        ' Cargar los catálogos de Aplicaciones y VersionAplicación ligados entre ellos
        ' Guardar el número de VersionAplicacion actual
        Dim sv As Core = New Core
        Dim dsAplicaciones As DataSet
        Try
            dsAplicaciones = sv.ColModulosVersionAplicacion(ptTicket, 0, prRespuesta)
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

    Private Sub GetDataSource()
        'Introducir aquí el código de usuario para inicializar la página
        Dim strResult As String
        'Try
        strResult = ObtieneResultado()
        If strResult <> String.Empty Then
            MsgBox1.ShowMessage(strResult)
        End If
        If Not IsPostBack Then
            Dim strRes As String = Session("DebeCambiarPwd")
            If strRes <> String.Empty Then
                If CType(strRes, Boolean) = True Then
                    server.transfer("Wfrm_CambiaPwd.aspx?index=0")
                    '            Exit Try
                End If
            End If
            CargaDS(Me.hiddenModuloID.Value)
        End If
        'Catch ex As Exception
        ' MsgBox1.ShowMessage(ex.ToString)
        ' End Try
    End Sub

    Private Sub CargaDS()
        'Introducir aquí el código de usuario para inicializar la página
        Dim tTicket As IDTicket
        Dim rRespuesta As Respuesta = Nothing
        Dim dsModulos As DataSet
        Dim pintModuloID As Integer = 0

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

        dsModulos = CargaReqModulo(tTicket, pintModuloID, rRespuesta)
        If dsModulos.Tables.Count > 0 Then
            CargaDG(dsModulos, False)
        ElseIf rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            Response.Write(rRespuesta.RespuestaToString)
        End If
        tTicket = Nothing

    End Sub

    Private Sub CargaDG(ByVal oDS As DataSet, ByVal blnExpandible As Boolean)
        'map the tables that are returned from the DB to the ones we will create in the dataset
        'oDS.Tables(0).TableName = "Aplicacion"
        oDS.Tables(0).TableName = "ReqModulo"
        'oDS.Tables(2).TableName = "Permiso"

        'set up the relationships
        'oDS.Relations.Add("Aplicacion_Version", oDS.Tables("Aplicacion").Columns("AplicacionID"), oDS.Tables("VersionAplicacion").Columns("AplicacionID"))
        'oDS.Relations.Add("Version_Permiso", oDS.Tables("VersionAplicacion").Columns("VersionAplicacionID"), oDS.Tables("Permiso").Columns("VersionAplicacionID"))

        Cache("dsModulos") = oDS
        BindData()
    End Sub

    Protected Sub btnAddMod_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddMod.Click
        Try
            Agregar_Registro()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub ddlMod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMod.SelectedIndexChanged
        Me.hiddenModuloID.Value = ddlMod.SelectedValue.ToString
        CargaDS(Me.hiddenModuloID.Value)
    End Sub
End Class