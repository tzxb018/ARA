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
    [Activity(Label = "Destination - 1 of 2")]
    public class M_VFR_Night_XC5 : Activity
    {
        public static int DestinationRisk, wind, xwind, ceiling;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.h_Layout_3);

            var lblWind = FindViewById<TextView>(Resource.Id.txtQuestion1);
            var btn0to15 = FindViewById<Button>(Resource.Id.btnQ1C1);
            var btn16to20 = FindViewById<Button>(Resource.Id.btnQ1C2);
            var btn21to25 = FindViewById<Button>(Resource.Id.btnQ1C3);
            var txtWInd = FindViewById<TextView>(Resource.Id.txtAnswer1);

            var lblXwind = FindViewById<TextView>(Resource.Id.txtQuestion2);
            var btn0to5 = FindViewById<Button>(Resource.Id.btnQ2C1);
            var btn6to10 = FindViewById<Button>(Resource.Id.btnQ2C2);
            var btn11to15 = FindViewById<Button>(Resource.Id.btnQ2C3);
            var txtxWind = FindViewById<TextView>(Resource.Id.txtAnswer2);

            var lblCeiling = FindViewById<TextView>(Resource.Id.txtQuestion3);
            var btn4000 = FindViewById<Button>(Resource.Id.btnQ3C1);
            var btn3500 = FindViewById<Button>(Resource.Id.btnQ3C2);
            var btn3000 = FindViewById<Button>(Resource.Id.btnQ3C3);
            var txtCieling = FindViewById<TextView>(Resource.Id.txtAnswer3);

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskText);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNum);

            lblWind.Text = "Wind";
            btn0to15.Text = "0 - 15 kts";
            btn16to20.Text = "16 - 20 kts";
            btn21to25.Text = "21 - 25 kts";

            lblXwind.Text = "Xwind";
            btn0to5.Text = "0 - 5 kts";
            btn6to10.Text = "6 - 10 kts";
            btn11to15.Text = "11 - 15 kts";

            lblCeiling.Text = "Ceiling";
            btn4000.Text = "4000+ ft";
            btn3500.Text = "3500 - 3999 ft";
            btn3000.Text = "3000 - 3499 ft";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn0to15, btn16to20, btn21to25, txtWInd, wind);
            class1.defaultVals(btn0to5, btn6to10, btn11to15, txtxWind, xwind);
            class1.defaultVals(btn4000, btn3500, btn3000, txtCieling, ceiling);

            DestinationRisk = wind + xwind + ceiling + M_VFR_Night_XC6.vis + M_VFR_Night_XC6.fuel + M_VFR_Night_XC6.iap;
            class1.riskShow(txtRisk, txtRiskNum, "Destination Risk", DestinationRisk, 9, 12);

            btn0to15.Touch += (s, e) =>
            {
                wind = class1.button1Pressed(btn0to15, btn16to20, btn21to25, txtWInd);
                DestinationRisk = wind + xwind + ceiling + M_VFR_Night_XC6.vis + M_VFR_Night_XC6.fuel + M_VFR_Night_XC6.iap;
                class1.riskShow(txtRisk, txtRiskNum, "Destination Risk", DestinationRisk, 9, 12);
            };
            btn16to20.Touch += (s, e) =>
            {
                wind = class1.button2Pressed(btn0to15, btn16to20, btn21to25, txtWInd);
                DestinationRisk = wind + xwind + ceiling + M_VFR_Night_XC6.vis + M_VFR_Night_XC6.fuel + M_VFR_Night_XC6.iap;
                class1.riskShow(txtRisk, txtRiskNum, "Destination Risk", DestinationRisk, 9, 12);
            };
            btn21to25.Touch += (s, e) =>
            {
                wind = class1.button3Pressed(btn0to15, btn16to20, btn21to25, txtWInd);
                DestinationRisk = wind + xwind + ceiling + M_VFR_Night_XC6.vis + M_VFR_Night_XC6.fuel + M_VFR_Night_XC6.iap;
                class1.riskShow(txtRisk, txtRiskNum, "Destination Risk", DestinationRisk, 9, 12);

            };

            btn0to5.Touch += (s, e) =>
            {
                xwind = class1.button1Pressed(btn0to5, btn6to10, btn11to15, txtxWind);
                DestinationRisk = wind + xwind + ceiling + M_VFR_Night_XC6.vis + M_VFR_Night_XC6.fuel + M_VFR_Night_XC6.iap;
                class1.riskShow(txtRisk, txtRiskNum, "Destination Risk", DestinationRisk, 9, 12);
            };
            btn6to10.Touch += (s, e) =>
            {
                xwind = class1.button2Pressed(btn0to5, btn6to10, btn11to15, txtxWind);
                DestinationRisk = wind + xwind + ceiling + M_VFR_Night_XC6.vis + M_VFR_Night_XC6.fuel + M_VFR_Night_XC6.iap;
                class1.riskShow(txtRisk, txtRiskNum, "Destination Risk", DestinationRisk, 9, 12);
            };
            btn11to15.Touch += (s, e) =>
            {
                xwind = class1.button3Pressed(btn0to5, btn6to10, btn11to15, txtxWind);
                DestinationRisk = wind + xwind + ceiling + M_VFR_Night_XC6.vis + M_VFR_Night_XC6.fuel + M_VFR_Night_XC6.iap;
                class1.riskShow(txtRisk, txtRiskNum, "Destination Risk", DestinationRisk, 9, 12);
            };

            btn4000.Touch += (s, e) =>
            {
                ceiling = class1.button1Pressed(btn4000, btn3500, btn3000, txtCieling);
                DestinationRisk = wind + xwind + ceiling + M_VFR_Night_XC6.vis + M_VFR_Night_XC6.fuel + M_VFR_Night_XC6.iap;
                class1.riskShow(txtRisk, txtRiskNum, "Destination Risk", DestinationRisk, 9, 12);
            };
            btn3500.Touch += (s, e) =>
            {

                ceiling = class1.button2Pressed(btn4000, btn3500, btn3000, txtCieling);
                DestinationRisk = wind + xwind + ceiling + M_VFR_Night_XC6.vis + M_VFR_Night_XC6.fuel + M_VFR_Night_XC6.iap;
                class1.riskShow(txtRisk, txtRiskNum, "Destination Risk", DestinationRisk, 9, 12);
            };
            btn3000.Touch += (s, e) =>
            {
                ceiling = class1.button3Pressed(btn4000, btn3500, btn3000, txtCieling);
                DestinationRisk = wind + xwind + ceiling + M_VFR_Night_XC6.vis + M_VFR_Night_XC6.fuel + M_VFR_Night_XC6.iap;
                class1.riskShow(txtRisk, txtRiskNum, "Destination Risk", DestinationRisk, 9, 12);
            };

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom3);

            btnNext.Click += delegate
            {
                StartActivity(typeof(M_VFR_Night_XC6));
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(M_VFR_Night_XC4));
            };
        }
    }
}