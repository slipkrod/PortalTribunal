Imports DevExpress.Web.ASPxTabControl

Partial Public Class Wfm_Indices_Editar
    Inherits System.Web.UI.Page

    Private Sub Page_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        AddTabs()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Funciones_Archivo.llenaCamposValor(PnlElementos, Request.QueryString("idArchivo"), Request.QueryString("idNorma"), Request.QueryString("idDescripcion"), Request.QueryString("idSerie"), Request.QueryString("idNivel"))
            tableIndices.Visible = True
        End If
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        ASPxError.Text = ""
    End Sub

    Protected Sub AddTabs()
        Dim sv As New WSArchivo.Service1
        Dim dsAreas As DataSet
        Dim intI As Integer
        'PnlElementos.TabPages.Clear()
        If Request.QueryString("idNorma") <> "" Then
            dsAreas = sv.ListaNormas_Elementos_CamposXArea_Serie(-1, Request.QueryString("idSerie"))
            For intI = 0 To dsAreas.Tables(0).Rows.Count - 1
                Funciones_Archivo.CreaTablaElemento(PnlElementos, Page, Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), Request.QueryString("idNorma"), dsAreas.Tables(0).Rows(intI).Item("idArea"), _
                                     dsAreas.Tables(0).Rows(intI).Item("idSerie"))
            Next
        End If
    End Sub



    Protected Sub aspxCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxCancelar.Click
        Response.Redirect("Wfm_Indices_Lectura.aspx?idNorma=" & Request.QueryString("idNorma") & _
                          "&idArchivo=" & Request.QueryString("idArchivo") & _
                          "&idSerie=" & Request.QueryString("idSerie") & _
                          "&idNivel=" & Request.QueryString("idNivel") & _
                          "&idDescripcion=" & Request.QueryString("idDescripcion") & "&Logico=0")
    End Sub

    Protected Sub aspxguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aspxguardar.Click
        Dim sv As New WSArchivo.Service1
        Dim intI As Integer
        Dim dsNomraCampos As DataSet
        Dim ValorCampo As String
        '' Dim nodo As TreeListNode = aspxtreenivel.FindNodeByKeyValue(Request.QueryString("idDescripcion"))
        Dim idnivel = Request.QueryString("idNivel")
        Try
            dsNomraCampos = sv.ListaNormas_Elementos_CamposxSerie(Request.QueryString("idSerie"))
            For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                    Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                        Case 0
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 1
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 2
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 3
                            ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 4
                            ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini & "/" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin & "/" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 5
                            ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 6
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 7
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 11
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).itemSeleccionado <> -1 Then
                                sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), _
                                        dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), _
                                        Request.QueryString("idDescripcion"), 0, idnivel, 0, _
                                        dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo, _
                                        dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), _
                                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCatalogo)
                            End If
                        Case 12
                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGridUnbound).GrabaDatos_Archivo(Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), Request.QueryString("idNorma"), idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"))
                        Case 13
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).cambiovalor Then
                                sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                            End If
                        Case 15
                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoMultiSelect).GrabaDatos_Archivo(Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), Request.QueryString("idNorma"), idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"))
                    End Select
                End If
            Next

            Funciones_Archivo.Actuliza_Codigo_Descripcion_Serie_Arbol(PnlElementos, Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), Request.QueryString("idSerie"))


            MsgBox1.ShowMessage("Los datos se guardaron correctamente")
            Response.Redirect("Wfm_Indices_Lectura.aspx?idNorma=" & Request.QueryString("idNorma") & _
                  "&idArchivo=" & Request.QueryString("idArchivo") & _
                  "&idSerie=" & Request.QueryString("idSerie") & _
                  "&idNivel=" & Request.QueryString("idNivel") & _
                  "&idDescripcion=" & Request.QueryString("idDescripcion") & "&Logico=0")
        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
    End Sub

End Class