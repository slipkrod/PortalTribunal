Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors
Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Partial Public Class Wfrm_RelacionISADISAAR
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim visibleindx As Integer
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Relación ISAD-ISAAR"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                Logoff()
                Exit Sub
            End If
        End If

    End Sub
#Region "  Comunes"

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


#End Region


    Private Sub gdrelacion_HtmlRowCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs) Handles gdrelacion.HtmlRowCreated
        Dim gdrelacion As ASPxGridView = CType(sender, ASPxGridView)
        If e.RowType = GridViewRowType.EditForm Then
            Dim cmbisad As ASPxComboBox = CType(gdrelacion.FindEditFormTemplateControl("cmbISAD"), ASPxComboBox)
            Dim cmbisaar As ASPxComboBox = CType(gdrelacion.FindEditFormTemplateControl("cmbISAAR"), ASPxComboBox)
            Dim btninsertar As ASPxButton = CType(gdrelacion.FindEditFormTemplateControl("btnInsertar"), ASPxButton)
            Dim btnactualizar As ASPxButton = CType(gdrelacion.FindEditFormTemplateControl("Btnactualizar"), ASPxButton)
            visibleindx = e.VisibleIndex
            If gdrelacion.IsNewRowEditing Then
                btnactualizar.Visible = False
                btninsertar.Visible = True
            Else
                Dim IDISAD As String = e.GetValue("IDISAD").ToString.Trim
                Dim IDISAAR As String = e.GetValue("IDISAAR").ToString.Trim

                Dim i As Integer
                For i = 0 To cmbisad.Items.Count - 1
                    If cmbisad.Items(i).Value.ToString = IDISAD Then
                        cmbisad.SelectedIndex = cmbisad.Items(i).Index
                    End If
                Next
                i = 0
                For i = 0 To cmbisaar.Items.Count - 1
                    If cmbisaar.Items(i).Value.ToString = IDISAAR Then
                        cmbisaar.SelectedIndex = cmbisaar.Items(i).Index
                    End If
                Next
                btnactualizar.Visible = True
                btninsertar.Visible = False
            End If
            
        End If
    End Sub

    


    Protected Sub btnInsertar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim cmbisad As ASPxComboBox = CType(gdrelacion.FindEditFormTemplateControl("cmbISAD"), ASPxComboBox)
        Dim cmbisaar As ASPxComboBox = CType(gdrelacion.FindEditFormTemplateControl("cmbISAAR"), ASPxComboBox)
        Dim valorisad As String
        Dim valorisaar As String
        valorisad = cmbisad.Value
        valorisaar = cmbisaar.Value

        Dim descripcion As String = cmbisad.SelectedItem.Text.Substring(valorisad.Length) + " - " + cmbisaar.SelectedItem.Text.Substring(valorisaar.Length)

        Try
            sv.ABC_Normas_relacion(0, 0, cmbisad.Value, cmbisaar.Value, descripcion)
            gdrelacion.CancelEdit()
            gdrelacion.DataBind()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try
    End Sub

    Protected Sub btnActualizar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim cmbisad As ASPxComboBox = CType(gdrelacion.FindEditFormTemplateControl("cmbISAD"), ASPxComboBox)
        Dim cmbisaar As ASPxComboBox = CType(gdrelacion.FindEditFormTemplateControl("cmbISAAR"), ASPxComboBox)

        Dim valorisad As String
        Dim valorisaar As String
        valorisad = cmbisad.Value
        valorisaar = cmbisaar.Value
        Dim id = gdrelacion.GetDataRow(visibleindx)


        Dim descripcion As String = cmbisad.SelectedItem.Text.Substring(valorisad.Length) + " - " + cmbisaar.SelectedItem.Text.Substring(valorisaar.Length)

        Try
            sv.ABC_Normas_relacion(2, id.ItemArray(0), cmbisad.Value, cmbisaar.Value, descripcion)
            gdrelacion.CancelEdit()
            gdrelacion.DataBind()
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try
    End Sub


    Protected Sub gdrelacion_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gdrelacion.RowDeleting
        Dim sv As New WSArchivo.Service1
        Dim strMsg As String = String.Empty
        Dim key As Object = e.Keys(0)
        e.Cancel = True
        gdrelacion.CancelEdit()
        Try
            sv.ABC_Normas_relacion(1, key, "", "", "")
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message)
        Finally
            sv = Nothing
        End Try

    End Sub
End Class