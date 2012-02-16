Public Partial Class CampoPeriodoFechas
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
            FechaIni.ValidationSettings.RequiredField.ErrorText = "* La fecha inicial del campo " & value.Replace("*", "") & " es requerido"
            FechaFin.ValidationSettings.RequiredField.ErrorText = "* La fecha final del campo " & value.Replace("*", "") & " es requerido"
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
    Public Property Fecha_Ini() As String
        Get
            Return FechaIni.Text
        End Get
        Set(ByVal value As String)
            FechaIni.Text = value
        End Set
    End Property
    Public Property Fecha_IniCampoObligatorio() As Boolean
        Get
            Return FechaIni.ValidationSettings.RequiredField.IsRequired
        End Get
        Set(ByVal value As Boolean)
            FechaIni.ValidationSettings.RequiredField.IsRequired = value
        End Set
    End Property

    Public Property Fecha_IniWidth() As Integer
        Get
            Return FechaIni.Width.Value
        End Get
        Set(ByVal value As Integer)
            FechaIni.Width = value
        End Set
    End Property

    Public Property Fecha_Fin() As String
        Get
            Return FechaFin.Text
        End Get
        Set(ByVal value As String)
            FechaFin.Text = value
        End Set
    End Property
    Public Property Fecha_FinCampoObligatorio() As Boolean
        Get
            Return FechaFin.ValidationSettings.RequiredField.IsRequired
        End Get
        Set(ByVal value As Boolean)
            FechaFin.ValidationSettings.RequiredField.IsRequired = value
        End Set
    End Property

    Public Property Fecha_FinWidth() As Integer
        Get
            Return FechaFin.Width.Value
        End Get
        Set(ByVal value As Integer)
            FechaFin.Width = value
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