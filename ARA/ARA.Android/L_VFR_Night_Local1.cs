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
    [Activity(Label = "Departure Airfield - 1 of 2", MainLauncher = true)]
    public class L_VFR_Night_Local1 : Activity
    {
        public static int departureRisk, wind, xwind;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblDepartureWind = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btn0to15 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn16to20 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn21to25 = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtDepartureWind = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblDepartureXwind = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btn0to5 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn6to10 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn11to15 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtDepartureXwind = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblDepartureWind.Text = "Wind";
            btn0to15.Text = "0 - 15 kts";
            btn16to20.Text = "16 - 20 kts";
            btn21to25.Text = "21 - 25 kts";
            txtDepartureWind.Text = "You have selected the '" + btn0to15.Text + "' choice.";

            lblDepartureXwind.Text = "Xwind";
            btn0to5.Text = "0 - 5 kts";
            btn6to10.Text = "6 - 10 kts";
            btn11to15.Text = "11 - 15 kts";
            txtDepartureXwind.Text = "You have selected the '" + btn0to5.Text + "' choice.";

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.defaultVals(btn0to15, btn16to20, btn21to25, txtDepartureWind, wind);
            sc.defaultVals(btn0to5, btn6to10, btn11to15, txtDepartureXwind, xwind);

            departureRisk = wind + xwind + L_VFR_Night_Local2.ceiling + L_VFR_Night_Local2.vis;
            sc.riskShow(txtRisk, txtRiskNum, "Departure Airfield Risk", departureRisk ,7, 9);

            btn0to15.Touch += (s, e) =>
            {
                wind = sc.button1Pressed(btn0to15, btn16to20, btn21to25, txtDepartureWind);
                departureRisk = wind + xwind + L_VFR_Night_Local2.ceiling + L_VFR_Night_Local2.vis;
                sc.riskShow(txtRisk, txtRiskNum, "Departure Airfield Risk", departureRisk, 7, 9);
            };
            btn16to20.Touch += (s, e) =>
            {
                wind = sc.button2Pressed(btn0to15, btn16to20, btn21to25, txtDepartureWind);
                departureRisk = wind + xwind + L_VFR_Night_Local2.ceiling + L_VFR_Night_Local2.vis;
                sc.riskShow(txtRisk, txtRiskNum, "Departure Airfield Risk", departureRisk, 7, 9);
            };
            btn21to25.Touch += (s, e) =>
            {
                wind = sc.button3Pressed(btn0to15, btn16to20, btn21to25, txtDepartureWind);
                departureRisk = wind + xwind + L_VFR_Night_Local2.ceiling + L_VFR_Night_Local2.vis;
                sc.riskShow(txtRisk, txtRiskNum, "Departure Airfield Risk", departureRisk, 7, 9);
            };

            btn0to5.Touch += (s, e) =>
            {
                xwind = sc.button1Pressed(btn0to5, btn6to10, btn11to15, txtDepartureXwind);
                departureRisk = wind + xwind + L_VFR_Night_Local2.ceiling + L_VFR_Night_Local2.vis;
                sc.riskShow(txtRisk, txtRiskNum, "Departure Airfield Risk", departureRisk, 7, 9);
            };
            btn6to10.Touch += (s, e) =>
            {
                xwind = sc.button2Pressed(btn0to5, btn6to10, btn11to15, txtDepartureXwind);
                departureRisk = wind + xwind + L_VFR_Night_Local2.ceiling + L_VFR_Night_Local2.vis;
                sc.riskShow(txtRisk, txtRiskNum, "Departure Airfield Risk", departureRisk, 7, 9);
            };
            btn11to15.Touch += (s, e) =>
            {
                xwind = sc.button3Pressed(btn0to5, btn6to10, btn11to15, txtDepartureXwind);
                departureRisk = wind + xwind + L_VFR_Night_Local2.ceiling + L_VFR_Night_Local2.vis;
                sc.riskShow(txtRisk, txtRiskNum, "Departure Airfield Risk", departureRisk, 7, 9);
            };

            btnNext.Click += delegate
            {
                StartActivity(typeof(L_VFR_Night_Local2));
            };
            btnBack.Click += delegate
            {
                StartActivity(typeof(G_Student_Human_Factors_2));
            };

        }
    }
}