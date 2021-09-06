using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecondHandMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services, string adminPW)
        {
            var rnd = new Random();
            using (var context = new ApplicationDbContext(services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Advertisements.Any()) return;

                var fake = new Faker();

                var userManger = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManger = services.GetRequiredService<RoleManager<IdentityRole>>();

                var roleNames = new[] { "Admin", "User" };

                foreach (var roleName in roleNames)
                {
                    if (await roleManger.RoleExistsAsync(roleName)) continue;

                    var role = new IdentityRole { Name = roleName };
                    var result = await roleManger.CreateAsync(role);

                    if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
                }

                for (int i = 0; i < 50; i++)
                {
                    string firstName = fake.Name.FirstName();
                    string lastName = fake.Name.LastName();
                    var mail = fake.Internet.Email($"{firstName} {lastName}");
                    var user = new ApplicationUser
                    {
                        DisplayName = firstName,
                        Email = mail,
                        UserName = mail,
                    };
                    var res = await userManger.CreateAsync(user, adminPW);
                    var res2 = await userManger.AddToRoleAsync(user, "User");
                }

                var admin = new ApplicationUser
                {
                    DisplayName = "Murtaza",
                    Email = "murtaza_rafi@gmail.com",
                    UserName = "murtaza_rafi@gmail.com"
                };
                await userManger.CreateAsync(admin, adminPW);
                await userManger.AddToRoleAsync(admin, "Admin");

                var users = context.ApplicationUsers.Take(50).ToArray();

                var advertisements = new List<Advertisement>();
                for (int i = 0; i < 50; i++)
                {
                    var advertisement = new Advertisement
                    {
                        Title = fake.Company.CatchPhrase(),
                        Description = fake.Lorem.Random.Words(10),
                        CategoryId = fake.Random.Int(3, 19),
                        LocationId = fake.Random.Int(1, 21),
                        Price = fake.Random.Int(1000, 25000),
                        PublishDate = DateTime.Now.AddDays(fake.Random.Int(-100, 0)),
                        Pictures = new List<Picture>() {
                            new Picture { Path = "C:/Users/Latitude/source/repos/SecondHandMarket/SecondHandMarket/wwwroot/Pics/Laptop.jpg" } },
                        ApplicationUserId = users[i].Id
                    };
                    advertisements.Add(advertisement);
                }
                await context.AddRangeAsync(advertisements);
                await context.SaveChangesAsync();
            }

        }
    }
}
