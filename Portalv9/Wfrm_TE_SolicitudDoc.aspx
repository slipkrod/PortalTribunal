<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_SolicitudDoc.aspx.vb" Inherits="Portalv9.Wfrm_TE_SolicitudDoc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>


<asp:Content ID="Content4" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitle" runat="server" 
        Text="Administraci�n--&gt; Unidad Documental Compuesta - Subserie"></asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
                <asp:ObjectDataSource ID="dsLista_SeriesModelo" runat="server" SelectMethod="ListaSeries_Modelo" 
        TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:Parameter Name="identidad" Type="Int32" DefaultValue="" />
                        <asp:Parameter DefaultValue="5" Name="Profundidad" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 220px">
                <asp:Label ID="lblindices" runat="server" Text="Indices de B�squeda" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td>
                <asp:ObjectDataSource ID="dsSeries_Indices" runat="server" 
                    SelectMethod="ListaSeries_Indices" 
                    TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmbTipoExpediente" Name="idSerie" 
                            PropertyName="Value" Type="Int32" />
                    </SelectParameters>
                 </asp:ObjectDataSource>
<dxwgv:ASPxGridView ID="gdSeries" runat="server" 
                    DataSourceID="dsSeries_Indices" AutoGenerateColumns="False" 
                    KeyFieldName="idIndice" Width="500px" Visible="False">
                    <SettingsPager Visible="False">
                    </SettingsPager>
                    <SettingsEditing EditFormColumnCount="1" NewItemRowPosition="Bottom" />
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="�Seguri desea eliminar este registro?" 
                        EmptyDataRow="No existen datos" />
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="idNorma" FieldName="idNorma" 
                            VisibleIndex="0" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idArea" FieldName="idArea" 
                            VisibleIndex="0" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idElemento" FieldName="idElemento" 
                            VisibleIndex="0" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idIndice" FieldName="idIndice" 
                            VisibleIndex="0" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" 
                            VisibleIndex="0" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" 
                            VisibleIndex="0" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Nombre del campo" 
                            FieldName="Indice_descripcion" VisibleIndex="0">
                            <DataItemTemplate>
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <dxe:ASPxLabel ID="ASPxLabel1" runat="server" 
                                                Text='<%# Bind("Indice_descripcion") %>' Width="220px">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td>
                                            <dxe:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="250px" CssClass="requiredfield">
                                             <%--<ClientSideEvents KeyDown="function(s, e) 
                    {
                         s.SetText(s.GetText().toUpperCase());
                    }
                    "/>--%>
                                            </dxe:ASPxTextBox>
                                        </td>
                                    </tr>
                                </table>
                            </DataItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="Tipo de campo" 
                            FieldName="Indice_Tipo" VisibleIndex="1" Visible="False">
                            <PropertiesComboBox ValueType="System.Byte">
                                <Items>
                                    <dxe:ListEditItem Text="Texto" Value="0" />
                                    <dxe:ListEditItem Text="Texto Largo" Value="1" />
                                    <dxe:ListEditItem Text="Fecha" Value="2" />
                                    <dxe:ListEditItem Text="Periodo de fechas" Value="3" />
                                    <dxe:ListEditItem Text="Periodo Mes A�o" Value="4" />
                                    <dxe:ListEditItem Text="Periodo A�os" Value="5" />                                                
                                    <dxe:ListEditItem Text="Seleccion Si/No" Value="6" />
                                    <dxe:ListEditItem Text="Entero" Value="7" />
                                    <dxe:ListEditItem Text="Cat�logo del sistema" Value="11" />
                                </Items>
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Longitud" FieldName="Indice_LongitudMax" 
                            VisibleIndex="1" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="relacion_con_normaPID" 
                            FieldName="relacion_con_normaPID" VisibleIndex="3" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Mascara" FieldName="Indice_Mascara" 
                            VisibleIndex="1" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Obligatorio" 
                            FieldName="Indice_Obligatorio" VisibleIndex="1" Visible="False">
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Byte" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Indice �nico" FieldName="Indice_Unico" 
                            VisibleIndex="1" Visible="False">
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Byte" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                        </dxwgv:GridViewDataCheckColumn>
                    </Columns>
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 134px; text-align: right;">
                <asp:Label ID="lblanio" runat="server" Text="A�o:" 
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
                    ValueType="System.String" Visible="False">
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
                <asp:Label ID="lbldia" runat="server" Text="D�a:" 
                    ForeColor="#3F5DBC" style="text-align: right" Visible="False"></asp:Label>
                </td>
            <td style="height: 21px; text-align: left;">
                <dxe:ASPxComboBox ID="dlDia" runat="server" SelectedIndex="0" 
                    ValueType="System.String" Visible="False">
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
                         NavigateUrl='<%# "Wfrm_TE_SolicitudDocExp.aspx?confidencial=" & Request.QueryString("confidencial") & "&InstanciaPID=" & Eval("InstanciaId") & "&IdDescripcion=" & Eval("IdDescripcion")  %>' Text="Seleccionar" />
                 </DataItemTemplate>
             </dxwgv:GridViewDataHyperLinkColumn>
             <dxwgv:GridViewDataTextColumn Caption="Tipo" 
                 FieldName="TipoExpediente" VisibleIndex="1" ToolTip="Tipo de Expediente">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="C�digo" 
                 FieldName="Llave_expediente" VisibleIndex="2" 
                 ToolTip="C�digo del expediente">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Indice" 
                 FieldName="Indice_de_busqueda" VisibleIndex="3" 
                 ToolTip="Indice de b�squeda">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Fecha" VisibleIndex="4" 
                 FieldName="Fecha_solicitud" ToolTip="Fecha de Solicitud">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                 VisibleIndex="5" ToolTip="Usuario que solicit�">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                 VisibleIndex="6" ToolTip="Entidad a la que pertenece">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="7" 
                 ToolTip="Area a la que pertenece">
             </dxwgv:GridViewDataTextColumn>
         </Columns>
     </dxwgv:ASPxGridView>

     <asp:ObjectDataSource ID="ObjectDataSource2" runat="server">
     </asp:ObjectDataSource>

     <asp:ImageButton ID="ImageButton3" runat="server" 
         ImageUrl="~/Images/Crear_Exp.gif" Visible="False" />

    <br />
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>

</asp:Content>

