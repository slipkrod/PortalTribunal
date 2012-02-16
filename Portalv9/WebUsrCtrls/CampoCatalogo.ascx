<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoCatalogo.ascx.vb" Inherits="Portalv9.CampoCatalogo" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<table >
    <tr>
        <td width="40%">
            <table>
    <tr>
        <td class="WebUsrCtrls-td1" id="tdCampo" runat="server" style="height:24;">
            <dxe:ASPxLabel ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
        <td class="WebUsrCtrls-td2" id="tdTexto_Padres" runat="server" style="height:24;">
            <dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" 
                Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
    </tr>
</table>
        </td>
        <td width="60%">
            <dxe:ASPxComboBox ID="Valor" runat="server" DataSourceID="ObjectDataSource1" 
                ValueField="IDCatalogo_item" ValueType="System.Int32" Width="340px">
                <Columns>
                    <dxe:ListBoxColumn Caption="IDCatalogo_item" FieldName="IDCatalogo_item" 
                        Visible="False" />
                    <dxe:ListBoxColumn Caption="Descripción" FieldName="Descripcion" />
                </Columns>
                <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorText="Valor invalido" ErrorTextPosition="Bottom" ValidationGroup="Archivos">
                    <RequiredField ErrorText="* Campo requerido" />
                </ValidationSettings>
            </dxe:ASPxComboBox>
        </td>
    </tr>
</table>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="ListaCatalogo_Datos"                                            
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="{0}"  >
        <SelectParameters>
            <asp:Parameter Name="IDCatalogo" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
        
                                        
        
                                        