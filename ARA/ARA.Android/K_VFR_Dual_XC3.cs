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
    [Activity(Label = "Enroute or Practice Area - 1 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class K_VFR_Dual_XC3 : Activity
    {
        public static int vis, ceiling, manu, enrouteRisk;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.h_Layout_3);

            var lblCeiling = FindViewById<TextView>(Resource.Id.txtQuestion1);
            var btn4000 = FindViewById<Button>(Resource.Id.btnQ1C1);
            var btn3500to3999 = FindViewById<Button>(Resource.Id.btnQ1C2);
            var btn3000to3499 = FindViewById<Button>(Resource.Id.btnQ1C3);
            var txtCeiling = FindViewById<TextView>(Resource.Id.txtAnswer1);

            var lblVis = FindViewById<TextView>(Resource.Id.txtQuestion2);
            var btn7 = FindViewById<Button>(Resource.Id.btnQ2C1);
            var btn6 = FindViewById<Button>(Resource.Id.btnQ2C2);
            var btn5 = FindViewById<Button>(Resource.Id.btnQ2C3);
            var txtVis = FindViewById<TextView>(Resource.Id.txtAnswer2);

            var lblAreaManuevers = FindViewById<TextView>(Resource.Id.txtQuestion3);
            var btnNone = FindViewById<Button>(Resource.Id.btnQ3C1);
            var btn12 = FindViewById<Button>(Resource.Id.btnQ3C2);
            var btn3 = FindViewById<Button>(Resource.Id.btnQ3C3);
            var txtXWindSolo = FindViewById<TextView>(Resource.Id.txtAnswer3);

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskText);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNum);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom3);
            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);

            lblCeiling.Text = "Ceiling";
            btn4000.Text = "4000+ ft";
            btn3500to3999.Text = "3500 - 3999 ft";
            btn3000to3499.Text = "3000 - 3499 ft";

            lblVis.Text = "Visibility";
            btn7.Text = "7+ SM";
            btn6.Text = "6 SM";
            btn5.Text = "5 SM";

            lblAreaManuevers.Text = "Area Manuevers";
            btnNone.Text = "None";
            btn12.Text = "1 - 2";
            btn3.Text = "3 or more";

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.defaultVals(btn4000, btn3500to3999, btn3000to3499, txtCeiling, ceiling);
            sc.defaultVals(btn7, btn6, btn5, txtVis, vis);
            sc.defaultVals(btnNone, btn12, btn3, txtXWindSolo, manu);

            enrouteRisk = ceiling + vis + manu + K_VFR_Dual_XC4.checkpoints + K_VFR_Dual_XC4.timeEnroute;
            sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", enrouteRisk, 7, 9);

            btn4000.Touch += (s, e) =>
            {
                ceiling = sc.button1Pressed(btn4000, btn3500to3999, btn3000to3499, txtCeiling);
                enrouteRisk = ceiling + vis + manu + K_VFR_Dual_XC4.checkpoints + K_VFR_Dual_XC4.timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", enrouteRisk, 7, 9);

            };
            btn3500to3999.Touch += (s, e) =>
            {
                ceiling = sc.button2Pressed(btn4000, btn3500to3999, btn3000to3499, txtCeiling);
                enrouteRisk = ceiling + vis + manu + K_VFR_Dual_XC4.checkpoints + K_VFR_Dual_XC4.timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", enrouteRisk, 7, 9);
            };
            btn3000to3499.Touch += (s, e) =>
            {
                ceiling = sc.button3Pressed(btn4000, btn3500to3999, btn3000to3499, txtCeiling);
                enrouteRisk = ceiling + vis + manu + K_VFR_Dual_XC4.checkpoints + K_VFR_Dual_XC4.timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", enrouteRisk, 7, 9);
            };

            btn7.Touch += (s, e) =>
            {
                vis = sc.button1Pressed(btn7, btn6, btn5, txtVis);
                enrouteRisk = ceiling + vis + manu + K_VFR_Dual_XC4.checkpoints + K_VFR_Dual_XC4.timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", enrouteRisk, 7, 9);
            };
            btn6.Touch += (s, e) =>
            {
               vis = sc.button2Pressed(btn7, btn6, btn5, txtVis);
                enrouteRisk = ceiling + vis + manu + K_VFR_Dual_XC4.checkpoints + K_VFR_Dual_XC4.timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", enrouteRisk, 7, 9);
            };
            btn5.Touch += (s, e) =>
            {
                vis = sc.button3Pressed(btn7, btn6, btn5, txtVis);
                enrouteRisk = ceiling + vis + manu + K_VFR_Dual_XC4.checkpoints + K_VFR_Dual_XC4.timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", enrouteRisk, 7, 9);
            };

            btnNone.Touch += (s, e) =>
            {
                manu = sc.button1Pressed(btnNone, btn12, btn3, txtXWindSolo);
                enrouteRisk = ceiling + vis + manu + K_VFR_Dual_XC4.checkpoints + K_VFR_Dual_XC4.timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", enrouteRisk, 7, 9);
            };
            btn12.Touch += (s, e) =>
            {
                manu = sc.button2Pressed(btnNone, btn12, btn3, txtXWindSolo);
                enrouteRisk = ceiling + vis + manu + K_VFR_Dual_XC4.checkpoints + K_VFR_Dual_XC4.timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", enrouteRisk, 7, 9);

            };
            btn3.Touch += (s, e) =>
            {
                manu = sc.button3Pressed(btnNone, btn12, btn3, txtXWindSolo);
                enrouteRisk = ceiling + vis + manu + K_VFR_Dual_XC4.checkpoints + K_VFR_Dual_XC4.timeEnroute;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute or Practice Area Risk", enrouteRisk, 7, 9);

            };

            btnBack.Touch += (s, e) =>
            {
                StartActivity(typeof(K_VFR_Dual_XC2));
            };

            btnNext.Touch += (s, e) =>
            {
                StartActivity(typeof(K_VFR_Dual_XC4));
            };
            
        }
    }
}