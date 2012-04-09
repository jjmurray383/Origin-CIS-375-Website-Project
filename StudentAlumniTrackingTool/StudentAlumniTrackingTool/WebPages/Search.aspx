<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
 CodeBehind="Search.aspx.cs" Inherits="StudentAlumniTrackingTool.WebPages.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Search</h1>
                    <p>
                        Use the form below to search for people.
                        Please enter data for at least one form.</p>
                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="SearchUserValidationGroup"/>
                    <div class="accountInfo">
                        <fieldset class="search">
                            <legend>Search Query</legend>
                            <p>
                                <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastNameBox">Last Name:</asp:Label>
                                <asp:TextBox ID="LastNameBox" runat="server" CssClass="textEntry" TextMode="SingleLine" MaxLength="25"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="MajorDropdownLabel" runat="server" AssociatedControlID="MajorDropdown">Major:</asp:Label>
                                <asp:DropDownList ID = "MajorDropdown" runat = "server">
                                        <asp:ListItem Value="">--None Specified--</asp:ListItem>
                                        <asp:ListItem Value="Accounting">Accounting</asp:ListItem>
                                        <asp:ListItem Value="American Studies">American Studies</asp:ListItem>
                                        <asp:ListItem Value="Anthropology">Anthropology</asp:ListItem>
                                        <asp:ListItem Value="Art History">Art History</asp:ListItem>
                                        <asp:ListItem Value="Behavioral Sciences">Behavioral Sciences</asp:ListItem>
                                        <asp:ListItem Value="Biochemistry">Biochemistry</asp:ListItem>
                                        <asp:ListItem Value="Bioengineering">Bioengineering</asp:ListItem>
                                        <asp:ListItem Value="Biological Sciences">Biological Sciences</asp:ListItem>
                                        <asp:ListItem Value="Chemistry (ASC certified)">Chemistry (ASC certified)</asp:ListItem>
                                        <asp:ListItem Value="Chemistry (Instructional)">Chemistry (Instructional)</asp:ListItem>
                                        <asp:ListItem Value="Children and Families (BGS)">Children and Families (BGS)</asp:ListItem>
                                        <asp:ListItem Value="Communication">Communication</asp:ListItem>
                                        <asp:ListItem Value="Computer & Information Science">Computer & Information Science</asp:ListItem>
                                        <asp:ListItem Value="Computer Engineering">Computer Engineering</asp:ListItem>
                                        <asp:ListItem Value="Criminal Justice Studies">Criminal Justice Studies</asp:ListItem>
                                        <asp:ListItem Value="Digital Forensics">Digital Forensics</asp:ListItem>
                                        <asp:ListItem Value="Digital Marketing">Digital Marketing</asp:ListItem>
                                        <asp:ListItem Value="Earth Science">Earth Science</asp:ListItem>
                                        <asp:ListItem Value="Economics">Economics</asp:ListItem>
                                        <asp:ListItem Value="Education-Undecided">Education-Undecided</asp:ListItem>
                                        <asp:ListItem Value="Electrical Engineering">Electrical Engineering</asp:ListItem>
                                        <asp:ListItem Value="Elementary Education">Elementary Education</asp:ListItem>
                                        <asp:ListItem Value="Engineering - Undecided">Engineering - Undecided</asp:ListItem>
                                        <asp:ListItem Value="English">English</asp:ListItem>
                                        <asp:ListItem Value="Environmental Science">Environmental Science</asp:ListItem>
                                        <asp:ListItem Value="Environmental Studies">Environmental Studies</asp:ListItem>
                                        <asp:ListItem Value="Finance">Finance</asp:ListItem>
                                        <asp:ListItem Value="French Studies">French Studies</asp:ListItem>
                                        <asp:ListItem Value="General Business">General Business</asp:ListItem>
                                        <asp:ListItem Value="General Studies">General Studies</asp:ListItem>
                                        <asp:ListItem Value="Health Policy Studies">Health Policy Studies</asp:ListItem>
                                        <asp:ListItem Value="Hispanic Studies">Hispanic Studies</asp:ListItem>
                                        <asp:ListItem Value="History">History</asp:ListItem>
                                        <asp:ListItem Value="Humanities">Humanities</asp:ListItem>
                                        <asp:ListItem Value="Human Resource Management">Human Resource Management</asp:ListItem>
                                        <asp:ListItem Value="Industrial & Systems Engineering">Industrial & Systems Engineering</asp:ListItem>
                                        <asp:ListItem Value="Information Technology Management">Information Technology Management</asp:ListItem>
                                        <asp:ListItem Value="Integrated Science">Integrated Science</asp:ListItem>
                                        <asp:ListItem Value="International Studies">International Studies</asp:ListItem>
                                        <asp:ListItem Value="Liberal Studies">Liberal Studies</asp:ListItem>
                                        <asp:ListItem Value="Management">Management</asp:ListItem>
                                        <asp:ListItem Value="Manufacturing Engineering">Manufacturing Engineering</asp:ListItem>
                                        <asp:ListItem Value="Marketing">Marketing</asp:ListItem>
                                        <asp:ListItem Value="Mathematics">Mathematics</asp:ListItem>
                                        <asp:ListItem Value="Mechanical Engineering">Mechanical Engineering</asp:ListItem>
                                        <asp:ListItem Value="Microbiology">Microbiology</asp:ListItem>
                                        <asp:ListItem Value="Other/Not Listed">Other/Not Listed</asp:ListItem>
                                        <asp:ListItem Value="Philosophy">Philosophy</asp:ListItem>
                                        <asp:ListItem Value="Physics">Physics</asp:ListItem>
                                        <asp:ListItem Value="Political Science">Political Science</asp:ListItem>
                                        <asp:ListItem Value="Pre-Business">Pre-Business</asp:ListItem>
                                        <asp:ListItem Value="Pre-Dentistry">Pre-Dentistry</asp:ListItem>
                                        <asp:ListItem Value="Pre-Law">Pre-Law</asp:ListItem>
                                        <asp:ListItem Value="Pre-Medicine">Pre-Medicine</asp:ListItem>
                                        <asp:ListItem Value="Pre-Optometry">Pre-Optometry</asp:ListItem>
                                        <asp:ListItem Value="Pre-Pharmacy">Pre-Pharmacy</asp:ListItem>
                                        <asp:ListItem Value="Pre-Physical Therapy">Pre-Physical Therapy</asp:ListItem>
                                        <asp:ListItem Value="Pre-Physician Assistant">Pre-Physician Assistant</asp:ListItem>
                                        <asp:ListItem Value="Pre-Veterinary">Pre-Veterinary</asp:ListItem>
                                        <asp:ListItem Value="Psychology">Psychology</asp:ListItem>
                                        <asp:ListItem Value="Reading">Reading</asp:ListItem>
                                        <asp:ListItem Value="Secondary Education">Secondary Education</asp:ListItem>
                                        <asp:ListItem Value="Social Studies">Social Studies</asp:ListItem>
                                        <asp:ListItem Value="Sociology">Sociology</asp:ListItem>
                                        <asp:ListItem Value="Software Engineering">Software Engineering</asp:ListItem>
                                        <asp:ListItem Value="Special Education">Special Education</asp:ListItem>
                                        <asp:ListItem Value="Supply Chain Management">Supply Chain Management</asp:ListItem>
                                        <asp:ListItem Value="Undecided">Undecided</asp:ListItem>
                                        <asp:ListItem Value="Urban and Regional Studies">Urban and Regional Studies</asp:ListItem>
                                        <asp:ListItem Value="Women's & Gender Studies">Women's & Gender Studies</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                            <p>
                                <asp:Label ID="GraduationDate" runat="server" AssociatedControlID="GraduationMonth">Graduation Date:</asp:Label>
                                <asp:DropDownList ID = "GraduationMonth" runat = "server">
                                    <asp:ListItem Value="">--</asp:ListItem>
                                    <asp:ListItem Value="January">January</asp:ListItem>
                                    <asp:ListItem Value="February">February</asp:ListItem>
                                    <asp:ListItem Value="March">March</asp:ListItem>
                                    <asp:ListItem Value="April">April</asp:ListItem>
                                    <asp:ListItem Value="May">May</asp:ListItem>
                                    <asp:ListItem Value="June">June</asp:ListItem>
                                    <asp:ListItem Value="July">July</asp:ListItem>
                                    <asp:ListItem Value="August">August</asp:ListItem>
                                    <asp:ListItem Value="September">September</asp:ListItem>
                                    <asp:ListItem Value="October">October</asp:ListItem>
                                    <asp:ListItem Value="November">November</asp:ListItem>
                                    <asp:ListItem Value="December">December</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID = "GradYearDropdown" runat = "server">
                                    <asp:ListItem Value = "">--</asp:ListItem>
                                </asp:DropDownList>
                            </p>
&nbsp;<p>
                                <asp:Label ID="EmployerLabel" runat="server" AssociatedControlID="EmployerBox">Employer:</asp:Label>
                                <asp:TextBox ID = "EmployerBox" runat="server" CssClass = "textEntry" TextMode="SingleLine"></asp:TextBox>
                            </p>
                        </fieldset>

                        <asp:Button ID="SearchButton" runat="server" Text="Search" ValidationGroup="SearchUserValidationGroup"
                        OnClientClick="OnSearchClick" PostBackUrl="SearchResults.aspx" />
                                 <span class = "failureNotification" >
                                     <asp:Literal ID = "EntryError" Visible="false" runat = "server"></asp:Literal>
                                 </span>
                        <p class="submitButton">
                            
                        </p>
                    </div>
</asp:Content>
