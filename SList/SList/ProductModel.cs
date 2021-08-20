using SQLite;

namespace SList
{
    public class ProductModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
