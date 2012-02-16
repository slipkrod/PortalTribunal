<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoTexto.ascx.vb" Inherits="Portalv9.CampoTexto" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<table>
    <tr>
        <td width="40%">
            <table>
                <tr>
                    <td class="WebUsrCtrls-td1" id="tdCampo" runat="server">
                        <dxe:ASPxLabel  ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="WebUsrCtrls-td2" id="tdTexto_Padres" runat="server">
                        <dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" Font-Size="10pt">
                        </dxe:ASPxLabel>
                    </td>
                </tr>
            </table>
        </td>
        <td width="60%">
            <dxe:ASPxTextBox ID="Valor" runat="server" Font-Names="Arial" Font-Size="10pt" AutoPostBack="false" Width="340px">
                <ValidationSettings CausesValidation="True" Display="Dynamic" 
                    ErrorText="Valor invalido" ErrorTextPosition="Bottom" 
                    ValidationGroup="Archivos" SetFocusOnError="True">
                    <RequiredField ErrorText="* Campo requerido" />
                </ValidationSettings>
            </dxe:ASPxTextBox>
        </td>
    </tr>
</table>
