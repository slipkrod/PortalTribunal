Imports Portalv9.SvrUsr

Partial Public Class Wfrm_LogEventos
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Private tTicket As IDTicket
    Private eGrupoAdminID As Integer
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblTitle.Text = "Logs de Eventos"
        If Not Page.IsPostBack Then

            'Introducir aquí el código de usuario para inicializar la página
            CalendarIniHiperLink.NavigateUrl = "javascript:OpenCalendar('" & FechaIni.ClientID & "', false);"
            CalendarFinHiperLink.NavigateUrl = "javascript:OpenCalendar('" & FechaFin.ClientID & "', false);"

            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            GetDataSource()
        End If
    End Sub

#Region "Métodos privados"

    Private Sub GetDataSource()
        Try
            Dim nNoIdentidad As Integer = 0
            'Dim rRespuesta As Respuesta
            Dim strResult As String

            Try
                strResult = ObtieneResultado()
                If strResult <> String.Empty Then
                    Me.dlgBoxExcepciones.ShowMessage(strResult)
                End If
                If Not IsPostBack Then
                    Dim strRes As String = Session("DebeCambiarPwd")
                    If strRes <> String.Empty Then
                        If CType(strRes, Boolean) = True Then
                            Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                            Exit Try
                        End If
                    End If
                    'TODO: Crear Drop de Uusraios
                    CreaDropAndList(DropUsr, "UsrID", "Nombre")
                    'TODO: Crear Drop de Eventos
                    CreaDropAndList(DropEventos, "EventID", "Descripcion")
                    'TODO: Crear List de Permisos
                End If
            Catch ex As Exception
                dlgBoxExcepciones.ShowMessage(ex.Message)
            Finally
                tTicket = Nothing
            End Try

        Catch ex As Exception
            dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub CargaHistoricoAcceso()
        Dim sv As Core = New Core
        Dim dsHistacceso As DataSet
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        Dim rRespuesta As Respuesta = Nothing
        Try
            dsHistacceso = sv.ObtenerHistAccesoUsrxEvento(tTicket, CType(Application("GN_PROYECTO_ID"), Integer), CType(Application("GN_VERSION_APLICACION_ID"), Integer), DropUsr.SelectedValue, CType(DropEventos.SelectedValue, Integer), Format(CDate(FechaIni.Text), "dd/MM/yyyy").ToString, Format(CDate(FechaFin.Text), "dd/MM/yyyy").ToString, rRespuesta)
            Dim dv As DataView
            dv = dsHistacceso.Tables(0).DefaultView
            dv.Sort = htmlHiddenSortExpression.Value
            'If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            grdResultLogs.DataSource = dv
            grdResultLogs.DataBind()
            'End If
        Catch ex As Exception
            dlgBoxExcepciones.ShowMessage(ex.Message)
        Finally
            dsHistacceso = Nothing
            sv = Nothing
            tTicket = Nothing
        End Try
    End Sub

    Private Sub CreaDropAndList(ByVal DropList As Object, ByVal vDataValueField As String, ByVal vDataTextField As String)
        Dim sv As New Core
        Dim dv As DataView
        Dim ds As DataSet = Nothing
        Dim rRespuesta As Respuesta = Nothing
        'Dim dr As DataRow
        Dim fila As DataRow
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            Select Case DropList.ID
                Case "DropUsr"
                    ds = sv.ColUsuarios(tTicket, rRespuesta)
                Case "DropEventos"
                    ds = sv.ColEventos(tTicket, rRespuesta)
            End Select
            'If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            dv = ds.Tables(0).DefaultView
            'Else
            'Throw New Exception(rRespuesta.RespuestaToString)
            'End If
            'agregarle una fila al dv
            dv.AddNew()
            fila = dv.Item(dv.Count - 1).Row
            fila(0) = 0
            fila(1) = "Todos"

            'establecemos el origen de datos de las listas desplegables
            DropList.DataSource = dv
            DropList.DataValueField = vDataValueField
            DropList.DataTextField = vDataTextField
            DropList.DataBind()
            ds.Dispose()
            dv.Dispose()

        Catch exp As Exception
            dlgBoxExcepciones.ShowMessage(exp.Message)
        End Try
        sv = Nothing
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            grdResultLogs.CurrentPageIndex = 0
            CargaHistoricoAcceso()
        Catch ex As Exception
            Me.dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try

    End Sub

#End Region

#Region "Eventos del DataGrid"

    Private Sub grdResultLogs_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdResultLogs.PageIndexChanged
        Try
            grdResultLogs.CurrentPageIndex = e.NewPageIndex
            CargaHistoricoAcceso()
        Catch ex As Exception
            Me.dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub grdResultLogs_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdResultLogs.SortCommand
        Try
            htmlHiddenSortExpression.Value = e.SortExpression
            CargaHistoricoAcceso()
        Catch ex As Exception
            Me.dlgBoxExcepciones.ShowMessage(ex.Message)
        End Try
    End Sub

#End Region

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

    Protected Sub FechaIni_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FechaIni.TextChanged
        If cvStartDate.IsValid Then
            cvStartDate.Visible = False
        End If
    End Sub
End Class