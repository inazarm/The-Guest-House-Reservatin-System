//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheHouse.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Booking()
        {
            this.tbl_BookingBridge = new HashSet<tbl_BookingBridge>();
        }
    
        public int B_Id { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public Nullable<System.DateTime> DepartureDate { get; set; }
        public Nullable<int> TotalPerson { get; set; }
        public string BookedBy { get; set; }
        public Nullable<System.DateTime> Booking_Date { get; set; }
        public string B_Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BookingBridge> tbl_BookingBridge { get; set; }
    }
}
