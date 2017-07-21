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
using Newtonsoft.Json;
using System.IO;
using Android.Content.Res;

namespace ARA.Droid.Fragments
{
    public class Fragment2 : Android.Support.V4.App.Fragment
    {
        private ImageButton btnNext;
        private ImageButton btnBack;
        private TextView q1;
        private TextView q2;
        private Button ans11;
        private Button ans12;
        private Button ans13;
        private Button ans21;
        private Button ans22;
        private Button ans23;
        private TextView ans1;
        private TextView ans2;

        public static int risk1, risk2;

        private OnFragmentInteractionListener mListener;

        public Fragment2()
        {

        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Layoutfragment2, container, false);

            String stringData = this.Arguments.GetString("JSON Location");
            int questionNum = this.Arguments.GetInt("Question Start");
            string riskType = this.Arguments.GetString("Risk");
            int currRisk = Arguments.GetInt("Current Risk");
            int low = Arguments.GetInt("low");
            int med = Arguments.GetInt("med");

            var stream = Application.Context.Assets.Open(stringData);

            StreamReader sr = new StreamReader(stream);
            string jsonText = sr.ReadToEnd();

            RootObject result = JsonConvert.DeserializeObject<RootObject>(jsonText);

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

            q1.Text = result.IFR_Day_Local_Questions_Home_Airfield[questionNum][0];
            ans11.Text = result.IFR_Day_Local_Questions_Home_Airfield[questionNum][1];
            ans12.Text = result.IFR_Day_Local_Questions_Home_Airfield[questionNum][2];
            ans13.Text = result.IFR_Day_Local_Questions_Home_Airfield[questionNum][3];
            ans1.Text = "You have selected the '" + ans11.Text + "' option";

            q2.Text = result.IFR_Day_Local_Questions_Home_Airfield[questionNum + 1][0];
            ans21.Text = result.IFR_Day_Local_Questions_Home_Airfield[questionNum + 1][1];
            ans22.Text = result.IFR_Day_Local_Questions_Home_Airfield[questionNum + 1][2];
            ans23.Text = result.IFR_Day_Local_Questions_Home_Airfield[questionNum + 1][3];
            ans2.Text = "You have selected the '" + ans21.Text + "' option";

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            ans11.Touch += (s, e) =>
            {
                risk1 = 0;
                if (mListener != null)
                {
                    mListener.onFragmentInteraction(risk1);
                }

            };
            ans12.Touch += (s, e) =>
            {
                risk1 = 1;
                if (mListener != null)
                {
                    mListener.onFragmentInteraction(risk1);
                }
            };
            ans13.Touch += (s, e) =>
            {
                risk1 = 3;
                if (mListener != null)
                {
                    mListener.onFragmentInteraction(risk1);
                }
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

        public interface OnFragmentInteractionListener
        {
            void onFragmentInteraction(int riskOut);
        }
    }
}