Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Partial Class Wfrm_ISO15924
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Norma ISO 15924"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
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

    
#End Region

    Protected Sub aspxgdiso15924_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim clave_descripcion As String = ""
        Dim idfolio As Object = e.Keys(0)
        Dim clave_num = e.NewValues.Item(1)
        Dim clave = e.NewValues.Item(2)
        clave_descripcion = e.NewValues.Item(3)

        aspxgdiso15924.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_ISO_15924(2, idfolio, clave_num, clave, clave_descripcion)
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try

    End Sub


    Protected Sub aspxgdiso15924_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxgdiso15924.RowInserting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim clave_descripcion As String = ""
        Dim idfolio As Object = 0
        Dim clave_num = e.NewValues.Item(1)
        Dim clave = e.NewValues.Item(2)
        clave_descripcion = e.NewValues.Item(3)
        aspxgdiso15924.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_ISO_15924(0, idfolio, clave_num, clave, clave_descripcion)
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try
    End Sub

    Protected Sub aspxgdiso15924_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim clave_descripcion As String = ""
        Dim idfolio As Object = e.Keys(0)
        Dim clave_num = e.Values.Item(1)
        Dim clave = e.Values.Item(2)
        clave_descripcion = e.Values.Item(3)
        e.Cancel = True
        aspxgdiso15924.CancelEdit()
        Try
            sv.ABC_ISO_15924(1, idfolio, clave_num, clave, clave_descripcion)
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try
    End Sub

    Protected Sub aspxgdiso15924_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxgdiso15924.PageIndexChanged
        Try
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub aspxgdiso15924_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxgdiso15924.RowValidating
        If e.NewValues("Clave_descripcion") = Nothing Then
            e.RowError = "El nombre de la ISO no puede ser nulo."
        End If
        If e.NewValues("Clave") = Nothing Then
            e.RowError = "El nombre de la clave alfa no puede ser nulo."
        End If

        If e.NewValues("Clave_num") = Nothing Then
            e.RowError = "La clave númerica no puede ser nula."
        End If
    End Sub
End Class
