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
    [Activity(Label = "Enroute or Practice Area - 2 of 2")]
    public class K_VFR_Day_XC4 : Activity
    {
        public static int checkpoints;
        public static int timeEnroute;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblCheckpoints = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btnMult = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btnMod = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btnFew = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtCheckpoints = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblTimeEnroute = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btnLessThan60 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn60to120 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btn120Plus = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtTime = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblCheckpoints.Text = "Checkpoints (XC)";
            btnMult.Text = "Multiple";
            btnMod.Text = "Moderate";
            btnFew.Text = "Few to none";
            txtCheckpoints.Text = "You have selected the '" + btnMult.Text + "' choice.";

            lblTimeEnroute.Text = "Time enroute";
            btnLessThan60.Text = "< 60 min";
            btn60to120.Text = "60 - 120 min";
            btn120Plus.Text = "> 120 min";
            txtTime.Text = "You have selected the '" + btnLessThan60.Text + "' choice.";

            J_VFR_Day_XC3.enrouteRisk = J_VFR_Day_XC3.ceiling + J_VFR_Day_XC3.vis + J_VFR_Day_XC3.manu + checkpoints + timeEnroute;
            if (J_VFR_Day_XC3.enrouteRisk < 7)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Green);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
            }
            else if (J_VFR_Day_XC3.enrouteRisk < 9 && J_VFR_Day_XC3.enrouteRisk  > 6)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
            }
            else
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Red);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
            }

            //default values 
            if (checkpoints == 0)
            {
                btnMult.Pressed = true;
                btnMod.Pressed = false;
                btnFew.Pressed = false;
                txtCheckpoints.Text = "You have selected the '" + btnMult.Text + "' choice.";
            }
            else if (checkpoints == 1)
            {
                btnMult.Pressed = false;
                btnMod.Pressed = true;
                btnFew.Pressed = false;
                txtCheckpoints.Text = "You have selected the '" + btnMod.Text + "' choice.";
            }
            else
            {
                btnMult.Pressed = false;
                btnMod.Pressed = false;
                btnFew.Pressed = true;
                txtCheckpoints.Text = "You have selected the '" + btnFew.Text + "' choice.";
            }

            if (timeEnroute == 0)
            {
                btnLessThan60.Pressed = true;
                btn60to120.Pressed = false;
                btn120Plus.Pressed = false;
                txtTime.Text = "You have selected the '" + btnLessThan60.Text + "' choice.";
            }
            else if (timeEnroute == 1)
            {
                btnLessThan60.Pressed = false;
                btn60to120.Pressed = true;
                btn120Plus.Pressed = false;
                txtTime.Text = "You have selected the '" + btn60to120.Text + "' choice.";
            }
            else
            {
                btnLessThan60.Pressed = false;
                btn60to120.Pressed = false;
                btn120Plus.Pressed = true;
                txtTime.Text = "You have selected the '" + btn120Plus.Text + "' choice.";
            }

            //Pressed Events
            btnMult.Touch += (s, e) =>
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

                if (btnMult.Pressed == false)
                    btnMult.Pressed = !btnMult.Pressed;

                btnMod.Pressed = false;
                btnFew.Pressed = false;

                e.Handled = true;

                txtCheckpoints.Text = "You have selected the '" + btnMult.Text + "' option.";

                checkpoints = 0;

                J_VFR_Day_XC3.enrouteRisk = J_VFR_Day_XC3.ceiling + J_VFR_Day_XC3.vis + J_VFR_Day_XC3.manu + checkpoints + timeEnroute;
                if (J_VFR_Day_XC3.enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else if (J_VFR_Day_XC3.enrouteRisk < 9 && J_VFR_Day_XC3.enrouteRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }

            };
            btnMod.Touch += (s, e) =>
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

                if (btnMod.Pressed == false)
                    btnMod.Pressed = !btnMod.Pressed;

                btnMult.Pressed = false;
                btnFew.Pressed = false;

                e.Handled = true;

                txtCheckpoints.Text = "You have selected the '" + btnMod.Text + "' option.";

                checkpoints = 1;

                J_VFR_Day_XC3.enrouteRisk = J_VFR_Day_XC3.ceiling + J_VFR_Day_XC3.vis + J_VFR_Day_XC3.manu + checkpoints + timeEnroute;
                if (J_VFR_Day_XC3.enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else if (J_VFR_Day_XC3.enrouteRisk < 9 && J_VFR_Day_XC3.enrouteRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }

            };
            btnFew.Touch += (s, e) =>
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

                if (btnFew.Pressed == false)
                    btnFew.Pressed = !btnFew.Pressed;

                btnMod.Pressed = false;
                btnMult.Pressed = false;

                e.Handled = true;

                txtCheckpoints.Text = "You have selected the '" + btnFew.Text + "' option.";

                checkpoints = 3;

                J_VFR_Day_XC3.enrouteRisk = J_VFR_Day_XC3.ceiling + J_VFR_Day_XC3.vis + J_VFR_Day_XC3.manu + checkpoints + timeEnroute;
                if (J_VFR_Day_XC3.enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else if (J_VFR_Day_XC3.enrouteRisk < 9 && J_VFR_Day_XC3.enrouteRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
            };

            btnLessThan60.Touch += (s, e) =>
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

                if (btnLessThan60.Pressed == false)
                    btnLessThan60.Pressed = !btnLessThan60.Pressed;

                btn60to120.Pressed = false;
                btn120Plus.Pressed = false;

                e.Handled = true;

                txtTime.Text = "You have selected the '" + btnLessThan60.Text + "' option.";

                timeEnroute = 0;

                J_VFR_Day_XC3.enrouteRisk = J_VFR_Day_XC3.ceiling + J_VFR_Day_XC3.vis + J_VFR_Day_XC3.manu + checkpoints + timeEnroute;
                if (J_VFR_Day_XC3.enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else if (J_VFR_Day_XC3.enrouteRisk < 9 && J_VFR_Day_XC3.enrouteRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
            };
            btn60to120.Touch += (s, e) =>
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

                if (btn60to120.Pressed == false)
                    btn60to120.Pressed = !btn60to120.Pressed;

                btnLessThan60.Pressed = false;
                btn120Plus.Pressed = false;

                e.Handled = true;

                txtTime.Text = "You have selected the '" + btn60to120.Text + "' option.";

                timeEnroute = 1;

                J_VFR_Day_XC3.enrouteRisk = J_VFR_Day_XC3.ceiling + J_VFR_Day_XC3.vis + J_VFR_Day_XC3.manu + checkpoints + timeEnroute;
                if (J_VFR_Day_XC3.enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else if (J_VFR_Day_XC3.enrouteRisk < 9 && J_VFR_Day_XC3.enrouteRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
            };
            btn120Plus.Touch += (s, e) =>
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

                if (btn120Plus.Pressed == false)
                    btn120Plus.Pressed = !btn120Plus.Pressed;

                btn60to120.Pressed = false;
                btnLessThan60.Pressed = false;

                e.Handled = true;

                txtTime.Text = "You have selected the '" + btn120Plus.Text + "' option.";

                timeEnroute = 3;

                J_VFR_Day_XC3.enrouteRisk = J_VFR_Day_XC3.ceiling + J_VFR_Day_XC3.vis + J_VFR_Day_XC3.manu + checkpoints + timeEnroute;
                if (J_VFR_Day_XC3.enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else if (J_VFR_Day_XC3.enrouteRisk < 9 && J_VFR_Day_XC3.enrouteRisk > 6)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + J_VFR_Day_XC3.enrouteRisk;
                }
            };


            //Navigation
            btnNext.Click += delegate
            {
                if (J_VFR_Day_XC3.enrouteRisk < 9)
                {

                }
                else
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Alert");
                    alert.SetMessage("Your Enroute Risk is too high!");
                    alert.SetNeutralButton("OK", delegate
                    {
                        alert.Dispose();
                    });
                    alert.Show();
                }

            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(J_VFR_Day_XC3));
            };
        }
    }
}