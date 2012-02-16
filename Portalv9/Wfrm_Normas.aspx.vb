Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Imports DevExpress.Web.ASPxGridView
Partial Class Wfrm_Normas
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Normas"
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

    Protected Sub aspxgdnormas_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxgdnormas.PageIndexChanged
        Try
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Protected Sub aspxgdnormas_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles aspxgdnormas.RowUpdating
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim Norma_descripcion As String = ""
        Dim key As Object = e.Keys(0)
        Norma_descripcion = e.NewValues.Item(0)
        aspxgdnormas.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_Normas(2, key, Norma_descripcion)

        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try

    End Sub
    Protected Sub aspxgdnormas_CustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewColumnDataEventArgs)
        If e.IsGetData AndAlso e.Column.FieldName = "Norma_descripcion" Then
            Dim key As Object = e.GetListSourceFieldValue(e.ListSourceRowIndex, aspxgdnormas.KeyFieldName)
        End If

    End Sub


    Protected Sub aspxgdnormas_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim Norma_descripcion As String = ""
        Dim key As Object = e.Keys(0)
        e.Cancel = True
        aspxgdnormas.CancelEdit()
        Norma_descripcion = e.Values.Item(0)
        Try
            sv.ABC_Normas(1, key, Norma_descripcion)

        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try
    End Sub

    Protected Sub aspxgdnormas_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)
        Try
            Select Case e.CommandArgs.CommandName.ToString
                Case "Areas"
                    Response.Redirect("Wfrm_Normas_Areas.aspx?idNorma=" & e.KeyValue & "&Norma=" & e.CommandArgs.CommandArgument.ToString)
                Case "Niveles"
                    Response.Redirect("Wfrm_Normas_Organizacion.aspx?idNorma=" & e.KeyValue & "&Norma=" & e.CommandArgs.CommandArgument.ToString)
                Case "Organizacion"
                    Response.Redirect("Wfrm_Normas_Organizacion.aspx?idNorma=" & e.KeyValue & "&Norma=" & e.CommandArgs.CommandArgument.ToString)
                Case "Plantilla"
                    Response.Redirect("Wfrm_PlantillaMaster.aspx?idNorma=" & e.KeyValue & "&Norma=" & e.CommandArgs.CommandArgument.ToString)
                Case "Platillaesp"
                    Response.Redirect("Wfrm_PlantillaHija.aspx?idNorma=" & e.KeyValue & "&Norma=" & e.CommandArgs.CommandArgument.ToString)
            End Select
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Protected Sub aspxgdnormas_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxgdnormas.RowInserting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim Norma_descripcion As String = ""
        Norma_descripcion = e.NewValues.Item(0)
        aspxgdnormas.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_Normas(0, 0, Norma_descripcion)
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try
    End Sub


    Private Sub aspxgdnormas_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxgdnormas.RowValidating
        If e.NewValues("Norma_descripcion") = Nothing Then
            e.RowError = "El valor del nombre no puede ser nulo."
        End If
    End Sub
End Class
