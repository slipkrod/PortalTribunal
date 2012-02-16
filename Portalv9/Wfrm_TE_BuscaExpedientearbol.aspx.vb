Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxTreeList
Partial Public Class Wfrm_TE_BuscaExpedientearbol

    Inherits System.Web.UI.Page
    Private tTicket As IDTicket
    Dim DocumentosOK As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As DataSet
        Dim svr As New SAEX.ServiciosSAEX
        Label1.Text = "Contenido del Expediente"
        If Not IsPostBack Then
            Try
                'TBLDiferencias.Visible = False
                Me.lblError.Text = ""

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
                ds = svr.BuscaExpedientexFolio(Request.QueryString("idFolio"))

                'chkConfiddencial.Checked = ds.Tables(0).Rows(0).Item("Confidencial")
                lblTipoExpediente.Text = ds.Tables(0).Rows(0).Item("TipoExpediente")
                lblEntidad.Text = ds.Tables(0).Rows(0).Item("Entidad")
                lblArea.Text = ds.Tables(0).Rows(0).Item("Area")
                lblAno.Text = ds.Tables(0).Rows(0).Item("Anio")
                lblmes.Text = ds.Tables(0).Rows(0).Item("Mes")
                lbldia.Text = ds.Tables(0).Rows(0).Item("Dia")
                lblLlave.Text = ds.Tables(0).Rows(0).Item("Llave_expediente")
                lblIndice.Text = ds.Tables(0).Rows(0).Item("Indice_de_busqueda")
                'lblInstancia.Text = ds.Tables(0).Rows(0).Item("InstanciaPID")

                DataBind()
                ASPxTreeList1.ExpandAll()

            Catch ex As Exception
                Me.lblError.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Private Sub ASPxTreeList1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxTreeList1.DataBound
        Dim iterator As TreeListNodeIterator = New TreeListNodeIterator(ASPxTreeList1.RootNode)
        Do While Not iterator.Current Is Nothing
            If iterator.Current.GetValue("Nivel") = 9 Then
                iterator.Current.AllowSelect = True
                DocumentosOK = DocumentosOK + 1
            Else
                iterator.Current.AllowSelect = False
            End If
            iterator.GetNext()
        Loop

        lblDocumentos.Text = DocumentosOK
    End Sub

    Protected Sub dsExpediente_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsExpediente.Selecting
        e.InputParameters("idArchivo") = ConfigurationManager.AppSettings("Archivo")
    End Sub
End Class