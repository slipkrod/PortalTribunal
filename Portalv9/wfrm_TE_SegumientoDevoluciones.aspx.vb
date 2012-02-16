Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxEditors
Partial Public Class wfrm_TE_SegumientoDevoluciones
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 13
    Private Const eventoDigitaliza As Integer = 18
    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblError.Text = ""
        'tblArchivo.Visible = False
        'tblDocumentos.Visible = False

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
            Catch ex As Exception
                Me.lblError.Text = ex.Message
            End Try
        End If

    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub ASPxGridView1_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ASPxGridView1.RowCommand
        Select Case e.CommandArgs.CommandName.ToString
            Case "Liberacion"
                Response.Redirect("Wfrm_TE_FormatoLiberacion.aspx?Folio_Bolsa=" & e.CommandArgs.CommandArgument.ToString & "&InstanciaPID=" & e.KeyValue)
            Case "perdida"
                Response.Redirect("Wfrm_TE_FormatoPerdida.aspx?Folio_Bolsa=" & e.CommandArgs.CommandArgument.ToString & "&InstanciaPID=" & e.KeyValue & "&FOrigen=" & "TE")
            Case "Agegar"
                CType(ASPxPopupControl1.FindControl("lblLLave"), ASPxLabel).Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Llave_expediente").ToString()
                CType(ASPxPopupControl1.FindControl("lblIndice"), ASPxLabel).Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Indice_de_busqueda").ToString()
                CType(ASPxPopupControl1.FindControl("lblInstancia"), Label).Text = e.KeyValue
                CType(ASPxPopupControl1.FindControl("lblBolsa"), Label).Text = e.CommandArgs.CommandArgument.ToString

                ASPxPopupControl1.ShowOnPageLoad = True
        End Select
    End Sub

    Protected Sub ASPxButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxButton3.Click
        Dim Archivo As String
        Dim SaveLocation As String
        Dim Status_Bolsa As Integer

        If FileUpload.PostedFile Is Nothing Or FileUpload.PostedFile.ContentLength <= 0 Then
            MsgBox1.ShowMessage("Debe seleccionar un archivo")
        Else
            If System.IO.Path.GetExtension(FileUpload.PostedFile.FileName).ToUpper = ".GIF" Then
                Archivo = "ActaP_" & lblInstancia.Text & ".gif"
                SaveLocation = Server.MapPath("~\Archivos") + "\" & Archivo
                Try
                    FileUpload.PostedFile.SaveAs(SaveLocation)
                    Select Case CType(ASPxPopupControl1.FindControl("ASPxRadioButtonList1"), ASPxRadioButtonList).SelectedItem.Value
                        Case 0 'Acta de pérdida
                            Status_Bolsa = 2
                        Case 1 'Acta de LIberación
                            Status_Bolsa = 3
                    End Select
                    TransitaInstanciaDigitalizacion(lblInstancia.Text, Status_Bolsa)
                    ASPxPopupControl1.ShowOnPageLoad = False
                    ObjectDataSource1.Select()
                    ObjectDataSource2.Select()
                    ASPxGridView1.DataBind()
                    ASPxGridView2.DataBind()

                Catch ex As Exception
                    MsgBox1.ShowMessage(ex.Message)
                End Try
            Else
                MsgBox1.ShowMessage("Debe seleccionar un archivo tipo .Gif")
            End If
        End If

    End Sub

    Private Sub TransitaInstanciaDigitalizacion(ByVal InstanciaID As Integer, ByVal Status_Bolsa As Integer)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsAtributos As DataSet
        Dim nFila As DataRow
        Dim rsHijos As DataSet
        Dim intI As Integer

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If tTicket Is Nothing Then
            LogOff()
        End If

        If svr.ObtenTipoTraslado(InstanciaID, lblBolsa.Text) > 0 Then
            rsAtributos = svr.Obten_Atributos(eventoDigitaliza, "CorteInstancia")
            nFila = rsAtributos.Tables(0).NewRow
            nFila.Item("Status_Bolsa") = Status_Bolsa
            rsAtributos.Tables(0).Rows.Add(nFila)
            svr.SQLUpdate_Campos_Atributos(rsAtributos, "corteInstancia", InstanciaID)

            svr.TransitaInstancia(InstanciaID, eventoDigitaliza, "", tTicket.UsrID)

            rsHijos = svr.BuscaSoloDocumentosInstancia(lblBolsa.Text, InstanciaID)
            For intI = 0 To rsHijos.Tables(0).Rows.Count - 1
                rsAtributos = svr.Obten_Atributos(eventoDigitaliza, "CorteInstancia")
                nFila = rsAtributos.Tables(0).NewRow
                nFila.Item("Status_Bolsa") = Status_Bolsa
                rsAtributos.Tables(0).Rows.Add(nFila)
                svr.SQLUpdate_Campos_Atributos(rsAtributos, "corteInstancia", rsHijos.Tables(0).Rows(intI).Item("InstanciaId"))

                svr.TransitaInstancia(rsHijos.Tables(0).Rows(intI).Item("InstanciaId"), eventoDigitaliza, "", tTicket.UsrID)
            Next
        Else
            rsHijos = svr.BuscaSoloDocumentosInstancia(lblBolsa.Text, InstanciaID)
            For intI = 0 To rsHijos.Tables(0).Rows.Count - 1
                rsAtributos = svr.Obten_Atributos(eventoDigitaliza, "CorteInstancia")
                nFila = rsAtributos.Tables(0).NewRow
                Select Case ASPxRadioButtonList1.SelectedItem.Value
                    Case 0
                        nFila.Item("Status_Bolsa") = 2
                    Case 1
                        nFila.Item("Status_Bolsa") = 3
                End Select
                rsAtributos.Tables(0).Rows.Add(nFila)
                svr.SQLUpdate_Campos_Atributos(rsAtributos, "corteInstancia", InstanciaID)

                svr.TransitaInstancia(rsHijos.Tables(0).Rows(intI).Item("InstanciaId"), eventoDigitaliza, "", tTicket.UsrID)
            Next
        End If
    End Sub
End Class