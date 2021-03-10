using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArsenalAnalyzer.Services;
using ArsenalAnalyzer.Views;
using System.IO;
using Syncfusion.Licensing;

namespace ArsenalAnalyzer
{
    public partial class App : Application
    {
        static BallDatabase database;

        public static BallDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BallDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Balls.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            SyncfusionLicenseProvider.RegisterLicense("OTY4NzFAMzEzNzJlMzEyZTMwRmdoR2p3UkZ4dThlS2V6eXZmdnBHWkJnQUxWTkR3N2U5VEIwU3c4VWxCOD0=");

            MainPage = new MainPage();
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
