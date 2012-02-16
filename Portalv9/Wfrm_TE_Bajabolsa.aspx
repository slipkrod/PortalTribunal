<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_Bajabolsa.aspx.vb" Inherits="Portalv9.Wfrm_TE_Bajabolsa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Envío --&gt; Usuario/Baja de Bolsas"> </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 60%" align="center">
        <tr>
            <td style="width: 132px; text-align: right;">
                <asp:Label ID="Label2" runat="server" Text="Folio de Seguridad: " 
                    style="text-align: right"></asp:Label></td>
            <td>
    <asp:TextBox ID="txtfolio" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" ForeColor="Red" Text=" * Requerido" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 132px; text-align: right;">
                <asp:Label ID="Label4" runat="server" Text="Confirme Folio: "></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="txtcfolio" runat="server"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" ForeColor="Red" Text=" * Requerido" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 132px; text-align: right;">
                &nbsp;</td>
            <td>
                <asp:ImageButton ID="ibtneliminar" runat="server" 
                    ImageUrl="~/Images/E_bajabolsa.gif" />
            </td>
        </tr>
    </table>

    <br />
    
    
    <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
    
    
    <br />

    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    
</asp:Content>

