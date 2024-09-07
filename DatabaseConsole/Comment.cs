using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    public class Comment
    {
        /// <summary>
        /// المنتج يلي هاد التعليق موجود عليه
        /// </summary>
        public Product Product { get; set; } = new Product();
        /// <summary>
        /// تقييم المنتج يلي تم التعليق عليه من وجهه نظر صاحب التعليق.
        /// </summary>
        public string Evaluation { get; set; } = "";
        /// <summary>
        /// نص التعليق نفسو
        /// </summary>
        public string CommentTxt { get; set; }
        /// <summary>
        /// صاحب التعليق
        /// </summary>
        public Costomer Owner { get; set; } = new Costomer();
        /// <summary>
        /// رقم التعليق على القاعدة
        /// </summary>
        public string ID { get; set; }
    }
}
