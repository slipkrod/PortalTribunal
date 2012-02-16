Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Partial Class Wfrm_Normas_Elementos
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim Mensaje As String
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Normas->Areas->Elementos   [" & Request.QueryString("Norma") & "->" & Request.QueryString("Area") & "]"
            'Regresar.NavigateUrl = "Wfrm_Normas_Areas.aspx?idNorma=" & Request.QueryString("idNorma") & "&Norma=" & HttpUtility.UrlEncode(Request.QueryString("Norma"))
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
    Protected Sub aspxgelementos_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim Elemento_descripcion As String = ""
        Dim folio_norma As String = ""
        Dim IdNorma As String = Request.QueryString("idNorma")
        Dim IdArea As String = Request.QueryString("idArea")
        Dim key As Object = e.Keys(0)
        Elemento_descripcion = e.NewValues.Item(1)
        folio_norma = e.NewValues.Item(0)

        aspxgdelementos.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_Normas_Elementos(2, IdNorma, IdArea, key, Elemento_descripcion, folio_norma)

        Catch ex As Exception
            Mensaje = ex.Message.ToString
        Finally
            sv = Nothing
        End Try

    End Sub

    Protected Sub aspxgdelementos_CustomJSProperties(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs) Handles aspxgdelementos.CustomJSProperties
        e.Properties("cpmensaje") = Mensaje
    End Sub


    Protected Sub aspxgdelementos_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxgdelementos.RowInserting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim Elemento_descripcion As String = ""
        Dim folio_norma As String = ""
        Dim IdNorma As String = Request.QueryString("idNorma")
        Dim IdArea As String = Request.QueryString("idArea")
        Elemento_descripcion = e.NewValues.Item(1)
        folio_norma = e.NewValues.Item(0)
        aspxgdelementos.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_Normas_Elementos(0, IdNorma, IdArea, 0, Elemento_descripcion, folio_norma)
        Catch ex As Exception
            Mensaje = ex.Message.ToString
        Finally
            sv = Nothing
        End Try

    End Sub

    Protected Sub aspxgdelementos_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim Elemento_descripcion As String = ""
        Dim folio_norma As String = ""
        Dim IdNorma As String = Request.QueryString("idNorma")
        Dim IdArea As String = Request.QueryString("idArea")
        Dim key As Object = e.Keys(0)
        e.Cancel = True
        aspxgdelementos.CancelEdit()
        Elemento_descripcion = e.Values.Item(1)
        folio_norma = e.Values.Item(0)
        Try
            sv.ABC_Normas_Elementos(1, IdNorma, IdArea, key, Elemento_descripcion, folio_norma)
            'GetdataSource()
        Catch ex As Exception
            Mensaje = ex.Message.ToString
        Finally
            sv = Nothing
        End Try
    End Sub

    
    Private Sub aspxgdelementos_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxgdelementos.RowValidating
        If e.NewValues("Elemento_descripcion") = Nothing Then
            e.RowError = "El nombre del elemento no puede ser nulo."
        End If

        If e.NewValues("folio_norma") = Nothing Then
            e.RowError = "El folio del elemento no puede ser nulo."
        End If
    End Sub
End Class
