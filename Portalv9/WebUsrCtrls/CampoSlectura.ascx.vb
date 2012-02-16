Public Partial Class CampoSlectura
    Inherits System.Web.UI.UserControl
    Public Show_Parents As Boolean = False
    Private Muestra_ValorHTML As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub

    Public Property TextoCampo() As String
        Get
            Return ASPxtitulo.Text
        End Get
        Set(ByVal value As String)
            ASPxtitulo.Text = value
        End Set
    End Property
    Public Property Muestra_Campo() As Boolean
        Get
            Return tdCampo.Visible
        End Get
        Set(ByVal value As Boolean)
            tdCampo.Visible = value
        End Set
    End Property
    Public Property ValorCampo() As String
        Get
            Return Valor.Text
        End Get
        Set(ByVal value As String)
            Valor.Text = value
            ValorHTML.Text = value
            ShowHideHTML()
        End Set
    End Property

    Private Sub ShowHideHTML()
        If MuestraValorHTML Then
            Valor.Visible = False
            ValorHTML.Visible = True
        Else
            Valor.Visible = True
            ValorHTML.Visible = False
        End If
    End Sub

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
            tdTexto_Padres.Visible = value
        End Set
    End Property

    Public Property MuestraValorHTML() As Boolean
        Get
            Return Muestra_ValorHTML
        End Get
        Set(ByVal value As Boolean)
            Muestra_ValorHTML = value
        End Set
    End Property
End Class