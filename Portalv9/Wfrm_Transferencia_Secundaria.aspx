<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="Wfrm_Transferencia_Secundaria.aspx.vb" Inherits="Portalv9.Wfrm_Transferencia_Secundaria" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Transferencias Secundarias</asp:label>
</div>
<br />
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <dxwgv:ASPxGridView ID="gdTransferenciaActiva" runat="server" ClientInstanceName="grid" 
                    AutoGenerateColumns="False" DataSourceID="dsTransferenciaActiva" Width="100%" 
                    KeyFieldName="idFolio" EnableCallBacks="False">
<Templates>
                        <EditForm>
                            <table style="width: 700px">
                                <tr>
                                    <td style="width: 166px">
                                        Folio</td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text='<%# Eval("idFolio") %>'>
                                        </dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 166px">
                                        Fecha</td>
                                    <td>
                                        <dx:ASPxDateEdit ID="FechaAlta" runat="server" ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>"
                                            Value='<%# Bind("Fecha_Solicitud") %>'>
                                            <ValidationSettings>
                                                <RequiredField ErrorText="* Requerido" IsRequired="True" />
                                            </ValidationSettings>
                                        </dx:ASPxDateEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 166px">
                                        Archivo de Concentración</td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbArchivoTramite" runat="server" ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>"
                                            DataSourceID="dsArchivosTipo" TextField="Archivo_Descripcion" 
                                            Value='<%# Bind("idArchivoOrigen") %>' ValueField="idArchivo" 
                                            ValueType="System.Int32" Width="450px">
                                            <ValidationSettings ErrorTextPosition="Bottom">
                                                <RequiredField ErrorText="* Requerido" IsRequired="True" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 166px">
                                        Archivo de Histórico</td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbArchivoConcentracion" runat="server" ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>"
                                            DataSourceID="dsArchivosConcentracion" TextField="Archivo_Descripcion" 
                                            Value='<%# Bind("idArchivoDestino") %>' ValueField="idArchivo" 
                                            ValueType="System.Int32" Width="450px">
                                            <ValidationSettings ErrorTextPosition="Bottom">
                                                <RequiredField ErrorText="* Requerido" IsRequired="True" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 166px">
                                        Notas</td>
                                    <td>
                                        <dx:ASPxMemo ID="ASPxMemo1" runat="server" Rows="7" 
                                            Text='<%# Bind("Notas_Solicitud") %>' Width="450px">
                                        </dx:ASPxMemo>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 166px">
                                        Status</td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbStatus" runat="server" onload="cmbStatus_Load" ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>"
                                            Value='<%# Bind("Status") %>' ValueType="System.Int32">
                                            <ValidationSettings>
                                                <RequiredField ErrorText="* Requerido" IsRequired="True" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>                               
                            </table>
                            <div style="text-align: right; padding: 2px 2px 2px 2px">
                                <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton"
                                    runat="server">
                                </dxwgv:ASPxGridViewTemplateReplacement>
                                <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" 
                                    runat="server">
                                </dxwgv:ASPxGridViewTemplateReplacement>
                            </div>                            
                        </EditForm>
                    </Templates>                    
                    <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
                    <SettingsPager Mode="ShowAllRecords">
                    </SettingsPager>
                    <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" 
                        PopupEditFormHorizontalAlign="Center" PopupEditFormModal="True" 
                        PopupEditFormVerticalAlign="Middle" PopupEditFormWidth="600px" />
                    <SettingsText Title="Transferencia secundaria activa" CommandCancel="Cancelar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        EmptyDataRow="No existen registros" />
                    <Columns>
                        <dxwgv:GridViewCommandColumn VisibleIndex="0" Width="50px">
                            <EditButton Visible="True">
                            </EditButton>
                            <NewButton Visible="True">
                            </NewButton>
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Folio" FieldName="idFolio" 
                            VisibleIndex="1" ReadOnly="True">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Usrid" FieldName="Usrid" Visible="False" 
                            VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataDateColumn Caption="Fecha" FieldName="Fecha_Solicitud" 
                            VisibleIndex="2">
                            <PropertiesDateEdit EditFormat="Custom" EditFormatString="d">
                                <ValidationSettings>
                                    <RequiredField ErrorText="* Requerido" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesDateEdit>
                        </dxwgv:GridViewDataDateColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="Archivo de Concentración" FieldName="idArchivoOrigen" 
                            VisibleIndex="3">
                            <PropertiesComboBox DataSourceID="dsArchivosTipo" 
                                TextField="Archivo_Descripcion" ValueField="idArchivo" ValueType="System.Int32">
                                <ValidationSettings>
                                    <RequiredField ErrorText="* Requerido" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="Archivo Histórico" 
                            FieldName="idArchivoDestino" VisibleIndex="4">
                            <PropertiesComboBox DataSourceID="dsArchivosConcentracion" 
                                TextField="Archivo_Descripcion" ValueField="idArchivo" ValueType="System.Int32">
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataMemoColumn Caption="Notas" FieldName="Notas_Solicitud" 
                            VisibleIndex="5">
                            <PropertiesMemoEdit Rows="6">
                            </PropertiesMemoEdit>
                        </dxwgv:GridViewDataMemoColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="Status" FieldName="Status" 
                            VisibleIndex="6">
                            <PropertiesComboBox ValueType="System.Int32">
                                <Items>
                                    <dx:ListEditItem Text="Activa" Value="0" />
                                    <dx:ListEditItem Text="Cancelar" Value="-1" />
                                    <dx:ListEditItem Text="Activa." Value="1" />
                                </Items>
                            </PropertiesComboBox>
                            <EditFormSettings Visible="True" />
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Detalle" VisibleIndex="7" Width="50px">
                            <EditFormSettings Visible="False" />
                            <DataItemTemplate>
                                <dx:ASPxButton ID="btnVer" runat="server" CommandName="btnVer" Text="Ver" 
                                    Width="60px">
                                </dx:ASPxButton>
                            </DataItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowTitlePanel="True" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top">
                <dxwgv:ASPxGridView ID="gdTransferencaHist" runat="server" ClientInstanceName="grid" 
                    AutoGenerateColumns="False" DataSourceID="dsTransferenciaHistorica" Width="100%" 
                    KeyFieldName="idFolio" EnableCallBacks="False">
                    <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
                    <SettingsText Title="Histórico de Transferencias secundarias" />
                    <Columns>
                        <dxwgv:GridViewCommandColumn VisibleIndex="0">
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Folio" FieldName="idFolio" 
                            VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Usrid" FieldName="Usrid" Visible="False" 
                            VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Fecha" FieldName="Fecha_Solicitud" 
                            VisibleIndex="2">
                            <PropertiesTextEdit DisplayFormatString="d">
                            </PropertiesTextEdit>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataDateColumn Caption="Fecha de Transferencia" 
                            FieldName="Fecha_Aplicacion" VisibleIndex="5">
                        </dxwgv:GridViewDataDateColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="Archivo Trámite" 
                            FieldName="idArchivoOrigen" VisibleIndex="3">
                            <PropertiesComboBox DataSourceID="dsArchivos" TextField="Archivo_Descripcion" 
                                ValueField="idArchivo" ValueType="System.Int32">
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="Archivo de Concentración" 
                            FieldName="idArchivoDestino" VisibleIndex="4">
                            <PropertiesComboBox DataSourceID="dsArchivos" TextField="Archivo_Descripcion" 
                                ValueField="idArchivo" ValueType="System.Int32">
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataMemoColumn Caption="Notas" FieldName="Notas_Aplicacion" 
                            VisibleIndex="6">
                        </dxwgv:GridViewDataMemoColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="Status" FieldName="Status" 
                            VisibleIndex="7">
                            <PropertiesComboBox ValueType="System.Int32">
                                <Items>
                                    <dx:ListEditItem Text="Activa" Value="0" />
                                    <dx:ListEditItem Text="Cancelada" Value="-1" />
                                    <dx:ListEditItem Text="Transferida" Value="2" />
                                    <dx:ListEditItem Text="Transferida y Recibida" Value="3" />
                                </Items>
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Detalle" VisibleIndex="8">
                            <DataItemTemplate>
                                <dx:ASPxButton ID="btnVerHist" runat="server" CommandName="btnVer" Text="Ver" 
                                    Width="60px">
                                </dx:ASPxButton>
                            </DataItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowTitlePanel="True" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
    <cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox>
    <asp:ObjectDataSource ID="dsTransferenciaActiva" runat="server" 
            SelectMethod="ListaTransferencias_Secunarias" 
        TypeName="Portalv9.WSArchivo.Service1" 
        InsertMethod="ABC_Transferencias_Secundarias" 
        UpdateMethod="ABC_Transferencias_Secundarias">
        <UpdateParameters>
            <asp:Parameter DefaultValue="2" Name="op" Type="Int32" />
            <asp:Parameter DefaultValue="" Name="idFolio" Type="Int32" />
            <asp:Parameter Name="Usrid" Type="Int32" />
            <asp:Parameter Name="Fecha_Solicitud" Type="DateTime" />
            <asp:Parameter Name="idArchivoOrigen" Type="Int32" />
            <asp:Parameter Name="idArchivoDestino" Type="Int32" />
            <asp:Parameter Name="Notas_Solicitud" Type="String" />
            <asp:Parameter DefaultValue="0" Name="Status" Type="Int32" />
        </UpdateParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="Status" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter DefaultValue="0" Name="op" Type="Int32" />
            <asp:Parameter Name="idFolio" Type="Int32" />
            <asp:Parameter Name="Usrid" Type="Int32" />
            <asp:Parameter Name="Fecha_Solicitud" Type="DateTime" />
            <asp:Parameter Name="idArchivoOrigen" Type="Int32" />
            <asp:Parameter Name="idArchivoDestino" Type="Int32" />
            <asp:Parameter Name="Notas_Solicitud" Type="String" />
            <asp:Parameter Name="Status" Type="Int32" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsTransferenciaHistorica" runat="server" 
        SelectMethod="ListaTransferencias_Secunarias" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Status" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsArchivos" runat="server" 
            SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsArchivosTipo" runat="server" 
            SelectMethod="ListaArchivos_Tipo" 
        TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="Tipo_Archivo" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsArchivosConcentracion" runat="server" 
            SelectMethod="ListaArchivos_Tipo" 
        TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Tipo_Archivo" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>


