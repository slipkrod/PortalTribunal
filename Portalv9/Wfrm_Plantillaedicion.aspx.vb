Imports Portalv9.SvrUsr
Imports System.Data
Imports DevExpress.Web.ASPxEditors
Imports Portalv9.WSArchivo.Service1

Partial Class Wfrm_Plantillaedicion
    Inherits System.Web.UI.Page

#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Protected Sub Page_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        CargaAreas()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Normas->Plantilla  [" & Request.QueryString("Norma") & "]"
            'Regresar.NavigateUrl = "Wfrm_PlantillaHija.aspx?idNorma=" & Request.QueryString("idNorma") & "&Norma=" & HttpUtility.UrlEncode(Request.QueryString("Norma"))
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            DataBind()
        End If

    End Sub

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

    Private Sub CargaAreas()
        Dim sv As New WSArchivo.Service1
        Dim dsAreas As DataSet
        Dim intI As Integer
        sv.Carga_Normas_Plantilla_Campos(Request.QueryString("idPlantilla"), Request.QueryString("idNorma"))
        dsAreas = sv.ListaPlantilla_Areas(Request.QueryString("idPlantilla"), Request.QueryString("idNorma"))
        For intI = 0 To dsAreas.Tables(0).Rows.Count - 1
            CreaTablaElemento(Request.QueryString("idPlantilla"), Request.QueryString("idNorma"), dsAreas.Tables(0).Rows(intI).Item("idArea"))
        Next
        If dsAreas.Tables(0).Rows.Count > 0 Then
            If Not IsPostBack Then
                ElementosVisibles(dsAreas.Tables(0).Rows(0).Item("idArea"))
            End If
        End If
    End Sub
    Private Sub CreaTablaElemento(ByVal idplantilla As Integer, ByVal idNorma As Integer, ByVal idArea As Integer)
        Dim sv As New WSArchivo.Service1
        Dim dsElementos As DataSet
        Dim intI As Integer

        dsElementos = sv.ListaPlantilla_Elementos(idplantilla, idNorma, idArea)
        For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
            Dim DLCampos As New DataList
            Dim dsCampos As DataSet

            dsCampos = sv.ListaPlantilla_Elementos_Campos(idplantilla, idNorma, idArea, dsElementos.Tables(0).Rows(intI).Item("idElemento"))

            DLCampos.ID = "DLCampos" & dsElementos.Tables(0).Rows(intI).Item("idElemento")
            DLCampos.BorderColor = Drawing.Color.AliceBlue
            DLCampos.BorderWidth = 0.5
            DLCampos.BorderStyle = BorderStyle.Solid
            DLCampos.HeaderTemplate = Page.LoadTemplate("WebUsrCtrls/PlantillaHeaderCampoSelect.ascx")
            DLCampos.ItemTemplate = Page.LoadTemplate("WebUsrCtrls/CamposElementoSelect.ascx")
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

            If Not DLCampos.Controls(0).Controls(0).FindControl("Titulosel") Is Nothing Then
                Dim folio As ASPxLabel = CType(DLCampos.Controls(0).Controls(0).FindControl("Foliosel"), ASPxLabel)
                Dim titulo As ASPxLabel = CType(DLCampos.Controls(0).Controls(0).FindControl("Titulosel"), ASPxLabel)
                folio.Text = dsElementos.Tables(0).Rows(intI).Item("folio_norma")
                titulo.Text = dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")
            End If

            If Not DLCampos.Controls(0).Controls(0).FindControl("chkHeaderVisible") Is Nothing Then
                Dim chkVisible As CheckBox = CType(DLCampos.Controls(0).Controls(0).FindControl("chkHeaderVisible"), CheckBox)
                chkVisible.Checked = dsElementos.Tables(0).Rows(intI).Item("visible")
            End If

            PnlElementos.Controls.Add(DLCampos)

        Next
    End Sub

    Protected Sub dlAreas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dlAreas.SelectedIndexChanged
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

    Protected Sub aspxguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxguardar.Click
        Dim intI, intJ, intK As Integer
        Dim sv As New WSArchivo.Service1

        For intJ = 0 To dlAreas.Items.Count - 1
            If CType(dlAreas.Items(intJ).FindControl("chkVisible"), CheckBox).Checked Then
                sv.ABC_Normas_Plantilla_Areas(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idPlantilla"), Request.QueryString("idNorma"), dlAreas.DataKeys(dlAreas.Items(intJ).ItemIndex), 1)
            Else
                sv.ABC_Normas_Plantilla_Areas(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idPlantilla"), Request.QueryString("idNorma"), dlAreas.DataKeys(dlAreas.Items(intJ).ItemIndex), 0)
            End If
        Next
        For intI = 0 To PnlElementos.Controls.Count - 1
            If Not PnlElementos.Controls(intI).ID Is Nothing Then
                If PnlElementos.Controls(intI).ID.Substring(0, 8) = "DLCampos" Then
                    Dim nlista As New DataList
                    nlista = PnlElementos.Controls(intI)
                    If CType(nlista.Controls(0).Controls(0).FindControl("chkHeaderVisible"), CheckBox).Checked Then
                        sv.ABC_Normas_Plantilla_Elementos(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idPlantilla"), Request.QueryString("idNorma"), nlista.TabIndex, nlista.ID.Substring(8), 1)
                    Else
                        sv.ABC_Normas_Plantilla_Elementos(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idPlantilla"), Request.QueryString("idNorma"), nlista.TabIndex, nlista.ID.Substring(8), 0)
                    End If

                    For intK = 0 To nlista.Items.Count - 1
                        If CType(nlista.Items(intK).Controls(0).FindControl("chkVisible"), CheckBox).Checked Then
                            sv.ABC_Normas_Plantilla_Campos(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idPlantilla"), Request.QueryString("idNorma"), nlista.TabIndex, nlista.ID.Substring(8), nlista.DataKeys(nlista.Items(intK).ItemIndex), 1)
                        Else
                            sv.ABC_Normas_Plantilla_Campos(WSArchivo.OperacionesABC.operCambio, Request.QueryString("idPlantilla"), Request.QueryString("idNorma"), nlista.TabIndex, nlista.ID.Substring(8), nlista.DataKeys(nlista.Items(intK).ItemIndex), 0)
                        End If

                    Next
                End If
            End If
        Next
        Response.Redirect("Wfrm_PlantillaHija.aspx?idNorma=" & Request.QueryString("idNorma") & "&Norma=" & HttpUtility.UrlEncode(Request.QueryString("Norma")))

    End Sub
End Class
