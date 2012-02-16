Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Partial Public Class CampoMultiSelect
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

    Public Property Muestra_Campo() As Boolean
        Get
            Return tdCampo.Visible
        End Get
        Set(ByVal value As Boolean)
            tdCampo.Visible = value
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
    Public Property Catalogo() As String
        Get
            Return lblCatalogo.Text
        End Get
        Set(ByVal value As String)
            lblCatalogo.Text = value
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

    Public Property idArchivo() As String
        Get
            Return lblidArchivo.Text
        End Get
        Set(ByVal value As String)
            lblidArchivo.Text = value
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
    Public Property idIndice() As String
        Get
            Return lblidIndice.Text
        End Get
        Set(ByVal value As String)
            lblidIndice.Text = value
        End Set
    End Property


    Public Sub GrabaDatos_Archivo(ByVal idArchivo As Integer, ByVal idDescripcion As Integer, ByVal idNorma As Integer, ByVal idNivel As Integer, ByVal idSerie As Integer, ByVal idArea As Integer, ByVal idElemento As Integer, ByVal idIndice As Integer, ByVal idFolio As Integer, ByVal relacion_con_normaPID As Integer)
        Dim intI As Integer
        For intI = 0 To lbCatalogo.Items.Count - 1

            dsValores.InsertParameters("idArchivo").DefaultValue = idArchivo
            dsValores.InsertParameters("idDescripcion").DefaultValue = idDescripcion
            dsValores.InsertParameters("idNorma").DefaultValue = idNorma
            dsValores.InsertParameters("idNivel").DefaultValue = idNivel
            dsValores.InsertParameters("idSerie").DefaultValue = idSerie
            dsValores.InsertParameters("idArea").DefaultValue = idArea
            dsValores.InsertParameters("idElemento").DefaultValue = idElemento
            dsValores.InsertParameters("idIndice").DefaultValue = idIndice
            dsValores.InsertParameters("idFolio").DefaultValue = idFolio
            dsValores.InsertParameters("relacion_con_normaPID").DefaultValue = relacion_con_normaPID
            If lbCatalogo.Items(intI).Selected Then
                dsValores.InsertParameters("Valor").DefaultValue = 1
            Else
                dsValores.InsertParameters("Valor").DefaultValue = 0
            End If
            dsValores.InsertParameters("Indice_Tipo").DefaultValue = lblIndice_Tipo.Text
            dsValores.InsertParameters("IDCatalogo_item").DefaultValue = lbCatalogo.Items(intI).Value
            dsValores.Insert()
        Next
    End Sub


    Protected Sub lbCatalogo_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles lbCatalogo.DataBound
        Dim rsValoresIndices As DataView
        Dim intI As Integer

        dsValores.SelectParameters("idIndice").DefaultValue = lblidIndice.Text
        rsValoresIndices = dsValores.Select()
        For intI = 0 To rsValoresIndices.Table.Rows.Count - 1
            If rsValoresIndices.Table.Rows(intI).Item("Valor") = 1 Then
                If Not lbCatalogo.Items.FindByValue(rsValoresIndices.Table.Rows(intI).Item("IDCatalogo_item")) Is Nothing Then
                    lbCatalogo.Items.FindByValue(rsValoresIndices.Table.Rows(intI).Item("IDCatalogo_item")).Selected = True
                End If
            End If
        Next
        lbCatalogo.Height = lbCatalogo.Items.Count * 30
    End Sub


    Public Sub Pon_ValorenListItem(ByVal IDCatalogo_item As Integer, ByVal Seleccionado As Boolean)
        If Not lbCatalogo.Items.FindByValue(IDCatalogo_item) Is Nothing Then
            lbCatalogo.Items.FindByValue(IDCatalogo_item).Selected = Seleccionado
        End If
    End Sub


End Class