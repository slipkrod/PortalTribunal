<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Plantillaedicion.aspx.vb" Inherits="Portalv9.Wfrm_Plantillaedicion" MasterPageFile="~/Masterpages/Adminmasteranidada.master" %>

<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div>
    <table style="width:100%;">
        <tr>
         <TD noWrap class="style3">
    	    <dxe:ASPxHyperLink ID="Regresar" runat="server" 
                ImageUrl="~/Images/regresar.gif" NavigateUrl='<%# "~/Wfrm_PlantillaHija.aspx?idNorma=" & Request.QueryString("idNorma") & "&Norma=" & Request.QueryString("Norma")%>' />
                                        &nbsp;
												<asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" 
                                            Height="16px" Font-Names="Arial"
													Font-Bold="True" Font-Italic="True"> Texto en el 
                                                page_ load</asp:label>
        </TD>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                
               <asp:DataList ID="dlAreas" runat="server" BorderColor="#333333" 
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="2" Font-Bold="False" DataKeyField="idArea" 
                    DataSourceID="ObjectDataSource1"  Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                Font-Underline="False" ForeColor="White" GridLines="Both" Height="25px" 
                                HorizontalAlign="Left" RepeatDirection="Horizontal" SelectedIndex="0" 
                                style="margin-top: 0px" Width="600px" RepeatColumns="4">
                                             <EditItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                 Font-Strikeout="False" Font-Underline="False" ForeColor="Black" 
                                                 HorizontalAlign="Left" />
                                             <AlternatingItemStyle Font-Bold="False" Font-Italic="False" 
                                                 Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                 ForeColor="Black" HorizontalAlign="Left" />
                                             <ItemStyle Font-Bold="False" Font-Italic="False" 
                                              Font-Names="Arial" Font-Overline="False" Font-Size="8pt" Font-Strikeout="False" 
                        Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Top" CssClass="DataList_Aqua" 
                                                 ForeColor="Black" />
                                             <SeparatorStyle  BorderWidth="2px" ForeColor="Black" />
                                             <SelectedItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" 
                                                 Font-Overline="False" Font-Size="8pt" Font-Strikeout="False" 
                                                Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Top" 
                                                 CssClass="DataList_Aqua_Sel" ForeColor="Black" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkVisible" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Visible") %>'/>
                                                 <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Select" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.folio_norma") %>'></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Select" 
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Area_descripcion") %>'></asp:LinkButton>
                                            </ItemTemplate>
               </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                <dxp:ASPxPanel ID="PnlElementos" runat="server" Width="600px">
                    <Border BorderColor="#C9D7DD" BorderStyle="Solid" BorderWidth="1px" />
                    <PanelCollection>
                    <dxp:PanelContent ID="PanelContent1" runat="server"></dxp:PanelContent>
                </PanelCollection>
                </dxp:ASPxPanel>
            </td>
        </tr>
        <TR>
            <td>
                <dxe:ASPxButton ID="aspxguardar" runat="server" Text="Salvar" 
                    AutoPostBack="False">
                </dxe:ASPxButton>
            </TD>
        </TR>
    </table>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="ListaPlantilla_Areas" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:QueryStringParameter Name="idPlantilla" QueryStringField="idPlantilla" 
                Type="Int32" />
            <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
                            <asp:Label ID="lblidIndice" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblDataListID" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblEstado" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblElementoID" runat="server" Visible="False"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
