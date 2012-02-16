<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmasteranidada.master" CodeBehind="Wfrm_PlantillaArchivoBak.aspx.vb" Inherits="Portalv9.Wfrm_PlantillaArchivoBak" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<asp:Content ID="Content4" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <div>
    
                <dxpc:ASPxPopupControl ID="PantallaCaptura" runat="server"
                    HeaderText="Agregar campo en" Left=390 Top=10 Width="493px">
                    <ContentCollection>
<dxpc:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
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
                <dxe:ASPxComboBox ID="Tipo" runat="server" RenderIFrameForPopupElements="True" 
                    ValueType="System.Int32" Width="185px" AutoPostBack="True" >
                    <Items>
                        <dxe:ListEditItem Text="Entero" Value="7" />
                        <dxe:ListEditItem Text="Fecha" Value="2" />
                        <dxe:ListEditItem Text="Periodo de fechas" Value="3" />
                        <dxe:ListEditItem Text="Periodo Mes Año" Value="4" />
                        <dxe:ListEditItem Text="Periodo Años" Value="5" />
                        <dxe:ListEditItem Text="Texto" Value="0" />
                        <dxe:ListEditItem Text="Texto Largo" Value="1" />
                        <dxe:ListEditItem Text="Seleccion Si/No" Value="6" />
                    </Items>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="width: 74px">
                &nbsp;</td>
            <td style="text-align: right; table-layout: inherit;" width="40">
                <asp:Label ID="lblLongitud" runat="server" Text="Longitud"></asp:Label>
            </td>
            <td>
                <dxe:ASPxSpinEdit ID="Longitud" runat="server" AllowNull="False" Height="21px" 
                    Number="0" Width="70px">
                </dxe:ASPxSpinEdit>
                &nbsp;</td>
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
    </table>
    <br />
    <dxe:ASPxButton ID="ASPxButton2" runat="server" Text="Aceptar">
    </dxe:ASPxButton>
                        </dxpc:PopupControlContentControl>
</ContentCollection>
                </dxpc:ASPxPopupControl>
    
    <table style="width:100%; height: 51px;">
        <tr>
            <td>
    	    <dxe:ASPxHyperLink ID="Regresar" runat="server" 
                ImageUrl="~/Images/regresar.gif" NavigateUrl="~/Wfrm_Archivo_Elementos.aspx" />
												<asp:label id="lblTitle" runat="server" 
                    Font-Size="Small" Width="385px" 
                                            Height="16px" Font-Names="Arial"
													Font-Bold="True" Font-Italic="True">Configuración de campos para el archivo</asp:label>
            </td>
        </tr>
        <tr>
            <td>
                <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" 
        Text="" ForeColor="Red"></dxe:ASPxLabel></td>
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
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
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
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>

