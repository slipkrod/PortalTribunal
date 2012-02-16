Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxGridView
Imports System.Collections.Generic
Partial Public Class Wfrm_EN_RequrimientoDocDet
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket
    Private nodeKeys As List(Of String)
    Private Diccionario As New Dictionary(Of String, String)
    Private archivo = ConfigurationManager.AppSettings("Archivo")
    Private Const eventoOK As Integer = 2
    Private Fecha_solicitud As Date
    Private agregarnuevo As Integer
    Private Clave_Entidad, Clave_AreaAdmin, Codigo_expediente As String
    Dim Entidad, AreaAdmin, secuencia As Integer
    Private Const Flujo As Integer = 1
    Private idInstanciaPID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As DataSet
        Dim svr As New SAEX.ServiciosSAEX

        Me.lblError.Text = ""
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

                'If Request.QueryString("confidencial") = "0" Then
                lbltitle.Text = "Consulta->Usuario/Requerimiento de préstamo de documentos"

                'Else
                'lbltitle.Text = "Envío->Usuario/Solicitud de envío de documentos confidenciales"
                'Label2.Text = "= Expediente Confidencial ="
                'End If


                If Not Session("idTipoExpediente") Is Nothing Then
                    Dim rsEntidadArea As DataSet
                    Dim rsExpediente As DataSet
                    rsEntidadArea = svr.BuscaEntidad_Area(tTicket.NoIdentidad)
                    rsExpediente = svr.BuscaTipoExpedientexid(Session("idTipoExpediente"))

                    lblTipoDocumento.Text = Session("idTipoExpediente")
                    lblTipoExpediente.Text = rsExpediente.Tables(0).Rows(0).Item("TipoExpediente")
                    lblEntidad.Text = rsEntidadArea.Tables(0).Rows(0).Item("Entidad")
                    lblArea.Text = rsEntidadArea.Tables(0).Rows(0).Item("AreaAdmin")
                    lblAno.Text = Session("Anio")
                    lblmes.Text = Session("Mes")
                    lbldia.Text = Session("Dia")
                    lblLlave.Text = Session("Llave_expediente")
                    lblIndice.Text = Session("Indice")
                    lblIndiceCampos.Text = Session("IndiceCampos")
                    'lblInstancia.Text = ds.Tables(0).Rows(0).Item("InstanciaId")
                    'lblTipoDocumento.Text = ds.Tables(0).Rows(0).Item("idTipoDocumento")
                    lblsecuencia.Text = Session("Secuencia")
                    lblTipo_operacion.Text = "110"
                    llenargrid(Session("idTipoExpediente"))
                    usuario.Text = tTicket.UsrID.ToString
                    grupo.Text = tTicket.GrupoAdminID.ToString

                Else

                    ds = svr.BuscaExpedientexIDDescripcion(Request.QueryString("IdDescripcion"))
                    Session("TpExp") = ds.Tables(0).Rows(0).Item("idTipoDocumento")
                    lblTipoExpediente.Text = ds.Tables(0).Rows(0).Item("TipoExpediente")
                    lblEntidad.Text = ds.Tables(0).Rows(0).Item("Entidad")
                    lblArea.Text = ds.Tables(0).Rows(0).Item("Area")
                    lblAno.Text = ds.Tables(0).Rows(0).Item("Anio")
                    lblmes.Text = ds.Tables(0).Rows(0).Item("Mes")
                    lbldia.Text = ds.Tables(0).Rows(0).Item("Dia")
                    lblLlave.Text = ds.Tables(0).Rows(0).Item("Llave_expediente")
                    lblIndice.Text = ds.Tables(0).Rows(0).Item("Indice_de_busqueda")
                    lblInstancia.Text = ds.Tables(0).Rows(0).Item("InstanciaId")
                    lblTipoDocumento.Text = ds.Tables(0).Rows(0).Item("idTipoDocumento")
                    lblsecuencia.Text = ds.Tables(0).Rows(0).Item("Secuencia")
                    lblidFolio.Text = ds.Tables(0).Rows(0).Item("idFolio")
                    usuario.Text = tTicket.UsrID.ToString
                    grupo.Text = tTicket.GrupoAdminID.ToString
                    lblTipo_operacion.Text = "120"
                    llenargrid(Session("TpExp"))
                    ASPxTreeList1.ExpandAll()

                End If


            Catch ex As Exception
                Me.lblError.Text = ex.Message
            End Try
        End If
        ASPxTreeList1.ExpandAll()
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Private Sub llenargrid(ByVal IdSerie As Integer)

        dsLista_SeriesModelo_Hijos.SelectParameters("IdSerie").DefaultValue = IdSerie
        dsLista_SeriesModelo_Hijos.SelectParameters("identidad").DefaultValue = tTicket.NoIdentidad
        dsLista_SeriesModelo_Hijos.Select()
        'ASPxTreeList2.DataBind()
    End Sub
    Private Sub ASPxTreeList1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxTreeList1.DataBound
        Dim iterator As TreeListNodeIterator = New TreeListNodeIterator(ASPxTreeList1.RootNode)
        Do While Not iterator.Current Is Nothing
            If iterator.Current.GetValue("Nivel") = 9 Then
                iterator.Current.AllowSelect = True
                ' DocumentosOK = DocumentosOK + 1
            Else
                iterator.Current.AllowSelect = False
            End If
            iterator.GetNext()
        Loop

        'lblDocumentos.Text = DocumentosOK
    End Sub



    '    For Each nNodo As TreeListNode In ASPxTreeList1.FindNodesByFieldValue("Nivel", 9)
    '        nNodo.AllowSelect = True
    '    Next
    ''For Each nNodo As TreeListNode In ASPxTreeList1.FindNodesByFieldValue("Nivel", 5)
    ''    nNodo.AllowSelect = False
    ''Next
    'End Sub
    'Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
    '    Return "~/" & ASPxTreeList2.FindNodeByKeyValue(container.NodeKey).GetValue("Imagen_close")
    'End Function

    'Protected Sub ASPxTreeList2_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxTreeList2.DataBound
    '    For Each nNodo As TreeListNode In ASPxTreeList2.FindNodesByFieldValue("Nivel", 6)
    '        nNodo.AllowSelect = False
    '    Next
    'End Sub

    'Protected Sub btnaceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnaceptar.Click

    '    Dim idSerie As Integer
    '    Dim svr As New WSArchivo.Service1
    '    Dim dsCampos As DataSet
    '    Dim intJ As Integer
    '    Dim TipoExpPadre = Session("TpExp")
    '    lblError.Text = ""
    '    nodeKeys = New List(Of String)()


    '    If ASPxTreeList2.GetSelectedNodes.Count = 0 Then
    '        lblError.Text = "Debe selección al menos un documento a enviar."
    '    Else
    '        Dim dtIndicesDocumentos As New DataTable()
    '        dtIndicesDocumentos.TableName = "Campos"

    '        Dim pkCampoID As DataColumn = dtIndicesDocumentos.Columns.Add("idIndice", Type.GetType("System.Int32"))
    '        dtIndicesDocumentos.Columns.Add("Indice_Tipo", Type.GetType("System.String"))
    '        dtIndicesDocumentos.Columns.Add("Indice_descripcion", Type.GetType("System.String"))
    '        dtIndicesDocumentos.Columns.Add("Indice_LongitudMax", Type.GetType("System.Int32"))
    '        dtIndicesDocumentos.Columns.Add("Indice_Obligatorio", Type.GetType("System.Int32"))
    '        dtIndicesDocumentos.Columns.Add("Indice_Unico", Type.GetType("System.Int32"))
    '        dtIndicesDocumentos.Columns.Add("Indice_Mascara", Type.GetType("System.String"))
    '        dtIndicesDocumentos.Columns.Add("Serie_nombre", Type.GetType("System.String"))
    '        dtIndicesDocumentos.Columns.Add("idNorma", Type.GetType("System.Int32"))
    '        dtIndicesDocumentos.Columns.Add("idArea", Type.GetType("System.Int32"))
    '        dtIndicesDocumentos.Columns.Add("idElemento", Type.GetType("System.Int32"))
    '        dtIndicesDocumentos.Columns.Add("idNivel", Type.GetType("System.Int32"))
    '        dtIndicesDocumentos.Columns.Add("idSerie", Type.GetType("System.Int32"))
    '        dtIndicesDocumentos.PrimaryKey = New DataColumn() {pkCampoID}

    '        For Each nNodo As TreeListNode In ASPxTreeList2.GetSelectedNodes()
    '            idSerie = nNodo.Key
    '            dsCampos = svr.ListaSeries_Indices_padres(idSerie)
    '            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1

    '                Dim Row As DataRow = dtIndicesDocumentos.Rows.Find(dsCampos.Tables(0).Rows(intJ).Item("idIndice"))
    '                If Row Is Nothing Then
    '                    If dsCampos.Tables(0).Rows(intJ).Item("idSerie") <> TipoExpPadre Then
    '                        Dim IndiceRow As DataRow = dtIndicesDocumentos.NewRow()
    '                        IndiceRow("idIndice") = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
    '                        IndiceRow("Indice_Tipo") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
    '                        IndiceRow("Indice_descripcion") = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
    '                        IndiceRow("Indice_LongitudMax") = dsCampos.Tables(0).Rows(intJ).Item("Indice_LongitudMax")
    '                        IndiceRow("Indice_Obligatorio") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
    '                        IndiceRow("Indice_Unico") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Unico")
    '                        IndiceRow("Indice_Mascara") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")
    '                        IndiceRow("Serie_nombre") = dsCampos.Tables(0).Rows(intJ).Item("Serie_nombre")
    '                        IndiceRow("idNorma") = dsCampos.Tables(0).Rows(intJ).Item("idNorma")
    '                        IndiceRow("idArea") = dsCampos.Tables(0).Rows(intJ).Item("idArea")
    '                        IndiceRow("idElemento") = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
    '                        IndiceRow("idNivel") = dsCampos.Tables(0).Rows(intJ).Item("idNivel")
    '                        IndiceRow("idSerie") = dsCampos.Tables(0).Rows(intJ).Item("idSerie")
    '                        dtIndicesDocumentos.Rows.Add(IndiceRow)
    '                    End If
    '                End If
    '            Next

    '            SelectParentNode(nNodo)
    '        Next

    '        ASPxGridView1.DataSource = dtIndicesDocumentos
    '        ASPxGridView1.KeyFieldName = "idIndice"
    '        ASPxGridView1.DataBind()
    '        ASPxGridView1.Visible = True
    '        'btnSalvar.Visible = True
    '        lblindices.Visible = True
    '        Bloquear()
    '    End If
    'End Sub
    'Private Sub Bloquear()

    '    Dim NodosSeleccionados = From entry In Diccionario.Keys Order By entry Ascending Select entry

    '    Dim intI As Integer
    '    For intI = 0 To NodosSeleccionados.Count - 1
    '        ASPxTreeList2.FindNodeByKeyValue(NodosSeleccionados(intI)).AllowSelect = True
    '        ASPxTreeList2.FindNodeByKeyValue(NodosSeleccionados(intI)).Selected = True
    '    Next
    '    ASPxTreeList2.ClientVisible = False
    '    btnaceptar.Visible = False
    '    ImageButton1.Visible = True
    'End Sub
    Private Sub SelectParentNode(ByVal Node As DevExpress.Web.ASPxTreeList.TreeListNode)
        If (Node.ParentNode IsNot Nothing) Then
            If Diccionario.ContainsKey(Node.Key) Then

            Else
                Diccionario.Add(Node.Key, Node.ParentNode.Key)
            End If
            SelectParentNode(Node.ParentNode)
        End If
    End Sub

    'Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
    '    lblError.Text = ""
    '    Try
    '        'If ValidaIndicesUnicos() Then
    '        GuardaExpediente()
    '        Response.Redirect("Wfrm_TE_Aviso.aspx?Aviso=" & Server.UrlEncode("El documento se a asignado al Expediente " & Codigo_expediente & " exitosamente."))
    '        'End If

    '    Catch ex As Exception
    '        lblError.Text = ex.Message
    '    End Try
    'End Sub
    'Private Sub GuardaExpediente()

    '    Dim ds As DataSet
    '    Dim svrsa As New SAEX.ServiciosSAEX
    '    Dim nNodoID As Integer

    '    ds = svrsa.BuscaInstancia(Request.QueryString("InstanciaPID"))
    '    nNodoID = ds.Tables(0).Rows(0).Item("IdDocumento")
    '    Clave_Entidad = ds.Tables(0).Rows(0).Item("clave_entidad")
    '    Entidad = ds.Tables(0).Rows(0).Item("idEntidad")
    '    Clave_AreaAdmin = ds.Tables(0).Rows(0).Item("Clave_Area")
    '    AreaAdmin = ds.Tables(0).Rows(0).Item("IdArea")
    '    Codigo_expediente = ds.Tables(0).Rows(0).Item("Llave_expediente")
    '    idInstanciaPID = ds.Tables(0).Rows(0).Item("InstanciaID")
    '    secuencia = ds.Tables(0).Rows(0).Item("secuencia")
    '    Fecha_solicitud = Now
    '    GuardaDocumentos_Hijos(nNodoID)


    'End Sub

    'Private Sub GuardaDocumentos_Hijos(ByVal NewParentKey As Integer)
    '    'Valida bandera 0 Incorpora documentos
    '    If agregarnuevo = 0 Then
    '        Dim svr As New WSArchivo.Service1
    '        Dim nNodoID As Integer
    '        Dim InstanciaPadre As Integer
    '        Dim valor As String
    '        Dim list As List(Of TreeListNode) = ASPxTreeList2.GetSelectedNodes()
    '        For Each nNode As TreeListNode In list
    '            If nNode.Level = 1 Then
    '                InstanciaPadre = NewParentKey
    '            Else
    '                InstanciaPadre = nNode.ParentNode("idSeriePID")
    '            End If
    '            nNodoID = svr.ABC_Archivo_Descripciones(WSArchivo.OperacionesABC.operAlta, archivo, 0, "", nNode("idNivel"), nNode("idSerie"), "", 0, nNode("Serie_nombre"), 0, InstanciaPadre, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", "")
    '            nNode("idSeriePID") = nNodoID
    '            For intI = 0 To ASPxGridView1.VisibleRowCount - 1
    '                If ASPxGridView1.GetRowValues(intI, "idSerie") = nNode("idSerie") Then
    '                    valor = CType(ASPxGridView1.FindRowCellTemplateControl(intI, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).Text
    '                    svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, ASPxGridView1.GetRowValues(intI, "idNorma"), ASPxGridView1.GetRowValues(intI, "idArea"), ASPxGridView1.GetRowValues(intI, "idElemento"), ASPxGridView1.GetRowValues(intI, "idIndice"), archivo, nNodoID, 0, ASPxGridView1.GetRowValues(intI, "idNivel"), ASPxGridView1.GetRowValues(intI, "idSerie"), 0, valor, ASPxGridView1.GetRowValues(intI, "Indice_Tipo"))
    '                End If
    '            Next

    '            If nNode.HasChildren = False And nNode("idNivel") = 223 Then
    '                GuardaDocumentos_HijosInstancia(nNodoID, nNode("idNivel"), nNode("idSerie"), InstanciaPadre)
    '            End If
    '        Next
    '    Else
    '        Dim svr As New WSArchivo.Service1
    '        Dim nNodoID As Integer
    '        Dim InstanciaPadre As Integer
    '        Dim valor As String
    '        Dim list As List(Of TreeListNode) = ASPxTreeList2.GetSelectedNodes()
    '        For Each nNode As TreeListNode In list
    '            If nNode.Level = 1 Then
    '                InstanciaPadre = NewParentKey
    '            Else
    '                InstanciaPadre = nNode.ParentNode("idSeriePID")
    '            End If
    '            nNodoID = svr.ABC_Archivo_Descripciones(WSArchivo.OperacionesABC.operAlta, archivo, 0, "", nNode("idNivel"), nNode("idSerie"), "", 0, nNode("Serie_nombre"), 0, InstanciaPadre, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", "")
    '            nNode("idSeriePID") = nNodoID
    '            For intI = 0 To ASPxGridView1.VisibleRowCount - 1
    '                If ASPxGridView1.GetRowValues(intI, "idSerie") = nNode("idSerie") Then
    '                    valor = CType(ASPxGridView1.FindRowCellTemplateControl(intI, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).Text
    '                    svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, ASPxGridView1.GetRowValues(intI, "idNorma"), ASPxGridView1.GetRowValues(intI, "idArea"), ASPxGridView1.GetRowValues(intI, "idElemento"), ASPxGridView1.GetRowValues(intI, "idIndice"), archivo, nNodoID, 0, ASPxGridView1.GetRowValues(intI, "idNivel"), ASPxGridView1.GetRowValues(intI, "idSerie"), 0, valor, ASPxGridView1.GetRowValues(intI, "Indice_Tipo"))
    '                End If
    '            Next

    '            If nNode.HasChildren = False And nNode("idNivel") = 223 Then
    '                GuardaDocumentos_HijosInstancia(nNodoID, nNode("idNivel"), nNode("idSerie"), InstanciaPadre)
    '            End If
    '        Next
    '    End If

    'End Sub
    Sub GuardaDocumentos_HijosInstancia(ByVal idDocumento As Integer, ByVal idTipoElemento As Integer, ByVal idElemento As Integer, ByVal InstanciaPadre As Integer)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsDocumentos As DataSet
        Dim nInstancia As New SAEX.clsInstancia
        Dim idInstancia As Integer
        Dim iRespuesta As SAEX.Respuesta
        Dim idFolio As Integer
        Dim nFila As DataRow
        Dim objGlobal As New clsGlobal

        idInstancia = svr.ABC_Instancia(usuario.Text, grupo.Text, nInstancia, Flujo, SAEX.OperacionesABC.operAlta, iRespuesta, 1)

        rsDocumentos = svr.Obten_Atributos(eventoOK, "CorteInstancia")
        nFila = rsDocumentos.Tables(0).NewRow
        nFila.Item("InstanciaId") = idInstancia
        nFila.Item("idUsuario_Solicita") = tTicket.NoIdentidad
        nFila.Item("Fecha_solicitud") = Fecha_solicitud
        nFila.Item("idEntidad") = Entidad
        nFila.Item("idArea") = AreaAdmin
        nFila.Item("Status_Bolsa") = 0
        nFila.Item("Folio_bolsa") = System.DBNull.Value 'Request.QueryString("FolioBolsa")
        nFila.Item("idTipoObjeto") = 1 'Documento
        nFila.Item("idTipoDocumento") = lblTipoDocumento.Text
        nFila.Item("idDocumento") = idDocumento
        nFila.Item("idTipoElemento") = idTipoElemento
        nFila.Item("idElemento") = idElemento
        nFila.Item("Confidencial") = Request.QueryString("Confidencial")
        nFila.Item("Anio") = lblAno.Text
        nFila.Item("Mes") = lblmes.Text
        nFila.Item("Dia") = lbldia.Text
        nFila.Item("Secuencia") = secuencia
        nFila.Item("Indice_de_busqueda") = ""
        nFila.Item("Indice_de_busqueda_Campos") = ""
        nFila.Item("Llave_expediente") = Codigo_expediente
        nFila.Item("Subfolio_documento") = 0
        nFila.Item("Terminado") = 0
        nFila.Item("idStatus") = 0
        nFila.Item("idFolioPID") = InstanciaPadre
        nFila.Item("InstanciaPID") = idInstanciaPID
        nFila.Item("Tipo_operacion") = "110"

        rsDocumentos.Tables(0).Rows.Add(nFila)
        idFolio = svr.SQLInsert_Campos_Atributos(rsDocumentos, "CorteInstancia")

    End Sub
    Protected Sub dsExpediente_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsExpediente.Selecting
        e.InputParameters("idArchivo") = ConfigurationManager.AppSettings("Archivo")
    End Sub
    Protected Sub btnaceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnaceptar.Click
        If GuardaDatos() Then
            'DocumentosSel = ""
            'ObtenDocumentosSel(TreeView1.Nodes(0))
            'If Request.QueryString("confidencial") = "0" Then
            '    EnviaMail(eventoOK, 1, tTicket.NoIdentidad, tTicket.NombreCompleto)
            'Else
            '    EnviaMail(eventoOK, 2, tTicket.NoIdentidad, tTicket.NombreCompleto)
            'End If

            Response.Redirect("Wfrm_TE_Aviso.aspx?Aviso=" & Server.UrlEncode("Se ha generado la solicitud de envio de documentos"))
        End If
    End Sub
    Private Function GuardaDatos() As Boolean
        Dim srv As New SAEX.ServiciosSAEX
        Dim Folio_envio As Integer
        GuardaDatos = False
        Try
            Validate()
            If IsValid Then
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If tTicket Is Nothing Then
                    LogOff()
                End If
                Dim Fecha As Date
                Fecha = Date.Now
                Folio_envio = srv.Control_Maestro(1, 1)

                For Each nNodo As TreeListNode In ASPxTreeList1.GetSelectedNodes()
                    srv.AB_SolicitudEnvio(0, Folio_envio, 1, tTicket.NoIdentidad, nNodo.Key, Fecha)
                Next
                GuardaDatos = True
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Function
    'Private Sub GuardaDocumentos_Hijos(ByVal Nodo As String, ByVal folio_envio As Integer, ByVal InstanciaPID As Integer, ByVal fecha As DateTime)

    '    'Dim intI As Integer
    '    Dim svr As New SAEX.ServiciosSAEX
    '    svr.AB_SolicitudEnvio(0, folio_envio, 1, tTicket.NoIdentidad, Nodo, fecha)
    '    'Dim rsDocumentos As DataSet
    '    'Dim nFila As DataRow
    '    'Dim nInstancia As New SAEX.clsInstancia
    '    'Dim idInstancia As Integer
    '    'Dim iRespuesta As SAEX.Respuesta
    '    'If Nodo.Nodes.Count > 0 Then
    '    '    For intI = 0 To Nodo.Nodes.Count - 1
    '    '        If Nodo.Nodes.Item(intI).CheckBox = True Then
    '    '            If Nodo.Nodes.Item(intI).Checked Then
    '    '                svr.AB_SolicitudEnvio(0, folio_envio, 1, tTicket.NoIdentidad, Nodo.Nodes.Item(intI).NodeData, fecha)
    '    '            End If
    '    '        End If
    '    '        GuardaDocumentos_Hijos(Nodo.Nodes(intI), folio_envio, Nodo.Nodes.Item(intI).NodeData, fecha)
    '    '    Next
    '    'End If
    'End Sub
End Class