<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_PoliticasPassword.aspx.vb" Inherits="Portalv9.Wfrm_PoliticasPassword" 
MasterPageFile="~/MasterPages/Admin.master" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div id="content-container-one-div">
    <style type="text/css">
        .style1
        {
            width: 49px;
            height: 50px;
        }
        .style5
        {
            width: 632px;
            height: 35px;
        }
        .style6
        {
            height: 51px;
        }
    </style>
<link href="css/Grids.css" rel="stylesheet" type="text/css" />
    
        <table style="Z-INDEX: 100; LEFT: 2px; TOP: 2px" cellSpacing="0" cellPadding="0" width="700px" border="0">
				<tr>
					<td valign="top" align="left" width="*">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="700px" border="0">
										<TR>
											<TD class="style6">
                                                <br/>
                                                <br/>
                                                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                                                    Font-Names="Arial" Font-Size="Small" Height="34px" Width="624px"> Texto en 
                                                el page_ load</asp:Label>
                                            </TD>
										</TR>
										<TR>
											<TD noWrap class="style5">
                                                <input id="hiddenPPwd" runat="server" name="hiddenPPwd" size="8" 
                                                    style="WIDTH: 80px; HEIGHT: 14px" type="hidden">
                                                </input>
                                                <asp:Button ID="btnAddPPwd" runat="server" Font-Size="XX-Small" 
                                                    Text="Agregar Nueva Política de Contraseña" Width="200px" />
                                            </TD>
										</TR>
										<TR>
											<TD noWrap align="left" style="WIDTH: 632px; HEIGHT: 254px" valign="top">
                                                <asp:DataGrid ID="grdPPwd" runat="server" AllowPaging="True" 
                                                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                                                    Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" GridLines="None" Height="64px" 
                                                    PageSize="15" Width="626px">
                                                    <SelectedItemStyle CssClass="SelectedItemStyle" />
                                                    <EditItemStyle CssClass="EditItemStyle" />
                                                    <AlternatingItemStyle CssClass="AlternatingItemStyle" />
                                                    <ItemStyle CssClass="ItemStyle" />
                                                    <HeaderStyle CssClass="Encabezados" />
                                                    <FooterStyle CssClass="FooterStyle" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="PoliticaPwdID" HeaderText="ID" 
                                                            ItemStyle-CssClass="EncabezadosText" ReadOnly="True" Visible="false">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Nombre">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblnombre" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="Textnombre" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'>
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="Descripción">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDescripcion" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextDescripcion" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Width="305px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="LongMin">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLongMin" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.LongMin") %>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextLongMin" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.LongMin") %>' Width="23px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="LongMax">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLongMax" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.LongMax") %>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextLongMax" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.LongMax") %>' Width="23px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="May">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckMay" runat="server" 
                                                                    Checked='<%# DataBinder.Eval(Container, "DataItem.Mayusculas") %>' 
                                                                    Enabled="False" Text=" " />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:CheckBox ID="CheckEditMay" runat="server" 
                                                                    Checked='<%# DataBinder.Eval(Container, "DataItem.Mayusculas") %>' Text=" " />
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Min">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckMin" runat="server" 
                                                                    Checked='<%# DataBinder.Eval(Container, "DataItem.Minusculas") %>' 
                                                                    Enabled="False" Text=" " />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:CheckBox ID="CheckEditMin" runat="server" 
                                                                    Checked='<%# DataBinder.Eval(Container, "DataItem.Minusculas") %>' Text=" " />
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Simb">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckSimb" runat="server" 
                                                                    Checked='<%# DataBinder.Eval(Container, "DataItem.Simbolos") %>' 
                                                                    Enabled="False" Text=" " />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:CheckBox ID="CheckEditSimb" runat="server" 
                                                                    Checked='<%# DataBinder.Eval(Container, "DataItem.Simbolos") %>' Text=" " />
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Num">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckNum" runat="server" 
                                                                    Checked='<%# DataBinder.Eval(Container, "DataItem.Numeros") %>' Enabled="False" 
                                                                    Text=" " />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:CheckBox ID="CheckEditNum" runat="server" 
                                                                    Checked='<%# DataBinder.Eval(Container, "DataItem.Numeros") %>' Text=" " />
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" HeaderText="Máscara">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMascara" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Mascara") %>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextMascara" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Mascara") %>' Width="47px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="Duración">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDuracionMin" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Duraciondias") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextDuracionMin" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.Duraciondias") %>' Width="31px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="CantHist">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCantHist" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.CantHistorico") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextCantHist" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.CantHistorico") %>' Width="23px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="ReseteoMin">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCamResMin" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.CambioPwdResetMinutos") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextCamResMin" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.CambioPwdResetMinutos") %>' 
                                                                    Width="23px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="AviCadDias">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAviCadDias" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.AvisoCaducidadPwdDias") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextAviCadDias" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.AvisoCaducidadPwdDias") %>' 
                                                                    Width="23px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="CarIguales">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCarIguales" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.CarIguales") %>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextCarIguales" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.CarIguales") %>' Width="23px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderStyle-CssClass="EncabezadosText" 
                                                            HeaderText="CarConse.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCarConsecutivos" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.CarConsecutivos") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextCarConsecutivos" runat="server" 
                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.CarConsecutivos") %>' 
                                                                    Width="23px">
                                                                </asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:TemplateColumn>
                                                        <asp:EditCommandColumn ButtonType="LinkButton" CancelText="Cancelar" 
                                                            EditText="Editar" HeaderText="Editar" UpdateText="Actualizar">
                                                            <HeaderStyle CssClass="EncabezadosText" Font-Bold="True" Font-Italic="False" 
                                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                Width="50px" />
                                                            <ItemStyle Font-Names="Arial" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                        </asp:EditCommandColumn>
                                                        <asp:ButtonColumn CommandName="Delete" HeaderText="Eliminar" Text="X">
                                                            <HeaderStyle CssClass="EncabezadosText" Font-Bold="True" Font-Italic="False" 
                                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                HorizontalAlign="Left" Width="40px" />
                                                            <ItemStyle Font-Bold="True" Font-Italic="True" Font-Names="Arial Narrow" 
                                                                Font-Size="X-Small" ForeColor="#C00000" HorizontalAlign="Center" />
                                                        </asp:ButtonColumn>
                                                    </Columns>
                                                    <PagerStyle CssClass="PagerStyle" Mode="NumericPages" />
                                                </asp:DataGrid>
                                            </TD>
										</TR>
									</TABLE>
									
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<TR><td>
				    <asp:HiddenField ID="HiddenField1" runat="server" Visible="False" />
				    <asp:HiddenField ID="HiddenField2" runat="server" Visible="False" />
				    <asp:HiddenField ID="HiddenField3" runat="server" />
				    <asp:HiddenField ID="HiddenField4" runat="server" />
				    <asp:HiddenField ID="HiddenField5" runat="server" />
				    <asp:HiddenField ID="HiddenField6" runat="server" />
				    <asp:HiddenField ID="HiddenField7" runat="server" />
				    <asp:HiddenField ID="HiddenField8" runat="server" />
				    <asp:HiddenField ID="HiddenField9" runat="server" />
				    <asp:HiddenField ID="HiddenField10" runat="server" />
				    <asp:HiddenField ID="HiddenField11" runat="server" />
				    <asp:HiddenField ID="HiddenField12" runat="server" />
				    <asp:HiddenField ID="HiddenField13" runat="server" />
				    <asp:HiddenField ID="HiddenField14" runat="server" />
				    <asp:HiddenField ID="HiddenField15" runat="server" />
               </td>  </TR>
		</table>
		<cc1:MsgBox id="MsgBox1" runat="server"></cc1:MsgBox>

    </div> 
</asp:Content>



