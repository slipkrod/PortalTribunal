Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxGridView
Imports System.Collections.Generic
Imports System.Linq
Partial Public Class Wfrm_EN_RequerimientoDoc
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket

    Private Const estado As Integer = 1
    Private Const eventoOK As Integer = 2
    Private Const Flujo As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim svr As New SAEX.ServiciosSAEX
        If Not IsPostBack Then
            Try
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
                    Label1.Text = "Busqueda de Expedientes"
                    Label2.Text = ""

                Else
                    Label1.Text = "Busqueda de Expedientes confidenciales"
                    Label2.Text = " = Expediente Confidencial ="
                End If

                ds_Entidades.OldValuesParameterFormatString = "{0}"
                'ds_Entidades.TypeName = "Portalv9.WSArchivo.Service1"
                'ds_Entidades.SelectMethod = "ListaFondoxNivel"
                ds_Entidades.SelectParameters("idArchivo").DefaultValue = ConfigurationManager.AppSettings("Archivo")
                ds_Entidades.SelectParameters("Fondo_ini").DefaultValue = 3
                ds_Entidades.SelectParameters("Fondo_fin").DefaultValue = 3


            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        Else
            '            mostrar()

        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Protected Sub cmbTipoExpediente_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTipoExpediente.SelectedIndexChanged
        mostrar()
    End Sub
    Protected Sub ASPxComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxComboBox1.SelectedIndexChanged
        ds_AreasAdministrativas.OldValuesParameterFormatString = "{0}"
        'ds_AreasAdministrativas.TypeName = "Portalv9.WSArchivo.Service1"
        'ds_AreasAdministrativas.SelectMethod = "ListaFondoxNivelxPadre"
        ds_AreasAdministrativas.SelectParameters("idArchivo").DefaultValue = ConfigurationManager.AppSettings("Archivo")
        ds_AreasAdministrativas.SelectParameters("Fondo_ini").DefaultValue = 4
        ds_AreasAdministrativas.SelectParameters("Fondo_fin").DefaultValue = 4
        ds_AreasAdministrativas.SelectParameters("Padre").DefaultValue = ASPxComboBox1.SelectedItem.Value
        ds_AreasAdministrativas.Select()

        ASPxComboBox2.Visible = True
        ASPxComboBox2.DataBind()
        lblarea.Visible = True
    End Sub
    Protected Sub dsLista_SeriesModelo_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsLista_SeriesModelo.Selecting
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        e.InputParameters("identidad") = tTicket.NoIdentidad
    End Sub

    Private Sub mostrar()
        lblentidad.Visible = True
        lblarea.Visible = True
        ASPxComboBox1.Visible = True
        ASPxComboBox2.Visible = True
        lblindices.Visible = True
        txtindice.Visible = True
        lblanio.Visible = True
        txtanio.Visible = True
        lblmes.Visible = True
        dlMes.Visible = True
        lbldia.Visible = True
        dlDia.Visible = True
        ImageButton1.Visible = True
    End Sub
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If txtindice.Text = "" Then
            lblrequerido.Visible = True
        Else
            lblrequerido.Visible = False
            If FechaValida() Then
                Try
                    ASPxGridView1.PageIndex = 0
                    LLenaGrid()
                    'ocultar()
                Catch ex As Exception
                    lblerror.Text = ex.Message
                End Try

            End If
        End If
    End Sub

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

    Private Sub LLenaGrid()
        Dim svr As New Portalv9.WSArchivo.Service1
        Try
            Dim ds As New DataSet
            ''ObjectDataSource2.OldValuesParameterFormatString = "{0}"
            ''ObjectDataSource2.TypeName = "Portalv9.WSArchivo.Service1"
            ''ObjectDataSource2.SelectMethod = "BuscaExpediente"
            ObjectDataSource2.SelectParameters("SQLString").DefaultValue = CreaQuery()
            'ObjectDataSource2.SelectParameters.Add("SQLString", CreaQuery)
            ASPxGridView1.Visible = True
            svr = Nothing
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Private Function CreaQuery() As String
        Dim svr As New SAEX.ServiciosSAEX
        Dim srtSQL As String
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If tTicket Is Nothing Then
            LogOff()
        End If
        srtSQL = "select Folio_bolsa,Llave_expediente,TrackinMultiva.dbo.fn_IndiceBusqueda(Archivo_indices.IDDescripcion,Archivo_indices.idFolio) as Indice_de_busqueda, Archivo_indices.idfolio, InstanciaID, Archivo_indices.IDDescripcion,Archivo_indices.IdElemento as TipoExpediente, ISNULL(Solicita.Nombre, '') + ' ' + " & _
        "ISNULL(Solicita.ApellidoP, '') + ' ' + ISNULL(Solicita.ApellidoM, '') AS Usuario_Solicita, " & _
         "TrackinMultiva.dbo.corteinstancia.Fecha_solicitud, TrackinMultiva.dbo.corteinstancia.idEntidad, 'E' as clave_entidad, " & _
         "Entidad.Descripcion as Entidad, TrackinMultiva.dbo.corteinstancia.idArea, 'A' AS clave_Area, Area.Descripcion AS Area, Archivo_Indices.idIndice, Indice_descripcion as Indice, valor from Archivotrife.dbo.Archivo_Descripciones_Archivisticas, Archivotrife.dbo.Niveles, " & _
        "Archivo_Indices, TrackinMultiva.dbo.corteinstancia,  BDHPortalv8.dbo.IdentidadUsr as Solicita,   Archivotrife.dbo.Archivo_Descripciones_Archivisticas as Entidad," & _
          "Archivotrife.dbo.Archivo_Descripciones_Archivisticas as Area, elementos_campos where Archivo_Descripciones_Archivisticas.idDescripcion= " & _
        "TrackinMultiva.dbo.corteinstancia.idDocumento and Archivo_Descripciones_Archivisticas.idNivel =" & _
         "Niveles.idNivel and Archivo_Descripciones_Archivisticas.idArchivo =  Archivo_Indices.idArchivo and " & _
        "Archivo_Descripciones_Archivisticas.idDescripcion =  Archivo_Indices.idDescripcion and Niveles.Nivel = 5 and" & _
        " TrackinMultiva.dbo.corteinstancia.idEntidad *= Entidad.idDescripcion and " & _
        "TrackinMultiva.dbo.corteinstancia.idArea *= Area.idDescripcion And TrackinMultiva.dbo.CorteInstancia.idUsuario_Solicita = Solicita.NoIdentidad and" & _
        " Archivo_Indices.idIndice=elementos_campos.idIndice"

        srtSQL = srtSQL & " and Archivo_Descripciones_Archivisticas.idserie= " & cmbTipoExpediente.Value
        If Not ASPxComboBox1.Value Is Nothing Then
            srtSQL = srtSQL & " and TrackinMultiva.dbo.corteinstancia.idEntidad= " & ASPxComboBox1.Value
        Else
            ASPxGridView1.Columns("Entidad").Visible = True
        End If
        If Not ASPxComboBox2.Value Is Nothing Then
            srtSQL = srtSQL & " and TrackinMultiva.dbo.corteinstancia.idArea= " & ASPxComboBox2.Value
        Else
            ASPxGridView1.Columns("Area").Visible = True
        End If
        If txtanio.Text.Trim <> "" Then
            srtSQL = srtSQL & " and Archivo_Descripciones_Archivisticas.Ano = '" & txtanio.Text.Trim & "'"
        End If
        If dlMes.Value <> "" Then
            srtSQL = srtSQL & " and  Archivo_Descripciones_Archivisticas.Mes = '" & dlMes.Value.Trim & "'"
        End If
        If dlDia.Value <> "" Then
            srtSQL = srtSQL & " and Archivo_Descripciones_Archivisticas.Dia = '" & dlDia.Value.Trim & "'"
        End If
        Dim valor As String
        valor = txtindice.Text
        If valor <> "" Then
            srtSQL = srtSQL & " and valor like '%" & valor & "%'"
        End If
        CreaQuery = srtSQL
    End Function

    Protected Sub ASPxGridView1_RowCommand(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ASPxGridView1.RowCommand
        Select Case e.CommandArgs.CommandName
            Case "Solicitar"
                Response.Redirect("Wfrm_EN_RequrimientoDocDet.aspx?IdDescripcion=" & e.KeyValue)
                'If GardaSolicitud(e.KeyValue) Then
                '    If Request.QueryString("confidencial") = "0" Then
                '        EnviaMail(eventoOK, 1, tTicket.NoIdentidad, tTicket.NombreCompleto, e.CommandArgs.CommandArgument)
                '    Else
                '        EnviaMail(eventoOK, 2, tTicket.NoIdentidad, tTicket.NombreCompleto, e.CommandArgs.CommandArgument)
                '    End If
                '    Response.Redirect("Wfrm_TE_Aviso.aspx?Aviso=" & Server.UrlEncode("Se ha generado la solicitud de envio del expediente con código:" & e.CommandArgs.CommandArgument))
                'End If
        End Select
    End Sub

    Private Function GardaSolicitud(ByVal intanciaID As Integer) As Boolean
        Dim svr As New SAEX.ServiciosSAEX
        Dim Folio_envio As Integer
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            Folio_envio = svr.Control_Maestro(1, 1)
            svr.AB_SolicitudEnvio(0, Folio_envio, 0, tTicket.NoIdentidad, intanciaID, Now)
            GardaSolicitud = True
        Catch ex As Exception
            lblError.Text = ex.Message
            GardaSolicitud = False
        End Try

    End Function

    Private Sub EnviaMail(ByVal evento As Integer, ByVal Exp_doc As Integer, ByVal Noidentidad As Integer, ByVal NombreUsuario As String, ByVal ClaveExpediente As String)
        Dim dsMensaje As DataSet
        Dim dsEnviar As DataSet
        Dim dsEmails As DataSet
        Dim svr As New SAEX.ServiciosSAEX
        Dim intI As Integer
        Dim strTo, strFrom, strSubject, mensaje As String
        Dim rsEntidadArea As DataSet

        Try

            strFrom = ConfigurationManager.AppSettings("Cuenta_Email")
            rsEntidadArea = svr.BuscaEntidad_Area(Noidentidad)
            dsMensaje = svr.ObtieneMensajexEvento(evento, Exp_doc)

            If dsMensaje.Tables(0).Rows.Count > 0 Then
                strSubject = dsMensaje.Tables(0).Rows(0).Item("Asunto")

                mensaje = "El usuario " & NombreUsuario & " solicito el requerimineto de envío del expediente " & ClaveExpediente & vbNewLine
                mensaje = mensaje + dsMensaje.Tables(0).Rows(0).Item("Mensaje")

                dsEnviar = svr.ObtieneMensajeEnviarxEvento(evento, Exp_doc)
                If dsEnviar.Tables(0).Rows.Count > 0 Then
                    'strTo = userID.Email
                    strTo = ""
                    dsEmails = svr.BuscaResponsableAA(rsEntidadArea.Tables(0).Rows(0).Item("idAreaAdmin"), evento, Exp_doc)

                    For intI = 0 To dsEmails.Tables(0).Rows.Count - 1
                        strTo = strTo & dsEmails.Tables(0).Rows(intI).Item("email") & ";"
                    Next
                    dsEmails = svr.BuscaEnviar_usuarios(evento, Exp_doc)
                    For intI = 0 To dsEmails.Tables(0).Rows.Count - 1
                        strTo = strTo & dsEmails.Tables(0).Rows(intI).Item("email") & ";"
                    Next
                    If strTo <> "" Then
                        Dim smtp As New System.Net.Mail.SmtpClient
                        smtp.Host = ConfigurationManager.AppSettings("SMTP")
                        smtp.Send(strFrom, strTo, strSubject, mensaje)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

End Class