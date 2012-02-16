<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master"
    CodeBehind="Wfrm_Archivo_Elementos.aspx.vb" Inherits="Portalv9.Wfrm_Archivo_Elementos" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="MsgBox" Namespace="MsgBox" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Bienvenido"> </asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Label ID="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px"
            Font-Names="Arial" Font-Bold="True" Font-Italic="True">Archivo-&gt;Elementos</asp:Label>
        <br />
        <br />
        <dxwgv:ASPxGridView ID="GridArchivoElementos" runat="server" AutoGenerateColumns="False"
            DataSourceID="dsArchivoElementos" Width="464px" KeyFieldName="idElemento">
            <SettingsBehavior ConfirmDelete="true" />
            <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar éste elemento ?" />
            <Columns>
                <dxwgv:GridViewDataTextColumn Caption="idElemento" FieldName="idElemento" Name="idElemento"
                    ReadOnly="True" Visible="False" VisibleIndex="0">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="Elemento" FieldName="Elemento_descripcion"
                    Name="Elemento_descripcion" VisibleIndex="0">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataHyperLinkColumn Caption="Campos" FieldName="idElemento" ReadOnly="True"
                    ShowInCustomizationForm="False" VisibleIndex="1" Width="40px">
                    <PropertiesHyperLinkEdit ImageUrl="images/caja.gif" NavigateUrlFormatString="Wfrm_PlantillaArchivo.aspx"
                        Text="Elementos">
                    </PropertiesHyperLinkEdit>
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataHyperLinkColumn>
                <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="4">
                    <NewButton Visible="true" Text="Agregar">
                    </NewButton>
                </dxwgv:GridViewCommandColumn>
                <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="5">
                    <EditButton Visible="True" Text="Editar">
                    </EditButton>
                    <CancelButton Visible="True" Text="Cancelar">
                    </CancelButton>
                    <UpdateButton Visible="True" Text="Actualizar">
                    </UpdateButton>
                </dxwgv:GridViewCommandColumn>
                <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex="5">
                    <DeleteButton Text="Eliminar" Visible="true">
                    </DeleteButton>
                </dxwgv:GridViewCommandColumn>
                <%--  
                         <dxwgv:GridViewCommandColumn VisibleIndex="2" Width="160px">
                             <EditButton Text="Editar" Visible="True">
                            </EditButton>
                            <NewButton Text="Agregar" Visible="True">
                            </NewButton>
                            <DeleteButton Text="Eliminar" Visible="True">
                            </DeleteButton>
                            <CancelButton Text="Eliminar" Visible="True">
                            </CancelButton>
                         </dxwgv:GridViewCommandColumn>--%>
            </Columns>
        </dxwgv:ASPxGridView>
        <dxe:ASPxLabel ID="ASPxLabel1" runat="server" ClientInstanceName="label" Text=""
            ForeColor="Red">
        </dxe:ASPxLabel>
        <cc1:MsgBox ID="MsgBox1" runat="server" ForeColor="Red"></cc1:MsgBox>
    </div>
    <asp:ObjectDataSource ID="dsArchivoElementos" runat="server" SelectMethod="ListaArchivo_Cat_Elementos"
        TypeName="Portalv9.WSArchivo.Service1" UpdateMethod="ABC_Archivo_Cat_Elementos"
        DeleteMethod="ABC_Archivo_Cat_Elementos" InsertMethod="ABC_Archivo_Cat_Elementos">
        <DeleteParameters>
            <asp:Parameter Name="op" Type="Object" DefaultValue="1" />
            <asp:Parameter Name="idElemento" Type="Int32" />
            <asp:Parameter Name="Elemento_descripcion" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="op" Type="Object" DefaultValue="2" />
            <asp:Parameter Name="idElemento" Type="Int32" />
            <asp:Parameter Name="Elemento_descripcion" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="op" Type="Object" DefaultValue="0" />
            <asp:Parameter Name="idElemento" Type="Int32" />
            <asp:Parameter Name="Elemento_descripcion" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>
