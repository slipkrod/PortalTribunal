<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="Wfrm_TipoExpediente_Indices.aspx.vb" Inherits="Portalv9.Wfrm_TipoExpediente_Indices" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxMenu" tagprefix="dxm" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
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
            <td style="height: 36px">
                <dxtc:ASPxTabControl ID="ASPxTabControlA" runat="server" AutoPostBack="True">
                </dxtc:ASPxTabControl>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;">
                
            </td>
        </tr>
        <tr>
            <td>
                <dxwgv:ASPxGridView ID="aspxgdElementos" KeyFieldName="idElemento" runat="server" ClientInstanceName="aspxgdElementos"
                     AutoGenerateColumns="False" Width="470px">
                      <Templates>
                          <DetailRow>
                            <dxwgv:ASPxGridView ID="gdSeries" runat="server" 
                                DataSourceID="dsSeries_Indices" AutoGenerateColumns="False" 
                                KeyFieldName="idIndice" Width="600px" ClientInstanceName="gdSeries" 
                                oncustomerrortext="gdSeries_CustomErrorText" 
                                onrowinserting="gdSeries_RowInserting" onrowupdating="gdSeries_RowUpdating" 
                                onbeforeperformdataselect="gdSeries_BeforePerformDataSelect"
                                onhtmleditformcreated="aspxgdElementos_HtmlEditFormCreated" 
                                  onhtmlcommandcellprepared="gdSeries_HtmlCommandCellPrepared" >                                
                                <Templates>
                                    <EditForm>
                                        <table style="border: thin solid #C9D7DD; width: 100%; height: 160px;">
                                            <tr id="trFolio_Norma">
                                                <td class="style1" style="width: 161px">Folio</td>
                                                <td colspan="2">
                                                    <dxe:ASPxTextBox ID="ASPxTextBox1" runat="server" Text='<%# Bind("folio_norma") %>' Width="300px">
                                                    </dxe:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <table>
                                                        <tr id="trIndice_Sistema">
                                                            <td style="width: 161px" class="style1">Tipo de indice</td>
                                                            <td colspan="2">
                                                                <dxe:ASPxLabel ID="lblIndice_Sistema" runat="server" Text="De Usuario" Height="21px"></dxe:ASPxLabel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trDeUsuario">
                                                <td colspan="3">
                                                    <table>
                                                        <tr id="trIndice_descripcion">
                                                            <td class="style1" style="width: 161px">Nombre del campo</td>
                                                            <td colspan="2">
                                                                <dxe:ASPxTextBox ID="CampoNombre" runat="server" 
                                                                    Text='<%# Bind("Indice_descripcion") %>' Width="300px">
                                                                </dxe:ASPxTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="trIndice_Tipo">
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
                                                        <tr id="trAsigned">
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
                                                            <td style="width: 74px">Mascara</td>
                                                            <td colspan="2">
                                                                <dxe:ASPxTextBox ID="Mascara" runat="server" Width="300px" 
                                                                    Text="<%# Bind('Indice_Mascara') %>">
                                                                </dxe:ASPxTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="trObligatorio">
                                                            <td style="width: 74px">Obligatorio</td>
                                                            <td colspan="2">
                                                                <dxe:ASPxCheckBox ID="Obligatorio" runat="server" 
                                                                    Value="<%# Bind('Indice_Obligatorio') %>">
                                                                </dxe:ASPxCheckBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="trLlavePrimaria">
                                                            <td style="width: 161px" class="style1">Llave primaria</td>
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
                                                        <tr id="trIndice_Visible">
                                                            <td style="width: 161px" class="style1">Visible&nbsp;</td>
                                                            <td colspan="2">
                                                                <dxe:ASPxCheckBox ID="vVisible" runat="server" 
                                                                    Value='<%# Bind("Indice_Visible") %>'>
                                                                </dxe:ASPxCheckBox>
                                                            </td>
                                                        </tr>   
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trDeSistema" style="display:none;">
                                                <td colspan="3">
                                                    <dxcp:ASPxCallbackPanel runat="server" ID="cbpEC" ClientInstanceName="cbpEC" OnCallback="cbpEC_Callback">
                                                    <PanelCollection><dxp:PanelContent ID="PanelContent3" runat="server">
                                                    <table >
                                                        <tr id="tridIndice_Sistema">
                                                            <td style="width: 161px" class="style1">
                                                                <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Indice de Sistema" Height="21px"></dxe:ASPxLabel><br>
                                                                <asp:Literal ID="lblIndiceSistema" runat="server"></asp:Literal>
                                                            </td>
                                                            <td colspan="2">
                                                                <dxe:ASPxComboBox ID="idIndice_Sistema" runat="server" SelectedIndex="-1" ClientInstanceName="cmbidIndice_Sistema" 
                                                                    Width="200px" DataSourceID="dsIndices_Sistema" DropDownStyle="DropDown" Enabled="false" 
                                                                    TextField="Indice_Descripcion" ValueField="idIndice_Sistema" Value='<%# Bind("idIndice_Sistema") %>'
                                                                    ValueType="System.Int32" Height="21px">
                                                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                                       window.setTimeout(&quot;MyCallBack()&quot;, 100);
                                                                      }" />
                                                                    <Columns>
                                                                        <dxe:ListBoxColumn FieldName="Indice_Descripcion" Caption="Descripcion" />
                                                                        <dxe:ListBoxColumn FieldName="idIndice_Sistema" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="Indice_Tipo" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="relacion_con_normaPID" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="Indice_PK" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="Indice_Unico" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="Asigned" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="Asigned_value" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="Indice_LongitudMax" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="Indice_Mascara" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="Indice_Obligatorio" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="Indice_Visible" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="Area_Recomendada" Visible="False" />
                                                                        <dxe:ListBoxColumn FieldName="Elemento_Recomendado" Visible="False" />
                                                                    </Columns>
                                                                </dxe:ASPxComboBox>
                                                                <asp:Literal ID="txtIndiceSistema" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>   
                                                    </table>
                                                    </dxp:PanelContent></PanelCollection>
                                                   </dxcp:ASPxCallbackPanel>
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
                                    ConfirmDelete="¿Seguro que desea eliminar este registro?" 
                                    EmptyDataRow="No existen datos" />
                                    <ClientSideEvents EndCallback="function(s, e) { 
                                        try{
                                          if (cmbIndice_Sistema.GetValue() == false) {
                                              document.getElementById('trDeUsuario').style.display = '';
                                              document.getElementById('trDeSistema').style.display = 'none';
                                              }
                                          else {
                                              document.getElementById('trDeUsuario').style.display = 'none';
                                              document.getElementById('trDeSistema').style.display = '';
                                        }}
                                        catch(e){} 
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
                                    <dxwgv:GridViewDataTextColumn caption="idNorma" fieldname="idNorma" visible="False" visibleindex="0"></dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn caption="idArea" fieldname="idArea" visible="False" visibleindex="0"></dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn caption="idIndice" fieldname="idIndice" visible="False" visibleindex="0"></dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn caption="idNivel" fieldname="idNivel" visible="False" visibleindex="0"></dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn caption="idSerie" fieldname="idSerie" visible="False" visibleindex="0"></dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn caption="id" fieldname="idElemento" visibleindex="0"></dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn caption="Folio" fieldname="folio_norma" visibleindex="0"></dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataComboBoxColumn caption="Tipo de Indice" fieldname="Indice_Sistema" visibleindex="1">
                                        <PropertiesComboBox valuetype="System.Boolean" >
                                            <Items>
                                                <dxe:ListEditItem text="De Usuario" value="false"></dxe:ListEditItem>
                                                <dxe:ListEditItem text="De Sistema" value="true"></dxe:ListEditItem>
                                            </Items>
                                        </PropertiesComboBox>
                                    </dxwgv:GridViewDataComboBoxColumn>
                                    <dxwgv:GridViewDataTextColumn caption="Nombre del campo" fieldname="Indice_descripcion" visibleindex="2"></dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataComboBoxColumn caption="Tipo de Campo" fieldname="Indice_Tipo" visibleindex="3">
                                        <PropertiesComboBox valuetype="System.Byte" >
                                            <Items>
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
                                    <dxwgv:GridViewDataTextColumn caption="Longitud" fieldname="Indice_LongitudMax" visibleindex="4"></dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataCheckColumn caption="Llave primaria" fieldname="Indice_PK" visibleindex="5">
                                        <propertiescheckedit valuechecked="1" valuetype="System.Byte" valueunchecked="0"></propertiescheckedit>
                                    </dxwgv:GridViewDataCheckColumn>
                                    <dxwgv:GridViewDataCheckColumn caption="Obligatorio" fieldname="Indice_Obligatorio" visibleindex="6"></dxwgv:GridViewDataCheckColumn>
                                    <dxwgv:GridViewDataCheckColumn caption="Indice único" fieldname="Indice_Unico" visibleindex="7">
                                        <propertiescheckedit valuechecked="1" valuetype="System.Byte" valueunchecked="0"></propertiescheckedit>
                                    </dxwgv:GridViewDataCheckColumn>
                                    <dxwgv:GridViewDataCheckColumn caption="Visible" fieldname="Indice_Visible" visibleindex="8"></dxwgv:GridViewDataCheckColumn>
                                    <dxwgv:GridViewCommandColumn Visibleindex="9" Caption="Comandos">
                                        <newbutton visible="True"></newbutton>
                                        <EditButton visible="True"></EditButton>
                                        <deletebutton visible="True"></deletebutton>
                                    </dxwgv:GridViewCommandColumn>                                    
                                    <dxwgv:GridViewDataTextColumn caption="relacion_con_normaPID" fieldname="relacion_con_normaPID" visible="False"></dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn caption="Mascara" fieldname="Indice_Mascara" visible="False" ></dxwgv:GridViewDataTextColumn>                                            
                                </Columns>
                                <SettingsDetail IsDetailGrid="True" />
                            </dxwgv:ASPxGridView>
                            </DetailRow>
                      </Templates>
                      <Styles>
                          <Cell BackColor="#99CCFF">
                          </Cell>
                      </Styles>
                      <SettingsPager Visible="False">
                      </SettingsPager>
                      <Columns>
                          <dxwgv:GridViewDataTextColumn Caption="IDNorma" FieldName="idNorma" ReadOnly="True" Visible="false" VisibleIndex="0">
                          </dxwgv:GridViewDataTextColumn>
                          <dxwgv:GridViewDataTextColumn Caption="idElemento" FieldName="idElemento" ReadOnly="True" Visible="false" VisibleIndex="0">
                          </dxwgv:GridViewDataTextColumn>
                          <dxwgv:GridViewDataTextColumn Caption="Folio" FieldName="folio_norma" VisibleIndex="1" Width="30px">
                          </dxwgv:GridViewDataTextColumn>
                          <dxwgv:GridViewDataTextColumn Caption="Nombre" FieldName="Elemento_descripcion" ReadOnly="false" VisibleIndex="2">
                          </dxwgv:GridViewDataTextColumn>
                          <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="idArea" ReadOnly="false" Visible="False" VisibleIndex="5">
                          </dxwgv:GridViewDataTextColumn>
                      </Columns>
                      <Settings GridLines="Horizontal" ShowColumnHeaders="False" />
                      <SettingsDetail AllowOnlyOneMasterRowExpanded="False" ShowDetailRow="True" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:msgbox ID="dlgBoxExcepciones" runat="server" />
                <asp:ObjectDataSource ID="dsSeries_Indices" runat="server" 
                    SelectMethod="ListaNormas_Elementos_CamposxSeriexElemento" TypeName="Portalv9.WSArchivo.Service1" 
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
                        <asp:Parameter Name="Multi_valor" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="Asigned" Type="Int32" />
                        <asp:Parameter Name="Asigned_value" Type="String" />
                        <asp:Parameter Name="Indice_Sistema" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="idIndice_Sistema" Type="Int32" />
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
                        <asp:Parameter DefaultValue="" Name="Asigned" Type="Int32" />
                        <asp:Parameter Name="Asigned_value" Type="String" />
                        <asp:Parameter Name="Indice_Sistema" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="idIndice_Sistema" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" Type="Int32" />
                        <asp:SessionParameter Name="idElemento" SessionField="idElemento" Type="Int32" />
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
                        <asp:Parameter Name="Multi_valor" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="Asigned" Type="Int32" />
                        <asp:Parameter Name="Asigned_value" Type="String" />
                        <asp:Parameter Name="Indice_Sistema" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="idIndice_Sistema" Type="Int32" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsCatalogo" runat="server" 
                    SelectMethod="ListaCatalogo" TypeName="Portalv9.WSArchivo.Service1">
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
                <asp:ObjectDataSource ID="dsIndices_Sistema" runat="server" 
                    SelectMethod="ListaIndices_Sistema" TypeName="Portalv9.WSArchivo.Service1" >
                    <SelectParameters>
                        <asp:Parameter Name="idIndice_Sistema" DefaultValue="-1" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
