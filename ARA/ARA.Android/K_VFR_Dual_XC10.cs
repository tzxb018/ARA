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
    [Activity(Label = "Alternate Risk - 3 of 3", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class K_VFR_Dual_XC10 : Activity
    {
        public static int vis, fuel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblVIs = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btn7 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn6 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn5 = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtVis = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblFuel = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btn60 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn45to60 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var bnt30to45 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtFuel = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblVIs.Text = "Visibility";
            btn7.Text = "7+ SM";
            btn6.Text = "6 SM";
            btn5.Text = "5 SM";
            txtVis.Text = "You have selected the '" + btn7.Text + "' choice.";

            lblFuel.Text = "Fuel Remaining";
            btn60.Text = "> 60 min";
            btn45to60.Text = "45 - 60 min";
            bnt30to45.Text = "30 - 45 min";
            txtFuel.Text = "You have selected the '" + btn60.Text + "' choice.";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn7, btn6, btn5, txtVis, vis);
            class1.defaultVals(btn60, btn45to60, bnt30to45, txtFuel, fuel);

            K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + K_VFR_Dual_XC9.ceiling + K_VFR_Dual_XC9.xwind + fuel + vis;
            class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);

            btn7.Touch += (s, e) =>
            {
                vis = class1.button1Pressed(btn7, btn6, btn5, txtVis);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + K_VFR_Dual_XC9.ceiling + K_VFR_Dual_XC9.xwind + fuel + vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);
            };
            btn6.Touch += (s, e) =>
            {
                vis = class1.button2Pressed(btn7, btn6, btn5, txtVis);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + K_VFR_Dual_XC9.ceiling + K_VFR_Dual_XC9.xwind + fuel + vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);
            };
            btn5.Touch += (s, e) =>
            {
                vis = class1.button3Pressed(btn7, btn6, btn5, txtVis);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + K_VFR_Dual_XC9.ceiling + K_VFR_Dual_XC9.xwind + fuel + vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);

            };

            btn60.Touch += (s, e) =>
            {
                fuel = class1.button1Pressed(btn60, btn45to60, bnt30to45, txtFuel);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + K_VFR_Dual_XC9.ceiling + K_VFR_Dual_XC9.xwind + fuel + vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);
            };
            btn45to60.Touch += (s, e) =>
            {
                fuel = class1.button2Pressed(btn60, btn45to60, bnt30to45, txtFuel);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + K_VFR_Dual_XC9.ceiling + K_VFR_Dual_XC9.xwind + fuel + vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);
            };
            bnt30to45.Touch += (s, e) =>
            {
                fuel = class1.button3Pressed(btn60, btn45to60, bnt30to45, txtFuel);
                K_VFR_Dual_XC8.altRisk = K_VFR_Dual_XC8.windCFI + K_VFR_Dual_XC8.windComm + K_VFR_Dual_XC8.windPime + K_VFR_Dual_XC9.ceiling + K_VFR_Dual_XC9.xwind + fuel + vis;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", K_VFR_Dual_XC8.altRisk, 8, 10);
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(K_VFR_Dual_XC9));
            };

            btnNext.Click += delegate
            {
                if (K_VFR_Dual_XC8.altRisk > 9)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Alert");
                    alert.SetMessage("Your alternate risk is too high!");
                    alert.SetNeutralButton("OK", delegate
                    {
                        alert.Dispose();
                    });
                    alert.Show();
                }
                else
                {

                }
            };
        }
    }
}