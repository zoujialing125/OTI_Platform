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
    
    public partial class forecast_carrierCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public forecast_carrierCode()
        {
            this.BookMethods = new HashSet<BookMethod>();
            this.forecast_list = new HashSet<forecast_list>();
        }
    
        public int id { get; set; }
        public string SCAC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookMethod> BookMethods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<forecast_list> forecast_list { get; set; }
    }
}
