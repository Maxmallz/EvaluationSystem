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
using CommonLibrary;

namespace MainProgram.Forms.Admin
{
    public partial class AdminContainer : Form
    {
        public string AdminFullName = string.Empty;
        DataTable insTbl, stuTbl, claTbl, couTbl, rubTbl;
        BindingSource instructorBindingSrc, studentBindingSrc, classBindingSrc, courseBindingSrc, rubricBindingSrc;
        public AdminContainer()
        {
            InitializeComponent();
        }

        private void AdminContainer_Load(object sender, EventArgs e)
        {
            //display logged in user
            userFullNameLabel.Text = string.IsNullOrEmpty(AdminFullName) ? AdminFullName : "Logged in as " + AdminFullName;

            //populate datagrid view with data
            AdminConnect adminConnect = new AdminConnect();

            insTbl = adminConnect.GetInstructors();
            instructorDataGridView.DataSource = insTbl;
            FormClass.AddDatagridButtons(instructorDataGridView, 3, true);

            stuTbl = adminConnect.GetStudents();
            studentDataGridView.DataSource = stuTbl;
            FormClass.AddDatagridButtons(studentDataGridView, 3, true);

            claTbl = adminConnect.GetClasses();
            classDataGridView.DataSource = claTbl;
            FormClass.AddDatagridButtons(classDataGridView, 3, true);

            rubTbl = adminConnect.GetRubric();
            rubricDataGridView.DataSource = rubTbl;
            FormClass.AddDatagridButtons(rubricDataGridView, 3, true);

            couTbl = adminConnect.GetCourse();
            courseDataGridView.DataSource = couTbl;
            FormClass.AddDatagridButtons(courseDataGridView, 3, true);

            //bind views to datatable
            #region BindInstructor
            try
            {
                instructorBindingSrc = new BindingSource();
                instructorBindingSrc.DataSource = adminConnect.GetInstructors();
                IuserIdViewComboBox.Items.Clear();
                IuserIdViewComboBox.DataSource = instructorBindingSrc;
                IuserIdViewComboBox.ValueMember = "userId";
                IuserIdViewComboBox.DisplayMember = "userId";
                IuserIdViewComboBox.DataBindings.Add("Text", instructorBindingSrc, "userId", false);

                if (!string.IsNullOrEmpty((string)IuserIdViewComboBox.SelectedValue) && !string.IsNullOrEmpty(IuserIdViewComboBox.Text))
                {
                    //bind other controls
                    iPasswordViewtextBox.DataBindings.Add("Text", instructorBindingSrc, "password", false);
                    iFirstNameViewtextBox.DataBindings.Add("Text", instructorBindingSrc, "fName", false);
                    iLastNameViewTextBox.DataBindings.Add("Text", instructorBindingSrc, "lName", false);
                    iEmailViewTextBox.DataBindings.Add("Text", instructorBindingSrc, "email", false);
                    iPhoneViewTextBox.DataBindings.Add("Text", instructorBindingSrc, "phone", false);
                }
                else
                {
                    errorProvider1.SetError(IuserIdViewComboBox, "Invalid selection");
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
            #endregion

            #region BindStudent
            try
            {
                studentBindingSrc = new BindingSource();
            }
            catch (Exception)
            {
                throw;
            }
            #endregion

            #region BindClass
            try
            {
                classBindingSrc = new BindingSource();
            }
            catch (Exception)
            {
                throw;
            }
            #endregion

            #region BindCourse
            try
            {
                courseBindingSrc = new BindingSource();
            }
            catch (Exception)
            {
                throw;
            }
            #endregion

            #region BindRubric
            try
            {
                rubricBindingSrc = new BindingSource();
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        private void IupdateTableBtn_Click(object sender, EventArgs e)
        {
            //reload datagrid table
        }

        private void IclearBtn_Click(object sender, EventArgs e)
        {
            //clear instructor details
        }

        private void iUpdateBtn_Click(object sender, EventArgs e)
        {
            //validate input
            //update instructor details
        }

        private void iAddBtn_Click(object sender, EventArgs e)
        {
            //validate input
            //add instructor details

            if (!Validation.isTextBoxValid(errorProvider1, IuserIdTxtBox, iPasswordTxtBox, iFirstNameTxtBox, iLastNameTxtBox, iEmailTxtBox, iPhoneTxtBox)){return;}
            //add instructor
        }

        private void IuserIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //display instructor details
        }

        private void sClearButton_Click(object sender, EventArgs e)
        {

        }

        private void instructortabPage_Enter(object sender, EventArgs e)
        {
            
        }

        private void rubricGroupBox_Enter(object sender, EventArgs e)
        {
            
        }

        private void rubricTabPage_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
