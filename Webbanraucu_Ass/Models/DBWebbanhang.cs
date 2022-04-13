using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webbanraucu_Ass.ModelsView;


namespace Webbanraucu_Ass.Models
{
    public class DBWebbanhang : DbContext
    {
        public DBWebbanhang(DbContextOptions<DBWebbanhang> options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=DESKTOP-NPEJLEB\\SQLEXPRESS;Initial Catalog=Webbanhang_3;User ID=btn1;Password=123;MultipleActiveResultSets=True;Application Name=EntityFramework");
        //    }
        //}
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<TransacStatus> TransacStatus { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Accounts>(table =>
            {
                table.HasKey(x => x.AccountID);

                table.HasOne(x => x.Roles)
                    .WithMany(x => x.Accounts)
                    .HasForeignKey(x => x.RoleID)
                    .HasPrincipalKey(x => x.RoleID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Products>(table =>
            {
                table.HasKey(x => x.ProductID);

                table.HasOne(x => x.Categories)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.CatID)
                    .HasPrincipalKey(x => x.CatID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Orders>(table =>
            {
                table.HasKey(x => x.OrderID);

                table.HasOne(x => x.Customers)
                    .WithMany(x => x.Orders)
                    .HasForeignKey(x => x.CustomerID)
                    .HasPrincipalKey(x => x.CustomerID)
                    .OnDelete(DeleteBehavior.Cascade);
                table.HasOne(x => x.TransacStatus)
                    .WithMany(x => x.Orders)
                    .HasForeignKey(x => x.TransacStatuID)
                    .HasPrincipalKey(x => x.TransacStatuID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<OrderDetails>(table =>
            {
                table.HasKey(x => x.OrderDetailsID);

                table.HasOne(x => x.Orders)
                    .WithMany(x => x.OrderDetails)
                    .HasForeignKey(x => x.OrderID)
                    .HasPrincipalKey(x => x.OrderID)
                    .OnDelete(DeleteBehavior.Cascade);
                table.HasOne(x => x.Products)
                    .WithMany(x => x.OrderDetails)
                    .HasForeignKey(x => x.ProductsID)
                    .HasPrincipalKey(x => x.ProductID)
                    .OnDelete(DeleteBehavior.Cascade);
            });


        }

        public DbSet<Webbanraucu_Ass.ModelsView.RegiterViewModels> RegiterViewModels { get; set; }

    }
}
