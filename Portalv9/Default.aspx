<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Portalv9._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head1" runat="server">
        <title>Intranet de Consultas</title>
	    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
	    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
	    <meta content="JavaScript" name="vs_defaultClientScript" />
	    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
	    <script type="text/javascript" language="javascript" src="Scripts/md5.js"></script>
	    <script type="text/javascript" language="javascript" id="clientEventHandlersJS">
	        function Form1_onsubmit() {
	            if (document.getElementById('txtlogin').value == '') {
	                alert("El usuario es un campo requerido");
	                return false;
	            }
	            if (document.getElementById('txtPwd').value == '') {
	                alert("La contraseña del usuario es un campo requerido");
	                return false;
	            }
	            document.getElementById('txtPwdMD5').value = hex_md5(document.getElementById('txtPwd').value);
	            document.getElementById('txtPwd').value = '';
	            return true;
	        }
	    </script>
<style type="text/css">
.Estilo1 {	color: #1E345B
         }td img {display: block;}td img {display: block;}
.body
{ font-family:Verdana,Arial,Helvetica,sans-serif;
  font-size:10px;
  color:#666666;
 
  
    }
</style>        
</head>
<form id="Form1" runat="server" language="javascript" onfocus="txtPwd" 
    onsubmit="return Form1_onsubmit()" method="post" visible="True">
 <INPUT language="javascript" id="txtPwdMD5" style="WIDTH: 200px; HEIGHT: 22px" type="hidden"	size="28" name="txtPwdMD5">
<body>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">  
  <tr>
    <td>
        <div align="center">
          <table width="750" border="1" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td align="center" valign="middle"><table border="0" cellpadding="0" cellspacing="0" width="725">
              <!-- fwtable fwsrc="fondo.png" fwpage="Página 1" fwbase="fondo.jpg" fwstyle="Dreamweaver" fwdocid = "1550847967" fwnested="0" -->
              <tr>
                <td><img src="images/spacer.gif" width="233" height="1" border="0" alt="" /></td>
                <td><img src="images/spacer.gif" width="122" height="1" border="0" alt="" /></td>
                <td><img src="images/spacer.gif" width="370" height="1" border="0" alt="" /></td>
                <td><img src="images/spacer.gif" width="1" height="1" border="0" alt="" /></td>
              </tr>
              <tr>
                <td colspan="3"><img name="fondo_r1_c1" src="images/fondo_r1_c1.jpg" width="725" height="344" border="0" id="Img1" alt="" /></td>
                <td><img src="images/spacer.gif" width="1" height="344" border="0" alt="" /></td>
              </tr>
              <tr>
                <td rowspan="3"><img name="fondo_r2_c1" src="images/fondo_r2_c1.jpg" width="233" height="105" border="0" id="Img2" alt="" /></td>
                <td background="images/fondo_r2_c2.jpg"><span class="Estilo1">
                  <asp:TextBox ID="txtlogin" runat="server" Width="105px" Height="16px" Text="superadmin"></asp:TextBox>
                </span></td>
                <td rowspan="3"><asp:ImageButton ID="ibtn_entrar" runat="server" ImageUrl="images/fondo_r2_c3.jpg" width="370" height="105" border="0" /></td>
                <td><img src="images/spacer.gif" width="1" height="32" border="0" alt="" /></td>
              </tr>
              <tr>
                <td background="images/fondo_r3_c2.jpg"><span class="Estilo1">
                  
                  <input type="password" size="14" name="txtPwd" id="txtPwd" value="tester" >
                </span></td>
                <td><img src="images/spacer.gif" width="1" height="32" border="0" alt="" /></td>
              </tr>
              <tr>
                <td><img name="fondo_r4_c2" src="images/fondo_r4_c2.jpg" width="122" height="41" border="0" id="fondo_r4_c2" alt="" /></td>
                <td><img src="images/spacer.gif" width="1" height="41" border="0" alt="" /></td>
              </tr>
            </table></td>
          </tr>
        </table>
        
          
        
    </div></td>
  </tr>
  <tr>
    <td align="left" valign="top"><div align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="body">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Revolución 470 2° México D. F. 03800 Tel: +52 (55) 52 777 888 Fax: +52 55 52 773 988 info@digipro.com.mx</span></span></div></td>
  </tr>
  <tr>
    <td align="left">
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Arial" ></asp:Label>
    </td>
  </tr>
</table>
</body>
</form>
</html>