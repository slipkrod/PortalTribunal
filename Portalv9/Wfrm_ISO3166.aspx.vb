
Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Partial Class Wfrm_ISO3166
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Norma ISO 3166"
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

            dsNorma = sv.Lista_ISO_3166
            aspxgdiso3166.DataSource = dsNorma
            aspxgdiso3166.DataBind()
            dsNorma.Dispose()
            dsNorma = Nothing
            sv = Nothing

        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try

    End Sub

#End Region


    Protected Sub aspxgdiso3166_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxgdiso3166.PageIndexChanged
        Try
            'GetdataSource()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Protected Sub aspxgdiso3166_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles aspxgdiso3166.RowDeleting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim clave_descripcion As String = ""
        Dim idfolio As Object = e.Keys(0)
        Dim clave_num = e.Values.Item(1)
        Dim alfa2 = e.Values.Item(2)
        Dim alfa3 = e.Values.Item(3)
        clave_descripcion = e.Values.Item(4)
        e.Cancel = True
        aspxgdiso3166.CancelEdit()
        Try
            sv.ABC_ISO_3166(1, idfolio, clave_num, alfa2, alfa3, clave_descripcion)
            'GetdataSource()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try
    End Sub


    Protected Sub aspxgdiso3166_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxgdiso3166.RowInserting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim clave_descripcion As String = ""
        Dim idfolio As Object = 0
        Dim clave_num = e.NewValues.Item(1)
        Dim alfa2 = e.NewValues.Item(2)
        Dim alfa3 = e.NewValues.Item(3)

        clave_descripcion = e.NewValues.Item(4)
        aspxgdiso3166.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_ISO_3166(0, idfolio, clave_num, alfa2, alfa3, clave_descripcion)
            'GetdataSource()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try

    End Sub

    Protected Sub aspxgdiso3166_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles aspxgdiso3166.RowUpdating
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim clave_descripcion As String = ""
        Dim idfolio As Object = e.Keys(0)
        Dim clave_num = e.NewValues.Item(1)
        Dim Alfa2 = e.NewValues.Item(2)
        Dim Alfa3 = e.NewValues.Item(3)
        clave_descripcion = e.NewValues.Item(4)

        aspxgdiso3166.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_ISO_3166(2, idfolio, clave_num, Alfa2, Alfa3, clave_descripcion)
            'GetdataSource()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try

    End Sub

   

    Private Sub aspxgdiso3166_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxgdiso3166.RowValidating
        If e.NewValues("Clave_descripcion") = Nothing Then
            e.RowError = "El nombre  no puede ser nulo."
        End If

        If e.NewValues("A2") = Nothing Then
            e.RowError = "El nombre de la clave alfa 2 no puede ser nulo."
        End If
        If e.NewValues("A3") = Nothing Then
            e.RowError = "El nombre de la clave alfa 3 no puede ser nulo."
        End If

        If e.NewValues("Clave_num") = Nothing Then
            e.RowError = "La clave númerica no puede ser nula."
        End If

    End Sub
End Class
