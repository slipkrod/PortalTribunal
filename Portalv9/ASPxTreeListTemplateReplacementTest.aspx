<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ASPxTreeListTemplateReplacementTest.aspx.vb" Inherits="Portalv9.ASPxTreeListTemplateReplacementTest" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="1" 
            Height="137px" Width="398px">
            <TabPages>
                <dx:TabPage Text="TabA">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px">
                                <ValidationSettings CausesValidation="True" ErrorTextPosition="Bottom" 
                                    SetFocusOnError="True" ValidationGroup="A">
                                    <RequiredField ErrorText="El campo A es requerido *" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Text="TabB">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="170px">
                                <ValidationSettings CausesValidation="True" SetFocusOnError="True" 
                                    ValidationGroup="A">
                                    <RegularExpression ErrorText="Regular expsion validation failed" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
        </dx:ASPxPageControl>
        <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" 
            RenderMode="BulletedList" ValidationGroup="A">
        </dx:ASPxValidationSummary>
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="ASPxButton" 
            ValidationGroup="A">
        </dx:ASPxButton>
    
    </div>
    </form>
</body>
</html>
