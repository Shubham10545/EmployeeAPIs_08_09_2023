using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions con) : base(con) { }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Country> Country { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
             .HasOne(e => e.City)
             .WithMany()
             .HasForeignKey(e => e.CityId)
             .OnDelete(DeleteBehavior.Restrict);

            // Employee to State (one-to-many)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.State)
                .WithMany()
                .HasForeignKey(e => e.StateId)
                 .OnDelete(DeleteBehavior.Restrict);
            // Employee to Country (one-to-many)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId)
                 .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
