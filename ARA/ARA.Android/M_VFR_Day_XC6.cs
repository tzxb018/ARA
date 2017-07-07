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
    [Activity(Label = "Destination or Aux Field - 2 of 2")]
    public class M_VFR_Day_XC6 : Activity
    {
        public static int vis;
        public static int fuel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.h_Layout2);

            // Create your application here
            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblVIs = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btn7 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn6 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn5 = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtVis = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblFuel = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btn90 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn75to90 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn60to75 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtFuel = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblVIs.Text = "Visibility";
            btn7.Text = "7+ SM";
            btn6.Text = "6 SM";
            btn5.Text = "5 SM";
            txtVis.Text = "You have selected the '" + btn7.Text + "' choice.";

            lblFuel.Text = "Fuel Remaining";
            btn90.Text = "> 90 min";
            btn75to90.Text = "75 - 90 min";
            btn60to75.Text = "60 - 75 min";
            txtFuel.Text = "You have selected the '" + btn90.Text + "' choice.";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn7, btn6, btn5, txtVis, vis);
            class1.defaultVals(btn90, btn75to90, btn60to75, txtFuel, fuel);

            L_VFR_Day_XC5.DestinationRisk = vis + fuel + L_VFR_Day_XC5.ceiling + L_VFR_Day_XC5.xwind + L_VFR_Day_XC5.wind;
            class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", L_VFR_Day_XC5.DestinationRisk, 8, 10);

            btn7.Touch += (s, e) =>
            {
                vis = class1.button1Pressed(btn7, btn6, btn5, txtVis);
                L_VFR_Day_XC5.DestinationRisk = vis + fuel + L_VFR_Day_XC5.ceiling + L_VFR_Day_XC5.xwind + L_VFR_Day_XC5.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", L_VFR_Day_XC5.DestinationRisk, 8, 10);
            };
            btn6.Touch += (s, e) =>
            {
                vis = class1.button2Pressed(btn7, btn6, btn5, txtVis);
                L_VFR_Day_XC5.DestinationRisk = vis + fuel + L_VFR_Day_XC5.ceiling + L_VFR_Day_XC5.xwind + L_VFR_Day_XC5.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", L_VFR_Day_XC5.DestinationRisk, 8, 10);
            };
            btn5.Touch += (s, e) =>
            {
                vis = class1.button3Pressed(btn7, btn6, btn5, txtVis);
                L_VFR_Day_XC5.DestinationRisk = vis + fuel + L_VFR_Day_XC5.ceiling + L_VFR_Day_XC5.xwind + L_VFR_Day_XC5.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", L_VFR_Day_XC5.DestinationRisk, 8, 10);

            };

            btn90.Touch += (s, e) =>
            {
                fuel = class1.button1Pressed(btn90, btn75to90, btn60to75, txtFuel);
                L_VFR_Day_XC5.DestinationRisk = vis + fuel + L_VFR_Day_XC5.ceiling + L_VFR_Day_XC5.xwind + L_VFR_Day_XC5.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", L_VFR_Day_XC5.DestinationRisk, 8, 10);
            };
            btn75to90.Touch += (s, e) =>
            {
                fuel = class1.button2Pressed(btn90, btn75to90, btn60to75, txtFuel);
                L_VFR_Day_XC5.DestinationRisk = vis + fuel + L_VFR_Day_XC5.ceiling + L_VFR_Day_XC5.xwind + L_VFR_Day_XC5.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", L_VFR_Day_XC5.DestinationRisk, 8, 10);
            };
            btn60to75.Touch += (s, e) =>
            {
                fuel = class1.button3Pressed(btn90, btn75to90, btn60to75, txtFuel);
                L_VFR_Day_XC5.DestinationRisk = vis + fuel + L_VFR_Day_XC5.ceiling + L_VFR_Day_XC5.xwind + L_VFR_Day_XC5.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", L_VFR_Day_XC5.DestinationRisk, 8, 10);
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(L_VFR_Day_XC5));
            };

        }
    }
}