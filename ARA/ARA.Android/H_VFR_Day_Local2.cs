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
    [Activity(Label = "Home Airfield - 2 of 2")]

    public class H_VFR_Day_Local2 : Activity
    {
        public static int OtherXWind;
        public static int Ceiling;
        public static int vis;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.h_Layout_3);

            var lblXWindOther = FindViewById<TextView>(Resource.Id.txtQuestion1);
            var btnXWindOther0 = FindViewById<Button>(Resource.Id.btnQ1C1);
            var btnXWindOther1 = FindViewById<Button>(Resource.Id.btnQ1C2);
            var btnXWindOther3 = FindViewById<Button>(Resource.Id.btnQ1C3);
            var txtXWindOther = FindViewById<TextView>(Resource.Id.txtAnswer1);

            var lblCeiling = FindViewById<TextView>(Resource.Id.txtQuestion2);
            var btnCeiling0 = FindViewById<Button>(Resource.Id.btnQ2C1);
            var btnCeiling1 = FindViewById<Button>(Resource.Id.btnQ2C2);
            var btnCeiling3 = FindViewById<Button>(Resource.Id.btnQ2C3);
            var txtCeiling = FindViewById<TextView>(Resource.Id.txtAnswer2);

            var lblVis = FindViewById<TextView>(Resource.Id.txtQuestion3);
            var btnVis0 = FindViewById<Button>(Resource.Id.btnQ3C1);
            var btnVis1 = FindViewById<Button>(Resource.Id.btnQ3C2);
            var btnVis3 = FindViewById<Button>(Resource.Id.btnQ3C3);
            var txtVis = FindViewById<TextView>(Resource.Id.txtAnswer3);

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskText);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNum);

            lblXWindOther.Text = "Xwind (Other)";
            btnXWindOther0.Text = "0 - 5 kts.";
            btnXWindOther1.Text = "6 - 10 kts.";
            btnXWindOther3.Text = "11 - 15 kts.";

            lblCeiling.Text = "Ceiling";
            btnCeiling0.Text = "3000 + ft.";
            btnCeiling1.Text = "2500 - 2999 ft.";
            btnCeiling3.Text = "2000 - 2499 ft.";

            lblVis.Text = "Visibility";
            btnVis0.Text = "5 + SM";
            btnVis1.Text = "4 SM";
            btnVis3.Text = "3 SM";

            if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 7)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Green);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                txtRisk.Text = "OKAY - Home Airfield Risk";
                txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
            }
            else if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling >= 7 && H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 9)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                txtRisk.Text = "CAUTION - Home Airfield Risk";
                txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
            }
            else
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Red);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                txtRisk.Text = "NO GO! - Home Airfield Risk";
                txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
            }

            //default values
            if (OtherXWind == 0)
            {
                btnXWindOther0.Pressed = true;
                btnXWindOther1.Pressed = false;
                btnXWindOther3.Pressed = false;
                txtXWindOther.Text = "You have selected the '" + btnXWindOther0.Text +"' option.";
            }
            else if (OtherXWind == 1)
            {
                btnXWindOther0.Pressed = false;
                btnXWindOther1.Pressed = true;
                btnXWindOther3.Pressed = false;
                txtXWindOther.Text = "You have selected the '" + btnXWindOther1.Text + "'option";
            }
            else
            {
                btnXWindOther0.Pressed = false;
                btnXWindOther1.Pressed = false;
                btnXWindOther3.Pressed = true;
                txtXWindOther.Text = "You have selected the '" + btnXWindOther3.Text + "'option";
            }

            if (Ceiling == 0)
            {
                btnCeiling0.Pressed = true;
                btnCeiling1.Pressed = false;
                btnCeiling3.Pressed = false;
                txtCeiling.Text = "You have selected the '" + btnCeiling0.Text + "' option.";
            }
            else if (Ceiling == 1)
            {
                btnCeiling0.Pressed = false;
                btnCeiling1.Pressed = true;
                btnCeiling3.Pressed = false;
                txtCeiling.Text = "You have selected the '" + btnCeiling1.Text + "' option.";
            }
            else
            {
                btnCeiling0.Pressed = false;
                btnCeiling1.Pressed = false;
                btnCeiling3.Pressed = true;
                txtCeiling.Text = "You have selected the '" + btnCeiling3.Text + "' option.";
            }

            if (vis == 0)
            {
                btnVis0.Pressed = true;
                btnVis1.Pressed = false;
                btnVis3.Pressed = false;
                txtVis.Text = "You have selected the '" + btnVis0.Text + "' option.";
            }
            else if (vis == 1)
            {
                btnVis0.Pressed = false;
                btnVis1.Pressed = true;
                btnVis3.Pressed = false;
                txtVis.Text = "You have selected the '" + btnVis1.Text + "' option.";
            }
            else
            {
                btnVis0.Pressed = false;
                btnVis1.Pressed = false;
                btnVis3.Pressed = true;
                txtVis.Text = "You have selected the '" + btnVis3.Text + "' option.";
            }


            //Pressed events
            btnXWindOther0.Touch += (s, e) =>
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

                if (btnXWindOther0.Pressed == false)
                    btnXWindOther0.Pressed = !btnXWindOther0.Pressed;

                btnXWindOther1.Pressed = false;
                btnXWindOther3.Pressed = false;

                e.Handled = true;

                txtXWindOther.Text = "You have selected the '" + btnXWindOther0.Text + "' option.";

                OtherXWind = 0;

                if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling >= 7 && H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 9)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
            };
            btnXWindOther1.Touch += (s, e) =>
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

                if (btnXWindOther1.Pressed == false)
                    btnXWindOther1.Pressed = !btnXWindOther1.Pressed;

                btnXWindOther0.Pressed = false;
                btnXWindOther3.Pressed = false;

                e.Handled = true;
                txtXWindOther.Text = "You have selected the '" + btnXWindOther1.Text + "'option";

                OtherXWind = 1;

                if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling >= 7 && H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 9)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
            };
            btnXWindOther3.Touch += (s, e) =>
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

                if (btnXWindOther3.Pressed == false)
                    btnXWindOther3.Pressed = !btnXWindOther3.Pressed;

                btnXWindOther1.Pressed = false;
                btnXWindOther0.Pressed = false;

                e.Handled = true;
                txtXWindOther.Text = "You have selected the '" + btnXWindOther3.Text + "'option";

                OtherXWind = 3;
                if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling >= 7 && H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 9)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
            };

            btnCeiling0.Touch += (s, e) =>
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

                if (btnCeiling0.Pressed == false)
                    btnCeiling0.Pressed = !btnCeiling0.Pressed;

                btnCeiling1.Pressed = false;
                btnCeiling3.Pressed = false;

                e.Handled = true;
                txtCeiling.Text = "You have selected the '" + btnCeiling0.Text + "' option.";

                Ceiling = 0;

                if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling >= 7 && H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 9)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }

            };
            btnCeiling1.Touch += (s, e) =>
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

                if (btnCeiling1.Pressed == false)
                    btnCeiling1.Pressed = !btnCeiling1.Pressed;

                btnCeiling0.Pressed = false;
                btnCeiling3.Pressed = false;

                e.Handled = true;
                txtCeiling.Text = "You have selected the '" + btnCeiling1.Text + "' option.";

                Ceiling = 1;

                if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling >= 7 && H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 9)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
            };
            btnCeiling3.Touch += (s, e) =>
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

                if (btnCeiling3.Pressed == false)
                    btnCeiling3.Pressed = !btnCeiling3.Pressed;

                btnCeiling1.Pressed = false;
                btnCeiling0.Pressed = false;

                e.Handled = true;
                txtCeiling.Text = "You have selected the '" + btnCeiling3.Text + "' option.";

                Ceiling = 3;

                if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling >= 7 && H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 9)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
            };

            btnVis0.Touch += (s, e) =>
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

                if (btnVis0.Pressed == false)
                    btnVis0.Pressed = !btnVis0.Pressed;

                btnVis1.Pressed = false;
                btnVis3.Pressed = false;

                e.Handled = true;
                txtVis.Text = "You have selected the '" + btnVis0.Text + "' option.";

                vis = 0;

                if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling >= 7 && H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 9)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
            };
            btnVis1.Touch += (s, e) =>
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

                if (btnVis1.Pressed == false)
                    btnVis1.Pressed = !btnVis1.Pressed;

                btnVis0.Pressed = false;
                btnVis3.Pressed = false;

                e.Handled = true;
                txtVis.Text = "You have selected the '" + btnVis1.Text + "' option.";

                vis = 1;

                if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling >= 7 && H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 9)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
            };
            btnVis3.Touch += (s, e) =>
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

                if (btnVis3.Pressed == false)
                    btnVis3.Pressed = !btnVis3.Pressed;

                btnVis1.Pressed = false;
                btnVis0.Pressed = false;

                e.Handled = true;
                txtVis.Text = "You have selected the '" + btnVis3.Text + "' option.";

                vis = 3;

                if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling >= 7 && H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 9)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling);
                }
            };

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom3);

            btnNext.Click += delegate
            {
                if (H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.soloXWind + OtherXWind + vis + Ceiling < 9)
                {
                    StartActivity(typeof(I_VFR_Day_Local_PIC));
                }
                else
                {
                    AlertDialog.Builder alertRiskHigh = new AlertDialog.Builder(this);
                    alertRiskHigh.SetTitle("Alert");
                    alertRiskHigh.SetMessage("Your Student Human Factor Risk is too high!");
                    alertRiskHigh.SetNeutralButton("OK", delegate
                    {
                        alertRiskHigh.Dispose();
                    });
                    alertRiskHigh.Show();
                }
                    
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(H_VFR_Day_Local1));
            };
        }
    }
}