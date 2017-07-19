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
    [Activity(Label = "Departure Airfield - 2 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class M_VFR_Night_XC2 : Activity
    {
        public static int vis, iap;

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

            var lblAIP = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btnPrecision = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btnNonPrecision = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btnCircling = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtAIP = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblVIs.Text = "Visibility";
            btn7.Text = "7+ SM";
            btn6.Text = "6 SM";
            btn5.Text = "5 SM";
            txtVis.Text = "You have selected the '" + btn7.Text + "' choice.";

            lblAIP.Text = "Best IAP Available";
            btnPrecision.Text = "Precision";
            btnNonPrecision.Text = "Non-Precision";
            btnCircling.Text = "Circling";
            txtAIP.Text = "You have selected the '" + btnPrecision.Text + "' choice.";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn7, btn6, btn5, txtVis, vis);
            class1.defaultVals(btnPrecision, btnNonPrecision, btnCircling, txtAIP, iap);

            M_VFR_Night_XC1.departureRisk = M_VFR_Night_XC1.ceiling + M_VFR_Night_XC1.wind + M_VFR_Night_XC1.xwind + vis + iap;
            class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", M_VFR_Night_XC1.departureRisk, 8, 10);

            btn7.Touch += (s, e) =>
            {
                vis = class1.button1Pressed(btn7, btn6, btn5, txtVis);
                M_VFR_Night_XC1.departureRisk = M_VFR_Night_XC1.ceiling + M_VFR_Night_XC1.wind + M_VFR_Night_XC1.xwind + vis + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", M_VFR_Night_XC1.departureRisk, 8, 10);
            };
            btn6.Touch += (s, e) =>
            {
                vis = class1.button2Pressed(btn7, btn6, btn5, txtVis);
                M_VFR_Night_XC1.departureRisk = M_VFR_Night_XC1.ceiling + M_VFR_Night_XC1.wind + M_VFR_Night_XC1.xwind + vis + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", M_VFR_Night_XC1.departureRisk, 8, 10);
            };
            btn5.Touch += (s, e) =>
            {
                vis = class1.button3Pressed(btn7, btn6, btn5, txtVis);
                M_VFR_Night_XC1.departureRisk = M_VFR_Night_XC1.ceiling + M_VFR_Night_XC1.wind + M_VFR_Night_XC1.xwind + vis + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", M_VFR_Night_XC1.departureRisk, 8, 10);

            };

            btnPrecision.Touch += (s, e) =>
            {
                iap = class1.button1Pressed(btnPrecision, btnNonPrecision, btnCircling, txtAIP);
                M_VFR_Night_XC1.departureRisk = M_VFR_Night_XC1.ceiling + M_VFR_Night_XC1.wind + M_VFR_Night_XC1.xwind + vis + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", M_VFR_Night_XC1.departureRisk, 8, 10);
            };
            btnNonPrecision.Touch += (s, e) =>
            {
                iap = class1.button2Pressed(btnPrecision, btnNonPrecision, btnCircling, txtAIP);
                M_VFR_Night_XC1.departureRisk = M_VFR_Night_XC1.ceiling + M_VFR_Night_XC1.wind + M_VFR_Night_XC1.xwind + vis + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", M_VFR_Night_XC1.departureRisk, 8, 10);
            };
            btnCircling.Touch += (s, e) =>
            {
                iap = class1.button3Pressed(btnPrecision, btnNonPrecision, btnCircling, txtAIP);
                M_VFR_Night_XC1.departureRisk = M_VFR_Night_XC1.ceiling + M_VFR_Night_XC1.wind + M_VFR_Night_XC1.xwind + vis + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Departure Risk", M_VFR_Night_XC1.departureRisk, 8, 10);
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(M_VFR_Night_XC1));
            };

            btnNext.Click += delegate
            {
                if (M_VFR_Night_XC1.departureRisk > 9)
                {
                    class1.alertShow("Departure Risk", this);

                    class1.defaultVals(btn7, btn6, btn5, txtVis, vis);
                    class1.defaultVals(btnPrecision, btnNonPrecision, btnCircling, txtAIP, iap);
                }
                else
                {
                    StartActivity(typeof(M_VFR_Night_XC3));
                }
            };
        }
    }
}