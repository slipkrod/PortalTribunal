<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_Normas_Organizacion_Series.aspx.vb" Inherits="Portalv9.Wfrm_Normas_Organizacion_Series1" %>
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
<asp:Label ID="lblTitle" runat="server" Text=" Administración--&gt; Unidad Documental Compuesta - Subserie"></asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

    <table style="width: 100%">
        <tr>
            <td style="vertical-align: top;">
    <div __designer:mapid="0">
    	    <dxe:ASPxHyperLink ID="Regresar" runat="server" 
                ImageUrl="~/Images/regresar.gif" NavigateUrl='<%# "~/Wfrm_Normas_Organizacion.aspx?&idNorma=" & Request.QueryString("idNorma") %>' />
    	    <asp:label id="lblTitle0" runat="server" Font-Size="Small" Width="232px" 
                Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br __designer:mapid="3" />
    </div>
                <dxwgv:ASPxGridView ID="gdSeries" runat="server" 
                    DataSourceID="dsLista_SeriesModelo" AutoGenerateColumns="False" 
                    KeyFieldName="idSerie">
                    <SettingsEditing EditFormColumnCount="1" NewItemRowPosition="Bottom" />
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguri desea eliminar este registro?" 
                        EmptyDataRow="No existen datos" />
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="idNorma" FieldName="idNorma" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" 
                            VisibleIndex="0" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Tipo de expediente" FieldName="Serie_nombre" 
                            VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Clave" FieldName="Clave" Name="Clave" 
                            VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="Atributo" FieldName="Atributo" 
                            VisibleIndex="2">
                            <PropertiesComboBox ValueType="System.Int32">
                                <Items>
                                    <dxe:ListEditItem Text="Opcional" Value="0" />
                                    <dxe:ListEditItem Text="Al menos uno" Value="1" />
                                    <dxe:ListEditItem Text="Requerido" Value="2" />
                                </Items>
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idSeriePID" FieldName="idSeriePID" 
                            VisibleIndex="2" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewCommandColumn VisibleIndex="3">
                            <EditButton Visible="True">
                            </EditButton>
                            <NewButton Visible="True">
                            </NewButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Separadores" FieldName="idSerie" 
                            VisibleIndex="4">
                            <PropertiesTextEdit DisplayFormatString="{0}">
                            </PropertiesTextEdit>
                            <EditFormSettings Visible="False" />
                            <DataItemTemplate>
                                <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Detalle" NavigateUrl='<%# "Wfrm_Normas_Organizacion_SubSeries.aspx?idNorma=" & Eval("idNorma").ToString  & "&idNivel=" & Eval("idNivel").ToString  & "&idSerie=" & Eval("idSerie").ToString %>'/>
                            </DataItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indices" FieldName="idSerie" 
                            VisibleIndex="5">
                            <EditFormSettings Visible="False" />
                            <DataItemTemplate>
                                <dxe:ASPxHyperLink ID="ASPxHyperLink2" runat="server" Text="Detalle" NavigateUrl='<%# "Wfrm_Normas_Organizacion_indices.aspx?TipoExp=0&idNorma=" & Eval("idNorma").ToString  & "&idNivel=" & Eval("idNivel").ToString  & "&idSerie=" & Eval("idSerie").ToString %>' />
                            </DataItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Período de préstamo" Visible="False" 
                            VisibleIndex="6">
                            <EditFormSettings Visible="True" />
                            <EditItemTemplate>
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <dxe:ASPxSpinEdit ID="ASPxSpinEdit1" runat="server" Height="21px" 
                                                Number='<%# Bind("Periodo_Prestamo") %>' Width="98px" />
                                        </td>
                                        <td>
                                            <dxe:ASPxComboBox ID="ASPxComboBox1" runat="server" 
                                                Value='<%# Bind("idFrecuencia_prestamo") %>' ValueType="System.Int32">
                                                <Items>
                                                    <dxe:ListEditItem Text="Días" Value="1" />
                                                    <dxe:ListEditItem Text="Semanas" Value="2" />
                                                    <dxe:ListEditItem Text="Meses" Value="3" />
                                                    <dxe:ListEditItem Text="Años" Value="4" />
                                                </Items>
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Período de guarda activo" 
                            Visible="False" VisibleIndex="6">
                            <EditFormSettings Visible="True" />
                            <EditItemTemplate>
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <dxe:ASPxSpinEdit ID="ASPxSpinEdit1" runat="server" Height="21px" 
                                                Number='<%# Bind("Periodo_guardaActivo") %>' Width="98px" />
                                        </td>
                                        <td>
                                            <dxe:ASPxComboBox ID="ASPxComboBox1" runat="server" 
                                                Value='<%# Bind("idFrecuencia_guardaActivo") %>' ValueType="System.Int32">
                                                <Items>
                                                    <dxe:ListEditItem Text="Días" Value="1" />
                                                    <dxe:ListEditItem Text="Semanas" Value="2" />
                                                    <dxe:ListEditItem Text="Meses" Value="3" />
                                                    <dxe:ListEditItem Text="Años" Value="4" />
                                                </Items>
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Período de guarda Inactivo" 
                            Visible="False" VisibleIndex="6">
                            <EditFormSettings Visible="True" />
                            <EditItemTemplate>
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <dxe:ASPxSpinEdit ID="ASPxSpinEdit1" runat="server" Height="21px" 
                                                Number='<%# Bind("Periodo_guardaInactivo") %>' Width="98px" />
                                        </td>
                                        <td>
                                            <dxe:ASPxComboBox ID="ASPxComboBox1" runat="server" 
                                                Value='<%# Bind("idFrecuencia_guardaInactivo") %>' ValueType="System.Int32">
                                                <Items>
                                                    <dxe:ListEditItem Text="Días" Value="1" />
                                                    <dxe:ListEditItem Text="Semanas" Value="2" />
                                                    <dxe:ListEditItem Text="Meses" Value="3" />
                                                    <dxe:ListEditItem Text="Años" Value="4" />
                                                </Items>
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataSpinEditColumn Caption="Resellos" FieldName="Num_Resellos" 
                            Visible="False" VisibleIndex="6">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                            <EditFormSettings Visible="True" />
                        </dxwgv:GridViewDataSpinEditColumn>                        
                    </Columns>
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:MsgBox ID="dlgBoxExcepciones" runat="server" />
                <asp:ObjectDataSource ID="dsLista_SeriesModelo" runat="server" 
                    SelectMethod="ListaSeries_ModeloxNivel" TypeName="Portalv9.WSArchivo.Service1" 
                    DeleteMethod="ABC_Series_Modelo" InsertMethod="ABC_Series_Modelo" 
                    UpdateMethod="ABC_Series_Modelo">
                    <DeleteParameters>
                        <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
                        <asp:QueryStringParameter DefaultValue="" Name="idNorma" 
                            QueryStringField="idNorma" Type="Int32" />
                        <asp:Parameter Name="idNivel" Type="Int32" DefaultValue="" />
                        <asp:Parameter Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="Serie_nombre" Type="String" />
                        <asp:Parameter Name="Clave" Type="String" />
                        <asp:Parameter DefaultValue="" Name="Atributo" Type="Int32" />
                        <asp:Parameter Name="idSeriePID" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="identidad" Type="Int32" />
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
                        <asp:Parameter Name="idNorma" Type="Int32" />
                        <asp:Parameter Name="idNivel" Type="Int32" />
                        <asp:Parameter Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="Serie_nombre" Type="String" />
                        <asp:Parameter Name="Clave" Type="String" />
                        <asp:Parameter Name="Atributo" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="idSeriePID" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="identidad" Type="Int32" />
                        <asp:Parameter Name="Periodo_Prestamo" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_prestamo" Type="Int32" />
                        <asp:Parameter Name="Num_Resellos" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_guardaActivo" Type="Int32" />
                        <asp:Parameter Name="Periodo_guardaActivo" Type="Int32" />
                        <asp:Parameter Name="idFrecuencia_guardaInactivo" Type="Int32" />
                        <asp:Parameter Name="Periodo_guardaInactivo" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:Parameter Name="identidad" Type="Int32" />
                        <asp:QueryStringParameter Name="idNivel" QueryStringField="idNivel" 
                            Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                        <asp:QueryStringParameter DefaultValue="" Name="idNorma" 
                            QueryStringField="idNorma" Type="Int32" />
                        <asp:QueryStringParameter DefaultValue="" Name="idNivel" 
                            QueryStringField="idNivel" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="Serie_nombre" Type="String" />
                        <asp:Parameter DefaultValue="" Name="Clave" Type="String" />
                        <asp:Parameter Name="Atributo" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="idSeriePID" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="identidad" Type="Int32" />
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
        </table>
</asp:Content>
