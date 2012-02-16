<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_ArchivoBak.aspx.vb" Inherits="Portalv9.Wfrm_ArchivoBak" MasterPageFile="~/Masterpages/1.master"%>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitulo" runat="server" Text="Bienvenido" > </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <div>
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br />
    </div>
    <div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager>
         <br />
    </div>
    <div>
        <asp:ObjectDataSource ID="dsArchivos" runat="server" 
            SelectMethod="ListaArchivos" DeleteMethod="ABC_Archivos" 
            TypeName="Portalv9.WSArchivo.Service1" InsertMethod="ABC_Archivos" 
            UpdateMethod="ABC_Archivos">
            <DeleteParameters>
                      <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
                      <asp:Parameter DefaultValue="" Name="idArchivo" Type="Int32" />
                      <asp:Parameter Name="idNorma" Type="Int32" />
                      <asp:Parameter Name="Archivo_descripcion" Type="String" />
                      <asp:Parameter Name="Codigo_clasificacion" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
                <asp:Parameter DefaultValue="" Name="idArchivo" Type="Int32" />
                <asp:Parameter Name="idNorma" Type="Int32" />
                <asp:Parameter Name="Archivo_descripcion" Type="String" />
                <asp:Parameter Name="Codigo_clasificacion" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
                <asp:Parameter DefaultValue="" Name="idArchivo" Type="Int32" />
                <asp:Parameter Name="idNorma" Type="Int32" />
                <asp:Parameter Name="Archivo_descripcion" Type="String" />
                <asp:Parameter Name="Codigo_clasificacion" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsNormas" runat="server" 
            SelectMethod="ListaNormas" TypeName="Portalv9.WSArchivo.Service1">
        </asp:ObjectDataSource>
        <dxwtl:ASPxTreeList ID="aspxtreearchivo" runat="server" 
            AutoGenerateColumns="False" DataSourceID="dsArchivos" EnableCallbacks="False" 
            KeyFieldName="idArchivo">
            <Settings GridLines="Both" ShowRoot="false" ShowTreeLines="false" />
            <SettingsBehavior AllowFocusedNode="true" AllowSort="False" 
                AutoExpandAllNodes="True" ProcessFocusedNodeChangedOnServer="true" />
            <settingsediting mode="EditFormAndDisplayNode" />
            <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar éste archivo ?" />
            <templates>
                <editform>
                    <dxe:ASPxLabel ID="lblnombre" runat="server" Text="Nombre">
                    </dxe:ASPxLabel>
                    <dxe:ASPxTextBox ID="txtdescripcion" runat="server" EnableClientSideAPI="True" 
                        Text='<%# Bind("Archivo_Descripcion") %>' Width="250px">
                        <ValidationSettings SetFocusOnError="True">
                            <RequiredField ErrorText="La descripción debe ser capturada" 
                                IsRequired="True" />
                        </ValidationSettings>
                    </dxe:ASPxTextBox>
                    <asp:Label ID="Label2" runat="server" Text="Norma:"></asp:Label>
                    <dxe:ASPxComboBox ID="cmbnorma" runat="server" DataSourceID="dsNormas" 
                        DropDownStyle="DropDown" TextField="Norma_descripcion" 
                        Value='<%# Bind("idNorma") %>' ValueField="idNorma" ValueType="System.Int32">
                        <ValidationSettings>
                            <RequiredField ErrorText="* La norma debe ser capturada" IsRequired="True" />
                        </ValidationSettings>
                    </dxe:ASPxComboBox>
                    <dxe:ASPxLabel ID="lblcodigo" runat="server" Text="Còdigo:">
                    </dxe:ASPxLabel>
                    <dxe:ASPxTextBox ID="txtcodigo" runat="server" EnableClientSideAPI="True" 
                        Text='<%# Bind("Codigo_clasificacion") %>' Width="250px">
                    </dxe:ASPxTextBox>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                        <ContentTemplate>
                            <br />
                            <table>
                                <tr>
                                    <td align="right">
                                        <dxe:ASPxButton ID="btnActualizar" runat="server" onclick="btnActualizar_Click" 
                                            Text="Actualizar">
                                        </dxe:ASPxButton>
                                    </td>
                                    <td>
                                        <dxe:ASPxButton ID="btnCancel" runat="server" CausesValidation="False" 
                                            CommandName="Update" onclick="btnCancel_Click" Text="Cancelar">
                                        </dxe:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div>
                    </div>
                </editform>
            </templates>
            <Columns>
                <dxwtl:TreeListTextColumn Caption="idNorma" FieldName="idNorma" Name="idNorma" 
                    ReadOnly="True" Visible="False" VisibleIndex="1">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListTextColumn Caption="idArchivo" FieldName="idArchivo" 
                    Name="idArchivo" ReadOnly="True" Visible="False" VisibleIndex="1">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListTextColumn Caption="Archivo" FieldName="Archivo_Descripcion" 
                    Name="Archivo_Descripcion" VisibleIndex="0">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListCommandColumn ButtonType="Image" ShowNewButtonInHeader="True" 
                    ToolTip="Botones de Editar, Agregar y Eliminar" VisibleIndex="1">
                    <EditButton Visible="True">
                        <Image AlternateText="Editar" 
                            Url="../App_Themes/Aqua/Editors/edtDropDownHottracked.png" />
                    </EditButton>
                    <NewButton Text="Agregar" Visible="True">
                        <Image Url="../App_Themes/Aqua/Editors/fcaddhot.png" />
                    </NewButton>
                    <DeleteButton Visible="True">
                        <Image AlternateText="Eliminar" 
                            Url="../App_Themes/Aqua/Editors/fcremovehot.png" />
                    </DeleteButton>
                    <CancelButton Text="Eliminar" Visible="True">
                    </CancelButton>
                </dxwtl:TreeListCommandColumn>
            </Columns>
        </dxwtl:ASPxTreeList>
        <table style="width: 100%">
            <tr>
                <td valign="top">
                    &nbsp;</td>
                <td valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 31%;">
                        <tr>
                            <td>
                                <dxp:ASPxPanel ID="PnlElementos" runat="server" Width="600px">
                                    <Border BorderColor="#C9D7DD" BorderStyle="Solid" BorderWidth="1px" />
                                    <PanelCollection>
                                        <dxp:PanelContent ID="PanelContent1" runat="server">
                                        </dxp:PanelContent>
                                    </PanelCollection>
                                </dxp:ASPxPanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dxe:ASPxButton ID="btnGuardar" runat="server" Text="Guardar">
                                </dxe:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
 </asp:Panel>
    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red">
    </cc1:msgbox>
  
    <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" 
        Text="" ForeColor="Red">
    </dxe:ASPxLabel>
                        
</asp:Content>