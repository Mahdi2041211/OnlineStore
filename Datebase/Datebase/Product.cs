﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase
{
    internal class Product : Products_Comments
    {
        /// <summary>
        /// مسارات الصور اللي لهاد المنتج.
        /// </summary>
        public List<string> Photos {  get; set; }
    }
}
