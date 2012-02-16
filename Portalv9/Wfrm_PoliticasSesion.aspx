<%@ Page Language="vb" MasterPageFile="~/Masterpages/Adminmaster2col.master" AutoEventWireup="false" CodeBehind="Wfrm_PoliticasSesion.aspx.vb" Inherits="Portalv9.Wfrm_PoliticasSesion" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <div>
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br />
            <br />
    </div>
    <div>
		<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="700px" border="0">
									
										
										<TR>
									         <link href="Grids.css" rel="stylesheet" type="text/css" />
											<td style="WIDTH: 632px; HEIGHT: 254px" vAlign="top" noWrap align="left">
                                                <dxwgv:aspxgridview id="grdPSesion" runat="server" ClientInstanceName="grdPSesion" 
                                                    AutoGenerateColumns="False" KeyFieldName="PoliticaSesionID" 
                                                    OnRowInserting="grdPSesion_RowInserting" OnRowUpdating="grdPSesion_RowUpdating" 
                                                    OnRowDeleting="grdPSesion_RowDeleting" 
                                                    OnPageIndexChanged="grdPSesion_PageIndexChanged" SettingsPager-PageSize="2" >
                                                  <SettingsBehavior ConfirmDelete="true" />
                                                  <SettingsText ConfirmDelete="¿ Está seguro de eliminar la Política de sesión ?" />
                                                           <ClientSideEvents EndCallback="function(s, e) {
                                                if (grdPSesion.cpMessage != null)
	                                                alert(grdPSesion.cpMessage);
                                                }" />
                                                 <Columns>
                                                       <dxwgv:GridViewDataTextColumn  Caption="ID"  FieldName="PoliticaSesionID" ReadOnly="True" VisibleIndex="0" Visible="false">
                                                      </dxwgv:GridViewDataTextColumn>
                                                      <dxwgv:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" ReadOnly="false" VisibleIndex="1">
                                                      </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="Descripción" FieldName="Descripcion" 
                                                           ReadOnly="false" VisibleIndex="2">
                                                      </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="Duración" FieldName="DuracionMinutos" 
                                                           VisibleIndex="2" >
                                                       </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="Fallidos Totales" FieldName="IntentosFallidosConsec" 
                                                           VisibleIndex="3" >
                                                       </dxwgv:GridViewDataTextColumn>
                                                       
                                                      <dxwgv:GridViewDataTextColumn Caption="Fallidos Día" FieldName="IntentosFallidosDia" 
                                                           ReadOnly="false" VisibleIndex="4">
                                                      </dxwgv:GridViewDataTextColumn>
                                                      <dxwgv:GridViewDataCheckColumn  Caption="MultiSesión" FieldName="PermitirMultiSesion" 
                                                           VisibleIndex="5">
                                                           
                                                       </dxwgv:GridViewDataCheckColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="Inhab. Días" FieldName="PeriodoInhabCtaDias" 
                                                           VisibleIndex="5">
                                                       </dxwgv:GridViewDataTextColumn>
                                                         <dxwgv:GridViewDataTextColumn Caption="Borrar Días" FieldName="PeriodoBorrarCtaDias" 
                                                           VisibleIndex="6">
                                                       </dxwgv:GridViewDataTextColumn>
                                                       
                                                      <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="8" ButtonType="Image"  >
                                                                <NewButton Visible="true" Text="Agregar Nueva Política de Sesión" >
                                                                <Image Url="../App_Themes/Aqua/Editors/fcaddhot.png" />
                                                                </NewButton>
                                                                
                                                      </dxwgv:GridViewCommandColumn>
                                                       <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="9" ButtonType="Image">
                                                                
                                                                <EditButton Visible="True" Text="Editar" >
                                                                 <Image Url="../App_Themes/Aqua/Editors/edtDropDownHottracked.png" />
                                                                </EditButton>
                                                                <CancelButton Visible="True" Text="Cancelar" >
                                                                 <Image Url="Images/cancelar.jpg" />
                                                                </CancelButton>
                                                                <UpdateButton Visible="True" Text="Actualizar">
                                                                <Image Url="Images/actualiza.jpg" />
                                                                </UpdateButton>
                                                         </dxwgv:GridViewCommandColumn>
                                                     <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex="10" ButtonType="Image">
                                                         
                                                        <DeleteButton Text="Eliminar" Visible="true">
                                                         <Image Url="../App_Themes/Aqua/Editors/fcremovehot.png" />
                                                        </DeleteButton>
                                                      </dxwgv:GridViewCommandColumn>
                       
                                              </Columns>
                                                </dxwgv:aspxgridview>	
                                          </TD>
                                           
                                     	</TR>
										</TABLE>
       
    </div>							
				             
                     
       
                        
  

</asp:Content>


