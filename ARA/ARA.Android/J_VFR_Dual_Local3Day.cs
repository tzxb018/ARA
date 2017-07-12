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
    [Activity(Label = "Daytime Info")]
    public class J_VFR_Dual_Local3Day : Activity
    {
        public static int ceilingDay;
        public static int visDay;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblCeiling = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btn3000 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn2500 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn2000 = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtCeiling = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblVIs = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btn5 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn4 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn3 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtVis = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblCeiling.Text = "Ceiling (day)";
            btn3000.Text = "3000 + ft";
            btn2500.Text = "2500 - 2999 ft";
            btn2000.Text = "2000 - 2499 ft";
            txtCeiling.Text = "You have selected the '" + btn3000.Text + "' choice.";

            lblVIs.Text = "Visibility (day)";
            btn5.Text = "5+ SM";
            btn4.Text = "4 SM";
            btn3.Text = "3 SM";
            txtVis.Text = "You have selected the '" + btn5.Text + "' choice.";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn3000, btn2500, btn2000, txtCeiling, ceilingDay);
            class1.defaultVals(btn5, btn4, btn3, txtVis, visDay);

            if (J_VFR_Dual_Local2.time == 3)
            {
                J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
            }
            else
            {
                J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay;

            }
            class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);

            btn3000.Touch += (s,e) =>
            {
                ceilingDay = class1.button1Pressed(btn3000, btn2500, btn2000, txtCeiling);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };
            btn2500.Touch += (s,e) =>
            {
                ceilingDay = class1.button2Pressed(btn3000, btn2500, btn2000, txtCeiling);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };
            btn2000.Touch += (s,e) =>
            {
                ceilingDay = class1.button3Pressed(btn3000, btn2500, btn2000, txtCeiling);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };

            btn5.Touch += (s,e) =>
            {
                visDay = class1.button1Pressed(btn5, btn4, btn3, txtVis);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };
            btn4.Touch += (s,e) =>
            {
                visDay = class1.button2Pressed(btn5, btn4, btn3, txtVis);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);

            };
            btn3.Touch += (s,e) =>
            {
                visDay = class1.button3Pressed(btn5, btn4, btn3, txtVis);
                if (J_VFR_Dual_Local2.time == 3)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + J_VFR_Dual_Local2.xwind + visDay + ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };

            btnNext.Touch += (s,e) =>
            {
                if (J_VFR_Dual_Local2.time == 3)
                {
                    StartActivity(typeof(J_VFR_Dual_Local4Night));
                }
                else
                {
                    if (J_VFR_Dual_Local1.homeRisk > 9)
                    {
                        AlertDialog.Builder alert = new AlertDialog.Builder(this);
                        alert.SetTitle("Alert");
                        alert.SetMessage("Your home airfield risk is too high!");
                        alert.SetNeutralButton("OK", delegate
                        {
                            alert.Dispose();
                        });
                        alert.Show();
                    }
                }
            };

            btnBack.Touch += (s,e) =>
            {
                StartActivity(typeof(J_VFR_Dual_Local2));
            };

        }
    }
}