using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PokemonRepo.Domain;
using PokemonRepo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoemonRepo
{
    public class Program
    {
        public static void Main(string[] args)
        {
          
            var host = CreateHostBuilder(args).Build();
            //create Admin User
            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                    context.Database.Migrate();
                    if (!context.UserClaims.Any())
                    {
                        var adminUser = new ApplicationUser()
                        {
                            UserName = "admin",
                            PhotoPath = "AdminPicture.jpg"
                        };

                        var result = userManager.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            PokemonRepo.API.ApiHelper.InitilizeClient();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
