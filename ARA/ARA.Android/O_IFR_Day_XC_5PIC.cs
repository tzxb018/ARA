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
    [Activity(Label = "PIC")]
    public class O_IFR_Day_XC_5PIC : Activity
    {
        public static int last, dual, curr, PIC;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.h_Layout_3);

            var lblLast = FindViewById<TextView>(Resource.Id.txtQuestion1);
            var btn30 = FindViewById<Button>(Resource.Id.btnQ1C1);
            var btn30to45 = FindViewById<Button>(Resource.Id.btnQ1C2);
            var btn45 = FindViewById<Button>(Resource.Id.btnQ1C3);
            var txtLast = FindViewById<TextView>(Resource.Id.txtAnswer1);

            var lblDual = FindViewById<TextView>(Resource.Id.txtQuestion2);
            var btnLess30 = FindViewById<Button>(Resource.Id.btnQ2C1);
            var btn30to452 = FindViewById<Button>(Resource.Id.btnQ2C2);
            var btn45Plus = FindViewById<Button>(Resource.Id.btnQ2C3);
            var txtDulal = FindViewById<TextView>(Resource.Id.txtAnswer2);

            var lblIFR = FindViewById<TextView>(Resource.Id.txtQuestion3);
            var btnYes = FindViewById<Button>(Resource.Id.btnQ3C1);
            var btnNon = FindViewById<Button>(Resource.Id.btnQ3C2);
            var btnNo = FindViewById<Button>(Resource.Id.btnQ3C3);
            var txtiFR = FindViewById<TextView>(Resource.Id.txtAnswer3);

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskText);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNum);

            lblLast.Text = "Last Dual Landing";
            btn30.Text = "< 30 days";
            btn30to45.Text = "30 - 45 days";
            btn45.Text = "> 45 days";

            lblDual.Text = "Dual Instrument Approach";
            btnLess30.Text = "< 30 days";
            btn30to452.Text = "30 - 45 days";
            btn45Plus.Text = "> 45 days";

            lblIFR.Text = "IFR Current?";
            btnYes.Text = "Yes";
            btnNon.Text = "Non-Precision";
            btnNon.Visibility = ViewStates.Invisible;
            btnNo.Text = "No";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn30, btn30to45, btn45, txtLast, last);
            class1.defaultVals(btnLess30, btn30to452, btn45Plus, txtDulal, dual);
            class1.defaultVals(btnYes, btnNon, btnNo, txtiFR, curr);

            PIC = last + dual + curr;
            class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", PIC, 2, 3);

            btn30.Touch += (s, e) =>
            {
                last = class1.button1Pressed(btn30, btn30to45, btn45, txtLast);
                PIC = last + dual + curr;
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", PIC, 2, 3);
            };
            btn30to45.Touch += (s, e) =>
            {
                last = class1.button2Pressed(btn30, btn30to45, btn45, txtLast);
                PIC = last + dual + curr;
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", PIC, 2, 3);
            };
            btn45.Touch += (s, e) =>
            {
                last = class1.button3Pressed(btn30, btn30to45, btn45, txtLast);
                PIC = last + dual + curr;
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", PIC, 2, 3);

            };

            btnLess30.Touch += (s, e) =>
            {
                dual = class1.button1Pressed(btnLess30, btn30to452, btn45Plus, txtDulal);
                PIC = last + dual + curr;
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", PIC, 2, 3);
            };
            btn30to452.Touch += (s, e) =>
            {
                dual = class1.button2Pressed(btnLess30, btn30to452, btn45Plus, txtDulal);
                PIC = last + dual + curr;
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", PIC, 2, 3);
            };
            btn45Plus.Touch += (s, e) =>
            {
                dual = class1.button3Pressed(btnLess30, btn30to452, btn45Plus, txtDulal);
                PIC = last + dual + curr;
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", PIC, 2, 3);
            };

            btnYes.Touch += (s, e) =>
            {
                curr = class1.button1Pressed(btnYes, btnNon, btnNo, txtiFR);
                PIC = last + dual + curr;
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", PIC, 2, 3);
            };
            btnNo.Touch += (s, e) =>
            {
                curr = class1.button3Pressed(btnYes, btnNon, btnNo, txtiFR);
                PIC = last + dual + curr;
                class1.riskShow(txtRisk, txtRiskNum, "PIC Risk", PIC, 2, 3);
            };

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom3);

            btnNext.Click += delegate
            {
                if (PIC > 2)
                {
                    class1.alertShow("PIC Risk", this);
                }
                else
                    StartActivity(typeof(Y_Aircraft_and_Instructor));
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(N_IFR_Day_Local_Alternate));
            };
        }
    }
}