<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master"
    CodeBehind="wfrm_Expurgo_Expedientes.aspx.vb" Inherits="Portalv9.wfrmExpurgoExpedientes" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
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
    <h2>
        Expedientes eliminados</h2>
    <br />
    <div>
        <table>
            <tr>
                <td>
                    Desde:
                </td>
                <td>
                    <dxe:ASPxDateEdit ID="DateEditFechaDesde" runat="server">
                    </dxe:ASPxDateEdit>
                </td>
                <td>
                    Hasta:
                </td>
                <td>
                    <dxe:ASPxDateEdit ID="DateEditFechaHasta" runat="server">
                    </dxe:ASPxDateEdit>
                </td>
                <td>
                    <dxe:ASPxButton ID="ReporteButton" runat="server" Text="Ver Reporte" OnClick="BuscaExpedientes">
                    </dxe:ASPxButton>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <dxwgv:ASPxGridView ID="ExpedientesGrid" runat="server" AutoGenerateColumns="False"
                        KeyFieldName="idDescripcion" Width="600px" Settings-ShowFilterRow="true">
                        <%--<SettingsBehavior AllowFocusedRow="True" />--%>
                        <SettingsPager PageSize="20">
                        </SettingsPager>
                        <Settings ShowHeaderFilterButton="true"></Settings>
                        <Styles>
                            <SelectedRow BackColor="LightSalmon">
                            </SelectedRow>
                        </Styles>
                        <SettingsText EmptyDataRow="No hay expedientes a mostrar" />
                        <Columns>
                            <dxwgv:GridViewDataTextColumn Caption="ID" FieldName="idDescripcion" Visible="true"
                                VisibleIndex="0">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Código clasificación" FieldName="Expediente_Codigo"
                                VisibleIndex="1">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Descripción" FieldName="Expediente_Descripcion"
                                VisibleIndex="2">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Serie" FieldName="Padre_Descripcion" VisibleIndex="3">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Fecha eliminación" FieldName="Fecha_Ultimo_Cambio"
                                VisibleIndex="4">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataColumn VisibleIndex="6">
                                <EditFormSettings Visible="False" />
                                <DataItemTemplate>
                                    <dxe:ASPxButton runat="server" ID="btnActivar" Text="Activar" CommandName="Activar"
                                        CommandArgument='<%# Bind("idDescripcion") %>'>
                                    </dxe:ASPxButton>
                                </DataItemTemplate>
                            </dxwgv:GridViewDataColumn>
                        </Columns>
                        <Settings GridLines="Horizontal" ShowColumnHeaders="True" />
                    </dxwgv:ASPxGridView>
                    <hr />
                </td>
            </tr>
        </table>
        <br />
    </div>
    <cc1:MsgBox ID="MsgBox1" runat="server" ForeColor="Red"></cc1:MsgBox>
</asp:Content>
