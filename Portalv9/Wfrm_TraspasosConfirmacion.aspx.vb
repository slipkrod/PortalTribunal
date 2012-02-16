Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxUploadControl
Imports Portalv9.WSArchivo.Service1
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxGridView

Partial Public Class Wfrm_TraspasosConfirmacion
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            lblTitle.Text = Request.QueryString("sTitulo")
            If Request.QueryString("Tipo").ToString().Split("|")(0) = "Transferencia" Then
                butAceptar.Text = "Transferir"
                butAceptar.Visible = True
                If Request.QueryString("Tipo").ToString().Split("|")(1) = "Primaria" Then
                    lbltitulo.Text = "Transferencias primarias"
                Else
                    lbltitulo.Text = "Transferencias secundarias"
                End If
            Else
                If Request.QueryString("Tipo").ToString().Split("|")(1) = "Primaria" Then
                    lbltitulo.Text = "Valoraciones primarias"
                Else
                    lbltitulo.Text = "Valoraciones secundarias"
                End If
            End If
            CargaTraspaso()
        End If
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Private Sub CargaTraspaso()
        If Request.QueryString("Tipo").ToString().Split("|")(0) = "Transferencia" Then
            If Not Request.QueryString("idTraspasos") Is Nothing Then
                tableFolio.Visible = False
                rpHeader.Visible = True
                tableMain.Visible = True
                If Not Request.QueryString("idNorma") Is Nothing Then lblidNorma.Text = Request.QueryString("idNorma").ToString()
                gdbuscadorresultado.DataBind()
                If gdbuscadorresultado.VisibleRowCount > 0 Then
                    lblFolio.Text = gdbuscadorresultado.GetRowValues(0, "idTraspasos")
                    lblUserName.Text = gdbuscadorresultado.GetRowValues(0, "Username")
                    lblFecha_Solicitud.Text = gdbuscadorresultado.GetRowValues(0, "Fecha_Solicitud")
                    lblFecha_Aplicacion.Text = gdbuscadorresultado.GetRowValues(0, "Fecha_Aplicacion").ToString.Replace("01/01/1900 12:00:00 a.m.", "")
                    lblidArchivoOrigen.Text = gdbuscadorresultado.GetRowValues(0, "Archivo_Descripcion")
                    lblidArchivoDestino.Text = gdbuscadorresultado.GetRowValues(0, "ArchivoDestino")
                    idArchivoDestino.Text = gdbuscadorresultado.GetRowValues(0, "idArchivoDestino")
                    SelectArchivoDestino(gdbuscadorresultado.GetRowValues(0, "idArchivoDestino"))                    
                End If
            Else
                tableFolio.Visible = True
                rpHeader.Visible = False
                tableMain.Visible = False
                butAceptar.Visible = True
            End If
        Else
            If Request.QueryString("Tipo").ToString().Split("|")(0) = "Valoración" Then
                tableFolio.Visible = False
                rpHeader.Visible = True
                tableMain.Visible = True
                lblidNorma.Text = Request.QueryString("idNorma").ToString()
                gdbuscadorresultado.DataBind()
                treeArchivoDestino.Visible = False
                butAceptar.Text = "Asignar archivo"
                butAceptar.Visible = True
                trArchivoDestino.Visible = True
                If gdbuscadorresultado.VisibleRowCount > 0 Then
                    lblFolio.Text = gdbuscadorresultado.GetRowValues(0, "idTraspasos")
                    lblUserName.Text = gdbuscadorresultado.GetRowValues(0, "Username")
                    lblFecha_Solicitud.Text = gdbuscadorresultado.GetRowValues(0, "Fecha_Solicitud")
                    lblFecha_Aplicacion.Text = gdbuscadorresultado.GetRowValues(0, "Fecha_Aplicacion").ToString.Replace("01/01/1900 12:00:00 a.m.", "")
                    lblidArchivoOrigen.Text = gdbuscadorresultado.GetRowValues(0, "Archivo_Descripcion")
                    lblidArchivoDestino.Text = gdbuscadorresultado.GetRowValues(0, "ArchivoDestino")
                End If
            End If
        End If
    End Sub

    Protected Sub butRepAutorizacion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butRepAutorizacion.Click
        If gdbuscadorresultado.Selection.Count > 0 Then
            Dim iRow As Integer
            Session("idDescriptionRPTArray") = ""
            For iRow = 0 To gdbuscadorresultado.VisibleRowCount - 1
                If gdbuscadorresultado.Selection.IsRowSelected(iRow) Then
                    Session("idDescriptionRPTArray") += gdbuscadorresultado.GetRowValues(iRow, "idDescripcion").ToString() & ","
                End If
            Next
            Session("idDescriptionRPTArray") = Session("idDescriptionRPTArray").ToString.Substring(0, Session("idDescriptionRPTArray").ToString.Length - 1)
            Response.Redirect("Wfrm_Traspasos_RptAutorizacion.aspx?idArchivo=" & Request.QueryString("idArchivo").ToString() & _
                              "&Tipo=" & Request.QueryString("Tipo") & _
                              "&sTitulo=" & Request.QueryString("Tipo").ToString().Replace("|", " ") & " del archivo " & lblidArchivoOrigen.Text & " al archivo " & cmbArchivoDestino.SelectedItem.Text)
        Else
            MsgBox1.ShowMessage("Debe seleccionar por lo menos una descripcion archivistica.")
        End If
    End Sub

    Protected Sub butIdTraspaso_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butIdTraspaso.Click
        If txtIdTraspaso.Text.Length < 1 Then
            MsgBox1.ShowMessage("Debe proporcionar el numero de folio")
        Else
            Dim svr = New Portalv9.WSArchivo.Service1
            Dim dsTraspasos = svr.ListaTraspasos_ArchivoOrigen(txtIdTraspaso.Text, -1)
            If dsTraspasos.Tables(0).Rows.Count > 0 Then
                If getFasesTrasladosByVal(dsTraspasos.Tables(0).Rows(0)("idStatus")).Split(" ")(0) = "Valoración" Then
                    Response.Redirect("Wfrm_TraspasosConfirmacion.aspx?idArchivo=" & dsTraspasos.Tables(0).Rows(0)("idArchivoOrigen") & _
                                              "&Tipo=" & Request.QueryString("Tipo") & _
                                              "&idNorma=" & dsTraspasos.Tables(0).Rows(0)("idNorma") & _
                                              "&idTraspasos=" & txtIdTraspaso.Text & _
                                              "&sTitulo=Valoración primaria del archivo " & dsTraspasos.Tables(0).Rows(0)("Archivo_Descripcion"))
                Else
                    MsgBox1.ShowMessage("El folio " & txtIdTraspaso.Text & " ya fue transferido.")
                End If
            Else
                MsgBox1.ShowMessage("No existen valoraciones o transferencias con ese numero de folio.")
            End If
        End If
    End Sub

    Protected Sub butAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butAceptar.Click
        Dim svrArchivo As New WSArchivo.Service1
        Dim objGlobal As New clsGlobal
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If Not objGlobal.TicketValido(tTicket) Then
            LogOff()
            Exit Sub
        End If
        If Request.QueryString("Tipo").ToString().Split("|")(0) = "Valoración" Then
            If cmbArchivoDestino.SelectedItem Is Nothing Then
                MsgBox1.ShowMessage("Seleccione un el archivo de concentración.")
                Return
            End If
            'svrArchivo.ABC_TraspasosMaster(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idTraspasos"), _
            '    tTicket.NoIdentidad, Now, Request.QueryString("idArchivo"), cmbArchivoDestino.SelectedItem.Value)
            butRepAutorizacion.Visible = True
            butAceptar.Visible = False
            MsgBox1.ShowMessage("La valoración fue asignada ahora usted puede imprimir el reporte de autorización.")
        Else
            If gdbuscadorresultado.Selection.Count < 1 Then
                MsgBox1.ShowMessage("Seleccione las series del archivo de tramite que quiere transferir.")
                Return
            End If
            If treeArchivoDestino.GetSelectedNodes.Count < 1 Then
                MsgBox1.ShowMessage("Seleccione las series del archivo de concentración que quiere transferir.")
                Return
            End If
            If cmbArchivoDestino.SelectedItem Is Nothing Then
                SelectArchivoDestino(Integer.Parse(idArchivoDestino.Text))
            End If
            Dim listDestino As List(Of TreeListNode) = treeArchivoDestino.GetSelectedNodes()
            Dim valorPadreDestino As Integer
            Try
                If Request.QueryString("idNorma") <> cmbArchivoDestino.SelectedItem.GetValue("idNorma") Then
                    treeArchivoDestino.UnselectAll()
                    MsgBox1.ShowMessage("No se puede transferir nodos entre archivos con diferentes normas.")
                    Return
                End If
            Catch ex As Exception
                MsgBox1.ShowMessage("Error en las normas de los archivos, recuerde que no se puede transferir nodos entre archivos con diferentes normas. <br>" & ex.Message)
            End Try
            Try
                Dim myAlert As String = ""
                For Each nNode As TreeListNode In listDestino
                    valorPadreDestino = nNode.Key
                    For iRow = 0 To gdbuscadorresultado.VisibleRowCount - 1
                        If gdbuscadorresultado.Selection.IsRowSelected(iRow) Then
                            If Request.QueryString("idArchivo") = cmbArchivoDestino.SelectedItem.Value And _
                            gdbuscadorresultado.GetRowValues(iRow, "idDescripcion") = valorPadreDestino Then
                                myAlert = "Al menos uno de los nodos no se pudo transferir ya que se intento tranferir a el mismo"
                            Else
                                svrArchivo.Transfiere_Archivo_Descripciones(Request.QueryString("idArchivo"), gdbuscadorresultado.GetRowValues(iRow, "idDescripcion") _
                                                                , cmbArchivoDestino.SelectedItem.Value, valorPadreDestino)
                                'svrArchivo.ABC_Traspasos(WSArchivo.OperacionesABC.operCambio, gdbuscadorresultado.GetRowValues(iRow, "idTraspasosIndice"), Request.QueryString("idTraspasos"), _
                                '    gdbuscadorresultado.GetRowValues(iRow, "idDescripcion"), _
                                '    getFasesTrasladosByText(Request.QueryString("Tipo").Replace("|", " ")))
                                'La siguiente linea es un update manual para liberer la serie 
                                svrArchivo.BuscaExpediente("Update Archivo_Descripciones_Archivisticas set EnTraspaso = 0 Where idDescripcion=" & gdbuscadorresultado.GetRowValues(iRow, "idDescripcion") & ";")
                            End If
                        End If
                    Next
                Next
                If myAlert <> "" Then
                    MsgBox1.ShowMessage(myAlert)
                Else
                    MsgBox1.ShowMessage("La transferencia se ha realizado con éxito..")
                End If
            Catch ex As Exception
                MsgBox1.ShowMessage(ex.Message)
            Finally
                Response.Redirect("Wfrm_TraspasosHistorico.aspx")
            End Try
        End If
    End Sub

    Function getFasesTrasladosByVal(ByVal sVal As String) As String
        Dim svrStats = New Portalv9.WSArchivo.Service1
        Dim myStats As New ASPxComboBox
        myStats.ValueField = "IDCatalogo_item"
        myStats.TextField = "Descripcion"
        myStats.DataSource = svrStats.ListaCatalogo_Datos(15)
        myStats.DataBind()
        Return myStats.Items.FindByValue(sVal).Text
    End Function

    Function getFasesTrasladosByText(ByVal sDescripcion As String) As Integer
        Dim svrStats = New Portalv9.WSArchivo.Service1
        Dim myStats As New ASPxComboBox
        myStats.ValueField = "IDCatalogo_item"
        myStats.TextField = "Descripcion"
        myStats.DataSource = svrStats.ListaCatalogo_Datos(15)
        myStats.DataBind()
        Return myStats.Items.FindByText(sDescripcion).Value
    End Function

    Sub SelectArchivoDestino(ByVal myArchDest As Integer)
        cmbArchivoDestino.DataBind()
        'cmbArchivoDestino.Items.FindByValue(myArchDest).Selected = True
        treeArchivoDestino.UnselectAll()
        treeArchivoDestino.ClearNodes()
        'dsListaFondo.SelectParameters.Item("idArchivo").DefaultValue = cmbArchivoDestino.SelectedItem.Value
        treeArchivoDestino.DataBind()
        treeArchivoDestino.Visible = True
    End Sub
End Class