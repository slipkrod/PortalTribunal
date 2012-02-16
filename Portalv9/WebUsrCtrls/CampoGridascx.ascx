<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoGridascx.ascx.vb" Inherits="Portalv9.CampoGridascx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<style type="text/css">

        .style1
        {
        width: 200px;
        height: 24px;
    }
        .style2
    {
        height: 24px;
         width: 100px;
    }
</style>
<table style="vertical-align: top">
    <tr>
        <td class="style1">
            <dxe:ASPxLabel  ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
        <td class="style1">
            <dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" 
                Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
      </tr> <tr>
        <td class="style2">
            <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
                AutoGenerateColumns="False" DataSourceID="dsValores" KeyFieldName="idFolio" 
                Width="355px">
                <Columns>
                    <dxwgv:GridViewDataTextColumn Caption="idNorma" FieldName="idNorma" 
                        Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idArea" FieldName="idArea" 
                        Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idElemento" FieldName="idElemento" 
                        Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idIndice" FieldName="idIndice" 
                        Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" 
                        Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idDescripcion" FieldName="idDescripcion" 
                        Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idFolio" FieldName="idFolio" 
                        Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" 
                        Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="Indice_Tipo" FieldName="Indice_Tipo" 
                        Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataComboBoxColumn Caption="Campo" 
                        FieldName="relacion_con_normaPID" VisibleIndex="0">
                        <PropertiesComboBox DataSourceID="dsCatalogoDatos" ValueField="IDCatalogo_item" 
                            ValueType="System.Int32" TextField="Descripcion" 
                            EnableIncrementalFiltering="True">
                        </PropertiesComboBox>
                    </dxwgv:GridViewDataComboBoxColumn>
                    <dxwgv:GridViewDataTextColumn Caption="Valor" FieldName="Valor" 
                        VisibleIndex="1">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewCommandColumn VisibleIndex="2">
                        <EditButton Visible="True">
                        </EditButton>
                        <NewButton Visible="True">
                        </NewButton>
                        <DeleteButton Visible="True">
                        </DeleteButton>
                    </dxwgv:GridViewCommandColumn>
                </Columns>
            </dxwgv:ASPxGridView>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <dxe:ASPxLabel ID="idNorma" runat="server">
            </dxe:ASPxLabel>
            <dxe:ASPxLabel ID="idArea" runat="server">
            </dxe:ASPxLabel>
            <dxe:ASPxLabel ID="idElemento" runat="server" Visible="False">
            </dxe:ASPxLabel>
            <dxe:ASPxLabel ID="idIndice" runat="server">
            </dxe:ASPxLabel>
            <dxe:ASPxLabel ID="idArchivo" runat="server">
            </dxe:ASPxLabel>
            <dxe:ASPxLabel ID="idDescripcion" runat="server">
            </dxe:ASPxLabel>
            <dxe:ASPxLabel ID="idNivel" runat="server">
            </dxe:ASPxLabel>
            <dxe:ASPxLabel ID="Indice_Tipo" runat="server">
            </dxe:ASPxLabel>
          </td>
    </tr>
</table>
                                        <asp:ObjectDataSource ID="dsCatalogoDatos" runat="server" 
                                            SelectMethod="ListaCatalogo_Datos"          
                                            
    TypeName="Portalv9.WSArchivo.Service1" 
    OldValuesParameterFormatString="original_{0}"  >

                                            <SelectParameters>
                                                <asp:Parameter Name="IDCatalogo" Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
        
                                        
        
                                        <asp:ObjectDataSource ID="dsValores" runat="server" 
                                            SelectMethod="ListaArchivo_indice" DeleteMethod="ABC_Archivo_indice"          
                                            
    TypeName="Portalv9.WSArchivo.Service1" InsertMethod="ABC_Archivo_indice" 
    UpdateMethod="ABC_Archivo_indice"  >
                                             <DeleteParameters>
                                                 <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
                                                 <asp:Parameter Name="idNorma" Type="Int32" />
                                                 <asp:Parameter Name="idArea" Type="Int32" />
                                                 <asp:Parameter Name="idElemento" Type="Int32" />
                                                 <asp:Parameter Name="idIndice" Type="Int32" />
                                                 <asp:Parameter Name="idArchivo" Type="Int32" />
                                                 <asp:Parameter Name="idDescripcion" Type="Int32" />
                                                 <asp:Parameter Name="idFolio" Type="Int32" />
                                                 <asp:Parameter Name="idNivel" Type="Int32" />
                                                 <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                                                 <asp:Parameter Name="Valor" Type="String" />
                                                 <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                                             </DeleteParameters>
                                             <UpdateParameters>
                                                 <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
                                                 <asp:Parameter Name="idNorma" Type="Int32" />
                                                 <asp:Parameter Name="idArea" Type="Int32" />
                                                 <asp:Parameter Name="idElemento" Type="Int32" />
                                                 <asp:Parameter Name="idIndice" Type="Int32" />
                                                 <asp:Parameter Name="idArchivo" Type="Int32" />
                                                 <asp:Parameter Name="idDescripcion" Type="Int32" />
                                                 <asp:Parameter Name="idFolio" Type="Int32" />
                                                 <asp:Parameter Name="idNivel" Type="Int32" />
                                                 <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                                                 <asp:Parameter Name="Valor" Type="String" />
                                                 <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                                             </UpdateParameters>

                                            <SelectParameters>
                                                <asp:Parameter Name="idNorma" Type="Int32" />
                                                <asp:Parameter Name="idArea" Type="Int32" />
                                                <asp:Parameter Name="idElemento" Type="Int32" />
                                                <asp:Parameter Name="idIndice" Type="Int32" />
                                                <asp:Parameter Name="idArchivo" Type="Int32" />
                                                <asp:Parameter Name="idDescripcion" Type="Int32" />
                                            </SelectParameters>
                                             <InsertParameters>
                                                 <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                                                 <asp:Parameter Name="idNorma" Type="Int32" />
                                                 <asp:Parameter Name="idArea" Type="Int32" />
                                                 <asp:Parameter Name="idElemento" Type="Int32" />
                                                 <asp:Parameter Name="idIndice" Type="Int32" />
                                                 <asp:Parameter Name="idArchivo" Type="Int32" DefaultValue="" />
                                                 <asp:ControlParameter ControlID="idDescripcion" DefaultValue="" 
                                                     Name="idDescripcion" PropertyName="Text" Type="Int32" />
                                                 <asp:Parameter Name="idFolio" Type="Int32" />
                                                 <asp:Parameter Name="idNivel" Type="Int32" />
                                                 <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                                                 <asp:Parameter Name="Valor" Type="String" />
                                                 <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                                             </InsertParameters>
                                        </asp:ObjectDataSource>
        
                                        
        
                                        

        
                                        
        
                                        