using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string moderatorUserName = "Moderator";
            string moderatorEmail = "moderator@gmail.com";
            string password = "Moder@2000";
            if (await roleManager.FindByNameAsync("moderator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("moderator"));
            }
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByEmailAsync(moderatorEmail) == null)
            {
                IdentityUser moderator = new IdentityUser { Email = moderatorEmail, UserName = moderatorUserName };
                IdentityResult result = await userManager.CreateAsync(moderator, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(moderator, "moderator");
                }
            }
        }
    }
}
