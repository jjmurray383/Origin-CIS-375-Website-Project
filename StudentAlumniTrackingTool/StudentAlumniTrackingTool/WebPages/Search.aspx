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
                            <legend>Profile Information</legend>
                            <p>
                                <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstNameBox">First Name:</asp:Label>
                                <asp:TextBox ID="FirstNameBox" runat="server" CssClass="textEntry" TextMode="SingleLine" MaxLength="20"></asp:TextBox>
                            </p> 
                            <p>
                                <asp:Label ID="MiddleInitialLabel" runat="server" AssociatedControlID="MiddleInitialBox">Middle Initial:</asp:Label>
                                <asp:TextBox ID="MiddleInitialBox" runat="server" CssClass="textEntry" TextMode="SingleLine" Width="30" MaxLength="1"></asp:TextBox>
                                
                            </p>
                            <p>
                                <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastNameBox">Last Name:</asp:Label>
                                <asp:TextBox ID="LastNameBox" runat="server" CssClass="textEntry" TextMode="SingleLine" MaxLength="25"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="PhoneNumLabel" runat="server" AssociatedControlID="PhoneNumBox">Phone Number:</asp:Label>
                                <asp:TextBox ID="PhoneNumBox" runat="server" CssClass="textEntry" TextMode="SingleLine" MaxLength="10"></asp:TextBox>
                                <asp:RegularExpressionValidator ID = "PhoneNumberValidator" ControlToValidate = "PhoneNumBox" ValidationExpression = "\d{10}"
                                ErrorMessage = "Invalid phone number." runat="server">Format: 1234567890</asp:RegularExpressionValidator> 
                            </p>
                            <strong>Address</strong>
                            <p>
                                <asp:Label ID="StreetNumLabel" runat="server" AssociatedControlID="StreetBox">Number/street:</asp:Label>
                                <asp:TextBox ID="StreetBox" runat="server" CssClass="textEntry" TextMode="SingleLine" MaxLength="25"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="CityLabel" runat="server" AssociatedControlID="CityBox">City:</asp:Label>
                                <asp:TextBox ID="CityBox" runat="server" CssClass="textEntry" TextMode="SingleLine" MaxLength="25"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="StateDropdownLabel" runat="server" AssociatedControlID="StateDropdown">State:</asp:Label>
                                <asp:DropDownList ID="StateDropdown" runat="server" CssClass="textEntry">
                                    <asp:ListItem Value="--">--</asp:ListItem>
                                    <asp:ListItem Value="AL">Alabama</asp:ListItem>
	                                <asp:ListItem Value="AK">Alaska</asp:ListItem>
	                                <asp:ListItem Value="AZ">Arizona</asp:ListItem>
	                                <asp:ListItem Value="AR">Arkansas</asp:ListItem>
	                                <asp:ListItem Value="CA">California</asp:ListItem>
	                                <asp:ListItem Value="CO">Colorado</asp:ListItem>
	                                <asp:ListItem Value="CT">Connecticut</asp:ListItem>
	                                <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
	                                <asp:ListItem Value="DE">Delaware</asp:ListItem>
	                                <asp:ListItem Value="FL">Florida</asp:ListItem>
	                                <asp:ListItem Value="GA">Georgia</asp:ListItem>
	                                <asp:ListItem Value="HI">Hawaii</asp:ListItem>
	                                <asp:ListItem Value="ID">Idaho</asp:ListItem>
	                                <asp:ListItem Value="IL">Illinois</asp:ListItem>
	                                <asp:ListItem Value="IN">Indiana</asp:ListItem>
	                                <asp:ListItem Value="IA">Iowa</asp:ListItem>
	                                <asp:ListItem Value="KS">Kansas</asp:ListItem>
	                                <asp:ListItem Value="KY">Kentucky</asp:ListItem>
	                                <asp:ListItem Value="LA">Louisiana</asp:ListItem>
	                                <asp:ListItem Value="ME">Maine</asp:ListItem>
	                                <asp:ListItem Value="MD">Maryland</asp:ListItem>
	                                <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
	                                <asp:ListItem Value="MI">Michigan</asp:ListItem>
	                                <asp:ListItem Value="MN">Minnesota</asp:ListItem>
	                                <asp:ListItem Value="MS">Mississippi</asp:ListItem>
	                                <asp:ListItem Value="MO">Missouri</asp:ListItem>
	                                <asp:ListItem Value="MT">Montana</asp:ListItem>
	                                <asp:ListItem Value="NE">Nebraska</asp:ListItem>
	                                <asp:ListItem Value="NV">Nevada</asp:ListItem>
	                                <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
	                                <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
	                                <asp:ListItem Value="NM">New Mexico</asp:ListItem>
	                                <asp:ListItem Value="NY">New York</asp:ListItem>
	                                <asp:ListItem Value="NC">North Carolina</asp:ListItem>
	                                <asp:ListItem Value="ND">North Dakota</asp:ListItem>
	                                <asp:ListItem Value="OH">Ohio</asp:ListItem>
	                                <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
	                                <asp:ListItem Value="OR">Oregon</asp:ListItem>
	                                <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
	                                <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
	                                <asp:ListItem Value="SC">South Carolina</asp:ListItem>
	                                <asp:ListItem Value="SD">South Dakota</asp:ListItem>
	                                <asp:ListItem Value="TN">Tennessee</asp:ListItem>
	                                <asp:ListItem Value="TX">Texas</asp:ListItem>
	                                <asp:ListItem Value="UT">Utah</asp:ListItem>
	                                <asp:ListItem Value="VT">Vermont</asp:ListItem>
	                                <asp:ListItem Value="VA">Virginia</asp:ListItem>
	                                <asp:ListItem Value="WA">Washington</asp:ListItem>
	                                <asp:ListItem Value="WV">West Virginia</asp:ListItem>
	                                <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
	                                <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                            <p>
                                <asp:Label ID="ZIPLabel" runat="server" AssociatedControlID="ZIPBox">US ZIP Code:</asp:Label>
                                <asp:TextBox ID="ZIPBox" runat="server" CssClass="textEntry" TextMode="SingleLine" Width = "55" MaxLength="5">
                                </asp:TextBox>
                            </p>
                            <strong>Education Info</strong>
                            <p>
                                <asp:Label ID="UniversityLabel" runat="server" AssociatedControlID="UniversityBox">College/University Name:</asp:Label>
                                <asp:TextBox ID="UniversityBox" runat="server" CssClass="textEntry" TextMode="SingleLine"></asp:TextBox>
                            </p>
                             <p>
                                <asp:Label ID="DegreeDropdownLabel" runat="server" AssociatedControlID="DegreeDropdown">Degree Level:</asp:Label>
                                <asp:DropDownList ID = "DegreeDropdown" runat = "server">
                                    <asp:ListItem Value="">--</asp:ListItem>
                                    <asp:ListItem Value="Associate's">Associate's</asp:ListItem>
                                    <asp:ListItem Value="Bachelor's">Bachelor's</asp:ListItem>
                                    <asp:ListItem Value="Master's">Master's</asp:ListItem>
                                    <asp:ListItem Value="Ph. D">Ph. D</asp:ListItem>
                                </asp:DropDownList>
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
                                <asp:Label ID="MinorDropdownLabel" runat="server" AssociatedControlID="MinorDropdown">Minor:</asp:Label>
                                <asp:DropDownList ID = "MinorDropdown" runat = "server">
                                     <asp:ListItem Value="">--------------</asp:ListItem>
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
                                <asp:Label ID="GPALabel" runat="server" AssociatedControlID="GPABox">GPA:</asp:Label>
                                <asp:TextBox ID = "GPABox" runat = "server" MaxLength = "10"> </asp:TextBox>
                                <asp:RegularExpressionValidator ID = "GPAValidator" ControlToValidate = "GPABox" ValidationExpression = "\d{0,10}.?\d{0,10}"
                                ErrorMessage = "Invalid GPA." runat="server">Format: 0.000 (4 point scale)</asp:RegularExpressionValidator> 
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
                             <p>
                                <asp:Label ID="UnviersityEmailLabel" runat="server" AssociatedControlID="UnviersityEmailBox">School Email:</asp:Label>
                                <asp:TextBox ID = "UnviersityEmailBox" runat="server" CssClass = "textEntry" TextMode="SingleLine"></asp:TextBox>
                            </p>
                        <strong>Current Employer Info</strong>
                            <p>
                                <asp:Label ID="EmployerLabel" runat="server" AssociatedControlID="EmployerBox">Employer Name:</asp:Label>
                                <asp:TextBox ID = "EmployerBox" runat="server" CssClass = "textEntry" TextMode="SingleLine"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="EmployeeTitleLabel" runat="server" AssociatedControlID="EmployeeTitleBox">Title/Position:</asp:Label>
                                <asp:TextBox ID = "EmployeeTitleBox" runat="server" CssClass = "textEntry" TextMode="SingleLine"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="ScheduleLabel" runat="server" AssociatedControlID="ScheduleBox">Schedule:</asp:Label>
                                <asp:TextBox ID = "ScheduleBox" runat="server" CssClass = "textEntry" TextMode="SingleLine"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="EmployerContactInfoLabel" runat="server" AssociatedControlID="EmployerContactInfoBox">Contact Info:</asp:Label>
                                <asp:TextBox ID = "EmployerContactInfoBox" runat="server" CssClass = "textEntry" TextMode="SingleLine"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="EmployerEmailLabel" runat="server" AssociatedControlID="EmployerEmailBox">Email:</asp:Label>
                                <asp:TextBox ID = "EmployerEmailBox" runat="server" CssClass = "textEntry" TextMode="SingleLine"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="EmployerStartDateLabel" runat="server" AssociatedControlID="EmployerStartDateDDDay">Start Date:</asp:Label>
                                <asp:DropDownList ID = "EmployerStartDateDDDay" runat = "server">
                                    <asp:ListItem Value="--">--</asp:ListItem>
                                    <asp:ListItem Value="01">1</asp:ListItem>
                                    <asp:ListItem Value="02">2</asp:ListItem>
                                    <asp:ListItem Value="03">3</asp:ListItem>
                                    <asp:ListItem Value="04">4</asp:ListItem>
                                    <asp:ListItem Value="05">5</asp:ListItem>
                                    <asp:ListItem Value="06">6</asp:ListItem>
                                    <asp:ListItem Value="07">7</asp:ListItem>
                                    <asp:ListItem Value="08">8</asp:ListItem>
                                    <asp:ListItem Value="09">9</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="13">13</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                    <asp:ListItem Value="16">16</asp:ListItem>
                                    <asp:ListItem Value="17">17</asp:ListItem>
                                    <asp:ListItem Value="18">18</asp:ListItem>
                                    <asp:ListItem Value="19">19</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="21">21</asp:ListItem>
                                    <asp:ListItem Value="22">22</asp:ListItem>
                                    <asp:ListItem Value="23">23</asp:ListItem>
                                    <asp:ListItem Value="24">24</asp:ListItem>
                                    <asp:ListItem Value="25">25</asp:ListItem>
                                    <asp:ListItem Value="26">26</asp:ListItem>
                                    <asp:ListItem Value="27">27</asp:ListItem>
                                    <asp:ListItem Value="28">28</asp:ListItem>
                                    <asp:ListItem Value="29">29</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                    <asp:ListItem Value="31">31</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID = "EmployerStartDateDDMonth" runat = "server">
                                    <asp:ListItem Value="--">--</asp:ListItem>
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID = "EmployerStartDateDDYear" runat = "server">
                                    <asp:ListItem Value="--">--</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                            <p>
                                <asp:Label ID="EmployerEndDateLabel" runat="server" AssociatedControlID="EmployerEndDateDay">End Date:</asp:Label>
                                <asp:DropDownList ID = "EmployerEndDateDay" runat = "server">
                                    <asp:ListItem Value="--">--</asp:ListItem>
                                    <asp:ListItem Value="01">1</asp:ListItem>
                                    <asp:ListItem Value="02">2</asp:ListItem>
                                    <asp:ListItem Value="03">3</asp:ListItem>
                                    <asp:ListItem Value="04">4</asp:ListItem>
                                    <asp:ListItem Value="05">5</asp:ListItem>
                                    <asp:ListItem Value="06">6</asp:ListItem>
                                    <asp:ListItem Value="07">7</asp:ListItem>
                                    <asp:ListItem Value="08">8</asp:ListItem>
                                    <asp:ListItem Value="09">9</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="13">13</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                    <asp:ListItem Value="16">16</asp:ListItem>
                                    <asp:ListItem Value="17">17</asp:ListItem>
                                    <asp:ListItem Value="18">18</asp:ListItem>
                                    <asp:ListItem Value="19">19</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="21">21</asp:ListItem>
                                    <asp:ListItem Value="22">22</asp:ListItem>
                                    <asp:ListItem Value="23">23</asp:ListItem>
                                    <asp:ListItem Value="24">24</asp:ListItem>
                                    <asp:ListItem Value="25">25</asp:ListItem>
                                    <asp:ListItem Value="26">26</asp:ListItem>
                                    <asp:ListItem Value="27">27</asp:ListItem>
                                    <asp:ListItem Value="28">28</asp:ListItem>
                                    <asp:ListItem Value="29">29</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                    <asp:ListItem Value="31">31</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID = "EmployerEndDateMonth" runat = "server">
                                    <asp:ListItem Value="--">--</asp:ListItem>
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID = "EmployerEndDateYear" runat = "server">
                                    <asp:ListItem Value="--">--</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                            <strong>Employment History:</strong>
                            <p>
                                <asp:Label ID="EmployerHistoryLabel" runat="server" AssociatedControlID="EmployerHistoryBox">Previous Employer Name:</asp:Label>
                                <asp:TextBox ID = "EmployerHistoryBox" runat="server" CssClass = "textEntry" TextMode="SingleLine"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="EmployerHistoryTitleLabel" runat="server" AssociatedControlID="EmployerHistoryTitleBox">Title/Position:</asp:Label>
                                <asp:TextBox ID = "EmployerHistoryTitleBox" runat="server" CssClass = "textEntry" TextMode="SingleLine"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="EmployerHistoryEmailLabel" runat="server" AssociatedControlID="EmployerHistoryEmailBox">Email:</asp:Label>
                                <asp:TextBox ID = "EmployerHistoryEmailBox" runat="server" CssClass = "textEntry" TextMode="SingleLine"></asp:TextBox>
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
