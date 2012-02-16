Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_RecepMC
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 6
    Private Const eventoOK As Integer = 25
    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Introducir aquí el código de usuario para inicializar la página

        Me.lblerror.Text = ""
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

            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End If

    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub ibtnrecibir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnrecibir.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim dsBolsa As DataSet
        lblerror.Text = ""
        Try

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                LogOff()
            End If


            lblerror.Text = ""
            dsBolsa = svr.BuscaInstanciaXBolsa(txtfoliobolsa.Text)
            If dsBolsa.Tables(0).Rows.Count = 0 Then
                lblerror.Text = "No existe ese folio de bolsa..."
            Else
                If dsBolsa.Tables(0).Rows(0).Item("EstadoID") = estado Then
                    svr.TransitaInstanciaxBolsa(txtfoliobolsa.Text, eventoOK, "", tTicket.UsrID)
                    txtfoliobolsa.Text = ""
                Else
                    lblerror.Text = "La bolsa no se encuentra en Centro de Distribución..."
                End If
            End If
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub
End Class