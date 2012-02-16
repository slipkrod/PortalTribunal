<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master"
    CodeBehind="wfrm_Prestamos_Lista_Solicitudes.aspx.vb" Inherits="Portalv9.wfrmPrestamosListaSolicitudes" %>

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
        Solicitudes para prestamo de expedientes</h2>
    <br />
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <strong>Estatus:</strong>
                    <asp:DropDownList ID="EstatusDropDown" runat="server" AutoPostBack="true">
                        <asp:ListItem Value="0" Text="Pendiente" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Rechazado"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Aprobado"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Prestado"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Devuelto"></asp:ListItem>
                        <asp:ListItem Value="5" Text="Cancelado"></asp:ListItem>
                    </asp:DropDownList>
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <dxwgv:ASPxGridView ID="SolicitudesGrid" runat="server" AutoGenerateColumns="False"
                        KeyFieldName="idSolicitud_Prestamo" Width="600px">
                        <%--<SettingsBehavior AllowFocusedRow="True" />--%>
                        <SettingsPager PageSize="20">
                        </SettingsPager>
                        <Styles>
                            <SelectedRow BackColor="LightSalmon"></SelectedRow>
                        </Styles>
                        <SettingsText EmptyDataRow="No hay solicitudes a mostrar" />
                        <Columns>
                            <dxwgv:GridViewDataTextColumn Caption="ID" FieldName="idSolicitud_Prestamo" Visible="true"
                                VisibleIndex="0">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Fecha Solicitud" FieldName="Fecha_Solicitud"
                                VisibleIndex="1">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Solicitante" FieldName="Usuario_Solicitante"
                                VisibleIndex="2">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Expediente" FieldName="Codigo_clasificacion"
                                VisibleIndex="3">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Fecha de estimada devolución" FieldName="Fecha_Estimada_Devolucion"
                                VisibleIndex="4">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Estatus" FieldName="Estatus" Visible="false">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataHyperLinkColumn Caption=" " PropertiesHyperLinkEdit-Style-HorizontalAlign="Center"
                                FieldName="idSolicitud_Prestamo" PropertiesHyperLinkEdit-Text="Atender" PropertiesHyperLinkEdit-NavigateUrlFormatString="Wfrm_Prestamos_Modifica_Solicitud.aspx?idSolicitud={0}">
                            </dxwgv:GridViewDataHyperLinkColumn>
                        </Columns>
                        <Settings GridLines="Horizontal" ShowColumnHeaders="True" />
                    </dxwgv:ASPxGridView>
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <dxe:ASPxButton ID="NotificacionButton" runat="server" Text="Enviar notificación de devolución" OnClick="NotificacionButton_Click" Visible="false"/>
                </td>
                    
            </tr>
        </table>
        <br />
    </div>
    <cc1:MsgBox ID="MsgBox1" runat="server" ForeColor="Red"></cc1:MsgBox>
</asp:Content>
