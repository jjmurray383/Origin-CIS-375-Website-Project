<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Success.aspx.cs" Inherits="StudentAlumniTrackingTool.Account.Success" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   You have been successfully registered as <asp:LoginName ID = "LoginName" runat = "server" />!
</asp:Content>
