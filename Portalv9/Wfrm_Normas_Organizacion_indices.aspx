<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_Normas_Organizacion_indices.aspx.vb" Inherits="Portalv9.Wfrm_Normas_Organizacion_indices" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="height: 36px">
    	    <dxe:aspxhyperlink ID="Regresar" runat="server" 
                ImageUrl="~/Images/regresar.gif"  />
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                    Font-Names="Arial" Font-Size="10pt" Height="16px" Width="534px"> Administración--&gt; Definición de índices</asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;">
                <dxwgv:ASPxGridView ID="gdSeries" runat="server" 
                    DataSourceID="dsSeries_Indices" AutoGenerateColumns="False" 
                    KeyFieldName="idIndice" Width="600px" ClientInstanceName="gdSeries">
                    <Templates>
                        <EditForm>
                            <table style="border: thin solid #C9D7DD; width: 100%; height: 160px;">
                                <tr>
                                    <td style="width: 161px" class="style1">
                                        Area del índice</td>
                                    <td colspan="2">
                                        <dxe:ASPxComboBox ID="cmbArea" runat="server" ClientInstanceName="cmbArea" 
                                            DataSourceID="dsAreas" TextField="Area_descripcion" 
                                            Value='<%# Bind("idArea") %>' ValueField="idArea" ValueType="System.Int32" 
                                            Width="320px">
                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbElemento.PerformCallback(s.GetValue().toString());
}" />
                                        </dxe:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1" style="width: 161px">
                                        Elemento del índice</td>
                                    <td colspan="2">
                                        <dxe:ASPxComboBox ID="cmbElemento" runat="server" 
                                            ClientInstanceName="cmbElemento" DataSourceID="dsElementos" 
                                            oncallback="cmbElemento_Callback" TextField="Elemento_descripcion" 
                                            Value='<%# Bind("idElemento") %>' ValueField="idElemento" 
                                            ValueType="System.Int32" Width="320px">
                                        </dxe:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1" style="width: 161px">
                                        Nombre del campo</td>
                                    <td colspan="2">
                                        <dxe:ASPxTextBox ID="CampoNombre" runat="server" 
                                            Text='<%# Bind("Indice_descripcion") %>' Width="300px">
                                        </dxe:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 161px" class="style1">
                                        Tipo de dato</td>
                                    <td colspan="2">
                                        <dxe:ASPxComboBox ID="Tipo" runat="server" 
                                            ClientInstanceName="cmbTipo" 
                                            ValueType="System.Byte" Width="200px" 
                                            Value='<%# Bind("Indice_Tipo") %>'>
                                            <Items>                                                
                                                <dxe:ListEditItem Text="Alfanumerico" Value="0" />
                                                <dxe:ListEditItem Text="Numérico" Value="1" />
                                                <dxe:ListEditItem Text="Fecha" Value="2" />
                                            </Items>
                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
var value = s.GetValue();
gdSeries.PerformCallback(value);
	                                                    }" />
                                           </dxe:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1" style="height: 45px">
                                    </td>
                                    <td style="width: 52px; text-align: right; height: 45px;">
                                        <asp:Label ID="lblLongitud" runat="server" Text="Longitud" Visible="true" 
                                            Width="50px"></asp:Label>
                                    </td>
                                    <td style="height: 45px">
                                        <dxe:ASPxSpinEdit ID="Longitud" runat="server" AllowNull="False" 
                                            ClientInstanceName="Longitud" 
                                            Number='<%# Bind("Indice_LongitudMax") %>' 
                                            Width="70px" NumberType="Integer">
                                        </dxe:ASPxSpinEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 161px" class="style1">
                                        Es llave primaria?</td>
                                    <td colspan="2">
                                        <dxe:ASPxCheckBox ID="PK" runat="server" Value='<%# Bind("Indice_PK") %>'>
                                        </dxe:ASPxCheckBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1" style="width: 161px">
                                        Obligatorio</td>
                                    <td colspan="2">
                                        <dxe:ASPxCheckBox ID="Obligatorio" runat="server" 
                                            Value='<%# Bind("Indice_Obligatorio") %>'>
                                        </dxe:ASPxCheckBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 161px" class="style1">
                                        indice único&nbsp;</td>
                                    <td colspan="2">
                                        <dxe:ASPxCheckBox ID="vUnico" runat="server" 
                                            Value='<%# Bind("Indice_Unico") %>'>
                                        </dxe:ASPxCheckBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="width: 161px" class="style1">
                                        Indice Visible&nbsp;</td>
                                    <td colspan="2">
                                        <dxe:ASPxCheckBox ID="ASPxCheckBox1" runat="server" 
                                            Value='<%# Bind("Indice_Visible") %>'>
                                        </dxe:ASPxCheckBox>
                                    </td>
                                </tr>
                            </table>
                                  <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                                  <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                        </EditForm>
                    </Templates>
                    <SettingsEditing EditFormColumnCount="1" NewItemRowPosition="Bottom" />
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguri desea eliminar este registro?" 
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
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="Tipo de campo" 
                            FieldName="Indice_Tipo" VisibleIndex="1">
                            <PropertiesComboBox ValueType="System.Byte">
                                <Items>
                                    <dxe:ListEditItem Text="Alfanumerico" Value="0" />
                                    <dxe:ListEditItem Text="Numérico" Value="1" />
                                    <dxe:ListEditItem Text="Fecha" Value="2" />
                                </Items>
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Longitud" FieldName="Indice_LongitudMax" 
                            VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="relacion_con_normaPID" 
                            FieldName="relacion_con_normaPID" VisibleIndex="3" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Mascara" FieldName="Indice_Mascara" 
                            VisibleIndex="3" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataCheckColumn FieldName="Indice_PK" Caption="Es llave primaria?" VisibleIndex="3">
<PropertiesCheckEdit ValueType="System.Byte" ValueChecked="1" ValueUnchecked="0"></PropertiesCheckEdit>
</dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Obligatorio" 
                            FieldName="Indice_Obligatorio" VisibleIndex="4">
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Indice único" FieldName="Indice_Unico" 
                            VisibleIndex="5">
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Byte" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Byte" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Visible" FieldName="Indice_Visible" 
                            VisibleIndex="6">
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewCommandColumn VisibleIndex="7">
                            <EditButton Visible="True">
                            </EditButton>
                            <NewButton Visible="True">
                            </NewButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                        </dxwgv:GridViewCommandColumn>
                    </Columns>
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:msgbox ID="dlgBoxExcepciones" runat="server" />
                <asp:ObjectDataSource ID="dsSeries_Indices" runat="server" 
                    SelectMethod="ListaNormas_Elementos_CamposxSerie" TypeName="Portalv9.WSArchivo.Service1" 
                    DeleteMethod="ABC_Normas_Elementos_Campos" InsertMethod="ABC_Normas_Elementos_Campos" 
                    UpdateMethod="ABC_Normas_Elementos_Campos">
                    <DeleteParameters>
                        <asp:Parameter Name="op" Type="Object" DefaultValue="1" />
                        <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
                        <asp:Parameter Name="idArea" Type="Int32" />
                        <asp:Parameter Name="idElemento" Type="Int32" />
                        <asp:QueryStringParameter Name="idNivel" QueryStringField="idNivel" Type="Int32" />
                        <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" Type="Int32" />
                        <asp:Parameter Name="idIndice" Type="Int32" />
                        <asp:Parameter Name="Indice_descripcion" Type="String" />
                        <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                        <asp:Parameter Name="Indice_LongitudMax" Type="Int32" />
                        <asp:Parameter Name="Indice_Mascara" Type="String" />
                        <asp:Parameter Name="Indice_PK" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="Indice_Obligatorio" Type="Int32" />
                        <asp:Parameter Name="Indice_Unico" Type="Int32" />
                        <asp:Parameter Name="Indice_buscar" Type="Int32" />
                        <asp:Parameter Name="Indice_CopiarValor" Type="Int32" />
                        <asp:Parameter Name="Indice_EsAutoincremental" Type="Int32" />
                        <asp:Parameter Name="IndiceReadOnly" Type="Int32" />
                        <asp:Parameter Name="Indice_Visible" Type="Int32" />
                        <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                        <asp:Parameter Name="folio_norma" Type="String" />
                        <asp:Parameter Name="Muestra_padres" Type="Int32" />
                        <asp:Parameter Name="Multi_valor" Type="Int32" DefaultValue="" />
                        <asp:Parameter Name="Asigned" Type="Int32" />
                        <asp:Parameter Name="Asigned_value" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
                        <asp:QueryStringParameter DefaultValue="" Name="idNorma" 
                            QueryStringField="idNorma" Type="Int32" />
                        <asp:Parameter Name="idArea" Type="Int32" />
                        <asp:Parameter Name="idElemento" Type="Int32" />
                        <asp:QueryStringParameter  Name="idNivel" QueryStringField="idNivel" Type="Int32" />
                        <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" Type="Int32" />
                        <asp:Parameter Name="idIndice" Type="Int32" />
                        <asp:Parameter Name="Indice_descripcion" Type="String" />
                        <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                        <asp:Parameter Name="Indice_LongitudMax" Type="Int32" />
                        <asp:Parameter Name="Indice_Mascara" Type="String" />
                        <asp:Parameter Name="Indice_PK" Type="Int32" />
                        <asp:Parameter Name="Indice_Obligatorio" Type="Int32" />
                        <asp:Parameter Name="Indice_Unico" Type="Int32" />
                        <asp:Parameter Name="Indice_buscar" Type="Int32" />
                        <asp:Parameter Name="Indice_CopiarValor" Type="Int32" />
                        <asp:Parameter Name="Indice_EsAutoincremental" Type="Int32" />
                        <asp:Parameter Name="IndiceReadOnly" Type="Int32" />
                        <asp:Parameter Name="Indice_Visible" Type="Int32" />
                        <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                        <asp:Parameter Name="folio_norma" Type="String" />
                        <asp:Parameter Name="Muestra_padres" Type="Int32" />
                        <asp:Parameter Name="Multi_valor" Type="Int32" />
                        <asp:Parameter Name="Asigned" Type="Int32" />
                        <asp:Parameter Name="Asigned_value" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" 
                            Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="op" Type="Object" DefaultValue="0" />
                        <asp:QueryStringParameter  Name="idNorma" QueryStringField="idNorma" Type="Int32" />
                        <asp:Parameter Name="idArea" Type="Int32"  />
                        <asp:Parameter Name="idElemento" Type="Int32"  />
                        <asp:QueryStringParameter Name="idNivel" QueryStringField="idNivel" Type="Int32" />
                        <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" Type="Int32" />
                        <asp:Parameter Name="idIndice" Type="Int32" />
                        <asp:Parameter Name="Indice_descripcion" Type="String" />
                        <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                        <asp:Parameter Name="Indice_LongitudMax" Type="Int32" />
                        <asp:Parameter Name="Indice_Mascara" Type="String" />
                        <asp:Parameter Name="Indice_PK" Type="Int32" />
                        <asp:Parameter Name="Indice_Obligatorio" Type="Int32" />
                        <asp:Parameter Name="Indice_Unico" Type="Int32" />
                        <asp:Parameter Name="Indice_buscar" Type="Int32" />
                        <asp:Parameter Name="Indice_CopiarValor" Type="Int32" />
                        <asp:Parameter Name="Indice_EsAutoincremental" Type="Int32" />
                        <asp:Parameter Name="IndiceReadOnly" Type="Int32" />
                        <asp:Parameter Name="Indice_Visible" Type="Int32" />
                        <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                        <asp:Parameter Name="folio_norma" Type="String" />
                        <asp:Parameter Name="Muestra_padres" Type="Int32" />
                        <asp:Parameter Name="Multi_valor" Type="Int32" DefaultValue="" />
                        <asp:Parameter Name="Asigned" Type="Int32" />
                        <asp:Parameter Name="Asigned_value" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsCatalogo" runat="server" 
            SelectMethod="ListaCatalogo" TypeName="Portalv9.WSArchivo.Service1">
        </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsAreas" runat="server" 
                    SelectMethod="ListaNormas_Areas" TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsElementos" runat="server" 
                    SelectMethod="ListaNormas_Elementos" TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                            Type="Int32" />
                        <asp:SessionParameter Name="idArea" SessionField="idArea" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>
