using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace auto_service
{
    public partial class auto_serviceContext : DbContext
    {
        public auto_serviceContext()
        {
        }

        public auto_serviceContext(DbContextOptions<auto_serviceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientService> ClientServices { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP\\SQLEXPRESS;Database=auto_service;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GenderCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhotoPath).HasMaxLength(1000);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.HasOne(d => d.GenderCodeNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.GenderCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Gender");
            });

            modelBuilder.Entity<ClientService>(entity =>
            {
                entity.ToTable("ClientService");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientServices)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientService_Client");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ClientServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientService_Service");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Gender");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.MainImagePath).HasMaxLength(1000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
