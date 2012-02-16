<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfm_Captura_Expediente.aspx.vb" Inherits="Portalv9.Wfm_Captura_Expediente" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallbackPanel" tagprefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td colspan="3">
                Alta de Expediente</td>
        </tr>
        <tr>
            <td style="width: 205px">
                Código de referencia/Expediente</td>
            <td colspan="2">
    <dx:ASPxButtonEdit runat="server" Width="350px" ClientInstanceName="btEditCodigo" 
                    ID="btEditCodigo"><Buttons>
<dx:EditButton></dx:EditButton>
</Buttons>

<ButtonEditEllipsisImage Url="~/Images/Buscar.gif"></ButtonEditEllipsisImage>
</dx:ASPxButtonEdit>

            </td>
        </tr>
        <tr>
            <td style="width: 205px">        
            </td>
            <td>
                <dx:ASPxButton ID="btnAltaExp" runat="server" ClientInstanceName="btnAltaExp" 
                    Text="Alta de Expediente" Width="140px" ClientVisible="False">
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton ID="btnCancelaAlta" runat="server" ClientInstanceName="btnCancelaAlta" 
                    Text="Cancelar" Width="140px" ClientVisible="False">
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
    <asp:ObjectDataSource ID="dsBuscaArchivo" runat="server" 
        SelectMethod="ListaArchivo" TypeName="Portalv9.WSArchivo.Service1" 
                OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="idArchivo" Type="Int32" />            
        </SelectParameters>
    </asp:ObjectDataSource>
    </asp:Content>
