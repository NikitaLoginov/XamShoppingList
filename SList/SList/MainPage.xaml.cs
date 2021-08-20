using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SList
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    
    //Product Page
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ProductModel productModel;
        public MainPage()
        {
            productModel = new ProductModel();
            InitializeComponent();
        }

        private void SaveToolbarItem_Clicked(object sender, EventArgs e)
        {
            productModel.SaveItem(ProductEntry, QtyEntry, NotesEditor);

            Navigation.PopToRootAsync();
        }

    }
}
