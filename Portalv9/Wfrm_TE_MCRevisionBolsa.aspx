<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_MCRevisionBolsa.aspx.vb" Inherits="Portalv9.Wfrm_TE_MCRevisionBolsa" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxMenu" tagprefix="dxm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Envío --&gt Rechazos/Generación de actas"> </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
    
    <br />
        <asp:Label ID="Label2" runat="server" Text="Folio de bolsa de Seguridad: "></asp:Label>
    <asp:Label ID="lblFolioBolsa" runat="server" Text=""></asp:Label>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
        DataSourceID="ObjectDataSource1" AutoGenerateColumns="False">
            <Columns>
                <dxwgv:GridViewDataTextColumn Caption="Tipo de expediente" 
                    FieldName="TipoExpediente" VisibleIndex="0">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="Código del expediente" 
                    FieldName="Llave_expediente" VisibleIndex="1">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="Indice de búsqueda" 
                    FieldName="Indice_de_busqueda" VisibleIndex="2">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataHyperLinkColumn VisibleIndex="3">
                    <PropertiesHyperLinkEdit Text="Verificar contenidos">
                    </PropertiesHyperLinkEdit>
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%#"Wfrm_TE_MCRevisionDet.aspx?FolioBolsa="& eval("folio_bolsa")& "&InstanciaID=" & eval("InstanciaPID")%>'
                            Text="Verificar Contenidos" />
                    </DataItemTemplate>
                </dxwgv:GridViewDataHyperLinkColumn>
            </Columns>
        </dxwgv:ASPxGridView>
        <br />
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="BuscaInstanciaExpedientexEstadoxBolsa" 
        TypeName="Portalv9.SAEX.ServiciosSAEX">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblFolioBolsa" Name="Folio_Bolsa" 
                PropertyName="Text" Type="String" />
            <asp:Parameter DefaultValue="20" Name="EstadoID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
    
</asp:Content>

