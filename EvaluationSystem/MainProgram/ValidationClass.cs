using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntermediateLibrary;
using Models.Objects;
using System.Windows.Forms;

namespace MainProgram
{
    public static class Validation
    {
        public static bool isCredentialValid(TextBox usernameTxtBox, TextBox passwordTxtBox, ErrorProvider errorProvider)
        {
            bool _isValid = false;
            string username = usernameTxtBox.Text;
            string password = passwordTxtBox.Text;
            errorProvider.Clear();

            if (string.IsNullOrEmpty(username))//Empty Username
            {
                errorProvider.SetError(usernameTxtBox, "Username cannot be blank");
                usernameTxtBox.Focus();
            }
            else if (string.IsNullOrEmpty(password))//Empty Password
            {
                errorProvider.SetError(passwordTxtBox, "Password cannot be blank");
                passwordTxtBox.Focus();
            }
            else if (username.Length >= 50)//Long Username
            {
                errorProvider.SetError(usernameTxtBox, "Username cannot be more than 50 characters");
                usernameTxtBox.SelectAll();
                usernameTxtBox.Focus();
            }
            else if (password.Length <= 5)//Short password
            {
                errorProvider.SetError(passwordTxtBox, "Password must be more than 5 characters");
                passwordTxtBox.SelectAll();
                passwordTxtBox.Focus();
            }
            else { _isValid = true; }
            return _isValid;
        }
        public static bool isTextBoxValid(ErrorProvider errorProvider, params Control[] controls)
        {
            bool isValid = false;

            errorProvider.Clear();
            foreach (Control item in controls)
            {
                if (item.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(item, "Cannot be blank");
                    isValid = false;
                    break;
                }
                else
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}
