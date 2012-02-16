

Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxGridView

Partial Public Class Wfrm_PoliticasSesion
    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Private dvPSesion As DataView
    Dim mensaje As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aquí el código de usuario para inicializar la página

        If Not Page.IsPostBack Then
            lblTitle.Text = "Politicas de Sesión"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            GetDataSource()
        End If
    End Sub

#Region "Metodos Privados"

    Private Sub GetDataSource()
        Try
            'Introducir aquí el código de usuario para inicializar la página
            Dim strResult As String
            Dim rRespuesta As Respuesta = Nothing
            Dim nPoliticaSesionID As Integer = 0

            Try
                strResult = ObtieneResultado()
                If strResult <> String.Empty Then
                    mensaje = strResult
                End If
                If Not IsPostBack Then
                    Dim strRes As String = Session("DebeCambiarPwd")
                    If strRes <> String.Empty Then
                        If CType(strRes, Boolean) = True Then
                            Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                            Exit Try
                        End If
                    End If
                    nPoliticaSesionID = CargaPoliticasSesion(tTicket, rRespuesta)
                    If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                        mensaje = rRespuesta.RespuestaToString
                    End If
                End If

            Catch ex As Exception
                mensaje = ex.Message
            Finally
                tTicket = Nothing
            End Try
        Catch ex As Exception
            mensaje = ex.Message
        End Try
    End Sub

    Private Function CargaPoliticasSesion(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As Integer
        Dim sv As Core = New Core
        Dim dsPoliticasSesion As DataSet = sv.ColPoliticasSesion(ptTicket, prRespuesta)
        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            grdPSesion.DataSource = dsPoliticasSesion
            grdPSesion.DataBind()
            dsPoliticasSesion.Dispose()
        End If
        dsPoliticasSesion = Nothing
        sv = Nothing
    End Function

 
    Private Sub BindUser()
        Dim rRespuesta As Respuesta = Nothing
        Dim nPoliticaSesionID As Integer = 0
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            nPoliticaSesionID = CargaPoliticasSesion(tTicket, rRespuesta)
            If rRespuesta.RespuestaID <> Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                mensaje = rRespuesta.RespuestaToString
                Exit Sub
            End If
        Catch ex As Exception
            mensaje = ex.Message
        Finally
            tTicket = Nothing
        End Try
    End Sub



    
    'Private Sub VerIndiceFueradeRango()
    '    If grdPSesion.CurrentPageIndex < 0 Or grdPSesion.CurrentPageIndex >= grdPSesion.PageCount Then
    '        grdPSesion.CurrentPageIndex = 0
    '    End If
    'End Sub

   

   
#End Region

#Region "Eventos de Gridview"

    Private Sub grdPSesion_CustomJSProperties(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs) Handles grdPSesion.CustomJSProperties
        e.Properties("cpMessage") = mensaje
    End Sub



    Protected Sub grdPSesion_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPSesion.PageIndexChanged
        Try

            grdPSesion.PageIndex = CType(sender, ASPxGridView).PageIndex
            BindUser()
        Catch ex As Exception
            mensaje = ex.Message
        End Try

    End Sub

    Protected Sub grdPSesion_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grdPSesion.RowDeleting
        Dim aPoliticaSesion As PoliticaSesion
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty
        grdPSesion.CancelEdit()
        e.Cancel = True
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Core
            Dim sDescripcion As String
            sDescripcion = "Eliminación de la Política de Sesión: " & e.Values(1).ToString.Trim
            aPoliticaSesion = New PoliticaSesion
            With aPoliticaSesion
                .PoliticaSesionID = e.Keys(0)
            End With
            sv.ABC_PoliticaSesion(tTicket, aPoliticaSesion, 1, rRespuesta, sDescripcion)
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                CargaPoliticasSesion(tTicket, rRespuesta)
                mensaje = "Se ejecutó correctamente la operación de eliminar solicitada. "
            Else
                mensaje = "El registro no puede eliminarse ya que esta siendo utilizado en otra parte del sistema"
            End If

        Catch ex As Exception
            mensaje = "El registro no puede eliminarse ya que esta siendo utilizado en otra parte del sistema"
        Finally
            sv = Nothing
            aPoliticaSesion = Nothing
            rRespuesta = Nothing
        End Try
    End Sub

    Protected Sub grdPSesion_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grdPSesion.RowInserting
        Dim aPoliticaSesion As PoliticaSesion
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty
        grdPSesion.CancelEdit()
        e.Cancel = True
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Core
            'Valida si que el nombre no este repetido
            Dim blnVal As Boolean = False
            Dim dsVal As New DataSet
            dsVal = sv.BuscaXNombreTabla(tTicket, rRespuesta, "S", e.NewValues(0).ToString)
            If dsVal.Tables(0).Rows.Count > 0 Then
                blnVal = True
            End If
            dsVal = Nothing

            If blnVal Then
                CargaPoliticasSesion(tTicket, rRespuesta)
                mensaje = "El nombre de la Política de Sesión """ & e.NewValues(0).ToString & """ ya existe"

            Else
                aPoliticaSesion = New PoliticaSesion
                Dim sDescripcion As String
                sDescripcion = "Creación de la Política de Sesión: " & e.NewValues(0).ToString.Trim
                Dim descripcion As String = e.NewValues(1)
                Dim DuracionMinutos As Byte = e.NewValues(2)
                Dim IntentosFallidosConsecutivos As Byte = e.NewValues(3)
                Dim IntentosFallidosDia As Integer = e.NewValues(4)
                Dim PermitirMultiSesion As Boolean = e.NewValues(5)
                Dim PeriodoInhabCtaDias As Integer = e.NewValues(6)
                Dim PeriodoBorrarCtaDias As Integer = e.NewValues(7)

                With aPoliticaSesion
                    .Nombre = e.NewValues(0).ToString
                    .Descripcion = IIf(descripcion Is Nothing, " ", descripcion)
                    .DuracionMinutos = IIf(DuracionMinutos = 0, 20, DuracionMinutos)
                    .IntentosFallidosConsecutivos = IIf(IntentosFallidosConsecutivos = 0, 5, IntentosFallidosConsecutivos)
                    .IntentosFallidosDia = IIf(IntentosFallidosDia = 0, 5, IntentosFallidosDia)
                    .PermitirMultiSesion = PermitirMultiSesion
                    .PeriodoInhabCtaDias = IIf(PeriodoInhabCtaDias = 0, 5, PeriodoInhabCtaDias)
                    .PeriodoBorrarCtaDias = IIf(PeriodoBorrarCtaDias = 0, 5, PeriodoBorrarCtaDias)

                End With

                sv.ABC_PoliticaSesion(tTicket, aPoliticaSesion, 0, rRespuesta, sDescripcion)
                If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    CargaPoliticasSesion(tTicket, rRespuesta)
                    mensaje = "Se ejecutó correctamente la operación de agregar solicitada. "

                End If
            End If

        Catch ex As Exception
            mensaje = "El registro no pudo agregarse"
        Finally
            sv = Nothing
            aPoliticaSesion = Nothing
            rRespuesta = Nothing
        End Try
    End Sub

    Protected Sub grdPSesion_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grdPSesion.RowUpdating
        Dim aPoliticaSesion As PoliticaSesion
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty
        grdPSesion.CancelEdit()
        e.Cancel = True
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Core
            aPoliticaSesion = New PoliticaSesion
            Dim sDescripcion As String
            sDescripcion = DescripcionLog(e)
            Dim descripcion As String = e.NewValues(1)
            Dim DuracionMinutos As Byte = e.NewValues(2)
            Dim IntentosFallidosConsecutivos As Byte = e.NewValues(3)
            Dim IntentosFallidosDia As Integer = e.NewValues(4)
            Dim PermitirMultiSesion As Boolean = e.NewValues(5)
            Dim PeriodoInhabCtaDias As Integer = e.NewValues(6)
            Dim PeriodoBorrarCtaDias As Integer = e.NewValues(7)

            With aPoliticaSesion
                .PoliticaSesionID = e.Keys(0)
                .Nombre = e.NewValues(0).ToString
                .Descripcion = IIf(descripcion Is Nothing, " ", descripcion)
                .Nombre = e.NewValues(0).ToString
                .Descripcion = IIf(descripcion Is Nothing, " ", descripcion)
                .DuracionMinutos = IIf(DuracionMinutos = 0, 20, DuracionMinutos)
                .IntentosFallidosConsecutivos = IIf(IntentosFallidosConsecutivos = 0, 5, IntentosFallidosConsecutivos)
                .IntentosFallidosDia = IIf(IntentosFallidosDia = 0, 5, IntentosFallidosDia)
                .PermitirMultiSesion = PermitirMultiSesion
                .PeriodoInhabCtaDias = IIf(PeriodoInhabCtaDias = 0, 5, PeriodoInhabCtaDias)
                .PeriodoBorrarCtaDias = IIf(PeriodoBorrarCtaDias = 0, 5, PeriodoBorrarCtaDias)
            End With

            sv.ABC_PoliticaSesion(tTicket, aPoliticaSesion, 2, rRespuesta, sDescripcion)
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                CargaPoliticasSesion(tTicket, rRespuesta)
                mensaje = "Se ejecutó correctamente la operación de cambio solicitada. "

            End If
        Catch ex As Exception
            mensaje = "El registro no pudo actualizarse"
        Finally
            sv = Nothing
            aPoliticaSesion = Nothing
            rRespuesta = Nothing
        End Try

    End Sub
    Protected Sub grdPSesion_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles grdPSesion.RowValidating
        If e.NewValues("Nombre") = Nothing Then
            e.RowError = "El nombre es requerido."
        End If
    End Sub
#End Region

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

    Private Function DescripcionLog(ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) As String

        DescripcionLog = String.Empty
        Dim DuracionMinutos As Byte = e.NewValues(2)
        Dim IntentosFallidosConsecutivos As Byte = e.NewValues(3)
        Dim IntentosFallidosDia As Integer = e.NewValues(4)
        Dim PermitirMultiSesion As Boolean = e.NewValues(5)
        Dim PeriodoInhabCtaDias As Integer = e.NewValues(6)
        Dim PeriodoBorrarCtaDias As Integer = e.NewValues(7)
        DescripcionLog = "Modificación de la Política de Sesión: " & e.NewValues(0) & " "
        If e.OldValues(0) <> e.NewValues(0) Then
            DescripcionLog = DescripcionLog & "En el Nombre. "
        End If
        If e.OldValues(1) <> e.NewValues(1) Then
            DescripcionLog = DescripcionLog & "En la Desc. "
        End If
        If e.OldValues(2) <> IIf(DuracionMinutos = 0, 20, DuracionMinutos) Then
            DescripcionLog = DescripcionLog & "En Duración. "
        End If
        If e.OldValues(3) <> IIf(IntentosFallidosConsecutivos = 0, 5, IntentosFallidosConsecutivos) Then
            DescripcionLog = DescripcionLog & "En Fallidos Totales. "
        End If
        If e.OldValues(4) <> IIf(IntentosFallidosDia = 0, 5, IntentosFallidosDia) Then
            DescripcionLog = DescripcionLog & "En Fallidos días. "
        End If
        If e.OldValues(5) <> PermitirMultiSesion Then
            DescripcionLog = DescripcionLog & "En Acceso MultiSesión. "
        End If
        If e.OldValues(6) <> IIf(PeriodoInhabCtaDias = 0, 5, PeriodoInhabCtaDias) Then
            DescripcionLog = DescripcionLog & "En Inhab. Días. "
        End If
        If e.OldValues(7) <> IIf(PeriodoBorrarCtaDias = 0, 5, PeriodoBorrarCtaDias) Then
            DescripcionLog = DescripcionLog & "En Borrar Días. "
        End If  



    End Function

#End Region

   




 
   
    
End Class