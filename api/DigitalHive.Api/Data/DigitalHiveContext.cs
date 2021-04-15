using DigitalHive.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DigitalHive.Api.Data {
  public class DigitalHiveContext : DbContext
    {
        public DigitalHiveContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TimeSeriesReport> TimeSeriesReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}