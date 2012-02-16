<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfm_Captura_Expediente_Serie.aspx.vb" Inherits="Portalv9.Wfm_Captura_Expediente_Serie" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>

<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 126px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
                        <table style="border: 1px solid #BEDDFE; width: 600px; font-family: Arial, Helvetica, sans-serif; font-size: 12px;">
                            <tr>
                                <td class="style1">
                                                <dxe:aspxLabel ID="Label2" runat="server" Text="Serie" Width="150px"></dxe:aspxLabel>
                                            </td>
                                <td>
                                <div style="overflow: auto; height: 190px">
                                    <dxwtl:ASPxTreeList ID="aspxtreenivel" runat="server" 
                AutoGenerateColumns="False" ClientInstanceName="treeList" 
                DataSourceID="dsArchivoSeries" EnableViewState="False" Height="185px" 
                KeyFieldName="idDescripcion" ParentFieldName="idDocumentoPID" 
                SettingsText-CommandCancel="Cancelar" SettingsText-CommandDelete="Eliminar" 
                SettingsText-CommandEdit="Editar" SettingsText-CommandNew="Insertar" 
                SettingsText-CommandUpdate="Actualizar" 
                SettingsText-ConfirmDelete="Esta seguro que quiere eliminar ?" 
                Width="312px">
                                        <Border BorderColor="#BEDDFE" BorderStyle="Solid" BorderWidth="1px" />
                <SettingsBehavior AllowFocusedNode="true" AllowSort="False" 
                    ProcessFocusedNodeChangedOnServer="false" />                
                <SettingsEditing Mode="EditFormAndDisplayNode" />
                <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar este nivel ?" 
                    RecursiveDeleteError="El nivel no puede ser borrado ya que tiene subniveles." />               
                <Columns>
                    <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
                        ReadOnly="True" Visible="False">
                    </dxwtl:TreeListTextColumn>
                    <dxwtl:TreeListTextColumn Caption="Nivel" FieldName="idNivel" 
                        ReadOnly="True" Visible="False">
                    </dxwtl:TreeListTextColumn>
                    <dxwtl:TreeListTextColumn Caption="idSerie" FieldName="idSerie" ReadOnly="True" 
                        Visible="False">
                    </dxwtl:TreeListTextColumn>
                    <dxwtl:TreeListTextColumn Caption="Niveles" VisibleIndex="0">
                        <datacelltemplate>
                            <dxe:ASPxImage ID="ASPxImage2" runat="server" 
                                ImageUrl="<%# GetNodeGlyph(Container) %>">
                            </dxe:ASPxImage>
                        </datacelltemplate>
                    </dxwtl:TreeListTextColumn>
                    <dxwtl:TreeListTextColumn Caption="Descripción" VisibleIndex="1" 
                        FieldName="Descripcion">
                    </dxwtl:TreeListTextColumn>
                    <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" 
                        ReadOnly="True" Visible="False">
                    </dxwtl:TreeListTextColumn>
                    <dxwtl:TreeListTextColumn Caption="Codigo_clasificacion" 
                        FieldName="Codigo_clasificacion" Visible="False" VisibleIndex="2">
                    </dxwtl:TreeListTextColumn>
                </Columns>
            </dxwtl:ASPxTreeList>
                                </div>
                                            </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                                <dxe:aspxLabel ID="AspxLabel2" runat="server" Text="Tipo de Expediente" 
                                                    Width="150px"></dxe:aspxLabel>                                                 
                                            </td>
                                <td>
                                                <dxe:ASPxComboBox ID="cbSerie" runat="server" 
                                        DropDownStyle="DropDown" ClientInstanceName="cbSerie"                                                       
                                                    TextField="Serie_nombre" ValueField="idSerie" 
                                                    Width="350px" 
                                                    DataSourceID="dsTipoDeExpediente" ValueType="System.Int32">
                                                    <ValidationSettings ErrorTextPosition="Bottom">
                                                        <RequiredField ErrorText="* Requerido" IsRequired="True" />
                                                    </ValidationSettings>
                                                 </dxe:ASPxComboBox>
                                            </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                     <dxe:ASPxButton ID="aspxguardar" runat="server" ValidateInvisibleEditors="True"
                                         CausesValidation="True" style="height: 24px" Text="Continuar"></dxe:ASPxButton>
                                            </td>
                                <td>
                                     <dxe:ASPxButton ID="aspxCancelar" runat="server" Text="Cancelar" style="height: 24px" CausesValidation="False">
                                     </dxe:ASPxButton>
                                            </td>
                            </tr>
                        </table>
    
    </div>
    <asp:ObjectDataSource ID="dsTipoDeExpediente" runat="server" 
        SelectMethod="ListaSeries_ModeloXNorma" TypeName="Portalv9.WSArchivo.Service1" 
                OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="idNorma" QueryStringField="idNorma" Type="Int32" />
            <asp:QueryStringParameter Name="idNivel" QueryStringField="idNivel" 
                Type="Int32" />
            <asp:Parameter Name="NoIdentidad" Type="Int32" />            
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsArchivoSeries" runat="server" 
        SelectMethod="ListaArchivo_Descripciones_Nivel_Logico"
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
            <asp:Parameter Name="Nivel_Logico_Fisico" DefaultValue="0" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>                            

    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
    </form>
</body>
</html>

