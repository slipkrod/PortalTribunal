<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_RE_SolicitudExp.aspx.vb" Inherits="Portalv9.Wfrm_RE_SolicitudExp" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register src="WebUsrCtrls/CampoSI_NO.ascx" tagname="CampoSI_NO" tagprefix="uc1" %>
<%@ Register src="WebUsrCtrls/CampoEntero.ascx" tagname="CampoEntero" tagprefix="uc2" %>
<%@ Register src="WebUsrCtrls/CampoTexto.ascx" tagname="CampoTexto" tagprefix="uc3" %>
<%@ Register src="WebUsrCtrls/CampoTextoLargo.ascx" tagname="CampoTextoLargo" tagprefix="uc4" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitle" runat="server" 
        Text=" Recolección-&gt;Usuario/Solicitud de recolección de expedientes"></asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" style="width: 100%; border: 1px solid #A3C0E8">
        <tr>
            <td style="height: 21px; text-align: right; vertical-align: top;">
                <b><font color="#000000" face="Arial, Helvetica, sans-serif" size="2">
                Seleccione&nbsp;el expediente&nbsp;a&nbsp;recolectar&nbsp;:</font></b></td>
            <td style="height: 21px; text-align: center;">
     <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
         DataSourceID="ObjectDataSource2" AutoGenerateColumns="False" 
         Font-Size="X-Small" KeyFieldName="InstanciaId">
         <Columns>
             <dxwgv:GridViewDataHyperLinkColumn VisibleIndex="0">
                 <DataItemTemplate>
                     <dxe:ASPxButton ID="BtnSeleccionar" runat="server" CommandName="Seleccionar" 
                         Text="Seleccionar">
                     </dxe:ASPxButton>
                 </DataItemTemplate>
             </dxwgv:GridViewDataHyperLinkColumn>
             <dxwgv:GridViewDataTextColumn Caption="Tipo de Expediente" 
                 FieldName="Descripcion" VisibleIndex="1">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Código del expediente" 
                 FieldName="Llave_expediente" VisibleIndex="2">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Indice de búsqueda" 
                 FieldName="Indice_de_busqueda" VisibleIndex="3">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Confidencial" VisibleIndex="4" 
                 FieldName="Confidencial" Name="Confidencial">
             </dxwgv:GridViewDataTextColumn>
         </Columns>
     </dxwgv:ASPxGridView>

            </td>
        </tr>
        <tr>
            <td style="height: 21px; ">
                &nbsp;</td>
            <td style="height: 21px; ">
                <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dsdocumentos" 
                    KeyFieldName="idDescripcion" ParentFieldName="idDocumentoPID" 
                    EnableTheming="False" Width="195px" 
                    ClientInstanceName="ASPxTreeList1">
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguro desea borrar este registro?" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos." />
                    <SettingsSelection Enabled="True" />
                    <SettingsPager PageSize="20">
                    </SettingsPager>
                    <Settings ShowColumnHeaders="False" />
                    <SettingsBehavior AllowSort="False" />
                    <SettingsEditing EditFormColumnCount="1" Mode="EditFormAndDisplayNode" />
                    <Columns>
                        <dxwtl:TreeListTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" 
                            VisibleIndex="0">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" 
                            VisibleIndex="0">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Tipo" VisibleIndex="0" ReadOnly="True">
                            <EditFormSettings Visible="False" />
                            <DataCellTemplate>
                                <dxe:ASPxImage ID="ASPxImage1" runat="server" ImageUrl="<%# GetNodeGlyph(Container) %>">
                                </dxe:ASPxImage>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nombre" VisibleIndex="1" 
                            FieldName="Descripcion">
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idSeriePID" FieldName="idSeriePID" 
                            Visible="False" VisibleIndex="2">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Imagen_close" FieldName="Imagen_close" 
                            Name="Imagen_close" Visible="False" VisibleIndex="2">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nivel_Logico_Fisico" 
                            FieldName="Nivel_Logico_Fisico" Name="Nivel_Logico_Fisico" Visible="False" 
                            VisibleIndex="2">
                            <PropertiesTextEdit DisplayFormatString="g">
                            </PropertiesTextEdit>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nivel" FieldName="Nivel" Name="Nivel" 
                            Visible="False" VisibleIndex="2">
                        </dxwtl:TreeListTextColumn>
                    </Columns>
                </dxwtl:ASPxTreeList>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; ">
                <asp:Label ID="lblNoIdentidad" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblLLaveExpediente" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblEstadoID" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblInstanciaPID" runat="server" Visible="False">0</asp:Label>
                <asp:Label ID="lblDocumentos" runat="server" Visible="False"></asp:Label>
            </td>
            <td style="height: 21px; ">
                <asp:ImageButton ID="btnAceptar" runat="server" BorderWidth="0" 
                    CausesValidation="False" Height="53px" ImageUrl="images/aceptar.gif" 
                    Width="73px" Visible="False" />
                <cc1:MsgBox ID="dlgBoxExcepciones" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 21px; " colspan="2">
                <p>
                    &nbsp;</p>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="BuscaExpedientePrestadoxUsuario" 
        TypeName="Portalv9.SAEX.ServiciosSAEX">
        <SelectParameters>
            <asp:Parameter Name="idUsuario_Prestamo" Type="Int32" />
            <asp:Parameter Name="estadoID" Type="Int32" />
        </SelectParameters>
     </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsdocumentos" runat="server" 
        SelectMethod="ReconstruyeArbolxPrestamo" TypeName="Portalv9.SAEX.ServiciosSAEX">
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="idArchivo" Type="Int32" />
            <asp:Parameter DefaultValue="" Name="InstanciaPID" Type="Int32" />
            <asp:Parameter DefaultValue="" Name="Llave_expediente" Type="String" />
            <asp:Parameter Name="idUsuario_Prestamo" Type="Int32" />
            <asp:Parameter Name="estadoID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
