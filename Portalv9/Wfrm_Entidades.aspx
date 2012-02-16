<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_Entidades.aspx.vb" Inherits="Portalv9.Wfrm_Entidades" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text=" Administración--&gt; Unidad Documental Compuesta - Subserie"></asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

    <table style="width: 100%">
        <tr>
            <td style="height: 36px">
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                    Font-Names="Arial" Font-Size="10pt" Height="20px" Width="477px"> Administración--&gt; Unidad Documental Compuesta - Subserie</asp:Label>
                <br />
                <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dsListaFondoxNivel" 
                    KeyFieldName="idDescripcion" ParentFieldName="idDocumentoPID" 
                    EnableTheming="False" Width="399px" EnableViewState="False">
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguro desea borrar este registro?" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos." />
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
                        <dxwtl:TreeListTextColumn Caption="Tipo de elemento" FieldName="idSerie" 
                            Name="idSerie" VisibleIndex="2" Visible="False">
                            <EditFormSettings Visible="True" />
                            <EditCellTemplate>
                                <dxe:ASPxComboBox ID="cmbTipodeElemento" runat="server" 
                                    DataSourceID="dsListaSeries_ModeloxRango" TextField="Serie_nombre" 
                                    ValueField="idSerie" ValueType="System.Int32">
                                    <Columns>
                                        <dxe:ListBoxColumn Caption="idNorma" FieldName="idNorma" Name="idNorma" 
                                            Visible="False" />
                                        <dxe:ListBoxColumn Caption="idNivel" FieldName="idNivel" Name="idNivel" 
                                            Visible="False" />
                                        <dxe:ListBoxColumn Caption="idSerie" FieldName="idSerie" Name="idSerie" 
                                            Visible="False" />
                                        <dxe:ListBoxColumn Caption="Tipo de elemento" FieldName="Serie_nombre" 
                                            Name="Serie_nombre" />
                                        <dxe:ListBoxColumn Caption="Atributo" FieldName="Atributo" Name="Atributo" 
                                            Visible="False" />
                                        <dxe:ListBoxColumn Caption="PermisoID" FieldName="PermisoID" Name="PermisoID" 
                                            Visible="False" />
                                    </Columns>
                                </dxe:ASPxComboBox>
                            </EditCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
                            Visible="False" VisibleIndex="3">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Clave" Name="Clave" Visible="False" 
                            VisibleIndex="2" FieldName="Clave">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Visible="True" />
                            <EditCellTemplate>
                                <dxe:ASPxTextBox ID="ValorClave" runat="server" MaxLength="2" Width="100px">
                                </dxe:ASPxTextBox>
                            </EditCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idDescripcion" FieldName="idDescripcion" 
                            VisibleIndex="3" Visible="False">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListCommandColumn VisibleIndex="2" Width="110px">
                            <EditButton Visible="True">
                            </EditButton>
                            <NewButton Visible="True">
                            </NewButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                        </dxwtl:TreeListCommandColumn>
                    </Columns>
                </dxwtl:ASPxTreeList>
            
            </td>
        </tr>
        <tr>
            <td>
                <cc1:MsgBox ID="dlgBoxExcepciones" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:ObjectDataSource ID="dsListaFondoxNivel" runat="server" 
                    SelectMethod="ListaFondoxNivel" TypeName="Portalv9.WSArchivo.Service1" 
                    DeleteMethod="ABC_Archivo_Descripciones" InsertMethod="ABC_Archivo_Descripciones" 
                    UpdateMethod="ABC_Archivo_Descripciones">
                    <DeleteParameters>
                        <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
                        <asp:QueryStringParameter Name="idArchivo" Type="Int32" />
                        <asp:Parameter Name="idDescripcion" Type="Int32" />
                        <asp:Parameter Name="Codigo_clasificacion" Type="String" />
                        <asp:Parameter Name="idNivel" Type="Int32" />
                        <asp:Parameter Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="valuePath" Type="String" />
                        <asp:Parameter Name="idUnidadInstalacion" Type="Int32"/>
                        <asp:Parameter Name="Descripcion" Type="String" />
                        <asp:Parameter Name="idTipoElemento" Type="Int32" />
                        <asp:Parameter Name="idDocumentoPID" Type="Int32" />
                        <asp:Parameter Name="Atributo" Type="Int32" />
                        <asp:Parameter Name="idArchivo_Fisico" Type="Int32" />
                        <asp:Parameter Name="idPlanta" Type="Int32" />
                        <asp:Parameter Name="idPasillo" Type="Int32" />
                        <asp:Parameter Name="idSeccion" Type="Int32" />
                        <asp:Parameter Name="idEstante" Type="Int32" />
                        <asp:Parameter Name="idBalda" Type="Int32" />
                        <asp:Parameter Name="unidad_Instalacion" Type="String" />
                        <asp:Parameter Name="unidad_instalacion_subdivision" Type="String" />
                        <asp:Parameter Name="unidad_instalacion_orden" Type="String" />
                        <asp:Parameter Name="Ano" Type="String" />
                        <asp:Parameter Name="Mes" Type="String" />
                        <asp:Parameter Name="Dia" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
                        <asp:QueryStringParameter DefaultValue="" Name="idArchivo" 
                            QueryStringField="idArchivo" Type="Int32" />
                        <asp:Parameter Name="idDescripcion" Type="Int32" />
                        <asp:Parameter Name="Codigo_clasificacion" Type="String" />
                        <asp:Parameter Name="idNivel" Type="Int32" DefaultValue="" />
                        <asp:Parameter Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="valuePath" Type="String" />
                        <asp:Parameter Name="idUnidadInstalacion" Type="Int32"/>
                        <asp:Parameter Name="Descripcion" Type="String" />
                        <asp:Parameter Name="idTipoElemento" Type="Int32" />
                        <asp:Parameter Name="idDocumentoPID" Type="Int32" />
                        <asp:Parameter Name="Atributo" Type="Int32" />
                        <asp:Parameter Name="idArchivo_Fisico" Type="Int32" />
                        <asp:Parameter Name="idPlanta" Type="Int32" />
                        <asp:Parameter Name="idPasillo" Type="Int32" />
                        <asp:Parameter Name="idSeccion" Type="Int32" />
                        <asp:Parameter Name="idEstante" Type="Int32" />
                        <asp:Parameter Name="idBalda" Type="Int32" />
                        <asp:Parameter Name="unidad_Instalacion" Type="String" />
                        <asp:Parameter Name="unidad_instalacion_subdivision" Type="String" />
                        <asp:Parameter Name="unidad_instalacion_orden" Type="String" />
                        <asp:Parameter Name="Ano" Type="String" />
                        <asp:Parameter Name="Mes" Type="String" />
                        <asp:Parameter Name="Dia" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" 
                            Type="Int32" />
                        <asp:QueryStringParameter Name="Fondo_ini" QueryStringField="Fondo_ini" 
                            Type="Int32" />
                        <asp:QueryStringParameter Name="Fondo_fin" QueryStringField="Fondo_fin" 
                            Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                        <asp:QueryStringParameter DefaultValue="" Name="idArchivo" 
                            QueryStringField="idArchivo" Type="Int32" />
                        <asp:Parameter Name="idDescripcion" Type="Int32" DefaultValue="" 
                            Direction="Output" />
                        <asp:Parameter Name="Codigo_clasificacion" Type="String" />
                        <asp:Parameter DefaultValue="" Name="idNivel" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="valuePath" Type="String" />
                        <asp:Parameter Name="idUnidadInstalacion" Type="Int32"/>
                        <asp:Parameter Name="Descripcion" Type="String" />
                        <asp:Parameter Name="idTipoElemento" Type="Int32" />
                        <asp:Parameter Name="idDocumentoPID" Type="Int32" />
                        <asp:Parameter Name="Atributo" Type="Int32" />
                        <asp:Parameter Name="idArchivo_Fisico" Type="Int32" />
                        <asp:Parameter Name="idPlanta" Type="Int32" />
                        <asp:Parameter Name="idPasillo" Type="Int32" />
                        <asp:Parameter Name="idSeccion" Type="Int32" />
                        <asp:Parameter Name="idEstante" Type="Int32" />
                        <asp:Parameter Name="idBalda" Type="Int32" />
                        <asp:Parameter Name="unidad_Instalacion" Type="String" />
                        <asp:Parameter Name="unidad_instalacion_subdivision" Type="String" />
                        <asp:Parameter Name="unidad_instalacion_orden" Type="String" />
                        <asp:Parameter Name="Ano" Type="String" />
                        <asp:Parameter Name="Mes" Type="String" />
                        <asp:Parameter Name="Dia" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsListaSeries_ModeloxRango" runat="server" 
                    SelectMethod="ListaSeries_ModeloxRango" TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:Parameter Name="identidad" Type="Int32" />
                        <asp:Parameter DefaultValue="3" Name="nivel_ini" Type="Int32" />
                        <asp:Parameter DefaultValue="4" Name="nivel_fin" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

