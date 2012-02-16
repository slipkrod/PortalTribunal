<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CamposElemento.ascx.vb" Inherits="Portalv9.CamposElemento" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<style type="text/css">

        .style4
        {
            width: 20px;
        }
        td
{
    font-SIZE: 9px;
    COLOR: #000000;
    font-FAMILY: Verdana, Arial, Helvetica, sans-serif
}

        .style5
        {
            width: 12px;
        }
        .style6
    {
        width: 10px;
    }
        </style>
  <table style="width:100%; empty-cells: show;">
     <tr>
                 <td class="style6" align="right"> </td>
                 <td class="style4">
                                                                <dxe:ASPxButton ID="btnEdit" runat="server" HorizontalAlign="Left" 
                                                                    ImagePosition="Bottom" ImageSpacing="0px" ToolTip="Editar valores del campo"                                                                     
                                                                    Width="16px" Wrap="False" 
                                                                    CommandArgument='<%# DataBinder.Eval(Container, "DataItem.idIndice") %>' 
                                                                    CommandName="Edit" Height="28px">
                                                                    <Image Url="../App_Themes/Aqua/Editors/edtDropDownHottracked.png" />
                                                                </dxe:ASPxButton>
                                                            </td>
                 <td class="style5">
                                                                <dxe:ASPxButton ID="btnDelete" runat="server" HorizontalAlign="Left" 
                                                                    ImagePosition="Bottom" ImageSpacing="0px" ToolTip="Eliminar campo"                                                                     
                                                                    Width="16px" Wrap="False" 
                                                                    CommandArgument='<%# DataBinder.Eval(Container, "DataItem.idIndice") %>' 
                                                                    CommandName="Delete" Height="28px">
                                                                    <Image Url="../App_Themes/Aqua/Editors/fcremovehot.png" />
                                                                </dxe:ASPxButton>
                                                            </td>
                 <td>
                                                                <asp:Label ID="Folio" runat="server" 
                        Text='<%# DataBinder.Eval(Container, "DataItem.folio_norma") %>'></asp:Label>
                                                                <asp:Label ID="Label2" runat="server" 
                        Text='<%# DataBinder.Eval(Container, "DataItem.Indice_descripcion") %>'></asp:Label>
                                                            </td>
    </tr>
</table>
                                                