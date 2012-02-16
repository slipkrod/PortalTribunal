<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_Catalogos.aspx.vb" Inherits="Portalv9.Wfrm_Catalogos" %>

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
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br />
            <br />
    </div>
    <div>
         <dxwgv:ASPxGridView ID="aspxgdCatalogos" runat="server" 
             AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
             KeyFieldName="IDCatalogo" Width="559px">
              <SettingsBehavior ConfirmDelete="true" />
              <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar el registro ?" />
             
       <Columns>
                  <dxwgv:GridViewDataTextColumn Caption="IDCatalogo" FieldName="IDCatalogo" VisibleIndex="0" ReadOnly="True">
                      <EditFormSettings Visible="False" />
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Nombre" FieldName="Descripcion" VisibleIndex="1">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Clave1 Titulo" FieldName="A1_Titulo" 
                      VisibleIndex="2" Visible="False">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataSpinEditColumn Caption="Clave1 Ancho" FieldName="A1_Ancho" 
                      VisibleIndex="2" Visible="False">
                      <PropertiesSpinEdit DisplayFormatString="g">
                      </PropertiesSpinEdit>
                  </dxwgv:GridViewDataSpinEditColumn>
                  <dxwgv:GridViewDataCheckColumn Caption="Clave1 Visible" FieldName="A1_Visible" 
                      VisibleIndex="2" Visible="False">
                      <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                          ValueUnchecked="0">
                      </PropertiesCheckEdit>
                  </dxwgv:GridViewDataCheckColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Clave2 Titulo" FieldName="A2_Titulo" 
                      VisibleIndex="2" Visible="False">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataSpinEditColumn Caption="Clave2 Ancho" FieldName="A2_Ancho" 
                      VisibleIndex="2" Visible="False">
                      <PropertiesSpinEdit DisplayFormatString="g">
                      </PropertiesSpinEdit>
                  </dxwgv:GridViewDataSpinEditColumn>
                  <dxwgv:GridViewDataCheckColumn Caption="Clave2 Visible" FieldName="A2_Visible" 
                      VisibleIndex="2" Visible="False">
                      <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                          ValueUnchecked="0">
                      </PropertiesCheckEdit>
                  </dxwgv:GridViewDataCheckColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Clave3 Titulo" FieldName="A3_Titulo" 
                      VisibleIndex="2" Visible="False">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataSpinEditColumn Caption="Clave3 Ancho" FieldName="A3_Ancho" 
                      VisibleIndex="2" Visible="False">
                      <PropertiesSpinEdit DisplayFormatString="g">
                      </PropertiesSpinEdit>
                  </dxwgv:GridViewDataSpinEditColumn>
                  <dxwgv:GridViewDataCheckColumn Caption="Clave3 Visible" FieldName="A3_Visible" 
                      VisibleIndex="2" Visible="False">
                      <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                          ValueUnchecked="0">
                      </PropertiesCheckEdit>
                  </dxwgv:GridViewDataCheckColumn>
                  <dxwgv:GridViewDataComboBoxColumn caption="Tipo de campo" fieldname="Tipo_Dato" visibleindex="2">
                    <PropertiesComboBox valuetype="System.Int32">
                        <Items>
                            <dxe:ListEditItem text="Entero" value="7"></dxe:ListEditItem>
                            <dxe:ListEditItem text="Fecha" value="2"></dxe:ListEditItem>
                            <dxe:ListEditItem text="Texto" value="0"></dxe:ListEditItem>
                            <dxe:ListEditItem text="Seleccion Si/No" value="6"></dxe:ListEditItem>
                        </Items>
                    </PropertiesComboBox>
                </dxwgv:GridViewDataComboBoxColumn>                                                      
                <dxwgv:GridViewDataTextColumn Caption="# Valores Aceptados" 
                      FieldName="Valores_Aceptados" VisibleIndex="3" Visible="False">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewCommandColumn VisibleIndex="3"  >
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
                  <dxwgv:GridViewDataColumn Caption="Datos" VisibleIndex="4">
                  <EditFormSettings Visible="False" />
                  <DataItemTemplate>
                      <dxe:ASPxButton runat="server" ID="btnDatos" Text="Ver" CommandName="btnDatos" CommandArgument='<%# Bind("Descripcion") %>'>                      
                      </dxe:ASPxButton>
                  </DataItemTemplate> 
               </dxwgv:GridViewDataColumn>
           </Columns>
    </dxwgv:ASPxGridView>            
         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
             SelectMethod="ListaCatalogo" TypeName="Portalv9.WSArchivo.Service1" 
             DeleteMethod="ABC_Catalogo" InsertMethod="ABC_Catalogo" 
             UpdateMethod="ABC_Catalogo">
             <DeleteParameters>
                 <asp:Parameter Name="op"  DefaultValue="1" Type="Object" />
                 <asp:Parameter Name="IDCatalogo" Type="Int32" />
                 <asp:Parameter Name="Descripcion" Type="String" />
                 <asp:Parameter Name="A1_Titulo" Type="String" />
                 <asp:Parameter Name="A1_Ancho" Type="Int32" />
                 <asp:Parameter Name="A1_Visible" Type="Int32" />
                 <asp:Parameter Name="A2_Titulo" Type="String" />
                 <asp:Parameter Name="A2_Ancho" Type="Int32" />
                 <asp:Parameter Name="A2_Visible" Type="Int32" />
                 <asp:Parameter Name="A3_Titulo" Type="String" />
                 <asp:Parameter Name="A3_Ancho" Type="Int32" />
                 <asp:Parameter Name="A3_Visible" Type="Int32" />
                 <asp:Parameter Name="Tipo_Dato" Type="Int32" />     
                 <asp:Parameter Name="Valores_Aceptados" Type="Int32" />
             </DeleteParameters>
             <UpdateParameters>
                 <asp:Parameter Name="op" DefaultValue="2" Type="Object" />
                 <asp:Parameter Name="IDCatalogo" Type="Int32" DefaultValue="" />
                 <asp:Parameter Name="Descripcion" Type="String" />
                 <asp:Parameter Name="A1_Titulo" Type="String" />
                 <asp:Parameter Name="A1_Ancho" Type="Int32" />
                 <asp:Parameter Name="A1_Visible" Type="Int32" />
                 <asp:Parameter Name="A2_Titulo" Type="String" />
                 <asp:Parameter Name="A2_Ancho" Type="Int32" />
                 <asp:Parameter Name="A2_Visible" Type="Int32" />
                 <asp:Parameter Name="A3_Titulo" Type="String" />
                 <asp:Parameter Name="A3_Ancho" Type="Int32" />
                 <asp:Parameter Name="A3_Visible" Type="Int32" />
                 <asp:Parameter Name="Tipo_Dato" Type="Int32" />                 
                 <asp:Parameter Name="Valores_Aceptados" Type="Int32" />
             </UpdateParameters>
             <InsertParameters>
                 <asp:Parameter Name="op" DefaultValue="0" Type="Object" />
                 <asp:Parameter Name="IDCatalogo" Type="Int32" />
                 <asp:Parameter Name="Descripcion" Type="String" />
                 <asp:Parameter Name="A1_Titulo" Type="String" />
                 <asp:Parameter Name="A1_Ancho" Type="Int32" />
                 <asp:Parameter Name="A1_Visible" Type="Int32" />
                 <asp:Parameter Name="A2_Titulo" Type="String" />
                 <asp:Parameter Name="A2_Ancho" Type="Int32" />
                 <asp:Parameter Name="A2_Visible" Type="Int32" />
                 <asp:Parameter Name="A3_Titulo" Type="String" />
                 <asp:Parameter Name="A3_Ancho" Type="Int32" />
                 <asp:Parameter Name="A3_Visible" Type="Int32" />
                 <asp:Parameter Name="Tipo_Dato" Type="Int32" />
                 <asp:Parameter Name="Valores_Aceptados" Type="Int32" />
             </InsertParameters>
         </asp:ObjectDataSource> 
                  
    </div>
 </asp:Panel> 
<cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
</asp:Content>

