using System;
using System.ComponentModel;
using Xamarin.Forms;
using SQLite;

namespace SList
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SaveToolbarItem_Clicked(object sender, EventArgs e)
        {
            ProductModel entry = new ProductModel()
            {
                ProductName = ProductEntry.Text,
                Quantity = Convert.ToInt32(QtyEntry.Text),
                Notes = NotesEditor.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<ProductModel>();

                conn.InsertOrReplace(entry);
                conn.Close();
            }

            Navigation.PopToRootAsync();
        }

    }
}
