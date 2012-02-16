<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="wfrm_Buscador_Resultado.aspx.vb" Inherits="Portalv9.wfrm_Buscador_Resultado" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Resultados de busqueda"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" NavigateUrl="wfrm_Buscador.aspx" />
    <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Seleccione un resultado de la busqueda</asp:label>
</div>
    <table style="width:100%;">
        <tr>
            <td>
                <dxwgv:ASPxGridView ID="gdbuscadorresultado" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="895px" 
                    KeyFieldName="idDescripcion" EnableCallBacks="False">
                    <SettingsBehavior AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="true" />
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Archivo" FieldName="Archivo_Descripcion" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idDescripcion" FieldName="idDescripcion" Visible="False" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Nivel" FieldName="Nivel_Descripcion" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataColumn Caption="Descripcion" FieldName="Descripcion" VisibleIndex="2">
                            <DataItemTemplate>
                                <%#Eval("Descripcion").ToString.Replace(Request.QueryString("Palabra"), "<span style='background-color:Yellow;'>" + Request.QueryString("Palabra") + "</span>")%>
                            </DataItemTemplate>
                        </dxwgv:GridViewDataColumn>
                        <dxwgv:GridViewDataColumn Caption="Nivel" VisibleIndex="3">
                             <DataItemTemplate>
                                 <%#IIf(Eval("Nivel_Logico_Fisico") = 0, "Logico", "Fisico")%>
                             </DataItemTemplate>
                        </dxwgv:GridViewDataColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Documento" FieldName="Serie_Nombre" VisibleIndex="4">
                            <DataItemTemplate>
                                <%#Eval("Serie_Nombre").ToString.Replace(Request.QueryString("Palabra"), "<span style='background-color:Yellow;'>" + Request.QueryString("Palabra") + "</span>")%>
                            </DataItemTemplate>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataColumn VisibleIndex="5">
                             <DataItemTemplate>
                                 <dxe:ASPxHyperLink ID="ASPxHyperLink2" runat="server" ImageUrl='<%# Eval("Imagen_Open") %>'
                                NavigateUrl='<%#IIf(Eval("Nivel_Logico_Fisico") = 0,"Wfrm_PlantillaCaptura.aspx?","Wfrm_MuestraArchivo.aspx?") & "idArchivo=" & Eval("idArchivo") & "&idNorma=" & lblidNorma.Text & "&idNivel=" & Eval("idNivel") & "&idDescripcion=" & Eval("idDescripcion")  %>'></dxe:ASPxHyperLink>
                             </DataItemTemplate>
                        </dxwgv:GridViewDataColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
              <td valign="top">
                <table border="0" cellpadding="1" cellspacing="1" style="width: 31%;">
                    <tr>
                        <td nowrap class="DataList_Aqua" >
                            <dxtc:aspxpagecontrol ID="pgareas" runat="server" AutoPostBack="false" >
                                <TabStyle Width="40px"></TabStyle>
                            </dxtc:aspxpagecontrol>
                            <div class="clear"></div>
                        </td>
                     </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="BuscaExpediente" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:Parameter Name="SQLString" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="ListaNormas_Areas" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
