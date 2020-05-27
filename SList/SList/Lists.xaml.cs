using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lists : ContentPage
    {
        public Lists()
        {
            InitializeComponent();
        }

        private void AddToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            RefreshList();
        }

        private void DeleteToolbarItem_Clicked(object sender, EventArgs e)
        {
            var listItem = (sender as MenuItem).CommandParameter as ProductsList;
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                if (listItem != null)
                {
                    conn.Delete(listItem);

                    conn.Close();
                }  
            }

            RefreshList();
        }
        private void shoppingListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        }
        private void RefreshList()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<ProductsList>();
                List<ProductsList> products = conn.Table<ProductsList>().ToList();
                shoppingListView.ItemsSource = products;
            }
        }
    }
}