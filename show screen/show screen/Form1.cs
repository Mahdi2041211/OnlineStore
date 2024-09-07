using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace show_screen
{
    public partial class Form1 : Form
    {
        private int x = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Blue,x,0,2700,50);
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Point Current = panel1.AutoScrollPosition;
            Current.X = -Current.X;
            if (Current.X <= panel1.HorizontalScroll.Maximum)
            {
                Current.X += 20;
                panel1.AutoScrollPosition = Current;
                if (Current.X == 329)
                {
                    Current.X = panel1.HorizontalScroll.Maximum;
                }
            }
            if (Current.X == panel1.HorizontalScroll.Maximum)
            {
                Current.X = 0;
                panel1.AutoScrollPosition = Current;
                timer1.Stop();
            }
        }
        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        private void books_MouseMove(object sender, MouseEventArgs e)
        {
            books.Size = new Size(200, 200);
            books.BringToFront();
        }

        private void books_MouseLeave(object sender, EventArgs e)
        {
            books.Size = new Size(140, 120);
        }

        private void clothes_MouseMove(object sender, MouseEventArgs e)
        {
            clothes.Size = new Size(200, 200);
            clothes.BringToFront();
        }

        private void clothes_MouseLeave(object sender, EventArgs e)
        {
            clothes.Size = new Size(140, 120);
        }

        private void laptops_MouseLeave(object sender, EventArgs e)
        {
            laptops.Size = new Size(140, 120);
        }

        private void laptops_MouseMove(object sender, MouseEventArgs e)
        {
            laptops.Size = new Size(200, 200);
            laptops.BringToFront();
        }
    }
}
