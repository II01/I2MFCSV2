﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MFCSEntities : DbContext
    {
        public MFCSEntities()
            : base("name=MFCSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Command> Commands { get; set; }
        public virtual DbSet<MaterialID> MaterialIDs { get; set; }
        public virtual DbSet<Movement> Movements { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<PlaceID> PlaceIDs { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Alarm> Alarms { get; set; }
        public virtual DbSet<SimpleCommand> SimpleCommands { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<HistCommand> HistCommands { get; set; }
        public virtual DbSet<HistSimpleCommand> HistSimpleCommands { get; set; }
    
        public virtual int SwitchLanguage(Nullable<int> lang)
        {
            var langParameter = lang.HasValue ?
                new ObjectParameter("lang", lang) :
                new ObjectParameter("lang", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SwitchLanguage", langParameter);
        }
    }
}
