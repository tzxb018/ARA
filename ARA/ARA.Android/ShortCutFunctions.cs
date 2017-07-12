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
    class ShortCutFunctions
    {
        public int button1Pressed (Button btn1, Button btn2, Button btn3, TextView txt1)
        {
            btn1.Touch += (s, e) =>
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

                if (btn1.Pressed == false)
                    btn1.Pressed = !btn1.Pressed;

                btn2.Pressed = false;
                btn3.Pressed = false;

                e.Handled = true;

                txt1.Text = "You have selected the '" + btn1.Text + "' option.";

                
            };

            return 0;
        }

        public int button2Pressed(Button btn1, Button btn2, Button btn3, TextView txt1)
        {
            btn2.Touch += (s, e) =>
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

                if (btn2.Pressed == false)
                    btn2.Pressed = !btn2.Pressed;

                btn1.Pressed = false;
                btn3.Pressed = false;

                e.Handled = true;

                txt1.Text = "You have selected the '" + btn2.Text + "' option.";

            };

            return 1;
        }

        public int button3Pressed(Button btn1, Button btn2, Button btn3, TextView txt1)
        {
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

                btn2.Pressed = false;
                btn1.Pressed = false;

                e.Handled = true;

                txt1.Text = "You have selected the '" + btn3.Text + "' option.";

            };

            return 3;
        }

        public void defaultVals(Button btn1, Button btn2, Button btn3, TextView txt, int val)
        {
            if (val == 0)
            {
                btn1.Pressed = true;
                btn2.Pressed = false;
                btn3.Pressed = false;
                txt.Text = "You have selected the '" + btn1.Text + "' option.";
            }
            else if (val == 1)
            {
                btn2.Pressed = true;
                btn1.Pressed = false;
                btn3.Pressed = false;
                txt.Text = "You have selected the '" + btn2.Text + "' option.";
            }
            else
            {
                btn3.Pressed = true;
                btn2.Pressed = false;
                btn1.Pressed = false;
                txt.Text = "You have selected the '" + btn3.Text + "' option.";
            }
        }

        public void riskShow(TextView riskText, TextView riskNum, string risktype, int risk, int low, int med)
        {
            if (risk < low)
            {
                riskText.SetTextColor(Android.Graphics.Color.Green);
                riskNum.SetTextColor(Android.Graphics.Color.Green);
                riskText.Text = risktype + " - OKAY";
                riskNum.Text = "Risk = " + risk;
            }
            else if (risk >= low && risk < med)
            {
                riskText.SetTextColor(Android.Graphics.Color.Yellow);
                riskNum.SetTextColor(Android.Graphics.Color.Yellow);
                riskText.Text = risktype + " - CAUTION";
                riskNum.Text = "Risk = " + risk;
            }
            else
            {
                riskText.SetTextColor(Android.Graphics.Color.Red);
                riskNum.SetTextColor(Android.Graphics.Color.Red);
                riskText.Text = risktype + " - NO GO!";
                riskNum.Text = "Risk = " + risk;
            }
        }

        

       
    }
}