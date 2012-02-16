<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfm_Indices_Nuevo.aspx.vb" Inherits="Portalv9.Wfm_Indices_Nuevo" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/css-content.css" rel="stylesheet" type="text/css" />
    <style type="text/css">        
        #WebUsrCtrls-td1
        {
            width: 210px;
        }
        #WebUsrCtrls-td2
        {
            width: 75px;
        }
    </style>

    <script type="text/javascript">
        function resizeFrame() {
            try {
                parent.document.getElementById('ctl00_ctl00_ContentPlaceHolder2_ContentPlaceHolder1_ASPxCallbackPanel1_iframeIndices').style.height = (document.getElementById('iframedBody').scrollHeight + 20) + 'px';
                parent.document.getElementById('ctl00_ctl00_ContentPlaceHolder2_ContentPlaceHolder1_ASPxCallbackPanel1_iframeIndices').style.height = (document.getElementById('iframedBody').scrollHeight + 30) + 'px';
                parent.document.getElementById('tableMainIFrame').style.height = (document.getElementById('iframedBody').scrollHeight + 40) + 'px';
                //alert(parent.document.getElementById('ctl00_ctl00_ContentPlaceHolder2_ContentPlaceHolder1_ASPxCallbackPanel1_iframeIndices').style.height);
            }
            catch (e) { }
        }
        function RefrescaArbol(valor) {
            var parentWindow = window.parent;
            parentWindow.RefrescaArbol(2);
        }
    </script>
</head>
<body id="iframedBody" onload="resizeFrame()" style="background-color:White; background-image:none;">
    <form id="form1" runat="server">
            <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" Text="" ForeColor="Red"></dxe:ASPxLabel>
            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%; max-width:650px;" runat="server" id="tableIndices">
                <tr>
                    <td >
                       <div class="clear">
                                <dxp:ASPxPanel ID="PnlElementos" runat="server" Width="600px" 
                                    CssClass="ControlAlignLeft" >
                                    <Border BorderColor="#C9D7DD" BorderStyle="Solid" BorderWidth="1px" />
                                    <PanelCollection>
                                        <dxp:PanelContent ID="PanelContent1" runat="server">
                                        </dxp:PanelContent>
                                    </PanelCollection>
                                </dxp:ASPxPanel>
                        </div>                        
                    </td>
                </tr>
                <tr>
                    <td>
                         <table id="tableEditando" runat="server" Visible="True" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                     <dxe:ASPxButton ID="aspxguardar" runat="server" ValidateInvisibleEditors="True" ValidationGroup="Archivos"
                                         CausesValidation="True" style="height: 24px" Text="Guardar"></dxe:ASPxButton>
                                </td>
                                <td>&nbsp;&nbsp;</td>
                                <td>
                                     <dxe:ASPxButton ID="aspxCancelar" runat="server" Text="Cancelar" style="height: 24px" CausesValidation="False">
                                     </dxe:ASPxButton>
                                </td>
                            </tr>
                         </table>                                                                                                  
                    </td>
                </tr>
                <tr>
                    <td>
                        <dxe:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" 
                            ValidationGroup="Archivos" HeaderText="Lista de errores" 
                            RenderMode="Table" ShowErrorAsLink="False" ShowErrorsInEditors="True" 
                            Width="100%">
                            <BackgroundImage ImageUrl="~/Images/bgError.png" />
                            <Border BorderColor="Red" BorderStyle="Solid" BorderWidth="1px" />
                        </dxe:ASPxValidationSummary>
                    </td>
                </tr>
            </table>                                        
        <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
            <dxe:ASPxDateEdit ID="__ReferenceDateEdit" runat="server" ClientVisible="False">
            </dxe:ASPxDateEdit>
    <asp:ObjectDataSource ID="daArbolPadre" runat="server" 
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
            <asp:Parameter Name="idUnidadInstalacion" Type="Int32" DefaultValue="" />
            <asp:Parameter Name="Descripcion" Type="String" DefaultValue="" />
            <asp:Parameter Name="idTipoElemento" Type="Int32" DefaultValue=""/>
            <asp:Parameter Name="idDocumentoPID" Type="Int32" DefaultValue=""/>            
        </InsertParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
