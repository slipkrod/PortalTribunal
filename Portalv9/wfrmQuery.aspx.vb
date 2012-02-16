Imports Portalv9.SvrUsr
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxGridView
Imports System.Collections.Generic
Imports System.Linq
Partial Public Class wfrmQuery
    Inherits System.Web.UI.Page
    Private tTicket As IDTicket
    Dim mySvr As WSArchivo.Service1 = New WSArchivo.Service1()

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Not IsPostBack Then
            Session("dsIdNorma") = Nothing
            Session("dsIdNivel") = Nothing
            Session("dsIdSerie") = Nothing
        End If
    End Sub
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
                InicializaValoresFilterMaster()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub

    Private Sub InicializaValoresFilterMaster()
        Dim myDsFiltroMaster = mySvr.ListaFiltros_Master_All(Request.QueryString("idFiltro"))
        If myDsFiltroMaster.Tables(0).Rows.Count > 0 Then
            lblTitle.Text = myDsFiltroMaster.Tables(0).Rows(0)("Nombre")
            If myDsFiltroMaster.Tables(0).Rows(0)("idArchivo").ToString() = "" Or myDsFiltroMaster.Tables(0).Rows(0)("idArchivo").ToString() = "-1" Then
                Response.Redirect("wfrm_Filtros.aspx")
                Return
            End If
            Session("dsIdArchivo") = myDsFiltroMaster.Tables(0).Rows(0)("idArchivo")
            Session("dsIdNorma") = myDsFiltroMaster.Tables(0).Rows(0)("idNorma")
            Session("dsIdNivel") = myDsFiltroMaster.Tables(0).Rows(0)("idNivel")
            Session("dsIdSerie") = myDsFiltroMaster.Tables(0).Rows(0)("idSerie")
            lblArchivo.Text = myDsFiltroMaster.Tables(0).Rows(0)("Archivo")
            lblNivel.Text = myDsFiltroMaster.Tables(0).Rows(0)("Nivel_Descripcion")
            lblSerie.Text = myDsFiltroMaster.Tables(0).Rows(0)("Serie_Nombre")
            dsIndices.Select()
            lbCampos.DataBind()
            CargarFiltro()
            butEjecutar.Visible = True
        Else
            Response.Redirect("wfrm_Filtros.aspx")
        End If
    End Sub
    Protected Sub butGuardarFiltro_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butGuardarFiltro.Click
        Dim mySvr As WSArchivo.Service1 = New WSArchivo.Service1()
        mySvr.ABC_Filtros_Master(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idFiltro"), Session("dsIdArchivo"), Session("dsIdSerie"), lblTitle.Text, "Alias_" & lblTitle.Text)
        mySvr.ABC_Filtros(WSArchivo.OperacionesABC.operBaja, Request.QueryString("idFiltro"), "", "", "", "", "", "", "", "", "", "", "", "", 0)
        For intRows = 0 To lstFiltros.Items.Count - 1
            mySvr.ABC_Filtros(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idFiltro"), lstFiltros.Items(intRows).Text.Split("|")(0), lstFiltros.Items(intRows).Text.Split("|")(1), lstFiltros.Items(intRows).Text.Split("|")(2), lstFiltros.Items(intRows).Text.Split("|")(3), lstFiltros.Items(intRows).Text.Split("|")(4), lstFiltros.Items(intRows).Text.Split("|")(5), lstFiltros.Items(intRows).Text.Split("|")(6), lstFiltros.Items(intRows).Text.Split("|")(7), lstFiltros.Items(intRows).Text.Split("|")(8), lstFiltros.Items(intRows).Text.Split("|")(9), lstFiltros.Items(intRows).Text.Split("|")(10), lstFiltros.Items(intRows).Text.Split("|")(11), lstFiltros.Items(intRows).Text.Split("|")(12))
        Next        
        butEjecutar.Enabled = True
        btnEditar.Enabled = True
        butGuardarFiltro.Enabled = False
        butCancelar.Enabled = False
        tableFiltros.Style("display") = "none"
        HideOperators()
        If Session("bFiltrosProfile") Is Nothing Then
            btnAgregar.Enabled = False
            btnBorrar.Enabled = False
            btnY.Enabled = False
            btnO.Enabled = False
            BtnPD.Enabled = False
            BtnPI.Enabled = False
        End If
        MsgBox1.ShowMessage("La consulta fue grabada")
    End Sub

    Protected Sub CargarFiltro()
        Dim myFiltrosDs As DataSet = mySvr.ListaFiltros_Master_All(Request.QueryString("idFiltro"))
        If myFiltrosDs.Tables(0).Rows.Count > 0 Then
            LBSQL.Items.Clear()
            lbSQLDesc.Items.Clear()
            lstFiltros.Items.Clear()
            For intRows = 0 To myFiltrosDs.Tables(0).Rows.Count - 1
                If myFiltrosDs.Tables(0).Rows(intRows)("Parentesis").ToString().Trim() <> "" Or myFiltrosDs.Tables(0).Rows(intRows)("AndOr").ToString().Trim() <> "" Then
                    If myFiltrosDs.Tables(0).Rows(intRows)("Parentesis").ToString().Trim() <> "" Then
                        If myFiltrosDs.Tables(0).Rows(intRows)("Parentesis").ToString().Trim() = "(" Then
                            If VerificaParIzq() Then AltaParentesis(False)
                        Else
                            If CuentaParentesisIzq() > CuentaParentesisDer() Then AltaParentesis(True)
                        End If
                    End If
                    If myFiltrosDs.Tables(0).Rows(intRows)("AndOr").ToString().Trim() <> "" Then
                        If myFiltrosDs.Tables(0).Rows(intRows)("AndOrDesc").ToString().Trim() = "Y" Then
                            If VerificaAndOr() Then AltaAndOr(True)
                        Else
                            If VerificaAndOr() Then AltaAndOr(False)
                        End If
                    End If
                Else
                    CreaExpresion(myFiltrosDs.Tables(0).Rows(intRows)("idIndice"), myFiltrosDs.Tables(0).Rows(intRows)("Parentesis"), myFiltrosDs.Tables(0).Rows(intRows)("ParentesisDesc"), myFiltrosDs.Tables(0).Rows(intRows)("AndOr"), myFiltrosDs.Tables(0).Rows(intRows)("AndOrDesc"), myFiltrosDs.Tables(0).Rows(intRows)("FieldName"), myFiltrosDs.Tables(0).Rows(intRows)("FieldTitle"), myFiltrosDs.Tables(0).Rows(intRows)("FieldType"), myFiltrosDs.Tables(0).Rows(intRows)("Operador"), myFiltrosDs.Tables(0).Rows(intRows)("OperadorDesc"), myFiltrosDs.Tables(0).Rows(intRows)("Valor1"), myFiltrosDs.Tables(0).Rows(intRows)("Valor2"), myFiltrosDs.Tables(0).Rows(intRows)("ValorDesc"))
                    lstFiltros.Items.Add(String.Concat(myFiltrosDs.Tables(0).Rows(intRows)("Parentesis"), "|", myFiltrosDs.Tables(0).Rows(intRows)("ParentesisDesc"), "|", myFiltrosDs.Tables(0).Rows(intRows)("AndOr"), "|", myFiltrosDs.Tables(0).Rows(intRows)("AndOrDesc"), "|", myFiltrosDs.Tables(0).Rows(intRows)("FieldName"), "|", myFiltrosDs.Tables(0).Rows(intRows)("FieldTitle"), "|", myFiltrosDs.Tables(0).Rows(intRows)("FieldType"), "|", myFiltrosDs.Tables(0).Rows(intRows)("Operador"), "|", myFiltrosDs.Tables(0).Rows(intRows)("OperadorDesc"), "|", myFiltrosDs.Tables(0).Rows(intRows)("Valor1"), "|", myFiltrosDs.Tables(0).Rows(intRows)("Valor2"), "|", myFiltrosDs.Tables(0).Rows(intRows)("ValorDesc"), "|", myFiltrosDs.Tables(0).Rows(intRows)("idIndice").ToString()))
                End If
            Next
        End If
    End Sub

    Sub Ejecutar()
        If LBSQL.Items.Count > 0 Then
            lblerror.Visible = False
            If VerificaParentesis() Then
                If LBSQL.Items(LBSQL.Items.Count - 1).Value = "(" Or LBSQL.Items(LBSQL.Items.Count - 1).Value = "AND" Or LBSQL.Items(LBSQL.Items.Count - 1).Value = "OR" Then
                    lblerror.Text = "Error de sintaxis..."
                    lblerror.Visible = True
                Else
                    LLenaGrid()
                End If
            Else
                lblerror.Text = "Error en paréntesis..."
                lblerror.Visible = True
            End If
        End If
    End Sub

    Sub HideOperators()
        trFiltrosBotones.Style("display") = ""
        btnAgregar.Visible = False
        butGuardaFiltrosEditados.Visible = False
        btnBorrar.Visible = False
        BtnPD.Visible = False
        BtnPI.Visible = False
        btnY.Visible = False
        btnO.Visible = False
        val1.Visible = False
    End Sub
    Sub ShowOperators()
        trFiltrosBotones.Style("display") = ""
        lblvalores.Visible = True
        btnAgregar.Visible = True
        butGuardaFiltrosEditados.Visible = True
        btnBorrar.Visible = True
        BtnPD.Visible = True
        BtnPI.Visible = True
        btnY.Visible = True
        btnO.Visible = True
        val1.Visible = True
        lbSQLDesc.Visible = True
        nvalores2.Width = 300
        If LbOperador.SelectedIndex < 0 Then
        Else
            If LbOperador.SelectedItem.Text = "Entre" Then
                HabiltaEntre(True)
                If LbOperador.SelectedItem.GetValue("OpType") = "2" Then
                    val1.Visible = False
                    val2.Visible = False
                    CampoFecha1.Visible = False
                    CampoPeriodoFechas1.Visible = True
                    CampoPeriodoMesAno1.Visible = False
                    CampoPeriodoAno1.Visible = False
                    CampoSI_NO1.Visible = False
                    CampoCatalogo1.Visible = False
                    'CampoGrid1.Visible = False
                Else
                    CampoFecha1.Visible = False
                    CampoPeriodoFechas1.Visible = False
                    CampoPeriodoMesAno1.Visible = False
                    CampoPeriodoAno1.Visible = False
                    CampoSI_NO1.Visible = False
                    CampoCatalogo1.Visible = False
                    'CampoGrid1.Visible = False
                End If
            Else
                If (LbOperador.SelectedItem.Text = "Uno de") Or (LbOperador.SelectedItem.Text = "Diferente De") Then
                    Select Case LbOperador.SelectedItem.GetValue("OpType")
                        Case "2"
                            nvalores2.Visible = True
                            HabiltaValores(True)
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = True
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                        Case "3"
                            nvalores2.Visible = True
                            HabiltaValores(True)
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = True
                            CampoPeriodoFechas1.Fecha_IniWidth = 100
                            CampoPeriodoFechas1.Fecha_FinWidth = 100
                            nvalores2.Width = 200
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                        Case "4"
                            nvalores2.Visible = True
                            HabiltaValores(True)
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = True
                            nvalores2.Width = 100
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                        Case "5"
                            nvalores2.Visible = True
                            HabiltaValores(True)
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = True
                            nvalores2.Width = 150
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                        Case "6"
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = True
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                        Case "11"
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = True
                            If Not lbCampos.SelectedItem Is Nothing Then
                                CampoCatalogo1.Catalogo = lbCampos.SelectedItem.GetValue("relacion_con_normaPID")
                            Else
                                CampoCatalogo1.Catalogo = -1
                            End If
                            'CampoGrid1.Visible = False
                        Case "12"
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = True
                            If Not lbCampos.SelectedItem Is Nothing Then
                                CampoCatalogo1.Catalogo = lbCampos.SelectedItem.GetValue("relacion_con_normaPID")
                            Else
                                CampoCatalogo1.Catalogo = -1
                            End If
                            'CampoGrid1.Visible = True
                        Case Else
                            nvalores2.Visible = True
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                            HabiltaValores(True)
                    End Select
                Else
                    nvalores2.Visible = False
                    DesHabiltaTodos(False)
                    Select Case LbOperador.SelectedItem.GetValue("OpType")
                        Case "2"
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = True
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                        Case "3"
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = True
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                        Case "4"
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = True
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                        Case "5"
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = True
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                        Case "6"
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = True
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                        Case "11"
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = True
                            If Not lbCampos.SelectedItem Is Nothing Then
                                CampoCatalogo1.Catalogo = lbCampos.SelectedItem.GetValue("relacion_con_normaPID")
                            Else
                                CampoCatalogo1.Catalogo = -1
                            End If
                            'CampoGrid1.Visible = False
                        Case "12"
                            val1.Visible = False
                            val2.Visible = False
                            CampoFecha1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoCatalogo1.Visible = True
                            If Not lbCampos.SelectedItem Is Nothing Then
                                CampoCatalogo1.Catalogo = lbCampos.SelectedItem.GetValue("relacion_con_normaPID")
                            Else
                                CampoCatalogo1.Catalogo = -1
                            End If
                            'CampoGrid1.Visible = True
                        Case Else
                            CampoFecha1.Visible = False
                            CampoSI_NO1.Visible = False
                            CampoPeriodoAno1.Visible = False
                            CampoPeriodoFechas1.Visible = False
                            CampoPeriodoMesAno1.Visible = False
                            CampoCatalogo1.Visible = False
                            'CampoGrid1.Visible = False
                    End Select
                End If
            End If
            End If
    End Sub

    Private Sub HabiltaEntre(ByVal Visible As Boolean)
        nvalores2.Visible = False
        nvalores2.Items.Clear()
        b_A.Visible = False
        B_E.Visible = False
        val2.Visible = True
        val2.Text = ""
        Y.Visible = True
    End Sub
    Private Sub HabiltaValores(ByVal Visible As Boolean)
        val2.Visible = False
        val2.Text = ""
        Y.Visible = False
        nvalores2.Visible = True
        nvalores2.Items.Clear()
        b_A.Visible = True
        B_E.Visible = True
    End Sub

    Private Sub DesHabiltaTodos(ByVal Visible As Boolean)
        Val1.Text = ""
        val2.Visible = Visible
        val2.Text = ""
        Y.Visible = Visible
        nvalores2.Visible = Visible
        nvalores2.Items.Clear()
        b_A.Visible = False
        B_E.Visible = False
    End Sub

    Private Sub AltaParentesis(ByVal Derecho As Boolean)
        Dim nItem As New DevExpress.Web.ASPxEditors.ListEditItem

        If Derecho Then
            nItem.Text = ")"
            nItem.Value = ")"
            LBSQL.Items.Add(")", ")")
        Else
            nItem.Text = "("
            nItem.Value = "("
            LBSQL.Items.Add("(", "(")
        End If
        lstFiltros.Items.Add(String.Concat(nItem.Text, "|", nItem.Text, "|||||||||||0"))
        lbSQLDesc.Items.Add(nItem)
    End Sub

    Function VerificaParentesis() As Boolean
        If CuentaParentesisDer() = CuentaParentesisIzq() Then
            VerificaParentesis = True
        Else
            VerificaParentesis = False
        End If
    End Function

    Function CuentaParentesisDer() As Integer
        Dim intI As Integer
        Dim ParDer As Integer
        ParDer = 0
        For intI = 0 To LBSQL.Items.Count - 1
            If LBSQL.Items(intI).Value = ")" Then
                ParDer = ParDer + 1
            End If
        Next
        CuentaParentesisDer = ParDer
    End Function

    Function CuentaParentesisIzq() As Integer
        Dim intI As Integer
        Dim ParIzq As Integer
        ParIzq = 0
        For intI = 0 To LBSQL.Items.Count - 1
            If LBSQL.Items(intI).Value = "(" Then
                ParIzq = ParIzq + 1
            End If
        Next
        CuentaParentesisIzq = ParIzq
    End Function

    Function VerificaParIzq() As Boolean
        If LBSQL.Items.Count = 0 Then
            VerificaParIzq = True
        Else
            If LBSQL.Items(LBSQL.Items.Count - 1).Value = "(" Then
            Else
                If LBSQL.Items(LBSQL.Items.Count - 1).Text = "AND" Or LBSQL.Items(LBSQL.Items.Count - 1).Text = "OR" Then
                    VerificaParIzq = True
                Else
                    VerificaParIzq = False
                End If
            End If
        End If
    End Function

    Function VerificaParDer() As Boolean
        If LBSQL.Items(LBSQL.Items.Count - 1).Value = ")" Then
            VerificaParDer = True
        Else
            If LBSQL.Items(LBSQL.Items.Count - 1).Text <> ")" And LBSQL.Items(LBSQL.Items.Count - 1).Text <> "(" And LBSQL.Items(LBSQL.Items.Count - 1).Text <> "AND" And LBSQL.Items(LBSQL.Items.Count - 1).Text <> "OR" Then
                VerificaParDer = True
            Else
                VerificaParDer = False
            End If
        End If
    End Function

    Function VerificaAndOr() As Boolean
        If LBSQL.Items.Count = 0 Then
            VerificaAndOr = True
        Else
            If LBSQL.Items(LBSQL.Items.Count - 1).Value = ")" Then
            Else
                If LBSQL.Items(LBSQL.Items.Count - 1).Text <> ")" And LBSQL.Items(LBSQL.Items.Count - 1).Text <> "(" And LBSQL.Items(LBSQL.Items.Count - 1).Text <> "AND" And LBSQL.Items(LBSQL.Items.Count - 1).Text <> "OR" Then
                    VerificaAndOr = True
                Else
                    VerificaAndOr = False
                End If
            End If
        End If
    End Function

    Private Sub AltaAndOr(ByVal nAnd As Boolean)
        Dim nItem As New DevExpress.Web.ASPxEditors.ListEditItem
        Dim mItem As New DevExpress.Web.ASPxEditors.ListEditItem

        If nAnd Then
            nItem.Text = "AND"
            nItem.Value = "AND"
            mItem.Text = "Y"
            mItem.Value = "Y"
        Else
            nItem.Text = "OR"
            nItem.Value = "OR"
            mItem.Text = "O"
            mItem.Value = "O"
        End If
        LBSQL.Items.Add(nItem)
        lbSQLDesc.Items.Add(mItem)
        lstFiltros.Items.Add(String.Concat("||", nItem.Text, "|", mItem.Value, "|||||||||0"))
        'lbSQLDesc.Items.Add(DevExpress.Web.ASPxEditors.ListEditItem)
    End Sub
    Private Function VerificaExpresion() As Boolean
        If LBSQL.Items.Count = 0 Then
            VerificaExpresion = True
        Else
            If LBSQL.Items(LBSQL.Items.Count - 1).Value = "(" Then
                VerificaExpresion = True
            Else
                If LBSQL.Items(LBSQL.Items.Count - 1).Text = "AND" Or LBSQL.Items(LBSQL.Items.Count - 1).Text = "OR" Then
                    VerificaExpresion = True
                Else
                    VerificaExpresion = False
                End If
            End If
        End If
    End Function

    Private Sub CreaExpresion(ByVal oPeracion As WSArchivo.OperacionesABC)
        Dim intI As Integer
        Dim ValorDesc As String
        Dim ValorSQL As String
        Dim ValCampoSQL As String
        Dim ValCampoSQL1 As String

        ValorDesc = "["
        ValorSQL = ""
        lblerror.Visible = False
        If oPeracion = WSArchivo.OperacionesABC.operCambio And LbOperador.SelectedItem Is Nothing Then
            lbCampos.DataBind()
            lbCampos.Items.FindByValue(Integer.Parse(lblFiltroEdited.Text.Split("|")(12))).Selected = True
            LbOperador.DataBind()
            LbOperador.Items.FindByText(lblFiltroEdited.Text.Split("|")(8)).Selected = True
            'LbOperador.Items.FindByText(lblOperador.Text).Selected = True
        End If
        If Not LbOperador.SelectedItem.Text Is Nothing Then
            If (lbCampos.SelectedItem.GetValue("indice_tipo") <> 11 And lbCampos.SelectedItem.GetValue("indice_tipo") <> 12) And (LbOperador.SelectedItem.Text = "Diferente De" Or LbOperador.SelectedItem.Text = "Uno de") Then
                If nvalores2.Items.Count = 0 And LbOperador.SelectedItem.GetValue("OpType") <> "6" Then
                    lblerror.Text = "Debe Agregar valores..."
                    lblerror.Visible = True
                Else
                    For intI = 0 To nvalores2.Items.Count - 1
                        Select Case lbCampos.SelectedItem.GetValue("Indice_tipo")
                            Case "0"
                                ValorDesc = ValorDesc + "'" + nvalores2.Items(intI).Value + "',"
                                ValorSQL = ValorSQL + "'" + nvalores2.Items(intI).Value + "',"
                            Case "2", "3", "4", "5"
                                ValorDesc = ValorDesc + "'" + nvalores2.Items(intI).Value + "',"
                                ValorSQL = ValorSQL + "'" + nvalores2.Items(intI).Value + "',"
                            Case "1", "7"
                                ValorDesc = ValorDesc + nvalores2.Items(intI).Value + ","
                                ValorSQL = ValorSQL + nvalores2.Items(intI).Value.Replace("$", "").Replace(",", "") + ","
                        End Select
                    Next
                    ValorDesc = ValorDesc.Substring(0, ValorDesc.Length - 1) + "]"
                    If ValorSQL.Length > 1 Then ValorSQL = ValorSQL.Substring(0, ValorSQL.Length - 1)
                    If LbOperador.SelectedItem.Text = "Diferente De" Then
                        If nvalores2.Items.Count > 1 Then
                            If oPeracion = WSArchivo.OperacionesABC.operAlta Then
                                LBSQL.Items.Add(" (" & LbOperador.SelectedItem.GetValue("OpSQL").ToString().ToLower().Replace("'x'", ValorSQL & ")").Replace("campo", "Valor").Replace("<>", " not in (") & " and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value & ") ")
                            ElseIf oPeracion = WSArchivo.OperacionesABC.operCambio Then
                                LBSQL.Items(lblLbSQLDesc.Text).Text = " (" & LbOperador.SelectedItem.GetValue("OpSQL").ToString().ToLower().Replace("'x'", ValorSQL & ")").Replace("campo", "Valor").Replace("<>", " not in (") & " and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value & ") "
                            End If
                        Else
                            Select Case LbOperador.SelectedItem.GetValue("OpType")
                                Case "3"
                                    ValorDesc = String.Concat("'", CampoPeriodoFechas1.Fecha_Ini, "-", CampoPeriodoFechas1.Fecha_Fin, "'")
                                    ValorSQL = String.Concat("'", CampoPeriodoFechas1.Fecha_Ini, "-", CampoPeriodoFechas1.Fecha_Fin, "'")
                                Case "4"
                                    ValorDesc = String.Concat("'", CampoPeriodoMesAno1.Año_Ini, "-", CampoPeriodoMesAno1.Año_Fin, "'")
                                    ValorSQL = String.Concat("'", CampoPeriodoMesAno1.Año_Ini, "-", CampoPeriodoMesAno1.Año_Fin, "'")
                                Case "5"
                                    ValorDesc = String.Concat("'", CampoPeriodoAno1.Año_Ini, "-", CampoPeriodoAno1.Año_Fin, "'")
                                    ValorSQL = String.Concat("'", CampoPeriodoAno1.Año_Ini, "-", CampoPeriodoAno1.Año_Fin, "'")
                                Case "6"
                                    ValorDesc = "'" + CampoSI_NO1.ValorCampo + "'"
                                    ValorSQL = CampoSI_NO1.ValorCampo
                                Case "11"
                                Case "12"
                                    ValorDesc = "'" + CampoCatalogo1.ValorCampo + "'"
                                    ValorSQL = CampoCatalogo1.ValorCampo
                            End Select
                            If oPeracion = WSArchivo.OperacionesABC.operAlta Then
                                LBSQL.Items.Add(" (" & LbOperador.SelectedItem.GetValue("OpSQL").ToString().ToLower().Replace("x", ValorSQL).Replace("campo", "Valor") & " and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value & ") ")
                            ElseIf oPeracion = WSArchivo.OperacionesABC.operCambio Then
                                LBSQL.Items(lblLbSQLDesc.Text).Text = " (" & LbOperador.SelectedItem.GetValue("OpSQL").ToString().ToLower().Replace("x", ValorSQL).Replace("campo", "Valor") & " and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value & ") "
                            End If
                        End If
                        If oPeracion = WSArchivo.OperacionesABC.operAlta Then
                            lbSQLDesc.Items.Add(lbCampos.SelectedItem.Text + " " + LbOperador.SelectedItem.Text + " " + ValorDesc)
                        ElseIf oPeracion = WSArchivo.OperacionesABC.operCambio Then
                            lbSQLDesc.Items(lblLbSQLDesc.Text).Text = lbCampos.SelectedItem.Text + " " + LbOperador.SelectedItem.Text + " " + ValorDesc
                        End If
                    Else
                        If oPeracion = WSArchivo.OperacionesABC.operAlta Then
                            LBSQL.Items.Add(" (" & LbOperador.SelectedItem.GetValue("OpSQL").ToString().ToLower().Replace("x", ValorSQL).Replace("campo", "Valor") & " and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value & ") ")
                            lbSQLDesc.Items.Add(lbCampos.SelectedItem.Text + " " + LbOperador.SelectedItem.Text + " " + ValorDesc)
                        ElseIf oPeracion = WSArchivo.OperacionesABC.operCambio Then
                            LBSQL.Items(lblLbSQLDesc.Text).Text = " (" & LbOperador.SelectedItem.GetValue("OpSQL").ToString().ToLower().Replace("x", ValorSQL).Replace("campo", "Valor") & " and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value & ") "
                            lbSQLDesc.Items(lblLbSQLDesc.Text).Text = lbCampos.SelectedItem.Text + " " + LbOperador.SelectedItem.Text + " " + ValorDesc
                        End If
                    End If

                End If
            Else
                Select Case lbCampos.SelectedItem.GetValue("Indice_tipo")
                    Case "0"
                        If LbOperador.SelectedItem.Text = "Entre" Then
                            ValCampoSQL = "'" & val1.Text & "'"
                            ValCampoSQL1 = "'" & val2.Text & "'"
                        Else
                            ValCampoSQL = val1.Text
                            ValCampoSQL1 = val2.Text
                        End If
                    Case "2"
                        If LbOperador.SelectedItem.Text = "Entre" Then
                            ValCampoSQL = CampoPeriodoFechas1.Fecha_Ini
                            ValCampoSQL1 = CampoPeriodoFechas1.Fecha_Fin
                        Else
                            ValCampoSQL = CampoFecha1.ValorCampo
                        End If
                    Case "3"
                        ValCampoSQL = CampoPeriodoFechas1.Fecha_Ini
                        ValCampoSQL1 = CampoPeriodoFechas1.Fecha_Fin
                    Case "4"
                        ValCampoSQL = CampoPeriodoMesAno1.Año_Ini
                        ValCampoSQL1 = CampoPeriodoMesAno1.Año_Fin
                    Case "5"
                        ValCampoSQL = CampoPeriodoAno1.Año_Ini
                        ValCampoSQL1 = CampoPeriodoAno1.Año_Fin
                    Case "6"
                        ValCampoSQL = CampoSI_NO1.ValorCampo
                    Case "11"
                    Case "12"
                        ValCampoSQL = CampoCatalogo1.ValorCampo
                        ValCampoSQL1 = CampoCatalogo1.ValorCatalogo
                    Case "1", "7"
                        ValCampoSQL = val1.Text.Replace("$", "").Replace(",", "")
                        If val2.Text <> "" Then
                            ValCampoSQL1 = val2.Text.Replace("$", "").Replace(",", "")
                        End If
                End Select
                If LbOperador.SelectedItem.Text = "Entre" Then
                    If oPeracion = WSArchivo.OperacionesABC.operAlta Then
                        LBSQL.Items.Add("(Indice_Tipo=" & lbCampos.SelectedItem.GetValue("Indice_tipo") & " and " & LbOperador.SelectedItem.GetValue("OpSQL").Replace("campo", "Valor").Replace("x", ValCampoSQL).Replace("y", ValCampoSQL1) & ") and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value)
                        lbSQLDesc.Items.Add(lbCampos.SelectedItem.Text + " " + LbOperador.SelectedItem.Text + " [" + val1.Text + ".." + val2.Text + "]")
                    ElseIf oPeracion = WSArchivo.OperacionesABC.operCambio Then
                        LBSQL.Items(lblLbSQLDesc.Text).Text = "(Indice_Tipo=" & lbCampos.SelectedItem.GetValue("Indice_tipo") & " and " & LbOperador.SelectedItem.GetValue("OpSQL").Replace("campo", "Valor").Replace("x", ValCampoSQL).Replace("y", ValCampoSQL1) & ") and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value
                        lbSQLDesc.Items(lblLbSQLDesc.Text).Text = lbCampos.SelectedItem.Text + " " + LbOperador.SelectedItem.Text + " [" + ValCampoSQL + ".." + ValCampoSQL1 + "]"
                    End If
                Else
                    If oPeracion = WSArchivo.OperacionesABC.operAlta Then
                        Select Case lbCampos.SelectedItem.GetValue("Indice_tipo")
                            Case "3", "4", "5"
                                LBSQL.Items.Add(" (" & LbOperador.SelectedItem.GetValue("OpSQL").ToString().Replace("x", ValCampoSQL + "-" + ValCampoSQL1).Replace("campo", "Valor") & " and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value & ") ")
                                lbSQLDesc.Items.Add(lbCampos.SelectedItem.Text + " " + LbOperador.SelectedItem.Text + " " + ValCampoSQL + "-" + ValCampoSQL1)
                            Case Else
                                LBSQL.Items.Add(" (" & LbOperador.SelectedItem.GetValue("OpSQL").ToString().Replace("x", ValCampoSQL).Replace("campo", "Valor") & " and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value & ") ")
                                lbSQLDesc.Items.Add(lbCampos.SelectedItem.Text + " " + LbOperador.SelectedItem.Text + " " + ValCampoSQL)
                        End Select
                    ElseIf oPeracion = WSArchivo.OperacionesABC.operCambio Then
                        Select Case lbCampos.SelectedItem.GetValue("Indice_tipo")
                            Case "3", "4", "5"
                                LBSQL.Items(lblLbSQLDesc.Text).Text = " (" & LbOperador.SelectedItem.GetValue("OpSQL").ToString().Replace("x", ValCampoSQL + "-" + ValCampoSQL1).Replace("campo", "Valor") & " and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value & ") "
                                lbSQLDesc.Items(lblLbSQLDesc.Text).Text = lbCampos.SelectedItem.Text + " " + LbOperador.SelectedItem.Text + " " + ValCampoSQL + "-" + ValCampoSQL1
                            Case Else
                                LBSQL.Items(lblLbSQLDesc.Text).Text = " (" & LbOperador.SelectedItem.GetValue("OpSQL").ToString().Replace("x", ValCampoSQL).Replace("campo", "Valor") & " and Archivo_Indices.idIndice=" & lbCampos.SelectedItem.Value & ") "
                                lbSQLDesc.Items(lblLbSQLDesc.Text).Text = lbCampos.SelectedItem.Text + " " + LbOperador.SelectedItem.Text + " " + ValCampoSQL
                        End Select
                    End If
                End If
            End If
        Else
            lblerror.Visible = True
            lblerror.Text = "Favor de escoger un operador."
        End If

    End Sub

    Private Sub GuardaFiltros(ByVal oPeracion As WSArchivo.OperacionesABC)
        Dim intI As Integer
        Dim ValorDesc As String
        Dim ValorSQL As String
        Dim ValCampoSQL As String
        Dim ValCampoSQL1 As String
        Dim myLbOperador As String

        ValorDesc = "["
        ValorSQL = ""
        lblerror.Visible = False
        If LbOperador.SelectedItem.Text Is Nothing Then Return
        If (lbCampos.SelectedItem.GetValue("indice_tipo") <> 11 And lbCampos.SelectedItem.GetValue("indice_tipo") <> 12) And LbOperador.SelectedItem.Text = "Diferente De" Or LbOperador.SelectedItem.Text = "Uno de" Then
            If nvalores2.Items.Count = 0 And LbOperador.SelectedItem.GetValue("OpType") <> "6" Then
            Else
                For intI = 0 To nvalores2.Items.Count - 1
                    Select Case lbCampos.SelectedItem.GetValue("Indice_tipo")
                        Case "0", "2", "3", "4", "5"
                            ValorDesc = ValorDesc + "'" + nvalores2.Items(intI).Value + "',"
                            ValorSQL = ValorSQL + "'" + nvalores2.Items(intI).Value + "',"
                        Case "1", "7"
                            ValorDesc = ValorDesc + nvalores2.Items(intI).Value + ","
                            ValorSQL = ValorSQL + nvalores2.Items(intI).Value.Replace("$", "").Replace(",", "") + ","
                    End Select
                Next
                If LbOperador.SelectedItem.GetValue("OpType") = "6" Then
                    ValorDesc = CampoSI_NO1.ValorCampo
                    ValCampoSQL = CampoSI_NO1.ValorCampo
                Else
                    ValorDesc = ValorDesc.Substring(0, ValorDesc.Length - 1) + "]"
                    If ValorSQL.Length > 1 Then ValCampoSQL = ValorSQL.Substring(0, ValorSQL.Length - 1)
                End If
                '11
                '12
            End If
        Else
            Select Case lbCampos.SelectedItem.GetValue("Indice_tipo")
                Case "2"
                    If LbOperador.SelectedItem.Text = "Entre" Then
                        ValCampoSQL = CampoPeriodoFechas1.Fecha_Ini
                        ValCampoSQL1 = CampoPeriodoFechas1.Fecha_Fin
                    Else
                        ValCampoSQL = CampoFecha1.ValorCampo
                    End If
                Case "3"
                    ValCampoSQL = CampoPeriodoFechas1.Fecha_Ini + "-" + CampoPeriodoFechas1.Fecha_Fin
                    ValCampoSQL1 = CampoPeriodoFechas1.Fecha_Fin
                Case "4"
                    ValCampoSQL = CampoPeriodoMesAno1.Año_Ini
                    ValCampoSQL1 = CampoPeriodoMesAno1.Año_Fin
                Case "5"
                    ValCampoSQL = CampoPeriodoAno1.Año_Ini
                    ValCampoSQL1 = CampoPeriodoAno1.Año_Fin
                Case "6"
                    ValCampoSQL = CampoSI_NO1.ValorCampo
                Case "11"
                Case "12"
                    ValCampoSQL = CampoCatalogo1.ValorCampo
                Case "1", "7"
                    ValCampoSQL = val1.Text.Replace("$", "").Replace(",", "")
                    If val2.Text <> "" Then
                        ValCampoSQL1 = val2.Text.Replace("$", "").Replace(",", "")
                    End If
                Case "0"
                    If LbOperador.SelectedItem.Text = "Entre" Then
                        ValCampoSQL = "'" & val1.Text & "'"
                        ValCampoSQL1 = "'" & val2.Text & "'"
                    Else
                        ValCampoSQL = val1.Text
                        ValCampoSQL1 = val2.Text
                    End If
            End Select
            If LbOperador.SelectedItem.Text = "Entre" Then
                myLbOperador = LbOperador.SelectedItem.GetValue("OpSQL") '.Replace("campo", "")
            Else
                myLbOperador = LbOperador.SelectedItem.GetValue("OpSQL") '.Replace("campo", "")
            End If
            ValorDesc = ValCampoSQL
        End If
        Dim fParentesis As String = ""
        Dim fParentesisDesc As String = ""
        Dim fAndOr As String = ""
        Dim fAndOrDesc As String = ""
        Dim fFieldName As String = "Valor"
        Dim fFieldTitle As String = lbCampos.SelectedItem.GetValue("campo")
        Dim fFieldType As String = lbCampos.SelectedItem.GetValue("Indice_tipo")
        Dim fOperador As String = LbOperador.SelectedItem.GetValue("OpSQL") 'myLbOperador
        Dim fOperadorDesc As String = LbOperador.SelectedItem.Text
        Dim fValor1 As String = ValCampoSQL
        Dim fValor2 As String = ValCampoSQL1
        Dim fValorDesc As String = ValorDesc
        If oPeracion = WSArchivo.OperacionesABC.operAlta Then
            lstFiltros.Items.Add(String.Concat(fParentesis, "|", fParentesisDesc, "|", fAndOr, "|", fAndOrDesc, "|", fFieldName, "|", fFieldTitle, "|", fFieldType, "|", fOperador, "|", fOperadorDesc, "|", fValor1, "|", fValor2, "|", fValorDesc, "|", lbCampos.SelectedItem.Value))
        ElseIf oPeracion = WSArchivo.OperacionesABC.operCambio Then
            lstFiltros.Items(lblLbSQLDesc.Text).Text = String.Concat(fParentesis, "|", fParentesisDesc, "|", fAndOr, "|", fAndOrDesc, "|", fFieldName, "|", fFieldTitle, "|", fFieldType, "|", fOperador, "|", fOperadorDesc, "|", fValor1, "|", fValor2, "|", fValorDesc, "|", lbCampos.SelectedItem.Value)
        End If
    End Sub

    Private Sub CreaExpresion(ByVal _idIndice As Integer, ByVal _Parentesis As String, ByVal _ParentesisDesc As String, ByVal _AndOr As String, ByVal _AndOrDesc As String, ByVal _FieldName As String, ByVal _FieldTitle As String, ByVal _FieldType As String, ByVal _Operador As String, ByVal _OperadorDesc As String, ByVal _Valor1 As String, ByVal _Valor2 As String, ByVal _ValorDesc As String)
        Dim ValorDesc As String
        Dim ValorSQL As String
        Dim ValCampoSQL As String
        Dim ValCampoSQL1 As String

        ValorSQL = ""
        lblerror.Visible = False
        If _OperadorDesc.Trim() = "Diferente De" Or _OperadorDesc.Trim() = "Uno de" Then
            ValorDesc = _ValorDesc
            ValorSQL = _Valor1
            If _OperadorDesc.Trim() = "Diferente De" Then
                If ValorSQL.Split(",").Length > 0 And ValorSQL.IndexOf(",") > 0 Then
                    Dim iValues As Integer
                    Dim sValues As String = ""
                    For iValues = 0 To ValorSQL.Split(",").Length - 1
                        sValues = String.Concat(sValues, ValorSQL.Split(",")(iValues), ",")
                    Next
                    LBSQL.Items.Add(" (" & _Operador.ToString().ToLower().Replace("'x'", sValues.Substring(0, sValues.Length - 1) & ")").Replace("campo", "Valor").Replace("<>", " not in (") & " and Archivo_Indices.idIndice=" & _idIndice & ") ")
                Else
                    LBSQL.Items.Add(" (" & _Operador.ToString().ToLower().Replace("x", ValorSQL).Replace("campo", "Valor") & " and Archivo_Indices.idIndice=" & _idIndice & ") ")
                End If
                lbSQLDesc.Items.Add(_FieldTitle + " " + _OperadorDesc + " " + ValorDesc)
            Else
                LBSQL.Items.Add(" (" & _Operador.ToString().ToLower().Replace("x", ValorSQL).Replace("campo", "Valor") & " and Archivo_Indices.idIndice=" & _idIndice & ") ")
                lbSQLDesc.Items.Add(_FieldTitle + " " + _OperadorDesc + " " + ValorDesc)
            End If
        Else
            ValCampoSQL = _Valor1
            ValCampoSQL1 = _Valor2
            If _OperadorDesc.Trim() = "Entre" Then
                LBSQL.Items.Add("(Indice_Tipo=" & _FieldType & " and " & _Operador.Replace("campo", "Valor").Replace("x", ValCampoSQL).Replace("y", ValCampoSQL1) & ") and Archivo_Indices.idIndice=" & _idIndice)
                lbSQLDesc.Items.Add(_FieldTitle + " " + _OperadorDesc + " [" + _Valor1 + ".." + _Valor2 + "]")
            Else
                LBSQL.Items.Add(" (" & _Operador.ToString().Replace("x", ValCampoSQL).Replace("campo", "Valor") & " and Archivo_Indices.idIndice=" & _idIndice & ") ")
                lbSQLDesc.Items.Add(_FieldTitle + " " + _OperadorDesc + " " + _Valor1)
            End If
        End If
    End Sub
    Private Sub BorraValores()
        nvalores2.Items.Clear()
        val1.Text = ""
        val2.Text = ""
    End Sub
    Private Sub LLenaGrid()
        Dim svr As New Portalv9.WSArchivo.Service1
        Try
            Dim ds As New DataSet
            ObjConsulta.SelectParameters("SQLString").DefaultValue = CreaQuery()
            ObjConsulta.Select()
            ASPxGridView1.DataBind()
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
        srtSQL = "Select Archivo_indices.idArchivo, " & _
                 " Archivo_Descripciones_Archivisticas.idDescripcion,  Archivo_Descripciones_Archivisticas.idNivel," & _
                 " Descripcion, Archivo_Descripcion, (Select Serie_nombre From Series_modelo Where Series_modelo.idSerie = Archivo_Descripciones_Archivisticas.idSerie) As Tipo_Expediente, " & _
                 " Nivel, Nivel_Descripcion, Nivel_Logico_Fisico, " & _
                 " idFolio, archivo_indices.Valor, idIndice," & _
                 " Archivo_indices.IdElemento, (Select Area_descripcion From Areas Where Areas.idNorma=Archivo_indices.idNorma and Areas.idArea = Archivo_indices.idArea) As Area_Descripcion," & _
                 " (Select Indice_descripcion From Elementos_campos Where idIndice = archivo_indices.idIndice ) As Indice_Descripcion," & _
                 "(Select folio_norma + ' ' + Elemento_descripcion From Elementos Where Elementos.idNorma=Archivo_indices.idNorma and Elementos.idArea = Archivo_indices.idArea and Elementos.idElemento=Archivo_indices.idElemento) As Elemento_Descripcion " & _
                 " From" & _
                 "      Archivo_indices inner Join Archivo_Descripciones_Archivisticas " & _
                 "      On (Archivo_indices.idArchivo = Archivo_Descripciones_Archivisticas.idArchivo and Archivo_indices.idDescripcion = Archivo_Descripciones_Archivisticas.idDescripcion)" & _
                 "      Inner Join archivos On (Archivo_Descripciones_Archivisticas.idArchivo = archivos.idArchivo)" & _
                 "      Left Join Niveles On (Archivo_indices.idNivel = Niveles.idNivel)" & _
                 " Where " & _
                 " Archivo_Descripciones_Archivisticas.idArchivo = " & Session("dsIdArchivo")
        If LBSQL.Items.Count > 0 Then
            For intI = 0 To LBSQL.Items.Count - 1
                If intI = 0 Then
                    srtSQL = srtSQL + " And (" + LBSQL.Items(intI).Text + " "
                Else
                    srtSQL = srtSQL + " " + LBSQL.Items(intI).Text + " "
                End If
            Next
            srtSQL = srtSQL + ")"
        End If
        CreaQuery = srtSQL
    End Function

    Private Sub B_A_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_A.Click
        Dim nitem As New ListEditItem
        Select Case lbCampos.SelectedItem.GetValue("Indice_tipo")
            Case "2"
                nitem.Value = CampoFecha1.ValorCampo
                nitem.Text = nitem.Value
                nvalores2.Items.Add(nitem)
                CampoFecha1.ValorCampo = ""
                CampoFecha1.ValorCampo = ""
            Case "3"
                nitem.Value = CampoPeriodoFechas1.Fecha_Ini + "-" + CampoPeriodoFechas1.Fecha_Fin
                nitem.Text = nitem.Value
                nvalores2.Items.Add(nitem)
                CampoPeriodoFechas1.Fecha_Ini = ""
                CampoPeriodoFechas1.Fecha_Fin = ""
            Case "4"
                nitem.Value = CampoPeriodoMesAno1.Año_Ini + "-" + CampoPeriodoMesAno1.Año_Fin
                nitem.Text = nitem.Value
                nvalores2.Items.Add(nitem)
                CampoPeriodoMesAno1.Año_Ini = ""
                CampoPeriodoMesAno1.Año_Fin = ""
            Case "5"
                nitem.Value = CampoPeriodoAno1.Año_Ini + "-" + CampoPeriodoAno1.Año_Fin
                nitem.Text = nitem.Value
                nvalores2.Items.Add(nitem)
                CampoPeriodoAno1.Año_Ini = ""
                CampoPeriodoAno1.Año_Fin = ""
            Case Else
                nitem.Value = val1.Text
                nitem.Text = nitem.Value
                nvalores2.Items.Add(nitem)
                val1.Text = String.Empty
        End Select
    End Sub

    Private Sub B_E_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles B_E.Click
        If nvalores2.SelectedItem Is Nothing Then
            MsgBox1.ShowMessage("Debe selecionar el valor de la lista que quiere borrar")
        Else
            nvalores2.Items.Remove(nvalores2.SelectedItem)
        End If
    End Sub

    Protected Sub ObjConsulta_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjConsulta.Selecting
        If Not IsPostBack Then
            '    e.Cancel = True
        End If
    End Sub
    Protected Sub LBSQL_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles LBSQL.Callback
        LBSQL.DataBind()
    End Sub

    Protected Sub LbOperador_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LbOperador.SelectedIndexChanged
        ShowOperators()
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgregar.Click
        tableFiltros.Style("display") = ""
        Session("FilterAction") = "Add"
        btnAgregar.Enabled = False
        butGuardaFiltrosEditados.Enabled = False
        btnBorrar.Enabled = False
        BtnPI.Enabled = False
        BtnPD.Enabled = False
        btnY.Enabled = False
        btnO.Enabled = False
        If Not Session("bFiltrosProfile") Is Nothing Then
            lbCampos.Visible = True
            lblIndice.Visible = False
            LbOperador.Visible = True
            lblOperador.Visible = False
        Else
            btnAgregar.Enabled = False
            btnBorrar.Enabled = False
            lbCampos.Visible = False
            lblIndice.Visible = True
            LbOperador.Visible = False
            lblOperador.Visible = True
        End If
    End Sub

    Protected Sub btnBorrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBorrar.Click
        If lbSQLDesc.SelectedIndex < 0 Then
            MsgBox1.ShowMessage("Seleccione primero el filtro que va borrar")
        Else
            LBSQL.Items.RemoveAt(lbSQLDesc.SelectedIndex)            
            lstFiltros.Items.RemoveAt(lbSQLDesc.SelectedIndex)
            lbSQLDesc.Items.RemoveAt(lbSQLDesc.SelectedIndex)
            CheckAndOrFirstRow()
            Session("FilterAction") = Nothing
        End If
    End Sub

    Protected Sub BtnPI_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnPI.Click
        lblerror.Visible = False
        If VerificaParIzq() Then
            AltaParentesis(False)
        Else
            lblerror.Text = "No es posible poner un parentesis derecho, error sintaxis favor de verificar..."
            lblerror.Visible = True
        End If
    End Sub

    Protected Sub BtnPD_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnPD.Click
        If VerificaParDer() Then
            If CuentaParentesisIzq() > CuentaParentesisDer() Then
                AltaParentesis(True)
            Else
                lblerror.Text = "Falta parentesis Izquierdo, favor de verificar..."
                lblerror.Visible = True
            End If
        Else
            lblerror.Text = "No es posible poner un parentesis derecho, error sintaxis favor de verificar..."
            lblerror.Visible = True
        End If
    End Sub

    Protected Sub btnY_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnY.Click
        lblerror.Visible = False
        If VerificaAndOr() Then
            AltaAndOr(True)
        Else
            lblerror.Text = "Error sintaxis favor de verificar..."
            lblerror.Visible = True
        End If
    End Sub

    Protected Sub btnO_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnO.Click
        lblerror.Visible = False
        If VerificaAndOr() Then
            AltaAndOr(False)
        Else
            lblerror.Text = "Error sintaxis favor de verificar..."
            lblerror.Visible = True
        End If
    End Sub

    Protected Sub ASPxButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butEjecutar.Click
        Ejecutar()
    End Sub

    Protected Sub dsIndices_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsIndices.Selecting
        Try
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub lbCampos_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles lbCampos.Callback
        Session("dsIdSerie") = e.Parameter
        lbCampos.DataBind()
        lbCampos.SelectedIndex = -1
        LbOperador.Visible = True
        LbOperador.DataBind()
        tableFiltros.Style("display") = ""
        trFiltrosBotones.Style("display") = ""
    End Sub

    Protected Sub lbCampos_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lbCampos.ValueChanged
        LbOperador.DataBind()
        HideOperators()
        LbOperador.Visible = True
        trFiltrosBotones.Style("display") = ""
        val1.Visible = False
        CampoSI_NO1.Visible = False
        CampoFecha1.Visible = False
        CampoPeriodoAno1.Visible = False
        CampoPeriodoFechas1.Visible = False
        CampoPeriodoMesAno1.Visible = False
        CampoCatalogo1.Visible = False
        CampoCatalogo1.ValorCampo = -1
    End Sub

    Sub CheckAndOrFirstRow()
        If lbSQLDesc.Items.Count < 2 Then
            btnY.Enabled = False
            btnO.Enabled = False
        Else
            btnY.Enabled = True
            btnO.Enabled = True
        End If
    End Sub
    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditar.Click
        butEjecutar.Enabled = False
        btnEditar.Enabled = False
        butGuardarFiltro.Enabled = True
        butCancelar.Enabled = True
        ShowOperators()
        CheckAndOrFirstRow()
        If Session("bFiltrosProfile") Is Nothing Then
            btnAgregar.Enabled = False
            btnBorrar.Enabled = False
            btnY.Enabled = False
            btnO.Enabled = False
            BtnPD.Enabled = False
            BtnPI.Enabled = False
        End If
    End Sub

    Protected Sub butGuardaFiltrosEditados_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butGuardaFiltrosEditados.Click
        If lbSQLDesc.SelectedIndex < 0 Then
            MsgBox1.ShowMessage("Seleccione primero el filtro que va a editar")
        Else
            tableFiltros.Style("display") = ""
            Session("FilterAction") = "Edit"
            btnAgregar.Enabled = False
            butGuardaFiltrosEditados.Enabled = False
            btnBorrar.Enabled = False
            BtnPI.Enabled = False
            BtnPD.Enabled = False
            btnY.Enabled = False
            btnO.Enabled = False
            EditingOneRow()
            If Not Session("bFiltrosProfile") Is Nothing Then
                lbCampos.Visible = True
                lblIndice.Visible = False
                LbOperador.Visible = True
                lblOperador.Visible = False
            Else
                btnAgregar.Enabled = False
                btnBorrar.Enabled = False
                lbCampos.Visible = False
                lblIndice.Visible = True
                LbOperador.Visible = False
                lblOperador.Visible = True
            End If
        End If
    End Sub

    Protected Sub butCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butCancelar.Click
        Response.Redirect(Request.Url.ToString)
    End Sub

    Sub EditingOneRow()
        If lbSQLDesc.SelectedItem.Text = "Y" Or lbSQLDesc.SelectedItem.Text = "O" Or lbSQLDesc.SelectedItem.Text = "(" Or lbSQLDesc.SelectedItem.Text = ")" Then
            MsgBox1.ShowMessage("Este filtro no se puede editar solo eliminar")
            Return
        End If
        lblFiltroEdited.Text = lstFiltros.Items(lbSQLDesc.SelectedIndex).Text
        butGuardaFiltrosEditados.Visible = True
        lblIndiceDesc.Text = "Editando valores del campo : "
        tableFiltros.Style("display") = ""
        lblLbSQLDesc.Text = lbSQLDesc.SelectedIndex
        If lbCampos.Items.Count < 1 Then lbCampos.DataBind()
        lbCampos.Items.FindByValue(Integer.Parse(lstFiltros.Items(lbSQLDesc.SelectedIndex).Text.Split("|")(12))).Selected = True
        lblIndice.Text = lbCampos.SelectedItem.Text
        daOperadores.DataBind()
        LbOperador.DataBind()
        LbOperador.Items.FindByText(lstFiltros.Items(lbSQLDesc.SelectedIndex).Text.Split("|")(8)).Selected = True
        lblOperador.Text = "Operador utilizado: " + LbOperador.SelectedItem.Text
        ShowOperators()
        If LbOperador.SelectedItem.Text = "Entre" Then
            val1.Text = lstFiltros.Items(lbSQLDesc.SelectedIndex).Text.Split("|")(9).Replace("'", "")
            val2.Text = lstFiltros.Items(lbSQLDesc.SelectedIndex).Text.Split("|")(10).Replace("'", "")
        Else
            If (LbOperador.SelectedItem.Text = "Uno de") Or (LbOperador.SelectedItem.Text = "Diferente De") Then
                val1.Text = ""
                Dim iLista As Integer
                For iLista = 0 To lstFiltros.Items(lbSQLDesc.SelectedIndex).Text.Split("|")(9).Split(",").Length - 1
                    nvalores2.Items.Add(lstFiltros.Items(lbSQLDesc.SelectedIndex).Text.Split("|")(9).Split(",")(iLista).Replace("'", ""))
                Next
            Else
                val1.Text = lstFiltros.Items(lbSQLDesc.SelectedIndex).Text.Split("|")(9).Replace("'", "")
            End If
        End If
    End Sub

    Protected Sub butFiltroGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butFiltroGrabar.Click
        If Session("FilterAction") = "Add" Then
            lblerror.Visible = False
            lblerror.Text = ""
            If VerificaExpresion() Then
                CreaExpresion(WSArchivo.OperacionesABC.operAlta)
                GuardaFiltros(WSArchivo.OperacionesABC.operAlta)
                BorraValores()
                lbSQLDesc.Visible = True
                butEjecutar.Visible = True
            Else
                lblerror.Text = "Error sintaxis favor de verificar..."
                lblerror.Visible = True
            End If
        Else
            lblerror.Visible = False
            lblerror.Text = ""
            trFiltrosBotones.Style("display") = ""
            CreaExpresion(WSArchivo.OperacionesABC.operCambio)
            GuardaFiltros(WSArchivo.OperacionesABC.operCambio)
            BorraValores()
            lbSQLDesc.Visible = True
            butEjecutar.Visible = True
        End If
        FiltroCancelar()
    End Sub

    Protected Sub butFiltroCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butFiltroCancelar.Click
        FiltroCancelar()
    End Sub
    Sub FiltroCancelar()
        tableFiltros.Style("display") = "none"
        lbCampos.SelectedIndex = -1
        LbOperador.SelectedIndex = -1
        Session("FilterAction") = Nothing
        btnAgregar.Enabled = True
        butGuardaFiltrosEditados.Enabled = True
        btnBorrar.Enabled = True
        BtnPI.Enabled = True
        BtnPD.Enabled = True
        btnY.Enabled = True
        btnO.Enabled = True
        If Session("bFiltrosProfile") Is Nothing Then
            btnAgregar.Enabled = False
            btnBorrar.Enabled = False
            btnY.Enabled = False
            btnO.Enabled = False
            BtnPD.Enabled = False
            BtnPI.Enabled = False
        End If
    End Sub

    Protected Sub daOperadores_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles daOperadores.Selecting
        If IsPostBack And lbCampos.SelectedIndex > -1 Then
            e.InputParameters("OpType").Value = lbCampos.SelectedItem.GetValue("indice_tipo")
        End If
    End Sub
End Class
