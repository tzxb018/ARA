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
using Newtonsoft.Json;
using System.IO;
using ARA.Droid.Fragments;

namespace ARA.Droid
{
    [Activity(Label = "Home Airfield", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class P_IFR_Dual_Local_2Home : FragmentActivity, OnFragmentInteractionListener
    {
        public static int homeRisk;
        public static int questionNum;
        private Stack<SupportFragment> mStackFragment;
        private ImageButton btnNext;
        private ImageButton btnBack;
        private SupportFragment mCurrent;

        public static int[] questionArray = new int[4];

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.fragmentHolder);

            btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFragment);
            btnBack = FindViewById<ImageButton>(Resource.Id.btnBackFragment);

            var mFrg1 = new P_IFR_Dual_Local1();
            var mFrg2 = new P_IFR_Dual_Local2();
            mStackFragment = new Stack<SupportFragment>();

            var trans = SupportFragmentManager.BeginTransaction();
            if (questionNum == 4)
            {
                mCurrent = mFrg2;
                questionNum = 2;
            }
            else
            {
                questionNum = 0;
                mCurrent = mFrg1;
            }
            trans.Add(Resource.Id.frameLayout1, mCurrent);
            trans.Commit();

            Bundle bundle = new Bundle(); ;

            Android.App.FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            mFrg2.Arguments = bundle;
            mFrg1.Arguments = bundle;

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskFragment);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNumFragment);

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", homeRisk, 8, 10);

            btnNext.Click += (s, e) =>
            {
                if (mCurrent.Equals(mFrg2)) //determining question
                {
                    if (homeRisk > 9)
                    {
                        sc.alertShow("Home Airport Risk", this);
                    }
                    else
                    {
                        StartActivity(typeof(P_IFR_Dual_Local_3Alt));
                        questionNum = 4;
                    }
                }
                else
                {
                    questionNum += 2;
                    replaceFragment(mFrg2);
                }
            };

            btnBack.Click += (s, e) =>
            {
                if (mCurrent.Equals(mFrg1))
                {
                    StartActivity(typeof(P_IFR_Dual_Local_1DayNight));
                }
                else
                {
                    replaceFragment(mFrg1);
                    questionNum -= 2;
                }
            };
        }


        public void replaceFragment(SupportFragment frg)
        {
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.frameLayout1, frg);
            mCurrent = frg;
            ft.AddToBackStack(null);
            ft.Commit();
        }

        public void onFragmentInteraction(int riskOut, int riskOut2, int r3)
        {

            throw new NotImplementedException();


        }

        public void onFragmentInteraction(int riskOut, int riskOut2)
        {
            ShortCutFunctions sc = new ShortCutFunctions();
            try
            {
                var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskFragment);
                var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNumFragment);
                homeRisk = P_IFR_Dual_Local1.risk1 + P_IFR_Dual_Local1.risk2 + P_IFR_Dual_Local2.risk4 + P_IFR_Dual_Local2.risk5 + P_IFR_Dual_Local_1DayNight.timeRisk;
                sc.riskShow(txtRisk, txtRiskNum, "Home Airport Risk", homeRisk, 8, 10);
                questionArray[questionNum] = riskOut;
                questionArray[questionNum + 1] = riskOut2;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();

            }
        }
    }
}