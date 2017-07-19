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
    [Activity(Label = "Home Airfield - 1 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class H_VFR_Day_Local1 : Activity
    {
        public static int soloWind;
        public static int otherWind;
        public static int soloXWind;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.h_Layout_3);

            var lblWindSolo = FindViewById<TextView>(Resource.Id.txtQuestion1);
            var btnSolo0 = FindViewById<Button>(Resource.Id.btnQ1C1);
            var btnSolo1 = FindViewById<Button>(Resource.Id.btnQ1C2);
            var btnSolo3 = FindViewById<Button>(Resource.Id.btnQ1C3);
            var txtWindSolo = FindViewById<TextView>(Resource.Id.txtAnswer1);

            var lblWindOther = FindViewById<TextView>(Resource.Id.txtQuestion2);
            var btnWind0 = FindViewById<Button>(Resource.Id.btnQ2C1);
            var btnWind1 = FindViewById<Button>(Resource.Id.btnQ2C2);
            var btnWind3 = FindViewById<Button>(Resource.Id.btnQ2C3);
            var txtWindOther = FindViewById<TextView>(Resource.Id.txtAnswer2);

            var lblXWindSolo = FindViewById<TextView>(Resource.Id.txtQuestion3);
            var btnXSolo0= FindViewById<Button>(Resource.Id.btnQ3C1);
            var btnXSolo1 = FindViewById<Button>(Resource.Id.btnQ3C2);
            var btnXSolo3 = FindViewById<Button>(Resource.Id.btnQ3C3);
            var txtXWindSolo = FindViewById<TextView>(Resource.Id.txtAnswer3);

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskText);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNum);

            lblWindSolo.Text = "Wind (Initial Solo Only)";
            btnSolo0.Text = "0 - 5 kts";
            btnSolo1.Text = "6 - 10 kts";
            btnSolo3.Text = "11 - 15 kts";

            lblWindOther.Text = "Wind (Other)";
            btnWind0.Text = "0 - 15 kts";
            btnWind1.Text = "16 - 20 kts";
            btnWind3.Text = "21 - 25 kts";

            lblXWindSolo.Text = "Xwind (Initial Solo Only)";
            btnXSolo0.Text = "0 - 3 kts";
            btnXSolo1.Text = "4 - 7 kts";
            btnXSolo3.Text = "8 - 10 kts";

            //default values
            if (soloWind == 0)
            {
                btnSolo0.Pressed = true;
                btnSolo1.Pressed = false;
                btnSolo3.Pressed = false;
                txtWindSolo.Text = "You have selected the '0 - 5 kts' option.";
            }
            else if (soloWind == 1)
            {
                btnSolo0.Pressed = false;
                btnSolo1.Pressed = true;
                btnSolo3.Pressed = false;
                txtWindSolo.Text = "You have selected the '6 - 10 kts' option";
            }
            else
            {
                btnSolo0.Pressed = false;
                btnSolo1.Pressed = false;
                btnSolo3.Pressed = true;
                txtWindSolo.Text = "You have selected the '11 - 15 kts' option";
            }

            if (otherWind == 0)
            {
                btnWind0.Pressed = true;
                btnWind1.Pressed = false;
                btnWind3.Pressed = false;
                txtWindOther.Text = "You have selected the '0 - 15 kts' option.";
            }
            else if (otherWind == 1)
            {
                btnWind0.Pressed = false;
                btnWind1.Pressed = true;
                btnWind3.Pressed = false;
                txtWindOther.Text = "You have selected the '16 - 20 kts' option";
            }
            else
            {
                btnWind0.Pressed = false;
                btnWind1.Pressed = false;
                btnWind3.Pressed = true;
                txtWindOther.Text = "You have selected the '21 - 25 kts' option";
            }

            if (soloXWind == 0)
            {
                btnXSolo0.Pressed = true;
                btnXSolo1.Pressed = false;
                btnXSolo3.Pressed = false;
                txtXWindSolo.Text = "You have selected the '0 - 3 kts' option.";
            }
            else if (soloXWind == 1)
            {
                btnXSolo0.Pressed = false;
                btnXSolo1.Pressed = true;
                btnXSolo3.Pressed = false;
                txtXWindSolo.Text = "You have selected the '4 - 7 kts' option";
            }
            else
            {
                btnXSolo0.Pressed = false;
                btnXSolo1.Pressed = false;
                btnXSolo3.Pressed = true;
                txtXWindSolo.Text = "You have selected the '8 - 10 kts' option";
            }

            if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 7)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Green);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                txtRisk.Text = "Home Airfield Risk - OKAY";
                txtRiskNum.Text = "Risk = " + (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
            }
            else if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 9 && otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling >= 7)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                txtRisk.Text = "Home Airfield Risk - CAUTION";
                txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
            }
            else
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Red);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                txtRisk.Text = "Home Airfield Risk - NO GO!";
                txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
            }

            //Pressed events
            btnSolo0.Touch += (s, e) =>
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

                if (btnSolo0.Pressed == false)
                    btnSolo0.Pressed = !btnSolo0.Pressed;

                btnSolo1.Pressed = false;
                btnSolo3.Pressed = false;

                e.Handled = true;
                txtWindSolo.Text = "You have selected the '0 - 5 kts' option.";
                soloWind = 0;

                if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Home Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 9 && otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Home Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Home Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }

            };
            btnSolo1.Touch += (s, e) =>
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

                if (btnSolo1.Pressed == false)
                    btnSolo1.Pressed = !btnSolo1.Pressed;

                btnSolo0.Pressed = false;
                btnSolo3.Pressed = false;

                e.Handled = true;
                txtWindSolo.Text = "You have selected the '6 - 10 kts' option";
                soloWind = 1;

                if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Home Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 9 && otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Home Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Home Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
            };
            btnSolo3.Touch += (s, e) =>
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

                if (btnSolo3.Pressed == false)
                    btnSolo3.Pressed = !btnSolo3.Pressed;

                btnSolo1.Pressed = false;
                btnSolo0.Pressed = false;

                e.Handled = true;
                txtWindSolo.Text = "You have selected the '11 - 15 kts' option";

                soloWind = 3;

                if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Home Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 9 && otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Home Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Home Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }

            };

            btnWind0.Touch += (s, e) =>
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

                if (btnWind0.Pressed == false)
                    btnWind0.Pressed = !btnWind0.Pressed;

                btnWind1.Pressed = false;
                btnWind3.Pressed = false;

                e.Handled = true;
                txtWindOther.Text = "You have selected the '0 - 15 kts' option.";

                otherWind = 0;

                if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Home Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 9 && otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Home Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Home Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
            };
            btnWind1.Touch += (s, e) =>
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

                if (btnWind1.Pressed == false)
                    btnWind1.Pressed = !btnWind1.Pressed;

                btnWind0.Pressed = false;
                btnWind3.Pressed = false;

                e.Handled = true;
                txtWindOther.Text = "You have selected the '16 - 20 kts' option";

                otherWind = 1;

                if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Home Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 9 && otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Home Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Home Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
            };
            btnWind3.Touch += (s, e) =>
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

                if (btnWind3.Pressed == false)
                    btnWind3.Pressed = !btnWind3.Pressed;

                btnWind1.Pressed = false;
                btnWind0.Pressed = false;

                e.Handled = true;
                txtWindOther.Text = "You have selected the '21 - 25 kts' option";

                otherWind = 3;

                if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Home Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 9 && otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Home Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Home Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
            };

            btnXSolo0.Touch += (s, e) =>
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

                if (btnXSolo0.Pressed == false)
                    btnXSolo0.Pressed = !btnXSolo0.Pressed;

                btnXSolo1.Pressed = false;
                btnXSolo3.Pressed = false;

                e.Handled = true;
                txtXWindSolo.Text = "You have selected the '0 - 3 kts' option.";

                soloXWind = 0;

                if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Home Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 9 && otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Home Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Home Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
            };
            btnXSolo1.Touch += (s, e) =>
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

                if (btnXSolo1.Pressed == false)
                    btnXSolo1.Pressed = !btnXSolo1.Pressed;

                btnXSolo0.Pressed = false;
                btnXSolo3.Pressed = false;

                e.Handled = true;
                txtXWindSolo.Text = "You have selected the '4 - 7 kts.' option";

                soloXWind = 1;

                if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Home Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 9 && otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Home Airfield Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Home Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
            };
            btnXSolo3.Touch += (s, e) =>
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

                if (btnXSolo3.Pressed == false)
                    btnXSolo3.Pressed = !btnXSolo3.Pressed;

                btnXSolo1.Pressed = false;
                btnXSolo0.Pressed = false;

                e.Handled = true;
                txtXWindSolo.Text = "You have selected the '8 - 10 kts' option";

                soloXWind = 3;

                if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Home Airfield Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else if (otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling < 9 && otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Home Airfield Risk";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Home Airfield Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + +(otherWind + soloWind + soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.vis + H_VFR_Day_Local2.Ceiling);
                }
            };

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom3);

            btnNext.Click += delegate
            {
                StartActivity(typeof(H_VFR_Day_Local2));
            };

            btnBack.Click += delegate
           {
               StartActivity(typeof(G_Student_Human_Factors_2));
           };
        }
    }
}