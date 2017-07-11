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
    class JSON_Class
    {
        public class FlightInformation
        {
            public bool NOTAMS { get; set; }
            public bool FBO { get; set; }
            public bool flightPlan { get; set; }

            public string flightType { get; set; } 

            public DateTime flightDate { get; set; }
            public string Name { get; set; }
        }


    }
}