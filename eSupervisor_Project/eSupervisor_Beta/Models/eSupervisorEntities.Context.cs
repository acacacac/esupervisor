﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eSupervisor_Beta.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class eSupervisorEntities : DbContext
    {
        public eSupervisorEntities()
            : base("name=eSupervisorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<allocation> allocations { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<fileUpload> fileUploads { get; set; }
        public DbSet<interaction> interactions { get; set; }
        public DbSet<interactionType> interactionTypes { get; set; }
        public DbSet<meeting> meetings { get; set; }
        public DbSet<meetingArrangement> meetingArrangements { get; set; }
        public DbSet<message> messages { get; set; }
        public DbSet<post> posts { get; set; }
        public DbSet<project> projects { get; set; }
        public DbSet<role> roles { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<user> users { get; set; }
    }
}
