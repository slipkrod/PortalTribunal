Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Partial Public Class Wfrm_Archivo_Elementos
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Configuración Archivo"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            'GetdataSource()
        End If
    End Sub
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

    Private Sub GetdataSource()

        Dim sv As New WSArchivo.Service1
        Dim dsAreas As DataSet
        Try

            dsAreas = sv.ListaNormas_Areas(1)
            GridArchivoElementos.DataSource = dsAreas
            GridArchivoElementos.DataBind()
            dsAreas.Dispose()
            dsAreas = Nothing
            sv = Nothing

        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try

    End Sub


#End Region

    Private Sub GridArchivoElementos_HtmlRowCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs) Handles GridArchivoElementos.HtmlRowCreated

    End Sub
End Class