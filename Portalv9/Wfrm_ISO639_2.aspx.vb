Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1

Partial Class Wfrm_ISO639_2
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Norma ISO 639-2"
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
        Dim dsNorma As DataSet
        Try

            dsNorma = sv.Lista_ISO_639_2
            aspxgdiso639.DataSource = dsNorma
            aspxgdiso639.DataBind()
           
            dsNorma.Dispose()
            dsNorma = Nothing
            sv = Nothing

        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try

    End Sub

#End Region


    Protected Sub aspxgdiso639_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxgdiso639.PageIndexChanged
        Try
            'GetdataSource()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try

    End Sub

    Protected Sub aspxgdiso639_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles aspxgdiso639.RowDeleting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim clave_descripcion As String = ""
        Dim idfolio As Object = e.Keys(0)
        Dim alfa2 = e.Values.Item(1)
        Dim alfa3 = e.Values.Item(2)
        clave_descripcion = e.Values.Item(3)
        e.Cancel = True
        aspxgdiso639.CancelEdit()
        Try
            sv.ABC_ISO_639_2(1, idfolio, alfa2, alfa3, clave_descripcion)
            'GetdataSource()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try
    End Sub

    Protected Sub aspxgdiso639_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxgdiso639.RowInserting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim clave_descripcion As String = ""
        Dim idfolio As Object = 0
        Dim alfa2 = e.NewValues.Item(1)
        Dim alfa3 = e.NewValues.Item(2)

        clave_descripcion = e.NewValues.Item(3)
        aspxgdiso639.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_ISO_639_2(0, idfolio, alfa2, alfa3, clave_descripcion)
            'GetdataSource()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try
    End Sub

    Protected Sub aspxgdiso639_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles aspxgdiso639.RowUpdating
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim clave_descripcion As String = ""
        Dim idfolio As Object = e.Keys(0)
        Dim Alfa2 = e.NewValues.Item(1)
        Dim Alfa3 = e.NewValues.Item(2)
        clave_descripcion = e.NewValues.Item(3)
        aspxgdiso639.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_ISO_639_2(2, idfolio, Alfa2, Alfa3, clave_descripcion)
            'GetdataSource()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try
    End Sub

    Private Sub aspxgdiso639_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxgdiso639.RowValidating
        If e.NewValues("Clave_descripcion") = Nothing Then
            e.RowError = "El nombre  no puede ser nulo."
        End If

        If e.NewValues("A2") = Nothing Then
            e.RowError = "El nombre de la clave alfa 2 no puede ser nulo."
        End If
        If e.NewValues("A3") = Nothing Then
            e.RowError = "El nombre de la clave alfa 3 no puede ser nulo."
        End If
    End Sub
End Class
