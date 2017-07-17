using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ARA.Droid.Fragments
{
    public class N_IFR_Day_Local1 : Android.Support.V4.App.Fragment
    {
        public static int ceiling, vis, iap, homeRisk;

        private ImageButton btnNext;
        private ImageButton btnBack;
        private TextView q1;
        private TextView q2;
        private TextView q3;
        private Button ans11;
        private Button ans12;
        private Button ans13;
        private Button ans21;
        private Button ans22;
        private Button ans23;
        private Button ans31;
        private Button ans32;
        private Button ans33;
        private TextView ans1;
        private TextView ans2;
        private TextView ans3;
        private TextView risk;
        private TextView riskNum;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.LayoutFragment3, container, false);

            q1 = view.FindViewById<TextView>(Resource.Id.txtQuestion1);
            ans11 = view.FindViewById<Button>(Resource.Id.btnQ1C1);
            ans12 = view.FindViewById<Button>(Resource.Id.btnQ1C2);
            ans13 = view.FindViewById<Button>(Resource.Id.btnQ1C3);
            ans1 = view.FindViewById<TextView>(Resource.Id.txtAnswer1);

            q2 = view.FindViewById<TextView>(Resource.Id.txtQuestion2);
            ans21 = view.FindViewById<Button>(Resource.Id.btnQ2C1);
            ans22 = view.FindViewById<Button>(Resource.Id.btnQ2C2);
            ans23 = view.FindViewById<Button>(Resource.Id.btnQ2C3);
            ans2 = view.FindViewById<TextView>(Resource.Id.txtAnswer2);

            q3 = view.FindViewById<TextView>(Resource.Id.txtQuestion3);
            ans31 = view.FindViewById<Button>(Resource.Id.btnQ3C1);
            ans32 = view.FindViewById<Button>(Resource.Id.btnQ3C2);
            ans33 = view.FindViewById<Button>(Resource.Id.btnQ3C3);
            ans3 = view.FindViewById<TextView>(Resource.Id.txtAnswer3);

            risk = view.FindViewById<TextView>(Resource.Id.txtRiskText);
            riskNum = view.FindViewById<TextView>(Resource.Id.txtRiskNum);
            btnBack = view.FindViewById<ImageButton>(Resource.Id.btnBackfrom3);
            btnNext = view.FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);

            q1.Text = "Ceiling (Day)";
            ans11.Text = "> 3000 ft";
            ans12.Text = "2501 - 3000 ft";
            ans13.Text = "2000 - 2500 ft";
            ans1.Text = "You have selected the '" + ans11.Text + "' option.";

            q2.Text = "Visibility (Day)";
            ans21.Text = "5+ SM";
            ans22.Text = "4 SM";
            ans23.Text = "3 SM";
            ans2.Text = "You have selected the '" + ans21.Text + "' option.";

            q3.Text = "Best IAP Available";
            ans31.Text = "Precision";
            ans32.Text = "Non-Precision";
            ans33.Text = "Circling";
            ans3.Text = "You have selected the '" + ans31.Text + "' option";

            return view;

            //var next = view.FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);

            //var trans = Activity.SupportFragmentManager.BeginTransaction();
            //FragmentAct frg = new FragmentAct();

            //mFrag3 = new Fragment3();

            //next.Click += delegate
            //{
            //frg.replace(mFrag3, this);
            //   replace();
            //};
        }

        public override void OnStart()
        {
            ShortCutFunctions sc = new ShortCutFunctions();
            sc.defaultVals(ans11, ans12, ans13, ans1, ceiling);
            sc.defaultVals(ans21, ans22, ans23, ans2, vis);
            sc.defaultVals(ans31, ans32, ans33, ans3, iap);

            ans11.Touch += (s, e) =>
            {

            };
            ans12.Touch += (s, e) =>
            {

            };
            
        }




        //public void replace()
        //{

        //var ft = this.Activity.SupportFragmentManager.BeginTransaction();
        //ft.Replace(Resource.Id.frameLayout1, new Fragment3());
        //ft.AddToBackStack(null);
        //ft.Commit();
        //}

    }
}