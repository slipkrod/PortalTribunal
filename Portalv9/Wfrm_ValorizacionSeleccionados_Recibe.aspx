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
    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" />
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
                        <dxwgv:ASPxGridView ID="gdbuscadorresultado" runat="server" 
                            AutoGenerateColumns="False" ClientInstanceName="grid" 
                            DataSourceID="dsExpedientes" EnableCallBacks="False" 
                            KeyFieldName="idFolioDetalle" Width="900px">
                            <Columns>
                                <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        &nbsp;
                                    </HeaderTemplate>
                                </dxwgv:GridViewCommandColumn>
                                <dxwgv:GridViewDataTextColumn FieldName="idFolioDetalle" Visible="False" 
                                    VisibleIndex="1">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" 
                                    Visible="False" VisibleIndex="1">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="idDescripcion" FieldName="idDescripcion" 
                                    Visible="False" VisibleIndex="3">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" 
                                    Visible="False" VisibleIndex="4">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Nivel" FieldName="Nivel_Descripcion" 
                                    Visible="False" VisibleIndex="1">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Código de clasificación" 
                                    FieldName="Codigo_clasificacion" VisibleIndex="1">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Descripcion" FieldName="Descripcion" 
                                    VisibleIndex="2">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Alcance y Contenido" 
                                    FieldName="Alcance_Contenido" VisibleIndex="5">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataColumn Caption="Tipo" Visible="False" VisibleIndex="3">
                                    <DataItemTemplate>
                                        <%#IIf(Eval("Nivel_Logico_Fisico") = 0, "Logico", "Fisico")%>
                                    </DataItemTemplate>
                                </dxwgv:GridViewDataColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Apertura" FieldName="Apertura" 
                                    VisibleIndex="3">
                                    <PropertiesTextEdit DisplayFormatString="d">
                                    </PropertiesTextEdit>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Cierre" FieldName="Cierre" 
                                    VisibleIndex="4">
                                    <PropertiesTextEdit DisplayFormatString="d">
                                    </PropertiesTextEdit>
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Volumen y Soporte" VisibleIndex="6">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Plazo AT" FieldName="Plazo_AT" 
                                    VisibleIndex="7">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Plazo AC" FieldName="Plazo_AC" 
                                    VisibleIndex="8">
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
                                    FieldName="Valor_legal" VisibleIndex="11">
                                    <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                                        ValueUnchecked="0">
                                    </PropertiesCheckEdit>
                                </dxwgv:GridViewDataCheckColumn>
                                
                                <dxwgv:GridViewDataTextColumn Caption="Cajas" FieldName="Cajas" 
                                    VisibleIndex="12">
                                </dxwgv:GridViewDataTextColumn>                                
                                <dxwgv:GridViewDataTextColumn Caption="Acceso" FieldName="Acceso" 
                                    VisibleIndex="13">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" 
                                    Visible="False" VisibleIndex="13">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="idDocumentoPID" 
                                    FieldName="idDocumentoPID" Visible="False" VisibleIndex="10">
                                </dxwgv:GridViewDataTextColumn>
                            </Columns>
                            <Settings ShowHorizontalScrollBar="True" />
                        </dxwgv:ASPxGridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
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
    <asp:ObjectDataSource ID="dsExpedientes" runat="server" 
            SelectMethod="ListaVencimientos_Archivo_Tramite_Recepcion" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="idFolio" Type="Int32" />
            <asp:Parameter DefaultValue="2" Name="idStatus" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsArchivos" runat="server" 
            SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
    </asp:ObjectDataSource>
</asp:Content>


