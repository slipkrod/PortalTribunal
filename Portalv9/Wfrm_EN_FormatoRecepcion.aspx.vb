Imports Portalv9.SvrUsr
Partial Public Class Wfrm_EN_FormatoRecepcion
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sv As New SAEX.ServiciosSAEX
            Dim dsBolsas As DataSet

            Try

                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If objGlobal.TicketValido(tTicket) Then  'Is Nothing Then
                    lblRecibe.Text = tTicket.NoIdentidad & " - " & tTicket.NombreCompleto
                End If
                Dim strRes As String = Session("DebeCambiarPwd")
                If strRes <> String.Empty Then
                    If CType(strRes, Boolean) = True Then
                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                    End If
                End If

                dsBolsas = sv.BuscaDatosBolsa(Request.QueryString("Folio_bolsa"))

                lblFecha.Text = Format(Now.Date, "yyyyMMdd")
                lblHora.Text = Now.ToShortTimeString
                lblUsuario.Text = dsBolsas.Tables(0).Rows(0).Item("idUsuario_Solicita") & " - " & dsBolsas.Tables(0).Rows(0).Item("Usuario_Solicita")


                txtFolioBolsa.Text = Request.QueryString("Folio_bolsa").ToUpper
                sv = Nothing
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try

        End If

    End Sub

End Class