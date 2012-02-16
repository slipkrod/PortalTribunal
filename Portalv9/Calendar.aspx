<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Calendar.aspx.vb" Inherits="Portalv9.ASPNET.StarterKit.TimeTracker.Web.Calendar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Calendario</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="styleCal.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function CloseWindow()
			{
				self.close();
			}
		</script>
</HEAD>
	<body bgColor="#ffffff" leftMargin="5" topMargin="5">
		<form id="Calendar" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr bgColor="white">
					<td colspan="2"><img src="images/spacer.gif" height="10" width="1"></td>
				</tr>
				<tr bgColor="white">
					<td align="center" colSpan="2">
						<asp:dropdownlist id="MonthSelect" runat="server" CssClass="standard-text" Height="22px" Width="90px"
							AutoPostBack="True"></asp:dropdownlist>&nbsp;
						<asp:dropdownlist id="YearSelect" runat="server" CssClass="standard-text" Height="22px" Width="60px"
							AutoPostBack="True"></asp:dropdownlist>
						<asp:calendar id="Cal" runat="server" BorderWidth="5px" ShowTitle="False" ShowNextPrevMonth="False"
							BorderStyle="Solid" Font-Size="XX-Small" Font-Names="Arial" BorderColor="White" DayNameFormat="FirstTwoLetters"
							ForeColor="#C0C0FF" FirstDayOfWeek="Monday" CssClass="standard-text">
							<todaydaystyle Font-Bold="True" ForeColor="White" BackColor="#990000"></todaydaystyle>
							<daystyle BorderWidth="2px" ForeColor="#666666" BorderStyle="Solid" BorderColor="White" BackColor="#EAEAEA"></daystyle>
							<dayheaderstyle ForeColor="#649CBA"></dayheaderstyle>
							<selecteddaystyle Font-Bold="True" ForeColor="#333333" BackColor="#FAAD50"></selecteddaystyle>
							<weekenddaystyle ForeColor="White" BackColor="#BBBBBB"></weekenddaystyle>
							<othermonthdaystyle ForeColor="#666666" BackColor="White"></othermonthdaystyle>
						</asp:calendar>
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2">
						Fecha seleccionada:
						<asp:label id="lblDate" runat="server"></asp:label>
						<input id="datechosen" type="hidden" name="datechosen" runat="server">
					</td>
				</tr>
				<tr>
					<td colspan="2"><img src="images/spacer.gif" height="10" width="1"></td>
				</tr>
				<tr>
					<td align="center">
						<asp:button id="OKButton" runat="server" Text="Aceptar" Width="60px"></asp:button>
					</td>
					<td align="center">
						<a href="javascript:CloseWindow()">
							<asp:button id="CancelButton" runat="server" Text="Cancelar" Width="60px"></asp:button>
						</a>
					</td>
				</tr>
			</table>
			&nbsp;
		</form>
	</body>
</HTML>
