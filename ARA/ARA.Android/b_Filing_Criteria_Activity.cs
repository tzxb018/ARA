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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.b_Filing_Criteria);

            var next = FindViewById<ImageButton>(Resource.Id.btnContinueFromFilingCriteria);
            var back = FindViewById<ImageButton>(Resource.Id.btnBackfromFilingCriteria);
            var VFR_IFR = FindViewById<ToggleButton>(Resource.Id.tglFilingCriteria);
            var txt = FindViewById<TextView>(Resource.Id.txtVFRIFR);

            next.Click += delegate
            {
                StartActivity(typeof(C_Time_IFR_Activity));
            };

            VFR_IFR.CheckedChange += (s, e) =>
            {
                if (e.IsChecked)
                {
                    txt.Text = "VFR";
                    next.Click += delegate
                    {
                        StartActivity(typeof(C_Time_VFR_Activity));
                    };
                }
                else
                {
                    txt.Text = "IFR";
                    next.Click += delegate
                    {
                        StartActivity(typeof(C_Time_IFR_Activity));
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