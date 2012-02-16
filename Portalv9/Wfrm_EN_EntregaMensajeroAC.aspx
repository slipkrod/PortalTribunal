<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_EN_EntregaMensajeroAC.aspx.vb" Inherits="Portalv9.Wfrm_EN_EntregaMensajeroAC" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Centro de Distribución/Entrega folios a mensajería"> </asp:Label>
</div>
</asp:Content>
  
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table align="center" style="width: 80%; border: 1px solid #A3C0E8">
        <tr>
            <td style="width: 117px; text-align: right;">
                <br />
                <asp:Label ID="Label2" runat="server" Text="Mensajeria: "></asp:Label>
            </td>
            <td>
                <br />
                <asp:TextBox ID="txtmensajeria" runat="server"></asp:TextBox>
                <asp:Label ID="lblmreq" runat="server" Text="* Requerido" ForeColor="Red" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 117px; text-align: right;">
                <asp:Label ID="Label3" runat="server" Text="Folio de Bolsa: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFolioBolsa" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 117px; text-align: right;">
                &nbsp;</td>
            <td>
                <dxe:aspxbutton ID="btagregar" runat="server" Text="Agregar Folio">
                </dxe:aspxbutton>
                <br />
                <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 117px; text-align: right;" valign="bottom">
                <dxe:aspxbutton ID="btquitar" runat="server" 
                    Text="Quitar folio Seleccionado" Width="164px">
                </dxe:aspxbutton>
            </td>
            <td>
                <asp:ListBox ID="lbbolsas" runat="server" Height="152px" Width="223px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="width: 117px; text-align: right;">
                &nbsp;</td>
            <td>
                <asp:ImageButton ID="ibtnaceptar" runat="server" 
                    ImageUrl="~/Images/aceptar.gif" />
            </td>
        </tr>
    </table>

</asp:Content>


