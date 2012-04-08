<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="RegisterError.aspx.cs" Inherits="StudentAlumniTrackingTool.Account.RegisterError" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Register Error Occured</h2>
    <p>
        An error occured during registration. The most likely reason is because a field was not properly filled out or you
        were already logged in. Sorry about that.
    </p>
    <p>
        <a href="Register.aspx"> Try again</a>.
    </p>
    </asp:Content>
