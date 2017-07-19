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
    [Activity(Label = "Alternate - 2 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class I_VFR_Day_XC8 : Activity
    {
        public static int vis, fuel;

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

            I_VFR_Day_XC7.altRisk = vis + fuel + I_VFR_Day_XC7.ceiling + I_VFR_Day_XC7.xwind + I_VFR_Day_XC7.wind;
            class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", I_VFR_Day_XC7.altRisk, 8, 10);

            btn7.Touch += (s, e) =>
            {
                vis = class1.button1Pressed(btn7, btn6, btn5, txtVis);
                I_VFR_Day_XC7.altRisk = vis + fuel + I_VFR_Day_XC7.ceiling + I_VFR_Day_XC7.xwind + I_VFR_Day_XC7.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", I_VFR_Day_XC7.altRisk, 8, 10);
            };
            btn6.Touch += (s, e) =>
            {
                vis = class1.button2Pressed(btn7, btn6, btn5, txtVis);
                I_VFR_Day_XC7.altRisk = vis + fuel + I_VFR_Day_XC7.ceiling + I_VFR_Day_XC7.xwind + I_VFR_Day_XC7.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", I_VFR_Day_XC7.altRisk, 8, 10);
            };
            btn5.Touch += (s, e) =>
            {
                vis = class1.button3Pressed(btn7, btn6, btn5, txtVis);
                I_VFR_Day_XC7.altRisk = vis + fuel + I_VFR_Day_XC7.ceiling + I_VFR_Day_XC7.xwind + I_VFR_Day_XC7.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", I_VFR_Day_XC7.altRisk, 8, 10);

            };

            btn60.Touch += (s, e) =>
            {
                fuel = class1.button1Pressed(btn60, btn45to60, bnt30to45, txtFuel);
                I_VFR_Day_XC7.altRisk = vis + fuel + I_VFR_Day_XC7.ceiling + I_VFR_Day_XC7.xwind + I_VFR_Day_XC7.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", I_VFR_Day_XC7.altRisk, 8, 10);
            };
            btn45to60.Touch += (s, e) =>
            {
                fuel = class1.button2Pressed(btn60, btn45to60, bnt30to45, txtFuel);
                I_VFR_Day_XC7.altRisk = vis + fuel + I_VFR_Day_XC7.ceiling + I_VFR_Day_XC7.xwind + I_VFR_Day_XC7.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", I_VFR_Day_XC7.altRisk, 8, 10);
            };
            bnt30to45.Touch += (s, e) =>
            {
                fuel = class1.button3Pressed(btn60, btn45to60, bnt30to45, txtFuel);
                I_VFR_Day_XC7.altRisk = vis + fuel + I_VFR_Day_XC7.ceiling + I_VFR_Day_XC7.xwind + I_VFR_Day_XC7.wind;
                class1.riskShow(txtRisk, txtRiskNum, "Destination or Aux Field Risk", I_VFR_Day_XC7.altRisk, 8, 10);
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(I_VFR_Day_XC7));
            };

            btnNext.Click += delegate
            {
                if (I_VFR_Day_XC7.altRisk > 9)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Alert");
                    alert.SetMessage("Your Enroute Risk is too high!");
                    alert.SetNeutralButton("OK", delegate
                    {
                        alert.Dispose();
                    });
                    alert.Show();

                    class1.defaultVals(btn7, btn6, btn5, txtVis, vis);
                    class1.defaultVals(btn60, btn45to60, bnt30to45, txtFuel, fuel);
                }
                else
                {
                    StartActivity(typeof(I_VFR_Day_XCPIC));
                }
            };

        }
    }
}