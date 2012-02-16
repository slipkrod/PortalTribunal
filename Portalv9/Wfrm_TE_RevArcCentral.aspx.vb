Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TE_RevArcCentral
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 10
    Private Const eventoError As Integer = 15
    Private Const eventoOK As Integer = 14
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
                If Request.QueryString("FolioBolsa") <> "" Then
                    txtfoliobolsa.Text = Request.QueryString("FolioBolsa")
                    CargaExpedientes(True)
                End If
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Sub btnaceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnaceptar.Click
       CargaExpedientes(False)
    End Sub

    Private Sub CargaExpedientes(ByVal Inicio As Boolean)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsExisteBolsa As DataSet

        ASPxGridView1.Visible = False
        Validate()
        If IsValid Then

            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                LogOff()
            End If

            rsExisteBolsa = svr.BuscaInstanciaXBolsaXEstado(txtFolioBolsa.Text, estado)
            If rsExisteBolsa.Tables(0).Rows.Count = 0 Then
                If Inicio = False Then
                    lblerror.Text = "No existe ese folio de bolsa"
                End If
            Else
                If rsExisteBolsa.Tables(0).Rows(0).Item("EstadoID") = estado Then
                    ASPxGridView1.Visible = True
                    CargaElementos(txtfoliobolsa.Text)
                Else
                    lblerror.Text = "La bolsa no se encuentra en apertura."
                End If
            End If
        End If
    End Sub
    Private Function CargaElementos(ByVal Folio_Bolsa As String) As Integer
        Dim sv As New SAEX.ServiciosSAEX
        Try
            ObjectDataSource1.OldValuesParameterFormatString = "{0}"
            ObjectDataSource1.TypeName = "Portalv9.SAEX.ServiciosSAEX"
            ObjectDataSource1.SelectMethod = "BuscaInstanciaExpedientexEstadoxBolsa"
            ObjectDataSource1.SelectParameters.Add("Folio_Bolsa", Folio_Bolsa)
            ObjectDataSource1.SelectParameters.Add("EstadoID", "10")
            ASPxGridView1.DataBind()
            If ASPxGridView1.VisibleRowCount = 0 Then
                Response.Redirect("Wfrm_TE_RevArcCentral.aspx")
            End If
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try

    End Function
End Class