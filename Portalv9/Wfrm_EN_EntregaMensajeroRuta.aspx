<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_EN_EntregaMensajeroRuta.aspx.vb" Inherits="Portalv9.Wfrm_EN_EntregaMensajeroRuta" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
<asp:Label ID="Label1" runat="server" 
            Text=" Consulta-&gt;Centro de distribución/Entrega folios a mensajería"></asp:Label>
</div>
</asp:Content>
  
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblnoid" runat="server" ForeColor="Black" Visible="False"></asp:Label>
    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
    DataSourceID="daExpedientes" EnableTheming="False" 
        CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css" CssPostfix="Office2003_Silver" 
        AutoGenerateColumns="False" Font-Size="X-Small" KeyFieldName="Folio_envio">
        <Styles CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css" 
            CssPostfix="Office2003_Silver">
            <Header ImageSpacing="5px" SortingImageSpacing="5px">
            </Header>
            <LoadingPanel ImageSpacing="10px">
            </LoadingPanel>
        </Styles>
        <Images ImageFolder="~/App_Themes/Office2003Silver/{0}/">
            <CollapsedButton Height="12px" 
                Url="~/App_Themes/Office2003Silver/GridView/gvCollapsedButton.png" 
                Width="11px" />
            <ExpandedButton Height="12px" 
                Url="~/App_Themes/Office2003Silver/GridView/gvExpandedButton.png" 
                Width="11px" />
            <DetailCollapsedButton Height="12px" 
                Url="~/App_Themes/Office2003Silver/GridView/gvCollapsedButton.png" 
                Width="11px" />
            <DetailExpandedButton Height="12px" 
                Url="~/App_Themes/Office2003Silver/GridView/gvExpandedButton.png" 
                Width="11px" />
            <FilterRowButton Height="13px" Width="13px" />
        </Images>
        <SettingsText Title="Envío de expedientes" />
        <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Folio de envío" FieldName="Folio_envio" 
                VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Estado en que se encuentra" 
                FieldName="EstadoNombre" VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Fecha de solicitud" FieldName="Fecha_solicitud" 
                VisibleIndex="2">
                <PropertiesTextEdit DisplayFormatString="{0:dd-MM-yyyy}">
                </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="Entidad" Caption="Entidad" 
                VisibleIndex="4">
                </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" 
                VisibleIndex="5">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Settings ShowTitlePanel="True" />
        <StylesEditors>
            <ProgressBar Height="25px">
            </ProgressBar>
        </StylesEditors>
</dxwgv:ASPxGridView>
<br />
<asp:ObjectDataSource ID="daExpedientes" runat="server" 
    SelectMethod="Monitoreo_EnviosxUsuario" 
    TypeName="Portalv9.SAEX.ServiciosSAEX" 
        OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblnoid" DefaultValue="" Name="NoIdentidad" 
            PropertyName="Text" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
    <cc1:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>


