﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase
{
    internal class Costomer : User
    {
        /// <summary>
        /// التعليقات يلي علقها هاد المستخدم
        /// </summary>
        public List<Comment> Comments { get; set; }
        /// <summary>
        /// سلة المشتريات يلي بدو المستخدم يشتريها
        /// </summary>
        public List<Product> Basket {  get; set; } 
    }
}
