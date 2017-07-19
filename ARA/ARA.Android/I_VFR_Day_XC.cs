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
    [Activity(Label = "Departure Info - 1 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class I_VFR_Day_XC : Activity
    {
        public static int wind;
        public static int xwind;
        public static int DepartureRisk = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblDepartureWind = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btn0to15 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn16to20 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn21to25 = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtDepartureWind = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblDepartureXwind = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btn0to5 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn6to10 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn11to15 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtDepartureXwind = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblDepartureWind.Text = "Wind";
            btn0to15.Text = "0 - 15 kts";
            btn16to20.Text = "16 - 20 kts";
            btn21to25.Text = "21 - 25 kts";
            txtDepartureWind.Text = "You have selected the '" + btn0to15.Text + "' choice.";

            lblDepartureXwind.Text = "Xwind";
            btn0to5.Text = "0 - 5 kts";
            btn6to10.Text = "6 - 10 kts";
            btn11to15.Text = "11 - 15 kts";
            txtDepartureXwind.Text = "You have selected the '" + btn0to5.Text + "' choice.";

            DepartureRisk = wind + xwind + I_VFR_Day_XC2.ceiling + I_VFR_Day_XC2.vis;
            if (DepartureRisk < 7)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Green);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                txtRisk.Text = "Departure Airfield Risk - OKAY";
                txtRiskNum.Text = "Risk = " + (DepartureRisk);
            }
            else if (DepartureRisk < 9  && DepartureRisk > 6)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                txtRisk.Text = "Departure Airfield Risk - CAUTION";
                txtRiskNum.Text = "Risk = " + DepartureRisk;
            }
            else
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Red);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                txtRisk.Text = "Departure Airfield Risk - NO GO!";
                txtRiskNum.Text = "Risk = " + (DepartureRisk);
            }

            //default values 
            if (wind == 0)
            {
                btn0to15.Pressed = true;
                btn16to20.Pressed = false;
                btn21to25.Pressed = false;
                txtDepartureWind.Text = "You have selected the '" + btn0to15.Text + " 'choice.";
            }
            else if (wind == 1)
            {
                btn0to15.Pressed = false;
                btn16to20.Pressed = true;
                btn21to25.Pressed = false;
                txtDepartureWind.Text = "You have selected the '" + btn16to20.Text + " 'choice.";
            }
            else
            {
                btn0to15.Pressed = false;
                btn16to20.Pressed = false;
                btn21to25.Pressed = true;
                txtDepartureWind.Text = "You have selected the '" + btn21to25.Text + " 'choice.";
            }

            if (xwind == 0)
            {
                btn0to5.Pressed = true;
                btn6to10.Pressed = false;
                btn11to15.Pressed = false;
                txtDepartureXwind.Text = "You have selected the '" + btn0to5.Text + " 'choice.";
            }
            else if (xwind == 1)
            {
                btn0to5.Pressed = false;
                btn6to10.Pressed = true;
                btn11to15.Pressed = false;
                txtDepartureXwind.Text = "You have selected the '" + btn6to10.Text + " 'choice.";
            }
            else
            {
                btn0to5.Pressed = false;
                btn6to10.Pressed = false;
                btn11to15.Pressed = true;
                txtDepartureXwind.Text = "You have selected the '" + btn11to15.Text + " 'choice.";
            }

            //Pressed Events
            btn0to15.Touch += (s, e) =>
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

                if (btn0to15.Pressed == false)
                    btn0to15.Pressed = !btn0to15.Pressed;

                btn16to20.Pressed = false;
                btn21to25.Pressed = false;

                e.Handled = true;

                txtDepartureWind.Text = "You have selected the '" + btn0to15.Text + "' option.";

                wind = 0;

                if (wind + xwind < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (wind + xwind);
                }
                else if (wind + xwind < 9 && wind + xwind > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + (wind + xwind);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + (wind + xwind);
                }
            };
            btn16to20.Touch += (s, e) =>
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

                if (btn16to20.Pressed == false)
                    btn16to20.Pressed = !btn16to20.Pressed;

                btn0to15.Pressed = false;
                btn21to25.Pressed = false;

                e.Handled = true;

                txtDepartureWind.Text = "You have selected the '" + btn16to20.Text + "' option.";

                wind = 1;

                DepartureRisk = wind + xwind + I_VFR_Day_XC2.ceiling + I_VFR_Day_XC2.vis;
                if (DepartureRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (DepartureRisk);
                }
                else if (DepartureRisk < 9 && DepartureRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + DepartureRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + (DepartureRisk);
                }

            };
            btn21to25.Touch += (s, e) =>
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

                if (btn21to25.Pressed == false)
                    btn21to25.Pressed = !btn21to25.Pressed;

                btn16to20.Pressed = false;
                btn0to15.Pressed = false;

                e.Handled = true;

                txtDepartureWind.Text = "You have selected the '" + btn21to25.Text + "' option.";

                wind = 3;

                DepartureRisk = wind + xwind + I_VFR_Day_XC2.ceiling + I_VFR_Day_XC2.vis;
                if (DepartureRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (DepartureRisk);
                }
                else if (DepartureRisk < 9 && DepartureRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + DepartureRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + (DepartureRisk);
                }

            };

            btn0to5.Touch += (s, e) =>
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

                if (btn0to5.Pressed == false)
                    btn0to5.Pressed = !btn0to5.Pressed;

                btn6to10.Pressed = false;
                btn11to15.Pressed = false;

                e.Handled = true;

                txtDepartureXwind.Text = "You have selected the '" + btn0to5.Text + "' option.";

                xwind = 0;

                DepartureRisk = wind + xwind + I_VFR_Day_XC2.ceiling + I_VFR_Day_XC2.vis;
                if (DepartureRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (DepartureRisk);
                }
                else if (DepartureRisk < 9 && DepartureRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + DepartureRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + (DepartureRisk);
                }

            };
            btn6to10.Touch += (s, e) =>
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

                if (btn6to10.Pressed == false)
                    btn6to10.Pressed = !btn6to10.Pressed;

                btn0to5.Pressed = false;
                btn11to15.Pressed = false;

                e.Handled = true;

                txtDepartureXwind.Text = "You have selected the '" + btn6to10.Text + "' option.";

                xwind = 1;

                DepartureRisk = wind + xwind + I_VFR_Day_XC2.ceiling + I_VFR_Day_XC2.vis;
                if (DepartureRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (DepartureRisk);
                }
                else if (DepartureRisk < 9 && DepartureRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + DepartureRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + (DepartureRisk);
                }

            };
            btn11to15.Touch += (s, e) =>
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

                if (btn11to15.Pressed == false)
                    btn11to15.Pressed = !btn11to15.Pressed;

                btn6to10.Pressed = false;
                btn0to5.Pressed = false;

                e.Handled = true;

                txtDepartureXwind.Text = "You have selected the '" + btn11to15.Text + "' option.";

                xwind = 3;

                DepartureRisk = wind + xwind + I_VFR_Day_XC2.ceiling + I_VFR_Day_XC2.vis;
                if (DepartureRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (DepartureRisk);
                }
                else if (DepartureRisk < 9 && DepartureRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + DepartureRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + (DepartureRisk);
                }

            };


            //Navigation
            btnNext.Click += delegate
            {
                StartActivity(typeof(I_VFR_Day_XC2));
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(G_Student_Human_Factors_2));
            };

        }
    }
}