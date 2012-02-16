Imports Portalv9.SvrUsr
Partial Public Class Wfrm_Oficina_monitoreofolios
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket
    Private Const estadoenvio As Integer = 2
    Private Const estadorecoleccion As Integer = 82
    Private Const estadoconsulta As Integer = 54
    Private idArea As Integer
    Private idEntidad As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
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
                CargaElementos()
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub
    Private Function CargaElementos() As Integer
        Dim svr As Core = New Core
        Dim sv As New SAEX.ServiciosSAEX
        Dim dsGrupo As DataSet
        Dim rsEntidadArea As DataSet
        Dim rRespuesta As Respuesta
        ' Se comentariza porque tiene que ver con la seguridad que existia antes
        'Try

        '    rsEntidadArea = sv.BuscaEntidad_Area(tTicket.NoIdentidad)
        '    dsGrupo = svr.ColGrupoAdmin(tTicket, tTicket.GrupoAdminID, rRespuesta)
        '    idArea = rsEntidadArea.Tables(0).Rows(0).Item("idAreaAdmin")
        '    idEntidad = rsEntidadArea.Tables(0).Rows(0).Item("idEntidad")
        '    If dsGrupo Is Nothing Then
        '        ObjectDataSource1.OldValuesParameterFormatString = "{0}"
        '        ObjectDataSource1.TypeName = "Portalv9.SAEX.ServiciosSAEX"
        '        ObjectDataSource1.SelectMethod = "BuscaInstanciaXEstadoXArea"
        '        ObjectDataSource1.SelectParameters.Add("pintEstadoID", estadoenvio)
        '        ObjectDataSource1.SelectParameters.Add("idArea", idArea)
        '    Else
        '        Select Case dsGrupo.Tables(0).Rows(0).Item("Permiso_Busqueda")
        '            Case "2"
        '                ObjectDataSource1.OldValuesParameterFormatString = "{0}"
        '                ObjectDataSource1.TypeName = "Portalv9.SAEX.ServiciosSAEX"
        '                ObjectDataSource1.SelectMethod = "BuscaInstanciaXEstado"
        '                ObjectDataSource1.SelectParameters.Add("pintEstadoID", estadoenvio)
        '            Case "1"
        '                ObjectDataSource1.OldValuesParameterFormatString = "{0}"
        '                ObjectDataSource1.TypeName = "Portalv9.SAEX.ServiciosSAEX"
        '                ObjectDataSource1.SelectMethod = "BuscaInstanciaXEstadoXEntidad"
        '                ObjectDataSource1.SelectParameters.Add("pintEstadoID", estadoenvio)
        '                ObjectDataSource1.SelectParameters.Add("idEntidad", idEntidad)
        '            Case "0"
        '                ObjectDataSource1.OldValuesParameterFormatString = "{0}"
        '                ObjectDataSource1.TypeName = "Portalv9.SAEX.ServiciosSAEX"
        '                ObjectDataSource1.SelectMethod = "BuscaInstanciaXEstadoXArea"
        '                ObjectDataSource1.SelectParameters.Add("pintEstadoID", estadoenvio)
        '                ObjectDataSource1.SelectParameters.Add("idArea", rsEntidadArea.Tables(0).Rows(0).Item("idAreaAdmin"))
        '        End Select
        '    End If
        '    sv = Nothing
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Function
    Protected Sub ObjectDataSource2_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource2.Selecting
        e.InputParameters("pintEstadoID") = estadoconsulta
    End Sub
    Protected Sub ObjectDataSource3_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource3.Selecting
        e.InputParameters("pintEstadoID") = estadorecoleccion
    End Sub
End Class