Public Partial Class CampoGridISAAR
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



    Private Sub ASPxGridView1_CustomErrorText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomErrorTextEventArgs) Handles aspxGridCamposISAAR.CustomErrorText
        Dim xError As String
        xError = e.Exception.Message
    End Sub

    Private Sub dsValores_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsValores.Deleting
        e.InputParameters("idArea") = lblidArea.Text
        e.InputParameters("idElemento") = lblidElemento.Text
        e.InputParameters("idIndice") = lblidIndice.Text
        e.InputParameters("Indice_Tipo") = lblIndice_Tipo.Text
    End Sub

    Private Sub dsValores_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsValores.Inserting
        e.InputParameters("idArea") = lblidArea.Text
        e.InputParameters("idElemento") = lblidElemento.Text
        e.InputParameters("idIndice") = lblidIndice.Text
        e.InputParameters("Indice_Tipo") = lblIndice_Tipo.Text
    End Sub
    Private Sub dsValores_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsValores.Updating
        e.InputParameters("idArea") = lblidArea.Text
        e.InputParameters("idElemento") = lblidElemento.Text
        e.InputParameters("idIndice") = lblidIndice.Text
        e.InputParameters("Indice_Tipo") = lblIndice_Tipo.Text
    End Sub

    Protected Sub dsValores_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsValores.Selecting
        e.InputParameters("idArea") = lblidArea.Text
        e.InputParameters("idElemento") = lblidElemento.Text
        e.InputParameters("idIndice") = lblidIndice.Text
    End Sub

    Public Property idArea() As String
        Get
            Return lblidArea.Text
        End Get
        Set(ByVal value As String)
            lblidArea.Text = value
        End Set
    End Property

    Public Property idElemento() As String
        Get
            Return lblidElemento.Text
        End Get
        Set(ByVal value As String)
            lblidElemento.Text = value
        End Set
    End Property

    Public Property idIndice() As String
        Get
            Return lblidIndice.Text
        End Get
        Set(ByVal value As String)
            lblidIndice.Text = value
        End Set
    End Property

    Public Property idDescripcion() As String
        Get
            Return lblidDescripcion.Text
        End Get
        Set(ByVal value As String)
            lblidDescripcion.Text = value
        End Set
    End Property
    Public Property idNivel() As String
        Get
            Return lblidNivel.Text
        End Get
        Set(ByVal value As String)
            lblidNivel.Text = value
        End Set
    End Property
    Public Property Indice_Tipo() As String
        Get
            Return lblIndice_Tipo.Text
        End Get
        Set(ByVal value As String)
            lblIndice_Tipo.Text = value
        End Set
    End Property


End Class