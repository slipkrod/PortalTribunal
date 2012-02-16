<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoGridISAAR.ascx.vb" Inherits="Portalv9.CampoGridISAAR" %>
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
            <dxwgv:ASPxGridView ID="aspxGridCamposISAAR" runat="server" 
                AutoGenerateColumns="False" DataSourceID="dsValores" KeyFieldName="idFolio" 
                Width="355px">
                <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                    CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                    ConfirmDelete="¿Seguro desea borrar este registro?" 
                    EmptyDataRow="No existen datos" />
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
                        <PropertiesComboBox DataSourceID="daListaISAAR" ValueField="idISAAR" 
                            ValueType="System.String" TextField="Formas_autorizadas_nombre" 
                            EnableIncrementalFiltering="True">
                        </PropertiesComboBox>
                    </dxwgv:GridViewDataComboBoxColumn>
                    <dxwgv:GridViewDataTextColumn Caption="Valor" FieldName="Valor" 
                        VisibleIndex="1" Visible="False">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewCommandColumn VisibleIndex="1">
                        <EditButton Visible="True">
                        </EditButton>
                        <NewButton Visible="True">
                        </NewButton>
                        <DeleteButton Visible="True">
                        </DeleteButton>
                    </dxwgv:GridViewCommandColumn>
                </Columns>
            </dxwgv:ASPxGridView>
          </td>
    </tr>
</table>
        
                                        
        
                                        <asp:ObjectDataSource ID="dsValores" runat="server" 
                                            SelectMethod="ListaArchivo_indice" DeleteMethod="ABC_Archivo_indice"          
                                            
    TypeName="Portalv9.WSArchivo.Service1" InsertMethod="ABC_Archivo_indice" 
    UpdateMethod="ABC_Archivo_indice"  >
                                             <DeleteParameters>
                                                 <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
                                                 <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                                                     Type="Int32" />
                                                 <asp:Parameter Name="idArea" Type="Int32" DefaultValue="" />
                                                 <asp:Parameter Name="idElemento" Type="Int32" />
                                                 <asp:Parameter Name="idIndice" Type="Int32" />
                                                 <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                                                     Type="Int32" />
                                                 <asp:SessionParameter Name="idDescripcion" SessionField="idDescripcion" 
                                                     Type="Int32" />
                                                 <asp:Parameter Name="idFolio" Type="Int32" />
                                                 <asp:SessionParameter DefaultValue="" Name="idNivel" SessionField="idNivel" 
                                                     Type="Int32" />
                                                 <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                                                 <asp:Parameter Name="Valor" Type="String" />
                                                 <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                                             </DeleteParameters>
                                             <UpdateParameters>
                                                 <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
                                                 <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                                                     Type="Int32" />
                                                 <asp:Parameter Name="idArea" Type="Int32" DefaultValue="" />
                                                 <asp:Parameter Name="idElemento" Type="Int32" />
                                                 <asp:Parameter Name="idIndice" Type="Int32" />
                                                 <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                                                     Type="Int32" />
                                                 <asp:SessionParameter DefaultValue="" Name="idDescripcion" 
                                                     SessionField="idDescripcion" Type="Int32" />
                                                 <asp:Parameter Name="idFolio" Type="Int32" />
                                                 <asp:SessionParameter Name="idNivel" SessionField="idNivel" Type="Int32" />
                                                 <asp:Parameter Name="relacion_con_normaPID" Type="Int32" DefaultValue="" />
                                                 <asp:Parameter Name="Valor" Type="String" />
                                                 <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                                             </UpdateParameters>

                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                                                    Type="Int32" />
                                                <asp:Parameter Name="idArea" Type="Int32" />
                                                <asp:Parameter Name="idElemento" Type="Int32" />
                                                <asp:Parameter Name="idIndice" Type="Int32" />
                                                <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                                                    Type="Int32" />
                                                <asp:SessionParameter Name="idDescripcion" SessionField="idDescripcion" 
                                                    Type="Int32" />
                                            </SelectParameters>
                                             <InsertParameters>
                                                 <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                                                 <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                                                     Type="Int32" />
                                                 <asp:Parameter Name="idArea" Type="Int32" DefaultValue="" />
                                                 <asp:Parameter Name="idElemento" Type="Int32" />
                                                 <asp:Parameter Name="idIndice" Type="Int32" />
                                                 <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                                                     Type="Int32" />
                                                 <asp:SessionParameter Name="idDescripcion" SessionField="idDescripcion" 
                                                     Type="Int32" />
                                                 <asp:Parameter Name="idFolio" Type="Int32" />
                                                 <asp:SessionParameter DefaultValue="" Name="idNivel" SessionField="idNivel" 
                                                     Type="Int32" />
                                                 <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
                                                 <asp:Parameter Name="Valor" Type="String" />
                                                 <asp:Parameter Name="Indice_Tipo" Type="Int32" />
                                             </InsertParameters>
                                        </asp:ObjectDataSource>
        
                                        
        
                                        

        
                                        
        
                                        <asp:ObjectDataSource ID="daListaISAAR" runat="server" 
                                            SelectMethod="ListaISAAR"   
    TypeName="Portalv9.WSArchivo.Service1"  >
                                        </asp:ObjectDataSource>
        
                                      
        
                                                                                   
        
                                        
        
                                        
        
                                        

        
                                        
        
                                        <asp:Label ID="lblidArea" 
    runat="server" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblidElemento" runat="server" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblidIndice" runat="server" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblidDescripcion" runat="server" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblidNivel" runat="server" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblIndice_Tipo" runat="server" Visible="False"></asp:Label>

        
                                      
        
                                                                                   
        
                                        
        
                                        
        
                                        

        
                                        
        
                                        