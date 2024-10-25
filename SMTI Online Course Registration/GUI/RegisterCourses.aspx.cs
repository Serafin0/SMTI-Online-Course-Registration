using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMTI_Online_Course_Registration.BLL;
using SMTI_Online_Course_Registration.DAL;

namespace SMTI_Online_Course_Registration.GUI
{
    public partial class RegisterCourses : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudents();
                LoadCourses();
            }
        }

        private void LoadStudents()
        {
            Student student = new Student();
            List<Student> students = student.GetAllStudents();

            ddlStudents.DataSource = students;
            ddlStudents.DataTextField = "StudentNumber"; // Display the student number
            ddlStudents.DataValueField = "StudentNumber"; // Use the student number as the value
            ddlStudents.DataBind();

            // Optionally, add a default item
            ddlStudents.Items.Insert(0, new ListItem("Select a Student", ""));
        }

        protected void ddlStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses(); // Load courses when a student is selected
        }

        protected void LoadCourses()
        {
            Course c = new Course();
            List<Course> courses = c.GetAllCourses();
            cblCourses.DataSource = courses;
            cblCourses.DataTextField = "CourseTitle";
            cblCourses.DataValueField = "CourseNumber";
            cblCourses.DataBind();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (ddlStudents.SelectedValue != "")
            {
                int studentNumber = Convert.ToInt32(ddlStudents.SelectedValue);
                Registration reg = new Registration();

                // Get the currently registered courses for the selected student
                List<Course> registeredCourses = reg.GetCoursesByStudentNumber(studentNumber);
                List<string> alreadyRegisteredCourseNumbers = registeredCourses.Select(c => c.CourseNumber).ToList();

                // Track the number of successfully registered courses
                int registeredCount = 0;

                // Validate course registration constraints
                foreach (ListItem item in cblCourses.Items)
                {
                    if (item.Selected)
                    {
                        string selectedCourseNumber = item.Value;

                        // Check if the student is already registered for this course
                        if (alreadyRegisteredCourseNumbers.Contains(selectedCourseNumber))
                        {
                            lblMessage.Text = $"The student is already registered for course {selectedCourseNumber}.";
                            continue;
                        }

                        // Increment the registration count to check for limits
                        registeredCount++;
                    }
                }

                // Calculate total courses after potential registration
                int totalCoursesAfterRegistration = registeredCourses.Count + registeredCount;

                // Check registration constraints
                if (totalCoursesAfterRegistration > 4)
                {
                    lblMessage.Text = "The student cannot register for more than 4 courses.";
                    return;
                }
                else if (totalCoursesAfterRegistration < 2)
                {
                    lblMessage.Text = "The student must register for at least 2 courses.";
                    return;
                }

                // Now, register the courses
                foreach (ListItem item in cblCourses.Items)
                {
                    if (item.Selected)
                    {
                        string selectedCourseNumber = item.Value;

                        // Register the course
                        reg.RegisterCourse(new Registration { StudentNumber = studentNumber, CourseNumber = selectedCourseNumber });
                    }
                }

                lblMessage.Text = $"{registeredCount} course(s) registered successfully!";

                // Load the registered courses for the selected student
                LoadRegisteredCourses(studentNumber);
            }
            else
            {
                lblMessage.Text = "Please select a student.";
            }
        }


        private void LoadRegisteredCourses(int studentNumber)
        {
            Registration reg = new Registration();
            List<Course> registeredCourses = reg.GetCoursesByStudentNumber(studentNumber);
            gvRegisteredCourses.DataSource = registeredCourses;
            gvRegisteredCourses.DataBind();
        }

        protected void btnInfoPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/ListStudentsAndCourses.aspx");
        }
    }
}
