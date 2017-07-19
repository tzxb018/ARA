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
    public class M_VFR_Night_XC8 : Activity
    {
        public static int vis, fuel, iap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.h_Layout_3);

            var lblbVis = FindViewById<TextView>(Resource.Id.txtQuestion1);
            var btn7 = FindViewById<Button>(Resource.Id.btnQ1C1);
            var bnt6 = FindViewById<Button>(Resource.Id.btnQ1C2);
            var btn5 = FindViewById<Button>(Resource.Id.btnQ1C3);
            var txtVis = FindViewById<TextView>(Resource.Id.txtAnswer1);

            var lblFuel = FindViewById<TextView>(Resource.Id.txtQuestion2);
            var btn90 = FindViewById<Button>(Resource.Id.btnQ2C1);
            var btn75 = FindViewById<Button>(Resource.Id.btnQ2C2);
            var btn60 = FindViewById<Button>(Resource.Id.btnQ2C3);
            var txtFuel = FindViewById<TextView>(Resource.Id.txtAnswer2);

            var lblIAP = FindViewById<TextView>(Resource.Id.txtQuestion3);
            var btnPrecisoin = FindViewById<Button>(Resource.Id.btnQ3C1);
            var btnNon = FindViewById<Button>(Resource.Id.btnQ3C2);
            var btnCircle = FindViewById<Button>(Resource.Id.btnQ3C3);
            var txtIAP = FindViewById<TextView>(Resource.Id.txtAnswer3);

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskText);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNum);

            lblbVis.Text = "Visibility";
            btn7.Text = "7+ SM";
            bnt6.Text = "6 SM";
            btn5.Text = "5 SM";

            lblFuel.Text = "Fuel Remaining";
            btn90.Text = "> 76 min";
            btn75.Text = "60 - 75 min";
            btn60.Text = "45 - 60 min";

            lblIAP.Text = "Best IAP Available";
            btnPrecisoin.Text = "Precision";
            btnNon.Text = "Non-Precision";
            btnCircle.Text = "Circling";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn7, bnt6, btn5, txtVis, vis);
            class1.defaultVals(btn90, btn75, btn60, txtFuel, fuel);
            class1.defaultVals(btnPrecisoin, btnNon, btnCircle, txtIAP, iap);

            M_VFR_Night_XC7.altRisk = M_VFR_Night_XC7.wind + M_VFR_Night_XC7.xwind + M_VFR_Night_XC7.ceiling + vis + fuel + iap;
            class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", M_VFR_Night_XC7.altRisk, 9, 12);

            btn7.Touch += (s, e) =>
            {
                vis = class1.button1Pressed(btn7, bnt6, btn5, txtVis);
                M_VFR_Night_XC7.altRisk = M_VFR_Night_XC7.wind + M_VFR_Night_XC7.xwind + M_VFR_Night_XC7.ceiling + vis + fuel + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", M_VFR_Night_XC7.altRisk, 9, 12);
            };
            bnt6.Touch += (s, e) =>
            {
                vis = class1.button2Pressed(btn7, bnt6, btn5, txtVis);
                M_VFR_Night_XC7.altRisk = M_VFR_Night_XC7.wind + M_VFR_Night_XC7.xwind + M_VFR_Night_XC7.ceiling + vis + fuel + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", M_VFR_Night_XC7.altRisk, 9, 12);
            };
            btn5.Touch += (s, e) =>
            {
                vis = class1.button3Pressed(btn7, bnt6, btn5, txtVis);
                M_VFR_Night_XC7.altRisk = M_VFR_Night_XC7.wind + M_VFR_Night_XC7.xwind + M_VFR_Night_XC7.ceiling + vis + fuel + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", M_VFR_Night_XC7.altRisk, 9, 12);

            };

            btn90.Touch += (s, e) =>
            {
                fuel = class1.button1Pressed(btn90, btn75, btn60, txtFuel);
                M_VFR_Night_XC7.altRisk = M_VFR_Night_XC7.wind + M_VFR_Night_XC7.xwind + M_VFR_Night_XC7.ceiling + vis + fuel + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", M_VFR_Night_XC7.altRisk, 9, 12);
            };
            btn75.Touch += (s, e) =>
            {
                fuel = class1.button2Pressed(btn90, btn75, btn60, txtFuel);
                M_VFR_Night_XC7.altRisk = M_VFR_Night_XC7.wind + M_VFR_Night_XC7.xwind + M_VFR_Night_XC7.ceiling + vis + fuel + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", M_VFR_Night_XC7.altRisk, 9, 12);
            };
            btn60.Touch += (s, e) =>
            {
                fuel = class1.button3Pressed(btn90, btn75, btn60, txtFuel);
                M_VFR_Night_XC7.altRisk = M_VFR_Night_XC7.wind + M_VFR_Night_XC7.xwind + M_VFR_Night_XC7.ceiling + vis + fuel + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", M_VFR_Night_XC7.altRisk, 9, 12);
            };

            btnPrecisoin.Touch += (s, e) =>
            {
                iap = class1.button1Pressed(btnPrecisoin, btnNon, btnCircle, txtIAP);
                M_VFR_Night_XC7.altRisk = M_VFR_Night_XC7.wind + M_VFR_Night_XC7.xwind + M_VFR_Night_XC7.ceiling + vis + fuel + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", M_VFR_Night_XC7.altRisk, 9, 12);
            };
            btnNon.Touch += (s, e) =>
            {

                iap = class1.button2Pressed(btnPrecisoin, btnNon, btnCircle, txtIAP);
                M_VFR_Night_XC7.altRisk = M_VFR_Night_XC7.wind + M_VFR_Night_XC7.xwind + M_VFR_Night_XC7.ceiling + vis + fuel + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", M_VFR_Night_XC7.altRisk, 9, 12);
            };
            btnCircle.Touch += (s, e) =>
            {
                iap = class1.button3Pressed(btnPrecisoin, btnNon, btnCircle, txtIAP);
                M_VFR_Night_XC7.altRisk = M_VFR_Night_XC7.wind + M_VFR_Night_XC7.xwind + M_VFR_Night_XC7.ceiling + vis + fuel + iap;
                class1.riskShow(txtRisk, txtRiskNum, "Alternate Risk", M_VFR_Night_XC7.altRisk, 9, 12);
            };

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom3);

            btnNext.Click += delegate
            {
                if (M_VFR_Night_XC7.altRisk > 11)
                {
                    class1.alertShow("Alternate Risk", this);
                }
                else
                    StartActivity(typeof(M_VFR_Night_XC9));
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(M_VFR_Night_XC7));
            };
        }
    }
}