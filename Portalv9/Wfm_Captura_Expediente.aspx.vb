Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxTreeList

Partial Public Class Wfm_Captura_Expediente
    Inherits System.Web.UI.Page
    Dim sv As New WSArchivo.Service1

#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim descarch As String
    Dim aux As Integer = 0
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

    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        If container.Expanded Then
            Return container.GetValue("Imagen_Open")
        Else
            Return container.GetValue("Imagen_Close")
        End If
    End Function
    Protected Sub ASPxButtonEdit1_ButtonClick(ByVal source As Object, ByVal e As DevExpress.Web.ASPxEditors.ButtonEditClickEventArgs) Handles btEditCodigo.ButtonClick
        Dim rsBuscaCodigo As DataSet
        rsBuscaCodigo = sv.ListaArchivo_Codigo_clasificacion(Request.QueryString("idArchivo"), btEditCodigo.Text)
        If rsBuscaCodigo.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowMessage("No existe el expediente.")
            btEditCodigo.Enabled = False
            btnAltaExp.ClientVisible = True
            btnCancelaAlta.ClientVisible = True
        Else
            If rsBuscaCodigo.Tables(0).Rows(0).Item("idNivel") = 8 Then
                Response.Redirect("Wfm_Captura_Expediente_Documentos.aspx?idArchivo=" & Request.QueryString("idArchivo") & "&idDescripcion=" & rsBuscaCodigo.Tables(0).Rows(0).Item("idDescripcion") & "&idSerie=" & rsBuscaCodigo.Tables(0).Rows(0).Item("idSerie") & "&idNorma=" & rsBuscaCodigo.Tables(0).Rows(0).Item("idNorma"))
            Else
                MsgBox1.ShowMessage("El Código de referencia no pertenece a un expediente.")
                btnAltaExp.ClientVisible = False
                btnCancelaAlta.ClientVisible = False
                btEditCodigo.Enabled = True
            End If
        End If
    End Sub


    Protected Sub btnAltaExp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAltaExp.Click
        Dim rsBuscaArchivo As DataView
        dsBuscaArchivo.SelectParameters("idArchivo").DefaultValue = Request.QueryString("idArchivo")
        rsBuscaArchivo = dsBuscaArchivo.Select

        iframeIndices.Attributes("src") = "Wfm_Captura_Expediente_Serie.aspx?idArchivo=" & Request.QueryString("idArchivo") & "&idNorma=" & rsBuscaArchivo.Table.Rows(0).Item("idNorma") & "&idNivel=8"
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback

    End Sub

    Protected Sub btnCancelaAlta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelaAlta.Click
        btnAltaExp.ClientVisible = False
        btnCancelaAlta.ClientVisible = False
        btEditCodigo.Enabled = True
        iframeIndices.Attributes("src") = "Blank_Page.aspx"
    End Sub
End Class