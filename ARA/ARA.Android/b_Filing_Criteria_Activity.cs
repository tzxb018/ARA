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
    [Activity(Label = "Filing Criteria - 2 of 5")]
    public class B_Filing_Criteria_Activity : Activity
    {
        public static bool isVFR;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.b_Filing_Criteria);

            var next = FindViewById<ImageButton>(Resource.Id.btnContinueFromFilingCriteria);
            var back = FindViewById<ImageButton>(Resource.Id.btnBackfromFilingCriteria);
            var VFR_IFR = FindViewById<ToggleButton>(Resource.Id.tglFilingCriteria);

            if (isVFR) //setting toggle button to value given by the static bool 
            {
                VFR_IFR.Checked = true;
            }
            else
            {
                VFR_IFR.Checked = false;
            }

            VFR_IFR.Click += (s, e) => //if any chanages are made to the toggle button, the next slide has to correspond to the next change
            {
                if (VFR_IFR.Checked)
                {
                    isVFR = true;
                }
                else
                {
                    isVFR = false;
                }
            };

            next.Click += delegate //when clicked, it checks for the bool and then starts the appropriate activity
            {
                if (isVFR == true)
                {
                    StartActivity(typeof(C_Time_VFR_Activity));
                }
                else
                    StartActivity(typeof(C_Time_IFR_Activity));
            };

            back.Click += delegate //goes back to the first activity, with all the values inputted by the user svaed on there
            {
                StartActivity(typeof(A_Flight_Info_Activity));
            };


        }
    }
}