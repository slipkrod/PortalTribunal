<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_MCSolicitudDocExp.aspx.vb" Inherits="Portalv9.Wfrm_TE_MCSolicitudDocExp" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
  <div id="pagetitle">
<asp:Label ID="lbltitle" runat="server" 
        Text="Administración--&gt; Unidad Documental Compuesta - Subserie"></asp:Label>
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
                <asp:Label ID="usuario" runat="server" Text="" Visible="False"></asp:Label>
                
                <asp:Label ID="grupo" runat="server" Text="" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lbltipoexpt" runat="server" Text="Tipo de Expediente:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblTipoExpediente" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 193px; text-align: right;">
                <asp:Label ID="lblentidadt" runat="server" Text="Entidad:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td>
                <asp:Label ID="lblEntidad" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblareat" runat="server" Text="Area Adminitrativa:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblArea" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblañot" runat="server" Text="Año:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblAno" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblmest" runat="server" Text="Mes:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblmes" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lbldiat" runat="server" Text="Dia: " 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lbldia" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblindicet" runat="server" Text="Indice de Busqueda:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblIndice" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblmest0" runat="server" Text="Codigo del Expediente: " 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblLlave" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                &nbsp;</td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblInstancia" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                <asp:Label ID="lblTipoDocumento" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                <asp:Label ID="lblIndiceCampos" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                <asp:Label ID="lblsecuencia" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                <asp:Label ID="lblidFolio" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                <asp:Label ID="lblTipo_operacion" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
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
                <asp:ObjectDataSource ID="dsLista_SeriesModelo_Hijos" runat="server" 
                    SelectMethod="ListaSeries_Modelo_Hijos" 
                    TypeName="Portalv9.WSArchivo.Service1" 
                    OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                       <asp:Parameter Name="IdSerie" Type="Int32" />
                        <asp:Parameter Name="identidad" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <dxwtl:ASPxTreeList ID="ASPxTreeList2" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dsLista_SeriesModelo_Hijos" 
                    KeyFieldName="idSerie" ParentFieldName="idSeriePID" 
                    EnableTheming="False" Width="195px" 
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
                <br />
                </center>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px">
                &nbsp;</td>
            <td style="height: 21px; text-align: left;">
                                  <dxe:ASPxButton ID="btnaceptar" runat="server" Text="Continuar">
                                  </dxe:ASPxButton>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px">
                &nbsp;</td>
            <td style="height: 21px; text-align: left;">
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
                <asp:ObjectDataSource ID="dsSeries_IndicesDoc" runat="server" 
                    OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="ListaSeries_Indices" TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:Parameter Name="idSerie" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
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
                    
                    
                    </td>
        </tr>
        <tr>
            <td style="height: 21px; " colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 21px; " colspan="2">
            <center>
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/Images/aceptar.gif" Visible="False" />
            </center>
            </td>
        </tr>
    </table>
</asp:Content>
