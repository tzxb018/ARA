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
    public class O_IFR_Day_XC_4Alternate : FragmentActivity, OnFragmentInteractionListener 
    {
        private O_IFR_Day_XC7 mFrg1;
        private O_IFR_Day_XC8 mFrg2;
        private Stack<SupportFragment> mStackFragment;
        private ImageButton btnNext;
        private ImageButton btnBack;
        private SupportFragment mCurrent;

        public static int questionNum; //int to keep track of which number question of the section

        public static int AltRisk, r1, r2; //indivdual risks for IFR day local       

        public static string RISK_TYPE = "Alternate Risk";

        public static int[] questionArray = new int[6];

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.fragmentHolder);   

            btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFragment);
            btnBack = FindViewById<ImageButton>(Resource.Id.btnBackFragment);

            mFrg1 = new O_IFR_Day_XC7();
            mFrg2 = new O_IFR_Day_XC8();
            mStackFragment = new Stack<SupportFragment>();

            var trans = SupportFragmentManager.BeginTransaction();
            if (questionNum == 6)
            {
                mCurrent = mFrg2;
                questionNum = 3;
            }
            else
            {
                questionNum = 0;
                mCurrent = mFrg1;
            }
            trans.Add(Resource.Id.frameLayout1, mCurrent);
            trans.Commit();

            Bundle bundle = new Bundle();
            bundle.PutString("Risk", RISK_TYPE);

            Android.App.FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            mFrg2.Arguments = bundle;
            mFrg1.Arguments = bundle;            

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskFragment);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNumFragment);

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", AltRisk, 9, 12);


            btnNext.Click += (s, e) =>
            {
                if (mCurrent.Equals(mFrg2)) //determining question
                {
                    if (AltRisk > 11)
                    {
                        sc.alertShow("Alternate Risk", this);
                    }
                    else
                    {
                        StartActivity(typeof(O_IFR_Day_XC_5PIC));
                        questionNum = 6;

                    }
                }
                else
                {
                    questionNum += 3;
                    replaceFragment(mFrg2);

                    bundle = new Bundle();
                    fragmentTransaction = FragmentManager.BeginTransaction();
                }
            };

            btnBack.Click += (s, e) =>
            {
                if (mCurrent.Equals(mFrg1))
                {
                    StartActivity(typeof(O_IFR_Day_XC_3Destination));
                }
                else
                {
                    questionNum -= 3;
                    replaceFragment(mFrg1);
                    
                    bundle = new Bundle();
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
                sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", AltRisk, 9, 12);
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
                AltRisk = O_IFR_Day_XC7.risk1 + O_IFR_Day_XC7.risk2 + O_IFR_Day_XC7.risk3 + O_IFR_Day_XC8.risk1 + O_IFR_Day_XC8.risk2 + O_IFR_Day_XC8.risk3;
                sc.riskShow(txtRisk, txtRiskNum, "Alternate Risk", AltRisk, 9, 12);
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