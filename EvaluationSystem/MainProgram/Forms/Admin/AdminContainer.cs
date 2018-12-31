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
        public AdminContainer()
        {
            InitializeComponent();
        }

        private void courseTabPage_Click(object sender, EventArgs e)
        {

        }

        private void AdminContainer_Load(object sender, EventArgs e)
        {
            userFullNameLabel.Text = "Signed in as First Name";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
