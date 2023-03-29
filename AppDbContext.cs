using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_Conversion_Default
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EF_Test;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IEnumerable<Location> def = new List<Location> { Location.Cluj };
            modelBuilder.Entity<User>().Property(p => p.Locations)
               .HasConversion(
               v => JoinOrDefault(v),
               v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => Enum.Parse<Location>(val)),
               new ValueComparer<IEnumerable<Location>>(
                   (c1, c2) => Mycomp(c1, c2),
                   c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                   c => c))
               .HasDefaultValueSql(Location.Cluj.ToString());
        }

        static bool Mycomp(IEnumerable<Location>? a, IEnumerable<Location>? b)
        {
            if (a == null || b == null) return false;
            return a.SequenceEqual(b);
        }

        static string JoinOrDefault(IEnumerable<Location> v)
        {
            if (!v.Any())
            {
                return Location.Cluj.ToString();
            }

            return string.Join(";", v);
        }
    }

    public enum Location
    {
        Cluj = 1,
        Sibiu = 2,
        Brasov = 3
    }
}
