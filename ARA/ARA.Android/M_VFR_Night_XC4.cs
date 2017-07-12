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
    [Activity(Label = "Enroute - 2 of 2")]
    public class M_VFR_Night_XC4 : Activity
    {
        public static int checkpoints, timeEnroute;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblCheckpoints = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btnMult = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btnMod = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btnFew = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtCheckpoints = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblTimeEnroute = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btnLessThan60 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn60to120 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn120Plus = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtTime = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblCheckpoints.Text = "Checkpoints (XC)";
            btnMult.Text = "Multiple";
            btnMod.Text = "Moderate";
            btnFew.Text = "Few to none";
            txtCheckpoints.Text = "You have selected the '" + btnMult.Text + "' choice.";

            lblTimeEnroute.Text = "Time enroute";
            btnLessThan60.Text = "< 60 min";
            btn60to120.Text = "60 - 120 min";
            btn120Plus.Text = "> 120 min";
            txtTime.Text = "You have selected the '" + btnLessThan60.Text + "' choice.";

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.defaultVals(btnMult, btnMod, btnFew, txtCheckpoints, checkpoints);
            sc.defaultVals(btnLessThan60, btn60to120, btn120Plus, txtTime, timeEnroute);

            M_VFR_Night_XC3.enrouteRisk = M_VFR_Night_XC3.ceiling + M_VFR_Night_XC3.vis + checkpoints + timeEnroute;
            sc.riskShow(txtRisk, txtRiskNum, "Enroute Risk", M_VFR_Night_XC3.enrouteRisk, 7, 9);

            btnMult.Touch += (s, e) =>
            {
                checkpoints = sc.button1Pressed(btnMult, btnMod, btnFew, txtCheckpoints);
                M_VFR_Night_XC3.enrouteRisk = M_VFR_Night_XC3.ceiling + M_VFR_Night_XC3.vis + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute Risk", M_VFR_Night_XC3.enrouteRisk, 7, 9);
            };
            btnMod.Touch += (s, e) =>
            {
                checkpoints = sc.button2Pressed(btnMult, btnMod, btnFew, txtCheckpoints);
                M_VFR_Night_XC3.enrouteRisk = M_VFR_Night_XC3.ceiling + M_VFR_Night_XC3.vis + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute Risk", M_VFR_Night_XC3.enrouteRisk, 7, 9);
            };
            btnFew.Touch += (s, e) =>
            {
                checkpoints = sc.button3Pressed(btnMult, btnMod, btnFew, txtCheckpoints);
                M_VFR_Night_XC3.enrouteRisk = M_VFR_Night_XC3.ceiling + M_VFR_Night_XC3.vis + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute Risk", M_VFR_Night_XC3.enrouteRisk, 7, 9);
            };

            btnLessThan60.Touch += (s, e) =>
            {
                timeEnroute = sc.button1Pressed(btnLessThan60, btn60to120, btn120Plus, txtTime);
                M_VFR_Night_XC3.enrouteRisk = M_VFR_Night_XC3.ceiling + M_VFR_Night_XC3.vis + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute Risk", M_VFR_Night_XC3.enrouteRisk, 7, 9);
            };
            btn60to120.Touch += (s, e) =>
            {
                timeEnroute = sc.button2Pressed(btnLessThan60, btn60to120, btn120Plus, txtTime);
                M_VFR_Night_XC3.enrouteRisk = M_VFR_Night_XC3.ceiling + M_VFR_Night_XC3.vis + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute Risk", M_VFR_Night_XC3.enrouteRisk, 7, 9);
            };
            btn120Plus.Touch += (s, e) =>
            {
                timeEnroute = sc.button3Pressed(btnLessThan60, btn60to120, btn120Plus, txtTime);
                M_VFR_Night_XC3.enrouteRisk = M_VFR_Night_XC3.ceiling + M_VFR_Night_XC3.vis + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute Risk", M_VFR_Night_XC3.enrouteRisk, 7, 9);
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(M_VFR_Night_XC3));
            };

            btnNext.Click += delegate
            {
                if (M_VFR_Night_XC3.enrouteRisk > 8)
                {
                    sc.alertShow("Enroute Risk", this);
                }
                else
                {
                    StartActivity(typeof(M_VFR_Night_XC5));
                }
            };

        }
    }
}