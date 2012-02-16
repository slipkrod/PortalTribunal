<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_EN_ActasPerdidas.aspx.vb" Inherits="Portalv9.Wfrm_EN_ActasPerdidas" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="Label2" runat="server" Text="Generación de actas"> </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" 
         Text="Envío --&gt Rechazos/Generación de actas" Font-Names="Arial" 
         Font-Size="Medium" ForeColor="#3F5DBC"></asp:Label>
    <br />
    <br />
     <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
        DataSourceID="ObjectDataSource1" Font-Size="XX-Small" 
        AutoGenerateColumns="False" KeyFieldName="InstanciaId">
        <Columns>
             <dxwgv:GridViewDataTextColumn Caption="Folio de bolsa" FieldName="Folio_bolsa" 
                 VisibleIndex="0">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Tipo de expediente" 
                 FieldName="TipoExpediente" VisibleIndex="1">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Código del expediente" 
                 FieldName="Llave_expediente" VisibleIndex="2">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Indice de búsqueda" 
                 FieldName="Indice_de_busqueda" VisibleIndex="3">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Fecha de solicitud" 
                 FieldName="Fecha_solicitud" VisibleIndex="4">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                 VisibleIndex="5">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                 VisibleIndex="6">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="7">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataComboBoxColumn Caption="Tipo de Acta" 
                 FieldName="Status_Bolsa" Name="Status_Bolsa" VisibleIndex="8">
                 <PropertiesComboBox ValueType="System.String">
                     <Items>
                         <dxe:ListEditItem Text="Acta de pérdida" Value="2" />
                         <dxe:ListEditItem Text="Acta de liberación" Value="3" />
                     </Items>
                 </PropertiesComboBox>
             </dxwgv:GridViewDataComboBoxColumn>
             <dxwgv:GridViewDataHyperLinkColumn Caption="Acta" FieldName="InstanciaId" 
                 VisibleIndex="9">
                 <PropertiesHyperLinkEdit ImageUrl="~/Images/documento.gif" 
                     NavigateUrlFormatString="~/Archivos/ActaP_{0}.gif">
                 </PropertiesHyperLinkEdit>
             </dxwgv:GridViewDataHyperLinkColumn>
             <dxwgv:GridViewDataTextColumn VisibleIndex="10">
                 <DataItemTemplate>
                     <dxe:ASPxButton ID="ASPxButton1" runat="server" CommandName="Aceptar" 
                         Text="Aceptar acta">
                     </dxe:ASPxButton>
                 </DataItemTemplate>
             </dxwgv:GridViewDataTextColumn>
         </Columns>
     </dxwgv:ASPxGridView>
     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="BuscaInstanciaExpedientexEstado" 
        TypeName="Portalv9.SAEX.ServiciosSAEX">
         <SelectParameters>
             <asp:Parameter DefaultValue="11" Name="EstadoID" Type="Int32" />
         </SelectParameters>
     </asp:ObjectDataSource>
    <br />

     <dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" 
        DataSourceID="ObjectDataSource2" Font-Size="XX-Small" 
        AutoGenerateColumns="False">
        <Columns>
             <dxwgv:GridViewDataTextColumn Caption="Folio de bolsa" FieldName="Folio_bolsa" 
                 VisibleIndex="0">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Tipo de expediente" 
                 FieldName="TipoExpediente" VisibleIndex="1">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Código del expediente" 
                 FieldName="Llave_expediente" VisibleIndex="2">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Indice de búsqueda" 
                 FieldName="Indice_de_busqueda" VisibleIndex="3">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Fecha de solicitud" 
                 FieldName="Fecha_solicitud" VisibleIndex="4">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                 VisibleIndex="5">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                 VisibleIndex="6">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="7">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataComboBoxColumn Caption="Tipo de Acta" 
                 FieldName="Status_Bolsa" VisibleIndex="8">
                 <PropertiesComboBox ValueType="System.String">
                     <Items>
                         <dxe:ListEditItem Text="Acta de pérdida" Value="2" />
                         <dxe:ListEditItem Text="Acta de liberación" Value="3" />
                     </Items>
                 </PropertiesComboBox>
             </dxwgv:GridViewDataComboBoxColumn>
             <dxwgv:GridViewDataHyperLinkColumn Caption="Acta" FieldName="InstanciaId" 
                 VisibleIndex="9">
                 <PropertiesHyperLinkEdit ImageUrl="~/Images/documento.gif" 
                     NavigateUrlFormatString="~/Archivos/ActaP_{0}.gif">
                 </PropertiesHyperLinkEdit>
             </dxwgv:GridViewDataHyperLinkColumn>
             <dxwgv:GridViewDataTextColumn VisibleIndex="10">
                 <DataItemTemplate>
                     <dxe:ASPxButton ID="ASPxButton1" runat="server" CommandName="Aceptar" 
                         Text="Aceptar acta">
                     </dxe:ASPxButton>
                 </DataItemTemplate>
             </dxwgv:GridViewDataTextColumn>
         </Columns>
     </dxwgv:ASPxGridView>
     <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="BuscaInstanciaDocumentoxEstado" 
        TypeName="Portalv9.SAEX.ServiciosSAEX">
         <SelectParameters>
             <asp:Parameter DefaultValue="11" Name="EstadoID" Type="Int32" />
         </SelectParameters>
     </asp:ObjectDataSource>
     <br />
     <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
     <br />
</asp:Content>
