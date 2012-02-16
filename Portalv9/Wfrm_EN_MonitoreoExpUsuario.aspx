<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_EN_MonitoreoExpUsuario.aspx.vb" Inherits="Portalv9.Wfrm_EN_MonitoreoExpUsuario" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<asp:Content ID="Content4" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Monitoreo de Folios"> </asp:Label>
</div>
</asp:Content>
  
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblnoid" runat="server" ForeColor="Black" Visible="False"></asp:Label>
    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
    DataSourceID="ObjectDataSource1" EnableTheming="False" 
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
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="Monitoreo_EnviosxUsuario" 
    TypeName="Portalv9.SAEX.ServiciosSAEX" 
        OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblnoid" DefaultValue="" Name="NoIdentidad" 
            PropertyName="Text" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
    <br />
    <dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" 
        CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine" 
        DataSourceID="ObjectDataSource2" EnableTheming="False" 
        AutoGenerateColumns="False" Font-Size="XX-Small" 
        KeyFieldName="Folio_Bolsa">
        <Styles CssFilePath="~/App_Themes/RedWine/{0}/styles.css" CssPostfix="RedWine">
        </Styles>
        <SettingsLoadingPanel Text="" />
        <SettingsPager>
            <AllButton>
                <Image Height="19px" Width="24px" />
            </AllButton>
            <FirstPageButton>
                <Image Height="19px" Width="23px" />
            </FirstPageButton>
            <LastPageButton>
                <Image Height="19px" Width="23px" />
            </LastPageButton>
            <NextPageButton>
                <Image Height="19px" Width="19px" />
            </NextPageButton>
            <PrevPageButton>
                <Image Height="19px" Width="19px" />
            </PrevPageButton>
        </SettingsPager>
        <Images ImageFolder="~/App_Themes/RedWine/{0}/">
            <CollapsedButton Height="15px" 
                Url="~/App_Themes/RedWine/GridView/gvCollapsedButton.png" Width="15px" />
            <ExpandedButton Height="15px" 
                Url="~/App_Themes/RedWine/GridView/gvExpandedButton.png" Width="15px" />
            <DetailCollapsedButton Height="12px" 
                Url="~/App_Themes/RedWine/GridView/gvDetailCollapsedButton.png" Width="11px" />
            <DetailExpandedButton Height="12px" 
                Url="~/App_Themes/RedWine/GridView/gvDetailExpandedButton.png" Width="11px" />
            <HeaderFilter Height="19px" 
                Url="~/App_Themes/RedWine/GridView/gvHeaderFilter.png" Width="19px" />
            <HeaderActiveFilter Height="19px" 
                Url="~/App_Themes/RedWine/GridView/gvHeaderFilterActive.png" Width="19px" />
            <HeaderSortDown Height="15px" 
                Url="~/App_Themes/RedWine/GridView/gvHeaderSortDown.png" Width="11px" />
            <HeaderSortUp Height="15px" 
                Url="~/App_Themes/RedWine/GridView/gvHeaderSortUp.png" Width="11px" />
            <FilterRowButton Height="13px" Width="13px" />
            <CustomizationWindowClose Height="19px" Width="19px" />
            <PopupEditFormWindowClose Height="19px" Width="19px" />
            <WindowResizer Height="13px" 
                Url="~/App_Themes/RedWine/GridView/WindowResizer.png" Width="13px" />
            <FilterBuilderClose Height="19px" Width="19px" />
        </Images>
         <SettingsText Title="Rechazos por bolsas faltantes y/o bolsas abiertas" />
         <Columns>
             <dxwgv:GridViewDataTextColumn Caption="Folo de Bolsa" FieldName="Folio_bolsa" 
                 VisibleIndex="0">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Estado en que se encuentra" 
                 FieldName="EstadoNombre" VisibleIndex="1">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="No. exp." FieldName="No_Expedientes" 
                 VisibleIndex="2">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="No. docs." FieldName="No_Documentos" 
                 VisibleIndex="3">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Fecha de solicitud" 
                 FieldName="Fecha_solicitud" VisibleIndex="4">
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
        <StylesEditors>
            <ProgressBar Height="25px">
            </ProgressBar>
        </StylesEditors>
        <ImagesEditors>
            <CalendarFastNavPrevYear Height="19px" 
                Url="~/App_Themes/RedWine/Editors/edtCalendarFNPrevYear.png" Width="19px" />
            <CalendarFastNavNextYear Height="19px" 
                Url="~/App_Themes/RedWine/Editors/edtCalendarFNNextYear.png" Width="19px" />
            <DropDownEditDropDown Height="7px" 
                Url="~/App_Themes/RedWine/Editors/edtDropDown.png" 
                UrlDisabled="~/App_Themes/RedWine/Editors/edtDropDownDisabled.png" 
                UrlHottracked="~/App_Themes/RedWine/Editors/edtDropDownHottracked.png" 
                Width="7px" />
            <SpinEditIncrement Height="6px" 
                Url="~/App_Themes/RedWine/Editors/edtSpinEditIncrementImage.png" 
                UrlDisabled="~/App_Themes/RedWine/Editors/edtSpinEditIncrementDisabledImage.png" 
                UrlHottracked="~/App_Themes/RedWine/Editors/edtSpinEditIncrementHottrackedImage.png" 
                Width="7px" />
            <SpinEditDecrement Height="7px" 
                Url="~/App_Themes/RedWine/Editors/edtSpinEditDecrementImage.png" 
                UrlDisabled="~/App_Themes/RedWine/Editors/edtSpinEditDecrementDisabledImage.png" 
                UrlHottracked="~/App_Themes/RedWine/Editors/edtSpinEditDecrementHottrackedImage.png" 
                Width="7px" />
            <SpinEditLargeIncrement Height="9px" 
                Url="~/App_Themes/RedWine/Editors/edtSpinEditLargeIncImage.png" 
                UrlDisabled="~/App_Themes/RedWine/Editors/edtSpinEditLargeIncDisabledImage.png" 
                UrlHottracked="~/App_Themes/RedWine/Editors/edtSpinEditLargeIncHottrackedImage.png" 
                Width="7px" />
            <SpinEditLargeDecrement Height="9px" 
                Url="~/App_Themes/RedWine/Editors/edtSpinEditLargeDecImage.png" 
                UrlDisabled="~/App_Themes/RedWine/Editors/edtSpinEditLargeDecDisabledImage.png" 
                UrlHottracked="~/App_Themes/RedWine/Editors/edtSpinEditLargeDecHottrackedImage.png" 
                Width="7px" />
        </ImagesEditors>
    </dxwgv:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="Monitoreo_FoliosFaltantesEnvioxUsuario" 
        TypeName="Portalv9.SAEX.ServiciosSAEX" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblnoid" Name="NoIdentidad" 
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
</asp:Content>

