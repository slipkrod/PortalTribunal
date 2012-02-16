Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxCallbackPanel

Partial Class Wfrm_Indices_Sistema
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim mensaje As String
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub gdSeries_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Select Case e.NewValues("Indice_Tipo")
            Case 1
                e.NewValues("Indice_Mascara") = "^\d+(\.\d\d)?$"
            Case 2
                e.NewValues("Indice_Mascara") = "(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"
            Case 11, 12
                e.NewValues("Asigned_value") = Session("CatalogoDefaultValue")
                Session("CatalogoDefaultValue") = Nothing
        End Select
    End Sub

    Protected Sub gdSeries_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        e.NewValues("idElemento") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        e.NewValues("Indice_Obligatorio") = True
        Select Case e.NewValues("Indice_Tipo")
            Case 1
                e.NewValues("Indice_Mascara") = "^\d+(\.\d\d)?$"
            Case 2
                e.NewValues("Indice_Mascara") = "(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"
            Case 11, 12
                e.NewValues("Asigned_value") = Session("CatalogoDefaultValue")
                Session("CatalogoDefaultValue") = Nothing
        End Select
        Session("idArea") = CType(sender, ASPxGridView).GetMasterRowFieldValues("idArea")
        e.NewValues("Indice_buscar") = False
        e.NewValues("Indice_CopiarValor") = False
        e.NewValues("Indice_EsAutoincremental") = False
        e.NewValues("IndiceReadOnly") = False
        e.NewValues("folio_norma") = "" 'Calcular ms7
        e.NewValues("Muestra_padres") = False
        e.NewValues("Multi_valor") = False
    End Sub

    Protected Sub cbpSetSes_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Session("CatalogoDefaultValue") = e.Parameter
    End Sub

    Protected Sub gdSeries_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomErrorTextEventArgs)
        Dim nError As String
        nError = e.Exception.Message
    End Sub

    Protected Sub gdSeries_HtmlEditFormCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewEditFormEventArgs)
        Dim gdSeries As ASPxGridView = CType(sender, ASPxGridView)
        If Not CType(e.EditForm.Controls(0).FindControl("Tipo"), ASPxComboBox).SelectedItem Is Nothing And gdSeries.IsNewRowEditing = False And gdSeries.IsEditing Then
            If CType(e.EditForm.Controls(0).FindControl("Tipo"), ASPxComboBox).SelectedItem.Value = "11" Then
                Dim myCampoValor As ASPxTextBox = CType(e.EditForm.Controls(0).FindControl("CampoValor"), ASPxTextBox)
                If myCampoValor.Text.Length > 0 Then
                    Dim mycmbCatalogoValues As ASPxComboBox = CType(e.EditForm.Controls(0).FindControl("cmbCatalogoValues"), ASPxComboBox)
                    dsCatalogoValues.SelectParameters(0).DefaultValue = CType(e.EditForm.Controls(0).FindControl("cmbCatalogos"), ASPxComboBox).SelectedItem.Value
                    mycmbCatalogoValues.DataBind()
                    mycmbCatalogoValues.Items.FindByValue(Integer.Parse(myCampoValor.Text)).Selected = True
                    myCampoValor.Text = ""
                End If
            End If
        End If
    End Sub

    Protected Sub cmbCatalogoValues_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        dsCatalogoValues.SelectParameters(0).DefaultValue = e.Parameter
        CType(sender, ASPxComboBox).DataBind()
    End Sub

    Protected Sub dsIndices_Sistema_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsIndices_Sistema.Selecting
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dsIndices_Sistema_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsIndices_Sistema.Selected
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dsIndices_Sistema_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsIndices_Sistema.Inserting
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class
