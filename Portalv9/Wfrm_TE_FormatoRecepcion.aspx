<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_FormatoRecepcion.aspx.vb" Inherits="Portalv9.Wfrm_TE_FormatoRecepcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table1" align="left" style="WIDTH: 600px; height:264px; border: 1px solid #A3C0E8">
        <tr>
            <td colspan="2" style="WIDTH: 1114px; HEIGHT: 15px" width="1114">
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                    Font-Names="Arial" Font-Size="10pt" Height="16px" Width="544px"> Envío-&gt;Oficinas/Recepción de folios</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 12px; FONT-SIZE: 10pt" 
                width="523">
                Fecha:</td>
            <td style="WIDTH: 849px; HEIGHT: 12px" valign="center" width="849">
                <asp:Label ID="lblFecha" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Width="206px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 23px; FONT-SIZE: 10pt" 
                width="523">
                Hora:</td>
            <td style="WIDTH: 849px; HEIGHT: 23px" valign="center" width="849">
                <asp:Label ID="lblHora" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Width="206px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 12px; FONT-SIZE: 10pt" 
                width="523">
                Usuario que envía:</td>
            <td style="WIDTH: 849px; HEIGHT: 12px" valign="center" width="849">
                <asp:Label ID="lblUsuario" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Width="374px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 12px; FONT-SIZE: 10pt" 
                width="523">
                Usuario que recibe:</td>
            <td style="WIDTH: 849px; HEIGHT: 12px" valign="center" width="849">
                <asp:Label ID="lblRecibe" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Width="374px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" valign="top">
                <table id="Table2" border="0" cellpadding="0" cellspacing="0" 
                    style="WIDTH: 552px; HEIGHT: 72px" width="552">
                    <tr>
                        <td align="left" 
                            style="WIDTH: 179px; FONT-FAMILY: Arial; HEIGHT: 23px; FONT-SIZE: 10pt" 
                            valign="center">
                            Folios de bolsas entregadas:</td>
                        <td align="left" style="HEIGHT: 23px" valign="center">
                            <p align="left">
                                &nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" style="WIDTH: 168px; HEIGHT: 27px" 
                            valign="center">
                            <p align="left">
                                <asp:Label ID="txtFolioBolsa" runat="server" Font-Names="Arial" 
                                    Font-Size="10pt" Width="216px"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="WIDTH: 179px" valign="bottom">
                            &nbsp;</td>
                        <td align="left" valign="center">
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblError" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                    ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
