<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfm_Captura_Expediente_Documentos.aspx.vb" Inherits="Portalv9.Wfm_Captura_Expediente_Documentos" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallbackPanel" tagprefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td colspan="2">
                Alta de Documentos</td>
        </tr>
        <tr>
            <td style="width: 233px">
                Código de referencia/Expediente</td>
            <td>
                <dx:ASPxLabel ID="ASPxLabel1" runat="server">
                </dx:ASPxLabel>

            </td>
        </tr>
        <tr>
            <td style="width: 233px">
                Título/Num.Expediente (Jurisdiccional)</td>
            <td>
                <dx:ASPxLabel ID="ASPxLabel2" runat="server">
                </dx:ASPxLabel>

            </td>
        </tr>
        <tr>
            <td colspan="2">        
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="dsDocumentos" KeyFieldName="idDescripcion" Width="565px">
                    <SettingsText Title="Documentos" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" 
                            Visible="False" VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="idDescripcion" FieldName="idDescripcion" 
                            Visible="False" VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Codigo de referencia" 
                            FieldName="Codigo_clasificacion" VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Titulo" FieldName="Descripcion" 
                            VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowTitlePanel="True" />
                </dx:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td style="width: 233px">        
                <dx:ASPxButton ID="btnAltaExp" runat="server" ClientInstanceName="btnAltaExp" 
                    Text="Alta de Documento" Width="140px">
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton ID="btnSalir" runat="server" ClientInstanceName="btnAltaExp" 
                    Text="Terminar" Width="140px">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>

                            <dxcp:ASPxCallbackPanel ID="ASPxCallbackPanel1" 
                                ClientInstanceName="ASPxCallbackPanel1" 
                                oncallback="ASPxCallbackPanel1_Callback" runat="server" Width="100%" 
                                HideContentOnCallback="False">
                                <PanelCollection>
                                    <dxp:PanelContent ID="PanelContent2" runat="server">
                                        <iframe runat="server" id="iframeIndices" frameborder="0" width="100%" 
                                            height="350"></iframe>                            
                                    </dxp:PanelContent>
                                </PanelCollection>
                            </dxcp:ASPxCallbackPanel>

    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
    <asp:ObjectDataSource ID="dsDocumentos" runat="server" 
        SelectMethod="ListaArchivo_Descripciones_idDescripcion_Hijos" 
        TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                Type="Int32" />
            <asp:QueryStringParameter Name="idDescripcion" 
                QueryStringField="idDescripcion" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </asp:Content>

