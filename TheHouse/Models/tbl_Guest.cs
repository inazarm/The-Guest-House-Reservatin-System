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
    
    public partial class tbl_Guest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Guest()
        {
            this.tbl_BookingBridge = new HashSet<tbl_BookingBridge>();
        }
    
        public int G_Id { get; set; }
        public string G_Name { get; set; }
        public string G_Email { get; set; }
        public string G_Pass { get; set; }
        public string G_Phone { get; set; }
        public string G_Gender { get; set; }
        public string G_City { get; set; }
        public string G_Country { get; set; }
        public string G_CNIC { get; set; }
        public string G_Passport { get; set; }
        public string G_Status { get; set; }
        public string Type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BookingBridge> tbl_BookingBridge { get; set; }
    }
}
