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
    [Activity(Label = "Alternate Risk - 2 of 3", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class K_VFR_Dual_XC9 : Activity
    {
        public static int xwind, ceiling;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var lblxwind = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btn0to5 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn6to10 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn11to15 = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtxwind = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblCeiling = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btn4000 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn3500 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn3000 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtCeiling = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);
            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);

            lblxwind.Text = "Xwind";
            btn0to5.Text = "0 - 5 kts";
            btn6to10.Text = "6 - 10 kts";
            btn11to15.Text = "11 - 15 kts";

            lblCeiling.Text = "Ceiling";
            btn4000.Text = "4000 ft";
            btn3500.Text = "3500 - 3999 ft";
            btn3000.Text = "3000 - 3499 ft";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn0to5, btn6to10, btn11to15, txtxwind, xwind);
            class1.defaultVals(btn4000, btn3500, btn3000, txtCeiling, ceiling);

            K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + ceiling + xwind + K_VFR_Dual_XC10.fuel + K_VFR_Dual_XC10.vis;
            class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);

            btn0to5.Touch += (s, e) =>
            {
                xwind = class1.button1Pressed(btn0to5, btn6to10, btn11to15, txtxwind);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + ceiling + xwind + K_VFR_Dual_XC10.fuel + K_VFR_Dual_XC10.vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);
            };
            btn6to10.Touch += (s, e) =>
            {
                xwind = class1.button2Pressed(btn0to5, btn6to10, btn11to15, txtxwind);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + ceiling + xwind + K_VFR_Dual_XC10.fuel + K_VFR_Dual_XC10.vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);
            };
            btn11to15.Touch += (s, e) =>
            {
                xwind = class1.button3Pressed(btn0to5, btn6to10, btn11to15, txtxwind);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + ceiling + xwind + K_VFR_Dual_XC10.fuel + K_VFR_Dual_XC10.vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);
            };

            btn4000.Touch += (s, e) =>
            {
                ceiling = class1.button1Pressed(btn4000, btn3500, btn3000, txtCeiling);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + ceiling + xwind + K_VFR_Dual_XC10.fuel + K_VFR_Dual_XC10.vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);
            };
            btn3500.Touch += (s, e) =>
            {
                ceiling = class1.button2Pressed(btn4000, btn3500, btn3000, txtCeiling);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + ceiling + xwind + K_VFR_Dual_XC10.fuel + K_VFR_Dual_XC10.vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);
            };
            btn3000.Touch += (s, e) =>
            {
                ceiling = class1.button3Pressed(btn4000, btn3500, btn3000, txtCeiling);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + ceiling + xwind + K_VFR_Dual_XC10.fuel + K_VFR_Dual_XC10.vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);
            };

            btnBack.Touch += (s, e) =>
            {
                StartActivity(typeof(K_VFR_Dual_XC8));
            };

            btnNext.Touch += (s, e) =>
            {
                StartActivity(typeof(K_VFR_Dual_XC10));
            };
        }
    }
}