<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmasteranidada.master"CodeBehind="Wfrm_ReporteCGCArchivo.aspx.vb" Inherits="Portalv9.Wfrm_ReporteCGCArchivo" %>

<%@ Register Assembly="DevExpress.XtraReports.v10.1.Web, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1">
        </asp:ObjectDataSource>
    <dxwtl:aspxtreelist ID="aspxtreearchivo" runat="server" 
                        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
                        KeyFieldName="idArchivo" EnableCallbacks="false">
                        <Settings GridLines= "Both"  ShowRoot="false" ShowTreeLines="false"/>
                        <SettingsBehavior AllowFocusedNode="true" 
                        ProcessFocusedNodeChangedOnServer="true" AllowSort="False" 
                         AutoExpandAllNodes="True"/>
                        <Columns>
                             <dxwtl:TreeListTextColumn Caption="Imprimir" FieldName="idArchivo" 
                                 Name="Detalle" VisibleIndex="0">
                                 <PropertiesTextEdit DisplayFormatString="{0}">
                                 </PropertiesTextEdit>
                                 <DataCellTemplate>
                                 
                                     <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server"     ImageUrl="~/Images/btn_imprimir.gif" NavigateUrl='<%# "Wfrm_ReporteCGCA.aspx?idArchivo=" &  Eval("idArchivo").toString  & "&idNorma=" & Eval("idNorma").toString %>'
                                         Text="Ver Detalle" />
                                 </DataCellTemplate>
                             </dxwtl:TreeListTextColumn>
                            <dxwtl:TreeListTextColumn Caption="idArchivo" FieldName="idArchivo" 
                                Name="idArchivo" ReadOnly="True" Visible="False" VisibleIndex="1">
                            </dxwtl:TreeListTextColumn>
                            <dxwtl:TreeListTextColumn Caption="Archivo" FieldName="Archivo_Descripcion" 
                                Name="Archivo_Descripcion" VisibleIndex="1">
                            </dxwtl:TreeListTextColumn>
                           <%-- <dxwtl:TreeListCommandColumn ShowNewButtonInHeader="True" VisibleIndex="2" 
                            ButtonType="Image" ToolTip="Botones de Editar, Agregar y Eliminar" >
                            <EditButton  Visible="True" >
                                <Image Url="../App_Themes/Aqua/Editors/edtDropDownHottracked.png" AlternateText="Editar"></Image>
                             </EditButton>                            
                            <NewButton Text="Agregar" Visible="True" >
                                <Image Url="../App_Themes/Aqua/Editors/fcaddhot.png"></Image>                                
                            </NewButton>
                            <DeleteButton Visible="True"   >
                                <Image Url="../App_Themes/Aqua/Editors/fcremovehot.png" 
                                    AlternateText="Eliminar" ></Image>
                            </DeleteButton>
                            <CancelButton Text="Eliminar" Visible="True">
                            </CancelButton>
                        </dxwtl:TreeListCommandColumn>--%>
                        </Columns>
                    </dxwtl:aspxtreelist>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
