<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/1.master" CodeBehind="Wfrm_Archivo_Fisico_Detalle.aspx.vb" Inherits="Portalv9.Wfrm_Archivo_Fisico_Detalle" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc1" %>


<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>


<asp:Content ContentPlaceHolderID="TituloBarra" ID="Titulo" runat="server">
    <div id="pagetitle">
<asp:Label ID="lbltitulo" runat="server" Text="Bienvenido" > </asp:Label>
</div>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
      <div>
<asp:label id="lblTitle" runat="server" Font-Size="Small" Width="232px" Height="16px" Font-Names="Arial" Font-Bold="True" Font-Italic="True">Archivo Físico -&gt;Elementos</asp:label>
            <br />
            <br />
        <dxe:ASPxLabel ID="ASPxLabel1" runat="server" ClientInstanceName="label" 
        Text="" ForeColor="Red">
        </dxe:ASPxLabel>
                   <cc1:msgbox id="MsgBox1" runat="server" ForeColor="Red">
                </cc1:msgbox>
          <dx:ASPxTreeList ID="ASPxTreeList2" runat="server" AutoGenerateColumns="False" 
              DataSourceID="dsArchivoFisico" KeyFieldName="idEstructura" 
              ParentFieldName="idEstructuraPID" Width="800px">
              <SettingsText CommandCancel="Cancelar" CommandDelete="Borrar" 
                  CommandEdit="Editar" CommandNew="Nuevo" CommandUpdate="Actualizar" 
                  ConfirmDelete="Seguro desea borrar este registro?" 
                  RecursiveDeleteError="El nodo tiene hijos." />
              <SettingsEditing Mode="EditForm" />
              <Columns>
                  <dx:TreeListTextColumn Caption="idArchivo_Fisico" FieldName="idArchivo_Fisico" 
                      Visible="False" VisibleIndex="1">
                  </dx:TreeListTextColumn>
                  <dx:TreeListTextColumn Caption="idEstructura" FieldName="idEstructura" 
                      ReadOnly="True" Visible="False" VisibleIndex="1">
                  </dx:TreeListTextColumn>
                  <dx:TreeListComboBoxColumn Caption="Tipo" 
                      VisibleIndex="0" FieldName="idTipoElemento">
                      <PropertiesComboBox DataSourceID="dsTipoElemento" TextField="TipoElemento" 
                          ValueField="idTipoElemento" ValueType="System.Int32">
                      </PropertiesComboBox>
                      <CellStyle HorizontalAlign="Left">
                      </CellStyle>
                  </dx:TreeListComboBoxColumn>
                  <dx:TreeListTextColumn Caption="Descripción" FieldName="Descripcion" 
                      VisibleIndex="1">
                      <PropertiesTextEdit MaxLength="150">
                      </PropertiesTextEdit>
                  </dx:TreeListTextColumn>
                  <dx:TreeListComboBoxColumn Caption="Unidad" FieldName="idUnidad_medida" 
                      VisibleIndex="2">
                      <PropertiesComboBox DataSourceID="dsUnidad" 
                          TextField="Unidad_medida_descripcion" ValueField="idUnidad_medida" 
                          ValueType="System.String">
                      </PropertiesComboBox>
                  </dx:TreeListComboBoxColumn>
                  <dx:TreeListSpinEditColumn Caption="Alto" FieldName="Alto" VisibleIndex="3">
                      <PropertiesSpinEdit DecimalPlaces="2" DisplayFormatString="g">
                      </PropertiesSpinEdit>
                  </dx:TreeListSpinEditColumn>
                  <dx:TreeListSpinEditColumn Caption="Ancho" FieldName="Ancho" VisibleIndex="4">
                      <PropertiesSpinEdit DecimalPlaces="2" DisplayFormatString="g">
                      </PropertiesSpinEdit>
                  </dx:TreeListSpinEditColumn>
                  <dx:TreeListSpinEditColumn Caption="Fondo" FieldName="Fondo" VisibleIndex="5">
                      <PropertiesSpinEdit DecimalPlaces="2" DisplayFormatString="g">
                      </PropertiesSpinEdit>
                  </dx:TreeListSpinEditColumn>
                  <dx:TreeListTextColumn Caption="idEstructuraPID" FieldName="idEstructuraPID" 
                      VisibleIndex="7" Visible="False">
                  </dx:TreeListTextColumn>
                  <dx:TreeListCommandColumn ShowNewButtonInHeader="True" VisibleIndex="6" 
                      Width="60px">
                      <EditButton Visible="True">
                      </EditButton>
                      <NewButton Visible="True">
                      </NewButton>
                      <DeleteButton Visible="True">
                      </DeleteButton>
                  </dx:TreeListCommandColumn>
              </Columns>
          </dx:ASPxTreeList>
    </div>
    <asp:ObjectDataSource ID="dsArchivoFisico" runat="server" 
        SelectMethod="Lista_Archivo_Fisico_Estructura" 
        TypeName="Portalv9.WSArchivo.Service1" 
        UpdateMethod="ABC_Archivo_Fisico_Estructura" 
        DeleteMethod="ABC_Archivo_Fisico_Estructura" 
        InsertMethod="ABC_Archivo_Fisico_Estructura" 
          OldValuesParameterFormatString="{0}">
        <DeleteParameters>
            <asp:Parameter Name="op" Type="Object" defaultvalue="1" />
            <asp:QueryStringParameter Name="idArchivo_Fisico" 
                QueryStringField="idArchivo_Fisico" Type="Int32" />
            <asp:Parameter Name="idEstructura" Type="Int32" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="idTipoElemento" Type="Int32" />
            <asp:Parameter Name="idEstructuraPID" Type="Int32" />
            <asp:Parameter Name="Alto" Type="Double" />
            <asp:Parameter Name="Ancho" Type="Double" />
            <asp:Parameter Name="Fondo" Type="Double" />
            <asp:Parameter Name="idUnidad_medida" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="op" Type="Object" defaultvalue="2"/>
            <asp:Parameter Name="idArchivo_Fisico" Type="Int32" />
            <asp:Parameter Name="idEstructura" Type="Int32" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="idTipoElemento" Type="Int32" />
            <asp:Parameter Name="idEstructuraPID" Type="Int32" />
            <asp:Parameter Name="Alto" Type="Double" />
            <asp:Parameter Name="Ancho" Type="Double" />
            <asp:Parameter Name="Fondo" Type="Double" />
            <asp:Parameter Name="idUnidad_medida" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="idArchivo_Fisico" 
                QueryStringField="idArchivo_Fisico" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="op" Type="Object" defaultvalue="0"/>
            <asp:QueryStringParameter Name="idArchivo_Fisico" 
                QueryStringField="idArchivo_Fisico" Type="Int32" />
            <asp:Parameter Name="idEstructura" Type="Int32" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="idTipoElemento" Type="Int32" />
            <asp:Parameter Name="idEstructuraPID" Type="Int32" />
            <asp:Parameter Name="Alto" Type="Double" />
            <asp:Parameter Name="Ancho" Type="Double" />
            <asp:Parameter Name="Fondo" Type="Double" />
            <asp:Parameter Name="idUnidad_medida" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    

    <asp:ObjectDataSource ID="dsTipoElemento" runat="server" 
        SelectMethod="Lista_Archivo_Fisico_Elemento" 
        TypeName="Portalv9.WSArchivo.Service1" 
          OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
    

    <asp:ObjectDataSource ID="dsUnidad" runat="server" 
        SelectMethod="Lista_Archivo_Fisico_Unidades" 
        TypeName="Portalv9.WSArchivo.Service1" 
          OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
    

</asp:Content>



