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
                                    <asp:ListItem Value="1900">1900</asp:ListItem>
                                    <asp:ListItem Value="1901">1901</asp:ListItem>
                                    <asp:ListItem Value="1902">1902</asp:ListItem>
                                    <asp:ListItem Value="1903">1903</asp:ListItem>
                                    <asp:ListItem Value="1904">1904</asp:ListItem>
                                    <asp:ListItem Value="1905">1905</asp:ListItem>
                                    <asp:ListItem Value="1906">1906</asp:ListItem>
                                    <asp:ListItem Value="1907">1907</asp:ListItem>
                                    <asp:ListItem Value="1908">1908</asp:ListItem>
                                    <asp:ListItem Value="1909">1909</asp:ListItem>
                                    <asp:ListItem Value="1910">1910</asp:ListItem>
                                    <asp:ListItem Value="1911">1911</asp:ListItem>
                                    <asp:ListItem Value="1912">1912</asp:ListItem>
                                    <asp:ListItem Value="1913">1913</asp:ListItem>
                                    <asp:ListItem Value="1914">1914</asp:ListItem>
                                    <asp:ListItem Value="1915">1915</asp:ListItem>
                                    <asp:ListItem Value="1916">1916</asp:ListItem>
                                    <asp:ListItem Value="1917">1917</asp:ListItem>
                                    <asp:ListItem Value="1918">1918</asp:ListItem>
                                    <asp:ListItem Value="1919">1919</asp:ListItem>
                                    <asp:ListItem Value="1920">1920</asp:ListItem>
                                    <asp:ListItem Value="1921">1921</asp:ListItem>
                                    <asp:ListItem Value="1922">1922</asp:ListItem>
                                    <asp:ListItem Value="1923">1923</asp:ListItem>
                                    <asp:ListItem Value="1924">1924</asp:ListItem>
                                    <asp:ListItem Value="1925">1925</asp:ListItem>
                                    <asp:ListItem Value="1926">1926</asp:ListItem>
                                    <asp:ListItem Value="1927">1927</asp:ListItem>
                                    <asp:ListItem Value="1928">1928</asp:ListItem>
                                    <asp:ListItem Value="1929">1929</asp:ListItem>
                                    <asp:ListItem Value="1930">1930</asp:ListItem>
                                    <asp:ListItem Value="1931">1931</asp:ListItem>
                                    <asp:ListItem Value="1932">1932</asp:ListItem>
                                    <asp:ListItem Value="1933">1933</asp:ListItem>
                                    <asp:ListItem Value="1934">1934</asp:ListItem>
                                    <asp:ListItem Value="1935">1935</asp:ListItem>
                                    <asp:ListItem Value="1936">1936</asp:ListItem>
                                    <asp:ListItem Value="1937">1937</asp:ListItem>
                                    <asp:ListItem Value="1938">1938</asp:ListItem>
                                    <asp:ListItem Value="1939">1939</asp:ListItem>
                                    <asp:ListItem Value="1940">1940</asp:ListItem>
                                    <asp:ListItem Value="1941">1941</asp:ListItem>
                                    <asp:ListItem Value="1942">1942</asp:ListItem>
                                    <asp:ListItem Value="1943">1943</asp:ListItem>
                                    <asp:ListItem Value="1944">1944</asp:ListItem>
                                    <asp:ListItem Value="1945">1945</asp:ListItem>
                                    <asp:ListItem Value="1946">1946</asp:ListItem>
                                    <asp:ListItem Value="1947">1947</asp:ListItem>
                                    <asp:ListItem Value="1948">1948</asp:ListItem>
                                    <asp:ListItem Value="1949">1949</asp:ListItem>
                                    <asp:ListItem Value="1950">1950</asp:ListItem>
                                    <asp:ListItem Value="1951">1951</asp:ListItem>
                                    <asp:ListItem Value="1952">1952</asp:ListItem>
                                    <asp:ListItem Value="1953">1953</asp:ListItem>
                                    <asp:ListItem Value="1954">1954</asp:ListItem>
                                    <asp:ListItem Value="1955">1955</asp:ListItem>
                                    <asp:ListItem Value="1956">1956</asp:ListItem>
                                    <asp:ListItem Value="1957">1957</asp:ListItem>
                                    <asp:ListItem Value="1958">1958</asp:ListItem>
                                    <asp:ListItem Value="1959">1959</asp:ListItem>
                                    <asp:ListItem Value="1960">1960</asp:ListItem>
                                    <asp:ListItem Value="1961">1961</asp:ListItem>
                                    <asp:ListItem Value="1962">1962</asp:ListItem>
                                    <asp:ListItem Value="1963">1963</asp:ListItem>
                                    <asp:ListItem Value="1964">1964</asp:ListItem>
                                    <asp:ListItem Value="1965">1965</asp:ListItem>
                                    <asp:ListItem Value="1966">1966</asp:ListItem>
                                    <asp:ListItem Value="1967">1967</asp:ListItem>
                                    <asp:ListItem Value="1968">1968</asp:ListItem>
                                    <asp:ListItem Value="1969">1969</asp:ListItem>
                                    <asp:ListItem Value="1970">1970</asp:ListItem>
                                    <asp:ListItem Value="1971">1971</asp:ListItem>
                                    <asp:ListItem Value="1972">1972</asp:ListItem>
                                    <asp:ListItem Value="1973">1973</asp:ListItem>
                                    <asp:ListItem Value="1974">1974</asp:ListItem>
                                    <asp:ListItem Value="1975">1975</asp:ListItem>
                                    <asp:ListItem Value="1976">1976</asp:ListItem>
                                    <asp:ListItem Value="1977">1977</asp:ListItem>
                                    <asp:ListItem Value="1978">1978</asp:ListItem>
                                    <asp:ListItem Value="1979">1979</asp:ListItem>
                                    <asp:ListItem Value="1980">1980</asp:ListItem>
                                    <asp:ListItem Value="1981">1981</asp:ListItem>
                                    <asp:ListItem Value="1982">1982</asp:ListItem>
                                    <asp:ListItem Value="1983">1983</asp:ListItem>
                                    <asp:ListItem Value="1984">1984</asp:ListItem>
                                    <asp:ListItem Value="1985">1985</asp:ListItem>
                                    <asp:ListItem Value="1986">1986</asp:ListItem>
                                    <asp:ListItem Value="1987">1987</asp:ListItem>
                                    <asp:ListItem Value="1988">1988</asp:ListItem>
                                    <asp:ListItem Value="1989">1989</asp:ListItem>
                                    <asp:ListItem Value="1990">1990</asp:ListItem>
                                    <asp:ListItem Value="1991">1991</asp:ListItem>
                                    <asp:ListItem Value="1992">1992</asp:ListItem>
                                    <asp:ListItem Value="1993">1993</asp:ListItem>
                                    <asp:ListItem Value="1994">1994</asp:ListItem>
                                    <asp:ListItem Value="1995">1995</asp:ListItem>
                                    <asp:ListItem Value="1996">1996</asp:ListItem>
                                    <asp:ListItem Value="1997">1997</asp:ListItem>
                                    <asp:ListItem Value="1998">1998</asp:ListItem>
                                    <asp:ListItem Value="1999">1999</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="2001">2001</asp:ListItem>
                                    <asp:ListItem Value="2002">2002</asp:ListItem>
                                    <asp:ListItem Value="2003">2003</asp:ListItem>
                                    <asp:ListItem Value="2004">2004</asp:ListItem>
                                    <asp:ListItem Value="2005">2005</asp:ListItem>
                                    <asp:ListItem Value="2006">2006</asp:ListItem>
                                    <asp:ListItem Value="2007">2007</asp:ListItem>
                                    <asp:ListItem Value="2008">2008</asp:ListItem>
                                    <asp:ListItem Value="2009">2009</asp:ListItem>
                                    <asp:ListItem Value="2010">2010</asp:ListItem>
                                    <asp:ListItem Value="2011">2011</asp:ListItem>
                                    <asp:ListItem Value="2012">2012</asp:ListItem>
                                    <asp:ListItem Value="2013">2013</asp:ListItem>
                                    <asp:ListItem Value="2014">2014</asp:ListItem>
                                    <asp:ListItem Value="2015">2015</asp:ListItem>
                                    <asp:ListItem Value="2016">2016</asp:ListItem>
                                    <asp:ListItem Value="2017">2017</asp:ListItem>
                                    <asp:ListItem Value="2018">2018</asp:ListItem>
                                    <asp:ListItem Value="2019">2019</asp:ListItem>
                                    <asp:ListItem Value="2020">2020</asp:ListItem>
                                </asp:DropDownList>
                            </p>
&nbsp;<p>
                                <asp:Label ID="EmployerLabel" runat="server" AssociatedControlID="EmployerBox">Employer:</asp:Label>
                                <asp:TextBox ID = "EmployerBox" runat="server" CssClass = "textEntry" TextMode="SingleLine"></asp:TextBox>
                            </p>
                        </fieldset>

                        <asp:Button ID="SearchButton" runat="server" Text="Search" ValidationGroup="SearchUserValidationGroup"
                        OnClientClick="OnSearchClick" PostBackUrl="SearchResults.aspx" 
                            onclick="SearchButton_Click" />
                                 <span class = "failureNotification" >
                                     <asp:Literal ID = "EntryError" Visible="false" runat = "server"></asp:Literal>
                                 </span>
                        <p class="submitButton">
                            
                        </p>
                    </div>
</asp:Content>
