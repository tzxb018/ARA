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
    [Activity(Label = "Filing_Criteria_Activity")]
    public class Filing_Criteria_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.b_Filing_Criteria);

            var next = FindViewById<ImageButton>(Resource.Id.btnContinueFromFilingCriteria);
            var back = FindViewById<ImageButton>(Resource.Id.btnBackfromFilingCriteria);

            back.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };


        }
    }
}