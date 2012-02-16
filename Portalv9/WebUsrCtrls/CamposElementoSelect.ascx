<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CamposElementoSelect.ascx.vb" Inherits="Portalv9.CamposElementoSelect" %>
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
       <td class="style4" align="right" width="25">
       &nbsp; º</td>
      <td class="style4">
           <ASP:CheckBox ID="chkVisible" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Visible") %>'/>
           
       </td>
       <td>
           <asp:Label ID="Label3" runat="server" 
               Text='<%# DataBinder.Eval(Container, "DataItem.folio_norma") %>'></asp:Label>
           <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Indice_descripcion") %>'></asp:Label>
        </td>
 </tr>
 </table>
                                                