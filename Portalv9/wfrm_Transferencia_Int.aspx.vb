Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Partial Public Class wfrm_Transferencia_Int
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim svr As New SAEX.ServiciosSAEX
        If Not IsPostBack Then
            Try
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    Logoff()
                    Exit Sub
                End If
                Dim strRes As String = Session("DebeCambiarPwd")
                If strRes <> String.Empty Then
                    If CType(strRes, Boolean) = True Then
                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                    End If
                End If
                DatabindTrees()
            Catch ex As Exception

            End Try
        Else
            DatabindTrees()
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub cmbArchivo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbArchivo.SelectedIndexChanged
        Dim svrArchivo As New WSArchivo.Service1
        Dim rsTransferencia As DataSet
        If cmbArchivo.SelectedItem.GetValue("Tipo_Archivo") = 0 Then
            rsTransferencia = svrArchivo.ListaTransferencias_Primarias(1)
            If rsTransferencia.Tables(0).Rows.Count > 0 Then
                lblFolio.Text = rsTransferencia.Tables(0).Rows(0).Item("idFolio")
                chkTransferencia.ClientVisible = True
            Else
                chkTransferencia.ClientVisible = False
                lblFolio.Text = ""
            End If
            ASPxTreeList1.UnselectAll()
            ASPxTreeList2.UnselectAll()
            DatabindTrees()
        End If
    End Sub
    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        Try
            If ASPxTreeList1.FindNodeByKeyValue(container.NodeKey) Is Nothing Then
                Return "~/images/Separador.gif"
            Else
                If ASPxTreeList1.FindNodeByKeyValue(container.NodeKey).GetValue("imagen_close") Is Nothing Then
                    Return "~/images/Separador.gif"
                Else
                    Return "~/" & ASPxTreeList1.FindNodeByKeyValue(container.NodeKey).GetValue("imagen_close")
                End If

            End If
        Catch ex As Exception
            Return "~/images/Separador.gif"
        End Try
    End Function
    Protected Function GetNodeGlyphB(ByVal container As TreeListDataCellTemplateContainer) As String
        Try
            If ASPxTreeList2.FindNodeByKeyValue(container.NodeKey) Is Nothing Then
                Return "~/images/Separador.gif"
            Else
                If ASPxTreeList2.FindNodeByKeyValue(container.NodeKey).GetValue("imagen_close") Is Nothing Then
                    Return "~/images/Separador.gif"
                Else
                    Return "~/" & ASPxTreeList2.FindNodeByKeyValue(container.NodeKey).GetValue("imagen_close")
                End If

            End If
        Catch ex As Exception
            Return "~/images/Separador.gif"
        End Try
    End Function

    'Protected Sub ASPxTreeList2_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxTreeList2.SelectionChanged
    '    Dim treeList As ASPxTreeList = TryCast(sender, ASPxTreeList)

    '    If treeList.SelectionCount = 1 Then ' One node is selected within the control
    '        Session("PrevSelectedNodeKey") = treeList.GetSelectedNodes()(0).Key
    '    End If

    '    If treeList.SelectionCount > 1 Then ' Applies selection to the last selected node, if two nodes are selected
    '        Dim prevSelectedNode As TreeListNode = treeList.FindNodeByKeyValue(Session("PrevSelectedNodeKey").ToString())
    '        prevSelectedNode.Selected = False
    '        Session("PrevSelectedNodeKey") = treeList.GetSelectedNodes()(0).Key
    '    End If
    'End Sub

    Protected Sub Transferir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Transferir.Click
        Dim svrArchivo As New WSArchivo.Service1
        Dim listOrigen As List(Of TreeListNode) = ASPxTreeList1.GetSelectedNodes()
        Dim listDestino As List(Of TreeListNode) = ASPxTreeList2.GetSelectedNodes()
        Dim valorPadreDestino As Integer

        Try
            For Each nNode As TreeListNode In listDestino
                valorPadreDestino = nNode.Key
            Next
            For Each nNode As TreeListNode In listOrigen
                If nNode.Key = valorPadreDestino Then
                Else
                    svrArchivo.Transfiere_Archivo_Descripciones(cmbArchivo.SelectedItem.Value, nNode.Key, cmbArchivo.SelectedItem.Value, valorPadreDestino)
                End If
            Next
            MsgBox1.ShowMessage("La transferencia se ha realizado con éxito..")

            ASPxTreeList1.UnselectAll()
            ASPxTreeList2.UnselectAll()
            DatabindTrees()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub


    Protected Sub chkTransferencia_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTransferencia.CheckedChanged
        ASPxTreeList1.UnselectAll()
        ASPxTreeList2.UnselectAll()
        DatabindTrees()
    End Sub

    Private Sub DatabindTrees()

        If chkTransferencia.ClientVisible And chkTransferencia.Checked Then
            dsBuscaExpedienteFiltrado.SelectParameters.Item("idArchivo").DefaultValue = cmbArchivo.SelectedItem.Value
            dsBuscaExpedienteFiltrado.SelectParameters.Item("idFolio").DefaultValue = lblFolio.Text
            dsBuscaExpedienteFiltrado.Select()
            ASPxTreeList1.DataSourceID = "dsBuscaExpedienteFiltrado"
            ASPxTreeList1.DataBind()

            dsListaFondoFiltrado.SelectParameters.Item("idArchivo").DefaultValue = cmbArchivo.SelectedItem.Value
            dsListaFondoFiltrado.SelectParameters.Item("idFolio").DefaultValue = lblFolio.Text
            dsListaFondoFiltrado.Select()
            ASPxTreeList2.DataSourceID = "dsListaFondoFiltrado"
            ASPxTreeList2.DataBind()
        Else
            dsBuscaExpediente.SelectParameters.Item("idArchivo").DefaultValue = cmbArchivo.SelectedItem.Value
            dsBuscaExpediente.Select()
            ASPxTreeList1.DataSourceID = "dsBuscaExpediente"
            ASPxTreeList1.DataBind()

            dsListaFondo.SelectParameters.Item("idArchivo").DefaultValue = cmbArchivo.SelectedItem.Value
            dsListaFondo.Select()
            ASPxTreeList2.DataSourceID = "dsListaFondo"
            ASPxTreeList2.DataBind()
        End If
    End Sub

    Protected Sub btnExpand_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExpand.Click
        ASPxTreeList1.ExpandAll()
        ASPxTreeList2.ExpandAll()
    End Sub

    Protected Sub btnCollapse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCollapse.Click
        ASPxTreeList1.CollapseAll()
        ASPxTreeList2.CollapseAll()
    End Sub
End Class