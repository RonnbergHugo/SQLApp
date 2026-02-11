using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SQLapp.Models;

public partial class EHandelContext : DbContext
{
    public EHandelContext()
    {
    }

    public EHandelContext(DbContextOptions<EHandelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<VwOrderTotal> VwOrderTotals { get; set; }

    public virtual DbSet<VwPublicCustomerOrder> VwPublicCustomerOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-IBH59E1\\SQLEXPRESS;Database=eHandel;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83F7C1B7237");

            entity.ToTable("categories");

            entity.HasIndex(e => e.Category1, "UQ__categori__F7F53CC2856F00A5").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category1)
                .HasMaxLength(31)
                .IsUnicode(false)
                .HasColumnName("category");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83F1860C343");

            entity.ToTable("customers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(31)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders__3213E83FF747EBEE");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(63)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("orderDate");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__orders__customer__5FB337D6");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__orderIte__BAD83E4B30690D26");

            entity.ToTable("orderItems");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quant)
                .HasDefaultValue(1)
                .HasColumnName("quant");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orderItem__order__6A30C649");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orderItem__produ__6B24EA82");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3213E83F5EFE0578");

            entity.ToTable("products");

            entity.HasIndex(e => e.Name, "UQ__products__72E12F1BFDD0BB51").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(31)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");

            entity.HasMany(d => d.Categories).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__productCa__categ__6EF57B66"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__productCa__produ__6E01572D"),
                    j =>
                    {
                        j.HasKey("ProductId", "CategoryId").HasName("PK__productC__BF2C7E77A6BD9BE5");
                        j.ToTable("productCategories");
                        j.IndexerProperty<int>("ProductId").HasColumnName("productId");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("categoryId");
                    });
        });

        modelBuilder.Entity<VwOrderTotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwOrderTotals");

            entity.Property(e => e.CustomerName)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<VwPublicCustomerOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPublicCustomerOrders");

            entity.Property(e => e.Name)
                .HasMaxLength(31)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
