﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCarYard
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mycaryardEntities : DbContext
    {
        public mycaryardEntities()
            : base("name=mycaryardEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChatMessageDetail> ChatMessageDetails { get; set; }
        public virtual DbSet<ChatPrivateMessageDetail> ChatPrivateMessageDetails { get; set; }
        public virtual DbSet<ChatPrivateMessageMaster> ChatPrivateMessageMasters { get; set; }
        public virtual DbSet<ChatUserDetail> ChatUserDetails { get; set; }

        public System.Data.Entity.DbSet<MyCarYard.Models.UserListModel> UserListModels { get; set; }
    }
}
