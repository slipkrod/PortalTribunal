Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_MCRevisionBolsa
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 20
    Private Const eventoOK As Integer = 26
    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblError.Text = ""
        'Call GetFocusRemesa()
        If Not IsPostBack Then
            Try
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    Logoff()
                    Exit Sub
                End If
                Dim strRes As String = Session("DebeCambiarPwd")
                If strRes <> String.Empty Then
                    If CType(strRes, Boolean) = True Then
                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                    End If
                End If
                If Request.QueryString("Folio_bolsa") <> "" Then
                    lblFolioBolsa.Text = Request.QueryString("Folio_bolsa")
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
            ''grdDocumentos.DataSource = dsExpedientes
            ''grdDocumentos.DataBind()
            ''grdDocumentos.Dispose()
            ''grdDocumentos = Nothing
            sv = Nothing
            If dsExpedientes.Tables(0).Rows.Count = 0 Then
                Response.Redirect("Wfrm_TE_Aviso.aspx?Aviso=" & Server.UrlEncode("Ya no existen mas expedientes por recibir del folio de bolsa: ") & Folio_Bolsa)
            End If

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try

    End Function

End Class