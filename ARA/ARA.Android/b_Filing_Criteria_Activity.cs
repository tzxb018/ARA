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

            next.Click += delegate //in case user does not press the toggle button, then the next button has to be triggered to first state of the toggle button
            {
                StartActivity(typeof(C_Time_IFR_Activity));
                isVFR = false;
            };

            VFR_IFR.CheckedChange += (s, e) => //if any chanages are made to the toggle button, the next slide has to correspond to the next change
            {
                if (e.IsChecked)
                {
                    
                    next.Click += delegate
                    {
                        StartActivity(typeof(C_Time_VFR_Activity));
                        isVFR = true;
                    };
                }
                else
                {
                    
                    next.Click += delegate
                    {
                        StartActivity(typeof(C_Time_IFR_Activity));
                        isVFR = false;
                    };
                }
            };

            back.Click += delegate
            {
                StartActivity(typeof(A_Flight_Info_Activity));
            };


        }
    }
}