using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App6.Models;
using App6.ViewModels;
using SQLite;

namespace App6.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();



            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<SQLSource>();
                var content = conn.Table<SQLSource>().ToList();
                MessagingCenter.Send(content, "AddItem");

                dets.ItemsSource = content;
            }   
        }

            public ItemDetailPage()
        {
            InitializeComponent();

            


        }

        
    }
}