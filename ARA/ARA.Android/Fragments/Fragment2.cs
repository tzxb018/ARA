using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ARA.Droid.Fragments
{
    public class Fragment2 : Android.Support.V4.App.Fragment
    {
        private Fragment2 mFrag2;
        private Fragment3 mFrag3;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.h_Layout2, container, false);
            var next = view.FindViewById<ImageButton>(Resource.Id.btnContinueFrom2);

            var trans = Activity.SupportFragmentManager.BeginTransaction();
            FragmentAct frg = new FragmentAct();

            mFrag3 = new Fragment3();

            next.Click += delegate
            {
                //frg.replace(mFrag3, this);
                replace();
            };
            return view;
        }

        public void replace()
        {
           
            var ft = this.Activity.SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.frameLayout1, new Fragment3());
            ft.AddToBackStack(null);
            ft.Commit();
        }
    }
}