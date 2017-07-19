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
    [Activity(Label = "Home Airfield - 1 of 2", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class J_VFR_Dual_Local1 : Activity
    {
        public static int windPime;
        public static int windComm;
        public static int windCFI;
        public static int homeRisk;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.h_Layout_3);

            var lblWindPIME = FindViewById<TextView>(Resource.Id.txtQuestion1);
            var btn0to15 = FindViewById<Button>(Resource.Id.btnQ1C1);
            var btn16to20 = FindViewById<Button>(Resource.Id.btnQ1C2);
            var btn21to25 = FindViewById<Button>(Resource.Id.btnQ1C3);
            var txtWindPIME = FindViewById<TextView>(Resource.Id.txtAnswer1);

            var lblWindComm = FindViewById<TextView>(Resource.Id.txtQuestion2);
            var btn0to15Comm = FindViewById<Button>(Resource.Id.btnQ2C1);
            var btn16to23 = FindViewById<Button>(Resource.Id.btnQ2C2);
            var btn24to30 = FindViewById<Button>(Resource.Id.btnQ2C3);
            var txtWindComm = FindViewById<TextView>(Resource.Id.txtAnswer2);

            var lblWindCFI = FindViewById<TextView>(Resource.Id.txtQuestion3);
            var btn0to15CFI = FindViewById<Button>(Resource.Id.btnQ3C1);
            var btn16to25 = FindViewById<Button>(Resource.Id.btnQ3C2);
            var btn26to35 = FindViewById<Button>(Resource.Id.btnQ3C3);
            var txtWindCFI = FindViewById<TextView>(Resource.Id.txtAnswer3);

            var txtRisk = FindViewById<TextView>(Resource.Id.txtRiskText);
            var txtRiskNum = FindViewById<TextView>(Resource.Id.txtRiskNum);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfrom3);
            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFrom3);

            lblWindPIME.Text = "Wind (P, I, ME)";
            btn0to15.Text = "0 - 15 kts";
            btn16to20.Text = "16 - 20 kts";
            btn21to25.Text = "21 - 25 kts";

            lblWindComm.Text = "Wind (Comm)";
            btn0to15Comm.Text = "0 - 15 kts";
            btn16to23.Text = "16 - 23 kts";
            btn24to30.Text = "24 - 30 kts";

            lblWindCFI.Text = "Wind (CFI)";
            btn0to15CFI.Text = "0 - 15 kts";
            btn16to25.Text = "16 - 25 kts";
            btn26to35.Text = "26 - 35 kts";

            ShortCutFunctions class1 = new ShortCutFunctions();
            class1.defaultVals(btn0to15, btn16to20, btn21to25, txtWindPIME, windPime);
            class1.defaultVals(btn0to15Comm, btn16to23, btn24to30, txtWindComm, windComm);
            class1.defaultVals(btn0to15CFI, btn16to25, btn26to35, txtWindCFI, windCFI);

            if (J_VFR_Dual_Local2.time == 0)
            {
                homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;

            }
            else if (J_VFR_Dual_Local2.time == 1)
            {
                homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
            }
            else
            {
                homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;

            }
            class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", homeRisk, 7, 9);

            btn0to15.Touch += (s,e) =>
            {
                windPime = class1.button1Pressed(btn0to15, btn16to20, btn21to25, txtWindPIME);
                if (J_VFR_Dual_Local2.time == 0)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;

                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", homeRisk, 7, 9);
            };
            btn16to20.Touch += (s,e) =>
            {
                windPime = class1.button2Pressed(btn0to15, btn16to20, btn21to25, txtWindPIME);
                if (J_VFR_Dual_Local2.time == 0)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;

                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", homeRisk, 7, 9);
            };
            btn21to25.Touch += (s,e) =>
            {
                windPime = class1.button3Pressed(btn0to15, btn16to20, btn21to25, txtWindPIME);
                if (J_VFR_Dual_Local2.time == 0)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;

                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", homeRisk, 7, 9);
            };

            btn0to15Comm.Touch += (s,e) =>
            {
                windComm = class1.button1Pressed(btn0to15Comm, btn16to23, btn24to30, txtWindComm);
                if (J_VFR_Dual_Local2.time == 0)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;

                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", homeRisk, 7, 9);
            };
            btn16to23.Touch += (s,e) =>
            {
                windComm = class1.button2Pressed(btn0to15Comm, btn16to23, btn24to30, txtWindComm);
                if (J_VFR_Dual_Local2.time == 0)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;

                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", homeRisk, 7, 9);
            };
            btn24to30.Touch += (s,e) =>
            {
                windComm = class1.button3Pressed(btn0to15Comm, btn16to23, btn24to30, txtWindComm);
                if (J_VFR_Dual_Local2.time == 0)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;

                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", homeRisk, 7, 9);
            };

            btn0to15CFI.Touch += (s,e) =>
            {
                windCFI = class1.button1Pressed(btn0to15CFI, btn16to25, btn26to35, txtWindCFI);
                if (J_VFR_Dual_Local2.time == 0)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;

                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", homeRisk, 7, 9);
            };
            btn16to25.Touch += (s,e) =>
            {
                windCFI = class1.button2Pressed(btn0to15CFI, btn16to25, btn26to35, txtWindCFI);
                if (J_VFR_Dual_Local2.time == 0)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;

                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", homeRisk, 7, 9);
            };
            btn26to35.Touch += (s,e) =>
            {
                windCFI = class1.button3Pressed(btn0to15CFI, btn16to25, btn26to35, txtWindCFI);
                if (J_VFR_Dual_Local2.time == 0)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local3Day.ceilingDay + J_VFR_Dual_Local3Day.visDay;

                }
                else if (J_VFR_Dual_Local2.time == 1)
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis;
                }
                else
                {
                    homeRisk = windCFI + windComm + windPime + J_VFR_Dual_Local2.xwind + J_VFR_Dual_Local4Night.nightCeiling + J_VFR_Dual_Local4Night.nightVis + J_VFR_Dual_Local3Day.visDay + J_VFR_Dual_Local3Day.ceilingDay;

                }
                class1.riskShow(txtRisk, txtRiskNum, "Home Airfield Risk", homeRisk, 7, 9);
            };

            btnBack.Touch += (s,e) =>
            {
                StartActivity(typeof(G_Student_Human_Factors_2));
            };

            btnNext.Touch += (s,e) =>
            {
                StartActivity(typeof(J_VFR_Dual_Local2));
            };

        }
    }
}