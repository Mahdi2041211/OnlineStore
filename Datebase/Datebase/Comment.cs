using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase
{
    internal class Comment : Products_Comments
    {
        /// <summary>
        /// المنتج يلي هاد التعليق موجود عليه
        /// </summary>
        public Product Product { get; set; }
    }
}
