<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="Wfrm_PlantillaCapturaEspecial.aspx.vb" Inherits="Portalv9.Wfrm_PlantillaCapturaEspecial" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div>
        	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" 
                Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
                <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>
    <div >
    <table>
        <tr>
          <td valign="top" style="width: 534px" >
                <dxwtl:ASPxTreeList ID="aspxtreenivel" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
                    KeyFieldName="idDescripcion"   ClientInstanceName="treeList" 
                    ParentFieldName="idDocumentoPID"  
                    EnableCallbacks="False" Width="16px"  >                                    
                     <SettingsBehavior AllowFocusedNode="true" 
                        ProcessFocusedNodeChangedOnServer="true" AllowSort="False" 
                         AutoExpandAllNodes="True"/>
                 
                     <SettingsEditing Mode="EditFormAndDisplayNode" />
                    
                    <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar este nivel ?" 
                        RecursiveDeleteError="El nivel no puede ser borrado ya que tiene subniveles." />
                      <templates>
                          <editform>
                                                  <dxe:aspxLabel ID="Label2" runat="server" Text="Tipo de Nivel"></dxe:aspxLabel>
                                                    <dxe:ASPxComboBox ID="dlNiveles" runat="server" DropDownStyle="DropDown"                                                         
                                                    
                                                    TextField="Nivel_Descripcion" ValueField="idNivel"
                                                    DataSourceID="CatTipoNivel" ValueType="System.String" >
                                                        
                                                    </dxe:ASPxComboBox>
                                                    <dxe:aspxLabel ID="AspxLabel1" runat="server" Text="Nombre"></dxe:aspxLabel>
                                                    <dxe:ASPxTextBox ID="txtDescripcion" runat="server" 
                                                        EnableClientSideAPI="True" >
                                                             <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True">
                                                                <RequiredField IsRequired="True" ErrorText="El nombre debe ser capturado"></RequiredField>
                                                            </ValidationSettings>
                                                    </dxe:ASPxTextBox>
                                                     <table>
                                                                <tr>
                                                                    
                                                                            <td align="right">
                                                                                <dxe:ASPxButton ID="btnAceptar" runat="server" AutoPostBack="False" 
                                                                                 Text="Aceptar" 
                                                                                 ClientInstanceName="btnAceptar" 
                                                                                    UseSubmitBehavior="False" onclick="btnAceptar_Click" >   
                                                                                  
                                                                             </dxe:ASPxButton>
                                                                                
                                                                         
                                                                                <dxe:ASPxButton ID="btnActualizar" runat="server" AutoPostBack="False" 
                                                                                    onclick="btnActualizar_Click" Text="Actualizar">
                                                                                </dxe:ASPxButton>
                                                                                
                                                                         
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                    
                                                    <div>
                                                        <dxwtl:ASPxTreeListTemplateReplacement ID="Cancel" runat="server" 
                                                            ReplacementType="CancelButton" />
                                                   
                                                    </div>
                                                </editform>
                      </templates>
                    <Columns>
                        <dxwtl:TreeListTextColumn Caption="idDescripcion" FieldName="idDescripcion" 
                            ReadOnly="True" Visible="False">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nivel" FieldName="idNivel" ReadOnly="True" 
                            Visible="False">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Niveles" VisibleIndex="0">
                            <DataCellTemplate>
                                <dxe:ASPxImage ID="ASPxImage2" runat="server" 
                                    ImageUrl="<%# GetNodeGlyph(Container) %>">
                                </dxe:ASPxImage>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Descripción" FieldName="Descripcion" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="valuepath" FieldName="valuepath" 
                            ReadOnly="True" Visible="False">
                        </dxwtl:TreeListTextColumn>
                      
                        <%--   <dxwtl:TreeListCommandColumn ShowNewButtonInHeader="True" VisibleIndex="2" 
                            ButtonType="Image" ToolTip="Botones de Editar, Agregar y Eliminar" >
                            <EditButton  Visible="True" >
                                <Image Url="../App_Themes/Aqua/Editors/edtDropDownHottracked.png" AlternateText="Editar"></Image>
                             </EditButton>
                            
                            <NewButton Text="Agregar" Visible="True" >
                                <Image Url="../App_Themes/Aqua/Editors/fcaddhot.png"></Image>
                                
                            </NewButton>
                            <DeleteButton Visible="True"   >
                                <Image Url="../App_Themes/Aqua/Editors/fcremovehot.png" 
                                    AlternateText="Eliminar" ></Image>
                            </DeleteButton>
                            <CancelButton Text="Eliminar" Visible="True">
                            </CancelButton>
                        </dxwtl:TreeListCommandColumn>--%>
                       
                    </Columns>
                   
                   
                </dxwtl:ASPxTreeList>
          
    </td>
 
       
        <td valign="top">
                <table border="0" cellpadding="1" cellspacing="1" style="width: 31%;">
                    <tr>
                        <td>
                <asp:DataList ID="dlAreas" runat="server" 
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="2" DataKeyField="idArea" 
                         Font-Bold="False" Font-Italic="False" 
                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                        GridLines="Both" Height="20px" HorizontalAlign="Left" 
                        RepeatDirection="Horizontal" SelectedIndex="0" style="margin-top: 0px" 
                        Width="509px" RepeatColumns="3" DataSourceID="ObjectDataSource2" >
                                               <EditItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                   Font-Strikeout="False" Font-Underline="False" ForeColor="Black" 
                                                   HorizontalAlign="Left" />
                                               <AlternatingItemStyle Font-Bold="False" Font-Italic="False" 
                                                   Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                   ForeColor="Black" HorizontalAlign="Left" />
                                               <ItemStyle Font-Bold="False" Font-Italic="False" 
                            Font-Names="Arial" Font-Overline="False" Font-Size="8pt" Font-Strikeout="False" 
                            Font-Underline="False" HorizontalAlign="Left" 
                            VerticalAlign="Top" CssClass="DataList_Aqua" ForeColor="Black" />
                                                 <SeparatorStyle 
                            BorderWidth="2px" ForeColor="Black" />
                                                <SelectedItemStyle Font-Bold="False" Font-Italic="False" 
                            Font-Names="Arial" Font-Overline="False" Font-Size="8pt" Font-Strikeout="False" 
                            Font-Underline="False" HorizontalAlign="Left"     
                            VerticalAlign="Top" CssClass="DataList_Aqua_Sel" ForeColor="Black" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Select" 
                                            Text='<%# DataBinder.Eval(Container, "DataItem.folio_norma") %>' 
                                                        CausesValidation="False"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                        CommandName="Select" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.Area_descripcion") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:DataList>
                          
                   
                        </td>
                    </tr>
                    <tr>
                        <td style=" HEIGHT: 210px" vAlign="top" noWrap 
                                        align="left" width="375">
                            <dxp:ASPxPanel ID="PnlElementos" runat="server" Width="509px">
                    <Border BorderColor="#C9D7DD" BorderStyle="Solid" BorderWidth="1px" />
                    <PanelCollection>
                    <dxp:PanelContent ID="PanelContent1" runat="server"></dxp:PanelContent>
                </PanelCollection>
                </dxp:ASPxPanel>
                        </td>
                    </tr>
                 <%--   <tr>
                        <td>
                            <dxe:ASPxButton ID="btnGuardar" runat="server" Text="Guardar">
                            </dxe:ASPxButton>
                        </td>
                    </tr>--%>
                </table>
                          
                   
    </td>
    </tr>
        </table>
         <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
         <asp:Label ID="lblidArchivo" runat="server" Visible="False"></asp:Label>
   </div>

<div>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                            SelectMethod="ListaArchivo_Descripciones" DeleteMethod="Archivo_Descripciones_Del"          
                                            TypeName="Portalv9.WSArchivo.Service1" 
                                            UpdateMethod="ABC_Archivo_Descripciones"  >
                                             <DeleteParameters>
                                                <asp:QueryStringParameter Name="idArchivo"  QueryStringField="idArchivo" 
                                                    Type="Int32" />
                                                <asp:Parameter Name="idDescripcion" Type="Int32" />
                                                
                                        </DeleteParameters>

                                             <UpdateParameters>
                                                 <asp:Parameter Name="op" Type="Object" DefaultValue="2" />
                                                 <asp:Parameter Name="idArchivo" Type="Int32" />
                                                 <asp:Parameter Name="idDescripcion" Type="Int32" />
                                                 <asp:Parameter Name="Codigo_clasificacion" Type="String" />
                                                 <asp:Parameter Name="idNivel" Type="Int32" />
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
                                        </asp:ObjectDataSource>
        
                                        
        
                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                            SelectMethod="ListaNormas_Areas_Especial" TypeName="Portalv9.WSArchivo.Service1">
                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                                                    Type="Int32" />
                                                 <asp:QueryStringParameter Name="idplantilla" QueryStringField="idplantilla" 
                                                    Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
        
                                                
                                        <asp:ObjectDataSource ID="CatTipoNivel" runat="server" 
                                            SelectMethod="ListaNormas_Niveles" TypeName="Portalv9.WSArchivo.Service1">
                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                                                    Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
        
                                                
    </div>

</asp:Content>
