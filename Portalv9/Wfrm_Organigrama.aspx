<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_Organigrama.aspx.vb" MasterPageFile="~/Masterpages/Adminmaster2col.master" Inherits="Portalv9.Wfrm_Organigrama" %>

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
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div>
        	    <asp:label id="lblTitle" runat="server" Font-Size="Small" 
                Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
    </div>

    <div >
    
                <table>
                    <tr>
                        <td valign="top" style="width:334px">
                        
                            <dxwgv:ASPxGridView ID="gdnivel" runat="server" AutoGenerateColumns="false" EnableCallbacks="False" KeyFieldName="idDescripcion" DataSourceID="ObjectDataSource1" >
                            <SettingsBehavior AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="true"  />
                             <templates>
                                <editform>
                                 <dxe:aspxLabel ID="Label2" runat="server" Text="Tipo de Nivel"></dxe:aspxLabel>
                                 <dxe:ASPxComboBox ID="cmbnivel" runat="server" DropDownStyle="DropDown"                                                       
                                   TextField="Nivel_Descripcion" ValueField="idNivel"   DataSourceID="ObjectDataSource3" SelectedIndex="0" >
                                 </dxe:ASPxComboBox>
                                 <dxe:aspxLabel ID="AspxLabel1" runat="server" Text="Nombre"></dxe:aspxLabel>
                                 <dxe:ASPxTextBox ID="txtDescripcion" runat="server" EnableClientSideAPI="True"  EnableDefaultAppearance="True"  Text='<%# Eval("Descripcion") %>'>
                                      <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True">
                                              <RequiredField IsRequired="True" ErrorText="El nombre debe ser capturado"></RequiredField>
                                       </ValidationSettings>
                                  </dxe:ASPxTextBox>
                                   <table>
                                        <tr>
                                          <td align="right">
                                            <dxe:ASPxButton ID="Btnactualizar" runat="server" AutoPostBack="False" Text="Actualizar" ClientInstanceName="btnUpload" 
                                                                                    UseSubmitBehavior="False" OnClick="Btnactualizar_Click">   
                                                                                  
                                                                             </dxe:ASPxButton>
                                              <dxe:ASPxButton ID="btnAceptar" runat="server" AutoPostBack="False" Text="Insertar" ClientInstanceName="btnAceptar" UseSubmitBehavior="False" onclick="btnAceptar_Click" >   
                                              </dxe:ASPxButton>
                                          </td>
                                            <td align="right">
                                                <dxwgv:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement1"  runat="server" ReplacementType="EditFormCancelButton" />
                                            </td>
                                        </tr>
                                   </table>
                                   <div>
                                      <dxwtl:ASPxTreeListTemplateReplacement ID="Cancel"  runat="server"  ReplacementType="CancelButton" />
                                   </div>
                         </editform>
                            </templates>
                            <Columns>
                                 <dxwgv:GridViewDataTextColumn  Caption="Norma" FieldName="idDocumentoPID" 
                                    ReadOnly="True" Visible="False">
                                 </dxwgv:GridViewDataTextColumn>
                                 <dxwgv:GridViewDataTextColumn  Caption="Descripcion" FieldName="Nivel_Descripcion" 
                                    ReadOnly="True" Visible="False">
                                 </dxwgv:GridViewDataTextColumn>
                                 <dxwgv:GridViewDataTextColumn Caption="Nivel" FieldName="idNivel" ReadOnly="True" 
                                    Visible="False">
                                 </dxwgv:GridViewDataTextColumn>
                                 <dxwgv:GridViewDataTextColumn Caption="Descripción" FieldName="Descripcion" Width="100px" 
                                    VisibleIndex="1">
                                 </dxwgv:GridViewDataTextColumn>
                                 <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="2" >
                                      <NewButton Visible="true" Text="Agregar" >
                                      </NewButton>
                                  </dxwgv:GridViewCommandColumn>
                                 <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="3">
                                    <EditButton Visible="True" Text="Editar">
                                    </EditButton>
                                    <CancelButton Visible="True" Text="Cancelar">
                                    </CancelButton>
                                    <UpdateButton Visible="True" Text="Actualizar">
                                    </UpdateButton>
                             </dxwgv:GridViewCommandColumn>
                 <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex=4> <DeleteButton Text="Eliminar" Visible="true"></DeleteButton></dxwgv:GridViewCommandColumn>
                                 
                            </Columns>
                            </dxwgv:ASPxGridView>
                              
                        </td>
                              
                        <td valign="top">
                             <table border="0" cellpadding="1" cellspacing="1" style="width: 31%;">
             <tr>
                        <td noWrap CssClass="DataList_Aqua" >
                                       <asp:DataList ID="dlAreas" runat="server" 
                        BorderStyle="Solid" BorderWidth="3px" CellPadding="2" DataKeyField="idArea" 
                         Font-Bold="False" Font-Italic="False" 
                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                        GridLines="Both" Height="25px" HorizontalAlign="Left" 
                        RepeatDirection="Horizontal" SelectedIndex="0" style="margin-top: 0px" 
                        Width="509px" DataSourceID="ObjectDataSource2" RepeatColumns="4" >
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
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" BorderWidth="10px" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                                        CommandName="Select" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.folio_norma") %>'></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                        CommandName="Select" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.Area_descripcion") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:DataList>
                      
                        </td>
                    </tr>
                    <tr>
                        <TD style=" HEIGHT: 210px" vAlign="top" noWrap 
                                        align="left" width="375">
                                     <dxp:ASPxPanel ID="PnlElementos" runat="server" Width="500px">
                                    <Border BorderColor="#C9D7DD" BorderStyle="Solid" />
                                     <PanelCollection>
                                            <dxp:PanelContent ID="PanelContent1" runat="server"></dxp:PanelContent>
                                    </PanelCollection>
                                    
                                </dxp:ASPxPanel>
                        </td>
                     </tr>
                     <tr>
                        <td>
                             <dxe:ASPxButton ID="aspxguardar" runat="server" Text="Guardar" 
                                 style="height: 24px">
                              </dxe:ASPxButton>
                        </td>
                     </tr>
                </table>
     
    
      </td>
                    </tr>
                </table>
         <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
         <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" 
        Text="" ForeColor="Red">
        </dxe:ASPxLabel>
</div>

<div >
        
                                        
        
                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                            SelectMethod="ListaNormas_Areas" TypeName="Portalv9.WSArchivo.Service1">
                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                                                    Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
        
                                                
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                            SelectMethod="ListaArchivo_Descripciones" DeleteMethod="Archivo_Descripciones_Del"          
                                            TypeName="Portalv9.WSArchivo.Service1"  >
                                             <DeleteParameters>
                                                <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                                                    Type="Int32" />
                                                <asp:Parameter Name="idDescripcion" />
                                                
                                        </DeleteParameters>

                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                                                    Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
        
                                        
        
                                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                            SelectMethod="ListaNormas_Niveles" TypeName="Portalv9.WSArchivo.Service1">
                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                                                    Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
        
                                                
        
    </div>
    
</asp:Content>
