using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase
{
    internal abstract class Products_Comments : Database
    {
        /// <summary>
        /// the owner of this item
        /// </summary>
        public string OwnerID { get; set; }
        /// <summary>
        /// the evaluation of this item
        /// </summary>
        public string Evaluation { get; set; }
    }
}
