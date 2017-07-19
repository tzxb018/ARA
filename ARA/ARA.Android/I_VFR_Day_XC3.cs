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
    [Activity(Label = "Enroute or Practice Area - 1 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class I_VFR_Day_XC3 : Activity
    {
        public static int ceiling;
        public static int vis;
        public static int manu;

        public static int enrouteRisk = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.h_Layout_3);

            var lblCeiling = FindViewById<TextView>(Resource.Id.txtQuestion1);
            var btn4000 = FindViewById<Button>(Resource.Id.btnQ1C1);
            var btn3500to3999 = FindViewById<Button>(Resource.Id.btnQ1C2);
            var btn3000to3499 = FindViewById<Button>(Resource.Id.btnQ1C3);
            var txtCeiling = FindViewById<TextView>(Resource.Id.txtAnswer1);

            var lblVis = FindViewById<TextView>(Resource.Id.txtQuestion2);
            var btn7 = FindViewById<Button>(Resource.Id.btnQ2C1);
            var btn6 = FindViewById<Button>(Resource.Id.btnQ2C2);
            var btn5 = FindViewById<Button>(Resource.Id.btnQ2C3);
            var txtVis = FindViewById<TextView>(Resource.Id.txtAnswer2);

            var lblAreaManuevers = FindViewById<TextView>(Resource.Id.txtQuestion3);
            var btnNone = FindViewById<Button>(Resource.Id.btnQ3C1);
            var btn12 = FindViewById<Button>(Resource.Id.btnQ3C2);
            var btn3 = FindViewById<Button>(Resource.Id.btnQ3C3);
            var txtXWindSolo = FindViewById<TextView>(Resource.Id.txtAnswer3);

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskText);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNum);

            lblCeiling.Text = "Ceiling";
            btn4000.Text = "4000+ ft";
            btn3500to3999.Text = "3500 - 3999 ft";
            btn3000to3499.Text = "3000 - 3499 ft";

            lblVis.Text = "Visibility";
            btn7.Text = "7+ SM";
            btn6.Text = "6 SM";
            btn5.Text = "5 SM";

            lblAreaManuevers.Text = "Area Manuevers";
            btnNone.Text = "None";
            btn12.Text = "1 - 2";
            btn3.Text = "3 or more";

            //default values
            if (ceiling == 0)
            {
                btn4000.Pressed = true;
                btn3500to3999.Pressed = false;
                btn3000to3499.Pressed = false;
                txtCeiling.Text = "You have selected the '4000 ft' option.";
            }
            else if (ceiling == 1)
            {
                btn4000.Pressed = false;
                btn3500to3999.Pressed = true;
                btn3000to3499.Pressed = false;
                txtCeiling.Text = "You have selected the '3500 - 3999 ft' option";
            }
            else
            {
                btn4000.Pressed = false;
                btn3500to3999.Pressed = false;
                btn3000to3499.Pressed = true;
                txtCeiling.Text = "You have selected the '3000 - 3499 ft' option";
            }

            if (vis == 0)
            {
                btn7.Pressed = true;
                btn6.Pressed = false;
                btn5.Pressed = false;
                txtVis.Text = "You have selected the '7 + SM' option.";
            }
            else if (vis == 1)
            {
                btn7.Pressed = false;
                btn6.Pressed = true;
                btn5.Pressed = false;
                txtVis.Text = "You have selected the '6 SM' option";
            }
            else
            {
                btn7.Pressed = false;
                btn6.Pressed = false;
                btn5.Pressed = true;
                txtVis.Text = "You have selected the '5 SM' option";
            }

            if (manu == 0)
            {
                btnNone.Pressed = true;
                btn12.Pressed = false;
                btn3.Pressed = false;
                txtXWindSolo.Text = "You have selected the 'None' option.";
            }
            else if (manu == 1)
            {
                btnNone.Pressed = false;
                btn12.Pressed = true;
                btn3.Pressed = false;
                txtXWindSolo.Text = "You have selected the '1 - 2' option";
            }
            else
            {
                btnNone.Pressed = false;
                btn12.Pressed = false;
                btn3.Pressed = true;
                txtXWindSolo.Text = "You have selected the '3 or more' option";
            }

            enrouteRisk = vis + ceiling + manu + I_VFR_Day_XC4.checkpoints + I_VFR_Day_XC4.timeEnroute;

            if (enrouteRisk< 7)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Green);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                txtRiskNum.Text = "Risk = " + (enrouteRisk);
            }
            else if (enrouteRisk < 9 && enrouteRisk >= 7)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                txtRiskNum.Text = "Risk = "  +(enrouteRisk);
            }
            else
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Red);
                txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                txtRiskNum.Text = "Risk = " + enrouteRisk;
            }

            //Pressed events
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
                txtCeiling.Text = "You have selected the '4000 ft' option.";
                ceiling = 0;

                enrouteRisk = vis + ceiling + manu + I_VFR_Day_XC4.checkpoints + I_VFR_Day_XC4.timeEnroute;

                if (enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else if (enrouteRisk < 9 && enrouteRisk >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + enrouteRisk;
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
                txtCeiling.Text = "You have selected the 3500 - 3999 ft' option";
                ceiling = 1;

                enrouteRisk = vis + ceiling + manu + I_VFR_Day_XC4.checkpoints + I_VFR_Day_XC4.timeEnroute;

                if (enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else if (enrouteRisk < 9 && enrouteRisk >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + enrouteRisk;
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
                txtCeiling.Text = "You have selected the '3000 - 3499 ft' option";

                ceiling = 3;

                enrouteRisk = vis + ceiling + manu + I_VFR_Day_XC4.checkpoints + I_VFR_Day_XC4.timeEnroute;

                if (enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else if (enrouteRisk < 9 && enrouteRisk >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + enrouteRisk;
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

                btn6.Pressed = false;
                btn5.Pressed = false;

                e.Handled = true;
                txtVis.Text = "You have selected the '7 + SM' option.";

                vis = 0;

                enrouteRisk = vis + ceiling + manu + I_VFR_Day_XC4.checkpoints + I_VFR_Day_XC4.timeEnroute;

                if (enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else if (enrouteRisk < 9 && enrouteRisk >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + enrouteRisk;
                }
            };
            btn6.Touch += (s, e) =>
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

                if (btn6.Pressed == false)
                    btn6.Pressed = !btn6.Pressed;

                btn7.Pressed = false;
                btn5.Pressed = false;

                e.Handled = true;
                txtVis.Text = "You have selected the '6 SM' option";

                vis = 1;

                enrouteRisk = vis + ceiling + manu + I_VFR_Day_XC4.checkpoints + I_VFR_Day_XC4.timeEnroute;

                if (enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else if (enrouteRisk < 9 && enrouteRisk >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + enrouteRisk;
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

                btn6.Pressed = false;
                btn7.Pressed = false;

                e.Handled = true;
                txtVis.Text = "You have selected the '5 SM' option";

                vis = 3;

                enrouteRisk = vis + ceiling + manu + I_VFR_Day_XC4.checkpoints + I_VFR_Day_XC4.timeEnroute;

                if (enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else if (enrouteRisk < 9 && enrouteRisk >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + enrouteRisk;
                }
            };

            btnNone.Touch += (s, e) =>
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

                if (btnNone.Pressed == false)
                    btnNone.Pressed = !btnNone.Pressed;

                btn12.Pressed = false;
                btn3.Pressed = false;

                e.Handled = true;
                txtXWindSolo.Text = "You have selected the 'None' option.";

                manu = 0;

                enrouteRisk = vis + ceiling + manu + I_VFR_Day_XC4.checkpoints + I_VFR_Day_XC4.timeEnroute;

                if (enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else if (enrouteRisk < 9 && enrouteRisk >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + enrouteRisk;
                }
            };
            btn12.Touch += (s, e) =>
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

                if (btn12.Pressed == false)
                    btn12.Pressed = !btn12.Pressed;

                btnNone.Pressed = false;
                btn3.Pressed = false;

                e.Handled = true;
                txtXWindSolo.Text = "You have selected the '1 - 2.' option";

                manu = 1;

                enrouteRisk = vis + ceiling + manu + I_VFR_Day_XC4.checkpoints + I_VFR_Day_XC4.timeEnroute;

                if (enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else if (enrouteRisk < 9 && enrouteRisk >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + enrouteRisk;
                }
            };
            btn3.Touch += (s, e) =>
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

                if (btn3.Pressed == false)
                    btn3.Pressed = !btn3.Pressed;

                btn12.Pressed = false;
                btnNone.Pressed = false;

                e.Handled = true;
                txtXWindSolo.Text = "You have selected the '3 or more' option";

                manu = 3;

                enrouteRisk = vis + ceiling + manu + I_VFR_Day_XC4.checkpoints + I_VFR_Day_XC4.timeEnroute;

                if (enrouteRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "Enroute or Practice Area Risk - OKAY";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else if (enrouteRisk < 9 && enrouteRisk >= 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "Enroute or Practice Area Risk - CAUTION";
                    txtRiskNum.Text = "Risk = " + (enrouteRisk);
                }
                else
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "Enroute or Practice Area Risk - NO GO!";
                    txtRiskNum.Text = "Risk = " + enrouteRisk;
                }
            };

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom3);

            btnNext.Click += delegate
            {
                StartActivity(typeof(I_VFR_Day_XC4));
            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(I_VFR_Day_XC2));
            };
        }
    }
}