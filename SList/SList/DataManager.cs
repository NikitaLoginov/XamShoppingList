using SQLite;

namespace SList
{
    public static class DataManager
    {
        public static void SaveData(ProductModel model)
        {
            using (var conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<ProductModel>();
                conn.InsertOrReplace(model);
                
                conn.Close();
            }
        }

        public static void DeleteData(ProductModel model)
        {
            using (var conn = new SQLiteConnection(App.FilePath))
            {
                conn.Delete<ProductModel>(model.Id);
                
                conn.Close();
            }
        }
    }
}