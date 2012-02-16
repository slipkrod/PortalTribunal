<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_BE_ReporteDestruccionEX.aspx.vb" Inherits="Portalv9.Wfrm_BE_ReporteDestruccionEX" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbltitulo" runat="server" Text="Término --&amp;gt Destrucción/Archivo inactivo/Reporte de destrucción" 
Font-Names="Arial" Font-Size="Medium" ForeColor="#3F5DBC"></asp:Label>
<br />
<br />
    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
        DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" 
        Font-Size="XX-Small">
        <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Estado en que se encuentra" 
                FieldName="EstadoNombre" VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="EFA" FieldName="EFA" VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Código del expediente" 
                FieldName="llave_expediente" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. exp." FieldName="No_Expedientes" 
                VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No docs." FieldName="No_Documentos" 
                VisibleIndex="4">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Fecha de vencimiento" 
                FieldName="Fecha_vencimiento" VisibleIndex="5">
                <PropertiesTextEdit DisplayFormatString="{0:dd-MM-yyyy}">
                </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                VisibleIndex="6">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="7">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
    </dxwgv:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Monitoreo_Destruccion" TypeName="Portalv9.SAEX.ServiciosSAEX"></asp:ObjectDataSource>

    <br />
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/Images/Autorizar.gif" />
    <br />
    <br />
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>

</asp:Content>

