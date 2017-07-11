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
    public class I_VFR_Day_XCPIC : Activity
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

            var lblOtherLanding = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btnLessThan10 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn10to14 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btnPlus14 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtOtherLanding = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtPICRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtPICRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

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

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btnLessThan30, btn30to45, btn45Plus, txtCFILanding, CFI_Landing);
            class1.defaultVals(btnLessThan10, btn10to14, btnPlus14, txtOtherLanding, Other_Landing);

            class1.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", CFI_Landing + Other_Landing, 1, 3);

            btnLessThan30.Click += delegate
            {
                CFI_Landing = class1.button1Pressed(btnLessThan30, btn30to45, btn45Plus, txtCFILanding);
                class1.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", CFI_Landing + Other_Landing, 1, 3);
            };

            btn30to45.Click += delegate
            {
                CFI_Landing = class1.button2Pressed(btnLessThan30, btn30to45, btn45Plus, txtCFILanding);
                class1.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", CFI_Landing + Other_Landing, 1, 3);
            };

            btn45Plus.Click += delegate
            {
                CFI_Landing = class1.button3Pressed(btnLessThan30, btn30to45, btn45Plus, txtCFILanding);
                class1.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", CFI_Landing + Other_Landing, 1, 3);
            };

            btnLessThan10.Click += delegate
            {
                Other_Landing = class1.button1Pressed(btnLessThan10, btn10to14, btnPlus14, txtOtherLanding);
                class1.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", CFI_Landing + Other_Landing, 1, 3);
            };

            btn10to14.Click += delegate
            {
                Other_Landing = class1.button2Pressed(btnLessThan10, btn10to14, btnPlus14, txtOtherLanding);
                class1.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", CFI_Landing + Other_Landing, 1, 3);
            };

            btnPlus14.Click += delegate
            {
                Other_Landing = class1.button3Pressed(btnLessThan10, btn10to14, btnPlus14, txtOtherLanding);
                class1.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", CFI_Landing + Other_Landing, 1, 3);
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(I_VFR_Day_XC8));
            };

            btnNext.Click += delegate
            {
                if (I_VFR_Day_XC7.altRisk > 2)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Alert");
                    alert.SetMessage("Your PIC Risk is too high!");
                    alert.SetNeutralButton("OK", delegate
                    {
                        alert.Dispose();
                    });
                    alert.Show();

                    class1.defaultVals(btnLessThan30, btn30to45, btn45Plus, txtCFILanding, CFI_Landing);
                    class1.defaultVals(btnLessThan10, btn10to14, btnPlus14, txtOtherLanding, Other_Landing);
                }
                else
                {

                }
            };
        }
    }
}