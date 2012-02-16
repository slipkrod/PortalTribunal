Imports Portalv9.SvrUsr
Imports Portalv9.WSArchivo
Partial Public Class _1
    Inherits System.Web.UI.MasterPage
    Private tTicket As IDTicket

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim objGlobal As New clsGlobal
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
            LogOff()
            Exit Sub
        End If
        Dim strRes As String = Session("DebeCambiarPwd")
        If strRes <> String.Empty Then
            If CType(strRes, Boolean) = True Then
                'Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
            End If
        End If

       

        If Not IsPostBack Then
            Try
                'Valido permisos aplicacion
                Dim dspermisos As New DataSet
                Dim archivo As New WSArchivo.Service1
                dspermisos = archivo.PermisosAccesos(tTicket.NoIdentidad)

                For i As Integer = 0 To dspermisos.Tables(0).Rows.Count - 1
                    If dspermisos.Tables(0).Rows(i).Item("Nombre").ToString = "Envío de Expedientes" Then
                        envio()
                    Else
                        If dspermisos.Tables(0).Rows(i).Item("Nombre").ToString = "Envio de Documentos" Then
                            documentos()
                        Else
                            If dspermisos.Tables(0).Rows(i).Item("Nombre").ToString = "Entrega Folios Mensajeria" Then
                                mensajeria()
                            Else
                                If dspermisos.Tables(0).Rows(i).Item("Nombre").ToString = "Administra cambio de contraseña" Then
                                    pwd()
                                Else
                                    If dspermisos.Tables(0).Rows(i).Item("Nombre").ToString = "Alta de Bolsas" Then
                                        bolsas()
                                    Else
                                        If dspermisos.Tables(0).Rows(i).Item("Nombre").ToString = "Búsqueda de Expedientes" Then
                                            solicita()
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next

            Catch ex As Exception
                'Me.lblError.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub solicita()
        imbsolicita.Visible = True
        lblsolicita.Visible = True
    End Sub
    Private Sub bolsas()
        imbbolsas.Visible = True
        lblbolsas.Visible = True
    End Sub
    Private Sub pwd()
        ibtcpwd.Visible = True
        lblpwd.Visible = True
    End Sub
    Private Sub envio()
        ibtnenviar.Visible = True
        lblenvio.Visible = True
    End Sub
    Private Sub mensajeria()
        ibtnmensajeria.Visible = True
        lblmensajeria.Visible = True
    End Sub
    Private Sub documentos()
        ibtdocumentos.Visible = True
        lbldoc.Visible = True
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Validar el Ticket y los permisos

    End Sub
    Protected Sub imbtsalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbtsalir.Click
        Response.Redirect("Logoff.aspx")
    End Sub
    Protected Sub imbtcpwd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtcpwd.Click
        Response.Redirect("Wfrm_Admin_CambiaPwd.aspx")
    End Sub
    Protected Sub ibtnenviar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnenviar.Click
        Response.Redirect("Wfrm_TE_SolicitudExp.aspx?confidencial=0")
    End Sub
    Protected Sub ibtdocumentos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtdocumentos.Click
        Response.Redirect("Wfrm_TE_SolicitudDoc.aspx?confidencial=0")
    End Sub
    Protected Sub imbbolsas_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbbolsas.Click
        Response.Redirect("Wfrm_TE_Altabolsa.aspx")
    End Sub
    Protected Sub imbsolicita_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbsolicita.Click
        Response.Redirect("Wfrm_TE_BuscaExpediente.aspx?confidencial=0")
    End Sub
    Protected Sub ibtnmensajeria_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnmensajeria.Click
        Response.Redirect("Wfrm_TE_EntregaMensajeroUsu.aspx")
    End Sub
End Class