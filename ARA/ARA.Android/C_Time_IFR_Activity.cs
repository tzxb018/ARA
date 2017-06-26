using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ARA.Droid
{
    [Activity(Label = "Type of Flight - 3 of 5")]
    public class C_Time_IFR_Activity : Activity
    {
        public static bool IFRisDual;
        public static bool IFRisDay;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.c_Time_IFR);

            var back = FindViewById<ImageButton>(Resource.Id.btnBackfromIFRTime);
            var next = FindViewById<ImageButton>(Resource.Id.btnContinuefromIFRTime);
            var IFR_Dual = FindViewById<Button>(Resource.Id.btnDualIFR);
            var IFR_Day = FindViewById<Button>(Resource.Id.btnDayIFR);
            var IFR_Text = FindViewById<TextView>(Resource.Id.txtIFRTime);

            if (IFRisDual) //opens the page with the options already selected
            {
                IFR_Dual.Selected = true;
                IFR_Day.Selected = false;
                IFR_Day.Pressed = true; //changing the states of the two buttons to allow the user to see which he/she has selected
                IFR_Dual.RequestFocus();
                IFR_Text.Text = "You have selected the Day/Night Option.";
            }
            else if (IFRisDay)
            {
                IFR_Day.Selected = true;
                IFR_Dual.Selected = false;
                IFR_Dual.Pressed = true;
                IFR_Day.RequestFocus();
                IFR_Text.Text = "You have selcted the Day Time Option.";
            }

            IFR_Dual.Click += delegate
            {
                IFR_Dual.Selected = true;
                IFR_Day.Selected = false;
                IFR_Day.Pressed = true; //changing the states of the two buttons to allow the user to see which he/she has selected
                IFR_Dual.RequestFocus();
                IFRisDual = true;
                IFRisDay = false; //changing the variables
                IFR_Text.Text = "You have selected the Day/Night Option.";
            };

            IFR_Day.Click += delegate
            {
                IFR_Day.Selected = true;
                IFR_Dual.Selected = false;
                IFR_Dual.Pressed = true;
                IFR_Day.RequestFocus();
                IFRisDay = true;
                IFRisDual = false;
                IFR_Text.Text = "You have selcted the Day Time Option.";
            };

            back.Click += delegate
            {
                StartActivity(typeof(B_Filing_Criteria_Activity));
            };

            next.Click += delegate
            {
                StartActivity(typeof(D_Syllabus_Activity));
            };
        }
    }
}