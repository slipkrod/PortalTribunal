<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoTextoLargo.ascx.vb" Inherits="Portalv9.CampoTextoLargo" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
    
<table>
    <tr>
        <td width="40%">
            <table>
                <tr>
                    <td class="WebUsrCtrls-td1" style="vertical-align: top" id="tdCampo" runat="server">
                        <dxe:ASPxLabel ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="WebUsrCtrls-td2" style="vertical-align: top" id="tdTexto_Padres" runat="server">
                            <dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" Font-Size="10pt">
                    </dxe:ASPxLabel></td>
                </tr>
            </table>
        </td>
        <td width="60%">
            <dxe:ASPxMemo ID="Valor" runat="server" Height="150px" Width="100%">
                <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorText="Valor invalido" ErrorTextPosition="Bottom" ValidationGroup="Archivos">
                    <RequiredField ErrorText="* Campo requerido" />
                </ValidationSettings>
            </dxe:ASPxMemo>
        </td>
    </tr>
</table>