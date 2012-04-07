<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs"
 Inherits="StudentAlumniTrackingTool.WebPages.SearchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                                        <asp:LinkButton ID = "LinkName" runat = "server" Text='<%# Eval("FirstName") %>' 
                                            PostBackUrl='<%#"~/Profile.aspx?ID="Eval("ID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField = "Education" HeaderText = "Education" SortExpression = "Education" />
                                <asp:ImageField AlternateText="Edit" DataImageUrlField="../Images/pencil.gif"></asp:ImageField>
                                <asp:ImageField DataImageUrlField="../Images/delete.gif" AlternateText="Delete"></asp:ImageField>
                                </Columns>
                            </asp:GridView>

                            <asp:SqlDataSource ID = "SqlDataSource1" runat = "server" ConnectionString = "<%$ ConnectionStrings:ConnectionString %>" 
                                SelectCommand = "<%=  %>">
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
