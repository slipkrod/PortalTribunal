<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CampoMultiSelect.ascx.vb" Inherits="Portalv9.CampoMultiSelect" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<table>
    <tr>
        <td width="40%">
            &nbsp;
        <table style="vertical-align: top">
    <script type="text/javascript">
        function setValorControls() {
            try {
                txtValor.SetVisible(false);
                speValor.SetVisible(false);
                cmbValor.SetVisible(false);                
                daeValor.SetVisible(false);
                switch (lblTipoValor.GetValue()) {
                    case "0":
                        try {
                            txtValor.SetVisible(true);
                        }
                        catch (e) { }
                        break;
                    case "7":
                        try {
                            speValor.SetVisible(true);
                        }
                        catch (e) { }
                        break;
                    case "6":
                        try {
                            cmbValor.SetVisible(true);
                        }
                        catch (e) { }
                        break;
                    case "2":
                        try {
                            daeValor.SetVisible(true);
                        }
                        catch (e) { }
                        break;
                }
            }
            catch (e) { } 
        }
    </script>
    <tr>
        <td class="WebUsrCtrls-td1" style="height:24;" id="tdCampo" runat="server">
            <dxe:ASPxLabel  ID="Campo" runat="server" Font-Names="Arial" Font-Size="10pt" >
            </dxe:ASPxLabel>
        </td>
        <td class="WebUsrCtrls-td2" id="tdTexto_Padres" runat="server" style="height: 24px;">
            <dxe:ASPxLabel ID="Texto_Padres" runat="server" Font-Names="Arial" 
                Font-Size="10pt">
            </dxe:ASPxLabel>
        </td>
    </tr> 
    </table>
        </td>
        <td width="60%">
            &nbsp;<dxe:ASPxListBox ID="lbCatalogo" runat="server" 
                DataSourceID="dsCatalogoDatosAll" SelectionMode="CheckColumn" 
                TextField="Descripcion" ValueField="IDCatalogo_item" 
                ValueType="System.Int32" Width="100%" >
            </dxe:ASPxListBox>
        &nbsp;</td>
    </tr>
</table>
    <asp:ObjectDataSource ID="dsCatalogoDatosAll" runat="server" SelectMethod="ListaCatalogo_Datos" TypeName="Portalv9.WSArchivo.Service1"  >
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCatalogo" Name="IDCatalogo" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsValores" runat="server" 
        SelectMethod="ListaArchivo_indicexidDescripcion_idIndice"          
        TypeName="Portalv9.WSArchivo.Service1" 
    InsertMethod="ABC_Archivo_indice" UpdateMethod="ABC_Archivo_indice"  >
        <UpdateParameters>
            <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
            <asp:Parameter DefaultValue="" Name="idNorma" Type="Int32" />
            <asp:Parameter Name="idArea" Type="Int32" />
            <asp:Parameter Name="idElemento" Type="Int32" />
            <asp:Parameter Name="idIndice" Type="Int32" />
            <asp:Parameter Name="idArchivo" Type="Int32" />
            <asp:Parameter Name="idDescripcion" Type="Int32" />
            <asp:Parameter Name="idFolio" Type="Int32" />
            <asp:Parameter Name="idNivel" Type="Int32" />
            <asp:Parameter Name="idSerie" Type="Int32" />
            <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
            <asp:Parameter Name="Valor" Type="String" />
            <asp:Parameter Name="Indice_Tipo" Type="Int32" />
            <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
        </UpdateParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="lblidArchivo" Name="idArchivo" 
            PropertyName="Text" Type="Int32" />
        <asp:ControlParameter Name="idDescripcion"  ControlID="lblidDescripcion" PropertyName="Text" Type="Int32"/>
        <asp:Parameter Name="idIndice" Type="Int32" />
    </SelectParameters>
        <InsertParameters>
            <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
            <asp:Parameter Name="idNorma" Type="Int32" />
            <asp:Parameter Name="idArea" Type="Int32" />
            <asp:Parameter Name="idElemento" Type="Int32" />
            <asp:Parameter Name="idIndice" Type="Int32" />
            <asp:Parameter Name="idArchivo" Type="Int32" />
            <asp:Parameter Name="idDescripcion" Type="Int32" />
            <asp:Parameter Name="idFolio" Type="Int32" />
            <asp:Parameter Name="idNivel" Type="Int32" />
            <asp:Parameter Name="idSerie" Type="Int32" />
            <asp:Parameter Name="relacion_con_normaPID" Type="Int32" />
            <asp:Parameter Name="Valor" Type="String" />
            <asp:Parameter Name="Indice_Tipo" Type="Int32" />
            <asp:Parameter Name="IDCatalogo_item" Type="Int32" />
        </InsertParameters>
</asp:ObjectDataSource>
    <asp:Label ID="lblCatalogo" runat="server" Visible="False"></asp:Label>    
    <asp:Label ID="lblidDescripcion" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblidArchivo" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblIndice_Tipo" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblidIndice" runat="server" Visible="False"></asp:Label>
    <br />
    
