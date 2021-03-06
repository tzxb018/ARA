﻿
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using ARA.Droid.Fragments;

namespace ARA.Droid
{
    [Activity(Label = "Alternate", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class P_IFR_Dual_Local_3DayNight : Activity
    {
        public static int dayCeiling, nightCeiling, ceilingRisk;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.h_Layout2);

            var lblNight = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btn1500 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn1200 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn1000to = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtNight = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblDay = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btn1000 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn800 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn600 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtDay = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblNight.Text = "Ceiling (Night)";
            btn1500.Text = "> 1500 ft";
            btn1200.Text = "1200 - 1499 ft";
            btn1000to.Text = "1000 - 1199 ft";

            lblDay.Text = "Ceiling (Day)";
            btn1000.Text = "> 1000 ft";
            btn800.Text = "800 - 999 ft";
            btn600.Text = "600 - 799 ft";

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.defaultVals(btn1500, btn1200, btn1000to, txtNight, nightCeiling);
            sc.defaultVals(btn1000, btn800, btn600, txtDay, dayCeiling);

            if (P_IFR_Dual_Local_1DayNight.time == 0)
            {
                ceilingRisk = dayCeiling;
                lblDay.Visibility = ViewStates.Visible;
                btn1000.Visibility = ViewStates.Visible;
                btn800.Visibility = ViewStates.Visible;
                btn600.Visibility = ViewStates.Visible;
                txtDay.Visibility = ViewStates.Visible;
                lblNight.Visibility = ViewStates.Invisible;
                btn1500.Visibility = ViewStates.Invisible;
                btn1200.Visibility = ViewStates.Invisible;
                btn1000to.Visibility = ViewStates.Invisible;
                txtNight.Visibility = ViewStates.Invisible;
            }
            else if (P_IFR_Dual_Local_1DayNight.time == 1)
            {
                ceilingRisk = nightCeiling;
                lblDay.Visibility = ViewStates.Invisible;
                btn1000.Visibility = ViewStates.Invisible;
                btn800.Visibility = ViewStates.Invisible;
                btn600.Visibility = ViewStates.Invisible;
                lblNight.Visibility = ViewStates.Visible;
                btn1500.Visibility = ViewStates.Visible;
                btn1200.Visibility = ViewStates.Visible;
                btn1000to.Visibility = ViewStates.Visible;
                txtNight.Visibility = ViewStates.Visible;
                txtDay.Visibility = ViewStates.Invisible;
            }
            else
            {
                ceilingRisk = dayCeiling + nightCeiling;
                lblDay.Visibility = ViewStates.Visible;
                btn1000.Visibility = ViewStates.Visible;
                btn800.Visibility = ViewStates.Visible;
                btn600.Visibility = ViewStates.Visible;
                lblNight.Visibility = ViewStates.Visible;
                btn1500.Visibility = ViewStates.Visible;
                btn1200.Visibility = ViewStates.Visible;
                btn1000to.Visibility = ViewStates.Visible;
                txtDay.Visibility = ViewStates.Visible;
                txtNight.Visibility = ViewStates.Visible;
            }
            P_IFR_Dual_Local_4Alt.altRisk = P_IFR_Dual_Local3.risk1 + P_IFR_Dual_Local3.risk2 + P_IFR_Dual_Local4.risk3 + P_IFR_Dual_Local4.risk4 + P_IFR_Dual_Local4.risk5 + P_IFR_Dual_Local_3DayNight.ceilingRisk;
            sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", P_IFR_Dual_Local_4Alt.altRisk, 9, 12);

            btn1500.Touch += (s, e) =>
            {
                nightCeiling = sc.button1Pressed(btn1500, btn1200, btn1000to, txtNight);
                if (P_IFR_Dual_Local_1DayNight.time == 0)
                {
                    ceilingRisk = dayCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Invisible;
                    btn1500.Visibility = ViewStates.Invisible;
                    btn1200.Visibility = ViewStates.Invisible;
                    btn1000to.Visibility = ViewStates.Invisible;
                    txtNight.Visibility = ViewStates.Invisible;
                }
                else if (P_IFR_Dual_Local_1DayNight.time == 1)
                {
                    ceilingRisk = nightCeiling;
                    lblDay.Visibility = ViewStates.Invisible;
                    btn1000.Visibility = ViewStates.Invisible;
                    btn800.Visibility = ViewStates.Invisible;
                    btn600.Visibility = ViewStates.Invisible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Invisible;
                }
                else
                {
                    ceilingRisk = dayCeiling + nightCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                }
                P_IFR_Dual_Local_4Alt.altRisk = P_IFR_Dual_Local3.risk1 + P_IFR_Dual_Local3.risk2 + P_IFR_Dual_Local4.risk3 + P_IFR_Dual_Local4.risk4 + P_IFR_Dual_Local4.risk5 + P_IFR_Dual_Local_3DayNight.ceilingRisk;
                sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", P_IFR_Dual_Local_4Alt.altRisk, 9, 12);
            };
            btn1200.Touch += (s, e) =>
            {
                nightCeiling = sc.button2Pressed(btn1500, btn1200, btn1000to, txtNight);
                if (P_IFR_Dual_Local_1DayNight.time == 0)
                {
                    ceilingRisk = dayCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Invisible;
                    btn1500.Visibility = ViewStates.Invisible;
                    btn1200.Visibility = ViewStates.Invisible;
                    btn1000to.Visibility = ViewStates.Invisible;
                    txtNight.Visibility = ViewStates.Invisible;
                }
                else if (P_IFR_Dual_Local_1DayNight.time == 1)
                {
                    ceilingRisk = nightCeiling;
                    lblDay.Visibility = ViewStates.Invisible;
                    btn1000.Visibility = ViewStates.Invisible;
                    btn800.Visibility = ViewStates.Invisible;
                    btn600.Visibility = ViewStates.Invisible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Invisible;
                }
                else
                {
                    ceilingRisk = dayCeiling + nightCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                }
                P_IFR_Dual_Local_4Alt.altRisk = P_IFR_Dual_Local3.risk1 + P_IFR_Dual_Local3.risk2 + P_IFR_Dual_Local4.risk3 + P_IFR_Dual_Local4.risk4 + P_IFR_Dual_Local4.risk5 + P_IFR_Dual_Local_3DayNight.ceilingRisk;
                sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", P_IFR_Dual_Local_4Alt.altRisk, 9, 12);
            };
            btn1000to.Touch += (s, e) =>
            {
                nightCeiling = sc.button3Pressed(btn1500, btn1200, btn1000to, txtNight);
                if (P_IFR_Dual_Local_1DayNight.time == 0)
                {
                    ceilingRisk = dayCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Invisible;
                    btn1500.Visibility = ViewStates.Invisible;
                    btn1200.Visibility = ViewStates.Invisible;
                    btn1000to.Visibility = ViewStates.Invisible;
                    txtNight.Visibility = ViewStates.Invisible;
                }
                else if (P_IFR_Dual_Local_1DayNight.time == 1)
                {
                    ceilingRisk = nightCeiling;
                    lblDay.Visibility = ViewStates.Invisible;
                    btn1000.Visibility = ViewStates.Invisible;
                    btn800.Visibility = ViewStates.Invisible;
                    btn600.Visibility = ViewStates.Invisible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Invisible;
                }
                else
                {
                    ceilingRisk = dayCeiling + nightCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                }
                P_IFR_Dual_Local_4Alt.altRisk = P_IFR_Dual_Local3.risk1 + P_IFR_Dual_Local3.risk2 + P_IFR_Dual_Local4.risk3 + P_IFR_Dual_Local4.risk4 + P_IFR_Dual_Local4.risk5 + P_IFR_Dual_Local_3DayNight.ceilingRisk;
                sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", P_IFR_Dual_Local_4Alt.altRisk, 9, 12);
            };

            btn1000.Touch += (s, e) =>
            {
                dayCeiling = sc.button1Pressed(btn1000, btn800, btn600, txtDay);
                if (P_IFR_Dual_Local_1DayNight.time == 0)
                {
                    ceilingRisk = dayCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Invisible;
                    btn1500.Visibility = ViewStates.Invisible;
                    btn1200.Visibility = ViewStates.Invisible;
                    btn1000to.Visibility = ViewStates.Invisible;
                    txtNight.Visibility = ViewStates.Invisible;
                }
                else if (P_IFR_Dual_Local_1DayNight.time == 1)
                {
                    ceilingRisk = nightCeiling;
                    lblDay.Visibility = ViewStates.Invisible;
                    btn1000.Visibility = ViewStates.Invisible;
                    btn800.Visibility = ViewStates.Invisible;
                    btn600.Visibility = ViewStates.Invisible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Invisible;
                }
                else
                {
                    ceilingRisk = dayCeiling + nightCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                }
                P_IFR_Dual_Local_4Alt.altRisk = P_IFR_Dual_Local3.risk1 + P_IFR_Dual_Local3.risk2 + P_IFR_Dual_Local4.risk3 + P_IFR_Dual_Local4.risk4 + P_IFR_Dual_Local4.risk5 + P_IFR_Dual_Local_3DayNight.ceilingRisk;
                sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", P_IFR_Dual_Local_4Alt.altRisk, 9, 12);
            };
            btn800.Touch += (s, e) =>
            {
                dayCeiling = sc.button2Pressed(btn1000, btn800, btn600, txtDay);
                if (P_IFR_Dual_Local_1DayNight.time == 0)
                {
                    ceilingRisk = dayCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Invisible;
                    btn1500.Visibility = ViewStates.Invisible;
                    btn1200.Visibility = ViewStates.Invisible;
                    btn1000to.Visibility = ViewStates.Invisible;
                    txtNight.Visibility = ViewStates.Invisible;
                }
                else if (P_IFR_Dual_Local_1DayNight.time == 1)
                {
                    ceilingRisk = nightCeiling;
                    lblDay.Visibility = ViewStates.Invisible;
                    btn1000.Visibility = ViewStates.Invisible;
                    btn800.Visibility = ViewStates.Invisible;
                    btn600.Visibility = ViewStates.Invisible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Invisible;
                }
                else
                {
                    ceilingRisk = dayCeiling + nightCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                }
                P_IFR_Dual_Local_4Alt.altRisk = P_IFR_Dual_Local3.risk1 + P_IFR_Dual_Local3.risk2 + P_IFR_Dual_Local4.risk3 + P_IFR_Dual_Local4.risk4 + P_IFR_Dual_Local4.risk5 + P_IFR_Dual_Local_3DayNight.ceilingRisk;
                sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", P_IFR_Dual_Local_4Alt.altRisk, 9, 12);
            };
            btn600.Touch += (s, e) =>
            {
                dayCeiling = sc.button3Pressed(btn1000, btn800, btn600, txtDay);
                if (P_IFR_Dual_Local_1DayNight.time == 0)
                {
                    ceilingRisk = dayCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Invisible;
                    btn1500.Visibility = ViewStates.Invisible;
                    btn1200.Visibility = ViewStates.Invisible;
                    btn1000to.Visibility = ViewStates.Invisible;
                    txtNight.Visibility = ViewStates.Invisible;
                }
                else if (P_IFR_Dual_Local_1DayNight.time == 1)
                {
                    ceilingRisk = nightCeiling;
                    lblDay.Visibility = ViewStates.Invisible;
                    btn1000.Visibility = ViewStates.Invisible;
                    btn800.Visibility = ViewStates.Invisible;
                    btn600.Visibility = ViewStates.Invisible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Invisible;
                }
                else
                {
                    ceilingRisk = dayCeiling + nightCeiling;
                    lblDay.Visibility = ViewStates.Visible;
                    btn1000.Visibility = ViewStates.Visible;
                    btn800.Visibility = ViewStates.Visible;
                    btn600.Visibility = ViewStates.Visible;
                    lblNight.Visibility = ViewStates.Visible;
                    btn1500.Visibility = ViewStates.Visible;
                    btn1200.Visibility = ViewStates.Visible;
                    btn1000to.Visibility = ViewStates.Visible;
                    txtDay.Visibility = ViewStates.Visible;
                    txtNight.Visibility = ViewStates.Visible;
                }
                P_IFR_Dual_Local_4Alt.altRisk = P_IFR_Dual_Local3.risk1 + P_IFR_Dual_Local3.risk2 + P_IFR_Dual_Local4.risk3 + P_IFR_Dual_Local4.risk4 + P_IFR_Dual_Local4.risk5 + P_IFR_Dual_Local_3DayNight.ceilingRisk;
                sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", P_IFR_Dual_Local_4Alt.altRisk, 9, 12);
            };

            
            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            btnNext.Click += delegate
            {
                StartActivity(typeof(P_IFR_Dual_Local_4Alt));
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(P_IFR_Dual_Local_2Home));
            };
        }
    }
}