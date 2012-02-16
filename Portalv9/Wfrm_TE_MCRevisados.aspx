<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_MCRevisados.aspx.vb" Inherits="Portalv9.Wfrm_TE_MCRevisados" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Monitoreo de Folios Revisados"> </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
        DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" 
        Font-Size="XX-Small">
     <SettingsText Title="Envío --> Mesa de Control --&gt  Monitoreo folios revisados" />
        <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Tipo de expediente" 
                FieldName="TipoExpediente" VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Código del expediente" 
                FieldName="Llave_expediente" VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Indice de Busqueda" 
                FieldName="Indice_de_busqueda" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Fecha de solicitud" 
                FieldName="Fecha_solicitud" VisibleIndex="3">
                <PropertiesTextEdit DisplayFormatString="{0:dd-MM-yyyy}">
                 </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                VisibleIndex="4">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                VisibleIndex="5">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="6">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
    <Settings ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="BuscaInstanciaDocumentosxEstado" 
        TypeName="Portalv9.SAEX.ServiciosSAEX">
        <SelectParameters>
            <asp:Parameter Name="EstadoID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
    <br />
</asp:Content>
