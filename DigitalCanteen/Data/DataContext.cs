﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DigitalCanteen.Models;
using DigitalCanteen.Models.Entities;


namespace DigitalCanteen.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DataContext")
        {
            Database.SetInitializer<DataContext>(new CreateDatabaseIfNotExists<DataContext>());
        }
        public virtual DbSet<UserCredential> UserCredentials { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<AccountDetail> AccountDetails { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<RandomNo> RandomNoes { get; set; }  


       
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}