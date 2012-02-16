<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_Catalogos_Datos.aspx.vb" Inherits="Portalv9.Wfrm_Catalogos_Datos" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>

<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitulo" runat="server" Text="Bienvenido" > </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <div>
    	    <dxe:ASPxHyperLink ID="Regresar" runat="server" 
                ImageUrl="~/Images/regresar.gif" NavigateUrl="~/Wfrm_Catalogos.aspx" />
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="542px" 
                Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br />
            <br />
    </div>
    <div>
         <dxwgv:ASPxGridView ID="aspxgdCatalogos" runat="server" 
             AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
             KeyFieldName="IDCatalogo_item" Width="559px">
              <SettingsBehavior ConfirmDelete="true" />
              <SettingsPager PageSize="15">
              </SettingsPager>
              <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar el registro?" />
             
              <Columns>
                  <dxwgv:GridViewDataTextColumn Caption="IDCatalogo" FieldName="IDCatalogo" 
                      ReadOnly="True" Visible="False" VisibleIndex="0">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="IDCatalogo_item" 
                      FieldName="IDCatalogo_item" ReadOnly="True" Visible="True" VisibleIndex="0">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="A1" FieldName="A1" Visible="False" 
                      VisibleIndex="2">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="A2" FieldName="A2" Visible="False" 
                      VisibleIndex="3">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="A3" FieldName="A3" Visible="False" 
                      VisibleIndex="4">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Valor" FieldName="Descripcion" 
                      VisibleIndex="0">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewCommandColumn VisibleIndex="1" Width="100px">
                            <EditButton Visible="True" Text="Editar">
                            </EditButton>
                            <NewButton Visible="True" Text="Agregar" >
                            </NewButton>                            
                            <DeleteButton Visible="True" Text="Eliminar">
                            </DeleteButton>
                            
                            <CancelButton Text="Cancelar">
                            </CancelButton>
                            <UpdateButton Text="Actualizar">
                            </UpdateButton>

                  </dxwgv:GridViewCommandColumn>
              </Columns>
    </dxwgv:ASPxGridView>     
       
         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
             SelectMethod="ListaCatalogo_Datos" TypeName="Portalv9.WSArchivo.Service1" 
             DeleteMethod="ABC_Catalogo_Datos" InsertMethod="ABC_Catalogo_Datos" 
             UpdateMethod="ABC_Catalogo_Datos">
             <DeleteParameters>
                 <asp:Parameter Name="op"  DefaultValue="1" Type="Object" />
                 <asp:QueryStringParameter DefaultValue="" Name="IDCatalogo" 
                     QueryStringField="IDCatalogo" Type="Int32" />
                 <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
                 <asp:Parameter Name="Descripcion" Type="String" />
                 <asp:Parameter Name="A1" Type="String" />
                 <asp:Parameter Name="A2" Type="String" />
                 <asp:Parameter Name="A3" Type="String" />
             </DeleteParameters>
             <UpdateParameters>
                 <asp:Parameter Name="op" DefaultValue="2" Type="Object" />
                 <asp:QueryStringParameter DefaultValue="" Name="IDCatalogo" 
                     QueryStringField="IDCatalogo" Type="Int32" />
                 <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
                 <asp:Parameter Name="Descripcion" Type="String" />
                 <asp:Parameter Name="A1" Type="String" DefaultValue="" />
                 <asp:Parameter Name="A2" Type="String" DefaultValue="" />
                 <asp:Parameter Name="A3" Type="String" DefaultValue="" />
             </UpdateParameters>
             <SelectParameters>
                 <asp:QueryStringParameter Name="IDCatalogo" QueryStringField="IDCatalogo" 
                     Type="Int32" />
             </SelectParameters>
             <InsertParameters>
                 <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                 <asp:QueryStringParameter DefaultValue="" Name="IDCatalogo" 
                     QueryStringField="IDCatalogo" Type="Int32" />
                 <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
                 <asp:Parameter Name="Descripcion" Type="String" />
                 <asp:Parameter Name="A1" Type="String" />
                 <asp:Parameter Name="A2" Type="String" />
                 <asp:Parameter Name="A3" Type="String" />
             </InsertParameters>
         </asp:ObjectDataSource>          
    </div>
 </asp:Panel> 
                   <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red">
                </cc1:msgbox>

</asp:Content>
