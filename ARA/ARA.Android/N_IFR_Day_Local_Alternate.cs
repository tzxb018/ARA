using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V4.App;
using ARA.Droid.Fragments;
using Newtonsoft.Json;
using System.IO;

namespace ARA.Droid
{
    [Activity(Label = "Alternate", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class N_IFR_Day_Local_Alternate : FragmentActivity, OnFragmentInteractionListener 
    {
        private N_IFR_Day_Local3 mFrg1;
        private N_IFR_Day_Local4 mFrg2;
        private Stack<SupportFragment> mStackFragment;
        private ImageButton btnNext;
        private ImageButton btnBack;
        private SupportFragment mCurrent;

        public static int questionNum; //int to keep track of which number question of the section

        public static int AltRisk, r1, r2; //indivdual risks for IFR day local       

        public static string JSON_ARRAY = "IFR_Day_Local_Alternate.json";
        public static string RISK_TYPE = "Alternate Risk";

        public static int[] questionArray = new int[6];

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.fragmentHolder);   

            btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFragment);
            btnBack = FindViewById<ImageButton>(Resource.Id.btnBackFragment);

            mFrg1 = new N_IFR_Day_Local3();
            mFrg2 = new N_IFR_Day_Local4();
            mStackFragment = new Stack<SupportFragment>();

            var trans = SupportFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.frameLayout1, mFrg1);
            mCurrent = mFrg1;
            trans.Commit();

            Bundle bundle = new Bundle();
            bundle.PutString("JSON Location", JSON_ARRAY);
            bundle.PutString("Risk", RISK_TYPE);

            Android.App.FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            mFrg2.Arguments = bundle;
            mFrg1.Arguments = bundle;            

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskFragment);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNumFragment);

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", AltRisk, 7, 9);


            btnNext.Click += (s, e) =>
            {
                if (mCurrent.Equals(mFrg2)) //determining question
                {
            
                    //StartActivity(typeof());
                }
                else
                {
                    questionNum += 3;
                    replaceFragment(mFrg2);

                    bundle = new Bundle();
                    bundle.PutString("JSON Location", JSON_ARRAY);
                    fragmentTransaction = FragmentManager.BeginTransaction();
                }
            };

            btnBack.Click += (s, e) =>
            {
                if (mCurrent.Equals(mFrg1))
                {
                    StartActivity(typeof(N_IFR_Day_Local_Home));
                }
                else
                {
                    questionNum -= 3;
                    replaceFragment(mFrg1);
                    
                    bundle = new Bundle();
                    bundle.PutString("JSON Location", JSON_ARRAY);
                    fragmentTransaction = FragmentManager.BeginTransaction();
                }
            };
        }

        public void replaceFragment(SupportFragment frg)
        {
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.frameLayout1, frg);
            ft.AddToBackStack(null);
            mCurrent = frg;
            ft.Commit();
        }

        public void onFragmentInteraction(int riskOut, int riskOut2)
        {
            ShortCutFunctions sc = new ShortCutFunctions();
            try
            {
                r1 = riskOut + riskOut2;
                var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskFragment);
                var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNumFragment);
                AltRisk = r1 + r2;
                sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", AltRisk, 7, 9);
                questionArray[questionNum] = riskOut;
                questionArray[questionNum + 1] = riskOut2;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();

            }
        }

        public void onFragmentInteraction(int riskOut, int riskOut2, int r3)
        {
            ShortCutFunctions sc = new ShortCutFunctions();
            try
            {
                r2 = riskOut + riskOut2 + r3;
                var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskFragment);
                var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNumFragment);
                AltRisk = N_IFR_Day_Local3.risk1 + N_IFR_Day_Local3.risk2 + N_IFR_Day_Local3.risk3 + N_IFR_Day_Local4.risk4 + N_IFR_Day_Local4.risk5 + N_IFR_Day_Local4.risk6;
                sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", AltRisk, 7, 9);
                questionArray[questionNum] = riskOut;
                questionArray[questionNum + 1] = riskOut2;
                questionArray[questionNum + 2] = r3;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();

            }
        }


    }
}