<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_REchazoBolsaCD.aspx.vb" Inherits="Portalv9.Wfrm_TE_REchazoBolsaCD" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table1" border="1" 
        style="HEIGHT: 216px">
        <tr>
            <td style="HEIGHT: 8px;" >
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                    Font-Names="Arial" Font-Size="10pt" Height="16px" Width="606px"> Envío-&gt;Centro de distribución/Rechazo de folioEnvío-&gt;Centro de distribución/Rechazo de folio</asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" >
                <div>
                    <table id="Table2" border="0" cellpadding="0" cellspacing="0" 
                        style="HEIGHT: 182px">
                        <tr>
                            <td align="right" style="WIDTH: 216px; HEIGHT: 23px; font-weight: bold;" 
                                valign="top">
                                Folio 
                                de&nbsp;bolsa de seguridad&nbsp;: 
                            </td>
                            <td align="left" style="HEIGHT: 23px; vertical-align: top;" valign="center">
                                <asp:Label ID="lblFolioBolsa" runat="server" Font-Names="Arial" 
                                    Font-Size="10pt" Width="267px">Label</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" valign="top">
    <dxwgv:ASPxGridView ID="ASPxGridExpedientes" runat="server" 
        DataSourceID="dsDocumentos" AutoGenerateColumns="False" KeyFieldName="InstanciaPID" Width="597px">
    <SettingsText Title=" Envío--&gt;Centro de distribución/Rechazo de folio" />
    <Columns>
            <dxwgv:GridViewDataTextColumn Caption="InstanciaPID" FieldName="InstanciaPID" 
                VisibleIndex="0" Visible="False">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Tipo de expediente" FieldName="TipoExpediente" 
                VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Código del expediente" FieldName="Llave_expediente" 
                VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Indice de búsqueda" 
                FieldName="Indice_de_busqueda" VisibleIndex="2">
                <PropertiesTextEdit DisplayFormatString="{0:dd-MM-yyyy}">
                </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Folio_bolsa" FieldName="Folio_bolsa" 
                VisibleIndex="3" Visible="False">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Contenido" VisibleIndex="3">
                <DataItemTemplate>
                    <dxe:ASPxButton ID="cmdVerificar" runat="server" CommandArgument='<%# Bind("Folio_bolsa") %>' 
                        CommandName="cmdVerificar" onclick="cmdVerificar_Click" Text="Verificar">
                    </dxe:ASPxButton>
                </DataItemTemplate>
            </dxwgv:GridViewDataTextColumn>
        </Columns>
    <Settings ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" valign="top">
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
                <asp:Label ID="lblError" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                    ForeColor="Red"></asp:Label>
                <br />
    <asp:ObjectDataSource ID="dsDocumentos" runat="server" 
        SelectMethod="BuscaInstanciaExpedientexEstadoxBolsa" 
                    TypeName="Portalv9.SAEX.ServiciosSAEX" 
                    OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:QueryStringParameter Name="Folio_Bolsa" QueryStringField="FolioBolsa" 
                Type="String" />
            <asp:Parameter DefaultValue="4" Name="EstadoID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
