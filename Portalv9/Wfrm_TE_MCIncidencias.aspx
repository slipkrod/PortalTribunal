<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_MCIncidencias.aspx.vb" Inherits="Portalv9.Wfrm_TE_MCIncidencias" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v10.1.Export, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraPivotGrid.Web" tagprefix="dxpgw" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1.Export, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dxwgv" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Incidencias"> </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <dxwgv:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
    </dxwgv:ASPxGridViewExporter>

    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
        DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" 
        KeyFieldName="incidenciaid" Font-Size="X-Small">
        <SettingsText Title="Envio --&gt Mesa de Control --&gt Incidencias" 
            CommandCancel="Cancelar" CommandDelete="Eliminar" CommandEdit="Editar" 
            CommandNew="Agregar" />
        <Columns>
            <dxwgv:GridViewCommandColumn VisibleIndex="0">
                <EditButton Visible="True">
                </EditButton>
                <NewButton Visible="True">
                </NewButton>
                <DeleteButton Visible="True">
                </DeleteButton>
            </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn Caption="ID" FieldName="incidenciaid" 
                VisibleIndex="1">
                <EditFormSettings Visible="False" />
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataDateColumn Caption="Fecha" FieldName="fecha_creacion" 
                VisibleIndex="2">
              
                <PropertiesDateEdit DisplayFormatString="{0:d}">
                </PropertiesDateEdit>
              
            </dxwgv:GridViewDataDateColumn>
            <dxwgv:GridViewDataTextColumn Caption="Nombre" FieldName="nom_cliente" 
                VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Incidencias" FieldName="incidencia" 
                VisibleIndex="4">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Ejecutivo" FieldName="ejecutivo" 
                VisibleIndex="5">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Sucursal" FieldName="sucursal" 
                VisibleIndex="6">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No.Cuenta" FieldName="No_cuenta" 
                VisibleIndex="7">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="No. de Cliente" FieldName="No_cliente" 
                VisibleIndex="8">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Settings ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
    <br />
    <dxe:ASPxButton ID="abtnexportar" runat="server" Text="Exportar a Excel">
    </dxe:ASPxButton>
    <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="BuscaIncidencia" TypeName="Portalv9.SAEX.ServiciosSAEX" 
        UpdateMethod="ActualizaIncidencia" InsertMethod="InsertaIncidencia" 
        DeleteMethod="ActualizaIncidenciaedo">
        <DeleteParameters>
            <asp:Parameter Name="Incidenciaid" Type="Int32" />
            <asp:Parameter Name="Estado" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Incidenciaid" Type="Int32" />
            <asp:Parameter Name="Nom_cliente" Type="String" />
            <asp:Parameter Name="Incidencia" Type="String" />
            <asp:Parameter Name="Ejecutivo" Type="String" />
            <asp:Parameter Name="Sucursal" Type="String" />
            <asp:Parameter Name="No_cuenta" Type="String" />
            <asp:Parameter Name="No_cliente" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Nom_cliente" Type="String"/>
            <asp:Parameter Name="Incidencia" Type="String" />
            <asp:Parameter Name="Ejecutivo" Type="String" />
            <asp:Parameter Name="Sucursal" Type="String" />
            <asp:Parameter Name="No_cuenta" Type="String" />
            <asp:Parameter Name="No_cliente" Type="String" />
            <asp:Parameter Name="estado" Type="Int32" DefaultValue="1" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>

