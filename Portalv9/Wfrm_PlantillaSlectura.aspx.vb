Imports Portalv9.SvrUsr
Imports System.Data
Imports Portalv9.WSArchivo.Service1
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Partial Public Class Wfrm_PlantillaSlectura
    Inherits System.Web.UI.Page
#Region "Variables privadas"
    Public tTicket As IDTicket
#End Region

    Private Sub Wfrm_PlantillaSlectura_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        CreaTablaElemento()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblTitle.Text = "Archivos"
            Dim objGlobal As New clsGlobal
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If Not objGlobal.TicketValido(tTicket) Then 'Is Nothing Then
                LogOff()
                Exit Sub
            End If
            aspxtreearchivo.DataBind()
          
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

    Private Sub CreaTablaElemento()
        Dim sv As New WSArchivo.Service1
        Dim dsElementos As DataSet
        Dim intI As Integer
        Dim intJ As Integer

        dsElementos = sv.ListaArchivo_Cat_Elementos()
        For intI = 0 To dsElementos.Tables(0).Rows.Count - 1
            Dim TBCampos As New Table
            Dim dsCampos As DataSet

            dsCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intI).Item("idElemento"))


            TBCampos.ID = "TBCampos" & dsElementos.Tables(0).Rows(intI).Item("idElemento")
            TBCampos.BorderColor = Drawing.Color.AliceBlue
            TBCampos.BorderWidth = 0.5
            TBCampos.BorderStyle = BorderStyle.Solid
            TBCampos.Font.Size = 8
            TBCampos.Font.Name = "Arial"


            Dim nFila As New TableHeaderRow
            Dim nCelda As New TableHeaderCell

            nCelda.Width = PnlElementos.Width
            nCelda.Font.Size = 8
            nCelda.Font.Name = "Arial"
            nCelda.Font.Bold = False
            nCelda.CssClass = "DataList_Aqua"
            nCelda.ForeColor = Drawing.Color.Black
            nCelda.Text = dsElementos.Tables(0).Rows(intI).Item("Elemento_descripcion")
            nFila.Cells.Add(nCelda)
            TBCampos.Rows.Add(nFila)

            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1
                Dim nFilaC As New TableRow
                Dim nCeldaC As New TableCell

                Dim nCampoT As New CampoSlectura
                nCampoT = CType(LoadControl("~/WebUsrCtrls/CampoSlectura.ascx"), CampoSlectura)
                nCeldaC.Width = PnlElementos.Width
                nCeldaC.Controls.Add(nCampoT)
                nFilaC.Cells.Add(nCeldaC)
                TBCampos.Rows.Add(nFilaC)
                nCampoT.ID = "C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")
            Next

            TBCampos.Width = PnlElementos.Width
            PnlElementos.Controls.Add(TBCampos)


            For intJ = 0 To dsCampos.Tables(0).Rows.Count - 1

                If Not PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")) Is Nothing Then
                    CType(PnlElementos.FindControl("C" & dsCampos.Tables(0).Rows(intJ).Item("idIndice")), CampoSlectura).TextoCampo = dsCampos.Tables(0).Rows(intJ).Item("Indice_descripcion")
                   
                End If
            Next
        Next

    End Sub



    Protected Sub llenaCampos(ByVal idarchivo As Integer)
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim dsCampoValor As DataSet
        Dim dsElementos As DataSet

        dsElementos = sv.ListaArchivo_Cat_Elementos()
        For intJ = 0 To dsElementos.Tables(0).Rows.Count - 1
            dsNomraCampos = sv.ListaArchivo_Cat_Campos(dsElementos.Tables(0).Rows(intJ).Item("idElemento"))
            For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = ""
                    CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Visible = False
                    dsCampoValor = sv.ListaArchivo_val_Campo(idarchivo, dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"))
                    If dsCampoValor.Tables(0).Rows.Count > 0 Then
                        If Not dsCampoValor.Tables(0).Rows(0).Item("Valor") Is DBNull.Value Then
                            If dsCampoValor.Tables(0).Rows(0).Item("Valor").ToString.Length > 0 Then
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).ValorCampo = dsCampoValor.Tables(0).Rows(0).Item("Valor")
                                CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSlectura).Visible = True
                            End If
                        End If
                    End If
                  

                End If
            Next
        Next
    End Sub

    Private Sub aspxtreearchivo_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs) Handles aspxtreearchivo.HtmlRowPrepared
        If e.NodeKey <> Nothing Then
            If aspxtreearchivo.Nodes.Count = 1 And Not aspxtreearchivo.Nodes.Item(0).HasChildren Then
                llenaCampos(e.NodeKey)
            Else
                If Not aspxtreearchivo.FocusedNode Is Nothing Then
                    llenaCampos(aspxtreearchivo.FocusedNode.Key)
                Else
                    llenaCampos(e.NodeKey)
                End If

            End If
        End If
    End Sub
End Class