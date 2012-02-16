<%@ Page Language="vb" MasterPageFile="~/Masterpages/1.master"AutoEventWireup="false" CodeBehind="Wfrm_Filtros.aspx.vb" Inherits="Portalv9.Wfrm_Filtros" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Consultas" > </asp:Label>
    </div>
        <script type="text/javascript">
        function OnArchivoChanged(s, e) {
            cmbNivel.PerformCallback(e);
        }
        function OnNivelChanged(s) {
            cbSerie.PerformCallback(cmbNivel.GetValue().toString());
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <div>
    <asp:ObjectDataSource ID="dsFiltros" runat="server" 
        SelectMethod="ListaFiltros_Master" TypeName="Portalv9.WSArchivo.Service1" 
            OldValuesParameterFormatString="{0}" UpdateMethod="ABC_Filtros_Master"
             DeleteMethod="ABC_Filtros_Master" InsertMethod="ABC_Filtros_Master">
        <InsertParameters>
            <asp:Parameter Name="op" Type="Object" DefaultValue="0" />
            <asp:Parameter Name="idFiltro" Type="Int32" />
            <asp:Parameter Name="idArchivo" Type="Int32" DefaultValue="-1" />
            <asp:Parameter Name="idSerie" Type="Int32" DefaultValue="-1" />
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="FAlias" Type="String" DefaultValue=""/>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="op" Type="Object" DefaultValue="2" />
            <asp:Parameter Name="idFiltro" Type="Int32" />
            <asp:Parameter Name="idArchivo" Type="Int32"/>
            <asp:Parameter Name="idSerie" Type="Int32"/>
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="FAlias" Type="String"/>
        </UpdateParameters>
        <DeleteParameters >
            <asp:Parameter Name="op" Type="Object" DefaultValue="1" />
            <asp:Parameter Name="idFiltro" Type="Int32" />
            <asp:Parameter Name="idArchivo" Type="Int32" />
            <asp:Parameter Name="idSerie" Type="Int32" />
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="FAlias" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="idFiltro" Type="Int32" DefaultValue="-1" />
        </SelectParameters>
    </asp:ObjectDataSource>
      <dxwgv:ASPxGridView ID="aspxGridFiltros" runat="server" KeyFieldName="idFiltro"  
            OnRowCommand="aspxGridFiltros_RowCommand"  AutoGenerateColumns="False" 
            DataSourceID="dsFiltros">
            <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar ésta consulta?"/>
            <SettingsBehavior ConfirmDelete="true" />
            <SettingsEditing Mode="EditForm" />
            <Templates>
              <EditForm>
                  <table style="border: thin solid #C9D7DD; width: 100%;">
                    <tr>
                        <td style="width: 74px">
                            <dxe:aspxlabel ID="lblHeadArchivo" runat="server" Text="Archivo"></dxe:aspxlabel>
                        </td>
                        <td>
                            <dxe:ASPxComboBox ID="cmbArchivo" runat="server" ClientInstanceName="cmbArchivo" 
                                DataSourceID="dsArchivos" Value="<%# Bind('idArchivo') %>" ValueType="System.Int32" DropDownStyle="DropDown"
                                TextField="Archivo_Descripcion" ValueField="idArchivo" Width="250px" EnableSynchronization="False">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) { OnArchivoChanged(s, e); }"></ClientSideEvents>
                                <Columns>
                                    <dxe:ListBoxColumn FieldName="Archivo_Descripcion" Width="100%"/>
                                    <dxe:ListBoxColumn FieldName="idNorma" Visible="False" />
                                </Columns>
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 74px">
                            <asp:Label ID="lblHeadNivel" runat="server" Text="Nivel"></asp:Label>
                        </td>
                        <td>
                            <dxe:ASPxComboBox ID="dlNiveles" runat="server" EnableSynchronization="False"
                               TextField="Nivel_Descripcion" ValueField="idNivel"
                                ClientInstanceName="cmbNivel" DropDownStyle="DropDown"
                               DataSourceID="dsNivel" ValueType="System.Int32"
                                OnCallback="dlNiveles_Callback">
                               <ClientSideEvents SelectedIndexChanged="function(s, e) { OnNivelChanged(s); }"></ClientSideEvents>
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 74px">
                            <dxe:aspxLabel ID="lblHeadTipoExpediente" runat="server" Text="Tipo de Expediente"></dxe:aspxLabel>
                        </td>
                        <td>
                            <dxe:ASPxComboBox ID="cbSerie" runat="server" ClientInstanceName="cbSerie" DropDownStyle="DropDown"
                               TextField="Serie_nombre" ValueField="idSerie" SelectedIndex="-1" EnableSynchronization="False"
                               DataSourceID="dsTipoDeExpediente" Value="<%# Bind('idSerie') %>" ValueType="System.Int32" 
                               OnCallback="cbSerie_Callback">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 74px">
                            <dxe:aspxLabel ID="AspxLabel1" runat="server" Text="Nombre"></dxe:aspxLabel>
                        </td>
                        <td>
                            <dxe:ASPxTextBox ID="txtNombre" runat="server" Width="300px" 
                                Text="<%# Bind('Nombre') %>">
                            </dxe:ASPxTextBox>
                        </td>
                    </tr>
                  </table>
                  <br />
                  <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                  <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
              </EditForm>
            </Templates>
            <Columns>
                  <dxwgv:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre">                                   
                  <EditFormSettings Visible="True" VisibleIndex="0"/>
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Archivo" FieldName="Archivo" ReadOnly="True">
                  <EditFormSettings Visible="False" VisibleIndex="1"/>
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Tipo Documento" FieldName="Serie" ReadOnly="True">
                  <EditFormSettings Visible="False" VisibleIndex="2"/>
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Alias" FieldName="FAlias" Visible="false" ReadOnly="false">
                  <EditFormSettings Visible="false" VisibleIndex="3"/>
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" Visible="false" ReadOnly="true">
                  <EditFormSettings Visible="false" VisibleIndex="4"/>
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" Visible="false" ReadOnly="true">
                  <EditFormSettings Visible="false" VisibleIndex="5"/>
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewCommandColumn Caption="Nuevo">
                        <NewButton Visible="true" Text="Agregar Consulta" ></NewButton>
                  </dxwgv:GridViewCommandColumn>
                  <dxwgv:GridViewCommandColumn Caption="Editar">
                            <EditButton Visible="True" Text="Editar"></EditButton>
                            <CancelButton Visible="True" Text="Cancelar"></CancelButton>
                            <UpdateButton Visible="True" Text="Actualizar"></UpdateButton>
                     </dxwgv:GridViewCommandColumn>
                 <dxwgv:GridViewCommandColumn Caption="Eliminar"><DeleteButton Text="Eliminar" Visible="true"></DeleteButton></dxwgv:GridViewCommandColumn>
               <dxwgv:GridViewDataColumn Caption="Perfil">
                  <EditFormSettings Visible="False" />
                  <DataItemTemplate>
                      <dxe:ASPxButton runat="server" ID="btnUsuario" Text="Usuario" CommandName="Usuario"  CommandArgument='<%# Bind("idFiltro") %>'>
                      </dxe:ASPxButton>
                  </DataItemTemplate> 
               </dxwgv:GridViewDataColumn>
               <dxwgv:GridViewDataColumn Caption="Perfil">
                  <EditFormSettings Visible="False" />
                  <DataItemTemplate>
                      <dxe:ASPxButton runat="server" ID="btnAdmin" Text="Admin" CommandName="Admin"  CommandArgument='<%# Bind("idFiltro") %>'>
                      </dxe:ASPxButton>
                  </DataItemTemplate> 
               </dxwgv:GridViewDataColumn>
           </Columns>
    </dxwgv:ASPxGridView>
    </div>
 </asp:Panel>
    <asp:ObjectDataSource ID="dsArchivos" runat="server" 
        SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsNivel" runat="server" 
        SelectMethod="ListaNormas_Niveles" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:SessionParameter Name="idNorma" SessionField="dsIdNorma" Type="Int32" DefaultValue="-1"/>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsTipoDeExpediente" runat="server" 
        SelectMethod="ListaSeries_ModeloXNorma" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:SessionParameter Name="idNorma" SessionField="dsIdNorma" Type="Int32" DefaultValue="-1"/>
            <asp:SessionParameter Name="idNivel" SessionField="dsIdNivel" Type="Int32" DefaultValue="-1"/>
            <asp:Parameter Name="NoIdentidad" Type="Int32" DefaultValue="-1"/>
        </SelectParameters>
    </asp:ObjectDataSource>
<cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
</asp:Content>
