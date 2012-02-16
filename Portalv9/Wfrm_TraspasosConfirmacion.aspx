<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="Wfrm_TraspasosConfirmacion.aspx.vb" Inherits="Portalv9.Wfrm_TraspasosConfirmacion" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" NavigateUrl="wfrm_Buscador.aspx" />
    <asp:label id="lblTitle" runat="server" Font-Size="Small" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Seleccione el archivo a transferir</asp:label>
    <br />
    <table id="tableFolio" runat="server" visible="false" >
        <tr>
            <td>
                <asp:Label ID="lblIdTraspaso" runat="server" Text="Folio:"></asp:Label>
            </td>
            <td>
                <dxe:ASPxTextBox ID="txtIdTraspaso" runat="server" Width="160px"></dxe:ASPxTextBox>
            </td>
            <td>
                <dxe:ASPxButton ID="butIdTraspaso" runat="server" Text="Buscar"></dxe:ASPxButton>
            </td>
        </tr>
    </table>
    <dxrp:ASPxRoundPanel ID="rpHeader" Width="100%" HeaderText="Datos de la trasferencia " 
      runat="server" BackColor="White" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
      CssPostfix="Aqua" ShowHeader="True">
    <TopEdge><BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpTopEdge.gif" Repeat="RepeatX" VerticalPosition="Top" /></TopEdge>
    <LeftEdge><BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpLeftEdge.gif" Repeat="RepeatY" VerticalPosition="Top" /></LeftEdge>    
    <BottomRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomRight.png" Width="7px" />
    <ContentPaddings Padding="1px" />
    <NoHeaderTopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopRight.png" Width="7px" />
    <RightEdge><BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpRightEdge.gif" Repeat="RepeatY" VerticalPosition="Top" /></RightEdge>
    <HeaderRightEdge><BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" /></HeaderRightEdge>
    <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
    <HeaderLeftEdge><BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" /></HeaderLeftEdge>
    <HeaderStyle BackColor="#E0EDFF"><BorderBottom BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" /></HeaderStyle>
    <BottomEdge><BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpBottomEdge.gif" Repeat="RepeatX" VerticalPosition="Bottom" /></BottomEdge>
    <TopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopRight.png" Width="7px" />
    <HeaderContent><BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" /></HeaderContent>
    <NoHeaderTopEdge BackColor="White"><BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpNoHeaderTopEdge.gif" Repeat="RepeatX" VerticalPosition="Top" /></NoHeaderTopEdge>
    <NoHeaderTopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopLeft.png" Width="7px" />
    <PanelCollection>
        <dxp:PanelContent ID="PanelContent1" runat="server">
            <table style="width:100%">
                <tr>
                    <td style="width:20%">
                        <asp:label id="Label1" runat="server" Font-Names="Arial" Font-Bold="True" Text="Folio: "></asp:label>
                    </td>                        
                    <td style="width:30%">
                        <asp:label id="lblFolio" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                    <td style="width:20%">
                        <asp:label id="Label2" runat="server" Font-Names="Arial" Font-Bold="True" Text="Usuario que solicito: "></asp:label>
                    </td>                        
                    <td style="width:30%">
                        <asp:label id="lblUserName" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="Label3" runat="server" Font-Names="Arial" Font-Bold="True" Text="Archivo de Tramite: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblidArchivoOrigen" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                    <td>
                        <asp:label id="Label4" runat="server" Font-Names="Arial" Font-Bold="True" Text="Fecha de Solicitud: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblFecha_Solicitud" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="Label5" runat="server" Font-Names="Arial" Font-Bold="True" Text="Archivo de Concentracion: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblidArchivoDestino" runat="server" Font-Names="Arial"></asp:label>
                        <asp:label id="idArchivoDestino" runat="server" Font-Names="Arial" Visible="False"></asp:label>
                    </td>
                    <td>
                        <asp:label id="Label6" runat="server" Font-Names="Arial" Font-Bold="True" Text="Fecha de Aplicacion: "></asp:label>
                    </td>                        
                    <td>
                        <asp:label id="lblFecha_Aplicacion" runat="server" Font-Names="Arial"></asp:label>
                    </td>
                </tr>                    
            </table>
        </dxp:PanelContent> 
    </PanelCollection> 
    <TopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopLeft.png" Width="7px" />
    <BottomLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomLeft.png" Width="7px" />
</dxrp:ASPxRoundPanel>     
</div>
<br />
    <table style="width:100%;" id="tableMain" runat="server" >
        <tr>
            <td>
                <dxwgv:ASPxGridView ID="gdbuscadorresultado" runat="server" ClientInstanceName="grid" 
                    AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="100%" 
                    KeyFieldName="idDescripcion" EnableCallBacks="False">
                    <SettingsBehavior AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="true" />
                    <Columns>
                        <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                            <HeaderTemplate>
                                <input type="checkbox" onclick="grid.SelectAllRowsOnPage(this.checked);" title="Seleciona/DesMarcar todos los registros de la pagina" />
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idArchivoOrigen" FieldName="idArchivo" Visible="False" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Archivo" FieldName="Archivo_Descripcion" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idDescripcion" FieldName="idDescripcion" Visible="False" VisibleIndex="3">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" VisibleIndex="4">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Nivel" FieldName="Nivel_Descripcion" VisibleIndex="5"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Descripcion" FieldName="Descripcion" VisibleIndex="6"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataColumn Caption="Tipo" VisibleIndex="7">
                             <DataItemTemplate>
                                 <%#IIf(Eval("Nivel_Logico_Fisico") = 0, "Logico", "Fisico")%>
                             </DataItemTemplate>
                        </dxwgv:GridViewDataColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Alta" FieldName="Fecha_Alta" VisibleIndex="8">
                            <PropertiesTextEdit DisplayFormatString="d">
                            </PropertiesTextEdit>
                            <HeaderStyle HorizontalAlign="Center" />
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Periodo Guarda Activo" FieldName="PeriodoGuardaActivo" VisibleIndex="9"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Periodo Guarda InActivo" FieldName="PeriodoGuardaInActivo" VisibleIndex="10"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Documento" FieldName="Serie_Nombre" VisibleIndex="11"></dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataColumn VisibleIndex="12">
                             <DataItemTemplate>
                                 <dxe:ASPxHyperLink ID="ASPxHyperLink2" runat="server" ImageUrl='<%# Eval("Imagen_Open") %>'
                                NavigateUrl='<%#IIf(Eval("Nivel_Logico_Fisico") = 0,"Wfrm_PlantillaCaptura.aspx?","Wfrm_MuestraArchivo.aspx?") & "idArchivo=" & Eval("idArchivoOrigen") & "&idNorma=" & lblidNorma.Text & "&idDescripcion=" & Eval("idDescripcion")  %>'></dxe:ASPxHyperLink>
                             </DataItemTemplate>
                        </dxwgv:GridViewDataColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" VisibleIndex="13">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="idTraspasosIndice" FieldName="idTraspasosIndice" Visible="False" VisibleIndex="13">
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr id="trArchivoDestino" runat="server" visible="false">
            <td>
                <table style="border: 3px solid #C9D7DD; width: 100%; z-index: 99;">
                    <tr>
                        <td style="border: thin solid #C9D7DD" colspan="2">
                            <table style="width: 100%">
                                <tr>
                                    <td style="vertical-align: top">Archivo Destino:</td>
                                    <td style="vertical-align: top">
                                        <dxe:ASPxComboBox ID="cmbArchivoDestino" runat="server" 
                                            DataSourceID="dsArchivos" ValueType="System.Int32" 
                                            TextField="Archivo_Descripcion" ValueField="idArchivo" Width="250px" 
                                            AutoPostBack="True">
                                            <Columns>
                                                <dxe:ListBoxColumn FieldName="Archivo_Descripcion" Caption="Archivo" />
                                                <dxe:ListBoxColumn FieldName="idNorma" Visible="false" />
                                            </Columns>
                                        </dxe:ASPxComboBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <dxwtl:ASPxTreeList ID="treeArchivoDestino" runat="server" Visible="false" 
                    AutoGenerateColumns="False" DataSourceID="dsListaFondo" 
                    KeyFieldName="idDescripcion" ParentFieldName="idDocumentoPID" 
                    EnableTheming="False" Width="984px" EnableViewState="False">
                    <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                        CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                        ConfirmDelete="¿Seguro desea borrar este registro?" 
                        RecursiveDeleteError="Primero debe borrar los registros hijos." />
                    <SettingsSelection Enabled="True" />
                    <SettingsPager PageSize="20">
                    </SettingsPager>
                    <SettingsBehavior AllowSort="False" />
                    <SettingsEditing EditFormColumnCount="1" Mode="EditFormAndDisplayNode" />
                    <Columns>
                        <dxwtl:TreeListTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Tipo" VisibleIndex="0" ReadOnly="True" 
                            Width="30px">
                            <EditFormSettings Visible="False" />
                            <DataCellTemplate>
                                <dxe:ASPxImage ID="ASPxImage2" runat="server" ImageUrl='<%# Eval("Imagen_Open") %>'>
                                </dxe:ASPxImage>
                            </DataCellTemplate>
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Nombre" FieldName="Descripcion" 
                            VisibleIndex="1">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
                            Visible="False" VisibleIndex="3">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Imagen_open" FieldName="Imagen_open" 
                            Name="Imagen_open" Visible="False" VisibleIndex="2">
                        </dxwtl:TreeListTextColumn>
                        <dxwtl:TreeListTextColumn Caption="Imagen_close" FieldName="Imagen_close" 
                            Name="Imagen_close" Visible="False" VisibleIndex="2">
                        </dxwtl:TreeListTextColumn>
                    </Columns>
                </dxwtl:ASPxTreeList>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <dxe:ASPxButton ID="butRepAutorizacion" runat="server" Text="Reporte de Autorización" Visible="False"></dxe:ASPxButton>
                <dxe:ASPxButton ID="butAceptar" runat="server" Text="Aceptar" Visible="False"></dxe:ASPxButton>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="ListaTraspasos_ArchivoOrigen" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:QueryStringParameter Name="idTraspasos" QueryStringField="idTraspasos" Type="Int32" DefaultValue="-1" />
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" DefaultValue="-1" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsArchivos" runat="server" 
            SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsListaFondo" runat="server" 
        SelectMethod="ListaFondo" TypeName="Portalv9.WSArchivo.Service1" OldValuesParameterFormatString="{0}">
        <SelectParameters>
            <asp:Parameter DefaultValue="-1" Name="idArchivo" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
