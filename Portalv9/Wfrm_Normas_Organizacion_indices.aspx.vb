Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxClasses


Partial Public Class Wfrm_Normas_Organizacion_indices
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sv As New WSArchivo.Service1
            If Request.QueryString("TipoExp") = 0 Then
                Regresar.NavigateUrl = "~/Wfrm_Normas_Organizacion_Series.aspx?idNorma=" & Request.QueryString("idNorma") & "&idNivel=" & Request.QueryString("idNivel")
            Else
                Regresar.NavigateUrl = "~/Wfrm_Normas_Organizacion_SubSeries.aspx?idNorma=" & Request.QueryString("idNorma") & "&idNivel=" & Request.QueryString("idNivelP") & "&idSerie=" & Request.QueryString("idSerieP")
            End If
        End If
    End Sub

    Private Sub gdSeries_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomErrorTextEventArgs) Handles gdSeries.CustomErrorText
        Dim nError As String
        nError = e.Exception.Message
    End Sub

    Private Sub gdSeries_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gdSeries.RowInserting
        Select Case e.NewValues("Indice_Tipo")
            Case 1
                e.NewValues("Indice_Mascara") = "^\d+(\.\d\d)?$"
            Case 2
                e.NewValues("Indice_Mascara") = "(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"
        End Select
        e.NewValues("Indice_buscar") = False
        e.NewValues("Indice_CopiarValor") = False
        e.NewValues("Indice_EsAutoincremental") = False
        e.NewValues("IndiceReadOnly") = False
        e.NewValues("relacion_con_normaPID") = -1
        e.NewValues("folio_norma") = "" 'Calcular ms7
        e.NewValues("Muestra_padres") = False
        e.NewValues("Multi_valor") = False
        e.NewValues("Asigned") = False
    End Sub

    Private Sub gdSeries_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gdSeries.RowUpdating
        Select Case e.NewValues("Indice_Tipo")
            Case 1
                e.NewValues("Indice_Mascara") = "^\d+(\.\d\d)?$"
            Case 2
                e.NewValues("Indice_Mascara") = "(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"
        End Select

    End Sub


    Protected Sub cmbElemento_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Session("idArea") = e.Parameter.ToString
        CType(sender, ASPxComboBox).DataBind()
    End Sub

    Private Sub gdSeries_HtmlEditFormCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewEditFormEventArgs) Handles gdSeries.HtmlEditFormCreated
        If (Not gdSeries.IsEditing) Then
            Return
        End If
        If Not CType(gdSeries.FindEditFormTemplateControl("Tipo"), ASPxComboBox).SelectedItem Is Nothing Then
            If CType(gdSeries.FindEditFormTemplateControl("Tipo"), ASPxComboBox).SelectedItem.Value <> 0 Then
                gdSeries.FindEditFormTemplateControl("Longitud").Visible = False
                gdSeries.FindEditFormTemplateControl("lblLongitud").Visible = False
            Else
                gdSeries.FindEditFormTemplateControl("Longitud").Visible = True
                gdSeries.FindEditFormTemplateControl("lblLongitud").Visible = True
            End If
        End If

        If Not CType(gdSeries.FindEditFormTemplateControl("cmbArea"), ASPxComboBox).SelectedItem Is Nothing Then
            Dim idArea As String = CType(gdSeries.FindEditFormTemplateControl("cmbArea"), ASPxComboBox).SelectedItem.Value
            Session("idArea") = idArea
            DataBind()
        End If
    End Sub

    Protected Sub gdSeries_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs) Handles gdSeries.CustomCallback
        If (e.Parameters.ToString() = "0") Then
            gdSeries.FindEditFormTemplateControl("Longitud").Visible = True
            gdSeries.FindEditFormTemplateControl("lblLongitud").Visible = True
        Else
            gdSeries.FindEditFormTemplateControl("Longitud").Visible = False
            gdSeries.FindEditFormTemplateControl("lblLongitud").Visible = False
        End If
    End Sub
End Class