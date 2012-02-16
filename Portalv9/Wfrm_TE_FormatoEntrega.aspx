<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_FormatoEntrega.aspx.vb" Inherits="Portalv9.Wfrm_TE_FormatoEntrega" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table1" align="left" border="1" bordercolor="#eaeaea" 
        style="WIDTH: 738px; HEIGHT: 248px" width="738">
        <tr>
            <td colspan="2" style="HEIGHT: 1px">
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                    Font-Names="Arial" Font-Size="10pt" Height="16px" Width="544px"> Texto en el page_ load</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 12px; FONT-SIZE: 10pt" 
                width="523">
                Fecha:</td>
            <td style="HEIGHT: 12px" valign="center" width="849">
                <asp:Label ID="lblFecha" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Width="206px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 23px; FONT-SIZE: 10pt" 
                width="523">
                Hora:</td>
            <td style="HEIGHT: 23px" valign="center" width="849">
                <asp:Label ID="lblHora" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Width="206px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 12px; FONT-SIZE: 10pt" 
                width="523">
                Mensajería:</td>
            <td style="HEIGHT: 12px" valign="center" width="849">
                <asp:Label ID="lblMensajeria" runat="server" Font-Names="Arial" 
                    Font-Size="10pt" Width="374px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 12px; FONT-SIZE: 10pt" 
                width="523">
                Quién&nbsp;entrega:</td>
            <td style="HEIGHT: 12px" valign="center" width="849">
                <asp:Label ID="lblEntrega" runat="server" Font-Names="Arial" Font-Size="10pt" 
                    Width="374px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="WIDTH: 523px; FONT-FAMILY: Arial; HEIGHT: 12px; FONT-SIZE: 10pt" 
                width="523">
                Observaciones:</td>
            <td style="HEIGHT: 12px" valign="center" width="849">
                <asp:Label ID="lblObservaciones" runat="server" Font-Names="Arial" 
                    Font-Size="10pt" Width="374px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div align="center">
                    <table id="Table2" border="0" cellpadding="0" cellspacing="0" 
                        style="WIDTH: 600px; HEIGHT: 40px" width="600">
                        <tr>
                            <td align="middle" 
                                style="WIDTH: 168px; FONT-FAMILY: Arial; HEIGHT: 23px; FONT-SIZE: 10pt" 
                                valign="center">
                                Folios de bolsas entregadas:</td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="WIDTH: 168px; HEIGHT: 12px" valign="center">
                                <p align="left">
                                    <b><font color="#000000" face="Arial, Helvetica, sans-serif" size="2">
                                    <asp:Table ID="tblFolios" runat="server" Width="336px">
                                    </asp:Table>
                                    </font></b>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="WIDTH: 168px; HEIGHT: 4px" valign="bottom">
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
                <asp:Label ID="lblError" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                    ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
