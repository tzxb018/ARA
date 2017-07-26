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
    [Activity(Label = "Enroute", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Q_IFR_Dual_XC_4Enroute : FragmentActivity, OnFragmentInteractionListener
    {
        public static int enrouteRisk;
        public static int questionNum;
        private Stack<SupportFragment> mStackFragment;
        private ImageButton btnNext;
        private ImageButton btnBack;
        private SupportFragment mCurrent;

        public static int[] questionArray = new int[5];

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.fragmentHolder);

            btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFragment);
            btnBack = FindViewById<ImageButton>(Resource.Id.btnBackFragment);

            var mFrg1 = new Q_IFR_Dual_XC3();
            var mFrg2 = new Q_IFR_Dual_XC4();
            mStackFragment = new Stack<SupportFragment>();

            var trans = SupportFragmentManager.BeginTransaction();
            if (questionNum == 5)
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

            Bundle bundle = new Bundle(); ;

            Android.App.FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            mFrg2.Arguments = bundle;
            mFrg1.Arguments = bundle;

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskFragment);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNumFragment);

            ShortCutFunctions sc = new ShortCutFunctions();
            sc.riskShow(txtRisk, txtRiskNum, "Enroute Risk", enrouteRisk, 9, 12);

            btnNext.Click += (s, e) =>
            {
                if (mCurrent.Equals(mFrg2)) //determining question
                {
                    if (enrouteRisk > 11)
                    {
                        sc.alertShow("Enroute Risk", this);
                    }
                    else
                    {
                        StartActivity(typeof());
                        questionNum = 5;
                    }
                }
                else
                {
                    questionNum += 3;
                    replaceFragment(mFrg2);
                }
            };

            btnBack.Click += (s, e) =>
            {
                if (mCurrent.Equals(mFrg1))
                {
                    StartActivity(typeof(P_IFR_Dual_Local_3DayNight));
                }
                else
                {
                    replaceFragment(mFrg1);
                    questionNum -= 3;
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
            ShortCutFunctions sc = new ShortCutFunctions();
            try
            {
                var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskFragment);
                var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNumFragment);
                enrouteRisk = Q_IFR_Dual_XC_3EnrouteDayandNight.ceilingRisk + Q_IFR_Dual_XC3.risk1 + Q_IFR_Dual_XC3.risk2 + Q_IFR_Dual_XC3.risk5 + Q_IFR_Dual_XC4.risk4 + Q_IFR_Dual_XC4.risk5;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute Risk", enrouteRisk, 9, 12);
                questionArray[questionNum] = riskOut;
                questionArray[questionNum + 1] = riskOut2;
                questionArray[questionNum + 2] = r3;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();

            }
        }

        public void onFragmentInteraction(int riskOut, int riskOut2)
        {
            ShortCutFunctions sc = new ShortCutFunctions();
            try
            {
                var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskFragment);
                var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNumFragment);
                enrouteRisk = Q_IFR_Dual_XC_3EnrouteDayandNight.ceilingRisk + Q_IFR_Dual_XC3.risk1 + Q_IFR_Dual_XC3.risk2 + Q_IFR_Dual_XC3.risk5 + Q_IFR_Dual_XC4.risk4 + Q_IFR_Dual_XC4.risk5;
                sc.riskShow(txtRisk, txtRiskNum, "Enroute Risk", enrouteRisk, 9, 12);
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