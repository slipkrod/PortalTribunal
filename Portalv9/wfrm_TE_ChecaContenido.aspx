<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="wfrm_TE_ChecaContenido.aspx.vb" Inherits="Portalv9.wfrm_TE_ChecaContenido" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <TABLE id="Table2" style="width: 601px; height: 338px;" cellSpacing="0" 
                                cellPadding="0" border="0">
        <tr>
            <td style="HEIGHT: 23px; " vAlign="middle" align="right" colspan="2">
                <asp:HyperLink ID="Regresar" runat="server" ImageUrl="Images/regresar.gif" 
                    NavigateUrl='<%# "Wfrm_TE_RevArcCentral.aspx?FolioBolsa=" & Request.QueryString("FolioBolsa") %>'></asp:HyperLink>
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                    Font-Names="Arial" Font-Size="10pt" Height="16px" Width="544px"> Envío-&gt;Archivo central/Apertura de bolsasEnvío-&gt;Archivo central/Apertura de bolsas</asp:Label>
            </td>
        </tr>
        <tr>
            <td style="HEIGHT: 23px; " vAlign="middle" align="right" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="HEIGHT: 23px; width: 584px;" vAlign="middle" align="right">
                Es confidencial ?:&nbsp;</td>
            <td style="HEIGHT: 23px; width: 222px;" vAlign="middle" align="left">
                <dxe:ASPxCheckBox ID="chkConfiddencial" runat="server" ReadOnly="True">
                </dxe:ASPxCheckBox>
            </td>
        </tr>
        <tr>
            <td style="HEIGHT: 23px; width: 584px;" vAlign="middle" align="right">
                Tipo de expediente :</td>
            <td style="HEIGHT: 23px; width: 222px;" vAlign="middle" align="left">
                
                <dxe:ASPxLabel ID="lblTipoExpediente" runat="server">
                </dxe:ASPxLabel>
                </td>
        </tr>
        <tr>
            <td style="HEIGHT: 23px; width: 584px;" vAlign="middle" align="right">
                Entidad&nbsp;:</td>
            <td style="HEIGHT: 23px; width: 222px;" vAlign="middle" align="left">
                <dxe:ASPxLabel ID="lblEntidad" runat="server">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="HEIGHT: 23px; width: 584px;" vAlign="middle" align="right">
                Area&nbsp;administrativa&nbsp;:&nbsp;</td>
            <td style="HEIGHT: 23px; width: 222px;" vAlign="middle" align="left">
                <dxe:ASPxLabel ID="lblArea" runat="server">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="HEIGHT: 23px; width: 584px;" vAlign="middle" align="right">
                Año :</td>
            <td style="HEIGHT: 23px; width: 222px;" vAlign="middle" align="left">
                <dxe:ASPxLabel ID="lblAno" runat="server">
                </dxe:ASPxLabel>
            </td>
        </tr>                                
        <tr>
            <td style="HEIGHT: 23px; width: 584px;" vAlign="middle" align="right">
                Mes&nbsp;:</td>
            <td style="HEIGHT: 23px; width: 222px;" vAlign="middle" align="left">
                <dxe:ASPxLabel ID="lblMes" runat="server">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="HEIGHT: 23px; width: 584px;" vAlign="middle" align="right">
                Día&nbsp;:</td>
            <td style="HEIGHT: 23px; width: 222px;" vAlign="middle" align="left">
                <dxe:ASPxLabel ID="lblDia" runat="server">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="HEIGHT: 23px; width: 584px;" vAlign="middle" align="right">
                Código&nbsp;del expediente :</td>
            <td style="HEIGHT: 23px; width: 222px;" vAlign="middle" align="left">
                <dxe:ASPxLabel ID="lblLLave" runat="server">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="HEIGHT: 23px; width: 584px;" vAlign="middle" align="right">
                Índice de búsqueda&nbsp;:</td>
            <td style="HEIGHT: 23px; width: 222px;" vAlign="middle" align="left">
                <dxe:ASPxLabel ID="lblIndice" runat="server">
                </dxe:ASPxLabel>
                <dxe:ASPxLabel ID="lblInstancia" runat="server">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="WIDTH: 584px; text-align: right;" vAlign="top" align="left">
                Seleccione los documentos&nbsp;recibidos&nbsp;:</td>
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
                &nbsp;</td>
            <td >
                <asp:ImageButton ID="btnAceptar" runat="server" BorderWidth="0" 
                    CausesValidation="False" Height="65px" 
                    ImageUrl="~/Images/env_apertura_expedientes.gif" Width="109px" />
                &nbsp;&nbsp;
                <asp:ImageButton ID="btnDocumentosFaltantes" runat="server" BorderWidth="0" 
                    CausesValidation="False" Height="63px" ImageUrl="~/Images/env_doc_faltantes.gif" 
                    Width="99px" />
            </td>
        </tr>
        <tr>
            <td style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; FONT-FAMILY: Arial; HEIGHT: 36px"
										vAlign="top" align="right" colspan="2">
                <table style="width: 100%; font-size: 10px;" runat=server id="TBLDiferencias" cellpadding="0" 
                    cellspacing="0">
                    <tr>
                        <td style="width: 195px">
                            &nbsp;</td>
                        <td style="text-align: left">
                <dxe:ASPxRadioButtonList ID="RadioButtonList1" runat="server" SelectedIndex="0" 
                                            Width="396px" Font-Bold="False" Font-Size="10pt">
                    <Items>
                        <dxe:ListEditItem Text="No hay faltantes" Value="0" />
                        <dxe:ListEditItem Text="Inconsistencias (de más, de menos o cambiados)" 
                                                    Value="1" />
                    </Items>
                </dxe:ASPxRadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 195px">
                Descripción de la inconsistencia:</td>
                        <td style="text-align: left">
                <dxe:ASPxMemo ID="txtVariacion" runat="server" Height="71px" Width="400px">
                </dxe:ASPxMemo>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 195px">
                Observaciones:</td>
                        <td style="text-align: left">
                <dxe:ASPxMemo ID="txtObservaciones" runat="server" Height="71px" Width="400px">
                </dxe:ASPxMemo>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 195px">
                            &nbsp;</td>
                        <td style="text-align: left">
                <asp:imagebutton id="btnValidaBolsa" runat="server" Height="53px" Width="73px" ImageUrl="images/aceptar.gif"
												BorderWidth="0"></asp:imagebutton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="WIDTH: 584px" vAlign="bottom" align="left">
                &nbsp;</td>
            <td vAlign="top" align="left" style="width: 222px">
                <asp:label id="lblError" runat="server" Font-Names="Arial" Font-Size="X-Small" ForeColor="Red"></asp:label>
                        <asp:ObjectDataSource ID="dsExpediente" runat="server" 
                            SelectMethod="ReconstruyeArbolxBolsaxInstanciaPID" 
                    TypeName="Portalv9.SAEX.ServiciosSAEX" 
                    OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                                    Type="Int32" />
                                <asp:QueryStringParameter Name="Folio_bolsa" QueryStringField="FolioBolsa" 
                                    Type="String" />
                                <asp:QueryStringParameter Name="instanciaPID" QueryStringField="InstanciaPID" 
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                <dxe:ASPxLabel ID="lblDocumentos" runat="server" Visible="False">
                </dxe:ASPxLabel>
                <cc1:MsgBox ID="dlgBoxExcepciones" runat="server" />
            </td>
        </tr>
    </TABLE>
    <table style="width: 596px;">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td style="width: 194px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td style="width: 194px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td style="width: 194px">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

