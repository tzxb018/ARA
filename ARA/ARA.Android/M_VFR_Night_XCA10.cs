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
    [Activity(Label = "PIC - 2 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class M_VFR_Night_XCA10 : Activity
    {
        public static int dia, IFRCurr;

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

            var lblIFR = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btnYes = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btnfio = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btnNo = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txt3Night = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtPICRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtPICRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblDual.Text = "Dual Instrument Approach";
            btnLessThan30.Text = "<30 days";
            btn30to45.Text = "30 - 45 days";
            btn45Plus.Text = ">45 days";
            txtDual.Text = "You have selected the '" + btnLessThan30.Text + "' choice.";

            lblIFR.Text = "IFR current?";
            btnYes.Text = "Yes";
            btnfio.Visibility = ViewStates.Invisible;
            btnNo.Text = "No"; // only two options for this question

            txt3Night.Text = "You have selected the '" + btnYes.Text + "' choice.";

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.defaultVals(btnLessThan30, btn30to45, btn45Plus, txtDual, dia);
            sc.defaultVals(btnYes, btnfio, btnNo, txt3Night, IFRCurr);

            M_VFR_Night_XC9.pic = IFRCurr + dia + M_VFR_Night_XC9.Night3 + M_VFR_Night_XC9.ldl;
            sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", M_VFR_Night_XC9.pic, 2, 3);

            btnLessThan30.Touch += (s, e) =>
            {
                dia = sc.button1Pressed(btnLessThan30, btn30to45, btn45Plus, txtDual);
                M_VFR_Night_XC9.pic = IFRCurr + dia + M_VFR_Night_XC9.Night3 + M_VFR_Night_XC9.ldl;
                sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", M_VFR_Night_XC9.pic, 2, 3);
            };
            btn30to45.Touch += (s, e) =>
            {
                dia = sc.button2Pressed(btnLessThan30, btn30to45, btn45Plus, txtDual);
                M_VFR_Night_XC9.pic = IFRCurr + dia + M_VFR_Night_XC9.Night3 + M_VFR_Night_XC9.ldl;
                sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", M_VFR_Night_XC9.pic, 2, 3);
            };
            btn45Plus.Touch += (s, e) =>
            {
                dia = sc.button3Pressed(btnLessThan30, btn30to45, btn45Plus, txtDual);
                M_VFR_Night_XC9.pic = IFRCurr + dia + M_VFR_Night_XC9.Night3 + M_VFR_Night_XC9.ldl;
                sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", M_VFR_Night_XC9.pic, 2, 3);
            };

            btnYes.Touch += (s, e) =>
            {
                IFRCurr = sc.button1Pressed(btnYes, btnfio, btnNo, txt3Night);
                M_VFR_Night_XC9.pic = IFRCurr + dia + M_VFR_Night_XC9.Night3 + M_VFR_Night_XC9.ldl;
                sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", M_VFR_Night_XC9.pic, 2, 3);
            };
            btnNo.Touch += (s, e) =>
            {
                IFRCurr = sc.button3Pressed(btnYes, btnfio, btnNo, txt3Night);
                M_VFR_Night_XC9.pic = IFRCurr + dia + M_VFR_Night_XC9.Night3 + M_VFR_Night_XC9.ldl;
                sc.riskShow(txtPICRisk, txtPICRiskNum, "PIC Risk", M_VFR_Night_XC9.pic, 2, 3);
            };


            btnNext.Click += delegate
            {
                if (M_VFR_Night_XC9.pic < 3)
                {
                    StartActivity(typeof(Y_Aircraft_and_Instructor));

                }
                else
                {
                    sc.alertShow("PIC Risk", this);
                }
            };
            btnBack.Click += delegate
            {
                StartActivity(typeof(M_VFR_Night_XC9));
            };
        }
    }
}