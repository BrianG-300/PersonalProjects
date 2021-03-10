
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ArsenalAnalyzer.Droid
{
    [Activity(Label = "Arsenal Analyzer", Theme = "@style/MainTheme.Splash", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.UiMode, ScreenOrientation = ScreenOrientation.Portrait)]

    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            var startingIntent = new Intent(this, typeof(MainActivity));

            StartActivity(startingIntent);

        }
    }
}
