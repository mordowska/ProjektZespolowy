using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public static class DbInitializer
    {

        public async static void SeedUsersAndRoles(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Admin";


                IdentityResult result = userManager.CreateAsync
                (user, "P@ssw0rd").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("User").Result == null)
            {
                IdentityUser user2 = new IdentityUser();
                user2.UserName = "User";


                IdentityResult result2 = userManager.CreateAsync
                (user2, "P@ssw0rd").Result;

                if (result2.Succeeded)
                {
                    userManager.AddToRoleAsync(user2,
                                        "User").Wait();
                }
            }

        }

        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();
            if (!context.Pies.Any())
            {
                context.AddRange
                (
                    new Pie { Name = "Apple Pie", Price = 12.95M, ShortDescription = "Our famous apple pies!", LongDescription = "Apple cake", ImageThumbnailUrl = "/images/apple.png", ImageUrl = "/images/apple.png" },
                    new Pie { Name = "Bluberry Cheese Cake", Price = 12.95M, ShortDescription = "You'll love it!", LongDescription = "Blueberry cake", ImageThumbnailUrl = "/images/blueberry.png", ImageUrl = "/images/blueberry.png" },
                    new Pie { Name = "Cheese Cake", Price = 18.95M, ShortDescription = "Plain cheese cake. Plain pleasure.", LongDescription = "Cheese cake", ImageThumbnailUrl = "/images/cheese.png", ImageUrl = "/images/cheese.png" },
                    new Pie { Name = "Cherry Cake", Price = 15.95M, ShortDescription = "A summer classic!", LongDescription = "Cherry cake", ImageThumbnailUrl = "/images/cherry.png", ImageUrl = "/images/cherry.png" },
                    new Pie { Name = "Peach Cake", Price = 15.95M, ShortDescription = "A summer classic too!", LongDescription = "Peach cake", ImageThumbnailUrl = "/images/peach.png", ImageUrl = "/images/peach.png" },
                    new Pie { Name = "Pumpkin Cake", Price = 15.95M, ShortDescription = "A halloween classic!", LongDescription = "Pumpkin cake", ImageThumbnailUrl = "/images/pumpkin.png", ImageUrl = "/images/pumpkin.png" }
                );

                context.SaveChanges();
            }
        }
    }
}
