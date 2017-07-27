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
    [Activity(Label = "Aircraft and Instructor")]
    public class Y_Aircraft_and_Instructor : Activity
    {
        public static string aircraft, instructor, personal, email;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.y_Aircraft_and_Instructor);

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinnerInstructor);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.name_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            


            EditText txtAircraft = FindViewById<EditText>(Resource.Id.txtAircraft);
            AutoCompleteTextView txtEmail = FindViewById<AutoCompleteTextView>(Resource.Id.txtYourEmail);

            aircraft = txtAircraft.Text;
            personal = txtEmail.Text;

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFromAandI);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfromAandI);

            btnBack.Click += (s, e) =>{
                if (B_Filing_Criteria_Activity.isVFR) //if VFR
                {
                    if (C_Time_VFR_Activity.VFRisDay) //Day
                    {
                        if (D_Syllabus_Activity.isLocal) //Local
                        {
                            StartActivity(typeof(H_VFR_Day_LocalPIC));
                        }
                        else //XC
                        {
                            StartActivity(typeof(I_VFR_Day_XCPIC));
                        }
                    }
                    else if (C_Time_VFR_Activity.VFRisDual) //Dual
                    {
                        if (D_Syllabus_Activity.isLocal) //Local
                        {
                            if (J_VFR_Dual_Local2.time == 0)
                            {
                                StartActivity(typeof(J_VFR_Dual_Local3Day));
                            }
                            else
                            {
                                StartActivity(typeof(J_VFR_Dual_Local4Night));
                            }

                        }
                        else //XC
                        {
                            StartActivity(typeof(K_VFR_Dual_XC10));
                        }
                    }
                    else //Night
                    {
                        if (D_Syllabus_Activity.isLocal) //Local
                        {
                            StartActivity(typeof(L_VFR_Night_Local4));
                        }
                        else //XC
                        {
                            StartActivity(typeof(M_VFR_Night_XCA10));
                        }
                    }
                }
                else //IFR
                {
                    if (C_Time_IFR_Activity.IFRisDual) //Dual
                    {
                        if (D_Syllabus_Activity.isLocal) //Local
                        {
                            StartActivity(typeof(P_IFR_Dual_Local_4Alt));
                        }
                        else //XC
                        {
                            StartActivity(typeof(Q_IFR_Dual_XC_8Alternate));
                        }
                    }
                    else //Night
                    {
                        if (D_Syllabus_Activity.isLocal) //Local
                        {
                            StartActivity(typeof(N_IFR_Day_Local_PIC));
                        }
                        else //XC
                        {
                            StartActivity(typeof(O_IFR_Day_XC_5PIC));
                        }
                    }
                }
            };

            btnNext.Click += (s, e) => {
                StartActivity(typeof(Z_Risk_Summary));
            };
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            if (instructor.Equals("Tom Arington"))
            {
                email = "tarington@unomaha.edu";
            }
            else if (instructor.Equals("Jim Beyers"))
            {
                email = "jimbeyer34@gmail.com";
            }
            else if (instructor.Equals("Nick Bolander"))
            {
                email = "bolandernb@gmail.com";
            }
            else if (instructor.Equals("Eric Busskohl"))
            {
                email = "ebusskohl23@gmail.com";
            }
            else if (instructor.Equals("Thomas Christoffersen"))
            {
                email = "thchristoffersen@gmai.com";
            }
            else if (instructor.Equals("Benji Cunningham"))
            {
                email = "benjicunningham05@gmail.com";
            }
            else if (instructor.Equals("Steve Dethlefs"))
            {
                email = "sdethlefs22@gmail.com";
            }
            else if (instructor.Equals("Ken Green"))
            {
                email = "ksgreen54@yahoo.com";
            }
            else if (instructor.Equals("Joe Gustafson"))
            {
                email = "joeaugustafson68112@gmail.com";
            }
            else if (instructor.Equals("David Haller"))
            {
                email = "David.Haller@airmethods.com";
            }
            else if (instructor.Equals("Adam Liston"))
            {
                email = "ajiliston08@gmail.com";
            }
            else if (instructor.Equals("Nick Lynam"))
            {
                email = "nlynam94@gmail.com";
            }
            else if (instructor.Equals("Dan Manning"))
            {
                email = "dmanning@unomaha.edu";
            }
            else if (instructor.Equals("Ted Manos"))
            {
                email = "tmanos@unomaha.edu";
            }
            else if (instructor.Equals("Steve Michael"))
            {
                email = "sbmichael@cox.net";
            }
            else if (instructor.Equals("Brandon Perkins"))
            {
                email = "bperkins@unomaha.edu";
            }
            else if (instructor.Equals("Will Powers"))
            {
                email = "willpowers77@gmail.com";
            }
            else if (instructor.Equals("Tony Reedy"))
            {
                email = "anthonyreedy@msn.com";
            }
            else if (instructor.Equals("Ben Reher"))
            {
                email = "breher865@gmail.com";
            }
            else if (instructor.Equals("Joel Rourke"))
            {
                email = "rourke.joel@gmail.com";
            }
            else if (instructor.Equals("John Rued"))
            {
                email = "johnrued@gmail.com";
            }
            else if (instructor.Equals("Tiernan Siems"))
            {
                email = "tiernansiems@hotmail.com";
            }
            else if (instructor.Equals("Mark Van Pelt"))
            {
                email = "imvp@cox.net";
            }
            else if (instructor.Equals("Bryce Vezner"))
            {
                email = "brycevezner44@gmail.com";
            }
            else if (instructor.Equals("Glen Weaver"))
            {
                email = "johnglenweaver@gmail.com";
            }
            else if (instructor.Equals("Joe Wendl"))
            {
                email = "jmwendl@gmail.com";
            }
            else if (instructor.Equals("Ryan Williams"))
            {
                email = "williams.ryan073@gmail.com";
            }
            else if (instructor.Equals("Mark Wunderlich"))
            {
                email = "mark1derlich@gmail.com";
            }
        }
    }

    
}