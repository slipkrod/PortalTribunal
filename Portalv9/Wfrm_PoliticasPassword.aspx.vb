Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxGridView

Partial Public Class Wfrm_PoliticasPassword

    Inherits System.Web.UI.Page
    Public tTicket As IDTicket
    Private dvPPwd As DataView
    Dim mensaje As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load

        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then

            lblTitle.Text = "Politicas de Contraseña"

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
            Dim nPoliticaPwdID As Integer = 0

            Try

                strResult = ObtieneResultado()
                If strResult <> String.Empty Then
                    mensaje = strResult
                End If

                If Not IsPostBack Then
                    tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                    If tTicket Is Nothing Then
                        LogOff()
                        Exit Try
                    End If
                    Dim strRes As String = Session("DebeCambiarPwd")
                    If strRes <> String.Empty Then
                        If CType(strRes, Boolean) = True Then
                            Response.Redirect("Wfrm_CambiaPwd.aspx?index=0")
                            Exit Try
                        End If
                    End If
                    nPoliticaPwdID = CargaPoliticasPwd(tTicket, rRespuesta)
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

    Private Function CargaPoliticasPwd(ByRef ptTicket As IDTicket, ByRef prRespuesta As Respuesta) As Integer

        Dim sv As Core = New Core
        Dim dsPoliticasPwd As DataSet = sv.ColPoliticasPwd(ptTicket, prRespuesta)

        If prRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
            grdPPwd.DataSource = dsPoliticasPwd
            grdPPwd.DataBind()
            dsPoliticasPwd.Dispose()
        End If

        dsPoliticasPwd = Nothing
        sv = Nothing

    End Function

 

    Private Sub BindUser()
        Dim rRespuesta As Respuesta = Nothing
        Dim nPoliticaPwdID As Integer = 0
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            nPoliticaPwdID = CargaPoliticasPwd(tTicket, rRespuesta)
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

        Dim LongMin As Byte = e.NewValues(2)
        Dim LongMax As Byte = e.NewValues(3)
        Dim Mayusculas As Boolean = e.NewValues(4)
        Dim Minusculas As Boolean = e.NewValues(5)
        Dim IncluirSimbolos As Boolean = e.NewValues(6)
        Dim IncluirNumeros As Boolean = e.NewValues(7)
        Dim Mascara As String = e.NewValues(8)
        Dim DuracionDias As Integer = e.NewValues(9)
        Dim CantPwdHistorico As Integer = e.NewValues(10)
        Dim CambioPwdResetMinutos As Integer = e.NewValues(11)
        Dim AvisoCaducidadPwdDias As Integer = e.NewValues(12)
        Dim CaracteresIguales As Integer = e.NewValues(13)
        Dim CaracteresConsec As Integer = e.NewValues(14)

        DescripcionLog = "Modificación de la Política de Contraseña: " & e.NewValues(0) & " "
        If e.OldValues(0) <> e.NewValues(0) Then
            DescripcionLog = DescripcionLog & "En el Nombre. "
        End If

        If e.OldValues(1) <> e.NewValues(1) Then
            DescripcionLog = DescripcionLog & "En la Desc. "
        End If

        If e.OldValues(2) <> IIf(LongMin = 0, 3, LongMin) Then
            DescripcionLog = DescripcionLog & "En la LongMin. "
        End If

        If e.OldValues(3) <> IIf(LongMax = 0, 20, LongMax) Then
            DescripcionLog = DescripcionLog & "En la LongMax. "
        End If

        If e.OldValues(4) <> Mayusculas Then
            DescripcionLog = DescripcionLog & "En Check Mayús. "
        End If

        If e.OldValues(5) <> Minusculas Then
            DescripcionLog = DescripcionLog & "En Check Minús. "
        End If

        If e.OldValues(6) <> IncluirSimbolos Then
            DescripcionLog = DescripcionLog & "En Check Simbol. "
        End If

        If e.OldValues(7) <> IncluirNumeros Then
            DescripcionLog = DescripcionLog & "En Check Num. "
        End If

        If e.OldValues(8) <> IIf(Mascara Is Nothing, " ", Mascara) Then
            DescripcionLog = DescripcionLog & "En Máscara. "
        End If

        If e.OldValues(9) <> IIf(DuracionDias = 0, 20, DuracionDias) Then
            DescripcionLog = DescripcionLog & "En DurDías. "
        End If

        If e.OldValues(10) <> IIf(CantPwdHistorico = 0, 0, CantPwdHistorico) Then
            DescripcionLog = DescripcionLog & "En CantHist. "
        End If

        If e.OldValues(11) <> IIf(CambioPwdResetMinutos = 0, 0, CambioPwdResetMinutos) Then
            DescripcionLog = DescripcionLog & "En ReseteoMin. "
        End If

        If e.OldValues(12) <> IIf(AvisoCaducidadPwdDias = 0, 0, AvisoCaducidadPwdDias) Then
            DescripcionLog = DescripcionLog & "En AviCadDias. "
        End If

        If e.OldValues(13) <> IIf(CaracteresIguales = 0, 0, CaracteresIguales) Then
            DescripcionLog = DescripcionLog & "En CarIguales. "
        End If

        If e.OldValues(14) <> IIf(CaracteresConsec = 0, 0, CaracteresConsec) Then
            DescripcionLog = DescripcionLog & "En CarConse. "
        End If


    End Function

#End Region

    Protected Sub grdPPwd_CustomJSProperties(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs) Handles grdPPwd.CustomJSProperties
        e.Properties("cpMessage") = Mensaje

    End Sub

    Protected Sub grdPPwd_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPPwd.PageIndexChanged
        Try

            grdPPwd.PageIndex = CType(sender, ASPxGridView).PageIndex
            BindUser()
        Catch ex As Exception
            mensaje = ex.Message
        End Try

    End Sub


    Protected Sub grdPPwd_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grdPPwd.RowDeleting
        Dim aPoliticaPwd As PoliticaPwd
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty
        grdPPwd.CancelEdit()
        e.Cancel = True
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Core
            Dim sDescripcion As String
            sDescripcion = "Eliminación de la Política de Contraseña: " & e.Values(1).ToString.Trim
            aPoliticaPwd = New PoliticaPwd
            With aPoliticaPwd
                .PoliticaPwdID = e.Keys(0)
            End With

            sv.ABC_PoliticaPwd(tTicket, aPoliticaPwd, 1, rRespuesta, sDescripcion)
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                CargaPoliticasPwd(tTicket, rRespuesta)
                mensaje = "Se ejecutó correctamente la operación de eliminar solicitada. "
            Else
                mensaje = "El registro no puede eliminarse ya que esta siendo utilizado en otra parte del sistema"
            End If

        Catch ex As Exception
            mensaje = "El registro no puede eliminarse ya que esta siendo utilizado en otra parte del sistema"
        Finally
            sv = Nothing
            aPoliticaPwd = Nothing
            rRespuesta = Nothing
        End Try
    End Sub



    Protected Sub grdPPwd_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grdPPwd.RowInserting
        Dim aPoliticaPwd As PoliticaPwd
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty
        grdPPwd.CancelEdit()
        e.Cancel = True
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Core
            'Valida si que el nombre no este repetido
            Dim blnVal As Boolean = False
            Dim dsVal As New DataSet
            dsVal = sv.BuscaXNombreTabla(tTicket, rRespuesta, "C", e.NewValues(0).ToString)
            If dsVal.Tables(0).Rows.Count > 0 Then
                blnVal = True
            End If
            dsVal = Nothing

            If blnVal Then
                CargaPoliticasPwd(tTicket, rRespuesta)
                mensaje = "El nombre de la Política de Contraseña """ & e.NewValues(0).ToString & """ ya existe"

            Else
                aPoliticaPwd = New PoliticaPwd
                Dim sDescripcion As String
                sDescripcion = "Creación de la Política de Contraseña: " & e.NewValues(0).ToString.Trim
                Dim descripcion As String = e.NewValues(1)
                Dim LongMin As Byte = e.NewValues(2)
                Dim LongMax As Byte = e.NewValues(3)
                Dim Mayusculas As Boolean = e.NewValues(4)
                Dim Minusculas As Boolean = e.NewValues(5)
                Dim IncluirSimbolos As Boolean = e.NewValues(6)
                Dim IncluirNumeros As Boolean = e.NewValues(7)
                Dim Mascara As String = e.NewValues(8)
                Dim DuracionDias As Integer = e.NewValues(9)
                Dim CantPwdHistorico As Integer = e.NewValues(10)
                Dim CambioPwdResetMinutos As Integer = e.NewValues(11)
                Dim AvisoCaducidadPwdDias As Integer = e.NewValues(12)
                Dim CaracteresIguales As Integer = e.NewValues(13)
                Dim CaracteresConsec As Integer = e.NewValues(14)

                With aPoliticaPwd
                    .Nombre = e.NewValues(0).ToString
                    .Descripcion = IIf(descripcion Is Nothing, " ", descripcion)
                    .LongMin = IIf(LongMin = 0, 3, LongMin)
                    .LongMax = IIf(LongMax = 0, 20, LongMax)
                    .Mayusculas = Mayusculas
                    .Minusculas = Minusculas
                    .IncluirSimbolos = IncluirSimbolos
                    .IncluirNumeros = IncluirNumeros
                    .Mascara = IIf(Mascara Is Nothing, " ", Mascara)
                    .DuracionDias = IIf(DuracionDias = 0, 20, DuracionDias)
                    .CantPwdHistorico = IIf(CantPwdHistorico = 0, 0, CantPwdHistorico)
                    ''[IEJ 20081021] Asignar el valor de CambioPwdResetMinutos y AvisoCaducidadPwdDias
                    .CambioPwdResetMinutos = IIf(CambioPwdResetMinutos = 0, 0, CambioPwdResetMinutos)
                    .AvisoCaducidadPwdDias = IIf(AvisoCaducidadPwdDias = 0, 0, AvisoCaducidadPwdDias)
                    ''[IEJ 20081103] Cantidad de caracteres iguales y consecutivos
                    .CaracteresIguales = IIf(CaracteresIguales = 0, 0, CaracteresIguales)
                    .CaracteresConsec = IIf(CaracteresConsec = 0, 0, CaracteresConsec)
                End With

                sv.ABC_PoliticaPwd(tTicket, aPoliticaPwd, 0, rRespuesta, sDescripcion)
                If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then

                    mensaje = "Se ejecutó correctamente la operación de agregar solicitada. "
                    CargaPoliticasPwd(tTicket, rRespuesta)
                End If
            End If

        Catch ex As Exception
            mensaje = "El registro no pudo agregarse"
        Finally
            sv = Nothing
            aPoliticaPwd = Nothing
            rRespuesta = Nothing
        End Try



    End Sub

    Protected Sub grdPPwd_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grdPPwd.RowUpdating
        Dim aPoliticaPwd As PoliticaPwd
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty
        grdPPwd.CancelEdit()
        e.Cancel = True
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            sv = New Core
            aPoliticaPwd = New PoliticaPwd
            Dim sDescripcion As String
            sDescripcion = DescripcionLog(e)
            Dim descripcion As String = e.NewValues(1)
            Dim LongMin As Byte = e.NewValues(2)
            Dim LongMax As Byte = e.NewValues(3)
            Dim Mayusculas As Boolean = e.NewValues(4)
            Dim Minusculas As Boolean = e.NewValues(5)
            Dim IncluirSimbolos As Boolean = e.NewValues(6)
            Dim IncluirNumeros As Boolean = e.NewValues(7)
            Dim Mascara As String = e.NewValues(8)
            Dim DuracionDias As Integer = e.NewValues(9)
            Dim CantPwdHistorico As Integer = e.NewValues(10)
            Dim CambioPwdResetMinutos As Integer = e.NewValues(11)
            Dim AvisoCaducidadPwdDias As Integer = e.NewValues(12)
            Dim CaracteresIguales As Integer = e.NewValues(13)
            Dim CaracteresConsec As Integer = e.NewValues(14)


            With aPoliticaPwd
                .PoliticaPwdID = e.Keys(0)
                .Nombre = e.NewValues(0).ToString
                .Descripcion = IIf(descripcion Is Nothing, " ", descripcion)
                .LongMin = IIf(LongMin = 0, 3, LongMin)
                .LongMax = IIf(LongMax = 0, 20, LongMax)
                .Mayusculas = Mayusculas
                .Minusculas = Minusculas
                .IncluirSimbolos = IncluirSimbolos
                .IncluirNumeros = IncluirNumeros
                .Mascara = IIf(Mascara Is Nothing, " ", Mascara)
                .DuracionDias = IIf(DuracionDias = 0, 20, DuracionDias)
                .CantPwdHistorico = IIf(CantPwdHistorico = 0, 0, CantPwdHistorico)
                ''[IEJ 20081021] Asignar el valor de CambioPwdResetMinutos y AvisoCaducidadPwdDias
                .CambioPwdResetMinutos = IIf(CambioPwdResetMinutos = 0, 0, CambioPwdResetMinutos)
                .AvisoCaducidadPwdDias = IIf(AvisoCaducidadPwdDias = 0, 0, AvisoCaducidadPwdDias)
                ''[IEJ 20081103] Cantidad de caracteres iguales y consecutivos
                .CaracteresIguales = IIf(CaracteresIguales = 0, 0, CaracteresIguales)
                .CaracteresConsec = IIf(CaracteresConsec = 0, 0, CaracteresConsec)
            End With

            sv.ABC_PoliticaPwd(tTicket, aPoliticaPwd, 2, rRespuesta, sDescripcion)
            If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                CargaPoliticasPwd(tTicket, rRespuesta)
                mensaje = "Se ejecutó correctamente la operación de cambio solicitada. "

            End If
        Catch ex As Exception
            mensaje = "El registro no pudo actualizarse"
        Finally
            sv = Nothing
            aPoliticaPwd = Nothing
            rRespuesta = Nothing
        End Try
    End Sub


    Private Sub grdPPwd_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles grdPPwd.RowValidating
        If e.NewValues("Nombre") = Nothing Then
            e.RowError = "El nombre es requerido."
        End If
    End Sub

End Class