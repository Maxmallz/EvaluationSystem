using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntermediateLibrary;
using MainProgram.Forms;

namespace MainProgram
{
    public partial class LoginForm : Form
    {
        Models.Objects.UserObject.UserRole userRole;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            //validate user input
            if(Validation.isCredentialValid(usernameTxtBox, passwordTxtBox, errorProvider1))
            {
                string errorMsg;
                UserConnect userConnect = new UserConnect();

                userRole = userConnect.Login(usernameTxtBox.Text.Trim(), passwordTxtBox.Text.Trim(), out errorMsg);
                if (!userConnect.isLoginSuccessfull) { errorProvider1.SetError(usernameTxtBox, "Invalid Username or Password"); return;
                }
                switch (userRole)
                {
                    case Models.Objects.UserObject.UserRole.Admin:

                        Forms.Admin.AdminContainer adminContainer = new Forms.Admin.AdminContainer();
                        adminContainer.AdminFullName = userConnect.fullName;
                        this.Hide();
                        adminContainer.Show();

                        break;

                    case Models.Objects.UserObject.UserRole.Instructor:

                        Forms.Instructor.InstructorContainer instructorContainer = new Forms.Instructor.InstructorContainer();
                        instructorContainer.InstructorFullName = userConnect.fullName;
                        this.Hide();
                        instructorContainer.Show();

                        break;
                    case Models.Objects.UserObject.UserRole.Student:

                        Forms.Student.StudentContainer studentContainer = new Forms.Student.StudentContainer();
                        studentContainer.StudentFullName = userConnect.fullName;
                        this.Hide();
                        studentContainer.Show();

                        break;
                    default:
                        break;
                }
            }
            //if valid get user fullName and open Admin, Instructor or Student form
            //else show error msg
        }
        private void forgotPasswordLabel_Click(object sender, EventArgs e)
        {
            //open forgot password form
        }
    }
}
