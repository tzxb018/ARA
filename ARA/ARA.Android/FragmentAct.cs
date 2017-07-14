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

namespace ARA.Droid
{
    [Activity(Label = "FragmentAct", MainLauncher = true)]
    public class FragmentAct : FragmentActivity
    {
        private Fragment2 mFragment2;
        private Fragment3 mFragment3;
        private Stack<SupportFragment> mStackFragment;
        private Button fragButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.fragmentHolder);

            fragButton = FindViewById<Button>(Resource.Id.fragButton);

            mFragment2 = new Fragment2();
            mFragment3 = new Fragment3();
            mStackFragment = new Stack<SupportFragment>();

            var trans = SupportFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.frameLayout1, mFragment2);
            trans.Commit();

            fragButton.Click += (s, e) =>
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