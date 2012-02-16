<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoFecha.ascx.vb" Inherits="Portalv9.CampoFecha" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<table>
    <tr>
        <td width="40%">
            <table>
                <tr>
                    <td class="WebUsrCtrls-td1" id="tdCampo" runat="server">
                        <asp:Label ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                    </td>
                    <td class="WebUsrCtrls-td2" id="tdTexto_Padres" runat="server">
                        <dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" Font-Size="10pt"></dxe:ASPxLabel>
                    </td>
                </tr>
            </table>
        </td>
        <td width="60%">
            <dxe:ASPxDateEdit ID="Valor" runat="server" Height="16px">
                <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorText="Valor invalido" ErrorTextPosition="Bottom" ValidationGroup="Archivos">
                    <RequiredField ErrorText="* Campo requerido" />
                </ValidationSettings>
            </dxe:ASPxDateEdit>
        </td>
    </tr>
</table>