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
    [Activity(Label = "Personal Information - 5 of 5")]
    public class E_Personal_Information : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.e_Personal_Info);

            var submit = FindViewById<Button>(Resource.Id.btnSubmit);
            var back = FindViewById<ImageButton>(Resource.Id.btnBackFromPersonalInfo);

            back.Click += delegate
            {
                StartActivity(typeof(D_Syllabus_Activity));
            };

        }
    }
}