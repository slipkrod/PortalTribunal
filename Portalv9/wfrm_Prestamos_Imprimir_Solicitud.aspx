<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="wfrm_Prestamos_Imprimir_Solicitud.aspx.vb"
    Inherits="Portalv9.wfrmPrestamosImprimirSolicitud" %>

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
<html>
<head runat="server">
    <title>Solicitud de prestamo</title>
</head>
<body>
    <div style="margin-left: auto; margin-right: auto; text-align: center">
        <table style="width: 780px;">
            <tr>
                <td align="center">
                    <strong>Formato para solicitud de prestamo de expediente</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 96%; border: thin solid #C9D7DD">
                        <tr>
                            <td>
                                Folio:
                            </td>
                            <td>
                                <%=String.Format("{000000}", folio)%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha de solicitud:
                            </td>
                            <td>
                                <%=fechaConsulta%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Archivo:
                            </td>
                            <td>
                                <%=nombreArchivo%>
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
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Usuario solicitante:
                            </td>
                            <td>
                                <strong>
                                    <%=usuarioSolicitante%></strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
        </table>
        <br />
    </div>
</body>
</html>
