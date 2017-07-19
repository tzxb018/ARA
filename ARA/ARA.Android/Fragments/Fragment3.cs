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
    public class Fragment3 : Android.Support.V4.App.Fragment
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

            N_IFR_Day_Local frg = (N_IFR_Day_Local)Activity;

            var stream = Android.App.Application.Context.Assets.Open("IFR_Day_Local2.json");

            StreamReader sr = new StreamReader(stream);
            string jsonText = sr.ReadToEnd();

            Root result = JsonConvert.DeserializeObject<Root>(jsonText);

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

            q1.Text = result.IFR_Day_Local_Questions[frg.sectionNum][frg.questionNum][1];

            return view;
        }
    }
}