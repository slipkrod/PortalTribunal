<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="Wfrm_ValorizacionSeleccionados.aspx.vb" Inherits="Portalv9.Wfrm_ValorizacionSeleccionados" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Inventario Preliminar"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" 
            NavigateUrl="~/Wfrm_Valorizacion.aspx" />
    <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Seleccione el archivo a transferir</asp:label>
    <br />
    <dxrp:ASPxRoundPanel ID="rpHeader" Width="100%" HeaderText="Datos de la trasferencia " 
      runat="server">
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
            </table>
        </dxp:PanelContent> 
    </PanelCollection> 
</dxrp:ASPxRoundPanel>     
</div>
<br />
    <table style="width:100%;" id="tableMain" runat="server" >
        <tr>
            <td style="width: 737px" colspan="2">
                <dxwgv:ASPxGridView ID="gdbuscadorresultado" runat="server" ClientInstanceName="grid" 
                    AutoGenerateColumns="False" DataSourceID="dsExpedientesTransferir" Width="1000px" 
                    KeyFieldName="idFolioDetalle" EnableCallBacks="False">
                    <Templates>
                        <TitlePanel>
                            <table style="width: 100%">
                                <tr>
                                    <td style="text-align: center">
                                        Expedientes a transferir</td>
                                </tr>
                                <tr>
                                    <td>
                                        <dxe:ASPxButton ID="ASPxButton1" runat="server" Text="Cajas" Width="67px" 
                                            onclick="ASPxButton1_Click">
                                            <Image Url="~/Images/Cajas.png">
                                            </Image>
                                        </dxe:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </TitlePanel>
                    </Templates>
                    <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
                    <SettingsText Title="Expedientes a Transferir" />
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" Visible="False" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="idFolioDetalle" Visible="False" 
                            VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idDescripcion" FieldName="idDescripcion" Visible="False" VisibleIndex="3">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" VisibleIndex="4">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Nivel" FieldName="Nivel_Descripcion" 
                            VisibleIndex="1" Visible="False"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Código de clasificación" 
                            FieldName="Codigo_clasificacion" VisibleIndex="0"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Descripcion" FieldName="Descripcion" 
                            VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Alcance y Contenido" 
                            FieldName="Alcance_Contenido" VisibleIndex="4">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataColumn Caption="Tipo" VisibleIndex="3" Visible="False">
                             <DataItemTemplate>
                                 <%#IIf(Eval("Nivel_Logico_Fisico") = 0, "Logico", "Fisico")%>
                             </DataItemTemplate>
                        </dxwgv:GridViewDataColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Apertura" FieldName="Apertura" 
                            VisibleIndex="2">
                            <PropertiesTextEdit DisplayFormatString="d">
                            </PropertiesTextEdit>
                            <HeaderStyle HorizontalAlign="Center" />
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Cierre" FieldName="Cierre" 
                            VisibleIndex="3">
                            <PropertiesTextEdit DisplayFormatString="d">
                            </PropertiesTextEdit>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Volumen y Soporte" VisibleIndex="5">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Plazo AT" FieldName="Plazo_AT" 
                            VisibleIndex="6">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Plazo AC" FieldName="Plazo_AC" 
                            VisibleIndex="7">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Valor &lt;br/&gt;Administrativo" 
                            FieldName="Valor_administrativo" VisibleIndex="8">
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Valor &lt;br/&gt;Fiscal" 
                            FieldName="Valor_contable" VisibleIndex="9">
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Valor &lt;br/&gt;Legal" 
                            FieldName="Valor_legal" VisibleIndex="10">
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                        </dxwgv:GridViewDataCheckColumn>
                        
                        <dxwgv:GridViewDataTextColumn Caption="Acceso" FieldName="Acceso" 
                            VisibleIndex="11">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Cajas" FieldName="Cajas" 
                            VisibleIndex="12">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" VisibleIndex="13">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="idDocumentoPID" Visible="False" 
                            VisibleIndex="9">
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowTitlePanel="True" ShowHorizontalScrollBar="True" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="2" style="text-align: right">
                <dxe:ASPxButton ID="butRepAutorizacion" runat="server" 
                    Text="Reporte de Autorización" Width="190px"></dxe:ASPxButton>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 341px">
                <dxe:ASPxButton ID="butCambiar" runat="server" Text="Editar Lista" 
                    Width="160px">
                </dxe:ASPxButton>
            </td>
            <td valign="top">
                <dxe:ASPxButton ID="butAceptar" runat="server" Text="Generar Transferencia" 
                    Width="160px">
                </dxe:ASPxButton>
            </td>
        </tr>
        </table>
    <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
    <asp:ObjectDataSource ID="dsExpedientesTransferir" runat="server" 
            SelectMethod="ListaVencimientos_Archivo_Tramite_Seleccionados" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:QueryStringParameter Name="idFolio" QueryStringField="idFolio" 
                Type="Int32"  />
            <asp:Parameter DefaultValue="1" Name="idStatus" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="Baja" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsExpedientesEliminar" runat="server" 
            SelectMethod="ListaVencimientos_Archivo_Tramite_Seleccionados" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:QueryStringParameter Name="idFolio" QueryStringField="idFolio" 
                Type="Int32"  />
            <asp:Parameter DefaultValue="1" Name="idStatus" Type="Int32" />
            <asp:Parameter DefaultValue="1" Name="Baja" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsTransferenciaActiva" runat="server" 
            SelectMethod="ListaVencimientos_Archivo_Tramite_Seleccionados" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
        <SelectParameters>
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                Type="Int32"  />
            <asp:QueryStringParameter Name="idFolio" QueryStringField="idFolio" 
                Type="Int32"  />
        </SelectParameters>
    </asp:ObjectDataSource>
    </asp:Content>
