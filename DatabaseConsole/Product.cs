using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    public class Product : Database
    {
        /// <summary>
        /// مسارات الصور اللي لهاد المنتج.
        /// </summary>
        public List<string> Photos { get; set; } = new List<string>();
        /// <summary>
        /// التعليقات على المنتج
        /// </summary>
        public List<Comment> Comments { get; set; } = new List<Comment>();
        /// <summary>
        /// التاجر صاحب المنتج
        /// </summary>
        public Seller Owner { get; set; } = new Seller();
    }
}
