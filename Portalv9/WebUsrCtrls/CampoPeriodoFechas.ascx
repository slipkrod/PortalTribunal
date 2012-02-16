<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoPeriodoFechas.ascx.vb" Inherits="Portalv9.CampoPeriodoFechas" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<table align="left">
    <tr>
        <td class="WebUsrCtrls-td1" id="tdCampo" runat="server">
            <asp:Label ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label>
        </td>
        <td class="WebUsrCtrls-td2" id="tdTexto_Padres" runat="server">
            <dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
        <td>
            <dxe:ASPxDateEdit ID="FechaIni" runat="server">
                <ValidationSettings CausesValidation="True" Display="Dynamic" 
                    ErrorText="Valor invalido" ValidationGroup="Archivos" 
                    ErrorDisplayMode="ImageWithTooltip">
                    <RequiredField ErrorText="* Campo requerido" />
                </ValidationSettings>
            </dxe:ASPxDateEdit>
        </td>
        <td >
            -</td>
        <td>
            <dxe:ASPxDateEdit ID="FechaFin" runat="server">
                <ValidationSettings CausesValidation="True" Display="Dynamic" 
                    ErrorText="Valor invalido" ValidationGroup="Archivos" 
                    ErrorDisplayMode="ImageWithTooltip">
                    <RequiredField ErrorText="* Campo requerido" />
                </ValidationSettings>
            </dxe:ASPxDateEdit>
        </td>
    </tr>
</table>