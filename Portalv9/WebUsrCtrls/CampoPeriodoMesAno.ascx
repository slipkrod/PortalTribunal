<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoPeriodoMesAno.ascx.vb" Inherits="Portalv9.CampoPeriodoMesAno" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<table align="left" style="font-family: Arial; font-size: 10px">
    <tr>
        <td class="WebUsrCtrls-td1" id="tdCampo" runat="server">
            <asp:Label ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label>
        </td>
        <td class="WebUsrCtrls-td2" id="tdTexto_Padres" runat="server">
            <dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" 
                Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
        <td>
            <table><tr>
                <td>Año</td>
                <td>
                    <dxe:ASPxSpinEdit ID="vAno_ini" runat="server" Height="21px" MaxValue="9999" MinValue="1900" NumberType="Integer" Width="70px" >
                        <ValidationSettings CausesValidation="True" Display="Dynamic" 
                            ErrorText="Valor invalido" ValidationGroup="Archivos" 
                            ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="* Campo requerido" />
                        </ValidationSettings>
                    </dxe:ASPxSpinEdit>
                </td>
                <td>
                    Mes</td>
                <td>
                    <dxe:ASPxSpinEdit ID="vMes_ini" runat="server" Height="21px" MaxValue="12" MinValue="1" NumberType="Integer" Width="50px" >
                        <ValidationSettings CausesValidation="True" Display="Dynamic" 
                            ErrorText="Valor invalido" ValidationGroup="Archivos" 
                            ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="* Campo requerido" />
                        </ValidationSettings>
                    </dxe:ASPxSpinEdit>
                </td>
                <td>
                    -</td>
                <td>
                    Año</td>
                <td>
                    <dxe:ASPxSpinEdit ID="vAno_fin" runat="server" Height="21px" MaxValue="9999" MinValue="1900" NumberType="Integer" Width="70px">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" 
                            ErrorText="Valor invalido" ValidationGroup="Archivos" 
                            ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="* Campo requerido" />
                        </ValidationSettings>
                    </dxe:ASPxSpinEdit>
                </td>
                <td >
                    Mes</td>
                <td>
                    <dxe:ASPxSpinEdit ID="vMes_fin" runat="server" Height="21px" MaxValue="12" MinValue="1" NumberType="Integer" Width="50px">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" 
                            ErrorText="Valor invalido" ValidationGroup="Archivos" 
                            ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="* Campo requerido" />
                        </ValidationSettings>
                    </dxe:ASPxSpinEdit>
                </td>
            </tr></table>
        </td>
    </tr>
</table>