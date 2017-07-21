using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ARA.Droid
{
    interface OnFragmentInteractionListener
    {
        void onFragmentInteraction(int riskOut, int riskOut2);
        void onFragmentInteraction(int riskOut, int riskOut2, int r3);

    }
}