using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ARA.Droid
{
	[Activity (Label = "ARA", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 


			base.OnCreate (bundle);

            //testing purposes
            SetContentView(Resource.Layout.Time_VFR);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new ARA.App ());
		}
	}
}

