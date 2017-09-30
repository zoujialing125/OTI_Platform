//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OTI_Booking_Platform.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class forecast_list
    {
        public int id { get; set; }
        public string UID { get; set; }
        public string CNEE_Name { get; set; }
        public Nullable<int> ETD_Week { get; set; }
        public System.DateTime ETD { get; set; }
        public string Carrier_SCAC { get; set; }
        public string String1 { get; set; }
        public string VSL { get; set; }
        public string VOY { get; set; }
        public string S_C { get; set; }
        public string POL_Name { get; set; }
        public string POD_Name { get; set; }
        public Nullable<int> Forecast_TEU { get; set; }
        public string POD_Region { get; set; }
        public string Remarks { get; set; }
        public string Over_Book { get; set; }
        public Nullable<int> CT_Feedback { get; set; }
        public Nullable<int> Booked_TEU { get; set; }
        public Nullable<int> Cancelled_TEU { get; set; }
        public Nullable<int> Balance_TEU { get; set; }
        public System.DateTime Submit_Time { get; set; }
        public Nullable<System.DateTime> CT_Time { get; set; }
        public Nullable<System.DateTime> CAR_Time { get; set; }
        public string String2 { get; set; }
        public string Dpt { get; set; }
        public string Team_Leader { get; set; }
        public string Team_Name { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string OP_Type { get; set; }
    
        public virtual ClientDetail ClientDetail { get; set; }
        public virtual forecast_carrierCode forecast_carrierCode { get; set; }
        public virtual forecast_portCode forecast_portCode_pod { get; set; }
        public virtual forecast_portCode forecast_portCode_pol { get; set; }
    }
}