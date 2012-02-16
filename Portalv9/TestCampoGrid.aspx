<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TestCampoGrid.aspx.vb" Inherits="Portalv9.TestCampoGrid" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register src="WebUsrCtrls/CampoGrid.ascx" tagname="CampoGrid" tagprefix="uc1" %>

<%@ Register src="WebUsrCtrls/CampoMultiSelect.ascx" tagname="CampoMultiSelect" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
    .style1
    {
        width: 200px;
        height: 24px;
    }
    .style2
    {
        height: 24px;
        width: 100px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="vertical-align: top">
    <tr>
        <td class="style1">
            <dxe:ASPxLabel  ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
        <td class="style1">
            <dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" 
                Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
    </tr> 
    <tr>
        <td class="style2">
            <dxwgv:ASPxGridView ID="aspxGridCatalogoCampos" runat="server" 
                AutoGenerateColumns="False" DataSourceID="dsValores" KeyFieldName="idFolio" Width="355px">
                <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar"  
                    CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                    ConfirmDelete="¿Seguro desea borrar este registro?" 
                    EmptyDataRow="No existen datos" />
                <SettingsEditing EditFormColumnCount="1" NewItemRowPosition="Bottom" Mode="EditFormAndDisplayRow"/>
                <Templates>
                    <EditForm>
                        <table style="border: thin solid #C9D7DD; width: 100%; height: 160px;">
                            <tr>
                                <td style="width: 161px">Catalogo</td>
                                <td>
                                    <dxe:ASPxComboBox ID="cmbCatalogos" runat="server" ClientInstanceName="cmbCatalogos" 
                                        TextField="Descripcion" ValueField="IDCatalogo" ValueType="System.Int32" 
                                        DataSourceID="dsListaCatalogo" Value='<%# Bind("relacion_con_normaPID") %>'>
                                    </dxe:ASPxComboBox>
                                    <asp:Label ID="lblCatalogo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 161px">Campo</td>
                                <td>
                                    <dxe:ASPxComboBox ID="cmbCampo" runat="server" ClientInstanceName="cmbCampo" 
                                        TextField="Descripcion" ValueField="IDCatalogo_item" ValueType="System.Int32"  
                                        DataSourceID="dsCatalogoDatos" Value='<%# Bind("IDCatalogo_item") %>'>
                                    </dxe:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 161px">Valor</td>
                                <td>
                                    <dxe:ASPxTextBox ID="txtValor" runat="server" 
                                        Text='<%# Bind("Valor") %>'></dxe:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                        <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                        <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                    </EditForm>
                </Templates>                
                <Columns>
                    <dxwgv:GridViewDataTextColumn Caption="idNorma" FieldName="idNorma" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idArea" FieldName="idArea" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idElemento" FieldName="idElemento" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idIndice" FieldName="idIndice" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idArchivo" FieldName="idArchivo" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idDescripcion" FieldName="idDescripcion" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idFolio" FieldName="idFolio" Visible="True" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="Indice_Tipo" FieldName="Indice_Tipo" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataComboBoxColumn Caption="Catalogo" FieldName="relacion_con_normaPID" VisibleIndex="0" >
                         <PropertiesComboBox DataSourceID="dsListaCatalogo" TextField="Descripcion" 
                                ValueField="IDCatalogo" ValueType="System.Int32"></PropertiesComboBox>
                    </dxwgv:GridViewDataComboBoxColumn>
                    <dxwgv:GridViewDataComboBoxColumn Caption="Campo" FieldName="IDCatalogo_item" VisibleIndex="1">
                         <PropertiesComboBox DataSourceID="dsCatalogoDatos" TextField="Descripcion" 
                                ValueField="IDCatalogo_item" ValueType="System.Int32"></PropertiesComboBox>
                    </dxwgv:GridViewDataComboBoxColumn>
                    <dxwgv:GridViewDataTextColumn Caption="Valor" FieldName="Valor" VisibleIndex="2">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="idSerie" FieldName="idSerie" Visible="False" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewCommandColumn VisibleIndex="2">
                        <EditButton Visible="True"></EditButton>
                        <NewButton Visible="True"></NewButton>
                        <DeleteButton Visible="True"></DeleteButton>
                    </dxwgv:GridViewCommandColumn>
                </Columns>
            </dxwgv:ASPxGridView>            
          </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
    </tr>
</table>
    <asp:ObjectDataSource ID="dsListaCatalogo" runat="server" SelectMethod="ListaCatalogo" TypeName="Portalv9.WSArchivo.Service1"  >
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsCatalogoDatos" runat="server" SelectMethod="ListaCatalogo_Datos" TypeName="Portalv9.WSArchivo.Service1"  >
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCatalogo" Name="IDCatalogo" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsValores" runat="server" 
        SelectMethod="ListaArchivo_indice" DeleteMethod="ABC_Archivo_indice"          
        TypeName="Portalv9.WSArchivo.Service1" InsertMethod="ABC_Archivo_indice" 
        UpdateMethod="ABC_Archivo_indice"  >
     <DeleteParameters>
         <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
         <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
         <asp:Parameter DefaultValue="" Name="idArea" Type="Int32" />
         <asp:Parameter Name="idElemento" Type="Int32" />
         <asp:Parameter Name="idIndice" Type="Int32" />
         <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
         <asp:ControlParameter Name="idDescripcion"  ControlID="lblidDescripcion" PropertyName="Text" Type="Int32"/>
         <asp:Parameter Name="idFolio" Type="Int32" />         
         <asp:ControlParameter Name="idNivel"  ControlID="lblidNivel" PropertyName="Text" Type="Int32"/>
         <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" Type="Int32" />
         <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
         <asp:Parameter Name="Valor" Type="String" />
         <asp:Parameter Name="Indice_Tipo" Type="Int32" />
         <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
     </DeleteParameters>
     <UpdateParameters>
         <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
         <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
         <asp:Parameter DefaultValue="" Name="idArea" Type="Int32" />
         <asp:Parameter Name="idElemento" Type="Int32" />
         <asp:Parameter Name="idIndice" Type="Int32" />
         <asp:QueryStringParameter DefaultValue="" Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
         <asp:ControlParameter Name="idDescripcion" ControlID="lblidDescripcion" PropertyName="Text" Type="Int32"/>
         <asp:Parameter Name="idFolio" Type="Int32" DefaultValue="0"/>
         <asp:ControlParameter Name="idNivel"  ControlID="lblidNivel" PropertyName="Text" Type="Int32"/>
         <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" Type="Int32" />
         <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
         <asp:Parameter Name="Valor" Type="String" />
         <asp:Parameter Name="Indice_Tipo" Type="Int32" />
         <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
     </UpdateParameters>
    <SelectParameters>
        <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
        <asp:Parameter Name="idArea" Type="Int32" />
        <asp:Parameter Name="idElemento" Type="Int32" />
        <asp:Parameter Name="idIndice" Type="Int32" />
        <asp:QueryStringParameter Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
        <asp:ControlParameter Name="idDescripcion"  ControlID="lblidDescripcion" PropertyName="Text" Type="Int32"/>
    </SelectParameters>
     <InsertParameters>
         <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
         <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
         <asp:Parameter DefaultValue="" Name="idArea" Type="Int32" />
         <asp:Parameter Name="idElemento" Type="Int32" />
         <asp:Parameter Name="idIndice" Type="Int32" />
         <asp:QueryStringParameter DefaultValue="" Name="idArchivo" QueryStringField="idArchivo" Type="Int32" />
         <asp:ControlParameter Name="idDescripcion"  ControlID="lblidDescripcion" PropertyName="Text" Type="Int32"/>
         <asp:Parameter Name="idFolio" Type="Int32" DefaultValue="0" />
         <asp:ControlParameter Name="idNivel"  ControlID="lblidNivel" PropertyName="Text" Type="Int32"/>
         <asp:QueryStringParameter Name="idSerie" QueryStringField="idSerie" Type="Int32" />
         <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
         <asp:Parameter Name="Valor" Type="String" />
         <asp:Parameter Name="Indice_Tipo" Type="Int32" />
         <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
     </InsertParameters>
</asp:ObjectDataSource>
<p>
    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>    
    <br />1<asp:Label ID="lblidArea" runat="server" Visible="True" Text="48"></asp:Label>
    <br />2<asp:Label ID="lblidElemento" runat="server" Visible="True" Text="152"></asp:Label>
    <br />3<asp:Label ID="lblidIndice" runat="server" Visible="True" Text="641"></asp:Label>
    <br />4<asp:Label ID="lblidDescripcion" runat="server" Visible="True" Text="482707"></asp:Label>
    <br />5<asp:Label ID="lblidNivel" runat="server" Visible="True" Text="253"></asp:Label>
    <br />6<asp:Label ID="lblIndice_Tipo" runat="server" Visible="True" Text="12"></asp:Label>
    <br />7<asp:Label ID="lblCatalogo" runat="server" Visible="True" Text="12"></asp:Label>
</p>
    <uc1:CampoGrid ID="CampoGrid1" runat="server" Catalogo="12" idArea="48" idElemento="152" idIndice="641" idDescripcion="482707" idNivel="253"
     Indice_Tipo="12" />
    <uc2:CampoMultiSelect ID="CampoMultiSelect1" runat="server" Catalogo="16" />
    <br />
    </form>
</body>
</html>
