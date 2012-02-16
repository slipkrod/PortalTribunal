Imports Portalv9.SvrUsr
Partial Public Class Wfrm_EN_envioExp
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                'Me.lblError.Text = ex.Message
            End Try
        End If


    End Sub

    Protected Sub ASPxGridView1_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ASPxGridView1.RowCommand
        Select Case e.CommandArgs.CommandName
            Case "Aviso"
                GuardaStatus(e.KeyValue)
            Case "Enviar"
                If e.CommandArgs.CommandArgument = "Archivado" Then
                    Response.Redirect("wfrm_EN_Digitaliza.aspx?InstanciaPID=" & ASPxGridView1.GetDataRow(e.VisibleIndex).Item("InstanciaID") & "&Folio_envio=" & e.KeyValue)
                Else
                    MsgBox1.ShowMessage("Ese expediente tiene documentos fuera del archivo.")
                End If
        End Select
    End Sub

    Private Sub GuardaStatus(ByVal Folio_envio As Integer)
        Dim sv As New SAEX.ServiciosSAEX
        sv.Actualiza_Estatus_envio(Folio_envio, 2)
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        daExpedientes.Select()
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub ASPxGridView1_HtmlDataCellPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs) Handles ASPxGridView1.HtmlDataCellPrepared
        If e.DataColumn.FieldName = "status_expediente" Then

            Select Case Convert.ToInt32(ASPxGridView1.GetRowValues(e.VisibleIndex, "Estatus"))
                Case 0
                    e.Cell.BackColor = System.Drawing.Color.White
                Case 1
                    e.Cell.BackColor = System.Drawing.Color.YellowGreen
                Case 2
                    e.Cell.BackColor = System.Drawing.Color.Gold
            End Select
        End If
    End Sub
End Class