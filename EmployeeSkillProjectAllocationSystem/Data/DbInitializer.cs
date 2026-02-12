using Microsoft.AspNetCore.Identity;

namespace EmployeeSkillProjectAllocationSystem.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndAdminAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            string[] roles = { "Employee", "Manager", "HR" };

            foreach(var role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            string hrEmail = "nikhilhr@gmail.com";
            string hrPassword = "@Pran33th@";

            var hruser = await userManager.FindByEmailAsync(hrEmail);
            if(hruser == null)
            {
                var user = new IdentityUser
                {
                    UserName = hrEmail,
                    Email = hrEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, hrPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "HR");
                }
            } 
        }
    }
}
