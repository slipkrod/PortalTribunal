<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="Wfrm_ValorizacionBajas_Seleccion.aspx.vb" Inherits="Portalv9.Wfrm_ValorizacionBajas_Seleccion" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" 
            NavigateUrl="~/Wfrm_ValorizacionBajas.aspx" />
    <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Seleccione el archivo</asp:label>
</div>
<br />
    <table style="width:100%;">
        <tr>
            <td>
    <asp:Label ID="lblArchivo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 445px">
                    <tr>
                        <td>
                            <dxe:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" 
                                ClientInstanceName="ASPxRadioButtonList1" SelectedIndex="0" 
                                ValueType="System.Int32">
                                <Items>
                                    <dxe:ListEditItem Text="Fecha de corte" Value="0" />
                                    <dxe:ListEditItem Text="Código de expediente" Value="1" />
                                </Items>
                                <ClientSideEvents ValueChanged="function(s, e) {
	if(s.GetValue()==0)
    { txtCodigo.SetText('');
      deFechaCorte.SetText('');
      deFechaCorte.SetClientVisible(true);
      txtCodigo.SetClientVisible(false);
    }
    else
    { txtCodigo.SetText('');
      deFechaCorte.SetText('');
      deFechaCorte.SetClientVisible(false);
      txtCodigo.SetClientVisible(true);
    }
}" />
                            </dxe:ASPxRadioButtonList>
                        </td>
                        <td>
                            <dxe:ASPxDateEdit ID="deFechaCorte" runat="server" 
                                ClientInstanceName="deFechaCorte">
                            </dxe:ASPxDateEdit>
                            <dxe:ASPxTextBox ID="txtCodigo" runat="server" ClientInstanceName="txtCodigo" 
                                Width="170px" ClientVisible="False">
                            </dxe:ASPxTextBox>
                        </td>
                        <td>
                            <dxe:ASPxButton ID="btnBuscar" runat="server" Text="Buscar">
                            </dxe:ASPxButton>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <dxwgv:ASPxGridView ID="gdbuscadorBajas" runat="server" ClientInstanceName="grid" 
                    AutoGenerateColumns="False" DataSourceID="dsExpedientesBaja" Width="100%" 
                    KeyFieldName="idFolioDetalle" EnableCallBacks="False">
                    <SettingsBehavior AllowFocusedRow="true" />
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Eliminar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandSelect="Seleccionar" 
                        CommandUpdate="Actualizar" EmptyDataRow="No existen expedientes" 
                        Title="Documentos  a eliminar" />
                    <ClientSideEvents FocusedRowChanged="function(s, e) {
	//ASPxCallbackPanel1.PerformCallback(2);
}" />
                    <Columns>
                        <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" 
                            Caption="Selección">
                            <HeaderTemplate>
                                &nbsp;
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" Visible="False" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idDescripcion" FieldName="idDescripcion" Visible="False" VisibleIndex="3">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" VisibleIndex="4">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Nivel" FieldName="Nivel_Descripcion" 
                            VisibleIndex="1" Visible="False"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Código de clasificación" 
                            FieldName="Codigo_clasificacion" VisibleIndex="1"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Descripcion" FieldName="Descripcion" 
                            VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Alcance y Contenido" 
                            FieldName="Alcance_Contenido" VisibleIndex="5">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataColumn Caption="Tipo" VisibleIndex="3" Visible="False">
                             <DataItemTemplate>
                                 <%#IIf(Eval("Nivel_Logico_Fisico") = 0, "Logico", "Fisico")%>
                             </DataItemTemplate>
                        </dxwgv:GridViewDataColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Apertura" FieldName="Apertura" 
                            VisibleIndex="3">
                            <PropertiesTextEdit DisplayFormatString="d">
                            </PropertiesTextEdit>
                            <HeaderStyle HorizontalAlign="Center" />
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Cierre" FieldName="Cierre" 
                            VisibleIndex="4">
                            <PropertiesTextEdit DisplayFormatString="d">
                            </PropertiesTextEdit>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Volumen y Soporte" VisibleIndex="6">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Plazo AT" FieldName="Plazo_AT" 
                            VisibleIndex="7">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Plazo AC" FieldName="Plazo_AC" 
                            VisibleIndex="8">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Valor &lt;br/&gt;Administrativo" 
                            FieldName="Valor_administrativo" VisibleIndex="9">
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Valor &lt;br/&gt;Fiscal" 
                            FieldName="Valor_contable" VisibleIndex="10">
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Valor &lt;br/&gt;Legal" 
                            FieldName="Valor_legal" VisibleIndex="11">
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Acceso" FieldName="Acceso" 
                            VisibleIndex="12">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" VisibleIndex="13">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idDocumentoPID" 
                            FieldName="idDocumentoPID" Visible="False" VisibleIndex="10">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="Baja" FieldName="Baja" 
                            VisibleIndex="13">
                            <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                                ValueUnchecked="0">
                            </PropertiesCheckEdit>
                        </dxwgv:GridViewDataCheckColumn>
                    </Columns>
                    <Settings ShowTitlePanel="True" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td>
                <dxe:ASPxButton ID="butTransferir" runat="server" Text="Aceptar"></dxe:ASPxButton>
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
    <cc1:msgbox id="MsgBox1" runat="server"></cc1:msgbox>
    <asp:ObjectDataSource ID="dsExpedientesBaja" runat="server" 
            SelectMethod="ListaBajas_Archivo_Tramite" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="idFolio" Type="Int32" />
            <asp:Parameter DefaultValue="1" Name="Baja" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsArchivos" runat="server" 
            SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
    </asp:ObjectDataSource>
</asp:Content>
