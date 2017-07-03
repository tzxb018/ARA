using System;
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
using Android.Graphics;

namespace ARA.Droid
{
    [Activity(Label = "Student Human Factors - 1 of 2")]
    public class F_Student_Human_Factors : Activity
    {
        public static int previousFlights = 0; //each variable represents risk value for section depending on question
        public static int FlightDutyPeriod = 0;
        public static int SHFRisk = 0;
    
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.f_Student_Human_Factors);

            var btnnext = FindViewById<ImageButton>(Resource.Id.btnContinueFromSHF1);
            var btnback = FindViewById<ImageButton>(Resource.Id.btnBackfromSHF1);
            var btnPrev0 = FindViewById<Button>(Resource.Id.btnNoPreviousFlights);
            var btnPrev1 = FindViewById<Button>(Resource.Id.btn1PrevFlight);
            var btnPrev2 = FindViewById<Button>(Resource.Id.btn2PrevFlights);
            var txtPrevInfo = FindViewById<TextView>(Resource.Id.txtPrevFlightChoice);
            var btnLess8Flight = FindViewById<Button>(Resource.Id.btnDutyLessThanEight);
            var btn8to10 = FindViewById<Button>(Resource.Id.btnDutyEightToTen);
            var btn10Plus = FindViewById<Button>(Resource.Id.btnDutyTenToThirteen);
            var txtDutyInfo = FindViewById<TextView>(Resource.Id.txtDutyHoursAgo);
            var txtRisk = FindViewById<TextView>(Resource.Id.txtSHFRisk1);

            //Default Values
            if (previousFlights == 0)
            {
                btnPrev0.Pressed = true;
                btnPrev1.Pressed = false;
                btnPrev2.Pressed = false;
                txtPrevInfo.Text = "You have selected the 'none' option";
            }
            else if (previousFlights == 1)
            {
                btnPrev0.Pressed = false;
                btnPrev1.Pressed = true;
                btnPrev2.Pressed = false;
                txtPrevInfo.Text = "You have selected the '1' option";
            }
            else if (previousFlights == 3)
            {
                btnPrev0.Pressed = false;
                btnPrev1.Pressed = false;
                btnPrev2.Pressed = true;
                txtPrevInfo.Text = "You have selected the '2' option";
            }
            else
            {
                
                    btnPrev0.Pressed = false;
                    btnPrev1.Pressed = false;
                    btnPrev2.Pressed = false;
                    txtPrevInfo.Text = "Select number of previous flights with buttons above.";
               
            }

            if (FlightDutyPeriod == 0)
            {
                btnLess8Flight.Pressed = true;
                btn8to10.Pressed = false;
                btn10Plus.Pressed = false;
                txtDutyInfo.Text = "You have selected the '<8 hours ago' option";
            }
            else if (FlightDutyPeriod == 1)
            {
                btnLess8Flight.Pressed = false;
                btn8to10.Pressed = true;
                btn10Plus.Pressed = false;
                txtDutyInfo.Text = "You have selected the '8-10 hours ago' option";
            }
            else if (FlightDutyPeriod == 3)
            {
                btnLess8Flight.Pressed = false;
                btn8to10.Pressed = false;
                btn10Plus.Pressed = true;
                txtDutyInfo.Text = "You have selected the '10-13 hours ago' option";
            }
            else
            {

                btnLess8Flight.Pressed = false;
                btn8to10.Pressed = false;
                btn10Plus.Pressed = false;
                txtDutyInfo.Text = "Select when flight duty period began with buttons above.";

            }

            //Reading Click Values
            btnPrev0.Touch += (s,e) =>
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

                if (btnPrev0.Pressed == false)
                    btnPrev0.Pressed = !btnPrev0.Pressed;

                btnPrev1.Pressed = false;
                btnPrev2.Pressed = false;

                e.Handled = true;

                txtPrevInfo.Text = "You have selected the 'none' option";
                previousFlights = 0;
                SHFRisk = FlightDutyPeriod + previousFlights + G_Student_Human_Factors_2.temperature + G_Student_Human_Factors_2.syllabusFlight;
                if (SHFRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Student Human Factors Risk = " + SHFRisk.ToString();
                }
                else if (SHFRisk >= 7 && SHFRisk <= 8)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Student Human Factors Risk = " + SHFRisk.ToString();
                }
                else if (SHFRisk > 8)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Student Human Factors Risk = " + SHFRisk.ToString();
                }
                  
            };

            btnPrev1.Touch += (s,e) =>
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

                 if (btnPrev1.Pressed == false)
                    btnPrev1.Pressed = !btnPrev1.Pressed;

                 btnPrev0.Pressed = false;
                 btnPrev2.Pressed = false;

                 e.Handled = true;

                 txtPrevInfo.Text = "You have selected the '1' option";
                 previousFlights = 1;
                 SHFRisk = FlightDutyPeriod + previousFlights + G_Student_Human_Factors_2.temperature + G_Student_Human_Factors_2.syllabusFlight;
                 if (SHFRisk < 7)
                 {
                     txtRisk.SetTextColor(Android.Graphics.Color.Green);
                     txtRisk.Text = "OKAY - Student Human Factors Risk = " + SHFRisk.ToString();
                 }
                 else if (SHFRisk >= 7 && SHFRisk <= 8)
                 {
                     txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                     txtRisk.Text = "CAUTION - Student Human Factors Risk = " + SHFRisk.ToString();
                 }
                 else if (SHFRisk > 8)
                 {
                     txtRisk.SetTextColor(Android.Graphics.Color.Red);
                     txtRisk.Text = "NO GO! - Student Human Factors Risk = " + SHFRisk.ToString();
                 }
             };

            btnPrev2.Touch += (s,e) =>
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

                if(btnPrev2.Pressed == false)
                    btnPrev2.Pressed = !btnPrev2.Pressed;

                btnPrev1.Pressed = false;
                btnPrev0.Pressed = false;

                e.Handled = true;

                txtPrevInfo.Text = "You have selected the '2' option";
                previousFlights = 3;
                SHFRisk = FlightDutyPeriod + previousFlights + G_Student_Human_Factors_2.temperature + G_Student_Human_Factors_2.syllabusFlight;
                if (SHFRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Student Human Factors Risk = " + SHFRisk.ToString();
                }
                else if (SHFRisk >= 7 && SHFRisk <= 8)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Student Human Factors Risk = " + SHFRisk.ToString();
                }
                else if (SHFRisk > 8)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Student Human Factors Risk = " + SHFRisk.ToString();
                }
            };

            btnLess8Flight.Touch += (s,e) =>
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

               if (btnLess8Flight.Pressed == false)
                    btnLess8Flight.Pressed = !btnLess8Flight.Pressed;

               btn8to10.Pressed = false;
               btn10Plus.Pressed = false;

               e.Handled = true;

               txtDutyInfo.Text = "You have selected the '<8 hours ago' option";
               FlightDutyPeriod = 0;
               SHFRisk = FlightDutyPeriod + previousFlights + G_Student_Human_Factors_2.temperature + G_Student_Human_Factors_2.syllabusFlight;
               if (SHFRisk < 7)
               {
                   txtRisk.SetTextColor(Android.Graphics.Color.Green);
                   txtRisk.Text = "OKAY - Student Human Factors Risk = " + SHFRisk.ToString();
               }
               else if (SHFRisk >= 7 && SHFRisk <= 8)
               {
                   txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                   txtRisk.Text = "CAUTION - Student Human Factors Risk = " + SHFRisk.ToString();
               }
               else if (SHFRisk > 8)
               {
                   txtRisk.SetTextColor(Android.Graphics.Color.Red);
                   txtRisk.Text = "NO GO! - Student Human Factors Risk = " + SHFRisk.ToString();
               }
           };

            btn8to10.Touch += (s,e) =>
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

                if (btn8to10.Pressed == false)
                    btn8to10.Pressed = !btn8to10.Pressed;

                btn10Plus.Pressed = false;
                btnLess8Flight.Pressed = false;

                e.Handled = true;


                txtDutyInfo.Text = "You have selected the '8-10 hours ago' option";
                FlightDutyPeriod = 1;
                SHFRisk = FlightDutyPeriod + previousFlights + G_Student_Human_Factors_2.temperature + G_Student_Human_Factors_2.syllabusFlight;
                if (SHFRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Student Human Factors Risk = " + SHFRisk.ToString();
                }
                else if (SHFRisk >= 7 && SHFRisk <= 8)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Student Human Factors Risk = " + SHFRisk.ToString();
                }
                else if (SHFRisk > 8)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Student Human Factors Risk = " + SHFRisk.ToString();
                }
            };

            btn10Plus.Touch += (s, e) =>
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

                if (btn10Plus.Pressed == false)
                    btn10Plus.Pressed = !btn10Plus.Pressed;

                e.Handled = true;

                btn8to10.Pressed = false;
                btnLess8Flight.Pressed = false;

                txtDutyInfo.Text = "You have selected the '10-13 hours ago' option";
                FlightDutyPeriod = 3;
                SHFRisk = FlightDutyPeriod + previousFlights + G_Student_Human_Factors_2.temperature + G_Student_Human_Factors_2.syllabusFlight;
                if (SHFRisk < 7)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk.Text = "OKAY - Student Human Factors Risk = " + SHFRisk.ToString();
                }
                else if (SHFRisk >= 7 && SHFRisk <= 8)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk.Text = "CAUTION - Student Human Factors Risk = " + SHFRisk.ToString();
                }
                else if (SHFRisk > 8)
                {
                    txtRisk.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk.Text = "NO GO! - Student Human Factors Risk = " + SHFRisk.ToString();
                }
            };

            //showing risk on bottom
            if (SHFRisk < 7)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Green);
                txtRisk.Text = "OKAY - Student Human Factors Risk = " + SHFRisk.ToString();
            }
            else if (SHFRisk >= 7 && SHFRisk <= 8)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Yellow);
                txtRisk.Text = "CAUTION - Student Human Factors Risk = " + SHFRisk.ToString();
            }
            else if (SHFRisk > 8)
            {
                txtRisk.SetTextColor(Android.Graphics.Color.Red);
                txtRisk.Text = "NO GO! - Student Human Factors Risk = " + SHFRisk.ToString();
            }

            btnback.Click += delegate
            {
                StartActivity(typeof(E_Personal_Information));
            };

            btnnext.Click += delegate
          {
              StartActivity(typeof(G_Student_Human_Factors_2));
          };
        }
    }
}