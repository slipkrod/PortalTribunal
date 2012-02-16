Imports Portalv9.SvrUsr

Partial Public Class Wfrm_VersionApp

    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Private dvVersionApp As DataView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle.Text = "Versiones"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            'Cargar los catálogo de aplicación y versión
            CargaDSCat()

            'Si no hay datos en los combos no cargará nada en el grid
            If Me.ddlApp.SelectedValue.ToString <> "" Then

                'Guardar el ID del primer registro de la aplicación y versión
                Me.hiddenAplicacionID.Value = ddlApp.SelectedValue.ToString

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
                Server.Transfer("Wfrm_CambiaPwd.aspx?index=0")
                'TODO: Asegurarse de que sale de la página
            End If
        ElseIf Not Session("REDIRECT_PAG") Is Nothing Then
            Dim strPag As String = Session("REDIRECT_PAG")
            Session.Remove("REDIRECT_PAG")
            Server.Transfer(strPag)
        End If

        'Carga catálogos de Aplicación y Version
        Cache("mdsAplicaciones") = CargaCatalogos(tTicket, rRespuesta)
        Cache("mdsAplicaciones").Tables(0).TableName = "Aplicacion"

        'Llenar los combos
        BindCombos()

    End Sub

    Private Function CargaCatalogos(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As DataSet

        ' Cargar los catálogos de Aplicaciones y VersionAplicación ligados entre ellos
        ' Guardar el número de VersionAplicacion actual
        Dim sv As Core = New Core

        Dim dsAplicaciones As DataSet = sv.ColAplicacionVersionPermiso(ptTicket, prRespuesta)        

        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            Return dsAplicaciones
        Else
            Return Nothing
        End If

        dsAplicaciones = Nothing
        sv = Nothing

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
        grdVerApp.DataSource = ds
        Session(SESSIONKEY_DATASOURCE) = ds

        BindData()

        ' Guardar el valor de la AplicaciónID y no perderlo!
        Me.hiddenAplicacionID.Value = grdVerApp.Items(0).Cells(7).Text

    End Sub

    Private Sub BindData()

        grdVerApp.DataSource = Cache("dsAplicaciones")
        grdVerApp.DataMember = "VersionAplicacion"
        grdVerApp.DataBind()
        Cache("dsAplicaciones").tables(0).rows.count()

    End Sub

    Private Sub grdVerApp_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdVerApp.EditCommand

        If e.Item.ItemType = ListItemType.Pager OrElse _
            e.Item.ItemType = ListItemType.Header Then Exit Sub
        Try
            grdVerApp.EditItemIndex = e.Item.ItemIndex
            BindData()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub

    Private Sub grdVerApp_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdVerApp.CancelCommand
        'Obentemos el datatow el cuál se estaba editando
        If grdVerApp.Items(grdVerApp.EditItemIndex).Cells(1).Text = "&nbsp;" OrElse _
            grdVerApp.Items(grdVerApp.EditItemIndex).Cells(1).Text = "" Then
            Session(SESSIONKEY_DATASOURCE).Tables("VersionAplicacion").DefaultView().Delete(Session(SESSIONKEY_DATASOURCE).Tables("VersionAplicacion").DefaultView().Count - 1)
        End If
        grdVerApp.EditItemIndex = -1
        grdVerApp.SelectedIndex = -1
        BindData()

    End Sub

    Private Sub grdVerApp_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdVerApp.DeleteCommand
        DeleteItem(e.Item.ItemIndex)
    End Sub

    Private Sub DeleteItem(ByVal strID As Integer)
        Try

            Dim str As String

            str = EjecutaAccion(strID, OperacionesABC.operBaja)

            If grdVerApp.Items.Count = 1 AndAlso grdVerApp.CurrentPageIndex > 0 Then
                grdVerApp.CurrentPageIndex = grdVerApp.CurrentPageIndex - 1
            End If

            'Actualizar grid
            CargaDS(Me.hiddenAplicacionID.Value)

            grdVerApp.EditItemIndex = -1

        Catch exp As Exception
            Response.Write(exp.Message)
        End Try

    End Sub

    Private Sub grdVerApp_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdVerApp.UpdateCommand
        Dim str As String

        'Validar que se haya capturado al menos los siguientes datos
        If CType(grdVerApp.Items(e.Item.ItemIndex).Cells(1).Controls(0), TextBox).Text = "" Then
            MsgBox1.ShowMessage("El campo Mayor, es requerido.")
            Exit Sub
        End If
        If Not IsNumeric(CType(grdVerApp.Items(e.Item.ItemIndex).Cells(1).Controls(0), TextBox).Text) Then
            MsgBox1.ShowMessage("El campo Mayor, debe de ser númerico.")
            Exit Sub
        End If

        If CType(grdVerApp.Items(e.Item.ItemIndex).Cells(2).Controls(0), TextBox).Text = "" Then
            MsgBox1.ShowMessage("El campo Menor, es requerido.")
            Exit Sub
        End If
        If Not IsNumeric(CType(grdVerApp.Items(e.Item.ItemIndex).Cells(2).Controls(0), TextBox).Text) Then
            MsgBox1.ShowMessage("El campo Menor, debe de ser númerico.")
            Exit Sub
        End If

        If CType(grdVerApp.Items(e.Item.ItemIndex).Cells(3).Controls(0), TextBox).Text = "" Then
            MsgBox1.ShowMessage("El campo Revisión, es requerido.")
            Exit Sub
        End If
        If Not IsNumeric(CType(grdVerApp.Items(e.Item.ItemIndex).Cells(3).Controls(0), TextBox).Text) Then
            MsgBox1.ShowMessage("El campo Revisión, debe de ser númerico.")
            Exit Sub
        End If

        'Llena el valor de VersionAplicacion       
        If grdVerApp.Items(e.Item.ItemIndex).Cells(0).Text <> "" AndAlso _
            grdVerApp.Items(e.Item.ItemIndex).Cells(0).Text <> "&nbsp;" Then
            'Cambio
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operCambio)
        Else
            'Alta
            str = EjecutaAccion(e.Item.ItemIndex, OperacionesABC.operAlta)
        End If

        MsgBox1.ShowMessage(str)

        grdVerApp.EditItemIndex = -1

        ' Refresca el DataSet
        CargaDS(CInt(Me.hiddenAplicacionID.Value))

    End Sub

    Private Sub CargaDS(ByVal pintAplicacionID As Integer)

        'Introducir aquí el código de usuario para inicializar la página
        Dim tTicket As IDTicket
        Dim rRespuesta As Respuesta = Nothing
        Dim dsVersionAplicacion As DataSet

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

        Dim strRes As String = Session("DebeCambiarPwd")
        If strRes <> String.Empty Then
            If CType(strRes, Boolean) Then
                Server.Transfer("Wfrm_CambiaPwd.aspx?index=0")
                'TODO: Asegurarse de que sale de la página
            End If
        ElseIf Not Session("REDIRECT_PAG") Is Nothing Then
            Dim strPag As String = Session("REDIRECT_PAG")
            Session.Remove("REDIRECT_PAG")
            Server.Transfer(strPag)
        End If

        dsVersionAplicacion = CargaVersionAplicacion(tTicket, pintAplicacionID, rRespuesta)

        If dsVersionAplicacion.Tables.Count > 0 Then

            dsVersionAplicacion.Tables(0).TableName = "VersionAplicacion"
            Session(SESSIONKEY_DATASOURCE) = dsVersionAplicacion

            'Actualizar el cache del dataset completo
            CargaDG(dsVersionAplicacion, False)

        ElseIf rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then

            Response.Write(rRespuesta.RespuestaToString)

        End If

        tTicket = Nothing

    End Sub

    Private Sub CargaDG(ByVal oDS As DataSet, ByVal blnExpandible As Boolean)
        'map the tables that are returned from the DB to the ones we will create in the dataset
        oDS.Tables(0).TableName = "VersionAplicacion"
        Cache("dsAplicaciones") = oDS
        BindData()
    End Sub

    Private Function CargaAplicaciones(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As DataSet
        Dim sv As Core = New Core
        Dim dsAplicaciones As DataSet = sv.ColAplicacionVersionPermiso(ptTicket, prRespuesta)
        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            Return dsAplicaciones
        Else
            Return Nothing
        End If
        dsAplicaciones = Nothing
        sv = Nothing
    End Function

    Private Function CargaVersionAplicacion(ByRef ptTicket As IDTicket, ByVal pintAplicacionID As Integer, ByRef prRespuesta As Respuesta) As DataSet
        Dim sv As Core = New Core
        Dim dsVersionesAplicaciones As DataSet = sv.ColVersionAplicacion(ptTicket, pintAplicacionID, prRespuesta)
        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            Return dsVersionesAplicaciones
        Else
            Return Nothing
        End If
        dsVersionesAplicaciones = Nothing
        sv = Nothing
    End Function

    Private Function EjecutaAccion(ByVal Index As Long, ByVal op As String) As String

        Dim aVersionAplicacion As Portalv9.SvrUsr.VersionAplicacion = Nothing
        Dim rRespuesta As New Portalv9.SvrUsr.Respuesta
        Dim sv As Portalv9.SvrUsr.Core
        Dim strMsg As String = String.Empty
        Dim tTicket As IDTicket

        Try

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Portalv9.SvrUsr.Core
            aVersionAplicacion = New Portalv9.SvrUsr.VersionAplicacion

            With aVersionAplicacion
                If op <> 0 Then
                    .VersionAplicacionID = grdVerApp.Items(Index).Cells(0).Text
                End If
                If op <> 1 Then
                    .AplicacionID = Me.hiddenAplicacionID.Value
                    .Descripcion = CType(grdVerApp.Items(Index).Cells(4).Controls(0), TextBox).Text
                    .Mayor = CType(grdVerApp.Items(Index).Cells(1).Controls(0), TextBox).Text
                    .Menor = CType(grdVerApp.Items(Index).Cells(2).Controls(0), TextBox).Text
                    .Revision = CType(grdVerApp.Items(Index).Cells(3).Controls(0), TextBox).Text
                End If
            End With

            sv.ABC_VersionAplicacion(tTicket, aVersionAplicacion, op, rRespuesta)

            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                strMsg = "Se ejecutó correctamente la operacion de cambio solicitada. "
            Else
                strMsg = "Ocurrió un error al intentar la operación solicitada: " & rRespuesta.RespuestaToString
            End If

        Catch ex As Exception

            strMsg = ex.Message

        Finally

            sv = Nothing
            If Not aVersionAplicacion Is Nothing Then
                aVersionAplicacion = Nothing
            End If
            rRespuesta = Nothing

        End Try

        EjecutaAccion = strMsg

    End Function

    Private Sub btnAdVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdVersion.Click
        Try
            If ddlApp.SelectedValue.ToString <> "" Then
                Agregar_Registro()
            Else
                MsgBox1.ShowMessage("Para agregar una versión, debe dar de alta primero una aplicación.")
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub Agregar_Registro()

        Dim tTicket As IDTicket

        'Si el número de registros en el grid es igual al límite de registros por página
        If grdVerApp.Items.Count = grdVerApp.PageSize Then
            'Cambia de página
            grdVerApp.CurrentPageIndex = grdVerApp.PageCount - 1
            'Actualiza el grid
            BindData()
        End If

        Dim intTotalItemsGrid As Integer
        intTotalItemsGrid = grdVerApp.Items.Count + grdVerApp.PageSize * grdVerApp.CurrentPageIndex

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)

        Dim dv As DataView = Session(SESSIONKEY_DATASOURCE).Tables("VersionAplicacion").DefaultView
        If dv.Count <= intTotalItemsGrid Then
            dv.AddNew()
        End If

        'Tiene que recorrer toda la lista hasta el final hasta que haya lugar
        'para meter el registro nuevo
        If grdVerApp.Items.Count = grdVerApp.PageSize Then
            'Debe agregar en la siguiente página, ésta ya se llenó
            grdVerApp.CurrentPageIndex = grdVerApp.CurrentPageIndex + 1
            grdVerApp.EditItemIndex = 0
        Else
            grdVerApp.EditItemIndex = grdVerApp.Items.Count()
        End If

        With grdVerApp
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
                        Server.Transfer("Wfrm_CambiaPwd.aspx?index=0")
                        Exit Try
                    End If
                End If
                CargaDS(Me.hiddenAplicacionID.Value)
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.ToString)
        End Try
    End Sub

    Private Sub grdVerApp_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdVerApp.ItemDataBound
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
            l = CType(e.Item.Cells(6).Controls(0), LinkButton)
            l.Attributes.Add("onclick", "return getconfirm();")
        End If
    End Sub

    Private Sub grdVerAppUser_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdVerApp.PageIndexChanged
        Try
            grdVerApp.CurrentPageIndex = e.NewPageIndex
            grdVerApp.EditItemIndex = -1
            grdVerApp.SelectedIndex = -1
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
        'Validar que exista al menos un registro en el combo para mostrar datos
        If ddlApp.SelectedValue.ToString <> "" Then
            Me.hiddenAplicacionID.Value = ddlApp.SelectedValue.ToString
            CargaDS(CInt(Me.hiddenAplicacionID.Value))
        End If
    End Sub

End Class