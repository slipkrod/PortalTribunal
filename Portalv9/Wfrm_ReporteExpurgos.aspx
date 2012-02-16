<%@ Page Language="vb" AutoEventWireup="false" AspCompat="true" CodeBehind="Wfrm_ReporteExpurgos.aspx.vb" MasterPageFile="~/Masterpages/Adminmaster2col.master" Inherits="Portalv9.Wfrm_ReporteExpurgos" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v10.1.Web, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
        <table>
            <tr>
                <td>Desde:</td>
                <td>
                    <dx:ASPxDateEdit ID="DateEditFechaDesde" runat="server">
                    </dx:ASPxDateEdit>
                </td>
                <td>Hasta:</td>
                <td><dx:ASPxDateEdit ID="DateEditFechaHasta" runat="server">
                    </dx:ASPxDateEdit></td>
                    <td>
                        <dx:ASPxButton ID="ReporteButton" runat="server" Text="Ver Reporte" OnClick="CargaReporteClick">
                        </dx:ASPxButton>
                    </td>
            </tr>
            
        </table>
    </div>
    
    <div>
    <dxxr:ReportToolbar ID="ReportToolcgca" runat='server' ShowDefaultButtons='False' 
            ReportViewer="<%# ReportExpurgos %>" >
        <Items>
            <dxxr:ReportToolbarButton ItemKind='Search' ToolTip="Buscar" />
            <dxxr:ReportToolbarSeparator />
            <dxxr:ReportToolbarButton ItemKind='PrintReport' ToolTip="Imprimir reporte" />
            <dxxr:ReportToolbarButton ItemKind='PrintPage' ToolTip="Imprimir página" />
            <dxxr:ReportToolbarSeparator />
            <dxxr:ReportToolbarButton Enabled='False' ItemKind='FirstPage' ToolTip="Primera página" />
            <dxxr:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' ToolTip="Página anterior" />
            <dxxr:ReportToolbarLabel ItemKind='PageLabel' Text="Página" />
            <dxxr:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'>
            </dxxr:ReportToolbarComboBox>
            <dxxr:ReportToolbarLabel ItemKind='OfLabel' Text="a" />
            <dxxr:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
            <dxxr:ReportToolbarButton ItemKind='NextPage' ToolTip="Página siguiente" />
            <dxxr:ReportToolbarButton ItemKind='LastPage' ToolTip="Última página" />
            <dxxr:ReportToolbarSeparator />
            <dxxr:ReportToolbarButton ItemKind='SaveToDisk' ToolTip="Exportar un reporte y guardarlo" />
            <dxxr:ReportToolbarButton ItemKind='SaveToWindow' ToolTip="Exportar un reporte y mostrarlo en una nueva ventana" />
            <dxxr:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                <Elements>
                    <dxxr:ListElement Value='pdf' />
                    <dxxr:ListElement Value='xls' />
                    <dxxr:ListElement Value='xlsx' />
                    <dxxr:ListElement Value='rtf' />
                    <dxxr:ListElement Value='mht' />
                    <dxxr:ListElement Value='txt' />
                    <dxxr:ListElement Value='csv' />
                    <dxxr:ListElement Value='png' />
                </Elements>
            </dxxr:ReportToolbarComboBox>
        </Items>
        <Styles>
            <LabelStyle>
                <Margins MarginLeft='3px' MarginRight='3px' />
            </LabelStyle>
        </Styles>
    </dxxr:ReportToolbar>

    <dxxr:ReportViewer ID="ReportExpurgos" runat="server" 
            ReportName="Portalv9.RPT_Expurgos" >
    </dxxr:ReportViewer>

</div>
    </asp:Content>
