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
    [Activity(Label = "Risk Summary")]
    public class Z_Risk_Summary : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.z_risk_summary);

            ShortCutFunctions sc = new ShortCutFunctions();

            var txtFlight = FindViewById<TextView>(Resource.Id.txtFlightRiskStuff);
            var txtSHF = FindViewById<TextView>(Resource.Id.txtSHF);
            var txtRisk1 = FindViewById<TextView>(Resource.Id.txtRisk1);
            var txtRisk2 = FindViewById<TextView>(Resource.Id.txtRisk2);
            var txtRisk3 = FindViewById<TextView>(Resource.Id.txtRisk3);
            var txtRisk4 = FindViewById<TextView>(Resource.Id.txtRisk4);
            var txtRisk5 = FindViewById<TextView>(Resource.Id.txtRisk5);

            var btnNext = FindViewById<ImageButton>(Resource.Id.btnContinueFromRisk);
            var btnBack = FindViewById<ImageButton>(Resource.Id.btnBackfromRisk);

            if (B_Filing_Criteria_Activity.isVFR) //if VFR
            {
                if (C_Time_VFR_Activity.VFRisDay) //Day
                {
                    if (D_Syllabus_Activity.isLocal) //Local
                    {
                        txtFlight.Text = "Flying under VFR - Day, PVT/COMM/CFI Solo & Flight Team - Local Pattern (2)";
                        sc.riskSummary("Total Risk - Student Human Factors", txtSHF, F_Student_Human_Factors.SHFRisk, 7, 9);
                        sc.riskSummary("Home Airfield Risk", txtRisk1, H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.Ceiling + H_VFR_Day_Local2.vis, 7, 9);
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Invisible;
                        txtRisk4.Visibility = ViewStates.Invisible;
                        txtRisk5.Visibility = ViewStates.Invisible;
                        sc.riskSummary("PIC Risk", txtRisk2, (H_VFR_Day_LocalPIC.CFI_Landing + H_VFR_Day_LocalPIC.Other_Landing), 1, 3);
                    }
                    else //XC
                    {
                        txtFlight.Text = "Flying under VFR - Day, Pvt/Comm/CFI Solo & Flight Team - XC, Practice Area, Aux Field (3)";
                        sc.riskSummary("Total Risk - Student Human Factors", txtSHF, F_Student_Human_Factors.SHFRisk, 7, 9);
                        sc.riskSummary("Departure Airfield Risk", txtRisk1, I_VFR_Day_XC.DepartureRisk, 7, 9);
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Visible;
                        txtRisk4.Visibility = ViewStates.Visible;
                        txtRisk5.Visibility = ViewStates.Visible;
                        sc.riskSummary("Enroute or Practice Area Risk", txtRisk2, I_VFR_Day_XC3.enrouteRisk, 7, 9);
                        sc.riskSummary("Destination or Aux Field Risk", txtRisk3, I_VFR_Day_XC5.DestinationRisk, 8, 10);
                        sc.riskSummary("Alternate Risk", txtRisk4, I_VFR_Day_XC7.altRisk, 8, 10);
                        sc.riskSummary("PIC Risk", txtRisk5, I_VFR_Day_XCPIC.CFI_Landing + I_VFR_Day_XCPIC.Other_Landing, 1, 3);
                    }
                }
                else if (C_Time_VFR_Activity.VFRisDual) //Dual
                {
                    if (D_Syllabus_Activity.isLocal) //Local
                    {
                        txtFlight.Text = "Flying under VFR - Day/Night, Dual - Local Pattern (4)";
                        sc.riskSummary("Total Risk - Student Human Factors", txtSHF, F_Student_Human_Factors.SHFRisk, 7, 9);
                        sc.riskSummary("Home Airfield Risk", txtRisk1, J_VFR_Dual_Local1.homeRisk, 7, 9);
                        txtRisk2.Visibility = ViewStates.Invisible;
                        txtRisk3.Visibility = ViewStates.Invisible;
                        txtRisk4.Visibility = ViewStates.Invisible;
                        txtRisk5.Visibility = ViewStates.Invisible;
                    }
                    else //XC
                    {
                        txtFlight.Text = "Flying under VFR - Day/Night, Dual - XC, Practice Area, Aux Field (5)";
                        sc.riskSummary("Total Risk - Student Human Factors", txtSHF, F_Student_Human_Factors.SHFRisk, 7, 9);
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Visible;
                        txtRisk4.Visibility = ViewStates.Visible;
                        sc.riskSummary("Departure Airfield Risk", txtRisk1, K_VFR_Dual_XC1.DepartureRisk, 7, 9);
                        sc.riskSummary("Enroute or Practice Area Risk", txtRisk2, K_VFR_Dual_XC3.enrouteRisk, 7, 9);
                        sc.riskSummary("Destination or Aux Field Risk", txtRisk3, K_VFR_Dual_XC5.DestinationRisk, 8, 10);
                        sc.riskSummary("Alternate Risk", txtRisk4, K_VFR_Dual_XC8.altRisk, 8, 10);
                        txtRisk5.Visibility = ViewStates.Invisible;
                    }
                }
                else //Night
                {
                    if (D_Syllabus_Activity.isLocal) //Local
                    {
                        txtFlight.Text = "Flying under VFR - Night, Commercial/CFI Solo - Local Pattern (6)";
                        sc.riskSummary("Total Risk - Student Human Factors", txtSHF, F_Student_Human_Factors.SHFRisk, 7, 9);
                        sc.riskSummary("Departure Risk", txtRisk1, L_VFR_Night_Local1.departureRisk, 7, 9);
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Invisible;
                        txtRisk4.Visibility = ViewStates.Invisible;
                        txtRisk5.Visibility = ViewStates.Invisible;
                        sc.riskSummary("PIC Risk", txtRisk2, L_VFR_Night_Local3.PIC_Risk, 2, 3);
                     }
                    else //XC                     
                    {                                      
                        txtFlight.Text = "Flying under VFR - Night, Commercial/CFI Solo - XC (7)";
                        sc.riskSummary("Total Risk - Student Human Factors", txtSHF, F_Student_Human_Factors.SHFRisk, 7, 9);
                        sc.riskSummary("Departure Airfield Risk", txtRisk1, M_VFR_Night_XC1.departureRisk, 8, 10);
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Visible;
                        txtRisk4.Visibility = ViewStates.Visible;
                        txtRisk5.Visibility = ViewStates.Visible;
                        sc.riskSummary("Enroute or Practice Area Risk", txtRisk2, M_VFR_Night_XC3.enrouteRisk, 8, 10);
                        sc.riskSummary("Destination or Aux Field Risk", txtRisk3, M_VFR_Night_XC5.DestinationRisk, 9, 12);
                        sc.riskSummary("Alternate Risk", txtRisk4, M_VFR_Night_XC7.altRisk, 9, 12);
                        sc.riskSummary("PIC Risk", txtRisk5, M_VFR_Night_XC9.pic, 2, 3);
                    }
                }
            }
            else //IFR
            {
                if (C_Time_IFR_Activity.IFRisDual) //Dual
                {
                    if (D_Syllabus_Activity.isLocal) //Local
                    {
                        txtFlight.Text = "Flying under IFR - Day/Night Dual - Local Area (8)";
                        sc.riskSummary("Total Risk - Student Human Factors", txtSHF, F_Student_Human_Factors.SHFRisk, 7, 9);
                        sc.riskSummary("Home Airport Risk", txtRisk1, P_IFR_Dual_Local_2Home.homeRisk, 8, 10);
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Invisible;
                        txtRisk4.Visibility = ViewStates.Invisible;
                        txtRisk5.Visibility = ViewStates.Invisible;
                        sc.riskSummary("Alternate Risk", txtRisk2, P_IFR_Dual_Local_4Alt.altRisk, 9, 12);
                    }
                    else //XC
                    {
                        txtFlight.Text = "Flying under IFR - Day/Night Dual - Cross Country (9)";
                        sc.riskSummary("Total Risk - Student Human Factors", txtSHF, F_Student_Human_Factors.SHFRisk, 7, 9);
                        sc.riskSummary("Departure Risk", txtRisk1, Q_IFR_Dual_XC_2Departure.departureRisk, 8, 10);
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Visible;
                        txtRisk4.Visibility = ViewStates.Visible;
                        txtRisk5.Visibility = ViewStates.Invisible;
                        sc.riskSummary("Enroute Risk", txtRisk2, Q_IFR_Dual_XC_4Enroute.enrouteRisk, 9, 12);
                        sc.riskSummary("Destination Risk", txtRisk3, Q_IFR_Dual_XC_6Destination.destinationRisk, 8, 10);
                        sc.riskSummary("Alternate Risk", txtRisk4, Q_IFR_Dual_XC_8Alternate.altRisk, 9, 12);
                    }
                }
                else //Day
                {
                    if (D_Syllabus_Activity.isLocal) //Local
                    {
                        txtFlight.Text = "Flying under IFR - Day, Commerical/CFI Solo - Local Area (10)";
                        sc.riskSummary("Total Risk - Student Human Factors", txtSHF, F_Student_Human_Factors.SHFRisk, 7, 9);
                        txtRisk1.Text = "Home Airfield Risk: " + N_IFR_Day_Local_Home.HomeRisk;
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Visible;
                        txtRisk4.Visibility = ViewStates.Invisible;
                        txtRisk5.Visibility = ViewStates.Invisible;
                        txtRisk2.Text = "Alternate Risk: " + N_IFR_Day_Local_Alternate.AltRisk;
                        txtRisk3.Text = "PIC Risk: " + N_IFR_Day_Local_PIC.PIC;
                    }
                    else //XC
                    {
                        txtFlight.Text = "Flying under IFR - Day, Commercial/CFI Solo - Cross Country (11)";
                        sc.riskSummary("Total Risk - Student Human Factors", txtSHF, F_Student_Human_Factors.SHFRisk, 7, 9);
                        txtRisk1.Text = "Departure Airfield Risk: " + O_IFR_Day_XC_1Departure.HomeRisk;
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Visible;
                        txtRisk4.Visibility = ViewStates.Visible;
                        txtRisk5.Visibility = ViewStates.Visible;
                        txtRisk2.Text = "Enroute Risk: " + O_IFR_Day_XC_2Enroute.enroute;
                        txtRisk3.Text = "Destination Risk: " + O_IFR_Day_XC_3Destination.destinationRisk;
                        txtRisk4.Text = "Alternate Risk: " + O_IFR_Day_XC_4Alternate.AltRisk;
                        txtRisk5.Text = "PIC Risk: " + O_IFR_Day_XC_5PIC.PIC;
                    }
                }
            }

            btnBack.Click += (s, e) =>
           {
               StartActivity(typeof(Y_Aircraft_and_Instructor));
           };

            btnNext.Visibility = ViewStates.Invisible;
        }

    }
}