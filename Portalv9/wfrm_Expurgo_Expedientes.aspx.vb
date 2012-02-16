Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxGridView

Partial Public Class wfrmExpurgoExpedientes
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket

    Public idArchivo As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
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

            idArchivo = CType(Request("idArchivo"), Integer)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub ExpedientesGrid_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ExpedientesGrid.RowCommand
        Try
            If e.CommandArgs.CommandName.ToString = "Activar" Then
                Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1
                sv.Activa_Nivel(CType(e.KeyValue, Integer), False)

                Dim solicitudesDataSet As DataSet = sv.Lista_Expedientes_Expurgo(1, Date.Now.AddDays(-100), Date.Now)

                ExpedientesGrid.DataSource = solicitudesDataSet
                ExpedientesGrid.DataBind()
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub


    Protected Sub BuscaExpedientes(ByVal sender As Object, ByVal e As EventArgs)

        Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1
        Dim solicitudesDataSet As DataSet = sv.Lista_Expedientes_Expurgo(idArchivo, CType(DateEditFechaDesde.Text, Date), CType(DateEditFechaHasta.Text, Date))

        ExpedientesGrid.DataSource = solicitudesDataSet
        ExpedientesGrid.DataBind()

    End Sub


End Class