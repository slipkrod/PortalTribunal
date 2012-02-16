<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_EN_SeguimientoIncosistencias.aspx.vb" Inherits="Portalv9.Wfrm_EN_SeguimientoIncosistencias" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
<asp:Label ID="Label2" runat="server" Text="Seguimiento a inconsistencias"> </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width: 600px; overflow: auto;">
     <asp:Label ID="Label1" runat="server" 
         Text="Envío --&gt;Rechazos/Seguimiento a inconsistencias" Font-Names="Arial" 
         Font-Size="Medium" ForeColor="#3F5DBC"></asp:Label>
    <br />
    <br />
     <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
         AutoGenerateColumns="False" Font-Size="XX-Small" 
         DataSourceID="ObjectDataSource1" KeyFieldName="InstanciaId">
         <Columns>
             <dxwgv:GridViewDataTextColumn Caption="Folio de bolsa" FieldName="Folio_bolsa" 
                 VisibleIndex="0">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Tipo de expediente" 
                 FieldName="TipoExpediente" VisibleIndex="1">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Código del expediente" 
                 FieldName="Llave_expediente" VisibleIndex="2">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Indice de búsqueda" 
                 FieldName="Indice_de_busqueda" VisibleIndex="3">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Fecha de solicitud" 
                 FieldName="Fecha_solicitud" VisibleIndex="4">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                 VisibleIndex="5">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                 VisibleIndex="6">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="7">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Tipo de Acta" VisibleIndex="8">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Imprimir" VisibleIndex="9">
                 <DataItemTemplate>
                     <dxe:ASPxButton ID="ASPxButton1" runat="server" CommandName="Liberacion" 
                         Font-Size="XX-Small"  Text="Acta de liberación" 
                         Width="110px" CommandArgument='<%# eval("Folio_bolsa")%>'>
                     </dxe:ASPxButton>
                     <dxe:ASPxButton ID="ASPxButton2" runat="server" CommandName="perdida" 
                         Font-Size="XX-Small"  Text="Acta de perdida" 
                         Width="110px" CommandArgument='<%# eval("Folio_bolsa")%>'>
                     </dxe:ASPxButton>
                 </DataItemTemplate>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Agregar" VisibleIndex="10">
                 <DataItemTemplate>
                     <dxe:ASPxButton ID="ASPxButton4" runat="server" CommandName="Agegar" 
                         Font-Size="XX-Small" Text="Agegar acta digital" Width="124px" 
                         CommandArgument='<%# eval("Folio_bolsa")%>'>
                     </dxe:ASPxButton>
                 </DataItemTemplate>
             </dxwgv:GridViewDataTextColumn>
         </Columns>
     </dxwgv:ASPxGridView>
     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
         SelectMethod="BuscaInstanciaExpedientexEstado" 
         TypeName="Portalv9.SAEX.ServiciosSAEX">
         <SelectParameters>
             <asp:Parameter DefaultValue="13" Name="EstadoID" Type="Int32" />
         </SelectParameters>
     </asp:ObjectDataSource>
    <br />

     <dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" Font-Size="XX-Small" 
         AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" 
         KeyFieldName="InstanciaId">
     <Columns>
             <dxwgv:GridViewDataTextColumn Caption="Folio de bolsa" FieldName="Folio_bolsa" 
                 VisibleIndex="0">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Tipo de expediente" 
                 FieldName="TipoExpediente" VisibleIndex="1">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Código del expediente" 
                 FieldName="Llave_expediente" VisibleIndex="2">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Indice de búsqueda" 
                 FieldName="Indice_de_busqueda" VisibleIndex="3">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Fecha de solicitud" 
                 FieldName="Fecha_solicitud" VisibleIndex="4">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Solicita" FieldName="Usuario_Solicita" 
                 VisibleIndex="5">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Entidad" FieldName="Entidad" 
                 VisibleIndex="6">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="7">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Tipo de Acta" VisibleIndex="8">
             </dxwgv:GridViewDataTextColumn>
         </Columns>
     </dxwgv:ASPxGridView>
     <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
         SelectMethod="BuscaInstanciaDocumentosxEstado" 
         TypeName="Portalv9.SAEX.ServiciosSAEX">
         <SelectParameters>
             <asp:Parameter DefaultValue="13" Name="EstadoID" Type="Int32" />
         </SelectParameters>
     </asp:ObjectDataSource>
     <dxpc:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
         HeaderText="Agregar archivo digital con acta de folios faltantes firmada." 
         Width="505px" CloseAction="CloseButton" Modal="True" PopupAction="None" 
         PopupHorizontalAlign="Center" PopupVerticalAlign="Middle" >
         <ContentCollection>
<dxpc:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width: 144px">
                Código del expediente:</td>
            <td>
                <dxe:ASPxLabel ID="lblLLave" runat="server">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="width: 144px">
                Indice de búsqueda:</td>
            <td>
                <dxe:ASPxLabel ID="lblIndice" runat="server">
                </dxe:ASPxLabel>
                <b><font color="#000000" face="Arial, Helvetica, sans-serif" size="2">
                <asp:Label ID="lblInstancia" runat="server" Visible="False" Width="158px"></asp:Label>
                <asp:Label ID="lblBolsa" runat="server" Visible="False" Width="158px"></asp:Label>
                </font></b>
            </td>
        </tr>
        <tr>
            <td style="width: 144px">
                Tipo de acta:</td>
            <td>
                <dxe:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" Width="300px" SelectedIndex="0">
                    <Items>
                        <dxe:ListEditItem Text="Acta de pérdida" Value="0" />
                        <dxe:ListEditItem Text="Acta de liberación" Value="1" />
                    </Items>
                </dxe:ASPxRadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 144px">
                Archivo (Formato gif)</td>
            <td>
                <dxuc:ASPxUploadControl ID="FileUpload" runat="server" Size="30">
                </dxuc:ASPxUploadControl>
            </td>
        </tr>
        <tr>
            <td style="width: 144px">
                <dxe:ASPxButton ID="ASPxButton3" runat="server" Text="Aceptar">
                </dxe:ASPxButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
             </dxpc:PopupControlContentControl>
</ContentCollection>
     </dxpc:ASPxPopupControl>
        <cc1:MsgBox ID="MsgBox1" runat="server" />
     <br />
     <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
     <br />
</div>
</asp:Content>
