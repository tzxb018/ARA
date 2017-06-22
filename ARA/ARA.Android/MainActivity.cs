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
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

			base.OnCreate (bundle);

           
            SetContentView(Resource.Layout.a_Flight_Info);


            var next = FindViewById<ImageButton>(Resource.Id.btnContinueFromFlightInfo1);

            next.Click += delegate
            {
                StartActivity(typeof(Filing_Criteria_Activity));
            };


			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new ARA.App ());
		}
	}
}

