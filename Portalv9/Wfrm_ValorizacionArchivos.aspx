﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="Wfrm_ValorizacionArchivos.aspx.vb" Inherits="Portalv9.Wfrm_ValorizacionArchivos" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" 
            NavigateUrl="Wfrm_Valorizacion.aspx" />
    <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Seleccione el archivo</asp:label>
</div>
<br />
    <table style="width:100%;">
        <tr>
            <td>
    <asp:Label ID="lblArchivo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 445px">
                    <tr>
                        <td>
                            Fecha de corte:
                        </td>
                        <td>
                            <dxe:ASPxDateEdit ID="deFechaCorte" runat="server">
                            </dxe:ASPxDateEdit>
                        </td>
                        <td>
                            <dxe:ASPxButton ID="btnBuscar" runat="server" Text="Buscar">
                            </dxe:ASPxButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <dxwgv:ASPxGridView ID="gdbuscadorresultado" runat="server" ClientInstanceName="grid" 
                    AutoGenerateColumns="False" DataSourceID="dsExpedientesTraspaso" Width="100%" 
                    KeyFieldName="idFolioDetalle" EnableCallBacks="False">
                    <SettingsBehavior AllowFocusedRow="true" />
                    <SettingsText Title="Expedientes a traspasar" />
                    <ClientSideEvents FocusedRowChanged="function(s, e) {
	//ASPxCallbackPanel1.PerformCallback(1);
}" />
                    <Columns>
                        <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" 
                            Caption="Seleccion">
                            <HeaderTemplate>
                                &nbsp;
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" Visible="False" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idDescripcion" FieldName="idDescripcion" Visible="False" VisibleIndex="3">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" VisibleIndex="4">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Nivel" FieldName="Nivel_Descripcion" 
                            VisibleIndex="1" Visible="False"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Código de clasificación" 
                            FieldName="Codigo_clasificacion" VisibleIndex="1"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Descripcion" FieldName="Descripcion" 
                            VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Alcance y Contenido" 
                            FieldName="Alcance_Contenido" VisibleIndex="5">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataColumn Caption="Tipo" VisibleIndex="3" Visible="False">
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
                            FieldName="Valor_administrativo" VisibleIndex="9">
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Valor &lt;br/&gt;Fiscal" 
                            FieldName="Valor_contable" VisibleIndex="10">
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
                        <dxwgv:GridViewDataTextColumn Caption="Acceso" FieldName="Acceso" 
                            VisibleIndex="12">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" VisibleIndex="13">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idDocumentoPID" 
                            FieldName="idDocumentoPID" Visible="False" VisibleIndex="10">
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowTitlePanel="True" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <dxe:ASPxButton ID="butTransferir" runat="server" Text="Aceptar"></dxe:ASPxButton>
            </td>
        </tr>
        <tr>
            <td>
               <dxcp:ASPxCallbackPanel ID="ASPxCallbackPanel1" 
                    ClientInstanceName="ASPxCallbackPanel1" 
                    oncallback="ASPxCallbackPanel1_Callback" runat="server" Width="100%" 
                    HideContentOnCallback="False">
                    <PanelCollection>
                        <dxp:PanelContent ID="PanelContent2" runat="server">
                            <iframe runat="server" id="iframeIndices" frameborder="0" width="100%" 
                                height="300"></iframe>                            
                        </dxp:PanelContent>
                    </PanelCollection>
                </dxcp:ASPxCallbackPanel>            
            </td>
        </tr>
        <tr>
            <td valign="top">

            </td>
        </tr>
    </table>
    <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
    <cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox>
    <asp:ObjectDataSource ID="dsExpedientesTraspaso" runat="server" 
            SelectMethod="ListaVencimientos_Archivo_Tramite" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="idFolio" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="Baja" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsArchivos" runat="server" 
            SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
    </asp:ObjectDataSource>
</asp:Content>
