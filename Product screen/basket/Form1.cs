﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace basket
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void Discrip_Layout(object sender, LayoutEventArgs e)
        {
        }

        private void Product_Load(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;
            
        }
        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;
        }

        private void textBox1_HideSelectionChanged(object sender, EventArgs e)
        {
            
        }
    }
}
