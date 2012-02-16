<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="Wfrm_ValorizacionSeleccionados_Cajas.aspx.vb" Inherits="Portalv9.Wfrm_ValorizacionSeleccionados_Cajas" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Inventario Preliminar"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" 
            NavigateUrl="~/Wfrm_ValorizacionSeleccionados.aspx" />
    <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Seleccione el archivo a transferir</asp:label>
    <br />
    <dxrp:ASPxRoundPanel ID="rpHeader" Width="100%" HeaderText="Datos de la trasferencia " 
      runat="server">
    <PanelCollection>
        <dxp:PanelContent ID="PanelContent1" runat="server">
            <table style="width:100%">
                <tr>
                    <td style="width:20%">
                        <asp:label id="Label1" runat="server" Font-Names="Arial" Font-Bold="True" Text="Folio: "></asp:label>
                    </td>                        
                    <td style="width:30%">
                        <asp:label id="lblFolio" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                    <td style="width:20%">
                        <asp:label id="Label2" runat="server" Font-Names="Arial" Font-Bold="True" Text="Usuario que solicito: "></asp:label>
                    </td>                        
                    <td style="width:30%">
                        <asp:label id="lblUserName" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="Label3" runat="server" Font-Names="Arial" Font-Bold="True" Text="Archivo de Tramite: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblidArchivoOrigen" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                    <td>
                        <asp:label id="Label4" runat="server" Font-Names="Arial" Font-Bold="True" Text="Fecha de Solicitud: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblFecha_Solicitud" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="Label5" runat="server" Font-Names="Arial" Font-Bold="True" Text="Archivo de Concentracion: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblidArchivoDestino" runat="server" Font-Names="Arial"></asp:label>
                        <asp:label id="idArchivoDestino" runat="server" Font-Names="Arial" Visible="False"></asp:label>
                    </td>
                    <td>
                        <asp:label id="Label6" runat="server" Font-Names="Arial" Font-Bold="True" Text="Fecha de Aplicacion: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblFecha_Aplicacion" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                </tr>                    
            </table>
        </dxp:PanelContent> 
    </PanelCollection> 
</dxrp:ASPxRoundPanel>     
</div>
<br />
    <table style="width:100%;" id="tableMain" runat="server" >
        <tr>
            <td style="width: 737px">
                <dxwgv:ASPxGridView ID="gdCajas" runat="server" ClientInstanceName="grid" 
                    AutoGenerateColumns="False" DataSourceID="dsCajas" Width="959px" 
                    KeyFieldName="idFolioCaja" EnableCallBacks="False">
                    <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
                    <SettingsText Title="Cajas" CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nueva" CommandSelect="Seleccionar" 
                        CommandUpdate="Actualizar" ConfirmDelete="Borrar" EmptyDataRow="No hay cajas" />
                    <Columns>
                        <dxwgv:GridViewCommandColumn VisibleIndex="0" Width="120px">
                            <EditButton Visible="True">
                            </EditButton>
                            <NewButton Visible="True">
                            </NewButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idFolio" FieldName="idFolio" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="idFolioCaja" Visible="False" 
                            VisibleIndex="0" Caption="idFolioCaja">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Código" FieldName="Caja_Codigo" 
                            VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Descripción" 
                            FieldName="Caja_Descripcion" VisibleIndex="2">
                            <PropertiesTextEdit MaxLength="200">
                            </PropertiesTextEdit>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataMemoColumn Caption="Notas" FieldName="Caja_Notas" 
                            VisibleIndex="3">
                            <PropertiesMemoEdit Rows="8">
                            </PropertiesMemoEdit>
                        </dxwgv:GridViewDataMemoColumn>
                    </Columns>
                    <Settings ShowTitlePanel="True" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td style="width: 737px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 737px">
                            <dxwtl:ASPxTreeList ID="aspxtreeDocumentos" runat="server" 
                            AutoGenerateColumns="False" DataSourceID="dsExpedientesTransferir" 
                            KeyFieldName="idDescripcion" 
                            ParentFieldName="idDocumentoPID" ClientInstanceName="aspxtreeDocumentos" EnableViewState="False" 
                            SettingsText-CommandCancel="Cancelar" 
                            SettingsText-CommandDelete="Eliminar" SettingsText-CommandEdit="Editar" 
                            SettingsText-CommandNew="Insertar" SettingsText-CommandUpdate="Actualizar" 
                            SettingsText-ConfirmDelete="Esta seguro que quiere eliminar ?" Height="300px" 
                                  Width="960px">
                                <Settings GridLines="Horizontal" />
                            <SettingsBehavior AllowFocusedNode="true" ProcessFocusedNodeChangedOnServer="false"
                                AllowSort="False"/>
                            <SettingsEditing Mode="EditFormAndDisplayNode"/>
                            <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar este nivel ?" 
                                RecursiveDeleteError="El nivel no puede ser borrado ya que tiene subniveles." />
                            <templates>
                              <editform>
                                  <table style="width:315px;">
                                        <tr>
                                            <td style="width:150px">
                                                <dxe:aspxLabel ID="Label7" runat="server" Text="Tipo de Nivel" Width="150px"></dxe:aspxLabel>
                                            </td>
                                            <td style="width:160px">
                                                <dxe:ASPxComboBox ID="dlNiveles" runat="server" DropDownStyle="DropDown" 
                                                    ClientInstanceName="dlNiveles" Width="160px"
                                                   TextField="Nivel_Descripcion" ValueField="idNivel" DataSourceID="ObjectDataSource3" 
                                                   Value='<%# Bind("idNivel") %>' ValueType="System.Int32">
                                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                      cbSerie.PerformCallback(dlNiveles.GetValue().toString()); 
                                                      }" />
                                                 </dxe:ASPxComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:150px">
                                                <dxe:aspxLabel ID="AspxLabel2" runat="server" Text="Tipo de Expediente" Width="150px"></dxe:aspxLabel>                                                 
                                            </td>
                                            <td style="width:160px">
                                                <dxe:ASPxComboBox ID="cbSerie" runat="server" DropDownStyle="DropDown" ClientInstanceName="cbSerie"                                                       
                                                      TextField="Serie_nombre" ValueField="idSerie" 
                                                    Value='<%# Bind("idSerie") %>' Width="160px" DataSourceID="dsTipoDeExpediente" ValueType="System.Int32">                                                      
                                                 </dxe:ASPxComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dxe:aspxLabel ID="AspxLabel1" runat="server" Text="Titulo"></dxe:aspxLabel>
                                            </td>
                                            <td>
                                                <dxe:ASPxTextBox ID="txtDescripcion" runat="server" Value='<%# Bind("Descripcion") %>' Width="160px">
                                                </dxe:ASPxTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                <br />
                                <div style="width:322px;">
                                    <table>
                                        <tr>
                                            <td><dxe:ASPxButton ID="btnUpdtae" runat="server" Text="Actualizar"></dxe:ASPxButton></td>
                                            <td><dxe:ASPxButton ID="btnCancelar" runat="server" Text="Cancelar"></dxe:ASPxButton></td>
                                        </tr>
                                    </table>
                                </div>
                            </editform>
                            </templates>
                            <Columns>
                                <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" ReadOnly="True" Visible="False"></dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Niveles" VisibleIndex="0">
                                    <DataCellTemplate>
                                        <dxe:ASPxImage ID="ASPxImage2" runat="server" 
                                            ImageUrl="<%# GetNodeGlyph(Container) %>">
                                        </dxe:ASPxImage>
                                    </DataCellTemplate>
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Código de clasificación" 
                                    FieldName="Codigo_clasificacion" VisibleIndex="1" Width="260px">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Descripción" FieldName="Descripcion" 
                                    VisibleIndex="2">
                                    <CellStyle Wrap="True">
                                    </CellStyle>
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" ReadOnly="True" Visible="False"></dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Cajas" FieldName="Cajas" VisibleIndex="3">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Meter en caja" VisibleIndex="4" 
                                    Width="100px">
                                    <DataCellTemplate>
                                        <dxe:ASPxButton ID="btnSelCaja" runat="server" onclick="btnSelCaja_Click" 
                                            Width="50px">
                                            <Image Url="~/Images/Cajas.png">
                                            </Image>
                                        </dxe:ASPxButton>
                                    </DataCellTemplate>
                                </dxwtl:TreeListTextColumn>
                            </Columns>
                        </dxwtl:ASPxTreeList>
            </td>
        </tr>
        </table>
    <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
    <dx:ASPxPopupControl ID="popCajas" runat="server" CloseAction="CloseButton" 
        Height="153px" PopupAction="None" PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" Width="506px">
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dxwgv:ASPxGridView ID="gdCajasSel" runat="server" AutoGenerateColumns="False" 
        ClientInstanceName="grid" DataSourceID="dsCajas" EnableCallBacks="False" 
        KeyFieldName="idFolioCaja" Width="480px">
        <Columns>
            <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" 
                Width="20px">
            </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn Caption="idFolio" FieldName="idFolio" 
                Visible="False" VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="idFolioCaja" FieldName="idFolioCaja" 
                Visible="False" VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Código" FieldName="Caja_Codigo" 
                VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Descripción" 
                FieldName="Caja_Descripcion" VisibleIndex="2">
                <PropertiesTextEdit MaxLength="200">
                </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior ProcessFocusedRowChangedOnServer="True" />
        <Settings ShowTitlePanel="True" />
        <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
            CommandEdit="Editar" CommandNew="Nueva" CommandSelect="Seleccionar" 
            CommandUpdate="Actualizar" ConfirmDelete="Borrar" EmptyDataRow="No hay cajas" 
            Title="Cajas" />
    </dxwgv:ASPxGridView>
    <table style="width: 100%">
        <tr>
            <td>
                <dxe:ASPxButton ID="ASPxButton1" runat="server" Text="Aceptar">
                </dxe:ASPxButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>
    <asp:ObjectDataSource ID="dsExpedientesTransferir" runat="server" 
            SelectMethod="Lista_Transferencias_Primarias_Documentos" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:QueryStringParameter Name="idFolio" QueryStringField="idFolio" 
                Type="Int32"  />
            <asp:Parameter DefaultValue="0" Name="idStatus" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsTransferenciaActiva" runat="server" 
            SelectMethod="ListaVencimientos_Archivo_Tramite_Seleccionados" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
        <SelectParameters>
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                Type="Int32"  />
            <asp:QueryStringParameter Name="idFolio" QueryStringField="idFolio" 
                Type="Int32"  />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsCajas" runat="server" 
            SelectMethod="Lista_Transferencias_Primarias_Cajas" 
        TypeName="Portalv9.WSArchivo.Service1" 
        DeleteMethod="ABC_Transferencias_Primarias_Cajas" 
        InsertMethod="ABC_Transferencias_Primarias_Cajas" 
        UpdateMethod="ABC_Transferencias_Primarias_Cajas">
        <DeleteParameters>
            <asp:Parameter DefaultValue="1" Name="op" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="" Name="idFolio" 
                QueryStringField="idFolio" Type="Int32" />
            <asp:Parameter Name="idFolioCaja" Type="Int32" />
            <asp:Parameter Name="Caja_Codigo" Type="String" />
            <asp:Parameter Name="Caja_Descripcion" Type="String" />
            <asp:Parameter Name="Caja_Notas" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter DefaultValue="2" Name="op" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="" Name="idFolio" 
                QueryStringField="idFolio" Type="Int32" />
            <asp:Parameter Name="idFolioCaja" Type="Int32" />
            <asp:Parameter Name="Caja_Codigo" Type="String" />
            <asp:Parameter Name="Caja_Descripcion" Type="String" />
            <asp:Parameter Name="Caja_Notas" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="idFolio" QueryStringField="idFolio" 
                Type="Int32"  />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter DefaultValue="0" Name="op" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="" Name="idFolio" 
                QueryStringField="idFolio" Type="Int32" />
            <asp:Parameter Name="idFolioCaja" Type="Int32" />
            <asp:Parameter Name="Caja_Codigo" Type="String" />
            <asp:Parameter Name="Caja_Descripcion" Type="String" />
            <asp:Parameter Name="Caja_Notas" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    </asp:Content>

