<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master"
    CodeBehind="wfrm_Prestamos_Buscador.aspx.vb" Inherits="Portalv9.wfrmPrestamosBuscador" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="MsgBox" Namespace="MsgBox" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Archivos"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 80%; z-index: 99; padding-left: 15px">
            <tr>
                <td style="border: thin solid #C9D7DD" colspan="2">
                    <br />
                    <h2>
                        Busqueda de expedientes
                    </h2>
                    <br />
                    <table style="width: 100%">
                        <tr>
                            <td>
                                Achivo:
                            </td>
                            <td>
                                <dxe:ASPxComboBox ID="cmbArchivo" runat="server" DataSourceID="ObjectDataSource1"
                                    ValueType="System.Int32" TextField="Archivo_Descripcion" ValueField="idArchivo"
                                    Width="250px" AutoPostBack="false">
                                </dxe:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <label for="LIBRE">
                                    Ingresa el código del expediente que deseas buscar:</label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>
                                            <dxe:ASPxTextBox ID="txtPalabra" runat="server" Width="300px">
                                            </dxe:ASPxTextBox>
                                        </td>
                                        <td>
                                            <dxe:ASPxButton ID="btnBuscar" runat="server" Text="Buscar">
                                                <Image Url="~/Images/Buscar.gif" />
                                            </dxe:ASPxButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <dxwgv:ASPxGridView ID="dgExpedientes" runat="server" AutoGenerateColumns="False"
                                    KeyFieldName="idDescripcion" Width="550px">
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <SettingsText EmptyDataRow="No hay expedientes a mostrar" />
                                    <Columns>
                                        <dxwgv:GridViewDataTextColumn Caption="ID" FieldName="idDescripcion" Visible="true"
                                            VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dxwgv:GridViewDataTextColumn>
                                        <dxwgv:GridViewDataTextColumn Caption="Codigo Clasificación" FieldName="Codigo_clasificacion"
                                            VisibleIndex="1">
                                        </dxwgv:GridViewDataTextColumn>
                                        <dxwgv:GridViewDataTextColumn Caption="Descripción" FieldName="Descripcion" VisibleIndex="2">
                                        </dxwgv:GridViewDataTextColumn>
                                    </Columns>
                                    <Settings GridLines="Horizontal" ShowColumnHeaders="True" />
                                    <ClientSideEvents FocusedRowChanged="function(s, e) {
                                        dGrid.PerformCallback(s.GetFocusedRowIndex());
                                        }" />
                                </dxwgv:ASPxGridView>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <dxe:ASPxButton ID="SolicitarPrestamoButton" runat="server" Text="Prestamo Expediente"
                                    OnClick="SolicitarPrestamoButton_Click">
                                </dxe:ASPxButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"><hr /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <dxwgv:ASPxGridView ID="detailGrid" runat="server" Width="550px" AutoGenerateColumns="False"
                                    ClientInstanceName="dGrid" KeyFieldName="idDescripcion" OnCustomCallback="detailGrid_CustomCallback">
                                    <SettingsText Title="Documentos" />
                                    <Settings ShowTitlePanel="True" />
                                    <Columns>
                                        <dxwgv:GridViewDataTextColumn Caption="ID" FieldName="idDescripcion" Visible="true"
                                            VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dxwgv:GridViewDataTextColumn>
                                        <dxwgv:GridViewDataTextColumn Caption="Codigo Clasificación" FieldName="Codigo_clasificacion"
                                            VisibleIndex="1">
                                        </dxwgv:GridViewDataTextColumn>
                                        <dxwgv:GridViewDataTextColumn Caption="Descripción" FieldName="Descripcion" VisibleIndex="2">
                                        </dxwgv:GridViewDataTextColumn>
                                    </Columns>
                                </dxwgv:ASPxGridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListaArchivos"
        TypeName="Portalv9.WSArchivo.Service1" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
    <cc1:MsgBox ID="MsgBox1" runat="server" ForeColor="Red"></cc1:MsgBox>
</asp:Content>
