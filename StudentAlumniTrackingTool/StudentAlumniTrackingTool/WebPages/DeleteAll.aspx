<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteAll.aspx.cs" 
Inherits="StudentAlumniTrackingTool.WebPages.DeleteAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
                        Delete All Accounts
                    </h2>
                    <p>
                        Are you sure you want to delete ALL accounts?
                    </p>
                    <p>
                        <span style = "font-size:30px; color:Red">This action CANNOT be undone! Use extreme caution.</span>
                    </p>
                    <p>
                        <asp:Button ID = "YesDeleteAll" Text="Yes" runat="server" 
        OnCommand="DeleteUser" />
        </p>
        <p>
                        <asp:Button ID = "NoDeleteAll" Text="No" runat="server" OnCommand="SaveUser" />
                        </p>
        </asp:Content>
