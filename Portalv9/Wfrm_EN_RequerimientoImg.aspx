<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_EN_RequerimientoImg.aspx.vb" Inherits="Portalv9.Wfrm_EN_RequerimientoImg" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register src="WebUsrCtrls/CampoSI_NO.ascx" tagname="CampoSI_NO" tagprefix="uc1" %>
<%@ Register src="WebUsrCtrls/CampoEntero.ascx" tagname="CampoEntero" tagprefix="uc2" %>
<%@ Register src="WebUsrCtrls/CampoTexto.ascx" tagname="CampoTexto" tagprefix="uc3" %>
<%@ Register src="WebUsrCtrls/CampoTextoLargo.ascx" tagname="CampoTextoLargo" tagprefix="uc4" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
  <div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text=""> </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">.
     <table align="center" style="width: 80%; border: 1px solid #A3C0E8">
        <tr>
            <td style="text-align: right;" class="style1">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right; color: #FF0000;"></asp:Label>
                <br />
                </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 134px; text-align: right;">
                <asp:Label ID="lblSellada" runat="server" Text="Tipo de Expediente" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
 <dxe:ASPxComboBox ID="cmbTipoExpediente" runat="server" 
                    DataSourceID="dsLista_SeriesModelo" ValueType="System.Int32" 
                    TextField="Serie_nombre" ValueField="idSerie" Width="310px" 
                    AutoPostBack="True">
                    <Columns>
                        <dxe:ListBoxColumn Caption="idNorma" FieldName="idNorma" Name="idNorma" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="idNivel" FieldName="idNivel" Name="idNivel" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="idSerie" FieldName="idSerie" 
                            Name="idSerie" Visible="False" />
                        <dxe:ListBoxColumn Caption="Tipo de expediente" FieldName="Clave" 
                            Name="Clave" Visible="False" />
                        <dxe:ListBoxColumn Caption="Tipo de expediente" FieldName="Serie_nombre" 
                            Name="Serie_nombre" />
                    </Columns>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 134px; text-align: right;">
                <asp:Label ID="lblentidad" runat="server" Text="Entidad" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <dxe:ASPxComboBox ID="ASPxComboBox1" runat="server" DataSourceID="ds_Entidades" 
                    ValueType="System.String" AutoPostBack="True" TextField="Descripcion" 
                    ValueField="idDescripcion" Visible="False">
                    <Columns>
                        <dxe:ListBoxColumn Caption="idDescripcion" FieldName="idDescripcion" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="idNivel" FieldName="idNivel" Visible="False" />
                        <dxe:ListBoxColumn Caption="Descripcion" FieldName="Descripcion" />
                        <dxe:ListBoxColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
                            Visible="False" />
                    </Columns>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 134px; text-align: right;">
                <asp:Label ID="lblarea" runat="server" Text="Area Administrativa" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <dxe:ASPxComboBox ID="ASPxComboBox2" runat="server" Visible="False" 
                    AutoPostBack="True" DataSourceID="ds_AreasAdministrativas" 
                    TextField="Descripcion" ValueField="idDescripcion" ValueType="System.String">
                    <Columns>
                        <dxe:ListBoxColumn Caption="idDescripcion" FieldName="idDescripcion" 
                            Visible="False" />
                        <dxe:ListBoxColumn Caption="Descripcion" FieldName="Descripcion" />
                    </Columns>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 134px; text-align: right;">
                <asp:Label ID="lblindices" runat="server" Text="Palabra a Buscar" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td>
                <dxe:ASPxTextBox ID="txtindice" runat="server" Width="170px" Visible="False">
                </dxe:ASPxTextBox>
                <asp:Label ID="lblrequerido" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right; color: #FF0000;" 
                    Visible="False">* Requerido</asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 134px; text-align: right;">
                <asp:Label ID="lblanio" runat="server" Text="Año:" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <dxe:ASPxTextBox ID="txtanio" runat="server" Visible="False" Width="170px">
                </dxe:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 134px; text-align: right;">
                <asp:Label ID="lblmes" runat="server" Text="Mes: " 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <dxe:ASPxComboBox ID="dlMes" runat="server" SelectedIndex="0" 
                    ValueType="System.String" Visible="False" 
                    EnableIncrementalFiltering="True">
                    <Items>
                        <dxe:ListEditItem Selected="True" Text=" " />
                        <dxe:ListEditItem Text="01" Value="01" />
                        <dxe:ListEditItem Text="02" Value="02" />
                        <dxe:ListEditItem Text="03" Value="03" />
                        <dxe:ListEditItem Text="04" Value="04" />
                        <dxe:ListEditItem Text="05" Value="05" />
                        <dxe:ListEditItem Text="06" Value="06" />
                        <dxe:ListEditItem Text="07" Value="07" />
                        <dxe:ListEditItem Text="08" Value="08" />
                        <dxe:ListEditItem Text="09" Value="09" />
                        <dxe:ListEditItem Text="10" Value="10" />
                        <dxe:ListEditItem Text="11" Value="11" />
                        <dxe:ListEditItem Text="12" Value="12" />
                    </Items>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 134px; text-align: right;">
                <asp:Label ID="lbldia" runat="server" Text="Día:" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <dxe:ASPxComboBox ID="dlDia" runat="server" SelectedIndex="0" 
                    ValueType="System.String" Visible="False" 
                    EnableIncrementalFiltering="True">
                    <Items>
                        <dxe:ListEditItem Selected="True" Text=" " />
                        <dxe:ListEditItem Text="01" Value="01" />
                        <dxe:ListEditItem Text="02" Value="02" />
                        <dxe:ListEditItem Text="03" Value="03" />
                        <dxe:ListEditItem Text="04" Value="04" />
                        <dxe:ListEditItem Text="05" Value="05" />
                        <dxe:ListEditItem Text="06" Value="06" />
                        <dxe:ListEditItem Text="07" Value="07" />
                        <dxe:ListEditItem Text="08" Value="08" />
                        <dxe:ListEditItem Text="09" Value="09" />
                        <dxe:ListEditItem Text="10" Value="10" />
                        <dxe:ListEditItem Text="11" Value="11" />
                        <dxe:ListEditItem Text="12" Value="12" />
                        <dxe:ListEditItem Text="13" Value="13" />
                        <dxe:ListEditItem Text="14" Value="14" />
                        <dxe:ListEditItem Text="15" Value="15" />
                        <dxe:ListEditItem Text="16" Value="16" />
                        <dxe:ListEditItem Text="17" Value="17" />
                        <dxe:ListEditItem Text="18" Value="18" />
                        <dxe:ListEditItem Text="18" Value="18" />
                        <dxe:ListEditItem Text="20" Value="20" />
                        <dxe:ListEditItem Text="21" Value="21" />
                        <dxe:ListEditItem Text="22" Value="22" />
                        <dxe:ListEditItem Text="23" Value="23" />
                        <dxe:ListEditItem Text="24" Value="24" />
                        <dxe:ListEditItem Text="25" Value="25" />
                        <dxe:ListEditItem Text="26" Value="26" />
                        <dxe:ListEditItem Text="27" Value="27" />
                        <dxe:ListEditItem Text="28" Value="28" />
                        <dxe:ListEditItem Text="29" Value="29" />
                        <dxe:ListEditItem Text="30" Value="30" />
                        <dxe:ListEditItem Text="31" Value="31" />
                    </Items>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 134px">
                &nbsp;</td>
            <td style="height: 21px; text-align: left;">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/Images/Buscar2.gif" Visible="False" />
            </td>
        </tr>
    </table>
<br />
     <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" Visible="False" 
         DataSourceID="ObjectDataSource2" AutoGenerateColumns="False" 
         Font-Size="X-Small">
         <Columns>
             <dxwgv:GridViewDataHyperLinkColumn VisibleIndex="0">
                 <DataItemTemplate>
                     <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server" 
                         NavigateUrl='<%# "Wfrm_TE_BuscaExpedienteArbol.aspx?idDescripcion=" &  Eval("idDescripcion") & "&confidencial=" & Request.QueryString("confidencial") & "&idfolio=" & Eval("idFolio")  %>' Text="Ver" />
                 </DataItemTemplate>
             </dxwgv:GridViewDataHyperLinkColumn>
             <dxwgv:GridViewDataTextColumn Caption="Indice en el que se encontro" 
                 FieldName="Indice" VisibleIndex="1">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Valor" FieldName="valor" 
                 VisibleIndex="2">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Tipo de Expediente" 
                 FieldName="TipoExpediente" VisibleIndex="1" Visible="False">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Código del expediente" 
                 FieldName="Llave_expediente" VisibleIndex="3">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Indice de búsqueda" 
                 FieldName="Indice_de_busqueda" VisibleIndex="4">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Fecha" VisibleIndex="5" 
                 FieldName="Fecha_solicitud">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                 VisibleIndex="6">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                 VisibleIndex="7">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="8">
             </dxwgv:GridViewDataTextColumn>
         </Columns>
     </dxwgv:ASPxGridView>

                <asp:ObjectDataSource ID="ds_Entidades" runat="server" 
         SelectMethod="ListaFondoxNivel" TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:Parameter Name="idArchivo" Type="Int32" />
                        <asp:Parameter DefaultValue="3" Name="Fondo_ini" Type="Int32" />
                        <asp:Parameter DefaultValue="3" Name="Fondo_fin" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="ds_AreasAdministrativas" runat="server" 
         SelectMethod="ListaFondoxNivelxPadre" TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:Parameter Name="idArchivo" Type="Int32" />
                        <asp:Parameter DefaultValue="4" Name="Fondo_ini" Type="Int32" />
                        <asp:Parameter DefaultValue="4" Name="Fondo_fin" Type="Int32" />
                        <asp:Parameter Name="Padre" Type="Int32" />
                    </SelectParameters>
     </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="dsLista_SeriesModelo" runat="server" SelectMethod="ListaSeries_Modelo" 
        TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:Parameter Name="identidad" Type="Int32" DefaultValue="" />
                        <asp:Parameter DefaultValue="5" Name="Profundidad" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>

     <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
         SelectMethod="BuscaExpediente" TypeName="Portalv9.WSArchivo.Service1">
         <SelectParameters>
             <asp:Parameter Name="SQLString" Type="String" />
         </SelectParameters>
     </asp:ObjectDataSource>

    <br />
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
</asp:Content>
