﻿using System;

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
    [Activity(Label = "FragmentAct", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, MainLauncher = true)]
    public class N_IFR_Day_Local_Home : FragmentActivity
    {
        private Fragment2 mFragment2;
        private Fragment3 mFragment3;
        private Stack<SupportFragment> mStackFragment;
        private ImageButton btnNext;
        private ImageButton btnBack;
        private SupportFragment mCurrent;

        public int nav; //naviagates through fragments
        public int questionNum; //int to keep track of which number question of the section
        public int answer; //1,2,3 -> 0 , 1 ,3 (risk)
        private int interval; //amount of how many questoins were

        public static int HomeRisk; //indivdual risks for IFR day local       

        public static string JSON_ARRAY = "IFR_Day_Local_Home.json";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.fragmentHolder);   

            btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFragment);
            btnBack = FindViewById<ImageButton>(Resource.Id.btnBackFragment);

            mFragment2 = new Fragment2();
            mFragment3 = new Fragment3();
            mStackFragment = new Stack<SupportFragment>();
            

            var trans = SupportFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.frameLayout1, mFragment3);
            mCurrent = mFragment3;
            trans.Commit();

            Bundle bundle = new Bundle();
            bundle.PutString("JSON Location", JSON_ARRAY);
            bundle.PutInt("Question Start", questionNum);

            Android.App.FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            mFragment3.Arguments = bundle;
            mFragment2.Arguments = bundle;
            btnNext.Click += (s, e) =>
            {
                nav++;

                if (mCurrent.Equals(mFragment2)) //determining question
                {
                    questionNum += 2;
                    replace3();

                    bundle = new Bundle();
                    bundle.PutString("JSON Location", JSON_ARRAY);
                    bundle.PutInt("Question Start", questionNum);

                    fragmentTransaction = FragmentManager.BeginTransaction();
                }
                else
                {
                    questionNum += 3;
                    replace2();

                     bundle = new Bundle();
                    bundle.PutString("JSON Location", JSON_ARRAY);
                    bundle.PutInt("Question Start", questionNum);

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

                    questionNum -= 2;

                    bundle = new Bundle();
                    bundle.PutString("JSON Location", JSON_ARRAY);
                    bundle.PutInt("Question Start", questionNum);

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
        
        
    }
}