<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListStudentsAndCourses.aspx.cs" Inherits="SMTI_Online_Course_Registration.GUI.ListStudentsAndCourses" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List of Students, Courses, and Users</title>
    <style>
        h2 {
            text-align: center;
        }
        table {
            margin: 0 auto;
            width: 80%;
        }
        th, td {
            padding: 10px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>List of Students</h2>
        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" CssClass="table">
            <Columns>
                <asp:BoundField DataField="StudentNumber" HeaderText="Student Number" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
            </Columns>
        </asp:GridView>

        <h2>List of Courses</h2>
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" CssClass="table">
            <Columns>
                <asp:BoundField DataField="CourseNumber" HeaderText="Course Number" />
                <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
                <asp:BoundField DataField="TotalHour" HeaderText="Total Hour" />
            </Columns>
        </asp:GridView>

        <h2>List of Users</h2>
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" CssClass="table">
            <Columns>
                <asp:BoundField DataField="UserCode" HeaderText="User Code" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
