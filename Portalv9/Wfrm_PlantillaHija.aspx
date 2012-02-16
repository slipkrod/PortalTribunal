<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Wfrm_PlantillaHija.aspx.vb" Inherits="Portalv9.Wfrm_PlantillaHija" MasterPageFile="~/Masterpages/Adminmasteranidada.master" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div>
    	    <dxe:ASPxHyperLink ID="Regresar" runat="server" 
                ImageUrl="~/Images/regresar.gif" NavigateUrl="~/Wfrm_Normas.aspx" />
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br />
            <br />
    </div>
    <div>                <dxwgv:ASPxGridView ID="aspxgdplantillahija"   ClientInstanceName="aspxgdplantillahija"
        KeyFieldName="idPlantilla" runat="server" 
                     OnRowUpdating="aspxgdplantillahija_RowUpdating" 
                     OnRowInserting="aspxgdplantillahija_RowInserting" 
                     OnRowDeleting="aspxgdplantillahija_RowDeleting" OnRowCommand="aspxgdplantillahija_RowCommand" 
                     OnPageIndexChanged="aspxgdplantillahija_PageIndexChanged" AutoGenerateColumns="False" 
                     DataSourceID="objdsNorma_Plantillas" OnCustomJSProperties="aspxgdplantillahija_CustomJSProperties">
                      <ClientSideEvents EndCallback="function(s, e) {
                       Error.SetText(aspxgdplantillahija.cpmensaje);
                        }" />
        <Columns>
                   <dxwgv:GridViewDataTextColumn  Caption="IdNorma"  FieldName="idNorma" 
                                          ReadOnly="True" VisibleIndex="0" Visible="False">
                  <EditFormSettings Visible="False" />
                  </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn  Caption="IdPlantilla"  FieldName="idPlantilla" 
                       ReadOnly="True" VisibleIndex="0" Visible="False">
                         <EditFormSettings Visible="False" />
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewDataTextColumn Caption="Nombre" FieldName="Plantilla_descripcion" 
                       ReadOnly="false" VisibleIndex="0">
                  </dxwgv:GridViewDataTextColumn>
                  <dxwgv:GridViewCommandColumn Caption="Nuevo" VisibleIndex="1"  >
                            <NewButton Visible="true" Text="Agregar pantalla" >
                   </NewButton>
                            
                  </dxwgv:GridViewCommandColumn>
                  <dxwgv:GridViewCommandColumn Caption="Editar" VisibleIndex="2">
                            
                            <EditButton Visible="True" Text="Editar">
                            </EditButton>
                            <CancelButton Visible="True" Text="Cancelar">
                            </CancelButton>
                            <UpdateButton Visible="True" Text="Actualizar">
                            </UpdateButton>
                     </dxwgv:GridViewCommandColumn>
                 <dxwgv:GridViewCommandColumn Caption="Eliminar" VisibleIndex=3> 
                     <DeleteButton Text="Eliminar" Visible="true"></DeleteButton></dxwgv:GridViewCommandColumn>
               <dxwgv:GridViewDataColumn Caption="Plantillas" VisibleIndex="4">
                 <EditFormSettings Visible="False" />
                  <DataItemTemplate>
                      <dxe:ASPxButton ID="BtnElemento" runat="server" Text="Editar Pantalla" 
                          CommandName="Pantalla" CommandArgument='<%# Bind("Plantilla_descripcion") %>'>
                      </dxe:ASPxButton>
                  </DataItemTemplate> 
               </dxwgv:GridViewDataColumn>
              
                   
           </Columns>
        </dxwgv:ASPxGridView>

               
       
                 <asp:ObjectDataSource ID="objdsNorma_Plantillas" runat="server" 
        SelectMethod="ListaNorma_Plantillas" TypeName="Portalv9.WSArchivo.Service1">
                     <SelectParameters>
                         <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" 
                             Type="Int32" />
                     </SelectParameters>
    </asp:ObjectDataSource>
    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red">
                </cc1:msgbox>
        <dxe:ASPxLabel ID="ASPxError" runat="server" ClientInstanceName="Error" 
            ForeColor="Red" Text="">
        </dxe:ASPxLabel>
  </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
