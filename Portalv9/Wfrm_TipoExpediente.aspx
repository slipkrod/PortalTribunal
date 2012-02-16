<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_TipoExpediente.aspx.vb" Inherits="Portalv9.Wfrm_TipoExpediente"  MasterPageFile="~/Masterpages/Adminmaster2col.master" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
    <asp:Label ID="lblTitle" runat="server" Text=" Administración--&gt; Unidad Documental Compuesta - Subserie"></asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <table style="width: 100%">
        <tr>
            <td style="height: 36px">
    	    <dxe:aspxhyperlink ID="Regresar" runat="server" 
                ImageUrl="~/Images/regresar.gif"  />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
                    Font-Names="Arial" Font-Size="10pt" Height="16px" Width="90%"> Administración--&gt; Definición de índices</asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;">
                <dxwgv:ASPxGridView ID="gdSeries" runat="server" 
                    DataSourceID="dsLista_SeriesModelo" AutoGenerateColumns="False" 
                    KeyFieldName="idSerie">
                    <SettingsEditing EditFormColumnCount="1" NewItemRowPosition="Bottom" />
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguri desea eliminar este registro?" 
                        EmptyDataRow="No existen datos" />
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="idNorma" FieldName="idNorma" Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" VisibleIndex="2" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Tipo de expediente" FieldName="Serie_nombre" VisibleIndex="4">
                            <EditFormSettings VisibleIndex="4" />
                            <EditItemTemplate>
                                <dxe:ASPxTextBox ID="Serie_nombre" runat="server" Width="160px" Text='<%# Bind("Serie_nombre") %>'></dxe:ASPxTextBox>
                            </EditItemTemplate>
                        </dxwgv:GridViewDataTextColumn>                        
                        <dxwgv:GridViewDataComboBoxColumn Caption="Atributo" FieldName="Atributo" Visible="False" VisibleIndex="5">
                            <EditFormSettings Visible="False"  />
                            <PropertiesComboBox ValueType="System.Int32">
                                <Items>
                                    <dxe:ListEditItem Text="Opcional" Value="0" />
                                    <dxe:ListEditItem Text="Al menos uno" Value="1" />
                                    <dxe:ListEditItem Text="Requerido" Value="2" />
                                </Items>
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idSeriePID" FieldName="idSeriePID" VisibleIndex="6" Visible="False">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewCommandColumn VisibleIndex="7" Caption="">
                            <EditButton Visible="True">
                            </EditButton>
                            <NewButton Visible="True">
                            </NewButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Separadores" FieldName="idSerie" VisibleIndex="8">
                            <PropertiesTextEdit DisplayFormatString="{0}">
                            </PropertiesTextEdit>
                            <EditFormSettings Visible="False" />
                            <DataItemTemplate>
                                <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Detalle" NavigateUrl='<%# "Wfrm_TipoExpediente_Series.aspx?idNorma=" & Eval("idNorma").ToString  & "&idNivel=" & Eval("idNivel").ToString  & "&idSerie=" & Eval("idSerie").ToString %>'/>
                            </DataItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Indices" FieldName="idSerie" VisibleIndex="8">
                            <EditFormSettings Visible="False" />
                            <DataItemTemplate>
                                <dxe:ASPxHyperLink ID="ASPxHyperLink2" runat="server" Text="Detalle" NavigateUrl='<%# "Wfrm_TipoExpediente_Indices.aspx?TipoExp=0&idNorma=" & Eval("idNorma").ToString  & "&idNivelP=" & Request.QueryString("idNivel").ToString  & "&idNivel=" & Eval("idNivel").ToString  & "&idSerie=" & Eval("idSerie").ToString & "&idSerieP=" & Eval("idSerie").ToString %>' />
                            </DataItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Visible="False" VisibleIndex="9">
                            <EditFormSettings Visible="False" />
                            <EditItemTemplate>
                                <table style="width:100%; text-align:center;"><tr><td style="width:130px;"><hr style="width:130px;"/></td><td>&nbsp;&nbsp;Datos por default&nbsp;&nbsp;</td><td><hr style="width:130px;" /></td></tr></table>
                            </EditItemTemplate> 
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Período de préstamo" Visible="False" VisibleIndex="10">
                            <EditFormSettings Visible="False" />
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
                        <dxwgv:GridViewDataTextColumn Caption="Período de guarda activo" Visible="False" VisibleIndex="11">
                            <EditFormSettings Visible="False" />
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
                            Visible="False" VisibleIndex="12">
                            <EditFormSettings Visible="False" />
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
                        <dxwgv:GridViewDataSpinEditColumn Caption="Resellos" FieldName="Num_Resellos" Visible="False" VisibleIndex="13">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                            <EditFormSettings Visible="False" />
                        </dxwgv:GridViewDataSpinEditColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Valor documental" Visible="False" 
                            VisibleIndex="14">
                            <EditFormSettings Visible="False" />
                            <EditItemTemplate>
                                <dxe:ASPxCheckBox ID="ASPxCheckBox1" runat="server" Text="Administrativo" 
                                    Checked='<%# Bind("Valor_administrativo") %>' ValueChecked="1" 
                                    ValueType="System.Int32" ValueUnchecked="0">
                                </dxe:ASPxCheckBox>
                                <dxe:ASPxCheckBox ID="ASPxCheckBox2" runat="server" Text="Legal" 
                                    Checked='<%# Bind("Valor_legal") %>' ValueChecked="1" ValueType="System.Int32" 
                                    ValueUnchecked="0">
                                </dxe:ASPxCheckBox>
                                <dxe:ASPxCheckBox ID="ASPxCheckBox3" runat="server" Text="Contable" 
                                    Checked='<%# Bind("Valor_contable") %>' ValueChecked="1" 
                                    ValueType="System.Int32" ValueUnchecked="0">
                                </dxe:ASPxCheckBox>
                            </EditItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Metodo de destrucción" Visible="False" VisibleIndex="15">
                            <EditFormSettings Visible="False" />
                            <EditItemTemplate>
                                <dxe:ASPxComboBox ID="Metodo_Destruccion" runat="server" 
                                    DataSourceID="dsLista_catalogos" TextField="Descripcion" 
                                    Value='<%# Bind("Metodo_Destruccion") %>' ValueField="IDCatalogo_item" 
                                    ValueType="System.Int32">
                                </dxe:ASPxComboBox>
                            </EditItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Clasificación de Información" Visible="False" VisibleIndex="16">
                            <EditFormSettings Visible="False" />
                            <EditItemTemplate>
                                <dxe:ASPxComboBox ID="Clasificacion_De_Informacion" runat="server" 
                                    DataSourceID="dsLista_Clasificacion_De_Informacion" TextField="Descripcion" 
                                    Value='<%# Bind("Clasificacion_De_Informacion") %>' ValueField="IDCatalogo_item" 
                                    ValueType="System.Int32">
                                </dxe:ASPxComboBox>
                            </EditItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Visible="False" VisibleIndex="17">
                            <EditFormSettings Visible="False" />
                            <EditItemTemplate>
                                <table style="width:100%; text-align:center;"><tr><td style="width:130px;"><hr style="width:130px;"/></td><td>&nbsp;&nbsp;Fechas&nbsp;&nbsp;</td><td><hr style="width:130px;" /></td></tr></table>
                            </EditItemTemplate> 
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Creación" FieldName="Fecha_Alta" Visible="True" VisibleIndex="18">
                            <EditFormSettings Visible="False" />
                            <EditItemTemplate>
                                <dxe:aspxLabel ID="Fecha_Alta" runat="server" Width="150px" Text='<%# Eval("Fecha_Alta") %>'></dxe:aspxLabel>
                            </EditItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Ultimo cambio" FieldName="Fecha_Ultimo_Cambio" Visible="True" VisibleIndex="19">
                            <EditFormSettings Visible="False" />
                            <EditItemTemplate>
                                <dxe:aspxLabel ID="Fecha_Ultimo_Cambio" runat="server" Width="150px" Text='<%# Eval("Fecha_Ultimo_Cambio") %>'></dxe:aspxLabel>
                            </EditItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:MsgBox ID="dlgBoxExcepciones" runat="server" />
                <asp:ObjectDataSource ID="dsLista_SeriesModelo" runat="server" 
                    SelectMethod="ListaSeries_ModeloXNorma" TypeName="Portalv9.WSArchivo.Service1" 
                    DeleteMethod="ABC_Series_Modelo" InsertMethod="ABC_Series_Modelo" 
                    UpdateMethod="ABC_Series_Modelo">
                    <DeleteParameters>
                        <asp:Parameter Name="op" DefaultValue="1" Type="Object" />
                        <asp:QueryStringParameter DefaultValue="" Name="idNorma" QueryStringField="idNorma" Type="Int32" />
                        <asp:Parameter Name="idNivel" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="Serie_nombre" Type="String" DefaultValue=""/>
                        <asp:Parameter Name="Clave" Type="String" DefaultValue="0"/>
                        <asp:Parameter Name="Atributo" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="idSeriePID" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="identidad" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="Periodo_Prestamo" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="idFrecuencia_prestamo" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="Num_Resellos" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="idFrecuencia_guardaActivo" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="Periodo_guardaActivo" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="idFrecuencia_guardaInactivo" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="Periodo_guardaInactivo" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="Valor_administrativo" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="Valor_legal" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="Valor_contable" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="Metodo_Destruccion" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="Clasificacion_De_Informacion" Type="Int32" DefaultValue="0"/>
                        <asp:Parameter Name="Fecha_Ultimo_Cambio" Type="DateTime" DefaultValue="1/1/1900"/>
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="op" DefaultValue="2" Type="Object" />
                        <asp:Parameter Name="idNorma" Type="Int32" />
                        <asp:Parameter Name="idNivel" Type="Int32" />
                        <asp:Parameter Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="Serie_nombre" Type="String" />
                        <asp:Parameter DefaultValue="0" Name="Clave" Type="String" />
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
                        <asp:Parameter Name="Valor_administrativo" Type="Int32" />
                        <asp:Parameter Name="Valor_legal" Type="Int32" />
                        <asp:Parameter Name="Valor_contable" Type="Int32" />    
                        <asp:Parameter Name="Metodo_Destruccion" Type="Int32" />                    
                        <asp:Parameter Name="Clasificacion_De_Informacion" Type="Int32" />
                        <asp:Parameter Name="Fecha_Ultimo_Cambio" Type="DateTime" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="" Name="idNorma" QueryStringField="idNorma" Type="Int32" />
                        <asp:QueryStringParameter DefaultValue="0" Name="idNivel" QueryStringField="idNivel" Type="Int32" />
                        <asp:Parameter Name="NoIdentidad" Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                        <asp:QueryStringParameter DefaultValue="" Name="idNorma" QueryStringField="idNorma" Type="Int32" />
                        <asp:QueryStringParameter DefaultValue="" Name="idNivel" QueryStringField="idNivel" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="idSerie" Type="Int32" />
                        <asp:Parameter Name="Serie_nombre" Type="String" />
                        <asp:Parameter DefaultValue="0" Name="Clave" Type="String" />
                        <asp:Parameter Name="Atributo" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="idSeriePID" Type="Int32" />
                        <asp:Parameter DefaultValue="" Name="identidad" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="Periodo_Prestamo" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="idFrecuencia_prestamo" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="Num_Resellos" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="idFrecuencia_guardaActivo" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="Periodo_guardaActivo" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="idFrecuencia_guardaInactivo" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="Periodo_guardaInactivo" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="Valor_administrativo" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="Valor_legal" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="Valor_contable" Type="Int32" />    
                        <asp:Parameter DefaultValue="0" Name="Metodo_Destruccion" Type="Int32" />                    
                        <asp:Parameter Name="Clasificacion_De_Informacion" Type="Int32" />
                        <asp:Parameter Name="Fecha_Ultimo_Cambio" Type="DateTime" DefaultValue="1/1/1900" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsLista_catalogos" runat="server" 
                    SelectMethod="ListaCatalogo_Datos" TypeName="Portalv9.WSArchivo.Service1" 
                    OldValuesParameterFormatString="{0}">
                    <SelectParameters>
                        <asp:Parameter Name="IDCatalogo" Type="Int32" DefaultValue="10" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsLista_Clasificacion_De_Informacion" runat="server" 
                    SelectMethod="ListaCatalogo_Datos" TypeName="Portalv9.WSArchivo.Service1" 
                    OldValuesParameterFormatString="{0}">
                    <SelectParameters>
                        <asp:Parameter Name="IDCatalogo" Type="Int32" DefaultValue="14" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        </table>
</asp:Content>
