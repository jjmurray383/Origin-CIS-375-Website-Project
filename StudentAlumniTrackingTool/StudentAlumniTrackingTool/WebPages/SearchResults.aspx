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
                                AutoGenerateColumns = "False" DataSourceID = "" 
                                Width="100%" onselectedindexchanged="ResultsGridView_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField = "Lname" HeaderText = "Last Name" SortExpression = "LastName" />
                                    <asp:BoundField DataField = "fname" HeaderText = "First Name" SortExpression = "FirstName" />
                                    <asp:TemplateField HeaderText = "Email">
                                        <ItemTemplate>
                                            <asp:LinkButton ID = "LinkName" runat = "server" 
                                            Text='<%# Eval("Email") %>'
                                            PostBackUrl = '<%"~/WebPages/Profile.aspx?name="+Eval("Email") %>'> </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField = "SchoolName" HeaderText = "Education" SortExpression = "Education" />
                                    <asp:TemplateField HeaderText="Edit" ControlStyle-Width = "25px" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID = "EditImageLink" runat = "server" 
                                                PostBackUrl = '<%"~/WebPages/Edit.aspx?name="+Eval("Email") %>' >
                                                <asp:Image AlternateText = "Edit" ImageUrl = "~/Images/pencil.gif" runat = "server" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        
                                            <asp:TemplateField HeaderText="Delete" ControlStyle-Width="25px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID = "DeleteImageLink" runat = "server" 
                                                PostBackUrl = '<%"~/WebPages/Delete.aspx?name="+Eval("Email") %>' >
                                                <asp:Image ID = "DeleteImg" AlternateText = "Delete" ImageUrl = "~/Images/delete.gif" runat = "server" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                            <asp:SqlDataSource ID = "SqlDataSource1" 
                            runat = "server" 
                            SelectCommand="">
                                </asp:SqlDataSource>
                        </asp:Panel>
                        <asp:Panel ID = "ErrorPanel" runat="server">
                        </asp:Panel>
                        <asp:Panel ID = "NoResultsPanel" runat="server" Visible="false">
                        <p>Sorry, no results were found. :(</p>
                        </asp:Panel>
                    <br />
</asp:Content>
