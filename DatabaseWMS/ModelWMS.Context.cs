﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntitiesWMS : DbContext
    {
        public EntitiesWMS()
            : base("name=EntitiesWMS")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<CommandERPs> CommandERPs { get; set; }
        public virtual DbSet<Commands> Commands { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PlaceIDs> PlaceIDs { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<SKU_ID> SKU_ID { get; set; }
        public virtual DbSet<TU_ID> TU_ID { get; set; }
        public virtual DbSet<TUs> TUs { get; set; }
        public virtual DbSet<Parameters> Parameters { get; set; }
    }
}