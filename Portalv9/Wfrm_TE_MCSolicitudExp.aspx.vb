Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxGridView
Imports System.Collections.Generic
Imports System.Linq

Partial Public Class Wfrm_TE_MCSolicitudExp
    Inherits System.Web.UI.Page

    Private nodeKeys As List(Of String)
    Private Diccionario As New Dictionary(Of String, String)
    Private tTicket As IDTicket
    Private Codigo_expediente As String

    Private Clave_Entidad As String
    Private Clave_AreaAdmin As String
    Private Entidad As Integer
    Private AreaAdmin As Integer
    Private Secuencia As String
    Private Fecha_solicitud As Date

    ' Variables del tracking
    Private Const estado As Integer = 21
    Private Const eventoOK As Integer = 27
    Private Const Flujo As Integer = 1
    Private idInstanciaPID As Integer



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

                If Request.QueryString("confidencial") = "0" Then
                    lbltitle.Text = "Envío->Usuario/Solicitud de envío de expedientes"
                    Label2.Text = ""

                Else
                    lbltitle.Text = "Envío->Usuario/Solicitud de envío de expedientes confidenciales"
                    Label2.Text = " = Expediente Confidencial ="
                End If
                ds_Entidades.SelectParameters("idArchivo").DefaultValue = ConfigurationManager.AppSettings("Archivo")
            Catch ex As Exception
                Me.lblError.Text = ex.Message
            End Try
        Else
            mostrar()
        End If
    End Sub
    Private Sub mostrar()
        'gdSeries.Visible = True
        'lblindices.Visible = True
        lblanio.Visible = True
        lblmes.Visible = True
        lbldia.Visible = True
        txtanio.Visible = True
        dlMes.Visible = True
        dlDia.Visible = True
        cmbEntidad.Visible = True
        lblentidad.Visible = True
        cmbAreaAdmin.Visible = True
        lblarea.Visible = True
        ASPxTreeList1.Visible = True
        ASPxButton2.Visible = True
        lbldoc.Visible = True
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        Return "~/" & ASPxTreeList1.FindNodeByKeyValue(container.NodeKey).GetValue("Imagen_close")
    End Function

    Protected Sub dsLista_SeriesModelo_Hijos_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsLista_SeriesModelo_Hijos.Selecting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        e.InputParameters("identidad") = tTicket.NoIdentidad
        If Not IsPostBack Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ASPxTreeList1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxTreeList1.DataBound

        For Each nNodo As TreeListNode In ASPxTreeList1.FindNodesByFieldValue("Nivel", 6)
            nNodo.AllowSelect = False
        Next
    End Sub

    Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalvar.Click
        lblError.Text = ""
        Try
            If ValidaIndicesUnicos() Then
                GuardaExpediente()
                Response.Redirect("Wfrm_TE_Aviso.aspx?Aviso=" & Server.UrlEncode("El expediente con código de expediente " & Codigo_expediente & " ha sido registrado exitosamente."))
            End If

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Private Function ValidaIndicesUnicos() As Boolean
        Dim svr As New WSArchivo.Service1
        Dim valor As String
        Dim rsValores As DataSet
        ValidaIndicesUnicos = False
        For intI = 0 To ASPxGridView1.VisibleRowCount - 1
            If ASPxGridView1.GetRowValues(intI, "Indice_Unico") = 1 Then
                valor = CType(ASPxGridView1.FindRowCellTemplateControl(intI, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).Text
                rsValores = svr.Func_Indice_repetido(cmbEntidad.SelectedItem.GetValue("idArchivo"), ASPxGridView1.GetRowValues(intI, "idIndice"), valor)
                If rsValores.Tables(0).Rows(0).Item("Total") = 0 Then
                    ValidaIndicesUnicos = True
                Else
                    Throw New System.Exception("El índice " & ASPxGridView1.GetRowValues(intI, "Serie_nombre") & " - " & ASPxGridView1.GetRowValues(intI, "Indice_descripcion") & " es único y ya se encuentra el valor " & valor & " en la base de datos.")
                End If
            End If
        Next
        ValidaIndicesUnicos = True

    End Function
    Private Sub GuardaExpediente()
        Dim svr As New WSArchivo.Service1
        Dim dsSerie As DataSet
        Dim dsEntidad As DataSet
        Dim dsIndicesSistema As DataSet
        Dim dsFolioSecuencia As DataSet
        Dim valor As String
        Dim nNodoID As Integer
        Dim SecuenciaHEX As String
        Dim Perido_guardaActivo As Integer
        Dim Perido_guardaInActivo As Integer
        Dim Perido_prestamo As Integer
        Dim Resellos As Integer
        Dim Dias As Integer

        'Buscamos si existe el padre del tipo de expediente

        dsSerie = svr.ListaArchivo_Descripciones_idSerie(cmbEntidad.SelectedItem.GetValue("idArchivo"), cmbTipoExpediente.SelectedItem.GetValue("idNivel"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), cmbAreaAdmin.SelectedItem.GetValue("idDescripcion"))
        If dsSerie.Tables(0).Rows.Count = 0 Then
            nNodoID = svr.ABC_Archivo_Descripciones(WSArchivo.OperacionesABC.operAlta, cmbEntidad.SelectedItem.GetValue("idArchivo"), 0, "", cmbTipoExpediente.SelectedItem.GetValue("idNivel"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "", 0, cmbTipoExpediente.SelectedItem.GetValue("Serie_nombre"), 0, cmbAreaAdmin.SelectedItem.GetValue("idDescripcion"))
        Else
            nNodoID = dsSerie.Tables(0).Rows(0).Item("idDescripcion")
        End If

        dsEntidad = svr.ListaArchivo_indices_PK(cmbEntidad.SelectedItem.GetValue("idArchivo"), cmbEntidad.SelectedItem.GetValue("idDescripcion"), 1)
        Clave_Entidad = dsEntidad.Tables(0).Rows(0).Item("Valor")
        Entidad = cmbEntidad.SelectedItem.GetValue("idDescripcion")

        dsEntidad = svr.ListaArchivo_indices_PK(cmbEntidad.SelectedItem.GetValue("idArchivo"), cmbAreaAdmin.SelectedItem.GetValue("idDescripcion"), 1)
        Clave_AreaAdmin = dsEntidad.Tables(0).Rows(0).Item("Valor")
        AreaAdmin = cmbAreaAdmin.SelectedItem.GetValue("idDescripcion")
        '1.1.1 es el indiice secuencia
        dsFolioSecuencia = svr.Obten_Secuencia(cmbEntidad.SelectedItem.GetValue("idArchivo"), cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.Value, txtAnio.Text, dlMes.SelectedItem.Value, dlDia.SelectedItem.Value, "1.1.1", nNodoID)
        Secuencia = dsFolioSecuencia.Tables(0).Rows(0).Item("Valor")
        SecuenciaHEX = dsFolioSecuencia.Tables(0).Rows(0).Item("ValorHEX")

        Codigo_expediente = Clave_Entidad.PadLeft(1, "0") & Clave_AreaAdmin.PadLeft(2, "00") & cmbTipoExpediente.SelectedItem.GetValue("Clave") & txtAnio.Text & dlMes.SelectedItem.Value & dlDia.SelectedItem.Value & SecuenciaHEX

        'Inicio del expediente 
        'Alta del nuevo expediente Nodo Padre
        nNodoID = svr.ABC_Archivo_Descripciones(WSArchivo.OperacionesABC.operAlta, cmbEntidad.SelectedItem.GetValue("idArchivo"), 0, "", cmbTipoExpediente.SelectedItem.GetValue("idNivel"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "", 0, Codigo_expediente, 0, nNodoID)

        'Alta de los indices del nuevo expediente Nodo Padre (Capturados por el usuario)
        For intI = 0 To ASPxGridView1.VisibleRowCount - 1
            If ASPxGridView1.GetRowValues(intI, "idSerie") = cmbTipoExpediente.SelectedItem.GetValue("idSerie") Then
                valor = CType(ASPxGridView1.FindRowCellTemplateControl(intI, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).Text
                svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, ASPxGridView1.GetRowValues(intI, "idNorma"), ASPxGridView1.GetRowValues(intI, "idArea"), ASPxGridView1.GetRowValues(intI, "idElemento"), ASPxGridView1.GetRowValues(intI, "idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, ASPxGridView1.GetRowValues(intI, "idNivel"), ASPxGridView1.GetRowValues(intI, "idSerie"), 0, valor, ASPxGridView1.GetRowValues(intI, "Indice_Tipo"), 0)
            End If
        Next
        'Alta de los indices del nuevo expediente Nodo Padre (Indices por sistema)
        If IsNumeric(cmbTipoExpediente.SelectedItem.GetValue("Periodo_Prestamo")) And IsNumeric(cmbTipoExpediente.SelectedItem.GetValue("idFrecuencia_prestamo")) Then
            Select Case cmbTipoExpediente.SelectedItem.GetValue("idFrecuencia_prestamo")
                Case 1
                    Dias = 1
                Case 2
                    Dias = 7
                Case 3
                    Dias = 30
                Case 4
                    Dias = 365
            End Select
            Perido_prestamo = cmbTipoExpediente.SelectedItem.GetValue("Periodo_Prestamo") * Dias
        Else
            Perido_prestamo = 0
        End If

        If IsNumeric(cmbTipoExpediente.SelectedItem.GetValue("Periodo_guardaActivo")) And IsNumeric(cmbTipoExpediente.SelectedItem.GetValue("idFrecuencia_guardaActivo")) Then
            Select Case cmbTipoExpediente.SelectedItem.GetValue("idFrecuencia_guardaActivo")
                Case 1
                    Dias = 1
                Case 2
                    Dias = 7
                Case 3
                    Dias = 30
                Case 4
                    Dias = 365
            End Select
            Perido_guardaActivo = cmbTipoExpediente.SelectedItem.GetValue("Periodo_guardaActivo") * Dias
        Else
            Perido_guardaActivo = 0
        End If

        If IsNumeric(cmbTipoExpediente.SelectedItem.GetValue("Num_Resellos")) Then
            Resellos = cmbTipoExpediente.SelectedItem.GetValue("Num_Resellos")
        Else
            Resellos = 0
        End If

        If IsNumeric(cmbTipoExpediente.SelectedItem.GetValue("Periodo_guardaInactivo")) And IsNumeric(cmbTipoExpediente.SelectedItem.GetValue("idFrecuencia_guardaInactivo")) Then
            Select Case cmbTipoExpediente.SelectedItem.GetValue("idFrecuencia_guardaInactivo")
                Case 1
                    Dias = 1
                Case 2
                    Dias = 7
                Case 3
                    Dias = 30
                Case 4
                    Dias = 365
            End Select
            Perido_guardaInActivo = cmbTipoExpediente.SelectedItem.GetValue("Periodo_guardaInactivo") * Dias
        Else
            Perido_guardaInActivo = 0
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.1")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), Secuencia, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.2")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), Codigo_expediente, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.3")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), tTicket.NoIdentidad, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.4")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), tTicket.UsrID, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.5")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), tTicket.NombreCompleto, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.6")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), tTicket.GrupoAdminID, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.7")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), Now.Date, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.8")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), Perido_guardaActivo, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.9")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), Perido_guardaInActivo, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.10")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), Perido_prestamo, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.11")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), Resellos, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.12")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), Entidad, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.13")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), AreaAdmin, dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.14")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), Request.QueryString("Confidencial"), dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.15")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), cmbTipoExpediente.SelectedItem.GetValue("Metodo_Destruccion"), dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.16")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), cmbTipoExpediente.SelectedItem.GetValue("Valor_administrativo"), dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.17")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), cmbTipoExpediente.SelectedItem.GetValue("Valor_legal"), dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If

        dsIndicesSistema = svr.ListaArchivo_indicexFolio_norma(cmbTipoExpediente.SelectedItem.GetValue("idNorma"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"), "1.1.18")
        If dsIndicesSistema.Tables(0).Rows.Count > 0 Then
            svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, dsIndicesSistema.Tables(0).Rows(0).Item("idNorma"), dsIndicesSistema.Tables(0).Rows(0).Item("idArea"), dsIndicesSistema.Tables(0).Rows(0).Item("idElemento"), dsIndicesSistema.Tables(0).Rows(0).Item("idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, dsIndicesSistema.Tables(0).Rows(0).Item("idNivel"), dsIndicesSistema.Tables(0).Rows(0).Item("idSerie"), dsIndicesSistema.Tables(0).Rows(0).Item("relacion_con_normaPID"), cmbTipoExpediente.SelectedItem.GetValue("Valor_contable"), dsIndicesSistema.Tables(0).Rows(0).Item("Indice_Tipo"), 0)
        End If


        Fecha_solicitud = Now
        GuardaExpedienteInstancia(nNodoID, cmbTipoExpediente.SelectedItem.GetValue("idNivel"), cmbTipoExpediente.SelectedItem.GetValue("idSerie"))
        GuardaDocumentos_Hijos(nNodoID)

    End Sub
    Private Sub GuardaDocumentos_Hijos(ByVal NewParentKey As Integer)
        Dim svr As New WSArchivo.Service1
        Dim nNodoID As Integer
        Dim InstanciaPadre As Integer
        Dim valor As String
        Dim list As List(Of TreeListNode) = ASPxTreeList1.GetSelectedNodes()
        For Each nNode As TreeListNode In list
            If nNode.Level = 1 Then
                InstanciaPadre = NewParentKey
            Else
                InstanciaPadre = nNode.ParentNode("idSeriePID")
            End If
            nNodoID = svr.ABC_Archivo_Descripciones(WSArchivo.OperacionesABC.operAlta, cmbEntidad.SelectedItem.GetValue("idArchivo"), 0, "", nNode("idNivel"), nNode("idSerie"), "", 0, nNode("Serie_nombre"), 0, InstanciaPadre)
            nNode("idSeriePID") = nNodoID
            For intI = 0 To ASPxGridView1.VisibleRowCount - 1
                If ASPxGridView1.GetRowValues(intI, "idSerie") = nNode("idSerie") Then
                    valor = CType(ASPxGridView1.FindRowCellTemplateControl(intI, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).Text
                    svr.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, ASPxGridView1.GetRowValues(intI, "idNorma"), ASPxGridView1.GetRowValues(intI, "idArea"), ASPxGridView1.GetRowValues(intI, "idElemento"), ASPxGridView1.GetRowValues(intI, "idIndice"), cmbEntidad.SelectedItem.GetValue("idArchivo"), nNodoID, 0, ASPxGridView1.GetRowValues(intI, "idNivel"), ASPxGridView1.GetRowValues(intI, "idSerie"), 0, valor, ASPxGridView1.GetRowValues(intI, "Indice_Tipo"), 0)
                End If
            Next


            If nNode.HasChildren = False And nNode("Nivel") = 9 Then
                GuardaDocumentos_HijosInstancia(nNodoID, nNode("idNivel"), nNode("idSerie"), InstanciaPadre)
            End If

        Next
    End Sub
    Private Sub GuardaExpedienteInstancia(ByVal idDocumento As Integer, ByVal idTipoElemento As Integer, ByVal idElemento As Integer)
        Dim svr As New SAEX.ServiciosSAEX
        Dim iRespuesta As SAEX.Respuesta
        Dim nInstancia As New SAEX.clsInstancia
        Dim rsDocumentos As DataSet
        Dim nFila As DataRow
        Dim idFolio As Integer


        rsDocumentos = svr.Obten_Atributos(eventoOK, "CorteInstancia")
        idInstanciaPID = svr.ABC_Instancia(tTicket.UsrID, tTicket.GrupoAdminID, nInstancia, Flujo, SAEX.OperacionesABC.operAlta, iRespuesta, estado)

        nFila = rsDocumentos.Tables(0).NewRow
        nFila.Item("InstanciaId") = idInstanciaPID
        nFila.Item("idUsuario_Solicita") = tTicket.NoIdentidad
        nFila.Item("Fecha_solicitud") = Fecha_solicitud
        nFila.Item("idEntidad") = Entidad
        nFila.Item("idArea") = AreaAdmin
        nFila.Item("Status_Bolsa") = 0
        nFila.Item("Folio_bolsa") = System.DBNull.Value 'Request.QueryString("FolioBolsa")
        nFila.Item("idTipoObjeto") = 0 'Expediente
        nFila.Item("idTipoDocumento") = cmbTipoExpediente.SelectedItem.Value
        nFila.Item("idDocumento") = idDocumento
        nFila.Item("idTipoElemento") = idTipoElemento
        nFila.Item("idElemento") = idElemento
        nFila.Item("Confidencial") = Request.QueryString("Confidencial")
        nFila.Item("Anio") = txtAnio.Text
        nFila.Item("Mes") = dlMes.SelectedItem.Value
        nFila.Item("Dia") = dlDia.SelectedItem.Value
        nFila.Item("Secuencia") = Secuencia
        nFila.Item("Indice_de_busqueda") = ""
        nFila.Item("Indice_de_busqueda_Campos") = ""
        nFila.Item("Llave_expediente") = Codigo_expediente
        nFila.Item("Subfolio_documento") = 0
        nFila.Item("Terminado") = 0
        nFila.Item("idStatus") = 0
        nFila.Item("idFolioPID") = 0
        nFila.Item("InstanciaPID") = 0
        nFila.Item("Tipo_operacion") = "110"


        rsDocumentos.Tables(0).Rows.Add(nFila)
        idFolio = svr.SQLInsert_Campos_Atributos(rsDocumentos, "corteInstancia")

        'CreaIndicedeCampos(idInstancia, idFolio, 0)        
    End Sub
    Sub GuardaDocumentos_HijosInstancia(ByVal idDocumento As Integer, ByVal idTipoElemento As Integer, ByVal idElemento As Integer, ByVal InstanciaPadre As Integer)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsDocumentos As DataSet
        Dim nInstancia As New SAEX.clsInstancia
        Dim idInstancia As Integer
        Dim iRespuesta As SAEX.Respuesta
        Dim idFolio As Integer
        Dim nFila As DataRow

        idInstancia = svr.ABC_Instancia(tTicket.UsrID, tTicket.GrupoAdminID, nInstancia, Flujo, SAEX.OperacionesABC.operAlta, iRespuesta, estado)

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
        nFila.Item("idTipoDocumento") = cmbTipoExpediente.SelectedItem.Value
        nFila.Item("idDocumento") = idDocumento
        nFila.Item("idTipoElemento") = idTipoElemento
        nFila.Item("idElemento") = idElemento
        nFila.Item("Confidencial") = Request.QueryString("Confidencial")
        nFila.Item("Anio") = txtAnio.Text
        nFila.Item("Mes") = dlMes.SelectedItem.Value
        nFila.Item("Dia") = dlDia.SelectedItem.Value
        nFila.Item("Secuencia") = Secuencia
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

    Protected Sub ASPxButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxButton2.Click
        Dim idSerie As Integer
        Dim svr As New WSArchivo.Service1
        Dim dsCampos As DataSet
        Dim intJ As Integer
        lblError.Text = ""
        nodeKeys = New List(Of String)()
        If cmbEntidad.Text = "" Then
            lblError.Text = "Debe de seleccionar una Entidad"
        Else
            If ASPxTreeList1.GetSelectedNodes.Count = 0 Then
                lblError.Text = "Debe selección al menos un documento a enviar."
            Else
                Dim dtIndicesDocumentos As New DataTable()
                dtIndicesDocumentos.TableName = "Campos"

                Dim pkCampoID As DataColumn = dtIndicesDocumentos.Columns.Add("idIndice", Type.GetType("System.Int32"))
                dtIndicesDocumentos.Columns.Add("Indice_Tipo", Type.GetType("System.String"))
                dtIndicesDocumentos.Columns.Add("Indice_descripcion", Type.GetType("System.String"))
                dtIndicesDocumentos.Columns.Add("Indice_LongitudMax", Type.GetType("System.Int32"))
                dtIndicesDocumentos.Columns.Add("Indice_Obligatorio", Type.GetType("System.Int32"))
                dtIndicesDocumentos.Columns.Add("Indice_Unico", Type.GetType("System.Int32"))
                dtIndicesDocumentos.Columns.Add("Indice_Mascara", Type.GetType("System.String"))
                dtIndicesDocumentos.Columns.Add("Serie_nombre", Type.GetType("System.String"))
                dtIndicesDocumentos.Columns.Add("idNorma", Type.GetType("System.Int32"))
                dtIndicesDocumentos.Columns.Add("idArea", Type.GetType("System.Int32"))
                dtIndicesDocumentos.Columns.Add("idElemento", Type.GetType("System.Int32"))
                dtIndicesDocumentos.Columns.Add("idNivel", Type.GetType("System.Int32"))
                dtIndicesDocumentos.Columns.Add("idSerie", Type.GetType("System.Int32"))
                dtIndicesDocumentos.PrimaryKey = New DataColumn() {pkCampoID}

                For Each nNodo As TreeListNode In ASPxTreeList1.GetSelectedNodes()
                    idSerie = nNodo.Key
                    dsCampos = svr.ListaSeries_Indices_padres(idSerie)
                    For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1

                        Dim Row As DataRow = dtIndicesDocumentos.Rows.Find(dsCampos.Tables(0).Rows(intJ).Item("idIndice"))
                        If Row Is Nothing Then
                            Dim IndiceRow As DataRow = dtIndicesDocumentos.NewRow()
                            IndiceRow("idIndice") = dsCampos.Tables(0).Rows(intJ).Item("idIndice")
                            IndiceRow("Indice_Tipo") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Tipo")
                            IndiceRow("Indice_descripcion") = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                            IndiceRow("Indice_LongitudMax") = dsCampos.Tables(0).Rows(intJ).Item("Indice_LongitudMax")
                            IndiceRow("Indice_Obligatorio") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Obligatorio")
                            IndiceRow("Indice_Unico") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Unico")
                            IndiceRow("Indice_Mascara") = dsCampos.Tables(0).Rows(intJ).Item("Indice_Mascara")
                            IndiceRow("Serie_nombre") = dsCampos.Tables(0).Rows(intJ).Item("Serie_nombre")
                            IndiceRow("idNorma") = dsCampos.Tables(0).Rows(intJ).Item("idNorma")
                            IndiceRow("idArea") = dsCampos.Tables(0).Rows(intJ).Item("idArea")
                            IndiceRow("idElemento") = dsCampos.Tables(0).Rows(intJ).Item("idElemento")
                            IndiceRow("idNivel") = dsCampos.Tables(0).Rows(intJ).Item("idNivel")
                            IndiceRow("idSerie") = dsCampos.Tables(0).Rows(intJ).Item("idSerie")
                            dtIndicesDocumentos.Rows.Add(IndiceRow)
                        End If
                    Next

                    SelectParentNode(nNodo)
                Next

                ASPxGridView1.DataSource = dtIndicesDocumentos
                ASPxGridView1.KeyFieldName = "idIndice"
                ASPxGridView1.DataBind()
                ASPxGridView1.Visible = True
                btnSalvar.Visible = True
                lblindices.Visible = True
                Bloquear()
            End If
        End If
    End Sub


    Private Sub SelectParentNode(ByVal Node As DevExpress.Web.ASPxTreeList.TreeListNode)
        If (Node.ParentNode IsNot Nothing) Then
            If Diccionario.ContainsKey(Node.Key) Then

            Else
                Diccionario.Add(Node.Key, Node.ParentNode.Key)
            End If
            SelectParentNode(Node.ParentNode)
        End If
    End Sub
    Private Sub Bloquear()
        cmbTipoExpediente.Enabled = False
        cmbEntidad.Enabled = False
        txtAnio.Enabled = False
        dlDia.Enabled = False
        dlMes.Enabled = False
        lbldoc.Visible = False
        Dim NodosSeleccionados = From entry In Diccionario.Keys Order By entry Ascending Select entry

        Dim intI As Integer
        For intI = 0 To NodosSeleccionados.Count - 1
            ASPxTreeList1.FindNodeByKeyValue(NodosSeleccionados(intI)).AllowSelect = True
            ASPxTreeList1.FindNodeByKeyValue(NodosSeleccionados(intI)).Selected = True
        Next
        ASPxTreeList1.ClientVisible = False
        ASPxButton2.Visible = False
    End Sub

    Private Sub ASPxGridView1_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs) Handles ASPxGridView1.HtmlRowPrepared
        If e.RowType = GridViewRowType.Data Then

            Select Case e.GetValue("Indice_Tipo")
                Case 0
                    If e.GetValue("Indice_LongitudMax") <> 0 Then
                        CType(ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).MaxLength = e.GetValue("Indice_LongitudMax")
                    End If
                Case 1
                    CType(ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).ValidationSettings.RegularExpression.ErrorText = "Solo puede ser numérico"
                    CType(ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).ValidationSettings.RegularExpression.ValidationExpression = e.GetValue("Indice_Mascara")
                Case 2
                    CType(ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).ValidationSettings.RegularExpression.ErrorText = "Solo puede se fecha con formato 'aaaa/mm/dd'"
                    CType(ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).ValidationSettings.RegularExpression.ValidationExpression = e.GetValue("Indice_Mascara")
            End Select
            If e.GetValue("Indice_Obligatorio") Then
                CType(ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).ValidationSettings.RequiredField.IsRequired = True
                CType(ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns("Indice_descripcion"), "ASPxTextBox2"), ASPxTextBox).ValidationSettings.RequiredField.ErrorText = "* Campo requerido"
            End If
        End If
    End Sub

    Protected Sub dsLista_SeriesModelo_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsLista_SeriesModelo.Selecting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        e.InputParameters("identidad") = tTicket.NoIdentidad
    End Sub


    Protected Sub cmbEntidad_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbEntidad.SelectedIndexChanged
        ds_AreasAdministrativas.SelectParameters("idArchivo").DefaultValue = ConfigurationManager.AppSettings("Archivo")
        ds_AreasAdministrativas.SelectParameters("Fondo_ini").DefaultValue = 4
        ds_AreasAdministrativas.SelectParameters("Fondo_fin").DefaultValue = 4
        ds_AreasAdministrativas.SelectParameters("Padre").DefaultValue = cmbEntidad.SelectedItem.Value
        ds_AreasAdministrativas.Select()
        cmbAreaAdmin.SelectedIndex = -1
        cmbAreaAdmin.DataBind()
    End Sub
End Class

