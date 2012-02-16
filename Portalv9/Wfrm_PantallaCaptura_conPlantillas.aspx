<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_PantallaCaptura_conPlantillas.aspx.vb" Inherits="Portalv9.Wfrm_PantallaCaptura_conPlantillas" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text=" Administración--&gt; Unidad Documental Compuesta - Subserie"></asp:Label>
</div>
    <script type="text/javascript">
        function prueba() {
            e.processOnServer = false;
        }

        // Validation via standard LinkButton
        function OnLinkButtonClick(s, e) {
            var validationGroup = '';
            //return RaisePageValidation(validationGroup);
            e.processOnServer = false;
        }

        function RaisePageValidation(validationGroup) {
            var validationProcs = [RaiseDxValidation, RaiseStandardValidation];
            var result = true;
            for (var index = 0; index < validationProcs.length; index++)
                result = validationProcs[index](validationGroup) && result;
            return result;
        }


    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <table style="width: 100%">
        <tr>
            <td style="vertical-align: top; height: 600px">
    <div>
        	    <asp:label id="lblTitle" runat="server" Font-Size="Small" 
                Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
    </div>

    
    
 <dxcp:ASPxCallbackPanel ID="ASPxCallbackPanel1" 
            ClientInstanceName="ASPxCallbackPanel1" 
            oncallback="ASPxCallbackPanel1_Callback" runat="server" Width="427px" 
            HideContentOnCallback="False" Height="175px">
        <PanelCollection>
        <dxp:PanelContent ID="PanelContent2" runat="server">
                <table>
                    <tr>
                        <td valign="top" style="width:534px">
                                <dxwtl:ASPxTreeList ID="aspxtreenivel" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dsArchivo" 
                    KeyFieldName="idDescripcion"   ClientInstanceName="treeList" 
                    ParentFieldName="idDocumentoPID"   EnableCallbacks="true" EnableViewState="false" 
                                    Width="350px"  >                                    
                     <SettingsBehavior AllowFocusedNode="true"  ProcessFocusedNodeChangedOnServer="false" AllowSort="False" 
                         />
                     <ClientSideEvents FocusedNodeChanged="function(s, e) {
                                                        ASPxCallbackPanel1.PerformCallback();
                             }" />
   
                 
                     <SettingsEditing Mode="EditFormAndDisplayNode"  EditFormColumnCount="1"/>
                    
                    <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar este nivel ?" 
                        RecursiveDeleteError="El nivel no puede ser borrado ya que tiene subniveles." />
                    <Columns>
                        <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
                            ReadOnly="True" Visible="False">
                            </dxwtl:TreeListTextColumn>
                            <dxwtl:TreeListTextColumn Caption="Nivel_Descripcion" FieldName="Nivel_Descripcion" 
                            ReadOnly="True" Visible="False">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Niveles" ReadOnly="True" VisibleIndex="0">
                            <EditFormSettings Visible="False" />
                            <DataCellTemplate>
                                <dxe:ASPxImage ID="ASPxImage2" runat="server" 
                                    ImageUrl="<%# GetNodeGlyph(Container) %>">
                                </dxe:ASPxImage>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListComboBoxColumn Caption="Tipo de nivel" FieldName="idNivel" 
                            VisibleIndex="1" Visible="False">
                            <PropertiesComboBox DataSourceID="dsNiveles" TextField="Nivel_Descripcion" 
                                ValueField="idNivel" ValueType="System.Int32">
                            </PropertiesComboBox>
                            <EditFormSettings Visible="True" />
                        </dxwtl:TreeListComboBoxColumn>
                        <dxwtl:TreeListTextColumn Caption="Descripción" FieldName="Descripcion" 
                            VisibleIndex="2" Width="300px">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListCommandColumn ShowNewButtonInHeader="True" VisibleIndex="3" 
                            ButtonType="Image" ToolTip="Botones de Editar, Agregar y Eliminar" >
                            <EditButton  Visible="True" Text="Editar" >
                                <Image Url="../App_Themes/Aqua/Editors/edtDropDownHottracked.png" AlternateText="Editar"></Image>
                             </EditButton>
                            
                            <NewButton Text="Agregar" Visible="True" >
                                <Image Url="../App_Themes/Aqua/Editors/fcaddhot.png"></Image>
                                
                            </NewButton>
                            <DeleteButton Visible="True" Text="Eliminar"   >
                                <Image Url="../App_Themes/Aqua/Editors/fcremovehot.png" 
                                    AlternateText="Eliminar" ></Image>
                            </DeleteButton>
                            <UpdateButton Text="Actualizar">
                                <Image AlternateText="Actualizar" Url="~/Images/correcto.GIF" />
                            </UpdateButton>
                            <CancelButton Text="Cancelar" Visible="True">
                                <Image AlternateText="Cancelar" Url="~/Images/cancelar.gif" />
                            </CancelButton>
                        </dxwtl:TreeListCommandColumn>
                    </Columns>
                </dxwtl:ASPxTreeList>
                        </td>
                              
                        <td valign="top">
                             <table border="0" cellpadding="1" cellspacing="1" style="width: 31%;">
                    <tr>
                        <td noWrap CssClass="DataList_Aqua" >
                                       <dxtc:ASPxPageControl ID="pgareas"  runat="server" AutoPostBack="false">
                                       <TabStyle Width="40px"></TabStyle>
                                       </dxtc:ASPxPageControl>
                      
                        </td>
                    </tr>
                     <tr>
                        <td>
                             <dxe:ASPxButton ID="aspxguardar" runat="server" Text="Guardar" 
                                 style="height: 24px" AutoPostBack="False" CausesValidation="false" 
                                 EnableViewState="False" UseSubmitBehavior="False" >
                              </dxe:ASPxButton>
                        </td>
                     </tr>
                     <tr>
                     <td>
                         &nbsp;</td>
                     </tr>
                </table>
     
    
      </td>
                    </tr>
                </table>
                  <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" 
        Text="" ForeColor="Red">
        </dxe:ASPxLabel>
         </dxp:PanelContent>
	</PanelCollection>
     </dxcp:ASPxCallbackPanel>
         <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
       



           </td>
        </tr>
    </table>
       
<div >
                                        

                                        <asp:ObjectDataSource ID="dsArchivo" runat="server" 
                                            SelectMethod="ListaArchivo_Descripciones" DeleteMethod="ABC_Archivo_Descripciones"          
                                            TypeName="Portalv9.WSArchivo.Service1" 
                                            InsertMethod="ABC_Archivo_Descripciones" 
                                            UpdateMethod="ABC_Archivo_Descripciones"  >
                                             <DeleteParameters>
                                                 <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
                                                <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                                                    Type="Int32" />
                                                <asp:Parameter Name="idDescripcion" Type="Int32" />
                                                
                                                 <asp:Parameter Name="Codigo_clasificacion" Type="String" />
                                                 <asp:Parameter Name="idNivel" Type="Int32" />
                                                 <asp:Parameter Name="idSerie" Type="Int32" />
                                                 <asp:Parameter Name="valuePath" Type="String" />
                                                 <asp:Parameter Name="idUnidadInstalacion" Type="Int32" />
                                                 <asp:Parameter Name="Descripcion" Type="String" />
                                                 <asp:Parameter Name="idTipoElemento" Type="Int32" />
                                                 <asp:Parameter Name="idDocumentoPID" Type="Int32" />
                                                 <asp:Parameter Name="Atributo" Type="Int32" />
                                                 <asp:Parameter Name="idArchivo_Fisico" Type="Int32" />
                                                 <asp:Parameter Name="idPlanta" Type="Int32" />
                                                 <asp:Parameter Name="idPasillo" Type="Int32" />
                                                 <asp:Parameter Name="idSeccion" Type="Int32" />
                                                 <asp:Parameter Name="idEstante" Type="Int32" />
                                                 <asp:Parameter Name="idBalda" Type="Int32" />
                                                 <asp:Parameter Name="unidad_Instalacion" Type="String" />
                                                 <asp:Parameter Name="unidad_instalacion_subdivision" Type="String" />
                                                 <asp:Parameter Name="unidad_instalacion_orden" Type="String" />
                                                
                                        </DeleteParameters>

                                             <UpdateParameters>
                                                 <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
                                                 <asp:Parameter DefaultValue="" Name="idArchivo" Type="Int32" />
                                                 <asp:Parameter Name="idDescripcion" Type="Int32" />
                                                 <asp:Parameter Name="Codigo_clasificacion" Type="String" />
                                                 <asp:Parameter Name="idNivel" Type="Int32" />
                                                 <asp:Parameter Name="idSerie" Type="Int32" />
                                                 <asp:Parameter Name="valuePath" Type="String" />
                                                 <asp:Parameter Name="idUnidadInstalacion" Type="Int32" />
                                                 <asp:Parameter Name="Descripcion" Type="String" />
                                                 <asp:Parameter Name="idTipoElemento" Type="Int32" />
                                                 <asp:Parameter Name="idDocumentoPID" Type="Int32" />
                                                 <asp:Parameter Name="Atributo" Type="Int32" />
                                                 <asp:Parameter Name="idArchivo_Fisico" Type="Int32" />
                                                 <asp:Parameter Name="idPlanta" Type="Int32" />
                                                 <asp:Parameter Name="idPasillo" Type="Int32" />
                                                 <asp:Parameter Name="idSeccion" Type="Int32" />
                                                 <asp:Parameter Name="idEstante" Type="Int32" />
                                                 <asp:Parameter Name="idBalda" Type="Int32" />
                                                 <asp:Parameter Name="unidad_Instalacion" Type="String" />
                                                 <asp:Parameter Name="unidad_instalacion_subdivision" Type="String" />
                                                 <asp:Parameter Name="unidad_instalacion_orden" Type="String" />
                                             </UpdateParameters>

                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                                                    Type="Int32" />
                                            </SelectParameters>
                                             <InsertParameters>
                                                 <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                                                 <asp:QueryStringParameter DefaultValue="" Name="idArchivo" 
                                                     QueryStringField="idArchivo" Type="Int32" />
                                                 <asp:Parameter Name="idDescripcion" Type="Int32" />
                                                 <asp:Parameter Name="Codigo_clasificacion" Type="String" />
                                                 <asp:Parameter Name="idNivel" Type="Int32" />
                                                 <asp:Parameter Name="idSerie" Type="Int32" />
                                                 <asp:Parameter Name="valuePath" Type="String" />
                                                 <asp:Parameter Name="idUnidadInstalacion" Type="Int32" />
                                                 <asp:Parameter Name="Descripcion" Type="String" />
                                                 <asp:Parameter Name="idTipoElemento" Type="Int32" />
                                                 <asp:Parameter Name="idDocumentoPID" Type="Int32" />
                                                 <asp:Parameter Name="Atributo" Type="Int32" />
                                                 <asp:Parameter Name="idArchivo_Fisico" Type="Int32" />
                                                 <asp:Parameter Name="idPlanta" Type="Int32" />
                                                 <asp:Parameter Name="idPasillo" Type="Int32" />
                                                 <asp:Parameter Name="idSeccion" Type="Int32" />
                                                 <asp:Parameter Name="idEstante" Type="Int32" />
                                                 <asp:Parameter Name="idBalda" Type="Int32" />
                                                 <asp:Parameter Name="unidad_Instalacion" Type="String" />
                                                 <asp:Parameter Name="unidad_instalacion_subdivision" Type="String" />
                                                 <asp:Parameter Name="unidad_instalacion_orden" Type="String" />
                                             </InsertParameters>
                                        </asp:ObjectDataSource>
        
                                           
                                        
        
                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                            SelectMethod="ListaNormas_Areas" TypeName="Portalv9.WSArchivo.Service1">
                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                                                    Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
        
                                                
                                        <asp:ObjectDataSource ID="dsNiveles" runat="server" 
                                            SelectMethod="ListaNormas_Niveles" TypeName="Portalv9.WSArchivo.Service1">
                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                                                    Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
        
                                                
</div>    
</asp:Content>

