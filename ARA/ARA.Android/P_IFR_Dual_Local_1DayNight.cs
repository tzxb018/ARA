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
using ARA.Droid.Fragments;

namespace ARA.Droid
{
    [Activity(Label = "Home Airfield - Time Assessment", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, MainLauncher = true)]
    public class P_IFR_Dual_Local_1DayNight : Activity
    {
        public static int time, dayCeiling, nightCeiling, timeRisk;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.h_Layout_3);

            var lblTime = FindViewById<TextView>(Resource.Id.txtQuestion1);
            var btnDay = FindViewById<Button>(Resource.Id.btnQ1C1);
            var btnNight = FindViewById<Button>(Resource.Id.btnQ1C2);
            var btnBoth = FindViewById<Button>(Resource.Id.btnQ1C3);
            var txtTime = FindViewById<TextView>(Resource.Id.txtAnswer1);

            var lblDay = FindViewById<TextView>(Resource.Id.txtQuestion2);
            var btn1000 = FindViewById<Button>(Resource.Id.btnQ2C1);
            var btn800 = FindViewById<Button>(Resource.Id.btnQ2C2);
            var btn600 = FindViewById<Button>(Resource.Id.btnQ2C3);
            var txtDay = FindViewById<TextView>(Resource.Id.txtAnswer2);

            var lblNight = FindViewById<TextView>(Resource.Id.txtQuestion3);
            var btn1500 = FindViewById<Button>(Resource.Id.btnQ3C1);
            var btn1200 = FindViewById<Button>(Resource.Id.btnQ3C2);
            var btn1000to = FindViewById<Button>(Resource.Id.btnQ3C3);
            var txtNight = FindViewById<TextView>(Resource.Id.txtAnswer3);

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskText);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNum);

            lblTime.Text = "What time of day are you flying?";
            btnDay.Text = "Day";
            btnNight.Text = "Night";
            btnBoth.Text = "Both Day and Night";

            lblDay.Text = "Ceiling (Day)";
            btn1000.Text = "> 1000 ft";
            btn800.Text = "800 - 999 ft";
            btn600.Text = "600 - 799 ft";

            lblNight.Text = "Ceiling (Night)";
            btn1500.Text = "> 1500 ft";
            btn1200.Text = "1200 - 1499 ft";
            btn1000.Text = "1000 - 1199 ft";

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.defaultVals(btnDay, btnNight, btnBoth, txtTime, time);
            sc.defaultVals(btn1000, btn800, btn600, txtDay, dayCeiling);
            sc.defaultVals(btn1500, btn1200, btn1000, txtNight, nightCeiling);

            if (time == 0)
            {
                timeRisk = dayCeiling;
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
            else if (time == 1)
            {
                timeRisk = nightCeiling;
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
                timeRisk = dayCeiling + nightCeiling;
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
            P_IFR_Dual_Local_2Home.homeRisk = timeRisk + P_IFR_Dual_Local1.risk1 + P_IFR_Dual_Local1.risk2 + P_IFR_Dual_Local2.risk4 + P_IFR_Dual_Local2.risk5;
            sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", P_IFR_Dual_Local_2Home.homeRisk, 8 , 10);

            btnDay.Touch += (s, e) =>
            {
                sc.defaultVals(btn1000, btn800, btn600, txtDay, dayCeiling);
                sc.defaultVals(btn1500, btn1200, btn1000, txtNight, nightCeiling);
                time = sc.button1Pressed(btnDay, btnNight, btnBoth, txtTime);
                if(time == 0)
                {
                    timeRisk = dayCeiling;
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
                else if (time == 1)
                {
                    timeRisk = nightCeiling;
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
                    timeRisk = dayCeiling + nightCeiling;
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
                P_IFR_Dual_Local_2Home.homeRisk = timeRisk + P_IFR_Dual_Local1.risk1 + P_IFR_Dual_Local1.risk2 + P_IFR_Dual_Local2.risk4 + P_IFR_Dual_Local2.risk5;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", P_IFR_Dual_Local_2Home.homeRisk, 8, 10);
            };
            btnNight.Touch += (s, e) =>
            {
                sc.defaultVals(btn1000, btn800, btn600, txtDay, dayCeiling);
                sc.defaultVals(btn1500, btn1200, btn1000, txtNight, nightCeiling);
                time = sc.button2Pressed(btnDay, btnNight, btnBoth, txtTime);
                if (time == 0)
                {
                    timeRisk = dayCeiling;
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
                else if (time == 1)
                {
                    timeRisk = nightCeiling;
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
                    timeRisk = dayCeiling + nightCeiling;
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
                P_IFR_Dual_Local_2Home.homeRisk = timeRisk + P_IFR_Dual_Local1.risk1 + P_IFR_Dual_Local1.risk2 + P_IFR_Dual_Local2.risk4 + P_IFR_Dual_Local2.risk5;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", P_IFR_Dual_Local_2Home.homeRisk, 8, 10);
            };
            btnBoth.Touch += (s, e) =>
            {
                sc.defaultVals(btn1000, btn800, btn600, txtDay, dayCeiling);
                sc.defaultVals(btn1500, btn1200, btn1000, txtNight, nightCeiling);
                time = sc.button3Pressed(btnDay, btnNight, btnBoth, txtTime);
                if (time == 0)
                {
                    timeRisk = dayCeiling;
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
                else if (time == 1)
                {
                    timeRisk = nightCeiling;
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
                    timeRisk = dayCeiling + nightCeiling;
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
                P_IFR_Dual_Local_2Home.homeRisk = timeRisk + P_IFR_Dual_Local1.risk1 + P_IFR_Dual_Local1.risk2 + P_IFR_Dual_Local2.risk4 + P_IFR_Dual_Local2.risk5;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", P_IFR_Dual_Local_2Home.homeRisk, 8, 10);

            };

            btn1000.Touch += (s, e) =>
            {
                dayCeiling = sc.button1Pressed(btn1000, btn800, btn600, txtDay);
                if (time == 0)
                {
                    timeRisk = dayCeiling;
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
                else if (time == 1)
                {
                    timeRisk = nightCeiling;
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
                    timeRisk = dayCeiling + nightCeiling;
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
                P_IFR_Dual_Local_2Home.homeRisk = timeRisk + P_IFR_Dual_Local1.risk1 + P_IFR_Dual_Local1.risk2 + P_IFR_Dual_Local2.risk4 + P_IFR_Dual_Local2.risk5;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", P_IFR_Dual_Local_2Home.homeRisk, 8, 10);

            };
            btn800.Touch += (s, e) =>
            {
                dayCeiling = sc.button2Pressed(btn1000, btn800, btn600, txtDay);
                if (time == 0)
                {
                    timeRisk = dayCeiling;
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
                else if (time == 1)
                {
                    timeRisk = nightCeiling;
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
                    timeRisk = dayCeiling + nightCeiling;
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
                P_IFR_Dual_Local_2Home.homeRisk = timeRisk + P_IFR_Dual_Local1.risk1 + P_IFR_Dual_Local1.risk2 + P_IFR_Dual_Local2.risk4 + P_IFR_Dual_Local2.risk5;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", P_IFR_Dual_Local_2Home.homeRisk, 8, 10);

            };
            btn600.Touch += (s, e) =>
            {
                dayCeiling = sc.button3Pressed(btn1000, btn800, btn600, txtDay);
                if (time == 0)
                {
                    timeRisk = dayCeiling;
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
                else if (time == 1)
                {
                    timeRisk = nightCeiling;
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
                    timeRisk = dayCeiling + nightCeiling;
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
                P_IFR_Dual_Local_2Home.homeRisk = timeRisk + P_IFR_Dual_Local1.risk1 + P_IFR_Dual_Local1.risk2 + P_IFR_Dual_Local2.risk4 + P_IFR_Dual_Local2.risk5;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", P_IFR_Dual_Local_2Home.homeRisk, 8, 10);
            };

            btn1500.Touch += (s, e) =>
            {
                nightCeiling = sc.button1Pressed(btn1500, btn1200, btn1000, txtNight);
                if (time == 0)
                {
                    timeRisk = dayCeiling;
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
                else if (time == 1)
                {
                    timeRisk = nightCeiling;
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
                    timeRisk = dayCeiling + nightCeiling;
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
                P_IFR_Dual_Local_2Home.homeRisk = timeRisk + P_IFR_Dual_Local1.risk1 + P_IFR_Dual_Local1.risk2 + P_IFR_Dual_Local2.risk4 + P_IFR_Dual_Local2.risk5;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", P_IFR_Dual_Local_2Home.homeRisk, 8, 10);

            };
            btn1200.Touch += (s, e) =>
            { 
                nightCeiling = sc.button2Pressed(btn1500, btn1200, btn1000, txtNight);
                if (time == 0)
                {
                    timeRisk = dayCeiling;
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
                else if (time == 1)
                {
                    timeRisk = nightCeiling;
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
                    timeRisk = dayCeiling + nightCeiling;
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
                P_IFR_Dual_Local_2Home.homeRisk = timeRisk + P_IFR_Dual_Local1.risk1 + P_IFR_Dual_Local1.risk2 + P_IFR_Dual_Local2.risk4 + P_IFR_Dual_Local2.risk5;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", P_IFR_Dual_Local_2Home.homeRisk, 8, 10);

            };
            btn1000.Touch += (s, e) =>
            {
                nightCeiling = sc.button3Pressed(btn1500, btn1200, btn1000, txtNight);
                if (time == 0)
                {
                    timeRisk = dayCeiling;
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
                else if (time == 1)
                {
                    timeRisk = nightCeiling;
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
                    timeRisk = dayCeiling + nightCeiling;
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
                P_IFR_Dual_Local_2Home.homeRisk = timeRisk + P_IFR_Dual_Local1.risk1 + P_IFR_Dual_Local1.risk2 + P_IFR_Dual_Local2.risk4 + P_IFR_Dual_Local2.risk5;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", P_IFR_Dual_Local_2Home.homeRisk, 8, 10);
            };

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom3);

            btnNext.Click += delegate
            {
                StartActivity(typeof(P_IFR_Dual_Local_2Home));
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(G_Student_Human_Factors_2));
            };
        }
    }
}