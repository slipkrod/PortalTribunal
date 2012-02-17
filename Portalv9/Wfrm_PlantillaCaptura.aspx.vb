Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxRoundPanel
Imports DevExpress.Web.ASPxCallbackPanel

Partial Public Class Wfrm_PlantillaCaptura
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim descarch As String
    Dim aux As Integer = 0    
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargaArchivo()
            aspxtreenivel.DataBind()
            aspxtreenivel.ExpandToLevel(1)
            lblTitle.Text = "Archivo->Fondos->" & descarch
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If            
            If aspxtreenivel.Nodes.Count > 1 Then
                aspxtreenivel.Nodes(0).Selected = True
            End If
            aspxTreenivel_FocusedNodeChanged(1)
        End If

    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


    Private Sub CargaArchivo()
        Dim sv As New WSArchivo.Service1
        Dim dsArchivo As DataSet
        dsArchivo = sv.ListaArchivo(Request.QueryString("idArchivo"))
        If dsArchivo.Tables(0).Rows.Count > 0 Then
            lblidNorma.Text = dsArchivo.Tables(0).Rows(0).Item("idNorma")
            descarch = dsArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")
        End If
    End Sub

    Protected Sub dsTipoDeExpediente_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsTipoDeExpediente.Selecting
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            e.InputParameters("NoIdentidad") = tTicket.NoIdentidad
            If Session("idNivel") Is Nothing Or e.InputParameters("idNivel") Is Nothing Then
                If Not aspxtreenivel.FocusedNode Is Nothing Then Session("idNivel") = aspxtreenivel.FocusedNode.GetValue("idNivel")
                e.InputParameters("idNivel") = Session("idNivel")
            End If
        Catch ex As Exception
            LogOff()
        End Try
    End Sub


    Protected Sub cbSerie_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Try
            Session("idNivel") = e.Parameter.ToString
            dsTipoDeExpediente.Select()
            CType(CType(aspxtreenivel, ASPxTreeList).FindEditFormTemplateControl("cbSerie"), ASPxComboBox).DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub aspxtreenivel_NodeInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxtreenivel.NodeInserting
        Try
            e.NewValues("idNivel") = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("dlNiveles"), ASPxComboBox).SelectedItem.Value
            e.NewValues("idSerie") = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("cbSerie"), ASPxComboBox).SelectedItem.Value
            e.NewValues("Descripcion") = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("txtdescripcion"), ASPxTextBox).Text
            If aspxtreenivel.NewNodeParentKey = "" Then
                e.NewValues("idDocumentoPID") = 0
            Else
                e.NewValues("idDocumentoPID") = aspxtreenivel.NewNodeParentKey
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message.ToString)
        End Try
    End Sub

    Protected Sub aspxtreenivel_NodeDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles aspxtreenivel.NodeDeleting

    End Sub

    Protected Sub aspxtreenivel_NodeUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles aspxtreenivel.NodeUpdating
        Try
            e.NewValues("idNivel") = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("dlNiveles"), ASPxComboBox).SelectedItem.Value
            e.NewValues("idSerie") = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("cbSerie"), ASPxComboBox).SelectedItem.Value
            e.NewValues("Descripcion") = CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("txtdescripcion"), ASPxTextBox).Text
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message.ToString)
        End Try
    End Sub

    Protected Sub ObjectDataSource1_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Inserting
        Try
            If e.InputParameters("idArchivo") Is Nothing Then
                e.InputParameters("idArchivo") = Request.QueryString("idArchivo").ToString()
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message.ToString)
        End Try
    End Sub

    Protected Sub ObjectDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource1.Selecting
        Try
            If Request.QueryString("idDescripcion") Is Nothing Then
                Session("DSidDescripcion") = -1
            Else
                Session("DSidDescripcion") = Request.QueryString("idDescripcion").ToString()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub aspxtreenivel_NodeValidating(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListNodeValidationEventArgs) Handles aspxtreenivel.NodeValidating
        Try
            e.NodeError = ""
            If CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("dlNiveles"), ASPxComboBox).SelectedItem Is Nothing Then e.NodeError += "Debe proporcionar el Tipo de Nivel.<br>"
            If CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("cbSerie"), ASPxComboBox).SelectedItem Is Nothing Then
                e.NodeError += "Debe proporcionar el Tipo de Expediente.<br>"
            End If
            If String.IsNullOrEmpty(CType(CType(sender, ASPxTreeList).FindEditFormTemplateControl("txtdescripcion"), ASPxTextBox).Text) Then e.NodeError += "Debe proporcionar el Titulo.<br>"
        Catch ex As Exception
            e.NodeError = ex.Message
        End Try
    End Sub

    Protected Sub btnUpdtae_Click(ByVal sender As Object, ByVal e As EventArgs)
        aspxtreenivel.UpdateEdit()
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        aspxtreenivel.CancelEdit()
    End Sub

    Protected Sub dsTipoDeExpediente_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsTipoDeExpediente.Selected
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub aspxTreenivel_FocusedNodeChanged(ByVal Pantalla As Integer)
        If Not aspxtreenivel.FocusedNode Is Nothing Then
            Select Case Pantalla
                Case 1
                    iframeIndices.Attributes("src") = "Wfm_Indices_Lectura.aspx?idNorma=" & Request.QueryString("idNorma") & _
                                    "&idArchivo=" & aspxtreenivel.FocusedNode.GetValue("idArchivo") & _
                                    "&idSerie=" & aspxtreenivel.FocusedNode.GetValue("idSerie") & _
                                    "&idNivel=" & aspxtreenivel.FocusedNode.GetValue("idNivel") & _
                                    "&idDescripcion=" & aspxtreenivel.FocusedNode.GetValue("idDescripcion") & "&Logico=-1"

                Case 2
                    iframeIndices.Attributes("src") = "Wfm_Captura_Tipo_expediente.aspx?idNorma=" & Request.QueryString("idNorma") & _
                                    "&idArchivo=" & aspxtreenivel.FocusedNode.GetValue("idArchivo") & _
                                    "&idSerie=" & aspxtreenivel.FocusedNode.GetValue("idSerie") & _
                                    "&idNivel=" & aspxtreenivel.FocusedNode.GetValue("idNivel") & _
                                    "&idDescripcion=" & aspxtreenivel.FocusedNode.GetValue("idDescripcion") & "&Logico=-1"
                Case 3
                    iframeIndices.Attributes("src") = "Wfm_Indices_Editar.aspx?idNorma=" & Request.QueryString("idNorma") & _
                                    "&idArchivo=" & aspxtreenivel.FocusedNode.GetValue("idArchivo") & _
                                    "&idSerie=" & aspxtreenivel.FocusedNode.GetValue("idSerie") & _
                                    "&idNivel=" & aspxtreenivel.FocusedNode.GetValue("idNivel") & _
                                    "&idDescripcion=" & aspxtreenivel.FocusedNode.GetValue("idDescripcion") & "&Logico=-1"
                Case 5
                    iframeIndices.Attributes("src") = "Wfrm_Prestamos_Alta_Solicitud_Frame.aspx?idDescripcion=" & aspxtreenivel.FocusedNode.GetValue("idDescripcion")

            End Select
        End If
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback
        aspxTreenivel_FocusedNodeChanged(e.Parameter)
    End Sub

    Private Sub aspxtreenivel_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs) Handles aspxtreenivel.HtmlRowPrepared
        Try
            If (e.RowKind = TreeListRowKind.EditForm) Then
                Session("idNivel") = e.GetValue("idNivel")
                ''ShowViewStateControlsIndices()
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message.ToString)
        End Try
    End Sub


    Protected Sub aspxtreenivel_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs) Handles aspxtreenivel.CustomCallback
        Select Case e.Argument.Split(":")(0)
            Case 1
                If Not aspxtreenivel.FocusedNode Is Nothing Then
                    iframeIndices.Attributes("src") = "Wfm_Captura_Tipo_expediente.aspx?idNorma=" & Request.QueryString("idNorma") & _
                                    "&idArchivo=" & aspxtreenivel.FocusedNode.GetValue("idArchivo") & _
                                    "&idSerie=" & aspxtreenivel.FocusedNode.GetValue("idSerie") & _
                                    "&idNivel=" & aspxtreenivel.FocusedNode.GetValue("idNivel") & _
                                    "&idDescripcion=" & aspxtreenivel.FocusedNode.GetValue("idDescripcion") & "&Logico=0"
                End If
                aspxtreenivel.JSProperties("cpValor") = 0
            Case 2
                ObjectDataSource1.Select()
                aspxtreenivel.DataBind()
                Dim nuevoNodo As TreeListNode
                nuevoNodo = aspxtreenivel.FindNodeByKeyValue(e.Argument.Split(":")(1))
                nuevoNodo.Focus()
                aspxtreenivel.JSProperties("cpValor") = 1
            Case 3
                Dim nNodo As TreeListNode
                nNodo = aspxtreenivel.FindNodeByFieldValue("Codigo_clasificacion", btEditCodigo.Text)
                If Not nNodo Is Nothing Then
                    nNodo.Focus()
                End If
                aspxtreenivel.JSProperties("cpValor") = 3
                aspxtreenivel.CollapseAll()
                nNodo.MakeVisible()
        End Select
    End Sub
    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        If container.Expanded Then
            Return container.GetValue("Imagen_Open")
        Else
            Return container.GetValue("Imagen_Close")
        End If
    End Function

    Protected Sub aspxtreenivel_CommandColumnButtonInitialize(ByVal sender As Object, ByVal e As TreeListCommandColumnButtonEventArgs) Handles aspxtreenivel.CommandColumnButtonInitialize

        If (e.ButtonType = TreeListCommandColumnButtonType.Custom) Then
            Dim node As TreeListNode = aspxtreenivel.FindNodeByKeyValue(e.NodeKey)
            'If node("idNivel").ToString() = "8" Then
            '    e.Visible = DevExpress.Web.ASPxClasses.DefaultBoolean.True
            'End If

            If node("idNivel").ToString() = "8" Then
                e.Visible = DevExpress.Web.ASPxClasses.DefaultBoolean.True
            End If

        End If

        If (e.ButtonType = TreeListCommandColumnButtonType.Delete) Then
            Dim node As TreeListNode = aspxtreenivel.FindNodeByKeyValue(e.NodeKey)
            If CType(node("idNivel").ToString(), Integer) < 7 Then
                e.Visible = DevExpress.Web.ASPxClasses.DefaultBoolean.False
            End If
        End If

    End Sub

    'Metodo de prueba

    Protected Sub Test()

    End Sub

End Class