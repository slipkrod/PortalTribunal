<%@ Control Language="vb" AutoEventWireup="true" EnableViewState="true" CodeBehind="CampoGrid.ascx.vb" Inherits="Portalv9.CampoGrid" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<table style="vertical-align: top">
    <script type="text/javascript">
        function setValorControls() {
            try {
                txtValor.SetVisible(false);
                speValor.SetVisible(false);
                cmbValor.SetVisible(false);                
                daeValor.SetVisible(false);
                switch (lblTipoValor.GetValue()) {
                    case "0":
                        try {
                            txtValor.SetVisible(true);
                        }
                        catch (e) { }
                        break;
                    case "7":
                        try {
                            speValor.SetVisible(true);
                        }
                        catch (e) { }
                        break;
                    case "6":
                        try {
                            cmbValor.SetVisible(true);
                        }
                        catch (e) { }
                        break;
                    case "2":
                        try {
                            daeValor.SetVisible(true);
                        }
                        catch (e) { }
                        break;
                }
            }
            catch (e) { } 
        }
    </script>
    <tr>
        <td class="WebUsrCtrls-td1" style="height:24;" id="tdCampo" runat="server">
            <dxe:ASPxLabel  ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt" >
            </dxe:ASPxLabel>
        </td>
        <td class="WebUsrCtrls-td1" id="tdTexto_Padres" runat="server" style="height: 24px;">
            <dxe:ASPxLabel ID="Texto_Padres" runat="server" Font-Names="Arial" 
                Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
        <td>
        </td>
    </tr> 
    <tr>
        <td colspan="3">
            <dxwgv:ASPxGridView ID="aspxGridCatalogoCampos" runat="server" 
                AutoGenerateColumns="False" DataSourceID="dsValores" 
                KeyFieldName="idFolio" Width="355px" EnableRowsCache="False">
                <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar"  
                    CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                    ConfirmDelete="¿Seguro desea borrar este registro?" 
                    EmptyDataRow="No existen datos" />
                <SettingsEditing Mode="EditForm" />
                <Templates>
                    <EditForm>
                        <table style="border: thin solid #C9D7DD; width: 100%; height: 160px;">
                            <tr>
                                <td style="width: 161px">Catalogo</td>
                                <td>
                                    <dxe:ASPxComboBox ID="cmbCatalogos" runat="server" ClientInstanceName="cmbCatalogos" 
                                        TextField="Descripcion" ValueField="IDCatalogo" ValueType="System.Int32" Visible="false"  
                                        DataSourceID="dsListaCatalogo" Value='<%# Bind("relacion_con_normaPID") %>' EnableSynchronization="True">
                                    </dxe:ASPxComboBox>
                                    <asp:Label ID="lblCatalogo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 161px">Campo</td>
                                <td>
                                    <dxe:ASPxComboBox ID="cmbCampoAll" runat="server" 
                                        TextField="Descripcion" ValueField="IDCatalogo_item" ValueType="System.Int32"  
                                        DataSourceID="dsCatalogoDatosAll" Value='<%# Bind("IDCatalogo_item") %>'>
                                    </dxe:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 161px">Valor<dxe:ASPxLabel ID="lblidFolio" runat="server" 
                                        Value='<%# Bind("idFolio") %>'>
                                    </dxe:ASPxLabel>
                                </td>
                                <td>                                    
                                    <dxe:ASPxTextBox ID="txtValor" runat="server" Width="120px" Text='<%# Bind("Valor") %>' ClientInstanceName="txtValor"></dxe:ASPxTextBox>
                                    <dxe:ASPxSpinEdit ID="speValor" runat="server" AllowNull="False" NumberType="Integer" Width="70px"
                                        ClientInstanceName="speValor" ></dxe:ASPxSpinEdit>
                                    <dxe:ASPxComboBox ID="cmbValor" runat="server" SelectedIndex="-1" ClientInstanceName="cmbValor" 
                                        idth="200px" DropDownStyle="DropDown" ValueType="System.Int32">
                                        <Items>                                                
                                            <dxe:ListEditItem Text="No" Value="0" />
                                            <dxe:ListEditItem Text="Si" Value="1" />
                                        </Items>                                    
                                    </dxe:ASPxComboBox>
                                    <dxe:ASPxDateEdit ID="daeValor" runat="server" Date="" ClientInstanceName="daeValor" >
                                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorText="Valor invalido" ValidationGroup="Archivos" 
                                            ErrorDisplayMode="ImageWithTooltip"><RequiredField ErrorText="* Campo requerido" />
                                        </ValidationSettings>
                                    </dxe:ASPxDateEdit><div style=" display:none;">
                                    <dxe:ASPxLabel ID="lblTipoValor" runat="server" ClientInstanceName="lblTipoValor" ></dxe:ASPxLabel></div>
                                </td>
                            </tr>
                        </table> 
                        <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                        <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                    </EditForm>
                </Templates>                
                <ClientSideEvents EndCallback="function(s, e) { 
                    setValorControls();
                     }" />
                <Columns>
                    <dxwgv:GridViewDataTextColumn Caption="idNorma" FieldName="idNorma" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idArea" FieldName="idArea" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idElemento" FieldName="idElemento" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idIndice" FieldName="idIndice" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idDescripcion" FieldName="idDescripcion" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idFolio" FieldName="idFolio" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="Indice_Tipo" FieldName="Indice_Tipo" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="Catalogo" FieldName="relacion_con_normaPID" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <%--<dxwgv:GridViewDataComboBoxColumn Caption="Catalogo" FieldName="" VisibleIndex="0" >
                         <PropertiesComboBox DataSourceID="dsListaCatalogo" TextField="Descripcion" 
                                ValueField="IDCatalogo" ValueType="System.Int32"></PropertiesComboBox>
                    </dxwgv:GridViewDataComboBoxColumn>--%>
                    <dxwgv:GridViewDataComboBoxColumn Caption="Campo" FieldName="IDCatalogo_item" VisibleIndex="1">
                         <PropertiesComboBox DataSourceID="dsCatalogoDatosAll" TextField="Descripcion" 
                                ValueField="IDCatalogo_item" ValueType="System.Int32"></PropertiesComboBox>
                    </dxwgv:GridViewDataComboBoxColumn>
                    <dxwgv:GridViewDataTextColumn Caption="Valor" FieldName="Valor" VisibleIndex="2">
                        <DataItemTemplate>
                            <%#GeneraValor(Eval("Valor"), Eval("Tipo_Dato"))%>
                        </DataItemTemplate>
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewCommandColumn VisibleIndex="2">
                        <EditButton Visible="True"></EditButton>
                        <NewButton Visible="True"></NewButton>
                        <DeleteButton Visible="True"></DeleteButton>
                    </dxwgv:GridViewCommandColumn>
                </Columns>
            </dxwgv:ASPxGridView>            
        </td>
    </tr>
</table>
    <asp:ObjectDataSource ID="dsListaCatalogo" runat="server" SelectMethod="ListaCatalogo" TypeName="Portalv9.WSArchivo.Service1"  >
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsCatalogoDatos" runat="server" SelectMethod="ListaCatalogo_DatosXIndice" TypeName="Portalv9.WSArchivo.Service1"  >
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCatalogo" Name="IDCatalogo" PropertyName="Text" Type="Int32" />
            <asp:ControlParameter ControlID="lblidIndice" Name="idIndice" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsCatalogoDatosAll" runat="server" SelectMethod="ListaCatalogo_Datos" TypeName="Portalv9.WSArchivo.Service1"  >
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCatalogo" Name="IDCatalogo" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsValores" runat="server" 
        SelectMethod="ListaArchivo_indice" DeleteMethod="ABC_Archivo_indice"          
        TypeName="Portalv9.WSArchivo.Service1" InsertMethod="ABC_Archivo_indice" 
        UpdateMethod="ABC_Archivo_indice"  >
     <DeleteParameters>
         <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
         <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
         <asp:Parameter DefaultValue="" Name="idArea" Type="Int32" />
         <asp:Parameter Name="idElemento" Type="Int32" />
         <asp:Parameter Name="idIndice" Type="Int32" />
         <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
         <asp:ControlParameter Name="idDescripcion"  ControlID="lblidDescripcion" PropertyName="Text" Type="Int32"/>
         <asp:Parameter Name="idFolio" Type="Int32" />         
         <asp:ControlParameter Name="idNivel"  ControlID="lblidNivel" PropertyName="Text" Type="Int32"/>
         <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" Type="Int32" />
         <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
         <asp:Parameter Name="Valor" Type="String" />
         <asp:Parameter Name="Indice_Tipo" Type="Int32" />
         <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
     </DeleteParameters>
     <UpdateParameters>
         <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
         <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
         <asp:Parameter DefaultValue="" Name="idArea" Type="Int32" />
         <asp:Parameter Name="idElemento" Type="Int32" />
         <asp:Parameter Name="idIndice" Type="Int32" />
         <asp:QueryStringParameter DefaultValue="" Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
         <asp:ControlParameter Name="idDescripcion" ControlID="lblidDescripcion" PropertyName="Text" Type="Int32"/>
         <asp:Parameter Name="idFolio" Type="Int32" DefaultValue="0"/>
         <asp:ControlParameter Name="idNivel"  ControlID="lblidNivel" PropertyName="Text" Type="Int32"/>
         <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" Type="Int32" />
         <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
         <asp:Parameter Name="Valor" Type="String" />
         <asp:Parameter Name="Indice_Tipo" Type="Int32" />
         <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
     </UpdateParameters>
    <SelectParameters>
        <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
        <asp:ControlParameter ControlID="lblidArea" Name="idArea" PropertyName="Text" 
            Type="Int32" />
        <asp:ControlParameter ControlID="lblidElemento" Name="idElemento" 
            PropertyName="Text" Type="Int32" />
        <asp:ControlParameter ControlID="lblidIndice" Name="idIndice" 
            PropertyName="Text" Type="Int32" />
        <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
        <asp:QueryStringParameter Name="idDescripcion" QueryStringField="idDescripcion" 
            Type="Int32" />
    </SelectParameters>
     <InsertParameters>
         <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
         <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
         <asp:Parameter DefaultValue="" Name="idArea" Type="Int32" />
         <asp:Parameter Name="idElemento" Type="Int32" />
         <asp:Parameter Name="idIndice" Type="Int32" />
         <asp:QueryStringParameter DefaultValue="" Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
         <asp:ControlParameter Name="idDescripcion"  ControlID="lblidDescripcion" PropertyName="Text" Type="Int32"/>
         <asp:Parameter Name="idFolio" Type="Int32" DefaultValue="0" />
         <asp:ControlParameter Name="idNivel"  ControlID="lblidNivel" PropertyName="Text" Type="Int32"/>
         <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" Type="Int32" />
         <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
         <asp:Parameter Name="Valor" Type="String" />
         <asp:Parameter Name="Indice_Tipo" Type="Int32" />
         <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
     </InsertParameters>
</asp:ObjectDataSource>
    <asp:Label ID="lblidArea" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblidElemento" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblidIndice" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblidDescripcion" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblidNivel" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblIndice_Tipo" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCatalogo" runat="server" Visible="False"></asp:Label>    
    <dxe:ASPxLabel ID="lblTipoValor" runat="server" Visible="False"></dxe:ASPxLabel>
    <dxe:ASPxLabel ID="lblValores_Aceptados" runat="server" Visible="False"></dxe:ASPxLabel><br />
    <dxe:ASPxLabel ID="lblValoresAgregados" runat="server" Visible="False"></dxe:ASPxLabel>
