//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class SimpleCommand
    {
        public int ID { get; set; }
        public Nullable<int> Command_ID { get; set; }
        public Nullable<int> Material { get; set; }
        public string Source { get; set; }
        public SimpleCommand.EnumTask Task { get; set; }
        public SimpleCommand.EnumStatus Status { get; set; }
        public System.DateTime Time { get; set; }
        public Nullable<int> CancelID { get; set; }
        public Nullable<SimpleCommand.EnumReason> Reason { get; set; }
    
        public virtual MaterialID MaterialID { get; set; }
        public virtual PlaceID PlaceID { get; set; }
        public virtual Command Command { get; set; }
    }
}
