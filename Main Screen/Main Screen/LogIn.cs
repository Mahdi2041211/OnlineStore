using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Screen
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Check(object sender, EventArgs e)
        {
            if (Password.Text == "" && name.Text == "")
            {
                MessageBox.Show("please enter the user name and password", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Password.Text != "" && name.Text == "")
            {
                MessageBox.Show("the user name field is empty", "Warning ?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (name.Text != "" && Password.Text == "")
            {
                MessageBox.Show("the password field is empty ", "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Password.Text.Length <= 5)
            {
                MessageBox.Show("Please enter a number of characters between 5 and 15 in the  password", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void Show_Password(object sender, EventArgs e)
        {
            if (Check_Box.Checked)
            {
                Password.UseSystemPasswordChar = true;
            }
            else
            {
                Password.UseSystemPasswordChar = false;
            }
        }
    }
}
