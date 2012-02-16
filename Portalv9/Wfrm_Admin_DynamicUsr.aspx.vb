Imports Portalv9.SvrUsr

Partial Public Class Wfrm_DynamicUsr
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

#Region "Eventos de la forma"

    Private Sub Wfrm_DynamicUsr_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Asignar click al texto de buscar
        Me.txtBuscar.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Me.btnBuscar.UniqueID + "').click();return false;}} else {return true}; ")

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle.Text = "Campos dinámicos para el catálogo de usuarios"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            GetDataSource()
        End If
    End Sub

#End Region

#Region "Métodos Públicos"
    Public Function ObtenerValueTipoDato(ByVal strValue As String) As String
        'Parametros
        'IN
        '   strValue -->  Value actual
        'OUT
        '   ObtenerValueTipoDato --> Value a seleccionar en el DDL

        If strValue = "" Then
            'En caso de ser un nuevo registro regresará el value del primer registro
            ObtenerValueTipoDato = "Texto"
        Else
            Return strValue
        End If

    End Function
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
        Dim dsCampos As DataSet
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

            dsCampos = sv.ColDynamicUsr(tTicket, rRespuesta)
            If Not dsCampos Is Nothing Then
                If dsCampos.Tables.Count > 0 Then

                    dsCampos.Tables(0).TableName = "Campos"
                    Session(SESSIONKEY_DATASOURCE) = dsCampos

                    'Actualizar el cache del dataset completo
                    CargaDG(dsCampos, False)

                ElseIf rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    Throw New Exception(rRespuesta.RespuestaToString)
                End If
            Else
                Throw New Exception(rRespuesta.RespuestaToString)
            End If

            sv = Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Private Sub CargaDG(ByVal oDS As DataSet, ByVal blnExpandible As Boolean)
        'map the tables that are returned from the DB to the ones we will create in the dataset
        oDS.Tables(0).TableName = "Campos"
        Cache("dsCampos") = oDS
        grdCampos.CurrentPageIndex = 0
        grdCampos.EditItemIndex = -1
        grdCampos.SelectedIndex = -1
        BindData()
    End Sub

    Private Sub BindData()

        Dim dv As New DataView

        dv = Cache("dsCampos").Tables(0).DefaultView
        dv.RowFilter = " Etiqueta LIKE '%" & Me.txtBuscar.Text & "%'"
        'bind the DataSet to the HierarGrid
        grdCampos.DataSource = dv
        grdCampos.DataMember = "Campos"
        grdCampos.DataBind()
        Cache("dsCampos").tables(0).rows.count()
    End Sub


    Private Sub Agregar_Registro()

        'Si el número de registros en el grid es igual al límite de registros por página
        If grdCampos.Items.Count = grdCampos.PageSize Then
            'Cambia de página
            grdCampos.CurrentPageIndex = grdCampos.PageCount - 1
            'Actualiza el grid
            BindData()
        End If

        Dim intTotalItemsGrid As Integer
        intTotalItemsGrid = grdCampos.Items.Count + grdCampos.PageSize * grdCampos.CurrentPageIndex

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

        Dim dv As DataView = Cache("dsCampos").Tables("Campos").DefaultView
        If dv.Count <= intTotalItemsGrid Then
            dv.AddNew()
        End If

        If grdCampos.Items.Count = grdCampos.PageSize Then
            'Debe agregar en la siguiente página, ésta ya se llenó
            grdCampos.CurrentPageIndex = grdCampos.CurrentPageIndex + 1
            grdCampos.EditItemIndex = 0
        Else
            grdCampos.EditItemIndex = grdCampos.Items.Count()
        End If

        With grdCampos
            .DataSource = dv
            .DataBind()
        End With

        dv = Nothing

    End Sub


    Private Sub DeleteItem(ByVal strID As Integer)
        Try
            Dim str As String
            str = EjecutaAccion(strID, OperacionesABC.operBaja)
            If grdCampos.Items.Count = 1 AndAlso grdCampos.CurrentPageIndex > 0 Then
                grdCampos.CurrentPageIndex = grdCampos.CurrentPageIndex - 1
            End If
            CargaDS()
            grdCampos.EditItemIndex = -1
            BindData()
            Me.MsgBox1.ShowMessage(str)
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try
    End Sub

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String



        Dim aDynamicUsr As DynamicUsr
        Dim rRespuesta As Respuesta = Nothing
        Dim sv As Core
        Dim strMsg As String = String.Empty



        Try
            
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            aDynamicUsr = New DynamicUsr
            Dim sDescripcion As String
            sDescripcion = DescripcionLog(Index, op)
            With aDynamicUsr


                If op <> 0 Then 'No es Alta
                    .NoIdentidad = grdCampos.Items(Index).Cells(0).Text
                End If
                If op <> 1 Then  'No poner valores para eliminar
                    .Etiqueta = CType(grdCampos.Items(Index).FindControl("TextEtiqueta"), TextBox).Text
                    .TipoDato = CType(grdCampos.Items(Index).FindControl("ddTipoDato"), DropDownList).SelectedValue
                    .Orden = CType(grdCampos.Items(Index).FindControl("TextOrden"), TextBox).Text
                    .Obligatorio = CType(grdCampos.Items(Index).FindControl("CheckObligatorio"), CheckBox).Checked()
                    .Minlen = CType(grdCampos.Items(Index).FindControl("TextMinlen"), TextBox).Text
                    .Maxlen = CType(grdCampos.Items(Index).FindControl("TextMaxlen"), TextBox).Text
                End If
            End With

            sv = New Core

            sv.ABC_DynamicUsr(tTicket, aDynamicUsr, op, rRespuesta, sDescripcion)
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
        Catch ex As Exception
            strMsg = "El registro no puede eliminarse ya que esta siendo utilizado en otra parte del sistema"
        Finally
            sv = Nothing
            aDynamicUsr = Nothing
            rRespuesta = Nothing
        End Try
        EjecutaAccion = strMsg
    End Function

#End Region


#Region "Eventos del DataGrid"

    Private Sub grdCampos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdCampos.ItemCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdCampos)
        hiddenPGrupo.Value = Trim(e.Item.Cells(0).Text)
    End Sub

    Private Sub grdCampos_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdCampos.EditCommand
        GlobalDef.VerIndiceFueradeRango(grdCampos)
        If e.Item.ItemType = ListItemType.Pager Or _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        Try
            grdCampos.EditItemIndex = e.Item.ItemIndex
            BindData()
            'Crea lista de datos para posteriormente describir los cambios realizados
            'Crea lista de datos para posteriormente describir los cambios realizados
            Me.HiddenField1.Value = CType(e.Item.FindControl("lblEtiqueta"), Label).Text.Trim
            Me.HiddenField2.Value = CType(e.Item.Cells(2).Controls(0), DataBoundLiteralControl).Text.Trim
            Me.HiddenField3.Value = CType(e.Item.Cells(3).Controls(0), DataBoundLiteralControl).Text.Trim
            Me.HiddenField4.Value = CType(e.Item.FindControl("CheckObligatorio"), CheckBox).Checked
            Me.HiddenField5.Value = CType(e.Item.Cells(5).Controls(0), DataBoundLiteralControl).Text.Trim
            Me.HiddenField6.Value = CType(e.Item.Cells(6).Controls(0), DataBoundLiteralControl).Text.Trim
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try

    End Sub

    Private Sub grdCampos_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdCampos.CancelCommand
        GlobalDef.VerIndiceFueradeRango(grdCampos)
        If grdCampos.Items(grdCampos.EditItemIndex).Cells(1).Text = "&nbsp;" Then
            'Estaba en alta
            Session(SESSIONKEY_DATASOURCE).Tables("Campos").DefaultView().Delete(Session(SESSIONKEY_DATASOURCE).Tables("Campos").DefaultView().Count - 1)
        End If
        grdCampos.CurrentPageIndex = 0
        grdCampos.EditItemIndex = -1
        grdCampos.SelectedIndex = -1
        BindData()

    End Sub

    Private Sub grdCampos_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdCampos.DeleteCommand
        GlobalDef.VerIndiceFueradeRango(Me.grdCampos)
        hiddenPGrupo.Value = e.Item.ItemIndex
        Me.MsgBox1.ShowConfirmation("Está seguro de eliminar el campo dinámico " + CType(e.Item.FindControl("lblEtiqueta"), Label).Text, "Delete", True, False)
        'GlobalDef.VerIndiceFueradeRango(grdCampos)
        'hiddenPGrupo.Value = e.Item.ItemIndex
        'DeleteItem(hiddenPGrupo.Value)
    End Sub

    Private Sub grdCampos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdCampos.PageIndexChanged
        Try
            grdCampos.CurrentPageIndex = e.NewPageIndex
            grdCampos.EditItemIndex = -1
            grdCampos.SelectedIndex = -1
            BindData()
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub grdCampos_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdCampos.UpdateCommand

        Dim str As String

        'Validar datos
        If Trim(CType(grdCampos.Items(e.Item.ItemIndex).FindControl("TextEtiqueta"), TextBox).Text) = "" Then
            MsgBox1.ShowMessage("El dato Etiqueta, es requerido.")
            Exit Sub
        End If
        If Trim(CType(grdCampos.Items(e.Item.ItemIndex).FindControl("ddTipoDato"), DropDownList).SelectedValue) = "" Then
            MsgBox1.ShowMessage("El dato Tipo, es requerido.")
            Exit Sub
        End If
        If Trim(CType(grdCampos.Items(e.Item.ItemIndex).FindControl("TextOrden"), TextBox).Text) = "" Then
            MsgBox1.ShowMessage("El dato Orden, es requerido.")
            Exit Sub
        End If


        If grdCampos.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" Then 'actualizar cambios
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else 'insertar
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
        End If
        If str <> String.Empty Then
            Me.MsgBox1.ShowMessage(str)
        End If

        MsgBox1.ShowMessage(str)

        'Refresca el DataSet
        grdCampos.EditItemIndex = -1
        CargaDS()

    End Sub

#End Region

#Region "Eventos btnAddNew"


    Protected Sub btnAddNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddNew.Click
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

    Private Sub grdCampos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdCampos.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' BIND GRID DATA ITEMS: Handles HG1.ItemDataBound
        '----------------------------------------------------------------------------------------------------------
        ' Add events/alerts to grid items 
        '  Only applies to Item / Alt Items (ie: not header, footer rows)
        '  Adds Confirmation message to delete button
        '----------------------------------------------------------------------------------------------------------
        GlobalDef.VerIndiceFueradeRango(grdCampos)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'Add confirm message box to Delete button
            Dim l As LinkButton
            l = CType(e.Item.Cells(8).Controls(0), LinkButton)
            'l.Attributes.Add("onclick", "return getconfirm();")
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        'Encontrar los grupos que cumplan con la condición de busqueda

        CargaDS()

    End Sub


    Private Function DescripcionLog(ByVal Index As Long, ByVal op As String) As String

        DescripcionLog = String.Empty


        Select Case op
            Case OperacionesABC.operAlta
                DescripcionLog = "Creación del Campo Dinámico: " & CType(grdCampos.Items(Index).FindControl("TextEtiqueta"), TextBox).Text.Trim
            Case OperacionesABC.operCambio
                DescripcionLog = "Modificación del Campo Dinámico: " & Me.HiddenField1.Value.Trim & " "
                If Me.HiddenField1.Value.Trim <> CType(grdCampos.Items(Index).FindControl("TextEtiqueta"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Etiqueta. "
                End If
                If Me.HiddenField2.Value.Trim <> CType(grdCampos.Items(Index).FindControl("ddTipoDato"), DropDownList).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Tipo. "
                End If
                If Me.HiddenField3.Value.Trim <> CType(grdCampos.Items(Index).FindControl("TextOrden"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Orden. "
                End If
                If Me.HiddenField4.Value.Trim <> CType(grdCampos.Items(Index).FindControl("CheckObligatorio"), CheckBox).Checked Then
                    DescripcionLog = DescripcionLog & "En Obligatorio. "
                End If
                If Me.HiddenField5.Value.Trim <> CType(grdCampos.Items(Index).FindControl("TextMinlen"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Long. Min. "
                End If
                If Me.HiddenField6.Value.Trim <> CType(grdCampos.Items(Index).FindControl("TextMaxlen"), TextBox).Text.Trim Then
                    DescripcionLog = DescripcionLog & "En Long. Max. "
                End If
            Case OperacionesABC.operBaja
                DescripcionLog = "Eliminación del Campo Dinámico: " & CType(grdCampos.Items(Index).FindControl("lblEtiqueta"), Label).Text.Trim
        End Select

    End Function


    Private Sub MsgBox1_YesChoosed(ByVal sender As System.Object, ByVal Key As String) Handles MsgBox1.YesChoosed
        Select Case Key
            Case "Delete"
                DeleteItem(hiddenPGrupo.Value)
        End Select
    End Sub
End Class