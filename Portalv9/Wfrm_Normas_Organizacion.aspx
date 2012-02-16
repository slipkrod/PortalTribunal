<%@ Page Language="vb" MasterPageFile="~/Masterpages/Adminmaster2col.master"  AutoEventWireup="false" CodeBehind="Wfrm_Normas_Organizacion.aspx.vb" Inherits="Portalv9.Wfrm_Normas_Organizacion" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallbackPanel" tagprefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloBarra" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
//        var uploadedFilesFlag;
//        var extensionRegExp = /.+\.([^.]+)$/;
//        var ban;
//        var name1;        
//        function OnBtnUploadClick(s, e) {
//            if (upio.GetText() != "" && upic.GetText() != "") {
//                if (isAllowUpload() && isAllowUpload1()) {
//                    uploadedFilesFlag = null;
//                    name1 = upio.GetText();
//                    lblFileName.SetText(name1);
//                    lblFileName.SetVisible(true);
//                    lblCompleteMessage.SetVisible(false);
//                    lblmensajetipo.SetVisible(false);
//                }
//                else {
//                    e.processOnServer = false;
//                    lblCompleteMessage.SetVisible(false);
//                    lblmensajetipo.SetVisible(true);
//                }
//            }
//            else {
//                e.processOnServer = false;
//                lblmensajetipo.SetVisible(false);
//                lblCompleteMessage.SetVisible(true);

//            }

//        }
//        function isAllowUpload() {
//            for (var i = 0; i < upio.GetFileInputCount(); i++) {
//                if (getFileExtension(upio.GetText(i)) != "gif" && getFileExtension(upio.GetText(i)) != "jpg" && getFileExtension(upio.GetText(i)) != "jpeg")
//                    return false;
//            }
//            return true;
//        }

//        function isAllowUpload1() {
//            for (var i = 0; i < upic.GetFileInputCount(); i++) {
//                if (getFileExtension(upic.GetText(i)) != "gif" && getFileExtension(upic.GetText(i)) != "jpg" && getFileExtension(upic.GetText(i)) != "jpeg")
//                    return false;
//            }
//            return true;
//        }
//        function getFileExtension(fileName) {
//            var matches = extensionRegExp.exec(fileName);
//            if (matches.length == 2)
//                return matches[1];
//            else
//                return "";
//        }
//        function OnBtnActClick(s, e) {
//            if (rbImagen.GetSelectedIndex() != 0) {
//                if (upio.GetText() != "" && upic.GetText() != "") {
//                    if (isAllowUpload() && isAllowUpload1()) {
//                        uploadedFilesFlag = null;
//                        lblCompleteMessage.SetVisible(false);
//                        lblmensajetipo.SetVisible(false);
//                    }
//                    else {
//                        e.processOnServer = false;
//                        lblCompleteMessage.SetVisible(false);
//                        lblmensajetipo.SetVisible(true);
//                    }
//                }
//                else {
//                    e.processOnServer = false;
//                    lblmensajetipo.SetVisible(false);
//                    lblCompleteMessage.SetVisible(true);
//                }
//            }
//        }
        function ShowHideUpload() {
            if (document.getElementById('butUpload').value == 'Cambiar imagenes') {
                document.getElementById('butUpload').value = 'Cancelar';
                document.getElementById('tableImages').style.display = 'none';
                document.getElementById('divUpload').style.display = '';
            }
            else {
                document.getElementById('butUpload').value = 'Cambiar imagenes';
                document.getElementById('tableImages').style.display = '';
                document.getElementById('divUpload').style.display = 'none';
            }
        }
    </script>
    <div>
    	    <dxe:ASPxHyperLink ID="Regresar" runat="server" ImageUrl="~/Images/regresar.gif" NavigateUrl="~/Wfrm_Normas.aspx" />
    	    <asp:label id="lblTitle" runat="server" Font-Size="Small" Width="90%" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True"> Texto en el page_ load</asp:label>
            <br />
    </div>
    <div>
         <br />
         <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="200px">
         <PanelCollection>
            <dxp:PanelContent>
         <dxwtl:ASPxTreeList ID="aspxtreenivel" runat="server" 
             AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
             EnableViewState="False" KeyFieldName="idNivel" ParentFieldName="idDocumentoPID" 
             SettingsText-CommandCancel="Cancelar" SettingsText-CommandDelete="Eliminar" 
             SettingsText-CommandEdit="Editar" SettingsText-CommandNew="Insertar" 
             SettingsText-CommandUpdate="Actualizar" SettingsText-ConfirmDelete="Esta seguro que quiere eliminar ?">
             <SettingsBehavior AllowFocusedNode="True" ProcessFocusedNodeChangedOnServer="false" AllowSort="False"/>
             <SettingsEditing Mode="EditFormAndDisplayNode"/>
             <SettingsText ConfirmDelete="¿ Estás seguro de querer eliminar este nivel ?" 
                 RecursiveDeleteError="El nivel no puede ser borrado ya que tiene subniveles." />             
             <Templates>
                 <EditForm>
                     Nivel<dxe:ASPxTextBox ID="txtdescripcion" runat="server" Value='<%# Bind("Nivel_descripcion") %>' Width="250px">
                     </dxe:ASPxTextBox>
                     <dxe:ASPxLabel ID="Label2" runat="server" Text="Tipo"></dxe:ASPxLabel>
                     <dxe:ASPxComboBox ID="cmbTipo" runat="server" DropDownStyle="DropDown" 
                         ValueType="System.Byte" Value='<%# Bind("Nivel_Logico_Fisico") %>' AutoPostBack="False">
                         <Items>
                             <dxe:ListEditItem Text="Lógico" Value="0" />
                             <dxe:ListEditItem Text="Físico" Value="1" />
                         </Items>
                     </dxe:ASPxComboBox>
                     <br />
                     <table id="tableImages">
                        <tr>
                            <td valign"middle" align="center" > 
                                <dxe:ASPxImage ID="ASPxIImagen_open" runat="server" ImageAlign="Middle"></dxe:ASPxImage>
                            </td>
                            <td valign"middle" align="center" > 
                                <dxe:ASPxImage ID="ASPxIImagen_close" runat="server" ImageAlign="Middle"></dxe:ASPxImage>
                            </td>
                        </tr>
                        <tr>
                            <td valign"middle" align="center" > 
                                 <dxe:ASPxLabel ID="ASPxLabel1" runat="server" 
                                     Text="Imágen actual para nivel abierto" Width="100px"></dxe:ASPxLabel>
                            </td>
                            <td valign"middle" align="center" > 
                                <dxe:ASPxLabel ID="ASPxLabel2" runat="server" 
                                    Text="Imágen actual para nivel cerrado" Width="100px"></dxe:ASPxLabel>
                                <br />
                            </td>
                        </tr>
                     </table>
                     <div id="divUpload" style="display:none;">
                     <dxe:ASPxLabel ID="label3" runat="server" 
                         Text="Solo se aceptan imagenes (Gif o Jpeg) y menores de 1 MB">
                     </dxe:ASPxLabel>
                     <br />
                     <dxe:ASPxRadioButtonList ID="rbImagen" runat="server" 
                         ClientInstanceName="rbImagen" SelectedIndex="0">
                         <Items>
                             <dxe:ListEditItem Text="No sustituir Imagen" Value="0" />
                             <dxe:ListEditItem Text="Remplazar Imagen" Value="1" />
                         </Items>
                     </dxe:ASPxRadioButtonList>
                     <br />
                             <br />
                             <table>
                                 <tr>
                                     <td>
                                         <dxe:ASPxLabel ID="aspxlblio" runat="server" Text="Imágen para nivel abierto">
                                         </dxe:ASPxLabel>
                                         <br />
                                         <dxuc:ASPxUploadControl ID="Imagen_open" runat="server" ClientInstanceName="upio" Width="290px">
                                            <ValidationSettings MaxFileSize="1000000" AllowedContentTypes="image/jpeg,image/gif,image/pjpeg">
                                             </ValidationSettings>
                                         </dxuc:ASPxUploadControl>
                                         <br />
                                         <dxe:ASPxLabel ID="aspxlblic" runat="server" Text="Imágen para nivel cerrado">
                                         </dxe:ASPxLabel>
                                         <br />
                                         <dxuc:ASPxUploadControl ID="Imagen_close" runat="server" ClientInstanceName="upic" Width="290px" >
                                            <ValidationSettings MaxFileSize="1000000" AllowedContentTypes="image/jpeg,image/gif,image/pjpeg">
                                             </ValidationSettings>
                                         </dxuc:ASPxUploadControl>
                                         <tr>
                                             <td align="center">
                                                 <dxe:ASPxLabel ID="lblCompleteMessage" runat="server" 
                                                     ClientInstanceName="lblCompleteMessage" ClientVisible="False" 
                                                     ForeColor="#FF3300" Text="Favor de capturar ambas imágenes.">
                                                 </dxe:ASPxLabel>
                                                 <dxe:ASPxLabel ID="lblmensajetipo" runat="server" 
                                                     ClientInstanceName="lblmensajetipo" ClientVisible="False" ForeColor="#FF3300" 
                                                     Text="El tipo de archivo que intenta subir no es permitido.">
                                                 </dxe:ASPxLabel>
                                             </td>
                                         </tr>
                                     </td>
                                 </tr>
                             </table>
                     </div>
                     <input id="butUpload" type="button" value="Cambiar imagenes" onclick="ShowHideUpload();" /><br />
                     <br />
                    &nbsp;<div>
                             <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxButton ID="btnUpdtae" runat="server" Text="Actualizar" 
                                            AutoPostBack="False" UseSubmitBehavior="false" OnClick="btnUpdtae_Click1" ></dxe:ASPxButton>
                                    </td> 
                                    <td>
                                        <dxe:ASPxButton ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" AutoPostBack="False"></dxe:ASPxButton>
                                    </td>
                                </tr>
                             </table>
                        <br />                             
                     </div>
                 </EditForm>
             </Templates>
             <Columns>
                 <dxwtl:TreeListTextColumn Caption="idDocumentoPID" FieldName="idDocumentoPID" ReadOnly="True" Visible="false">
                 </dxwtl:TreeListTextColumn>
                 <dxwtl:TreeListTextColumn Caption="idNivel" FieldName="idNivel" ReadOnly="True" Visible="false">
                 </dxwtl:TreeListTextColumn>
                 <dxwtl:TreeListTextColumn Caption="Niveles" FieldName="Imagen" VisibleIndex="0">
                     <DataCellTemplate>
                         <dxe:ASPxImage ID="ASPxImage2" runat="server" 
                             ImageUrl="<%# GetNodeGlyph(Container) %>">
                         </dxe:ASPxImage>
                     </DataCellTemplate>
                 </dxwtl:TreeListTextColumn>
                 <dxwtl:TreeListTextColumn Caption="Descripción" FieldName="Nivel_descripcion" VisibleIndex="1">
                 </dxwtl:TreeListTextColumn>                 
                 <dxwtl:TreeListTextColumn Caption="valuepath" FieldName="valuepath" ReadOnly="True" Visible="false" >
                 </dxwtl:TreeListTextColumn>
                 <dxwtl:TreeListCommandColumn ShowNewButtonInHeader="True" ToolTip="Botones de Editar, Agregar y Eliminar" VisibleIndex="2" ButtonType="Image" >
                     <EditButton Visible="True">
                         <Image AlternateText="Editar" 
                             Url="../App_Themes/Editors/edtDropDownHottracked.png" />
                     </EditButton>
                     <NewButton Text="Agregar" Visible="True">
                         <Image Url="../App_Themes/Editors/fcaddhot.png" />
                     </NewButton>
                     <DeleteButton Visible="True">
                         <Image AlternateText="Eliminar" 
                             Url="../App_Themes/Editors/fcremovehot.png" />
                     </DeleteButton>
                     <CancelButton Text="Cancelar" Visible="True">
                     </CancelButton>
                 </dxwtl:TreeListCommandColumn>
                 <dxwtl:TreeListTextColumn Caption="Imagen_open" FieldName="Imagen_open" ReadOnly="True" Visible="False" VisibleIndex="3">
                 </dxwtl:TreeListTextColumn>
                 <dxwtl:TreeListTextColumn Caption="Configuración" VisibleIndex="4">
                     <DataCellTemplate>
                         <dxe:ASPxHyperLink ID="ASPxHyperLink2" runat="server" 
                             NavigateUrl='<%# "Wfrm_TipoExpediente.aspx?idNorma=" & Eval("idNorma").ToString  & "&idNivel=" & Eval("idNivel").ToString   %>' 
                             Text="Detalle" />
                     </DataCellTemplate>
                 </dxwtl:TreeListTextColumn>
                 <dxwtl:TreeListTextColumn Caption="Nivel_Logico_Fisico" FieldName="Nivel_Logico_Fisico" Visible="false">
                 </dxwtl:TreeListTextColumn>
                 <dxwtl:TreeListTextColumn Caption="idNorma" FieldName="idNorma" ReadOnly="True" Visible="false">
                 </dxwtl:TreeListTextColumn>                 
             </Columns>
         </dxwtl:ASPxTreeList>
            </dxp:PanelContent>
         </PanelCollection>
         </dx:ASPxCallbackPanel>
    </div>
   <dxe:ASPxLabel ID="lblFileName" runat="server" ClientInstanceName="lblFileName" ClientVisible="False" text="ASPxLabel">
   </dxe:ASPxLabel>
    
     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="ListaNormas_Niveles" TypeName="Portalv9.WSArchivo.Service1"  
        DeleteMethod="ABC_Normas_Niveles" InsertMethod="ABC_Normas_Niveles" 
        UpdateMethod="ABC_Normas_Niveles">
        <DeleteParameters>
            <asp:Parameter DefaultValue="1" Name="op" Type="Object" />
            <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
            <asp:Parameter Name="idNivel" Type="Int32" />
            <asp:Parameter Name="Nivel" Type="Int32" />
            <asp:Parameter Name="valuePath" Type="String" />
            <asp:Parameter Name="Nivel_descripcion" Type="String" />
            <asp:Parameter Name="idDocumentoPID" Type="Int32" />
            <asp:Parameter Name="Imagen_open" Type="String" />
            <asp:Parameter Name="Imagen_close" Type="String" />
            <asp:Parameter Name="Nivel_Logico_Fisico" Type="Int32" />
         </DeleteParameters>
         <UpdateParameters>
             <asp:Parameter DefaultValue="2" Name="op" Type="Object" />
             <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
             <asp:Parameter Name="idNivel" Type="Int32" />
             <asp:Parameter Name="Nivel" Type="Int32" />
             <asp:Parameter Name="valuePath" Type="String" />
             <asp:Parameter Name="Nivel_descripcion" Type="String" />
             <asp:Parameter Name="idDocumentoPID" Type="Int32" />
             <asp:Parameter Name="Imagen_open" Type="String" />
             <asp:Parameter Name="Imagen_close" Type="String" />
             <asp:Parameter Name="Nivel_Logico_Fisico" Type="Int32" />
         </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
        </SelectParameters>
         <InsertParameters>
             <asp:Parameter DefaultValue="0" Name="op" Type="Object" />
             <asp:QueryStringParameter Name="idNorma" QueryStringField="idNorma" Type="Int32" />
             <asp:Parameter DefaultValue="0" Name="idNivel" Type="Int32" />
             <asp:Parameter Name="Nivel" Type="Int32" />
             <asp:Parameter DefaultValue="" Name="valuePath" Type="String" />
             <asp:Parameter Name="Nivel_descripcion" Type="String" />
             <asp:Parameter Name="idDocumentoPID" Type="Int32" />
             <asp:Parameter Name="Imagen_open" Type="String" />
             <asp:Parameter Name="Imagen_close" Type="String" />
             <asp:Parameter Name="Nivel_Logico_Fisico" Type="Int32" />
         </InsertParameters>
    </asp:ObjectDataSource>                                                                                                                        
    <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red"></cc1:msgbox>
    </asp:Content>
 

