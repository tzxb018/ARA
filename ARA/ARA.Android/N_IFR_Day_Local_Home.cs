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
    [Activity(Label = "Home Airfield", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, MainLauncher = true)]
    public class N_IFR_Day_Local_Home : FragmentActivity, OnFragmentInteractionListener 
    {
        private N_IFR_Day_Local2 mFragment2;
        private N_IFR_Day_Local1 mFragment3;
        private Stack<SupportFragment> mStackFragment;
        private ImageButton btnNext;
        private ImageButton btnBack;
        private SupportFragment mCurrent;
        private N_IFR_Day_Local3 mNextFragment;

        public int nav; //naviagates through fragments
        public static int questionNum = 0; //int to keep track of which number question of the section
        public int answer; //1,2,3 -> 0 , 1 ,3 (risk)

        public static int HomeRisk, r1, r2; //indivdual risks for IFR day local       

        public static string JSON_ARRAY = "IFR_Day_Local_Home.json";
        public static string RISK_TYPE = "Home Airfield Risk";

        public static int[] questionArray = new int[5];

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.fragmentHolder);   

            btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFragment);
            btnBack = FindViewById<ImageButton>(Resource.Id.btnBackFragment);

            mFragment2 = new N_IFR_Day_Local2();
            mFragment3 = new N_IFR_Day_Local1();
            mStackFragment = new Stack<SupportFragment>();
            mNextFragment = new N_IFR_Day_Local3();

            var trans = SupportFragmentManager.BeginTransaction();
            if (questionNum == 5)
            {
                mCurrent = mFragment2;
                questionNum = 3;
            }
            else
            {
                questionNum = 0;
                mCurrent = mFragment3;
            }
            trans.Add(Resource.Id.frameLayout1, mCurrent);
            trans.Commit();

            Bundle bundle = new Bundle();
            bundle.PutString("JSON Location", JSON_ARRAY);
            bundle.PutString("Risk", RISK_TYPE);

            Android.App.FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            mFragment3.Arguments = bundle;
            mFragment2.Arguments = bundle;            

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskFragment);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNumFragment);

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", HomeRisk, 8, 10);


            btnNext.Click += (s, e) =>
            {
                nav++;

                if (mCurrent.Equals(mFragment2)) //determining question
                {
                    questionNum = 5;

                    if (HomeRisk > 9)
                    {
                        sc.alertShow("Home Airfield Risk", this);
                    }
                    else
                        StartActivity(typeof(N_IFR_Day_Local_Alternate));
                }
                else
                {
                    questionNum += 3;
                    replace2();

                    bundle = new Bundle();
                    bundle.PutString("JSON Location", JSON_ARRAY);

                    fragmentTransaction = FragmentManager.BeginTransaction();
                }

                

                
            };

            btnBack.Click += (s, e) =>
            {
                

                if (mCurrent.Equals(mFragment3))
                {
                    StartActivity(typeof(G_Student_Human_Factors_2));
                }
                else
                {
                    replace3();

                    questionNum -= 3;

                    bundle = new Bundle();
                    bundle.PutString("JSON Location", JSON_ARRAY);

                    fragmentTransaction = FragmentManager.BeginTransaction();
                }

                
            };
        }

        
        public void replace3()
        {
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.frameLayout1, mFragment3);
            ft.AddToBackStack(null);
            mCurrent = mFragment3; 
            ft.Commit();
        }

        public void replace2()
        {
           var ft = SupportFragmentManager.BeginTransaction();
           ft.Replace(Resource.Id.frameLayout1, mFragment2);
            ft.AddToBackStack(null);
           mCurrent = mFragment2;
            ft.Commit();
        }

        public void replaceFragment(SupportFragment frg)
        {
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.frameLayout1, frg);
            ft.AddToBackStack(null);
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
                HomeRisk = r1 + r2;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", HomeRisk, 8, 10);
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
                HomeRisk = r1 + r2;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", HomeRisk, 8, 10);
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