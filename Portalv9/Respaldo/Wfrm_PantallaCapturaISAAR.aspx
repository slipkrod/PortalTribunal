    <%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmasteranidada.master" CodeBehind="Wfrm_PantallaCapturaISAAR.aspx.vb" Inherits="Portalv9.Wfrm_PantallaCapturaISAAR" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server" >
    <div>
        	    <asp:label id="lblTitle" runat="server" Font-Size="Small" 
                Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
    </div>
    
     <div>
         <dxe:ASPxButton ID="btnNuevo" runat="server" Text="Agregar">
         </dxe:ASPxButton>
    </div>

    <div >
     
                <table>
                    <tr>
                        <td valign="top" style="width:334px">
                        
                            <dxwgv:ASPxGridView ID="gdnivel" ClientInstanceName="gd" runat="server" AutoGenerateColumns="False" 
                                EnableCallbacks="False" KeyFieldName="idISAAR" 
                                DataSourceID="ListaISAAR" >
                            <SettingsBehavior AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="true"  />
                            <SettingsBehavior ConfirmDelete="true" />
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                             <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar éste registro ?" />
                            <Columns>
                                 <dxwgv:GridViewDataTextColumn  Caption="idISAAR" FieldName="idISAAR" 
                                    ReadOnly="True" Visible="False">
                                 </dxwgv:GridViewDataTextColumn>
                                 <dxwgv:GridViewDataTextColumn  Caption="Nombre" FieldName="Formas_autorizadas_nombre" 
                                    ReadOnly="True" Visible="true" VisibleIndex="1">
                                    <EditFormSettings Visible="False" />
                                 </dxwgv:GridViewDataTextColumn>
                               
                                 <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="3">
                                    <EditButton Visible="True" Text="Editar">
                                    
                                    </EditButton>
                                 
                             </dxwgv:GridViewCommandColumn>
                 <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex="4"> <DeleteButton Text="Eliminar" Visible="true"></DeleteButton></dxwgv:GridViewCommandColumn>
                                 
                            </Columns>
                            <Templates>
                          <EditForm>
                              <dxwgv:ASPxGridViewTemplateReplacement ReplacementType="EditFormEditors" ID="editors" runat="server">
                              </dxwgv:ASPxGridViewTemplateReplacement>
                          </EditForm>
                        </Templates>
                            </dxwgv:ASPxGridView>
                              
                        </td>
                        
                        <td valign="top">
                             <dxtc:ASPxPageControl ID="pgareas" runat="server" ActiveTabIndex="0" 
                                 Visible="False">
                                 <TabPages>
                                     <dxtc:TabPage Text="1 Identificación"   >
                                         <ContentCollection >
                                             <dxw:ContentControl runat="server" >
                                                 <table style="width: 100%" >
                                                     <tr>
                                                         <td colspan="2">
                                                             1.1 Tipo de entidad</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lbltipo" runat="server" Text="Tipo:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxComboBox ID="txt11" runat="server" SelectedIndex="0" 
                                                                 AutoPostBack="false" >
                                                                 <Items>
                                                                   <dxe:ListEditItem Text="Institución" Value="0"  />
                                                                   <dxe:ListEditItem Text="Familia" Value="1" />
                                                                   <dxe:ListEditItem Text="Persona" Value="2" />
                                                                  </Items>
                                                              <ValidationSettings ErrorDisplayMode="Text" ValidationGroup="requeridos" SetFocusOnError="True">
                                                                <RequiredField IsRequired="True" ErrorText="Debe ser capturado"></RequiredField>
                                                              </ValidationSettings> 
                                                             </dxe:ASPxComboBox>
                                                             
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             1.2 Formas autorizadas del nombre</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lblnombre1" runat="server" Text="Nombre:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxTextBox ID="txt12" runat="server" Width="170px">
                                                               <ValidationSettings ErrorDisplayMode="Text" ValidationGroup="requeridos" SetFocusOnError="True">
                                                                <RequiredField IsRequired="True" ErrorText="Debe ser capturado"></RequiredField>
                                                            </ValidationSettings>
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             1.3 Formas paralelas del nombre</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lblnombre2" runat="server" Text="Nombre:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxTextBox ID="txt13" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             1.4 Formas normalizadas del nombre</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lblnombre3" runat="server" Text="Nombre:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxTextBox ID="txt14" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             1.5 Otras formas del nombre</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lblnombre4" runat="server" Text="Nombre:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxTextBox ID="txt15" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             1.6 Identificadores para instituciones</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lblnombre5" runat="server" 
                                                                 Text="Identificadores para entidades colectivas:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxTextBox ID="txt16" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             &nbsp;</td>
                                                         <td>
                                                             &nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             &nbsp;</td>
                                                         <td>
                                                             &nbsp;</td>
                                                     </tr>
                                                 </table>
                                             </dxw:ContentControl>
                                         </ContentCollection>
                                     </dxtc:TabPage>
                                     <dxtc:TabPage Text="2 Descripción">
                                         <ContentCollection>
                                             <dxw:ContentControl runat="server" >
                                                 <table style="width: 100%">
                                                     <tr>
                                                         <td colspan="2">
                                                             2.1 Fechas de existencia</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lblfechaexistencia" runat="server" 
                                                                 Text="Fechas de existencia:">
                                                                 
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxDateEdit ID="txt21" runat="server" Height="16px" Width="80px">
                                                                     <ValidationSettings ErrorDisplayMode="Text" ValidationGroup="requeridos" SetFocusOnError="true">
                                                                     <RequiredField IsRequired="true" ErrorText="Debe ser capturada" />
                                                                     </ValidationSettings>
                                                             </dxe:ASPxDateEdit>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             2.2 Historia</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lblhistoria" runat="server" Text="Historia:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             &nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxMemo ID="txt22" runat="server" Height="109px" Width="350px">
                                                             </dxe:ASPxMemo>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             2.3 Lugares</td>
                                                     </tr>
                                                     <tr>
                                                          <td>
                                                             <dxe:ASPxLabel ID="lbllugar" runat="server" 
                                                                 Text="Lugares :">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxTextBox ID="txt23" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             2.4 Estatuto jurídico</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lbllugar0" runat="server" Text="Estatuto jurídico :">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxTextBox ID="txt24" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             2.5 Funciones, ocupaciones y actividades</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxLabel ID="lblfoa" runat="server" 
                                                                 Text="Funciones, ocupaciones y actividades:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxTextBox ID="txt25" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             2.6 Atribuciones/Fuentes legales</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxLabel ID="lblafl" runat="server" Text="Atribuciones/Fuentes legales:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxTextBox ID="txt26" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             2.7 Estructuras internas/Genealogía</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxLabel ID="lbleig" runat="server" 
                                                                 Text="Estructura(s) interna(s)/ Genealogía :">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxTextBox ID="txt27" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             2.8 Contexto general</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxLabel ID="lblcg" runat="server" Text="Contexto general:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxTextBox ID="txt28" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                    
                                                 </table>
                                             </dxw:ContentControl>
                                         </ContentCollection>
                                     </dxtc:TabPage>
                                     <dxtc:TabPage Text="3 Relaciones">
                                         <ContentCollection>
                                             <dxw:ContentControl runat="server" >
                                                    <dxwgv:ASPxGridView ID="aspxgdisaarrelacion" runat="server"  ClientInstanceName="aspxgdisaarrelacion"
                                                                    KeyFieldName="idRelacion"  AutoGenerateColumns="False" 
                                                                    DataSourceID="Relaciones" Enabled="true" >
                                                                              <ClientSideEvents EndCallback="function(s, e) {
                                                                               Error.SetText(aspxgdisaarrelacion.cpmensaje);
                                                                                }" />
                                                                        <SettingsBehavior ConfirmDelete="true" />
                                                                      <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar éste elemento ?" />
                                                                      
                                                                  <Columns>
                                                                          <dxwgv:GridViewDataTextColumn  Caption="idISAAR" Visible="false"  FieldName="idISAAR" ReadOnly="True" VisibleIndex="0">
                                                                          </dxwgv:GridViewDataTextColumn>
                                                                          <dxwgv:GridViewDataTextColumn  Caption="idRelacion"  Visible="false" FieldName="idRelacion" ReadOnly="True" VisibleIndex="0">
                                                                          </dxwgv:GridViewDataTextColumn>
                                                                          <dxwgv:GridViewDataComboBoxColumn Caption="Nombres de Identificadores" 
                                                                              FieldName="idISAAR_REL" VisibleIndex="0">
                                                                              <PropertiesComboBox DataSourceID="ListaISAAR" 
                                                                                  EnableIncrementalFiltering="True" TextField="Formas_autorizadas_nombre" 
                                                                                  ValueField="idISAAR" ValueType="System.String">
                                                                              </PropertiesComboBox>
                                                                          </dxwgv:GridViewDataComboBoxColumn>
                                                                          <dxwgv:GridViewDataComboBoxColumn Caption="Naturaleza de la relación" 
                                                                              FieldName="IDCatalogo_item" VisibleIndex="1">
                                                                              <PropertiesComboBox DataSourceID="ListaCatalogoNaturaleza" 
                                                                                  EnableIncrementalFiltering="True" TextField="Descripcion" 
                                                                                  ValueField="IDCatalogo_item" ValueType="System.Int32">
                                                                              </PropertiesComboBox>
                                                                          </dxwgv:GridViewDataComboBoxColumn>
                                                                          <dxwgv:GridViewDataTextColumn Caption="Descripción de la relación" FieldName="Descripción_relación" ReadOnly="false" VisibleIndex="3">
                                                                          </dxwgv:GridViewDataTextColumn>
                                                                          <dxwgv:GridViewDataDateColumn Caption="Fechas de la relación" FieldName="Fechas_relación" ReadOnly="false" VisibleIndex="4" >
                                                                          
                                                                          </dxwgv:GridViewDataDateColumn>
                                                                         <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="5"  >
                                                                               <NewButton Visible="true" Text="Agregar relación" >
                                                                               </NewButton>
                                                                                    
                                                                          </dxwgv:GridViewCommandColumn>
                                                                          <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="6">
                                                                                    
                                                                                    <EditButton Visible="True" Text="Editar">
                                                                                    </EditButton>
                                                                                    <CancelButton Visible="True" Text="Cancelar">
                                                                                    </CancelButton>
                                                                                    <UpdateButton Visible="True" Text="Actualizar">
                                                                                    </UpdateButton>
                                                                             </dxwgv:GridViewCommandColumn>
                                                                         <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex=7> <DeleteButton Text="Eliminar" Visible="true"></DeleteButton></dxwgv:GridViewCommandColumn>
                                                                       
                                                                      
                                                                           
                                                                   </Columns>
                                                    </dxwgv:ASPxGridView>
                                             </dxw:ContentControl>
                                         </ContentCollection>
                                     </dxtc:TabPage>
                                     <dxtc:TabPage Text="4 Control" >
                                        <ContentCollection>
                                             <dxw:ContentControl runat="server"  >
                                                 <table style="width: 100%">
                                                     <tr>
                                                         <td colspan="2">
                                                             4.1 Identificador del registro de autoridad</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lblira" runat="server" 
                                                                 Text="Identificador del registro de autoridad:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxTextBox ID="txt41" runat="server" Width="170px">
                                                                   <ValidationSettings ErrorDisplayMode="Text" ValidationGroup="requeridos" CausesValidation="true" SetFocusOnError="true">
                                                                     <RequiredField IsRequired="true" ErrorText="Debe ser capturado" />
                                                                     </ValidationSettings>
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             4.2 Identificadores de la institución</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lblii" runat="server" 
                                                                 Text="Identificadores de la institución:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxTextBox ID="txt42" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             4.3 Reglas y/o convenciones</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxLabel ID="lblryo" runat="server" Text="Reglas y/o convenciones:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxMemo ID="txt43" runat="server" Height="109px" Width="350px">
                                                             </dxe:ASPxMemo>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             4.4 Estado de elaboración</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxLabel ID="lblee" runat="server" Text="Estado de elaboración :">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxTextBox ID="txt44" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             4.5 Nivel de detalle</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxLabel ID="lblnd" runat="server" Text="Nivel de detalle:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxMemo ID="txt45" runat="server" Height="109px" Width="350px">
                                                             </dxe:ASPxMemo>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             4.6 Fechas de creación, revisión o eliminación</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxLabel ID="lbl46" runat="server" 
                                                                 Text="Fechas de creación, revisión o eliminación:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                              <dxe:ASPxDateEdit ID="txt46" runat="server" Height="16px" Width="80px">
                                                             </dxe:ASPxDateEdit>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             4.7 Lenguas y escrituras</td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <dxe:ASPxLabel ID="lbl47" runat="server" Text="Lenguas y escrituras:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                         <td>
                                                             <dxe:ASPxTextBox ID="txt47" runat="server" Width="170px">
                                                             </dxe:ASPxTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             4.8 Fuentes</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxLabel ID="lbl48" runat="server" Text="Fuentes:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxMemo ID="txt48" runat="server" Height="109px" Width="350px">
                                                             </dxe:ASPxMemo>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             4.9 Notas de mantenimiento</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxLabel ID="lbl49" runat="server" Text="Notas de mantenimiento:">
                                                             </dxe:ASPxLabel>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="2">
                                                             <dxe:ASPxMemo ID="txt49" runat="server" Height="109px" Width="350px">
                                                             </dxe:ASPxMemo>
                                                         </td>
                                                     </tr>
                                                 </table>
                                             </dxw:ContentControl>
                                         </ContentCollection>
                                     </dxtc:TabPage>
                                 </TabPages>
                             </dxtc:ASPxPageControl>
                             <table border="0" cellpadding="1" cellspacing="1" style="width: 31%;">
        
                           
                     <tr>
                        <td>
                             <dxe:ASPxButton ID="btnguardar" runat="server" Text="Guardar" 
                                 style="height: 24px" Visible="False" AutoPostBack="false" 
                                 EnableViewState="False" UseSubmitBehavior="False" 
                                 ValidationGroup="requeridos">
                              </dxe:ASPxButton>
                        </td>
                      
                     </tr>
                </table>
     
    
      </td>
                    </tr>
                </table>
         <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
        <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" 
            ForeColor="Red" Text="">
        </dxe:ASPxLabel>
         <asp:Label ID="lblidISAAR" runat="server" Visible="False"></asp:Label>
</div>

<div >
        
                                        
        
                                        
                                        <asp:ObjectDataSource ID="ListaISAAR" runat="server" 
                                            SelectMethod="ListaISAAR"   TypeName="Portalv9.WSArchivo.Service1"  >
                                        </asp:ObjectDataSource>
        
                                      
        
                                                                                   
        
                                        <asp:ObjectDataSource ID="Relaciones" runat="server" 
                                            SelectMethod="ListaISAAR_Relaciones"   
                                            TypeName="Portalv9.WSArchivo.Service1" DeleteMethod="ABC_ISAAR_Relaciones" 
                                            InsertMethod="ABC_ISAAR_Relaciones" UpdateMethod="ABC_ISAAR_Relaciones">
                                            <DeleteParameters>
                                                <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                                <asp:Parameter Name="idRelacion" Type="Int32" />
                                                <asp:Parameter Name="idISAAR_REL" Type="Int32" />
                                                <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
                                                <asp:Parameter Name="Descripción_relación" Type="String" />
                                                <asp:Parameter Name="Fechas_relación" Type="DateTime" />
                                            </DeleteParameters>
                                            <UpdateParameters>
                                                <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                                <asp:Parameter Name="idRelacion" Type="Int32" />
                                                <asp:Parameter Name="idISAAR_REL" Type="Int32" />
                                                <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
                                                <asp:Parameter Name="Descripción_relación" Type="String" />
                                                <asp:Parameter Name="Fechas_relación" Type="DateTime" />
                                            </UpdateParameters>
                                            <SelectParameters>
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                            </SelectParameters>
                                            <InsertParameters>
                                                <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                                <asp:Parameter Name="idRelacion" Type="Int32" />
                                                <asp:Parameter Name="idISAAR_REL" Type="Int32" />
                                                <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
                                                <asp:Parameter Name="Descripción_relación" Type="String" />
                                                <asp:Parameter Name="Fechas_relación" Type="DateTime" />
                                            </InsertParameters>
                                        </asp:ObjectDataSource>
        
                                      
        
                                                                                   
        
                                        <asp:ObjectDataSource ID="ListaCatalogoNaturaleza" runat="server" 
                                            SelectMethod="ListaCatalogo_Datos"   
                                            TypeName="Portalv9.WSArchivo.Service1" 
                                            OldValuesParameterFormatString="original_{0}">
                                            <SelectParameters>
                                                <asp:Parameter Name="IDCatalogo" Type="Int32" DefaultValue="5" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
        
                                      
        
                                                                                   
        
    </div>
    
</asp:Content>
