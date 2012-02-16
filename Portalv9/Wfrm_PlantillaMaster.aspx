<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmasteranidada.master" CodeBehind="Wfrm_PlantillaMaster.aspx.vb" Inherits="Portalv9.Wfrm_PlantillaMaster" %>
<%@ Register assembly="DevExpress.Web.v9.2, Version=9.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v9.2, Version=9.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.v9.2, Version=9.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v9.2, Version=9.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.v9.2, Version=9.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v9.2, Version=9.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div>
    <table style="width:100%;">
        <tr>
            <td>
    	    <dxe:ASPxHyperLink ID="Regresar" runat="server" 
                ImageUrl="~/Images/regresar.gif" NavigateUrl="~/Wfrm_Normas.aspx" />
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="325px" 
                Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Configuración de campos de captura de la norma</asp:label>
            </td>
        </tr>
        <tr>
            <td>
                <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" 
        Text="" ForeColor="Red"></dxe:ASPxLabel></td>
        </tr>
        <tr>
            <td>
            
            
                <asp:DataList ID="dlAreas" runat="server" 
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="2" DataKeyField="idArea" 
                    DataSourceID="ObjectDataSource1" Font-Bold="False" Font-Italic="False" 
                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                    GridLines="Both" Height="25px" HorizontalAlign="Left" 
                    RepeatDirection="Horizontal" SelectedIndex="0" style="margin-top: 0px" 
                    Width="600px" RepeatColumns="4">
                    <EditItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                        Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
                    <AlternatingItemStyle Font-Bold="False" Font-Italic="False" 
                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                        ForeColor="Black" />
                        
                    <ItemStyle Font-Bold="False" Font-Italic="False" 
                        Font-Names="Arial" Font-Overline="False" Font-Size="8pt" Font-Strikeout="False" 
                        Font-Underline="False" HorizontalAlign="Left" 
                        VerticalAlign="Top" CssClass="DataList_Aqua" ForeColor="Black" />
                    <SeparatorStyle 
                        BorderWidth="2px" ForeColor="Black" />
                    <SelectedItemStyle Font-Bold="False" Font-Italic="False" 
                        Font-Names="Arial" Font-Overline="False" Font-Size="8pt" Font-Strikeout="False" 
                        Font-Underline="False" HorizontalAlign="Left" 
                        VerticalAlign="Top" CssClass="DataList_Aqua_Sel" ForeColor="Black" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# DataBinder.Eval(Container, "DataItem.folio_norma") %>'></asp:Label>
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
<dxp:PanelContent runat="server"></dxp:PanelContent>
</PanelCollection>
                </dxp:ASPxPanel>
            </td>
        </tr>
        <tr>
            <td>
                <dxpc:ASPxPopupControl ID="PantallaCaptura" runat="server"
                    HeaderText="Agregar campo en" Left=390 Top=10 Width="493px">
                    <ContentCollection>
<dxpc:PopupControlContentControl runat="server">
    <table style="border: thin solid #C9D7DD; width: 100%;">
        <tr>
            <td style="width: 74px">
                &nbsp;</td>
            <td colspan="2">
                <dxe:ASPxLabel ID="lblElemento" runat="server" Font-Bold="True" 
                    Font-Size="10pt">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="width: 74px">
                Tipo</td>
            <td colspan="2">
                <dxe:ASPxComboBox ID="Tipo" runat="server" 
                    SelectedIndex="0" ValueType="System.Int32" Width="200px" 
                    ClientInstanceName="cmbTipo" AutoPostBack="True" >
                    <Items>
                        <dxe:ListEditItem Text="Entero" Value="7" />
                        <dxe:ListEditItem Text="Fecha" Value="2" />
                        <dxe:ListEditItem Text="Periodo de fechas" Value="3" />
                        <dxe:ListEditItem Text="Periodo Mes Año" Value="4" />
                        <dxe:ListEditItem Text="Periodo Años" Value="5" />
                        <dxe:ListEditItem Text="Texto" Value="0" />
                        <dxe:ListEditItem Text="Texto Largo" Value="1" />
                        <dxe:ListEditItem Text="Seleccion Si/No" Value="6" />
                        <dxe:ListEditItem Text="Calculo Valor mas reciente" Value="8" />
                        <dxe:ListEditItem Text="Calculo Valor mas antiguo" Value="9" />
                        <dxe:ListEditItem Text="Calculo Suma Valor" Value="10" />
                        <dxe:ListEditItem Text="Catálogo del sistema" Value="11" />
                        <dxe:ListEditItem Text="Catálogo ISAAR" Value="13" />
                        <dxe:ListEditItem Text="Grid ISAAR" Value="14" />
                    </Items>                
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="width: 74px">
                &nbsp;</td>
            <td style="text-align: left; vertical-align: top; width: 25px;">
                <asp:Label ID="lblLongitud" runat="server" Text="Longitud" Visible="False"></asp:Label>
            </td>
            <td style="text-align: left; vertical-align: top;">
                <dxe:ASPxSpinEdit ID="Longitud" runat="server" AllowNull="False" Number="0" 
                    Width="60px" ClientInstanceName="Longitud" Visible="False">
                </dxe:ASPxSpinEdit>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 74px">
                <asp:Label ID="lblCatalogo" runat="server" Text="Catálogo" Visible="False"></asp:Label>
            </td>
            <td colspan="2" style="text-align: left; vertical-align: top; ">
                <dxe:ASPxComboBox ID="cmbCatalogo" runat="server" DataSourceID="odsCatalogo" 
                    ValueField="IDCatalogo" ValueType="System.Int32" Visible="False" Width="300px">
                    <Columns>
                        <dxe:ListBoxColumn Caption="IDCatalogo" FieldName="IDCatalogo" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="Descripcion" FieldName="Descripcion" />
                    </Columns>
                </dxe:ASPxComboBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 74px">
                <asp:Label ID="lblMultivalor" runat="server" Text="multi-valor" Visible="False"></asp:Label>
            </td>
            <td colspan="2" style="text-align: left; vertical-align: top; ">
                <dxe:ASPxCheckBox ID="chkMultivalor" runat="server" Visible="False">
                </dxe:ASPxCheckBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 74px">
                ID</td>
            <td colspan="2" >
                <dxe:ASPxTextBox ID="folio_norma" runat="server" Width="300px">
                </dxe:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 74px">
                Nombre</td>
            <td colspan="2">
                <dxe:ASPxTextBox ID="CampoNombre" runat="server" Width="300px">
                </dxe:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 74px">
                Mascara</td>
            <td colspan="2">
                <dxe:ASPxTextBox ID="Mascara" runat="server" Width="300px">
                </dxe:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 74px">
                Obligatorio</td>
            <td colspan="2">
                <dxe:ASPxCheckBox ID="Obligatorio" runat="server">
                </dxe:ASPxCheckBox>
            </td>
        </tr>
        <tr>
            <td style="width: 74px">
                Visible</td>
            <td colspan="2">
                <dxe:ASPxCheckBox ID="vVisible" runat="server" Checked="True">
                </dxe:ASPxCheckBox>
            </td>
        </tr>
        <tr>
            <td style="width: 74px">
                Concatena valores de sus padres</td>
            <td colspan="2">
                <dxe:ASPxCheckBox ID="vPadres" runat="server" Checked="True">
                </dxe:ASPxCheckBox>
            </td>
        </tr>
    </table>
    <br />
    <dxe:ASPxButton ID="ASPxButton2" runat="server" Text="Aceptar">
    </dxe:ASPxButton>
                        </dxpc:PopupControlContentControl>
</ContentCollection>
                </dxpc:ASPxPopupControl>
            </td>
        </tr>
    </table>
        <asp:ObjectDataSource ID="odsCatalogo" runat="server" 
            SelectMethod="ListaCatalogo" TypeName="Portalv9.WSArchivo.Service1">
        </asp:ObjectDataSource>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="ListaNormas_Areas" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
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
