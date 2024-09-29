﻿using FlightSystem.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Data
{
    public class FlightSystemDBContext : DbContext
    {
        public FlightSystemDBContext(DbContextOptions<FlightSystemDBContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Flight> Flights  { get;set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Document_Type> Document_Types { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("default", options =>
        //        options.MigrationsAssembly("FlightSystem.Domain")); // Thay thế "Back-End" bằng tên của assembly chứa migration
        //}

    }
}
