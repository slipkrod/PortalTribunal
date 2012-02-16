Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_EntregaMensajeroMC
    Inherits System.Web.UI.Page

    Private Const estado As Integer = 22
    Private Const eventoOK As Integer = 28
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

            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub btagregar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btagregar.Click
        Dim nItem As ListItem
        Dim svr As New SAEX.ServiciosSAEX
        Dim dsBolsa As DataSet
        Dim newItem As New ListItem

        lblerror.Text = ""
        If txtFolioBolsa.Text <> "" Then
            nItem = lbbolsas.Items.FindByText(txtFolioBolsa.Text)
            If nItem Is Nothing Then
                dsBolsa = svr.BuscaInstanciaXBolsa(txtFolioBolsa.Text)
                If dsBolsa.Tables(0).Rows.Count = 0 Then
                    lblerror.Text = "No existe ese folio de bolsa..."
                Else
                    If dsBolsa.Tables(0).Rows(0).Item("EstadoID") = estado Then
                        newItem.Text = txtFolioBolsa.Text
                        newItem.Value = txtFolioBolsa.Text
                        lbbolsas.Items.Add(newItem)
                        txtFolioBolsa.Text = ""
                        SetFocus(txtFolioBolsa)
                    Else
                        lblerror.Text = "La bolsa no se encuentra en mesa de control para entrega a mensajería..."
                    End If
                End If
            End If
        End If
    End Sub
    Protected Sub btquitar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btquitar.Click
        lbbolsas.Items.Remove(lbbolsas.SelectedItem)
    End Sub

    Protected Sub ibtnaceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnaceptar.Click
        Dim intI, intJ As Integer
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsAtributos As DataSet
        Dim nFila As DataRow
        Dim valores As String
        Dim NumValija As Integer

        Try
            lblError.Text = ""

            If (txtMensajeria.Text <> "") Then
                Validate()
                If IsValid Then

                    If lbBolsas.Items.Count > 0 Then
                        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                        If tTicket Is Nothing Then
                            LogOff()
                        End If

                        rsAtributos = svr.Obten_Atributos(eventoOK, "Valija")
                        nFila = rsAtributos.Tables(0).NewRow
                        nFila.Item("NumValija") = 0
                        nFila.Item("Fecha") = Now.Date
                        nFila.Item("Mensajeria") = txtMensajeria.Text
                        nFila.Item("Observaciones") = ""
                        rsAtributos.Tables(0).Rows.Add(nFila)
                        NumValija = svr.SQLInsert_Campos_Atributos(rsAtributos, "Valija")

                        For intI = 0 To lbBolsas.Items.Count - 1
                            svr.Actualiza_ValijaxBolsa(tTicket.NoIdentidad, txtMensajeria.Text, NumValija, lbBolsas.Items(intI).Value)
                            svr.TransitaInstanciaxBolsa(lbBolsas.Items(intI).Value, eventoOK, "", tTicket.UsrID)
                        Next

                        For intI = 0 To lbBolsas.Items.Count - 1
                            valores = valores & lbBolsas.Items(intI).Text & ","
                        Next

                        valores = valores.Substring(0, valores.Length - 1)
                        Response.Redirect("Wfrm_TE_FormatoEntrega.aspx?Bolsas=" & valores & "&Mensajeria=" & Server.UrlEncode(txtMensajeria.Text) & "&Ubicacion=1" & "&Valija=" & NumValija)
                    Else
                        lblError.Text = "No existen bolsas seleccionadas para entregar a la mensajería..."
                    End If
                End If

            Else
                lblError.Text = "La mensajería no puede ir vacía..."
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

End Class