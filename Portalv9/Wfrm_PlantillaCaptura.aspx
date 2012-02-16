<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster1col.master"
    CodeBehind="Wfrm_PlantillaCaptura.aspx.vb" Inherits="Portalv9.Wfrm_PlantillaCaptura" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="MsgBox" Namespace="MsgBox" TagPrefix="cc1" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Administración de áreas, elementos e indices"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function RefrescaArbol(value) {
            aspxtreenivel.PerformCallback(value);
        }
        function RefrescaiFrame() {
            document.getElementById('ctl00_ctl00_ContentPlaceHolder2_ContentPlaceHolder1_ASPxCallbackPanel1_iframeIndices').contentDocument.location.reload(true);
        }
        function CambiaFrame() {
            document.getElementById('ctl00_ctl00_ContentPlaceHolder2_ContentPlaceHolder1_ASPxCallbackPanel1_iframeIndices').contentWindow.RefrescaDatos();
        }
    </script>

    <table id="tableMainIFrame" style="width: 100%;">
        <tr>
            <td runat="server" id="trMainH" style="vertical-align: top; min-height: 450px;">
                <div>
                    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif"
                        NavigateUrl="javascript:history.go(-1);" />
                    <asp:Label ID="lblTitle" runat="server" Font-Size="Small" Height="16px" Font-Names="Arial"
                        Font-Bold="True" Font-Italic="True"> </asp:Label>
                    <dxe:ASPxButton ID="ASPxButton1" runat="server" Text="ASPxButton" ClientVisible="False">
                        <ClientSideEvents Click="function(s, e) {
	CambiaFrame();
}" />
                    </dxe:ASPxButton>
                </div>
                <table style="width: 100%">
                    <tr>
                        <td valign="top" style="min-width: 200px; height: 100%;">
                            <dxe:ASPxButtonEdit runat="server" Width="350px" ClientInstanceName="btEditCodigo"
                                ID="btEditCodigo" NullText="Buscar por código de clasificación">
                                <Buttons>
                                    <dxe:EditButton>
                                    </dxe:EditButton>
                                </Buttons>
                                <ClientSideEvents ButtonClick="function(s, e) {
	aspxtreenivel.PerformCallback(3);
}" />
                                <ButtonEditEllipsisImage Url="~/Images/Buscar.gif">
                                </ButtonEditEllipsisImage>
                            </dxe:ASPxButtonEdit>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="min-width: 200px; height: 100%;">
                            <div style="border: thin solid #BEDDFE; height: 310px; overflow: scroll;" runat="server"
                                id="MarcoArbol">
                                <dxwtl:ASPxTreeList ID="aspxtreenivel" runat="server" AutoGenerateColumns="False"
                                    DataSourceID="ObjectDataSource1" KeyFieldName="idDescripcion" ParentFieldName="idDocumentoPID"
                                    ClientInstanceName="aspxtreenivel" EnableViewState="False" SettingsText-CommandCancel="Cancelar"
                                     SettingsText-CommandNew="Insertar" SettingsText-CommandEdit="Editar" SettingsText-CommandDelete="Eliminar" 
                                    SettingsText-CommandUpdate="Actualizar" SettingsText-ConfirmDelete="Esta seguro que quiere eliminar ?"
                                    Height="300px" Width="960px">
                                    <Settings GridLines="Horizontal" />
                                    <SettingsBehavior AllowFocusedNode="true" ProcessFocusedNodeChangedOnServer="false"
                                        AllowSort="False" />
                                    <ClientSideEvents FocusedNodeChanged="function(s, e) {ASPxCallbackPanel1.PerformCallback(1); }"
                                        CustomButtonClick="function(s, e) {
	//s.PerformCallback(e.buttonID);
	if(e.buttonID=='btnSolicitar'){
	    ASPxCallbackPanel1.PerformCallback(5);
	} 
	else if (e.buttonID=='btnEditar'){
	   ASPxCallbackPanel1.PerformCallback(3);
	   }
	else{   
	   ASPxCallbackPanel1.PerformCallback(2);
	   }
}" EndCallback="function(s, e) {
       if (aspxtreenivel.cpValor == '1'){
       ASPxCallbackPanel1.PerformCallback(1);}
       if (aspxtreenivel.cpValor == '3'){
          document.getElementById('ctl00_ctl00_ContentPlaceHolder2_ContentPlaceHolder1_MarcoArbol').scrollTop=150;}       
}" />
                                    <SettingsEditing Mode="EditFormAndDisplayNode" />
                                    <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar este nivel ?" RecursiveDeleteError="El nivel no puede ser borrado ya que tiene subniveles." />
                                    <Templates>
                                        <EditForm>
                                            <table style="width: 315px;">
                                                <tr>
                                                    <td style="width: 150px">
                                                        <dxe:ASPxLabel ID="Label2" runat="server" Text="Tipo de Nivel" Width="150px">
                                                        </dxe:ASPxLabel>
                                                    </td>
                                                    <td style="width: 160px">
                                                        <dxe:ASPxComboBox ID="dlNiveles" runat="server" DropDownStyle="DropDown" ClientInstanceName="dlNiveles"
                                                            Width="160px" TextField="Nivel_Descripcion" ValueField="idNivel" DataSourceID="ObjectDataSource3"
                                                            Value='<%# Bind("idNivel") %>' ValueType="System.Int32">
                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                      cbSerie.PerformCallback(dlNiveles.GetValue().toString()); 
                                                      }" />
                                                        </dxe:ASPxComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px">
                                                        <dxe:ASPxLabel ID="AspxLabel2" runat="server" Text="Tipo de Expediente" Width="150px">
                                                        </dxe:ASPxLabel>
                                                    </td>
                                                    <td style="width: 160px">
                                                        <dxe:ASPxComboBox ID="cbSerie" runat="server" DropDownStyle="DropDown" ClientInstanceName="cbSerie"
                                                            TextField="Serie_nombre" ValueField="idSerie" Value='<%# Bind("idSerie") %>'
                                                            Width="160px" DataSourceID="dsTipoDeExpediente" ValueType="System.Int32">
                                                        </dxe:ASPxComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <dxe:ASPxLabel ID="AspxLabel1" runat="server" Text="Titulo">
                                                        </dxe:ASPxLabel>
                                                    </td>
                                                    <td>
                                                        <dxe:ASPxTextBox ID="txtDescripcion" runat="server" Value='<%# Bind("Descripcion") %>'
                                                            Width="160px">
                                                        </dxe:ASPxTextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <div style="width: 322px;">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <dxe:ASPxButton ID="btnUpdtae" runat="server" Text="Actualizar" OnClick="btnUpdtae_Click">
                                                            </dxe:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dxe:ASPxButton ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click">
                                                            </dxe:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </EditForm>
                                    </Templates>
                                    <Columns>
                                        <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" ReadOnly="True"
                                            Visible="False">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="Norma" FieldName="Nivel_Descripcion" ReadOnly="True"
                                            Visible="False">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="Nivel" FieldName="idNivel" ReadOnly="True" Visible="False">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="idSerie" FieldName="idSerie" ReadOnly="True" Visible="False">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="Niveles" VisibleIndex="0">
                                            <DataCellTemplate>
                                                <dxe:ASPxImage ID="ASPxImage2" runat="server" ImageUrl="<%# GetNodeGlyph(Container) %>">
                                                </dxe:ASPxImage>
                                            </DataCellTemplate>
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="Código de clasificación" FieldName="Codigo_clasificacion"
                                            VisibleIndex="1" Width="260px">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="Descripción" FieldName="Descripcion" VisibleIndex="2">
                                            <CellStyle Wrap="True">
                                            </CellStyle>
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListCommandColumn ShowNewButtonInHeader="True" VisibleIndex="3" ButtonType="Image"
                                            ToolTip="Botones de Editar, Agregar y Eliminar" Width="30px" >
                                            <EditButton>
                                                <Image Url="~/Images/editar.gif" AlternateText="Editar" Width="13" Height="13">
                                                </Image>
                                            </EditButton>
                                            <NewButton Text="Agregar">
                                                <Image Url="~/App_Themes/Editors/fcaddhot.png">
                                                </Image>
                                            </NewButton>
                                            <CustomButtons>
                                                <dxwtl:TreeListCommandColumnCustomButton ID="btnAgregar" Text="Agregar">
                                                    <Image Url="~/Images/fcaddhot.png">
                                                    </Image>
                                                </dxwtl:TreeListCommandColumnCustomButton>
                                                <dxwtl:TreeListCommandColumnCustomButton Text="Editar" ID="btnEditar">
                                                    <Image Url="~/Images/editar.gif" Height="13" Width="13">
                                                    </Image>
                                                </dxwtl:TreeListCommandColumnCustomButton>
                                                <dxwtl:TreeListCommandColumnCustomButton Text="Solicitar" ID="btnSolicitar" Visibility="Hidden">
                                                    <Image Url="~/Images/adicional.png" Height="13" Width="13" ToolTip="Solicitar prestamo de expediente">
                                                    </Image>
                                                </dxwtl:TreeListCommandColumnCustomButton>
                                            </CustomButtons>
                                            
                                            <CancelButton Text="Cancelar" Visible="True">
                                            </CancelButton>
                                            
                                        </dxwtl:TreeListCommandColumn>
                                          <dxwtl:TreeListCommandColumn ShowNewButtonInHeader="false" VisibleIndex="4" ButtonType="Image"
                                            ToolTip="Boton Eliminar" Width="10px" >
                                            <DeleteButton Visible="True">
                                                <Image Url="~/App_Themes/Editors/fcremovehot.png" AlternateText="Eliminar">
                                                </Image>
                                            </DeleteButton>
                                            </dxwtl:TreeListCommandColumn>
                                        
                                        <dxwtl:TreeListTextColumn Caption="valuePath" FieldName="valuePath" ReadOnly="True"
                                            Visible="False">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" ReadOnly="True"
                                            Visible="False">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="idTipoElemento" FieldName="idTipoElemento" ReadOnly="True"
                                            Visible="False">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn FieldName="idUnidadInstalacion" ReadOnly="True" Visible="False">
                                        </dxwtl:TreeListTextColumn>
                                    </Columns>
                                </dxwtl:ASPxTreeList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="min-width: 200px; height: 100%;">
                            <dxcp:ASPxCallbackPanel ID="ASPxCallbackPanel1" ClientInstanceName="ASPxCallbackPanel1"
                                OnCallback="ASPxCallbackPanel1_Callback" runat="server" Width="100%" HideContentOnCallback="False">
                                <PanelCollection>
                                    <dxp:PanelContent ID="PanelContent2" runat="server">
                                        <iframe runat="server" id="iframeIndices" frameborder="0" width="100%" height="300">
                                        </iframe>
                                    </dxp:PanelContent>
                                </PanelCollection>
                            </dxcp:ASPxCallbackPanel>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblidNorma" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListaArchivo_Descripciones_idSerie"
        TypeName="Portalv9.WSArchivo.Service1" DeleteMethod="ABC_Archivo_Descripciones"
        InsertMethod="ABC_Archivo_Descripciones" OldValuesParameterFormatString="{0}"
        UpdateMethod="ABC_Archivo_Descripciones">
        <DeleteParameters>
            <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
            <asp:Parameter Name="idDescripcion" Type="Int32" />
            <asp:Parameter Name="Codigo_clasificacion" Type="String" DefaultValue="0" />
            <asp:Parameter Name="idNivel" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="idSerie" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="valuePath" Type="String" DefaultValue="0" />
            <asp:Parameter Name="idUnidadInstalacion" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="Descripcion" Type="String" DefaultValue="0" />
            <asp:Parameter Name="idTipoElemento" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="idDocumentoPID" Type="Int32" DefaultValue="0" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
            <asp:Parameter Name="idDescripcion" Type="Int32" />
            <asp:Parameter Name="Codigo_clasificacion" Type="String" DefaultValue="0" />
            <asp:Parameter Name="idNivel" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="idSerie" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="valuePath" Type="String" DefaultValue="0" />
            <asp:Parameter Name="idUnidadInstalacion" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="Descripcion" Type="String" DefaultValue="0" />
            <asp:Parameter Name="idTipoElemento" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="idDocumentoPID" Type="Int32" DefaultValue="0" />
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
            <asp:Parameter Name="idNivel" DefaultValue="-1" Type="Int32" />
            <asp:Parameter Name="idSerie" DefaultValue="-1" Type="Int32" />
            <asp:SessionParameter Name="idDocumentoPID" SessionField="DSidDescripcion" DefaultValue="-1"
                Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
            <asp:Parameter Name="idDescripcion" Type="Int32" />
            <asp:Parameter Name="Codigo_clasificacion" Type="String" />
            <asp:Parameter Name="idNivel" Type="Int32" />
            <asp:Parameter Name="idSerie" Type="Int32" />
            <asp:Parameter Name="valuePath" Type="String" DefaultValue="0" />
            <asp:Parameter Name="idUnidadInstalacion" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="idTipoElemento" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="idDocumentoPID" Type="Int32" DefaultValue="0" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="ListaNormas_Niveles"
        TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsTipoDeExpediente" runat="server" SelectMethod="ListaSeries_ModeloXNorma"
        TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="idNorma" QueryStringField="idNorma"
                Type="Int32" />
            <asp:SessionParameter Name="idNivel" SessionField="idNivel" Type="Int32" />
            <asp:Parameter Name="NoIdentidad" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <cc1:MsgBox ID="MsgBox1" runat="server" ForeColor="Red"></cc1:MsgBox>
</asp:Content>
