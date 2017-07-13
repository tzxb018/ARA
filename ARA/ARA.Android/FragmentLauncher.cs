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
using ARA.Droid.Fragments;
using Android.Support.V4.App;

namespace ARA.Droid
{
    [Activity(Label = "FragmentLauncher", MainLauncher = true)]
    public class FragmentLauncher : FragmentActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.fragmentHolder);

            Fragment3 mFrag3 = new Fragment3();
            Fragment2 mFrag2 = new Fragment2();


            var trans = SupportFragmentManager.BeginTransaction();
            trans.Add(, mFrag3);
            trans.Commit();

        }
    }
}