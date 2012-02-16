<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoPeriodoAno.ascx.vb" Inherits="Portalv9.CampoPeriodoAno" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<table style="font-family: Arial; font-size: 10px; text-align:left;" width="100%">
<tr>
<td width="40%">
    <table width="100%">
        <tr>
            <td class="WebUsrCtrls-td1" id="tdCampo" runat="server"><asp:Label ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></td>
            <td class="WebUsrCtrls-td2" id="tdTexto_Padres" runat="server"><dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" Font-Size="10pt"></dxe:ASPxLabel></td>
        </tr>
    </table>
</td>
<td width="60%">
    <table>
        <tr>
           <td>Año</td>
        <td >
            <dxe:ASPxSpinEdit ID="vAno_ini" runat="server" Height="21px" 
                MaxValue="9999" MinValue="1900" NumberType="Integer" 
                Width="70px" >
                <ValidationSettings CausesValidation="True" Display="Dynamic" 
                    ErrorText="Valor invalido" ValidationGroup="Archivos" 
                    ErrorDisplayMode="ImageWithTooltip">
                    <RequiredField ErrorText="* Campo requerido" />
                </ValidationSettings>
            </dxe:ASPxSpinEdit>
        </td>
        <td >-</td>
        <td>Año</td>
        <td>
            <dxe:ASPxSpinEdit ID="vAno_fin" runat="server" Height="21px" 
                MaxValue="9999" MinValue="1900" NumberType="Integer" 
                Width="70px" TabIndex="1">
                <ValidationSettings CausesValidation="True" Display="Dynamic" 
                    ErrorText="Valor invalido" ValidationGroup="Archivos" 
                    ErrorDisplayMode="ImageWithTooltip">
                    <RequiredField ErrorText="* Campo requerido" />
                </ValidationSettings>
            </dxe:ASPxSpinEdit>
        </td> 
        </tr>
    </table>
</td>
</tr>
</table>