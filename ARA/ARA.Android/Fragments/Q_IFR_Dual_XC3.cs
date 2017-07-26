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
    public class Q_IFR_Dual_XC3 : Android.Support.V4.App.Fragment
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

        public static int risk1, risk2, risk5;

        private OnFragmentInteractionListener mListener;

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

            btnBack = view.FindViewById<ImageButton>(Resource.Id.btnBackfrom3);
            btnNext = view.FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);

            ShortCutFunctions sc = new ShortCutFunctions();



            /*
            q1.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum][0];
            ans11.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum][1];
            ans12.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum][2];
            ans13.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum][3];

            q2.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 1][0];
            ans21.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 1][1];
            ans22.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 1][2];
            ans23.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 1][3];

            q3.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 2][0];
            ans31.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 2][1];
            ans32.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 2][2];
            ans33.Text = result.IFR_Day_Local_Questions_Alternate[N_IFR_Day_Local_Alternate.questionNum + 2][3]; */

            q1.Text = "Visibility";
            ans11.Text = "4+ SM";
            ans12.Text = "3 SM";
            ans13.Text = "2 SM";

            q2.Text = "Time Enroute";
            ans21.Text = "< 45 min";
            ans22.Text = "45 - 90 min";
            ans23.Text = "> 90 min";

            q3.Text = "Thunderstorm Probability";
            ans31.Text = "0 - 10%";
            ans32.Text = "11 - 29%";
            ans33.Text = "> 30%";

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            ShortCutFunctions sc = new ShortCutFunctions();

            sc.defaultVals(ans11, ans12, ans13, ans1, Q_IFR_Dual_XC_4Enroute.questionArray[Q_IFR_Dual_XC_4Enroute.questionNum]);
            sc.defaultVals(ans21, ans22, ans23, ans2, Q_IFR_Dual_XC_4Enroute.questionArray[Q_IFR_Dual_XC_4Enroute.questionNum + 1]);
            sc.defaultVals(ans31, ans32, ans33, ans3, Q_IFR_Dual_XC_4Enroute.questionArray[Q_IFR_Dual_XC_4Enroute.questionNum + 2]);

            ans11.Touch += (s, e) =>
            {
                risk1 = 0;
                mListener.onFragmentInteraction(risk1, risk2, risk1);
                sc.button1Pressed(ans11, ans12, ans13, ans1);
            };
            ans12.Touch += (s, e) =>
            {
                risk1 = 1;
                mListener.onFragmentInteraction(risk1, risk2, risk1);
                sc.button2Pressed(ans11, ans12, ans13, ans1);
            };
            ans13.Touch += (s, e) =>
            {
                risk1 = 3;
                mListener.onFragmentInteraction(risk1, risk2, risk1);
                sc.button3Pressed(ans11, ans12, ans13, ans1);
            };

            ans21.Touch += (s, e) =>
            {
                risk2 = 0;
                mListener.onFragmentInteraction(risk1, risk2, risk1);
                sc.button1Pressed(ans21, ans22, ans23, ans2);
            };
            ans22.Touch += (s, e) =>
            {
                risk2 = 1;
                mListener.onFragmentInteraction(risk1, risk2, risk1);
                sc.button2Pressed(ans21, ans22, ans23, ans2);
            };
            ans23.Touch += (s, e) =>
            {
                risk2 = 3;
                mListener.onFragmentInteraction(risk1, risk2, risk1);
                sc.button3Pressed(ans21, ans22, ans23, ans2);
            };

            ans31.Touch += (s, e) =>
            {
                risk1 = 0;
                mListener.onFragmentInteraction(risk1, risk2, risk1);
                sc.button1Pressed(ans31, ans32, ans33, ans3);
            };
            ans32.Touch += (s, e) =>
            {
                risk1 = 1;
                mListener.onFragmentInteraction(risk1, risk2, risk1);
                sc.button2Pressed(ans31, ans32, ans33, ans3);
            };
            ans33.Touch += (s, e) =>
            {
                risk1 = 3;
                mListener.onFragmentInteraction(risk1, risk2, risk1);
                sc.button3Pressed(ans31, ans32, ans33, ans3);
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