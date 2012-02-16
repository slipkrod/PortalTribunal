<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="wfrm_Transferencia_EntreArchivos.aspx.vb" Inherits="Portalv9.wfrm_Transferencia_EntreArchivos" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Transferencia interna de nodo en un mismo archivo"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="overflow: auto; width: 1000px; height: 620px;">
    <table style="border: 3px solid #C9D7DD; width: 100%; z-index: 99;">
        <tr>
            <td style="border: thin solid #C9D7DD" colspan="2">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top">Archivo Origen:</td>
                        <td style="vertical-align: top">
                            <dxe:ASPxComboBox ID="cmbArchivo" runat="server" 
                                DataSourceID="ObjectDataSource1" ValueType="System.Int32" 
                                TextField="Archivo_Descripcion" ValueField="idArchivo" Width="370px" 
                                AutoPostBack="True">
                            </dxe:ASPxComboBox>
                        </td>
                        <td style="vertical-align: top">Archivo Destino:</td>
                        <td style="vertical-align: top">
                            <dxe:ASPxComboBox ID="cmbArchivoDestino" runat="server" 
                                DataSourceID="ObjectDataSource1" ValueType="System.Int32" 
                                TextField="Archivo_Descripcion" ValueField="idArchivo" Width="370px" 
                                AutoPostBack="True">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
        <table style="width: 100%; vertical-align: top;">
            <tr>
                <td style="width: 37px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" 
                    style="font-size: 14px; font-weight: bold; font-family: Arial; background-color: #006600; color: #FFFFFF">
                    Transferir de:</td>
                <td style="font-size: 14px; font-weight: bold; font-family: Arial; background-color: #003399; color: #FFFFFF">
                    Transferir a:</td>
            </tr>
            <tr>
                <td colspan="2" style="vertical-align: top">
                <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dsBuscaExpediente" 
                    KeyFieldName="idDescripcion" ParentFieldName="idDocumentoPID" 
                    EnableTheming="False" Width="399px" EnableViewState="False">
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguro desea borrar este registro?" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos." />
                    <SettingsSelection Enabled="True" />
                    <SettingsPager PageSize="20">
                    </SettingsPager>
                    <SettingsBehavior AllowSort="False" />
                    <SettingsEditing EditFormColumnCount="1" Mode="EditFormAndDisplayNode" />
                    <Columns>
                        <dxwtl:TreeListTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Tipo" VisibleIndex="0" ReadOnly="True" 
                            Width="30px">
                            <EditFormSettings Visible="False" />
                            <DataCellTemplate>
                                <dxe:ASPxImage ID="ASPxImage1" runat="server" ImageUrl="<%# GetNodeGlyph(Container) %>">
                                </dxe:ASPxImage>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nombre" FieldName="Descripcion" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
                            Visible="False" VisibleIndex="3">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Imagen_close" FieldName="Imagen_close" 
                            Name="Imagen_close" Visible="False" VisibleIndex="2">
                        </dxwtl:TreeListTextColumn>
                    </Columns>
                </dxwtl:ASPxTreeList>            
                </td>
                <td style="vertical-align: top">
                <dxwtl:ASPxTreeList ID="ASPxTreeList2" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dsListaFondo" 
                    KeyFieldName="idDescripcion" ParentFieldName="idDocumentoPID" 
                    EnableTheming="False" Width="399px" EnableViewState="False">
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguro desea borrar este registro?" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos." />
                    <SettingsSelection Enabled="True" />
                    <SettingsPager PageSize="20">
                    </SettingsPager>
                    <SettingsBehavior AllowSort="False" />
                    <SettingsEditing EditFormColumnCount="1" Mode="EditFormAndDisplayNode" />
                    <Columns>
                        <dxwtl:TreeListTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Tipo" VisibleIndex="0" ReadOnly="True" 
                            Width="30px">
                            <EditFormSettings Visible="False" />
                            <DataCellTemplate>
                                <dxe:ASPxImage ID="ASPxImage2" runat="server" ImageUrl='<%# Eval("Imagen_Open") %>'>
                                </dxe:ASPxImage>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nombre" FieldName="Descripcion" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
                            Visible="False" VisibleIndex="3">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Imagen_open" FieldName="Imagen_open" 
                            Name="Imagen_open" Visible="False" VisibleIndex="2">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Imagen_close" FieldName="Imagen_close" 
                            Name="Imagen_close" Visible="False" VisibleIndex="2">
                        </dxwtl:TreeListTextColumn>
                    </Columns>
                </dxwtl:ASPxTreeList>            
                </td>
            </tr>
            </table>
        </div>
        <table style="width: 100%">
            <tr>
                <td style="vertical-align: top">
                            <dxe:ASPxButton ID="Transferir" runat="server" Text="Transferir">
                                <Image Url="~/Images/adicional.png" />
                            </dxe:ASPxButton>
                        </td>
                <td style="vertical-align: top">
                    &nbsp;</td>
            </tr>
        </table>
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="ListaArchivo_Niveles_Norma" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbArchivo" Name="idArchivo" 
                PropertyName="Value" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="Nivel_Logico_Fisico" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
        SelectMethod="ListaArchivo_Niveles_Norma" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbArchivo" Name="idArchivo" 
                PropertyName="Value" Type="Int32" />
            <asp:Parameter Name="Nivel_Logico_Fisico" Type="Int32" DefaultValue="1" />
        </SelectParameters>
    </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="ds_Entidades" runat="server" 
         SelectMethod="ListaFondoxNivel" TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
                    <SelectParameters>
                        <asp:Parameter Name="idArchivo" Type="Int32" />
                        <asp:Parameter DefaultValue="3" Name="Fondo_ini" Type="Int32" />
                        <asp:Parameter DefaultValue="3" Name="Fondo_fin" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>

<%--                <asp:ObjectDataSource ID="ds_AreasAdministrativas" runat="server" 
         SelectMethod="ListaFondoxNivelxPadre" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
                    <SelectParameters>
                        <asp:Parameter Name="idArchivo" Type="Int32" />
                        <asp:Parameter DefaultValue="4" Name="Fondo_ini" Type="Int32" />
                        <asp:Parameter DefaultValue="4" Name="Fondo_fin" Type="Int32" />
                        <asp:ControlParameter ControlID="ASPxComboBox1" DefaultValue="" Name="Padre" 
                            PropertyName="Value" Type="Int32" />
                    </SelectParameters>
     </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="dsLista_SeriesModelo" runat="server" SelectMethod="ListaSeries_Modelo" 
        TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:Parameter Name="identidad" Type="Int32" DefaultValue="" />
                        <asp:Parameter DefaultValue="5" Name="Profundidad" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
--%>            
                <asp:ObjectDataSource ID="dsListaFondo" runat="server" 
                    SelectMethod="ListaFondo" TypeName="Portalv9.WSArchivo.Service1" OldValuesParameterFormatString="{0}">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="-1" Name="idArchivo" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsBuscaExpediente" runat="server" SelectMethod="getPadresBusqueda" TypeName="Portalv9.WSArchivo.Service1" OldValuesParameterFormatString="{0}">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="" Name="idArchivo" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="Entidad" Type="String" />
                        <asp:Parameter Name="Area" Type="String" />
                        <asp:Parameter Name="Tipo_expediente" Type="Int32" />
                        <asp:Parameter Name="ano" Type="String" />
                        <asp:Parameter Name="mes" Type="String" />
                        <asp:Parameter Name="dia" Type="String" />
                        <asp:Parameter Name="Palabra" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
                <cc1:MsgBox ID="MsgBox1" runat="server" />

                </asp:Content>

