Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxGridView
Imports System.Collections.Generic
Imports System.Linq
Partial Public Class Wfrm_EN_RequerimientoImg
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket

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

                'If Request.QueryString("confidencial") = "0" Then
                '    Label1.Text = "Busqueda de Expedientes"
                '    Label2.Text = ""

                'Else
                '    Label1.Text = "Busqueda de Expedientes confidenciales"
                '    Label2.Text = " = Expediente Confidencial ="
                'End If

                ds_Entidades.OldValuesParameterFormatString = "{0}"
                'ds_Entidades.TypeName = "Portalv9.WSArchivo.Service1"
                'ds_Entidades.SelectMethod = "ListaFondoxNivel"
                ds_Entidades.SelectParameters("idArchivo").DefaultValue = ConfigurationManager.AppSettings("Archivo")
                ds_Entidades.SelectParameters("Fondo_ini").DefaultValue = 3
                ds_Entidades.SelectParameters("Fondo_fin").DefaultValue = 3


            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        Else
            '            mostrar()

        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Sub cmbTipoExpediente_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTipoExpediente.SelectedIndexChanged
        mostrar()
    End Sub
    Protected Sub ASPxComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxComboBox1.SelectedIndexChanged
        ds_AreasAdministrativas.OldValuesParameterFormatString = "{0}"
        'ds_AreasAdministrativas.TypeName = "Portalv9.WSArchivo.Service1"
        'ds_AreasAdministrativas.SelectMethod = "ListaFondoxNivelxPadre"
        ds_AreasAdministrativas.SelectParameters("idArchivo").DefaultValue = ConfigurationManager.AppSettings("Archivo")
        ds_AreasAdministrativas.SelectParameters("Fondo_ini").DefaultValue = 4
        ds_AreasAdministrativas.SelectParameters("Fondo_fin").DefaultValue = 4
        ds_AreasAdministrativas.SelectParameters("Padre").DefaultValue = ASPxComboBox1.SelectedItem.Value
        ds_AreasAdministrativas.Select()

        ASPxComboBox2.Visible = True
        ASPxComboBox2.DataBind()
        lblarea.Visible = True
    End Sub
    Protected Sub dsLista_SeriesModelo_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsLista_SeriesModelo.Selecting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        e.InputParameters("identidad") = tTicket.NoIdentidad
    End Sub

    Private Sub mostrar()
        lblentidad.Visible = True
        lblarea.Visible = True
        ASPxComboBox1.Visible = True
        ASPxComboBox2.Visible = True
        lblindices.Visible = True
        txtindice.Visible = True
        lblanio.Visible = True
        txtanio.Visible = True
        lblmes.Visible = True
        dlMes.Visible = True
        lbldia.Visible = True
        dlDia.Visible = True
        ImageButton1.Visible = True
    End Sub

End Class