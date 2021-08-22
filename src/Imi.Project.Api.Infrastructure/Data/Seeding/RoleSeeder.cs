using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class RoleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "00000000-0000-0000-0000-000000000001", Name = "User", NormalizedName = "USER" },
               new IdentityRole { Id = "00000000-0000-0000-0000-000000000002", Name = "Moderator", NormalizedName = "MODERATOR" },
               new IdentityRole { Id = "00000000-0000-0000-0000-000000000003", Name = "Admin", NormalizedName = "ADMIN" }
               );



        }
    }
}
