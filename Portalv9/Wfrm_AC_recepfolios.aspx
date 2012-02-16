<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_AC_recepfolios.aspx.vb" Inherits="Portalv9.Wfrm_AC_recepfolios" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="lbltitulo" runat="server" Text="Envío --&gt Archivo central/Recepción de folios"> </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <br />

    <br />

    <table align="center" style="width: 80%; border: 1px solid #A3C0E8">
        <tr>
            <td style="text-align: center;" colspan="2">
                <br />
                <asp:Label ID="Label1" runat="server" 
                    Text="Verificar que la bolsa se encuentre sellada al recibir" Font-Bold="True" 
                    ForeColor="#3F5DBC"></asp:Label>
                <br />
                <br />
                </td>
        </tr>
        <tr>
            <td style="width: 177px; text-align: right;">
                <asp:Label ID="Label2" runat="server" Text="Folio de bolsa:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtfoliobolsa" runat="server"></asp:TextBox>
                <asp:ImageButton ID="ibtnbuscar" runat="server" ImageUrl="Images/Buscar.gif" />
                <asp:Label ID="estadoactual" runat="server" ForeColor="#3F5DBC" Visible="False"></asp:Label>
                <br />
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 177px; text-align: right;">
                <asp:Label ID="lblSellada" runat="server" Text="¿Bolsa Sellada?" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:CheckBox ID="chkbolsasellada" runat="server" Visible="False" 
                    AutoPostBack="True" />
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 177px">
                &nbsp;</td>
            <td style="height: 21px; text-align: center;">
                <asp:ImageButton ID="btnaceptar" runat="server" 
                    ImageUrl="Images/Recibir_Bolsa.gif" Height="54px" Visible="False" />
                <asp:ImageButton ID="btndevolver" runat="server" 
                    ImageUrl="~/Images/env_devolucion.gif" Height="54px" Visible="False" />
            </td>
        </tr>
    </table>

    <br />
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>

</asp:Content>
