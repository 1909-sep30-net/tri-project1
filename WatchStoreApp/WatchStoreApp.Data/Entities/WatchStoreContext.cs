using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WatchStoreApp.Data.Entities
{
    public partial class WatchStoreContext : DbContext
    {
        public WatchStoreContext()
        {
        }

        public WatchStoreContext(DbContextOptions<WatchStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrder { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:nguyenct.database.windows.net,1433;Initial Catalog=WatchStore;Persist Security Info=False;User ID=tri;Password=Arena101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Customer__C1F8DC599EED01B3");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.Addresses)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => new { e.Oid, e.Pid })
                    .HasName("CompKey_OP");

                entity.ToTable("Customer_Order");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.HasOne(d => d.O)
                    .WithMany(p => p.CustomerOrder)
                    .HasForeignKey(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer_Or__OID__7849DB76");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.CustomerOrder)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer_Or__PID__793DFFAF");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.Lid, e.Pid })
                    .HasName("CompKey_LP");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.Lid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__LID__70A8B9AE");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__PID__719CDDE7");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.Lid)
                    .HasName("PK__Location__C6555721C6936266");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.Located)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("PK__Orders__CB394B39B0A3C619");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.OrderTime)
                    .HasColumnName("Order_Time")
                    .HasColumnType("date");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK__Orders__CID__74794A92");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Lid)
                    .HasConstraintName("FK__Orders__LID__756D6ECB");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Product__C5775520F1965526");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
