Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Public Class Wfrm_ValorizacionBajas
    Inherits System.Web.UI.Page
    Dim sv As New WSArchivo.Service1

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objGlobal As New clsGlobal
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
            LogOff()
            Exit Sub
        End If

        If Not Page.IsPostBack Then
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub



    Protected Sub dsTransferenciaActiva_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsTransferenciaActiva.Inserting
        e.InputParameters("Usrid") = tTicket.NoIdentidad
    End Sub

    Protected Sub gdTransferenciaActiva_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles gdTransferenciaActiva.RowCommand
        Select Case e.CommandArgs.CommandName
            Case "btnVer"
                If gdTransferenciaActiva.GetRowValuesByKeyValue(e.KeyValue, "Status") = 0 Then
                    Response.Redirect("Wfrm_ValorizacionBajas_Seleccion.aspx?idArchivo=" & gdTransferenciaActiva.GetRowValuesByKeyValue(e.KeyValue, "idArchivoOrigen") & "&idFolio=" & gdTransferenciaActiva.GetRowValuesByKeyValue(e.KeyValue, "idFolio"))
                ElseIf gdTransferenciaActiva.GetRowValuesByKeyValue(e.KeyValue, "Status") = 1 Then
                    Response.Redirect("Wfrm_ValorizacionBajas_Seleccionados.aspx?idArchivo=" & gdTransferenciaActiva.GetRowValuesByKeyValue(e.KeyValue, "idArchivoOrigen") & _
                  "&idNorma=" & lblidNorma.Text & _
                  "&idFolio=" & gdTransferenciaActiva.GetRowValuesByKeyValue(e.KeyValue, "idFolio"))
                End If
        End Select
    End Sub

    Protected Sub gdTransferencaHist_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles gdTransferencaHist.RowCommand
        Select Case e.CommandArgs.CommandName
            Case "btnVer"
                Response.Redirect("Wfrm_ValorizacionBajas_Seleccionados_Hist.aspx?idArchivo=" & gdTransferencaHist.GetRowValuesByKeyValue(e.KeyValue, "idArchivoOrigen") & _
              "&idNorma=" & lblidNorma.Text & _
              "&idFolio=" & gdTransferencaHist.GetRowValuesByKeyValue(e.KeyValue, "idFolio"))
        End Select
    End Sub


    Protected Sub cmbStatus_Load(ByVal sender As Object, ByVal e As EventArgs)
        CType(gdTransferenciaActiva.FindEditFormTemplateControl("cmbStatus"), ASPxComboBox).Items.Clear()
        If gdTransferenciaActiva.IsNewRowEditing Then
            CType(gdTransferenciaActiva.FindEditFormTemplateControl("cmbStatus"), ASPxComboBox).Items.Add("Activa", 0)
        ElseIf gdTransferenciaActiva.IsEditing Then
            Dim container As GridViewEditFormTemplateContainer = TryCast(CType(sender, ASPxComboBox).NamingContainer, GridViewEditFormTemplateContainer)
            If container.DataItem("Status") = 0 Then
                CType(gdTransferenciaActiva.FindEditFormTemplateControl("cmbStatus"), ASPxComboBox).Items.Add("Activa", 0)
            Else
                CType(gdTransferenciaActiva.FindEditFormTemplateControl("cmbStatus"), ASPxComboBox).Items.Add("Activa", 1)
            End If
            CType(gdTransferenciaActiva.FindEditFormTemplateControl("cmbStatus"), ASPxComboBox).Items.Add("Cancelar", -1)
        End If
    End Sub

    Protected Sub gdTransferenciaActiva_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatedEventArgs) Handles gdTransferenciaActiva.RowUpdated
        If e.NewValues("Status") = -1 Then
            dsTransferenciaHistorica.Select()
            gdTransferencaHist.DataBind()
        End If

    End Sub

    Protected Sub gdTransferenciaActiva_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles gdTransferenciaActiva.InitNewRow
        e.NewValues("Status") = 0
    End Sub




End Class