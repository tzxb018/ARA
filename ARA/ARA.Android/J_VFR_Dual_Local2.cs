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
    [Activity(Label = "Home Airfield - 2 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class J_VFR_Dual_Local2 : Activity
    {
        public static int xwind;
        public static int time;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblxwind = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btn0to5 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn6to10 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn11to15 = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtxwind = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblTime = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btnDay = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btnNight = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btnBoth = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtTime = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblxwind.Text = "Xwind";
            btn0to5.Text = "0 - 5 kts";
            btn6to10.Text = "6 - 10 kts";
            btn11to15.Text = "11 to 15 kts";
            txtxwind.Text = "You have selected the '" + btn0to5.Text + "' choice.";

            lblTime.Text = "What time of day are you flying?";
            btnDay.Text = "Day";
            btnNight.Text = "Night";
            btnBoth.Text = "Both Day and Night";
            txtTime.Text = "You have selected the '" + btnDay.Text + "' choice.";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn0to5, btn6to10, btn11to15, txtxwind, xwind);
            class1.defaultVals(btnDay, btnNight, btnBoth, txtTime, time);


            if (time == 0)
            {
                J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;
            }
            else if (time == 1)
            {
                J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
            }
            else
            {
                J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;
            }
            
            class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk",  J_VFR_Dual_Local1.homeRisk, 7, 9);

            btn0to5.Touch += (s,e) =>
            {
                xwind = class1.button1Pressed(btn0to5, btn6to10, btn11to15, txtxwind);

                if (time == 0)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;
                }
                else if (time == 1)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;
                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };
            btn6to10.Touch += (s,e) =>
            {
                xwind = class1.button2Pressed(btn0to5, btn6to10, btn11to15, txtxwind);

                if (time == 0)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;
                }
                else if (time == 1)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;
                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };
            btn11to15.Touch += (s,e) =>
            {
                xwind = class1.button3Pressed(btn0to5, btn6to10, btn11to15, txtxwind);

                if (time == 0)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;
                }
                else if (time == 1)
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    J_VFR_Dual_Local1.homeRisk = J_VFR_Dual_Local1.windCFI + J_VFR_Dual_Local1.windComm + J_VFR_Dual_Local1.windPime + xwind + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;
                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", J_VFR_Dual_Local1.homeRisk, 7, 9);
            };

            btnDay.Touch += (s,e) =>
            {
                time = class1.button1Pressed(btnDay, btnNight, btnBoth, txtTime);
            };
            btnNight.Touch += (s,e) =>
            {
                time = class1.button2Pressed(btnDay, btnNight, btnBoth, txtTime);

            };
            btnBoth.Touch += (s,e) =>
            {
                time = class1.button3Pressed(btnDay, btnNight, btnBoth, txtTime);

            };

            btnNext.Touch += (s,e) =>
            {
                if (time == 0 || time == 3)
                {
                    StartActivity(typeof(J_VFR_Dual_Local3Day));
                }
                else if (time == 1)
                {
                    StartActivity(typeof(J_VFR_Dual_Local4Night));
                }
             
            };

            btnBack.Touch += (s,e) =>
            {
                StartActivity(typeof(J_VFR_Dual_Local1));
            };


        }
    }
}