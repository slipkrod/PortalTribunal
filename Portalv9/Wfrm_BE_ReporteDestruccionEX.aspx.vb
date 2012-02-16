Imports Portalv9.SvrUsr
Partial Public Class Wfrm_BE_ReporteDestruccionEX
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket
    Private Const eventoOK As Integer = 110

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                Dim strRes As String = Session("DebeCambiarPwd")
                If strRes <> String.Empty Then
                    If CType(strRes, Boolean) = True Then
                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                    End If
                End If
                'CargaElementos()


            Catch ex As Exception
                Me.lblError.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim intI As Integer
        Dim Folio_envio As Integer
        Dim objGlobal As New clsGlobal
        Dim fecha As DateTime

        fecha = Date.Now
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
            LogOff()
            Exit Sub
        End If

        Folio_envio = svr.Control_Maestro(4, 1)
        If ASPxGridView1.VisibleRowCount > 0 Then
            For intI = 0 To ASPxGridView1.VisibleRowCount - 1
                svr.TransitarInstanciaDestruccion(ASPxGridView1.GetDataRow(intI).Item("instanciaID").ToString(), Folio_envio, fecha, eventoOK, "", tTicket.UsrID)
            Next
            Response.Redirect("Wfrm_BE_FormatoAutorizacion.aspx?Folio_destruccion=" & Folio_envio)
        Else
            lblerror.Text = "No existen elementos a procesar"
        End If
        
    End Sub
End Class