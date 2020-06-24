using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App6.Models;
using App6.Views;
using App6.ViewModels;

using SQLite;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;

namespace App6.Views
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public Guid num { get; set; }
        public int DataID { get; set; }

            

        public int ItemId { get; set; }

        private static SQLiteConnection _sqlite_conn;
        private static SQLiteCommand _sqlite_cmd;


        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();

            
        }

     /*   public static void SortDatabase()
        {
            _sqlite_conn = new SQLiteConnection(App.FilePath);
            string selectsql = "SELECT Database FROM SQLSource ORDER BY Date ASC";
         //   _sqlite_cmd = SQLiteCommand(selectsql, _sqlite_conn);
            _sqlite_conn.Close();
                
        }
     */

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        async void ExpandedView(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<SQLSource>();
                var content = conn.Table<SQLSource>().ToList();
                MessagingCenter.Send(content, "AddItem");

                contentListView.ItemsSource = content;
            }

           

           

            //   var date = Item.Date;

            // var db = new SQLiteConnection(App.FilePath);
            //    var Database = db.Table<SQLSource>();

            /*   IEnumerable<SQLSource> sortAscendQuery =
                   (IEnumerable<SQLSource>)(from SQLSource in Database
                   orderby date ascending
                   select date);


               using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
               {

                   var Date = Item.Date.ToString();
                   var content = conn.Table<SQLSource>().ToList();

                   content.Sort(Date);
                   contentListView.ItemsSource = content;





               }
               */

        }

        


        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {

            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            viewModel.DataStore.DeleteItemAsync(item.Id);

        }

        async void OnMore(object sender, EventArgs e)
        {
            Console.WriteLine("0");
            var layout = (BindableObject)sender;
            Console.WriteLine("1");
            var item = (SQLSource)layout.BindingContext;
            Console.WriteLine("2");
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            

        }


        public SQLiteConnection _sqlconnection;


        // private object sqlsource;


        public void DeleteStudent(int Id)
        {

            _sqlconnection.Delete<SQLSource>(num);
        }

        public void OnDelete(object sender, EventArgs e)
        {
            
            string item = contentListView.ToString();
            Console.WriteLine(item);
            var got = contentListView.SelectedItem;
            Console.WriteLine( "Hi");
            var db = new SQLiteConnection(App.FilePath);
            var Database = db.Table<SQLSource>();
            var pk = 0;
         // var select = ItemId;
            
            /*
             So I need to be able to read what the selected Item Id is then I need to store that as a variable then from there I need to use the
             foreach loop to be able to find which record is the actual one and then execute the kill 
            .
            */


            foreach (var s in Database)
            {
               

            }
           
            // Needs to delete from the actual ID not the Guid
            Console.WriteLine(Id + "ID ");
            Console.WriteLine(num);
            
            //db.Delete<SQLSource>(DataID);
            Console.WriteLine("Hi");
             
            //pk = s.id
            



            
              /*  if(Selected == pk)
                {
                    db.Delete<SQLSource>(pk);
                }
              */
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(App.FilePath);
            var Database = db.Table<SQLSource>();

            foreach (var s in Database)
            {
                Console.WriteLine(s.Id + " " + s.Name);
                var pk = s.Id;
                db.Delete<SQLSource>(pk);
                Console.WriteLine("The database was deleted");




            }

           

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<SQLSource>();
                var content = conn.Table<SQLSource>().ToList();

                contentListView.ItemsSource = content;
                
            }

        }

        
    }

                


           

        
    }
    



   