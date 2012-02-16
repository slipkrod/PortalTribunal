Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxPanel

Partial Class Wfrm_Archivo
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region
    Dim deldatos As Boolean = False

    Private Sub Wfrm_Archivo_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        Presentation.Helpers.CreaTablaElemento(PnlElementos, Page)
        Presentation.Helpers.verCreaTablaElemento(PnlViewElementos, Page)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Archivos"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            aspxtreearchivo.DataBind()
            If aspxtreearchivo.Nodes.Count > 0 Then
                Presentation.Helpers.llenaCampos(PnlElementos, aspxtreearchivo)
                Presentation.Helpers.verLlenaCampos(PnlViewElementos, aspxtreearchivo.FocusedNode.Key)
                PnlViewElementos.Visible = True
                PnlElementos.Visible = False
            End If
        End If
    End Sub

#Region "  Comunes"

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Private Function ObtieneResultado() As String
        Dim strResultado As String
        If Session.Item("GSTR_SESSION_RESULT") Is Nothing Then
            strResultado = String.Empty
        Else
            strResultado = Session.Item("GSTR_SESSION_RESULT")
            Session.Remove("GSTR_SESSION_RESULT")
        End If
        Return strResultado
    End Function


#End Region

    Private Sub aspxtreearchivo_FocusedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxtreearchivo.FocusedNodeChanged
        Presentation.Helpers.LimpiaCampos(PnlElementos)
        Presentation.Helpers.llenaCampos(PnlElementos, aspxtreearchivo)
        If Not aspxtreearchivo.FocusedNode Is Nothing Then
            Presentation.Helpers.verLlenaCampos(PnlViewElementos, aspxtreearchivo.FocusedNode.Key)
        End If
        PnlViewElementos.Visible = True
        PnlElementos.Visible = False
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardar.Click, btnGuardarBottom.Click
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim ValorCampo As String
        Dim dsElementos As DataSet
        Try
            dsElementos = sv.ListaArchivo_Cat_Elementos()
            For intJ = 0 To dsElementos.Tables(0).Rows.Count - 1
                dsNomraCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intJ).Item("idElemento"))
                For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                    If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                        Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                            Case 0
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo)
                            Case 1
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo)
                            Case 2
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo)
                            Case 3
                                ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, ValorCampo)
                            Case 4
                                ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini & "/" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin & "/" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, ValorCampo)
                            Case 5
                                ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, ValorCampo)
                            Case 6
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo)
                            Case 7
                                sv.ABC_Archivo_val_campo(WSArchivo.OperacionesABC.operAlta, aspxtreearchivo.FocusedNode.Key, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0, CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo)
                        End Select
                    End If
                Next
            Next
            MsgBox1.ShowMessage("Los datos se guardaron correctamente")
        Catch ex As Exception
            MsgBox1.ShowMessage(ex.Message.ToString)
        End Try
        btnEditar.Visible = True
        btnGuardar.Visible = False
        btnCancelar.Visible = False
        btnEditarBottom.Visible = True
        btnGuardarBottom.Visible = False
        btnCancelarBottom.Visible = False
        PnlViewElementos.Visible = True
        PnlElementos.Visible = False
        Presentation.Helpers.verLlenaCampos(PnlViewElementos, aspxtreearchivo.FocusedNode.Key)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        aspxtreearchivo.CancelEdit()
    End Sub

    Protected Sub btnActualizar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Session("CanChangeNorma") = False And Session("idOriginalNorma") <> Session("idCurrentNorma") Then
            MsgBox1.ShowMessage("No puede cambiar la norma por que este archivo ya tiene documentos ligados a la normal actual.")
        Else
            aspxtreearchivo.UpdateEdit()
        End If
        Session("CanChangeNorma") = Nothing
        Session("idOriginalNorma") = Nothing
        Session("idCurrentNorma") = Nothing
    End Sub

    Protected Sub btnVer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditar.Click, btnEditarBottom.Click
        Presentation.Helpers.LimpiaCampos(PnlElementos)
        Presentation.Helpers.llenaCampos(PnlElementos, aspxtreearchivo)
        If Not aspxtreearchivo.FocusedNode Is Nothing Then
            Presentation.Helpers.verLlenaCampos(PnlViewElementos, aspxtreearchivo.FocusedNode.Key)
        End If
        btnEditar.Visible = False
        btnGuardar.Visible = True
        btnCancelar.Visible = True
        btnEditarBottom.Visible = False
        btnGuardarBottom.Visible = True
        btnCancelarBottom.Visible = True
        PnlViewElementos.Visible = False
        PnlElementos.Visible = True
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click, btnCancelarBottom.Click
        Presentation.Helpers.LimpiaCampos(PnlElementos)
        Presentation.Helpers.llenaCampos(PnlElementos, aspxtreearchivo)
        If Not aspxtreearchivo.FocusedNode Is Nothing Then
            Presentation.Helpers.verLlenaCampos(PnlViewElementos, aspxtreearchivo.FocusedNode.Key)
        End If
        btnEditar.Visible = True
        btnGuardar.Visible = False
        btnCancelar.Visible = False
        btnEditarBottom.Visible = True
        btnGuardarBottom.Visible = False
        btnCancelarBottom.Visible = False
        PnlViewElementos.Visible = True
        PnlElementos.Visible = False
    End Sub

    Protected Sub aspxtreearchivo_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs) Handles aspxtreearchivo.HtmlRowPrepared
        If (e.RowKind = TreeListRowKind.EditForm) Then
            Dim sv As New WSArchivo.Service1
            Try
                Session("idOriginalNorma") = e.GetValue("idNorma")
                Session("idCurrentNorma") = e.GetValue("idNorma")
                If sv.Busca_enArchivo(e.GetValue("idArchivo"), "").Tables(0).Rows.Count > 0 Then
                    Session("CanChangeNorma") = False
                Else
                    Session("CanChangeNorma") = True
                End If
            Catch
            End Try
        End If
    End Sub

    Protected Sub cmbnorma_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Session("idCurrentNorma") = CType(sender, ASPxComboBox).SelectedItem.Value
    End Sub
End Class