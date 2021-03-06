﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ARA.Droid
{
    [Activity(Label = "Risk Assessment - 4 of 5", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class D_Syllabus_Activity : Activity
    {

        public static bool isLocal = true;
        public static int riskVal;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.d_syllabus);

            var back = FindViewById<ImageButton>(Resource.Id.btnBackFromSyllabus);
            var next = FindViewById<ImageButton>(Resource.Id.btnContinueFromSyllabus);
            var btnLocal = FindViewById<Button>(Resource.Id.btnLocal);
            var btnCross = FindViewById<Button>(Resource.Id.btnCross);
            var flightInfo = FindViewById<TextView>(Resource.Id.txtFlightInfo);
            var risk = FindViewById<TextView>(Resource.Id.txtRisk);
            var areaInfo = FindViewById<TextView>(Resource.Id.txtAreaChoice);

            //lots of conditoinals to help create the accurate toggle button
            if (B_Filing_Criteria_Activity.isVFR)
            {
                if (C_Time_VFR_Activity.VFRisDay)
                {
                    btnLocal.Text = "Local Pattern (2)";
                    btnCross.Text = "XC, Practice Area, Aux Field (3)";
                    flightInfo.Text = "(Flying under VFR - Day, Pvt/Comm/CFI Solo & Flight Team)";
                    areaInfo.Text = "You have selected the 'local pattern' choice.";
                    riskVal = 2; //default value is local area
                    btnLocal.Pressed = true;
                    btnCross.Pressed = false;
                }
                else if (C_Time_VFR_Activity.VFRisDual)
                {
                    btnLocal.Text = "Local Pattern (4)";
                    btnCross.Text = "XC, Practice Area, Aux Field (5)";
                    flightInfo.Text = "(Flying under VFR - Day/Night Dual)";
                    riskVal = 4;
                    areaInfo.Text = "You have selected the 'local pattern' choice.";
                    btnLocal.Pressed = true;
                    btnCross.Pressed = false;
                }
                else
                {
                    btnLocal.Text = "Local Pattern (6)";
                    btnCross.Text = "XC (7)";
                    flightInfo.Text = "(Flying under VFR - Night, Commerical/CFI Solo)";
                    riskVal = 6;
                    areaInfo.Text = "You have selected the 'local pattern' choice.";
                    btnLocal.Pressed = true;
                    btnCross.Pressed = false;
                }
            }
            else
            {
                if (C_Time_IFR_Activity.IFRisDual)
                {
                    btnLocal.Text = "Local Area (8)";
                    btnCross.Text = "Cross Country (9)";
                    flightInfo.Text = "(Flying udner IFR, Day/Night, Dual)";
                    riskVal = 8;
                    areaInfo.Text = "You have selected the 'local area' choice.";
                    btnLocal.Pressed = true;
                    btnCross.Pressed = false;
                }
                else
                {
                    btnLocal.Text = "Local Area (10)";
                    btnCross.Text = "Cross Country (11)";
                    flightInfo.Text = "(Flying under IFR, Day, Commerical/CFI Solo)";
                    riskVal = 10;
                    areaInfo.Text = "You have selected the 'local area' choice.";
                    btnLocal.Pressed = true;
                    btnCross.Pressed = false;
                }
            }

            risk.Text = "Risk: " + riskVal;

            //click events for each condition
            //from this point, I realized that I should have done a running total instead of a condtional check total, it would have been more efficient with larger projects
            if (B_Filing_Criteria_Activity.isVFR)
            {
                if (C_Time_VFR_Activity.VFRisDay)
                {
                    btnLocal.Touch += (s,e) =>
                    {
                        if (e.Event.Action == Android.Views.MotionEventActions.Down)
                        {
                            e.Handled = true;
                            return;
                        }

                        if (e.Event.Action == Android.Views.MotionEventActions.Up)
                        {
                            e.Handled = false;
                        }

                        if (btnLocal.Pressed == false)
                            btnLocal.Pressed = !btnLocal.Pressed;

                        e.Handled = true;
                        btnCross.Pressed = false;

                        isLocal = true;
                        areaInfo.Text = "You have selected the 'local pattern' choice.";
                        riskVal = 2;
                        risk.Text = "Risk: " + riskVal;
                    };

                    btnCross.Touch += (s,e) =>
                    {
                        if (e.Event.Action == Android.Views.MotionEventActions.Down)
                        {
                            e.Handled = true;
                            return;
                        }

                        if (e.Event.Action == Android.Views.MotionEventActions.Up)
                        {
                            e.Handled = false;
                        }

                        if (btnCross.Pressed == false)
                            btnCross.Pressed = !btnCross.Pressed;

                        e.Handled = true;
                        btnLocal.Pressed = false;

                        isLocal = false;
                        areaInfo.Text = "You have selected the 'XC, Practice Area, Aux Field' choice.";
                        riskVal = 3;
                        risk.Text = "Risk: " + riskVal;
                    };
                }
                else if (C_Time_VFR_Activity.VFRisDual)
                {
                    btnLocal.Touch += (s,e) =>
                    {
                        if (e.Event.Action == Android.Views.MotionEventActions.Down)
                        {
                            e.Handled = true;
                            return;
                        }

                        if (e.Event.Action == Android.Views.MotionEventActions.Up)
                        {
                            e.Handled = false;
                        }

                        if (btnLocal.Pressed == false)
                            btnLocal.Pressed = !btnLocal.Pressed;

                        e.Handled = true;
                        btnCross.Pressed = false;

                        isLocal = true;
                        areaInfo.Text = "You have selected the 'local pattern' choice.";
                        riskVal = 4;
                        risk.Text = "Risk: " + riskVal;
                    };

                    btnCross.Touch += (s,e) =>
                    {
                        if (e.Event.Action == Android.Views.MotionEventActions.Down)
                        {
                            e.Handled = true;
                            return;
                        }

                        if (e.Event.Action == Android.Views.MotionEventActions.Up)
                        {
                            e.Handled = false;
                        }

                        if (btnCross.Pressed == false)
                            btnCross.Pressed = !btnCross.Pressed;

                        e.Handled = true;
                        btnLocal.Pressed = false;

                        isLocal = false;
                        areaInfo.Text = "You have selected the 'XC, Practice Area, Aux Field' choice.";
                        riskVal = 5;
                        risk.Text = "Risk: " + riskVal;
                    };
                }
                else
                {
                    btnLocal.Touch += (s,e) =>
                    {

                        if (e.Event.Action == Android.Views.MotionEventActions.Down)
                        {
                            e.Handled = true;
                            return;
                        }

                        if (e.Event.Action == Android.Views.MotionEventActions.Up)
                        {
                            e.Handled = false;
                        }

                        if (btnLocal.Pressed == false)
                            btnLocal.Pressed = !btnLocal.Pressed;

                        e.Handled = true;
                        btnCross.Pressed = false;

                        isLocal = true;
                        areaInfo.Text = "You have selected the 'local pattern' choice.";
                        riskVal = 6;
                        risk.Text = "Risk: " + riskVal;
                    };

                    btnCross.Touch += (s,e) =>
                    {
                        if (e.Event.Action == Android.Views.MotionEventActions.Down)
                        {
                            e.Handled = true;
                            return;
                        }

                        if (e.Event.Action == Android.Views.MotionEventActions.Up)
                        {
                            e.Handled = false;
                        }

                        if (btnCross.Pressed == false)
                            btnCross.Pressed = !btnCross.Pressed;

                        e.Handled = true;
                        btnLocal.Pressed = false;

                        isLocal = false;
                        areaInfo.Text = "You have selected the 'XC' choice.";
                        riskVal = 7;
                        risk.Text = "Risk: " + riskVal;
                    };
                }
            }
            else
            {
                if (C_Time_IFR_Activity.IFRisDual)
                {
                    btnLocal.Touch += (s,e) =>
                    { 
                        if (e.Event.Action == Android.Views.MotionEventActions.Down)
                        {
                            e.Handled = true;
                            return;
                        }

                        if (e.Event.Action == Android.Views.MotionEventActions.Up)
                        {
                            e.Handled = false;
                        }

                        if (btnLocal.Pressed == false)
                            btnLocal.Pressed = !btnLocal.Pressed;

                        e.Handled = true;
                        btnCross.Pressed = false;

                        isLocal = true;
                        areaInfo.Text = "You have selected the 'local area' choice.";
                        riskVal = 8;
                        risk.Text = "Risk: " + riskVal;

                    };

                    btnCross.Touch += (s,e) =>
                    {
                        if (e.Event.Action == Android.Views.MotionEventActions.Down)
                        {
                            e.Handled = true;
                            return;
                        }

                        if (e.Event.Action == Android.Views.MotionEventActions.Up)
                        {
                            e.Handled = false;
                        }

                        if (btnCross.Pressed == false)
                            btnCross.Pressed = !btnCross.Pressed;

                        e.Handled = true;
                        btnLocal.Pressed = false;

                        isLocal = false;
                        areaInfo.Text = "You have selected the 'cross country' choice.";
                        riskVal = 9;
                        risk.Text = "Risk: " + riskVal;

                    };
                }
                else
                {
                    btnLocal.Touch += (s,e) =>
                    {
                        if (e.Event.Action == Android.Views.MotionEventActions.Down)
                        {
                            e.Handled = true;
                            return;
                        }

                        if (e.Event.Action == Android.Views.MotionEventActions.Up)
                        {
                            e.Handled = false;
                        }

                        if (btnLocal.Pressed == false)
                            btnLocal.Pressed = !btnLocal.Pressed;

                        e.Handled = true;
                        btnCross.Pressed = false;

                        isLocal = true;
                        areaInfo.Text = "You have selected the 'local area' choice.";
                        riskVal = 10;
                        risk.Text = "Risk: " + riskVal;
                    };

                    btnCross.Touch += (s,e) =>
                    {
                        if (e.Event.Action == Android.Views.MotionEventActions.Down)
                        {
                            e.Handled = true;
                            return;
                        }

                        if (e.Event.Action == Android.Views.MotionEventActions.Up)
                        {
                            e.Handled = false;
                        }

                        if (btnCross.Pressed == false)
                            btnCross.Pressed = !btnCross.Pressed;

                        e.Handled = true;
                        btnLocal.Pressed = false;

                        isLocal = false;
                        areaInfo.Text = "You have selected the 'cross country' choice.";
                        riskVal = 11;
                        risk.Text = "Risk: " + riskVal;
                    };
                }
            }

            back.Click += delegate
            {
                if (B_Filing_Criteria_Activity.isVFR)
                {
                    StartActivity(typeof(C_Time_VFR_Activity));
                }
                else
                {
                    StartActivity(typeof(C_Time_IFR_Activity));
                }
                //returns back to the previous page using a boolean from the selecting page of VFR vs. IFR
            };

            next.Click += delegate
            {
                StartActivity(typeof(E_Personal_Information));
            };
        }
    }
}