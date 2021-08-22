using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class ClaimSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(//birthdate
               new IdentityUserClaim<string> { Id = 1, UserId = "00000000-0000-0000-0000-000000000006", ClaimType = "registration-date", ClaimValue = "28-04-18" },
               new IdentityUserClaim<string> { Id = 2, UserId = "00000000-0000-0000-0000-000000000001", ClaimType = "registration-date", ClaimValue = "10-01-19" },
               new IdentityUserClaim<string> { Id = 3, UserId = "00000000-0000-0000-0000-000000000002", ClaimType = "registration-date", ClaimValue = "22-11-20" },
               new IdentityUserClaim<string> { Id = 4, UserId = "00000000-0000-0000-0000-000000000003", ClaimType = "registration-date", ClaimValue = "17-08-01" },
               new IdentityUserClaim<string> { Id = 5, UserId = "00000000-0000-0000-0000-000000000004", ClaimType = "registration-date", ClaimValue = "05-01-21" },
               new IdentityUserClaim<string> { Id = 6, UserId = "00000000-0000-0000-0000-000000000005", ClaimType = "registration-date", ClaimValue = "01-01-21" },
               new IdentityUserClaim<string> { Id = 7, UserId = "00000000-0000-0000-0000-000000000001", ClaimType = "name", ClaimValue = "Shahinnaji" },
               new IdentityUserClaim<string> { Id = 8, UserId = "00000000-0000-0000-0000-000000000002", ClaimType = "name", ClaimValue = "Jantje" },
               new IdentityUserClaim<string> { Id = 9, UserId = "00000000-0000-0000-0000-000000000003", ClaimType = "name", ClaimValue = "Tommy" },
               new IdentityUserClaim<string> { Id = 10, UserId = "00000000-0000-0000-0000-000000000004", ClaimType = "name", ClaimValue = "Timmy" },
               new IdentityUserClaim<string> { Id = 11, UserId = "00000000-0000-0000-0000-000000000005", ClaimType = "name", ClaimValue = "Billy" },
               new IdentityUserClaim<string> { Id = 12, UserId = "00000000-0000-0000-0000-000000000006", ClaimType = "name", ClaimValue = "Admin" },
               new IdentityUserClaim<string> { Id = 13, UserId = "00000000-0000-0000-0000-000000000001", ClaimType = "id", ClaimValue = "00000000-0000-0000-0000-000000000001" },
               new IdentityUserClaim<string> { Id = 14, UserId = "00000000-0000-0000-0000-000000000002", ClaimType = "id", ClaimValue = "00000000-0000-0000-0000-000000000002" },
               new IdentityUserClaim<string> { Id = 15, UserId = "00000000-0000-0000-0000-000000000003", ClaimType = "id", ClaimValue = "00000000-0000-0000-0000-000000000003" },
               new IdentityUserClaim<string> { Id = 16, UserId = "00000000-0000-0000-0000-000000000004", ClaimType = "id", ClaimValue = "00000000-0000-0000-0000-000000000004" },
               new IdentityUserClaim<string> { Id = 17, UserId = "00000000-0000-0000-0000-000000000005", ClaimType = "id", ClaimValue = "00000000-0000-0000-0000-000000000005" },
               new IdentityUserClaim<string> { Id = 18, UserId = "00000000-0000-0000-0000-000000000006", ClaimType = "id", ClaimValue = "00000000-0000-0000-0000-000000000006" },
               new IdentityUserClaim<string> { Id = 19, UserId = "00000000-0000-0000-0000-000000000001", ClaimType = "birthdate", ClaimValue = "20/11/2000" },
               new IdentityUserClaim<string> { Id = 20, UserId = "00000000-0000-0000-0000-000000000002", ClaimType = "birthdate", ClaimValue = "14/05/1998" },
               new IdentityUserClaim<string> { Id = 21, UserId = "00000000-0000-0000-0000-000000000003", ClaimType = "birthdate", ClaimValue = "04/05/1992" },
               new IdentityUserClaim<string> { Id = 22, UserId = "00000000-0000-0000-0000-000000000004", ClaimType = "birthdate", ClaimValue = "14/06/1989" },
               new IdentityUserClaim<string> { Id = 23, UserId = "00000000-0000-0000-0000-000000000005", ClaimType = "birthdate", ClaimValue = "09/05/2000" },
               new IdentityUserClaim<string> { Id = 24, UserId = "00000000-0000-0000-0000-000000000006", ClaimType = "birthdate", ClaimValue = "18/02/1999" }
               );
        }
    }
}

/*

"Shahin.naji@student.howest.be", DateOfBirth = DateTime.Parse("")},
ntje@student.howest.be", DateOfBirth = DateTime.Parse("") },
", DateOfBirth = DateTime.Parse("") },
", DateOfBirth = DateTime.Parse("") },
ail.com", DateOfBirth = DateTime.Parse("") }


*/
