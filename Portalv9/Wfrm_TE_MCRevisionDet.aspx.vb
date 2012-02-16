Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxTreeList

Partial Public Class Wfrm_TE_MCRevisionDet
    Inherits System.Web.UI.Page

    Private Const estado As Integer = 20
    Private Const eventoFaltantes As Integer = 4
    Private Const eventoNoDiferencias As Integer = 26
    Private tTicket As IDTicket
    Private DocumentosOK As Integer
    Dim svr As New SAEX.ServiciosSAEX

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        Dim ds As DataSet
        Me.lblError.Text = ""
        'Call GetFocusRemesa()
        If Not IsPostBack Then
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
                If Request.QueryString("FolioBolsa") <> "" Then
                    lblFolioBolsa.Text = Request.QueryString("FolioBolsa")
                End If

                DocumentosOK = 0
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


    Private Sub btnValidaBolsa_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnValidaBolsa.Click        
        Dim exp_doc As Integer
        Dim Fecha_aviso As DateTime
        Try
            Fecha_aviso = Now
            If CType(lblDocumentos.Text, Integer) > ASPxTreeList1.GetSelectedNodes.Count And RadioButtonList1.SelectedItem.Value = 0 Then
                Me.lblError.Text = "Si no marca todos los documentos debe seleccionar hay inconsistencias..."
            Else
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    LogOff()
                    Exit Sub
                End If

                If svr.ObtenTipoTraslado(Request.QueryString("InstanciaID"), Request.QueryString("FolioBolsa")) > 0 Then
                    If RadioButtonList1.SelectedItem.Value = 0 Then
                        'Padre en caso de venir en la misma bolsa
                        svr.TransitaInstancia(Request.QueryString("InstanciaID"), eventoNoDiferencias, "", tTicket.UsrID)
                    Else
                        'Padre en caso de venir en la misma bolsa
                        If txtNombre.Text.Length = 0 Or txtObservaciones.Text.Length = 0 Or txtEjecutivo.Text.Length = 0 Or txtSucursal.Text.Length = 0 Or txtCliente.Text.Length = 0 Or txtCuenta.Text.Length = 0 Then
                            lblError.Text = "Favor de capturar todos los datos."
                            Exit Sub
                        End If
                        svr.TransitaInstancia(Request.QueryString("InstanciaID"), eventoNoDiferencias, "", tTicket.UsrID)
                        svr.InsertaIncidencia(txtNombre.Text, txtObservaciones.Text, txtEjecutivo.Text, txtSucursal.Text, txtCuenta.Text, txtCliente.Text, 1)
                    End If
                    exp_doc = 1
                Else
                    exp_doc = 3
                End If

                GuardaDocumentos_HijosInconsistencias(eventoNoDiferencias, eventoFaltantes)
                Response.Redirect("Wfrm_TE_MCRevisionBolsa.aspx?Folio_Bolsa=" & Request.QueryString("FolioBolsa")) 'En caso de necesitar enviar email quitar esta linea

            End If

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try

    End Sub


    Private Sub GuardaDocumentos_HijosInconsistencias(ByVal nEventoOK As Integer, ByVal eventoFaltantes As Integer)
        Dim iterator As TreeListNodeIterator = New TreeListNodeIterator(ASPxTreeList1.RootNode)
        Do While Not iterator.Current Is Nothing
            If iterator.Current.GetValue("Nivel") = 9 Then
                If iterator.Current.Selected Then
                    svr.TransitaInstancia(iterator.Current.GetValue("InstanciaID"), nEventoOK, "", tTicket.UsrID)
                Else
                    svr.TransitaInstancia(iterator.Current.GetValue("InstanciaID"), eventoFaltantes, "", tTicket.UsrID)
                End If
            End If
            iterator.GetNext()
        Loop

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

    End Sub
End Class