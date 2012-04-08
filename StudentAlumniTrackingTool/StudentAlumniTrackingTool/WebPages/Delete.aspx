<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" 
Inherits="StudentAlumniTrackingTool.WebPages.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
                        Delete Account
                    </h2>
                    <p>
                        Are you sure you want to delete this account?
                    </p>
                    <p>
                        <asp:Button ID = "YesDelete" Text="Yes" runat="server" 
        OnCommand="DeleteUser" />
        </p>
        <p>
                        <asp:Button ID = "NoDelete" Text="No" runat="server" OnCommand="SaveUser" />
                        </p>
        </asp:Content>
