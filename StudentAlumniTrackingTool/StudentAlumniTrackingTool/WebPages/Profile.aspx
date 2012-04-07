<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="Profile.aspx.cs" Inherits="StudentAlumniTrackingTool.WebPages.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <span class="header">Details for the user </span>
    <asp:Label ID = "TitleName" runat = "server" CssClass = "header" ></asp:Label>
    <span class="header">:</span>
    <asp:DetailsView ID="DetailsView" runat="server"
        DataSourceID = "DetailsSql"
        AutoGenerateRows = "true"
        Height="50px" Width="100%" >
        </asp:DetailsView>

        <asp:SqlDataSource ID = "DetailsSql" runat ="server"
        ConnectionString = "<% ConnectionStrings:ApplicationServices %>"
        SelectCommand="SELECT * FROM [] WHERE ([Email] = @Email)">
            <SelectParameters>
                <asp:ControlParameter ControlID ="DetailsView" Name = "EmailDetails" Type = "String" />
            </SelectParameters>
        </asp:SqlDataSource>

</asp:Content>
