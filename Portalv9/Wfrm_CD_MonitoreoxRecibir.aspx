<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_CD_MonitoreoxRecibir.aspx.vb" Inherits="Portalv9.Wfrm_CD_MonitoreoxRecibir" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Monitoreo de Folios por recibir"> </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
        DataSourceID="ObjectDataSource1" AutoGenerateColumns="False">
    <SettingsText Title="Envío --&gt Centro de distribución/Monitoreo folios por recibir" />
        <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Mensajería" FieldName="Mensajeria" 
                VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Folo de bolsa" FieldName="Folio_bolsa" 
                VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. de expedientes que contiene" 
                FieldName="No_Expedientes" VisibleIndex="2">
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
        SelectMethod="BuscaInstanciaXEstado" TypeName="Portalv9.SAEX.ServiciosSAEX">
        <SelectParameters>
            <asp:Parameter Name="pintEstadoID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" 
        DataSourceID="ObjectDataSource2">
    <SettingsText Title="Consulta --&gt Centro de distribución/Monitoreo de folios por recibir" />
     <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Mensajería" FieldName="Mensajeria" 
                VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Folo de bolsa" FieldName="Folio_bolsa" 
                VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. de expedientes que contiene" 
                FieldName="No_Expedientes" VisibleIndex="2">
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
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"
    SelectMethod="BuscaInstanciaXEstado" TypeName="Portalv9.SAEX.ServiciosSAEX">
        <SelectParameters>
            <asp:Parameter Name="pintEstadoID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <dxwgv:ASPxGridView ID="ASPxGridView3" runat="server" 
        DataSourceID="ObjectDataSource3">
    <SettingsText Title="Recolección --&gt Centro de distribución/Monitoreo folios por recibir" />
     <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Mensajería" FieldName="Mensajeria" 
                VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Folo de bolsa" FieldName="Folio_bolsa" 
                VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. de expedientes que contiene" 
                FieldName="No_Expedientes" VisibleIndex="2">
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
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"
    SelectMethod="BuscaInstanciaXEstado" TypeName="Portalv9.SAEX.ServiciosSAEX">
        <SelectParameters>
            <asp:Parameter Name="pintEstadoID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
    <br />
</asp:Content>
