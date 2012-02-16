<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_ReporteGSArchivo.aspx.vb" Inherits="Portalv9.Wfrm_ReporteGSArchivo" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1">
        </asp:ObjectDataSource>
    <dxwtl:ASPxTreeList  ID="aspxtreearchivo" runat="server" 
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
                                     <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server"     ImageUrl="~/Images/btn_imprimir.gif" NavigateUrl='<%# "Wfrm_ReporteGS.aspx?idArchivo=" &  Eval("idArchivo").toString  %>'
                                         Text="Ver Detalle" >
                                     </dxe:ASPxHyperLink>
                                    
                                 </DataCellTemplate>
                             </dxwtl:TreeListTextColumn>
                            <dxwtl:TreeListTextColumn Caption="idArchivo" FieldName="idArchivo" 
                                Name="idArchivo" ReadOnly="True" Visible="False" VisibleIndex="1">
                            </dxwtl:TreeListTextColumn>
                            <dxwtl:TreeListTextColumn Caption="Archivo" FieldName="Archivo_Descripcion" 
                                Name="Archivo_Descripcion" VisibleIndex="1">
                            </dxwtl:TreeListTextColumn>
                        </Columns>
    </dxwtl:ASPxTreeList>
</asp:Content>

