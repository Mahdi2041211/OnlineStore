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
        Form2 form = new Form2();
        
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
            if (Form2.name == null || Form2.pass == null)
            {
                MessageBox.Show("you Don't have an email, Please Regstier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Password.Text == Form2.pass && UserName.Text == Form2.name)
                {
                    MessageBox.Show("welcome", "notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("sorry,either password or user name os wrong, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkBox_show_CheckedChanged(object sender, EventArgs e)
        {
           Password.UseSystemPasswordChar= checkBox_show.Checked?
           Password.UseSystemPasswordChar = true : Password.UseSystemPasswordChar = false;   
        }

        

        private void pictureBox_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_sign_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Hide();
        }
    }
}

   


