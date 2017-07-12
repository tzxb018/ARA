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
    [Activity(Label = "Departure Airfield - 2 of 2")]
    public class K_VFR_Dual_XC2 : Activity
    {
        public static int xwind, ceiling, vis;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.h_Layout_3);

            var lblxwind = FindViewById<TextView>(Resource.Id.txtQuestion1);
            var btn0to5 = FindViewById<Button>(Resource.Id.btnQ1C1);
            var btn6to10 = FindViewById<Button>(Resource.Id.btnQ1C2);
            var btn11to15 = FindViewById<Button>(Resource.Id.btnQ1C3);
            var txtxwind = FindViewById<TextView>(Resource.Id.txtAnswer1);

            var lblCeiling = FindViewById<TextView>(Resource.Id.txtQuestion2);
            var btn4000 = FindViewById<Button>(Resource.Id.btnQ2C1);
            var btn3500 = FindViewById<Button>(Resource.Id.btnQ2C2);
            var btn3000 = FindViewById<Button>(Resource.Id.btnQ2C3);
            var txtCeiling = FindViewById<TextView>(Resource.Id.txtAnswer2);

            var lblvis = FindViewById<TextView>(Resource.Id.txtQuestion3);
            var btn7 = FindViewById<Button>(Resource.Id.btnQ3C1);
            var btn6 = FindViewById<Button>(Resource.Id.btnQ3C2);
            var btn5 = FindViewById<Button>(Resource.Id.btnQ3C3);
            var txtvis = FindViewById<TextView>(Resource.Id.txtAnswer3);

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskText);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNum);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom3);
            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);

            lblxwind.Text = "Xwind";
            btn0to5.Text = "0 - 5 kts";
            btn6to10.Text = "6 - 10 kts";
            btn11to15.Text = "11 - 15 kts";

            lblCeiling.Text = "Ceiling";
            btn4000.Text = "4000 ft";
            btn3500.Text = "3500 - 3999 ft";
            btn3000.Text = "3000 - 3499 ft";

            lblvis.Text = "Visibility";
            btn7.Text = "7+ SM";
            btn6.Text = "6 SM";
            btn5.Text = "5 SM";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn0to5, btn6to10, btn11to15, txtxwind, xwind);
            class1.defaultVals(btn4000, btn3500, btn3000, txtCeiling, ceiling);
            class1.defaultVals(btn7, btn6, btn5, txtvis, vis);

            K_VFR_Dual_XC1.DepartureRisk = vis + xwind + ceiling + K_VFR_Dual_XC1.windCFI + K_VFR_Dual_XC1.windComm + K_VFR_Dual_XC1.windPime;
            class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", K_VFR_Dual_XC1.DepartureRisk, 7, 9);

            btn0to5.Touch += (s, e) =>
            {
                xwind = class1.button1Pressed(btn0to5, btn6to10, btn11to15, txtxwind);
                K_VFR_Dual_XC1.DepartureRisk = vis + xwind + ceiling + K_VFR_Dual_XC1.windCFI + K_VFR_Dual_XC1.windComm + K_VFR_Dual_XC1.windPime;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", K_VFR_Dual_XC1.DepartureRisk, 7, 9);
            };
            btn6to10.Touch += (s, e) =>
            {
                xwind = class1.button2Pressed(btn0to5, btn6to10, btn11to15, txtxwind);
                K_VFR_Dual_XC1.DepartureRisk = vis + xwind + ceiling + K_VFR_Dual_XC1.windCFI + K_VFR_Dual_XC1.windComm + K_VFR_Dual_XC1.windPime;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", K_VFR_Dual_XC1.DepartureRisk, 7, 9);
            };
            btn11to15.Touch += (s, e) =>
            {
                xwind = class1.button3Pressed(btn0to5, btn6to10, btn11to15, txtxwind);
                K_VFR_Dual_XC1.DepartureRisk = vis + xwind + ceiling + K_VFR_Dual_XC1.windCFI + K_VFR_Dual_XC1.windComm + K_VFR_Dual_XC1.windPime;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", K_VFR_Dual_XC1.DepartureRisk, 7, 9);
            };

            btn4000.Touch += (s, e) =>
            {
                ceiling = class1.button1Pressed(btn4000, btn3500, btn3000, txtCeiling);
                K_VFR_Dual_XC1.DepartureRisk = vis + xwind + ceiling + K_VFR_Dual_XC1.windCFI + K_VFR_Dual_XC1.windComm + K_VFR_Dual_XC1.windPime;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", K_VFR_Dual_XC1.DepartureRisk, 7, 9);
            };
            btn3500.Touch += (s, e) =>
            {
                ceiling = class1.button2Pressed(btn4000, btn3500, btn3000, txtCeiling);
                K_VFR_Dual_XC1.DepartureRisk = vis + xwind + ceiling + K_VFR_Dual_XC1.windCFI + K_VFR_Dual_XC1.windComm + K_VFR_Dual_XC1.windPime;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", K_VFR_Dual_XC1.DepartureRisk, 7, 9);
            };
            btn3000.Touch += (s, e) =>
            {
                ceiling = class1.button3Pressed(btn4000, btn3500, btn3000, txtCeiling);
                K_VFR_Dual_XC1.DepartureRisk = vis + xwind + ceiling + K_VFR_Dual_XC1.windCFI + K_VFR_Dual_XC1.windComm + K_VFR_Dual_XC1.windPime;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", K_VFR_Dual_XC1.DepartureRisk, 7, 9);
            };

            btn7.Touch += (s, e) =>
            {
                vis = class1.button1Pressed(btn7, btn6, btn5, txtvis);
                K_VFR_Dual_XC1.DepartureRisk = vis + xwind + ceiling + K_VFR_Dual_XC1.windCFI + K_VFR_Dual_XC1.windComm + K_VFR_Dual_XC1.windPime;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", K_VFR_Dual_XC1.DepartureRisk, 7, 9);
            };
            btn6.Touch += (s, e) =>
            {
                vis = class1.button2Pressed(btn7, btn6, btn5, txtvis);
                K_VFR_Dual_XC1.DepartureRisk = vis + xwind + ceiling + K_VFR_Dual_XC1.windCFI + K_VFR_Dual_XC1.windComm + K_VFR_Dual_XC1.windPime;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", K_VFR_Dual_XC1.DepartureRisk, 7, 9);
            };
            btn5.Touch += (s, e) =>
            {
                vis = class1.button3Pressed(btn7, btn6, btn5, txtvis);
                K_VFR_Dual_XC1.DepartureRisk = vis + xwind + ceiling + K_VFR_Dual_XC1.windCFI + K_VFR_Dual_XC1.windComm + K_VFR_Dual_XC1.windPime;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", K_VFR_Dual_XC1.DepartureRisk, 7, 9);
            };

            btnBack.Touch += (s, e) =>
            {
                StartActivity(typeof(K_VFR_Dual_XC1));
            };

            btnNext.Touch += (s, e) =>
            {
                if (K_VFR_Dual_XC1.DepartureRisk > 8)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Alert");
                    alert.SetMessage("Your departure risk is too high!");
                    alert.SetNeutralButton("OK", delegate
                    {
                        alert.Dispose();
                    });
                    alert.Show();
                }
                else
                    StartActivity(typeof(K_VFR_Dual_XC3));
            };
        }
    }
}