using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DatabaseConsole
{
    /// <summary>
    /// all methods that you will need to manage our seak database is here, creat a database is a static method and all the other methods are working with an instans of thes class.
    /// </summary>
    public class DatabaseManager
    {
        /// <summary>
        /// the database you are managing.
        /// </summary>
        /// 
        public string Path { set; get; }
        public DatabaseManager(string path) {  Path = path; }
        static void Creatdirs(string path, string name)
        {
            string Database = path + "\\" + name;
            string[] dirs = { "", "\\Costomers", "\\Sellers", "\\Blocks" };
            for (int i = 0; i < dirs.Length; i++)
            {
                Directory.CreateDirectory(Database + dirs[i]);
                switch (dirs[i])
                {
                    case "\\Costomers":
                    case "\\Sellers":
                        using (FileStream fs = File.Create(Database + dirs[i] + "\\Users.txt")) { }
                        break;
                    case "\\Blocks":
                        using (FileStream fs = File.Create(Database + dirs[i] + @"\counter.txt")) { }
                        using (FileStream fs = File.Create(Database + dirs[i] + @"\products.txt")) { }
                        using (FileStream fs = File.Create(Database + dirs[i] + @"\comments.txt")) { }
                        string[] s = { "0" };
                        File.WriteAllLines(Database + dirs[i] + @"\counter.txt", s);
                        break;
                }
            }
        }
        /// <summary>
        /// هي الميثود عنا ألها نسختين, وحدة مع Id والتانية بدونو، هو مالو طعمة فعليا بس حط بالخرج.
        /// هي الدالة مهمتها تساوي قاعدة البيانات بكل الملفات والمجلدات يلي راح تلزم تكون بقلبها من شان نشتغل عليها بعدين.
        /// قبل ما نبلش شغل بالقواعد لازم ننشئ قاهدة ونربطها بالبرنامج من شان يرجعلها بعدين.
        /// </summary>
        /// <param name="path">المسار يلي بدك يكون فيه مجلد القاعدة</param>
        /// <param name="name">اسم القاعدة</param>
        /// <returns>ترجع مسار القاعدة من شان تستعملو بإنشاء كائن القاعدة.</returns>
        public static string CreatDateBase(string path, string name)
        {
            Creatdirs(path, name);
            return path + "\\" + name;
        }
        /// <summary>
        /// هي الدالة من شان تنسخ الملفات من أي مكان علكمبيوتر لأي مكان تاني، راح نستخدمها من شان نسخ الملفات من الجمبيوتر يلي عنا لقاعدة البيانات تبعنا.
        /// </summary>
        /// <param name="sourceFIlePath">الملف يلي بدنا ننسخو</param>
        /// <param name="path">المكان يلي بدي أنسخو لعندو</param>
        public void AddFile(string sourceFIlePath, string path)
        {
            string[] s = sourceFIlePath.Split('\\');
            s = s[s.Length - 1].Split('.');
            File.Copy(sourceFIlePath, path + "." + s[s.Length - 1]);
        }

        /// <summary>
        /// الدالة المستخدمة لإضافة مستخدم عادي للقاعدة.
        /// بالنسبة للملف النصي للمستخدم وللتاجر زللمنتج راح يكون ترتيب السطور هو أنو أول سطر للاسم والتاني للعنوان.
        /// the username and the password are in the same line in Users.txt
        /// </summary>
        /// <param name="user">اسم المستخدم</param>
        /// <param name="passwd">the password of this user</param>
        /// <param name="added">if it added or not</param>
        public void AddCostomer(string user, string passwd, out bool added)
        {
            added = true;
            List<string> users = new List<string>(File.ReadAllLines(Path + "\\Costomers\\Users.txt"));
            foreach (string s in users)
            {
                string[] ss = s.Split(";");
                if (ss[0] == user)
                {
                    added = false;
                    break;
                }
            }
            if (added)
            {
                users.Add(user + ";" + passwd);
                using (FileStream fs = File.Create(Path + "\\Costomers\\" + user + "basket.txt")) { }
                using (FileStream fs = File.Create(Path + "\\Costomers\\" + user + "comments.txt")) { }
                File.WriteAllLines(Path + "\\Costomers\\Users.txt", users);
            }
        }
        
        public void AddSeller(string user, string passwd, out bool added)
        {
            added = true;
            List<string> users = new List<string>(File.ReadAllLines(Path + "\\Sellers\\Users.txt"));
            foreach (string s in users)
            {
                string[] ss = s.Split(";");
                if (ss[0] == user)
                {
                    added = false ;
                    break;
                }
            }
            if (added)
            {
                users.Add(user + ";" + passwd);
                using (FileStream fs = File.Create(Path + "\\Sellers\\" + user + "products.txt")) { }
                File.WriteAllLines(Path + "\\Sellers\\Users.txt", users);
            }
        }
        /// <summary>
        /// هي الدالة من شان إضافة منتج على قاعدة البيانات الخاصة فينا من شان تقدر تعرضو على البرنانج.
        /// بالنسبة لملف info حيكون مقسم علشكل التالي:
        /// أول سطر من اسم المنتج
        /// تاني سطر العنوان تبعو
        /// 
        /// </summary>
        /// <param name="ProductName">اسم المنتَج</param>
        /// <param name="OwnerID">اسم التاجر المالك للمنتج (أكيد مافي منتج حينضاف بدون ما يكون ألو صاحب)</param>
        public void AddProduct(string ProductName, string OwnerID)
        {
            string id = File.ReadAllLines(Path + "\\Blocks\\counter.txt")[0];
            List<string> s = new List<string>{ (int.Parse(id) + 1).ToString() };
            File.WriteAllLines(Path + "\\Blocks\\counter.txt", s);
            using (FileStream fs = File.Create(Path + "\\Blocks\\P" + id + ".txt")) { }
            s = new List<string> { ProductName, id, OwnerID };
            File.WriteAllLines(Path + "\\Blocks\\P" + id + ".txt", s);
            using (FileStream fs = File.Create(Path + "\\Blocks\\" + id + "C.txt")) { }
            s = new List<string>(File.ReadAllLines(Path + "\\Blocks\\products.txt"));
            s.Add(id);
            File.WriteAllLines(Path + "\\Blocks\\products.txt", s);
            s = new List<string>(File.ReadAllLines(Path + "\\Sellers\\" + OwnerID + "products.txt"));
            s.Add(id);
            File.WriteAllLines(Path + "\\Sellers\\" + OwnerID + "products.txt", s);
        }
        /// <summary>
        /// هي الدالة بتضيف تعليق على مجلد التعليقات الموجود بالقاعدة، كل تعليق بكون عبارة عن مستند نصي فيه كل التعاصيل عن هاد التعليق.
        /// ترتيب السطور بالملف هو كالتالي:
        /// الاول فيه رقم المستخدم يلي علق
        /// التالني فيه رقم التعليق على القاعدة
        /// الثالث فيه رقم المنتج بالقاعدة
        /// الرابع فيه التقييم
        /// الخامس والأخير فيه التعليق نفسو.
        /// </summary>
        /// <param name="user">رقم المستخدم يلي علق</param>
        /// <param name="product">رقم المنتج يلي تك التعليق عليه</param>
        /// <param name="comment">نص التعليق نفسو</param>
        /// <param name="evaluation">التقييم يلي بيبعتو المستخدم مع تعليقو</param>
        public void AddComment(string user, string product, string evaluation, string comment)
        {
            string id = File.ReadAllLines(Path + "\\Blocks\\counter.txt")[0];
            List<string> list = new List<string> { (int.Parse(id) + 1).ToString() };
            File.WriteAllLines(Path + "\\Blocks\\counter.txt", list);
            using (FileStream fs = File.Create(Path + "\\Blocks\\C" + id + ".txt")) { }
            list = new List<string> { user, id, product, evaluation, comment };
            File.WriteAllLines(Path + "\\Blocks\\C" + id + ".txt", list);
            list = new List<string>(File.ReadAllLines(Path + "\\Costomers\\" + user + "comments.txt"));
            list.Add(id);
            File.WriteAllLines(Path + "\\Costomers\\" + user + "comments.txt", list);
            list = new List<string>(File.ReadAllLines(Path + "\\Blocks\\" + product + "C.txt"));
            list.Add(id);
            File.WriteAllLines(Path + "\\Blocks\\" + product + "C.txt", list);
        }
        
        /// <summary>
        /// لإضافة عنصر للسلة الخاصة بأي مستخدم
        /// </summary>
        /// <param name="userid">رقم المستخدم اللي حنضيف للسلة تبعو</param>
        /// <param name="productid">رقم المنتج يلي عنضيفو للسلة</param>
        public void AddToBasket(string userid, string productid)
        {
            List<string> basket = new List<string>(File.ReadAllLines(Path + "\\Costomers\\" + userid + "\\basket.txt"));
            basket.Append(productid);
            File.WriteAllLines(Path + "\\Costomers\\" + userid + "\\basket.txt", basket);
        }
        /// <summary>
        /// هي الدالة بتحذف كلشي ألو علاقة بالمستخدم موجود علقاعدة (كلشي حرفيا)
        /// لو ما كان موجود مجلد باسم رقم المستخدم المدخل ما راح يصير شي ساعتها
        /// </summary>
        /// <param name="userid">رقم المستخدم يلي بدك تحذفو</param>
        public void RemoveUser(string userid)
        {
            List<string> list = new List<string>(File.ReadAllLines(Path + "\\Costomers\\" + userid + "comments.txt"));
            foreach (string comment in list) 
                RemoveComment(comment);
            File.Delete(Path + "\\Costomers\\" + userid + "comments.txt");
            File.Delete(Path + "\\Costomers\\" + userid + "basket.txt");
            list = new List<string>(File.ReadAllLines(Path + "\\Costomers\\Users.txt"));
            List<string> s = new List<string>(list);
            for (int i = 0; i < list.Count; i++)
                s[i] = list[i].Split(';')[0];
            list.RemoveAt(s.IndexOf(userid));
            File.WriteAllLines(Path + "\\Costomers\\User.txt", list);
        }
        /// <summary>
        /// متل دالة حذف المستخدم هي الدالة بتحذف كلشي ألو علاقة بهاد التاجر بشكل نهائي
        /// </summary>
        /// <param name="sellerid"></param>
        public void RemoveSeller(string sellerid)
        {
            List<string> list = new List<string>(File.ReadAllLines(Path + "\\Sellers\\" + sellerid + "products.txt"));
            foreach (string s  in list)
                RemoveProduct(s);
            File.Delete(Path + "\\Sellers\\" + sellerid + "products.txt");
            list = new List<string>(File.ReadAllLines(Path + "\\Sellers\\Users.txt"));
            List<string> s = new List<string>(list);
            for (int i = 0; i < list.Count; i++)
                s[i] = list[i].Split(';')[0];
            list.RemoveAt(s.IndexOf(sellerid));
            File.WriteAllLines(Path + "\\Sellers\\User.txt", list);
        }
        /// <summary>
        /// بتشيل الكومينت بشكل نهائي من القاعدة ومن قمة التعليقات يلي موحوجة بالمنتج يلي هو فيه
        /// </summary>
        /// <param name="commentid">رقم الكومينت الموجود بالقاعدة</param>
        public void RemoveComment(string commentid)
        {
            string[] info = File.ReadAllLines(Path + "\\Blocks\\C" + commentid + ".txt");
            List<string> list = new List<string>(File.ReadAllLines(Path + "\\Costomers\\" + info[0] + "comments.txt"));
            list.Remove(commentid);
            File.WriteAllLines(Path + "\\Costomers\\" + info[0] + "comments.txt", list);
            list = new List<string>(File.ReadAllLines(Path + "\\Blocks\\" + info[2] + "C.txt"));
            list.Remove(commentid);
            File.WriteAllLines(Path + "\\Blocks\\" + info[3] + "C.txt", list);
            File.Delete(Path + "\\Blocks\\C" + commentid + ".txt");
        }
        /// <summary>
        /// بتشيل المنتج هو وكلشي متعلق فيه (ما عدا التاجر طبعا) برا القاعدة نهائيا
        /// ما حينشال رقم المنتج من سلة واحد كم الزباين يلي ضايفينو لسلهم بس بنفس الوقت ما عاد يلاقي هاد المنتج بالقاعدة عندو.
        /// </summary>
        /// <param name="productid">رقم المنتج بالقاعدة</param>
        public void RemoveProduct(string productid)
        {
            string[] info = File.ReadAllLines(Path + "\\Blocks\\P" + productid + ".txt");
            List<string> list = new List<string>(File.ReadAllLines(Path + "\\Blocks\\" + productid + "C.txt"));
            foreach(string s in list) 
                RemoveComment(s);
            File.Delete(Path + "\\Blocks\\" + productid + "C.txt");
            list = new List<string>(File.ReadAllLines(Path + "\\Sellers\\" + info[2] + "products.txt"));
            list.Remove(productid);
            File.WriteAllLines(Path + "\\Sellers\\" + info[2] + "products.txt", list);
            File.Delete(Path + "\\Blocks\\P" + productid + ".txt");
        }
        /// <summary>
        /// هي الدالة من شان هذف المنتج من قائمة السلة 
        /// </summary>
        /// <param name="userid">رقم المستخدم</param>
        /// <param name="productid">رقم المنتج المراد حذفو</param>
        public void RemoveFromBasket(string userid, string productid)
        {
            List<string> basket = new List<string>(File.ReadAllLines(Path + "\\Costomers\\" + userid + "basket.txt"));
            basket.Remove(productid);
            File.WriteAllLines(Path + "\\Costomers\\" + userid + "basket.txt", basket);
        }

        public Costomer GetCostomer(string costomerid)
        {
            Costomer costomer = new Costomer();
            costomer.ID = costomerid;
            string[] s = File.ReadAllLines(Path + "\\Costomers\\" + costomerid + "basket.txt");
            foreach (string pro in s)
            {
                Product product = new Product();
                product.ID = pro;
                costomer.Basket.Add(product);
            }
            s = File.ReadAllLines(Path + "\\Costomers\\" + costomerid + "comments.txt");
            foreach (string pro in s)
            {
                Comment comment = new Comment();
                comment.ID = pro;
                costomer.Comments.Add(comment);
            }
            return costomer;
        }
        public Product GetProduct(string productid)
        {
            Product product = new Product();
            product.ID = productid;
            string[] s = File.ReadAllLines(Path + "\\Blocks\\" + productid + "C.txt");
            foreach (string pro in s)
            {
                Comment comment = new Comment();
                comment.ID = pro;
                product.Comments.Add(comment);
            }
            s = File.ReadAllLines(Path + "\\Blocks\\P" + productid);
            Seller seller = new Seller();
            seller.ID = s[2];
            product.Owner = seller;
            return product;
        }
        public Comment GetComment(string commentid)
        {
            List<string> list = new List<string>(File.ReadAllLines(Path + "\\Blocks\\C" + commentid + ".txt"));
            Comment comment = new Comment();
            comment.ID = commentid;
            comment.Owner.ID = list[0];
            comment.Product.ID = list[2];
            comment.Evaluation = list[3];
            comment.CommentTxt = list[4];
            return comment;
        }
        public Seller GetSeller(string sellerid)
        {
            Seller seller = new Seller();
            seller.ID = sellerid;
            string[] s = File.ReadAllLines(Path + "\\Seller\\" + sellerid + "products.txt");
            foreach(string pro in s)
            {
                Product product = new Product();
                product.ID = pro;
                seller.Products.Add(product);
            }
            return seller;
        }
    }
}
