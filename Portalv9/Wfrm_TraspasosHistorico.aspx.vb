Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxGridView

Partial Public Class Wfrm_TraspasosHistorico
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            lbltitulo.Text = "Registro historico de valoraciones y transpasos"
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Function getFasesTrasladosByVal(ByVal sVal As String) As String
        Dim svrStats = New Portalv9.WSArchivo.Service1
        Dim myStats As New ASPxComboBox
        myStats.ValueField = "IDCatalogo_item"
        myStats.TextField = "Descripcion"
        myStats.DataSource = svrStats.ListaCatalogo_Datos(15)
        myStats.DataBind()
        Return myStats.Items.FindByValue(sVal).Text
    End Function

    Function getFasesTrasladosByText(ByVal sDescripcion As String) As Integer
        Dim svrStats = New Portalv9.WSArchivo.Service1
        Dim myStats As New ASPxComboBox
        myStats.ValueField = "IDCatalogo_item"
        myStats.TextField = "Descripcion"
        myStats.DataSource = svrStats.ListaCatalogo_Datos(15)
        myStats.DataBind()
        Return myStats.Items.FindByText(sDescripcion).Value
    End Function

    Protected Sub butRepAutorizacion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butRepAutorizacion.Click

    End Sub
End Class
