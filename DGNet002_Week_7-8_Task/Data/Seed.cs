using DGNet002_Week_7_8_Task.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace DGNet002_Week_7_8_Task.Data
{
    public class Seed
    {
        public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));


                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AdminUser>>();

                string adminUserEmail = "fabbenco97@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if (adminUser == null)
                {
                    var newAdminUser = new AdminUser()
                    {
						Name = "Fabian Muoghalu",
						UserName = "@fabbenco",
                        Email = adminUserEmail,
						City = "PortHarcout",
						Address = "Alcon Road, Woji",
						PhoneNumber = "08104636559",
                        EmailConfirmed = true,
					};
                    await userManager.CreateAsync(newAdminUser, "Fabb@122");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
			};
		}



        public static void SeedData(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var hasher = new PasswordHasher<AdminUser>();

                var admin = new AdminUser()
                {                   
                    Name = "Fabian Muoghalu",
                    Email = "fabbenco97@gmail.com",
                    UserName = "@fabbenco",
                    City = "PortHarcout",
                    Address = "Alcon Road, Woji",
                    PhoneNumber = "08104636559",
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                admin.PasswordHash = hasher.HashPassword(admin, "Fabb@122");

                context.Users.Add(admin);
                context.SaveChanges();

            }

        }
    }
}
