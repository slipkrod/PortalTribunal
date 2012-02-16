<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmasteranidada.master" CodeBehind="Wfrm_BE_FormatoAutorizacion.aspx.vb" Inherits="Portalv9.Wfrm_BE_FormatoAutorizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Label ID="lbltitulo" runat="server" Text="Autorización de destrucción de expedientes" 
        Font-Names="Arial" Font-Size="Medium" ForeColor="#3F5DBC"></asp:Label>
    <br />

    <br />

    <br />

    <table align="center" style="width: 80%; border: 1px solid #A3C0E8">
     
        <tr>
            <td style="width: 177px; text-align: right;">
                <asp:Label ID="Label2" runat="server" Text="Fecha" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td>
                <asp:Label ID="lblfecha" runat="server" ForeColor="#3F5DBC"></asp:Label>
                <br />
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 177px; text-align: right;">
                <asp:Label ID="lblSellada" runat="server" Text="Hora: " 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblhora" runat="server" ForeColor="#3F5DBC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 177px; text-align: right;">
                <asp:Label ID="lblForaneo" runat="server" Text="Núm de orden de destrucción" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblfolio" runat="server" ForeColor="#3F5DBC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; text-align: center;" colspan="2">
                <asp:Label ID="lblfecha0" runat="server" ForeColor="#3F5DBC" 
                    style="text-align: center">Códigos de expedientes autorizados:</asp:Label>
                <br />
                <asp:Table ID="tblFolios" runat="server">
                </asp:Table>
            </td>
        </tr>
    </table>

    <br />
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
