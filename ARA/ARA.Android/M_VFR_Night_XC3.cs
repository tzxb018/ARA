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
    [Activity(Label = "Enroute - 1 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class M_VFR_Night_XC3 : Activity
    {
        public static int enrouteRisk, ceiling, vis;
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

            var lblCeiling = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btn4000 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn3500 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn3000 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtCieling = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblVIs.Text = "Visibility";
            btn7.Text = "7+ SM";
            btn6.Text = "6 SM";
            btn5.Text = "5 SM";
            txtVis.Text = "You have selected the '" + btn7.Text + "' choice.";

            lblCeiling.Text = "Ceiling";
            btn4000.Text = "4000+ ft";
            btn3500.Text = "3500 - 3999 ft";
            btn3000.Text = "3000 - 3499 ft";
            txtCieling.Text = "You have selected the '" + btn4000.Text + "' choice.";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn7, btn6, btn5, txtVis, vis);
            class1.defaultVals(btn4000, btn3500, btn3000, txtCieling, ceiling);

            enrouteRisk = vis + ceiling + M_VFR_Night_XC4.checkpoints + M_VFR_Night_XC4.timeEnroute;
            class1.riskShow(txtRisk, txtRiskNum, "Enroute Risk", enrouteRisk, 7, 9);

            btn7.Touch += (s, e) =>
            {
                vis = class1.button1Pressed(btn7, btn6, btn5, txtVis);
                enrouteRisk = vis + ceiling + M_VFR_Night_XC4.checkpoints + M_VFR_Night_XC4.timeEnroute;
                class1.riskShow(txtRisk, txtRiskNum, "Enroute Risk", enrouteRisk, 7, 9);
            };
            btn6.Touch += (s, e) =>
            {
                vis = class1.button2Pressed(btn7, btn6, btn5, txtVis);
                enrouteRisk = vis + ceiling + M_VFR_Night_XC4.checkpoints + M_VFR_Night_XC4.timeEnroute;
                class1.riskShow(txtRisk, txtRiskNum, "Enroute Risk", enrouteRisk, 7, 9);
            };
            btn5.Touch += (s, e) =>
            {
                vis = class1.button3Pressed(btn7, btn6, btn5, txtVis);
                enrouteRisk = vis + ceiling + M_VFR_Night_XC4.checkpoints + M_VFR_Night_XC4.timeEnroute;
                class1.riskShow(txtRisk, txtRiskNum, "Enroute Risk", enrouteRisk, 7, 9);

            };

            btn4000.Touch += (s, e) =>
            {
                ceiling = class1.button1Pressed(btn4000, btn3500, btn3000, txtCieling);
                enrouteRisk = vis + ceiling + M_VFR_Night_XC4.checkpoints + M_VFR_Night_XC4.timeEnroute;
                class1.riskShow(txtRisk, txtRiskNum, "Enroute Risk", enrouteRisk, 7, 9);
            };
            btn3500.Touch += (s, e) =>
            {
                ceiling = class1.button2Pressed(btn4000, btn3500, btn3000, txtCieling);
                enrouteRisk = vis + ceiling + M_VFR_Night_XC4.checkpoints + M_VFR_Night_XC4.timeEnroute;
                class1.riskShow(txtRisk, txtRiskNum, "Enroute Risk", enrouteRisk, 7, 9);
            };
            btn3000.Touch += (s, e) =>
            {
                ceiling = class1.button3Pressed(btn4000, btn3500, btn3000, txtCieling);
                enrouteRisk = vis + ceiling + M_VFR_Night_XC4.checkpoints + M_VFR_Night_XC4.timeEnroute;
                class1.riskShow(txtRisk, txtRiskNum, "Enroute Risk", enrouteRisk, 7, 9);
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(M_VFR_Night_XC2));
            };

            btnNext.Click += delegate
            {
                  StartActivity(typeof(M_VFR_Night_XC4));
                
            };
        }
    }
}