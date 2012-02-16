Imports Portalv9.SvrUsr
Partial Public Class Wfrm_AC_recepfolios
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 8
    Private Const eventoOK As Integer = 10
    Private Const estado1 As Integer = 85
    Private Const eventoOK1 As Integer = 88
    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                txtfoliobolsa.Focus()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Sub ibtnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnbuscar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim dsBolsa As DataSet
        lblerror.Text = ""
        Try

            chkbolsasellada.Visible = False
            lblSellada.Visible = False

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                LogOff()
            End If
            lblerror.Text = ""
            dsBolsa = svr.BuscaInstanciaXBolsa(txtfoliobolsa.Text)
            If dsBolsa.Tables(0).Rows.Count = 0 Then
                lblerror.Text = "No existe ese folio de bolsa..."
                btnaceptar.Visible = False
                btndevolver.Visible = False
            Else

                estadoactual.Text = dsBolsa.Tables(0).Rows(0).Item("EstadoID")
                Select Case dsBolsa.Tables(0).Rows(0).Item("EstadoID")
                    Case estado
                        lblSellada.Visible = True
                        chkbolsasellada.Visible = True
                        btnaceptar.Visible = False
                        btndevolver.Visible = True

                    Case estado1
                        lblSellada.Visible = True
                        chkbolsasellada.Visible = True
                        btnaceptar.Visible = False
                        btndevolver.Visible = True

                    Case Else
                        lblerror.Text = "La bolsa no se pude recibir en en Archivo Central..."
                End Select
            End If
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try

    End Sub

    Protected Sub chkbolsasellada_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkbolsasellada.CheckedChanged
        If chkbolsasellada.Checked Then
            btnaceptar.Visible = True
            btndevolver.Visible = False
        Else
            btnaceptar.Visible = False
            btndevolver.Visible = True
        End If
    End Sub

    Protected Sub btnaceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnaceptar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim dsBolsa As DataSet
        lblerror.Text = ""
        Try

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                LogOff()
            End If

            lblerror.Text = ""
            Select Case estadoactual.Text
                Case estado
                    svr.TransitaInstanciaxBolsa(txtfoliobolsa.Text, eventoOK, "", tTicket.UsrID)
                    txtfoliobolsa.Text = ""
                    lblSellada.Visible = False
                    chkbolsasellada.Checked = False
                    chkbolsasellada.Visible = False
                    btndevolver.Visible = False
                    btnaceptar.Visible = False
                Case estado1
                    svr.TransitaInstanciaxBolsa(txtfoliobolsa.Text, eventoOK1, "", tTicket.UsrID)
                    txtfoliobolsa.Text = ""
                    lblSellada.Visible = False
                    chkbolsasellada.Checked = False
                    chkbolsasellada.Visible = False
                    btndevolver.Visible = False
                    btnaceptar.Visible = False
            End Select
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub btndevolver_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btndevolver.Click
        lblerror.Text = ""
        Try
            Select Case estadoactual.Text
                Case estado
                    Response.Redirect("Wfrm_TE_REchazoBolsaAC.aspx?FolioBolsa=" & txtfoliobolsa.Text)
                Case estado1
                    Response.Redirect("Wfrm_RE_REchazoBolsaAC.aspx?FolioBolsa=" & txtfoliobolsa.Text)
            End Select
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub
End Class