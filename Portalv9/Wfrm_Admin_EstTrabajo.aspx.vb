Imports Portalv9.SvrUsr
Partial Public Class Wfrm_EstTrabajo
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket

#Region "Eventos de la forma"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle.Text = "Estaciones de Trabajo"
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
        Dim dsEstTra As DataSet = Nothing
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
            ''Dim intGrupoAdmin As Integer = tTicket.GrupoAdminID
            ''If intGrupoAdmin > 0 Then

            dsEstTra = sv.ColEstacionTrabajo(tTicket, rRespuesta)
            If Not dsEstTra Is Nothing Then
                If dsEstTra.Tables.Count > 0 Then

                    dsEstTra.Tables(0).TableName = "Estaciones"
                    Session(SESSIONKEY_DATASOURCE) = dsEstTra

                    'Actualizar el cache del dataset completo
                    CargaDG(dsEstTra, False)

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
        oDS.Tables(0).TableName = "Estaciones"
        Cache("dsEstTra") = oDS
        grdEstTra.CurrentPageIndex = 0
        grdEstTra.EditItemIndex = -1
        grdEstTra.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub BindData()
        '[IEJ 20081021] Aplicar Filtro BUSQUEDA
        Dim dv As New DataView
        dv = Cache("dsEstTra").Tables(0).DefaultView
        ''dv.RowFilter = " (Nombre + ' ' + Descripcion) LIKE '%" & Me.txtBuscar.Text & "%'"
        'bind the DataSet to the HierarGrid
        grdEstTra.DataSource = dv
        grdEstTra.DataMember = "Estaciones"
        grdEstTra.DataBind()
        Cache("dsEstTra").tables(0).rows.count()
    End Sub

    Private Function Agregar_Registro()

        'Si el número de registros en el grid es igual al límite de registros por página
        If grdEstTra.Items.Count = grdEstTra.PageSize Then
            'Cambia de página
            grdEstTra.CurrentPageIndex = grdEstTra.PageCount - 1
            'Actualiza el grid
            BindData()
        End If

        Dim intTotalItemsGrid As Integer
        intTotalItemsGrid = grdEstTra.Items.Count + grdEstTra.PageSize * grdEstTra.CurrentPageIndex

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

        Dim dv As DataView = Cache("dsEstTra").Tables("Estaciones").DefaultView
        If dv.Count <= intTotalItemsGrid Then
            dv.AddNew()
        End If

        If grdEstTra.Items.Count = grdEstTra.PageSize Then
            'Debe agregar en la siguiente página, ésta ya se llenó
            grdEstTra.CurrentPageIndex = grdEstTra.CurrentPageIndex + 1
            grdEstTra.EditItemIndex = 0
        Else
            grdEstTra.EditItemIndex = grdEstTra.Items.Count()
        End If

        With grdEstTra
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
            If grdEstTra.Items.Count = 1 AndAlso grdEstTra.CurrentPageIndex > 0 Then
                grdEstTra.CurrentPageIndex = grdEstTra.CurrentPageIndex - 1
            End If
            CargaDS()
            grdEstTra.EditItemIndex = -1
            BindData()
            Me.MsgBox1.ShowMessage(str)
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String
        Dim aEstTra As EstacionTrabajo
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty

        Try


            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Core

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
                strMsg = "El nombre de la Estación de Trabajo """ & CType(grdEstTra.Items(Index).FindControl("TextNombre"), TextBox).Text & """ ya existe"
            Else
                aEstTra = New EstacionTrabajo
                Dim sDescripcion As String
                sDescripcion = DescripcionLog(Index, op)
                With aEstTra
                    If op <> 0 Then 'No es Alta                        
                        .EstacionTrabajoID = grdEstTra.Items(Index).Cells(0).Text
                    End If
                    If op <> 1 Then  'No poner valores para eliminar
                        .IP = CType(grdEstTra.Items(Index).FindControl("TextIP"), TextBox).Text
                        .Nombre = CType(grdEstTra.Items(Index).FindControl("TextNombre"), TextBox).Text
                        .Dominio = IIf(CType(grdEstTra.Items(Index).FindControl("TextDominio"), TextBox).Text.Trim = "", " ", CType(grdEstTra.Items(Index).FindControl("TextDominio"), TextBox).Text)
                        .Alias = IIf(CType(grdEstTra.Items(Index).FindControl("TextAlias"), TextBox).Text.Trim = "", " ", CType(grdEstTra.Items(Index).FindControl("TextAlias"), TextBox).Text)
                        .LlavePublica = IIf(CType(grdEstTra.Items(Index).FindControl("TextLlavePublica"), TextBox).Text.Trim = "", " ", CType(grdEstTra.Items(Index).FindControl("TextLlavePublica"), TextBox).Text)
                        .Status = 0
                    End If
                End With

                sv.ABC_EstacionTrabajo(tTicket, aEstTra, op, rRespuesta)
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
                    End If
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
            aEstTra = Nothing
            rRespuesta = Nothing
        End Try
        EjecutaAccion = strMsg
    End Function

#End Region

#Region "Eventos del DataGrid"

    Private Sub grdEstTra_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdEstTra.ItemCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdEstTra)
        hiddenPEstTra.Value = Trim(e.Item.Cells(0).Text)
    End Sub

    Private Sub grdEstTra_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdEstTra.EditCommand
        GlobalDef.VerIndiceFueradeRango(grdEstTra)
        If e.Item.ItemType = ListItemType.Pager Or _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        'Crea lista de datos para posteriormente describir los cambios realizados
        Me.HiddenField1.Value = CType(e.Item.FindControl("lblIP"), Label).Text
        Me.HiddenField2.Value = CType(e.Item.FindControl("lblNombre"), Label).Text
        Me.HiddenField3.Value = CType(e.Item.FindControl("lblDominio"), Label).Text
        Me.HiddenField4.Value = CType(e.Item.FindControl("lblAlias"), Label).Text
        Me.HiddenField5.Value = CType(e.Item.FindControl("lblLlavePublica"), Label).Text
        Me.HiddenField6.Value = CType(e.Item.FindControl("lblStatus"), Label).Text
        Try
            grdEstTra.EditItemIndex = e.Item.ItemIndex
            BindData()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub grdEstTra_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdEstTra.CancelCommand
        'Obentemos el datatow el cuál se estaba editando
        GlobalDef.VerIndiceFueradeRango(grdEstTra)
        If grdEstTra.Items(grdEstTra.EditItemIndex).Cells(1).Text = "&nbsp;" Then
            'Estaba en alta
            Session(SESSIONKEY_DATASOURCE).Tables("Estaciones").DefaultView().Delete(Session(SESSIONKEY_DATASOURCE).Tables("Estaciones").DefaultView().Count - 1)
        End If
        grdEstTra.CurrentPageIndex = 0
        grdEstTra.EditItemIndex = -1
        grdEstTra.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub grdEstTra_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdEstTra.DeleteCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdEstTra)
        hiddenPEstTra.Value = e.Item.ItemIndex
        Me.MsgBox1.ShowConfirmation("Está seguro de eliminar el grupo " + CType(e.Item.FindControl("lblNombre"), Label).Text, "Delete", True, False)
    End Sub

    Private Sub grdEstTra_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdEstTra.PageIndexChanged
        Try
            grdEstTra.CurrentPageIndex = e.NewPageIndex
            grdEstTra.EditItemIndex = -1
            grdEstTra.SelectedIndex = -1
            BindData()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub grdEstTra_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdEstTra.UpdateCommand

        Dim str As String

        'Validar datos
        If Trim(CType(grdEstTra.Items(e.Item.ItemIndex).FindControl("TextIP"), TextBox).Text) = "" Then
            MsgBox1.ShowMessage("El dato IP, es requerido.")
            Exit Sub
        End If
        If Trim(CType(grdEstTra.Items(e.Item.ItemIndex).FindControl("TextNombre"), TextBox).Text) = "" Then
            MsgBox1.ShowMessage("El dato Nombre, es requerido.")
            Exit Sub
        End If

        If grdEstTra.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" Then 'actualizar cambios
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else 'insertar
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
        End If
        If str <> String.Empty Then
            Me.MsgBox1.ShowMessage(str)
        End If

        MsgBox1.ShowMessage(str)

        'Refresca el DataSet
        grdEstTra.EditItemIndex = -1
        CargaDS()

    End Sub

#End Region

#Region "Eventos MsgBox1 y btnAddNew"

    Private Sub MsgBox1_YesChoosed(ByVal sender As System.Object, ByVal Key As String) Handles MsgBox1.YesChoosed
        Select Case Key
            Case "Delete"
                DeleteItem(Me.hiddenPEstTra.Value)
        End Select
    End Sub

    Private Sub btnAddPEstTra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPEstTra.Click
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

    Private Sub grdEstTra_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdEstTra.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' BIND GRID DATA ITEMS: Handles HG1.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' Add events/alerts to grid items 
        '  Only applies to Item / Alt Items (ie: not header, footer rows)
        '  Adds Confirmation message to delete button
        '----------------------------------------------------------------------------------------------------------
        GlobalDef.VerIndiceFueradeRango(grdEstTra)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'Add confirm message box to Delete button
            Dim l As LinkButton
            l = CType(e.Item.Cells(8).Controls(0), LinkButton)
        End If
    End Sub

    Private Function DescripcionLog(ByVal Index As Long, ByVal op As String) As String

        DescripcionLog = String.Empty

        Select Case op
            Case OperacionesABC.operAlta
                DescripcionLog = "Creación de la Estación de Trabajo: " & CType(grdEstTra.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim
            Case OperacionesABC.operCambio
                DescripcionLog = "Modificación de la Estación de Trabajo: " & CType(grdEstTra.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim & " "
                If Me.HiddenField1.Value.Trim <> CType(grdEstTra.Items(Index).FindControl("TextIP"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En IP. "
                End If
                If Me.HiddenField2.Value.Trim <> CType(grdEstTra.Items(Index).FindControl("TextNombre"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Nombre. "
                End If
                If Me.HiddenField3.Value.Trim <> CType(grdEstTra.Items(Index).FindControl("TextDominio"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Dominio. "
                End If
                If Me.HiddenField5.Value.Trim <> CType(grdEstTra.Items(Index).FindControl("TextAlias"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Alias. "
                End If
                If Me.HiddenField6.Value.Trim <> CType(grdEstTra.Items(Index).FindControl("TextLlavePublica"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Llave Pública. "
                End If
            Case OperacionesABC.operBaja
                DescripcionLog = "Eliminación de la Estación de Trabajo: " & CType(grdEstTra.Items(Index).FindControl("lblNombre"), Label).Text
        End Select

    End Function

End Class