﻿using eTicketsNew.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsNew.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Play>().HasKey(ap => new
            {
                ap.ActorId,
                ap.PlayId
            });

            modelBuilder.Entity<Actor_Play>().HasOne(p => p.Play).WithMany(ap => ap.Actors_Plays).HasForeignKey(p => p.PlayId);
            modelBuilder.Entity<Actor_Play>().HasOne(p => p.Actor).WithMany(ap => ap.Actors_Plays).HasForeignKey(p => p.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Actor_Play> Actors_Plays { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Director> Directors { get; set; }



        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
