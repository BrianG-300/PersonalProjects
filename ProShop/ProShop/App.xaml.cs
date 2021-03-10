using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProShop.Views;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;
using ProShop.Services;
using Syncfusion.Licensing;

namespace ProShop
{
    public partial class App : Application
    {
        static PlayerDatabase database;

        public static PlayerDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PlayerDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Players.db3"));
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
