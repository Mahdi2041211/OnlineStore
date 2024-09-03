using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase
{
    /// <summary>
    /// all methods that you will need to manage our seak database is here, creat a database is a static method and all the other methods are working with an instans of thes class.
    /// </summary>
    internal class DatabaseManager
    {
        /// <summary>
        /// the database you are managing.
        /// </summary>
        /// 
        public string Path { get; set; }
        public DatabaseManager(string name) { Path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName + "\\" + name; }
        public DatabaseManager(string name, string path) : this(name) { Path = path; }
        static void Creatdirs(string path, string name)
        {
            string Database = path + "\\" + name;
            string[] dirs = { "", "\\Costomers", "\\Seller", "\\Products", "\\Comments" };
            for (int i = 0; i < dirs.Length; i++)
            {
                Directory.CreateDirectory(Database + dirs[i] + Console.ReadLine());
                if (i > 0)
                {
                    using (FileStream fs = File.Create(Database + dirs[i] + @"\counter.txt"))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(Database + dirs[i] + @"\counter.txt"))
                        { streamWriter.WriteLine("0"); }
                    }
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

    }
}
