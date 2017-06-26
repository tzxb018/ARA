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
    [Activity(Label = "Risk Assessment - 4 of 5")]
    public class D_Syllabus_Activity : Activity
    {

        public static bool isLocal;
        public static int riskVal;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.d_syllabus);

            var back = FindViewById<ImageButton>(Resource.Id.btnBackFromSyllabus);
            var next = FindViewById<ImageButton>(Resource.Id.btnContinueFromSyllabus);
            var area = FindViewById<ToggleButton>(Resource.Id.tglArea);
            var flightInfo = FindViewById<TextView>(Resource.Id.txtFlightInfo);
            var risk = FindViewById<TextView>(Resource.Id.txtRisk);

            //lots of conditoinals to help create the accurate toggle button
            if (B_Filing_Criteria_Activity.isVFR)
            {
                if (C_Time_VFR_Activity.VFRisDay)
                {
                    area.TextOff = "Local Pattern (2)";
                    area.TextOn = "XC, Practice Area, Aux Field (3)";
                    flightInfo.Text = "(Flying under VFR - Day, Pvt/Comm/CFI Solo & Flight Team)";
                    riskVal = 2;
                }
                else if (C_Time_VFR_Activity.VFRisDual)
                {
                    area.TextOff = "Local Pattern (4)";
                    area.TextOn = "XC, Practice Area, Aux Field (5)";
                    flightInfo.Text = "(Flying under VFR - Day/Night Dual";
                    riskVal = 4;
                }
                else
                {
                    area.TextOff = "Local Pattern (6)";
                    area.TextOn = "XC (7)";
                    flightInfo.Text = "(Flying under VFR - Night, Commerical/CFI Solo)";
                    riskVal = 6;
                }
            }
            else
            {
                if (C_Time_IFR_Activity.IFRisDual)
                {
                    area.TextOff = "Local Area (8)";
                    area.TextOn = "Cross Country (9)";
                    flightInfo.Text = "(Flying udner IFR, Day/Night, Dual)";
                    riskVal = 8;
                }
                else
                {
                    area.TextOff = "Local Area (10)";
                    area.TextOn = "Cross Country (11)";
                    flightInfo.Text = "(Flying under IFR, Day, Commerical/CFI Solo)";
                    riskVal = 10;
                }
            }

            area.Text = area.TextOff; //sets the default value to the given off value of the toggle button
            risk.Text = "Risk = " + riskVal;

            //click events for each condition
            //from this point, I realized that I should have done a running total instead of a condtional check total, it would have been more efficient with larger projects
            if (B_Filing_Criteria_Activity.isVFR)
            {
                if (C_Time_VFR_Activity.VFRisDay)
                {
                    area.Click += (s, e) =>
                    {
                        if (area.Checked)
                        {
                            riskVal = 3;
                            risk.Text = "Risk = " + riskVal;
                        }
                        else
                        {
                            riskVal = 2;
                            risk.Text = "Risk = " + riskVal;
                        }
                    };
                }
                else if (C_Time_VFR_Activity.VFRisDual)
                {
                    area.Click += (s, e) =>
                    {
                        if (area.Checked)
                        {
                            riskVal = 5;
                            risk.Text = "Risk = " + riskVal;
                        }
                        else
                        {
                            riskVal = 4;
                            risk.Text = "Risk = " + riskVal;
                        }
                    };
                }
                else
                {
                    area.Click += (s, e) =>
                    {
                        if (area.Checked)
                        {
                            riskVal = 7;
                            risk.Text = "Risk = " + riskVal;
                        }
                        else
                        {
                            riskVal = 6;
                            risk.Text = "Risk = " + riskVal;
                        }
                    };
                }
            }
            else
            {
                if (C_Time_IFR_Activity.IFRisDual)
                {
                    area.Click += (s, e) =>
                    {
                        if (area.Checked)
                        {
                            riskVal = 9;
                            risk.Text = "Risk = " + riskVal;
                        }
                        else
                        {
                            riskVal = 8;
                            risk.Text = "Risk = " + riskVal;
                        }
                    };
                }
                else
                {
                    area.Click += (s, e) =>
                    {
                        if (area.Checked)
                        {
                            riskVal = 11;
                            risk.Text = "Risk = " + riskVal;
                        }
                        else
                        {
                            riskVal = 10;
                            risk.Text = "Risk = " + riskVal;
                        }
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