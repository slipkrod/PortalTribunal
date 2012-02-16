<%@ Page Language="vb" MasterPageFile="~/Masterpages/Adminmasteranidada.master" AutoEventWireup="false" CodeBehind="Wfrm_ISO3166.aspx.vb" Inherits="Portalv9.Wfrm_ISO3166" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <div>
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br />
            <br />
    </div>
    <div>
        
         <dxwgv:aspxgridview ID="aspxgdiso3166" runat="server"   KeyFieldName="idFolio" 
             OnRowUpdating="aspxgdiso3166_RowUpdating"    
             OnRowInserting="aspxgdiso3166_RowInserting"     
             OnRowDeleting="aspxgdiso3166_RowDeleting"     
             OnPageIndexChanged="aspxgdiso3166_PageIndexChanged" AutoGenerateColumns="False" 
             DataSourceID="ObjectDataSource1">
              <SettingsBehavior ConfirmDelete="true" />
              <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar ésta ISO ?" />
                 <Columns>
                   <dxwgv:GridViewDataTextColumn  Caption="ID"  FieldName="idFolio" ReadOnly="True" VisibleIndex="0">
                  </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn  Caption="Clave númerica"  FieldName="Clave_num" ReadOnly="false" VisibleIndex="1">
                    <PropertiesTextEdit>
                     <ClientSideEvents KeyPress="function numeros(){var key=window.event.keyCode;if (key < 48 || key > 57){window.event.keyCode=0;}}"/>
                    </PropertiesTextEdit>
                   
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Alfa 2" FieldName="A2" ReadOnly="false" VisibleIndex="2">
                  </dxwgv:GridViewDataTextColumn>
                   <dxwgv:GridViewDataTextColumn Caption="Alfa 3" FieldName="A3" ReadOnly="false" VisibleIndex="3">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Nombre" FieldName="Clave_descripcion" ReadOnly="false" VisibleIndex="4">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="5"  >
                            <NewButton Visible="true" Text="Agregar norma" >
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
                 <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex="7">
                    <DeleteButton Text="Eliminar" Visible="true"></DeleteButton>
                  </dxwgv:GridViewCommandColumn>
                       
           </Columns>
    </dxwgv:aspxgridview>
         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
             SelectMethod="Lista_ISO_3166" TypeName="Portalv9.WSArchivo.Service1">
         </asp:ObjectDataSource>
    </div>
 </asp:Panel> 
                   <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red">
                </cc1:msgbox>
                
                
                     
                
  
 
                        
     
  

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder5" Runat="Server">
    
</asp:Content>
