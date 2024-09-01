using profile.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace profile
{
    public partial class Form1 : Form
    {
        public Image[] images;
        public Image[] dark;
        public Image[] Default;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void name_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (language.Checked)
            {
                Favorite.Text = "المفضلة";
                Money.Text = "الرصيد";
                Buttons.Text = "الطلبات";
                Notifications.Text = "الإشعارات";
                Titles.Text = "العناوين";
                Payments.Text = "الدفع";
                barcode.Text = "الكود الخاص بك";
                proves.Text = "الضمانات";
                account.Text = "حسابي";
                account.Location = new Point(433, 276);
                settings.Text = "الإعدادات";
                settings.Location = new Point(419, 589);
                language.Text = "العربية";
                language.Location = new Point(442, 632);
                DarkMode.Text = "الوضع المظلم";
                DarkMode.Location = new Point(404, 664);
            }
            else
            {
                Favorite.Text = "Favorite";
                Money.Text = "Money";
                Buttons.Text = "Orders";
                Notifications.Text = "Notifications";
                Titles.Text = "Titles";
                Payments.Text = "Payments";
                barcode.Text = "QR Code";
                proves.Text = "Proves";
                account.Text = "My Account";
                account.Location = new Point(12, 277);
                settings.Text = "Settings";
                settings.Location = new Point(12, 589);
                language.Text = "Arabic";
                language.Location = new Point(19, 632);
                DarkMode.Text = "Dark Mode";
                DarkMode.Location = new Point(19, 664);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "images(*.png;*.jpg;*.jpeg)|*.png||*.jpg";
            open.Title = "select a file";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string name = open.FileName;
                images = new Image[]
                {
                    Image.FromFile(name),

                };
                pictureBox1.Image = images[0];
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Favorite_Click(object sender, EventArgs e)
        {
            fav favorite = new fav();
            favorite.Show();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            dark = new Image[]
            {
                    Image.FromFile(@"C:\Users\DR.tech\source\repos\profile\profile\Resources\LightMode.png"),
                    Image.FromFile(@"C:\Users\DR.tech\source\repos\profile\profile\Resources\DarkMode.png")
            };
            if (DarkMode.Checked)
            {
                BackgroundImage = dark[1];
            }
            else
            {
                BackgroundImage = dark[0];
            }
        }
        ///C:\Users\DR.tech\source\repos\profile\profile\Resources\LightMode.png
        private void toolStripTextBox1_DoubleClick(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "")
            {
                DialogResult res = MessageBox.Show("nothing here to write", "nothing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("are you sure you want to rename the account to " + toolStripTextBox1.Text + "?", "notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    name.Text = toolStripTextBox1.Text;
                    if (!language.Checked)
                    {
                        if (toolStripTextBox1.Text == "")
                        {
                            name.Text = "enter your name";
                        }
                    }
                    else
                    {
                        if (toolStripTextBox1.Text == "")
                        {
                            name.Text = "ادخل اسمك";
                            name.TextAlign = ContentAlignment.TopLeft;
                        }
                    }
                    toolStripTextBox1.Text = "";
                }

                else
                {
                    name.Text = name.Text;
                    toolStripTextBox1.Text = "";
                }
            }
        }

        private void removePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void Notifications_Click(object sender, EventArgs e)
        {
            notifications note = new notifications();
            note.Show();
        }

        private void Orders_Click(object sender, EventArgs e)
        {
            orders orders = new orders();
            orders.Show();
        }

        private void Money_Click(object sender, EventArgs e)
        {
            money money = new money();
            money.Show();
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (toolStripTextBox1.Text == "")
                {
                    DialogResult res = MessageBox.Show("nothing here to write", "nothing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("are you sure you want to rename the account to " + toolStripTextBox1.Text + "?", "notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        name.Text = toolStripTextBox1.Text;
                        if (!language.Checked)
                        {
                            if (toolStripTextBox1.Text == "")
                            {
                                name.Text = "enter your name";
                            }
                        }
                        else
                        {
                            if (toolStripTextBox1.Text == "")
                            {
                                name.Text = "ادخل اسمك";
                                name.TextAlign = ContentAlignment.TopLeft;
                            }
                        }
                        toolStripTextBox1.Text = "";
                    }

                    else
                    {
                        name.Text = name.Text;
                        toolStripTextBox1.Text = "";
                    }
                }
            }
        }
    }
}
