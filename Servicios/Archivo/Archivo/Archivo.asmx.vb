Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data
Imports Archivo
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la siguiente línea.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Service1
    Inherits System.Web.Services.WebService

    Private Const mstrModNombre As String = "Archivo"

    <WebMethod()> Public Sub ABC_Archivo_Fisico(ByVal op As OperacionesABC, ByVal idArchivo_Fisico As Integer, ByVal Archivo_Fisico_Descripcion As String)
        Const strProcName As String = "ABC_Archivo_Fisico"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Archivo_Fisico(op, idArchivo_Fisico, Archivo_Fisico_Descripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub ABC_Archivo_Fisico_Unidades(ByVal op As OperacionesABC, ByVal idUnidad_medida As String, ByVal Unidad_medida_descripcion As String)
        Const strProcName As String = "ABC_Archivo_Fisico_Unidades"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Archivo_Fisico_Unidades(op, idUnidad_medida, Unidad_medida_descripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub
    <WebMethod()> Public Sub ABC_Archivo_Fisico_elemento(ByVal op As OperacionesABC, ByVal idTipoElemento As Integer, ByVal TipoElemento As String)
        Const strProcName As String = "ABC_Archivo_Fisico_elemento"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Archivo_Fisico_elemento(op, idTipoElemento, TipoElemento)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub ABC_Archivo_Fisico_Estructura(ByVal op As OperacionesABC, ByVal idArchivo_Fisico As Integer, ByVal idEstructura As Integer, ByVal Descripcion As String, ByVal idTipoElemento As Integer, ByVal idEstructuraPID As Integer, ByVal Alto As Double, ByVal Ancho As Double, ByVal Fondo As Double, ByVal idUnidad_medida As String)
        Const strProcName As String = "ABC_Archivo_Fisico_Estructura"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Archivo_Fisico_Estructura(op, idArchivo_Fisico, idEstructura, Descripcion, idTipoElemento, idEstructuraPID, Alto, Ancho, Fondo, idUnidad_medida)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub ABC_Normas(ByVal op As OperacionesABC, ByVal idNorma As Integer, ByVal Norma_descripcion As String)
        Const strProcName As String = "ABC_Normas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Normas(op, idNorma, Norma_descripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function ABC_Filtros_Master(ByVal op As OperacionesABC, ByVal idFiltro As Integer, ByVal idArchivo As Integer, ByVal idSerie As Integer, ByVal Nombre As String, ByVal FAlias As String) As Integer
        Const strProcName As String = "ABC_Filtros_Master"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Filtros_Master(op, idFiltro, idArchivo, idSerie, Nombre, FAlias)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function

    <WebMethod()> Public Function ABC_Filtros(ByVal op As OperacionesABC, ByVal idFiltro As Integer, ByVal Parentesis As String, ByVal ParentesisDesc As String, ByVal AndOr As String, ByVal AndOrDesc As String, ByVal FieldName As String, ByVal FieldTitle As String, ByVal FieldType As String, ByVal Operador As String, ByVal OperadorDesc As String, ByVal Valor1 As String, ByVal Valor2 As String, ByVal ValorDesc As String, ByVal idIndice As Integer) As Integer
        Const strProcName As String = "ABC_Filtros"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Filtros(op, idFiltro, Parentesis, ParentesisDesc, AndOr, AndOrDesc, FieldName, FieldTitle, FieldType, Operador, OperadorDesc, Valor1, Valor2, ValorDesc, idIndice)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function


    <WebMethod()> Public Function ABC_Indices_Sistema(ByVal op As OperacionesABC, ByVal idIndice_Sistema As Integer, ByVal Area_Recomendada As String, ByVal Elemento_Recomendado As String, ByVal Indice_descripcion As String, ByVal Indice_Tipo As Integer, ByVal Indice_LongitudMax As Integer, ByVal Indice_Mascara As String, ByVal Indice_PK As Integer, ByVal Indice_Obligatorio As Integer, ByVal Indice_Unico As Integer, ByVal Indice_buscar As Integer, ByVal Indice_CopiarValor As Integer, ByVal Indice_EsAutoincremental As Integer, ByVal IndiceReadOnly As Integer, ByVal Indice_Visible As Integer, ByVal relacion_con_normaPID As Integer, ByVal folio_norma As String, ByVal Indice_ValorInicial As Integer, ByVal Indice_ValorActual As Integer, ByVal Indice_ValorMaximo As Integer, ByVal Muestra_padres As Integer, ByVal Multi_valor As Integer, ByVal Asigned As Integer, ByVal Asigned_value As String) As Integer
        Const strProcName As String = "ABC_Indices_Sistema"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Indices_Sistema(op, idIndice_Sistema, Area_Recomendada, Elemento_Recomendado, Indice_descripcion, Indice_Tipo, Indice_LongitudMax, Indice_Mascara, Indice_PK, Indice_Obligatorio, Indice_Unico, Indice_buscar, Indice_CopiarValor, Indice_EsAutoincremental, IndiceReadOnly, Indice_Visible, relacion_con_normaPID, folio_norma, Indice_ValorInicial, Indice_ValorActual, Indice_ValorMaximo, Muestra_padres, Multi_valor, Asigned, Asigned_value)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function

    <WebMethod()> Public Function ListaFiltros_Master(ByVal idFiltro As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaFiltros_Master"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaFiltros_Master(idFiltro)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaOperadores(ByVal OpType As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaOperadores"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaOperadores(OpType)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaIndices_Sistema(ByVal idIndice_Sistema As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaIndices_Sistema"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.ListaIndices_Sistema(idIndice_Sistema)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaIndices_SistemaxNorma(ByVal idNorma As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaIndices_SistemaxNorma"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.ListaIndices_SistemaxNorma(idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaFiltros(ByVal idFiltro As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaFiltros"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaFiltros(idFiltro)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaFiltros_Master_All(ByVal idFiltro As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaFiltros_Master_All"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaFiltros_Master_All(idFiltro)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaFiltros_Indices(ByVal idNorma As Integer, ByVal idNivel As Integer, ByVal idSerie As Integer) As DataSet
        Const strProcName As String = "ListaFiltros_Indices"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaFiltros_Indices(idNorma, idNivel, idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaTraspasos_ArchivoOrigen(ByVal idTraspasos As Integer, ByVal idArchivo As Integer) As DataSet
        Const strProcName As String = "ListaTraspasos_ArchivoOrigen"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaTraspasos_ArchivoOrigen(idTraspasos, idArchivo)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Lista_Archivo_Fisico() As System.Data.DataSet
        Const strProcName As String = "Lista_Archivo_Fisico"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Lista_Archivo_Fisico()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNormas() As System.Data.DataSet
        Const strProcName As String = "ListaNormas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ABC_Normas_Niveles(ByVal op As OperacionesABC, ByVal idNorma As Integer, ByVal idNivel As Integer, ByVal Nivel As Integer, ByVal valuePath As String, ByVal Nivel_descripcion As String, ByVal idDocumentoPID As Integer, ByVal Imagen_open As String, ByVal Imagen_close As String, ByVal Nivel_Logico_Fisico As Integer) As Integer
        Const strProcName As String = "ABC_Normas_Niveles"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Normas_Niveles(op, idNorma, idNivel, Nivel, valuePath, Nivel_descripcion, idDocumentoPID, Imagen_open, Imagen_close, Nivel_Logico_Fisico)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function
    <WebMethod()> Public Function Normas_Niveles_Del(ByVal idNorma As Integer, ByVal idNivel As Integer) As Integer
        Const strProcName As String = "Normas_Niveles_Del"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.Normas_Niveles_Del(idNorma, idNivel)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function

    <WebMethod()> Public Function Normas_Niveles_Up(ByVal idNorma As Integer, ByVal idNivel As Integer, ByVal valuePath As String, ByVal Nivel_descripcion As String, ByVal idDocumentoPID As Integer, ByVal Imagen_open As String, ByVal Imagen_close As String, ByVal Nivel_Logico_Fisico As Integer) As Integer
        Const strProcName As String = "Normas_Niveles_Del"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.Normas_Niveles_up(idNorma, idNivel, valuePath, Nivel_descripcion, idDocumentoPID, Imagen_open, Imagen_close, Nivel_Logico_Fisico)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function

    <WebMethod()> Public Function ListaNormas_Niveles(ByVal idNorma As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Niveles"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Niveles(idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNormas_Niveles_Hijos(ByVal idNorma As Integer, ByVal Nivel_padre As Integer, ByVal Nivel_Logico_Fisico As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Niveles"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Niveles_Hijos(idNorma, Nivel_padre, Nivel_Logico_Fisico)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNorma_Nivel(ByVal idNorma As Integer, ByVal idNivel As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNorma_Nivel"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNorma_Nivel(idNorma, idNivel)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaNorma_Nivel_SerieyDocumento(ByVal idNorma As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNorma_Nivel_SerieyDocumento"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNorma_Nivel_SerieyDocumento(idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Sub ABC_Normas_Areas(ByVal op As OperacionesABC, ByVal idNorma As Integer, ByVal idArea As Integer, ByVal Area_descripcion As String, ByVal folio_norma As String)
        Const strProcName As String = "ABC_Normas_Areas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Normas_Areas(op, idNorma, idArea, Area_descripcion, folio_norma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub
    <WebMethod()> Public Function ListaNormas_Areas(ByVal idNorma As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Niveles"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Areas(idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNormas_Areas_Especial(ByVal idNorma As Integer, ByVal idplantilla As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Areas_Especial"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Areas_Especial(idNorma, idplantilla)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Sub ABC_Normas_Elementos(ByVal op As OperacionesABC, ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idElemento As Integer, ByVal Elemento_descripcion As String, ByVal folio_norma As String)
        Const strProcName As String = "ABC_Normas_Elementos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Normas_Elementos(op, idNorma, idArea, idElemento, Elemento_descripcion, folio_norma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub
    <WebMethod()> Public Function ListaNormas_Elementos(ByVal idNorma As Integer, ByVal idArea As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos(idNorma, idArea)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaNormas_ElementosxSeriexElemento_Visible(ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idSerie As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_ElementosxSeriexElemento_Visible"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_ElementosxSeriexElemento_Visible(idNorma, idArea, idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaNormas_Elementos_Especial(ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idPlantilla As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_Especial"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_Especial(idNorma, idArea, idPlantilla)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Sub ABC_Normas_Elementos_Campos(ByVal op As OperacionesABC, ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idElemento As Integer, ByVal idNivel As Integer, ByVal idSerie As Integer, ByVal idIndice As Integer, ByVal Indice_descripcion As String, ByVal Indice_Tipo As Integer, ByVal Indice_LongitudMax As Integer, ByVal Indice_Mascara As String, ByVal Indice_PK As Integer, ByVal Indice_Obligatorio As Integer, ByVal Indice_Unico As Integer, ByVal Indice_buscar As Integer, ByVal Indice_CopiarValor As Integer, ByVal Indice_EsAutoincremental As Integer, ByVal IndiceReadOnly As Integer, ByVal Indice_Visible As Integer, ByVal Indice_Visible_Concentracion As Integer, ByVal Indice_Visible_Historico As Integer, ByVal Indice_Hereda_valor As Integer, ByVal relacion_con_normaPID As Integer, ByVal folio_norma As String, ByVal Muestra_padres As Integer, ByVal Multi_valor As Integer, ByVal Asigned As Integer, ByVal Asigned_value As String, ByVal Indice_Sistema As Integer, ByVal idIndice_Sistema As Integer)
        Const strProcName As String = "ABC_Normas_Elementos_Campos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Normas_Elementos_Campos(op, idNorma, idArea, idElemento, idNivel, idSerie, idIndice, Indice_descripcion, Indice_Tipo, Indice_LongitudMax, Indice_Mascara, Indice_PK, Indice_Obligatorio, Indice_Unico, Indice_buscar, Indice_CopiarValor, Indice_EsAutoincremental, IndiceReadOnly, Indice_Visible, Indice_Visible_Concentracion, Indice_Visible_Historico, Indice_Hereda_valor, relacion_con_normaPID, folio_norma, Muestra_padres, Multi_valor, Asigned, Asigned_value, Indice_Sistema, idIndice_Sistema)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub


    <WebMethod()> Public Function ListaNormas_Campos(ByVal idNorma As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Campos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Campos(idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNormas_Elementos_CamposxSerie(ByVal idSerie As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_Campos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_CamposxSerie(idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaNormas_Elementos_CamposxSerie_Visibles(ByVal idSerie As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_CamposxSerie_Visibles"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_CamposxSerie_Visibles(idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNormas_Elementos_CamposxSerie_Defaults(ByVal idSerie As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_CamposxSerie_Defaults"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_CamposxSerie_Defaults(idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNormas_Elementos_CamposxSerie_Heredar(ByVal idSerie As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_CamposxSerie_Heredar"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_CamposxSerie_Heredar(idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNormas_Elementos_CamposxSerie_idIndiceNorma(ByVal idSerie As Integer, ByVal idIndice_Norma As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_CamposxSerie_idIndiceNorma"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_CamposxSerie_idIndiceNorma(idSerie, idIndice_Norma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNormas_Elementos_CamposXArea_Serie(ByVal idArea As Integer, ByVal idSerie As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_CamposXArea_Serie"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_CamposXArea_Serie(idArea, idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaNormas_Elementos_CamposxSeriexElemento(ByVal idSerie As Integer, ByVal idElemento As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_CamposxSeriexElemento"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_CamposxSeriexElemento(idSerie, idElemento)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNormas_Elementos_CamposxSeriexElemento_Visible(ByVal idSerie As Integer, ByVal idElemento As Integer, ByVal Tipo_Archivo As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_CamposxSeriexElemento_Visible"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_CamposxSeriexElemento_Visible(idSerie, idElemento, Tipo_Archivo)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function


    <WebMethod()> Public Function ListaNormas_Elementos_Campos(ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idElemento As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_Campos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_Campos(idNorma, idArea, idElemento)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNormas_Elementos_Campos_Especial(ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idElemento As Integer, ByVal idPlantilla As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_Campos_Especial"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_Campos_Especial(idNorma, idArea, idElemento, idPlantilla)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaNormas_Elementos_Campo(ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idElemento As Integer, ByVal idIndice As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_Campo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_Campo(idNorma, idArea, idElemento, idIndice)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNormas_Elementos_CampoxSerie_and_PK(ByVal idSerie As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNormas_Elementos_CampoxSerie_and_PK"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNormas_Elementos_CampoxSerie_and_PK(idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Sub ABC_Archivos(ByVal op As OperacionesABC, ByVal idArchivo As Integer, ByVal idNorma As Integer, ByVal Archivo_descripcion As String, ByVal Codigo_clasificacion As String, ByVal Tipo_Archivo As Integer)
        Const strProcName As String = "ABC_Archivos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Archivos(op, idArchivo, idNorma, Archivo_descripcion, Codigo_clasificacion, Tipo_Archivo)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub
    <WebMethod()> Public Function ListaArchivos_Tipo(ByVal Tipo_Archivo As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivos_Tipo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivos_Tipo(Tipo_Archivo)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaArchivos() As System.Data.DataSet
        Const strProcName As String = "ListaArchivos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivos()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function


    <WebMethod()> Public Function ListaArchivo(ByVal idArchivo As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo(idArchivo)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ABC_Archivo_Descripciones(ByVal op As OperacionesABC, ByVal idArchivo As Integer, ByVal idDescripcion As Integer, ByVal Codigo_clasificacion As String, ByVal idNivel As Integer, ByVal idSerie As Integer, ByVal valuePath As String, ByVal idUnidadInstalacion As Integer, ByVal Descripcion As String, ByVal idTipoElemento As Integer, ByVal idDocumentoPID As Integer) As Integer
        Const strProcName As String = "ABC_Archivo_Descripciones"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Archivo_Descripciones(op, idArchivo, idDescripcion, Codigo_clasificacion, idNivel, idSerie, valuePath, idUnidadInstalacion, Descripcion, idTipoElemento, idDocumentoPID)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function
    <WebMethod()> Public Function ListaArchivo_Descripciones(ByVal idArchivo As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_Descripciones"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Descripciones(idArchivo)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaArchivo_Descripciones_Nivel_Logico(ByVal idArchivo As Integer, ByVal Nivel_Logico_Fisico As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_Descripciones_Nivel_Logico"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Descripciones_Nivel_Logico(idArchivo, Nivel_Logico_Fisico)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaArchivo_Descripciones_idSerie(ByVal idArchivo As Integer, ByVal idNivel As Integer, ByVal idSerie As Integer, ByVal idDocumentoPID As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_Descripciones_idSerie"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Descripciones_idSerie(idArchivo, idNivel, idSerie, idDocumentoPID)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaArchivo_Descripciones_idDescripcion(ByVal idArchivo As Integer, ByVal idDescripcion As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_Descripciones_idDescripcion"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Descripciones_idDescripcion(idArchivo, idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaArchivo_Descripciones_idDescripcion_Hijos(ByVal idArchivo As Integer, ByVal idDescripcion As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_Descripciones_idDescripcion_Hijos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Descripciones_idDescripcion_Hijos(idArchivo, idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaArchivo_Codigo_clasificacion(ByVal idArchivo As Integer, ByVal Codigo_clasificacion As String) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_Codigo_clasificacion"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Codigo_clasificacion(idArchivo, Codigo_clasificacion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Func_GeneraCodigoDeSeries(ByVal idArchivo As Integer, ByVal FormatoCodigo As Integer, ByVal idDocumentoPID As Integer) As Integer
        Const strProcName As String = "Func_GeneraCodigoDeSeries"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            Return pBD.Func_GeneraCodigoDeSeries(idArchivo, FormatoCodigo, idDocumentoPID)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return 1
    End Function

    <WebMethod()> Public Function ListaArchivo_Descripciones_nivel(ByVal idArchivo As Integer, ByVal idNivel As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_Descripciones_nivel"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Descripciones_nivel(idArchivo, idNivel)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaArchivo_indice(ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idElemento As Integer, ByVal idIndice As Integer, ByVal idArchivo As Integer, ByVal idDescripcion As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_indice"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_indice(idNorma, idArea, idElemento, idIndice, idArchivo, idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaArchivo_indicexFolio_norma(ByVal idNorma As Integer, ByVal idSerie As Integer, ByVal Folio_norma As String) As DataSet
        Const strProcName As String = "ListaArchivo_indicexFolio_norma"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_indicexFolio_norma(idNorma, idSerie, Folio_norma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function


    <WebMethod()> Public Function ABC_Archivo_indice(ByVal op As Integer, ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idElemento As Integer, ByVal idIndice As Integer, ByVal idArchivo As Integer, ByVal idDescripcion As Integer, ByVal idFolio As Integer, ByVal idNivel As Integer, ByVal idSerie As Integer, ByVal relacion_con_normaPID As Integer, ByVal Valor As String, ByVal Indice_Tipo As Integer, ByVal IDCatalogo_item As Integer) As Integer
        Const strProcName As String = "ABC_Archivo_Descripciones"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Archivo_indice(op, idNorma, idArea, idElemento, idIndice, idArchivo, idDescripcion, idFolio, idNivel, idSerie, relacion_con_normaPID, Valor, Indice_Tipo, IDCatalogo_item)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function

    <WebMethod()> Public Function ListaNorma_Plantillas(ByVal idNorma As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNorma_Plantillas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNorma_Plantillas(idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaNorma_Plantilla(ByVal idNorma As Integer, ByVal idPlantilla As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNorma_Plantilla"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNorma_Plantilla(idNorma, idPlantilla)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ABC_Normas_plantillas(ByVal op As OperacionesABC, ByVal idNorma As Integer, ByVal idPlantilla As Integer, ByVal Plantilla_descripcion As String) As Integer
        Const strProcName As String = "ABC_Normas_plantillas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Normas_plantillas(op, idNorma, idPlantilla, Plantilla_descripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function

    <WebMethod()> Public Sub ABC_Normas_Plantilla_Areas(ByVal op As OperacionesABC, ByVal idPlantilla As Integer, ByVal idNorma As Integer, ByVal idArea As Integer, ByVal Visible As Integer)
        Const strProcName As String = "ABC_Normas_Plantilla_Areas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Normas_Plantilla_Areas(op, idPlantilla, idNorma, idArea, Visible)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub
    <WebMethod()> Public Sub ABC_Normas_Plantilla_Elementos(ByVal op As OperacionesABC, ByVal idPlantilla As Integer, ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idElemento As Integer, ByVal Visible As Integer)
        Const strProcName As String = "ABC_Normas_Plantilla_Elementos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Normas_Plantilla_Elementos(op, idPlantilla, idNorma, idArea, idElemento, Visible)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub
    <WebMethod()> Public Sub ABC_Normas_Plantilla_Campos(ByVal op As OperacionesABC, ByVal idPlantilla As Integer, ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idElemento As Integer, ByVal idIndice As Integer, ByVal Visible As Integer)
        Const strProcName As String = "ABC_Normas_Plantilla_Campos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Normas_Plantilla_Campos(op, idPlantilla, idNorma, idArea, idElemento, idIndice, Visible)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub Carga_Normas_Plantilla_Campos(ByVal idPlantilla As Integer, ByVal idNorma As Integer)
        Const strProcName As String = "Carga_Normas_Plantilla_Campos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.Carga_Normas_Plantilla_Campos(idPlantilla, idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function ListaPlantilla_Areas(ByVal idPlantilla As Integer, ByVal idNorma As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaPlantilla_Areas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaPlantilla_Areas(idPlantilla, idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaPlantilla_Elementos(ByVal idPlantilla As Integer, ByVal idNorma As Integer, ByVal idArea As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaPlantilla_Elementos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaPlantilla_Elementos(idPlantilla, idNorma, idArea)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaPlantilla_Elementos_Campos(ByVal idPlantilla As Integer, ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idElemento As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaPlantilla_Elementos_Campos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaPlantilla_Elementos_Campos(idPlantilla, idNorma, idArea, idElemento)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Archivo_Descripciones_Del(ByVal idArchivo As Integer, ByVal idDescripcion As Integer) As Integer
        Const strProcName As String = "Archivo_Descripciones_Del"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.Archivo_Descripciones_Del(idArchivo, idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function

    <WebMethod()> Public Function ListaArchivo_Cat_Elementos() As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_Cat_Elementos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Cat_Elementos()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ABC_Archivo_Cat_Elementos(ByVal op As OperacionesABC, ByVal idElemento As Integer, ByVal Elemento_descripcion As String) As Integer
        Const strProcName As String = "ABC_Archivo_Cat_Elementos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Archivo_Cat_Elementos(op, idElemento, Elemento_descripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function

    <WebMethod()> Public Function ListaArchivo_Cat_Campos(ByVal idElemento As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_Cat_Campos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Cat_Campos(idElemento)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaArchivo_Cat_Campo(ByVal idElemento As Integer, ByVal idIndice As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_Cat_Campo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Cat_Campo(idElemento, idIndice)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Sub ABC_Archivo_Elementos_Campos(ByVal op As OperacionesABC, ByVal idElemento As Integer, ByVal idIndice As Integer, ByVal Indice_descripcion As String, ByVal Indice_Tipo As Integer, ByVal Indice_LongitudMax As Integer, ByVal Indice_Mascara As String, ByVal Indice_Obligatorio As Integer, ByVal Indice_Unico As Integer, ByVal Indice_buscar As Integer, ByVal Indice_CopiarValor As Integer, ByVal Indice_EsAutoincremental As Integer, ByVal IndiceReadOnly As Integer, ByVal Indice_Visible As Integer, ByVal relacion_con_normaPID As Integer, _
                ByVal Indice_Sistema As Integer, ByVal idIndice_Sistema As Integer)
        Const strProcName As String = "ABC_Archivo_Elementos_Campos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Archivo_Elementos_Campos(op, idElemento, idIndice, Indice_descripcion, Indice_Tipo, Indice_LongitudMax, Indice_Mascara, Indice_Obligatorio, Indice_Unico, Indice_buscar, Indice_CopiarValor, Indice_EsAutoincremental, IndiceReadOnly, Indice_Visible, relacion_con_normaPID, Indice_Sistema, idIndice_Sistema)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub


    <WebMethod()> Public Function ListaArchivo_val_Campo(ByVal idArchivo As Integer, ByVal idElemento As Integer, ByVal idIndice As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_val_Campo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_val_Campo(idArchivo, idElemento, idIndice)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Sub ABC_Archivo_val_campo(ByVal op As OperacionesABC, ByVal idArchivo As Integer, ByVal idElemento As Integer, ByVal idIndice As Integer, ByVal Indice_Tipo As Integer, ByVal relacion_con_normaPID As Integer, ByVal Valor As Object)
        Const strProcName As String = "ABC_Archivo_val_campo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)

        Try
            pBD.ABC_Archivo_val_campo(op, idArchivo, idElemento, idIndice, Indice_Tipo, relacion_con_normaPID, Valor)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function ListaArchivo_Niveles_Norma(ByVal idArchivo As Integer, ByVal Nivel_Logico_Fisico As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_NivelesNorma"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Niveles_Norma(idArchivo, Nivel_Logico_Fisico)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function


    <WebMethod()> Public Function Busca_enArchivo(ByVal idArchivo As Integer, ByVal Palabra As String) As System.Data.DataSet
        Const strProcName As String = "Busca_enArchivo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Busca_enArchivo(idArchivo, Palabra)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaArchivo_indicexelemen(ByVal idIndice As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_indicexelemen"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_indicexelemen(idIndice)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ABC_BajaElementos_Campos(ByVal idIndice As Integer) As Integer
        Const strProcName As String = "ABC_BajaElementos_Campos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nRes As Integer = 0

        Try
            nRes = pBD.ABC_BajaElementos_Campos(idIndice)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nRes
    End Function

    <WebMethod()> Public Function ListaArchivo_val_Campo_bus(ByVal idElemento As Integer, ByVal idIndice As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_val_Campo_bus"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_val_Campo_bus(idElemento, idIndice)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Reportecgca_datos(ByVal idNorma As Integer, ByVal idArchivo As Integer) As System.Data.DataSet
        Const strProcName As String = "Reportecgca_datos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Reportecgca_datos(idNorma, idArchivo)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Reportegs_datos(ByVal idArchivo As Integer, ByVal idNorma As Integer) As DataSet
        Const strProcName As String = "Reportegs_datos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Reportegs_datos(idArchivo, idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function


    <WebMethod()> Public Function Lista_Normas_relacion() As System.Data.DataSet
        Const strProcName As String = "Lista_Normas_relacion"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Lista_Normas_relacion()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Lista_Normas_ISAAR() As System.Data.DataSet
        Const strProcName As String = "Lista_Normas_ISAAR"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Lista_Normas_ISAAR()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Lista_Normas_ISAD() As System.Data.DataSet
        Const strProcName As String = "Lista_Normas_ISAD"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Lista_Normas_ISAD()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function





    <WebMethod()> Public Sub ABC_Normas_relacion(ByVal op As OperacionesABC, ByVal idNr As Integer, ByVal idisad As String, ByVal idisaar As String, ByVal descripcion As String)
        Const strProcName As String = "ABC_Normas_relacion"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Normas_relacion(op, idNr, idisad, idisaar, descripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function ListaNivel_Plantilla_captura(ByVal idNorma As Integer, ByVal idNivel As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNivel_Plantilla_captura"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNivel_Plantilla_captura(idNorma, idNivel)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Sub ABC_Niveles_Plantilla_Captura(ByVal op As OperacionesABC, ByVal idNorma As Integer, ByVal idNivel As Integer, ByVal idPlantillaold As Integer, ByVal idPlantillanew As Integer)
        Const strProcName As String = "ABC_Niveles_Plantilla_Captura"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Niveles_Plantilla_Captura(op, idNorma, idNivel, idPlantillaold, idPlantillanew)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function Func_Concatena_Indices_Grid(ByVal idIndice_Norma As Integer, ByVal relacion_con_normaPID As Integer, ByVal idArchivo As Integer, ByVal idDescripcion As Integer) As System.Data.DataSet
        Const strProcName As String = "Func_Concatena_Indices_Grid"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Func_Concatena_Indices_Grid(idIndice_Norma, relacion_con_normaPID, idArchivo, idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function Func_Concatena_Indices_Grid_Suma(ByVal idIndice_Norma As Integer, ByVal relacion_con_normaPID As Integer, ByVal idArchivo As Integer, ByVal idDescripcion As Integer) As System.Data.DataSet
        Const strProcName As String = "Func_Concatena_Indices_Grid_Suma"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Func_Concatena_Indices_Grid_Suma(idIndice_Norma, relacion_con_normaPID, idArchivo, idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function


    <WebMethod()> Public Function Func_Concatena_padres(ByVal idArchivo As Integer, ByVal idIndice As Integer, ByVal idFolio As Integer) As System.Data.DataSet
        Const strProcName As String = "Func_Concatena_padres"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Func_Concatena_padres(idArchivo, idIndice, idFolio)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Func_Maximo_valor(ByVal idArchivo As Integer, ByVal idIndice As Integer, ByVal idDescripcion As Integer) As System.Data.DataSet
        Const strProcName As String = "Func_Maximo_valor"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Func_Maximo_valor(idArchivo, idIndice, idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Func_Minimo_valor(ByVal idArchivo As Integer, ByVal idIndice As Integer, ByVal idDescripcion As Integer) As System.Data.DataSet
        Const strProcName As String = "Func_Minimo_valor"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Func_Minimo_valor(idArchivo, idIndice, idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Func_Suma_valor_hijos(ByVal idArchivo As Integer, ByVal idIndice As Integer, ByVal idDescripcion As Integer) As System.Data.DataSet
        Const strProcName As String = "Func_Suma_valor_hijos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Func_Suma_valor_hijos(idArchivo, idIndice, idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ABC_Catalogo(ByVal op As OperacionesABC, ByVal IDCatalogo As Integer, ByVal Descripcion As String, ByVal A1_Titulo As String, ByVal A1_Ancho As Integer, ByVal A1_Visible As Integer, ByVal A2_Titulo As String, ByVal A2_Ancho As Integer, ByVal A2_Visible As Integer, ByVal A3_Titulo As String, ByVal A3_Ancho As Integer, ByVal A3_Visible As Integer, ByVal Tipo_Dato As Integer, ByVal Valores_Aceptados As Integer) As Integer
        Const strProcName As String = "ABC_Catalogo_Alta"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Catalogo(op, IDCatalogo, Descripcion, A1_Titulo, A1_Ancho, A1_Visible, A2_Titulo, A2_Ancho, A2_Visible, A3_Titulo, A3_Ancho, A3_Visible, Tipo_Dato, Valores_Aceptados)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function
    <WebMethod()> Public Function ListaCatalogo() As System.Data.DataSet
        Const strProcName As String = "ListaCatalogo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaCatalogo()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ABC_Catalogo_Datos(ByVal op As OperacionesABC, ByVal IDCatalogo As Integer, ByVal IDCatalogo_item As Integer, ByVal Descripcion As String, ByVal A1 As String, ByVal A2 As String, ByVal A3 As String) As Integer
        Const strProcName As String = "ABC_Catalogo_Datos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Catalogo_Datos(op, IDCatalogo, IDCatalogo_item, Descripcion, A1, A2, A3)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function

    <WebMethod()> Public Function ListaCatalogo_Datos(ByVal IDCatalogo As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaCatalogo_Datos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaCatalogo_Datos(IDCatalogo)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaCatalogo_DatosXIndice(ByVal IDCatalogo As Integer, ByVal idIndice As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaCatalogo_DatosXIndice"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaCatalogo_DatosXIndice(IDCatalogo, idIndice)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Sub Archivos_Del(ByVal idNorma As Integer, ByVal idArchivo As Integer)
        Const strProcName As String = "Archivos_Del"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            pBD.Archivos_Del(idNorma, idArchivo)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try

    End Sub

    <WebMethod()> Public Function ListaNorma_Descripciones(ByVal idNorma As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaNorma_Descripciones"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaNorma_Descripciones(idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function




    <WebMethod()> Public Function ABC_ISAAR(ByVal op As OperacionesABC, ByVal idISAAR As Integer, ByVal Tipo_de_entidad As String, ByVal Formas_autorizadas_nombre As String, ByVal Formas_paralelas_nombre As String, ByVal Formas_normalizadas_nombre As String, ByVal Otras_formas_nombre As String, ByVal Identificadores_para_instituciones As String, ByVal Fechas_de_existencia As Date, ByVal Historia As String, ByVal Lugares As String, ByVal Estatuto_jurídico As String, ByVal Funciones_ocupaciones_actividades As String, ByVal Atribuciones_Fuentes_legales As String, ByVal Estructuras_internas_Genealogía As String, ByVal Contexto_general As String, ByVal Identificador_registro_autoridad As String, ByVal Identificadores_institución As String, ByVal Reglas_convenciones As String, ByVal Estado_elaboración As String, ByVal Nivel_detalle As String, ByVal Fechas_creación_revisión_eliminación As Date, ByVal Lenguas_escrituras As String, ByVal Fuentes As String, ByVal Notas_de_mantenimiento As String) As Integer
        Const strProcName As String = "ABC_ISAAR"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_ISAAR(op, idISAAR, Tipo_de_entidad, Formas_autorizadas_nombre, Formas_paralelas_nombre, Formas_normalizadas_nombre, Otras_formas_nombre, Identificadores_para_instituciones, Fechas_de_existencia, Historia, Lugares, Estatuto_jurídico, Funciones_ocupaciones_actividades, Atribuciones_Fuentes_legales, Estructuras_internas_Genealogía, Contexto_general, Identificador_registro_autoridad, Identificadores_institución, Reglas_convenciones, Estado_elaboración, Nivel_detalle, Fechas_creación_revisión_eliminación, Lenguas_escrituras, Fuentes, Notas_de_mantenimiento)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function


    <WebMethod()> Public Sub ABC_ISAAR_Relaciones(ByVal op As OperacionesABC, ByVal idISAAR As Integer, ByVal idRelacion As Integer, ByVal idISAAR_REL As Integer, ByVal IDCatalogo_item As Integer, ByVal Descripción_relación As String, ByVal Fechas_relación As Date)
        Const strProcName As String = "ABC_ISAAR_Relaciones"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            pBD.ABC_ISAAR_Relaciones(op, idISAAR, idRelacion, idISAAR_REL, IDCatalogo_item, Descripción_relación, Fechas_relación)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub ABC_ISAAR_Entidades(ByVal op As OperacionesABC, ByVal idISAAR As Integer, ByVal idArchivo As Integer, ByVal idDescripcion As Integer)
        Const strProcName As String = "ABC_ISAAR_Entidades"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            pBD.ABC_ISAAR_Entidades(op, idISAAR, idArchivo, idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub ABC_ISAAR_Series_Modelo(ByVal op As OperacionesABC, ByVal idISAAR As Integer, ByVal idNorma As Integer, ByVal idNivel As Integer, ByVal idSerie As Integer)
        Const strProcName As String = "ABC_ISAAR_Series_Modelo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            pBD.ABC_ISAAR_Series_Modelo(op, idISAAR, idNorma, idNivel, idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function ListaISAAR() As System.Data.DataSet
        Const strProcName As String = "ListaISAAR"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaISAAR()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function


    <WebMethod()> Public Function ListaISAAR_Relaciones(ByVal idISAAR As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaISAAR_Relaciones"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaISAAR_Relaciones(idISAAR)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaISAARxtipoent(ByVal tipo_de_entidad As String) As System.Data.DataSet
        Const strProcName As String = "ListaISAARxtipoent"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaISAARxtipoent(tipo_de_entidad)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaISAARxid(ByVal idISAAR As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaISAARxid"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaISAARxid(idISAAR)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function


    <WebMethod()> Public Function ListaISAAR_Series_Modelo(ByVal idISAAR As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaISAAR_Series_Modelo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaISAAR_Series_Modelo(idISAAR)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaISAAR_Entidades(ByVal idISAAR As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaISAAR_Entidades"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaISAAR_Entidades(idISAAR)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Lista_ISAAR_EntidadesxUsuario(ByVal idISAAR As Integer) As System.Data.DataSet
        Const strProcName As String = "Lista_ISAAR_EntidadesxUsuario"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.Lista_ISAAR_EntidadesxUsuario(idISAAR)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function PermisosAccesos(ByVal identidad As Integer) As System.Data.DataSet
        Const strProcName As String = "SP_PermisosAD"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.PermisosAccesos(identidad)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaSeries_Modelo(ByVal identidad As Integer, ByVal Profundidad As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaSeries_Modelo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaSeries_Modelo(identidad, Profundidad)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaSeries_ModeloXNorma(ByVal idNorma As Integer, ByVal idNivel As Integer, ByVal NoIdentidad As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaSeries_ModeloXNorma"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaSeries_ModeloXNorma(idNorma, idNivel, NoIdentidad)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaSeries_ModeloxRango(ByVal identidad As Integer, ByVal nivel_ini As Integer, ByVal nivel_fin As Integer) As DataSet
        Const strProcName As String = "ListaSeries_ModeloxRango"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaSeries_ModeloxRango(identidad, nivel_ini, nivel_fin)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaSeries_ModeloxNivel(ByVal identidad As Integer, ByVal idNivel As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaSeries_ModeloxNivel"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaSeries_ModeloxNivel(identidad, idNivel)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ABC_Series_Modelo(ByVal op As OperacionesABC, ByVal idNorma As Integer, ByVal idNivel As Integer, _
                                                    ByVal idSerie As Integer, ByVal Serie_nombre As String, ByVal Clave As String, _
                                                    ByVal Atributo As Integer, ByVal idSeriePID As Integer, ByVal identidad As Integer, _
                                                    ByVal Periodo_Prestamo As Integer, ByVal idFrecuencia_prestamo As Integer, ByVal Num_Resellos As Integer, _
                                                    ByVal idFrecuencia_guardaActivo As Integer, ByVal Periodo_guardaActivo As Integer, _
                                                    ByVal idFrecuencia_guardaInactivo As Integer, ByVal Periodo_guardaInactivo As Integer, _
                                                    ByVal Valor_administrativo As Integer, ByVal Valor_legal As Integer, ByVal Valor_contable As Integer, ByVal Metodo_Destruccion As Integer, _
                                                    ByVal Clasificacion_De_Informacion As Integer, _
                                                    ByVal Fecha_Ultimo_Cambio As Date) As Integer
        Const strProcName As String = "ABC_Series_Modelo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Dim permiso As DataSet
        Try
            If (op = OperacionesABC.operAlta) Then
                permiso = CrearPermiso(Serie_nombre, 1)
                OtorgarPermiso(identidad, permiso.Tables(0).Rows(0)(0))
                nID = pBD.ABC_Series_Modelo(op, idNorma, idNivel, idSerie, Serie_nombre, Clave, Atributo, idSeriePID, permiso.Tables(0).Rows(0)(0), Periodo_Prestamo, idFrecuencia_prestamo, Num_Resellos, idFrecuencia_guardaActivo, Periodo_guardaActivo, idFrecuencia_guardaInactivo, Periodo_guardaInactivo, Valor_administrativo, Valor_legal, Valor_contable, Metodo_Destruccion, Clasificacion_De_Informacion, Fecha_Ultimo_Cambio)
            Else
                nID = pBD.ABC_Series_Modelo(op, idNorma, idNivel, idSerie, Serie_nombre, Clave, Atributo, idSeriePID, 0, Periodo_Prestamo, idFrecuencia_prestamo, Num_Resellos, idFrecuencia_guardaActivo, Periodo_guardaActivo, idFrecuencia_guardaInactivo, Periodo_guardaInactivo, Valor_administrativo, Valor_legal, Valor_contable, Metodo_Destruccion, Clasificacion_De_Informacion, Fecha_Ultimo_Cambio)
            End If
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function
    <WebMethod()> Public Function CrearPermiso(ByVal Nombre As String, ByVal version As Integer) As System.Data.DataSet
        Const strProcName As String = "SVRUSR_SP_AltaPermiso"
        Dim pBD As New Persistencia(ObtenerBDH, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.CrearPermiso(Nombre, version)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function OtorgarPermiso(ByVal PerfilUsuarioID As Integer, ByVal PermisoID As Integer) As System.Data.DataSet
        Const strProcName As String = "SVRUSR_SP_ABCPERMISOPERFILUSR"
        Dim pBD As New Persistencia(ObtenerBDH, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.OtorgarPermiso(PerfilUsuarioID, PermisoID)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaSeries_Modelo_Hijos(ByVal idSerie As Integer, ByVal identidad As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaSeries_Modelo_Hijos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaSeries_Modelo_Hijos(idSerie, identidad)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaSeries_Indices(ByVal idSerie As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaSeries_Indices"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaSeries_Indices(idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaSeries_Indices_padres(ByVal idSerie As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaSeries_Indices_padres"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaSeries_Indices_padres(idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function



    <WebMethod()> Public Function ABC_Series_Indices(ByVal op As OperacionesABC, ByVal idNorma As Integer, ByVal idArea As Integer, ByVal idElemento As Integer, ByVal idIndice As Integer, ByVal idNivel As Integer, ByVal idSerie As Integer, ByVal Indice_descripcion As String, ByVal Indice_Tipo As Integer, ByVal Indice_LongitudMax As Integer, ByVal Indice_Mascara As String, ByVal Indice_PK As Integer, ByVal Indice_Obligatorio As Integer, ByVal Indice_Unico As Integer, ByVal Indice_buscar As Integer, ByVal Indice_CopiarValor As Integer, ByVal Indice_EsAutoincremental As Integer, ByVal IndiceReadOnly As Integer, ByVal Indice_Visible As Integer, ByVal relacion_con_normaPID As Integer, ByVal folio_norma As String, ByVal Muestra_padres As Integer, ByVal Multi_valor As Integer) As Integer
        Const strProcName As String = "ABC_Series_Indices"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Series_Indices(op, idNorma, idArea, idElemento, idIndice, idNivel, idSerie, Indice_descripcion, Indice_Tipo, Indice_LongitudMax, Indice_Mascara, Indice_PK, Indice_Obligatorio, Indice_Unico, Indice_buscar, Indice_CopiarValor, Indice_EsAutoincremental, IndiceReadOnly, Indice_Visible, relacion_con_normaPID, folio_norma, Muestra_padres, Multi_valor)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function

    <WebMethod()> Public Function ListaSeries_Area_Elemento(ByVal idNorma As Integer) As DataSet
        Const strProcName As String = "ListaSeries_Area_Elemento"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaSeries_Area_Elemento(idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function


    <WebMethod()> Public Function ListaArchivo_indices_PK(ByVal idArchivo As Integer, ByVal idDescripcion As Integer, ByVal indice_PK As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_indices_PK"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_indices_PK(idArchivo, idDescripcion, indice_PK)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Obten_Secuencia(ByVal idArchivo As Integer, ByVal idNorma As Integer, ByVal idSerie As Integer, ByVal ano As String, ByVal mes As String, ByVal dia As String, ByVal folio_norma As String, ByVal idDocumentoPID As Integer) As System.Data.DataSet
        Const strProcName As String = "Obten_Secuencia"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.Obten_Secuencia(idArchivo, idNorma, idSerie, ano, mes, dia, folio_norma, idDocumentoPID)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Func_Indice_repetido(ByVal idArchivo As Integer, ByVal idIndice As Integer, ByVal valor As String) As System.Data.DataSet
        Const strProcName As String = "Func_Indice_repetido"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.Func_Indice_repetido(idArchivo, idIndice, valor)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Func_Suma_IndicesSistemaXNorma(ByVal idIndice_Sistema As Integer, ByVal idNorma As Integer) As System.Data.DataSet
        Const strProcName As String = "Func_Suma_IndicesSistemaXNorma"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.Func_Suma_IndicesSistemaXNorma(idIndice_Sistema, idNorma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaFondoxNivel(ByVal idArchivo As Integer, ByVal Fondo_ini As Integer, ByVal Fondo_fin As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaFondoxNivel"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaFondoxNivel(idArchivo, Fondo_ini, Fondo_fin)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaFondo(ByVal idArchivo As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaFondo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaFondo(idArchivo)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaArchivo_Serie(ByVal idArchivo As Integer, ByVal idSerie As Integer) As DataSet
        Const strProcName As String = "ListaArchivo_Serie"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_Serie(idArchivo, idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaArchivo_indicexidDescripcion(ByVal idArchivo As Integer, ByVal idDescripcion As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_indicexidDescripcion"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_indicexidDescripcion(idArchivo, idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaArchivo_indicexidDescripcion_folio_norma(ByVal idArchivo As Integer, ByVal idDescripcion As Integer, ByVal folio_norma As String) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_indicexidDescripcion_folio_norma"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_indicexidDescripcion_folio_norma(idArchivo, idDescripcion, folio_norma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function


    <WebMethod()> Public Function ListaArchivo_indicexidDescripcion_idIndice(ByVal idArchivo As Integer, ByVal idDescripcion As Integer, ByVal idIndice As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaArchivo_indicexidDescripcion_folio_norma"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaArchivo_indicexidDescripcion_idIndice(idArchivo, idDescripcion, idIndice)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaSeries_Modelo_indice_sistema(ByVal idIndice_Sistema As Integer, ByVal idSerie As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaSeries_Modelo_indice_sistema"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaSeries_Modelo_indice_sistema(idIndice_Sistema, idSerie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function BuscaExpediente(ByVal SQLString As String) As System.Data.DataSet
        Const strProcName As String = "BuscaExpediente()"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.BuscaExpediente(SQLString)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaFondoxNivelxPadre(ByVal idArchivo As Integer, ByVal Fondo_ini As Integer, ByVal Fondo_fin As Integer, ByVal Padre As Integer) As System.Data.DataSet
        Const strProcName As String = "ListaFondoxNivelxPadre"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet

        Try
            ds = pBD.ListaFondoxNivelxPadre(idArchivo, Fondo_ini, Fondo_fin, Padre)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Sub Transfiere_Archivo_Descripciones(ByVal idArchivo As Integer, ByVal idDescripcion As Integer, ByVal idArchivoNew As Integer, ByVal idDocumentoPIDNew As Integer)
        Const strProcName As String = "Transfiere_Archivo_Descripciones"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.Transfiere_Archivo_Descripciones(idArchivo, idDescripcion, idArchivoNew, idDocumentoPIDNew)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub
    <WebMethod()> Public Function getPadresBusqueda(ByVal idArchivo As Integer, ByVal Entidad As String, ByVal Area As String, ByVal Tipo_expediente As Integer, ByVal ano As String, ByVal mes As String, ByVal dia As String, ByVal Palabra As String) As DataSet
        Const strProcName As String = "getPadresBusqueda"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.getPadresBusqueda(idArchivo, Entidad, Area, Tipo_expediente, ano, mes, dia, Palabra)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaArchivo_conLimite(ByVal idArchivo As Integer, ByVal nivelMax As Integer) As DataSet
        Const strProcName As String = "ListaArchivo_conLimite"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.ListaArchivo_conLimite(idArchivo, nivelMax)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function
    <WebMethod()> Public Function ListaCatalogo_disposicion(ByVal idArchivo As Integer, ByVal nivelIni As Integer, ByVal nivelMax As Integer) As DataSet
        Const strProcName As String = "ListaCatalogo_disposicion"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.ListaCatalogo_disposicion(idArchivo, nivelIni, nivelMax)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaValoracion_Archivo(ByVal idArchivo As Integer, ByVal Tipo As String) As DataSet
        Const strProcName As String = "ListaValoracion_Archivo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.ListaValoracion_Archivo(idArchivo, Tipo)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Lista_Archivo_Fisico_Elemento() As DataSet
        Const strProcName As String = "Lista_Archivo_Fisico_Elemento"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.Lista_Archivo_Fisico_Elemento()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Lista_Archivo_Fisico_Unidades() As DataSet
        Const strProcName As String = "Lista_Archivo_Fisico_Unidades"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.Lista_Archivo_Fisico_Unidades()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function Lista_Archivo_Fisico_Estructura(ByVal idArchivo_Fisico As Integer) As DataSet
        Const strProcName As String = "Lista_Archivo_Fisico_Estructura"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.Lista_Archivo_Fisico_Estructura(idArchivo_Fisico)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaVencimientos_Archivo_Tramite(ByVal idFolio As Integer, ByVal Baja As Integer) As DataSet
        Const strProcName As String = "ListaVencimientos_Archivo_Tramite"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.ListaVencimientos_Archivo_Tramite(idFolio, Baja)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    '-------------------------------------------------
    '-------------------------------------------------
    'Solicitud de prestamos

    <WebMethod()> Public Function BuscaDocumentosPorExpedientesPrestamos(ByVal idExpediente As Integer) As System.Data.DataSet
        Const strProcName As String = "BuscarDocumentosPorExpedientesPrestamos()"
        Dim sqlCommand As String = String.Format("select * from Archivo_Descripciones_Archivisticas where idDocumentoPID={0} AND idNivel=9", idExpediente)

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.BuscaExpediente(sqlCommand)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return ds

    End Function


    <WebMethod()> Public Function BuscaExpedientePrestamos(ByVal idExpediente As Integer) As System.Data.DataSet
        Const strProcName As String = "BuscarDocumentosPorExpedientesPrestamos()"
        Dim sqlCommand As String = String.Format("select exp.*, ar.Archivo_Descripcion from Archivo_Descripciones_Archivisticas exp, Archivos ar where idDescripcion={0} AND idNivel=8 and exp.idArchivo = ar.idArchivo", idExpediente)

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.BuscaExpediente(sqlCommand)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return ds

    End Function


    <WebMethod()> Public Function BuscaExpedientesPrestamos(ByVal idArchivo As Integer, ByVal criterioBusqueda As String) As System.Data.DataSet
        Const strProcName As String = "BuscarExpedientesPrestamos()"
        Dim sqlCommand As String = String.Format("select * from Archivo_Descripciones_Archivisticas where (Codigo_clasificacion like '%{0}%' OR Descripcion like '%{0}%') AND idNivel=8 AND idArchivo={1}", criterioBusqueda, idArchivo)

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.BuscaExpediente(sqlCommand)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return ds

    End Function

    <WebMethod()> Public Function ABC_Solicitud_Prestamos(ByVal op As OperacionesABC, ByVal idSolicitudPrestamo As Integer, ByVal idArchivo As Integer, _
                                                          ByVal idDescripcion As Integer, ByVal folio As String, ByVal atendida As Boolean, ByVal fechaAtencion As Nullable(Of Date), _
                                                          ByVal estatus As Integer, ByVal idUsuario_Solicitante As String, ByVal idUsuario_Atencion As String, ByVal dias As Integer, _
                                                          ByVal fechaEstimadaDevolucion As Nullable(Of Date), ByVal fechaDevolucion As Nullable(Of Date)) As Integer
        Const strProcName As String = "ABC_Solicitud_Prestamos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            Return pBD.ABC_Solicitud_Prestamos(op, idSolicitudPrestamo, idArchivo, idDescripcion, folio, atendida, fechaAtencion, estatus, idUsuario_Solicitante, _
                                               idUsuario_Atencion, dias, fechaEstimadaDevolucion, fechaDevolucion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Function


    <WebMethod()> Public Function BuscarSolicitudPrestamo(ByVal idSolicitud As Integer) As DataSet
        Const strProcName As String = "Busca_Solicitud_Prestamo"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.Busca_Solicitud_Prestamo(idSolicitud)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaSolicitudesPrestamos(ByVal estatus As Integer) As DataSet
        Const strProcName As String = "Lista_Solicitudes_Prestamos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.Lista_Solicitudes_Prestamos(estatus)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function


    <WebMethod()> Public Function CuentaSolicitudesExpedienteEstatus(ByVal idDescripcion As Integer, ByVal estatus As Integer) As Integer
        Const strProcName As String = "Cuenta_Solicitudes_Expediente_Estatus()"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As Integer
        Try
            resultado = pBD.Cuenta_Solicitudes_Expediente_Estatus(idDescripcion, estatus)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function


    <WebMethod()> Public Function ListaSolicitudesPrestamosPorVencer() As DataSet
        Const strProcName As String = "Lista_Solicitudes_Prestamos_Por_Vencer"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.Lista_Solicitudes_Prestamos_Por_Vencer()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ObtenFechaDevolucionExpedientePrestado(ByVal idExpediente As Integer) As String
        Const strProcName As String = "Obten_Fecha_Devolucion_Expediente_Prestado"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim fecha As String
        Try
            fecha = pBD.ObtenFechaDevolucionExpedientePrestado(idExpediente)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return fecha
    End Function

    '-------------------------------------------------------------------------------------------------------------------
    '-------------------------------------------------------------------------------------------------------------------
    ' Transferencia Primara

    <WebMethod()> Public Sub Prepara_Vencimientos_Archivo_Tramite(ByVal idArchivo As Integer, ByVal idFolio As Integer, ByVal Fecha_Corte As Date)
        Const strProcName As String = "Prepara_Vencimientos_Archivo_Tramite"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.Prepara_Vencimientos_Archivo_Tramite(idArchivo, idFolio, Fecha_Corte)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub Prepara_Vencimientos_Archivo_Tramite_Bajas(ByVal idArchivo As Integer, ByVal idFolio As Integer, ByVal Fecha_Corte As Date)
        Const strProcName As String = "Prepara_Vencimientos_Archivo_Tramite_Bajas"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.Prepara_Vencimientos_Archivo_Tramite_Bajas(idArchivo, idFolio, Fecha_Corte)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub Prepara_Vencimientos_Archivo_Tramite_Bajas_Codigo(ByVal idArchivo As Integer, ByVal idFolio As Integer, ByVal Codigo_clasificacion As String)
        Const strProcName As String = "Prepara_Vencimientos_Archivo_Tramite_Bajas_Codigo"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.Prepara_Vencimientos_Archivo_Tramite_Bajas_Codigo(idArchivo, idFolio, Codigo_clasificacion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
    End Sub



    <WebMethod()> Public Sub Prepara_Vencimientos_Concentracion_Bajas(ByVal idArchivo As Integer, ByVal idFolio As Integer, ByVal Fecha_Corte As Date)
        Const strProcName As String = "Prepara_Vencimientos_Concentracion_Bajas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.Prepara_Vencimientos_Concentracion_Bajas(idArchivo, idFolio, Fecha_Corte)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
    End Sub


    <WebMethod()> Public Function ListaTransferencias_Primarias(ByVal Status As Integer) As DataSet
        Const strProcName As String = "ListaTransferencias_Primarias"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaTransferencias_Primarias(Status)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function





    <WebMethod()> Public Sub ABC_Transferencias_Primarias(ByVal op As Integer, ByVal idFolio As Integer, ByVal Usrid As Integer, ByVal Fecha_Solicitud As Date, ByVal idArchivoOrigen As Integer, ByVal idArchivoDestino As Integer, ByVal Notas_Solicitud As String, ByVal Status As Integer)
        Const strProcName As String = "ABC_Transferencias_Primarias"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Primarias(op, idFolio, Usrid, Fecha_Solicitud, idArchivoOrigen, idArchivoDestino, Notas_Solicitud, Status)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function ABC_Transferencias_Primarias_Expedientes(ByVal op As Integer, ByVal idFolio As Integer, ByVal idFolioDetalle As Integer, ByVal idDescripcion As Integer, ByVal idDocumentoPID As Integer, ByVal idStatus As Integer) As Integer
        Const strProcName As String = "ABC_Transferencias_Primarias_Expedientes"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim nID As Integer
        Try
            nID = pBD.ABC_Transferencias_Primarias_Expedientes(op, idFolio, idFolioDetalle, idDescripcion, idDocumentoPID, idStatus)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return nID
    End Function

    <WebMethod()> Public Sub ABC_Transferencias_Primarias_Documentos(ByVal op As Integer, ByVal idFolio As Integer, ByVal idFolioDetalle As Integer, ByVal idFolioDetalleDocumento As Integer, ByVal idDescripcion As Integer, ByVal idDocumentoPID As Integer, ByVal idStatus As Integer)
        Const strProcName As String = "ABC_Transferencias_Primarias_Documentos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Primarias_Documentos(op, idFolio, idFolioDetalle, idFolioDetalleDocumento, idDescripcion, idDocumentoPID, idStatus)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub


    <WebMethod()> Public Sub ABC_Transferencias_Primarias_Bajas_Documentos(ByVal op As Integer, ByVal idFolio As Integer, ByVal idFolioDetalle As Integer, ByVal idDescripcion As Integer, ByVal idDocumentoPID As Integer, ByVal idStatus As Integer)
        Const strProcName As String = "ABC_Transferencias_Primarias_Bajas_Documentos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Primarias_Bajas_Documentos(op, idFolio, idFolioDetalle, idDescripcion, idDocumentoPID, idStatus)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub ABC_Transferencias_Secundarias_Bajas_Documentos(ByVal op As Integer, ByVal idFolio As Integer, ByVal idFolioDetalle As Integer, ByVal idDescripcion As Integer, ByVal idDocumentoPID As Integer, ByVal idStatus As Integer)
        Const strProcName As String = "ABC_Transferencias_Secundarias_Bajas_Documentos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Secundarias_Bajas_Documentos(op, idFolio, idFolioDetalle, idDescripcion, idDocumentoPID, idStatus)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function ListaArchivo_Descripciones_Transferencia_Filtro(ByVal idArchivo As Integer, ByVal idFolio As Integer) As DataSet
        Const strProcName As String = "ListaArchivo_Descripciones_Transferencia_Filtro"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaArchivo_Descripciones_Transferencia_Filtro(idArchivo, idFolio)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Function ListaVencimientos_Archivo_Tramite_Seleccion(ByVal idFolio As Integer, ByVal Baja As Integer) As DataSet
        Const strProcName As String = "ListaVencimientos_Archivo_Tramite_Seleccion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaVencimientos_Archivo_Tramite_Seleccion(idFolio, Baja)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function


    <WebMethod()> Public Function ListaBajas_Archivo_Tramite(ByVal idFolio As Integer, ByVal Baja As Integer) As DataSet
        Const strProcName As String = "ListaBajas_Archivo_Tramite"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaBajas_Archivo_Tramite(idFolio, Baja)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Function ListaBajas_Archivo_Tramite_Seleccionados(ByVal idFolio As Integer, ByVal Baja As Integer) As DataSet
        Const strProcName As String = "ListaBajas_Archivo_Tramite_Seleccionados"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaBajas_Archivo_Tramite_Seleccionados(idFolio, Baja)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Function ListaBajas_Archivo_Concentracion(ByVal idFolio As Integer, ByVal Baja As Integer) As DataSet
        Const strProcName As String = "ListaBajas_Archivo_Concentracion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaBajas_Archivo_Concentracion(idFolio, Baja)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Function ListaBajas_Archivo_Concentracion_Seleccionados(ByVal idFolio As Integer, ByVal Baja As Integer) As DataSet
        Const strProcName As String = "ListaBajas_Archivo_Concentracion_Seleccionados"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaBajas_Archivo_Concentracion_Seleccionados(idFolio, Baja)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Function ListaVencimientos_Archivo_Concentracion_Seleccion(ByVal idFolio As Integer, ByVal Baja As Integer) As DataSet
        Const strProcName As String = "ListaVencimientos_Archivo_Concentracion_Seleccion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaVencimientos_Archivo_Concentracion_Seleccion(idFolio, Baja)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function
    <WebMethod()> Public Function ListaVencimientos_Archivo_Tramite_Seleccion_idDescripcion(ByVal idArchivo As Integer, ByVal idFolio As Integer, ByVal idFolioDetalle As Integer) As DataSet
        Const strProcName As String = "ListaVencimientos_Archivo_Tramite_Seleccion_idDescripcion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaVencimientos_Archivo_Tramite_Seleccion_idDescripcion(idArchivo, idFolio, idFolioDetalle)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Function ListaTransferencia_Primaria(ByVal idFolio As Integer) As DataSet
        Const strProcName As String = "ListaVencimientos_Archivo_Tramite_Seleccion_idDescripcion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaTransferencia_Primaria(idFolio)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Function ListaTransferencia_Secundaria(ByVal idFolio As Integer) As DataSet
        Const strProcName As String = "ListaVencimientos_Archivo_Tramite_Seleccion_idDescripcion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaTransferencia_Secundaria(idFolio)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function


    <WebMethod()> Public Function Transfiere_Archivo_Descripciones_primarias(ByVal idArchivo As Integer, ByVal idDescripcion As Integer, ByVal idArchivoNew As Integer, ByVal idDocumentoPIDNew As Integer, ByVal idFolioDetalle As Integer) As DataSet
        Const strProcName As String = "Transfiere_Archivo_Descripciones_primarias"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.Transfiere_Archivo_Descripciones_primarias(idArchivo, idDescripcion, idArchivoNew, idDocumentoPIDNew, idFolioDetalle)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Function ListaVencimientos_Archivo_Tramite_Recepcion(ByVal idFolio As Integer, ByVal idStatus As Integer) As DataSet
        Const strProcName As String = "ListaVencimientos_Archivo_Tramite_Recepcion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaVencimientos_Archivo_Tramite_Recepcion(idFolio, idStatus)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function
    '--------------------------------------------------------------------------------------------------------------------------------------------------
    <WebMethod()> Public Function ListaTransferencias_Secunarias(ByVal Status As Integer) As DataSet
        Const strProcName As String = "ListaTransferencias_Secunarias"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaTransferencias_Secunarias(Status)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Sub ABC_Transferencias_Secundarias(ByVal op As Integer, ByVal idFolio As Integer, ByVal Usrid As Integer, ByVal Fecha_Solicitud As Date, ByVal idArchivoOrigen As Integer, ByVal idArchivoDestino As Integer, ByVal Notas_Solicitud As String, ByVal Status As Integer)
        Const strProcName As String = "ABC_Transferencias_Secundarias"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Secundarias(op, idFolio, Usrid, Fecha_Solicitud, idArchivoOrigen, idArchivoDestino, Notas_Solicitud, Status)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function ListaVencimientos_Archivo_Concentracion(ByVal idFolio As Integer, ByVal Baja As Integer) As DataSet
        Const strProcName As String = "ListaVencimientos_Archivo_Concentracion"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim ds As DataSet
        Try
            ds = pBD.ListaVencimientos_Archivo_Concentracion(idFolio, Baja)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
        Return ds
    End Function

    <WebMethod()> Public Function ListaVencimientos_Archivo_Concentracion_Seleccionados(ByVal idFolio As Integer, ByVal idStatus As Integer, ByVal Baja As Integer) As DataSet
        Const strProcName As String = "ListaVencimientos_Archivo_Concentracion_Seleccionados"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaVencimientos_Archivo_Concentracion_Seleccionados(idFolio, idStatus, Baja)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Function ListaVencimientos_Archivo_Tramite_Seleccionados(ByVal idFolio As Integer, ByVal idStatus As Integer, ByVal Baja As Integer) As DataSet
        Const strProcName As String = "ListaVencimientos_Archivo_Tramite_Seleccionados"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaVencimientos_Archivo_Tramite_Seleccionados(idFolio, idStatus, Baja)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Sub ABC_Transferencias_Secundarias_Expedientes(ByVal op As Integer, ByVal idFolio As Integer, ByVal idFolioDetalle As Integer, ByVal idDescripcion As Integer, ByVal idDocumentoPID As Integer, ByVal idStatus As Integer)
        Const strProcName As String = "ABC_Transferencias_Secundarias_Expedientes"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Secundarias_Expedientes(op, idFolio, idFolioDetalle, idDescripcion, idDocumentoPID, idStatus)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub ABC_Transferencias_Secundarias_Documentos(ByVal op As Integer, ByVal idFolio As Integer, ByVal idFolioDetalle As Integer, ByVal idFolioDetalleDocumento As Integer, ByVal idDescripcion As Integer, ByVal idDocumentoPID As Integer, ByVal idStatus As Integer)
        Const strProcName As String = "ABC_Transferencias_Secundarias_Documentos"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Secundarias_Documentos(op, idFolio, idFolioDetalle, idFolioDetalleDocumento, idDescripcion, idDocumentoPID, idStatus)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub


    <WebMethod()> Public Function Transfiere_Archivo_Descripciones_Secundarias(ByVal idArchivo As Integer, ByVal idDescripcion As Integer, ByVal idArchivoNew As Integer, ByVal idDocumentoPIDNew As Integer, ByVal idFolioDetalle As Integer) As DataSet
        Const strProcName As String = "Transfiere_Archivo_Descripciones_Secundarias"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.Transfiere_Archivo_Descripciones_Secundarias(idArchivo, idDescripcion, idArchivoNew, idDocumentoPIDNew, idFolioDetalle)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Function ListaVencimientos_Archivo_Concentracion_Seleccion_idDescripcion(ByVal idArchivo As Integer, ByVal idFolio As Integer, ByVal idFolioDetalle As Integer) As DataSet
        Const strProcName As String = "ListaVencimientos_Archivo_Concentracion_Seleccion_idDescripcion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaVencimientos_Archivo_Concentracion_Seleccion_idDescripcion(idArchivo, idFolio, idFolioDetalle)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado

    End Function

    <WebMethod()> Public Sub ABC_Transferencias_Primarias_Cajas(ByVal op As Integer, ByVal idFolio As Integer, ByVal idFolioCaja As Integer, ByVal Caja_Codigo As String, ByVal Caja_Descripcion As String, ByVal Caja_Notas As String)
        Const strProcName As String = "ABC_Transferencias_Primarias_Cajas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Primarias_Cajas(op, idFolio, idFolioCaja, Caja_Codigo, Caja_Descripcion, Caja_Notas)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub ABC_Transferencias_Secundarias_Cajas(ByVal op As Integer, ByVal idFolio As Integer, ByVal idFolioCaja As Integer, ByVal Caja_Codigo As String, ByVal Caja_Descripcion As String, ByVal Caja_Notas As String)
        Const strProcName As String = "ABC_Transferencias_Primarias_Cajas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Secundarias_Cajas(op, idFolio, idFolioCaja, Caja_Codigo, Caja_Descripcion, Caja_Notas)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function Lista_Transferencias_Primarias_Cajas(ByVal idFolio As Integer) As DataSet
        Const strProcName As String = "Lista_Transferencias_Primarias_Cajas"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.Lista_Transferencias_Primarias_Cajas(idFolio)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Function Lista_Transferencias_Secundarias_Cajas(ByVal idFolio As Integer) As DataSet
        Const strProcName As String = "Lista_Transferencias_Secundarias_Cajas"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.Lista_Transferencias_Secundarias_Cajas(idFolio)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Function Lista_Transferencias_Primarias_Documentos(ByVal idFolio As Integer, ByVal idStatus As Integer) As DataSet
        Const strProcName As String = "Lista_Transferencias_Primarias_Documentos"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.Lista_Transferencias_Primarias_Documentos(idFolio, idStatus)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Function Lista_Transferencias_Secundarias_Documentos(ByVal idFolio As Integer, ByVal idStatus As Integer) As DataSet
        Const strProcName As String = "Lista_Transferencias_Secundarias_Documentos"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.Lista_Transferencias_Secundarias_Documentos(idFolio, idStatus)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Sub ABC_Transferencias_Primarias_Documentos_Cajas(ByVal op As Integer, ByVal idFolio As Integer, ByVal idFolioCaja As Integer, ByVal idFolioDetalle As Integer, ByVal idFolioDetalleDocumento As Integer)
        Const strProcName As String = "ABC_Transferencias_Primarias_Cajas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Primarias_Documentos_Cajas(op, idFolio, idFolioCaja, idFolioDetalle, idFolioDetalleDocumento)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub ABC_Transferencias_Secundarias_Documentos_Cajas(ByVal op As Integer, ByVal idFolio As Integer, ByVal idFolioCaja As Integer, ByVal idFolioDetalle As Integer, ByVal idFolioDetalleDocumento As Integer)
        Const strProcName As String = "ABC_Transferencias_Primarias_Cajas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Secundarias_Documentos_Cajas(op, idFolio, idFolioCaja, idFolioDetalle, idFolioDetalleDocumento)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function Lista_Transferencias_Primarias_Documentos_CajasxidFolioDetalleDocumento(ByVal idFolioDetalleDocumento As Integer) As DataSet
        Const strProcName As String = "Lista_Transferencias_Primarias_Documentos_CajasxidFolioDetalleDocumento"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.Lista_Transferencias_Primarias_Documentos_CajasxidFolioDetalleDocumento(idFolioDetalleDocumento)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Function Lista_Transferencias_Secundarias_Documentos_CajasxidFolioDetalleDocumento(ByVal idFolioDetalleDocumento As Integer) As DataSet
        Const strProcName As String = "Lista_Transferencias_Secundarias_Documentos_CajasxidFolioDetalleDocumento"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.Lista_Transferencias_Secundarias_Documentos_CajasxidFolioDetalleDocumento(idFolioDetalleDocumento)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function


    <WebMethod()> Public Sub Prepara_Vencimientos_Archivo_Concentracion(ByVal idArchivo As Integer, ByVal idFolio As Integer, ByVal Fecha_Corte As DateTime)
        Const strProcName As String = "Prepara_Vencimientos_Archivo_Concentracion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.Prepara_Vencimientos_Archivo_Concentracion(idArchivo, idFolio, Fecha_Corte)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function ListaBajas_Tramite(ByVal Status As Integer) As DataSet
        Const strProcName As String = "ListaBajas_Tramite"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaBajas_Tramite(Status)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Function ListaBaja_Tramite(ByVal idFolio As Integer) As DataSet
        Const strProcName As String = "ListaBaja_Tramite"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaBaja_Tramite(idFolio)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function
    <WebMethod()> Public Function ListaBajas_Concentracion(ByVal Status As Integer) As DataSet
        Const strProcName As String = "ListaBajas_Concentracion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaBajas_Concentracion(Status)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Function ListaBaja_Concentracion(ByVal idFolio As Integer) As DataSet
        Const strProcName As String = "ListaBaja_Tramite"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ListaBaja_Concentracion(idFolio)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Sub ABC_Transferencias_Primarias_Bajas(ByVal op As Integer, ByVal idFolio As Integer, ByVal Usrid As Integer, ByVal Fecha_Solicitud As Date, ByVal idArchivoOrigen As Integer, ByVal Notas_Solicitud As String, ByVal Status As Integer)
        Const strProcName As String = "ABC_Transferencias_Primarias_Bajas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Primarias_Bajas(op, idFolio, Usrid, Fecha_Solicitud, idArchivoOrigen, Notas_Solicitud, Status)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Sub ABC_Transferencias_Secundarias_Bajas(ByVal op As Integer, ByVal idFolio As Integer, ByVal Usrid As Integer, ByVal Fecha_Solicitud As Date, ByVal idArchivoOrigen As Integer, ByVal Notas_Solicitud As String, ByVal Status As Integer)
        Const strProcName As String = "ABC_Transferencias_Secundarias_Bajas"
        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Try
            pBD.ABC_Transferencias_Secundarias_Bajas(op, idFolio, Usrid, Fecha_Solicitud, idArchivoOrigen, Notas_Solicitud, Status)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw New Exception(mstrModNombre & "." & strProcName & " : " & ex.Message)
        End Try
    End Sub

    '---------------------------------------------------------------------
    '---------------------------------------------------------------------
    'Reporte Expurgo de Expedientes
    <WebMethod()> Public Function Lista_Expedientes_Expurgo(ByVal idArchivo As Integer, ByVal fechaInicio As Date, ByVal fechaFin As Date) As DataSet
        Const strProcName As String = "Lista_Expedientes_Expurgo"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.Lista_Expedientes_Expurgo(idArchivo, fechaInicio, fechaFin)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Function Activa_Nivel(ByVal idDescripcion As Integer, ByVal hereda As Boolean) As Integer
        Const strProcName As String = "Activa_Nivel"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As Integer
        Try
            resultado = pBD.Activar_Nivel(idDescripcion, hereda)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Function CuentaElementosNivel(ByVal idArchivo As Integer, ByVal idDocumentoPID As Integer) As Integer
        Const strProcName As String = "Activa_Nivel"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As Integer
        Try
            resultado = pBD.Cuenta_Elementos_Nivel(idArchivo, idDocumentoPID)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Function ObtenDocIdPorIdDescripcion(ByVal idDescripcion As Integer) As Integer
        Const strProcName As String = "ObtenDocIdPorIdDescripcion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As Integer
        Try
            resultado = pBD.ObtenDocIdPorIdDescripcion(idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function

    <WebMethod()> Public Function ObtenArchivoDescripcionesArchivisticasPorIdDescripcion(ByVal idDescripcion As Integer) As DataSet
        Const strProcName As String = "ObtenArchivoDescripcionesArchivisticasPorIdDescripcion"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.ObtenArchivoDescripcionesArchivisticasPorIdDescripcion(idDescripcion)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function
    <WebMethod()> Public Function TieneHijosconValorenIndice(ByVal idArchivo As Integer, ByVal idDescripcion As Integer, ByVal idIndice_Norma As Integer) As DataSet
        Const strProcName As String = "TieneHijosconValorenIndice"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.TieneHijosconValorenIndice(idArchivo, idDescripcion, idIndice_Norma)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function


    <WebMethod()> Public Sub InsertaEventoLog(ByVal TipoEvento As Byte, ByVal Descripcion As String, ByVal Pagina As String, ByVal Usuario As String, ByVal Grupo As String, ByVal Archivo As String, ByVal IP As String, ByVal objeto As String, ByVal idDescripcion As Integer, ByVal idserie As Integer)
        Const strProcName As String = "InsertaLogEventos"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        'Dim resultado As DataSet
        Try
            pBD.InsertaEventoLog(TipoEvento, Descripcion, Pagina, Usuario, Grupo, Archivo, IP, objeto, idDescripcion, idserie)
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
    End Sub

    <WebMethod()> Public Function GetLogEventosFecha() As DataSet
        Const strProcName As String = "GetLogEventosFecha"

        Dim pBD As New Persistencia(ObtenerCS, ObtenerTipoBD)
        Dim resultado As DataSet
        Try
            resultado = pBD.GetLogEventosFecha()
        Catch ex As System.Exception
            RegistraEventoLog(mstrModNombre & "." & strProcName, System.Diagnostics.TraceEventType.Error, ex.Message)
            Throw Excepciones.ConstruyeExcepcion(mstrModNombre, strProcName, ex, ex.Message)
        End Try
        Return resultado
    End Function


End Class