<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_PermisosApp.aspx.vb" Inherits="Portalv9.PermisosApp" MasterPageFile="~/MasterPages/1.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" language="javascript" id="clientEventHandlersJS" >
       function getconfirm() 
        {
            if (confirm("¿Seguro de querer eliminar este registro?") == true)
                return true;
            else
                return false;
        }        
    </script>
    <link href="css/Grids.css" rel="stylesheet" type="text/css" />
    <asp:Panel ID="Panel1" runat="server" > 
 		<table style="LEFT: 2px; TOP: 2px;" cellspacing="0" cellPadding="0" border="0">
			<tr>
                
				<td vAlign="top" align="left" width="*">
					<table cellspacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td class="style9">
							   <br/>
                               <br/>
							   <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="34px" Font-Names="Arial"  Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
							</td>
						</tr>
						<tr>
							<td class="style5" style="vertical-align: middle">
                                <input id="hiddenAplicacionID" type="hidden" name="hiddenAplicacionID" runat="server" />
                                <input id="hiddenVersionID" type="hidden" name="hiddenVersionID" runat="server" />
                                <asp:button id="btnAdPermiso" Font-Size="XX-Small" Text="Agregar Permiso" runat="server"></asp:button>
			                </td>
		                </tr>
		                <tr>
		                  <td>	
		                    <asp:label id="lblApp" runat="server" Font-Size="XX-Small" Width="100px" 
                                Height="16px" Font-Names="Arial"
				                Font-Bold="True" >Aplicación:</asp:label>                                        
                                <asp:DropDownList ID="ddlApp" runat="server" Height="16px" Width="250px" 
                                AutoPostBack="True" Font-Names="Arial" Font-Size="XX-Small"></asp:DropDownList>												                                         										    
		                </td>
		                </tr>
		                <tr>
		                  <td class="style6">	
		                    <asp:label id="Label1" runat="server" Font-Size="XX-Small" Width="100px" 
                                Height="16px" Font-Names="Arial"
				                Font-Bold="True" >Versión:</asp:label>                                        
                                <asp:DropDownList ID="ddlVer" runat="server" Height="16px" Width="250px" 
                                AutoPostBack="True" Font-Names="Arial" Font-Size="XX-Small"></asp:DropDownList>												                                         										    
						                </td>
						</tr>
	                </table>	
                    <asp:datagrid id="DG1" runat="server" Width="592px" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" Height="232px" PageSize="15" 
                        CellPadding="3" GridLines="None" Font-Bold="False" Font-Italic="False" 
                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                <SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
                <EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
                <AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
                <ItemStyle CssClass="ItemStyle"></ItemStyle>
                <HeaderStyle CssClass="Encabezados"></HeaderStyle>
                <FooterStyle CssClass="FooterStyle"></FooterStyle>
                <Columns>
	                <asp:BoundColumn DataField="PermisoID" ReadOnly="True" HeaderText="<span class='EncabezadosText'>ID</span>"></asp:BoundColumn>
	                <asp:BoundColumn DataField="Nombre" HeaderText="<span class='EncabezadosText'>Nombre</span>"></asp:BoundColumn>
	                <asp:BoundColumn DataField="Descripcion" HeaderText="<span class='EncabezadosText'>Descripci&#243;n</span>"></asp:BoundColumn>
	                <asp:EditCommandColumn HeaderStyle-CssClass="EncabezadosText" ButtonType="LinkButton" UpdateText="Actualizar" HeaderText="Edici&#243;n" CancelText="Cancelar"
		                EditText="Edici&#243;n"></asp:EditCommandColumn>
	                <asp:ButtonColumn Text="X" HeaderText="Borrar" CommandName="Delete">
	                    <HeaderStyle CssClass="EncabezadosText" />
		                <ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
			                HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
	                </asp:ButtonColumn>
	                <asp:BoundColumn Visible="False" DataField="VersionAplicacionID" HeaderText="VerAPID"></asp:BoundColumn>
                </Columns>
                <PagerStyle CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
                </asp:datagrid>
        	    	<cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox>  
          	   </td>
          </tr>  	 
        </table>
     </asp:Panel>
</asp:Content>				
 