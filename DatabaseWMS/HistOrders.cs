//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseWMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class HistOrders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HistOrders()
        {
            this.HistCommands = new HashSet<HistCommands>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ERP_ID { get; set; }
        public int OrderID { get; set; }
        public int SubOrderID { get; set; }
        public int SubOrderERPID { get; set; }
        public string SKU_ID { get; set; }
        public string SubOrderName { get; set; }
        public double SKU_Qty { get; set; }
        public string Destination { get; set; }
        public System.DateTime ReleaseTime { get; set; }
        public string SKU_Batch { get; set; }
        public int Status { get; set; }
    
        public virtual CommandERPs CommandERPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistCommands> HistCommands { get; set; }
        public virtual PlaceIDs PlaceIDs { get; set; }
        public virtual SKU_ID SKU_ID1 { get; set; }
    }
}
