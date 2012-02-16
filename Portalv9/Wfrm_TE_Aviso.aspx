<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_Aviso.aspx.vb" Inherits="Portalv9.Wfrm_TE_Aviso" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table1" style="Z-INDEX: 101; LEFT: 8px; TOP: 8px;"
				borderColor="#eaeaea" align="left" border="0">
				<tr>
				<td style="HEIGHT: 65px; width: 21%;">
				<br /><br />
						<asp:label id="lblTitle" runat="server" Font-Size="Larger" Font-Names="Arial" 
                            Width="610px"
							Font-Bold="True" Font-Italic="True" Text="AVISO" ForeColor="#000066" style="text-align: center"></asp:label>
							<br />
						<asp:label id="lblFecha" runat="server" Font-Italic="True" Font-Bold="True" 
                            Height="16px" Width="617px"
							Font-Names="Arial" Font-Size="10pt" Text="Fecha:" ForeColor="#000099" 
                            style="text-align: center"></asp:label>
				</TD>
					
				</tr>
				<tr>
					<td colspan="2">
						<br /><br />
							<asp:Label id="lblAviso" runat="server" Height="53px" 
                                style="text-align: center" Width="615px" Font-Bold="True" 
                                Font-Size="Medium" > lblAviso</asp:Label>
					</td>
				</tr>
			</table>
</asp:Content>
