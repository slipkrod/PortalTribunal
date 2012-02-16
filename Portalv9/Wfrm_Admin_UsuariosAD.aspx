<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Admin_UsuariosAD.aspx.vb" MasterPageFile="~/MasterPages/Adminmasteranidada.master" Inherits="Portalv9.Wfrm_UsuariosAD" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
     <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
         <cc1:CollapsiblePanelExtender ID="cpe" runat="server"          
            TargetControlID="ContentPanel"
            ExpandControlID="TitlePanel"
            CollapseControlID="TitlePanel"
            CollapsedSize="0"
            AutoCollapse="False"
            Collapsed="True"
            TextLabelID="Label1"
            ExpandedText="(Esconder Instrucciones...)" 
            CollapsedText="(Mostrar Instrucciones...)"
            ImageControlID="Image1" 
            ExpandedImage="Images/collapse_blue.jpg" 
            CollapsedImage="Images/expand_blue.jpg"
            SuppressPostBack="False">
         </cc1:CollapsiblePanelExtender>
   
      <center>
      <link href="Grids.css" rel="stylesheet" type="text/css" />  
      <style type="text/css">
        .negro
        {
            color: #000000;
        }
        .rojo
        {
            color: #FF0000;
            font-weight: bold;
        }
        .div
        {
            width: 100%;
            text-align: center;
        }
        .style2
        {
            width: 80%;
        }
        .style5
            {
                width: 82%;
            }
        </style>
     <br />
     <asp:label id="lblTitle" runat="server" Font-Size="Small" 
                Width="232px" Height="30px" Font-Names="Arial" 
                Font-Bold="True" Font-Italic="True"> Texto en el page_ load
     </asp:label>
     <br />
     <br />
       <table align="center" style="width: 640px">
          <tr>
            <td>
            <asp:Panel ID="TitlePanel" runat="server" CssClass="collapsePanelHeader" Width="614px">
            <asp:Image ID="Image1" runat="server" ImageUrl="Images/expand_blue.jpg" />
            &nbsp;&nbsp;<span class="colapsetitulo">Ayuda e Instrucciones</span>
            </asp:Panel>
            <asp:Panel ID="ContentPanel" runat="server" CssClass="collapsePanel" Width="624px">
            <h1>
            <span class="colapsesubtitulo">Recuerda que para Accesar...</span></h1>
            <div class="div" style="height: 103px; width: 99%">
            <span class="negro">Necesitas tener una cuenta de </span>
            <span class="rojo">Directorio Activo </span><span class="negro">para poder hacer las busquedas en este.
                                                        <br />
                                                        <br />
                                                        La cuenta del Directorio Activo es aquella que ocupas para Accesar a tu 
                                                        computadora.<br />
                                                        <br />
                                                        Al momento de ejecutar la busqueda, si seleccionas la opcion</span> <span class="rojo">TODO</span> Puede que tarde un poco.<br />
                                                        Ya que este generada la busqueda selecciona los usuarios a ingresar y el grupo al cual lo deseas asignar.
                                                    </div>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                                                       
                                    <table class="style2">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblusrad" runat="server" Text="Usuario" CssClass="standard-text"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtusuad" runat="server" CssClass="standard-text" TabIndex="1"></asp:TextBox>
                                    &nbsp;<asp:Label ID="lblpwdad" runat="server" Text="Contraseña:" 
                                        CssClass="standard-text"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtpwdad" runat="server" CssClass="standard-text" 
                                        TextMode="Password" TabIndex="2"></asp:TextBox>
                                    &nbsp;<asp:Button ID="btningresar" runat="server" Text="Ingresar al AD" 
                                        CssClass="standard-text" TabIndex="3"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Button ID="btnbuscarag" runat="server" Text="Nueva Busqueda" 
                                                    CssClass="standard-text" Visible="false" />
                                            </td>
                                            <td class="style5" align="center">
                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
              style="text-align: justify" Visible="False" TabIndex="5">
              <asp:ListItem>Cuenta</asp:ListItem>
              <asp:ListItem Value="noa">Nombre o Apellidos</asp:ListItem>
              <asp:ListItem Value="Todo">Todo (La búsqueda puede tardar)</asp:ListItem>
          </asp:RadioButtonList>
        
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                        
                <asp:Label ID="lblcuenta" runat="server" Text="Cuenta" Visible="False" CssClass="standard-text" 
                                        TabIndex="6" ></asp:Label>
                                                <asp:TextBox ID="txtcuenta" runat="server" 
              Visible="False" TabIndex="7"></asp:TextBox>
                                                <asp:Label ID="lblnombre" runat="server" Text="Nombres" Visible="False" CssClass="standard-text" 
                                        TabIndex="8"></asp:Label>
                                                                   <asp:TextBox ID="txtnom" runat="server" Visible="False" TabIndex="9"></asp:TextBox>
                                                <asp:Label ID="lblapp" runat="server" Text="Apellidos" Visible="False" CssClass="standard-text" 
                                        TabIndex="10"></asp:Label>
                                                <asp:TextBox ID="txtapp" runat="server" Visible="False" TabIndex="11"></asp:TextBox>
                                                <br />
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Visible="False" CssClass="standard-text" 
                                        TabIndex="12" />
           
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
           
                  <asp:Label ID="lbllista" runat="server" Text="Grupo: " Visible="False" CssClass="standard-text" 
                                        TabIndex="13" ></asp:Label>
										<asp:DropDownList id="DropGrupoAdmin" tabIndex="14" runat="server" 
                                        Font-Size="XX-Small" Width="256px"
											Font-Names="Arial" Visible="false" ></asp:DropDownList>
                                        
                                                <br />
                                        
                                                <br />
      
                <asp:GridView CssClass="Grid" ID="GwAd" runat="server" 
    CellPadding="4" ForeColor="Blue" GridLines="None" TabIndex="15">
                    <RowStyle CssClass="SelectedItemStyle"/>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkad" runat="server" ToolTip="Agregar Usuario" 
                                    />
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="CheckBox1_CheckedChanged" />
                            </HeaderTemplate>
                        </asp:TemplateField>
                      </Columns>
                    <FooterStyle CssClass="FooterStyle"/>
                    <PagerStyle CssClass="PagerStyle"/>
                    <SelectedRowStyle CssClass="SelectedItemStyle"/>
                    <HeaderStyle CssClass="Encabezados"/>
                    <EditRowStyle CssClass="EditItemStyle"/>
                    <AlternatingRowStyle CssClass="AlternatingItemStyle"/>                                     
                </asp:GridView>
         <br />         
          <asp:Button ID="btnInsertar" runat="server" Text="Ingresar" Visible="false" TabIndex="16" CssClass="standard-text"/>
      </td>
      </tr>
</table>
      </center>
    </div>
 </asp:Content>
