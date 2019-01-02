using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            //loadinstructor data table
            //load student data table
            //load class data table
            //load course data table
            //load rubric data table

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
        }

        private void IuserIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //display instructor details
        }

        private void sClearButton_Click(object sender, EventArgs e)
        {

        }
    }
}
