<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="LoginError.aspx.cs" Inherits="StudentAlumniTrackingTool.Account.LoginError" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Login Error Occured</h2>
    <p>
        An error occured during login. The most likely reason is because your user name or password
        was entered incorrectly.
    </p>
    <p>
        <a href="Login.aspx">Try again</a>.
    </p>
    </asp:Content>
