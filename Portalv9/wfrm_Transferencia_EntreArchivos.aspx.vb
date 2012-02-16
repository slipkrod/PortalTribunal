Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Partial Public Class wfrm_Transferencia_EntreArchivos
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim svr As New SAEX.ServiciosSAEX
        If Not IsPostBack Then
            Try
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    LogOff()
                    Exit Sub
                End If
                Dim strRes As String = Session("DebeCambiarPwd")
                If strRes <> String.Empty Then
                    If CType(strRes, Boolean) = True Then
                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                    End If
                End If
                ASPxTreeList1.DataBind()
                ASPxTreeList2.DataBind()
            Catch ex As Exception

            End Try
        Else

        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
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

    Protected Sub Transferir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Transferir.Click
        Dim svrArchivo As New WSArchivo.Service1
        Dim listOrigen As List(Of TreeListNode) = ASPxTreeList1.GetSelectedNodes()
        Dim listDestino As List(Of TreeListNode) = ASPxTreeList2.GetSelectedNodes()
        Dim valorPadreDestino As Integer
        Try
            If svrArchivo.ListaArchivo(cmbArchivo.SelectedItem.Value).Tables(0).Rows(0)("idNorma") <> svrArchivo.ListaArchivo(cmbArchivoDestino.SelectedItem.Value).Tables(0).Rows(0)("idNorma") Then
                ASPxTreeList2.UnselectAll()
                MsgBox1.ShowMessage("No se puede transferir nodos entre archivos con diferentes normas.")
                Return
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage("Error en las normas de los archivos, recuerde que no se puede transferir nodos entre archivos con diferentes normas. <br>" & ex.Message)
        End Try
        Try
            Dim myAlert As String = ""
            For Each nNodeOrigen As TreeListNode In listDestino
                valorPadreDestino = nNodeOrigen.Key
                For Each nNode As TreeListNode In listOrigen
                    If cmbArchivo.SelectedItem.Value = cmbArchivoDestino.SelectedItem.Value And nNode.Key = valorPadreDestino Then
                        myAlert = "Al menos uno de los nodos no se pudo transferir ya que se intento tranferir a el mismo"
                    Else
                        svrArchivo.Transfiere_Archivo_Descripciones(cmbArchivo.SelectedItem.Value, nNode.Key, cmbArchivoDestino.SelectedItem.Value, valorPadreDestino)
                    End If
                Next
            Next
            If myAlert <> "" Then
                MsgBox1.ShowMessage(myAlert)
            Else
                MsgBox1.ShowMessage("La transferencia se ha realizado con éxito..")
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            ReSetNodes()
        End Try
    End Sub

    Sub ReSetNodes()
        ASPxTreeList1.UnselectAll()
        ASPxTreeList2.UnselectAll()
        dsListaFondo.Select()
        dsBuscaExpediente.Select()
        ASPxTreeList1.DataBind()
        ASPxTreeList2.DataBind()
    End Sub

    Protected Sub dsBuscaExpediente_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsBuscaExpediente.Selecting
        If IsPostBack And cmbArchivo.SelectedIndex > -1 Then
            e.InputParameters("idArchivo") = cmbArchivo.SelectedItem.Value
            e.InputParameters("Entidad") = ""
            e.InputParameters("Area") = ""
            e.InputParameters("Tipo_expediente") = -1
            e.InputParameters("ano") = ""
            e.InputParameters("mes") = ""
            e.InputParameters("dia") = ""
        End If
    End Sub

    Protected Sub dsListaFondo_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsListaFondo.Selecting
        If IsPostBack And cmbArchivoDestino.SelectedIndex > -1 Then
            e.InputParameters("idArchivo") = cmbArchivoDestino.SelectedItem.Value
        End If
    End Sub

    Protected Sub cmbArchivo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbArchivo.SelectedIndexChanged
        ASPxTreeList1.UnselectAll()
        dsBuscaExpediente.SelectParameters.Item("idArchivo").DefaultValue = cmbArchivo.SelectedItem.Value
        dsBuscaExpediente.Select()
    End Sub

    Protected Sub cmbArchivoDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbArchivoDestino.SelectedIndexChanged
        ASPxTreeList2.UnselectAll()
        ASPxTreeList2.ClearNodes()
        ASPxTreeList2.DataBind()
        dsListaFondo.SelectParameters.Item("idArchivo").DefaultValue = cmbArchivoDestino.SelectedItem.Value
        dsListaFondo.Select()
    End Sub

    Protected Sub dsBuscaExpediente_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsBuscaExpediente.Selected

    End Sub

    Protected Sub dsListaFondo_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsListaFondo.Selected

    End Sub
End Class