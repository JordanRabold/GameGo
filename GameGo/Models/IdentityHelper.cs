using Microsoft.AspNetCore.Identity;

namespace GameGo.Models
{
#nullable disable
    public static class IdentityHelper
    {
        public const string Administrator = "Administrator";
        public const string User = "User";

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetService<RoleManager<IdentityRole>>();

            foreach(string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task CreateDefaultUser(IServiceProvider provider, string role)
        {
            var userManager = provider.GetService<UserManager<IdentityUser>>();

            // If no users present, make the deafult user
            int numUsers = (await userManager.GetUsersInRoleAsync(role)).Count;
            if(numUsers == 0) // If no users are in the specified role
            {
                var defaultUser = new IdentityUser()
                {
                    Email = "admin@GameGo.com",
                    UserName = "Admin"
                };

                await userManager.CreateAsync(defaultUser, "Programming#01");

                await userManager.AddToRoleAsync(defaultUser, role);
            }
        }
    }
}
