Imports System.Web.Security
Imports Portalv9.SvrUsr
Imports DigiPro.Menu
Partial Public Class MasterSite
    Inherits System.Web.UI.MasterPage
    Dim instance As StaticSiteMapProvider
    Dim returnValue As SiteMapNode
    Dim objHeaders As New Core
    Private Const strMenuDataSet As String = "strMenuDataSet"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tTicket As IDTicket
        Try
            tTicket = CType(Session.Item("GSTR_TICKET"), IDTicket)
            If tTicket Is Nothing Then
                LogOff()
                Exit Try
            End If
            'Función que crea el menu de acuerdo a los permisos que tiene el usuario
            CrearMenu("10100", tTicket.UsrID, CType(Application("GN_VERSION_APLICACION_ID"), Integer), CType(Application("GN_PROYECTO_ID"), Integer))
        Catch ex As Exception

            MsgBox1.ShowMessage(ex.ToString)

        Finally
            tTicket = Nothing
        End Try

    End Sub

    Private Sub CrearMenu(ByVal strH1 As String, ByVal strUserID As String, ByVal intAppID As Integer, ByVal intProyID As Integer)

        Dim strNombre As String = ""

        Dim ds As DataSet = GetDatos(strUserID)
        Dim j As Integer = 1

        '' Nuevo Menu
        If ds.Tables(0).Rows.Count > 0 Then
            For Each parentItem As DataRow In ds.Tables("Menu").Rows
                Dim header As New DPMenuHeader()
                header.Text = Trim(parentItem("Link"))
                header.SubMenuId = Trim(parentItem("Link")) & "SubMenu"

                For Each childItem As DataRow In parentItem.GetChildRows("Children")
                    Dim childrenItem As New DPMenuItem()

                    childrenItem.Text = Trim(childItem("Name"))
                    childrenItem.EsEncabezado = CType(childItem("EsEncabezado"), Boolean)
                    childrenItem.NavigateUrl = Trim(childItem("Link"))
                    header.AddItem(childrenItem)
                Next

                DPMenu1.AddHeader(header)
            Next
        End If

    End Sub

    Private Function GetDataSetForMenu(ByVal strH1 As String, ByVal strUserID As String, ByVal intAppID As Integer, ByVal intProyID As Integer) As DataSet

        Dim ds As New DataSet
        Dim dsMenu As DataSet
        Dim dsSubMenu As New DataSet
        Dim i As Integer
        Dim dtsJunto As New DataSet

        Try

            'Cargar menus principales
            dsMenu = objHeaders.ObtenerMenu(strUserID, intAppID, intProyID)
            dsMenu.Tables(0).TableName = "Menu"

            For i = 0 To dsMenu.Tables(0).Rows.Count - 1
                If Not IsDBNull(dsMenu.Tables(0).Rows(i)("RowLink")) Then
                    dtsJunto = objHeaders.ObtenerSubMenu(Trim(dsMenu.Tables(0).Rows(i)("RowLink")), strUserID, intAppID, intProyID)
                    dsSubMenu.Merge(dtsJunto)
                End If
            Next
            dsMenu.Merge(dsSubMenu)
            dsMenu.Tables(1).TableName = "SubMenu"

            dsMenu.Relations.Add("Children", dsMenu.Tables("Menu").Columns("RowLink"), dsMenu.Tables("SubMenu").Columns("H1"))

            Return dsMenu

        Catch ex As Exception

            Me.MsgBox1.ShowMessage(ex.ToString)
            dsMenu = Nothing
            dsSubMenu = Nothing
            Return dsMenu

        End Try

    End Function

    Private Function CrearTabla() As DataTable

        Try

            Dim dtMenus As New DataTable("Menus")
            Dim dcColumn As DataColumn

            Dim myType1 As Type = Type.GetType("System.String")

            dcColumn = New DataColumn("RowLink")
            dcColumn.DataType = System.Type.GetType(myType1.FullName)
            dcColumn.MaxLength = 10
            dtMenus.Columns.Add(dcColumn)

            dcColumn = New DataColumn("Name")
            dcColumn.DataType = System.Type.GetType(myType1.FullName)
            dcColumn.MaxLength = 100
            dtMenus.Columns.Add(dcColumn)

            dcColumn = New DataColumn("Link")
            dcColumn.DataType = System.Type.GetType(myType1.FullName)
            dcColumn.MaxLength = 100
            dtMenus.Columns.Add(dcColumn)

            'Regresa el DataTable
            CrearTabla = dtMenus

        Catch ex As Exception

            CrearTabla = Nothing

        End Try

    End Function

    Private Function CrearTabla2() As DataTable

        Try

            Dim dtMenus As New DataTable("Menus")
            Dim dcColumn As DataColumn

            Dim myType1 As Type = Type.GetType("System.String")

            dcColumn = New DataColumn("RowLink")
            dcColumn.DataType = System.Type.GetType(myType1.FullName)
            dcColumn.MaxLength = 10
            dtMenus.Columns.Add(dcColumn)

            dcColumn = New DataColumn("Name")
            dcColumn.DataType = System.Type.GetType(myType1.FullName)
            dcColumn.MaxLength = 100
            dtMenus.Columns.Add(dcColumn)

            dcColumn = New DataColumn("Link")
            dcColumn.DataType = System.Type.GetType(myType1.FullName)
            dcColumn.MaxLength = 100
            dtMenus.Columns.Add(dcColumn)

            dcColumn = New DataColumn("EsEncabezado")
            dcColumn.DataType = System.Type.GetType(myType1.FullName)
            dcColumn.MaxLength = 5
            dtMenus.Columns.Add(dcColumn)

            'Regresa el DataTable
            CrearTabla2 = dtMenus

        Catch ex As Exception
            CrearTabla2 = Nothing
        End Try
    End Function

    Private Function GetDatos(ByVal strUserID As String) As DataSet
        Dim ds As DataSet

        If Session(strMenuDataSet) Is Nothing Then
            ds = Asignardatos(strUserID)
            Session(strMenuDataSet) = ds
        Else
            ds = CType(Session(strMenuDataSet), DataSet)
        End If

        Return ds
    End Function

    Private Function Asignardatos(ByVal strUserID As String) As DataSet

        Dim dtMenu As New DataTable
        Dim dtSubMenu As New DataTable

        Dim dtsMenu As New DataSet
        Dim i As Integer

        Dim dsMenu As DataSet
        Dim dsSubMenu As DataSet
        Dim dtsJunto As New DataSet

        'Llamar a la función para crear la tabla
        dtMenu = CrearTabla()
        dtSubMenu = CrearTabla2()

        'dsMenu = objHeaders.ObtenerMenu("superadmin", 1, 1)
        dsMenu = objHeaders.ObtenerMenu(strUserID, 1, 1)

        For i = 0 To dsMenu.Tables(0).Rows.Count - 1
            If Not IsDBNull(dsMenu.Tables(0).Rows(i)("RowLink")) Then
                'Asignar valores a los campos del DataTable
                Dim drRow As DataRow
                drRow = dtMenu.NewRow
                drRow("RowLink") = Trim(Mid(CType(dsMenu.Tables(0).Rows(i)("RowLink"), String), 1, 10))
                drRow("Name") = Trim(Mid(dsMenu.Tables(0).Rows(i)("RowName"), 1, 100))
                drRow("Link") = Trim(Mid(dsMenu.Tables(0).Rows(i)("RowName"), 1, 100))

                'Agregar row al DataTable
                dtMenu.Rows.Add(drRow)

            End If
        Next

        dtsJunto.Merge(dtMenu)
        dtsJunto.Tables(0).TableName = "Menu"

        For i = 0 To dsMenu.Tables(0).Rows.Count - 1
            If Not IsDBNull(dsMenu.Tables(0).Rows(i)("RowLink")) Then
                dsSubMenu = objHeaders.ObtenerSubMenu(Trim(dsMenu.Tables(0).Rows(i)("RowLink")), strUserID, 1, 1)
                For j = 0 To dsSubMenu.Tables(0).Rows.Count - 1
                    If Not IsDBNull(dsSubMenu.Tables(0).Rows(j)("H1")) Then
                        'Asignar valores a los campos del DataTable
                        Dim drRow As DataRow
                        drRow = dtSubMenu.NewRow
                        drRow("RowLink") = Trim(Mid(CType(dsSubMenu.Tables(0).Rows(j)("H1"), String), 1, 10))
                        drRow("Name") = Trim(Mid(dsSubMenu.Tables(0).Rows(j)("Name3"), 1, 100))
                        drRow("Link") = Trim(Mid(dsSubMenu.Tables(0).Rows(j)("Link"), 1, 100))
                        drRow("EsEncabezado") = Trim(Mid(dsSubMenu.Tables(0).Rows(j)("EsEncabezado"), 1, 5))

                        'Agregar row al DataTable
                        dtSubMenu.Rows.Add(drRow)
                    End If
                Next
            End If
        Next

        dtsJunto.Merge(dtSubMenu)
        dtsJunto.Tables(1).TableName = "SubMenu"

        dtsJunto.Relations.Add("Children", dtsJunto.Tables("Menu").Columns("RowLink"), dtsJunto.Tables("SubMenu").Columns("RowLink"))

        Return dtsJunto

    End Function

    Private Sub LogOff()
        Server.Transfer("Logoff.aspx")
    End Sub

End Class