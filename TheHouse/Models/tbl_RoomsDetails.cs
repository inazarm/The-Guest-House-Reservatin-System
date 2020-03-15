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
    
    public partial class tbl_RoomsDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_RoomsDetails()
        {
            this.tbl_BookingBridge = new HashSet<tbl_BookingBridge>();
        }
    
        public int R_Id { get; set; }
        public Nullable<int> FK_HouseID { get; set; }
        public Nullable<int> FK_TypeID { get; set; }
        public Nullable<int> FK_CateID { get; set; }
        public string R_Desc { get; set; }
        public Nullable<int> R_Capacity { get; set; }
        public string R_Image { get; set; }
        public Nullable<bool> R_Status { get; set; }
    
        public virtual tbl_Category tbl_Category { get; set; }
        public virtual tbl_House tbl_House { get; set; }
        public virtual tbl_Type tbl_Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BookingBridge> tbl_BookingBridge { get; set; }
    }
}