<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="wfrm_Transferencia_Int.aspx.vb" Inherits="Portalv9.wfrm_Transferencia_Int" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"   Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
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
    
        <table style="border: 3px solid #C9D7DD; width: 100%; z-index: 99;">
        <tr>
            <td style="border: thin solid #C9D7DD" colspan="2">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top">
                    Archivo:</td>
                        <td style="vertical-align: top">
                     <dxe:ASPxComboBox ID="cmbArchivo" runat="server" 
                    DataSourceID="ObjectDataSource1" ValueType="System.Int32" 
                    TextField="Archivo_Descripcion" ValueField="idArchivo" Width="650px" 
                    AutoPostBack="True">
                         <Columns>
                             <dxe:ListBoxColumn Caption="idArchivo" FieldName="idArchivo" Visible="False" />
                             <dxe:ListBoxColumn Caption="idNorma" FieldName="idNorma" Visible="False" />
                             <dxe:ListBoxColumn Caption="Archivo" FieldName="Archivo_Descripcion" 
                                 Width="600px" />
                             <dxe:ListBoxColumn Caption="Tipo_Archivo" FieldName="Tipo_Archivo" 
                                 Visible="False" />
                         </Columns>
                    </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <dxe:ASPxLabel ID="lblFolio" runat="server" ClientVisible="False">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="vertical-align: top">
                            <dxe:ASPxCheckBox ID="chkTransferencia" runat="server" AutoPostBack="True" 
                                ClientVisible="False" 
                                Text="Existe una transferencia primaria activa. Desa filtrar los datos?.">
                            </dxe:ASPxCheckBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>    
    </table>
        <div style="overflow: auto; width: 1000px; height: 620px; vertical-align: top;">
        <table style="width: 100%; vertical-align: top;">
            <tr>
                <td style="width: 37px; height: 16px;">
                    <dxe:aspxbutton ID="btnExpand" runat="server" Text="Expander todo" Width="120px">
                    </dxe:aspxbutton>
                    </td>
                <td style="height: 16px; width: 202px;">
                    <dxe:aspxbutton ID="btnCollapse" runat="server" Text="Contraer todo">
                    </dxe:aspxbutton>
                    </td>
                <td style="height: 16px">
                    </td>
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
                        <dxwtl:TreeListTextColumn caption="idSerie" 
                            fieldname="idSerie" visible="False" visibleindex="1"></dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn caption="Tipo" readonly="True" 
                            visibleindex="0" width="30px">
                        <editformsettings visible="False"></editformsettings>
                        <datacelltemplate>
                                <dxe:ASPxImage ID="ASPxImage1" runat="server" 
                            ImageUrl="<%# GetNodeGlyph(Container) %>">
                                </dxe:ASPxImage>
                            
                            </datacelltemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn caption="Nombre" 
                            fieldname="Descripcion" visibleindex="1"></dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn caption="idDocumentoPID" 
                            fieldname="idDocumentoPID" visible="False" visibleindex="3"></dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn caption="Imagen_close" 
                            fieldname="Imagen_close" name="Imagen_close" visible="False" visibleindex="2"></dxwtl:TreeListTextColumn>
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
                                <dxe:ASPxImage ID="ASPxImage2" runat="server" 
                                    ImageUrl="<%# GetNodeGlyphB(Container) %>">
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
        <table style="width: 100%; ">
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
        OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="dsListaFondo" runat="server" 
                    SelectMethod="ListaFondo" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="-1" Name="idArchivo" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
                <asp:ObjectDataSource ID="dsListaFondoFiltrado" runat="server" 
                    SelectMethod="ListaArchivo_Descripciones_Transferencia_Filtro" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="" Name="idArchivo" Type="Int32" />
                        <asp:Parameter Name="idFolio" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
                <asp:ObjectDataSource ID="dsBuscaExpediente" runat="server" 
                    SelectMethod="ListaFondo" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="-1" Name="idArchivo" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
                <asp:ObjectDataSource ID="dsBuscaExpedienteFiltrado" runat="server" 
                    SelectMethod="ListaArchivo_Descripciones_Transferencia_Filtro" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="" Name="idArchivo" Type="Int32" />
                        <asp:Parameter Name="idFolio" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
                <cc1:MsgBox ID="MsgBox1" runat="server" />

                </asp:Content>

