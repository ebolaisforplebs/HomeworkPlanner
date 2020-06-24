using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App6.Models;
using App6.Services;
using SQLite;
using System.Linq;
using System.Globalization;

namespace App6.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        
        public Item Item { get; set; }
        public MockDataStore dataStore { get;  set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
               // Text = "Item name",
               // Description = "This is an item description."
            };

            // Populate Department Picker with Departments

            DepartmentSelector.Items.Add("Maths");
            DepartmentSelector.Items.Add("English");
            DepartmentSelector.Items.Add("HSIE");
            DepartmentSelector.Items.Add("Science");
            DepartmentSelector.Items.Add("CAPA");
            DepartmentSelector.Items.Add("TAS");
            DepartmentSelector.Items.Add("PDHPE");
            DepartmentSelector.Items.Add("LOTE");




            BindingContext = this;
        }

        
        
          
        

        async void Save_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine(Item.Percentage);
            var SelectedDate = Item.DueDate;
            



            MessagingCenter.Send(this, "AddItem", Item);
            SQLSource sqlsource = new SQLSource()
            {
                Name = ItemName.Text,
                Description = ItemDescription.Text,
                Department = (string)DepartmentSelector.SelectedItem,
                Subject = (string)SubjectSelector.SelectedItem,
                Date = SelectedDate,
                Percent = Item.Percentage,
                
            };

            Console.Write(SelectedDate + "Selected");

               using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<SQLSource>();
                    int rowsAdded = conn.Insert(sqlsource);

              //String selectQuery = "SELECT * FROM " + TABLE_NAME + " ORDER BY datetime(dateColumn) DESC";
              //return database.rawQuery(selectQuery, null);

            }

                await Navigation.PopModalAsync();
           


        }
    

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void DepartmentSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubjectSelector.Items.Clear();
            if (Item.Index == 0)
            {
                // Maths Department 

                SubjectSelector.Items.Add("Junior Mathematics");
                SubjectSelector.Items.Add("2U Maths");
                SubjectSelector.Items.Add("3U Maths");
                SubjectSelector.Items.Add("4U Maths");
            }

            else if (Item.Index == 1)
            {
                // English

                SubjectSelector.Items.Add("Junior English");
                SubjectSelector.Items.Add("2U English");
                SubjectSelector.Items.Add("3U English");
                SubjectSelector.Items.Add("4U English");
            }
            else if (Item.Index == 2)
            {
                // HSIE

                SubjectSelector.Items.Add("Junior Geography");
                SubjectSelector.Items.Add("Junior History");
                SubjectSelector.Items.Add("Business Studies");
                SubjectSelector.Items.Add("Economics");
                SubjectSelector.Items.Add("Senior Geography");
                SubjectSelector.Items.Add("Modern History");
                SubjectSelector.Items.Add("Ancient History");
                SubjectSelector.Items.Add("Legal Studies");
                SubjectSelector.Items.Add("History Extension");

            }

            else if (Item.Index == 3)
            {
                // Science

                SubjectSelector.Items.Add("Junior Science");
                SubjectSelector.Items.Add("Physics");
                SubjectSelector.Items.Add("Biology");
                SubjectSelector.Items.Add("Chemistry");

            }

            else if (Item.Index == 4)
            {
                // CAPA

                SubjectSelector.Items.Add("Visual Arts");
                SubjectSelector.Items.Add("Junior Music");
                SubjectSelector.Items.Add("Drama");
                SubjectSelector.Items.Add("Music 1");
                SubjectSelector.Items.Add("Music 2");
                SubjectSelector.Items.Add("Extension Music");

            }

            else if (Item.Index == 5)
            {
                // TAS

                SubjectSelector.Items.Add("Design and Technology");
                SubjectSelector.Items.Add("Food Technology");
                SubjectSelector.Items.Add("Engineering Studies");
                SubjectSelector.Items.Add("Automotive Engineering");
                SubjectSelector.Items.Add("Information Processes and Technology");
                SubjectSelector.Items.Add("Software Design and Development");
                SubjectSelector.Items.Add("ISTEM");

            }

            else if (Item.Index == 6)
            {
                //PDHPE

                SubjectSelector.Items.Add("PDHPE");
                SubjectSelector.Items.Add("PASS");
            }

            else
            {
                // Languages

                SubjectSelector.Items.Add("Indonesian");
                SubjectSelector.Items.Add("Indonesian Continuers");
                SubjectSelector.Items.Add("German");
                SubjectSelector.Items.Add("German Continuers");
                SubjectSelector.Items.Add("Extension German");
                SubjectSelector.Items.Add("German Beginners");
                SubjectSelector.Items.Add("Japanese");
                SubjectSelector.Items.Add("Japanese Continuers");
                SubjectSelector.Items.Add("Extension Japanese");
                SubjectSelector.Items.Add("Japanese Beginners");
                SubjectSelector.Items.Add("French");
                SubjectSelector.Items.Add("French Continuers");
                SubjectSelector.Items.Add("Extension French");
                SubjectSelector.Items.Add("French Beginners");
                SubjectSelector.Items.Add("Latin");
                SubjectSelector.Items.Add("Extension Latin");

            }
        }

        private void DueDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            

        }

        private void Slider_DragCompleted(object sender, EventArgs e)
        {
            var test = Slider.ValueProperty;
            Console.WriteLine(test);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void ImageButton_Focused(object sender, FocusEventArgs e)
        {

        }
    }
}