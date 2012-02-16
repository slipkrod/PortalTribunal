<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmasteranidada.master" CodeBehind="Wfrm_Normas_niveles.aspx.vb" Inherits="Portalv9.Wfrm_Normas_niveles" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <div>
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br />
            <br />
    </div>
    <div>
          
        <table style="LEFT: 2px; WIDTH: 656px; TOP: 2px; cellSpacing="0"
				cellPadding="0" width="656" border="0">
        <tr>
            <td style="HEIGHT: 325px" vAlign="top" align="left" width="*">
                <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <tr>
                        <td style="HEIGHT: 184px">
                            <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD noWrap class="style3">
                                    </TD>
                                    <TD noWrap class="style3">
                                        <asp:HyperLink ID="Regresar" runat="server" ImageUrl="Images/regresar.gif" 
                                            NavigateUrl="Wfrm_Normas.aspx">Regresar</asp:HyperLink>
                                    </TD>
                                    <TD noWrap class="style3">
                                        &nbsp;
												<asp:label id="Label1" runat="server" Font-Size="Small" Width="232px" 
                                            Height="16px" Font-Names="Arial"
													Font-Bold="True" Font-Italic="True"> Texto en el 
                                                page_ load</asp:label>
                                    </TD>
                                </TR>
                                <TR>
                                    <TD noWrap class="style1">
                                    </TD>
                                    <TD noWrap class="style6">
                                    </TD>
                                    <TD noWrap class="style7">
                                        <asp:button id="btnAddNorma" runat="server" Font-Size="XX-Small" Width="91px" 
                                            Text="Agregar nivel"></asp:button>
                                    </TD>
                                </TR>
                                <TR>
                                    <TD noWrap class="style2">
                                    </TD>
                                    <TD style="WIDTH: 21px; HEIGHT: 210px" noWrap>
                                    </TD>
                                    <TD style="WIDTH: 632px; HEIGHT: 210px" vAlign="top" noWrap align="left">
                                        <asp:datagrid id="grdNiveles" runat="server" Width="626px" Height="91px" 
                                            ForeColor="Black" PageSize="15"
													AutoGenerateColumns="False" BorderWidth="1px" AllowPaging="True" AllowSorting="True">
                                            <SelectedItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black" BackColor="#B4C8DC">
                                            </SelectedItemStyle>
                                            <EditItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black" BackColor="#B4C8DC">
                                            </EditItemStyle>
                                            <AlternatingItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black" BackColor="#EAEAEA">
                                            </AlternatingItemStyle>
                                            <ItemStyle Font-Size="XX-Small" Font-Names="Arial" ForeColor="Black">
                                            </ItemStyle>
                                            <HeaderStyle Font-Size="X-Small" Font-Names="Arial Narrow" 
                                                Font-Bold="True" HorizontalAlign="Center"
														ForeColor="White" BackColor="Gray"></HeaderStyle>
                                            <FooterStyle Font-Size="X-Small" Font-Names="Arial" HorizontalAlign="Center" ForeColor="Black"
														BackColor="CornflowerBlue"></FooterStyle>
                                            <Columns>
                                                <asp:BoundColumn DataField="idNorma" ReadOnly="True" HeaderText="IDNorma">
                                                    <HeaderStyle Width="60px" />
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="idNivel" HeaderText="IDNivel" ReadOnly="True">
                                                    <HeaderStyle Width="50px" />
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Nombre">
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label id="lblNombre" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.Nivel_Descripcion") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox id="TextNombre" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.Nivel_Descripcion") %>' 
                                                            MaxLength="250" Width="458px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" CancelText="Cancelar" EditText="Editar">
                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                    <ItemStyle Font-Size="XX-Small" Font-Names="Arial" HorizontalAlign="Center">
                                                    </ItemStyle>
                                                </asp:EditCommandColumn>
                                                <asp:ButtonColumn Text="X" HeaderText="Eliminar" CommandName="Delete">
                                                    <HeaderStyle HorizontalAlign="Left" Width="40px"></HeaderStyle>
                                                    <ItemStyle Font-Size="X-Small" Font-Names="Arial Narrow" Font-Italic="True" Font-Bold="True"
																HorizontalAlign="Center" ForeColor="#C00000"></ItemStyle>
                                                </asp:ButtonColumn>
                                            </Columns>
                                            <PagerStyle Font-Size="XX-Small" Font-Underline="True" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Center"
														ForeColor="#C00000" BackColor="White" Mode="NumericPages">
                                            </PagerStyle>
                                        </asp:datagrid>
                                    </TD>
                                </TR>
                            </TABLE>
                        </td>
                    </tr>
                </table>
               
            </td>
        </tr>
    </table>       
       
    </div>
 </asp:Panel> 
                   <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red">
                </cc1:msgbox>
                
                
  
                
                        
     
  

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder5" Runat="Server">
    
</asp:Content>
