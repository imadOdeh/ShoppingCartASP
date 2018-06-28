using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCartASP.Models;

namespace ShoppingCartASP
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services
                .GetRequiredService<RoleManager<IdentityRole>>();

            await EnsureRolesAsync(roleManager);
             
            var userManager = services
                .GetRequiredService<UserManager<ApplicationUser>>();

            await EnsureTestAdminAsync(userManager);
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager.RoleExistsAsync("Administrator");

            if (alreadyExists) return;

            await roleManager.CreateAsync(new IdentityRole("Administrator"));
        }

        private static async Task EnsureTestAdminAsync(UserManager<ApplicationUser> userManager)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == "en.imadodeh@hotmail.com")
                .SingleOrDefaultAsync();

            if (testAdmin != null) return;

            testAdmin = new ApplicationUser
            {
                UserName = "en.imadodeh@hotmail.com",
                Email = "en.imadodeh@hotmail.com",
            };

            await userManager.CreateAsync(testAdmin, "P@ssw0rd");
            await userManager.AddToRoleAsync(testAdmin, "Administrator");
        }
    }
}
