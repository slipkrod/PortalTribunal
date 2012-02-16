<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_GrupoAdmin.aspx.vb" Inherits="Portalv9.Wfrm_GrupoAdmin" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 50px;
            height: 35px;
        }
        .style4
        {
            width: 21px;
            height: 50px;
        }
        </style>

    <script type="text/javascript" language="javascript" id="clientEventHandlersJS" >
        function getconfirm() {
            if (confirm("¿Seguro de querer eliminar este registro?") == true)
                return true;
            else
                return false;
        }
    </script>
    <link href="css/Grids.css" rel="stylesheet" type="text/css" />
    <asp:Panel ID="Panel1" runat="server" >
 		<table style="LEFT: 2px; TOP: 2px; " cellspacing="0" cellpadding="0" border="0">
			<tr>
                
				<td valign="top" align="left" width="*">
					<table cellspacing="0" cellpadding="0" width="100%" border="0">
						<tr>
							<td  colspan=3>
							   <br/>
                               <br/>
							   <asp:label id="lblTitle" runat="server" Font-Size="Small"  
                                    Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
							</td>
						</tr>					    
						<TR>
							<TD class="style4">
                                <asp:button id="btnAddPGrupo" runat="server" Font-Size="XX-Small" Width="168px" Text="Agregar Grupo Administrativo"></asp:button>
                                <INPUT id="hiddenPGrupo" style="WIDTH: 88px; " type="hidden" size="9" name="hiddenPSesion"	runat="server">
                            </TD>
							<td>
							  <asp:Label ID="lblBuscar" runat="server" Font-Names="Arial"  Font-Size="XX-Small" Width="89px" Height="16px">Buscar Grupo:</asp:Label>
                            </td>
                            <td>
                               <asp:TextBox ID="txtBuscar" runat="server" Font-Size="XX-Small" MaxLength="50" tabIndex="14" Width="185px"></asp:TextBox>
                                <asp:Button ID="btnBuscar" runat="server" tabIndex="15" Text="Buscar..." Height="26px" CssClass="standard-text" />
                             </td>
						</TR>
					</TABLE>	
	                <asp:datagrid id="grdPGrupo" runat="server" Width="626px" Height="64px" PageSize="15" 
	                     AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" GridLines="None">
						<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
						<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
						<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
						<ItemStyle CssClass="ItemStyle"></ItemStyle>
						<HeaderStyle CssClass="Encabezados"></HeaderStyle>
						<FooterStyle CssClass="FooterStyle"></FooterStyle>
						<Columns>
							<asp:BoundColumn DataField="GrupoAdminID" ReadOnly="True" HeaderText="ID" Visible="false">
								<ItemStyle HorizontalAlign="Left"></ItemStyle>
							</asp:BoundColumn>
							<asp:TemplateColumn HeaderText="Nombre" HeaderStyle-CssClass="EncabezadosText">
								<ItemStyle HorizontalAlign="Left"></ItemStyle>
								<ItemTemplate>
									<asp:Label id="lblNombre" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'>
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id="TextNombre" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Descripci&#243;n" HeaderStyle-CssClass="EncabezadosText">
								<ItemStyle HorizontalAlign="Left"></ItemStyle>
								<ItemTemplate>															
									<asp:label id="lbldescripcion" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion")%>'>
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id="TextDescripcion" runat="server" Width="305px" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Responsable" HeaderStyle-CssClass="EncabezadosText">
								<ItemTemplate>
								    <asp:Label ID="lblresposable" runat="server" Text='<%#Container.DataItem("NombreResp")%>'>
								    </asp:Label> 
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList id="ddResponsable" DataValueField="NoIdentidad" DataTextField="Nombre" DataSource="<%# ObtenerUsuarios() %>"  SelectedValue='<%# ObtenerValueUsuario(IIf(DataBinder.Eval(Container, "DataItem.ResponsableID") Is System.DBNull.Value, -1, DataBinder.Eval(Container, "DataItem.ResponsableID"))) %>' Runat="server">
									</asp:DropDownList>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Gpo Padre" HeaderStyle-CssClass="EncabezadosText">
							<ItemTemplate>
							<asp:Label ID="lblgrupopadre" runat="server" Text='<%#Container.DataItem("NombrePadre")%>'>
								    </asp:Label> 														
							</ItemTemplate>
							    <EditItemTemplate>
							        <asp:DropDownList ID="ddgpopadre" DataValueField="GrupoAdminID" DataTextField="Nombre" DataSource="<%# ObtenerGrupos() %>"  SelectedValue='<%# ObtenerValueGrupo(IIf(DataBinder.Eval(Container, "DataItem.GrupoAdminID") Is System.DBNull.Value, -1, DataBinder.Eval(Container, "DataItem.GrupoAdminID"))) %>' Runat="server">
							        </asp:DropDownList>
							    </EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Cliente" HeaderStyle-CssClass="EncabezadosText">
								<ItemTemplate>
									<%#Container.DataItem("NombreCliente")%>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList id="ddCliente" DataValueField="ClienteID" DataTextField="Nombre" DataSource="<%# ObtenerClientes() %>"  SelectedValue='<%# ObtenerValueCliente(IIf(DataBinder.Eval(Container, "DataItem.ClienteID") Is System.DBNull.Value, -1, DataBinder.Eval(Container, "DataItem.ClienteID"))) %>' Runat="server"  >
									</asp:DropDownList>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" CancelText="Cancelar" EditText="Editar" HeaderText = "Editar" HeaderStyle-CssClass="EncabezadosText">
								<ItemStyle Font-Size="XX-Small" Font-Names="Arial" HorizontalAlign="Center"></ItemStyle>
							</asp:EditCommandColumn>
							<asp:ButtonColumn Text="X" HeaderText="Eliminar" CommandName="Delete" HeaderStyle-CssClass="EncabezadosText">
								<ItemStyle Font-Size="X-Small" Font-Names="Arial " Font-Italic="True" Font-Bold="True"
									HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
							</asp:ButtonColumn>
						</Columns>
						<PagerStyle CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
					</asp:datagrid>
					<br />
					<cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
				 </td>
				</tr>
				<tr>
				 <td colspan=2 >
				    <asp:HiddenField ID="HiddenField1" runat="server" />
				    <asp:HiddenField ID="HiddenField2" runat="server" />
				    <asp:HiddenField ID="HiddenField3" runat="server" />
				    <asp:HiddenField ID="HiddenField4" runat="server" />
				    <asp:HiddenField ID="HiddenField5" runat="server" />
				 </td>
				</table>
    </asp:Panel>
</asp:Content>
