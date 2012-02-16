
Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1

Partial Class Wfrm_PlantillaHija
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim mensaje As String
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Normas->Plantillas  [" & Request.QueryString("Norma") & "]"
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

    Protected Sub aspxgdplantillahija_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim plantilla_descripcion As String = ""
        Dim IdNorma As String
        Dim key As Object = e.Keys(0)
        IdNorma = Request.QueryString("idNorma")
        plantilla_descripcion = e.NewValues.Item(0)

        aspxgdplantillahija.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_Normas_plantillas(2, IdNorma, key, plantilla_descripcion)
        Catch ex As Exception
            mensaje = ex.Message.ToString
        Finally
            sv = Nothing
        End Try

    End Sub

    Protected Sub aspxgdplantillahija_CustomJSProperties(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs) Handles aspxgdplantillahija.CustomJSProperties
        e.Properties("cpmensaje") = mensaje
    End Sub


    Protected Sub aspxgdplantillahija_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxgdplantillahija.RowInserting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim plantilla_descripcion As String = ""
        Dim IdNorma As String
        IdNorma = Request.QueryString("idNorma")
        plantilla_descripcion = e.NewValues.Item(0)
        aspxgdplantillahija.CancelEdit()
        e.Cancel = True
        Try
            sv.ABC_Normas_plantillas(0, IdNorma, 0, plantilla_descripcion)
        Catch ex As Exception
            mensaje = ex.Message.ToString
        Finally
            sv = Nothing
        End Try

    End Sub

    Protected Sub aspxgdplantillahija_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim plantilla_descripcion As String = ""
        Dim IdNorma As String = Request.QueryString("idNorma")
        Dim key As Object = e.Keys(0)
        e.Cancel = True
        aspxgdplantillahija.CancelEdit()
        plantilla_descripcion = e.Values.Item(2)
        Try
            sv.ABC_Normas_plantillas(1, IdNorma, key, plantilla_descripcion)
        Catch ex As Exception
            mensaje = ex.Message.ToString
        Finally
            sv = Nothing
        End Try
    End Sub

    Protected Sub aspxgdplantillahija_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)
        Try
            Select Case e.CommandArgs.CommandName.ToString
                Case "Pantalla"
                    Response.Redirect("Wfrm_Plantillaedicion.aspx?idPlantilla=" & e.KeyValue & "&Norma=" & HttpUtility.UrlEncode(Request.QueryString("Norma")) & "&idNorma=" & HttpUtility.UrlEncode(Request.QueryString("idNorma")))
            End Select
        Catch ex As Exception
            mensaje = ex.Message.ToString
        End Try
    End Sub

    Protected Sub aspxgdplantillahija_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxgdplantillahija.PageIndexChanged
        Try

        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub aspxgdplantillahija_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles aspxgdplantillahija.RowValidating
        If e.NewValues("Plantilla_descripcion") = Nothing Then
            e.RowError = "El nombre de la pantalla no puede ser nulo."
        End If
    End Sub


End Class

