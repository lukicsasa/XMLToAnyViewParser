﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XMLToAnyViewParser.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using XMLToAnyViewParser.Entities;

    public partial class XMLToAnyViewParserEntities : DbContext
    {
        public XMLToAnyViewParserEntities()
            : base("name=XMLToAnyViewParserEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> Users { get; set; }
    }
}
