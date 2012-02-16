<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_TE_Altabolsa.aspx.vb" Inherits="Portalv9.Wfrm_TE_Altabolsa" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
<div id="pagetitle">
<asp:Label ID="Label1" runat="server" Text="Envío --&gt; Usuario/Alta de Bolsas"> </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 50%; margin-right: 0px;">
        <tr>
            <td style="width: 167px" align="right">
    <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Folio de bolsa de Seguridad">
    </dxe:ASPxLabel>
            </td>
            <td>
                <asp:TextBox ID="txtfbolsa" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 167px" align="right" >
    <dxe:ASPxLabel ID="ASPxLabel2" runat="server" Text="Confirme el folio: ">
    </dxe:ASPxLabel>
            </td>
            <td>
                <asp:TextBox ID="txtConfbolsa" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 167px" align="right" >
                &nbsp;</td>
            <td align="center">
                <asp:ImageButton ID="ibaceptar" runat="server" 
                    ImageUrl="~/Images/aceptar.gif" />
            </td>
        </tr>
    </table>
    <br />
    
    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
        DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" 
        KeyFieldName="InstanciaID" Visible="False" Font-Size="XX-Small">
        <Columns>
        <dxwgv:GridViewCommandColumn ShowSelectCheckbox="true" VisibleIndex="0" 
                Caption="Seleccionar" />
            <dxwgv:GridViewDataTextColumn Caption="Tipo" 
                FieldName="TipoExpediente" VisibleIndex="1" ToolTip="Tipo de Expediente">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Código" 
                FieldName="Llave_expediente" VisibleIndex="2" 
                ToolTip="Código del Expediente">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Indice" 
                FieldName="Indice_de_busqueda" VisibleIndex="3" 
                ToolTip="Indice de Busqueda">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Fecha" 
                FieldName="Fecha_solicitud" VisibleIndex="4" ToolTip="Fecha de Solicitud">
                 <PropertiesTextEdit DisplayFormatString="{0:dd-MM-yyyy}">
                 </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                VisibleIndex="5" ToolTip="Usuario que Solicitó">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                VisibleIndex="6" ToolTip="Entidad a la que pertenece">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="7" 
                ToolTip="Area a la que pertenece">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataCheckColumn Caption="Conf" FieldName="Confidencial" 
                VisibleIndex="8" ToolTip="Indica si es Confidencial">
                <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" 
                    ValueUnchecked="0">
                </PropertiesCheckEdit>
            </dxwgv:GridViewDataCheckColumn>
            <dxwgv:GridViewDataTextColumn Caption="Exp / Doc" FieldName="Tipo_operacion" 
                VisibleIndex="9" ToolTip="Indica si es Expediente o Documento">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
    </dxwgv:ASPxGridView>


    <br />


    <asp:Button ID="btncerrar" runat="server" Text="Cerrar y enviar Bolsa" 
    Visible="False" />


    <br />
    <asp:Label ID="Lblerror" runat="server" ForeColor="Red"></asp:Label>
    
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="BuscaInstanciaDocumentosxEstado" 
        TypeName="Portalv9.SAEX.ServiciosSAEX">
        <SelectParameters>
            <asp:Parameter Name="EstadoID" Type="Int32" DefaultValue="1" />
        </SelectParameters>
    </asp:ObjectDataSource>


    <br />


    <br />


</asp:Content>
