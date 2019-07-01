using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Data
{
    public class SeedDatabase
    {
        public static async Task CreateUserRoleAsync(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            IdentityResult roleResult;
            //Adding Admin Role
            var adminRoleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!adminRoleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            //Adding User Role
            var userRoleCheck = await RoleManager.RoleExistsAsync("User");
            if (!userRoleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("User"));
            }
            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            ApplicationUser user01 = await UserManager.FindByNameAsync("Root");
            await UserManager.AddToRoleAsync(user01, "Admin");

            //Assign User role to the main User here we have given our newly registered 
            ApplicationUser user02 = await UserManager.FindByNameAsync("Manager");
            await UserManager.AddToRoleAsync(user02, "User");

        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<PersonalNotesDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                ApplicationUser user01 = new ApplicationUser()
                {
                    Email = "a@b.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Root"
                };
                userManager.CreateAsync(user01, "Root@123"); // admin is password
            }
            ApplicationUser user02 = new ApplicationUser()
            {
                Email = "a@b.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Manager"
            };
            userManager.CreateAsync(user02, "Manager@123");
        }
    }
}
