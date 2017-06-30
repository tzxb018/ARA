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
    [Activity(Label = "Student Human Factors - 1 of 2")]
    public class G_Student_Human_Factors_2 : Activity
    {
        public static int syllabusFlight = 0;
        public static int temperature = 0;
        public static bool isLowerThan55;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.g_Student_Human_Factors2);

            var btnSylNormal = FindViewById<Button>(Resource.Id.btnSyllabusFlightNormal);
            var btnSylStage = FindViewById<Button>(Resource.Id.btnSyllabusFlightStageCheck);
            var btnSylFAA = FindViewById<Button>(Resource.Id.btnSyllabusFlightFAA);
            var txtSyl = FindViewById<TextView>(Resource.Id.txtSyllabusFlight);
            var btnTemp0 = FindViewById<Button>(Resource.Id.btnTemp0);
            var btnTemp30 = FindViewById<Button>(Resource.Id.btnTemp30);
            var btnTemp55 = FindViewById<Button>(Resource.Id.btnTemp55);
            var btnTemp76 = FindViewById<Button>(Resource.Id.btnTemp76);
            var btnTemp90 = FindViewById<Button>(Resource.Id.btnTemp90);
            var txtTempInfo = FindViewById<TextView>(Resource.Id.txtTemp);
            var txtRisk2 = FindViewById<TextView>(Resource.Id.txtSHFRisk2);
            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFromSHF2);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfromSHF2);

            //Default Values
            if (syllabusFlight == 0)
            {
                btnSylNormal.Pressed = true;
                btnSylStage.Pressed = false;
                btnSylFAA.Pressed = false;
                txtSyl.Text = "You have selected the 'Normal' option.";
            }
            else if (syllabusFlight == 1)
            {
                btnSylNormal.Pressed = false;
                btnSylStage.Pressed = true;
                btnSylFAA.Pressed = false;
                txtSyl.Text = "You have selected the 'Stage Check' option.";
            }
            else if (syllabusFlight == 3)
            {
                btnSylNormal.Pressed = false;
                btnSylStage.Pressed = false;
                btnSylFAA.Pressed = true;
                txtSyl.Text = "You have selected the 'FAA Check' option.";
            }
            else
            {
                    btnSylNormal.Pressed = false;
                    btnSylStage.Pressed = false;
                    btnSylFAA.Pressed = false;
                    txtSyl.Text = "Select type of syllabus flight with buttons above.";
            }

            if (temperature == 0)
            {
             
                btnTemp55.Pressed = true;
                btnTemp0.Pressed = false;
                btnTemp30.Pressed = false;
                btnTemp76.Pressed = false;
                btnTemp90.Pressed = false;
                txtTempInfo.Text = "You have selected the '55 - 75' option.";
            }
            else if (temperature == 1)
            {
                if (isLowerThan55 == true)
                {
                    btnTemp55.Pressed = false;
                    btnTemp0.Pressed = false;
                    btnTemp30.Pressed = true;
                    btnTemp76.Pressed = false;
                    btnTemp90.Pressed = false;
                    txtTempInfo.Text = "You have selected the '30 - 54' option.";
                }
                else
                {
                    btnTemp55.Pressed = false;
                    btnTemp0.Pressed = false;
                    btnTemp30.Pressed = false;
                    btnTemp76.Pressed = true;
                    btnTemp90.Pressed = false;
                    txtTempInfo.Text = "You have selected the '76 - 89' option.";
                }
               
            }
            else if (temperature == 3)
            {
                if (isLowerThan55 == true)
                {
                    btnTemp55.Pressed = false;
                    btnTemp0.Pressed = true;
                    btnTemp30.Pressed = false;
                    btnTemp76.Pressed = false;
                    btnTemp90.Pressed = false;
                    txtTempInfo.Text = "You have selected the '0 - 29' option.";
                }
                else
                {
                    btnTemp55.Pressed = false;
                    btnTemp0.Pressed = false;
                    btnTemp30.Pressed = false;
                    btnTemp76.Pressed = false;
                    btnTemp90.Pressed = true;
                    txtTempInfo.Text = "You have selected the '90 +' option.";
                }
               
            }
            else
            {
                btnTemp55.Pressed = false;
                btnTemp0.Pressed = false;
                btnTemp30.Pressed = false;
                btnTemp76.Pressed = false;
                btnTemp90.Pressed = false;
                txtTempInfo.Text = "Select outside temperature with buttons above.";
            }


            //Click events
            btnSylNormal.Click += delegate
            {
                syllabusFlight = 0;
                btnSylNormal.Pressed = true;
                btnSylStage.Pressed = false;
                btnSylFAA.Pressed = false;
                txtSyl.Text = "You have selected the 'Normal' option.";
                F_Student_Human_Factors.SHFRisk = (syllabusFlight) + F_Student_Human_Factors.previousFlights + F_Student_Human_Factors.FlightDutyPeriod + temperature;
                if (F_Student_Human_Factors.SHFRisk < 7)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk2.Text = "OKAY - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk >= 7 && F_Student_Human_Factors.SHFRisk <= 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk2.Text = "CAUTION - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk > 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk2.Text = "NO GO! - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
            };

            btnSylStage.Click += delegate
            {
                syllabusFlight = 1;
                btnSylNormal.Pressed = false;
                btnSylStage.Pressed = true;
                btnSylFAA.Pressed = false;
                txtSyl.Text = "You have selected the 'Stage Check' option.";
                F_Student_Human_Factors.SHFRisk = (syllabusFlight) + F_Student_Human_Factors.previousFlights + F_Student_Human_Factors.FlightDutyPeriod + temperature;
                if (F_Student_Human_Factors.SHFRisk < 7)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk2.Text = "OKAY - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk >= 7 && F_Student_Human_Factors.SHFRisk <= 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk2.Text = "CAUTION - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk > 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk2.Text = "NO GO! - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
            };

            btnSylFAA.Click += delegate
            {
                syllabusFlight = 3;
                btnSylNormal.Pressed = false;
                btnSylStage.Pressed = false;
                btnSylFAA.Pressed = true;
                txtSyl.Text = "You have selected the 'FAA Check' option.";
                F_Student_Human_Factors.SHFRisk = (syllabusFlight) + F_Student_Human_Factors.previousFlights + F_Student_Human_Factors.FlightDutyPeriod + temperature;
                if (F_Student_Human_Factors.SHFRisk < 7)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk2.Text = "OKAY - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk >= 7 && F_Student_Human_Factors.SHFRisk <= 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk2.Text = "CAUTION - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk > 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk2.Text = "NO GO! - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
            };

            //TEmperature
            btnTemp55.Click += delegate
            {
                temperature = 0;
                btnTemp0.Pressed = false;
                btnTemp30.Pressed = false;
                btnTemp55.Pressed = true;
                btnTemp76.Pressed = false;
                btnTemp90.Pressed = false;
                txtTempInfo.Text = "You have selected the '55 - 75' option.";
                F_Student_Human_Factors.SHFRisk = (syllabusFlight) + F_Student_Human_Factors.previousFlights + F_Student_Human_Factors.FlightDutyPeriod + temperature;
                if (F_Student_Human_Factors.SHFRisk < 7)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk2.Text = "OKAY - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk >= 7 && F_Student_Human_Factors.SHFRisk <= 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk2.Text = "CAUTION - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk > 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk2.Text = "NO GO! - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
            };

            btnTemp76.Click += delegate
            {
                temperature = 1;
                btnTemp0.Pressed = false;
                btnTemp30.Pressed = false;
                btnTemp55.Pressed = false;
                btnTemp76.Pressed = true;
                btnTemp90.Pressed = false;
                isLowerThan55 = false;
                txtTempInfo.Text = "You have selected the '76- 89' option.";
                F_Student_Human_Factors.SHFRisk = (syllabusFlight) + F_Student_Human_Factors.previousFlights + F_Student_Human_Factors.FlightDutyPeriod + temperature;
                if (F_Student_Human_Factors.SHFRisk < 7)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk2.Text = "OKAY - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk >= 7 && F_Student_Human_Factors.SHFRisk <= 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk2.Text = "CAUTION - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk > 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk2.Text = "NO GO! - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
            };

            btnTemp90.Click += delegate
            {
                temperature = 3;
                btnTemp0.Pressed = false;
                btnTemp30.Pressed = false;
                btnTemp55.Pressed = false;
                btnTemp76.Pressed = false;
                btnTemp90.Pressed = true;
                isLowerThan55 = false;
                txtTempInfo.Text = "You have selected the '90 +' option.";
                F_Student_Human_Factors.SHFRisk = (syllabusFlight) + F_Student_Human_Factors.previousFlights + F_Student_Human_Factors.FlightDutyPeriod + temperature;
                if (F_Student_Human_Factors.SHFRisk < 7)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk2.Text = "OKAY - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk >= 7 && F_Student_Human_Factors.SHFRisk <= 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk2.Text = "CAUTION - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk > 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk2.Text = "NO GO! - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
            };

            btnTemp30.Click += delegate
            {
                temperature = 1;
                btnTemp0.Pressed = false;
                btnTemp30.Pressed = true;
                btnTemp55.Pressed = false;
                btnTemp76.Pressed = false;
                btnTemp90.Pressed = false;
                isLowerThan55 = false;
                txtTempInfo.Text = "You have selected the '30 - 54' option.";
                F_Student_Human_Factors.SHFRisk = (syllabusFlight) + F_Student_Human_Factors.previousFlights + F_Student_Human_Factors.FlightDutyPeriod + temperature;
                if (F_Student_Human_Factors.SHFRisk < 7)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk2.Text = "OKAY - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk >= 7 && F_Student_Human_Factors.SHFRisk <= 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk2.Text = "CAUTION - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk > 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk2.Text = "NO GO! - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
            };

            btnTemp0.Click += delegate
            {
                temperature = 3;
                btnTemp0.Pressed = true;
                btnTemp30.Pressed = false;
                btnTemp55.Pressed = false;
                btnTemp76.Pressed = false;
                btnTemp90.Pressed = false;
                isLowerThan55 = false;
                txtTempInfo.Text = "You have selected the '0 - 29' option.";
                F_Student_Human_Factors.SHFRisk = (syllabusFlight) + F_Student_Human_Factors.previousFlights + F_Student_Human_Factors.FlightDutyPeriod + temperature;
                if (F_Student_Human_Factors.SHFRisk < 7)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Green);
                    txtRisk2.Text = "OKAY - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk >= 7 && F_Student_Human_Factors.SHFRisk <= 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Yellow);
                    txtRisk2.Text = "CAUTION - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
                else if (F_Student_Human_Factors.SHFRisk > 8)
                {
                    txtRisk2.SetTextColor(Android.Graphics.Color.Red);
                    txtRisk2.Text = "NO GO! - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
                }
            };

            if (F_Student_Human_Factors.SHFRisk < 7)
            {
                txtRisk2.SetTextColor(Android.Graphics.Color.Green);
                txtRisk2.Text = "OKAY - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
            }
            else if (F_Student_Human_Factors.SHFRisk >= 7 && F_Student_Human_Factors.SHFRisk <= 8)
            {
                txtRisk2.SetTextColor(Android.Graphics.Color.Yellow);
                txtRisk2.Text = "CAUTION - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
            }
            else if (F_Student_Human_Factors.SHFRisk > 8)
            {
                txtRisk2.SetTextColor(Android.Graphics.Color.Red);
                txtRisk2.Text = "NO GO! - Student Human Factors Risk = " + F_Student_Human_Factors.SHFRisk.ToString();
            }


            btnBack.Click += delegate
            {
                StartActivity(typeof(F_Student_Human_Factors));
            };

        }
    }
}