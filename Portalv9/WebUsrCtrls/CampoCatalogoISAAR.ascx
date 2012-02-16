<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoCatalogoISAAR.ascx.vb" Inherits="Portalv9.CampoCatalogoISAAR" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
  <script type="text/javascript">
      function OnTipoChanged(cmbtipo) {
          valor.PerformCallback(cmbtipoentidad.GetText());
      }
  </script>
  
<table>
    <tr>
        <td class="WebUsrCtrls-td1">
            <dxe:ASPxLabel  ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
        <td class="WebUsrCtrls-td2" id="tdTexto_Padres" runat="server">
            <dxe:ASPxLabel  ID="Texto_Padres" runat="server" Font-Names="Arial" 
                Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
        <td>
         <dxe:ASPxComboBox ID="cmbtipoentidad" ClientInstanceName="cmbtipoentidad"  runat="server" SelectedIndex="0" AutoPostBack="true">
            <Items>
               <dxe:ListEditItem Text=" " Value="-1" />
               <dxe:ListEditItem Text="Institución" Value="0"   />
               <dxe:ListEditItem Text="Familia" Value="1" />
               <dxe:ListEditItem Text="Persona" Value="2" />
                </Items>
                 <ClientSideEvents SelectedIndexChanged="function(s, e) { e.processOnServer = false; OnTipoChanged(s);   }"></ClientSideEvents>
           </dxe:ASPxComboBox>

        <dxe:ASPxComboBox ID="Valor" runat="server" DataSourceID="ListaISAARxtipos"  ClientInstanceName="valor" SelectedIndex="0"
                ValueField="idISAAR" ValueType="System.Int32">
                <Columns>
                    <dxe:ListBoxColumn Caption="idISAAR" FieldName="idISAAR" 
                        Visible="False" />
                    <dxe:ListBoxColumn Caption="Descripción" FieldName="Formas_autorizadas_nombre" />
                </Columns>
        </dxe:ASPxComboBox>
        </td>
    </tr>
</table>

<asp:ObjectDataSource ID="ListaISAARxtipos" runat="server" TypeName="Portalv9.WSArchivo.Service1" SelectMethod="ListaISAARxtipoent" >
 <SelectParameters>
      <asp:Parameter Name="tipo_de_entidad" Type="String" />
</SelectParameters> 
    
</asp:ObjectDataSource>                                        
        
                                        
        
