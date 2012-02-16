<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmasteranidada.master" CodeBehind="wfrm_PlantillaArchivo.aspx.vb" Inherits="Portalv9.wfrm_PlantillaArchivo" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table style="width:480px; padding-left:250px; height: 51px;">
        <tr>
            <td>
    	        <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" NavigateUrl="~/Wfrm_Archivo_Elementos.aspx" />
			    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="385px" Height="16px" Font-Names="Arial"
					Font-Bold="True" Font-Italic="True">Configuración de campos para el archivo</asp:label>
            </td>
        </tr>
        <tr>
            <td>
                <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" Text="" ForeColor="Red"></dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td>
                <dxwgv:aspxgridview ID="aspxgdareas" KeyFieldName="idElemento" runat="server" ClientInstanceName="aspxgdareas"
                     OnRowInserting="aspxgdareas_RowInserting" 
                     OnRowCommand="aspxgdareas_RowCommand" 
                     OnPageIndexChanged="aspxgdareas_PageIndexChanged" AutoGenerateColumns="False" 
                     DataSourceID="dsCat_Archivo_elementos" 
                     OnCustomJSProperties="aspxgdareas_CustomJSProperties" Width="470px">
                      <Templates>
                          <DetailRow>                                                                       
                              <dxwgv:ASPxGridView ID="aspxgdelementos" runat="server" 
                                  AutoGenerateColumns="False" ClientInstanceName="aspxgdelementos" 
                                  DataSourceID="dsElementos" KeyFieldName="idIndice" 
                                  onbeforeperformdataselect="aspxgdelementos_BeforePerformDataSelect" 
                                  onrowinserting="aspxgdelementos_RowInserting" 
                                  onrowdeleted="aspxgdelementos_RowDeleted">                                  
                                  <Templates>
                                      <EditForm>
                                          <table style="border: thin solid #C9D7DD; width: 100%;">
                                            <tr>
                                                <td style="width: 74px">&nbsp;</td>
                                                <td colspan="2">
                                                    <dxe:ASPxLabel ID="lblElemento" runat="server" Font-Bold="True" Font-Size="10pt">
                                                    </dxe:ASPxLabel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 74px">Nombre</td>
                                                <td colspan="2">
                                                    <dxe:ASPxTextBox ID="CampoNombre" runat="server" 
                                                        Text="<%# Bind('Indice_descripcion') %>" Width="300px">
                                                    </dxe:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 74px">Tipo</td>
                                                <td colspan="2">
                                                    <dxe:ASPxComboBox ID="Tipo" runat="server" ClientInstanceName="cboTipo" 
                                                        ValueType="System.Byte" Width="185px" 
                                                        Value="<%# Bind('Indice_Tipo') %>" >
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
                                                        <ClientSideEvents ValueChanged="function(s, e) {
	                                                    if (s.GetValue() == 0)
		                                                   {
		                                                        document.getElementById('trLongitud').style.display = ''; 
		                                                        document.getElementById('trMascara').style.display = ''; 
		                                                   }
                                                        else
                                                            {
		                                                        document.getElementById('trLongitud').style.display = 'none'; 
		                                                        document.getElementById('trMascara').style.display = 'none'; 
		                                                    }
		                                                if (s.GetValue() == 7 || s.GetValue() == 4 || s.GetValue() == 5 || s.GetValue() == 6)
		                                                   {
		                                                        document.getElementById('trObligatorio').style.display = 'none'; 
		                                                   }
                                                        else
                                                            {
		                                                        document.getElementById('trObligatorio').style.display = ''; 
		                                                    }
                                                        }" />
                                                    </dxe:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr id="trLongitud">
                                                <td style="width: 74px">Longitud</td>
                                                <td colspan="2">
                                                    <dxe:ASPxSpinEdit ID="Longitud" runat="server" AllowNull="False"
                                                        Number="<%# Bind('Indice_LongitudMax') %>" Width="70px" 
                                                        ClientInstanceName="Longitud">
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
                                            <tr>
                                                <td style="width: 74px">Visible</td>
                                                <td colspan="2">
                                                    <dxe:ASPxCheckBox ID="vVisible" runat="server" Checked="True" 
                                                        Value="<%# Bind('Indice_Visible') %>">
                                                    </dxe:ASPxCheckBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                                        <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                                      </EditForm>
                                  </Templates>
                                  <SettingsBehavior ConfirmDelete="True" />
                                  <SettingsPager PageSize="15">
                                  </SettingsPager>
                                  <SettingsEditing Mode="EditForm" />
                                  <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar este campo ?" />
                                  <ClientSideEvents EndCallback="function(s, e) { 
                                  label.SetText(aspxgdelementos.cpdeletedflag);
                                  try{
                                      if (cboTipo.GetValue() == 0)
	                                    {
		                                    document.getElementById('trLongitud').style.display = ''; 
		                                    document.getElementById('trMascara').style.display = ''; 
		                                }
                                    else
                                        {
		                                    document.getElementById('trLongitud').style.display = 'none'; 
		                                    document.getElementById('trMascara').style.display = 'none'; 
		                                }
		                            }
	                                catch(e){} 
	                                try{
		                            if (cboTipo.GetValue() == 7 || cboTipo.GetValue() == 4 || cboTipo.GetValue() == 5 || cboTipo.GetValue() == 6)
                                       {
                                            document.getElementById('trObligatorio').style.display = 'none'; 
                                       }
                                    else
                                        {
                                            document.getElementById('trObligatorio').style.display = ''; 
                                        }
		                            }
	                                catch(e){} 
                                  }" />
                                  <Columns>
                                      <dxwgv:GridViewDataTextColumn Caption="Elemento" FieldName="idElemento" 
                                          ReadOnly="True" Visible="true" VisibleIndex="0">
                                      </dxwgv:GridViewDataTextColumn>
                                      <dxwgv:GridViewDataTextColumn Caption="Indice" FieldName="idIndice" 
                                          VisibleIndex="1">
                                      </dxwgv:GridViewDataTextColumn>
                                      <dxwgv:GridViewDataTextColumn Caption="Campo" FieldName="Indice_descripcion" 
                                          ReadOnly="false" VisibleIndex="2">
                                          <PropertiesTextEdit>
                                              <ValidationSettings ErrorDisplayMode="ImageWithText">
                                                  <RequiredField ErrorText="* El Campo es requerido" IsRequired="True" />
                                              </ValidationSettings>
                                          </PropertiesTextEdit>
                                      </dxwgv:GridViewDataTextColumn>
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_Tipo" FieldName="Indice_Tipo" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_LongitudMax" FieldName="Indice_LongitudMax" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_Mascara" FieldName="Indice_Mascara" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_Obligatorio" FieldName="Indice_Obligatorio" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_Unico" FieldName="Indice_Unico" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_buscar" FieldName="Indice_buscar" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_CopiarValor" FieldName="Indice_CopiarValor" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_EsAutoincremental" FieldName="Indice_EsAutoincremental" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="IndiceReadOnly" FieldName="IndiceReadOnly" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_Visible" FieldName="Indice_Visible" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="relacion_con_normaPID" FieldName="relacion_con_normaPID" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_ValorInicial" FieldName="Indice_ValorInicial" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_ValorActual" FieldName="Indice_ValorActual" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="Indice_ValorMaximo" FieldName="Indice_ValorMaximo" Visible="false" />
                                      <dxwgv:GridViewDataTextColumn Caption="folio_norma" FieldName="folio_norma" Visible="false" />
                                      <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="3">
                                          <NewButton Text="Agregar elemento" Visible="true">
                                          </NewButton>
                                      </dxwgv:GridViewCommandColumn>
                                      <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="4">
                                          <EditButton Text="Editar" Visible="True"></EditButton>
                                          <CancelButton Text="Cancelar" Visible="True"></CancelButton>
                                          <UpdateButton Text="Actualizar" Visible="True"></UpdateButton>
                                      </dxwgv:GridViewCommandColumn>
                                      <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex="5">
                                          <DeleteButton Text="Eliminar" Visible="true"></DeleteButton>
                                      </dxwgv:GridViewCommandColumn>
                                  </Columns>
                                  <SettingsDetail AllowOnlyOneMasterRowExpanded="True" IsDetailGrid="True" />
                              </dxwgv:ASPxGridView>
                          </DetailRow>
                      </Templates>
                      <SettingsBehavior ConfirmDelete="True" />
                      <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar ésta área, si contiene campos tambien seran eliminados ?" />
                      <ClientSideEvents EndCallback="function(s, e) {label.SetText(aspxgdareas.cpdeletedflag);}" />
                      <Columns>
                          <dxwgv:GridViewDataTextColumn Caption="idElemento" FieldName="idElemento" 
                              ReadOnly="True" Visible="false" VisibleIndex="0">
                          </dxwgv:GridViewDataTextColumn>
                          <dxwgv:GridViewDataTextColumn Caption="Elemento" FieldName="Elemento_descripcion" 
                              ReadOnly="false" VisibleIndex="1">
                          </dxwgv:GridViewDataTextColumn>
                          <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="3" Width="20px">
                              <NewButton Text="Agregar Elemento" Visible="true">
                              </NewButton>
                          </dxwgv:GridViewCommandColumn>
                          <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="4" Width="20px">
                              <EditButton Text="Editar" Visible="True">
                              </EditButton>
                              <CancelButton Text="Cancelar" Visible="True">
                              </CancelButton>
                              <UpdateButton Text="Actualizar" Visible="True">
                              </UpdateButton>
                          </dxwgv:GridViewCommandColumn>
                          <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex="5" Width="20px">
                              <DeleteButton Text="Eliminar" Visible="true">
                              </DeleteButton>
                          </dxwgv:GridViewCommandColumn>
                      </Columns>
                      <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                </dxwgv:aspxgridview>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
    </table>
    <br />
        <asp:ObjectDataSource ID="dsCat_Archivo_elementos" runat="server" 
            SelectMethod="ListaArchivo_Cat_Elementos" TypeName="Portalv9.WSArchivo.Service1"
            UpdateMethod="ABC_Archivo_Cat_Elementos" 
            DeleteMethod="ABC_Archivo_Cat_Elementos" 
            InsertMethod="ABC_Archivo_Cat_Elementos">
            <DeleteParameters>
                <asp:Parameter Name="op" Type="Object" defaultvalue="1" />
                <asp:Parameter Name="idElemento" Type="Int32" />
                <asp:Parameter Name="Elemento_descripcion" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="op" Type="Object" defaultvalue="2"/>
                <asp:Parameter Name="idElemento" Type="Int32" />
                <asp:Parameter Name="Elemento_descripcion" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="op" Type="Object" defaultvalue="0"/>
                <asp:Parameter Name="idElemento" Type="Int32" />
                <asp:Parameter Name="Elemento_descripcion" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsElementos" runat="server" 
             SelectMethod="ListaArchivo_Cat_Campos" 
             TypeName="Portalv9.WSArchivo.Service1" DeleteMethod="ABC_Archivo_Elementos_Campos" 
             InsertMethod="ABC_Archivo_Elementos_Campos" 
             UpdateMethod="ABC_Archivo_Elementos_Campos">
             <DeleteParameters>
                 <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
                 <asp:SessionParameter Name="idElemento" SessionField="idElemento" Type="Int32" />
                 <asp:Parameter Name="idIndice" Type="Int32" DefaultValue="" />
                 <asp:Parameter Name="Indice_descripcion" Type="String" />
                 <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                 <asp:Parameter Name="Indice_LongitudMax" Type="Int32" />
                 <asp:Parameter Name="Indice_Mascara" Type="String" />
                 <asp:Parameter Name="Indice_Obligatorio" Type="Int32" />
                 <asp:Parameter Name="Indice_Unico" Type="Int32" />
                 <asp:Parameter Name="Indice_buscar" Type="Int32" />
                 <asp:Parameter Name="Indice_CopiarValor" Type="Int32" />
                 <asp:Parameter Name="Indice_EsAutoincremental" Type="Int32" />
                 <asp:Parameter Name="IndiceReadOnly" Type="Int32" />
                 <asp:Parameter Name="Indice_Visible" Type="Int32" />
                 <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                 <asp:Parameter Name="Indice_Sistema" Type="Int32" />
                 <asp:Parameter Name="idIndice_Sistema" Type="Int32" />
             </DeleteParameters>
             <UpdateParameters>
                 <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
                 <asp:Parameter Name="idElemento" Type="Int32" DefaultValue="" />
                 <asp:Parameter Name="idIndice" Type="Int32" />
                 <asp:Parameter Name="Indice_descripcion" Type="String" />
                 <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                 <asp:Parameter Name="Indice_LongitudMax" Type="Int32" />
                 <asp:Parameter Name="Indice_Mascara" Type="String" />
                 <asp:Parameter Name="Indice_Obligatorio" Type="Int32" />
                 <asp:Parameter Name="Indice_Unico" Type="Int32" />
                 <asp:Parameter Name="Indice_buscar" Type="Int32" />
                 <asp:Parameter Name="Indice_CopiarValor" Type="Int32" />
                 <asp:Parameter Name="Indice_EsAutoincremental" Type="Int32" />
                 <asp:Parameter Name="IndiceReadOnly" Type="Int32" />
                 <asp:Parameter Name="Indice_Visible" Type="Int32" />
                 <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                 <asp:Parameter Name="Indice_Sistema" Type="Int32" />
                 <asp:Parameter Name="idIndice_Sistema" Type="Int32" />
             </UpdateParameters>
             <SelectParameters>
                 <asp:SessionParameter Name="idElemento" SessionField="idElemento" Type="Int32" />
             </SelectParameters>
             <InsertParameters>
                 <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                 <asp:Parameter Name="idElemento" Type="Int32" DefaultValue="" />
                 <asp:Parameter Name="idIndice" Type="Int32" />
                 <asp:Parameter Name="Indice_descripcion" Type="String" />
                 <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                 <asp:Parameter Name="Indice_LongitudMax" Type="Int32" />
                 <asp:Parameter Name="Indice_Mascara" Type="String" />
                 <asp:Parameter Name="Indice_Obligatorio" Type="Int32" />
                 <asp:Parameter Name="Indice_Unico" Type="Int32" />
                 <asp:Parameter Name="Indice_buscar" Type="Int32" />
                 <asp:Parameter Name="Indice_CopiarValor" Type="Int32" />
                 <asp:Parameter Name="Indice_EsAutoincremental" Type="Int32" />
                 <asp:Parameter Name="IndiceReadOnly" Type="Int32" />
                 <asp:Parameter Name="Indice_Visible" Type="Int32" />
                 <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                 <asp:Parameter Name="Indice_Sistema" Type="Int32" />
                 <asp:Parameter Name="idIndice_Sistema" Type="Int32" />
             </InsertParameters>
        </asp:ObjectDataSource>
        
        <dxe:ASPxLabel ID="ASPxLabel1" runat="server" ClientInstanceName="label" Text="" ForeColor="Red"></dxe:ASPxLabel>
        <asp:Label ID="lblidIndice" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblDataListID" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblEstado" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblElementoID" runat="server" Visible="False"></asp:Label>
</asp:Content>
