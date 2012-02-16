Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxGridView
Imports System.Collections.Generic
Imports System.Linq

Partial Public Class Wfrm_RE_SolicitudExp
    Inherits System.Web.UI.Page

#Region "Variables Globales"

    Private Const estado As Integer = 80
    Private Const estadoPrestamo As Integer = 56
    Private Const eventoPrestamo As Integer = 80
    Private Const Flujo As Integer = 1
    Private tTicket As IDTicket
    Private DocumentosOK As Integer

#End Region

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
                lblNoIdentidad.Text = tTicket.NoIdentidad
                lblEstadoID.Text = estadoPrestamo

                ASPxTreeList1.DataBind()

                ASPxTreeList1.ExpandAll()
            Catch ex As Exception
                dlgBoxExcepciones.ShowMessage(ex.Message)
            End Try
        Else
            ASPxTreeList1.DataBind()
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub ObjectDataSource2_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource2.Selecting
        e.InputParameters("idUsuario_Prestamo") = lblNoIdentidad.Text
        e.InputParameters("estadoID") = estadoPrestamo
    End Sub

    Protected Sub ASPxGridView1_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ASPxGridView1.RowCommand
        If e.CommandArgs.CommandName = "Seleccionar" Then
            lblLLaveExpediente.Text = ASPxGridView1.GetDataRow(e.VisibleIndex).Item("Llave_expediente")
            If ASPxGridView1.GetDataRow(e.VisibleIndex).Item("Confidencial") <> Request.QueryString("Confidencial") Then
                dlgBoxExcepciones.ShowMessage("Ese expediente se debe recolectar como confidencial.")
            Else
                lblInstanciaPID.Text = ASPxGridView1.GetDataRow(e.VisibleIndex).Item("InstanciaId")
                lblLLaveExpediente.Text = ASPxGridView1.GetDataRow(e.VisibleIndex).Item("Llave_expediente")
                ASPxTreeList1.DataBind()
                ASPxTreeList1.ExpandAll()
                btnAceptar.Visible = True
            End If
        End If
    End Sub

    Protected Function GetNodeGlyph(ByVal container As TreeListDataCellTemplateContainer) As String
        Return "~/" & ASPxTreeList1.FindNodeByKeyValue(container.NodeKey).GetValue("Imagen_close")
    End Function


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

    Protected Sub dsdocumentos_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsdocumentos.Selecting
        If lblInstanciaPID.Text <> "0" Then
            e.InputParameters("idArchivo") = 16
            e.InputParameters("InstanciaPID") = lblInstanciaPID.Text
            e.InputParameters("Llave_expediente") = lblLLaveExpediente.Text
            e.InputParameters("idUsuario_Prestamo") = lblNoIdentidad.Text
            e.InputParameters("estadoID") = lblEstadoID.Text
        End If
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAceptar.Click
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsEntidadArea As DataSet
        Try
            If CType(lblDocumentos.Text, Integer) = ASPxTreeList1.GetSelectedNodes.Count Then
                Validate()
                If IsValid Then
                    tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                    If tTicket Is Nothing Then
                        LogOff()
                    End If
                    'rsEntidadArea = svr.BuscaEntidad_Area(tTicket.NoIdentidad)
                    GuardaDocumentos_Arbol(lblInstanciaPID.Text)
                    Response.Redirect("Wfrm_TE_Aviso.aspx?Aviso=" & Server.UrlEncode("El expediente con código de expediente " & lblLLaveExpediente.Text & " ha sido registrado exitosamente."))
                End If
            Else
                dlgBoxExcepciones.ShowMessage("Para poder solicitar la recolecci{on del expediente es necesario que todos los documentos esten seleccionados")
            End If
        Catch ex As Exception
            dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub GuardaDocumentos_Hijos(ByVal Fecha As DateTime)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsDocumentos As DataSet
        Dim nFila As DataRow

        Dim iterator As TreeListNodeIterator = New TreeListNodeIterator(ASPxTreeList1.RootNode)
        Do While Not iterator.Current Is Nothing
            If iterator.Current.GetValue("Nivel") = 9 Then
                rsDocumentos = svr.Obten_Atributos(eventoPrestamo, "CorteInstancia")
                nFila = rsDocumentos.Tables(0).NewRow

                nFila.Item("idUsuario_Solicita") = tTicket.NoIdentidad
                'nFila.Item("idEntidad") = idEntidad
                'nFila.Item("idArea") = idArea
                nFila.Item("Fecha_solicitud") = Fecha
                nFila.Item("Folio_bolsa") = "" 'System.DBNull.Value 'Request.QueryString("FolioBolsa")
                nFila.Item("Status_Bolsa") = 0
                nFila.Item("Terminado") = 0
                nFila.Item("idStatus") = 0
                nFila.Item("Observaciones") = ""
                nFila.Item("Variacion") = ""
                nFila.Item("tipo_operacion") = "310"

                rsDocumentos.Tables(0).Rows.Add(nFila)
                svr.SQLUpdate_Campos_Atributos(rsDocumentos, "corteInstancia", iterator.Current.GetValue("InstanciaID"))

            End If
            iterator.GetNext()
        Loop
    End Sub

    Private Sub GuardaDocumentos_Arbol(ByVal InstanciaId As Integer)
        Dim svr As New SAEX.ServiciosSAEX
        Dim rsDocumentos As DataSet
        Dim nFila As DataRow
        Dim Fecha As DateTime

        rsDocumentos = svr.Obten_Atributos(eventoPrestamo, "CorteInstancia")

        Fecha = Now
        nFila = rsDocumentos.Tables(0).NewRow

        nFila.Item("idUsuario_Solicita") = tTicket.NoIdentidad
        'nFila.Item("idEntidad") = idEntidad
        'nFila.Item("idArea") = idArea
        nFila.Item("Fecha_solicitud") = Fecha
        nFila.Item("Folio_bolsa") = "" 'System.DBNull.Value 'Request.QueryString("FolioBolsa")
        nFila.Item("Status_Bolsa") = 0
        nFila.Item("Terminado") = 0
        nFila.Item("idStatus") = 0
        nFila.Item("Observaciones") = ""
        nFila.Item("Variacion") = ""
        nFila.Item("tipo_operacion") = "310"

        rsDocumentos.Tables(0).Rows.Add(nFila)
        svr.SQLUpdate_Campos_Atributos(rsDocumentos, "corteInstancia", InstanciaId)

        GuardaDocumentos_Hijos(Fecha)
    End Sub


End Class