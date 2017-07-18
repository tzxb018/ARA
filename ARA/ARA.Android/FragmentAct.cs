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
    [Activity(Label = "FragmentAct", MainLauncher = true)]
    public class FragmentAct : FragmentActivity
    {
        private Fragment2 mFragment2;
        private Fragment3 mFragment3;
        private Stack<SupportFragment> mStackFragment;
        private ImageButton btnNext;
        private ImageButton btnBack;

        public int sectionNum; //int to keep track of which section
        public int questionNum; //int to keep track of which number question of the section
        public int answer; //1,2,3 -> 0 , 1 ,3 (risk)

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
            trans.Add(Resource.Id.frameLayout1, mFragment2);
            trans.Commit();

            btnNext.Click += (s, e) =>
            {
                replace();
            };
        }

        public void replace()
        {
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.frameLayout1, new Fragment3());
            ft.AddToBackStack(null);
            ft.Commit();
        }
        
        
    }
}