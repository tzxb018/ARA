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
    [Activity(Label = "Night Info", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class J_VFR_Dual_Local4Night : Activity
    {
        public static int nightCeiling;
        public static int nightVis;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblCeiling = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btn4000 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn3500 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn3000 = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtCeiling = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblVIs = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btn7 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn6 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn5 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtVis = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblCeiling.Text = "Ceiling (day)";
            btn4000.Text = "4000 + ft";
            btn3500.Text = "3500 - 3999 ft";
            btn3000.Text = "3000 - 3499 ft";
            txtCeiling.Text = "You have selected the '" + btn4000.Text + "' choice.";

            lblVIs.Text = "Visibility (day)";
            btn7.Text = "7+ SM";
            btn6.Text = "6 SM";
            btn5.Text = "5 SM";
            txtVis.Text = "You have selected the '" + btn7.Text + "' choice.";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn4000, btn3500, btn3000, txtCeiling, nightCeiling);
            class1.defaultVals(btn7, btn6, btn5, txtVis, nightVis);

            if (J_VFR_Dual_Local2.time == 3)
            {
                J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;
            }
            else if (J_VFR_Dual_Local2.time == 1)
            {
                J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling;
            }
            class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);

            btn4000.Touch += (s,e) =>
            {
                nightCeiling = class1.button1Pressed(btn4000, btn3500, btn3000, txtCeiling);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;
                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling;
                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };
            btn3500.Touch += (s,e) =>
            {
                nightCeiling = class1.button2Pressed(btn4000, btn3500, btn3000, txtCeiling);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;
                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling;
                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };
            btn3000.Touch += (s,e) =>
            {
                nightCeiling = class1.button3Pressed(btn4000, btn3500, btn3000, txtCeiling);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;
                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling;
                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };

            btn7.Touch += (s,e) =>
            {
                nightVis = class1.button1Pressed(btn7, btn6, btn5, txtVis);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;
                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling;
                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };
            btn6.Touch += (s,e) =>
            {
                nightVis = class1.button2Pressed(btn7, btn6, btn5, txtVis);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;
                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling;
                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);

            };
            btn5.Touch += (s,e) =>
            {
                nightVis = class1.button3Pressed(btn7, btn6, btn5, txtVis);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;
                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + nightVis + nightCeiling;
                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };

            btnNext.Touch += (s,e) =>
            {
                if (J_VFR_Dual_Local1.homeRisk > 9)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Alert");
                    alert.SetMessage("Your " + "Home Airfield Risk" + " is too high!");
                    alert.SetNeutralButton("OK", delegate
                    {
                        alert.Dispose();
                    });
                    alert.Show();
                }
                else
                {
                    StartActivity(typeof(Y_Aircraft_and_Instructor));
                }
            };

            btnBack.Touch += (s,e) =>
            {
                if (J_VFR_Dual_Local2.time == 1)
                {
                    StartActivity(typeof(J_VFR_Dual_Local2));

                }
                else if (J_VFR_Dual_Local2.time == 3)
                {
                    StartActivity(typeof(J_VFR_Dual_Local3Day));
                }
            };
        }
    }
}