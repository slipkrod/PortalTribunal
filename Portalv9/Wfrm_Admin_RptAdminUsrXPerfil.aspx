<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/1.master" CodeBehind="Wfrm_Admin_RptAdminUsrXPerfil.aspx.vb" Inherits="Portalv9.Wfrm_RptAdminUsrXPerfil" 
    title="Reporte - Usuarios por Perfil " %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <table class="style2">
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style30">
                </td>
                <td class="style7" colspan="6">
                    </td>
            </tr>
            <tr>
                <td class="style13">
                    &nbsp;</td>
                <td class="style3" colspan="7">
                    <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Names="Arial" Font-Size="Small" Height="30px" Width="232px"> Texto en 
                    el page_ load</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    &nbsp;</td>
                <td class="style31">
                    &nbsp;</td>
                <td colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="10pt" 
                        Width="135px">&nbsp;Seleccione Perfil:</asp:Label>
                </td>
                <td class="style26">
                    <asp:DropDownList ID="ddlPerfiles" runat="server" Font-Names="Arial" 
                        Font-Size="XX-Small" tabIndex="10" Width="256px">
                    </asp:DropDownList>
                </td>
                <td class="style27">
                    <asp:Button ID="btnBuscar" runat="server" Height="25px" tabIndex="12" 
                        Text="Buscar" Width="90px" />
                </td>
                <td class="style34">
                    <asp:Button ID="btnExportar" runat="server" Height="25px" tabIndex="12" 
                        Text="Exportar a Excel" Visible="False" Width="123px" />
                </td>
                <td class="style35">
                    <asp:Button ID="btnExportar2" runat="server" Height="25px" tabIndex="12" 
                        Text="Exportar a Word" Visible="False" Width="118px" />
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                    &nbsp;</td>
                <td class="style31">
                    &nbsp;</td>
                <td colspan="6">
                    &nbsp;</td>
            </tr>
        </table>
    
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="False">
        <table >
            <tr>
                <td class="style10">
                    </td>
                <td class="style7">
                    </td>
                <td class="style28">
                </td>
            </tr>
            <tr>
                <td class="style32"  >
                    &nbsp;</td>
                    <td class="style17">
                        &nbsp;</td>
                <td class="style29" align=center>
                    <b>SEGURIDAD DE LA INFORMACIÓN
                    <br />
                    </b>
                    <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="11pt"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="style10">
                    </td>
                <td class="style7">
                    </td>
                <td class="style28">
                    </td>
            </tr>
            <tr>
                <td class="style18">
                    </td>
                <td colspan="2" style="border-bottom-width:thin; border-bottom-color:Red; border-bottom-style:solid" 
                    class="style19">
                    <asp:Label ID="lblTitle2" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Names="Arial" Font-Size="13pt" ForeColor="Blue" Height="30px" 
                        Width="453px"> Texto en el page_ load</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    </td>
                <td class="style7">
                
                    </td>
                <td class="style28">
                </td>
            </tr>
            <tr>
                <td class="style32">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:DataGrid ID="grdReporte" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" BorderStyle="None" 
                        BorderWidth="0px" Height="18px" HorizontalAlign="Justify" PageSize="40" 
                        style="margin-bottom: 0px" >
                        <SelectedItemStyle Font-Names="Arial" 
                            Font-Size="XX-Small" />
                        <EditItemStyle Font-Names="Arial" Font-Size="XX-Small" />
                        <AlternatingItemStyle 
                            Font-Names="Arial" Font-Size="XX-Small" />
                        <ItemStyle Font-Names="Arial" 
                            Font-Size="Medium" />
                        <HeaderStyle Font-Names="Arial Narrow" 
                            Font-Size="20pt" HorizontalAlign="Left" BackColor="White" Font-Bold="True" 
                            Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                            Font-Underline="False" ForeColor="Black" />
                        <FooterStyle Font-Size="Smaller" 
                            HorizontalAlign="Center" />
                        <Columns>

                            <asp:BoundColumn DataField="NominaEsp" 
                                HeaderText="" HeaderStyle-Font-Size="10pt" >
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                    />
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="" 
                                HeaderText="" >
                                <ItemStyle Width="4px" Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                    />
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="NombreUsr" 
                                HeaderText="" HeaderStyle-Font-Size="10pt" >
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                     />
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="" 
                                HeaderText="" >
                                <ItemStyle Width="4px" Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                    />
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="UsrID"  HeaderText="" HeaderStyle-Font-Size="10pt">
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                     />
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="" 
                                HeaderText="" >
                                <ItemStyle Width="4px" Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                    />
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="GEID"  HeaderText="" HeaderStyle-Font-Size="10pt">
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                     />
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="" 
                                HeaderText="" >
                                <ItemStyle Width="4px" Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                    />
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="SOEID"  HeaderText="" HeaderStyle-Font-Size="10pt">
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                     />
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="" 
                                HeaderText="" >
                                <ItemStyle Width="4px" Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                    />
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="RITSID"  HeaderText="" HeaderStyle-Font-Size="10pt">
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                     />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="" 
                                HeaderText="" >
                                <ItemStyle Width="4px" Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                    />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Mantener" >
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                    />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="" 
                                HeaderText="" >
                                <ItemStyle Width="2px" Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                    />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Borrar" >
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
                                     />
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Font-Size="15px" Font-Underline="False" Mode="NumericPages" 
                            PageButtonCount="15" Font-Bold="True" Font-Italic="False" 
                            Font-Names="Times New Roman" Font-Overline="False" Font-Strikeout="False" 
                            ForeColor="Blue" HorizontalAlign="Center" Position="TopAndBottom" 
                            Wrap="False" />
                    </asp:DataGrid>
                    </td>
            </tr>
            <tr>
                <td class="style10">
                    </td>
                <td class="style7">
                    </td>
                <td class="style28">
                    </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Visible="False">
        &nbsp;<table Width="897px" >
            <tr>
                <td class="style33">
                    &nbsp;</td>
                <td colspan="3" 
                    >
                    &nbsp;</td>
            </tr>
            <tr >
                <td class="style33">
                    &nbsp;</td>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    &nbsp;</td>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    &nbsp;</td>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                 <td class="style33">
                    &nbsp;</td>
                <td colspan="3" 
                     style="border-bottom-width:thin; border-bottom-color:Black; border-bottom-style:solid">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" align="center">
                    &nbsp;</td>
                <td align="center" class="style23">
                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Asignado para Revisión&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
                    <br />
                    <br />
                    <br />
                    Nombre y Firma</b></td>
                <td align="center" class="style23">
                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dueño de la información&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
                    </b><b>
                    <br />
                    <br />
                    <br />
                    Nombre y Firma</b></td>
                <td align="center" class="style23">
                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fecha&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    </b>
                    <b>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp; /&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; / </b>
                </td>
            </tr>
            <tr>
                <td class="style33">
                    &nbsp;</td>
                <td colspan="3" 
                    style="border-bottom-width:thin; border-bottom-color:Black; border-bottom-style:solid">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" align="center">
                    &nbsp;</td>
                <td align="center" class="style23">
                    <b>Aplicó ISA<br />
                    <br />
                    <br />
                    <br />
                    Nombre y Firma</b></td>
                <td align="center" class="style23">
                    <b>Revisó ISA<br />
                    <br />
                    <br />
                    <br />
                    Nombre y Firma</b></td>
                <td align="center" class="style23">
                    <b>Fecha<br />
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp; /&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; / </b>
                </td>
            </tr>
            <tr>
                <td class="style33">
                    &nbsp;</td>
                <td colspan="3" 
                    style="border-bottom-width:thin; border-bottom-color:Black; border-bottom-style:solid">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" align="center">
                    &nbsp;</td>
                <td class="style23" align="center">
                    <b>Verificación Independiente información<br />
                    <br />
                    <br />
                    <br />
                    Nombre y Firma</b></td>
                <td class="style23" align="center">
                    <b>
                    <br />
                    <br />
                    <br />
                    <br />
                    </b></td>
                <td class="style23" align="center">
                    <b>Fecha<br />
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; / </b></td>
            </tr>
            <tr>
                <td class="style33">
                    &nbsp;</td>
                <td class="style20">
                    &nbsp;</td>
                <td class="style22">
                    &nbsp;</td>
                <td class="style21">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    &nbsp;</td>
                <td class="style20">
                    &nbsp;</td>
                <td class="style22">
                    &nbsp;</td>
                <td class="style21">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    &nbsp;</td>
                <td class="style20">
                    &nbsp;</td>
                <td class="style22">
                    &nbsp;</td>
                <td class="style21">
                    &nbsp;</td>
            </tr>
        </table>
    
            </asp:Panel>
    <cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox></td>
</asp:Content>
