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
    [Activity(Label = "Type of Flight - 3 of 5", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class C_Time_VFR_Activity : Activity
    {
        public static bool VFRisDay;
        public static bool VFRisDual;
        public static bool VFRisNight;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.c_Time_VFR);

            var back = FindViewById<ImageButton>(Resource.Id.btnBackFromVFRTime);
            var next = FindViewById<ImageButton>(Resource.Id.btnContinuefromVFRTime);
            var VFR_Day = FindViewById<Button>(Resource.Id.btnDayVFR);
            var VFR_Dual = FindViewById<Button>(Resource.Id.btnDualVFR);
            var VFR_Night = FindViewById<Button>(Resource.Id.btnNightVFR);
            var VFR_Text = FindViewById<TextView>(Resource.Id.txtVFRTime);
            
            //setting up the screen using the boolean values (if first time, all bool will be false, therefore none of these will run)
            if (VFRisDay)
            {
                VFR_Day.Selected = true;
                VFR_Dual.Selected = false;
                VFR_Night.Selected = false;
                VFR_Day.RequestFocus();
                VFR_Text.Text = "You have selected the Day Option.";
            }
            if (VFRisDual)
            {
                VFR_Dual.Selected = true;
                VFR_Day.Selected = false;
                VFR_Night.Selected = false;
                VFR_Dual.RequestFocus();
                VFR_Text.Text = "You have selected the Day/Night Option.";
            }
            if (VFRisNight)
            {
                VFR_Night.Selected = true;
                VFR_Day.Selected = false;
                VFR_Dual.Selected = false;
                VFR_Night.RequestFocus();
                VFR_Text.Text = "You have selected the Night Option.";
            }

            //when one of them are clicked, the rest are unselected, because only one option can be selected
            VFR_Day.Click += delegate
            {
                VFR_Day.Selected = true;
                VFR_Dual.Selected = false;
                VFR_Night.Selected = false;
                VFR_Day.RequestFocus();
                VFR_Text.Text = "You have selected the Day Option."; //displaying the selection
                VFRisDay = true;
                VFRisDual = false;
                VFRisNight = false; //setting and changing the respecitive booleans
            };
            VFR_Dual.Click += delegate
            {
                VFR_Day.Selected = false;
                VFR_Dual.Selected = true;
                VFR_Night.Selected = false;
                VFR_Dual.RequestFocus();
                VFR_Text.Text = "You have selected the Day/Night Option."; //displaying the selection
                VFRisDay = false;
                VFRisDual = true;
                VFRisNight = false; //setting and changing the respecitive booleans
            };
            VFR_Night.Click += delegate
            {
                VFR_Day.Selected = false;
                VFR_Dual.Selected = false;
                VFR_Night.Selected = true;
                VFR_Night.RequestFocus();
                VFR_Text.Text = "You have selected the Night Option."; //displaying the selection
                VFRisDay = false;
                VFRisDual = false;
                VFRisNight = true; //setting and changing the respecitive booleans
            };

            back.Click += delegate
            {
                StartActivity(typeof(B_Filing_Criteria_Activity));
            };

            next.Click += delegate
            {
                if (VFRisDay == false && VFRisDual == false && VFRisNight == false)
                {
                    AlertDialog.Builder alertVFR = new AlertDialog.Builder(this);
                    alertVFR.SetTitle("Alert");
                    alertVFR.SetMessage("You must select a time to continue.");
                    alertVFR.SetNeutralButton("OK", delegate
                    {
                        alertVFR.Dispose();
                    });
                    alertVFR.Show();
                }
                else
                {
                    StartActivity(typeof(D_Syllabus_Activity));
                }
            };

        }
    }
}