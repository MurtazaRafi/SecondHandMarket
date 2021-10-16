using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondHandMarket.Models;
using SecondHandMarket.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondHandMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
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
        public DbSet<SubLocation> SubLocations { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MainCategory>()
                .HasData(
                new MainCategory { Id = 1, Name = "Fordon" },
                new MainCategory { Id = 2, Name = "För Hemmet" },
                new MainCategory { Id = 3, Name = "Personligt" },
                new MainCategory { Id = 4, Name = "Elektronik" },
                new MainCategory { Id = 5, Name = "Fritid & hobby" }
                );

            modelBuilder.Entity<Property>()
                .HasData(
                new Property { Id = 1, Name = "Modellår" },
                new Property { Id = 2, Name = "Miltal" }
                );
            modelBuilder.Entity<CategoryProperty>()
              .HasData(
                 new CategoryProperty { Id = 1, CategoryId = 1, PropertyId = 1 },
                 new CategoryProperty { Id = 2, CategoryId = 1, PropertyId = 2 },
                 new CategoryProperty { Id = 3, CategoryId = 2, PropertyId = 1 });


            modelBuilder.Entity<Category>()
                    .HasData(
                    // Fordon
                    new Category
                    {
                        Id = 1,
                        Name = "Bilar",
                        MainCategoryId = 1
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Båtar",
                        MainCategoryId = 1
                    },
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
                    new Category { Id = 19, Name = "Upplevelser & nöje", MainCategoryId = 5 },
                    new Category { Id = 20, Name = "Böcker & studentlitteratur", MainCategoryId = 5 },
                    new Category { Id = 21, Name = "Djur", MainCategoryId = 5 },
                    new Category { Id = 22, Name = "Sport", MainCategoryId = 5 }

                    );

            modelBuilder.Entity<Location>()
              .HasData(
                 new Location { Id = 1, Name = "Blekinge" },
                 new Location { Id = 2, Name = "Dalarna" },
                 new Location { Id = 3, Name = "Gotland" },
                 new Location { Id = 4, Name = "Gävleborg" },
                 new Location { Id = 5, Name = "Halland" },
                 new Location { Id = 6, Name = "Jämtland" },
                 new Location { Id = 7, Name = "Jönköping" },
                 new Location { Id = 8, Name = "Kalmar" },
                 new Location { Id = 9, Name = "Kronoberg" },
                 new Location { Id = 10, Name = "Norrbotten" },
                 new Location { Id = 11, Name = "Skåne" },
                 new Location { Id = 12, Name = "Stockholm" },
                 new Location { Id = 13, Name = "Södermanland" },
                 new Location { Id = 14, Name = "Uppsala" },
                 new Location { Id = 15, Name = "Värmland" },
                 new Location { Id = 16, Name = "Västerbotten" },
                 new Location { Id = 17, Name = "Västernorrland" },
                 new Location { Id = 18, Name = "Västmanland" },
                 new Location { Id = 19, Name = "Västra Götaland" },
                 new Location { Id = 20, Name = "Örebro" },
                 new Location { Id = 21, Name = "Östergötland" }

              );

            modelBuilder.Entity<SubLocation>()
             .HasData(
                //TODO antingen ha färre locations eller ha åtminstonde 1 sublocation för varje location
                new SubLocation { Id = 1, Name = "Botkyrka", LocationId = 12 },
                new SubLocation { Id = 2, Name = "Solna", LocationId = 12 },
                new SubLocation { Id = 3, Name = "Huddinge", LocationId = 12 },
                new SubLocation { Id = 4, Name = "Lidingö", LocationId = 12 },
                new SubLocation { Id = 5, Name = "Stockholm", LocationId = 12 },
                new SubLocation { Id = 6, Name = "Ronneby", LocationId = 1 },
                new SubLocation { Id = 7, Name = "Karlskrona", LocationId = 1 },
                new SubLocation { Id = 8, Name = "Karlskoga" , LocationId = 20},
                new SubLocation { Id = 9, Name = "Alvesta" , LocationId = 9},
                new SubLocation { Id = 10, Name = "Kiruna" , LocationId = 10},
                new SubLocation { Id = 11, Name = "Malmö" , LocationId = 11}
             );

        }
    }
}
