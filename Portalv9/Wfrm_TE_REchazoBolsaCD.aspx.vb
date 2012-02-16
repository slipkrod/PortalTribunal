Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_REchazoBolsaCD
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 4
    Private Const eventoOK As Integer = 5

    Private tTicket As IDTicket

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        Dim ds As DataSet
        Me.lblError.Text = ""
        'Call GetFocusRemesa()
        If Not IsPostBack Then
            Try
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    LogOff()
                    Exit Sub
                End If
                If Request.QueryString("FolioBolsa") <> "" Then
                    lblFolioBolsa.Text = Request.QueryString("FolioBolsa")
                    CargaElementos(lblFolioBolsa.Text)
                End If
            Catch ex As Exception
                Me.lblError.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Private Function CargaElementos(ByVal Folio_Bolsa As String) As Integer
        Dim sv As New SAEX.ServiciosSAEX
        Dim dsExpedientes As DataSet

        Try
            dsExpedientes = sv.BuscaInstanciaExpedientexEstadoxBolsa(Folio_Bolsa, estado)
            sv = Nothing
            If dsExpedientes.Tables(0).Rows.Count = 0 Then
                Response.Redirect("Wfrm_TE_Aviso.aspx?Aviso=" & Server.UrlEncode("Ya no existen mas expedientes por verificar del folio de bolsa: ") & Folio_Bolsa)
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try

    End Function


    Protected Sub ASPxGridExpedientes_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ASPxGridExpedientes.RowCommand        
        If e.CommandArgs.CommandName = "cmdVerificar" Then
            Response.Redirect("Wfrm_TE_RechazoBolsaCDDet.aspx?FolioBolsa=" & e.CommandArgs.CommandArgument & "&InstanciaID=" & e.KeyValue & "&idArchivo=16")
        End If
    End Sub

    Protected Sub cmdVerificar_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
End Class