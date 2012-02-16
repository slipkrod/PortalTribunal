<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_Archivo_Fisico_Unidades.aspx.vb" Inherits="Portalv9.Wfrm_Archivo_Fisico_Unidades" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>


<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitulo" runat="server" Text="Bienvenido" > </asp:Label>
</div>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
      <div>
<asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Archivo Físico</asp:label>
            <br />
            <br />
                 <dxwgv:ASPxGridView ID="GridArchivoElementos" runat="server" 
            AutoGenerateColumns="False" DataSourceID="dsArchivoFisico" 
            Width="630px" KeyFieldName="idUnidad_medida">
             <SettingsBehavior ConfirmDelete="true" />
              <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar éste elemento ?" />
                     <Columns>
                         <dxwgv:GridViewDataTextColumn Caption="Clave" FieldName="idUnidad_medida" 
                             Name="idUnidad_medida" VisibleIndex="0">
                         </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewDataTextColumn Caption="Unidad" 
                             FieldName="Unidad_medida_descripcion" Name="Unidad_medida_descripcion" 
                             VisibleIndex="1">
                         </dxwgv:GridViewDataTextColumn>
                           <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="4" Width="50px"  >
                            <NewButton Visible="true" Text="Agregar" ></NewButton>                            
                  </dxwgv:GridViewCommandColumn>
                  <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="5" Width="50px" 
                             Visible="False">                            
                            <EditButton Visible="True" Text="Editar">
                            </EditButton>
                            <CancelButton Visible="True" Text="Cancelar">
                            </CancelButton>
                            <UpdateButton Visible="True" Text="Actualizar">
                            </UpdateButton>
                     </dxwgv:GridViewCommandColumn>
                 <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex="3" Width="50px"> <DeleteButton Text="Eliminar" Visible="true"></DeleteButton></dxwgv:GridViewCommandColumn>                         
                       <%--  
                         <dxwgv:GridViewCommandColumn VisibleIndex="2" Width="160px">
                             <EditButton Text="Editar" Visible="True">
                            </EditButton>
                            <NewButton Text="Agregar" Visible="True">
                            </NewButton>
                            <DeleteButton Text="Eliminar" Visible="True">
                            </DeleteButton>
                            <CancelButton Text="Eliminar" Visible="True">
                            </CancelButton>
                         </dxwgv:GridViewCommandColumn>--%>
                     </Columns>
        </dxwgv:ASPxGridView>
        <dxe:ASPxLabel ID="ASPxLabel1" runat="server" ClientInstanceName="label" 
        Text="" ForeColor="Red">
        </dxe:ASPxLabel>
                   <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red">
                </cc1:msgbox>
    </div>
    <asp:ObjectDataSource ID="dsArchivoFisico" runat="server" 
        SelectMethod="Lista_Archivo_Fisico_Unidades" 
        TypeName="Portalv9.WSArchivo.Service1" 
        UpdateMethod="ABC_Archivo_Fisico_Unidades" 
        DeleteMethod="ABC_Archivo_Fisico_Unidades" 
        InsertMethod="ABC_Archivo_Fisico_Unidades">
        <DeleteParameters>
            <asp:Parameter Name="op" Type="Object" defaultvalue="1" />
            <asp:Parameter Name="idUnidad_medida" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="Unidad_medida_descripcion" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="op" Type="Object" defaultvalue="2"/>
            <asp:Parameter Name="idUnidad_medida" Type="String" />
            <asp:Parameter Name="Unidad_medida_descripcion" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="op" Type="Object" defaultvalue="0"/>
            <asp:Parameter Name="idUnidad_medida" Type="String"/>
            <asp:Parameter Name="Unidad_medida_descripcion" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    

</asp:Content>



