<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourses.aspx.cs" Inherits="SMTI_Online_Course_Registration.GUI.RegisterCourses" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Courses</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register Courses</h2>
            <asp:Label ID="lblSelectStudent" runat="server" Text="Select Student:"></asp:Label>
            <asp:DropDownList ID="ddlStudents" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStudents_SelectedIndexChanged"></asp:DropDownList>

            <asp:Label ID="lblSelectCourses" runat="server" Text="Select Courses:"></asp:Label>
            <asp:CheckBoxList ID="cblCourses" runat="server"></asp:CheckBoxList>

            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

            <h3>Registered Courses:</h3>
            <asp:GridView ID="gvRegisteredCourses" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="CourseNumber" HeaderText="Course Number" />
                    <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
                </Columns>
            </asp:GridView>
        </div>
        <p>
            <asp:Button ID="btnInfoPage" runat="server" OnClick="btnInfoPage_Click" Text="View All Info" />
        </p>
    </form>
</body>
</html>
