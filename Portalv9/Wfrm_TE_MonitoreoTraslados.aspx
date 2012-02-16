<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_MonitoreoTraslados.aspx.vb" Inherits="Portalv9.Wfrm_TE_MonitoreoTraslados" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content4" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Monitoreo de traslados"> </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
        DataSourceID="ObjectDataSource1" Font-Size="XX-Small">
    <SettingsText Title="Envío --&gt Archivo central/Monitoreo de traslados" />
     <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Folio de bolsa" FieldName="Folio_bolsa" 
                VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Estado en que se encuentra" 
                FieldName="EstadoNombre" VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. Exp." FieldName="No_Expedientes" 
                VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. Docs." FieldName="No_Documentos" 
                VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="Fecha_solicitud" Caption="Fecha de solicitud" 
                VisibleIndex="4">
                <PropertiesTextEdit DisplayFormatString="{0:dd-MM-yyyy}">
                 </PropertiesTextEdit>
                </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                VisibleIndex="5">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                VisibleIndex="6">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="7">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
    <Settings ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Monitoreo_Traslados" TypeName="Portalv9.SAEX.ServiciosSAEX">
    </asp:ObjectDataSource>
    <br />
    <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
