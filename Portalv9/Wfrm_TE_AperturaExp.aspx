<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_AperturaExp.aspx.vb" Inherits="Portalv9.Wfrm_TE_AperturaExp" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Envío --&gt; Usuario/Baja de Bolsas"> </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <br />

                <dxwgv:aspxgridview ID="ASPxGridView1" runat="server" 
                    DataSourceID="ObjectDataSource1" 
                    AutoGenerateColumns="False">
                     <SettingsText Title="Envío --&gt Archivo central/Monitoreo de traslados" />
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="Tipo de Expediente" 
                            FieldName="TipoExpediente" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Código del expediente" 
                            FieldName="Llave_expediente" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indice de búsqueda" 
                            FieldName="Indice_de_busqueda" VisibleIndex="2">
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
                        <dxwgv:GridViewDataHyperLinkColumn VisibleIndex="7">
                            <propertieshyperlinkedit text="Ver"></propertieshyperlinkedit>
                            <DataItemTemplate>
                                <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%#"Wfrm_TE_AperturaExpDet.aspx?idArchivo=" & "16" & "&Folio_bolsa="& eval("folio_bolsa")& "&InstanciaID=" & eval("InstanciaId")& "&idFolio=" & eval("idFolio") & "&idDescripcion=" & eval("idDocumento")%>' 
                                    Text="Ver" />
                            </DataItemTemplate>
                        </dxwgv:GridViewDataHyperLinkColumn>
                    </Columns>
                     <Settings ShowTitlePanel="True" />
                </dxwgv:aspxgridview>
                <br />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="BuscaInstanciaExpedientexEstado" 
                    TypeName="Portalv9.SAEX.ServiciosSAEX">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="12" Name="EstadoID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
          

    <br />
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
</asp:Content>