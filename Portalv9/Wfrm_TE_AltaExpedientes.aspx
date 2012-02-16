<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_AltaExpedientes.aspx.vb" Inherits="Portalv9.Wfrm_TE_AltaExpedientes" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register src="WebUsrCtrls/CampoSI_NO.ascx" tagname="CampoSI_NO" tagprefix="uc1" %>
<%@ Register src="WebUsrCtrls/CampoEntero.ascx" tagname="CampoEntero" tagprefix="uc2" %>
<%@ Register src="WebUsrCtrls/CampoTexto.ascx" tagname="CampoTexto" tagprefix="uc3" %>
<%@ Register src="WebUsrCtrls/CampoTextoLargo.ascx" tagname="CampoTextoLargo" tagprefix="uc4" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Content1" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitle" runat="server" > </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <table align="center" style="width: 100%; border: 1px solid #A3C0E8">
        <tr>
            <td style="text-align: right; width: 193px;" class="style1">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                <br />
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblSellada" runat="server" Text="Tipo de Expediente" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <dxe:ASPxComboBox ID="cmbTipoExpediente" runat="server" 
                    DataSourceID="dsLista_SeriesModelo" ValueType="System.Int32" 
                    TextField="Serie_nombre" ValueField="idSerie" Width="310px" 
                    AutoPostBack="True">
                    <Columns>
                        <dxe:ListBoxColumn Caption="idNorma" FieldName="idNorma" Name="idNorma" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="idNivel" FieldName="idNivel" Name="idNivel" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="idSerie" FieldName="idSerie" 
                            Name="idSerie" Visible="False" />
                        <dxe:ListBoxColumn Caption="Tipo de expediente" FieldName="Clave" 
                            Name="Clave" Visible="False" />
                        <dxe:ListBoxColumn Caption="Tipo de expediente" FieldName="Serie_nombre" 
                            Name="Serie_nombre" />
                        <dxe:ListBoxColumn Caption="Periodo_Prestamo" FieldName="Periodo_Prestamo" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="idFrecuencia_prestamo" 
                            FieldName="idFrecuencia_prestamo" Visible="False" />
                        <dxe:ListBoxColumn Caption="Num_Resellos" FieldName="Num_Resellos" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="idFrecuencia_guardaActivo" 
                            FieldName="idFrecuencia_guardaActivo" Visible="False" />
                        <dxe:ListBoxColumn Caption="Periodo_guardaActivo" 
                            FieldName="Periodo_guardaActivo" Visible="False" />
                        <dxe:ListBoxColumn Caption="idFrecuencia_guardaInactivo" 
                            FieldName="idFrecuencia_guardaInactivo" Visible="False" />
                        <dxe:ListBoxColumn Caption="Periodo_guardaInactivo" 
                            FieldName="Periodo_guardaInactivo" Visible="False" />                    
                        <dxe:ListBoxColumn Caption="Metodo_Destruccion" 
                            FieldName="Metodo_Destruccion" />
                        <dxe:ListBoxColumn Caption="Valor_administrativo" 
                            FieldName="Valor_administrativo" Visible="False" />
                        <dxe:ListBoxColumn Caption="Valor_legal" FieldName="Valor_legal" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="Valor_contable" FieldName="Valor_contable" 
                            Visible="False" />
                    </Columns>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="width: 193px; text-align: right;">
                <asp:Label ID="lblentidad" runat="server" Text="Entidad" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td>
                <dxe:ASPxComboBox ID="cmbEntidad" runat="server" DataSourceID="ds_Entidades" 
                    ValueType="System.Int32" AutoPostBack="True" TextField="Descripcion" 
                    ValueField="idDescripcion" Visible="False">
                    <Columns>
                        <dxe:ListBoxColumn Caption="idDescripcion" FieldName="idDescripcion" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="idNivel" FieldName="idNivel" Visible="False" />
                        <dxe:ListBoxColumn Caption="Descripcion" FieldName="Descripcion" />
                        <dxe:ListBoxColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
                            Visible="False" />
                    </Columns>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblarea" runat="server" Text="Area Administrativa" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <dxe:ASPxComboBox ID="cmbAreaAdmin" runat="server" Visible="False" 
                    AutoPostBack="True" DataSourceID="ds_AreasAdministrativas" 
                    TextField="Descripcion" ValueField="idDescripcion" 
                    ValueType="System.Int32">
                    <Columns>
                        <dxe:ListBoxColumn Caption="idDescripcion" FieldName="idDescripcion" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="Descripcion" FieldName="Descripcion" />
                    </Columns>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblanio" runat="server" Text="Año:" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <dxe:ASPxSpinEdit ID="txtAnio" runat="server" AllowNull="False" Height="21px" 
                    Number="0" Visible="False" />
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblmes" runat="server" Text="Mes: " 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <dxe:ASPxComboBox ID="dlMes" runat="server" SelectedIndex="0" 
                    ValueType="System.String" Visible="False" 
                    EnableIncrementalFiltering="True">
                    <Items>
                        <dxe:ListEditItem Selected="True" Text="01" Value="01" />
                        <dxe:ListEditItem Text="02" Value="02" />
                        <dxe:ListEditItem Text="03" Value="03" />
                        <dxe:ListEditItem Text="04" Value="04" />
                        <dxe:ListEditItem Text="05" Value="05" />
                        <dxe:ListEditItem Text="06" Value="06" />
                        <dxe:ListEditItem Text="07" Value="07" />
                        <dxe:ListEditItem Text="08" Value="08" />
                        <dxe:ListEditItem Text="09" Value="09" />
                        <dxe:ListEditItem Text="10" Value="10" />
                        <dxe:ListEditItem Text="11" Value="11" />
                        <dxe:ListEditItem Text="12" Value="12" />                        
                    </Items>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lbldia" runat="server" Text="Día:" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <dxe:ASPxComboBox ID="dlDia" runat="server" ValueType="System.String" 
                    Visible="False" EnableIncrementalFiltering="True">
                    <Items>
                        <dxe:ListEditItem Selected="True" Text="01" Value="01" />
                        <dxe:ListEditItem Text="02" Value="02" />
                        <dxe:ListEditItem Text="03" Value="03" />
                        <dxe:ListEditItem Text="04" Value="04" />
                        <dxe:ListEditItem Text="05" Value="05" />
                        <dxe:ListEditItem Text="06" Value="06" />
                        <dxe:ListEditItem Text="07" Value="07" />
                        <dxe:ListEditItem Text="08" Value="08" />
                        <dxe:ListEditItem Text="09" Value="09" />
                        <dxe:ListEditItem Text="10" Value="10" />
                        <dxe:ListEditItem Text="11" Value="11" />
                        <dxe:ListEditItem Text="12" Value="12" />
                        <dxe:ListEditItem Text="13" Value="13" />
                        <dxe:ListEditItem Text="14" Value="14" />
                        <dxe:ListEditItem Text="15" Value="15" />
                        <dxe:ListEditItem Text="16" Value="16" />
                        <dxe:ListEditItem Text="17" Value="17" />
                        <dxe:ListEditItem Text="18" Value="18" />
                        <dxe:ListEditItem Text="19" Value="19" />
                        <dxe:ListEditItem Text="20" Value="20" />
                        <dxe:ListEditItem Text="21" Value="21" />
                        <dxe:ListEditItem Text="22" Value="22" />
                        <dxe:ListEditItem Text="23" Value="23" />
                        <dxe:ListEditItem Text="24" Value="24" />
                        <dxe:ListEditItem Text="25" Value="25" />
                        <dxe:ListEditItem Text="26" Value="26" />
                        <dxe:ListEditItem Text="27" Value="27" />
                        <dxe:ListEditItem Text="28" Value="28" />
                        <dxe:ListEditItem Text="29" Value="29" />
                        <dxe:ListEditItem Text="30" Value="30" />                        
                        <dxe:ListEditItem Text="31" Value="31" />                        
                    </Items>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; text-align: center;" colspan="2">
                <asp:Label ID="lbldoc" runat="server" Text="Seleccione los Doc a Enviar" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; text-align: center;" colspan="2">
            <center>
                <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dsLista_SeriesModelo_Hijos" 
                    KeyFieldName="idSerie" ParentFieldName="idSeriePID" 
                    EnableTheming="False" Width="195px" Visible="False" 
                    ClientInstanceName="ASPxTreeList1">
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguro desea borrar este registro?" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos." />
                    <SettingsSelection Enabled="True" />
                    <SettingsPager PageSize="20">
                    </SettingsPager>
                    <Settings ShowColumnHeaders="False" />
                    <SettingsBehavior AllowSort="False" />
                    <SettingsEditing EditFormColumnCount="1" Mode="EditFormAndDisplayNode" />
                    <Columns>
                        <dxwtl:TreeListTextColumn Caption="idNorma" FieldName="idNorma" Visible="False" 
                            VisibleIndex="0">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Tipo" VisibleIndex="0" ReadOnly="True">
                            <EditFormSettings Visible="False" />
                            <DataCellTemplate>
                                <dxe:ASPxImage ID="ASPxImage1" runat="server" ImageUrl="<%# GetNodeGlyph(Container) %>">
                                </dxe:ASPxImage>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nombre" FieldName="Serie_nombre" 
                            VisibleIndex="1">
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListComboBoxColumn Caption="Tipo de elemento" FieldName="idNivel" 
                            VisibleIndex="2" Visible="False">
                            <PropertiesComboBox ValueType="System.Int32">
                                <Items>
                                    <dxe:ListEditItem Text="Separador" Value="220" />
                                    <dxe:ListEditItem Text="Documento" Value="223" />
                                </Items>
                            </PropertiesComboBox>
                            <EditFormSettings Visible="True" />
                        </dxwtl:TreeListComboBoxColumn>
                        <dxwtl:TreeListComboBoxColumn Caption="Atributo" FieldName="Atributo" 
                            VisibleIndex="2" Visible="False">
                            <PropertiesComboBox ValueType="System.Int32">
                                <Items>
                                    <dxe:ListEditItem Text="Opcional" Value="0" />
                                    <dxe:ListEditItem Text="Al menos uno" Value="1" />
                                    <dxe:ListEditItem Text="Requerido" Value="2" />
                                </Items>
                            </PropertiesComboBox>
                        </dxwtl:TreeListComboBoxColumn>
                        <dxwtl:TreeListTextColumn Caption="idSeriePID" FieldName="idSeriePID" 
                            Visible="False" VisibleIndex="3">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Indices" VisibleIndex="2">
                            <PropertiesTextEdit DisplayFormatString="{0}">
                            </PropertiesTextEdit>
                            <EditFormSettings Visible="False" />
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="InstanciaNueva" FieldName="InstanciaNueva" 
                            Visible="False" VisibleIndex="3">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Imagen_close" FieldName="Imagen_close" 
                            Name="Imagen_close" Visible="False" VisibleIndex="3">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nivel_Logico_Fisico" 
                            FieldName="Nivel_Logico_Fisico" Name="Nivel_Logico_Fisico" Visible="False" 
                            VisibleIndex="3">
                            <PropertiesTextEdit DisplayFormatString="g">
                            </PropertiesTextEdit>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nivel" FieldName="Nivel" Name="Nivel" 
                            Visible="False" VisibleIndex="3">
                        </dxwtl:TreeListTextColumn>
                    </Columns>
                </dxwtl:ASPxTreeList>
            </center>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px">
                &nbsp;</td>
            <td style="height: 21px; text-align: left;">
                    <dxe:ASPxButton ID="ASPxButton2" runat="server" Text="Continuar" 
                        Visible="False" CausesValidation="False">
                    </dxe:ASPxButton>
                <asp:Label ID="lblError" runat="server" Font-Names="Arial" Font-Size="Small" 
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; text-align: center;" colspan="2">
                <asp:Label ID="lblindices" runat="server" Text="Indices de Búsqueda" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; text-align: center;" colspan="2">
            <center>
                <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
                    AutoGenerateColumns="False"  Visible="False" Width="283px">
                    <SettingsBehavior AllowGroup="False" AllowSort="False" />
                    <SettingsPager Mode="ShowAllRecords">
                    </SettingsPager>
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="CampoID" FieldName="CampoID" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idIndice" FieldName="idIndice" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indice_Tipo" FieldName="Indice_Tipo" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Documento Origen" FieldName="Serie_nombre" 
                            VisibleIndex="0">
                            <PropertiesTextEdit>
                                <Style Font-Size="XX-Small" ForeColor="#000066">
                                </Style>
                            </PropertiesTextEdit>
                            <CellStyle Font-Size="Smaller" ForeColor="#3F5DBC" HorizontalAlign="Left">
                            </CellStyle>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Nombre del campo" 
                            FieldName="Indice_descripcion" VisibleIndex="1">
                            <PropertiesTextEdit ClientInstanceName="Indice_descripcion">
                            </PropertiesTextEdit>
                            <DataItemTemplate>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 173px">
                                            <dxe:ASPxLabel ID="ASPxLabel2" runat="server" 
                                                Text='<%# Bind("Indice_descripcion") %>' Width="190px">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td>
                                            <dxe:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="200px">
                                            <ClientSideEvents KeyDown="function(s, e) 
                    {
                        s.SetText(s.GetText().toUpperCase());
                    }
                    "/>
                                            </dxe:ASPxTextBox>
                                            
                                        </td>
                                    </tr>
                                </table>
                            </DataItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indice_LongitudMax" 
                            FieldName="Indice_LongitudMax" VisibleIndex="1" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indice_Obligatorio" 
                            FieldName="Indice_Obligatorio" VisibleIndex="2" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indice_Unico" FieldName="Indice_Unico" 
                            VisibleIndex="3" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indice_Mascara" FieldName="Indice_Mascara" 
                            VisibleIndex="4" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" 
                            Visible="False" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idNorma" FieldName="idNorma" 
                            Visible="False" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idArea" FieldName="idArea" 
                            Visible="False" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idElemento" FieldName="idElemento" 
                            Visible="False" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" 
                            Visible="False" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                </dxwgv:ASPxGridView>
            </center>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; " colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 21px; " colspan="2">
            <center>
                <dxe:ASPxButton ID="btnSalvar" runat="server" AutoPostBack="False" 
                    CausesValidation="False" Text="Salvar" Visible="False">
                </dxe:ASPxButton>
            </center>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="dsLista_SeriesModelo" runat="server" 
                    SelectMethod="ListaSeries_Modelo" 
        TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:Parameter Name="identidad" Type="Int32" DefaultValue="" />
                        <asp:Parameter DefaultValue="5" Name="Profundidad" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsSeries_Indices" runat="server" 
                    SelectMethod="ListaSeries_Indices" 
        TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmbTipoExpediente" Name="idSerie" 
                            PropertyName="Value" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsLista_SeriesModelo_Hijos" runat="server" 
                    SelectMethod="ListaSeries_Modelo_Hijos" 
                    TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmbTipoExpediente" Name="idSerie" 
                            PropertyName="Value" Type="Int32" />
                        <asp:Parameter Name="identidad" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsSeries_IndicesDoc" runat="server" 
                    SelectMethod="ListaSeries_Indices" TypeName="Portalv9.WSArchivo.Service1" 
                    OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter Name="idSerie" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>

  

    
                <asp:ObjectDataSource ID="ds_Entidades" runat="server" 
         SelectMethod="ListaFondoxNivel" TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:Parameter Name="idArchivo" Type="Int32" />
                        <asp:Parameter DefaultValue="3" Name="Fondo_ini" Type="Int32" />
                        <asp:Parameter DefaultValue="3" Name="Fondo_fin" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="ds_AreasAdministrativas" runat="server" 
         SelectMethod="ListaFondoxNivelxPadre" TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:Parameter Name="idArchivo" Type="Int32" />
                        <asp:Parameter DefaultValue="4" Name="Fondo_ini" Type="Int32" />
                        <asp:Parameter DefaultValue="4" Name="Fondo_fin" Type="Int32" />
                        <asp:Parameter Name="Padre" Type="Int32" />
                    </SelectParameters>
     </asp:ObjectDataSource>

                  

    
</asp:Content>

