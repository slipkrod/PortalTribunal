<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmasteranidada.master" CodeBehind="Wfrm_TE_SolicitudExp.aspx.vb" Inherits="Portalv9.Wfrm_TE_SolicitudExp" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register src="WebUsrCtrls/CampoSI_NO.ascx" tagname="CampoSI_NO" tagprefix="uc1" %>
<%@ Register src="WebUsrCtrls/CampoEntero.ascx" tagname="CampoEntero" tagprefix="uc2" %>
<%@ Register src="WebUsrCtrls/CampoTexto.ascx" tagname="CampoTexto" tagprefix="uc3" %>
<%@ Register src="WebUsrCtrls/CampoTextoLargo.ascx" tagname="CampoTextoLargo" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 220px">
                Es confidencial?</td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 220px">
                Tipo de expediente</td>
            <td>
                <dxe:ASPxComboBox ID="dlTipoExpediente" runat="server" 
                    DataSourceID="dsLista_SeriesModelo" ValueType="System.Int32" 
                    TextField="Serie_nombre" ValueField="idSerie" Width="400px" 
                    AutoPostBack="True">
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="width: 220px">
                Año:</td>
            <td>
                <dxe:ASPxSpinEdit ID="txtAnio" runat="server" AllowNull="False" Height="21px" 
                    Number="0" />
            </td>
        </tr>
        <tr>
            <td style="width: 220px">
                Mes</td>
            <td>
                <dxe:ASPxComboBox ID="dlMes" runat="server" SelectedIndex="0" 
                    ValueType="System.String">
                    <Items>
                        <dxe:ListEditItem Selected="True" Text="01" Value="01" />
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
            <td style="width: 220px">
                Día</td>
            <td>
                <dxe:ASPxComboBox ID="dlDia" runat="server" ValueType="System.String">
                    <Items>
                        <dxe:ListEditItem Selected="True" Text="01" Value="01" />
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
                        <dxe:ListEditItem Text="19" Value="19" />
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
            <td style="width: 220px">
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 220px">
                Indices de búsqueda:</td>
            <td>
                <dxwgv:ASPxGridView ID="gdSeries" runat="server" 
                    DataSourceID="dsSeries_Indices" AutoGenerateColumns="False" 
                    KeyFieldName="idIndice" Width="500px">
                    <SettingsPager Visible="False">
                    </SettingsPager>
                    <SettingsEditing EditFormColumnCount="1" NewItemRowPosition="Bottom" />
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
                                            <dxe:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="250px">
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
                                    <dxe:ListEditItem Text="Periodo Mes Año" Value="4" />
                                    <dxe:ListEditItem Text="Periodo Años" Value="5" />                                                
                                    <dxe:ListEditItem Text="Seleccion Si/No" Value="6" />
                                    <dxe:ListEditItem Text="Entero" Value="7" />
                                    <dxe:ListEditItem Text="Catálogo del sistema" Value="11" />
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
                        <dxwgv:GridViewDataCheckColumn Caption="Indice único" FieldName="Indice_Unico" 
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
            <td style="width: 220px">
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 220px">
                Seleccione los documentos a enviar</td>
            <td>
                <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dsLista_SeriesModelo_Hijos" 
                    KeyFieldName="idSerie" ParentFieldName="idSeriePID" 
                    EnableTheming="False" Width="195px">
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguro desea borrar este registro?" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos." />
                    <SettingsSelection Enabled="True" />
                    <SettingsPager Mode="ShowPager" PageSize="20">
                    </SettingsPager>
                    <SettingsBehavior AllowSort="False" />
                    <SettingsEditing EditFormColumnCount="1" Mode="EditFormAndDisplayNode" />
                    <Columns>
                        <dxwtl:TreeListTextColumn Caption="idNorma" FieldName="idNorma" Visible="False" 
                            VisibleIndex="0">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Tipo" VisibleIndex="0" ReadOnly="True">
                            <EditFormSettings Visible="False" />
                            <DataCellTemplate>
                                <dxe:ASPxImage ID="ASPxImage1" runat="server" ImageUrl="<%# GetNodeGlyph(Container) %>">
                                </dxe:ASPxImage>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nombre" FieldName="Serie_nombre" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListComboBoxColumn Caption="Tipo de elemento" FieldName="idNivel" 
                            VisibleIndex="2" Visible="False">
                            <PropertiesComboBox ValueType="System.Int32">
                                <Items>
                                    <dxe:ListEditItem Text="Separador" Value="220" />
                                    <dxe:ListEditItem Text="Documento" Value="223" />
                                </Items>
                            </PropertiesComboBox>
                            <EditFormSettings Visible="True" />
                        </dxwtl:TreeListComboBoxColumn>
                        <dxwtl:TreeListComboBoxColumn Caption="Atributo" FieldName="Atributo" 
                            VisibleIndex="2" Visible="False">
                            <PropertiesComboBox ValueType="System.Int32">
                                <Items>
                                    <dxe:ListEditItem Text="Opcional" Value="0" />
                                    <dxe:ListEditItem Text="Al menos uno" Value="1" />
                                    <dxe:ListEditItem Text="Requerido" Value="2" />
                                </Items>
                            </PropertiesComboBox>
                        </dxwtl:TreeListComboBoxColumn>
                        <dxwtl:TreeListTextColumn Caption="idSeriePID" FieldName="idSeriePID" 
                            Visible="False" VisibleIndex="3">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Indices" VisibleIndex="2">
                            <PropertiesTextEdit DisplayFormatString="{0}">
                            </PropertiesTextEdit>
                            <EditFormSettings Visible="False" />
                        </dxwtl:TreeListTextColumn>
                    </Columns>
                </dxwtl:ASPxTreeList>
            
            </td>
        </tr>
        <tr>
            <td style="width: 220px">
                </td>
            <td>
                <p>
                    <asp:ImageButton ID="btnAceptar" runat="server" BorderWidth="0" 
                        CausesValidation="False" Height="53px" ImageUrl="images/aceptar.gif" 
                        Width="73px" />
                </p>
            </td>
        </tr>
        <tr>
            <td style="width: 220px">
                &nbsp;</td>
            <td>
                <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
                    AutoGenerateColumns="False" Width="327px">
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="CampoID" FieldName="CampoID" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idIndice" FieldName="idIndice" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indice_Tipo" FieldName="Indice_Tipo" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Nombre del campo" 
                            FieldName="Indice_descripcion" VisibleIndex="0">
                            <PropertiesTextEdit ClientInstanceName="Indice_descripcion">
                            </PropertiesTextEdit>
                            <DataItemTemplate>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 108px">
                                            <dxe:ASPxLabel ID="ASPxLabel2" runat="server" 
                                                Text='<%# Bind("Indice_descripcion") %>'>
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td>
                                            <dxe:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="170px">
                                            </dxe:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <uc2:CampoEntero ID="CampoEntero1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <uc3:CampoTexto ID="CampoTexto1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <uc4:CampoTextoLargo ID="CampoTextoLargo1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </DataItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indice_LongitudMax" 
                            FieldName="Indice_LongitudMax" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indice_Obligatorio" 
                            FieldName="Indice_Obligatorio" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indice_Unico" FieldName="Indice_Unico" 
                            VisibleIndex="3">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="folio_norma" FieldName="folio_norma" 
                            VisibleIndex="4">
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td style="width: 220px">
                &nbsp;</td>
            <td>
                <dxe:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" 
                    CausesValidation="False" Text="Salvar">
                </dxe:ASPxButton>
            </td>
        </tr>
        <tr>
            <td style="width: 220px">
                </td>
            <td>
                <asp:Label ID="lblError" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table><div>
                <asp:ObjectDataSource ID="dsLista_SeriesModelo" runat="server" 
                    SelectMethod="ListaSeries_Modelo" TypeName="Portalv9.WSArchivo.Service1" 
                    OldValuesParameterFormatString="original_{0}">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsSeries_Indices" runat="server" 
                    SelectMethod="ListaSeries_Indices" TypeName="Portalv9.WSArchivo.Service1" 
                    OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="dlTipoExpediente" Name="idSerie" 
                            PropertyName="Value" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsLista_SeriesModelo_Hijos" runat="server" 
                    SelectMethod="ListaSeries_Modelo_Hijos" 
                    TypeName="Portalv9.WSArchivo.Service1" 
                    OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="dlTipoExpediente" Name="idSerie" 
                            PropertyName="Value" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsSeries_IndicesDoc" runat="server" 
                    SelectMethod="ListaSeries_Indices" TypeName="Portalv9.WSArchivo.Service1" 
                    OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter Name="idSerie" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
