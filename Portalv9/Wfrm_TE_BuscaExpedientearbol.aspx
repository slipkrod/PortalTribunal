<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_BuscaExpedientearbol.aspx.vb" Inherits="Portalv9.Wfrm_TE_BuscaExpedientearbol" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text=""> </asp:Label>
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
                <asp:Label ID="lblindicet" runat="server" Text="Indice de Busqueda:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblIndice" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                <asp:Label ID="lblInstancia" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                &nbsp;</td>
            <td style="height: 21px; text-align: left;">
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
                <asp:Label ID="lbldoc" runat="server" Text="Documentos Recibidos" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                &nbsp;
                                  <asp:Label ID="lbldocumentos" runat="server" 
                    Font-Names="Arial" Font-Size="Small" 
                    ForeColor="Red"></asp:Label>
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
                <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dsExpediente" 
                    KeyFieldName="idDescripcion" ParentFieldName="idDocumentoPID" 
                    EnableTheming="False" Width="402px" 
                    ClientInstanceName="ASPxTreeList1">
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguro desea borrar este registro?" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos." />
                    <SettingsText ConfirmDelete="&#191;Seguro desea borrar este registro?" CommandEdit="Editar" 
                        CommandNew="Nuevo" CommandDelete="Borrar" CommandUpdate="Actualizar" 
                        CommandCancel="Cancelar" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos.">
                    </SettingsText>
                    <SettingsSelection Enabled="False" />
                    <SettingsPager PageSize="20">
                    </SettingsPager>
                    <Settings ShowColumnHeaders="False" />
                    <SettingsBehavior AllowSort="False" />
                    <SettingsEditing EditFormColumnCount="1" Mode="EditFormAndDisplayNode" />
                    <Settings ShowColumnHeaders="False">
                    </Settings>
                    <SettingsBehavior AllowSort="False">
                    </SettingsBehavior>
                    <SettingsEditing EditFormColumnCount="1" Mode="EditFormAndDisplayNode">
                    </SettingsEditing>
                    <Columns>
                        <dxwtl:TreeListTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Tipo" VisibleIndex="0" ReadOnly="True">
                            <EditFormSettings Visible="False">
                            </EditFormSettings>
                            <EditFormSettings Visible="False" />
                            <DataCellTemplate>
                                <dxe:ASPxImage ID="ASPxImage1" runat="server" 
                                    ImageUrl='<%# Eval("Imagen_close") %>'>
                                </dxe:ASPxImage>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nombre" FieldName="Descripcion" 
                            VisibleIndex="1">
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListComboBoxColumn Caption="Tipo de elemento" FieldName="idNivel" 
                            VisibleIndex="2" Visible="False">
                            <EditFormSettings Visible="True">
                            </EditFormSettings>
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
                        <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
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
                        <dxwtl:TreeListTextColumn Caption="InstanciaId" FieldName="InstanciaId" 
                            Name="InstanciaId" Visible="False" VisibleIndex="2">
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
                                  <dxe:ASPxButton ID="btnaceptar" runat="server" Text="Continuar" Visible="False">
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
                        <asp:ObjectDataSource ID="dsExpediente" runat="server" 
                            SelectMethod="ListaArchivo_Serie" TypeName="Portalv9.WSArchivo.Service1">
                            <SelectParameters>
                                <asp:Parameter Name="idArchivo" Type="Int32" />
                                <asp:QueryStringParameter Name="idSerie" QueryStringField="idDescripcion" 
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; text-align: center;" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 21px; " colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 21px; " colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
