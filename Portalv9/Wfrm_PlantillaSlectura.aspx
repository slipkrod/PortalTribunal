<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_PlantillaSlectura.aspx.vb" Inherits="Portalv9.Wfrm_PlantillaSlectura" MasterPageFile="~/Masterpages/Adminmaster2col.master"  %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server" >
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <div>
        <dxe:ASPxLabel id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">
        </dxe:ASPxLabel>
            <br />
    </div>
    <div>
         <br />
    </div>
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1">
        </asp:ObjectDataSource>
        <table style="width: 100%">
            <tr>
            
                <td valign="top">
                    <dxwtl:ASPxTreeList ID="aspxtreearchivo" runat="server" 
                        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
                        KeyFieldName="idArchivo" EnableCallbacks="false">
                        <Settings GridLines= "Both"  ShowRoot="false" ShowTreeLines="false"/>
                        <SettingsBehavior AllowFocusedNode="true" 
                        ProcessFocusedNodeChangedOnServer="true" AllowSort="False" 
                         AutoExpandAllNodes="True"/>
                        <Columns>
                             <dxwtl:TreeListTextColumn Caption="Detalle" FieldName="idArchivo" 
                                 Name="Detalle" VisibleIndex="0">
                                 <PropertiesTextEdit DisplayFormatString="{0}">
                                 </PropertiesTextEdit>
                                 <DataCellTemplate>
                                     <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server" 
                                         ImageUrl="~/Images/Caja.gif" NavigateUrl='<%# "Wfrm_PlantillaCaptura.aspx?idArchivo=" &  Eval("idArchivo").toString  & "&idNorma=" & Eval("idNorma").toString %>'
                                         Text="Ver Detalle" />
                                 </DataCellTemplate>
                             </dxwtl:TreeListTextColumn>
                            <dxwtl:TreeListTextColumn Caption="idArchivo" FieldName="idArchivo" 
                                Name="idArchivo" ReadOnly="True" Visible="False" VisibleIndex="1">
                            </dxwtl:TreeListTextColumn>
                            <dxwtl:TreeListTextColumn Caption="Archivo" FieldName="Archivo_Descripcion" 
                                Name="Archivo_Descripcion" VisibleIndex="1">
                            </dxwtl:TreeListTextColumn>
                            <%-- <dxwtl:TreeListCommandColumn ShowNewButtonInHeader="True" VisibleIndex="2">
                            <EditButton Text="Editar" Visible="True">
                            </EditButton>
                            <NewButton Text="Agregar" Visible="True">
                            </NewButton>
                            <DeleteButton Text="Eliminar" Visible="True">
                            </DeleteButton>
                            <CancelButton Text="Eliminar" Visible="True">
                            </CancelButton>
                        </dxwtl:TreeListCommandColumn>--%>
                        </Columns>
                    </dxwtl:ASPxTreeList>
                </td>
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