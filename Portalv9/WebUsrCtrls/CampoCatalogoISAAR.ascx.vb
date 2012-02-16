Public Partial Class CampoCatalogoISAAR
    Inherits System.Web.UI.UserControl
    Public Show_Parents As Boolean = False
    Public cambio As Boolean = False
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
    Public Property ValorCampo() As Integer
        Get
            Return Valor.SelectedItem.Value
        End Get
        Set(ByVal value As Integer)
            If value <> "-1" Then
                Valor.SelectedIndex = Valor.Items.IndexOfValue(value)
            Else
                Valor.SelectedIndex = -1
            End If

        End Set
    End Property
    Public Property EntidadValor() As String
        Get
            Return cmbtipoentidad.SelectedItem.Text
        End Get
        Set(ByVal value As String)
            If value <> "-1" Then
                cmbtipoentidad.SelectedIndex = cmbtipoentidad.Items.IndexOfText(value)
                ListaISAARxtipos.SelectParameters(0).DefaultValue = value
                Valor.DataBind()
                Valor.SelectedIndex = 0
            Else
                cmbtipoentidad.SelectedIndex = -1
            End If

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
    Public Property cambiovalor() As Boolean
        Get
            Return cambio
        End Get
        Set(ByVal value As Boolean)
            cambio = value
        End Set
    End Property

    Protected Sub Valor_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles Valor.Callback
        llenadatos(e.Parameter)

    End Sub
    Protected Sub llenadatos(ByVal tipo As String)
        If String.IsNullOrEmpty(tipo) Then
            Return
        End If
        ListaISAARxtipos.SelectParameters(0).DefaultValue = tipo.Trim
        Valor.DataBind()
        cambiovalor = True
    End Sub

End Class