<%@ Page Language="vb" MasterPageFile="~/Masterpages/Adminmasteranidada.master" AutoEventWireup="false" CodeBehind="Wfrm_Normas_Elementos.aspx.vb" Inherits="Portalv9.Wfrm_Normas_Elementos" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <div>
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="450px" 
                Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br />
            <br />
    </div>
    <div>
             
        <dxwgv:ASPxGridView ID="aspxgdelementos" runat="server"  ClientInstanceName="aspxgdelementos"
            KeyFieldName="idElemento" OnRowUpdating="aspxgelementos_RowUpdating" 
            OnRowInserting="aspxgdelementos_RowInserting" 
            OnRowDeleting="aspxgdelementos_RowDeleting" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" OnCustomJSProperties="aspxgdelementos_CustomJSProperties">
                      <ClientSideEvents EndCallback="function(s, e) {
                       Error.SetText(aspxgdelementos.cpmensaje);
                        }" />
                <SettingsBehavior ConfirmDelete="true" />
              <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar éste elemento ?" />
          <Columns>
                   <dxwgv:GridViewDataTextColumn  Caption="IDNorma" Visible="false"  FieldName="idNorma" ReadOnly="True" VisibleIndex="0">
                                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn  Caption="IDArea"  Visible="false" FieldName="idArea" ReadOnly="True" VisibleIndex="0">
                  </dxwgv:GridViewDataTextColumn>
                   <dxwgv:GridViewDataTextColumn  Caption="IDElemento"  FieldName="idElemento" Visible="false" ReadOnly="True" VisibleIndex="0">
                  </dxwgv:GridViewDataTextColumn>
                   <dxwgv:GridViewDataTextColumn  Caption="ID"  FieldName="folio_norma"  VisibleIndex="1">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Nombre" FieldName="Elemento_descripcion" ReadOnly="false" VisibleIndex="2">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="3"  >
                            <NewButton Visible="true" Text="Agregar elemento" >
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
                 <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex=5> <DeleteButton Text="Eliminar" Visible="true"></DeleteButton></dxwgv:GridViewCommandColumn>
               
              
                   
           </Columns>
        </dxwgv:ASPxGridView>
               
       
        <asp:ObjectDataSource ID="dsElementos" runat="server" 
            SelectMethod="ListaNormas_Elementos" 
            TypeName="Portalv9.WSArchivo.Service1">
            <SelectParameters>
                <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                    Type="Int32" />
                <asp:QueryStringParameter Name="idArea" QueryStringField="idArea" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
               
       
    </div>
    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red">
                </cc1:msgbox>
        <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" 
            ForeColor="Red" Text="">
        </dxe:ASPxLabel>
 </asp:Panel>
 
 
                   
                
                
  
                
                        
     
  

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder5" Runat="Server">
    
</asp:Content>
