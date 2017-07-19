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
    [Activity(Label = "Enroute or Practice Area - 2 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class K_VFR_Dual_XC4 : Activity
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

            K_VFR_Dual_XC3.enrouteRisk = K_VFR_Dual_XC3.vis + K_VFR_Dual_XC3.ceiling + K_VFR_Dual_XC3.manu + checkpoints + timeEnroute;
            sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", K_VFR_Dual_XC3.enrouteRisk, 7, 9);

            btnMult.Touch += (s, e) =>
            {
                checkpoints = sc.button1Pressed(btnMult, btnMod, btnFew, txtCheckpoints);
                K_VFR_Dual_XC3.enrouteRisk = K_VFR_Dual_XC3.vis + K_VFR_Dual_XC3.ceiling + K_VFR_Dual_XC3.manu + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", K_VFR_Dual_XC3.enrouteRisk, 7, 9);
            };
            btnMod.Touch += (s, e) =>
            {
                checkpoints = sc.button2Pressed(btnMult, btnMod, btnFew, txtCheckpoints);
                K_VFR_Dual_XC3.enrouteRisk = K_VFR_Dual_XC3.vis + K_VFR_Dual_XC3.ceiling + K_VFR_Dual_XC3.manu + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", K_VFR_Dual_XC3.enrouteRisk, 7, 9);
            };
            btnFew.Touch += (s, e) =>
            {
                checkpoints = sc.button3Pressed(btnMult, btnMod, btnFew, txtCheckpoints);
                K_VFR_Dual_XC3.enrouteRisk = K_VFR_Dual_XC3.vis + K_VFR_Dual_XC3.ceiling + K_VFR_Dual_XC3.manu + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", K_VFR_Dual_XC3.enrouteRisk, 7, 9);
            };

            btnLessThan60.Touch += (s, e) =>
            {
                timeEnroute = sc.button1Pressed(btnLessThan60, btn60to120, btn120Plus, txtTime);
                K_VFR_Dual_XC3.enrouteRisk = K_VFR_Dual_XC3.vis + K_VFR_Dual_XC3.ceiling + K_VFR_Dual_XC3.manu + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", K_VFR_Dual_XC3.enrouteRisk, 7, 9);
            };
            btn60to120.Touch += (s, e) =>
            {
                timeEnroute = sc.button2Pressed(btnLessThan60, btn60to120, btn120Plus, txtTime);
                K_VFR_Dual_XC3.enrouteRisk = K_VFR_Dual_XC3.vis + K_VFR_Dual_XC3.ceiling + K_VFR_Dual_XC3.manu + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", K_VFR_Dual_XC3.enrouteRisk, 7, 9);
            };
            btn120Plus.Touch += (s, e) =>
            {
                timeEnroute = sc.button3Pressed(btnLessThan60, btn60to120, btn120Plus, txtTime);
                K_VFR_Dual_XC3.enrouteRisk = K_VFR_Dual_XC3.vis + K_VFR_Dual_XC3.ceiling + K_VFR_Dual_XC3.manu + checkpoints + timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", K_VFR_Dual_XC3.enrouteRisk, 7, 9);
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(K_VFR_Dual_XC3));
            };

            btnNext.Click += delegate
            {
                if (K_VFR_Dual_XC3.enrouteRisk > 8)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Alert");
                    alert.SetMessage("Your enroute or practice area risk is too high!");
                    alert.SetNeutralButton("OK", delegate
                    {
                        alert.Dispose();
                    });
                    alert.Show();
                }
                else
                {
                    StartActivity(typeof(K_VFR_Dual_XC5));
                }
            };

            
        }
    }
}