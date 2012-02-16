<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmasteranidada.master" CodeBehind="wfrm_ArchivoIns.aspx.vb" Inherits="Portalv9.wfrm_ArchivoIns" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table  class="style4"> <tr>
            
            
            <td>
                <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" 
                                            Height="16px" Font-Names="Arial"
													Font-Bold="True" Font-Italic="True"> Texto en el 
                                                page_ load</asp:label>
            </td>
        </tr>
          <tr>
           
          
            <td>
                <table class="style5">
                    <tr>
                        <td class="style9" style="width: 104px">
                            <dxe:ASPxLabel ID="ASPxnombre" runat="server" Text=" Nombre del archivo"  Width="114px">
                            </dxe:ASPxLabel>
                           </td>
                        <td class="style6">
                            <dxe:ASPxTextBox  ID="txtArchivo" runat="server" Width="300px" Height="21px">
                            <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True">
                                                                <RequiredField IsRequired="True" ErrorText="* El nombre debe ser capturado"></RequiredField>
                            </ValidationSettings>
                            </dxe:ASPxTextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style9" style="width: 104px">
                           <dxe:ASPxLabel ID="ASPxnorma" runat="server" Text="Norma a aplicar" 
                                Width="114px">
                            </dxe:ASPxLabel>
                            </td>
                        <td class="style6">
                            <dxe:ASPxComboBox ID="dlNormas" runat="server"  DropDownStyle="DropDown" SelectedIndex="0"                                                         
                               TextField="Norma_Descripcion" ValueField="idNorma" DataSourceID="ObjectDataSource1">
                            </dxe:ASPxComboBox>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="style9" style="width: 104px">
                            <span class="nombre_campo">
                             <dxe:ASPxLabel ID="ASPxcodigo" runat="server" Text=" Código de clasificación"  Width="130px">
                            </dxe:ASPxLabel>
                           </span></td>
                        <td class="style6">
                            <dxe:ASPxTextBox ID="txtCodigo" runat="server" Width="293px">
                            </dxe:ASPxTextBox>
                            
                        </td>
                    </tr>
        
                    <tr>
                        <td class="style9" style="width: 104px">
                            Tipo de Archivo</td>
                        <td class="style6">
                            <dxe:ASPxComboBox ID="dlTipoArchivo" runat="server"  DropDownStyle="DropDown" SelectedIndex="0"                                                         
                               TextField="Norma_Descripcion" ValueField="idNorma" 
                                DataSourceID="ObjectDataSource1" ValueType="System.String">
                                <Items>
                                    <dxe:ListEditItem Text="Trámite" Value="0" />
                                    <dxe:ListEditItem Text="Concentración" Value="1" />
                                    <dxe:ListEditItem Text="Histórico" Value="2" />
                                </Items>
                            </dxe:ASPxComboBox>
                           
                        </td>
                    </tr>
        
        </table>
    <table>
            
                    <tr>
                        <td bgcolor="White" class="style7" colspan="2" 
                            style="border: 1px solid #000000; width: 564px;" valign="top" >
                            En esta seccion deben ir campos de información del archivo [se pretende poner 
                            una estructura como las normas]<br />
                            <div class="cuerpo_pestanha">
                                <h2 align="center" 
                                    style="font-size: 14px; font-weight: bold; background-color: #F2F2F2;">
                                    Archivo</h2>
                                <div class="pestanha_no_js">
                                    <p>
                                        <span class="nombre_campo">País :</span> <span class="detalle_campo">España</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Comuni autónoma :</span> <span class="detalle_campo">
                                        Ceuta</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Domicilio :</span> <span class="detalle_campo">Plaza 
                                        de Africa, 1</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Municipio :</span> <span class="detalle_campo">Ceuta</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Localidad :</span> <span class="detalle_campo">-Ceuta</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Teléfonos :</span> <span class="detalle_campo">956 
                                        528184</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Fax :</span> <span class="detalle_campo">956 528206</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Correo electrónico :</span>
                                        <span class="detalle_campo"><a href="mailto:archivo@ceuta.es" target="_top">
                                        archivo@ceuta.es</a></span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Dirección WWW :</span> <span class="detalle_campo">
                                        <a href="http://www2.ceuta.es/ALBALA/OPW" target="_top">www2.ceuta.es/ALBALA/OPW</a></span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Horarios de apertura :</span>
                                        <span class="detalle_campo">Laborables de 8:30 a 14 horas, y de 16:30 a 18:30 h, 
                                        excepto los viernes</span>
                                                            </p>
                                                        </div>
                                                        <!-- Fin Primera --><!-- informacion -->
                                                        <h2 align="center" 
                                                            style="font-size: 14px; font-weight: bold; background-color: #F2F2F2;">
                                                            Información
                                </h2>
                                                        <div class="pestanha_no_js">
                                                            <p>
                                                                <span class="nombre_campo">Historia del archivo :</span>
                                        <span class="detalle_campo">El Archivo General de Ceuta se crea a partir del 
                                        Reglamento de Organización y Funcionamiento del Sistema Archivístico de Ceuta. 
                                        Tiene como función la custodia, conservación y divulgación del Patrimonio 
                                        documental ceutí que ha alcanzado valor terciario.</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Historia del edificio :</span>
                                        <span class="detalle_campo">El Archivo se encuentra instalado en la ampliación 
                                        del Palacio autonómico, construido en 1992, con proyecto de los arquitectos 
                                        Antonio Cruz y Antonio Ortiz. El área de trabajo y de atención al público se 
                                        sitúa en la planta baja, y los depósitos en la zona sótano del mismo, 
                                        acondicionado para ello con equipo de climatización y estanterías compactas. En 
                                        espera a su nueva ubicación comparte el espacio con el Archivo Central de Ceuta</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Fecha :</span> <span class="detalle_campo">2004</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Red de archivos :</span> <span class="detalle_campo">
                                        Sin especificar</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Titularidad :</span> <span class="detalle_campo">
                                        Pública</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Clasificación de Titularidad 2 :</span>
                                        <span class="detalle_campo">Administración autonómica</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Clasificación de Titularidad 3 :</span>
                                        <span class="detalle_campo">Consejería o departamento de cultura</span>
                                                            </p>
                                                        </div>
                                                        <!-- Fin informacion --><!-- Servicios tecnicos -->
                                                        <h2 align="center" 
                                                            style="font-size: 14px; font-weight: bold; background-color: #F2F2F2;">
                                                            Servicios técnicos</h2>
                                                        <div class="pestanha_no_js">
                                                            <p>
                                                                <span class="nombre_campo">Taller de restauración </span>
                                        <span class="detalle_campo">No</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Servicio de reproducción documental </span>
                                        <span class="detalle_campo">Sí</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Laboratorio microfilmación</span>
                                        <span class="detalle_campo">No</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Laboratorio fotográfico </span>
                                        <span class="detalle_campo">No</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Otro equipamiento técnico </span>
                                        <span class="detalle_campo">No</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Servicio de biblioteca auxiliar</span>
                                        <span class="detalle_campo">Sí</span>
                                                            </p>
                                                        </div>
                                                        <!-- Fin Servicios tecnicos --><!-- Servicios al publico -->
                                                        <h2 align="center" 
                                                            style="font-size: 14px; font-weight: bold; background-color: #F2F2F2;">
                                                            Servicios al público</h2>
                                                        <div class="pestanha_no_js">
                                                            <p>
                                                                <span class="nombre_campo">Condiciones de consulta :</span>
                                        <span class="detalle_campo">Cosulta en sala</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Reprografía :</span> <span class="detalle_campo">Sí</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Restauración :</span> <span class="detalle_campo">No</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Servicio de biblioteca auxiliar</span>
                                        <span class="detalle_campo">Sí</span>
                                                            </p>
                                                        </div>
                                                        <!-- Fin Servicios al publico --><!-- informatizacion -->
                                                        <h2 align="center" dir="ltr" 
                                                            style="font-size: 14px; font-weight: bold; background-color: #F2F2F2;">
                                                            Informatización</h2>
                                                        <div class="pestanha_no_js">
                                                            <p>
                                                                <span class="nombre_campo">Gestión de usuarios </span>
                                        <span class="detalle_campo">Sí</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Descripción de fondos</span>
                                        <span class="detalle_campo">Sí</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Gestión documental</span> <span class="detalle_campo">
                                        Sí</span>
                                    </p>
                                    <p>
                                        <span class="nombre_campo">Otros :</span> <span class="detalle_campo">No</span>
                                    </p>
                                </div>
                                <!-- Fin informatizacion --><!-- Pestanha de Notas --><!-- Fin de Pestanha -->
                                <div class="break">
                                </div>
                            </div>
                            <!-- div fin archivo -->
                            <div class="pie_pestanha">
                                &nbsp;</div>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" colspan="2" style="width: 564px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 564px">
                            <dxe:ASPxButton ID="Button1" runat="server" Text="Salvar">
                            </dxe:ASPxButton>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                SelectMethod="ListaNormas" TypeName="Portalv9.WSArchivo.Service1">
                                                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="3" style="width: 594px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder5" Runat="Server">
    
</asp:Content>

