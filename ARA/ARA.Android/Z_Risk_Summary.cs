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
                        txtSHF.Text = "Total Risk - Student Human Factors: " + F_Student_Human_Factors.SHFRisk;
                        txtRisk1.Text = "Home Airfield Risk: " + (H_VFR_Day_Local1.soloWind + H_VFR_Day_Local1.otherWind + H_VFR_Day_Local1.soloXWind + H_VFR_Day_Local2.OtherXWind + H_VFR_Day_Local2.Ceiling + H_VFR_Day_Local2.vis);
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Invisible;
                        txtRisk4.Visibility = ViewStates.Invisible;
                        txtRisk5.Visibility = ViewStates.Invisible;
                        txtRisk2.Text = "PIC Risk: " + (H_VFR_Day_LocalPIC.CFI_Landing + H_VFR_Day_LocalPIC.Other_Landing);
                    }
                    else //XC
                    {
                        txtFlight.Text = "Flying under VFR - Day, Pvt/Comm/CFI Solo & Flight Team - XC, Practice Area, Aux Field (3)";
                        txtSHF.Text = "Total Risk - Student Human Factors: " + F_Student_Human_Factors.SHFRisk;
                        txtRisk1.Text = "Departure Airfield Risk: " + I_VFR_Day_XC.DepartureRisk;
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Visible;
                        txtRisk4.Visibility = ViewStates.Visible;
                        txtRisk5.Visibility = ViewStates.Visible;
                        txtRisk2.Text = "Enroute or Practice Area Risk: " + I_VFR_Day_XC3.enrouteRisk;
                        txtRisk3.Text = "Destination or Aux Field Risk: " + I_VFR_Day_XC5.DestinationRisk;
                        txtRisk4.Text = "Alternate Risk: " + I_VFR_Day_XC7.altRisk;
                        txtRisk5.Text = "PIC Risk: " + (I_VFR_Day_XCPIC.CFI_Landing + I_VFR_Day_XCPIC.Other_Landing);
                    }
                }
                else if (C_Time_VFR_Activity.VFRisDual) //Dual
                {
                    if (D_Syllabus_Activity.isLocal) //Local
                    {
                        txtFlight.Text = "Flying under VFR - Day/Night, Dual - Local Pattern (4)";
                        txtSHF.Text = "Total Risk - Student Human Factors: " + F_Student_Human_Factors.SHFRisk;
                        txtRisk1.Text = "Home Airfield Risk: " + J_VFR_Dual_Local1.homeRisk;
                        txtRisk2.Visibility = ViewStates.Invisible;
                        txtRisk3.Visibility = ViewStates.Invisible;
                        txtRisk4.Visibility = ViewStates.Invisible;
                        txtRisk5.Visibility = ViewStates.Invisible;
                    }
                    else //XC
                    {
                        txtFlight.Text = "Flying under VFR - Day/Night, Dual - XC, Practice Area, Aux Field (5)";
                        txtSHF.Text = "Total Risk - Student Human Factors: " + F_Student_Human_Factors.SHFRisk;
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Visible;
                        txtRisk4.Visibility = ViewStates.Visible;
                        txtRisk1.Text = "Departure Airfield Risk: " + K_VFR_Dual_XC1.DepartureRisk;
                        txtRisk2.Text = "Enroute or Practice Area Risk: " + K_VFR_Dual_XC3.enrouteRisk;
                        txtRisk3.Text = "Destination or Aux Field Risk: " + K_VFR_Dual_XC5.DestinationRisk;
                        txtRisk4.Text = "Alternate Risk: " + K_VFR_Dual_XC8.altRisk;
                        txtRisk5.Visibility = ViewStates.Invisible;
                    }
                }
                else //Night
                {
                    if (D_Syllabus_Activity.isLocal) //Local
                    {
                        txtFlight.Text = "Flying under VFR - Night, Commercial/CFI Solo - Local Pattern (6)";
                        txtSHF.Text = "Total Risk - Student Human Factors: " + F_Student_Human_Factors.SHFRisk;
                        txtRisk1.Text = "Departure Risk: " + L_VFR_Night_Local1.departureRisk;
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Invisible;
                        txtRisk4.Visibility = ViewStates.Invisible;
                        txtRisk5.Visibility = ViewStates.Invisible;
                        txtRisk2.Text = "PIC Risk: " + L_VFR_Night_Local3.PIC_Risk;
                    }
                    else //XC
                    {
                        txtFlight.Text = "Flying under VFR - Night, Commercial/CFI Solo - XC (7)";
                        txtSHF.Text = "Total Risk - Student Human Factors: " + F_Student_Human_Factors.SHFRisk;
                        txtRisk1.Text = "Departure Airfield Risk: " + M_VFR_Night_XC1.departureRisk;
                        txtRisk2.Visibility = ViewStates.Visible;
                        txtRisk3.Visibility = ViewStates.Visible;
                        txtRisk4.Visibility = ViewStates.Visible;
                        txtRisk5.Visibility = ViewStates.Visible;
                        txtRisk2.Text = "Enroute or Practice Area Risk: " + M_VFR_Night_XC3.enrouteRisk;
                        txtRisk3.Text = "Destination or Aux Field Risk: " + M_VFR_Night_XC5.DestinationRisk;
                        txtRisk4.Text = "Alternate Risk: " + M_VFR_Night_XC7.altRisk;
                        txtRisk5.Text = "PIC Risk: " + M_VFR_Night_XC9.pic;
                    }
                }
            }
            else //IFR
            {
                if (C_Time_IFR_Activity.IFRisDual) //Dual
                {
                    if (D_Syllabus_Activity.isLocal) //Local
                    {
                        
                    }
                    else //XC
                    {

                    }
                }
                else //Day
                {
                    if (D_Syllabus_Activity.isLocal) //Local
                    {
                        txtFlight.Text = "Flying under IFR - Day, Commerical/CFI Solo - Local Area (10)";
                        txtSHF.Text = "Total Risk - Student Human Factors: " + F_Student_Human_Factors.SHFRisk;
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
                        txtSHF.Text = "Total Risk - Student Human Factors: " + F_Student_Human_Factors.SHFRisk;
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