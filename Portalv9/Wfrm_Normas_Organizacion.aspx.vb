
Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports DevExpress.Web.ASPxGridView
Partial Class Wfrm_Normas_Organizacion
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
    Dim idplantillaold As Integer
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sv As New WSArchivo.Service1
        If sv.Func_Suma_IndicesSistemaXNorma(-1, Request.QueryString("idNorma")).Tables(0).Rows(0)(0) > 0 Then
            Response.Write("<SCRIPT language='JavaScript'>alert('Antes de accesar a esta seccion debe asignar todos los indices de sistemas');window.location='Wfrm_Normas.aspx';</SCRIPT>")
        Else
            If Not Page.IsPostBack Then
                lblTitle.Text = "Normas->Niveles  [" & Request.QueryString("Norma") & "]"
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    LogOff()
                    Exit Sub
                End If
                aspxtreenivel.DataBind()
                aspxtreenivel.ExpandAll()
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

    'Private Sub GetdataSource()
    '    Dim sv As New WSArchivo.Service1
    '    Dim dsNiveles As DataSet

    '    Try
    '        dsNiveles = sv.ListaNormas_Niveles(Request.QueryString("idNorma"))
    '        aspxtreenivel.DataSource = dsNiveles.Tables(0)
    '        aspxtreenivel.DataBind()

    '    Catch ex As Exception
    '        MsgBox1.ShowMessage(ex.Message)
    '    End Try

    'End Sub

#End Region

    Private Sub aspxtreenivel_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles aspxtreenivel.DataBound
        Try
            Dim cabezado As TreeListCommandColumn = CType(CType(sender, ASPxTreeList).Columns.Item(5), TreeListCommandColumn)
            If aspxtreenivel.Nodes.Count > 0 Then
                cabezado.ShowNewButtonInHeader = False
                cabezado.Caption = "Edición"
            End If

            If aspxtreenivel.Nodes.Count = 0 Then
                cabezado.ShowNewButtonInHeader = True
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage(String.Format("ERROR: {0}", ex.Message))
        End Try
    End Sub

    Private Sub aspxtreenivel_HtmlCommandCellPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListHtmlCommandCellEventArgs) Handles aspxtreenivel.HtmlCommandCellPrepared
        ''Dim nodo = aspxtreenivel.FindNodeByKeyValue(e.NodeKey)
        ''If nodo.ChildNodes.Count = 1 And e.Cell.Controls.Count > 1 Then
        ''    e.Cell.Controls(1).Visible = False
        ''End If
    End Sub
    Protected Sub aspxtreenivel_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs) Handles aspxtreenivel.HtmlRowPrepared
        Try
            If (e.RowKind = TreeListRowKind.EditForm) Then
                Dim tree1 As ASPxTreeList = CType(sender, ASPxTreeList)
                Dim txtdescripcion As ASPxTextBox = CType(tree1.FindEditFormTemplateControl("txtdescripcion"), ASPxTextBox)
                Dim cmbtipo As ASPxComboBox = CType(aspxtreenivel.FindEditFormTemplateControl("cmbTipo"), ASPxComboBox)
                Dim Key As String = tree1.IsNewNodeEditing

                If (Not (e.NodeKey) Is Nothing) Then
                    txtdescripcion.Text = e.GetValue("Nivel_descripcion").ToString
                    cmbtipo.SelectedIndex = e.GetValue("Nivel_Logico_Fisico").ToString
                    CType(aspxtreenivel.FindEditFormTemplateControl("ASPxIImagen_open"), ASPxImage).ImageUrl = e.GetValue("Imagen_open").ToString
                    CType(aspxtreenivel.FindEditFormTemplateControl("ASPxIImagen_close"), ASPxImage).ImageUrl = e.GetValue("Imagen_close").ToString
                Else
                    CType(aspxtreenivel.FindEditFormTemplateControl("ASPxIImagen_open"), ASPxImage).ImageUrl = "images/v_" & IIf(e.Level.ToString().Length = 1, "0" & e.Level, e.Level) & ".gif"
                    CType(aspxtreenivel.FindEditFormTemplateControl("ASPxIImagen_close"), ASPxImage).ImageUrl = "images/f_" & IIf(e.Level.ToString().Length = 1, "0" & e.Level, e.Level) & ".gif"
                End If
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage("ERROR: " & ex.Message.ToString())
        End Try
    End Sub

    'Protected Sub UploadBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim srv As New WSArchivo.Service1
    '    Dim savePathio As String
    '    Dim urlPathio As String
    '    Dim savePathic As String
    '    Dim urlPathic As String
    '    Dim nNodoID As Integer
    '    Dim Imagen_open As New ASPxUploadControl
    '    Imagen_open = CType(aspxtreenivel.FindEditFormTemplateControl("Imagen_open"), ASPxUploadControl)
    '    Dim Imagen_close As New ASPxUploadControl
    '    Imagen_close = CType(aspxtreenivel.FindEditFormTemplateControl("Imagen_close"), ASPxUploadControl)
    '    Dim nivel_descrpcion As String = CType(aspxtreenivel.FindEditFormTemplateControl("txtdescripcion"), ASPxTextBox).Text
    '    Dim TipoNivel As Integer = CType(aspxtreenivel.FindEditFormTemplateControl("cmbTipo"), ASPxComboBox).SelectedItem.Value
    '    Dim idDocumentoPID As Integer
    '    Dim prueba = lblFileName.Text
    '    Dim nivel As Integer
    '    If aspxtreenivel.NewNodeParentKey = "" Then
    '        idDocumentoPID = 0
    '    Else
    '        idDocumentoPID = aspxtreenivel.NewNodeParentKey
    '    End If
    '    nivel = aspxtreenivel.FindNodeByKeyValue(aspxtreenivel.EditingNodeKey).Level
    '    Try
    '        savePathio = Me.MapPath(".") & "\images\" & Imagen_open.FileName
    '        urlPathio = "images/" & Imagen_open.FileName
    '        savePathic = Me.MapPath(".") & "\images\" & Imagen_close.FileName
    '        urlPathic = "images/" & Imagen_close.FileName
    '        Imagen_open.SaveAs(savePathio)
    '        Imagen_close.SaveAs(savePathic)
    '        If aspxtreenivel.Nodes.Count = 0 Then
    '            nNodoID = srv.ABC_Normas_Niveles(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), 0, nivel, "", nivel_descrpcion, 0, urlPathio, urlPathic, TipoNivel)
    '        Else
    '            nNodoID = srv.ABC_Normas_Niveles(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), 0, "", nivel, nivel_descrpcion, idDocumentoPID, urlPathio, urlPathic, TipoNivel)
    '        End If
    '        aspxtreenivel.CancelEdit()
    '    Catch ex As Exception
    '        MsgBox1.ShowMessage(String.Format("ERROR: {0}", ex.Message))
    '    End Try

    'End Sub

    'Protected Sub Actbtn_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim srv As New WSArchivo.Service1
    '    Dim savePathio As String
    '    Dim urlPathio As String
    '    Dim savePathic As String
    '    Dim urlPathic As String
    '    Dim nNodoID As Integer
    '    Dim Imagen_open As New ASPxUploadControl
    '    Imagen_open = CType(aspxtreenivel.FindEditFormTemplateControl("Imagen_open"), ASPxUploadControl)
    '    Dim Imagen_close As New ASPxUploadControl
    '    Imagen_close = CType(aspxtreenivel.FindEditFormTemplateControl("Imagen_close"), ASPxUploadControl)
    '    Dim txtdescripcion As ASPxTextBox = CType(aspxtreenivel.FindEditFormTemplateControl("txtdescripcion"), ASPxTextBox)
    '    Dim cmbtipo As ASPxComboBox = CType(aspxtreenivel.FindEditFormTemplateControl("cmbTipo"), ASPxComboBox)
    '    Dim rbImagen As ASPxRadioButtonList = CType(aspxtreenivel.FindEditFormTemplateControl("rbImagen"), ASPxRadioButtonList)
    '    Dim cmbVal As String = cmbtipo.SelectedItem.Value
    '    Dim nivel As Integer

    '    Dim nodo As TreeListNode = aspxtreenivel.FindNodeByKeyValue(aspxtreenivel.EditingNodeKey)

    '    Dim idnivel = aspxtreenivel.EditingNodeKey
    '    nivel = aspxtreenivel.FindNodeByKeyValue(aspxtreenivel.EditingNodeKey).Level()

    '        If rbImagen.SelectedIndex = 0 Then
    '        Try
    '            srv.ABC_Normas_Niveles(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idNorma"), idnivel, nivel, "", txtdescripcion.Text, nodo.DataItem(5), nodo.DataItem(6), nodo.DataItem(7), cmbVal)
    '            aspxtreenivel.CancelEdit()
    '        Catch ex As Exception
    '            MsgBox1.ShowMessage("ERROR: " & ex.Message.ToString())
    '        End Try
    '        Else
    '        Try
    '            savePathio = Me.MapPath(".") & "\images\" & Imagen_open.FileName
    '            urlPathio = "images/" & Imagen_open.FileName
    '            savePathic = Me.MapPath(".") & "\images\" & Imagen_close.FileName
    '            urlPathic = "images/" & Imagen_close.FileName
    '            Imagen_open.SaveAs(savePathio)
    '            Imagen_close.SaveAs(savePathic)
    '            srv.ABC_Normas_Niveles(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idNorma"), idnivel, idnivel, "", txtdescripcion.Text, nodo.DataItem(5), urlPathio, urlPathic, cmbVal)
    '            aspxtreenivel.CancelEdit()
    '        Catch ex As Exception
    '            MsgBox1.ShowMessage("ERROR: " & ex.Message.ToString())
    '        End Try
    '    End If
    'End Sub

    Protected Sub aspxtreenivel_NodeInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles aspxtreenivel.NodeInserting
        Try
            If aspxtreenivel.NewNodeParentKey = "" Then
                e.NewValues("idDocumentoPID") = 0
                e.NewValues("Nivel") = 1
            Else
                e.NewValues("idDocumentoPID") = aspxtreenivel.NewNodeParentKey
                e.NewValues("Nivel") = aspxtreenivel.FindNodeByKeyValue(aspxtreenivel.NewNodeParentKey).Level + 1                
            End If

            Dim savePathio As String
            Dim urlPathio As String
            Dim savePathic As String
            Dim urlPathic As String
            Dim Imagen_open As New ASPxUploadControl
            Imagen_open = CType(aspxtreenivel.FindEditFormTemplateControl("Imagen_open"), ASPxUploadControl)
            Dim Imagen_close As New ASPxUploadControl
            Imagen_close = CType(aspxtreenivel.FindEditFormTemplateControl("Imagen_close"), ASPxUploadControl)
            If Imagen_open.UploadedFiles Is Nothing Then
                urlPathio = "images/v_" & IIf(e.NewValues("Nivel").ToString().Length = 1, "0" & e.NewValues("Nivel"), e.NewValues("Nivel")) & ".gif"
            Else
                If Imagen_open.UploadedFiles(0).FileName = "" Then
                    urlPathio = "images/v_" & IIf(e.NewValues("Nivel").ToString().Length = 1, "0" & e.NewValues("Nivel"), e.NewValues("Nivel")) & ".gif"
                Else
                    savePathio = Me.MapPath(".") & "\images\" & Imagen_open.UploadedFiles(0).FileName
                    urlPathio = "images/" & Imagen_open.UploadedFiles(0).FileName
                    Imagen_open.UploadedFiles(0).SaveAs(savePathio)
                End If
            End If
            If Imagen_close.UploadedFiles Is Nothing Then
                urlPathic = "images/f_" & IIf(e.NewValues("Nivel").ToString().Length = 1, "0" & e.NewValues("Nivel"), e.NewValues("Nivel")) & ".gif"
            Else
                If Imagen_close.UploadedFiles(0).FileName = "" Then
                    urlPathic = "images/f_" & IIf(e.NewValues("Nivel").ToString().Length = 1, "0" & e.NewValues("Nivel"), e.NewValues("Nivel")) & ".gif"
                Else
                    savePathic = Me.MapPath(".") & "\images\" & Imagen_close.UploadedFiles(0).FileName
                    urlPathic = "images/" & Imagen_close.UploadedFiles(0).FileName
                    Imagen_close.UploadedFiles(0).SaveAs(savePathic)
                End If
            End If

            e.NewValues("Imagen_open") = urlPathio
            e.NewValues("Imagen_close") = urlPathic
        Catch ex As Exception
            e.Cancel = True
            MsgBox1.ShowMessage("ERROR: " & ex.Message.ToString())
        End Try
    End Sub

    Protected Sub aspxtreenivel_InitNewNode(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles aspxtreenivel.InitNewNode
        Try

        Catch ex As Exception
            MsgBox1.ShowMessage("ERROR: " & ex.Message.ToString())
        End Try
    End Sub

    Protected Sub ObjectDataSource1_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Inserted
        Try

        Catch ex As Exception
            MsgBox1.ShowMessage("ERROR: " & ex.Message.ToString())
        End Try
    End Sub

    Protected Sub ObjectDataSource1_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Inserting
        Try
            If e.InputParameters("idNorma") Is Nothing Then
                e.InputParameters("idNorma") = Request.QueryString("idNorma").ToString()
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage("ERROR: " & ex.Message.ToString())
        End Try
    End Sub

    Protected Sub aspxtreenivel_NodeUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles aspxtreenivel.NodeUpdating
        Try
            Dim savePathio As String
            Dim urlPathio As String
            Dim savePathic As String
            Dim urlPathic As String
            Dim Imagen_open As New ASPxUploadControl
            Imagen_open = CType(aspxtreenivel.FindEditFormTemplateControl("Imagen_open"), ASPxUploadControl)
            Dim Imagen_close As New ASPxUploadControl
            Imagen_close = CType(aspxtreenivel.FindEditFormTemplateControl("Imagen_close"), ASPxUploadControl)
            If Imagen_open.UploadedFiles Is Nothing Then
                urlPathio = "images/v_" & IIf(e.NewValues("Nivel").ToString().Length = 1, "0" & e.NewValues("Nivel"), e.NewValues("Nivel")) & ".gif"
            Else
                If Imagen_open.UploadedFiles(0).FileName = "" Then
                    urlPathio = "images/v_" & IIf(e.NewValues("Nivel").ToString().Length = 1, "0" & e.NewValues("Nivel"), e.NewValues("Nivel")) & ".gif"
                Else
                    savePathio = Me.MapPath(".") & "\images\" & Imagen_open.UploadedFiles(0).FileName
                    urlPathio = "images/" & Imagen_open.UploadedFiles(0).FileName
                    Imagen_open.UploadedFiles(0).SaveAs(savePathio)
                End If
            End If
            If Imagen_close.UploadedFiles Is Nothing Then
                urlPathic = "images/f_" & IIf(e.NewValues("Nivel").ToString().Length = 1, "0" & e.NewValues("Nivel"), e.NewValues("Nivel")) & ".gif"
            Else
                If Imagen_close.UploadedFiles(0).FileName = "" Then
                    urlPathic = "images/f_" & IIf(e.NewValues("Nivel").ToString().Length = 1, "0" & e.NewValues("Nivel"), e.NewValues("Nivel")) & ".gif"
                Else
                    savePathic = Me.MapPath(".") & "\images\" & Imagen_close.UploadedFiles(0).FileName
                    urlPathic = "images/" & Imagen_close.UploadedFiles(0).FileName
                    Imagen_close.UploadedFiles(0).SaveAs(savePathic)
                End If
            End If
            e.NewValues("Imagen_open") = urlPathio
            e.NewValues("Imagen_close") = urlPathic
        Catch ex As Exception
            e.Cancel = True
            MsgBox1.ShowMessage("ERROR: " & ex.Message.ToString())
        End Try
    End Sub

    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        Try
            If container.Expanded Then
                Return container.GetValue("Imagen_Open")
            Else
                Return container.GetValue("Imagen_Close")
            End If
        Catch ex As Exception
            MsgBox1.ShowMessage("ERROR: " & ex.Message.ToString())
            Return ""
        End Try
    End Function

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        aspxtreenivel.CancelEdit()
    End Sub

    Protected Sub btnUpdtae_Click1(ByVal sender As Object, ByVal e As EventArgs)
        aspxtreenivel.UpdateEdit()
    End Sub
End Class
