<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_Oficina_monitoreofolios.aspx.vb" Inherits="Portalv9.Wfrm_Oficina_monitoreofolios" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Monitoreo de Folios"> </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
        DataSourceID="ObjectDataSource1" AutoGenerateColumns="False">
        <SettingsText Title="Envío --&gt; Oficinas/Monitoreo de folios" />
        <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Folio" FieldName="Folio_bolsa" 
                VisibleIndex="0" ToolTip="Folio de Bolsa">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. exp." FieldName="No_Expedientes" 
                VisibleIndex="1" ToolTip="Numero de Expedientes que contiene">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. docs." FieldName="No_Documentos" 
                VisibleIndex="2" ToolTip="Numero de Documentos que contiene">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Fecha" 
                FieldName="Fecha_solicitud" VisibleIndex="3" ToolTip="Fecha de Solicitud">
                <PropertiesTextEdit DisplayFormatString="{0:dd-MM-yyyy}">
                 </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                VisibleIndex="4" ToolTip="Usuario que solicitó">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                VisibleIndex="5" ToolTip="Entidad a la que pertenecen">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="6" 
                ToolTip="Area a la que pertenecen">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Settings ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="BuscaInstanciaXEstado" TypeName="Portalv9.SAEX.ServiciosSAEX">
        <SelectParameters>
            <asp:Parameter DefaultValue="3" Name="pintEstadoID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" 
        DataSourceID="ObjectDataSource2" AutoGenerateColumns="False">
    <SettingsText Title="Consulta --&gt; Oficinas/Monitoreo de folios" />
    <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Folio" FieldName="Folio_bolsa" 
                VisibleIndex="0" ToolTip="Folio de Bolsa">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. exp." FieldName="No_Expedientes" 
                VisibleIndex="1" ToolTip="Numero de Expedientes que contiene">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. docs." FieldName="No_Documentos" 
                VisibleIndex="2" ToolTip="Numero de Documentos que contiene">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Fecha" 
                FieldName="Fecha_solicitud" VisibleIndex="3" ToolTip="Fecha de Solicitud">
                <PropertiesTextEdit DisplayFormatString="{0:dd-MM-yyyy}">
                 </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                VisibleIndex="4" ToolTip="Usuario que solicito">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                VisibleIndex="5" ToolTip="Entidad a la que pertenecen">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="6" 
                ToolTip="Area a la que pertenecen">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Settings ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="BuscaInstanciaXEstado" 
        TypeName="Portalv9.SAEX.ServiciosSAEX" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="pintEstadoID" Type="Int32" DefaultValue="55" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <dxwgv:ASPxGridView ID="ASPxGridView3" runat="server" 
        DataSourceID="ObjectDataSource3" AutoGenerateColumns="False">
    <SettingsText Title="Recolección --&gt; Oficinas/Monitoreo de folios" />
    <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Folio" FieldName="Folio_bolsa" 
                VisibleIndex="0" ToolTip="Folio de Bolsa">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. exp." FieldName="No_Expedientes" 
                VisibleIndex="1" ToolTip="Numero de Expedientes">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. docs." FieldName="No_Documentos" 
                VisibleIndex="2" ToolTip="Numero de Documentos">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Fecha" 
                FieldName="Fecha_solicitud" VisibleIndex="3" ToolTip="Fecha de Solicitud">
                <PropertiesTextEdit DisplayFormatString="{0:dd-MM-yyyy}">
                </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                VisibleIndex="4" ToolTip="Usuario que Solicita">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                VisibleIndex="5" ToolTip="Entidad a la que pertenece">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="6" 
                ToolTip="Area a la que pertenece">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
    <Settings ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
       <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
        SelectMethod="BuscaInstanciaXEstado" 
        TypeName="Portalv9.SAEX.ServiciosSAEX" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="pintEstadoID" Type="Int32" DefaultValue="82" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
</asp:Content>

