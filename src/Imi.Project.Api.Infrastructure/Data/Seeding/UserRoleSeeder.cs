using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class UserRoleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000003",
                    UserId = "00000000-0000-0000-0000-000000000006"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000002",
                    UserId = "00000000-0000-0000-0000-000000000001"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000001",
                    UserId = "00000000-0000-0000-0000-000000000002"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000001",
                    UserId = "00000000-0000-0000-0000-000000000003"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000001",
                    UserId = "00000000-0000-0000-0000-000000000004"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000001",
                    UserId = "00000000-0000-0000-0000-000000000005"
                }

                );
        }
    }
}
