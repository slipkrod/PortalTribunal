<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="Wfrm_TraspasosHistorico.aspx.vb" Inherits="Portalv9.Wfrm_TraspasosHistorico" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" NavigateUrl="wfrm_Buscador.aspx" />
    <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Seleccione el archivo a transferir</asp:label>
</div>
<br />
    <table style="width:100%;">
        <tr>
            <td>
                <dxwgv:ASPxGridView ID="gdTraspasos" runat="server" ClientInstanceName="grid" 
                    AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="100%" 
                    KeyFieldName="idTraspasos" EnableCallBacks="False">
                    <SettingsBehavior AllowFocusedRow="false" ProcessFocusedRowChangedOnServer="true" />
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="Folio" FieldName="idTraspasos" VisibleIndex="0"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Status" FieldName="StatusDescripcion" VisibleIndex="1"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Fecha de Solicitud" FieldName="Fecha_Solicitud" VisibleIndex="2"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Fecha de Aplicación" FieldName="Fecha_Aplicacion" VisibleIndex="3"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Archivo Origen" FieldName="Archivo_Descripcion" VisibleIndex="4"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Archivo Destino" FieldName="ArchivoDestino" VisibleIndex="5"></dxwgv:GridViewDataTextColumn>
                    </Columns>
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <dxe:ASPxButton ID="butRepAutorizacion" runat="server" Text="Generar Reporte"></dxe:ASPxButton>
                        </td>
                        <td>
                            <dxe:ASPxButton ID="butExpurgos" runat="server" Text="Expurgos"></dxe:ASPxButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="ListaTraspasos_ArchivoOrigen" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:QueryStringParameter Name="idTraspasos" QueryStringField="idTraspasos" Type="Int32" DefaultValue="-1" />
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" DefaultValue="-1" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
