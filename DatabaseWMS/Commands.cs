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
    
    public partial class Commands
    {
        public int ID { get; set; }
        public int Order_ID { get; set; }
        public int TU_ID { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public int Status { get; set; }
        public System.DateTime Time { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual PlaceIDs PlaceIDs { get; set; }
        public virtual PlaceIDs PlaceIDs1 { get; set; }
        public virtual TU_ID TU_ID1 { get; set; }
    }
}