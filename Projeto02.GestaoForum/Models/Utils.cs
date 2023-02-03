using Microsoft.AspNetCore.Identity;

namespace Projeto02.GestaoForum.Models
{
    public class Utils
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "ADMIN", "USER", "GUEST" };

            IdentityResult result;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    result = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
