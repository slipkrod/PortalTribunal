Imports DevExpress.Web.ASPxTabControl
Partial Public Class Wfm_Indices_Nuevo
    Inherits System.Web.UI.Page
    Dim newidDescripcionPID As Integer

    Private Sub Page_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        AddTabs()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Funciones_Archivo.llenaCamposDefault(PnlElementos, Request.QueryString("idArchivo"), Request.QueryString("idSerie"))
            Funciones_Archivo.llenaCamposCodigo(PnlElementos, Request.QueryString("idArchivo"), Request.QueryString("idSeriePadre"), Request.QueryString("idDescripcion"), Request.QueryString("idSerie"), Request.QueryString("idNivel"), Request.QueryString("idNorma"))
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
                Funciones_Archivo.CreaTablaElemento(PnlElementos, Page, Request.QueryString("idArchivo"), -1, Request.QueryString("idNorma"), dsAreas.Tables(0).Rows(intI).Item("idArea"), _
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


        Dim idnivel = Request.QueryString("idNivel")
        Try
            InsertaenArbol()
            dsNomraCampos = sv.ListaNormas_Elementos_CamposxSerie(Request.QueryString("idSerie"))
            For intI = 0 To dsNomraCampos.Tables(0).Rows.Count - 1
                If Not PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")) Is Nothing Then
                    Select Case dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo")
                        Case 0
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), newidDescripcionPID, 0, idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTexto).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 1
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), newidDescripcionPID, 0, idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoTextoLargo).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 2
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), newidDescripcionPID, 0, idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoFecha).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 3
                            ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoFechas).Fecha_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), newidDescripcionPID, 0, idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 4
                            ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Ini & "/" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Mes_Fin & "/" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoMesAno).Año_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), newidDescripcionPID, 0, idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 5
                            ValorCampo = CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Ini & "-" & CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoPeriodoAno).Año_Fin
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), newidDescripcionPID, 0, idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 6
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), newidDescripcionPID, 0, idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoSI_NO).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 7
                            sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), newidDescripcionPID, 0, idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoEntero).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                        Case 11
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).itemSeleccionado <> -1 Then
                                sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), _
                                        dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), _
                                        newidDescripcionPID, 0, idnivel, Request.QueryString("idSerie"), _
                                        dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCampo, _
                                        dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), _
                                        CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogo).ValorCatalogo)
                            End If
                        Case 12
                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoGridUnbound).GrabaDatos_Archivo(Request.QueryString("idArchivo"), newidDescripcionPID, Request.QueryString("idNorma"), idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"))
                        Case 13
                            If CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).cambiovalor Then
                                sv.ABC_Archivo_indice(WSArchivo.OperacionesABC.operAlta, Request.QueryString("idNorma"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), Request.QueryString("idArchivo"), Request.QueryString("idDescripcion"), 0, idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"), CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoCatalogoISAAR).ValorCampo, dsNomraCampos.Tables(0).Rows(intI).Item("Indice_Tipo"), 0)
                            End If

                        Case 15
                            CType(PnlElementos.FindControl("C" & dsNomraCampos.Tables(0).Rows(intI).Item("idIndice")), CampoMultiSelect).GrabaDatos_Archivo(Request.QueryString("idArchivo"), newidDescripcionPID, Request.QueryString("idNorma"), idnivel, Request.QueryString("idSerie"), dsNomraCampos.Tables(0).Rows(intI).Item("idArea"), dsNomraCampos.Tables(0).Rows(intI).Item("idElemento"), dsNomraCampos.Tables(0).Rows(intI).Item("idIndice"), 0, dsNomraCampos.Tables(0).Rows(intI).Item("relacion_con_normaPID"))
                    End Select
                End If
            Next
            Response.Write("<script language=javascript>var parentWindow = window.parent;parentWindow.RefrescaArbol('2:" & newidDescripcionPID & "');</script>")

        Catch ex As Exception
            ASPxError.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub InsertaenArbol()
        daArbolPadre.InsertParameters("op").DefaultValue = 0
        daArbolPadre.InsertParameters("idArchivo").DefaultValue = Request.QueryString("idArchivo")
        'daArbolPadre.InsertParameters("idDescripcion").DefaultValue=        
        daArbolPadre.InsertParameters("Codigo_clasificacion").DefaultValue = ValorControl("1")
        daArbolPadre.InsertParameters("Descripcion").DefaultValue = ValorControl("2")
        daArbolPadre.InsertParameters("idNivel").DefaultValue = Request.QueryString("idNivel")
        daArbolPadre.InsertParameters("idSerie").DefaultValue = Request.QueryString("idSerie")
        'daArbolPadre.InsertParameters("valuePath").DefaultValue=
        'daArbolPadre.InsertParameters("idUnidadInstalacion").DefaultValue=
        daArbolPadre.InsertParameters("idTipoElemento").DefaultValue = 0
        daArbolPadre.InsertParameters("idDocumentoPID").DefaultValue = Request.QueryString("idDescripcion")

        daArbolPadre.Insert()
    End Sub

    Protected Sub daArbolPadre_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles daArbolPadre.Inserted
        If e.Exception Is Nothing Then
            newidDescripcionPID = e.ReturnValue
        Else
            MsgBox1.ShowMessage(e.Exception.Message)
        End If
    End Sub

    Protected Function ValorControl(ByVal Folio_indice As Integer) As String
        Dim sv As New WSArchivo.Service1
        Dim dsIndiceCodigo As DataSet

        dsIndiceCodigo = sv.ListaSeries_Modelo_indice_sistema(Folio_indice, Request.QueryString("idSerie"))
        If dsIndiceCodigo.Tables(0).Rows.Count > 0 Then
            ValorControl = CType(PnlElementos.FindControl("C" & dsIndiceCodigo.Tables(0).Rows(0).Item("idIndice")), CampoTexto).ValorCampo
        Else
            ValorControl = ""
        End If
    End Function

End Class
