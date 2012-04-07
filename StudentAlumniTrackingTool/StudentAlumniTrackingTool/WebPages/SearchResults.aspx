<%@ Page Title="Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
 CodeBehind="SearchResults.aspx.cs" Inherits="StudentAlumniTrackingTool.WebPages.SearchResults" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Search Results</h1>
                    <p>
                       Here are the result(s):
                        </p>
                        <asp:Panel ID="ResultsPanel" runat="server" Visible="False">
                            <asp:GridView ID = "ResultsGridView" runat = "server" 
                                AutoGenerateColumns = "False" DataSourceID = "SqlDataSource1" 
                                Width="100%" onselectedindexchanged="ResultsGridView_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField = "LastName" HeaderText = "Last Name" SortExpression = "LastName" />
                                    <asp:TemplateField HeaderText = "First Name">
                                        <ItemTemplate>
                                            <asp:LinkButton ID = "LinkName" runat = "server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField = "Education" HeaderText = "Education" SortExpression = "Education" />
                                    <asp:TemplateField HeaderText="Edit" ControlStyle-Width = "25px" >
                                        <ItemTemplate>
                                            <asp:Image AlternateText = "Edit" ImageUrl = "~/Images/pencil.gif" runat = "server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ControlStyle-Width="25px">
                                        <ItemTemplate>
                                            <asp:Image ID = "DeleteImg" AlternateText = "Delete" ImageUrl = "~/Images/delete.gif" runat = "server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                            <asp:SqlDataSource ID = "SqlDataSource1" runat = "server" ConnectionString = "<%$ ConnectionStrings:ConnectionString %>" 
                                SelectCommand = "<%= Session["SearchQuery"]  %>">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID = " " Name = "FirstName" PropertyName = "Text" Type = "String" />

                                    </SelectParameters>
                                </asp:SqlDataSource>
                        </asp:Panel>
                        <asp:Panel ID = "ErrorPanel" runat="server">
                        </asp:Panel>
                        <asp:Panel ID = "NoResultsPanel" runat="server" Visible="false">
                        <p>Sorry, no results were found. :(</p>
                        </asp:Panel>
                    <br />
</asp:Content>
