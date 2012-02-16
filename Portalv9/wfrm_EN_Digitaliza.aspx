<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="wfrm_EN_Digitaliza.aspx.vb" Inherits="Portalv9.wfrm_EN_Digitaliza" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text=""> </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" style="width: 100%; border: 1px solid #A3C0E8">
        <tr>
            <td style="text-align: right; width: 193px;" class="style1">
                <b><font color="#000000" face="Arial, Helvetica, sans-serif" size="2">Solicita&nbsp;:</font></b></td>
            <td>
                <asp:Label ID="lblUsuarioSolicita" runat="server" Font-Names="Arial" 
                    Font-Size="10pt" Width="432px"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 193px;" class="style1">
                <b><font color="#000000" face="Arial, Helvetica, sans-serif" size="2">Fecha de 
                solicitud&nbsp;:</font></b></td>
            <td>
                <asp:Label ID="lblFechaSolicitud" runat="server" Font-Names="Arial" 
                    Font-Size="10pt" Width="419px"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 193px;" class="style1">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                <asp:Label ID="usuario" runat="server" Text="" Visible="False"></asp:Label>
                
                <asp:Label ID="grupo" runat="server" Text="" Visible="False"></asp:Label>
                <asp:Label ID="lblidSolicita" runat="server" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <b><font color="#000000" face="Arial, Helvetica, sans-serif" size="2">Es 
                confidencial ?:&nbsp;</font></b></td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblConfidencial" runat="server" Font-Names="Arial" 
                    Font-Size="10pt" Width="295px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lbltipoexpt" runat="server" Text="Tipo de Expediente:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblTipoExpediente" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 193px; text-align: right;">
                <asp:Label ID="lblentidadt" runat="server" Text="Entidad:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td>
                <asp:Label ID="lblEntidad" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                <asp:Label ID="lblidEntidad" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblareat" runat="server" Text="Area Adminitrativa:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblArea" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                <asp:Label ID="lblidArea" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblañot" runat="server" Text="Año:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblAno" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblmest" runat="server" Text="Mes:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblmes" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lbldiat" runat="server" Text="Dia: " 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lbldia" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblmest0" runat="server" Text="Codigo del Expediente: " 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblLlave" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <asp:Label ID="lblindicet" runat="server" Text="Indice de Busqueda:" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblIndice" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                <asp:Label ID="lblInstancia" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                &nbsp;</td>
            <td style="height: 21px; text-align: left;">
                <asp:Label ID="lblTipoDocumento" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                <asp:Label ID="lblIndiceCampos" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                <asp:Label ID="lblsecuencia" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                <asp:Label ID="lblidFolio" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                <asp:Label ID="lblTipo_operacion" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <b><font color="#000000" face="Arial, Helvetica, sans-serif" size="2">
                Digitalizar&nbsp;:</font></b></td>
            <td style="height: 21px; text-align: left;">
                                  <dxe:ASPxButton ID="ASPxButton1" runat="server" CausesValidation="False" 
                                      Text="Digitalizar">
                                  </dxe:ASPxButton>
                                  <asp:Label ID="lblDigitalizado" runat="server" Font-Names="Arial" 
                                      Font-Size="10pt" Visible="False" Width="43px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px; text-align: right;">
                <b><font color="white" face="Arial, Helvetica, sans-serif" size="2">
                <font color="#000000" face="Arial, Helvetica, sans-serif" size="2">Bolsa de 
                seguridad&nbsp;:&nbsp;</font> </font></b></td>
            <td style="height: 21px; text-align: left;">
                                  <asp:TextBox ID="txtBolsa" runat="server" MaxLength="20" Width="274px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="rfvBolsa" runat="server" 
                                      ControlToValidate="txtBolsa" ErrorMessage="* Requerido" Font-Size="XX-Small"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px">
                &nbsp;</td>
            <td style="height: 21px; text-align: left;">
                                  <p>
                                      <asp:ImageButton ID="btnAceptar" runat="server" BorderWidth="0" 
                                          CausesValidation="False" Height="53px" ImageUrl="images/aceptar.gif" 
                                          Width="73px" />
                                  </p>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 193px">
                &nbsp;</td>
            <td style="height: 21px; text-align: left;">
                                  <asp:Label ID="lblError" runat="server" Font-Names="Arial" Font-Size="Small" 
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; text-align: center;" colspan="2">
                        <asp:ObjectDataSource ID="dsExpediente" runat="server" 
                            SelectMethod="ListaArchivo_Serie" TypeName="Portalv9.WSArchivo.Service1">
                            <SelectParameters>
                                <asp:Parameter Name="idArchivo" Type="Int32" />
                                <asp:QueryStringParameter Name="idSerie" QueryStringField="idDescripcion" 
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                </td>
        </tr>
        <tr>
            <td style="height: 21px; text-align: center;" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 21px; " colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 21px; " colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
