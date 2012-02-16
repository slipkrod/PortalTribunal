<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_ArchivoExpDocsDet.aspx.vb" Inherits="Portalv9.Wfrm_TE_ArchivoExpDocsDet" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td class="style1" style="width: 120px">
                &nbsp;</td>
            <td>
                <dxe:ASPxLabel ID="lblConfidencial" runat="server">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                Tipo de expediente :</td>
            <td>
                <dxe:ASPxLabel ID="lblTipoExpediente" runat="server">
                </dxe:ASPxLabel>
                <dxe:ASPxLabel ID="lblClaveTipoExpediente" runat="server" Visible="False">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                Entidad:</td>
            <td>
                <dxe:ASPxLabel ID="lblEntidad" runat="server">
                </dxe:ASPxLabel>
                <dxe:ASPxLabel ID="lblidEntidad" runat="server" Visible="False">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                Area administrativa:</td>
            <td>
                <dxe:ASPxLabel ID="lblAreaAdministracion" runat="server">
                </dxe:ASPxLabel>
                <dxe:ASPxLabel ID="lblidArea" runat="server" Visible="False">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                Año:</td>
            <td>
                <asp:Label ID="lblAno" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Width="91px" Height="17px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                Mes:</td>
            <td>
                <asp:Label ID="lblMes" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Width="50px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                Día:</td>
            <td>
                <asp:Label ID="lblDia" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Width="93px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                Código de expediente:</td>
            <td>
                <dxe:ASPxLabel ID="lblLLave" runat="server">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                <b><font color="#000000" face="Arial, Helvetica, sans-serif" size="2">Asignar 
                EFA&nbsp;:</font></b></td>
            <td>
                <dxe:ASPxTextBox ID="txtEFA" runat="server" Width="250px">
                    <ValidationSettings CausesValidation="True">
                        <RequiredField ErrorText="* Campo requerido" IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                Seleccione los documentos a archivar:</td>
            <td>
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
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                Indices de búsqueda:</td>
            <td>
                <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
                    AutoGenerateColumns="False" Width="283px">
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
                        <dxwgv:GridViewDataTextColumn Caption="Documento Origen" FieldName="Descripcion" 
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
                                            <dxe:ASPxLabel ID="ASPxLabel3" runat="server" Text='<%# Bind("Valor") %>' 
                                                Width="190px">
                                            </dxe:ASPxLabel>
                                            
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
                        <dxwgv:GridViewDataTextColumn Caption="idFolio" FieldName="idFolio" 
                            Visible="False" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" 
                            Visible="False" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idDescripcion" FieldName="idDescripcion" 
                            Visible="False" VisibleIndex="3">
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                &nbsp;</td>
            <td>
                <p>
                    <asp:ImageButton ID="btnAceptar" runat="server" BorderWidth="0" 
                        CausesValidation="False" Height="53px" ImageUrl="images/aceptar.gif" 
                        Width="73px" />
                </p>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 120px">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblSecuencia" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Visible="False" Width="86px"></asp:Label>
                <asp:Label ID="lblInstancia" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Visible="False" Width="73px"></asp:Label>
                <asp:Label ID="lblidNorma" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Visible="False" Width="67px"></asp:Label>
                <asp:Label ID="lblidSerie" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Visible="False" Width="63px"></asp:Label>
                <asp:Label ID="lblidDocumentoPID" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Visible="False" Width="119px" Height="16px"></asp:Label>
            </td>
        </tr>
    </table>                        
    <asp:ObjectDataSource ID="dsExpediente" runat="server" 
     SelectMethod="ReconstruyeArbolxBolsa" TypeName="Portalv9.SAEX.ServiciosSAEX">
     <SelectParameters>
        <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
        <asp:QueryStringParameter Name="Folio_bolsa" QueryStringField="Folio_bolsa" 
             Type="String" />
     </SelectParameters>
     </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsLista_SeriesModelo" runat="server" 
                    SelectMethod="ListaSeries_Modelo" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter Name="identidad" Type="Int32" DefaultValue="" />
                        <asp:Parameter DefaultValue="5" Name="Profundidad" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    <cc1:MsgBox ID="dlgBoxExcepciones" runat="server" />
</asp:Content>

