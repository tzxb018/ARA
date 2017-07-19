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
    [Activity(Label = "PIC - 1 of 1", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class H_VFR_Day_LocalPIC : Activity
    {
        public static int CFI_Landing;
        public static int Other_Landing;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.h_Layout2);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom2);

            var lblCFILanding = FindViewById<TextView>(Resource.Id.txt2Question1);
            var btnLessThan30 = FindViewById<Button>(Resource.Id.btn2Q1C1);
            var btn30to45 = FindViewById<Button>(Resource.Id.btn2Q1C2);
            var btn45Plus = FindViewById<Button>(Resource.Id.btn2Q1C3);
            var txtCFILanding = FindViewById<TextView>(Resource.Id.txt2Answer1);

            var lblOtherLanding = FindViewById<TextView>(Resource.Id.txt2Question2);
            var btnLessThan10 = FindViewById<Button>(Resource.Id.btn2Q2C1);
            var btn10to14 = FindViewById<Button>(Resource.Id.btn2Q2C2);
            var btnPlus14 = FindViewById<Button>(Resource.Id.btn2Q2C3);
            var txtOtherLanding = FindViewById<TextView>(Resource.Id.txt2Answer2);

            var txtPICRisk = FindViewById<TextView>(Resource.Id.txt2RiskText2);
            var txtPICRiskNum = FindViewById<TextView>(Resource.Id.txt2RiskNum);

            lblCFILanding.Text = "Last dual landing (C, CFI)";
            btnLessThan30.Text = "<30 days";
            btn30to45.Text = "30 - 45 days";
            btn45Plus.Text = ">45 days";
            txtCFILanding.Text = "You have selected the '" + btnLessThan30.Text + "' choice.";

            lblOtherLanding.Text = "Last dual landing (Other)";
            btnLessThan10.Text = "<10 days";
            btn10to14.Text = "10 - 14 days";
            btnPlus14.Text = ">14 days";
            txtOtherLanding.Text = "You have selected the '" + btnLessThan10.Text + "' choice.";

            if (CFI_Landing + Other_Landing == 0)
            {
                txtPICRisk.SetTextColor(Android.Graphics.Color.Green);
                txtPICRiskNum.SetTextColor(Android.Graphics.Color.Green);
                txtPICRisk.Text = "PIC Risk - OKAY";
                txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
            }
            else if (CFI_Landing + Other_Landing < 3 && CFI_Landing + Other_Landing > 0)
            {
                txtPICRisk.SetTextColor(Android.Graphics.Color.Yellow);
                txtPICRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                txtPICRisk.Text = "PIC Risk - CAUTION";
                txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
            }
            else
            {
                txtPICRisk.SetTextColor(Android.Graphics.Color.Red);
                txtPICRiskNum.SetTextColor(Android.Graphics.Color.Red);
                txtPICRisk.Text = "PIC Risk - NO GO!";
                txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
            }

            //default values 
            if (CFI_Landing == 0)
            {
                btnLessThan30.Pressed = true;
                btn30to45.Pressed = false;
                btn45Plus.Pressed = false;
                txtCFILanding.Text = "You have selected the '" + btnLessThan30.Text + "'choice.";
            }
            else if (CFI_Landing == 1)
            {
                btnLessThan30.Pressed = false;
                btn30to45.Pressed = true;
                btn45Plus.Pressed = false;
                txtCFILanding.Text = "You have selected the '" + btn30to45.Text + "'choice.";
            }
            else
            {
                btnLessThan30.Pressed = false;
                btn30to45.Pressed = false;
                btn45Plus.Pressed = true;
                txtCFILanding.Text = "You have selected the '" + btn45Plus.Text + "'choice.";
            }

            if (Other_Landing == 0)
            {
                btnLessThan10.Pressed = true;
                btn10to14.Pressed = false;
                btnPlus14.Pressed = false;
                txtOtherLanding.Text = "You have selected the '" + btnLessThan10.Text + "'choice.";
            }
            else if (Other_Landing == 1)
            {
                btnLessThan10.Pressed = false;
                btn10to14.Pressed = true;
                btnPlus14.Pressed = false;
                txtOtherLanding.Text = "You have selected the '" + btn10to14.Text + "'choice.";
            }
            else
            {
                btnLessThan10.Pressed = false;
                btn10to14.Pressed = false;
                btnPlus14.Pressed = true;
                txtOtherLanding.Text = "You have selected the '" + btnPlus14.Text + "'choice.";
            }

            //Pressed Events
            btnLessThan30.Touch += (s, e) =>
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

                if (btnLessThan30.Pressed == false)
                    btnLessThan30.Pressed = !btnLessThan30.Pressed;

                btn30to45.Pressed = false;
                btn45Plus.Pressed = false;

                e.Handled = true;

                txtCFILanding.Text = "You have selected the '" + btnLessThan30.Text + "' option.";

                CFI_Landing = 0;

                if (CFI_Landing + Other_Landing == 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRisk.Text = "PIC Risk - OKAY";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else if (CFI_Landing + Other_Landing < 3 && CFI_Landing + Other_Landing > 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRisk.Text = "PIC Risk - CAUTION";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRisk.Text = "PIC Risk - NO GO!";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
            };
            btn30to45.Touch += (s, e) =>
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

                if (btn30to45.Pressed == false)
                    btn30to45.Pressed = !btn30to45.Pressed;

                btnLessThan30.Pressed = false;
                btn45Plus.Pressed = false;

                e.Handled = true;

                txtCFILanding.Text = "You have selected the '" + btn30to45.Text + "' option.";

                CFI_Landing = 1;

                if (CFI_Landing + Other_Landing == 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRisk.Text = "PIC Risk - OKAY";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else if (CFI_Landing + Other_Landing < 3 && CFI_Landing + Other_Landing > 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRisk.Text = "PIC Risk - CAUTION";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRisk.Text = "PIC Risk - NO GO!";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
            };
            btn45Plus.Touch += (s, e) =>
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

                if (btn45Plus.Pressed == false)
                    btn45Plus.Pressed = !btn45Plus.Pressed;

                btn30to45.Pressed = false;
                btnLessThan30.Pressed = false;

                e.Handled = true;

                txtCFILanding.Text = "You have selected the '" + btn45Plus.Text + "' option.";

                CFI_Landing = 3;

                if (CFI_Landing + Other_Landing == 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRisk.Text = "PIC Risk - OKAY";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else if (CFI_Landing + Other_Landing < 3 && CFI_Landing + Other_Landing > 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRisk.Text = "PIC Risk - CAUTION";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRisk.Text = "PIC Risk - NO GO!";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
            };

            btnLessThan10.Touch += (s, e) =>
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

                if (btnLessThan10.Pressed == false)
                    btnLessThan10.Pressed = !btnLessThan10.Pressed;

                btn10to14.Pressed = false;
                btnPlus14.Pressed = false;

                e.Handled = true;

                txtOtherLanding.Text = "You have selected the '" + btnLessThan10.Text + "' option.";

                Other_Landing = 0;

                if (CFI_Landing + Other_Landing == 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRisk.Text = "PIC Risk - OKAY";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else if (CFI_Landing + Other_Landing < 3 && CFI_Landing + Other_Landing > 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRisk.Text = "PIC Risk - CAUTION";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRisk.Text = "PIC Risk - NO GO!";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
            };
            btn10to14.Touch += (s, e) =>
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

                if (btn10to14.Pressed == false)
                    btn10to14.Pressed = !btn10to14.Pressed;

                btnLessThan10.Pressed = false;
                btnPlus14.Pressed = false;

                e.Handled = true;

                txtOtherLanding.Text = "You have selected the '" + btn10to14.Text + "' option.";

                Other_Landing = 1;

                if (CFI_Landing + Other_Landing == 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRisk.Text = "PIC Risk - OKAY";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else if (CFI_Landing + Other_Landing < 3 && CFI_Landing + Other_Landing > 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRisk.Text = "PIC Risk - CAUTION";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRisk.Text = "PIC Risk - NO GO!";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
            };
            btnPlus14.Touch += (s, e) =>
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

                if (btnPlus14.Pressed == false)
                    btnPlus14.Pressed = !btnPlus14.Pressed;

                btn10to14.Pressed = false;
                btnLessThan10.Pressed = false;

                e.Handled = true;

                txtOtherLanding.Text = "You have selected the '" + btnPlus14.Text + "' option.";

                Other_Landing = 3;

                if (CFI_Landing + Other_Landing == 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Green);
                    txtPICRisk.Text = "PIC Risk - OKAY";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else if (CFI_Landing + Other_Landing < 3 && CFI_Landing + Other_Landing > 0)
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Yellow);
                    txtPICRisk.Text = "PIC Risk - CAUTION";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
                else
                {
                    txtPICRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRiskNum.SetTextColor(Android.Graphics.Color.Red);
                    txtPICRisk.Text = "PIC Risk - NO GO!";
                    txtPICRiskNum.Text = "Risk = " + (CFI_Landing + Other_Landing);
                }
            };


            //Navigation
            btnNext.Click += delegate
            {
                if (CFI_Landing + Other_Landing < 3)
                {
                    StartActivity(typeof(Y_Aircraft_and_Instructor));
                }
                else
                {
                    AlertDialog.Builder alertPICRisk = new AlertDialog.Builder(this);
                    alertPICRisk.SetTitle("Alert");
                    alertPICRisk.SetMessage("Your PIC Risk is too high!");
                    alertPICRisk.SetNeutralButton("OK", delegate
                    {
                        alertPICRisk.Dispose();
                    });
                    alertPICRisk.Show();
                }

            };

            btnBack.Click += delegate
            {
                StartActivity(typeof(H_VFR_Day_Local1));
            };

        }
    }
}