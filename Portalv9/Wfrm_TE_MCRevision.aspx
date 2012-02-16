<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_MCRevision.aspx.vb" Inherits="Portalv9.Wfrm_TE_MCRevision" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Revisión de Expedientes"> </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
        <br />
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
            DataSourceID="ObjectDataSource1" EnableTheming="False" AutoGenerateColumns="False" 
            CssFilePath="~/App_Themes/Office2003Silver/{0}/styles.css" 
            CssPostfix="Office2003_Silver" Font-Size="X-Small">
            <Columns>
                <dxwgv:GridViewDataTextColumn Caption="Folio de bolsa" FieldName="Folio_bolsa" 
                    VisibleIndex="0">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="No. exp" FieldName="No_Expedientes" 
                    VisibleIndex="1">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="No. docs" FieldName="No_Documentos" 
                    VisibleIndex="2">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="Fecha de Solicitud" 
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
                <dxwgv:GridViewDataHyperLinkColumn VisibleIndex="7" FieldName="Folio_bolsa">
                    <PropertiesHyperLinkEdit Text="Verificar Contenidos" 
                        NavigateUrlFormatString="Wfrm_TE_MCRevisionBolsa.aspx?Folio_bolsa={0}">
                    </PropertiesHyperLinkEdit>
                </dxwgv:GridViewDataHyperLinkColumn>
            </Columns>
            <Settings ShowTitlePanel="True" />
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
            <SettingsText Title="Envío --&gt Mesa de Control -- &gt Revisión de expedientes" />
            <StylesEditors>
                <ProgressBar Height="25px">
                </ProgressBar>
            </StylesEditors>
        </dxwgv:ASPxGridView>
                 
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="BuscaInstanciaXEstado" TypeName="Portalv9.SAEX.ServiciosSAEX">
            <SelectParameters>
                <asp:Parameter DefaultValue="20" Name="pintEstadoID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>

   
        <br />
   
</asp:Content>
