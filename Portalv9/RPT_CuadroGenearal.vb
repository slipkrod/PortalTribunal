Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports System.Drawing

Public Class RPT_CuadroGenearal

    Private Sub DsRPT_CuadroGenearal1_Initialized(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub RPT_CuadroGenearal_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'Dim sv As New WSArchivo.Service1
        'Dim intI As Integer
        'Dim dsNiveles As DataSet
        'dsNiveles = sv.ListaNormas_Niveles(Parameters("idNorma").Value)
        'Dim nXRTableCell As New XRTableCell()
        'XrTable1.Rows(0).Cells(0).WidthF = 200.0F
        'XrTable1.BeginInit()
        'For intI = 0 To dsNiveles.Tables(0).Rows.Count - 1
        '    If dsNiveles.Tables(0).Rows(intI).Item("Nivel_Logico_Fisico") = 0 Then
        '        nXRTableCell = New XRTableCell()
        '        nXRTableCell.WidthF = 120.0F
        '        nXRTableCell.Borders = BorderSide.Bottom
        '        nXRTableCell.Font = New System.Drawing.Font("Arial", 10, FontStyle.Bold)
        '        nXRTableCell.Text = dsNiveles.Tables(0).Rows(intI).Item("Nivel_Descripcion").ToString
        '        XrTable1.Rows(0).Cells.Add(nXRTableCell)
        '    End If
        'Next
        'XrTable1.WidthF = 894
        'XrTable1.EndInit()


    End Sub

    
    Private Sub XrTableCell2_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs)

    End Sub
End Class