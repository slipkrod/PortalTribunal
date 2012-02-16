<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_MCRevisionDet.aspx.vb" Inherits="Portalv9.Wfrm_TE_MCRevisionDet" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <TABLE id="Table2" style="width: 601px; height: 338px;" cellSpacing="0" 
                                cellPadding="0" border="0">
        <tr>
            <td style="HEIGHT: 23px; width: 584px;" vAlign="middle" align="right">
                Folio 
												de bolsa de seguridad:&nbsp; 
									</td>
            <td style="HEIGHT: 23px; width: 222px;" vAlign="middle" align="left">
                <asp:label id="lblFolioBolsa" runat="server" Width="336px" Font-Names="Arial" Font-Size="10pt">Label</asp:label>
            </td>
        </tr>
        <tr>
            <td style="WIDTH: 584px" vAlign="top" align="right">
                Código&nbsp;del 
																				expediente:&nbsp;</td>
            <td vAlign="top" align="left" style="width: 222px">
                <asp:label id="lblLLave" 
                                            runat="server" Width="406px" Font-Names="Arial" Font-Size="10pt"></asp:label>
            </td>
        </tr>
        <tr>
            <td style="WIDTH: 584px" vAlign="top" align="left">
                &nbsp;</td>
            <td vAlign="top" align="left" style="width: 222px">
                <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dsExpediente" 
                    KeyFieldName="idDescripcion" ParentFieldName="idDocumentoPID" 
                    EnableTheming="False" Width="402px" 
                    ClientInstanceName="ASPxTreeList1">
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguro desea borrar este registro?" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos." />
                    <SettingsSelection Enabled="True" />
                    <SettingsText ConfirmDelete="&#191;Seguro desea borrar este registro?" CommandEdit="Editar" 
                        CommandNew="Nuevo" CommandDelete="Borrar" CommandUpdate="Actualizar" 
                        CommandCancel="Cancelar" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos.">
                    </SettingsText>
                    <SettingsSelection Enabled="True" />
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
            <td style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; WIDTH: 584px; FONT-FAMILY: Arial; HEIGHT: 36px"
										vAlign="top" align="right">
            </td>
            <td >
                <dxe:ASPxRadioButtonList ID="RadioButtonList1" runat="server" SelectedIndex="0" 
                                            Width="396px">
                    <Items>
                        <dxe:ListEditItem Text="No hay faltantes" Value="0" />
                        <dxe:ListEditItem Text="Inconsistencias (de más, de menos o cambiados)" 
                                                    Value="1" />
                    </Items>
                </dxe:ASPxRadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 584px;">
                <asp:label id="Label3" runat="server">Nombre:</asp:label>
            </td>
            <td>
                <dxe:ASPxTextBox ID="txtNombre" runat="server" MaxLength="150" Width="400px">
                </dxe:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 584px;">
                Incidencias:</td>
            <td>
                <dxe:ASPxMemo ID="txtObservaciones" runat="server" Height="71px" Width="400px">
                </dxe:ASPxMemo>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 584px;">
                Ejecutivo:</td>
            <td>
                <dxe:ASPxTextBox ID="txtEjecutivo" runat="server" MaxLength="150" Width="400px">
                </dxe:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 584px;">
                Sucursal:</td>
            <td>
                <dxe:ASPxTextBox ID="txtSucursal" runat="server" MaxLength="150" Width="400px">
                </dxe:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 584px;">
                No Cuenta:</td>
            <td>
                <dxe:ASPxTextBox ID="txtCuenta" runat="server" MaxLength="50" Width="400px">
                </dxe:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 584px;">
                No Cliente:</td>
            <td>
                <dxe:ASPxTextBox ID="txtCliente" runat="server" MaxLength="50" Width="400px">
                </dxe:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td style="WIDTH: 584px" vAlign="bottom" align="left">
                &nbsp;</td>
            <td vAlign="top" align="left" style="width: 222px">
                <asp:imagebutton id="btnValidaBolsa" runat="server" Height="53px" Width="73px" ImageUrl="images/aceptar.gif"
												BorderWidth="0"></asp:imagebutton>
            </td>
        </tr>
        <tr>
            <td style="WIDTH: 584px" vAlign="bottom" align="left">
                &nbsp;</td>
            <td vAlign="top" align="left" style="width: 222px">
                <asp:label id="lblError" runat="server" Font-Names="Arial" Font-Size="X-Small" ForeColor="Red"></asp:label>
                        <asp:ObjectDataSource ID="dsExpediente" runat="server" 
                            SelectMethod="ReconstruyeArbolxBolsa" TypeName="Portalv9.SAEX.ServiciosSAEX">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                                    Type="Int32" />
                                <asp:QueryStringParameter Name="Folio_bolsa" QueryStringField="FolioBolsa" 
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                <dxe:ASPxLabel ID="lblDocumentos" runat="server" Visible="False">
                </dxe:ASPxLabel>
            </td>
        </tr>
    </TABLE>
</asp:Content>
