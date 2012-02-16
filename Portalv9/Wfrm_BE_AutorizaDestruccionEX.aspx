<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmasteranidada.master" CodeBehind="Wfrm_BE_AutorizaDestruccionEX.aspx.vb" Inherits="Portalv9.Wfrm_BE_AutorizaDestruccionEX" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbltitulo" runat="server" Text=" Término --&amp;gt Destrucción/Archivo inactivo/Autorización de destrucción" 
        Font-Names="Arial" Font-Size="Medium" ForeColor="#3F5DBC"></asp:Label>
    <br />
    <br />
    
   <asp:Label ID="Label2" runat="server" Text="Número de orden de destrucción  " 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
    
   <asp:Label ID="lblfolio" runat="server" 
                    ForeColor="#3F5DBC" style="text-align: right"></asp:Label>
        <br />
    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
        DataSourceID="ObjectDataSource1" AutoGenerateColumns="False">
        <Columns>
             <dxwgv:GridViewCommandColumn ShowSelectCheckbox="true" VisibleIndex="0" 
                Caption="Aceptar" />
            <dxwgv:GridViewDataTextColumn Caption="EFA" FieldName="EFA" VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Código del expediente" 
                FieldName="llave_expediente" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Indice de búsqueda" 
                FieldName="Indice_de_busqueda" VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
    </dxwgv:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="BuscaInstanciaExpedientexEstadoDestruccion" 
        TypeName="Portalv9.SAEX.ServiciosSAEX">
        <SelectParameters>
            <asp:QueryStringParameter Name="Folio_destruccion" 
                QueryStringField="Folio_destruccion" Type="Int32" />
            <asp:Parameter DefaultValue="110" Name="estadoID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ImageButton ID="btnautorizar" runat="server" 
        ImageUrl="~/Images/Autorizar.gif" />
    <br />
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
    <br />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
