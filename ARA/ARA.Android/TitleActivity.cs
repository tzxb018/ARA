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
    [Activity(Label = "UNO Flight Risk Assessment", MainLauncher = true )]
    public class TitleActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            StartActivity(typeof(A_Flight_Info_Activity));
        }
    }
}