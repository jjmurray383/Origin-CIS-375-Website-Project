<%@ Page Title="Log Out" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Logout.aspx.cs" Inherits="StudentAlumniTrackingTool.Account.Logout" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Log OUT</h2>
    <p>
        You have been logged out. Have a nice day!</p>
<p>
        &nbsp;</p>
<p>
        <asp:HyperLink runat="server" NavigateUrl="../Default.aspx">Back to default page</asp:HyperLink></p>
    </asp:Content>
