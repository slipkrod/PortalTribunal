Public Partial Class CampoGridascx
    Inherits System.Web.UI.UserControl
    Public Show_Parents As Boolean = False   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Property TextoCampo() As String
        Get
            Return Campo.Text
        End Get
        Set(ByVal value As String)
            Campo.Text = value
        End Set
    End Property
    Public Property Catalogo() As Integer
        Get
            Return dsCatalogoDatos.SelectParameters.Item("IDCatalogo").DefaultValue
        End Get
        Set(ByVal value As Integer)
            dsCatalogoDatos.SelectParameters.Item("IDCatalogo").DefaultValue = value
            dsCatalogoDatos.Select()

        End Set
    End Property
    Public Property TextoPadres() As String
        Get
            Return Texto_Padres.Text
        End Get
        Set(ByVal value As String)
            Texto_Padres.Text = value
        End Set
    End Property

    Public Property Muestra_Padres() As Boolean
        Get
            Return Show_Parents
        End Get
        Set(ByVal value As Boolean)
            Show_Parents = value
        End Set
    End Property



    Private Sub ASPxGridView1_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomErrorTextEventArgs) Handles ASPxGridView1.CustomErrorText
        Dim xError As String
        xError = e.Exception.Message
    End Sub

    Private Sub dsValores_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsValores.Deleting
        e.InputParameters.Item("op") = 1
        e.InputParameters.Item("idNorma") = Session("idNorma")
        e.InputParameters.Item("idArea") = Session("idArea")
        e.InputParameters.Item("idElemento") = Session("idElemento")
        e.InputParameters.Item("idIndice") = Session("idIndice")
        e.InputParameters.Item("idArchivo") = Session("idArchivo")
        e.InputParameters.Item("idDescripcion") = Session("idDescripcion")
    End Sub

    Private Sub dsValores_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsValores.Inserting
        e.InputParameters.Item("op") = 0
        e.InputParameters.Item("idNorma") = Session("idNorma")
        e.InputParameters.Item("idArea") = Session("idArea")
        e.InputParameters.Item("idElemento") = Session("idElemento")
        e.InputParameters.Item("idIndice") = Session("idIndice")
        e.InputParameters.Item("idArchivo") = Session("idArchivo")
        e.InputParameters.Item("idDescripcion") = Session("idDescripcion")
        e.InputParameters.Item("idNivel") = Session("idNivel")
        e.InputParameters.Item("Indice_Tipo") = Session("Indice_Tipo")
    End Sub

    Private Sub dsValores_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsValores.Selecting
        e.InputParameters.Item("idNorma") = Session("idNorma")
        e.InputParameters.Item("idArea") = Session("idArea")
        e.InputParameters.Item("idElemento") = Session("idElemento")
        e.InputParameters.Item("idIndice") = Session("idIndice")
        e.InputParameters.Item("idArchivo") = Session("idArchivo")
        e.InputParameters.Item("idDescripcion") = Session("idDescripcion")
    End Sub


    Private Sub dsValores_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsValores.Updating
        e.InputParameters.Item("op") = 2
    End Sub


End Class