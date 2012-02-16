Imports Portalv9.SvrUsr

Partial Public Class Wfrm_TE_FormatoPerdida
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ds As DataSet
        Dim svr As New SAEX.ServiciosSAEX

        'Introducir aquí el código de usuario para inicializar la página
        If Not IsPostBack Then
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

            ds = svr.BuscaInstanciaExpedientexID(Request.QueryString("Folio_Bolsa"), Request.QueryString("InstanciaPID"))

            lblFecha.Text = Format(Now.Date, "yyyyMMdd")
            lblHora.Text = Now.ToShortTimeString

            lblUsuario.Text = ds.Tables(0).Rows(0).Item("idUsuario_Solicita") & " - " & ds.Tables(0).Rows(0).Item("Usuario_Solicita")

            chkConfiddencial.Checked = ds.Tables(0).Rows(0).Item("Confidencial")
            lblTipoExpediente.Text = ds.Tables(0).Rows(0).Item("TipoExpediente")
            lblEntidad.Text = ds.Tables(0).Rows(0).Item("Entidad")
            lblArea.Text = ds.Tables(0).Rows(0).Item("Area")
            lblAno.Text = ds.Tables(0).Rows(0).Item("Anio")
            lblMes.Text = ds.Tables(0).Rows(0).Item("Mes")
            lblDia.Text = ds.Tables(0).Rows(0).Item("Dia")
            lblLLave.Text = ds.Tables(0).Rows(0).Item("Llave_expediente")
            lblIndice.Text = ds.Tables(0).Rows(0).Item("Indice_de_busqueda")
            lblInstancia.Text = ds.Tables(0).Rows(0).Item("InstanciaId")
            lblObservaciones.Text = ds.Tables(0).Rows(0).Item("Observaciones")

            If Request.QueryString("FOrigen") = "RE" Then 'RECOLECCION
                Regresar.NavigateUrl = "wfrm_RE_SegumientoDevoluciones.aspx"
            Else  ' TRASLADO
                Regresar.NavigateUrl = "wfrm_TE_SegumientoDevoluciones.aspx"
            End If

        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub


End Class