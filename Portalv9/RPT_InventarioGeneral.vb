Public Class RPT_InventarioGeneral
    Sub New(ByVal idArchivo As Integer)
        InitializeComponent()
        'Initialize the report data based on the ManagerID parameter

        Archivo_Descripciones_ArchivisticasTableAdapter.GetData(idArchivo)
        Reporte_Inventario_GeneralTableAdapter.GetData(idArchivo)

    End Sub
End Class