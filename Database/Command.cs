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
    
    public partial class Command
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Command()
        {
            this.SimpleCommands = new HashSet<SimpleCommand>();
        }
    
        public int ID { get; set; }
        public int WMS_ID { get; set; }
        public Command.EnumCommandTask Task { get; set; }
        public string Info { get; set; }
        public Command.EnumCommandStatus Status { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public int Priority { get; set; }
        public Nullable<Command.EnumCommandReason> Reason { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SimpleCommand> SimpleCommands { get; set; }
    }
}
