<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_EN_RevUsuario.aspx.vb" Inherits="Portalv9.Wfrm_EN_RevUsuario" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitulo" runat="server" Text="Envío --&gt Archivo central/Apertura de bolsas"> </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <table align="center" style="width: 80%; border: 1px solid #A3C0E8">
        <tr>
            <td style="width: 177px; text-align: right;">
                <asp:Label ID="Label2" runat="server" Text="Folio de bolsa de seguridad:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="width: 268px">
                <asp:TextBox ID="txtfoliobolsa" runat="server" Width="134px"></asp:TextBox>
                <asp:Label ID="lblreq" runat="server" ForeColor="Red" Text="* Requerido" 
                    Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 177px; text-align: right;">
                &nbsp;</td>
            <td style="height: 21px; text-align: left; width: 268px;">
                <asp:ImageButton ID="btnaceptar" runat="server" 
                    ImageUrl="~/Images/aceptar.gif" Height="54px" />
            </td>
        </tr>
        <tr>
            <td style="height: 21px; " colspan="2">
                <br />
                <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
                    DataSourceID="ObjectDataSource1" Visible="False" 
                    AutoGenerateColumns="False">
                    <SettingsBehavior AllowSort="False" />
                    <Columns>
                        <dxwgv:GridViewDataTextColumn VisibleIndex="0">
                            <PropertiesTextEdit DisplayFormatString="{0}">
                            </PropertiesTextEdit>
                            <DataItemTemplate>
                                <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server" 
                                     NavigateUrl='<%# "Wfrm_EN_RevUsuarioContenido.aspx?FolioBolsa=" &  Eval("Folio_bolsa").toString & "&InstanciaPID=" & Eval("InstanciaPID").toString %>'  Text="Recibir" />
                            </DataItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Tipo de Expediente" 
                            FieldName="TipoExpediente" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Código del Expediente" 
                            FieldName="Llave_expediente" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indice de búsqueda" 
                            FieldName="Indice_de_busqueda" VisibleIndex="3">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Folio_bolsa" FieldName="Folio_bolsa" 
                            Name="Folio_bolsa" Visible="False" VisibleIndex="4">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="InstanciaPID" FieldName="InstanciaPID" 
                            Name="InstanciaPID" Visible="False" VisibleIndex="4">
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                </dxwgv:ASPxGridView>
                <br />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="BuscaInstanciaExpedientexEstadoxBolsa" 
                    TypeName="Portalv9.SAEX.ServiciosSAEX">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="" Name="Folio_bolsa" Type="String" />
                        <asp:Parameter DefaultValue="55" Name="EstadoID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>

    <br />
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
</asp:Content>
