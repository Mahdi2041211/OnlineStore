﻿using System;
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
                    Current.X += 650;
                    panel1.AutoScrollPosition = Current;
                }
            if (Current.X == 3228)
            {
                timer1.Stop();
                timer2.Start();
            }
        }
        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
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
            books.Size = new Size(140, 140);
        }

        private void clothes_MouseMove(object sender, MouseEventArgs e)
        {
            clothes.Size = new Size(200, 200);
            clothes.BringToFront();
        }

        private void clothes_MouseLeave(object sender, EventArgs e)
        {
            clothes.Size = new Size(140, 140);
        }

        private void laptops_MouseLeave(object sender, EventArgs e)
        {
            laptops.Size = new Size(140, 140);
        }

        private void laptops_MouseMove(object sender, MouseEventArgs e)
        {
            laptops.Size = new Size(200, 200);
            laptops.BringToFront();
        }

        private void mobiles_MouseMove(object sender, MouseEventArgs e)
        {
            mobiles.Location = new Point(140, 260);
            mobiles.Size = new Size(450, 340);
            mobiles.BringToFront();
        }

        private void mobiles_MouseLeave(object sender, EventArgs e)
        {
            mobiles.Location = new Point(160,340);
            mobiles.Size = new Size(370, 320);
        }

        private void elctronic_MouseMove(object sender, MouseEventArgs e)
        {
            elctronic.Size = new Size(200, 200);
            elctronic.BringToFront();
        }

        private void elctronic_MouseLeave(object sender, EventArgs e)
        {
            elctronic.Size = new Size(140, 140);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Point Current = panel1.AutoScrollPosition;
            Current.X = -Current.X;
            if (Current.X >= panel1.HorizontalScroll.Minimum)
            {
                Current.X -= 640;
                panel1.AutoScrollPosition = Current;
            }
            if (Current.X == -640)
            {
                timer2.Stop();
                timer1.Start();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
