<%@ Page Language="vb" MasterPageFile="~/Masterpages/Adminmaster2col.master" AutoEventWireup="false" CodeBehind="Wfrm_Indices_Sistema.aspx.vb" Inherits="Portalv9.Wfrm_Indices_Sistema" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Indices de sistema" > </asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    	    <dxe:ASPxHyperLink ID="Regresar" runat="server" 
                ImageUrl="~/Images/regresar.gif" NavigateUrl="~/Wfrm_Contenido.aspx" />
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="90%" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True" Text="Indices basicos escenciales"></asp:label>
            <br />
            <br />
    </div>
    <div>
        <dxwgv:ASPxGridView ID="gdIndices_Sistema" runat="server" 
            DataSourceID="dsIndices_Sistema" AutoGenerateColumns="False" 
            KeyFieldName="idIndice_Sistema" Width="100%" ClientInstanceName="gdSeries" 
            oncustomerrortext="gdSeries_CustomErrorText"  SettingsPager-PageSize="20" 
            onrowinserting="gdSeries_RowInserting" onrowupdating="gdSeries_RowUpdating" 
            onhtmleditformcreated="gdSeries_HtmlEditFormCreated">
            <Templates>
                <EditForm>
                    <table style="border: thin solid #C9D7DD; width: 100%; height: 160px;">
                        <tr>
                            <td class="style1" style="width: 161px">Area recomendada</td>
                            <td colspan="2">
                                <dxe:ASPxTextBox ID="Area_Recomendada" runat="server" 
                                    Text='<%# Bind("Area_Recomendada") %>' Width="300px">
                                </dxe:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" style="width: 161px">Elemento recomendado</td>
                            <td colspan="2">
                                <dxe:ASPxTextBox ID="Elemento_Recomendado" runat="server" 
                                    Text='<%# Bind("Elemento_Recomendado") %>' Width="300px">
                                </dxe:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" style="width: 161px">Nombre del campo</td>
                            <td colspan="2">
                                <dxe:ASPxTextBox ID="CampoNombre" runat="server" 
                                    Text='<%# Bind("Indice_descripcion") %>' Width="300px">
                                </dxe:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 161px" class="style1">Tipo de dato</td>
                            <td colspan="2">
                                <dxe:ASPxComboBox ID="Tipo" runat="server" ClientInstanceName="cmbTipo" 
                                    ValueType="System.Byte" Width="200px" 
                                    Value='<%# Bind("Indice_Tipo") %>'>
                                    <Items>                                                
                                        <dxe:ListEditItem Text="Entero" Value="7" />
                                        <dxe:ListEditItem Text="Fecha" Value="2" />
                                        <dxe:ListEditItem Text="Periodo de fechas" Value="3" />
                                        <dxe:ListEditItem Text="Periodo Mes Año" Value="4" />
                                        <dxe:ListEditItem Text="Periodo Años" Value="5" />
                                        <dxe:ListEditItem Text="Texto" Value="0" />
                                        <dxe:ListEditItem Text="Texto Largo" Value="1" />
                                        <dxe:ListEditItem Text="Seleccion Si/No" Value="6" />
                                        <dxe:ListEditItem Text="Catalogo" Value="11" />
                                        <dxe:ListEditItem Text="Grid" Value="12" />
                                    </Items>
                                    <ClientSideEvents ValueChanged="function(s, e) {
                                        try{
                                            document.getElementById('trLongitud').style.display = 'none';
                                            document.getElementById('trMascara').style.display = 'none';
                                            document.getElementById('trObligatorio').style.display = '';
                                            document.getElementById('tdIndiceUnico').style.display = '';
                                            document.getElementById('trLlavePrimaria').style.display = '';
                                            document.getElementById('trCatalogo').style.display = 'none';
                                            CampoValor.SetVisible(true);
                                            cmbCatalogoValues.SetVisible(false);
                                            }
                                            catch(e){} 
                                            switch (cmbTipo.GetValue()) {
                                                case 0:
                                                    try{
                                                        document.getElementById('trLongitud').style.display = '';
                                                        document.getElementById('trMascara').style.display = '';
                                                        CampoValor.SetVisible(true);
                                                        cmbCatalogoValues.SetVisible(false);
                                                        }
                                                    catch(e){} 
                                                    break;
                                                case 4:
                                                case 5:
                                                case 6:
                                                case 7:
                                                    try{
                                                    CampoValor.SetVisible(true);
                                                    cmbCatalogoValues.SetVisible(false);
                                                    }
                                                    catch(e){} 
                                                    break;
                                                case 11:
                                                    try{    
                                                        document.getElementById('trCatalogo').style.display = '';
                                                        document.getElementById('tdIndiceUnico').style.display = 'none';
                                                        document.getElementById('trLlavePrimaria').style.display = 'none';
                                                        CampoValor.SetVisible(false);
                                                        cmbCatalogoValues.SetVisible(true);
                                                        }
                                                    catch(e){} 
                                                    break;                                            
                                                case 12:                                                                                
                                                try{    
                                                    document.getElementById('trCatalogo').style.display = '';
                                                    document.getElementById('trAsigned').style.display = 'none';
                                                    document.getElementById('tdIndiceUnico').style.display = 'none';
                                                    document.getElementById('trLlavePrimaria').style.display = 'none';
                                                    CampoValor.SetVisible(false);
                                                    cmbCatalogoValues.SetVisible(true);
                                                    }
                                                catch(e){} 
                                                break;                                            
                                            }
                                       }" 
                                        />
                                   </dxe:ASPxComboBox>
                            </td>
                        </tr>
                        <tr id="trCatalogo" style="display:none;" >
                            <td class="style1" style="width: 161px">Tipo de Catalogo</td>
                            <td colspan="2">
                                <dxe:ASPxComboBox ID="cmbCatalogos" runat="server" ClientInstanceName="cmbCatalogos" 
                                    TextField="Descripcion" ValueField="IDCatalogo" ValueType="System.Int32"
                                    Width="200px" DataSourceID="dsCatalogos" Value='<%# Bind("relacion_con_normaPID") %>'>
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                        cmbCatalogoValues.PerformCallback(cmbCatalogos.GetValue().toString());
                                    }" />
                                </dxe:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" style="width: 161px">Valor por default</td>
                            <td colspan="2">
                                <dxe:ASPxCheckBox ID="ASPxCheckBox2" runat="server" 
                                    Value='<%# Bind("Asigned") %>' ClientInstanceName="ASPxCheckBox2">
                                    <ClientSideEvents ValueChanged="function(s, e) {
                                        if (s.GetValue() == 1)
                                                document.getElementById('trAsigned_value').style.display = ''; 
                                        else
                                                document.getElementById('trAsigned_value').style.display = 'none'; 
                                        if (document.getElementById('trCatalogo').style.display == '')
                                        {
                                            CampoValor.SetVisible(false); 
                                            cmbCatalogoValues.SetVisible(true); 
                                        }
                                        else
                                        {
                                            CampoValor.SetVisible(true); 
                                            cmbCatalogoValues.SetVisible(false); 
                                        }
                                        }" />
                                </dxe:ASPxCheckBox>
                            </td>
                        </tr>
                        <tr id="trAsigned_value">
                            <td class="style1" style="width: 161px">Valor</td>
                            <td colspan="2">
                                <dxe:ASPxTextBox ID="CampoValor" runat="server" Text='<%# Bind("Asigned_value") %>' Width="300px" ClientInstanceName="CampoValor"></dxe:ASPxTextBox>
                                <dxe:ASPxComboBox ID="cmbCatalogoValues" runat="server" SelectedIndex="-1" ClientInstanceName="cmbCatalogoValues" 
                                    Width="200px" DataSourceID="dsCatalogoValues" DropDownStyle="DropDown" 
                                    TextField="Descripcion" ValueField="IDCatalogo_item" 
                                    ValueType="System.Int32" OnCallback="cmbCatalogoValues_Callback" >
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                        cbpSetSes.PerformCallback(cmbCatalogoValues.GetValue().toString());
                                        }" />                                                                            
                                </dxe:ASPxComboBox>
                                <dxcp:ASPxCallbackPanel runat="server" ID="cbpSetSes" ClientInstanceName="cbpSetSes" OnCallback="cbpSetSes_Callback">
                                    <PanelCollection>
                                    <dxp:PanelContent ID="PanelContent1" runat="server">
                                    </dxp:PanelContent>
                                    </PanelCollection>
                                </dxcp:ASPxCallbackPanel>
                            </td>
                        </tr>
                        <tr id="trLongitud">
                            <td style="width: 74px;">Longitud</td>
                            <td colspan="2">
                                <dxe:ASPxSpinEdit ID="Longitud" runat="server" AllowNull="False" 
                                    ClientInstanceName="Longitud" Number='<%# Bind("Indice_LongitudMax") %>' 
                                    NumberType="Integer" Width="70px">
                                </dxe:ASPxSpinEdit>
                            </td>
                        </tr>
                        <tr id="trMascara">
                            <td style="width: 74px">
                                Mascara</td>
                            <td colspan="2">
                                <dxe:ASPxTextBox ID="Mascara" runat="server" Width="300px" 
                                    Text="<%# Bind('Indice_Mascara') %>">
                                </dxe:ASPxTextBox>
                            </td>
                        </tr>
                        <tr id="trObligatorio">
                            <td style="width: 74px">
                                Obligatorio</td>
                            <td colspan="2">
                                <dxe:ASPxCheckBox ID="Obligatorio" runat="server" Checked="true" Enabled="false" >
                                </dxe:ASPxCheckBox>
                            </td>
                        </tr>
                        <tr id="trLlavePrimaria">
                            <td style="width: 161px" class="style1">Es llave primaria?</td>
                            <td colspan="2">
                                <dxe:ASPxCheckBox ID="PK" runat="server" Value='<%# Bind("Indice_PK") %>'>
                                </dxe:ASPxCheckBox>
                            </td>
                        </tr>
                        <tr id="tdIndiceUnico">
                            <td style="width: 161px" class="style1">Indice único&nbsp;</td>
                            <td colspan="2">
                                <dxe:ASPxCheckBox ID="vUnico" runat="server" 
                                    Value='<%# Bind("Indice_Unico") %>'>
                                </dxe:ASPxCheckBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 161px" class="style1">Visible&nbsp;</td>
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
            <SettingsEditing EditFormColumnCount="1" NewItemRowPosition="Bottom" Mode="EditFormAndDisplayRow"   />
            <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                ConfirmDelete="¿Seguro que desea eliminar este registro?" 
                EmptyDataRow="No existen datos" />
                <ClientSideEvents EndCallback="function(s, e) { 
                  try{
                    document.getElementById('trLongitud').style.display = 'none';
                    document.getElementById('trMascara').style.display = 'none';
                    document.getElementById('trObligatorio').style.display = '';
                    document.getElementById('tdIndiceUnico').style.display = '';
                    document.getElementById('trLlavePrimaria').style.display = '';
                    document.getElementById('trCatalogo').style.display = 'none';
                    CampoValor.SetVisible(true);
                    cmbCatalogoValues.SetVisible(false);
                    }
                    catch(e){} 
                    try{
                    switch (cmbTipo.GetValue()) {
                        case 0:
                            try{
                                document.getElementById('trLongitud').style.display = '';
                                document.getElementById('trMascara').style.display = '';
                                CampoValor.SetVisible(true);
                                cmbCatalogoValues.SetVisible(false);
                                }
                            catch(e){} 
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            try{
                            CampoValor.SetVisible(true);
                            cmbCatalogoValues.SetVisible(false);
                            }
                            catch(e){} 
                            break;
                        case 11:
                            try{    
                                document.getElementById('trCatalogo').style.display = '';
                                document.getElementById('tdIndiceUnico').style.display = 'none';
                                document.getElementById('trLlavePrimaria').style.display = 'none';
                                CampoValor.SetVisible(false);
                                cmbCatalogoValues.SetVisible(true);
                                }
                            catch(e){} 
                            break;                                            
                        case 12:                                                                                
                            try{    
                                document.getElementById('trCatalogo').style.display = '';
                                document.getElementById('trAsigned').style.display = 'none';
                                document.getElementById('tdIndiceUnico').style.display = 'none';
                                document.getElementById('trLlavePrimaria').style.display = 'none';
                                CampoValor.SetVisible(false);
                                cmbCatalogoValues.SetVisible(true);
                                }
                            catch(e){} 
                            break;                                            
                        }
                        }
                    catch(e){} 
                    try{
                        if (ASPxCheckBox2.GetValue() == 1)
                            document.getElementById('trAsigned_value').style.display = ''; 
                        else
                            document.getElementById('trAsigned_value').style.display = 'none'; 
                        }
                    catch(e){} 
                    try{
                        if (document.getElementById('trCatalogo').style.display == '')
                        {
                            CampoValor.SetVisible(false); 
                            cmbCatalogoValues.SetVisible(true); 
                        }
                        else
                        {
                            CampoValor.SetVisible(true); 
                            cmbCatalogoValues.SetVisible(false); 
                        }    
                    }                                    
                    catch(e){}
                  }" />
            <Columns>
                <dxwgv:GridViewDataTextColumn caption="Indice" fieldname="idIndice_Sistema" visibleindex="0"></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn caption="Area Recomendada" fieldname="Area_Recomendada" visibleindex="1"></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn caption="Elemento Recomendado" fieldname="Elemento_Recomendado" visibleindex="2"></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn caption="Descripción" fieldname="Indice_descripcion" visibleindex="3"></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataComboBoxColumn caption="Tipo de campo" fieldname="Indice_Tipo" visibleindex="4">
                    <PropertiesComboBox valuetype="System.Byte"><Items>
                    <dxe:ListEditItem text="Entero" value="7"></dxe:ListEditItem>
                    <dxe:ListEditItem text="Fecha" value="2"></dxe:ListEditItem>
                    <dxe:ListEditItem text="Periodo de fechas" value="3"></dxe:ListEditItem>
                    <dxe:ListEditItem text="Periodo Mes Año" value="4"></dxe:ListEditItem>
                    <dxe:ListEditItem text="Periodo Años" value="5"></dxe:ListEditItem>
                    <dxe:ListEditItem text="Texto" value="0"></dxe:ListEditItem>
                    <dxe:ListEditItem text="Texto Largo" value="1"></dxe:ListEditItem>
                    <dxe:ListEditItem text="Seleccion Si/No" value="6"></dxe:ListEditItem>
                    <dxe:ListEditItem Text="Catalogo" Value="11" />
                    <dxe:ListEditItem Text="Grid" Value="12" />
                    </Items>
                    </PropertiesComboBox>
                    </dxwgv:GridViewDataComboBoxColumn>
                <dxwgv:GridViewDataTextColumn caption="Longitud" fieldname="Indice_LongitudMax" visibleindex="5"></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn caption="relacion_con_normaPID" fieldname="relacion_con_normaPID" visible="False" visibleindex="3"></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn caption="Mascara" fieldname="Indice_Mascara" visible="False" visibleindex="3"></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataCheckColumn caption="Es llave primaria" fieldname="Indice_PK" visibleindex="4" Visible="false">
                    <propertiescheckedit valuechecked="1" valuetype="System.Byte" valueunchecked="0"></propertiescheckedit>
                </dxwgv:GridViewDataCheckColumn>
                <dxwgv:GridViewDataCheckColumn caption="Obligatorio" fieldname="Indice_Obligatorio" visibleindex="5"></dxwgv:GridViewDataCheckColumn>
                <dxwgv:GridViewDataCheckColumn caption="Indice único" fieldname="Indice_Unico" visibleindex="6">
                    <propertiescheckedit valuechecked="1" valuetype="System.Byte" valueunchecked="0"></propertiescheckedit>
                </dxwgv:GridViewDataCheckColumn>
                <dxwgv:GridViewDataCheckColumn caption="Visible" 
                    fieldname="Indice_Visible" visibleindex="7"></dxwgv:GridViewDataCheckColumn>
                <dxwgv:GridViewCommandColumn visibleindex="8">
                    <newbutton visible="True"></newbutton>
                    <editbutton visible="True"></editbutton>
                    <deletebutton visible="True"></deletebutton>
                </dxwgv:GridViewCommandColumn>
            </Columns>
        </dxwgv:ASPxGridView>         
        <br />
        <div class="clear"></div>
    </div>
 <asp:ObjectDataSource ID="dsIndices_Sistema" runat="server" 
            SelectMethod="ListaIndices_Sistema" TypeName="Portalv9.WSArchivo.Service1" 
            DeleteMethod="ABC_Indices_Sistema" InsertMethod="ABC_Indices_Sistema" 
            UpdateMethod="ABC_Indices_Sistema">
            <SelectParameters>
                <asp:Parameter Name="idIndice_Sistema" DefaultValue="-1" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="op" Type="Object" DefaultValue="1" />
                <asp:Parameter Name="idIndice_Sistema" Type="Int32" />
                <asp:Parameter Name="Area_Recomendada" Type="String" />
                <asp:Parameter Name="Elemento_Recomendado" Type="String" />
                <asp:Parameter Name="Indice_descripcion" Type="String" />
                <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                <asp:Parameter Name="Indice_LongitudMax" Type="Int32" />
                <asp:Parameter Name="Indice_Mascara" Type="String" />
                <asp:Parameter Name="Indice_PK" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="Indice_Obligatorio" Type="Int32" />
                <asp:Parameter Name="Indice_Unico" Type="Int32" />
                <asp:Parameter Name="Indice_buscar" Type="Int32" />
                <asp:Parameter Name="Indice_CopiarValor" Type="Int32" />
                <asp:Parameter Name="Indice_EsAutoincremental" Type="Int32" />
                <asp:Parameter Name="IndiceReadOnly" Type="Int32" />
                <asp:Parameter Name="Indice_Visible" Type="Int32" />
                <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                <asp:Parameter Name="folio_norma" Type="String" />
                <asp:Parameter Name="Indice_ValorInicial" Type="Int32" />
                <asp:Parameter Name="Indice_ValorActual" Type="Int32" />
                <asp:Parameter Name="Indice_ValorMaximo" Type="Int32" />
                <asp:Parameter Name="Muestra_padres" Type="Int32" />
                <asp:Parameter Name="Multi_valor" Type="Int32" />
                <asp:Parameter DefaultValue="" Name="Asigned" Type="Int32" />
                <asp:Parameter Name="Asigned_value" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
                <asp:Parameter Name="idIndice_Sistema" Type="Int32" />
                <asp:Parameter Name="Area_Recomendada" Type="String" />
                <asp:Parameter Name="Elemento_Recomendado" Type="String" />
                <asp:Parameter Name="Indice_descripcion" Type="String" />
                <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                <asp:Parameter Name="Indice_LongitudMax" Type="Int32" />
                <asp:Parameter Name="Indice_Mascara" Type="String" />
                <asp:Parameter Name="Indice_PK" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="Indice_Obligatorio" Type="Int32" />
                <asp:Parameter Name="Indice_Unico" Type="Int32" />
                <asp:Parameter Name="Indice_buscar" Type="Int32" />
                <asp:Parameter Name="Indice_CopiarValor" Type="Int32" />
                <asp:Parameter Name="Indice_EsAutoincremental" Type="Int32" />
                <asp:Parameter Name="IndiceReadOnly" Type="Int32" />
                <asp:Parameter Name="Indice_Visible" Type="Int32" />
                <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                <asp:Parameter Name="folio_norma" Type="String" />
                <asp:Parameter Name="Indice_ValorInicial" Type="Int32" />
                <asp:Parameter Name="Indice_ValorActual" Type="Int32" />
                <asp:Parameter Name="Indice_ValorMaximo" Type="Int32" />
                <asp:Parameter Name="Muestra_padres" Type="Int32" />
                <asp:Parameter Name="Multi_valor" Type="Int32" />
                <asp:Parameter DefaultValue="" Name="Asigned" Type="Int32" />
                <asp:Parameter Name="Asigned_value" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="op" Type="Object" DefaultValue="0" />
                <asp:Parameter Name="idIndice_Sistema" Type="Int32" />
                <asp:Parameter Name="Area_Recomendada" Type="String" />
                <asp:Parameter Name="Elemento_Recomendado" Type="String" />
                <asp:Parameter Name="Indice_descripcion" Type="String" />
                <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                <asp:Parameter Name="Indice_LongitudMax" Type="Int32" />
                <asp:Parameter Name="Indice_Mascara" Type="String" />
                <asp:Parameter Name="Indice_PK" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="Indice_Obligatorio" Type="Int32" />
                <asp:Parameter Name="Indice_Unico" Type="Int32" />
                <asp:Parameter Name="Indice_buscar" Type="Int32" />
                <asp:Parameter Name="Indice_CopiarValor" Type="Int32" />
                <asp:Parameter Name="Indice_EsAutoincremental" Type="Int32" />
                <asp:Parameter Name="IndiceReadOnly" Type="Int32" />
                <asp:Parameter Name="Indice_Visible" Type="Int32" />
                <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                <asp:Parameter Name="folio_norma" Type="String" />
                <asp:Parameter Name="Indice_ValorInicial" Type="Int32" />
                <asp:Parameter Name="Indice_ValorActual" Type="Int32" />
                <asp:Parameter Name="Indice_ValorMaximo" Type="Int32" />
                <asp:Parameter Name="Muestra_padres" Type="Int32" />
                <asp:Parameter Name="Multi_valor" Type="Int32" />
                <asp:Parameter DefaultValue="" Name="Asigned" Type="Int32" />
                <asp:Parameter Name="Asigned_value" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsCatalogos" runat="server" 
            SelectMethod="ListaCatalogo_Datos" TypeName="Portalv9.WSArchivo.Service1" 
            OldValuesParameterFormatString="{0}">
            <SelectParameters><asp:Parameter Name="IDCatalogo" Type="Int32" DefaultValue="-1" /></SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsCatalogoValues" runat="server" 
            SelectMethod="ListaCatalogo_Datos" TypeName="Portalv9.WSArchivo.Service1" 
            OldValuesParameterFormatString="{0}">
            <SelectParameters><asp:Parameter Name="IDCatalogo" Type="Int32"/></SelectParameters>
        </asp:ObjectDataSource>
<cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>    
</asp:Content>
