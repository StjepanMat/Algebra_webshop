﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Data
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(200)]
        public string? City { get; set; }

        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        public string? PostalCode { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }


        [ForeignKey("UserId")]
        public virtual ICollection<Order> Orders { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 50,
                Title = "Rambo",
                Description = "Description",
                Price = 10.99m,
                Active = true,
                Quantity = 10
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 51,
                Title = "Rambo 2",
                Description = "Description 2",
                Price = 13.99m,
                Active = true,
                Quantity = 8
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 52,
                Title = "Rambo 3",
                Description = "Description 3",
                Price = 15.99m,
                Active = true,
                Quantity = 12
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}