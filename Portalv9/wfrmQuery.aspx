<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Adminmaster2col.master" CodeBehind="wfrmQuery.aspx.vb" Inherits="Portalv9.wfrmQuery" %>
<%@ Register TagPrefix="dxrp" Namespace="DevExpress.Web.ASPxRoundPanel" Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register src="WebUsrCtrls/CampoSI_NO.ascx" tagname="CampoSI_NO" tagprefix="uc1" %>
<%@ Register src="WebUsrCtrls/CampoPeriodoAno.ascx" tagname="CampoPeriodoAno" tagprefix="uc2" %>
<%@ Register src="WebUsrCtrls/CampoPeriodoFechas.ascx" tagname="CampoPeriodoFechas" tagprefix="uc3" %>
<%@ Register src="WebUsrCtrls/CampoPeriodoMesAno.ascx" tagname="CampoPeriodoMesAno" tagprefix="uc4" %>
<%@ Register src="WebUsrCtrls/CampoFecha.ascx" tagname="CampoFecha" tagprefix="uc5" %>
<%@ Register src="WebUsrCtrls/CampoCatalogo.ascx" tagname="CampoCatalogo" tagprefix="uc6" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server"> 
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Reporteador"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" NavigateUrl="~/Wfrm_Filtros.aspx" />
    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Texto en el page_ load</asp:label>
    <br /><br />
</div>
        <table bgcolor="white" align="center" style="width: 100%; border: 1px solid #A3C0E8">
            <tr id="trFiltrosBotones" runat="server" bgcolor="#d2e9ff" style="width: 100%; border: 1px solid #A3C0E8">
                <td style="height: 21px; text-align: left;" colspan="3">
                    <table style="width: 100%">
                        <tr>
                            <td style=" width:80px;">
                                <dxe:ASPxButton ID="butEjecutar" runat="server" Text="Ejecutar" Width="80px" Height="32PX" >
                                </dxe:ASPxButton>
                            </td>
                            <td style=" width:80px;">
                                <dxe:ASPxButton ID="btnEditar" runat="server" Text="Editar" Width="80px" Height="32PX" AutoPostBack="true" >
                                </dxe:ASPxButton>                    
                            </td>
                            <td style="width:80px;">
                                <dxe:ASPxButton ID="butGuardarFiltro" runat="server" ClientInstanceName="butGuardarFiltro" 
                                ToolTip="Grabar" Text="Grabar" Enabled="false" Width="80px" Height="32PX" >
                                </dxe:ASPxButton>
                            </td>
                            <td style=" width:80px;">
                                <dxe:ASPxButton ID="butCancelar" runat="server" Text="Cancelar" Width="80px" 
                                    Height="32PX" AutoPostBack="true" Enabled="false">
                                </dxe:ASPxButton>                    
                            </td>
                            <td style=" width:15px;">
                            </td> 
                            <td style=" width:15px; border-left: 1px solid #A3C0E8;">
                            </td> 
                            <td style=" width:40px;">
                                <dxe:ASPxButton ID="btnAgregar" runat="server" 
                                    ClientInstanceName="btnAgregar" 
                                    ToolTip="Agrega la condicion de Busqueda" Height="40px" Width="40px" Visible="False">
                                    <Image Url="~/Images/agregar.gif" />
                                </dxe:ASPxButton>
                            </td>
                            <td style="width:40px;">
                                <dxe:ASPxButton ID="butGuardaFiltrosEditados" runat="server" Visible="false" Width="40px" Height="40px" >
                                    <Image Url="~/Images/aceptar3.jpg"  />
                                </dxe:ASPxButton>
                            </td>
                            <td style=" width:40px;">
                                <dxe:ASPxButton ID="btnBorrar" runat="server" AutoPostBack="False" 
                                    ClientInstanceName="btnBorrar" 
                                    ToolTip="Agrega la condicion de Busqueda" Visible="False" Height="40px" Width="40px">
                                    <Image Url="~/Images/Borrar.gif" />
                                </dxe:ASPxButton>
                            </td>
                            <td style=" width:40px;">
                                <dxe:ASPxButton ID="BtnPI" runat="server" AutoPostBack="False" 
                                    ClientInstanceName="btnPI" 
                                    ToolTip="Agrega la condicion de Busqueda" Width="40px" Height="40px" Text="(" Visible="False">
                                    <ClientSideEvents Click="function(s, e) {
                                        lbSQLDesc.SetVisible(true);
                                        lbSQLDesc.PerformCallback('(');
                                        }" />
                                </dxe:ASPxButton>
                            </td>
                            <td style=" width:40px;">
                                <dxe:ASPxButton ID="BtnPD" runat="server" AutoPostBack="False" 
                                    ClientInstanceName="btnPD" 
                                    ToolTip="Agrega la condicion de Busqueda" Width="40px" Height="40px" Text=")" Visible="False">
                                </dxe:ASPxButton>
                            </td>
                            <td style=" width:40px;">
                                <dxe:ASPxButton ID="btnY" runat="server" 
                                    ClientInstanceName="btnY" 
                                    ToolTip="Agrega la condicion de Busqueda" Width="40px" Height="40px" Text="Y" Visible="False">
                                </dxe:ASPxButton>
                            </td>
                            <td style=" width:40px;">
                                <dxe:ASPxButton ID="btnO" runat="server" 
                                    ClientInstanceName="btnO" 
                                    ToolTip="Agrega la condicion de Busqueda" Width="40px" Height="40px" Text="O" Visible="False">
                                </dxe:ASPxButton>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;
                                <dxe:ASPxLabel ID="lblerror" runat="server" ClientInstanceName="lblerror" ForeColor="Red" Text="Error de Sintaxis ..." Font-Bold="True" Visible="False">
                                </dxe:ASPxLabel>
                                <dxe:aspxLabel ID="lblLbSQLDesc" runat="server" Text="" Visible="false"></dxe:aspxLabel>
                            </td>                            
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table bgcolor="white" align="center" style="width: 100%; border: 1px solid #A3C0E8">
            <tr id="tableFiltros_Master" bgcolor="white" style="width: 100%; border: 1px solid #A3C0E8">
                <td style="height: 21px; text-align: left;" colspan="4">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <dxe:aspxlabel ID="lblHeadArchivo" runat="server" Text="Archivo -> " ForeColor="#3F5DBC"></dxe:aspxlabel><dxe:aspxLabel ID="lblArchivo" runat="server" Text=""></dxe:aspxLabel>
                            </td>
                            <td><asp:Label ID="lblHeadNivel" runat="server" Text="Nivel -> " ForeColor="#3F5DBC"></asp:Label><dxe:aspxLabel ID="lblNivel" runat="server" Text=""></dxe:aspxLabel>
                            </td>
                            <td>
                                <dxe:aspxLabel ID="lblHeadTipoExpediente" runat="server" Text="Tipo de Expediente -> " ForeColor="#3F5DBC"></dxe:aspxLabel><dxe:aspxLabel ID="lblSerie" runat="server" Text=""></dxe:aspxLabel>
                            </td>
                        </tr>                      
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table id="tableFiltros" bgcolor="white" style="width: 100%; border: 1px solid #A3C0E8; display:none;" runat="server">
            <tr>
                <td style="height: 21px; text-align: left;" colspan="4">
                    <table style="width: 95%">
                        <tr>
                            <td><asp:Label ID="lblIndiceDesc" runat="server" Text="Campos" Width="100%" style="text-align:center;" ForeColor="#3F5DBC"></asp:Label></td>
                            <td><asp:Label ID="lblOperadorDesc" runat="server" Text="Operador" Width="100%" style="text-align:center;" ForeColor="#3F5DBC"></asp:Label></td>
                            <td align="center" ><dxe:ASPxLabel ID="lblvalores" runat="server" Text="Valores" Width="506px" style="text-align:center;" ForeColor="#3F5DBC"></dxe:ASPxLabel></td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;" width="250px">
                                <table><tr><td>
                                <dxe:aspxLabel ID="lblIndice" runat="server" Text="" Visible="false"></dxe:aspxLabel>
                                <dxe:ASPxComboBox ID="lbCampos" runat="server" DataSourceID="dsIndices" 
                                    TextField="Campo" ValueField="idindice" 
                                    ValueType="System.Int32" Width="300px" ClientInstanceName="lbCampos" 
                                    OnCallback="lbCampos_Callback" DropDownStyle="DropDown"
                                    EnableSynchronization="False" AutoPostBack="True">
                                    <Columns>
                                        <dxe:ListBoxColumn FieldName="Campo" Width="100%" />
                                        <dxe:ListBoxColumn FieldName="idindice" Visible="false" />
                                        <dxe:ListBoxColumn FieldName="indice_tipo" Visible="false" />
                                        <dxe:ListBoxColumn FieldName="relacion_con_normaPID" Visible="false" />
                                    </Columns>
                                </dxe:ASPxComboBox>
                                </td> </tr> </table> 
                            </td>
                            <td style="vertical-align:top;" width="150px">  
                                <table><tr><td>
                                <dxe:ASPxComboBox ID="LbOperador" runat="server" 
                                    DataSourceID="daOperadores" TextField="OpName" ValueField="Folio" DropDownStyle="DropDown"
                                    ValueType="System.Int32" Width="150px" ClientInstanceName="cmboperadores" 
                                    EnableSynchronization="False" AutoPostBack="True">
                                    <Columns>
                                        <dxe:ListBoxColumn FieldName="OpType" Visible="False" />
                                        <dxe:ListBoxColumn FieldName="Folio" Visible="False" />
                                        <dxe:ListBoxColumn FieldName="OpName" Caption="Operador" />
                                        <dxe:ListBoxColumn FieldName="OpSQL" Visible="False" />
                                        <dxe:ListBoxColumn FieldName="OpCRW" Visible="False" />
                                        <dxe:ListBoxColumn FieldName="OpSQLNull" Visible="False" />
                                    </Columns>
                                </dxe:ASPxComboBox>
                                <dxe:aspxLabel ID="lblOperador" runat="server" Text="" Visible="false"></dxe:aspxLabel>
                                <dxe:aspxLabel ID="lblFiltroEdited" runat="server" Text="" Visible="false"></dxe:aspxLabel>
                                </td> </tr> </table> 
                            </td>
                            <td style="vertical-align: top;" width="506px">
                                <table>
                                    <tr>    
                                        <td style="vertical-align: top;">
                                            <dxe:ASPxTextBox ID="val1" runat="server" ClientInstanceName="val1" Width="170px" Visible="False"> </dxe:ASPxTextBox>
                                            <uc1:CampoSI_NO ID="CampoSI_NO1" runat="server" Visible="false" Muestra_Campo="False" Muestra_Padres="false" />
                                            <uc5:CampoFecha ID="CampoFecha1" runat="server" Visible="false" Muestra_Campo="False" Muestra_Padres="false"/>
                                            <uc2:CampoPeriodoAno ID="CampoPeriodoAno1" runat="server" Visible="false" Muestra_Campo="False" Muestra_Padres="false"/>
                                            <uc3:CampoPeriodoFechas ID="CampoPeriodoFechas1" runat="server" Visible="false" Muestra_Campo="False" Muestra_Padres="false" />                                            
                                            <uc4:CampoPeriodoMesAno ID="CampoPeriodoMesAno1" runat="server" Visible="false" Muestra_Campo="False" Muestra_Padres="false" />
                                            <uc6:CampoCatalogo ID="CampoCatalogo1" runat="server" Visible="False" Muestra_Campo="False" Muestra_Padres="false" />
                                        </td>
                                        <td valign="top"><asp:ImageButton ID="b_A" runat="server" ImageUrl="~/Images/agregar.gif" Visible="False" /></td>
                                        <td rowspan="2">
                                            <dxe:ASPxListBox ID="nvalores2" runat="server" Visible="False" Width="300px" 
                                                Height="80px">
                                            </dxe:ASPxListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><dxe:ASPxLabel ID="Y" runat="server" ClientInstanceName="Y" Text="Y" ForeColor="#3F5DBC" ClientVisible="False"> </dxe:ASPxLabel></td>
                                        <td rowspan="1" valign="top"><asp:ImageButton ID="B_E" runat="server" ImageUrl="~/Images/Borrar.gif" Visible="False" /></td>
                                    </tr>
                                    <tr>
                                        <td><dxe:ASPxTextBox ID="val2" runat="server" ClientInstanceName="val2" Width="170px" Visible="False"></dxe:ASPxTextBox></td>                                        
                                    </tr>
                                </table>                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 21px; text-align:right;" colspan="4">
                    <table><tr><td>
                    <dxe:ASPxButton ID="butFiltroGrabar" runat="server" Text="Grabar"></dxe:ASPxButton>
                    </td><td>
                    <dxe:ASPxButton ID="butFiltroCancelar" runat="server" Text="Cancelar"></dxe:ASPxButton>
                    </td></tr></table>
                </td>
            </tr>
        </table>        
        <br />
        <table id="tableContultas" bgcolor="white" style="width: 100%; border: 1px solid #A3C0E8" runat="server">
            <tr>
                <td style="" colspan="3">
                    <center>
                        <dxe:ASPxListBox runat="server" EnableCallbackMode="True" ClientInstanceName="lbSQLDesc" Width="100%" ID="lbSQLDesc" Height="80px"></dxe:ASPxListBox>
                    </center> 
                </td>
            </tr>  
        </table>          
        <br />        
        <table id="tableResultados" bgcolor="white" style="width: 100%; border: 1px solid #A3C0E8">
            <tr>
                <td style="height: 21px; " colspan="4" align="left">
                    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
                        DataSourceID="ObjConsulta" AutoGenerateColumns="False" Visible="False" 
                        Width="100%">
                        <SettingsBehavior AutoExpandAllGroups="True" />
                        <Columns>
                            <dxwgv:GridViewCommandColumn VisibleIndex="0">
                                <ClearFilterButton Visible="True">
                                </ClearFilterButton>
                            </dxwgv:GridViewCommandColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Archivo" FieldName="Archivo_Descripcion">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Nivel" FieldName="Nivel_Descripcion">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Expediente" FieldName="Tipo_Expediente" >
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Nombre Nivel" FieldName="Descripcion" >
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Area" FieldName="Area_Descripcion">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Elemento" FieldName="Elemento_Descripcion">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Indice" FieldName="Indice_Descripcion">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Valor" FieldName="Valor" ToolTip="Valor Encontrado">
                            </dxwgv:GridViewDataTextColumn>
                        </Columns>
                        <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    </dxwgv:ASPxGridView>
                </td>
            </tr>
        </table>
        <table style="width:100%; "><tr><td>
        <dxe:ASPxListBox runat="server" EnableCallbackMode="True" ClientInstanceName="LBSQL" ID="LBSQL"></dxe:ASPxListBox></td>
        <td><dxe:ASPxListBox runat="server" EnableCallbackMode="True" ClientInstanceName="lstFiltros" ID="lstFiltros"></dxe:ASPxListBox>
        </td></tr></table>
    <asp:ObjectDataSource ID="dsIndices" runat="server" 
        SelectMethod="ListaFiltros_Indices" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:SessionParameter Name="idNorma" SessionField="dsIdNorma" Type="Int32" DefaultValue="-1"/>
            <asp:SessionParameter Name="idNivel" SessionField="dsIdNivel" Type="Int32" DefaultValue="-1"/>
            <asp:SessionParameter Name="idSerie" SessionField="dsIdSerie" Type="Int32" DefaultValue="-1"/>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjConsulta" runat="server" 
        SelectMethod="BuscaExpediente" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:Parameter Name="SQLString" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>                   
    <asp:ObjectDataSource ID="daOperadores" runat="server" 
        SelectMethod="ListaOperadores" TypeName="Portalv9.WSArchivo.Service1">
        <SelectParameters>
            <asp:Parameter Name="OpType" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
</asp:Content>
