﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SOMIService.Models;
using SOMIService.Models.Entities;
using SOMIService.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOMIService.Data
{
    public class MyContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public MyContext(DbContextOptions<MyContext> options)
       : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //fluent API

            builder.Entity<Subscription>()
                .Property(x => x.Amount)
                .HasPrecision(9, 2);
            builder.Entity<Subscription>()
                .Property(x => x.PaidAmount)
                .HasPrecision(9, 2);
            builder.Entity<SubscriptionType>()
                .Property(x => x.Price)
                .HasPrecision(9, 2);
        }

       
        public DbSet<FailureLogging> FailureLoggings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }



    }
}
