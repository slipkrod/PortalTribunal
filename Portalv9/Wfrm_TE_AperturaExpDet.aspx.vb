Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxGridView
Partial Public Class Wfrm_TE_AperturaExpDet
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 12
    Private Const eventoOK As Integer = 22
    Private tTicket As IDTicket
    Dim svr As New SAEX.ServiciosSAEX
    Dim svrArchivo As New WSArchivo.Service1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ds As DataSet
            ds = svr.BuscaInstanciaExpedientexID(Request.QueryString("Folio_Bolsa"), Request.QueryString("InstanciaId"))
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("Confidencial") = 1 Then
                    lblConfidencial.Text = "Confidencial"
                End If
                lblTipoExpediente.Text = ds.Tables(0).Rows(0).Item("TipoExpediente")
                lblClaveTipoExpediente.Text = ds.Tables(0).Rows(0).Item("Clave_TipoExpediente")
                lblEntidad.Text = ds.Tables(0).Rows(0).Item("Entidad")
                lblidEntidad.Text = ds.Tables(0).Rows(0).Item("idEntidad")
                lblAreaAdministracion.Text = ds.Tables(0).Rows(0).Item("Area")
                lblidArea.Text = ds.Tables(0).Rows(0).Item("idArea")
                txtAnio.Text = ds.Tables(0).Rows(0).Item("Anio")
                lblAno.Text = ds.Tables(0).Rows(0).Item("Anio")
                dlMes.SelectedIndex = dlMes.Items.FindByValue(ds.Tables(0).Rows(0).Item("Mes")).Index
                lblMes.Text = ds.Tables(0).Rows(0).Item("Mes")
                dlDia.SelectedIndex = dlDia.Items.FindByValue(ds.Tables(0).Rows(0).Item("Dia")).Index
                lblDia.Text = ds.Tables(0).Rows(0).Item("Dia")
                lblLLave.Text = ds.Tables(0).Rows(0).Item("Llave_expediente")
                lblInstancia.Text = Request.QueryString("InstanciaId")
                lblSecuencia.Text = ds.Tables(0).Rows(0).Item("Secuencia")
                lblidNorma.Text = ds.Tables(0).Rows(0).Item("idNorma")
                lblidSerie.Text = ds.Tables(0).Rows(0).Item("idTipoDocumento")
                lblidDocumentoPID.Text = ds.Tables(0).Rows(0).Item("idFolioPID")
                DataBind()
                ASPxTreeList1.ExpandAll()
                CargaIndices(ASPxTreeList1.RootNode)
            End If
        End If
    End Sub

    Protected Sub CargaIndices(ByVal startNode As TreeListNode)
        Dim dsCampos As DataSet

        Dim dtIndicesDocumentos As New DataTable()
        dtIndicesDocumentos.TableName = "Campos"
        Dim pkCampoID As DataColumn = dtIndicesDocumentos.Columns.Add("idIndice", Type.GetType("System.Int32"))
        dtIndicesDocumentos.Columns.Add("idArchivo", Type.GetType("System.Int32"))
        dtIndicesDocumentos.Columns.Add("idDescripcion", Type.GetType("System.Int32"))
        dtIndicesDocumentos.Columns.Add("idFolio", Type.GetType("System.Int32"))
        dtIndicesDocumentos.Columns.Add("Indice_Tipo", Type.GetType("System.String"))
        dtIndicesDocumentos.Columns.Add("Indice_descripcion", Type.GetType("System.String"))
        dtIndicesDocumentos.Columns.Add("Indice_LongitudMax", Type.GetType("System.Int32"))
        dtIndicesDocumentos.Columns.Add("Indice_Obligatorio", Type.GetType("System.Int32"))
        dtIndicesDocumentos.Columns.Add("Indice_Unico", Type.GetType("System.Int32"))
        dtIndicesDocumentos.Columns.Add("Indice_Mascara", Type.GetType("System.String"))
        dtIndicesDocumentos.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtIndicesDocumentos.Columns.Add("idNorma", Type.GetType("System.Int32"))
        dtIndicesDocumentos.Columns.Add("idArea", Type.GetType("System.Int32"))
        dtIndicesDocumentos.Columns.Add("idElemento", Type.GetType("System.Int32"))
        dtIndicesDocumentos.Columns.Add("idNivel", Type.GetType("System.Int32"))
        dtIndicesDocumentos.Columns.Add("Valor", Type.GetType("System.String"))
        dtIndicesDocumentos.PrimaryKey = New DataColumn() {pkCampoID}


        Dim iterator As TreeListNodeIterator = New TreeListNodeIterator(startNode)
        Do While Not iterator.Current Is Nothing
            dsCampos = svrArchivo.ListaArchivo_indicexidDescripcion(ConfigurationManager.AppSettings("Archivo"), iterator.Current.Item("idDescripcion"))
            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                Dim IndiceRow As DataRow = dtIndicesDocumentos.NewRow()
                IndiceRow("idIndice") = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                IndiceRow("idArchivo") = dsCampos.Tables(0).Rows(intJ).Item("idArchivo")
                IndiceRow("idDescripcion") = dsCampos.Tables(0).Rows(intJ).Item("idDescripcion")
                IndiceRow("idFolio") = dsCampos.Tables(0).Rows(intJ).Item("idFolio")
                IndiceRow("Indice_Tipo") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                IndiceRow("Indice_descripcion") = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                IndiceRow("Indice_LongitudMax") = dsCampos.Tables(0).Rows(intJ).Item("Indice_LongitudMax")
                IndiceRow("Indice_Obligatorio") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                IndiceRow("Indice_Unico") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Unico")
                IndiceRow("Indice_Mascara") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")
                IndiceRow("Descripcion") = dsCampos.Tables(0).Rows(intJ).Item("Descripcion")
                IndiceRow("idNorma") = dsCampos.Tables(0).Rows(intJ).Item("idNorma")
                IndiceRow("idArea") = dsCampos.Tables(0).Rows(intJ).Item("idArea")
                IndiceRow("idElemento") = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
                IndiceRow("idNivel") = dsCampos.Tables(0).Rows(intJ).Item("idNivel")
                IndiceRow("Valor") = dsCampos.Tables(0).Rows(intJ).Item("Valor")
                dtIndicesDocumentos.Rows.Add(IndiceRow)
            Next
            iterator.GetNext()
        Loop
        ASPxGridView1.DataSource = dtIndicesDocumentos
        ASPxGridView1.KeyFieldName = "idIndice"
        ASPxGridView1.DataBind()

    End Sub
    Private Sub GetParentNodeKey(ByVal node As TreeListNode)
    End Sub



    Protected Sub dsExpediente_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsExpediente.Selecting

    End Sub
    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        Return "~/" & ASPxTreeList1.FindNodeByKeyValue(container.NodeKey).GetValue("Imagen_close")
    End Function


    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAceptar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim llave_expediente As String
        Dim Secuencia As String
        If FechaValida() Then
            Try
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If tTicket Is Nothing Then
                    LogOff()
                End If
                If txtAnio.Text = lblAno.Text And dlMes.SelectedItem.Value = lblMes.Text And dlDia.SelectedItem.Value = lblDia.Text And lblLLave.Text.Substring(3, 1) <> "?" Then
                    If ValidaLLaveduplicada() Then
                        llave_expediente = GeneraNuevaLLave(Secuencia)
                    Else
                        llave_expediente = lblLLave.Text
                        Secuencia = lblSecuencia.Text
                    End If
                Else
                    llave_expediente = GeneraNuevaLLave(Secuencia)
                End If
                GuardaDocumentos_Arbol(lblInstancia.Text, Secuencia, llave_expediente)
                CreaIndicedeCampos()
            Catch ex As Exception
                dlgBoxExcepciones.ShowMessage(ex.Message)
            End Try
            Response.Redirect("Wfrm_TE_AperturaExp.aspx")
        Else
            dlgBoxExcepciones.ShowMessage("Error en año mes y dia.")
        End If
    End Sub

    Private Sub GuardaDocumentos_Arbol(ByVal InstanciaId As Integer, ByVal Secuencia As String, ByVal Llave_expediente As String)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsDocumentos As DataSet
        Dim nFila As DataRow

        rsDocumentos = svr.Obten_Atributos(eventoOK, "CorteInstancia")

        nFila = rsDocumentos.Tables(0).NewRow
        nFila.Item("Indice_de_busqueda") = ""
        nFila.Item("Indice_de_busqueda_Campos") = ""
        nFila.Item("Anio") = txtAnio.Text
        nFila.Item("Mes") = dlMes.SelectedItem.Value
        nFila.Item("Dia") = dlDia.SelectedItem.Value
        nFila.Item("Secuencia") = Secuencia
        nFila.Item("Llave_expediente") = Llave_expediente

        rsDocumentos.Tables(0).Rows.Add(nFila)
        svr.SQLUpdate_Campos_Atributos(rsDocumentos, "corteInstancia", InstanciaId)

        svr.TransitaInstancia(InstanciaId, eventoOK, "", tTicket.UsrID)
        GuardaDocumentos_Hijos(Request.QueryString("Folio_Bolsa"), InstanciaId, Secuencia, Llave_expediente)

    End Sub

    Private Sub GuardaDocumentos_Hijos(ByVal Folio_bolsa As String, ByVal InstanciaPID As Integer, ByVal Secuencia As String, ByVal Llave_expediente As String)
        Dim intI As Integer
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsDocumentos As DataSet
        Dim rsInstancias As DataSet
        Dim nFila As DataRow

        rsInstancias = svr.BuscaInstanciaExpedientexID(Folio_bolsa, InstanciaPID)
        For intI = 0 To rsInstancias.Tables(0).Rows.Count - 1
            rsDocumentos = svr.Obten_Atributos(eventoOK, "CorteInstancia")
            nFila = rsDocumentos.Tables(0).NewRow
            nFila.Item("Indice_de_busqueda") = ""
            nFila.Item("Indice_de_busqueda_Campos") = ""
            nFila.Item("Anio") = txtAnio.Text
            nFila.Item("Mes") = dlMes.SelectedItem.Value
            nFila.Item("Dia") = dlDia.SelectedItem.Value
            nFila.Item("Secuencia") = Secuencia
            nFila.Item("Llave_expediente") = Llave_expediente
            rsDocumentos.Tables(0).Rows.Add(nFila)
            svr.SQLUpdate_Campos_Atributos(rsDocumentos, "corteInstancia", rsInstancias.Tables(0).Rows(intI).Item("InstanciaId"))
            If rsInstancias.Tables(0).Rows(intI).Item("Confirmacion_recibido") = 1 Then
                svr.TransitaInstancia(rsInstancias.Tables(0).Rows(intI).Item("InstanciaId"), eventoOK, "", tTicket.UsrID)
            End If
        Next
    End Sub
    Private Function FechaValida() As Boolean
        If txtAnio.Text <> "" And txtAnio.Text <> "0" Then
            If IsNumeric(txtAnio.Text) And IsNumeric(dlMes.SelectedItem.Value) And IsNumeric(dlDia.SelectedItem.Value) Then
                If IsDate(dlDia.SelectedItem.Value & "/" & dlMes.SelectedItem.Value & "/" & txtAnio.Text) Then
                    FechaValida = True
                Else
                    FechaValida = False
                End If
            Else
                FechaValida = False
            End If
        Else
            FechaValida = False
        End If
    End Function

    Private Function ValidaLLaveduplicada() As Boolean
        Dim svr As New SAEX.ServiciosSAEX
        ValidaLLaveduplicada = svr.BuscaLLaveExpedienteDuplicada(lblInstancia.Text, lblLLave.Text)
    End Function

    Private Function GeneraNuevaLLave(ByRef Secuencia As String) As String
        Dim dsFolioSecuencia As DataSet
        Dim SecuenciaHEX As String

        dsFolioSecuencia = svrArchivo.Obten_Secuencia(ConfigurationManager.AppSettings("Archivo"), lblidNorma.Text, lblidSerie.Text, txtAnio.Text, dlMes.SelectedItem.Value, dlDia.SelectedItem.Value, "1.1.4", lblidDocumentoPID.Text)
        Secuencia = dsFolioSecuencia.Tables(0).Rows(0).Item("Valor")
        SecuenciaHEX = dsFolioSecuencia.Tables(0).Rows(0).Item("ValorHEX")

        GeneraNuevaLLave = lblidEntidad.Text.PadLeft(1, "0") & lblidArea.Text.PadLeft(2, "00") & lblClaveTipoExpediente.Text & txtAnio.Text & dlMes.SelectedItem.Value & dlDia.SelectedItem.Value & SecuenciaHEX

    End Function

    Private Sub CreaIndicedeCampos()
        Dim intI As Integer
        Dim valor As String

        For intI = 0 To ASPxGridView1.VisibleRowCount - 1
            valor = CType(ASPxGridView1.FindRowCellTemplateControl(intI, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).Text
            svrArchivo.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, ASPxGridView1.GetRowValues(intI, "idNorma"), ASPxGridView1.GetRowValues(intI, "idArea"), ASPxGridView1.GetRowValues(intI, "idElemento"), ASPxGridView1.GetRowValues(intI, "idIndice"), ASPxGridView1.GetRowValues(intI, "idArchivo"), ASPxGridView1.GetRowValues(intI, "idDescripcion"), ASPxGridView1.GetRowValues(intI, "idFolio"), ASPxGridView1.GetRowValues(intI, "idNivel"), ASPxGridView1.GetRowValues(intI, "idSerie"), 0, valor, ASPxGridView1.GetRowValues(intI, "Indice_Tipo"), 0)
        Next
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

End Class
