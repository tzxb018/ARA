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

namespace ARA.Droid
{
    [Activity(Label = "FragmentAct", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class N_IFR_Day_Local : FragmentActivity
    {
        private Fragment2 mFragment2;
        private Fragment3 mFragment3;
        private Stack<SupportFragment> mStackFragment;
        private ImageButton btnNext;
        private ImageButton btnBack;
        private SupportFragment mCurrent;

        public int nav; //naviagates through array
        public int sectionNum; //int to keep track of which section
        public int questionNum; //int to keep track of which number question of the section
        public int answer; //1,2,3 -> 0 , 1 ,3 (risk)
        private int interval; //amount of how many questoins were added before

        public int[] FragmentLength = { 3, 2, 3, 3, 3 }; //number of questions per slide

        public static int HomeRisk, AltRisk, PICRisk; //indivdual risks for IFR day local       

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



            btnNext.Click += (s, e) =>
            {
                nav++;

                if (mCurrent.Equals(mFragment2)) //determining question
                {
                    questionNum += 2;
                    interval = 2;
                    if (sectionNum == 0 && questionNum > 4)
                    {
                        sectionNum = 1;
                        questionNum = 0;
                    }
                    else if (sectionNum == 1 && questionNum > 5)
                    {
                        sectionNum = 2;
                        questionNum = 0;
                    }
                }
                else
                {
                    questionNum += 3;
                    interval = 3;
                    if (sectionNum == 0 && questionNum > 4)
                    {
                        sectionNum = 1;
                        questionNum = 0;
                    }
                    else if (sectionNum == 1 && questionNum > 5)
                    {
                        sectionNum = 2;
                        questionNum = 0;
                    }
                }

                if (nav >= FragmentLength.Length) // go to summary
                {

                }
                else
                {
                    if (FragmentLength[nav] == 2)
                    {
                        replace2();
                    }
                    else
                    {
                        replace3();
                    }
                }

                
            };

            btnBack.Click += (s, e) =>
            {
                questionNum -= interval; 

                if (nav < 1)
                {
                    StartActivity(typeof(G_Student_Human_Factors_2));
                    nav = 0;
                }
                else
                {
                    nav--;
                    if (FragmentLength[nav] == 2)
                    {
                        replace2();
                    }
                    else
                    {
                        replace3();
                    }
                }

                
            };
        }

        public void replace3()
        {
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.frameLayout1, new Fragment3());
            ft.AddToBackStack(null);
            mCurrent = mFragment3; 
            ft.Commit();
        }

        public void replace2()
        {
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.frameLayout1, new Fragment2());
            ft.AddToBackStack(null);
            mCurrent = mFragment2;
            ft.Commit();
        }
        
        
    }
}