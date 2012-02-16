<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_Normas_Organizacion_SubSeries.aspx.vb" Inherits="Portalv9.Wfrm_Normas_Organizacion_Series" %>
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
                ImageUrl="~/Images/regresar.gif" NavigateUrl='<%# "~/Wfrm_Normas_Organizacion_Series.aspx?&idNorma=" & Request.QueryString("idNorma") & "&idNivel=" & Request.QueryString("idNivel") %>' />
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="True" 
                    Font-Names="Arial" Font-Size="10pt" Height="20px" Width="477px"> Administración--&gt; Unidad Documental Compuesta - Subserie</asp:Label>
                <br />
                <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dsLista_SeriesModelo_Hijos" 
                    KeyFieldName="idSerie" ParentFieldName="idSeriePID" 
                    EnableTheming="False" Width="195px" EnableViewState="False">
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguro desea borrar este registro?" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos." />
                    <SettingsPager PageSize="20">
                    </SettingsPager>
                    <SettingsBehavior AllowSort="False" />
                    <SettingsEditing EditFormColumnCount="1" Mode="EditFormAndDisplayNode" />
                    <Columns>
                        <dxwtl:TreeListTextColumn Caption="idNorma" FieldName="idNorma" Visible="False" 
                            VisibleIndex="0">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Tipo" VisibleIndex="0" ReadOnly="True">
                            <EditFormSettings Visible="False" />
                            <DataCellTemplate>
                                <dxe:ASPxImage ID="ASPxImage1" runat="server" ImageUrl="<%# GetNodeGlyph(Container) %>">
                                </dxe:ASPxImage>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nombre" FieldName="Serie_nombre" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListComboBoxColumn Caption="Tipo de elemento" FieldName="idNivel" 
                            VisibleIndex="2" Visible="False">
                            <PropertiesComboBox ValueType="System.Int32">
                                <Items>
                                    <dxe:ListEditItem Text="Separador" Value="220" />
                                    <dxe:ListEditItem Text="Documento" Value="223" />
                                </Items>
                            </PropertiesComboBox>
                            <EditFormSettings Visible="True" />
                        </dxwtl:TreeListComboBoxColumn>
                        <dxwtl:TreeListComboBoxColumn Caption="Atributo" FieldName="Atributo" 
                            VisibleIndex="2">
                            <PropertiesComboBox ValueType="System.Int32">
                                <Items>
                                    <dxe:ListEditItem Text="Opcional" Value="0" />
                                    <dxe:ListEditItem Text="Al menos uno" Value="1" />
                                    <dxe:ListEditItem Text="Requerido" Value="2" />
                                </Items>
                            </PropertiesComboBox>
                        </dxwtl:TreeListComboBoxColumn>
                        <dxwtl:TreeListTextColumn Caption="idSeriePID" FieldName="idSeriePID" 
                            Visible="False" VisibleIndex="3">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListCommandColumn ShowNewButtonInHeader="True" VisibleIndex="3">
                            <EditButton Visible="True">
                            </EditButton>
                            <NewButton Visible="True">
                            </NewButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                        </dxwtl:TreeListCommandColumn>
                        <dxwtl:TreeListTextColumn Caption="Indices" VisibleIndex="4">
                            <PropertiesTextEdit DisplayFormatString="{0}">
                            </PropertiesTextEdit>
                            <EditFormSettings Visible="False" />
                            <DataCellTemplate>
                                <dxe:ASPxHyperLink ID="ASPxHyperLink2" runat="server" Text="Detalle" NavigateUrl='<%# "Wfrm_Normas_Organizacion_indices.aspx?idNorma=" & Eval("idNorma").ToString  & "&idNivelP=" & Request.QueryString("idNivel").ToString  & "&idNivel=" & Eval("idNivel").ToString  & "&idSerie=" & Eval("idSerie").ToString & "&idSerieP=" & Request.QueryString("idSerie").ToString & "&TipoExp=1" %>'/>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Imagen_close" FieldName="Imagen_close" 
                            Name="Imagen_close" Visible="False" VisibleIndex="5">
                        </dxwtl:TreeListTextColumn>
                    </Columns>
                </dxwtl:ASPxTreeList>
            
            </td>
        </tr>
        <tr>
            <td>
                <cc1:MsgBox ID="dlgBoxExcepciones" runat="server" />
                <asp:ObjectDataSource ID="dsLista_SeriesModelo_Hijos" runat="server" 
                    SelectMethod="ListaSeries_Modelo_Hijos" TypeName="Portalv9.WSArchivo.Service1" 
                    DeleteMethod="ABC_Series_Modelo" InsertMethod="ABC_Series_Modelo" 
                    UpdateMethod="ABC_Series_Modelo">
                    <DeleteParameters>
                        <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
                        <asp:QueryStringParameter  Name="idNorma"                             
                        QueryStringField="idNorma" Type="Int32" />
                        <asp:Parameter Name="idNivel" Type="Int32" />
                        <asp:Parameter Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="Serie_nombre" Type="String" />
                        <asp:Parameter Name="Clave" Type="String" DefaultValue=""/>
                        <asp:Parameter Name="Atributo" Type="Int32" />
                        <asp:Parameter Name="idSeriePID" Type="Int32" />
                        <asp:Parameter Name="identidad" Type="Int32" />
                        <asp:Parameter Name="Periodo_Prestamo" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_prestamo" Type="Int32" />
                        <asp:Parameter Name="Num_Resellos" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_guardaActivo" Type="Int32" />
                        <asp:Parameter Name="Periodo_guardaActivo" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_guardaInactivo" Type="Int32" />
                        <asp:Parameter Name="Periodo_guardaInactivo" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
                        <asp:QueryStringParameter Name="idNorma" 
                            QueryStringField="idNorma" Type="Int32" />
                        <asp:Parameter Name="idNivel" Type="Int32" DefaultValue="" />
                        <asp:Parameter Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="Serie_nombre" Type="String" />
                        <asp:Parameter Name="Clave" Type="String" DefaultValue=""/>
                        <asp:Parameter Name="Atributo" Type="Int32" />
                        <asp:Parameter Name="idSeriePID" Type="Int32" />
                        <asp:Parameter Name="identidad" Type="Int32" />
                        <asp:Parameter Name="Periodo_Prestamo" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_prestamo" Type="Int32" />
                        <asp:Parameter Name="Num_Resellos" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_guardaActivo" Type="Int32" />
                        <asp:Parameter Name="Periodo_guardaActivo" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_guardaInactivo" Type="Int32" />
                        <asp:Parameter Name="Periodo_guardaInactivo" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" 
                            Type="Int32" />
                        <asp:Parameter Name="identidad" Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                        <asp:QueryStringParameter Name="idNorma" 
                            QueryStringField="idNorma" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="idNivel" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="Serie_nombre" Type="String" />
                        <asp:Parameter Name="Clave" Type="String" DefaultValue=""/>
                        <asp:Parameter Name="Atributo" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="idSeriePID" Type="Int32" />
                        <asp:Parameter Name="identidad" Type="Int32" />
                        <asp:Parameter Name="Periodo_Prestamo" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_prestamo" Type="Int32" />
                        <asp:Parameter Name="Num_Resellos" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_guardaActivo" Type="Int32" />
                        <asp:Parameter Name="Periodo_guardaActivo" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_guardaInactivo" Type="Int32" />
                        <asp:Parameter Name="Periodo_guardaInactivo" Type="Int32" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

