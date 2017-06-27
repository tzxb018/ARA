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
using static Android.App.DatePickerDialog;

namespace ARA.Droid
{
    [Activity(Label = "Personal Information - 5 of 5")]
    public class E_Personal_Information : Activity,IOnDateSetListener
    {
        private const int DATE_DIALOG = 1;
        private int year = DateTime.Now.Year, month = DateTime.Now.Month - 1, day = DateTime.Now.Day;
        public static int min = 00, hour = 00, sharableYear, sharableMonth, sharableDay;
        public static String first = null , last = null;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.e_Personal_Info);

            var submit = FindViewById<Button>(Resource.Id.btnSubmit);
            var back = FindViewById<ImageButton>(Resource.Id.btnBackFromPersonalInfo);
            var date = FindViewById<ImageButton>(Resource.Id.btnSelectDate);
            var txtTimeHour = FindViewById<EditText>(Resource.Id.txtHour);
            var txtTimeMin = FindViewById<EditText>(Resource.Id.txtMinute);
            var txtfirstName = FindViewById<EditText>(Resource.Id.txtFirstName);
            var txtlastName = FindViewById<EditText>(Resource.Id.txtLastName);
            var txtDate = FindViewById<TextView>(Resource.Id.txtDateView);


            //default values (if this hasnt been filled out yet) if values have been filled out, the values should be saved 
            if (sharableDay != 0 && sharableMonth != 0 && sharableYear != 0)
            {
                txtDate.Text = (sharableMonth + 1) + "/" + sharableDay + "/" + sharableYear; 
            }

            if (hour == 0)
            {
                txtTimeHour.Text = "00";
            }
            else
            {
                txtTimeHour.Text = hour.ToString("00"); //format to have to two places
            }

            if (min == 0)
            {
                txtTimeMin.Text = "00";
            }
            else
            {
                txtTimeMin.Text = min.ToString("00"); //format to have to two places
            }

            if (!(String.IsNullOrEmpty(first)))
            {
                txtfirstName.Text = first;
            }

            if (!(String.IsNullOrEmpty(last)))
            {
                txtlastName.Text = last;
            }

            //when text values are changed
            txtTimeHour.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                int testHour;
                if (Int32.TryParse(txtTimeHour.Text, out testHour))
                {
                    if (testHour >= 0 && testHour < 24)
                        hour = testHour;
                    else
                    {
                        AlertDialog.Builder alertHour = new AlertDialog.Builder(this);
                        alertHour.SetTitle("Alert");
                        alertHour.SetMessage("Enter a valid hour (0 - 23)");
                        alertHour.SetNeutralButton("OK", delegate
                        {
                            alertHour.Dispose();
                        });
                        alertHour.Show();
                        txtTimeHour.Text = "00"; //sets back to original hour of 00
                        hour = 0;
                    }
                }
                       
            };
            txtTimeMin.AfterTextChanged += (s,e) =>
            {
                int testMin;
                if (Int32.TryParse(txtTimeMin.Text, out testMin))
                {
                    if (testMin >= 0 && testMin < 60)
                        min = testMin;
                    else
                    {
                        AlertDialog.Builder alertMin = new AlertDialog.Builder(this);
                        alertMin.SetTitle("Alert");
                        alertMin.SetMessage("Enter a valid minute (0 - 60)");
                        alertMin.SetNeutralButton("OK", delegate
                        {
                            alertMin.Dispose();
                        });
                        alertMin.Show();
                        txtTimeMin.Text = "00";
                        min = 0;
                    }
                }
            };
            
            txtfirstName.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                first = txtfirstName.Text;
            };
            txtlastName.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                last = txtlastName.Text;
            };


            back.Click += delegate
            {
                StartActivity(typeof(D_Syllabus_Activity));
            };

            date.Click += delegate
            {
                ShowDialog(DATE_DIALOG);
            };


        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            this.year = year;
            this.month = dayOfMonth;
            this.day = dayOfMonth;

            var dateDisplay = FindViewById<TextView>(Resource.Id.txtDateView);

            dateDisplay.Text = (month + 1) + "/" + day + "/" + year;

            sharableYear = year;
            sharableMonth = month;
            sharableDay = day;

        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch(id)
            {
                case DATE_DIALOG:
                    {
                        return new DatePickerDialog(this, this, year, month, day);
                    }
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}