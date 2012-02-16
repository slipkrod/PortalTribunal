Imports Portalv9.SvrUsr
Partial Public Class Wfrm_RE_FormatoRecepcion
    Inherits System.Web.UI.Page

    Private tTicket As IDTicket
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not IsPostBack Then
            Dim sv As New SAEX.ServiciosSAEX
            Dim dsBolsas As DataSet

            Try

                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    LogOff()
                    Exit Sub
                End If
                If objGlobal.TicketValido(tTicket) Then  'Is Nothing Then
                    lblRecibe.Text = tTicket.NoIdentidad & " - " & tTicket.NombreCompleto
                End If

                lblTitle.Text = "Recolección->Oficinas/Recepción de folios"

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

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

End Class
