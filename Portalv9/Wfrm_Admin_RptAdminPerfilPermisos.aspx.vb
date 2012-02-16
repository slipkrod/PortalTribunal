Imports Portalv9.SvrUsr
Imports System.IO


Partial Public Class Wfrm_RptAdminPerfilPermisos
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Private tTicket As IDTicket
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            lblTitle.Text = "Reporte de Permisos por Perfil"
            lblTitle2.Text = "Reporte de Permisos por Perfil"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            'Carga los perfiles
            CreaDropAndList(Me.ddlPerfiles, "PerfilUsuarioID", "Nombre", 0, 1)
            Dim MiItem As New ListItem
            MiItem.Text = "(Todos)"
            MiItem.Value = 0
            Me.ddlPerfiles.Items.Add(MiItem)
            MiItem = Nothing
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

    Private Sub CreaDropAndList(ByVal DropList As Object, ByVal vDataValueField As String, ByVal vDataTextField As String, ByVal aGrupoAdminid As Integer, ByVal Tipop As Integer)
        Dim sv As New Core
        Dim dv As DataView = Nothing
        Dim ds As DataSet = Nothing
        'Dim dsh As DataSet
        Dim rRespuesta As Respuesta = Nothing
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Tipop = 1 Then
                ds = sv.ColPerfilesUsr(tTicket, tTicket.UsrID, rRespuesta)
                If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    dv = ds.Tables(0).DefaultView
                End If
            End If
            'establecemos el origen de datos de las listas desplegables
            DropList.DataSource = dv
            DropList.DataValueField = vDataValueField
            DropList.DataTextField = vDataTextField
            DropList.DataBind()
            ds.Dispose()
            dv.Dispose()
        Catch exp As Exception
            Me.MsgBox1.ShowMessage(exp.Message)
        End Try
        sv = Nothing
    End Sub

    Private Sub CargaGrid(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta)
        Dim sv As Core = New Core
        Dim ds As DataSet = sv.RptAdminPerfilPermisos(ptTicket, prRespuesta, Me.ddlPerfiles.SelectedValue)
        Dim MiDs As New DataSet
        Dim MiDt As DataTable = New DataTable("Reporte")
        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then

            If ds.Tables(0).Rows.Count > 0 Then

                '**********************
                'CREAR LA TABLA TEMPORAL
                '**********************

                Dim MiDc As DataColumn
                'COLUMNA PERFIL
                MiDc = New DataColumn()
                MiDc.DataType = System.Type.GetType("System.String")
                MiDc.ColumnName = "NomPerfilID"
                MiDt.Columns.Add(MiDc)
                MiDc = Nothing
                'COLUMNA PERMISO
                MiDc = New DataColumn()
                MiDc.DataType = System.Type.GetType("System.String")
                MiDc.ColumnName = "Permiso"
                MiDt.Columns.Add(MiDc)
                MiDc = Nothing
                'COLUMNA MANTENER
                MiDc = New DataColumn()
                MiDc.DataType = System.Type.GetType("System.String")
                MiDc.ColumnName = "Mantener"
                MiDt.Columns.Add(MiDc)
                MiDc = Nothing
                'COLUMNA BORRAR
                MiDc = New DataColumn()
                MiDc.DataType = System.Type.GetType("System.String")
                MiDc.ColumnName = "Borrar"
                MiDt.Columns.Add(MiDc)
                MiDc = Nothing

                '**********************
                'CREAR DATOS DEL REPORTE
                '**********************
                Dim i As Integer
                Dim strPerfilAct As String
                Dim strPerfilAnt As String
                Dim MiDr As DataRow
                strPerfilAnt = ""
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    strPerfilAct = ds.Tables(0).Rows(i).Item("NomPerfilID")
                    If strPerfilAct <> strPerfilAnt Then
                        MiDr = MiDt.NewRow()
                        MiDr("NomPerfilID") = ds.Tables(0).Rows(i).Item("NomPerfilID")
                        MiDr("Permiso") = ""
                        MiDr("Mantener") = ""
                        MiDr("Borrar") = ""
                        MiDt.Rows.Add(MiDr)
                    End If

                    MiDr = MiDt.NewRow()
                    MiDr("NomPerfilID") = ""
                    MiDr("Permiso") = ds.Tables(0).Rows(i).Item("Permiso")
                    MiDr("Mantener") = "[ ] MANTENER"
                    MiDr("Borrar") = "[ ] BORRAR"
                    MiDt.Rows.Add(MiDr)

                    strPerfilAnt = ds.Tables(0).Rows(i).Item("NomPerfilID")
                Next

            End If

        End If

        MiDs.Tables.Add(MiDt)
        MiDt = Nothing

        grdReporte.DataSource = MiDs.Tables("Reporte")
        grdReporte.DataBind()

        MiDs.Dispose()
        MiDs = Nothing
        ds.Dispose()
        ds = Nothing
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
        Dim rRespuesta As Respuesta = Nothing
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            CargaGrid(tTicket, rRespuesta)
            
            If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                Me.MsgBox1.ShowMessage(rRespuesta.RespuestaToString)
                Exit Sub
            End If
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

        htw.Write("<b>" & Me.lblTitle.Text & "</b>")

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

        htw.Write("<b>" & Me.lblTitle.Text & "</b>")

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

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        Try
            Dim rRespuesta As Respuesta = Nothing
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
                CargaGrid(tTicket, rRespuesta)
                Me.lblFecha.Text = Date.Today
                If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    Me.MsgBox1.ShowMessage(rRespuesta.RespuestaToString)
                End If
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