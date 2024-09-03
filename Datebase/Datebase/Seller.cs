﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase
{
    internal class Seller : User
    {
        /// <summary>
        /// المنتجات يلي عند هاد البياع
        /// </summary>
        public List<Product> Products { get; set; }
    }
}
