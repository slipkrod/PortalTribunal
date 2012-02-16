<%@ Page Language="vb" MasterPageFile="~/Masterpages/1.master"AutoEventWireup="false" CodeBehind="Wfrm_Normas.aspx.vb" Inherits="Portalv9.Wfrm_Normas" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitulo" runat="server" Text="Bienvenido" > </asp:Label>
</div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <div>
	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
        <br />
    </div>
    <div><br /></div>
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="ListaNormas" TypeName="Portalv9.WSArchivo.Service1">
        </asp:ObjectDataSource>
        <dxwgv:ASPxGridView ID="aspxgdnormas" runat="server" KeyFieldName="idNorma"  
            OnCustomUnboundColumnData="aspxgdnormas_CustomUnboundColumnData" 
            OnRowUpdating="aspxgdnormas_RowUpdating" 
            OnRowDeleting="aspxgdnormas_RowDeleting" 
            OnRowCommand="aspxgdnormas_RowCommand"  
            OnRowInserting="aspxgdnormas_RowInserting" 
            OnPageIndexChanged="aspxgdnormas_PageIndexChanged" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1">
            <SettingsText Title="Normas" />
            <Settings ShowTitlePanel="True" />
             <SettingsBehavior ConfirmDelete="true" />
              <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar ésta norma ?" />
            <Columns>
                <dxwgv:GridViewDataTextColumn  Caption="ID"  FieldName="idNorma" ReadOnly="True" VisibleIndex="0">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="Nombre" FieldName="Norma_descripcion" ReadOnly="false" VisibleIndex="1">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="IndicesSistemaPendientes" ReadOnly="true" VisibleIndex="2">
                    <EditFormSettings Visible="False" />
                    <HeaderCaptionTemplate><center>Indices de<br />Sistema<br />sin aplicar</center></HeaderCaptionTemplate>
                    <CellStyle ForeColor="Red" HorizontalAlign="Center"></CellStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="3" >
                    <NewButton Visible="true" Text="Agregar Norma" ></NewButton>                            
                </dxwgv:GridViewCommandColumn>
                <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="4">
                    <EditButton Visible="True" Text="Editar"></EditButton>
                    <CancelButton Visible="True" Text="Cancelar"></CancelButton>
                    <UpdateButton Visible="True" Text="Actualizar"></UpdateButton>
                </dxwgv:GridViewCommandColumn>
               <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex="5"> <DeleteButton Text="Eliminar" Visible="true"></DeleteButton></dxwgv:GridViewCommandColumn>
               <dxwgv:GridViewDataColumn Caption="Áreas" VisibleIndex="6">
                  <EditFormSettings Visible="False" />
                  <DataItemTemplate>
                      <dxe:ASPxButton runat="server" ID="btnArea" Text="Áreas"   CommandName="Areas"  CommandArgument='<%# Bind("Norma_descripcion") %>'>
                      </dxe:ASPxButton>
                  </DataItemTemplate> 
               </dxwgv:GridViewDataColumn>
               <dxwgv:GridViewDataColumn Caption="Niveles" VisibleIndex="7">
                 <EditFormSettings Visible="False" />
                  <DataItemTemplate>
                      <dxe:ASPxButton runat="server" ID="btnNivel" Text="Niveles" CommandName="Niveles" CommandArgument='<%# Bind("Norma_descripcion") %>' Enabled='<%#Iif(Eval("IndicesSistemaPendientes")>0,False, True) %>'>
                      </dxe:ASPxButton>
                  </DataItemTemplate> 
               </dxwgv:GridViewDataColumn>
               <dxwgv:GridViewDataColumn Caption="Definición" VisibleIndex="8" Visible="False">
                 <EditFormSettings Visible="False" />
                  <DataItemTemplate>
                      <dxe:ASPxButton runat="server" ID="btnPlantilla" Text="Definición de la norma" CommandName="Plantilla" CommandArgument='<%# Bind("Norma_descripcion") %>' >
                      
                      </dxe:ASPxButton>
                  </DataItemTemplate> 
               </dxwgv:GridViewDataColumn>
                <dxwgv:GridViewDataColumn Caption="Pantallas" VisibleIndex="9" Visible="False">
                  <EditFormSettings Visible="False" />
                  <DataItemTemplate>
                      <dxe:ASPxButton runat="server" ID="btnPlantillaesp" Text="Pantallas captura" CommandName="Platillaesp" CommandArgument='<%# Bind("Norma_descripcion") %>' >
                      
                      </dxe:ASPxButton>
                  </DataItemTemplate> 
               </dxwgv:GridViewDataColumn>
           </Columns>
    </dxwgv:ASPxGridView>
    </div>
 </asp:Panel>
<cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
</asp:Content>
