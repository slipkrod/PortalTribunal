<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_EN_ExpFaltantes.aspx.vb" Inherits="Portalv9.Wfrm_EN_ExpFaltantes" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitle" runat="server" Text=""> </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
                <dxwgv:aspxgridview ID="ASPxGridView1" runat="server" 
                    DataSourceID="ObjectDataSource1" 
                    AutoGenerateColumns="False" Font-Size="XX-Small">
                     <SettingsPager PageSize="20">
                     </SettingsPager>
                     <SettingsText Title="Tránsito --&gt Archivo central/Reporte de tránsito" />
                     <Columns>
                         <dxwgv:GridViewDataHyperLinkColumn VisibleIndex="0">
                             <PropertiesHyperLinkEdit Text="Enviar a Folios faltantes">
                             </PropertiesHyperLinkEdit>
                         </dxwgv:GridViewDataHyperLinkColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Bolsa" FieldName="Folio_bolsa" 
                             VisibleIndex="1" ToolTip="Folio de la Bolsa">
                         </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Estado" 
                             FieldName="EstadoNombre" VisibleIndex="2" 
                             ToolTip="Estado en que se encuentra">
                         </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Exp" 
                             FieldName="No_Expedientes" VisibleIndex="3" 
                             ToolTip="Numero de Expedientes que contiene la bolsa">
                         </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Fecha" 
                             FieldName="Fecha_solicitud" VisibleIndex="4" 
                             ToolTip="Fecha de la Solicitud">
                         </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Vencimiento" 
                             FieldName="Fecha_vencimiento" VisibleIndex="5" 
                             ToolTip="Fecha del Vencimiento">
                             <PropertiesTextEdit DisplayFormatString="{0:dd-MM-yyyy}">
                              </PropertiesTextEdit>
                         </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Horas" FieldName="Horas" 
                             VisibleIndex="6" ToolTip="Horas Transcurridas">
                         </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                             VisibleIndex="7" ToolTip="Usuario que solicitó">
                         </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                             VisibleIndex="8">
                         </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="9">
                         </dxwgv:GridViewDataTextColumn>
                     </Columns>
                     <Settings ShowTitlePanel="True" />
                </dxwgv:aspxgridview>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="Monitoreo_FoliosFaltantes" 
                    TypeName="Portalv9.SAEX.ServiciosSAEX" 
        OldValuesParameterFormatString="{0}">
                </asp:ObjectDataSource>
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
</asp:Content>
