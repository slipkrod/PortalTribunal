<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="wfrm_Buscador.aspx.vb" Inherits="Portalv9.wfrmBuscador" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitulo" runat="server" Text="Archivos"></asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <table style="border: 3px solid #C9D7DD; width: 80%; z-index: 99;">
        <tr>
            <td style="border: thin solid #C9D7DD" colspan="2">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <label for="LIBRE">
                            Indique la cadena de búsqueda en cualquier campo:</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dxe:ASPxTextBox ID="txtPalabra" runat="server" Width="300px">
                            </dxe:ASPxTextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="border: thin solid #C9D7DD">
                Achivo:</td>
            <td style="border: thin solid #C9D7DD">
 <dxe:ASPxComboBox ID="cmbArchivo" runat="server" 
                    DataSourceID="ObjectDataSource1" ValueType="System.Int32" 
                    TextField="Archivo_Descripcion" ValueField="idArchivo" Width="250px" 
                    AutoPostBack="True">
                </dxe:ASPxComboBox>
                        </td>
        </tr>
        <tr>
            <td style="border: thin solid #C9D7DD" colspan="2">
                <table style="width: 100%">
                    <tr>
                        <td colspan="2" style="text-align: center">
                            Si lo desea puede acotar la busqueda seleccionando:</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <dxe:ASPxCheckBox ID="NivelLogico" runat="server" Text="Niveles lógicos" 
                                AutoPostBack="True">
                            </dxe:ASPxCheckBox>
                        </td>
                        <td>
                            <dxe:ASPxCheckBox ID="NivelFisico" runat="server" Text="Niveles físicos" 
                                AutoPostBack="True">
                            </dxe:ASPxCheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <dxwgv:ASPxGridView ID="datagridLogicos" runat="server" 
                                AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" 
                                KeyFieldName="idNivel" Width="206px" Enabled="False">
                                <SettingsPager Visible="False"></SettingsPager>                                
                                <SettingsText EmptyDataRow="No hay niveles a mostrar" />
                                <Columns>
                                    <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                                    </dxwgv:GridViewCommandColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" 
                                        Visible="False" VisibleIndex="1">
                                    </dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="Nivel" FieldName="Nivel_Descripcion" 
                                        VisibleIndex="1">
                                    </dxwgv:GridViewDataTextColumn>
                                </Columns>
                                <Settings GridLines="None" ShowColumnHeaders="False" />
                            </dxwgv:ASPxGridView>
                        </td>
                        <td style="vertical-align: top">
                            <dxwgv:ASPxGridView ID="datagridFisicos" runat="server" 
                                AutoGenerateColumns="False" DataSourceID="ObjectDataSource3" 
                                KeyFieldName="idNivel" Width="206px" Enabled="False">
                                <SettingsPager Visible="False"></SettingsPager>
                                <SettingsText EmptyDataRow="No hay niveles a mostrar" />
                                <Columns>
                                    <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                                    </dxwgv:GridViewCommandColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="idNivel" FieldName="idNivel" Visible="False" VisibleIndex="1">
                                    </dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="Nivel" FieldName="Nivel_Descripcion" VisibleIndex="1">
                                    </dxwgv:GridViewDataTextColumn>
                                </Columns>
                                <Settings GridLines="None" ShowColumnHeaders="False" />
                            </dxwgv:ASPxGridView>
                        </td>
                    </tr>                    
                    <tr>
                        <td style="vertical-align: top">
                            <dxe:ASPxButton ID="btnBuscar" runat="server" Text="Buscar">
                                <Image Url="~/Images/Buscar.gif" />
                            </dxe:ASPxButton>
                        </td>
                        <td style="vertical-align: top">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br/>    
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="ListaArchivos" TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="ListaArchivo_Niveles_Norma" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbArchivo" Name="idArchivo" 
                PropertyName="Value" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="Nivel_Logico_Fisico" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
        SelectMethod="ListaArchivo_Niveles_Norma" 
        TypeName="Portalv9.WSArchivo.Service1" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbArchivo" Name="idArchivo" 
                PropertyName="Value" Type="Int32" />
            <asp:Parameter Name="Nivel_Logico_Fisico" Type="Int32" DefaultValue="1" />
        </SelectParameters>
    </asp:ObjectDataSource>
        <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
     </asp:Content>
