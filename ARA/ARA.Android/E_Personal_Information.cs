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
        private int year, month, day;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.e_Personal_Info);

            var submit = FindViewById<Button>(Resource.Id.btnSubmit);
            var back = FindViewById<ImageButton>(Resource.Id.btnBackFromPersonalInfo);
            var date = FindViewById<ImageButton>(Resource.Id.btnSelectDate);
            back.Click += delegate
            {
                StartActivity(typeof(D_Syllabus_Activity));
            };

            date.Click += delegate
            {
                ShowDialog(DATE_DIALOG);
            };

            year = DateTime.Now.Year;
            month = DateTime.Now.Month - 1;
            day = DateTime.Now.Day;

        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            this.year = year;
            this.month = dayOfMonth;
            this.day = dayOfMonth;

            var dateDisplay = FindViewById<TextView>(Resource.Id.txtDateView);

            dateDisplay.Text = (month + 1) + "/" + day + "/" + year;
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