Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo
Imports DevExpress.Web.ASPxEditors


Partial Public Class Wfrm_PlantillaMaster
    Inherits System.Web.UI.Page

    Public tTicket As IDTicket
    Public AreaActiva As Integer

    Private Sub Wfrm_PlantillaMaster_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        CargaAreas()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Page.IsPostBack Then
                'lblTitle.Text = "Normas->Plantilla Maestra   [" & Request.QueryString("Norma") & "]"
                Dim objGlobal As New clsGlobal
                tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
                If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                    Logoff()
                    Exit Sub
                End If
                ElementosVisibles(AreaActiva)
            End If
        End If
    End Sub
    Private Sub CargaAreas()
        Dim sv As New WSArchivo.Service1
        Dim dsAreas As DataSet
        Dim intI As Integer

        dsAreas = sv.ListaNormas_Areas(Request.QueryString("idNorma"))
        For intI = 0 To dsAreas.Tables(0).Rows.Count - 1
            CreaTablaElemento(Request.QueryString("idNorma"), dsAreas.Tables(0).Rows(intI).Item("idArea"))
        Next
        If dsAreas.Tables(0).Rows.Count > 0 Then
            AreaActiva = dsAreas.Tables(0).Rows(0).Item("idArea")
        End If
    End Sub
    Private Sub CreaTablaElemento(ByVal idNorma As Integer, ByVal idArea As Integer)
        Dim sv As New WSArchivo.Service1
        Dim dsElementos As DataSet
        Dim intI As Integer

        dsElementos = sv.ListaNormas_Elementos(idNorma, idArea)
        For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
            Dim DLCampos As New DataList
            Dim dsCampos As DataSet

            dsCampos = sv.ListaNormas_Elementos_Campos(idNorma, idArea, dsElementos.Tables(0).Rows(intI).Item("idElemento"))

            DLCampos.ID = "DLCampos" & dsElementos.Tables(0).Rows(intI).Item("idElemento")
            DLCampos.BorderColor = Drawing.Color.AliceBlue
            DLCampos.BorderWidth = 0.5
            DLCampos.BorderStyle = BorderStyle.Solid
            DLCampos.HeaderTemplate = Page.LoadTemplate("WebUsrCtrls/PlantillaHeaderCampo.ascx")
            DLCampos.ItemTemplate = Page.LoadTemplate("WebUsrCtrls/CamposElemento.ascx")
            DLCampos.ShowFooter = True
            DLCampos.ShowHeader = True
            DLCampos.GridLines = GridLines.Both

            DLCampos.DataSource = dsCampos
            DLCampos.DataKeyField = "idIndice"
            DLCampos.DataBind()
            DLCampos.Visible = False
            DLCampos.TabIndex = idArea
            DLCampos.Width = 600
            DLCampos.BorderStyle = BorderStyle.Solid
            DLCampos.BorderWidth = 1
            DLCampos.BorderColor = Drawing.Color.AliceBlue


            If Not DLCampos.Controls(0).Controls(0).FindControl("Titulo") Is Nothing Then
                Dim Folio As ASPxLabel = CType(DLCampos.Controls(0).Controls(0).FindControl("Folio"), ASPxLabel)
                Dim titulo As ASPxLabel = CType(DLCampos.Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel)
                Folio.Text = dsElementos.Tables(0).Rows(intI).Item("folio_norma")
                titulo.Text = dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")
            End If

            AddHandler DLCampos.EditCommand, AddressOf DLCampos_editCommand
            AddHandler DLCampos.ItemCommand, AddressOf DLCampos_ItemCommand
            AddHandler DLCampos.DeleteCommand, AddressOf DLCampos_DeleteCommand

            PnlElementos.Controls.Add(DLCampos)

        Next
    End Sub

    Protected Sub DLCampos_editCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim sv As New WSArchivo.Service1
        Dim dsCampos As DataSet
        Dim nDatalist As DataList
        nDatalist = source

        PantallaCaptura.HeaderText = "Agregar campo en "
        lblElementoID.Text = nDatalist.ID.Substring(8)
        lblDataListID.Text = nDatalist.ID
        lblElemento.Text = CType(nDatalist.Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text

        dsCampos = sv.ListaNormas_Elementos_Campo(Request.QueryString("idNorma"), dlAreas.SelectedValue, lblElementoID.Text, e.CommandArgument)
        Dim indicetipo As Integer = dsCampos.Tables(0).Rows(0).Item("Indice_Tipo")
        Tipo.SelectedIndex = Tipo.Items.IndexOfValue(indicetipo)
        'Tipo.SelectedIndex = dsCampos.Tables(0).Rows(0).Item("Indice_Tipo")
        Longitud.Value = dsCampos.Tables(0).Rows(0).Item("Indice_LongitudMax")
        CampoNombre.Text = dsCampos.Tables(0).Rows(0).Item("Indice_descripcion")
        folio_norma.Text = dsCampos.Tables(0).Rows(0).Item("folio_norma")
        Mascara.Text = dsCampos.Tables(0).Rows(0).Item("Indice_Mascara")
        Obligatorio.Checked = dsCampos.Tables(0).Rows(0).Item("Indice_Obligatorio")
        vVisible.Checked = dsCampos.Tables(0).Rows(0).Item("Indice_Visible")
        vPadres.Checked = dsCampos.Tables(0).Rows(0).Item("Muestra_padres")
        chkMultivalor.Checked = dsCampos.Tables(0).Rows(0).Item("Multi_Valor")
        If dsCampos.Tables(0).Rows(0).Item("relacion_con_normaPID") <> -1 Then
            cmbCatalogo.Visible = True
            lblCatalogo.Visible = True
            chkMultivalor.Visible = True
            lblMultivalor.Visible = True
            cmbCatalogo.DataBindItems()
            cmbCatalogo.SelectedIndex = cmbCatalogo.Items.IndexOfValue(dsCampos.Tables(0).Rows(0).Item("relacion_con_normaPID"))
        Else
            cmbCatalogo.Visible = False
            lblCatalogo.Visible = False
            chkMultivalor.Visible = True
            lblMultivalor.Visible = True
        End If


        lblEstado.Text = "Editar"
        lblidIndice.Text = e.CommandArgument
        'TablaCampo.Visible = True
        PantallaCaptura.ShowOnPageLoad = True
    End Sub
    Protected Sub DLCampos_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim sv As New WSArchivo.Service1
        Dim dsCampos As DataSet
        Dim Titulo As String
        Dim dselementos As DataSet
        Dim nDatalist As DataList
        Dim bandel As Boolean = False
        nDatalist = source
        lblElementoID.Text = nDatalist.ID.Substring(8)

        dselementos = sv.ListaArchivo_indicexelemen(e.CommandArgument)

        If dselementos.Tables(0).Rows.Count > 0 Then
            For Each elementos As DataRow In dselementos.Tables(0).Rows

                Dim valor As String = elementos("Valor")

                If Not valor Is DBNull.Value Then
                    If valor.ToString.Length > 0 Then
                        bandel = True
                        Exit For
                    End If
                End If
            Next
        End If

        If bandel Then
            ASPxError.Text = "La variable no puede ser eliminada ya que tiene valores"
        Else
            Dim res = sv.ABC_BajaElementos_Campos(e.CommandArgument)
            If res = 1 Then
                ASPxError.Text = "Se ejecutó correctamente la operación de eliminar solicitada. "
            End If
            'sv.ABC_Normas_Elementos_Campos(WSArchivo.OperacionesABC.operBaja, Request.QueryString("idNorma"), dlAreas.SelectedValue, lblElementoID.Text, e.CommandArgument, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        End If


        dsCampos = sv.ListaNormas_Elementos_Campos(Request.QueryString("idNorma"), dlAreas.SelectedValue, lblElementoID.Text)
        Titulo = CType(nDatalist.Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text
        nDatalist.DataSource = dsCampos
        nDatalist.DataBind()
        CType(nDatalist.Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text = Titulo


    End Sub
    Protected Sub DLCampos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        ASPxError.Text = ""
        If e.CommandName = "Select" Then
            Dim nDatalist As DataList
            nDatalist = source

            Longitud.Text = "0"
            CampoNombre.Text = ""
            Mascara.Text = ""
            Obligatorio.Checked = False
            vVisible.Checked = True

            'TablaCampo.Visible = True
            lblElementoID.Text = nDatalist.ID.Substring(8)
            lblDataListID.Text = nDatalist.ID

            lblElemento.Text = CType(nDatalist.Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text
            lblEstado.Text = "Add"
            PantallaCaptura.ShowOnPageLoad = True
        End If
    End Sub


    Protected Sub dlAreas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dlAreas.SelectedIndexChanged
        ASPxError.Text = ""
        dlAreas.DataBind()
        ElementosVisibles(dlAreas.SelectedValue)
    End Sub

    Protected Sub ElementosVisibles(ByVal idArea As String)
        Dim intI As Integer
        For intI = 0 To PnlElementos.Controls.Count - 1
            If Not PnlElementos.Controls(intI).ID Is Nothing Then
                If PnlElementos.Controls(intI).ID.Substring(0, 8) = "DLCampos" Then
                    CType(PnlElementos.Controls(intI), DataList).Visible = False
                    If CType(PnlElementos.Controls(intI), DataList).TabIndex = idArea Then
                        CType(PnlElementos.Controls(intI), DataList).Visible = True
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub LogOff()
        Response.Redirect("Logoff.aspx", False)
    End Sub



    Protected Sub ASPxButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxButton2.Click
        Dim sv As New WSArchivo.Service1
        Dim dsCampos As DataSet
        Dim Titulo As String
        If Longitud.Value = 0 Then
            Longitud.Value = 20
        End If
        Select Case lblEstado.Text
            Case "Editar"
                If cmbCatalogo.Visible Then
                    If chkMultivalor.Checked Then
                        sv.ABC_Normas_Elementos_Campos(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idNorma"), dlAreas.SelectedValue, lblElementoID.Text, lblidIndice.Text, CampoNombre.Text, 12, Longitud.Text, Mascara.Text, Obligatorio.Checked, 0, 1, 0, 0, 0, vVisible.Checked, cmbCatalogo.SelectedItem.Value, folio_norma.Text.Trim, vPadres.Checked, chkMultivalor.Checked)
                    Else
                        sv.ABC_Normas_Elementos_Campos(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idNorma"), dlAreas.SelectedValue, lblElementoID.Text, lblidIndice.Text, CampoNombre.Text, Tipo.SelectedItem.Value, Longitud.Text, Mascara.Text, Obligatorio.Checked, 0, 1, 0, 0, 0, vVisible.Checked, cmbCatalogo.SelectedItem.Value, folio_norma.Text.Trim, vPadres.Checked, chkMultivalor.Checked)
                    End If

                Else
                    sv.ABC_Normas_Elementos_Campos(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idNorma"), dlAreas.SelectedValue, lblElementoID.Text, lblidIndice.Text, CampoNombre.Text, Tipo.SelectedItem.Value, Longitud.Text, Mascara.Text, Obligatorio.Checked, 0, 1, 0, 0, 0, vVisible.Checked, -1, folio_norma.Text.Trim, vPadres.Checked, 0)
                End If
                ASPxError.Text = "Se ejecutó correctamente la operación de editar solicitada. "
            Case "Add"
                If cmbCatalogo.Visible Then
                    sv.ABC_Normas_Elementos_Campos(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dlAreas.SelectedValue, lblElementoID.Text, 0, CampoNombre.Text, Tipo.SelectedItem.Value, Longitud.Text, Mascara.Text, Obligatorio.Checked, 0, 1, 0, 0, 0, vVisible.Checked, cmbCatalogo.SelectedItem.Value, folio_norma.Text.Trim, vPadres.Checked, 0)
                Else
                    sv.ABC_Normas_Elementos_Campos(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dlAreas.SelectedValue, lblElementoID.Text, 0, CampoNombre.Text, Tipo.SelectedItem.Value, Longitud.Text, Mascara.Text, Obligatorio.Checked, 0, 1, 0, 0, 0, vVisible.Checked, -1, folio_norma.Text.Trim, vPadres.Checked, chkMultivalor.Checked)
                End If
                ASPxError.Text = "Se ejecutó correctamente la operación de añadir solicitada. "
        End Select
        dsCampos = sv.ListaNormas_Elementos_Campos(Request.QueryString("idNorma"), dlAreas.SelectedValue, lblElementoID.Text)
        If Not PnlElementos.FindControl(lblDataListID.Text) Is Nothing Then            
            Titulo = CType(CType(PnlElementos.FindControl(lblDataListID.Text), DataList).Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text
            CType(PnlElementos.FindControl(lblDataListID.Text), DataList).DataSource = dsCampos
            CType(PnlElementos.FindControl(lblDataListID.Text), DataList).DataBind()
            CType(CType(PnlElementos.FindControl(lblDataListID.Text), DataList).Controls(0).Controls(0).FindControl("Titulo"), ASPxLabel).Text = Titulo
        End If

        PantallaCaptura.ShowOnPageLoad = False

    End Sub


    Protected Sub Tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Tipo.SelectedIndexChanged
        Select Case Tipo.Value
            Case 0
                lblLongitud.Visible = True
                Longitud.Visible = True
                lblCatalogo.Visible = False
                cmbCatalogo.Visible = False
                lblMultivalor.Visible = False
                chkMultivalor.Visible = False
            Case 11, 12
                lblLongitud.Visible = False
                Longitud.Visible = False
                lblCatalogo.Visible = True
                cmbCatalogo.Visible = True
                lblMultivalor.Visible = True
                chkMultivalor.Visible = True
            Case Else
                lblLongitud.Visible = False
                Longitud.Visible = False
                lblCatalogo.Visible = False
                cmbCatalogo.Visible = False
                lblMultivalor.Visible = False
                chkMultivalor.Visible = False
        End Select
    End Sub
End Class