Imports Portalv9.SvrUsr
Partial Public Class wfrmBuscador
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim svr As New SAEX.ServiciosSAEX
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

            End Try
        Else
            '            mostrar()

        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


    Protected Sub NivelLogico_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles NivelLogico.CheckedChanged
        datagridLogicos.Enabled = NivelLogico.Checked
    End Sub

    Protected Sub NivelFisico_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles NivelFisico.CheckedChanged
        datagridFisicos.Enabled = NivelFisico.Checked
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        If cmbArchivo.SelectedIndex < 0 Then
            MsgBox1.ShowMessage("Debe selecionar un archivo")
        Else
            Dim iSelRows As Integer
            Dim sNiveles As String = "&idNiveles="
            If NivelLogico.Checked Then
                For iSelRows = 0 To datagridLogicos.GetSelectedFieldValues("idNivel").Count - 1
                    sNiveles += datagridLogicos.GetSelectedFieldValues("idNivel")(iSelRows).ToString() + "~"
                Next
            End If
            If NivelFisico.Checked Then
                For iSelRows = 0 To datagridFisicos.GetSelectedFieldValues("idNivel").Count - 1
                    sNiveles += datagridFisicos.GetSelectedFieldValues("idNivel")(iSelRows).ToString() + "~"
                Next
            End If
            If sNiveles <> "&idNiveles=" Then
                sNiveles = sNiveles.Substring(0, sNiveles.Length - 1)
            End If
            Response.Redirect("wfrm_Buscador_Resultado.aspx?idArchivo=" & cmbArchivo.SelectedItem.Value & "&Palabra=" & txtPalabra.Text + sNiveles)
        End If
    End Sub

End Class