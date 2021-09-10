﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Xml;
using JoolServerApp.Data;
using Microsoft.AspNetCore.Http;


//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JoolServerApp.Repo
{
    public partial class JoolServerEntities : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

      
  /*public JoolServerEntities(DbContextOptions<JoolServerEntities> options, IHttpContextAccessor httpContextAccessor)
            :base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }*/
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblCity> tblCities { get; set; }
        public virtual DbSet<tblCredential> tblCredentials { get; set; }
        public virtual DbSet<tblDepartment> tblDepartments { get; set; }
        public virtual DbSet<tblDocument> tblDocuments { get; set; }
        public virtual DbSet<tblFeedBack> tblFeedBacks { get; set; }
        public virtual DbSet<tblManufacturer> tblManufacturers { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProject> tblProjects { get; set; }
        public virtual DbSet<tblProperty> tblProperties { get; set; }
        public virtual DbSet<tblPropertyValue> tblPropertyValues { get; set; }
        public virtual DbSet<tblSale> tblSales { get; set; }
        public virtual DbSet<tblState> tblStates { get; set; }
        public virtual DbSet<tblSubCategory> tblSubCategories { get; set; }
        public virtual DbSet<tblTechSpecFilter> tblTechSpecFilters { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblTypeFilter> tblTypeFilters { get; set; }
    }
}
