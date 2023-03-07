using Identity.API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Domain
{
    public class ApplicationDbContextSeed
    {
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();

        public async Task SeedAsync(ApplicationDbContext context, IWebHostEnvironment env,
            ILogger<ApplicationDbContextSeed> logger, int? retry = 0)
        {
            int retryForAvaiability = retry.Value;

            try
            {
                var contentRootPath = env.ContentRootPath;
                var webroot = env.WebRootPath;

                if (!context.Users.Any())
                {
                    context.Users.AddRange(GetDefaultUsers());

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvaiability < 10)
                {
                    retryForAvaiability++;

                    logger.LogError(ex, "EXCEPTION ERROR while migrating {DbContextName}", nameof(ApplicationDbContext));

                    await SeedAsync(context, env, logger, retryForAvaiability);
                }
            }
        }


        private IEnumerable<ApplicationUser> GetDefaultUsers()
        {
            var user =
            new ApplicationUser()
            {
                Email = "demouser@kienchu.blogspot.com",
                Id = Guid.NewGuid().ToString(),
                LastName = "User",
                FirstName = "Demo",
                PhoneNumber = "1234567890",
                UserName = "demouser@kienchu.blogspot.com",
                NormalizedEmail = "DEMOUSER@KIENCHU.BLOGSPOT.COM",
                NormalizedUserName = "DEMOUSER@KIENCHU.BLOGSPOT.COM",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, "Pass@word1");

            return new List<ApplicationUser>()
            {
                user
            };
        }
    }
}
