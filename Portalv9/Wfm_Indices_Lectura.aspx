﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfm_Indices_Lectura.aspx.vb" Inherits="Portalv9.Wfm_Indices_Lectura" %>
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
        window.RefrescaDatos = function(args) {
            pnlDatos.PerformCallback();
        }     
        function resizeFrame() {
            try {
                parent.document.getElementById('ctl00_ctl00_ContentPlaceHolder2_ContentPlaceHolder1_ASPxCallbackPanel1_iframeIndices').style.height = (document.getElementById('iframedBody').scrollHeight + 20) + 'px';
                parent.document.getElementById('ctl00_ctl00_ContentPlaceHolder2_ContentPlaceHolder1_ASPxCallbackPanel1_iframeIndices').style.height = (document.getElementById('iframedBody').scrollHeight + 30) + 'px';
                parent.document.getElementById('tableMainIFrame').style.height = (document.getElementById('iframedBody').scrollHeight + 40) + 'px';
                //alert(parent.document.getElementById('ctl00_ctl00_ContentPlaceHolder2_ContentPlaceHolder1_ASPxCallbackPanel1_iframeIndices').style.height);
            }
            catch (e) { }
        }
    </script>
</head>
<body id="iframedBody" onload="resizeFrame()" style="background-color:White; background-image:none;">
    <form id="form1" runat="server">
            <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" Text="" ForeColor="Red"></dxe:ASPxLabel>
            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%; max-width:650px;" runat="server" id="tableIndices">
                <tr>
                    <td >
                                <dxp:ASPxPanel ID="PnlElementos" runat="server" Width="600px" 
                                    CssClass="ControlAlignLeft" >
                                    <Border BorderColor="#C9D7DD" BorderStyle="Solid" BorderWidth="1px" />
                                    <PanelCollection>
                                        <dxp:PanelContent ID="PanelContent1" runat="server">
                                        </dxp:PanelContent>
                                    </PanelCollection>
                                </dxp:ASPxPanel>
                    </td>
                </tr>
                <tr>
                    <td>
                         <dxe:ASPxButton ID="aspxEditar" runat="server" style="height: 24px" 
                             Text="Editar" ClientInstanceName="aspxEditar" ClientVisible="False" >
                             <ClientSideEvents CheckedChanged="function(s, e) {
	resizeFrame();
}" />
                         </dxe:ASPxButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>                                        
        <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
            <dxe:ASPxDateEdit ID="__ReferenceDateEdit" runat="server" ClientVisible="False">
            </dxe:ASPxDateEdit>
    </form>
</body>
</html>
