Imports Portalv9.SvrUsr
Partial Public Class Wfrm_TipoExpediente
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sv As New WSArchivo.Service1
        If sv.Func_Suma_IndicesSistemaXNorma(-1, Request.QueryString("idNorma")).Tables(0).Rows(0)(0) > 0 Then
            Response.Write("<SCRIPT language='JavaScript'>alert('Antes de accesar a esta seccion debe asignar todos los indices de sistemas');</SCRIPT>")
        Else
            If Not Page.IsPostBack Then
                Regresar.NavigateUrl = "~/Wfrm_Normas_Organizacion.aspx?idNorma=" & Request.QueryString("idNorma")
                lblTitle.Text = "Administración->Unidad Documental Compuesta - Subserie"
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
            End If
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Sub gdSeries_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomErrorTextEventArgs) Handles gdSeries.CustomErrorText
        'Dim xError As String
        'xError = e.Exception.InnerException.Message
    End Sub

    Private Sub dsLista_SeriesModelo_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsLista_SeriesModelo.Inserting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim objGlobal As New clsGlobal
        If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
            LogOff()
            Exit Sub
        End If
        e.InputParameters("identidad") = tTicket.PerfilUsuarioID
    End Sub

    Protected Sub dsLista_SeriesModelo_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsLista_SeriesModelo.Selecting
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            e.InputParameters("NoIdentidad") = tTicket.NoIdentidad
        Catch ex As Exception
            LogOff()
        End Try
    End Sub
    Function ShowFormatoCodigo(ByVal sClave As String) As String
        Select Case sClave
            Case "1"
                Return "Alfanumérico"
            Case "2"
                Return "Numérico"
            Case "3"
                Return "Auto numérico global"
            Case "4"
                Return "Auto numérico en la serie"
            Case Else
                Return ""
        End Select
    End Function

    Protected Sub dsLista_SeriesModelo_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsLista_SeriesModelo.Updating
        e.InputParameters("Fecha_Ultimo_Cambio") = Now
    End Sub
End Class