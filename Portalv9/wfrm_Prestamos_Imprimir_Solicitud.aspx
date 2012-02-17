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
    <style type="text/css">
table.solicitud {
	border-width: 1px;
	border-spacing: 0px;
	border-style: none;
	border-color: gray;
	border-collapse: collapse;
	background-color: white;
}
table.solicitud th {
	border-width: 1px;
	padding: 1px;
	border-style: inset;
	border-color: gray;
	background-color: white;
	-moz-border-radius: ;
}
table.solicitud td {
	border-width: 1px;
	padding: 1px;
	border-style: inset;
	border-color: gray;
	background-color: white;
	-moz-border-radius: ;
}
</style>
</head>


<body>
    <center>
        <div style="text-align:justify">
            <table width="800px">
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td style="width: 50%">
                                    <img alt="logo" src="Images/logo_nvo_balanza.jpg" height="120px" /></td>
                                <td>
                                    <p>
                                        COORDINACIÓN DE INFORMACIÓN, DOCUMENTACIÓN Y TRANSFERENCIA<br />
                                        DIRECCION DE ARCHIVOS.
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #006742; color:White" align="center">
                        VALE DE PRÉSTAMO
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        FOLIO: <%=String.Format("{000000}", folio)%>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #006742; color:White" align="center">
                        DATOS DEL SOLICITANTE
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" class="solicitud">
                            <tr>
                                <td>
                                    NOMBRE: <%=usuarioSolicitante%>
                                </td>
                                <td>
                                    FECHA DE PRÉSTAMO: <%=fechaConsulta%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    CARGO:
                                </td>
                                <td>
                                    FECHA COMPROMISO DEVOLUCIÓN: <%=fechaConsulta.AddDays(dias)%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    FECHA DEL PRIMER REFRENDO:
                                </td>
                                <td>
                                    FECHA DEL SEGUNDO REFRENDO:
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #006742; color:White" align="center">
                        INFORMACIÓN SOLICITADA
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" class="solicitud" style="text-align:center">
                            <tr style="vertical-align:top" >
                                <th>
                                    CÓD. REFERENCIA 
                                </th>
                                <th>
                                    TÍTULO
                                </th>
                                <th>
                                    FECHAS EXTREMAS
                                </th>
                                <th>
                                    FOJAS
                                </th>
                                <th>
                                    SIG. TOPOGRÁFICA
                                </th>
                            </tr>
                            <tr style="height:120px;">
                                <td><%= codigoClasificacion %></td>
                                <td><%= descripcion %></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #006742; color:White" align="center">
                        OBSERVACIONES
                    </td>
                </tr>
                <tr style="height:80px">
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" class="solicitud">
                            <tr>
                                <th style="background-color: #006742; color:White; width: 50%">
                                    RECIBE UNIDAD
                                </th>
                                <th style="background-color: #006742; color:White; width: 50%">
                                    APRUEBA Y ENTREGA DIRECCIÓN DE ARCHIVOS
                                </th>
                            </tr>
                            <tr>
                                <td style="height: 120px">
                                </td>
                                <td style="height: 120px">
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    NOMBRE Y FIRMA
                                </td>
                                <td align="center">
                                    NOMBRE Y FIRMA
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </center>

    <%--<div style="margin-left: auto; margin-right: auto; text-align: center">
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
    </div>--%>
</body>
</html>
