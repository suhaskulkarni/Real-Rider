//*************************************************************************************************
// REALRIDER® Technical Test.
// file="SplashScreenView.cs"
//*************************************************************************************************

namespace RealRider.Droid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using RealRider.Droid.Views;

    [Activity(MainLauncher = true, Theme = "@style/MyTheme.Splash", NoHistory = true)]
	public class SplashScreenView : Activity
	{
        /// <summary>
        /// Creates the page of splash screen and then navigates to main page.
        /// </summary>
        /// <param name="savedInstanceState"></param>
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			Task.Delay(3000);
			StartActivity(new Intent(Application.Context, typeof(RealRiderMainView)));
		}
	}
}

