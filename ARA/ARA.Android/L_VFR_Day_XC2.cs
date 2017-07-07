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
    [Activity(Label = "Departure Info - 2 of 2")]
    public class L_VFR_Day_XC2 : Activity
    {
        public static int ceiling;
        public static int vis;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblCeiling = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btn4000 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn3500to3999 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn3000to3499 = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtCeiling = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblVis = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btn7 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var bnt6 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn5 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtVis = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblCeiling.Text = "Ceiling";
            btn4000.Text = "4000+ ft";
            btn3500to3999.Text = "3500 - 3999 ft";
            btn3000to3499.Text = "3000 - 3499 ft";
            txtCeiling.Text = "You have selected the '" + btn4000.Text + "' choice.";

            lblVis.Text = "Visibility";
            btn7.Text = "7+ SM";
            bnt6.Text = "6 SM";
            btn5.Text = "5 SM";
            txtVis.Text = "You have selected the '" + btn7.Text + "' choice.";

            K_VFR_Day_XC.DepartureRisk = K_VFR_Day_XC.wind + K_VFR_Day_XC.xwind + ceiling + vis;
            if (K_VFR_Day_XC.DepartureRisk < 7)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Green);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                txtRisk.Text = "Departure Airfield Risk - OKAY";
                txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
            }
            else if (K_VFR_Day_XC.DepartureRisk < 9 && K_VFR_Day_XC.DepartureRisk > 6)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                txtRisk.Text = "Departure Airfield Risk - CAUTION";
                txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
            }
            else
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Red);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                txtRisk.Text = "Departure Airfield Risk - NO GO!";
                txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
            }

            //default values 
            if (ceiling == 0)
            {
                btn4000.Pressed = true;
                btn3500to3999.Pressed = false;
                btn3000to3499.Pressed = false;
                txtCeiling.Text = "You have selected the '" + btn4000.Text + "' choice.";
            }
            else if (ceiling == 1)
            {
                btn4000.Pressed = false;
                btn3500to3999.Pressed = true;
                btn3000to3499.Pressed = false;
                txtCeiling.Text = "You have selected the '" + btn3500to3999.Text + "' choice.";
            }
            else
            {
                btn4000.Pressed = false;
                btn3500to3999.Pressed = false;
                btn3000to3499.Pressed = true;
                txtCeiling.Text = "You have selected the '" + btn3000to3499.Text + "' choice.";
            }

            if (vis == 0)
            {
                btn7.Pressed = true;
                bnt6.Pressed = false;
                btn5.Pressed = false;
                txtVis.Text = "You have selected the '" + btn7.Text + "' choice.";
            }
            else if (vis == 1)
            {
                btn7.Pressed = false;
                bnt6.Pressed = true;
                btn5.Pressed = false;
                txtVis.Text = "You have selected the '" + bnt6.Text + "' choice.";
            }
            else
            {
                btn7.Pressed = false;
                bnt6.Pressed = false;
                btn5.Pressed = true;
                txtVis.Text = "You have selected the '" + btn5.Text + "' choice.";
            }

            //Pressed Events
            btn4000.Touch += (s, e) =>
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

                if (btn4000.Pressed == false)
                    btn4000.Pressed = !btn4000.Pressed;

                btn3500to3999.Pressed = false;
                btn3000to3499.Pressed = false;

                e.Handled = true;

                txtCeiling.Text = "You have selected the '" + btn4000.Text + "' option.";

                ceiling = 0;

                K_VFR_Day_XC.DepartureRisk = K_VFR_Day_XC.wind + K_VFR_Day_XC.xwind + ceiling + vis;
                if (K_VFR_Day_XC.DepartureRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else if (K_VFR_Day_XC.DepartureRisk < 9 && K_VFR_Day_XC.DepartureRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }

            };
            btn3500to3999.Touch += (s, e) =>
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

                if (btn3500to3999.Pressed == false)
                    btn3500to3999.Pressed = !btn3500to3999.Pressed;

                btn4000.Pressed = false;
                btn3000to3499.Pressed = false;

                e.Handled = true;

                txtCeiling.Text = "You have selected the '" + btn3500to3999.Text + "' option.";

                ceiling = 1;

                K_VFR_Day_XC.DepartureRisk = K_VFR_Day_XC.wind + K_VFR_Day_XC.xwind + ceiling + vis;
                if (K_VFR_Day_XC.DepartureRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else if (K_VFR_Day_XC.DepartureRisk < 9 && K_VFR_Day_XC.DepartureRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }

            };
            btn3000to3499.Touch += (s, e) =>
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

                if (btn3000to3499.Pressed == false)
                    btn3000to3499.Pressed = !btn3000to3499.Pressed;

                btn3500to3999.Pressed = false;
                btn4000.Pressed = false;

                e.Handled = true;

                txtCeiling.Text = "You have selected the '" + btn3000to3499.Text + "' option.";

                ceiling = 3;

                K_VFR_Day_XC.DepartureRisk = K_VFR_Day_XC.wind + K_VFR_Day_XC.xwind + ceiling + vis;
                if (K_VFR_Day_XC.DepartureRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else if (K_VFR_Day_XC.DepartureRisk < 9 && K_VFR_Day_XC.DepartureRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }

            };

            btn7.Touch += (s, e) =>
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

                if (btn7.Pressed == false)
                    btn7.Pressed = !btn7.Pressed;

                bnt6.Pressed = false;
                btn5.Pressed = false;

                e.Handled = true;

                txtVis.Text = "You have selected the '" + btn7.Text + "' option.";

                vis = 0;

                K_VFR_Day_XC.DepartureRisk = K_VFR_Day_XC.wind + K_VFR_Day_XC.xwind + ceiling + vis;
                if (K_VFR_Day_XC.DepartureRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else if (K_VFR_Day_XC.DepartureRisk < 9 && K_VFR_Day_XC.DepartureRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }

            };
            bnt6.Touch += (s, e) =>
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

                if (bnt6.Pressed == false)
                    bnt6.Pressed = !bnt6.Pressed;

                btn7.Pressed = false;
                btn5.Pressed = false;

                e.Handled = true;

                txtVis.Text = "You have selected the '" + bnt6.Text + "' option.";

                vis = 1;

                K_VFR_Day_XC.DepartureRisk = K_VFR_Day_XC.wind + K_VFR_Day_XC.xwind + ceiling + vis;
                if (K_VFR_Day_XC.DepartureRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else if (K_VFR_Day_XC.DepartureRisk < 9 && K_VFR_Day_XC.DepartureRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }

            };
            btn5.Touch += (s, e) =>
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

                if (btn5.Pressed == false)
                    btn5.Pressed = !btn5.Pressed;

                bnt6.Pressed = false;
                btn7.Pressed = false;

                e.Handled = true;

                txtVis.Text = "You have selected the '" + btn5.Text + "' option.";

                vis = 3;

                K_VFR_Day_XC.DepartureRisk = K_VFR_Day_XC.wind + K_VFR_Day_XC.xwind + ceiling + vis;
                if (K_VFR_Day_XC.DepartureRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Departure Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else if (K_VFR_Day_XC.DepartureRisk < 9 && K_VFR_Day_XC.DepartureRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Departure Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Departure Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + K_VFR_Day_XC.DepartureRisk;
                }

            };


            //Navigation
            btnNext.Click += delegate
            {
                if (K_VFR_Day_XC.DepartureRisk < 9)
                {
                    StartActivity(typeof(M_VFR_Day_XC3));
                }
                else
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Alert");
                    alert.SetMessage("Your Departure Risk is too high!");
                    alert.SetNeutralButton("OK", delegate
                    {
                        alert.Dispose();
                    });
                    alert.Show();
                }

            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(K_VFR_Day_XC));
            };
        }
    }
}