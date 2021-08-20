using System;
using SQLite;
using Xamarin.Forms;

namespace SList
{
    public class ProductModel
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; } //should be nullable for autoincrement to work with InsertOrReplace

        [Unique]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }


        public void SaveItem(Entry productEntry, Entry qtyEntry, Editor notesEditor)
        {
            ProductName = productEntry.Text;
            Quantity = Convert.ToInt32(qtyEntry.Text);
            Notes = notesEditor.Text;
            
            DataManager.SaveData(this);
        }

        public void EditItem(MainPage mainPage)
        {
            mainPage.ProductEntry.Text = ProductName;
            mainPage.QtyEntry.Text = Quantity.ToString();
            mainPage.NotesEditor.Text = Notes;
        }

        public void DeleteItem()
        {
            DataManager.DeleteData(this);
        }
    }
}
