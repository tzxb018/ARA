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
    [Activity(Label = "PIC - 1 of 1")]
    public class I_VFR_Day_Local_PIC : Activity
    {
        public static int CFI_Landing;
        public static int Other_Landing;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblCFILanding = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btnLessThan30 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn30to45 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn45Plus = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtCFILanding = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblOtherLanding = FindViewById<TextView>(Resource.Id.txt2Answer2);
            var btnLessThan10 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn10to14 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btnPlus14 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtOtherLanding = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtPICRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);

            lblCFILanding.Text = "Last dual landing (C, CFI)";
            btnLessThan30.Text = "<30 days";
            btn30to45.Text = "30 - 45 days";
            btn45Plus.Text = ">45 days";
            txtCFILanding.Text = "You have selected the '" + btnLessThan30.Text + "' choice.";

            lblOtherLanding.Text = "Last dual landing (Other)";
            btnLessThan10.Text = "<10 days";
            btn10to14.Text = "10 - 14 days";
            btnPlus14.Text = ">14 days";
            txtOtherLanding.Text = "You have selected the '" + btnLessThan10.Text + "' choice.";

            if (CFI_Landing + Other_Landing == 0)
            {
                txtPICRisk.SetTextColor(Android.Graphics.Color.Green);
                txtPICRisk.Text = "PIC Risk - OKAY";
            }



        }
    }
}