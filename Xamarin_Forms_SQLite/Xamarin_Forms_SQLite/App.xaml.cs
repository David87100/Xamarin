using System;
using System.IO;
using Xamarin_Forms_SQLite.Repositories;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Xamarin_Forms_SQLite
{
    public partial class App : Application
    {
        protected string dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db3");
        public static HumeurRepository HumeurRepository { get; set; }
        
        public App()
        {
            InitializeComponent();
            MainPage = new TabbedPage1();
            HumeurRepository = new HumeurRepository(dbPath);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}