Public Partial Class CampoSI_NO
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
            Valor.ValidationSettings.RequiredField.ErrorText = "* El campo " & value.Replace("*", "") & " es requerido"
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
            Return Valor.SelectedItem.Value
        End Get
        Set(ByVal value As String)
            If value <> "0" Then
                Valor.SelectedItem = Valor.Items.FindByValue(value)
            End If

        End Set
    End Property
    Public Property ValorCampoObligatorio() As Boolean
        Get
            Return Valor.ValidationSettings.RequiredField.IsRequired
        End Get
        Set(ByVal value As Boolean)
            Valor.ValidationSettings.RequiredField.IsRequired = value
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
            tdTexto_Padres.Visible = value
        End Set
    End Property

End Class