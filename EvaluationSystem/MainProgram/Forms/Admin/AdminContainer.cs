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

            instructorDataGridView.DataSource = adminConnect.GetInstructors();
            FormClass.AddDatagridButtons(instructorDataGridView, 3, true);

            studentDataGridView.DataSource = adminConnect.GetStudents();
            FormClass.AddDatagridButtons(studentDataGridView, 3, true);

            classDataGridView.DataSource = adminConnect.GetClasses();
            FormClass.AddDatagridButtons(classDataGridView, 3, true);

            rubricDataGridView.DataSource = adminConnect.GetRubric();
            FormClass.AddDatagridButtons(rubricDataGridView, 3, true);

            courseDataGridView.DataSource = adminConnect.GetCourse();
            FormClass.AddDatagridButtons(courseDataGridView, 3, true);

            //bind view instructor data table
            //bind view student data table
            //bind view class data table
            //bind view course data table
            //bind view rubric data table

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
