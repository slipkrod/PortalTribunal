Imports Portalv9.SvrUsr
Imports System.IO

Partial Public Class Wfrm_Traspasos_RptAutorizacion
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Private tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle2.Text = Request.QueryString("sTitulo")
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            CargaArchivo()
        End If
    End Sub

#Region "Comunes"

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

    Private Sub CargaGrid(ByRef ptTicket As IDTicket)
        If Session("idDescriptionRPTArray") Is Nothing Or Request.QueryString("idArchivo") Is Nothing Or Request.QueryString("Tipo") Is Nothing Then
            Response.Redirect("Wfrm_ValorizacionArchivos.aspx?Tipo=" + Request.QueryString("Tipo").ToString)
            Return
        End If
        'Dim sv As Core = New Core
        'Dim ds As DataSet = sv.RptAdminPerfilPermisos(ptTicket, prRespuesta, Me.ddlPerfiles.SelectedValue)
        Dim sv As Portalv9.WSArchivo.Service1 = New WSArchivo.Service1
        grdReporte.DataSource = sv.BuscaExpediente(" " & _
                "Select Archivo_Descripciones_Archivisticas.idArchivo, Archivo_Descripcion, idDescripcion, " & _
                "     [idFrecuencia_guardaActivo], [Periodo_guardaActivo], [idFrecuencia_guardaInactivo], [Periodo_guardaInactivo] " & _
                "     ,Fecha_Alta,Case idFrecuencia_guardaActivo  " & _
                "	     When 1 Then DATEDIFF (DAY , Fecha_Alta , GETDATE()) " & _
                "	     When 2 Then DATEDIFF (WEEK , Fecha_Alta , GETDATE()) " & _
                "	     When 3 Then DATEDIFF (MONTH , Fecha_Alta , GETDATE()) " & _
                "	     When 4 Then DATEDIFF (YEAR , Fecha_Alta , GETDATE()) " & _
                "      End As TiempoTranscurrido, " & _
                "      Archivo_Descripciones_Archivisticas.idNivel, (Select Serie_nombre From Series_modelo where Series_modelo.idSerie = Archivo_Descripciones_Archivisticas.idSerie) As Serie_Nombre,  " & _
                "      Descripcion, Nivel, Nivel_Descripcion, Nivel_Logico_Fisico, idSerie, Imagen_open, Imagen_Close, " & _
                "      Case Periodo_guardaActivo When 0 Then '' When 1 Then '1 ' + Case idFrecuencia_guardaActivo When 1 Then 'Día'  " & _
                "        When 2 Then 'Semana' When 3 Then 'Mes' When 4 Then 'Año' Else '' End Else Cast(Periodo_guardaActivo as nvarchar(6)) + Case idFrecuencia_guardaActivo When 1 Then ' Días' When 2 Then ' Semanas' When 3 Then ' Meses' When 4 Then ' Años' Else '' End End as PeriodoGuardaActivo, " & _
                "      (Case Periodo_guardaInActivo When 0 Then '' When 1 Then '1 ' + Case idFrecuencia_guardaInActivo When 1 Then 'Día' " & _
                "       When 2 Then 'Semana' When 3 Then 'Mes' When 4 Then 'Año' Else '' End Else  " & _
                "       Cast(Periodo_guardaInActivo as nvarchar(6)) + Case idFrecuencia_guardaInActivo When 1 Then ' Días' When 2 Then ' Semanas' When 3 Then ' Meses' When 4 Then ' Años' Else '' End End) as PeriodoGuardaInActivo " & _
                "    From Archivo_Descripciones_Archivisticas, archivos, niveles " & _
                "    Where (Archivo_Descripciones_Archivisticas.idArchivo = archivos.idArchivo And " & _
                "      Archivo_Descripciones_Archivisticas.idNivel = niveles.idNivel) And " & _
                "      idDescripcion In ( " & Session("idDescriptionRPTArray") & " ) " & _
                "      And Archivo_Descripciones_Archivisticas.idArchivo = " + Request.QueryString("idArchivo").ToString())
        grdReporte.DataBind()
        'Dim MiDs As New DataSet
        'Dim MiDt As DataTable = New DataTable("Reporte")
        'If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then

        '    If ds.Tables(0).Rows.Count > 0 Then

        '        '**********************
        '        'CREAR LA TABLA TEMPORAL
        '        '**********************

        '        Dim MiDc As DataColumn
        '        MiDc = New DataColumn()
        '        MiDc.DataType = System.Type.GetType("System.String")
        '        MiDc.ColumnName = "Nivel_Descripcion"
        '        MiDt.Columns.Add(MiDc)
        '        MiDc = Nothing
        '        MiDc = New DataColumn()
        '        MiDc.DataType = System.Type.GetType("System.String")
        '        MiDc.ColumnName = "Nivel_Descripcion"
        '        MiDt.Columns.Add(MiDc)
        '        MiDc = Nothing
        '        MiDc = New DataColumn()
        '        MiDc.DataType = System.Type.GetType("System.String")
        '        MiDc.ColumnName = "Tipo"
        '        MiDt.Columns.Add(MiDc)
        '        MiDc = Nothing
        '        MiDc = New DataColumn()
        '        MiDc.DataType = System.Type.GetType("System.String")
        '        MiDc.ColumnName = "Borrar"
        '        MiDt.Columns.Add(MiDc)
        '        MiDc = Nothing

        '        '**********************
        '        'CREAR DATOS DEL REPORTE
        '        '**********************
        '        Dim i As Integer
        '        Dim strPerfilAct As String
        '        Dim strPerfilAnt As String
        '        Dim MiDr As DataRow
        '        strPerfilAnt = ""
        '        For i = 0 To ds.Tables(0).Rows.Count - 1
        '            strPerfilAct = ds.Tables(0).Rows(i).Item("NomPerfilID")
        '            If strPerfilAct <> strPerfilAnt Then
        '                MiDr = MiDt.NewRow()
        '                MiDr("NomPerfilID") = ds.Tables(0).Rows(i).Item("NomPerfilID")
        '                MiDr("Permiso") = ""
        '                MiDr("Mantener") = ""
        '                MiDr("Borrar") = ""
        '                MiDt.Rows.Add(MiDr)
        '            End If

        '            MiDr = MiDt.NewRow()
        '            MiDr("NomPerfilID") = ""
        '            MiDr("Permiso") = ds.Tables(0).Rows(i).Item("Permiso")
        '            MiDr("Mantener") = "[ ] MANTENER"
        '            MiDr("Borrar") = "[ ] BORRAR"
        '            MiDt.Rows.Add(MiDr)
        '            strPerfilAnt = ds.Tables(0).Rows(i).Item("NomPerfilID")
        '        Next
        '    End If
        'End If

        'MiDs.Tables.Add(MiDt)
        'MiDt = Nothing

        'grdReporte.DataSource = MiDs.Tables("Reporte")
        'grdReporte.DataBind()

        'MiDs.Dispose()
        'MiDs = Nothing
        'ds.Dispose()
        'ds = Nothing
        sv = Nothing

    End Sub

    Private Sub grdReporte_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdReporte.PageIndexChanged
        Try
            grdReporte.CurrentPageIndex = e.NewPageIndex
            BindUser()
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try

    End Sub

    Private Sub BindUser()
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            CargaGrid(tTicket)
        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        Finally
            tTicket = Nothing
        End Try
    End Sub


    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExportar.Click
        Dim sb As New StringBuilder()
        Dim sw As New StringWriter(sb)
        Dim htw As New HtmlTextWriter(sw)

        Dim page As New Page()
        Dim form As New HtmlForm()
        Dim lblFooter As New Label()

        'Me.ImageButton1.ImageUrl = "http://" & System.Net.Dns.GetHostName() & "/intranetbanamex160/Images/logoafore2a.gif"

        htw.Write("<b>" & Me.lblTitle2.Text & "</b>")

        Me.grdReporte.AllowPaging = False
        BindUser()
        Me.grdReporte.EnableViewState = False

        'lblFooter.Text = "<table style='width:70%;'>" & _
        '"<tr><td>&nbsp;</td><td>&nbsp;</td></tr>" & _
        '"<tr><td>Folios en proceso de recorte:</td><td align='right'>" & lblTotRecorte.Text & "</td></tr>" & _
        '"<tr><td>Folios por Mesa de Control:</td><td align='right'>" & lblTotMc.Text & "</asp:Label></td></tr>" & _
        '"<tr><td>Total:</td><td align='right'>" & lblTotal.Text & "</td></tr>" & _
        '"</table>"


        form.Controls.Add(Me.Panel2)
        form.Controls.Add(Me.Panel3)
        form.Controls.Add(lblFooter)
        page.EnableEventValidation = False
        page.DesignerInitialize()
        page.Controls.Add(form)
        page.RenderControl(htw)

        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=RepPermisosPerfil.xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString())
        Response.End()
        Me.grdReporte.AllowPaging = True
        'Me.ImageButton1.ImageUrl = "~/Images/logoafore2a.gif"
    End Sub

    Protected Sub btnExportar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExportar2.Click
        Dim sb As New StringBuilder()
        Dim sw As New StringWriter(sb)
        Dim htw As New HtmlTextWriter(sw)

        Dim page As New Page()
        Dim form As New HtmlForm()
        Dim lblFooter As New Label()

        'Me.ImageButton1.ImageUrl = "http://" & System.Net.Dns.GetHostName() & "/intranetbanamex160/Images/logoafore2a.gif"

        htw.Write("<b>" & Me.lblTitle2.Text & "</b>")

        Me.grdReporte.AllowPaging = False
        BindUser()
        Me.grdReporte.EnableViewState = False

        'lblFooter.Text = "<table style='width:70%;'>" & _
        '"<tr><td>&nbsp;</td><td>&nbsp;</td></tr>" & _
        '"<tr><td>Folios en proceso de recorte:</td><td align='right'>" & lblTotRecorte.Text & "</td></tr>" & _
        '"<tr><td>Folios por Mesa de Control:</td><td align='right'>" & lblTotMc.Text & "</asp:Label></td></tr>" & _
        '"<tr><td>Total:</td><td align='right'>" & lblTotal.Text & "</td></tr>" & _
        '"</table>"


        form.Controls.Add(Me.Panel2)
        form.Controls.Add(Me.Panel3)
        form.Controls.Add(lblFooter)
        page.EnableEventValidation = False
        page.DesignerInitialize()
        page.Controls.Add(form)
        page.RenderControl(htw)

        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-word"
        Response.AddHeader("Content-Disposition", "attachment;filename=RepPermisosPerfil.doc")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString())
        Response.End()
        Me.grdReporte.AllowPaging = True
        'Me.ImageButton1.ImageUrl = "~/Images/logoafore2a.gif"
    End Sub

    Protected Sub CargaArchivo()
        Try
            Dim strResult As String
            Try
                strResult = ObtieneResultado()
                If strResult <> String.Empty Then
                    Me.MsgBox1.ShowMessage(strResult)
                End If
                Me.Panel2.Visible = True
                Me.Panel3.Visible = True
                Me.btnExportar.Visible = True
                Me.btnExportar2.Visible = True
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                CargaGrid(tTicket)
                Me.lblFecha.Text = Date.Today
            Catch ex As Exception
                Me.MsgBox1.ShowMessage(ex.Message)
            Finally
                tTicket = Nothing
            End Try

        Catch ex As Exception
            Me.MsgBox1.ShowMessage(ex.Message)
        End Try
    End Sub

End Class