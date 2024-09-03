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


    public partial class Decorations : Form
    {
        System.Timers.Timer Timer;
        Form Form = new LogIn();

        public Decorations()
        {
            InitializeComponent();
            Timer = new System.Timers.Timer();
            Timer.Interval = 0.0000001;
            Timer.Elapsed += OnTimeEvent;
            Timer.Start();
            Form.Show();
        }

        private void Exit(object sender, EventArgs e)
        {
            Close();
        }
        private void OnTimeEvent(object sender, EventArgs e)
        {
                Form.Location = Location + new Size(new Point(150, 81));
        }

        private void Change_To_LogIn(object sender, EventArgs e)
        {
            Form.Close();
            Form = new LogIn();
            Form.Show();
        }

        private void Change_To_Products(object sender, EventArgs e)
        {
            Form.Close();
            Form = new DisplayProduct();
            Form.Show();
        }
    }
}
