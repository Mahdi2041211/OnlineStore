using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_market_applicatinon_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_minmize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            if (textBox_pass.Text == "" && textBox_user.Text == "")
            {
                MessageBox.Show("please enter the user name and password", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox_pass.Text != "" && textBox_user.Text == "")
            {
                MessageBox.Show("the user name field is empty", "Warning ?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox_user.Text != "" && textBox_pass.Text == "")
            {
                MessageBox.Show("the password field is empty ", "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox_pass.Text.Length <= 5)
            {
                MessageBox.Show("Please enter a number of characters between 5 and 15 in the  password", "Error",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void checkBox_show_CheckedChanged(object sender, EventArgs e)
        {
           textBox_pass.UseSystemPasswordChar= checkBox_show.Checked?
           textBox_pass.UseSystemPasswordChar = true : textBox_pass.UseSystemPasswordChar = false;   
        }

        

        private void pictureBox_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

    }
}

   


