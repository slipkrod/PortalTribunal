<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfm_Captura_Tipo_documento.aspx.vb" Inherits="Portalv9.Wfm_Captura_Tipo_documento" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 130px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="vertical-align: top">
    
                        <table style="width: 600px; font-family: Arial, Helvetica, sans-serif; font-size: 12px;">
                            <tr>
                                <td class="style1">
                                                <dxe:aspxLabel ID="AspxLabel2" runat="server" Text="Tipo de Documento" 
                                                    Width="120px"></dxe:aspxLabel>                                                 
                                            </td>
                                <td>
                                                <dxe:ASPxComboBox ID="cbSerie" runat="server" 
                                        DropDownStyle="DropDown" ClientInstanceName="cbSerie"                                                       
                                                    TextField="Serie_nombre" ValueField="idSerie" 
                                                    Width="400px" 
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
            <asp:Parameter Name="NoIdentidad" Type="Int32" DefaultValue="-1" />            
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>

