<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_Archivo_Series.aspx.vb" Inherits="Portalv9.Wfrm_Archivo_Series" %>
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
    	    <dxe:ASPxHyperLink ID="Regresar" runat="server" 
                ImageUrl="~/Images/regresar.gif" 
                    NavigateUrl="~/Wfrm_Archivo_SoloLectura.aspx" />
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                    Font-Names="Arial" Font-Size="10pt" Height="20px" Width="477px"> Administración--&gt; Unidad Documental Compuesta - Subserie</asp:Label>
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ArchivotrifeConnectionString %>"
SelectCommand="select 1000 idArchivo, idDescripcion, Archivo_Descripciones_Archivisticas.idDocumentoPID, 
Archivo_Descripciones_Archivisticas.idNivel, Archivo_Descripciones_Archivisticas.idSerie, 
Codigo_clasificacion, idUnidadInstalacion, Descripcion, idTipoElemento, Atributo,
idArchivo_Fisico, idPlanta, idPasillo, idSeccion, idEstante, idBalda, 
unidad_Instalacion, unidad_instalacion_subdivision, unidad_instalacion_orden,
ano, mes, dia, nivel, Imagen_open,Imagen_close
from Archivo_Descripciones_Archivisticas, niveles where 
Archivo_Descripciones_Archivisticas.idNivel = niveles.idNivel and 
[idArchivo] = @idArchivo and Archivo_Descripciones_Archivisticas.idDocumentoPID = @idDocumentoPID">
            <SelectParameters>
                        <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
                        <asp:Parameter Name="idDocumentoPID" DBType="Int32"/>
                    </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ArchivotrifeConnectionString %>"
SelectCommand="select 1000 idArchivo, idDescripcion, Archivo_Descripciones_Archivisticas.idDocumentoPID, 
Archivo_Descripciones_Archivisticas.idNivel, Archivo_Descripciones_Archivisticas.idSerie, 
Codigo_clasificacion, idUnidadInstalacion, Descripcion, idTipoElemento, Atributo,
idArchivo_Fisico, idPlanta, idPasillo, idSeccion, idEstante, idBalda, 
unidad_Instalacion, unidad_instalacion_subdivision, unidad_instalacion_orden,
ano, mes, dia, nivel, Imagen_open,Imagen_close
from Archivo_Descripciones_Archivisticas, niveles where 
Archivo_Descripciones_Archivisticas.idNivel = niveles.idNivel and Archivo_Descripciones_Archivisticas.idDocumentoPID = 2 and 
[idArchivo] = @idArchivo">
            <SelectParameters>
                        <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
                    </SelectParameters>
                    </asp:SqlDataSource>

                <%--DataSourceID="dsListaFondo" ParentFieldName="idDocumentoPID" --%>
                <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" 
                    AutoGenerateColumns="False" 
                    KeyFieldName="idDescripcion" 
                    EnableTheming="False" Width="399px" EnableViewState="False">
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguro desea borrar este registro?" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos." />
                    <SettingsPager PageSize="30" AlwaysShowPager="True" Mode="ShowPager">
                        <AllButton Visible="True">
                        </AllButton>
                    </SettingsPager>
                    <SettingsBehavior AllowSort="False" />
                    <SettingsEditing EditFormColumnCount="1" Mode="EditFormAndDisplayNode" />
                    <Columns>
                        <dxwtl:TreeListTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <%--<dxwtl:TreeListTextColumn Caption="Tipo" VisibleIndex="0" ReadOnly="True" Width="30px">
                            <EditFormSettings Visible="False" />
                            <DataCellTemplate>
                                <dxe:ASPxImage ID="ASPxImage1" runat="server" ImageUrl="<%# GetNodeGlyph(Container) %>">
                                </dxe:ASPxImage>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>--%>
                        <dxwtl:TreeListTextColumn Caption="Nombre" FieldName="Descripcion" VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" Visible="False" VisibleIndex="3">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Imagen_open" FieldName="Imagen_open" Name="Imagen_open" Visible="False" VisibleIndex="2">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Imagen_close" FieldName="Imagen_close" Name="Imagen_close" Visible="False" VisibleIndex="2">
                        </dxwtl:TreeListTextColumn>
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
                <asp:ObjectDataSource ID="dsListaFondo" runat="server" 
                    SelectMethod="ListaFondo" TypeName="Portalv9.WSArchivo.Service1">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>


