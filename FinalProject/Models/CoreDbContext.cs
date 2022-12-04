using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinalProject.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Champion> Champions { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-N8QUTCU;database=FinalProjectDatabase;Trusted_Connection=true", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Champion>(entity =>
            {
                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Champions)
                    .HasForeignKey(d => d.Person)
                    .HasConstraintName("FK_Champion_Person");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.Person)
                    .HasConstraintName("FK_Games_Person");
            });

            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Pokemons)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pokemon_Person");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
