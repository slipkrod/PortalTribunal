Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxTreeList

Partial Public Class Wfrm_ValorizacionSeleccionados_Recibe
    Inherits System.Web.UI.Page
    Dim sv As New WSArchivo.Service1
#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
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

    Protected Sub btnBuscaTransferencia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscaTransferencia.Click
        Dim rsDatosArchivo As DataSet
        Dim rsDatosTransferencia As DataSet
        rsDatosTransferencia = sv.ListaTransferencia_Primaria(txtTransferencia.Value)
        If rsDatosTransferencia.Tables(0).Rows.Count > 0 Then
            Select Case rsDatosTransferencia.Tables(0).Rows(0).Item("Status")
                Case -1
                    MsgBox1.ShowMessage("Ese folio de transferencia se encuentra cancelado")
                Case 0
                    MsgBox1.ShowMessage("El folio de transferencia se encuentra sin transferir")
                Case 1
                    MsgBox1.ShowMessage("El folio de transferencia se encuentra sin transferir")
                Case 2
                    rsDatosArchivo = sv.ListaArchivo(rsDatosTransferencia.Tables(0).Rows(0).Item("idArchivoOrigen"))
                    idArchivoOrigen.Text = rsDatosTransferencia.Tables(0).Rows(0).Item("idArchivoOrigen")
                    idArchivoDestino.Text = rsDatosTransferencia.Tables(0).Rows(0).Item("idArchivoDestino")
                    lblidNorma.Text = rsDatosArchivo.Tables(0).Rows(0).Item("idNorma")
                    lblFolio.Text = txtTransferencia.Text
                    lblidArchivoOrigen.Text = rsDatosArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")
                    lblFecha_Solicitud.Text = rsDatosTransferencia.Tables(0).Rows(0).Item("Fecha_Solicitud")
                    rsDatosArchivo = sv.ListaArchivo(rsDatosTransferencia.Tables(0).Rows(0).Item("idArchivoDestino"))
                    lblidArchivoDestino.Text = rsDatosArchivo.Tables(0).Rows(0).Item("Archivo_Descripcion")
                    lblFecha_Aplicacion.Text = rsDatosTransferencia.Tables(0).Rows(0).Item("Fecha_Aplicacion")

                    dsExpedientesTransferir.SelectParameters("idFolio").DefaultValue = txtTransferencia.Value
                    dsExpedientesTransferir.Select()
                    aspxtreeDocumentos.DataBind()

                    rpHeader.ClientVisible = True

                Case 3
                    MsgBox1.ShowMessage("Ese folio de transferencia ya fué aplicado")
            End Select

        Else
            MsgBox1.ShowMessage("No existe ese folio de transferencia....")
            rpHeader.ClientVisible = False
        End If

    End Sub

    Protected Sub butTransferir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butTransferir.Click
        Dim intI As Integer
        Dim rsElementoPadre As DataSet
        Dim rsElementoPadreNew As DataSet        
        'For Each nNodo As TreeListNode In aspxtreeDocumentos.GetSelectedNodes()
        '    If nNodo.Level = 1 Then
        '        sv.ABC_Transferencias_Primarias_Expedientes(3, txtTransferencia.Value, nNodo.GetValue("idFolioDetalle"), nNodo.GetValue("idDescripcion"), nNodo.GetValue("idDocumentoPID"), 3)
        '    ElseIf nNodo.Level = 2 Then
        '        sv.ABC_Transferencias_Primarias_Documentos(3, txtTransferencia.Value, nNodo.GetValue("idFolioDetalle"), nNodo.GetValue("idFolioDetalleDocumento"), nNodo.GetValue("idDescripcion"), nNodo.GetValue("idDocumentoPID"), 3)
        '    End If
        'Next

        For intI = 0 To aspxtreeDocumentos.Nodes.Count - 1
            Dim iterator As TreeListNodeIterator = New TreeListNodeIterator(aspxtreeDocumentos.Nodes(intI))
            Do While Not iterator.Current Is Nothing
                If iterator.Current.Selected Then
                    If iterator.Current.Level = 1 Then
                        sv.ABC_Transferencias_Primarias_Expedientes(3, txtTransferencia.Value, iterator.Current.GetValue("idFolioDetalle"), iterator.Current.GetValue("idDescripcion"), iterator.Current.GetValue("idDocumentoPID"), 3)
                    ElseIf iterator.Current.Level = 2 Then
                        If aspxtreeDocumentos.FindNodeByKeyValue(iterator.Current.Key).ParentNode.Selected Then
                            sv.ABC_Transferencias_Primarias_Documentos(3, txtTransferencia.Value, iterator.Current.GetValue("idFolioDetalle"), iterator.Current.GetValue("idFolioDetalleDocumento"), iterator.Current.GetValue("idDescripcion"), iterator.Current.GetValue("idDocumentoPID"), 3)
                        End If
                    End If
                Else
                    If iterator.Current.Level = 1 Then
                        'Se transfiere el expediente al archivo de concentracion
                        rsElementoPadre = sv.ListaArchivo_Descripciones_idDescripcion(idArchivoOrigen.Text, iterator.Current.GetValue("idDocumentoPID"))
                        If rsElementoPadre.Tables(0).Rows.Count > 0 Then
                            rsElementoPadreNew = sv.ListaArchivo_Codigo_clasificacion(idArchivoDestino.Text, rsElementoPadre.Tables(0).Rows(0).Item("Codigo_clasificacion"))
                            If rsElementoPadreNew.Tables(0).Rows.Count > 0 Then
                                sv.Transfiere_Archivo_Descripciones_primarias(idArchivoDestino.Text, iterator.Current.GetValue("idDescripcion"), idArchivoOrigen.Text, iterator.Current.GetValue("idDocumentoPID"), iterator.Current.GetValue("idFolioDetalle"))
                            End If
                        End If
                    End If
                End If
                iterator.GetNext()
            Loop
        Next



        sv.ABC_Transferencias_Primarias(3, txtTransferencia.Value, 0, Now.Date, 0, 0, "", 3)
        Response.Redirect("Wfrm_ValorizacionSeleccionados_OK.aspx")
    End Sub

    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        If container.Expanded Then
            Return container.GetValue("Imagen_Open")
        Else
            Return container.GetValue("Imagen_Close")
        End If
    End Function

    Protected Sub btnBuscaExpediente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscaExpediente.Click
        Dim rsDatosExpediente As DataSet
        Dim rsDatosTransferencia As DataSet
        Dim rsElementoPadre As DataSet
        Dim idFolioDetalle As Integer
        Dim rsElementoPadreNew As DataSet
        Dim rsElementoDocumentos As DataSet
        Dim intI As Integer

        rsDatosExpediente = sv.ListaArchivo_Codigo_clasificacion(idArchivoOrigen.Text, txtBuscaCodigo.Text)
        If rsDatosExpediente.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowMessage("Expediente no encontrado")
        Else
            'Se da de alta el expediente y sus documentos en la tabla de transferencias
            rsDatosTransferencia = sv.ListaTransferencia_Primaria(txtTransferencia.Value)
            idFolioDetalle = sv.ABC_Transferencias_Primarias_Expedientes(0, rsDatosTransferencia.Tables(0).Rows(0).Item("idFolio"), 0, rsDatosExpediente.Tables(0).Rows(0).Item("idDescripcion"), rsDatosExpediente.Tables(0).Rows(0).Item("idDocumentoPID"), 2)
            sv.ABC_Transferencias_Primarias_Documentos(0, rsDatosTransferencia.Tables(0).Rows(0).Item("idFolio"), idFolioDetalle, 0, rsDatosExpediente.Tables(0).Rows(0).Item("idDescripcion"), rsDatosExpediente.Tables(0).Rows(0).Item("idDocumentoPID"), 0)
            rsElementoDocumentos = sv.ListaArchivo_Descripciones_idDescripcion_Hijos(idArchivoOrigen.Text, rsDatosExpediente.Tables(0).Rows(0).Item("idDescripcion"))
            For intI = 0 To rsElementoDocumentos.Tables(0).Rows.Count - 1
                sv.ABC_Transferencias_Primarias_Documentos(0, rsDatosTransferencia.Tables(0).Rows(0).Item("idFolio"), idFolioDetalle, 0, rsElementoDocumentos.Tables(0).Rows(intI).Item("idDescripcion"), rsElementoDocumentos.Tables(0).Rows(intI).Item("idDocumentoPID"), 0)
            Next

            'Se transfiere el expediente al archivo de concentración
            rsElementoPadre = sv.ListaArchivo_Descripciones_idDescripcion(idArchivoOrigen.Text, rsDatosExpediente.Tables(0).Rows(0).Item("idDocumentoPID"))
            If rsElementoPadre.Tables(0).Rows.Count > 0 Then
                rsElementoPadreNew = sv.ListaArchivo_Codigo_clasificacion(idArchivoDestino.Text, rsElementoPadre.Tables(0).Rows(0).Item("Codigo_clasificacion"))
                If rsElementoPadreNew.Tables(0).Rows.Count > 0 Then
                    sv.Transfiere_Archivo_Descripciones_primarias(idArchivoOrigen.Text, rsDatosExpediente.Tables(0).Rows(0).Item("idDescripcion"), idArchivoDestino.Text, rsElementoPadreNew.Tables(0).Rows(0).Item("idDescripcion"), idFolioDetalle)
                End If
            End If

            'Se actualiza el arbol.
            dsExpedientesTransferir.SelectParameters("idFolio").DefaultValue = txtTransferencia.Value
            dsExpedientesTransferir.Select()
            aspxtreeDocumentos.DataBind()

            ASPxPopupControl1.ShowOnPageLoad = False
        End If
    End Sub
End Class