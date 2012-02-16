<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PlantillaHeaderCampo.ascx.vb" Inherits="Portalv9.PlantillaHeaderCampo" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

        <style type="text/css">
            .style1
            {
                width: 18px;
                height: 31px;
            }
            .style2
            {
                width: 447px;
                height: 31px;
            }
        </style>
        <table style="margin: 0px; padding: 0px; border: 0.5px solid #A3C0E8; width:100%; background-color: #D8E8FE;" 
    cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="style1">
                                                                <dxe:ASPxButton ID="btnEdit" runat="server" HorizontalAlign="Left" 
                                                                    ImagePosition="Bottom" ImageSpacing="0px" ToolTip="Agregar nuevo campo"                                                                     
                                                                    Width="10px" Wrap="False" 
                                                                    CommandName="Select">
                                                                    <Image Url="../App_Themes/Aqua/Editors/fcaddhot.png"/>
                                                                </dxe:ASPxButton>
                                                            </td>
                                                            <td style="font-size: 12px" class="style2">
                                                                <dxe:ASPxLabel ID="Folio" runat="server">
                                                                </dxe:ASPxLabel>
                                                                <dxe:ASPxLabel ID="Titulo" runat="server">
                                                                </dxe:ASPxLabel>
                                                            </td>
                                                        </tr>
                                                    </table>
