Imports Portalv9.SvrUsr
Imports System.Text
Imports System.Security.Cryptography
Imports System.Linq
Imports System.Data.DataTableExtensions

Partial Public Class Wfrm_UsuariosAD
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Private tTicket As IDTicket
    Private eGrupoAdminID As Integer
#End Region
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Asignar click al texto de buscar
        Me.txtpwdad.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Me.btningresar.UniqueID + "').click();return false;}} else {return true}; ")
        Me.txtcuenta.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Me.btnBuscar.UniqueID + "').click();return false;}} else {return true}; ")
        Me.txtnom.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Me.btnBuscar.UniqueID + "').click();return false;}} else {return true}; ")
        Me.txtapp.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Me.btnBuscar.UniqueID + "').click();return false;}} else {return true}; ")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblTitle.Text = "Creacion de Usuarios a través de Active Directory"
        txtusuad.Focus()
        cargarcombo()
        If DropGrupoAdmin.Items.Count = 0 Then
            Response.Write("<script>alert('No tiene grupos para asignar usuarios.');window.navigate('Wfrm_Contenido.aspx')</script>")
        End If
        cpe.Collapsed = True
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        Dim dominio As String
        dominio = conexion.Dominios
        Dim buscar As New ActiveDirectory
        Dim dt, dt2 As New DataTable
        Dim sv As Core = New Core

        Dim objGlobal As New clsGlobal
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
            Logoff()
            Exit Sub
        End If
        Dim rRespuesta As Respuesta = Nothing

        If Session("UserAD") = "" Or Session("PwdAd") = "" Then
            Response.Write("<script>alert('Por favor introduce tus credenciales de Windows.');</script>")
            mostrarAD()
        Else
            Select Case RadioButtonList1.SelectedItem.Value
                Case "Cuenta"
                    If txtcuenta.Text <> "" Then
                        ' Obtiene los Usuarios de Active Directory
                        dt = buscar.OntenerTodo(txtcuenta.Text, dominio, Session("UserAD"), Session("PwdAd"))
                        'Evaluas si tienes Usuarios para ingresar
                        If dt.Rows.Count > 0 Then
                            'Obtiene los Usuarios de IDportal
                            Dim dsIdentidadUsr As DataSet = sv.ColUsuariosAdministrartodo(tTicket, rRespuesta)
                            dt2 = dsIdentidadUsr.Tables(0)
                            'realizar la conciliacion de Usuarios
                            Dim condw = From da In dt _
                                        Group Join idportal In dt2 _
                                        On da.Item("cuenta").ToString.ToUpper Equals idportal.Item("UsrId").ToString.ToUpper Into noestan = Any() _
                                        Where Not noestan _
                                        Select Cuenta = da("cuenta").ToString, Nombre = da("Nombre").ToString, Apellidos = da("Apellidos").ToString, _
                                        Telefono = da("Telefono").ToString, Mail = da("mail").ToString Order By Cuenta
                            GwAd.DataSource = condw
                            GwAd.DataBind()
                            GwAd.Visible = True
                            DropGrupoAdmin.Visible = True
                            btnInsertar.Visible = True
                            'cargarcombo()
                            lbllista.Visible = True
                            ocultar()
                            btnbuscarag.Visible = True
                        Else
                            Response.Write("<script>alert('No hay usuarios con ese criterio de busqueda.');</script>")
                            txtcuenta.Text = ""
                            txtcuenta.Focus()
                        End If
                    Else
                        Response.Write("<script>alert('Es Nesesario intrudicir un Valor.');</script>")
                        txtcuenta.Text = ""
                        txtcuenta.Focus()
                    End If
                Case "noa"
                    If txtnom.Text <> "" Then
                        If txtapp.Text <> "" Then
                            'buscar completo
                            dt = buscar.buscar(txtnom.Text, dominio, txtapp.Text, Session("UserAD"), Session("PwdAd"))
                            If dt.Rows.Count > 0 Then
                                'Obtiene los Usuarios de IDportal
                                Dim dsIdentidadUsr As DataSet = sv.ColUsuariosAdministrartodo(tTicket, rRespuesta)
                                dt2 = dsIdentidadUsr.Tables(0)
                                'realizar la conciliacion de Usuarios
                                Dim condw = From da In dt _
                                            Group Join idportal In dt2 _
                                            On da.Item("cuenta").ToString.ToUpper Equals idportal.Item("UsrId").ToString.ToUpper Into noestan = Any() _
                                            Where Not noestan _
                                            Select Cuenta = da("cuenta").ToString, Nombre = da("Nombre").ToString, Apellidos = da("Apellidos").ToString, _
                                                   Telefono = da("Telefono").ToString, Mail = da("mail").ToString Order By Cuenta
                                GwAd.DataSource = condw
                                GwAd.DataBind()
                                GwAd.Visible = True
                                DropGrupoAdmin.Visible = True
                                btnInsertar.Visible = True
                                'cargarcombo()
                                lbllista.Visible = True
                                ocultar()
                                btnbuscarag.Visible = True
                            Else
                                Response.Write("<script>alert('No hay usuarios con ese criterio de busqueda.');</script>")
                                txtnom.Text = ""
                                txtapp.Text = ""
                                txtnom.Focus()
                            End If

                        Else
                            'buscar nombre
                            dt = buscar.buscarnombre(txtnom.Text, dominio, Session("UserAD"), Session("PwdAd"))
                            If dt.Rows.Count > 0 Then
                                'Obtiene los Usuarios de IDportal
                                Dim dsIdentidadUsr As DataSet = sv.ColUsuariosAdministrartodo(tTicket, rRespuesta)
                                dt2 = dsIdentidadUsr.Tables(0)
                                'realizar la conciliacion de Usuarios
                                Dim condw = From da In dt _
                                            Group Join idportal In dt2 _
                                            On da.Item("cuenta").ToString.ToUpper Equals idportal.Item("UsrId").ToString.ToUpper Into noestan = Any() _
                                            Where Not noestan _
                                            Select Cuenta = da("cuenta").ToString, Nombre = da("Nombre").ToString, Apellidos = da("Apellidos").ToString, _
                                                   Telefono = da("Telefono").ToString, Mail = da("mail").ToString Order By Cuenta
                                GwAd.DataSource = condw
                                GwAd.DataBind()
                                GwAd.Visible = True
                                DropGrupoAdmin.Visible = True
                                btnInsertar.Visible = True
                                'cargarcombo()
                                lbllista.Visible = True
                                ocultar()
                                btnbuscarag.Visible = True
                            Else
                                Response.Write("<script>alert('No hay usuarios con ese criterio de busqueda.');</script>")
                                txtnom.Text = ""
                                txtapp.Text = ""
                                txtnom.Focus()
                            End If

                        End If
                    Else
                        If txtapp.Text <> "" Then
                            'buscar apellidos
                            dt = buscar.buscarappellido(txtapp.Text, dominio, Session("UserAD"), Session("PwdAd"))
                            If dt.Rows.Count > 0 Then
                                'Obtiene los Usuarios de IDportal
                                Dim dsIdentidadUsr As DataSet = sv.ColUsuariosAdministrartodo(tTicket, rRespuesta)
                                dt2 = dsIdentidadUsr.Tables(0)
                                'realizar la conciliacion de Usuarios
                                Dim condw = From da In dt _
                                            Group Join idportal In dt2 _
                                            On da.Item("cuenta").ToString.ToUpper Equals idportal.Item("UsrId").ToString.ToUpper Into noestan = Any() _
                                            Where Not noestan _
                                            Select Cuenta = da("cuenta").ToString, Nombre = da("Nombre").ToString, Apellidos = da("Apellidos").ToString, _
                                                   Telefono = da("Telefono").ToString, Mail = da("mail").ToString Order By Cuenta
                                GwAd.DataSource = condw
                                GwAd.DataBind()
                                GwAd.Visible = True
                                DropGrupoAdmin.Visible = True
                                btnInsertar.Visible = True
                                'cargarcombo()
                                lbllista.Visible = True
                                ocultar()
                                btnbuscarag.Visible = True
                            Else
                                Response.Write("<script>alert('No hay usuarios con ese criterio de busqueda.');</script>")
                                txtnom.Text = ""
                                txtapp.Text = ""
                                txtnom.Focus()
                            End If
                        Else
                            'error
                            Response.Write("<script>alert('Es necesario poner Nombre o Apellidos para Buscar');</script>")
                        End If
                    End If
            End Select

        End If
    End Sub
    Public Sub cargarcombo()
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        'Crear Drop de GrupoaAdmin
        CreaDropAndList(DropGrupoAdmin, "GrupoAdminID", "Nombre", tTicket.GrupoAdminID, 1)
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim dt As New DataTable
        Dim buscar As New ActiveDirectory
        Dim dominio As String = conexion.Dominios
        Select Case RadioButtonList1.SelectedItem.Value
            Case "Cuenta"
                RadioButtonList1.Visible = False
                lblcuenta.Visible = True
                txtcuenta.Visible = True
                txtcuenta.Focus()
                lblnombre.Visible = False
                txtnom.Visible = False
                lblapp.Visible = False
                txtapp.Visible = False
                btnBuscar.Visible = True
            Case "noa"
                RadioButtonList1.Visible = False
                lblnombre.Visible = True
                lblapp.Visible = True
                txtnom.Visible = True
                txtnom.Focus()
                txtapp.Visible = True
                btnBuscar.Visible = True
                lblcuenta.Visible = False
                txtcuenta.Visible = False
            Case "Todo"
                Dim dt2 As New DataTable
                Dim sv As Core = New Core
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    LogOff()
                    Exit Sub
                End If
                Dim rRespuesta As Respuesta = Nothing
                dt = buscar.OntenerTodo("", dominio, Session("UserAD"), Session("PwdAd"))
                If dt.Rows.Count > 0 Then
                    'Obtiene los Usuarios de IDportal
                    Dim dsIdentidadUsr As DataSet = sv.ColUsuariosAdministrartodo(tTicket, rRespuesta)
                    dt2 = dsIdentidadUsr.Tables(0)
                    'realizar la conciliacion de Usuarios
                    Dim condw = From da In dt _
                                Group Join idportal In dt2 _
                                On da.Item("cuenta").ToString.ToUpper Equals idportal.Item("UsrId").ToString.ToUpper Into noestan = Any() _
                                Where Not noestan _
                                Select Cuenta = da("cuenta").ToString, Nombre = da("Nombre").ToString, Apellidos = da("Apellidos").ToString, _
                                       Telefono = da("Telefono").ToString, Mail = da("mail").ToString Order By Cuenta
                    GwAd.DataSource = condw
                    GwAd.DataBind()
                    GwAd.Visible = True
                    RadioButtonList1.Visible = False
                    DropGrupoAdmin.Visible = True
                    btnInsertar.Visible = True
                    'cargarcombo()
                    lbllista.Visible = True
                    ocultar()
                    btnBuscarag.visible = True
                End If

        End Select
    End Sub
    Private Sub CreaDropAndList(ByVal DropList As Object, ByVal vDataValueField As String, ByVal vDataTextField As String, ByVal aGrupoAdminid As Integer, ByVal Tipop As Integer)
        Dim sv As New Core
        Dim dv As DataView = Nothing
        Dim ds As DataSet
        'Dim dsh As DataSet
        Dim rRespuesta As Respuesta = Nothing
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Tipop = 1 Then
                'ds = sv.ColGrupoAdmin(tTicket, aGrupoAdminid, rRespuesta)
                'If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                ds = sv.ColGrupoAdminHijos(tTicket, aGrupoAdminid, rRespuesta)
                If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                    'ds.Merge(dsh)
                    dv = ds.Tables(0).DefaultView
                End If
                'End If
            Else
                'ds = sv.ColTodoslosPerfiles(tTicket, rRespuesta)
                'ColPerfilesUsr
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
            'Me.MsgBox1.ShowMessage(exp.Message)
        End Try
        sv = Nothing
    End Sub
    Protected Sub btnInsertar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInsertar.Click
        Dim Usuario
        Dim Nombre
        Dim Apellidos As String = String.Empty
        Dim Apellidop As String = String.Empty
        Dim Apellidom As String = String.Empty
        Dim Mail As String = String.Empty
        Dim filtro As String = String.Empty
        Dim completos As Integer = 0
        Dim sDescripcion As String
        Dim aIdentidadUsr As IdentidadUsr
        Dim rRespuesta As New Respuesta
        Dim sv As Core
        Dim strMsg As String = String.Empty
        Dim op As String = 0
        tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
        sv = New Core

        Try
            For i As Integer = 0 To Me.GwAd.Rows.Count - 1

                If CType(GwAd.Rows.Item(i).Cells(0).Controls(1), CheckBox).Checked Then
                    'Acción seleccionadas
                    Usuario = HttpUtility.HtmlDecode(GwAd.Rows.Item(i).Cells(1).Text.ToString)
                    Nombre = HttpUtility.HtmlDecode(GwAd.Rows.Item(i).Cells(2).Text.ToString)
                    Apellidos = GwAd.Rows.Item(i).Cells(3).Text.ToString
                    filtro = Apellidos.IndexOf(" ")
                    If Apellidos.LastIndexOf(" ") > 0 Then
                        Apellidop = HttpUtility.HtmlDecode(Apellidos.Substring(0, filtro))
                        Apellidom = HttpUtility.HtmlDecode((Right(Apellidos, Apellidos.Length - (Apellidos.LastIndexOf(" ") + 1))))
                    End If
                    Mail = HttpUtility.HtmlDecode(GwAd.Rows.Item(i).Cells(5).Text.ToString)
                    'Valida si que el nombre no este repetido
                    Dim blnVal As Boolean = False
                    If op = 0 Then
                        Dim dsVal As New DataSet
                        dsVal = sv.BuscaXNombreTabla(tTicket, rRespuesta, "U", Usuario)
                        If dsVal.Tables(0).Rows.Count > 0 Then
                            blnVal = True
                        End If
                        dsVal = Nothing
                    End If

                    If blnVal Then
                        Response.Write("<script>alert('El Login " & Usuario & " ya existe para otro Usuario');</script>")
                    Else
                        aIdentidadUsr = New IdentidadUsr
                        sDescripcion = DescripcionLog(1, op, Usuario, Apellidop, Apellidom)
                        With aIdentidadUsr
                            .FechaCreacionPwd = DateTime.Now
                            Dim autentificacion As String
                            autentificacion = conexion.Autentificacion
                            .Pwd = " "
                            .UsrID = Usuario
                            .Nombre = Nombre
                            .ApellidoP = Apellidop
                            .ApellidoM = Apellidom
                            .Desactivado = False
                            .DebeCambiarPwd = False
                            .GrupoAdminID = DropGrupoAdmin.SelectedValue
                            .IntentosFallidosConsec = 0
                            .LlavePublica = ""

                            '[BCC 20080506] Asignar el valor de email y domicilio indicados
                            .Email = Mail
                            .DomicilioID = 0

                            '[IEJ 20081021] Asignar el valor de IntentosFallidosDia y FechaDesacIntentosDia, ELIMINADO
                            .IntentosFallidosDia = 0
                            .FechaDesacIntentosDia = DateTime.Now
                            .Eliminado = False
                        End With

                        Dim NoIdentidad As Integer = 0
                        NoIdentidad = sv.ABC_IdentidadUsr(tTicket, aIdentidadUsr, op, rRespuesta, sDescripcion)

                        If rRespuesta.RespuestaID = Application("GSTR_RESPUESTA_OK_DEFAULT") Then
                            completos += 1
                        Else
                            Response.Write("<script>alert('Ocurrió un error al intentar la operación solicitada:" & rRespuesta.RespuestaToString & "');</script>")
                        End If

                    End If
                End If
            Next
            Response.Write("<script>alert('Se Crearon " & completos & " Usuarios en el Sistema');</script>")
            GwAd.Dispose()
            GwAd.Visible = False
            DropGrupoAdmin.Visible = False
            btnbuscarag.Visible = False
            mostrar()
            cpe.Collapsed = True
        Catch ex As Exception

        Finally
            sv = Nothing
            aIdentidadUsr = Nothing
            rRespuesta = Nothing
        End Try
    End Sub
    Protected Sub btningresar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btningresar.Click
        Dim usuario, dominio As String
        dominio = conexion.Dominios
        Dim ad As New ActiveDirectory
        Try
            usuario = ad.loginAd(dominio, txtusuad.Text, txtpwdad.Text)
            If usuario <> "" Then
                Session("UserAD") = txtusuad.Text
                Session("PwdAd") = txtpwdad.Text
                txtusuad.Visible = False
                txtpwdad.Visible = False
                lblusrad.Visible = False
                lblpwdad.Visible = False
                btningresar.Visible = False
                RadioButtonList1.Visible = True
            End If
        Catch ex As Exception
            txtusuad.Text = ""
            txtpwdad.Text = ""
            Response.Write("<script>alert('El Usuario o la Contraseñas son Incorrectas');</script>")
            txtusuad.Focus()
        End Try

    End Sub
    Private Function DescripcionLog(ByVal Index As Long, ByVal op As String, ByVal nombre As String, ByVal apellidop As String, ByVal apellidom As String) As String
        DescripcionLog = String.Empty
        Select Case op
            Case OperacionesABC.operAlta
                DescripcionLog = "Creación del Usuario: " & nombre & " " & apellidop & " " & apellidom & ", "
        End Select
    End Function
    Private Sub ocultar()
        lblcuenta.Visible = False
        txtcuenta.Visible = False
        lblnombre.Visible = False
        txtnom.Visible = False
        lblapp.Visible = False
        txtapp.Visible = False
        btnBuscar.Visible = False
        RadioButtonList1.Visible = False
    End Sub
    Private Sub mostrar()
        txtcuenta.Text = ""
        txtnom.Text = ""
        RadioButtonList1.ClearSelection()
        RadioButtonList1.Visible = True
        btnInsertar.Visible = False
        lbllista.Visible = False
    End Sub
    Private Sub mostrarAD()
        lblusrad.Visible = True
        txtusuad.Visible = True
        txtusuad.Text = ""
        lblpwdad.Visible = True
        txtpwdad.Text = ""
        txtpwdad.Visible = True
        btningresar.Visible = True
    End Sub
    Private Sub LogOff()
        Server.Transfer("Logoff.aspx")
    End Sub
    Protected Sub Tbtbuscarag_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnbuscarag.Click
        GwAd.Dispose()
        GwAd.Visible = False
        RadioButtonList1.ClearSelection()
        RadioButtonList1.Visible = True
        btnbuscarag.Visible = False
        lbllista.Visible = False
        DropGrupoAdmin.Visible = False
        btnInsertar.Visible = False
        txtcuenta.Text = ""
        txtnom.Text = ""
        txtapp.Text = ""
    End Sub
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        'GwAd.Column(0).headertext.checkbox1
        Dim chk As CheckBox = CType(GwAd.HeaderRow.Cells(0).FindControl("CheckBox1"), CheckBox)
        If chk IsNot Nothing Then
            If chk.Checked = True Then
                'Dim a = GwAd.Page.Request
                'Dim b = GwAd.PageCount
                'Dim c = GwAd.PageIndex
                For i = 0 To GwAd.Rows.Count - 1
                    Dim chkhijo As CheckBox = GwAd.Rows.Item(i).Cells(0).FindControl("chkad")
                    chkhijo.Checked = True
                Next
            Else
                For i = 0 To GwAd.Rows.Count - 1
                    Dim chkhijo As CheckBox = GwAd.Rows.Item(i).Cells(0).FindControl("chkad")
                    chkhijo.Checked = False
                Next
            End If
            ' Response.Write(chk.Checked)
        End If
        'Response.Write("<script>alert('Prueba')</script>")
    End Sub
End Class