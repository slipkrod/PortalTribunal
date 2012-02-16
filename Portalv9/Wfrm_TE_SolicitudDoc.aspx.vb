Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxEditors
Partial Public Class Wfrm_TE_SolicitudDoc
    Inherits System.Web.UI.Page
    Private Const estado As Integer = 1
    Private Const eventoOK As Integer = 2
    Private Const Flujo As Integer = 1
    Private tTicket As IDTicket

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim svr As New SAEX.ServiciosSAEX
        Dim dsTE As DataSet
        If Not IsPostBack Then
            Try
                'CheckBox Read Only no Enable = false
                'chkConfidencial.Attributes.Add("onclick", "return false;")
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    LogOff()
                    Exit Sub
                End If
                Dim strRes As String = Session("DebeCambiarPwd")
                If strRes <> String.Empty Then
                    If CType(strRes, Boolean) = True Then
                        Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                    End If
                End If

                If Request.QueryString("confidencial") = "0" Then
                    lbltitle.Text = "Envío->Usuario/Solicitud de envío de documentos"
                    Label2.Text = ""

                Else
                    lbltitle.Text = "Envío->Usuario/Solicitud de envío de documentos confidenciales"
                    Label2.Text = " = Expediente Confidencial ="
                End If

            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        Else
            mostrar()
           
        End If

    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    
    Private Sub mostrar()
        gdSeries.Visible = True
        lblindices.Visible = True
        lblanio.Visible = True
        lblmes.Visible = True
        lbldia.Visible = True
        txtanio.Visible = True
        dlMes.Visible = True
        dlDia.Visible = True
        ImageButton1.Visible = True

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If FechaValida() Then
            Try
                ObjectDataSource2.SelectParameters.Clear()
                LLenaGrid()
                ocultar()
                ImageButton3.Visible = True
            Catch ex As Exception
                lblerror.Text = ex.Message
            End Try
            
        End If
    End Sub
    Private Sub ocultar()
        lblindices.Visible = False
        gdSeries.Visible = False
        lblanio.Visible = False
        lbldia.Visible = False
        lblmes.Visible = False
        txtanio.Visible = False
        dlDia.Visible = False
        dlMes.Visible = False
        ImageButton1.Visible = False

    End Sub
    Private Sub LLenaGrid()
        Dim svr As New Portalv9.WSArchivo.Service1
        Try
            Dim ds As New DataSet
            ObjectDataSource2.OldValuesParameterFormatString = "{0}"
            ObjectDataSource2.TypeName = "Portalv9.WSArchivo.Service1"
            ObjectDataSource2.SelectMethod = "BuscaExpediente"
            ObjectDataSource2.SelectParameters.Add("SQLString", CreaQuery)
            ASPxGridView1.Visible = True
            svr = Nothing
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try

    End Sub
    Private Function CreaQuery() As String
        Dim svr As New SAEX.ServiciosSAEX
        Dim srtSQL As String
        Dim intI, Contador As Integer
        Dim nCampo As String
        Dim nCampos As String

        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If tTicket Is Nothing Then
            LogOff()
        End If

        'srtSQL = "select Folio_bolsa, idFolio, corteinstancia.InstanciaId,  idDocumento, TipoExpediente, dbo.fn_IndiceBusqueda(corteinstancia.InstanciaId, idFolio) as Indice_de_busqueda, Indice_de_busqueda_campos, Llave_expediente,  " & _
        '         "CorteInstancia.idUsuario_Solicita, ISNULL(Solicita.Nombre, '') + ' ' + ISNULL(Solicita.ApellidoP, '') + ' ' + ISNULL(Solicita.ApellidoM, '') AS Usuario_Solicita, " & _
        '          "CorteInstancia.Fecha_solicitud, CorteInstancia.idEntidad, Entidad.clave_entidad, Entidad.Entidad, CorteInstancia.idArea, Area.clave_entidad AS clave_Area, Area.Entidad AS Area, EFA, Anio, mes, dia " & _
        '          "from corteinstancia, tipo_expediente, instancia, Entidad, Entidad as Area, BDHMultiva.dbo.IdentidadUsr as Solicita " & _
        '          "where idFolioPID = 0 and idTipoObjeto = 0 and corteinstancia.idTipoDocumento = tipo_expediente.idTipoDocumento and " & _
        '          "corteinstancia.InstanciaId = instancia.InstanciaId and " & _
        '          "instancia.EstadoID <> 7 and " & _
        '          "CorteInstancia.idEntidad *= Entidad.idEntidad and " & _
        '          "CorteInstancia.idArea *= Area.idEntidad  and " & _
        '          "CorteInstancia.idArea *= Area.idEntidad  and " & _
        '          "CorteInstancia.idUsuario_Solicita = Solicita.NoIdentidad "

        srtSQL = "SELECT DISTINCT Folio_bolsa,Llave_expediente,TrackinMultiva.dbo.fn_IndiceBusqueda(Archivo_indices.IDDescripcion,Archivo_indices.idFolio) as Indice_de_busqueda, InstanciaID, Archivo_indices.IDDescripcion,Archivo_indices.IdElemento as TipoExpediente, ISNULL(Solicita.Nombre, '') + ' ' + " & _
        "ISNULL(Solicita.ApellidoP, '') + ' ' + ISNULL(Solicita.ApellidoM, '') AS Usuario_Solicita, " & _
         "TrackinMultiva.dbo.corteinstancia.Fecha_solicitud, TrackinMultiva.dbo.corteinstancia.idEntidad, 'E' as clave_entidad, " & _
         "Entidad.Descripcion as Entidad, TrackinMultiva.dbo.corteinstancia.idArea, 'A' AS clave_Area, Area.Descripcion AS Area  from Archivotrife.dbo.Archivo_Descripciones_Archivisticas, Archivotrife.dbo.Niveles, " & _
        "Archivo_Indices, TrackinMultiva.dbo.corteinstancia,  BDHPortalv8.dbo.IdentidadUsr as Solicita,   Archivotrife.dbo.Archivo_Descripciones_Archivisticas as Entidad," & _
          "Archivotrife.dbo.Archivo_Descripciones_Archivisticas as Area where Archivo_Descripciones_Archivisticas.idDescripcion= " & _
        "TrackinMultiva.dbo.corteinstancia.idDocumento and Archivo_Descripciones_Archivisticas.idNivel =" & _
         "Niveles.idNivel and Archivo_Descripciones_Archivisticas.idArchivo =  Archivo_Indices.idArchivo and " & _
        "Archivo_Descripciones_Archivisticas.idDescripcion =  Archivo_Indices.idDescripcion and Niveles.Nivel = 5 and" & _
        " TrackinMultiva.dbo.corteinstancia.idEntidad *= Entidad.idDescripcion and " & _
        "TrackinMultiva.dbo.corteinstancia.idArea *= Area.idDescripcion And TrackinMultiva.dbo.CorteInstancia.idUsuario_Solicita = Solicita.NoIdentidad "

        srtSQL = srtSQL & " and Archivo_Descripciones_Archivisticas.idserie= " & cmbTipoExpediente.Value

        If txtanio.Text.Trim <> "" Then
            srtSQL = srtSQL & " and Archivo_Descripciones_Archivisticas.Ano = '" & txtanio.Text.Trim & "'"
        End If
        If dlMes.Value <> "" Then
            srtSQL = srtSQL & " and  Archivo_Descripciones_Archivisticas.Mes = '" & dlMes.Value.Trim & "'"
        End If
        If dlDia.Value <> "" Then
            srtSQL = srtSQL & " and Archivo_Descripciones_Archivisticas.Dia = '" & dlDia.Value.Trim & "'"
        End If


        nCampos = ""
        Contador = 0
        Dim valor, campo As String
        For intI = 0 To gdSeries.VisibleRowCount - 1
            valor = CType(gdSeries.FindRowCellTemplateControl(intI, gdSeries.Columns("Indice_descripcion"), "ASPxTextBox1"), ASPxTextBox).Text
            campo = gdSeries.GetDataRow(intI)(2).ToString
            If valor <> "" Then
                Contador = Contador + 1
                Select Case gdSeries.GetDataRow(intI)(7).ToString

                    Case "0"
                        nCampo = " and ((Archivo_indices.idElemento='" & campo & "' and Convert(varchar(100),VALOR) like '%" & valor & "%')) or "
                    Case "1"
                        If Not Trim(valor) = "" Then
                            nCampo = " and ((Archivo_indices.idElemento='" & campo & "' and Convert(int,VALOR) = " & valor & " )) or "
                        End If
                    Case "2"
                        If Not Trim(valor) = "" Then
                            nCampo = " and ((Archivo_indices.IdElemento='" & campo & "' and Convert(smalldatetime,VALOR) = '" & CDate(valor).Year & Format(CDate(valor).Month, "00") & Format(CDate(valor).Date.Day, "00") & "' )) or "
                        End If
                End Select
                nCampos = nCampos & nCampo
            End If
        Next

        If Not nCampos.Trim = "" Then
            nCampos = nCampos.Substring(0, nCampos.Length - 3) ' & "))" ' Group BY InstanciaId  having Count(*)=" & Contador & ")"
            srtSQL = srtSQL & nCampos
        End If
        CreaQuery = srtSQL
    End Function
    Private Function FechaValida() As Boolean
        If IsNumeric(txtanio.Text) And IsNumeric(dlMes.Value) And IsNumeric(dlDia.Value) Then
            If IsDate(dlDia.Value & "/" & dlMes.Value & "/" & txtanio.Text) Then
                FechaValida = True
            Else
                lblerror.Text = "Error en año mes y dia."
                FechaValida = False
            End If
        Else
            FechaValida = True
        End If
    End Function
    Protected Sub ASPxGridView1_PageIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxGridView1.PageIndexChanged
        LLenaGrid()
    End Sub
    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("Wfrm_TE_SolicitudExp.aspx?confidencial=" & Request.QueryString("confidencial"))
    End Sub
    Protected Sub dsLista_SeriesModelo_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsLista_SeriesModelo.Selecting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        e.InputParameters("identidad") = tTicket.NoIdentidad
    End Sub
End Class