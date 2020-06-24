using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App6.Services;
using App6.Views;
using System.IO;

namespace App6
{
    public partial class App : Application
    {

        public static string FilePath;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "DatabaseName.txt");
            FilePath = path;
        }

        public App(String filePath)
        {
            InitializeComponent();
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "DatabaseName.txt");
            filePath = path;
            FilePath = filePath;
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

       
        
        
    }
}
