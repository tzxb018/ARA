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
    [Activity(Label = "Student Human Factors - 2 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
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
            btnSylNormal.Touch += (s, e) =>
            {
                //keeps the button looking like it is pressed to allow the user to easlity identify
                if (e.Event.Action == Android.Views.MotionEventActions.Down)
                {
                    e.Handled = true;
                    return;
                }

                if (e.Event.Action == Android.Views.MotionEventActions.Up)
                {
                    e.Handled = false;
                }

                if (btnSylNormal.Pressed==false)
                    btnSylNormal.Pressed = !btnSylNormal.Pressed;

                btnSylStage.Pressed = false;
                btnSylFAA.Pressed = false;

                e.Handled = true;
                syllabusFlight = 0;
                
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

            btnSylStage.Touch += (s,e) =>
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

                if (btnSylStage.Pressed == false)
                    btnSylStage.Pressed = !btnSylStage.Pressed;

                btnSylNormal.Pressed = false;
                btnSylFAA.Pressed = false;

                e.Handled = true;
                syllabusFlight = 1;
                
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

            btnSylFAA.Touch += (s,e) =>
            {
                syllabusFlight = 3;
                if (e.Event.Action == Android.Views.MotionEventActions.Down)
                {
                    e.Handled = true;
                    return;
                }

                if (e.Event.Action == Android.Views.MotionEventActions.Up)
                {
                    e.Handled = false;
                }

                if (btnSylFAA.Pressed == false)
                    btnSylFAA.Pressed = !btnSylFAA.Pressed;

                btnSylNormal.Pressed = false;
                btnSylStage.Pressed = false;

                e.Handled = true;
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
            btnTemp55.Touch += (s,e) =>
            {
                temperature = 0;
                if (e.Event.Action == Android.Views.MotionEventActions.Down)
                {
                    e.Handled = true;
                    return;
                }

                if (e.Event.Action == Android.Views.MotionEventActions.Up)
                {
                    e.Handled = false;
                }

                if (btnTemp55.Pressed == false)
                    btnTemp55.Pressed = !btnTemp55.Pressed;


                btnTemp0.Pressed = false;
                btnTemp30.Pressed = false;
              
                btnTemp76.Pressed = false;
                btnTemp90.Pressed = false;

                e.Handled = true;
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

            btnTemp76.Touch += (s,e) =>
            {
                temperature = 1;
                if (e.Event.Action == Android.Views.MotionEventActions.Down)
                {
                    e.Handled = true;
                    return;
                }

                if (e.Event.Action == Android.Views.MotionEventActions.Up)
                {
                    e.Handled = false;
                }

                if(btnTemp76.Pressed == false)
                    btnTemp76.Pressed = !btnTemp76.Pressed;

                e.Handled = true;

                btnTemp0.Pressed = false;
                btnTemp30.Pressed = false;
                btnTemp55.Pressed = false;
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

            btnTemp90.Touch += (s,e) =>
            {
                temperature = 3;

                if (e.Event.Action == Android.Views.MotionEventActions.Down)
                {
                    e.Handled = true;
                    return;
                }

                if (e.Event.Action == Android.Views.MotionEventActions.Up)
                {
                    e.Handled = false;
                }

                if(btnTemp90.Pressed == false)
                    btnTemp90.Pressed = !btnTemp90.Pressed;


                btnTemp0.Pressed = false;
                btnTemp30.Pressed = false;
                btnTemp55.Pressed = false;
                btnTemp76.Pressed = false;
                e.Handled = true;

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

            btnTemp30.Touch += (s,e) =>
            {
                temperature = 1;
                if (e.Event.Action == Android.Views.MotionEventActions.Down)
                {
                    e.Handled = true;
                    return;
                }

                if (e.Event.Action == Android.Views.MotionEventActions.Up)
                {
                    e.Handled = false;
                }

                if(btnTemp30.Pressed == false)
                    btnTemp30.Pressed = !btnTemp30.Pressed;

                btnTemp0.Pressed = false;
                btnTemp55.Pressed = false;
                btnTemp76.Pressed = false;
                btnTemp90.Pressed = false;
                e.Handled = true;
                isLowerThan55 = true;
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

            btnTemp0.Touch += (s,e) =>
            {
                temperature = 3;
                if (e.Event.Action == Android.Views.MotionEventActions.Down)
                {
                    e.Handled = true;
                    return;
                }

                if (e.Event.Action == Android.Views.MotionEventActions.Up)
                {
                    e.Handled = false;
                }

                if (btnTemp0.Pressed == false)
                    btnTemp0.Pressed = !btnTemp0.Pressed;

                e.Handled = true;
                isLowerThan55 = true;
                btnTemp30.Pressed = false;
                btnTemp55.Pressed = false;
                btnTemp76.Pressed = false;
                btnTemp90.Pressed = false;
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

            btnNext.Click += delegate
            {
                if (B_Filing_Criteria_Activity.isVFR) //if VFR
                {
                    if (C_Time_VFR_Activity.VFRisDay) //Day
                    {
                        if (D_Syllabus_Activity.isLocal) //Local
                        {
                            if (F_Student_Human_Factors.SHFRisk < 9)
                            {
                                StartActivity(typeof(H_VFR_Day_Local1));
                            }
                            else
                            {
                                AlertDialog.Builder alertSHFisHigh = new AlertDialog.Builder(this);
                                alertSHFisHigh.SetTitle("Alert");
                                alertSHFisHigh.SetMessage("Your Student Human Factor Risk is too high!");
                                alertSHFisHigh.SetNeutralButton("OK", delegate
                                {
                                    alertSHFisHigh.Dispose();
                                });
                                alertSHFisHigh.Show();
                            }
                                
                        }
                        else //XC
                        {
                            if (F_Student_Human_Factors.SHFRisk < 9)
                            {
                                StartActivity(typeof(I_VFR_Day_XC));
                            }
                            else
                            {
                                AlertDialog.Builder alertSHFisHigh = new AlertDialog.Builder(this);
                                alertSHFisHigh.SetTitle("Alert");
                                alertSHFisHigh.SetMessage("Your Student Human Factor Risk is too high!");
                                alertSHFisHigh.SetNeutralButton("OK", delegate
                                {
                                    alertSHFisHigh.Dispose();
                                });
                                alertSHFisHigh.Show();
                            }
                        }
                    }
                    else if (C_Time_VFR_Activity.VFRisDual) //Dual
                    {
                        if (D_Syllabus_Activity.isLocal) //Local
                        {
                            if (F_Student_Human_Factors.SHFRisk < 9)
                            {
                                StartActivity(typeof(J_VFR_Dual_Local1));
                            }
                            else
                            {
                                AlertDialog.Builder alertSHFisHigh = new AlertDialog.Builder(this);
                                alertSHFisHigh.SetTitle("Alert");
                                alertSHFisHigh.SetMessage("Your Student Human Factor Risk is too high!");
                                alertSHFisHigh.SetNeutralButton("OK", delegate
                                {
                                    alertSHFisHigh.Dispose();
                                });
                                alertSHFisHigh.Show();
                            }
                        }
                        else //XC
                        {
                            if (F_Student_Human_Factors.SHFRisk < 9)
                            {
                                StartActivity(typeof(K_VFR_Dual_XC1));
                            }
                            else
                            {
                                AlertDialog.Builder alertSHFisHigh = new AlertDialog.Builder(this);
                                alertSHFisHigh.SetTitle("Alert");
                                alertSHFisHigh.SetMessage("Your Student Human Factor Risk is too high!");
                                alertSHFisHigh.SetNeutralButton("OK", delegate
                                {
                                    alertSHFisHigh.Dispose();
                                });
                                alertSHFisHigh.Show();
                            }
                        }
                    }
                    else //Night
                    {
                        if (D_Syllabus_Activity.isLocal) //Local
                        {
                            if (F_Student_Human_Factors.SHFRisk < 9)
                            {
                                StartActivity(typeof(L_VFR_Night_Local1));
                            }
                            else
                            {
                                AlertDialog.Builder alertSHFisHigh = new AlertDialog.Builder(this);
                                alertSHFisHigh.SetTitle("Alert");
                                alertSHFisHigh.SetMessage("Your Student Human Factor Risk is too high!");
                                alertSHFisHigh.SetNeutralButton("OK", delegate
                                {
                                    alertSHFisHigh.Dispose();
                                });
                                alertSHFisHigh.Show();
                            }
                        }
                        else //XC
                        {
                            if (F_Student_Human_Factors.SHFRisk < 9)
                            {
                                StartActivity(typeof(M_VFR_Night_XC1));
                            }
                            else
                            {
                                AlertDialog.Builder alertSHFisHigh = new AlertDialog.Builder(this);
                                alertSHFisHigh.SetTitle("Alert");
                                alertSHFisHigh.SetMessage("Your Student Human Factor Risk is too high!");
                                alertSHFisHigh.SetNeutralButton("OK", delegate
                                {
                                    alertSHFisHigh.Dispose();
                                });
                                alertSHFisHigh.Show();
                            }
                        }
                    }
                }
                else //IFR
                {
                    if (C_Time_IFR_Activity.IFRisDual) //Dual
                    {
                        if (D_Syllabus_Activity.isLocal) //Local
                        {
                            
                        }
                        else //XC
                        {

                        }
                    }
                    else //Night
                    {
                        if (D_Syllabus_Activity.isLocal) //Local
                        {
                            if (F_Student_Human_Factors.SHFRisk < 9)
                            {
                                StartActivity(typeof(N_IFR_Day_Local_Home));
                            }
                            else
                            {
                                AlertDialog.Builder alertSHFisHigh = new AlertDialog.Builder(this);
                                alertSHFisHigh.SetTitle("Alert");
                                alertSHFisHigh.SetMessage("Your Student Human Factor Risk is too high!");
                                alertSHFisHigh.SetNeutralButton("OK", delegate
                                {
                                    alertSHFisHigh.Dispose();
                                });
                                alertSHFisHigh.Show();
                            }
                        }
                        else //XC
                        {
                            if (F_Student_Human_Factors.SHFRisk < 9)
                            {
                                StartActivity(typeof(O_IFR_Day_XC_1Departure));
                            }
                            else
                            {
                                AlertDialog.Builder alertSHFisHigh = new AlertDialog.Builder(this);
                                alertSHFisHigh.SetTitle("Alert");
                                alertSHFisHigh.SetMessage("Your Student Human Factor Risk is too high!");
                                alertSHFisHigh.SetNeutralButton("OK", delegate
                                {
                                    alertSHFisHigh.Dispose();
                                });
                                alertSHFisHigh.Show();
                            }
                        }
                    }
                }
            };

        }
    }
}