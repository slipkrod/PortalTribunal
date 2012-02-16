<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master"
    CodeBehind="wfrm_Prestamos_Alta_Solicitud.aspx.vb" Inherits="Portalv9.wfrmPrestamosAltaSolicitud" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="MsgBox" Namespace="MsgBox" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <script type="text/javascript">
        function OnClick(s, e) {
            window.open("Wfrm_Prestamos_Imprimir_Solicitud.aspx?idSolicitud=" + <%= idSolicitud %>, '_black','width=790,height=600');
        }
    </script>
    <div id="pagetitle">
        <asp:Label ID="lbltitulo" runat="server" Text="Archivos"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <strong>Confirmación solicitud de prestamo de expediente</strong>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 96%; border: thin solid #C9D7DD">
                        <tr>
                            <td>
                                Fecha de solicitud:
                            </td>
                            <td>
                                <%=DateTime.Now.ToString("dd/MM/yyyy")%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Archivo:
                            </td>
                            <td>
                                <%=NombreArchivo%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <strong>Expediente</strong>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 5px">
                                Código de clásificación:
                            </td>
                            <td>
                                <%=codigoClasificacion%>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 5px">
                                Descripción:
                            </td>
                            <td>
                                <%=descripcion%>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 5px" valign="top">
                                Días:
                            </td>
                            <td>
                                <dxe:ASPxTextBox ID="TextBoxDias" runat="server" Size="3" MaxLength="3"></dxe:ASPxTextBox>
                                <asp:RequiredFieldValidator ID="TextBoxDiasRequired" runat="server" ControlToValidate="TextBoxDias" ErrorMessage="Debes ingresar el número de días para el prestamo"></asp:RequiredFieldValidator>
                                <br /><asp:CompareValidator ID="TextBoxDiasValidator" runat="server" ControlToValidate="TextBoxDias" Type="Integer"
   Operator="DataTypeCheck" ErrorMessage="Número no válido" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Usuario solicitante:
                            </td>
                            <td>
                                <strong>
                                    <%=tTicket.NombreCompleto%></strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table style="width: 96%;">
                        <tr>
                            <td align="right">
                                <dxe:ASPxButton ID="ConfirmaButton" runat="server" Text="Confirmar" OnClick="Confirmar_Click"/>
                            </td>
                            <td align="left">
                                <dxe:ASPxButton ID="ASPxButton1" runat="server" Text="Cancelar" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <dxe:ASPxLabel ID="MensajeLabel" runat="server" Text="La solicitud de prestamo ha sido registrada" Visible="false" ForeColor="Highlight"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <dxe:ASPxButton ID="ImprimirButton" runat="server" Text="Imprimir Formato de Solicitud" Visible="false">
                                    <ClientSideEvents Click="OnClick" />
                                </dxe:ASPxButton>
                            </td>
                        </tr>
                    </table>
                    
                </td>
            </tr>
        </table>
        <br />
    </div>
    <cc1:MsgBox ID="MsgBox1" runat="server" ForeColor="Red"></cc1:MsgBox>
</asp:Content>
