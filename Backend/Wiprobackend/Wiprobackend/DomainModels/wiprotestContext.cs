using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Wiprobackend.DomainModels
{
    public partial class WiprotestContext : DbContext
    {
        public static string ConnectionString
        {
            get; set;
        }

        public WiprotestContext()
        {
        }

        public WiprotestContext(DbContextOptions<WiprotestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Training> Training { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Training>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(1000);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });
        }
    }
}
