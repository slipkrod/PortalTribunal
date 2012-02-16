<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_BE_DestruccionFolio.aspx.vb" Inherits="Portalv9.Wfrm_BE_DestruccionFolio" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbltitulo" runat="server" Text="Término --&amp;gt Destrucción/Archivo inactivo/Digitalizar acta de destrucción" 
        Font-Names="Arial" Font-Size="Medium" ForeColor="#3F5DBC"></asp:Label>
    <br />
    <br />
    <dxwgv:aspxgridview ID="ASPxGridView1" runat="server" 
        DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" 
        Font-Size="XX-Small">
        <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Núm. orden de destrucción" 
                FieldName="Folio_destruccion" VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Fecha" FieldName="Fecha_destruccion" 
                VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataHyperLinkColumn FieldName="Folio_destruccion" 
                VisibleIndex="2">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="Wfrm_BE_AutorizaDestruccionEX.aspx?Folio_destruccion={0}" 
                    Text="Ver">
                </PropertiesHyperLinkEdit>
            </dxwgv:GridViewDataHyperLinkColumn>
        </Columns>
    </dxwgv:aspxgridview>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="BuscaFolioDestruccionEstado" 
        TypeName="Portalv9.SAEX.ServiciosSAEX">
        <SelectParameters>
            <asp:Parameter DefaultValue="110" Name="estadoID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
    <br />

    <br />
</asp:Content>

