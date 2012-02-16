    <%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_PantallaCapturaISAAR.aspx.vb" Inherits="Portalv9.Wfrm_PantallaCapturaISAAR" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitulo" runat="server" Text="Bienvenido" > </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
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
                             <table border="0" cellpadding="1" cellspacing="1" style="width: 31%;">
        
                           
                     <tr>
                        <td>
                             <asp:FormView ID="FormView1" runat="server" DataSourceID="ListaISAARxID" 
                                 DataKeyNames="idISAAR">
                                 <EditItemTemplate>
                                     <dxe:ASPxTextBox ID="txtidISAAR" runat="server" Text='<%# Bind("idISAAR") %>' 
                                         Visible="False" Width="170px">
                                     </dxe:ASPxTextBox>
                                     <dxtc:ASPxPageControl ID="pgareas" runat="server" ActiveTabIndex="0" >
                                         <TabPages>
                                             <dxtc:TabPage Text="1 Identificación"   >
                                                 <ContentCollection >
                                                     <dxw:ContentControl runat="server" >
                                                         <table style="width: 100%" >
                                                             <tr>
                                                                 <td>
                                                                     &nbsp;<dxe:ASPxLabel ID="lbltipo" runat="server" Text="Tipo:">
                                                                     </dxe:ASPxLabel>
                                                                 </td>
                                                                 <td>
                                                                     <dxe:ASPxComboBox ID="txt11" runat="server" AutoPostBack="false" 
                                                                         SelectedIndex="0" Value='<%# Bind("Tipo_de_entidad") %>'>
                                                                         <Items>
                                                                             <dxe:ListEditItem Text="Institución" Value="0" />
                                                                             <dxe:ListEditItem Text="Familia" Value="1" />
                                                                             <dxe:ListEditItem Text="Persona" Value="2" />
                                                                         </Items>
                                                                         <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True" 
                                                                             ValidationGroup="requeridos">
                                                                             <RequiredField ErrorText="Debe ser capturado" IsRequired="True" />
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
                                                                     &nbsp;<dxe:ASPxLabel ID="lblnombre1" runat="server" Text="Nombre:">
                                                                     </dxe:ASPxLabel>
                                                                 </td>
                                                                 <td>
                                                                     <dxe:ASPxTextBox ID="txt12" runat="server" 
                                                                         Text='<%# Bind("Formas_autorizadas_nombre") %>' Width="170px">
                                                                         <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True" 
                                                                             ValidationGroup="requeridos">
                                                                             <RequiredField ErrorText="Debe ser capturado" IsRequired="True" />
                                                                         </ValidationSettings>
                                                                     </dxe:ASPxTextBox>
                                                                 </td>
                                                             </tr>
                                                             <tr>
                                                                 <td colspan="2">
                                                                     1.1 Tipo de entidad</td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                     <dxe:ASPxLabel ID="lblnombre2" runat="server" Text="Nombre:">
                                                                     </dxe:ASPxLabel>
                                                                 </td>
                                                                 <td>
                                                                     <dxe:ASPxTextBox ID="txt13" runat="server" 
                                                                         Text='<%# Bind("Formas_paralelas_nombre") %>' Width="170px">
                                                                     </dxe:ASPxTextBox>
                                                                 </td>
                                                             </tr>
                                                             <tr>
                                                                 <td colspan="2">
                                                                     1.3 Formas paralelas del nombre</td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                     <dxe:ASPxLabel ID="lblnombre3" runat="server" Text="Nombre:">
                                                                     </dxe:ASPxLabel>
                                                                 </td>
                                                                 <td>
                                                                     <dxe:ASPxTextBox ID="txt14" runat="server" 
                                                                         Text='<%# Bind("Formas_normalizadas_nombre") %>' Width="170px">
                                                                     </dxe:ASPxTextBox>
                                                                 </td>
                                                             </tr>
                                                             <tr>
                                                                 <td colspan="2">
                                                                     1.6 Identificadores para instituciones</td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                     <dxe:ASPxLabel ID="lblnombre4" runat="server" Text="Nombre:">
                                                                     </dxe:ASPxLabel>
                                                                 </td>
                                                                 <td>
                                                                     <dxe:ASPxTextBox ID="txt15" runat="server" 
                                                                         Text='<%# Bind("Otras_formas_nombre") %>' Width="170px">
                                                                     </dxe:ASPxTextBox>
                                                                 </td>
                                                             </tr>
                                                             <tr>
                                                                 <td colspan="2">
                                                                     1.5 Otras formas del nombre</td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                     <dxe:ASPxLabel ID="lblnombre5" runat="server" 
                                                                         Text="Identificadores para entidades colectivas:">
                                                                     </dxe:ASPxLabel>
                                                                 </td>
                                                                 <td>
                                                                     <dxe:ASPxTextBox ID="txt16" runat="server" 
                                                                         Text='<%# Bind("Identificadores_para_instituciones") %>' Width="170px">
                                                                     </dxe:ASPxTextBox>
                                                                 </td>
                                                             </tr>
                                                             <tr>
                                                                 <td colspan="2">
                                                                     1.4 Formas normalizadas del nombre</td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                     </td>
                                                                 <td>
                                                                     &nbsp;</td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                     </td>
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
                                                                     <dxe:ASPxDateEdit ID="txt21" runat="server" Height="16px" 
                                                                         Value='<%# Bind("Fechas_de_existencia") %>' Width="80px">
                                                                         <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True" 
                                                                             ValidationGroup="requeridos">
                                                                             <RequiredField ErrorText="Debe ser capturada" IsRequired="True" />
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
                                                                     <dxe:ASPxMemo ID="txt22" runat="server" Height="109px" 
                                                                         Text='<%# Bind("Historia") %>' Width="350px">
                                                                     </dxe:ASPxMemo>
                                                                 </td>
                                                             </tr>
                                                             <tr>
                                                                 <td colspan="2">
                                                                     2.3 Lugares</td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                     <dxe:ASPxLabel ID="lbllugar" runat="server" Text="Lugares :">
                                                                     </dxe:ASPxLabel>
                                                                 </td>
                                                                 <td>
                                                                     <dxe:ASPxTextBox ID="txt23" runat="server" Text='<%# Bind("Lugares") %>' 
                                                                         Width="170px">
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
                                                                     <dxe:ASPxTextBox ID="txt24" runat="server" 
                                                                         Text='<%# Bind("Estatuto_jurídico") %>' Width="170px">
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
                                                                     <dxe:ASPxTextBox ID="txt25" runat="server" 
                                                                         Text='<%# Bind("Funciones_ocupaciones_actividades") %>' Width="350px">
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
                                                                     <dxe:ASPxTextBox ID="txt26" runat="server" 
                                                                         Text='<%# Bind("Atribuciones_Fuentes_legales") %>' Width="350px">
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
                                                                     <dxe:ASPxTextBox ID="txt27" runat="server" 
                                                                         Text='<%# Bind("Estructuras_internas_Genealogía") %>' Width="350px">
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
                                                                     <dxe:ASPxTextBox ID="txt28" runat="server" 
                                                                         Text='<%# Bind("Contexto_general") %>' Width="350px">
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
                                                                    DataSourceID="Relaciones" Enabled="true" Width="600px" >
                                                             <SettingsBehavior ConfirmDelete="true" />
                                                             <Settings ShowTitlePanel="True" />
                                                             <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar éste elemento ?" 
                                                                 Title="Relaciones" />
                                                             <Columns>
                                                                 <dxwgv:GridViewDataTextColumn  Caption="idISAAR" Visible="false"  
                                                                              FieldName="idISAAR" ReadOnly="True" VisibleIndex="0">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataTextColumn  Caption="idRelacion"  Visible="false" 
                                                                              FieldName="idRelacion" ReadOnly="True" VisibleIndex="0">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataComboBoxColumn Caption="Nombres de Identificadores" 
                                                                              FieldName="idISAAR_REL" VisibleIndex="0">
                                                                     <PropertiesComboBox DataSourceID="ListaISAAR" 
                                                                                  EnableIncrementalFiltering="True" TextField="Formas_autorizadas_nombre" 
                                                                                  ValueField="idISAAR" ValueType="System.String"></PropertiesComboBox>
                                                                 </dxwgv:GridViewDataComboBoxColumn>
                                                                 <dxwgv:GridViewDataComboBoxColumn Caption="Naturaleza de la relación" 
                                                                              FieldName="IDCatalogo_item" VisibleIndex="1">
                                                                     <PropertiesComboBox DataSourceID="ListaCatalogoNaturaleza" 
                                                                                  EnableIncrementalFiltering="True" TextField="Descripcion" 
                                                                                  ValueField="IDCatalogo_item" ValueType="System.Int32"></PropertiesComboBox>
                                                                 </dxwgv:GridViewDataComboBoxColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="Descripción de la relación" 
                                                                              FieldName="Descripción_relación" ReadOnly="false" 
                                                                     VisibleIndex="3">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataDateColumn Caption="Fechas de la relación" 
                                                                              FieldName="Fechas_relación" ReadOnly="false" VisibleIndex="4" >
                                                                 </dxwgv:GridViewDataDateColumn>
                                                                 <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="4"  >
                                                                     <DeleteButton Text="Eliminar" Visible="true">
                                                                     </DeleteButton>
                                                                 </dxwgv:GridViewCommandColumn>
                                                                 <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="5">
                                                                     <NewButton Text="Agregar relación" Visible="true">
                                                                     </NewButton>
                                                                 </dxwgv:GridViewCommandColumn>
                                                                 <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex=6>
                                                                     <EditButton Text="Editar" Visible="True">
                                                                     </EditButton>
                                                                     <CancelButton Text="Cancelar" Visible="True">
                                                                     </CancelButton>
                                                                     <UpdateButton Text="Actualizar" Visible="True">
                                                                     </UpdateButton>
                                                                 </dxwgv:GridViewCommandColumn>
                                                             </Columns>
                                                         </dxwgv:ASPxGridView>
                                                         <br />
                                                         <dxwgv:ASPxGridView ID="gdISAARExpedientes" runat="server" 
                                                             AutoGenerateColumns="False" ClientInstanceName="gdISAARExpedientes" 
                                                             DataSourceID="ListaISAARTipoExpediente" KeyFieldName="idSerie" 
                                                             OnRowInserting="gdISAARExpedientes_RowInserting" Width="600px" 
                                                             OnCustomErrorText="gdISAARExpedientes_CustomErrorText" 
                                                             OnRowDeleting="gdISAARExpedientes_RowDeleting">
                                                             <Columns>
                                                                 <dxwgv:GridViewCommandColumn VisibleIndex="0" Width="100px">
                                                                     <NewButton Visible="True">
                                                                     </NewButton>
                                                                     <DeleteButton Visible="True">
                                                                     </DeleteButton>
                                                                 </dxwgv:GridViewCommandColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="op" FieldName="op" Visible="False" 
                                                                     VisibleIndex="1">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idISAAR" FieldName="idISAAR" 
                                                                     VisibleIndex="1" Visible="False">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idNorma" FieldName="idNorma" 
                                                                     VisibleIndex="1" Visible="False">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" 
                                                                     VisibleIndex="1" Visible="False">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataComboBoxColumn Caption="Tipo de expediente" FieldName="idSerie" 
                                                                     VisibleIndex="1">
                                                                     <PropertiesComboBox DataSourceID="TiposExpediente" EnableCallbackMode="True" 
                                                                         TextField="Serie_nombre" ValueField="idSerie" ValueType="System.Int32"></PropertiesComboBox>
                                                                     <EditItemTemplate>
                                                                         <dxe:ASPxComboBox ID="cmbTipoExpediente" runat="server" 
                                                                             DataSourceID="TiposExpediente" EnableIncrementalFiltering="True" 
                                                                             TextField="Serie_nombre" Value='<%# Bind("idSerie") %>' ValueField="idSerie" 
                                                                             ValueType="System.Int32">
                                                                             <Columns>
                                                                                 <dxe:ListBoxColumn Caption="idNorma" FieldName="idNorma" Name="idNorma" 
                                                                                     Visible="False" />
                                                                                 <dxe:ListBoxColumn Caption="idNivel" FieldName="idNivel" Name="idNivel" 
                                                                                     Visible="False" />
                                                                                 <dxe:ListBoxColumn Caption="idSerie" FieldName="idSerie" Name="idSerie" 
                                                                                     Visible="False" />
                                                                                 <dxe:ListBoxColumn Caption="Serie_nombre" FieldName="Serie_nombre" 
                                                                                     Name="Serie_nombre" />
                                                                             </Columns>
                                                                         </dxe:ASPxComboBox>
                                                                     </EditItemTemplate>
                                                                 </dxwgv:GridViewDataComboBoxColumn>
                                                             </Columns>
                                                             <SettingsBehavior ConfirmDelete="True" />
                                                             <Settings ShowTitlePanel="True" />
                                                             <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar éste elemento ?" 
                                                                 Title="Tipos de documentos que puede producir" CommandCancel="Cancelar" 
                                                                 CommandDelete="Borrar" CommandEdit="Editar" CommandNew="Nuevo" 
                                                                 CommandUpdate="Actualizar" EmptyDataRow="No existen datos" />
                                                         </dxwgv:ASPxGridView>
                                                         <br />
                                                         <dxwgv:ASPxGridView ID="gdISAAREntidades" runat="server" 
                                                             AutoGenerateColumns="False" ClientInstanceName="gdISAAREntidades" 
                                                             DataSourceID="ListaISAAREntidades" KeyFieldName="idDescripcion" 
                                                             OnCustomErrorText="gdISAAREntidades_CustomErrorText" 
                                                             OnRowDeleting="gdISAAREntidades_RowDeleting" 
                                                             OnRowInserting="gdISAAREntidades_RowInserting" Width="600px">
                                                             <Columns>
                                                                 <dxwgv:GridViewCommandColumn VisibleIndex="0" Width="100px">
                                                                     <NewButton Visible="True">
                                                                     </NewButton>
                                                                     <DeleteButton Visible="True">
                                                                     </DeleteButton>
                                                                 </dxwgv:GridViewCommandColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idISAAR" FieldName="idISAAR" 
                                                                     VisibleIndex="1" Visible="False">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" 
                                                                     VisibleIndex="1" Visible="False">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataComboBoxColumn Caption="Entidad" FieldName="idDescripcion" 
                                                                     VisibleIndex="1">
                                                                     <PropertiesComboBox DataSourceID="Series" TextField="Descripcion" 
                                                                         ValueField="idDescripcion" ValueType="System.Int32">
                                                                     </PropertiesComboBox>
                                                                     <EditItemTemplate>
                                                                         <dxe:ASPxComboBox ID="cmbSeries" runat="server" DataSourceID="Series" 
                                                                             TextField="Descripcion" Value='<%# bind("idDescripcion") %>' 
                                                                             ValueField="idDescripcion" ValueType="System.Int32" Width="300px">
                                                                             <Columns>
                                                                                 <dxe:ListBoxColumn Caption="idArchivo" FieldName="idArchivo" Name="idArchivo" 
                                                                                     Visible="False" />
                                                                                 <dxe:ListBoxColumn Caption="idDescripcion" FieldName="idDescripcion" 
                                                                                     Name="idDescripcion" Visible="False" />
                                                                                 <dxe:ListBoxColumn Caption="Entidad" FieldName="Descripcion" 
                                                                                     Name="Descripcion" />
                                                                             </Columns>
                                                                         </dxe:ASPxComboBox>
                                                                     </EditItemTemplate>
                                                                 </dxwgv:GridViewDataComboBoxColumn>
                                                             </Columns>
                                                             <SettingsBehavior ConfirmDelete="True" />
                                                             <Settings ShowTitlePanel="True" />
                                                             <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                                                                 CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                                                                 ConfirmDelete="¿ Estás seguro de querer eliminar éste elemento ?" 
                                                                 EmptyDataRow="No existen datos" 
                                                                 Title="Entidad a la que pertenece" />
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
                                                                     <dxe:ASPxTextBox ID="txt41" runat="server" 
                                                                         Text='<%# Bind("Identificador_registro_autoridad") %>' Width="170px">
                                                                         <ValidationSettings CausesValidation="True" ErrorDisplayMode="Text" 
                                                                             SetFocusOnError="True" ValidationGroup="requeridos">
                                                                             <RequiredField ErrorText="Debe ser capturado" IsRequired="True" />
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
                                                                     <dxe:ASPxTextBox ID="txt42" runat="server" 
                                                                         Text='<%# Bind("Identificadores_institución") %>' Width="170px">
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
                                                                     <dxe:ASPxMemo ID="txt43" runat="server" Height="109px" 
                                                                         Text='<%# Bind("Reglas_convenciones") %>' Width="350px">
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
                                                                     <dxe:ASPxTextBox ID="txt44" runat="server" 
                                                                         Text='<%# Bind("Estado_elaboración") %>' Width="350px">
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
                                                                     <dxe:ASPxMemo ID="txt45" runat="server" Height="109px" 
                                                                         Text='<%# Bind("Nivel_detalle") %>' Width="350px">
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
                                                                     <dxe:ASPxDateEdit ID="txt46" runat="server" Height="16px" 
                                                                         Value='<%# Bind("Fechas_creación_revisión_eliminación") %>' Width="80px">
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
                                                                     <dxe:ASPxTextBox ID="txt47" runat="server" 
                                                                         Text='<%# Bind("Lenguas_escrituras") %>' Width="170px">
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
                                                                     <dxe:ASPxMemo ID="txt48" runat="server" Height="109px" 
                                                                         Text='<%# Bind("Fuentes") %>' Width="350px">
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
                                                                     <dxe:ASPxMemo ID="txt49" runat="server" Height="109px" 
                                                                         Text='<%# Bind("Notas_de_mantenimiento") %>' Width="350px">
                                                                     </dxe:ASPxMemo>
                                                                 </td>
                                                             </tr>
                                                         </table>
                                                     </dxw:ContentControl>
                                                 </ContentCollection>
                                             </dxtc:TabPage>
                                         </TabPages>
                                     </dxtc:ASPxPageControl>
                                     <dxe:ASPxButton ID="btnguardar" runat="server" 
                                         CommandName="Update" EnableViewState="False" 
                                         style="height: 24px" Text="Guardar" UseSubmitBehavior="False" 
                                         ValidationGroup="requeridos" CausesValidation="False" 
                                         onclick="btnguardar_Click">
                                     </dxe:ASPxButton>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <dxe:ASPxTextBox ID="ASPxTextBox1" runat="server" Text='<%# Bind("idISAAR") %>' 
                                         Visible="False" Width="170px">
                                     </dxe:ASPxTextBox>
                                     <dxtc:ASPxPageControl ID="pgareasReadonly" runat="server" ActiveTabIndex="0" >
                                         <TabPages>
                                             <dxtc:TabPage Text="1 Identificación">
                                                 <ContentCollection>
                                                     <dxw:ContentControl runat="server">
                                                         <table style="width: 100%">
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
                                                                     <dxe:ASPxLabel ID="tx11" runat="server" AutoPostBack="false" 
                                                                         SelectedIndex="0" Value='<%# Eval("Tipo_de_entidad") %>'>
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx12" runat="server" 
                                                                         Text='<%# Eval("Formas_autorizadas_nombre") %>' Width="170px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx13" runat="server" 
                                                                         Text='<%# Eval("Formas_paralelas_nombre") %>' Width="170px" >
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx14" runat="server" 
                                                                         Text='<%# Eval("Formas_normalizadas_nombre") %>' Width="170px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx15" runat="server" 
                                                                         Text='<%# Eval("Otras_formas_nombre") %>' Width="170px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx16" runat="server" 
                                                                         Text='<%# Eval("Identificadores_para_instituciones") %>' Width="170px">
                                                                     </dxe:ASPxLabel>
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
                                                     <dxw:ContentControl runat="server">
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
                                                                     <dxe:ASPxLabel ID="txt21" runat="server" 
                                                                         Text='<%# Eval("Fechas_de_existencia") %>' >
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="txt22" runat="server" Height="109px" 
                                                                         Text='<%# Eval("Historia") %>' Width="350px">
                                                                     </dxe:ASPxLabel>
                                                                 </td>
                                                             </tr>
                                                             <tr>
                                                                 <td colspan="2">
                                                                     2.3 Lugares</td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                     <dxe:ASPxLabel ID="lbllugar" runat="server" Text="Lugares :">
                                                                     </dxe:ASPxLabel>
                                                                 </td>
                                                                 <td>
                                                                     <dxe:ASPxTextBox ID="tx23" runat="server" Text='<%# Eval("Lugares") %>' 
                                                                         Width="170px">
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
                                                                     <dxe:ASPxLabel ID="tx24" runat="server" 
                                                                         Text='<%# Eval("Estatuto_jurídico") %>' Width="170px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx25" runat="server" 
                                                                         Text='<%# Eval("Funciones_ocupaciones_actividades") %>' Width="350px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx26" runat="server" 
                                                                         Text='<%# Eval("Atribuciones_Fuentes_legales") %>' Width="350px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx27" runat="server" 
                                                                         Text='<%# Eval("Estructuras_internas_Genealogía") %>' Width="350px" >
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx28" runat="server" 
                                                                         Text='<%# Eval("Contexto_general") %>' Width="350px">
                                                                     </dxe:ASPxLabel>
                                                                 </td>
                                                             </tr>
                                                         </table>
                                                     </dxw:ContentControl>
                                                 </ContentCollection>
                                             </dxtc:TabPage>
                                             <dxtc:TabPage Text="3 Relaciones">
                                                 <ContentCollection>
                                                     <dxw:ContentControl runat="server">
                                                         <dxwgv:ASPxGridView ID="aspxgdisaarrelacion" runat="server" 
                                                             AutoGenerateColumns="False" ClientInstanceName="aspxgdisaarrelacion" 
                                                             DataSourceID="Relaciones" Enabled="true" KeyFieldName="idRelacion" 
                                                             Width="600px">
                                                             <SettingsBehavior ConfirmDelete="true" />
                                                             <Settings ShowTitlePanel="True" />
                                                             <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar éste elemento ?" 
                                                                 Title="Relaciones" />
                                                             <Columns>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idISAAR" FieldName="idISAAR" 
                                                                     ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idRelacion" FieldName="idRelacion" 
                                                                     ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataComboBoxColumn Caption="Nombres de Identificadores" 
                                                                     FieldName="idISAAR_REL" VisibleIndex="0">
                                                                     <PropertiesComboBox DataSourceID="ListaISAAR" EnableIncrementalFiltering="True" 
                                                                         TextField="Formas_autorizadas_nombre" ValueField="idISAAR" 
                                                                         ValueType="System.String"></PropertiesComboBox>
                                                                 </dxwgv:GridViewDataComboBoxColumn>
                                                                 <dxwgv:GridViewDataComboBoxColumn Caption="Naturaleza de la relación" 
                                                                     FieldName="IDCatalogo_item" VisibleIndex="1">
                                                                     <PropertiesComboBox DataSourceID="ListaCatalogoNaturaleza" 
                                                                         EnableIncrementalFiltering="True" TextField="Descripcion" 
                                                                         ValueField="IDCatalogo_item" ValueType="System.Int32"></PropertiesComboBox>
                                                                 </dxwgv:GridViewDataComboBoxColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="Descripción de la relación" 
                                                                     FieldName="Descripción_relación" ReadOnly="false" VisibleIndex="3">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataDateColumn Caption="Fechas de la relación" 
                                                                     FieldName="Fechas_relación" ReadOnly="false" VisibleIndex="4">
                                                                 </dxwgv:GridViewDataDateColumn>
                                                             </Columns>
                                                         </dxwgv:ASPxGridView>
                                                         <br />
                                                         <dxwgv:ASPxGridView ID="aspxgdisaarrelacion0" runat="server" 
                                                             AutoGenerateColumns="False" ClientInstanceName="aspxgdisaarrelacion" 
                                                             DataSourceID="ListaISAARTipoExpediente" KeyFieldName="idSerie" 
                                                             Width="600px">
                                                             <Columns>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idISAAR" FieldName="idISAAR" 
                                                                     VisibleIndex="0" Visible="False">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idNorma" FieldName="idNorma" 
                                                                     VisibleIndex="0" Visible="False">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" 
                                                                     VisibleIndex="0" Visible="False">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataComboBoxColumn Caption="Tipo de expediente" 
                                                                     FieldName="idSerie" VisibleIndex="0">
                                                                     <PropertiesComboBox DataSourceID="TiposExpediente" TextField="Serie_Nombre" 
                                                                         ValueField="idSerie" ValueType="System.Int32"></PropertiesComboBox>
                                                                 </dxwgv:GridViewDataComboBoxColumn>
                                                             </Columns>
                                                             <SettingsBehavior ConfirmDelete="True" />
                                                             <Settings ShowTitlePanel="True" />
                                                             <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar éste elemento ?" 
                                                                 Title="Tipo de documentos que puede producir" />
                                                         </dxwgv:ASPxGridView>
                                                         <br />
                                                         <dxwgv:ASPxGridView ID="aspxgdisaarrelacion1" runat="server" 
                                                             AutoGenerateColumns="False" ClientInstanceName="aspxgdisaarrelacion" 
                                                             DataSourceID="ListaISAAREntidades" KeyFieldName="idDescripcion" 
                                                             Width="600px">
                                                             <Columns>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idISAAR" FieldName="idISAAR" 
                                                                     VisibleIndex="0" Visible="False">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" 
                                                                     VisibleIndex="0" Visible="False">
                                                                 </dxwgv:GridViewDataTextColumn>
                                                                 <dxwgv:GridViewDataComboBoxColumn Caption="Entidades" FieldName="idDescripcion" 
                                                                     VisibleIndex="0">
                                                                     <PropertiesComboBox DataSourceID="Series" TextField="Descripcion" 
                                                                         ValueField="idDescripcion" ValueType="System.Int32"></PropertiesComboBox>
                                                                 </dxwgv:GridViewDataComboBoxColumn>
                                                             </Columns>
                                                             <SettingsBehavior ConfirmDelete="True" />
                                                             <Settings ShowTitlePanel="True" />
                                                             <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar éste elemento ?" 
                                                                 Title="Entidad a la que pertenece" />
                                                         </dxwgv:ASPxGridView>
                                                     </dxw:ContentControl>
                                                 </ContentCollection>
                                             </dxtc:TabPage>
                                             <dxtc:TabPage Text="4 Control">
                                                 <ContentCollection>
                                                     <dxw:ContentControl runat="server">
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
                                                                     <dxe:ASPxLabel ID="tx41" runat="server" 
                                                                         Text='<%# Eval("Identificador_registro_autoridad") %>' Width="170px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx42" runat="server" 
                                                                         Text='<%# Eval("Identificadores_institución") %>' Width="170px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx43" runat="server" Height="109px" 
                                                                         Text='<%# Eval("Reglas_convenciones") %>' Width="350px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx44" runat="server" 
                                                                         Text='<%# Eval("Estado_elaboración") %>' Width="350px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx45" runat="server" Height="109px" 
                                                                         Text='<%# Eval("Nivel_detalle") %>' Width="350px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx46" runat="server" 
                                                                         Text='<%# Eval("Fechas_creación_revisión_eliminación") %>' Width="80px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx47" runat="server" 
                                                                         Text='<%# Eval("Lenguas_escrituras") %>' Width="170px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx48" runat="server" Height="109px" 
                                                                         Text='<%# Eval("Fuentes") %>' Width="350px">
                                                                     </dxe:ASPxLabel>
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
                                                                     <dxe:ASPxLabel ID="tx49" runat="server" Height="109px" 
                                                                         Text='<%# Eval("Notas_de_mantenimiento") %>' Width="350px">
                                                                     </dxe:ASPxLabel>
                                                                 </td>
                                                             </tr>
                                                         </table>
                                                     </dxw:ContentControl>
                                                 </ContentCollection>
                                             </dxtc:TabPage>
                                         </TabPages>
                                     </dxtc:ASPxPageControl>
                                 </ItemTemplate>
                             </asp:FormView>
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
                                            SelectMethod="ListaISAAR"   TypeName="Portalv9.WSArchivo.Service1" 
                                            DeleteMethod="ABC_ISAAR"  >
                                            <DeleteParameters>
                                                <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                                <asp:Parameter Name="Tipo_de_entidad" Type="String" />
                                                <asp:Parameter Name="Formas_autorizadas_nombre" Type="String" />
                                                <asp:Parameter Name="Formas_paralelas_nombre" Type="String" />
                                                <asp:Parameter Name="Formas_normalizadas_nombre" Type="String" />
                                                <asp:Parameter Name="Otras_formas_nombre" Type="String" />
                                                <asp:Parameter Name="Identificadores_para_instituciones" Type="String" />
                                                <asp:Parameter Name="Fechas_de_existencia" Type="DateTime" />
                                                <asp:Parameter Name="Historia" Type="String" />
                                                <asp:Parameter Name="Lugares" Type="String" />
                                                <asp:Parameter Name="Estatuto_jurídico" Type="String" />
                                                <asp:Parameter Name="Funciones_ocupaciones_actividades" Type="String" />
                                                <asp:Parameter Name="Atribuciones_Fuentes_legales" Type="String" />
                                                <asp:Parameter Name="Estructuras_internas_Genealogía" Type="String" />
                                                <asp:Parameter Name="Contexto_general" Type="String" />
                                                <asp:Parameter Name="Identificador_registro_autoridad" Type="String" />
                                                <asp:Parameter Name="Identificadores_institución" Type="String" />
                                                <asp:Parameter Name="Reglas_convenciones" Type="String" />
                                                <asp:Parameter Name="Estado_elaboración" Type="String" />
                                                <asp:Parameter Name="Nivel_detalle" Type="String" />
                                                <asp:Parameter Name="Fechas_creación_revisión_eliminación" Type="DateTime" />
                                                <asp:Parameter Name="Lenguas_escrituras" Type="String" />
                                                <asp:Parameter Name="Fuentes" Type="String" />
                                                <asp:Parameter Name="Notas_de_mantenimiento" Type="String" />
                                            </DeleteParameters>
                                        </asp:ObjectDataSource>
        
                                      
        
                                                                                   
        
                                        <asp:ObjectDataSource ID="ListaISAARxID" runat="server" 
                                            SelectMethod="ListaISAARxid"   TypeName="Portalv9.WSArchivo.Service1" 
                                            UpdateMethod="ABC_ISAAR"  >
                                            <UpdateParameters>
                                                <asp:Parameter Name="op" Type="Object" DefaultValue="2" />
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                                <asp:Parameter Name="Tipo_de_entidad" Type="String" />
                                                <asp:Parameter Name="Formas_autorizadas_nombre" Type="String" />
                                                <asp:Parameter Name="Formas_paralelas_nombre" Type="String" />
                                                <asp:Parameter Name="Formas_normalizadas_nombre" Type="String" />
                                                <asp:Parameter Name="Otras_formas_nombre" Type="String" />
                                                <asp:Parameter Name="Identificadores_para_instituciones" Type="String" />
                                                <asp:Parameter Name="Fechas_de_existencia" Type="DateTime" />
                                                <asp:Parameter Name="Historia" Type="String" />
                                                <asp:Parameter Name="Lugares" Type="String" />
                                                <asp:Parameter Name="Estatuto_jurídico" Type="String" />
                                                <asp:Parameter Name="Funciones_ocupaciones_actividades" Type="String" />
                                                <asp:Parameter Name="Atribuciones_Fuentes_legales" Type="String" />
                                                <asp:Parameter Name="Estructuras_internas_Genealogía" Type="String" />
                                                <asp:Parameter Name="Contexto_general" Type="String" />
                                                <asp:Parameter Name="Identificador_registro_autoridad" Type="String" />
                                                <asp:Parameter Name="Identificadores_institución" Type="String" />
                                                <asp:Parameter Name="Reglas_convenciones" Type="String" />
                                                <asp:Parameter Name="Estado_elaboración" Type="String" />
                                                <asp:Parameter Name="Nivel_detalle" Type="String" />
                                                <asp:Parameter Name="Fechas_creación_revisión_eliminación" Type="DateTime" 
                                                    DefaultValue="" />
                                                <asp:Parameter Name="Lenguas_escrituras" Type="String" />
                                                <asp:Parameter Name="Fuentes" Type="String" />
                                                <asp:Parameter Name="Notas_de_mantenimiento" Type="String" />
                                            </UpdateParameters>
                                            <SelectParameters>
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                            </SelectParameters>
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
        
                                      
        
                                                                                   
        
                                        <asp:ObjectDataSource ID="ListaISAARTipoExpediente" runat="server" 
                                            SelectMethod="ListaISAAR_Series_Modelo" 
                                            TypeName="Portalv9.WSArchivo.Service1" DeleteMethod="ABC_ISAAR_Series_Modelo" 
                                            InsertMethod="ABC_ISAAR_Series_Modelo">
                                            <DeleteParameters>
                                                <asp:Parameter Name="op" Type="Object" DefaultValue="1" />
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                                <asp:Parameter Name="idNorma" Type="Int32" />
                                                <asp:Parameter Name="idNivel" Type="Int32" />
                                                <asp:Parameter Name="idSerie" Type="Int32" />
                                            </DeleteParameters>
                                            <SelectParameters>
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                            </SelectParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="op" Type="Object" DefaultValue="0" />
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                                <asp:Parameter Name="idNorma" Type="Int32" />
                                                <asp:Parameter Name="idNivel" Type="Int32" />
                                                <asp:Parameter Name="idSerie" Type="Int32" />
                                            </InsertParameters>
                                        </asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="ListaISAAREntidades" runat="server" 
                                            SelectMethod="ListaISAAR_Entidades" TypeName="Portalv9.WSArchivo.Service1" 
                                            DeleteMethod="ABC_ISAAR_Entidades" InsertMethod="ABC_ISAAR_Entidades">
                                            <DeleteParameters>
                                                <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                                <asp:Parameter Name="idArchivo" Type="Int32" />
                                                <asp:Parameter Name="idDescripcion" Type="Int32" />
                                            </DeleteParameters>
                                            <SelectParameters>
                                                <asp:Parameter Name="idISAAR" Type="Int32" DefaultValue="" />
                                            </SelectParameters>
                                            <InsertParameters>
                                                <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                                                <asp:Parameter Name="idISAAR" Type="Int32" />
                                                <asp:Parameter Name="idArchivo" Type="Int32" />
                                                <asp:Parameter Name="idDescripcion" Type="Int32" />
                                            </InsertParameters>
                                        </asp:ObjectDataSource>
        
                                      
        
                                                                                   
        
                                        <asp:ObjectDataSource ID="TiposExpediente" runat="server" 
                                            SelectMethod="ListaSeries_Modelo" TypeName="Portalv9.WSArchivo.Service1">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="" Name="identidad" Type="Int32" />
                                                <asp:Parameter DefaultValue="5" Name="Profundidad" Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
        
                                      
        
                                                                                   
        
                                        <asp:ObjectDataSource ID="Series" runat="server" 
                                            SelectMethod="ListaArchivo_Descripciones_nivel" 
                                            TypeName="Portalv9.WSArchivo.Service1">
                                            <SelectParameters>
                                                <asp:Parameter Name="idArchivo" Type="Int32" DefaultValue="16" />
                                                <asp:Parameter Name="idNivel" Type="Int32" DefaultValue="218" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
        
                                      
        
                                                                                   
        
    </div>
    
</asp:Content>
