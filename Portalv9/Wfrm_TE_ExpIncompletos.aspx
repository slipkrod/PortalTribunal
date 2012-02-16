<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_ExpIncompletos.aspx.vb" Inherits="Portalv9.Wfrm_TE_ExpIncompletos" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1.Export, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dxwgv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Reporte de tránsito"> </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dxe:ASPxButton ID="btnexportar" runat="server" Text="Exportar a Excel" 
        Width="138px">
    </dxe:ASPxButton>
    <dxwgv:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
    </dxwgv:ASPxGridViewExporter>
    <br />

                <dxwgv:aspxgridview ID="ASPxGridView1" runat="server" 
                    DataSourceID="ObjectDataSource1" 
                    AutoGenerateColumns="False">
                     <SettingsPager PageSize="20">
                     </SettingsPager>
                     <SettingsText Title="Tránsito --&gt Archivo central/Reporte de tránsito" />
                     <Columns>
                         <dxwgv:GridViewDataHyperLinkColumn Caption="Código del Expediente" 
                             FieldName="instanciaID" VisibleIndex="0">
                             <PropertiesHyperLinkEdit NavigateUrlFormatString="Wfrm_TE_BajaDocumentosDet.aspx?InstanciaPID={0}" 
                                 TextField="llave_expediente">
                             </PropertiesHyperLinkEdit>
                         </dxwgv:GridViewDataHyperLinkColumn>
                         <dxwgv:GridViewDataTextColumn Caption="EFA" FieldName="efa" VisibleIndex="1">
                         </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                             VisibleIndex="2">
                         </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="3">
                         </dxwgv:GridViewDataTextColumn>
                     </Columns>
                     <Settings ShowTitlePanel="True" />
                </dxwgv:aspxgridview>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="BuscaExpedientesIncompletos" 
                    TypeName="Portalv9.SAEX.ServiciosSAEX" 
        OldValuesParameterFormatString="{0}">
                </asp:ObjectDataSource>
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
</asp:Content>
