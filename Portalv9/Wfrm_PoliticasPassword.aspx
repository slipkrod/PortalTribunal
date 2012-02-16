<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_PoliticasPassword.aspx.vb" Inherits="Portalv9.Wfrm_PoliticasPassword" MasterPageFile="~/Masterpages/Adminmaster2col.master"%>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
    

<%@ Register TagPrefix="cc1" Namespace="MsgBox" Assembly="MsgBox" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <div>
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br />
            <br />
    </div>
    <div>
		
                                                <dxwgv:ASPxGridView id="grdPPwd" runat="server" ClientInstanceName="grdPPwd" AutoGenerateColumns="False" KeyFieldName="PoliticaPwdID" OnRowInserting="grdPPwd_RowInserting" OnRowUpdating="grdPPwd_RowUpdating" OnRowDeleting="grdPPwd_RowDeleting" OnPageIndexChanged="grdPPwd_PageIndexChanged"  >
                                                  <SettingsBehavior ConfirmDelete="true" />
              <SettingsText ConfirmDelete="¿ Está seguro de eliminar la Política de contraseña ?" />
               
                                            <ClientSideEvents EndCallback="function(s, e) {
                                if (grdPPwd.cpMessage != null)
	                                alert(grdPPwd.cpMessage);
                                }" />
                                                  <Columns>
                                                       <dxwgv:GridViewDataTextColumn  Caption="ID"  FieldName="PoliticaPwdID" ReadOnly="True" VisibleIndex="0" Visible="false">
                                                      </dxwgv:GridViewDataTextColumn>
                                                      <dxwgv:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" ReadOnly="false" VisibleIndex="1">
                                                      </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="Descripción" FieldName="Descripcion" 
                                                           ReadOnly="false" VisibleIndex="2">
                                                      </dxwgv:GridViewDataTextColumn>
                                                      <dxwgv:GridViewDataTextColumn Caption="LongMin" FieldName="LongMin" 
                                                           ReadOnly="false" VisibleIndex="3">
                                                      </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="LongMax" FieldName="LongMax" 
                                                           VisibleIndex="4">
                                                       </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataCheckColumn  Caption="May" FieldName="Mayusculas" 
                                                           VisibleIndex="5">
                                                           
                                                       </dxwgv:GridViewDataCheckColumn>
                                                       <dxwgv:GridViewDataCheckColumn Caption="Min" FieldName="Minusculas" 
                                                           VisibleIndex="6">
                                                       </dxwgv:GridViewDataCheckColumn>
                                                       <dxwgv:GridViewDataCheckColumn  Caption="Simb" FieldName="Simbolos" 
                                                           VisibleIndex="7" >
                                                       </dxwgv:GridViewDataCheckColumn>
                                                       <dxwgv:GridViewDataCheckColumn Caption="Num" FieldName="Numeros" 
                                                           VisibleIndex="8">
                                                        </dxwgv:GridViewDataCheckColumn>
                                                         <dxwgv:GridViewDataTextColumn Caption="Mascara" FieldName="Mascara" 
                                                           VisibleIndex="9">
                                                       </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="Duración" FieldName="DuracionDias" 
                                                           VisibleIndex="10" >
                                                       </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="CantHist" FieldName="CantHistorico" 
                                                           VisibleIndex="11">
                                                       </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="ReseteoMin" 
                                                           FieldName="CambioPwdResetMinutos" VisibleIndex="12">
                                                       </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="AviCadDias" 
                                                           FieldName="AvisoCaducidadPwdDias" VisibleIndex="13">
                                                       </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="CarIguales" FieldName="CarIguales" 
                                                           VisibleIndex="14">
                                                       </dxwgv:GridViewDataTextColumn>
                                                       <dxwgv:GridViewDataTextColumn Caption="CarConse." FieldName="CarConsecutivos" 
                                                           VisibleIndex="15">
                                                       </dxwgv:GridViewDataTextColumn>
                                                      <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="16" ButtonType="Image"  >
                                                                <NewButton Visible="true" Text="Agregar Nueva Política de Contraseña" >
                                                                <Image Url="../App_Themes/Aqua/Editors/fcaddhot.png" />
                                                                </NewButton>                                                                
                                                      </dxwgv:GridViewCommandColumn>
                                                      <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="17" ButtonType="Image">
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
                                                     <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex="18" ButtonType="Image">
                                                        <DeleteButton Text="Eliminar" Visible="true">
                                                         <Image Url="../App_Themes/Aqua/Editors/fcremovehot.png" />
                                                        </DeleteButton>
                                                      </dxwgv:GridViewCommandColumn>   
                                              </Columns>
                                                </dxwgv:ASPxGridView>	
                                          
				                            <asp:HiddenField ID="HiddenField1" runat="server" />
				                            <asp:HiddenField ID="HiddenField2" runat="server" />
				                            <asp:HiddenField ID="HiddenField3" runat="server" />
				                            <asp:HiddenField ID="HiddenField4" runat="server" />
				                            <asp:HiddenField ID="HiddenField5" runat="server" />
				                            <asp:HiddenField ID="HiddenField6" runat="server" />
				                            <asp:HiddenField ID="HiddenField7" runat="server" />
				                            <asp:HiddenField ID="HiddenField8" runat="server" />
				                            <asp:HiddenField ID="HiddenField9" runat="server" />
				                            <asp:HiddenField ID="HiddenField10" runat="server" />
				                            <asp:HiddenField ID="HiddenField11" runat="server" />
				                            <asp:HiddenField ID="HiddenField12" runat="server" />
				                            <asp:HiddenField ID="HiddenField13" runat="server" />
				                            <asp:HiddenField ID="HiddenField14" runat="server" />
				                            <asp:HiddenField ID="HiddenField15" runat="server" />
				                        
    </div>							
				             
                     
       
                        
  

</asp:Content>


