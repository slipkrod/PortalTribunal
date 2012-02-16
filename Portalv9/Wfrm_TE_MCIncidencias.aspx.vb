Imports System.IO
Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_MCIncidencias
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblerror.Text = ""
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
                'CargaElementos()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Sub abtnexportar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles abtnexportar.Click
        ASPxGridViewExporter1.GridViewID = "ASPxGridView1"
        ASPxGridViewExporter1.FileName = "reporteincidencias"
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub
    'Protected Sub ObjectDataSource1_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Inserting
    '    e.InputParameters("Nom_cliente") = ASPxGridView1.GetDataRow(ASPxGridView1.FocusedRowIndex).Item("Nom_cliente")
    '    e.InputParameters("Incidencia") = ASPxGridView1.GetDataRow(ASPxGridView1.FocusedRowIndex).Item("Incidencia")
    '    e.InputParameters("Ejecutivo") = ASPxGridView1.GetDataRow(ASPxGridView1.FocusedRowIndex).Item("Ejecutivo")
    '    e.InputParameters("Sucursal") = ASPxGridView1.GetDataRow(ASPxGridView1.FocusedRowIndex).Item("Sucursal")
    '    e.InputParameters("No_cuenta") = ASPxGridView1.GetDataRow(ASPxGridView1.FocusedRowIndex).Item("No_cuenta")
    '    e.InputParameters("No_cliente") = ASPxGridView1.GetDataRow(ASPxGridView1.FocusedRowIndex).Item("No_cliente")
    '    e.InputParameters("estado") = ASPxGridView1.GetDataRow(ASPxGridView1.FocusedRowIndex).Item("estado")
    'End Sub
    'Protected Sub ObjectDataSource1_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Deleting
    '    e.InputParameters("Incidenciaid") = ASPxGridView1.GetDataRow(ASPxGridView1.FocusedRowIndex).Item("Incidenciaid")
    '    e.InputParameters("Estado") = ASPxGridView1.GetDataRow(ASPxGridView1.FocusedRowIndex).Item("Incidenciaid")
    'End Sub
End Class