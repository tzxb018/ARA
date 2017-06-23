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
    [Activity(Label = "D_Syllabus_Activity")]
    public class D_Syllabus_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.d_syllabus);

            var back = FindViewById<ImageButton>(Resource.Id.btnBackFromSyllabus);
            var next = FindViewById<ImageButton>(Resource.Id.btnContinueFromSyllabus);

            back.Click += delegate
            {
                if (B_Filing_Criteria_Activity.isVFR)
                {
                    StartActivity(typeof(C_Time_VFR_Activity));
                }
                else
                {
                    StartActivity(typeof(C_Time_IFR_Activity));
                }
                //returns back to the previous page using a boolean from the selecting page of VFR vs. IFR
            };
        }
    }
}