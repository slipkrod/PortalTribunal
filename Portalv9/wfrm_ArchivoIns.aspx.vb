﻿Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1

Partial Class wfrm_ArchivoIns
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Archivo"
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


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sv As New WSArchivo.Service1
        sv.ABC_Archivos(WSArchivo.OperacionesABC.operAlta, 0, dlNormas.SelectedItem.Value, txtArchivo.Text, txtCodigo.Text, dlTipoArchivo.SelectedItem.Value)
        Response.Redirect("Wfrm_Archivo.aspx")
    End Sub
End Class