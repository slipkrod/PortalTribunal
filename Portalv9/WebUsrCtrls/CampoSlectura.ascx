<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoSlectura.ascx.vb" Inherits="Portalv9.CampoSlectura" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<table>
    <tr>
        <td class="WebUsrCtrls-td1" id="tdCampo" runat="server">
            <dxe:ASPxLabel ID="ASPxtitulo" runat="server" Font-Names="Arial" 
                Font-Size="10pt" Font-Bold="False" >
            </dxe:ASPxLabel>
        </td>
        <td class="WebUsrCtrls-td2" id="tdTexto_Padres" runat="server">
            <dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
        <td style="text-align:left;">
            <dxe:ASPxLabel ID="Valor" runat="server" Font-Names="Arial" Font-Size="10pt" Font-Bold="False">
            </dxe:ASPxLabel>
            <asp:Literal ID="ValorHTML" runat="server" Visible="false"></asp:Literal>
        </td>
     
    </tr>
</table>
