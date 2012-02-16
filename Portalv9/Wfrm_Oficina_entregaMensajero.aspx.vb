Imports Portalv9.SvrUsr
Partial Public Class Wfrm_Oficina_entregaMensajero
    Inherits System.Web.UI.Page
    Private eventoentregamensajeroOK1 As Integer = 82
    Private eventoentregamensajeroOK As Integer = 3
    Private Const eventoError As Integer = 4
    Private Const eventoentregamensajeroError1 As Integer = 83
    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblerror.Text = ""

        'Call GetFocusRemesa()
        If Not IsPostBack Then
            Try
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    LogOff()
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
    Protected Sub ibtnaceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnaceptar.Click
        Dim intI, intJ As Integer
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsAtributos As DataSet
        Dim nFila As DataRow
        Dim valores As String
        Dim NumValija As Integer

        Try
            lblerror.Text = ""

            If (txtmensajeria.Text <> "") Then
                Validate()
                If IsValid Then

                    If lbbolsas.Items.Count > 0 Then
                        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                        If tTicket Is Nothing Then
                            LogOff()
                        End If

                        rsAtributos = svr.Obten_Atributos(eventoentregamensajeroOK, "Valija")
                        nFila = rsAtributos.Tables(0).NewRow
                        nFila.Item("NumValija") = 0
                        nFila.Item("Fecha") = Now.Date
                        nFila.Item("Mensajeria") = txtmensajeria.Text
                        nFila.Item("Observaciones") = ""
                        rsAtributos.Tables(0).Rows.Add(nFila)
                        NumValija = svr.SQLInsert_Campos_Atributos(rsAtributos, "Valija")

                        For intI = 0 To lbbolsas.Items.Count - 1
                            svr.Actualiza_ValijaxBolsa(tTicket.NoIdentidad, txtmensajeria.Text, NumValija, lbbolsas.Items(intI).Text)
                            svr.TransitaInstanciaxBolsa(lbbolsas.Items(intI).Text, lbbolsas.Items(intI).Value, "", tTicket.UsrID)
                        Next

                        For intI = 0 To lbbolsas.Items.Count - 1
                            valores = valores & lbbolsas.Items(intI).Text & ","
                        Next

                        valores = valores.Substring(0, valores.Length - 1)
                        Response.Redirect("Wfrm_TE_FormatoEntrega.aspx?Bolsas=" & valores & "&Mensajeria=" & Server.UrlEncode(txtmensajeria.Text) & "&Ubicacion=0" & "&Valija=" & NumValija)
                    Else
                        lblerror.Text = "No existen bolsas seleccionadas para entregar a la mensajería..."
                    End If
                End If
            Else
                lblerror.Text = "La mensajería no puede ir vacía..."
            End If
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub
    Protected Sub btagregar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btagregar.Click
        Dim nItem As ListItem
        Dim svr As New SAEX.ServiciosSAEX
        Dim dsBolsa As DataSet
        Dim newItem As New ListItem

        lblerror.Text = ""
        If txtfbolsa.Text <> "" Then
            nItem = lbbolsas.Items.FindByText(txtfbolsa.Text)
            If nItem Is Nothing Then
                dsBolsa = svr.BuscaInstanciaXBolsa(txtfbolsa.Text)
                If dsBolsa.Tables(0).Rows.Count = 0 Then
                    lblerror.Text = "No existe ese folio de bolsa..."
                Else
                    Select Case dsBolsa.Tables(0).Rows(0).Item("EstadoID")
                        Case 3
                            newItem.Text = txtfbolsa.Text
                            newItem.Value = eventoentregamensajeroOK
                            lbbolsas.Items.Add(newItem)
                            txtfbolsa.Text = ""
                            SetFocus(txtfbolsa)
                        Case 82
                            newItem.Text = txtfbolsa.Text
                            newItem.Value = eventoentregamensajeroOK1
                            lbbolsas.Items.Add(newItem)
                            txtfbolsa.Text = ""
                            SetFocus(txtfbolsa)
                        Case Else
                            lblerror.Text = "La bolsa no se encuentra en oficinas para entrega a mensajería..."
                    End Select
                End If
            End If
        Else
            lblmreq.Visible = True
        End If

    End Sub
    Protected Sub btquitar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btquitar.Click
        lbbolsas.Items.Remove(lbbolsas.SelectedItem)
    End Sub
End Class