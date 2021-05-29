using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondHandMarket.Models;
using SecondHandMarket.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondHandMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementProperty> AdvertisementProperties { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProperty> CategoryProperties { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainCategory>()
                .HasData(
                new MainCategory { Id = 1, Name = "Fordon" },
                new MainCategory { Id = 2, Name = "För Hemmet" },
                new MainCategory { Id = 3, Name = "Personligt" },
                new MainCategory { Id = 4, Name = "Elektronik" },
                new MainCategory { Id = 5, Name = "Fritid & hobby" }
                );

            //TODO Fixa Seed för Property
            modelBuilder.Entity<Property>()
                .HasData(
                new Property { Id = 1, Name = "Pris" },
                new Property { Id = 2, Name = "Modellår" },
                new Property { Id = 3, Name = "Miltal" }
                );

            modelBuilder.Entity<Category>()
                .HasData(
                // Fordon
                new Category
                {
                    Id = 1,
                    Name = "Bilar",
                    MainCategoryId = 1,
                    CategoryProperties = new List<CategoryProperty>() {
                        new CategoryProperty { Id = 1, CategoryId = 1, PropertyId = 1 },
                        new CategoryProperty { Id=2 , CategoryId=1, PropertyId= 2} }
                },

                //TODO Categoryproperty inbakad 
                new Category { Id = 2, Name = "Båtar", MainCategoryId = 1 },
                new Category { Id = 3, Name = "Motorcyklar", MainCategoryId = 1 },
                new Category { Id = 4, Name = "Mopeder", MainCategoryId = 1 },
                new Category { Id = 5, Name = "Cyklar", MainCategoryId = 1 },
                new Category { Id = 6, Name = "Lastbilar", MainCategoryId = 1 },
                new Category { Id = 7, Name = "Snöskotrar", MainCategoryId = 1 },
                // För hemmet
                new Category { Id = 8, Name = "Möbler", MainCategoryId = 2 },
                new Category { Id = 9, Name = "Vitvaror", MainCategoryId = 2 },
                new Category { Id = 10, Name = "Byggmaterial", MainCategoryId = 2 },
                new Category { Id = 11, Name = "Verktyg", MainCategoryId = 2 },
                // Personligt
                new Category { Id = 12, Name = "Kläder & skor", MainCategoryId = 3 },
                new Category { Id = 13, Name = "Accessoarer & klockor", MainCategoryId = 3 },
                new Category { Id = 14, Name = "Barnkläder & Skor", MainCategoryId = 3 },
                new Category { Id = 15, Name = "Barnartiklar & leksaker", MainCategoryId = 3 },
                // Elektronik
                new Category { Id = 16, Name = "Datorer & TV-spel", MainCategoryId = 4 },
                new Category { Id = 17, Name = "Ljus & bild", MainCategoryId = 4 },
                new Category { Id = 18, Name = "Telefoner & tillbehör", MainCategoryId = 4 },
                // Fritid & hobby
                new Category { Id = 19, Name = "Upplevelser & nöje", MainCategoryId = 5 }

                //TODO Fixa resterande categorier: se Blocket.se
                );
            //TODO Fixa seed för applicationuser 6-7 personer
            //TODO Fixa Seed för annonser 10-15 annonser. För bil attribut: Pris, miltal, modellår
            new Advertisement { Id = 1, CategoryId = 1};
        }
    }
}
