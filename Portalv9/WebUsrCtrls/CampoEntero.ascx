<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoEntero.ascx.vb" Inherits="Portalv9.CampoEntero" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<style type="text/css">
    .style1
    {
        width: 100px;
    }
</style>
<table class="style1">
    <tr>
        <td width="40%">
<table>
    <tr>
        <td class="WebUsrCtrls-td1" id="tdCampo" runat="server">
            <dxe:ASPxLabel  ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt"></dxe:ASPxLabel>
        </td>
        <td class="WebUsrCtrls-td2" id="tdTexto_Padres" runat="server">
            <dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
    </tr>
</table>
        </td>
        <td width="60%">
            <dxe:ASPxSpinEdit ID="Valor" runat="server" AllowMouseWheel="False" 
                Height="21px" Width="200px" >
                <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorText="Valor invalido" ErrorTextPosition="Bottom" ValidationGroup="Archivos">
                    <RequiredField ErrorText="* Campo requerido" />
                </ValidationSettings>
            </dxe:ASPxSpinEdit>        
            </td>
          </tr>
</table>

