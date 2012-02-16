<%@ Page Language="vb" MasterPageFile="~/Masterpages/Adminmasteranidada.master" AutoEventWireup="false" CodeBehind="Wfrm_RelacionISADISAAR.aspx.vb" Inherits="Portalv9.Wfrm_RelacionISADISAAR" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <div>
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br />
            <br />
    </div>
    <div>
       <dxwgv:aspxgridview ID="gdrelacion" runat="server"   KeyFieldName="IDnr" OnRowDeleting="gdrelacion_RowDeleting"
           AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1">
                <SettingsBehavior ConfirmDelete="true"  />
                <SettingsEditing  Mode="EditFormAndDisplayRow"    />
                
              <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar ésta Relación ?" />
                          <Columns>
                 <dxwgv:GridViewDataTextColumn  Caption="ID"  FieldName="IDnr" ReadOnly="false" VisibleIndex="0" Visible="false">
                  </dxwgv:GridViewDataTextColumn>
                 <dxwgv:GridViewDataTextColumn  Caption="IDISAD"  FieldName="IDISAD" ReadOnly="false" VisibleIndex="0">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="IDISAAR" FieldName="IDISAAR" ReadOnly="false" VisibleIndex="1">
                  </dxwgv:GridViewDataTextColumn>
                              
                  <dxwgv:GridViewDataTextColumn Caption="Nombre" FieldName="Descripcion" ReadOnly="false" VisibleIndex="2">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="3"  >
                            <NewButton Visible="true" Text="Agregar relación" >
                   </NewButton>
                            
                  </dxwgv:GridViewCommandColumn>
                  <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="4">
                            
                            <EditButton Visible="True" Text="Editar">
                            </EditButton>
                            <CancelButton Visible="True" Text="Cancelar">
                            </CancelButton>
                            <UpdateButton Visible="True" Text="Actualizar">
                            </UpdateButton>
                     </dxwgv:GridViewCommandColumn>
                 <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex="5">
                    <DeleteButton Text="Eliminar" Visible="true"></DeleteButton>
                  </dxwgv:GridViewCommandColumn>
                       
           </Columns>
                          <Templates>
                      <EditForm>
                      
                          <dxe:ASPxLabel ID="lblISAD" runat="server" Text="Norma ISAD">
                          </dxe:ASPxLabel>
                          <dxe:ASPxComboBox ID="cmbISAD" runat="server" DropDownStyle="DropDown"                                                       
                                   TextField="Descripcion" ValueField="folio_norma"   DataSourceID="ObjectDataSource2" SelectedIndex="0" >
                          </dxe:ASPxComboBox>
                           <dxe:ASPxLabel ID="lblISAAR" runat="server" Text="Norma ISAAR">
                          </dxe:ASPxLabel>
                          <dxe:ASPxComboBox ID="cmbISAAR" runat="server" DropDownStyle="DropDown"                                                       
                                   TextField="Descripcion" ValueField="folio_norma"   DataSourceID="ObjectDataSource3" SelectedIndex="0" >
                          </dxe:ASPxComboBox>
                          <table>
                                        <tr>
                                          <td align="right">
                                            <dxe:ASPxButton ID="Btnactualizar" runat="server" AutoPostBack="False" Text="Actualizar" ClientInstanceName="Btnactualizar" 
                                                                                    UseSubmitBehavior="False" Visible=false onclick="btnActualizar_Click" >   
                                                                                  
                                                                             </dxe:ASPxButton>
                                              <dxe:ASPxButton ID="btnInsertar" runat="server" AutoPostBack="False" Text="Insertar" ClientInstanceName="btnAceptar" UseSubmitBehavior="False" onclick="btnInsertar_Click"  >   
                                              </dxe:ASPxButton>
                                          </td>
                                          <td align="right">
                                            <dxwgv:ASPxGridViewTemplateReplacement ID="Cancel"  runat="server" ReplacementType="EditFormCancelButton" />
                                          </td>
                                        </tr>
                                   </table>
                      </EditForm>
                  </Templates>
    </dxwgv:aspxgridview>  
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="Lista_Normas_relacion" TypeName="Portalv9.WSArchivo.Service1">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="Lista_Normas_ISAD" TypeName="Portalv9.WSArchivo.Service1">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
            SelectMethod="Lista_Normas_ISAAR" TypeName="Portalv9.WSArchivo.Service1">
        </asp:ObjectDataSource>
    </div>
 </asp:Panel> 
                   <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red">
                </cc1:msgbox>
                
                
                     
                
  
 
                        
     
  

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder5" Runat="Server">
    
</asp:Content>
