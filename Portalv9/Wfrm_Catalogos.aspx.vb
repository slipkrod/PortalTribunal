Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Partial Public Class Wfrm_Catalogos
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Catálogos del sistema"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub aspxgdCatalogos_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles aspxgdCatalogos.RowCommand
        Try
            Select Case e.CommandArgs.CommandName.ToString
                Case "btnDatos"
                    Response.Redirect("Wfrm_Catalogos_datos.aspx?IDCatalogo=" & e.KeyValue & "&Catalogo=" & e.CommandArgs.CommandArgument.ToString)
            End Select
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub
End Class