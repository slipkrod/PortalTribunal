<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="Wfrm_ValorizacionSeleccionados_Recibe.aspx.vb" Inherits="Portalv9.Wfrm_ValorizacionSeleccionados_Recibe" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Recepción</asp:label>
</div>
<br />
    <table style="width: 466px">
        <tr>
            <td style="width: 217px">
                Folio de transferencia Primaria:</td>
            <td>
                <dxe:ASPxSpinEdit ID="txtTransferencia" runat="server" AllowNull="False" 
                    Height="21px" Number="0" Width="120px" />
            </td>
            <td>
                <dxe:ASPxButton ID="btnBuscaTransferencia" runat="server" Text="Buscar">
                    <Image Url="~/Images/Buscar.gif">
                    </Image>
                </dxe:ASPxButton>
            </td>
        </tr>
        <tr>
            <td style="width: 217px">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td>
    <dxrp:ASPxRoundPanel ID="rpHeader" Width="100%" HeaderText="Datos de la trasferencia " 
      runat="server" ClientVisible="False">
    <PanelCollection>
        <dxp:PanelContent ID="PanelContent1" runat="server">
            <table style="width:100%">
                <tr>
                    <td style="width:20%">
                        <asp:label id="Label1" runat="server" Font-Names="Arial" Font-Bold="True" Text="Folio: "></asp:label>
                    </td>                        
                    <td style="width:30%">
                        <asp:label id="lblFolio" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                    <td style="width:20%">
                        <asp:label id="Label2" runat="server" Font-Names="Arial" Font-Bold="True" Text="Usuario que solicito: "></asp:label>
                    </td>                        
                    <td style="width:30%">
                        <asp:label id="lblUserName" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="Label3" runat="server" Font-Names="Arial" Font-Bold="True" Text="Archivo de Tramite: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblidArchivoOrigen" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                    <td>
                        <asp:label id="Label4" runat="server" Font-Names="Arial" Font-Bold="True" Text="Fecha de Solicitud: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblFecha_Solicitud" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="Label5" runat="server" Font-Names="Arial" Font-Bold="True" Text="Archivo de Concentracion: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblidArchivoDestino" runat="server" Font-Names="Arial"></asp:label>
                        <asp:label id="idArchivoDestino" runat="server" Font-Names="Arial" Visible="False"></asp:label>
                    </td>
                    <td>
                        <asp:label id="Label6" runat="server" Font-Names="Arial" Font-Bold="True" Text="Fecha de Aplicacion: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblFecha_Aplicacion" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                </tr>                    
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <dxwtl:ASPxTreeList ID="aspxtreeDocumentos" runat="server" 
                            AutoGenerateColumns="False" ClientInstanceName="aspxtreeDocumentos" 
                            DataSourceID="dsExpedientesTransferir" EnableViewState="False" Height="300px" 
                            KeyFieldName="idDescripcion" ParentFieldName="idDocumentoPID" Width="960px">
                            <Columns>
                                <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
                                    ReadOnly="True" Visible="False">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Niveles" VisibleIndex="0">
                                    <DataCellTemplate>
                                        <dxe:ASPxImage ID="ASPxImage2" runat="server" 
                                            ImageUrl="<%# GetNodeGlyph(Container) %>">
                                        </dxe:ASPxImage>
                                    </DataCellTemplate>
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Código de clasificación" 
                                    FieldName="Codigo_clasificacion" VisibleIndex="1" Width="260px">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Descripción" FieldName="Descripcion" 
                                    VisibleIndex="2">
                                    <CellStyle Wrap="True">
                                    </CellStyle>
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
                                    ReadOnly="True" Visible="False">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Cajas" FieldName="Cajas" VisibleIndex="3" 
                                    AllowSort="True">
                                </dxwtl:TreeListTextColumn>
                            </Columns>
                            <Settings GridLines="Horizontal" />
                            <SettingsBehavior AllowFocusedNode="True" />
                            <SettingsSelection AllowSelectAll="True" Enabled="True" Recursive="True" />
                            <SettingsEditing Mode="EditFormAndDisplayNode" />
                            <SettingsText CommandCancel="Cancelar" CommandDelete="Eliminar" 
                                CommandEdit="Editar" CommandNew="Insertar" CommandUpdate="Actualizar" 
                                ConfirmDelete="¿ Estás seguro de querer eliminar este nivel ?" 
                                RecursiveDeleteError="El nivel no puede ser borrado ya que tiene subniveles." />
                            <Templates>
                                <EditForm>
                                    <table style="width:315px;">
                                        <tr>
                                            <td style="width:150px">
                                                <dxe:ASPxLabel ID="Label7" runat="server" Text="Tipo de Nivel" Width="150px">
                                                </dxe:ASPxLabel>
                                            </td>
                                            <td style="width:160px">
                                                <dxe:ASPxComboBox ID="dlNiveles" runat="server" ClientInstanceName="dlNiveles" 
                                                    DataSourceID="ObjectDataSource3" DropDownStyle="DropDown" 
                                                    TextField="Nivel_Descripcion" Value='<%# Bind("idNivel") %>' 
                                                    ValueField="idNivel" ValueType="System.Int32" Width="160px">
                                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                      cbSerie.PerformCallback(dlNiveles.GetValue().toString()); 
                                                      }" />
                                                </dxe:ASPxComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:150px">
                                                <dxe:ASPxLabel ID="AspxLabel2" runat="server" Text="Tipo de Expediente" 
                                                    Width="150px">
                                                </dxe:ASPxLabel>
                                            </td>
                                            <td style="width:160px">
                                                <dxe:ASPxComboBox ID="cbSerie" runat="server" ClientInstanceName="cbSerie" 
                                                    DataSourceID="dsTipoDeExpediente" DropDownStyle="DropDown" 
                                                    TextField="Serie_nombre" Value='<%# Bind("idSerie") %>' ValueField="idSerie" 
                                                    ValueType="System.Int32" Width="160px">
                                                </dxe:ASPxComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dxe:ASPxLabel ID="AspxLabel1" runat="server" Text="Titulo">
                                                </dxe:ASPxLabel>
                                            </td>
                                            <td>
                                                <dxe:ASPxTextBox ID="txtDescripcion" runat="server" 
                                                    Value='<%# Bind("Descripcion") %>' Width="160px">
                                                </dxe:ASPxTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div style="width:322px;">
                                        <table>
                                            <tr>
                                                <td>
                                                    <dxe:ASPxButton ID="btnUpdtae" runat="server" Text="Actualizar">
                                                    </dxe:ASPxButton>
                                                </td>
                                                <td>
                                                    <dxe:ASPxButton ID="btnCancelar" runat="server" Text="Cancelar">
                                                    </dxe:ASPxButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </EditForm>
                            </Templates>
                        </dxwtl:ASPxTreeList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <dxe:ASPxButton ID="butTransferir" runat="server" Text="Aceptar">
                        </dxe:ASPxButton>
                    </td>
                </tr>
            </table>
        </dxp:PanelContent> 
    </PanelCollection> 
</dxrp:ASPxRoundPanel>     
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lblArchivo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
    <cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox>
    <asp:ObjectDataSource ID="dsArchivos" runat="server" 
            SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsExpedientesTransferir" runat="server" 
            SelectMethod="Lista_Transferencias_Primarias_Documentos" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="idFolio" Type="Int32" />
            <asp:Parameter DefaultValue="2" Name="idStatus" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </asp:Content>


