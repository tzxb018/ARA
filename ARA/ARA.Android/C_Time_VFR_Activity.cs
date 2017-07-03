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
                VFR_Day.Pressed = true;
                VFR_Dual.Pressed = false;
                VFR_Night.Pressed = false;
                VFR_Text.Text = "You have selected the Day Option.";
            }
            if (VFRisDual)
            {
                VFR_Day.Pressed = false;
                VFR_Dual.Pressed = true;
                VFR_Night.Pressed = false;
                VFR_Text.Text = "You have selected the Day/Night Option.";
            }
            if (VFRisNight)
            {
                VFR_Day.Pressed = false;
                VFR_Dual.Pressed = false;
                VFR_Night.Pressed = true;
                VFR_Text.Text = "You have selected the Night Option.";
            }

            //when one of them are clicked, the rest are unselected, because only one option can be selected
            VFR_Day.Touch += (s,e) =>
            {
                if (e.Event.Action == Android.Views.MotionEventActions.Down)
                {
                    e.Handled = true;
                    return;
                }

                if (e.Event.Action == Android.Views.MotionEventActions.Up)
                {
                    e.Handled = false;
                }

                if (VFR_Day.Pressed == false)
                    VFR_Day.Pressed = !VFR_Day.Pressed;

                e.Handled = true;

                VFR_Dual.Pressed = false;
                VFR_Night.Pressed = false;

                VFR_Text.Text = "You have selected the Day Option."; //displaying the selection

                VFRisDay = true;
                VFRisDual = false;
                VFRisNight = false; //setting and changing the respecitive booleans
            };
            VFR_Dual.Touch += (s,e) =>
            {
                if (e.Event.Action == Android.Views.MotionEventActions.Down)
                {
                    e.Handled = true;
                    return;
                }

                if (e.Event.Action == Android.Views.MotionEventActions.Up)
                {
                    e.Handled = false;
                }

                if (VFR_Dual.Pressed == false)
                    VFR_Dual.Pressed = !VFR_Dual.Pressed;

                e.Handled = true;

                VFR_Day.Pressed = false;
                VFR_Night.Pressed = false;

                VFR_Text.Text = "You have selected the Day/Night Option."; //displaying the selection
                VFRisDay = false;
                VFRisDual = true;
                VFRisNight = false; //setting and changing the respecitive booleans
            };
            VFR_Night.Touch += (s,e) =>
            {
                if (e.Event.Action == Android.Views.MotionEventActions.Down)
                {
                    e.Handled = true;
                    return;
                }

                if (e.Event.Action == Android.Views.MotionEventActions.Up)
                {
                    e.Handled = false;
                }

                if (VFR_Night.Pressed == false)
                    VFR_Night.Pressed = !VFR_Night.Pressed;

                e.Handled = true;

                VFR_Day.Pressed = false;
                VFR_Dual.Pressed = false;

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