Public Class RPT_Expurgos
    Sub New(ByVal idArchivo As Integer, ByVal fechaInicio As Date, ByVal fechaFin As Date)
        InitializeComponent()
        'Initialize the report data based on the ManagerID parameter

        Reporte_ExpurgosTableAdapter.GetData(idArchivo, fechaInicio, fechaFin)

    End Sub
End Class