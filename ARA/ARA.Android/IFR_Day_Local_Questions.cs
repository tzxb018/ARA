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
    class IFR_Day_Local_Questions
    {
        public class HomeAirport
        {
            public IList<string> Ceiling { get; set; }
            public IList<string> Visibility { get; set; }
            public IList<string> Best_IAP_Available { get; set; }
            public IList<string> Wind { get; set; }
            public IList<string> Xwind { get; set; }
        }

        public class Alternate
        {
            public IList<string> Ceiling { get; set; }
            public IList<string> Visibility { get; set; }
            public IList<string> Best_IAP_Available { get; set; }
            public IList<string> Wind { get; set; }
            public IList<string> Xwind { get; set; }
            public IList<string> Fuel_Remaining { get; set; }
        }

        public class PIC
        {
            public IList<string> Last_Dual_Landing { get; set; }
            public IList<string> Dual_Instrument_Approach { get; set; }
            public IList<string> IFR_Current { get; set; }
        }

        public class RootObject
        {
        public HomeAirport Home_Airport { get; set; }
        public Alternate Alternate { get; set; }
        public PIC PIC { get; set; }
        }
    }
}