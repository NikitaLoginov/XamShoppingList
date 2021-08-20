using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductList : ContentPage
    {
        public ProductList()
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
            var listItem = (sender as MenuItem)?.CommandParameter as ProductModel;
            listItem?.DeleteItem();

            RefreshList();
        }

        private void ShoppingListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            var mainPage = new MainPage();
            
            switch (e.Item)
            {
                case null:
                    throw new ArgumentException("Item cannot be null!", nameof(e.Item));
                case ProductModel model:
                    model.EditItem(mainPage);
                    break;
            }
            
            Navigation.PushAsync(mainPage);
        }
        
        private void RefreshList()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<ProductModel>();
                List<ProductModel> products = conn.Table<ProductModel>().ToList();
                ShoppingListView.ItemsSource = products;
            }
        }
    }
}