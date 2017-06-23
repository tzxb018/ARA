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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.c_Time_IFR);

            var back = FindViewById<ImageButton>(Resource.Id.btnBackfromIFRTime);
            var next = FindViewById<ImageButton>(Resource.Id.btnContinuefromIFRTime);

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