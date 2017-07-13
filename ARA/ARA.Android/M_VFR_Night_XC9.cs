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
    [Activity(Label = "PIC - 1 of 2")]
    public class M_VFR_Night_XC9 : Activity
    {
        public static int pic, Night3, ldl;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblDual = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btnLessThan30 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn30to45 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn45Plus = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtDual = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lbl3Night = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btnLessthan45 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn45 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn90 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txt3Night = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtPICRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtPICRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblDual.Text = "Last dual landing";
            btnLessThan30.Text = "<30 days";
            btn30to45.Text = "30 - 45 days";
            btn45Plus.Text = ">45 days";
            txtDual.Text = "You have selected the '" + btnLessThan30.Text + "' choice.";

            lbl3Night.Text = "3 Night Landings";
            btnLessthan45.Text = "< 45 days";
            btn45.Text = "45 - 90 days";
            btn90.Text = "> 90 days";
            txt3Night.Text = "You have selected the '" + btnLessthan45.Text + "' choice.";

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.defaultVals(btnLessThan30, btn30to45, btn45Plus, txtDual, ldl);
            sc.defaultVals(btnLessthan45, btn45, btn90, txt3Night, Night3);

            pic = Night3 + ldl + M_VFR_Night_XCA10.dia + M_VFR_Night_XCA10.IFRCurr;
            sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", pic, 2, 3);

            btnLessThan30.Touch += (s, e) =>
            {
                ldl = sc.button1Pressed(btnLessThan30, btn30to45, btn45Plus, txtDual);
                pic = Night3 + ldl + M_VFR_Night_XCA10.dia + M_VFR_Night_XCA10.IFRCurr;
                sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", pic, 2, 3);
            };
            btn30to45.Touch += (s, e) =>
            {
                ldl = sc.button2Pressed(btnLessThan30, btn30to45, btn45Plus, txtDual);
                pic = Night3 + ldl + M_VFR_Night_XCA10.dia + M_VFR_Night_XCA10.IFRCurr;
                sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", pic, 2, 3);
            };
            btn45Plus.Touch += (s, e) =>
            {
                ldl = sc.button3Pressed(btnLessThan30, btn30to45, btn45Plus, txtDual);
                pic = Night3 + ldl + M_VFR_Night_XCA10.dia + M_VFR_Night_XCA10.IFRCurr;
                sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", pic, 2, 3);
            };

            btnLessthan45.Touch += (s, e) =>
            {
                Night3 = sc.button1Pressed(btnLessthan45, btn45, btn90, txt3Night);
                pic = Night3 + ldl + M_VFR_Night_XCA10.dia + M_VFR_Night_XCA10.IFRCurr;
                sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", pic, 2, 3);
            };
            btn45.Touch += (s, e) =>
            {
                Night3 = sc.button2Pressed(btnLessthan45, btn45, btn90, txt3Night);
                pic = Night3 + ldl + M_VFR_Night_XCA10.dia + M_VFR_Night_XCA10.IFRCurr;
                sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", pic, 2, 3);
            };
            btn90.Touch += (s, e) =>
            {
                Night3 = sc.button3Pressed(btnLessthan45, btn45, btn90, txt3Night);
                pic = Night3 + ldl + M_VFR_Night_XCA10.dia + M_VFR_Night_XCA10.IFRCurr;
                sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", pic, 2, 3);
            };

            btnNext.Click += delegate
            {
                StartActivity(typeof(M_VFR_Night_XCA10));
            };
            btnBack.Click += delegate
            {
                StartActivity(typeof(M_VFR_Night_XC8));
            };
        }
    }
}