using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerceApp.Data;
using Microsoft.Extensions.DependencyInjection;


namespace ECommerceApp.Models
{
    public class RoleInitializer
    {
        //Let's make a list of roles that we want to "add" into our db
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = ApplicationRoles.Member, NormalizedName = ApplicationRoles.Member.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()},

            new IdentityRole{Name = ApplicationRoles.Member, NormalizedName = ApplicationRoles.Member.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()}
        };

        public static void SeedData(IServiceProvider serviceProvider)
        {
            //opens connection to db
            using (var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //ensures db has been created
                dbContext.Database.EnsureCreated();
                // Add Roles to the db
                AddRoles(dbContext);
            }
        }

        private static void AddRoles(ApplicationDbContext context)
        {
            //check to see if there is anything in the db first
            if (context.Roles.Any()) return;

            //add role to db and save (do not save async - next task should NOT run until this is done)
            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

    }
}
