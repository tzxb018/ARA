using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ARA.Droid
{
	[Activity (Label = "Flight Information - 1 of 5", Icon = "@drawable/icon", MainLauncher = true)] // Theme="@style/MainTheme", 
    public class A_Flight_Info_Activity : Activity //global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
           
            SetContentView(Resource.Layout.a_Flight_Info);


            var next = FindViewById<ImageButton>(Resource.Id.btnContinueFromFlightInfo1);

            next.Click += delegate
            {
                StartActivity(typeof(B_Filing_Criteria_Activity));
            };


			//global::Xamarin.Forms.Forms.Init (this, savedInstanceState);
			//LoadApplication (new ARA.App ());
		}
	}
}

