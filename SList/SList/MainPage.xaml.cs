using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ProductsList entry = new ProductsList()
            {
                ProductName = productEntry.Text,
                Quantity = Convert.ToInt32(qtyEntry.Text),
                Notes = notesEditor.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<ProductsList>();

                conn.Insert(entry);
                conn.Close();
            }

            Navigation.PopToRootAsync();
        }

    }
}
