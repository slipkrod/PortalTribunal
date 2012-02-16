<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="Wfrm_PlantillaCapturaBak.aspx.vb" Inherits="Portalv9.Wfrm_PlantillaCapturaBak" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Administración de áreas, elementos e indices"></asp:Label>
    </div>
    <%--<script type="text/javascript">
        function prueba() {
            e.processOnServer = false;
        }

        // Validation via standard LinkButton
        function OnLinkButtonClick(s, e) {
            var validationGroup = '';
            //return RaisePageValidation(validationGroup);
            e.processOnServer = false;
        }

        function RaisePageValidation(validationGroup) {
            var validationProcs = [RaiseDxValidation, RaiseStandardValidation];
            var result = true;
            for (var index = 0; index < validationProcs.length; index++)
                result = validationProcs[index](validationGroup) && result;
            return result;
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div style="width: 992px; overflow:auto;">
    <table style="width: 100%;">
        <tr>
            <td runat="server" id="trMainH" style="vertical-align: top; height:450px;">
                <div>   
                    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" NavigateUrl="javascript:history.go(-1);" />
        	        <asp:label id="lblTitle" runat="server" Font-Size="Small" 
                    Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> </asp:label>
                </div>
                <dxcp:ASPxCallbackPanel ID="ASPxCallbackPanel1" 
                    ClientInstanceName="ASPxCallbackPanel1" 
                    oncallback="ASPxCallbackPanel1_Callback" runat="server" Width="200px" 
                    HideContentOnCallback="False" Height="175px">
                    <PanelCollection>
                            <dxp:PanelContent ID="PanelContent2" runat="server">
                                <table>
                                    <tr>
                                        <td valign="top" style="width:534px">
                                            <dxwtl:ASPxTreeList ID="aspxtreenivel" runat="server" 
                                                AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
                                                KeyFieldName="idDescripcion" ParentFieldName="idDocumentoPID" ClientInstanceName="treeList" 
                                                EnableCallbacks="true" EnableViewState="false" 
                                                SettingsText-CommandCancel="Cancelar" SettingsText-CommandDelete="Eliminar" SettingsText-CommandEdit="Editar" SettingsText-CommandNew="Insertar" SettingsText-CommandUpdate="Actualizar" SettingsText-ConfirmDelete="Esta seguro que quiere eliminar ?">
                                            <SettingsBehavior AllowFocusedNode="true"  ProcessFocusedNodeChangedOnServer="false" AllowSort="False"/>
                                            <ClientSideEvents FocusedNodeChanged="function(s, e) {ASPxCallbackPanel1.PerformCallback(); }" />
                                            <SettingsEditing Mode="EditFormAndDisplayNode"/>                                            
                                            <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar este nivel ?" 
                                                RecursiveDeleteError="El nivel no puede ser borrado ya que tiene subniveles." />
                                            <templates>
                                              <editform>
                                               <dxrp:ASPxRoundPanel EnableViewState="False" ID="rpHeader" Width="100%"  
                                                      runat="server" BackColor="White" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                                                      CssPostfix="Aqua" ShowHeader="False">
                                                    <TopEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpTopEdge.gif" 
                                                            Repeat="RepeatX" VerticalPosition="Top" />
                                                    </TopEdge>
                                                    <LeftEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpLeftEdge.gif" 
                                                            Repeat="RepeatY" VerticalPosition="Top" />
                                                    </LeftEdge>
                                                    <BottomRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomRight.png" Width="7px" />
                                                    <ContentPaddings Padding="1px" />
                                                    <NoHeaderTopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopRight.png" Width="7px" />
                                                    <RightEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpRightEdge.gif" Repeat="RepeatY" VerticalPosition="Top" />
                                                    </RightEdge>
                                                    <HeaderRightEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" />
                                                    </HeaderRightEdge>
                                                    <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
                                                    <HeaderLeftEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" />
                                                    </HeaderLeftEdge>
                                                    <HeaderStyle BackColor="#E0EDFF">
                                                    <BorderBottom BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
                                                    </HeaderStyle>
                                                    <BottomEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpBottomEdge.gif" Repeat="RepeatX" VerticalPosition="Bottom" />
                                                    </BottomEdge>
                                                    <TopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopRight.png" Width="7px" />
                                                    <HeaderContent>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" />
                                                    </HeaderContent>
                                                    <NoHeaderTopEdge BackColor="White">
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpNoHeaderTopEdge.gif" Repeat="RepeatX" VerticalPosition="Top" />
                                                    </NoHeaderTopEdge>
                                                    <NoHeaderTopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopLeft.png" Width="7px" />
                                                    <PanelCollection>
                                                         <dxp:PanelContent ID="PanelContent1" runat="server">
                                                          <table style="width:315px;">
                                                                <tr>
                                                                    <td style="width:150px">
                                                                        <dxe:aspxLabel ID="Label2" runat="server" Text="Tipo de Nivel" Width="150px"></dxe:aspxLabel>
                                                                    </td>
                                                                    <td style="width:160px">
                                                                        <dxe:ASPxComboBox ID="dlNiveles" runat="server" DropDownStyle="DropDown" ClientInstanceName="dlNiveles" Width="160px"
                                                                           TextField="Nivel_Descripcion" ValueField="idNivel" DataSourceID="ObjectDataSource3" SelectedIndex="-1">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                                              cbSerie.PerformCallback(s.GetValue().toString()); 
                                                                              }" />
                                                                         </dxe:ASPxComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width:150px">
                                                                        <dxe:aspxLabel ID="AspxLabel2" runat="server" Text="Tipo de Expediente" Width="150px"></dxe:aspxLabel>                                                 
                                                                    </td>
                                                                    <td style="width:160px">
                                                                        <dxe:ASPxComboBox ID="cbSerie" runat="server" DropDownStyle="DropDown" ClientInstanceName="cbSerie"                                                       
                                                                              TextField="Serie_nombre" ValueField="idSerie" Width="160px"
                                                                              SelectedIndex="-1" DataSourceID="dsTipoDeExpediente" 
                                                                              oncallback="cbSerie_Callback">
                                                                              <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                                              cbpEC.PerformCallback(s,s.GetValue().toString()); 
                                                                              }" />
                                                                              <Columns>
                                                                                <dxe:ListBoxColumn Caption="Expediente" FieldName="Serie_nombre"/>
                                                                                <dxe:ListBoxColumn FieldName="Clave" Visible="False"/>
                                                                                <dxe:ListBoxColumn FieldName="Periodo_guardaActivo" Visible="False"/>
                                                                                <dxe:ListBoxColumn FieldName="idFrecuencia_guardaActivo" Visible="False"/>
                                                                                <dxe:ListBoxColumn FieldName="Periodo_guardaInactivo" Visible="False"/>
                                                                                <dxe:ListBoxColumn FieldName="idFrecuencia_guardaInactivo" Visible="False"/>
                                                                                <dxe:ListBoxColumn FieldName="Valor_administrativo" Visible="False"/>
                                                                                <dxe:ListBoxColumn FieldName="Valor_contable" Visible="False"/>
                                                                                <dxe:ListBoxColumn FieldName="Metodo_Destruccion" Visible="False"/>
                                                                                <dxe:ListBoxColumn FieldName="Clasificacion_De_Informacion" Visible="False"/>
                                                                                <dxe:ListBoxColumn FieldName="Fecha_Alta" Visible="False"/>
                                                                                <dxe:ListBoxColumn FieldName="Fecha_Ultimo_Cambio" Visible="False"/>
                                                                            </Columns>
                                                                         </dxe:ASPxComboBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </dxp:PanelContent> 
                                                    </PanelCollection> 
                                                    <TopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopLeft.png" Width="7px" />
                                                    <BottomLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomLeft.png" Width="7px" />
                                                </dxrp:ASPxRoundPanel> 
                                                <br />
                                                <dxrp:ASPxRoundPanel EnableViewState="False" ID="rpIndicesEscenciales" Width="100%" HeaderText="Elementos esenciales" 
                                                      runat="server" BackColor="White" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                                    <TopEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpTopEdge.gif" Repeat="RepeatX" VerticalPosition="Top" />
                                                    </TopEdge>
                                                    <LeftEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpLeftEdge.gif" Repeat="RepeatY" VerticalPosition="Top" />
                                                    </LeftEdge>
                                                    <BottomRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomRight.png" Width="7px" />
                                                    <ContentPaddings Padding="1px" />
                                                    <NoHeaderTopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopRight.png" Width="7px" />
                                                    <RightEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpRightEdge.gif" Repeat="RepeatY" VerticalPosition="Top" />
                                                    </RightEdge>
                                                    <HeaderRightEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" />
                                                    </HeaderRightEdge>
                                                    <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
                                                    <HeaderLeftEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" />
                                                    </HeaderLeftEdge>
                                                    <HeaderStyle BackColor="#E0EDFF">
                                                    <BorderBottom BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
                                                    </HeaderStyle>
                                                    <BottomEdge>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpBottomEdge.gif" Repeat="RepeatX" VerticalPosition="Bottom" />
                                                    </BottomEdge>
                                                    <TopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopRight.png" Width="7px" />
                                                    <HeaderContent>
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" />
                                                    </HeaderContent>
                                                    <NoHeaderTopEdge BackColor="White">
                                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpNoHeaderTopEdge.gif" Repeat="RepeatX" VerticalPosition="Top" />
                                                    </NoHeaderTopEdge>
                                                    <NoHeaderTopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopLeft.png" Width="7px" />
                                         <PanelCollection>
                                             <dxp:PanelContent ID="PanelContent2" runat="server">
                                             <dxcp:ASPxCallbackPanel runat="server" ID="cbpEC" ClientInstanceName="cbpEC" OnCallback="cbpEC_Callback">
                                                <PanelCollection><dxp:PanelContent ID="PanelContent3" runat="server">
                                                <table style="width:315px;">                                                    
                                                    <tr>
                                                        <td>
                                                            <dxe:aspxLabel ID="AspxLabel3" runat="server" Text="Codigo de referencia" Width="150px"></dxe:aspxLabel>
                                                        </td>
                                                        <td style="width:160px"> 
                                                            <dxe:ASPxTextBox ID="txtCodigo" runat="server" EnableClientSideAPI="True" EnableDefaultAppearance="True" Width="160px">
                                                            </dxe:ASPxTextBox>
                                                            <dxe:aspxLabel ID="lblCodigo" runat="server" Text="" Width="160px"></dxe:aspxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dxe:aspxLabel ID="AspxLabel1" runat="server" Text="Titulo"></dxe:aspxLabel>
                                                        </td>
                                                        <td>
                                                            <dxe:ASPxTextBox ID="txtDescripcion" runat="server" EnableClientSideAPI="True" EnableDefaultAppearance="True" Width="160px">
                                                            </dxe:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dxe:aspxLabel ID="AspxLabel4" runat="server" Text="Período de guarda activo"></dxe:aspxLabel>
                                                        </td>
                                                        <td>
                                                             <table style="width: 100%" cellpadding="0px" cellspacing="0px">
                                                                <tr>
                                                                    <td style="width:70px;">
                                                                        <dxe:ASPxSpinEdit ID="Periodo_guardaActivo" runat="server" Height="21px" Width="55px" />
                                                                    </td>
                                                                    <td>
                                                                        <dxe:ASPxComboBox ID="idFrecuencia_guardaActivo" runat="server" 
                                                                            ValueType="System.Int32" Width="90px" 
                                                                            ClientInstanceName="idFrecuencia_guardaActivo" >
                                                                            <Items>
                                                                                <dxe:ListEditItem Text="Días" Value="1" />
                                                                                <dxe:ListEditItem Text="Semanas" Value="2" />
                                                                                <dxe:ListEditItem Text="Meses" Value="3" />
                                                                                <dxe:ListEditItem Text="Años" Value="4" />
                                                                            </Items>
                                                                        </dxe:ASPxComboBox>
                                                                    </td>
                                                                </tr>
                                                             </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dxe:aspxLabel ID="AspxLabel5" runat="server" Text="Período de guarda inactivo"></dxe:aspxLabel>
                                                        </td>
                                                        <td>
                                                             <table style="width: 100%" cellpadding="0px" cellspacing="0px">
                                                                <tr>
                                                                    <td style="width:70px;">
                                                                        <dxe:ASPxSpinEdit ID="Periodo_guardaInactivo" runat="server" Height="21px" Width="55px" />
                                                                    </td>
                                                                    <td>
                                                                        <dxe:ASPxComboBox ID="idFrecuencia_guardaInactivo" runat="server" ValueType="System.Int32" Width="90px">
                                                                            <Items>
                                                                                <dxe:ListEditItem Text="Días" Value="1" />
                                                                                <dxe:ListEditItem Text="Semanas" Value="2" />
                                                                                <dxe:ListEditItem Text="Meses" Value="3" />
                                                                                <dxe:ListEditItem Text="Años" Value="4" />
                                                                            </Items>
                                                                        </dxe:ASPxComboBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dxe:aspxLabel ID="AspxLabel6" runat="server" Text="Valor documental"></dxe:aspxLabel>
                                                        </td>
                                                        <td>
                                                            <table style="width:100%" cellpadding="0px" cellspacing="0px">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <dxe:ASPxCheckBox ID="Valor_administrativo" runat="server" Text="Administrativo" ValueChecked="1" ValueType="System.Int32" ValueUnchecked="0">
                                                                        </dxe:ASPxCheckBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width:89px;">
                                                                        <dxe:ASPxCheckBox ID="Valor_legal" runat="server" Text="Legal" ValueChecked="1" ValueType="System.Int32" ValueUnchecked="0">
                                                                        </dxe:ASPxCheckBox>
                                                                    </td>
                                                                    <td>
                                                                        <dxe:ASPxCheckBox ID="Valor_contable" runat="server" Text="Contable" ValueChecked="1" ValueType="System.Int32" ValueUnchecked="0">
                                                                        </dxe:ASPxCheckBox>
                                                                    </td>
                                                                </tr> 
                                                            </table> 
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dxe:aspxLabel ID="AspxLabel7" runat="server" Text="Metodo de destrucción"></dxe:aspxLabel>
                                                        </td>
                                                        <td style="width:160px;">
                                                            <dxe:ASPxComboBox ID="Metodo_Destruccion" runat="server" 
                                                                DataSourceID="dsLista_catalogos" TextField="Descripcion" 
                                                                ValueField="IDCatalogo_item" Width="160px" 
                                                                ValueType="System.Int32">
                                                            </dxe:ASPxComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dxe:aspxLabel ID="AspxLabel8" runat="server" Text="Clasificación de Información"></dxe:aspxLabel>
                                                        </td>
                                                        <td style="width:160px;">
                                                            <dxe:ASPxComboBox ID="Clasificacion_De_Informacion" runat="server" 
                                                                DataSourceID="dsLista_Clasificacion_De_Informacion" TextField="Descripcion" 
                                                                ValueField="IDCatalogo_item" Width="160px" 
                                                                ValueType="System.Int32">
                                                            </dxe:ASPxComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dxe:aspxLabel ID="AspxLabel9" runat="server" Text="Fecha de Creación"></dxe:aspxLabel>
                                                        </td>
                                                        <td style="width:160px;">
                                                            <dxe:aspxLabel ID="Fecha_Alta" EnableViewState="true" runat="server" Text=""></dxe:aspxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dxe:aspxLabel ID="AspxLabel10" runat="server" Text="Fecha de ultimo cambio"></dxe:aspxLabel>
                                                        </td>
                                                        <td style="width:160px;">
                                                            <dxe:aspxLabel ID="Fecha_Ultimo_Cambio" runat="server" Text=""></dxe:aspxLabel>
                                                        </td>
                                                    </tr>
                                                </table>       
                                                </dxp:PanelContent></PanelCollection>
                                            </dxcp:ASPxCallbackPanel>
                                            </dxp:PanelContent> 
                                        </PanelCollection> 
                                                    <TopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopLeft.png" Width="7px" />
                                                    <BottomLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomLeft.png" Width="7px" />
                                                </dxrp:ASPxRoundPanel> 
                                                <br />
                                                <div style="width:322px;">
                                                    <dxwtl:ASPxTreeListTemplateReplacement ID="btUpdate" runat="server" ReplacementType="UpdateButton" /> 
                                                    <dxwtl:ASPxTreeListTemplateReplacement ID="Cancelar" runat="server"  ReplacementType="CancelButton" />
                                                </div>
                                            </editform>
                                            </templates>
                                            <Columns>
                                                <dxwtl:TreeListTextColumn Caption="Norma" FieldName="idDocumentoPID" 
                                                    ReadOnly="True" Visible="False">
                                                    </dxwtl:TreeListTextColumn>
                                                <dxwtl:TreeListTextColumn Caption="Norma" FieldName="Nivel_Descripcion" 
                                                    ReadOnly="True" Visible="False">
                                                </dxwtl:TreeListTextColumn>
                                                <dxwtl:TreeListTextColumn Caption="Nivel" FieldName="idNivel" ReadOnly="True" 
                                                    Visible="False">
                                                </dxwtl:TreeListTextColumn>
                                                <dxwtl:TreeListTextColumn Caption="Niveles" VisibleIndex="0">
                                                    <DataCellTemplate>
                                                        <dxe:ASPxImage ID="ASPxImage2" runat="server" 
                                                            ImageUrl="<%# GetNodeGlyph(Container) %>">
                                                        </dxe:ASPxImage>
                                                    </DataCellTemplate>
                                                </dxwtl:TreeListTextColumn>
                                                <dxwtl:TreeListTextColumn Caption="Descripción" FieldName="Descripcion" VisibleIndex="1">
                                                </dxwtl:TreeListTextColumn>
                                                <dxwtl:TreeListTextColumn Caption="Codigo" VisibleIndex="1">
                                                    <EditFormSettings Visible="False" />
                                                    <DataCellTemplate>
                                                        <span style="font-size:8px;">
                                                        <%# String.Concat(Eval("FormatoCodigo"), "_")  %>
                                                        </span><span style="font-size:10px;">
                                                        <%# Eval("Codigo_clasificacion")  %>
                                                        </span>
                                                    </DataCellTemplate>
                                                </dxwtl:TreeListTextColumn>
                                                <dxwtl:TreeListTextColumn Caption="valuepath" FieldName="valuepath" ReadOnly="True" Visible="False">
                                                </dxwtl:TreeListTextColumn>
                                                <dxwtl:TreeListCommandColumn ShowNewButtonInHeader="True" VisibleIndex="2" 
                                                    ButtonType="Image" ToolTip="Botones de Editar, Agregar y Eliminar" >
                                                    <EditButton  Visible="True" >
                                                        <Image Url="../App_Themes/Aqua/Editors/edtDropDownHottracked.png" AlternateText="Editar"></Image>
                                                    </EditButton>                            
                                                    <NewButton Text="Agregar" Visible="True"><Image Url="../App_Themes/Aqua/Editors/fcaddhot.png"></Image>                                
                                                    </NewButton>
                                                    <DeleteButton Visible="True"><Image Url="../App_Themes/Aqua/Editors/fcremovehot.png" AlternateText="Eliminar" ></Image>
                                                    </DeleteButton>
                                                    <CancelButton Text="Eliminar" Visible="True">
                                                    </CancelButton>
                                                </dxwtl:TreeListCommandColumn>
                                                <dxwtl:TreeListTextColumn FieldName="FormatoCodigo" Visible="False"></dxwtl:TreeListTextColumn> 
                                                <dxwtl:TreeListTextColumn FieldName="Periodo_guardaActivo" Visible="False"></dxwtl:TreeListTextColumn> 
                                                <dxwtl:TreeListTextColumn FieldName="idFrecuencia_guardaActivo" Visible="False"></dxwtl:TreeListTextColumn> 
                                                <dxwtl:TreeListTextColumn FieldName="Periodo_guardaInactivo" Visible="False"></dxwtl:TreeListTextColumn>
                                                <dxwtl:TreeListTextColumn FieldName="idFrecuencia_guardaInactivo" Visible="False"></dxwtl:TreeListTextColumn> 
                                                <dxwtl:TreeListTextColumn FieldName="Valor_administrativo" Visible="False"></dxwtl:TreeListTextColumn> 
                                                <dxwtl:TreeListTextColumn FieldName="Valor_contable" Visible="False"></dxwtl:TreeListTextColumn> 
                                                <dxwtl:TreeListTextColumn FieldName="Metodo_Destruccion" Visible="False"></dxwtl:TreeListTextColumn> 
                                                <dxwtl:TreeListTextColumn FieldName="Clasificacion_De_Informacion" Visible="False"></dxwtl:TreeListTextColumn> 
                                                <dxwtl:TreeListTextColumn FieldName="Fecha_Alta" Visible="False"></dxwtl:TreeListTextColumn> 
                                                <dxwtl:TreeListTextColumn FieldName="Fecha_Ultimo_Cambio" Visible="False"></dxwtl:TreeListTextColumn> 
                                            </Columns>
                                        </dxwtl:ASPxTreeList>
                                        </td>
                                        <td valign="top">
                                            <table border="0" cellpadding="1" cellspacing="1" style="width: 31%;" runat="server" id="tableIndices">
                                                <tr>
                                                    <td nowrap="noWrap" class="DataList_Aqua" >
                                                       <dxtc:ASPxPageControl ID="pgareas" runat="server" AutoPostBack="false" >
                                                            <TabStyle Width="40px"></TabStyle>
                                                       </dxtc:ASPxPageControl>
                                                       <div class="clear"></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                         <dxp:ASPxPanel ID="ASPxPanel1" runat="server" Width="200px">
                                                             <PanelCollection>
                                                                 <dxp:PanelContent runat="server">
                                                                     <dxe:ASPxButton ID="aspxEditar" runat="server" 
                                                                         CausesValidation="False" EnableViewState="false" style="height: 24px" 
                                                                         Text="Editar" UseSubmitBehavior="False">
                                                                     </dxe:ASPxButton>
                                                                     <table id="tableEditando" runat="server" Visible="False" cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                 <dxe:ASPxButton ID="aspxguardar" runat="server" 
                                                                                     ValidateInvisibleEditors="True" ValidationGroup="Archivos"
                                                                                     CausesValidation="True" EnableViewState="True" UseSubmitBehavior="False"
                                                                                     style="height: 24px" Text="Guardar"></dxe:ASPxButton>
                                                                            </td>
                                                                            <td>&nbsp;&nbsp;</td>
                                                                            <td>
                                                                                 <dxe:ASPxButton ID="aspxCancelar" runat="server" ValidateInvisibleEditors="True" ValidationGroup="Archivos"
                                                                                     CausesValidation="True" EnableViewState="True" UseSubmitBehavior="True"
                                                                                     Text="Cancelar" style="height: 24px">
                                                                                 </dxe:ASPxButton>
                                                                            </td>
                                                                        </tr>
                                                                     </table>                                                                                                  
                                                                 </dxp:PanelContent>
                                                             </PanelCollection>
                                                         </dxp:ASPxPanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td> 
                                    </tr>
                                </table>
                                <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" Text="" ForeColor="Red">
                            </dxe:ASPxLabel>
                        </dxp:PanelContent>
	                </PanelCollection>
                </dxcp:ASPxCallbackPanel>
                <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
           </td>
        </tr>
    </table>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="ListaArchivo_Descripciones_idSerie"
        TypeName="Portalv9.WSArchivo.Service1" 
        DeleteMethod="ABC_Archivo_Descripciones" 
        InsertMethod="ABC_Archivo_Descripciones" 
        OldValuesParameterFormatString="{0}" 
        UpdateMethod="ABC_Archivo_Descripciones">
        <DeleteParameters>
            <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
            <asp:Parameter Name="idDescripcion" Type="Int32" />
            <asp:Parameter Name="Codigo_clasificacion" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="idNivel" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idSerie" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="valuePath" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="idUnidadInstalacion" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Descripcion" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="idTipoElemento" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idDocumentoPID" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Atributo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idArchivo_Fisico" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idPlanta" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idPasillo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idSeccion" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idEstante" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idBalda" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="unidad_Instalacion" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="unidad_instalacion_subdivision" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="unidad_instalacion_orden" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="Ano" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="Mes" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="Dia" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="FormatoCodigo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idFrecuencia_guardaActivo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Periodo_guardaActivo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idFrecuencia_guardaInactivo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Periodo_guardaInactivo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Valor_administrativo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Valor_legal" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Valor_contable" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Metodo_Destruccion" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Clasificacion_De_Informacion" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Fecha_Ultimo_Cambio" Type="DateTime" DefaultValue="1/1/1900" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
            <asp:Parameter Name="idDescripcion" Type="Int32" />
            <asp:Parameter Name="Codigo_clasificacion" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="idNivel" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idSerie" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="valuePath" Type="String" DefaultValue="0" />
            <asp:Parameter Name="idUnidadInstalacion" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="Descripcion" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="idTipoElemento" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idDocumentoPID" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Atributo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idArchivo_Fisico" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idPlanta" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idPasillo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idSeccion" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idEstante" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idBalda" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="unidad_Instalacion" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="unidad_instalacion_subdivision" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="unidad_instalacion_orden" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="Ano" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="Mes" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="Dia" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="FormatoCodigo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idFrecuencia_guardaActivo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Periodo_guardaActivo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idFrecuencia_guardaInactivo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Periodo_guardaInactivo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Valor_administrativo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Valor_legal" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Valor_contable" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Metodo_Destruccion" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Clasificacion_De_Informacion" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Fecha_Ultimo_Cambio" Type="DateTime" DefaultValue="1/1/1900"/>
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
            <asp:Parameter Name="idNivel" DefaultValue="-1" Type="Int32" />
            <asp:Parameter Name="idSerie" DefaultValue="-1" Type="Int32" />
            <asp:SessionParameter Name="idDocumentoPID" SessionField="DSidDescripcion" DefaultValue="-1" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
            <asp:Parameter Name="idDescripcion" Type="Int32" />
            <asp:Parameter Name="Codigo_clasificacion" Type="String" />
            <asp:Parameter Name="idNivel" Type="Int32" />
            <asp:Parameter Name="idSerie" Type="Int32" />
            <asp:Parameter Name="valuePath" Type="String" DefaultValue="" />
            <asp:Parameter Name="idUnidadInstalacion" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="idTipoElemento" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idDocumentoPID" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="Atributo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idArchivo_Fisico" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idPlanta" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idPasillo" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idSeccion" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idEstante" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="idBalda" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="unidad_Instalacion" Type="String" DefaultValue=""/>
            <asp:Parameter Name="unidad_instalacion_subdivision" Type="String" DefaultValue=""/>
            <asp:Parameter Name="unidad_instalacion_orden" Type="String" DefaultValue=""/>
            <asp:Parameter Name="Ano" Type="String" DefaultValue=""/>
            <asp:Parameter Name="Mes" Type="String" DefaultValue=""/>
            <asp:Parameter Name="Dia" Type="String" DefaultValue=""/>
            <asp:Parameter Name="FormatoCodigo" Type="Int32" />
            <asp:Parameter Name="idFrecuencia_guardaActivo" Type="Int32" />
            <asp:Parameter Name="Periodo_guardaActivo" Type="Int32" />
            <asp:Parameter Name="idFrecuencia_guardaInactivo" Type="Int32" />
            <asp:Parameter Name="Periodo_guardaInactivo" Type="Int32" />
            <asp:Parameter Name="Valor_administrativo" Type="Int32" />
            <asp:Parameter Name="Valor_legal" Type="Int32" />
            <asp:Parameter Name="Valor_contable" Type="Int32" />
            <asp:Parameter Name="Metodo_Destruccion" Type="Int32" />
            <asp:Parameter Name="Clasificacion_De_Informacion" Type="Int32" />
            <asp:Parameter Name="Fecha_Ultimo_Cambio" Type="DateTime" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="ListaNormas_Areas" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
        SelectMethod="ListaNormas_Niveles" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsTipoDeExpediente" runat="server" 
        SelectMethod="ListaSeries_ModeloXNorma" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="idNorma" QueryStringField="idNorma" Type="Int32" />
            <asp:SessionParameter Name="idNivel" SessionField="idNivel" Type="Int32" />
            <asp:Parameter Name="NoIdentidad" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsLista_catalogos" runat="server" 
        SelectMethod="ListaCatalogo_Datos" TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
        <SelectParameters>
            <asp:Parameter Name="IDCatalogo" Type="Int32" DefaultValue="10" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsLista_Clasificacion_De_Informacion" runat="server" 
        SelectMethod="ListaCatalogo_Datos" TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}">
        <SelectParameters>
            <asp:Parameter Name="IDCatalogo" Type="Int32" DefaultValue="14" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
    <div class="clear"></div>
</asp:Content>
