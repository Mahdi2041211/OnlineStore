using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Database
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
                        File.Create(Database + dirs[i] + "\\Users.txt"); break;
                    case "\\Blocks":
                        File.Create(Database + dirs[i] + "\\counter.txt");
                        using (StreamWriter st = new StreamWriter(Database + dirs[i] + "\\counter.txt"))
                        {
                            st.WriteLine("0");
                        }
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
        /// نفس أختها بس بتنشئ القاعدة بقلب المسار اللي عم يتم تنفيذ المشروع فيه.
        /// </summary>
        /// <param name="name">اسم القاعدة</param>
        /// <returns></returns>
        public static string CreatDateBase(string name)
        {
            string path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;
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
            string last = ".";
            {
                string[] s = path.Split("\\");
                string[] ss = s[s.Length - 1].Split(".");
                last += ss[ss.Length - 1];
            }
            File.Copy(sourceFIlePath, path + last);
        }

        /// <summary>
        /// الدالة المستخدمة لإضافة مستخدم عادي للقاعدة.
        /// بالنسبة للملف النصي للمستخدم وللتاجر زللمنتج راح يكون ترتيب السطور هو أنو أول سطر للاسم والتاني للعنوان.
        /// </summary>
        /// <param name="user">اسم المستخدم</param>
        public void AddCostomer(string user)
        {
            string id = AddInfo(user, "\\Costomers");
            using (FileStream fs = File.Create(Path + "\\Costomers\\" + id + "\\comments.txt")) { }
            using (FileStream fs = File.Create(Path + "\\Costomers\\" + id + "\\basket.txt")) { }
        }
        /// <summary>
        /// الدالة المستخدمة لإضافة تاجر على القاعدة.
        /// السطر الأول من ملف الinfo للاسم والتاني للعنوان
        /// </summary>
        /// <param name="name">اسم التاجر</param>
        public void AddSeller(string name)
        {
            string id = AddInfo(name, "\\Seller");
            using (FileStream fs = File.Create(Path + "\\Seller\\" + id + "\\products.txt")) { }
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
            string id = AddInfo(ProductName, "\\Products");
            Directory.CreateDirectory(Path + "\\Products\\" + id + "\\coppons");
            Directory.CreateDirectory(Path + "\\Products\\" + id + "\\photos");
            using (FileStream fs = File.Create(Path + "\\Products\\" + id + "\\comments.txt")) { }
            List<string> info = new List<string>(File.ReadAllLines(Path + "\\Product\\" + id + "\\info.txt"));
            info.Append(OwnerID);
            File.WriteAllLines(Path + "\\Product\\" + id + "\\info.txt", info);
            List<string> OwnerProducts = new List<string>(File.ReadAllLines(Path + "\\Seller\\" + info[1] + "\\products.txt"));
            OwnerProducts.Append(id);
            File.WriteAllLines(Path + "\\Seller\\" + info[1] + "\\products.txt", OwnerProducts);
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
            string id = File.ReadLines(Path + "\\Comments\\counter.txt").First();
            using (FileStream fs = File.Create(Path + "\\Comments\\" + id + ".txt")) { }
            List<string> info = new List<string> { user, id, product, evaluation, comment };
            File.WriteAllLines(Path + "\\Comments\\" + id + ".txt", info);
            info = new List<string>(File.ReadAllLines(Path + "\\Costomers\\" + user + "\\comments.txt"));
            info.Append(id);
            File.WriteAllLines(Path + "\\Costomers\\" + user + "\\comments.txt", info);
            info = new List<string>(File.ReadAllLines(Path + "\\Products\\" + product + "\\comments.txt"));
            info.Append(id);
            File.WriteAllLines(Path + "\\Products\\" + product + "\\comments.txt", info);
        }
        string AddInfo(string name, string path)
        {
            string id = File.ReadLines(Path + path + "\\counter.txt").First();
            Directory.CreateDirectory(Path + path + "\\" + id);
            string[] s = { (int.Parse(id) + 1).ToString() };
            using (FileStream fs = File.Create(Path + path + "\\" + id + "info.txt")) { }
            using (StreamWriter streamWriter = new StreamWriter(Path + path + "\\" + id + "\\info.txt"))
            {
                streamWriter.WriteLine(name);
                streamWriter.WriteLine(id);
            }
            File.WriteAllLines(Path + path + "\\counter.txt", s);
            return id;
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
            if (Directory.Exists(Path + "\\Costomers\\" + userid))
            {
                string[] comments = File.ReadAllLines(Path + "\\Costomers\\" + userid + "\\comments.txt");
                foreach (string comment in comments) 
                    RemoveComment(comment);
                Directory.Delete(Path + "\\Costomers\\" + userid, true);
            }
        }
        /// <summary>
        /// متل دالة حذف المستخدم هي الدالة بتحذف كلشي ألو علاقة بهاد التاجر بشكل نهائي
        /// </summary>
        /// <param name="sellerid"></param>
        public void RemoveSeller(string sellerid)
        {
            if (Directory.Exists(Path + "\\Costomers\\" + sellerid))
            {
                string[] products = File.ReadAllLines(Path + "\\Seller\\" + sellerid + "\\products.txt");
                foreach(string product in products)
                    RemoveProduct(product);
                Directory.Delete(Path + "\\Seller\\" + sellerid, true);
            }
        }
        /// <summary>
        /// بتشيل الكومينت بشكل نهائي من القاعدة ومن قمة التعليقات يلي موحوجة بالمنتج يلي هو فيه
        /// </summary>
        /// <param name="commentid">رقم الكومينت الموجود بالقاعدة</param>
        public void RemoveComment(string commentid)
        {
            if (File.Exists(Path + "\\Comments\\" + commentid + ".txt"))
            {
                string[] s = File.ReadAllLines(Path + "\\Comments\\" + commentid + ".txt");
                List<string> list = new List<string>(File.ReadAllLines(Path + "\\Products\\" + s[2] + "\\comments.txt"));
                list.Remove(commentid);
                File.WriteAllLines(Path + "\\Products\\" + s[2] + "\\comments.txt", list);
                list = new List<string>(File.ReadAllLines(Path + "\\Costomers\\" + s[0] + "\\comments.txt"));
                list.Remove(commentid);
                File.WriteAllLines(Path + "\\Costomers\\" + s[0] + "\\comments.txt", list);
                File.Delete(Path + "\\Comments\\" + commentid + ".txt");
            }
        }
        /// <summary>
        /// بتشيل المنتج هو وكلشي متعلق فيه (ما عدا التاجر طبعا) برا القاعدة نهائيا
        /// ما حينشال رقم المنتج من سلة واحد كم الزباين يلي ضايفينو لسلهم بس بنفس الوقت ما عاد يلاقي هاد المنتج بالقاعدة عندو.
        /// </summary>
        /// <param name="productid">رقم المنتج بالقاعدة</param>
        public void RemoveProduct(string productid)
        {
            if (Directory.Exists(Path + "\\Products\\" + productid))
            {
                List<string> list = new List<string>(File.ReadAllLines(Path + "\\Products\\" + productid + "\\info.txt"));
                string owner = list[2];
                list = new List<string>(File.ReadAllLines(Path + "\\Seller\\" + owner + "\\products.txt"));
                list.Remove(productid);
                File.WriteAllLines(Path + "\\Seller\\" + owner + "\\products.txt", list);
                list = new List<string>(File.ReadAllLines(Path + "\\Products\\" + productid + "\\comments.txt"));
                foreach (string s in list)
                    RemoveComment(s);
                Directory.Delete(Path + "\\Products\\" + productid);
            }
        }
        /// <summary>
        /// هي الدالة من شان هذف المنتج من قائمة السلة 
        /// </summary>
        /// <param name="userid">رقم المستخدم</param>
        /// <param name="productid">رقم المنتج المراد حذفو</param>
        public void RemoveFromBasket(string userid, string productid)
        {
            List<string> basket = new List<string>(File.ReadAllLines(Path + "\\Costomers\\" + userid + "\\basket.txt"));
            basket.Remove(productid);
            File.WriteAllLines(Path + "\\Costomers\\" + userid + "\\basket.txt", basket);
        }

        public Costomer GetCostomer(string costomerid)
        {
            Costomer user = new Costomer();
            user.ID = costomerid;
            List<string> list = new List<string>(File.ReadAllLines(Path + "\\Costomers\\" + costomerid + "info.txt"));
            user.Name = list[0];
            list = new List<string>(File.ReadAllLines(Path + "\\Costomers\\" + costomerid + "\\comments.txt"));
            foreach (string comment in list)
                user.Comments.Append(GetComment(comment));
            list = new List<string>(File.ReadAllLines(Path + "\\Costomers\\" + costomerid + "\\basket.txt"));
            foreach (string product in list)
                user.Basket.Append(GetProduct(product));
            return user;
        }
        public Product GetProduct(string productid)
        {
            List<string> list = new List<string>(File.ReadAllLines(Path + "\\Products\\" + productid + "\\info.txt"));
            Product product = new Product();
            product.ID = productid;
            product.Name = list[0];
            product.Owner.ID = list[2];
            product.Photos = new List<string>(Directory.GetFiles(Path + "\\Products\\" + productid + "\\photos"));
            list = new List<string>(File.ReadAllLines(Path + "\\Prosucts\\" + product + "\\comments.txt"));
            foreach(string comment in list)
                product.Comments.Append(GetComment(comment));
            return product;
        }
        public Comment GetComment(string commentid)
        {
            List<string> list = new List<string>(File.ReadAllLines(Path + "\\Comments\\" + commentid + ".txt"));
            Comment comment = new Comment();
            comment.ID = commentid;
            comment.Owner.ID = list[0];
            comment.Product.ID = list[2];
            comment.Evaluation = list[3];
            comment.CommentTxt = list[4];
            return comment;
        }
    }
}
