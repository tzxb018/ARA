using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ARA.Droid
{
	[Activity (Label = "UNO Flight Risk Assessment",  ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)] //, MainLauncher = true)] // Theme="@style/MainTheme", 
   
    public class A_Flight_Info_Activity : Activity //global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{

        public static bool isNOTMAS;
        public static bool isFBO;
        public static bool isFlightPlan = true;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
           
            SetContentView(Resource.Layout.a_Flight_Info);


            var next = FindViewById<ImageButton>(Resource.Id.btnContinueFromFlightInfo1);
            var NOTMAS = FindViewById<ToggleButton>(Resource.Id.tglNOTMAS);
            var FBO = FindViewById<ToggleButton>(Resource.Id.tglFBO);
            var FlightPlan = FindViewById<ToggleButton>(Resource.Id.tglFlightPlan);

            //setting up tgl buttons based on static variables
            if (isNOTMAS)
            {
                NOTMAS.Checked = true;
            }
            else
                NOTMAS.Checked = false;

            if (isFBO)
            {
                FBO.Checked = true;
            }
            else
            {
                FBO.Checked = false;
            }

            if (isFlightPlan)
            {
                FlightPlan.Checked = true;
            }
            else
            {
                FlightPlan.Checked = false;
            }

            //Changes the static var associated with the toggle button to keep the boolean data through out the program
            NOTMAS.Click += (s, e) =>
            {
                if (NOTMAS.Checked)
                    isNOTMAS = true;
                else
                {
                    isNOTMAS = false;
                }
            };

            FBO.Click += (s, e) =>
            {
                if (FBO.Checked)
                    isFBO = true;
                else
                    isFBO = false;
            };

            FlightPlan.Click += (s, e) =>
            {
                if (FlightPlan.Checked)
                {
                    isFlightPlan = true;
                }
                else
                    isFlightPlan = false;
            };


            next.Click += delegate
            {
                //NOTMAS and FBO have to be checked as yes in order for the survey to continue
                if (isFBO == true && isNOTMAS == true)
                    StartActivity(typeof(B_Filing_Criteria_Activity));
                else
                {
                    AlertDialog.Builder alertFBOandNOTMAS = new AlertDialog.Builder(this);
                    alertFBOandNOTMAS.SetTitle("Alert");
                    alertFBOandNOTMAS.SetMessage("You must have to have checked NOTAMS and FBO to proceed with flight.");
                    alertFBOandNOTMAS.SetNeutralButton("OK", delegate
                    {
                        alertFBOandNOTMAS.Dispose();
                    });
                    alertFBOandNOTMAS.Show();
                }
            };


			//global::Xamarin.Forms.Forms.Init (this, savedInstanceState);
			//LoadApplication (new ARA.App ());
		}
	}
}

