<%@ Page Language="vb"  MasterPageFile="~/Masterpages/1.master" AutoEventWireup="false" CodeBehind="Wfrm_Contenido.aspx.vb" Inherits="Portalv9.Wfrm_Contenido" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitulo" runat="server" Text="Bienvenido" > </asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <center>
   <font color="#666666" size="2" face="Arial, Helvetica, sans-serif"><strong><font size="5">
        <br />
        <br />
        
      
        Bienvenido<br />
        </font><br />
          <asp:Label ID="lblNombre" runat="server" Text="Label" ForeColor="#333333"></asp:Label>
          <br />
          <br />
			 <br />

    Seleccione el tipo de consulta que desea hacer en<br />

    la parte superior de esta ventana</strong></font>
    <p align="center">
            <font color="#c00000" face="Tahoma" size="2">
                <asp:Label ID="lblAviso" runat="server"></asp:Label>
            </font>
        </p>





    <font color="#666666" size="2" face="Arial, Helvetica, sans-serif">
        <br />
        Su último acceso fué el día <asp:Label ID="lblUltimoAcceso" runat="server"></asp:Label></font>

   </center>
  <cc1:msgbox id="dlgBoxExcepciones2" runat="server"></cc1:msgbox>

</asp:Content>




