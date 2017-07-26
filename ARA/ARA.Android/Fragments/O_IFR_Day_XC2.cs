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
using System.IO;
using Newtonsoft.Json;

namespace ARA.Droid.Fragments
{
    public class O_IFR_Day_XC2 : Android.Support.V4.App.Fragment
    {
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

        public static int risk4, risk5, risk6;

        private OnFragmentInteractionListener mListener;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Layoutfragment2, container, false);

            q1 = view.FindViewById<TextView>(Resource.Id.txt2Question1);
            ans11 = view.FindViewById<Button>(Resource.Id.btn2Q1C1);
            ans12 = view.FindViewById<Button>(Resource.Id.btn2Q1C2);
            ans13 = view.FindViewById<Button>(Resource.Id.btn2Q1C3);
            ans1 = view.FindViewById<TextView>(Resource.Id.txt2Answer1);

            q2 = view.FindViewById<TextView>(Resource.Id.txt2Question2);
            ans21 = view.FindViewById<Button>(Resource.Id.btn2Q2C1);
            ans22 = view.FindViewById<Button>(Resource.Id.btn2Q2C2);
            ans23 = view.FindViewById<Button>(Resource.Id.btn2Q2C3);
            ans2 = view.FindViewById<TextView>(Resource.Id.txt2Answer2);

            btnBack = view.FindViewById<ImageButton>(Resource.Id.btnBackfrom2);
            btnNext = view.FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);

            ShortCutFunctions sc = new ShortCutFunctions();

            sc.defaultVals(ans11, ans12, ans13, ans1, O_IFR_Day_XC_1Departure.questionArray[O_IFR_Day_XC_1Departure.questionNum]);
            sc.defaultVals(ans21, ans22, ans23, ans2, O_IFR_Day_XC_1Departure.questionArray[O_IFR_Day_XC_1Departure.questionNum + 1]);

            /*
            q1.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum][0];
            ans11.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum][1];
            ans12.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum][2];
            ans13.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum][3];
            ans1.Text = "You have selected the '" + ans11.Text + "' option";

            q2.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 1][0];
            ans21.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 1][1];
            ans22.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 1][2];
            ans23.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 1][3];
            ans2.Text = "You have selected the '" + ans21.Text + "' option";

            q3.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 2][0];
            ans31.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 2][1];
            ans32.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 2][2];
            ans33.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 2][3];
            ans3.Text = "You have selected the '" + ans31.Text + "' option"; */

            q1.Text = "Wind";
            ans11.Text = "0 - 15 kts";
            ans12.Text = "16 - 20 kts";
            ans13.Text = "21 - 25 kts";

            q2.Text = "Xwind";
            ans21.Text = "0 - 5 kts";
            ans22.Text = "6 - 10 kts";
            ans23.Text = "11 - 15 kts";

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            ShortCutFunctions sc = new ShortCutFunctions();

            ans11.Touch += (s, e) =>
            {
                risk4 = 0;
                mListener.onFragmentInteraction(risk4, risk5);
                sc.button1Pressed(ans11, ans12, ans13, ans1);
            };
            ans12.Touch += (s, e) =>
            {
                risk4 = 1;
                mListener.onFragmentInteraction(risk4, risk5);
                sc.button2Pressed(ans11, ans12, ans13, ans1);
            };
            ans13.Touch += (s, e) =>
            {
                risk4 = 3;
                mListener.onFragmentInteraction(risk4, risk5);
                sc.button3Pressed(ans11, ans12, ans13, ans1);
            };

            ans21.Touch += (s, e) =>
            {
                risk5 = 0;
                mListener.onFragmentInteraction(risk4, risk5);
                sc.button1Pressed(ans21, ans22, ans23, ans2);
            };
            ans22.Touch += (s, e) =>
            {
                risk5 = 1;
                mListener.onFragmentInteraction(risk4, risk5);
                sc.button2Pressed(ans21, ans22, ans23, ans2);
            };
            ans23.Touch += (s, e) =>
            {
                risk5 = 3;
                mListener.onFragmentInteraction(risk4, risk5);
                sc.button3Pressed(ans21, ans22, ans23, ans2);
            };

            

        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);

            try
            {
                mListener = (OnFragmentInteractionListener)Activity;
            }
            catch (Exception ex) { }
        }


        public void onFragmentInteraction(int riskOut, int riskOut2)
        {

        }

        public void onFragmentInteraction(int riskOut, int riskOut2, int r3)
        {
        }
    }
}