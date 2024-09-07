namespace DatabaseConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager Ds = new DatabaseManager(DatabaseManager.CreatDateBase(@"A:\", "Mahdi"));
            //Ds.AddFile(@"C:\Users\DELL\OneDrive\Pictures\Camera Roll\WIN_20240907_12_04_09_Pro.jpg", @"A:\Mahdi\Costomers\mahdi");
            //Ds.AddSeller("mahdi", "123", out bool added);
            //Ds.AddSeller("mahdi", "123", out added);
            //Ds.AddProduct("berd", "mahdi");
            //Ds.AddCostomer("Mahdi_204", "123456", out bool added);
            //Ds.AddComment("Mahdi_204", "0", "5", "this is a nice product!.");
            Ds.AddCostomer("mh", "123", out bool added);
            Ds.AddComment("mh", "0", "5", "Ok!");
            Ds.RemoveUser("mh");
        }
    }
}
