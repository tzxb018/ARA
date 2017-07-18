using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ARA.Droid
{
        public class HomeAirport
        {
            [JsonProperty("Ceiling (Day)")]
            public IList<string> Ceiling { get; set; }
            [JsonProperty("Visibility (Day)")]
            public IList<string> Visibility { get; set; }
            [JsonProperty("Best IAP Available")]
            public IList<string> Best_IAP_Available { get; set; }
            [JsonProperty("Wind")]
            public IList<string> Wind { get; set; }
            [JsonProperty("Xwind")]
            public IList<string> Xwind { get; set; }
        }

        public class Alternate
        {
            [JsonProperty("Ceiling (Day)")]
            public IList<string> Ceiling { get; set; }
            [JsonProperty("Visibility (Day)")]
            public IList<string> Visibility { get; set; }
            [JsonProperty("Best IAP Available")]
            public IList<string> Best_IAP_Available { get; set; }
            [JsonProperty("Wind")]
            public IList<string> Wind { get; set; }
            [JsonProperty("Xwind")]
            public IList<string> Xwind { get; set; }
            [JsonProperty("Fuel Remaining")]
            public IList<string> Fuel_Remaining { get; set; }
        }

        public class PIC
        {
            [JsonProperty("Last Dual Landing")]
            public IList<string> Last_Dual_Landing { get; set; }
            [JsonProperty("Dual Instrument Approach")]
            public IList<string> Dual_Instrument_Approach { get; set; }
            [JsonProperty("IFR Current")]
            public IList<string> IFR_Current { get; set; }
        }

        public class RootObject
        {
        [JsonProperty("HomeAirport")]
        public HomeAirport HomeAirport { get; set; }
        [JsonProperty("Alternate")]
        public Alternate Alternate { get; set; }
        [JsonProperty("PIC")]
        public PIC PIC { get; set; }
        }
}