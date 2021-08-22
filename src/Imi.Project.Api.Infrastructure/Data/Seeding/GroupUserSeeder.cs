using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class GroupUserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupUser>().HasData(
               new GroupUser { GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"), UserId = "00000000-0000-0000-0000-000000000001" },
               new GroupUser { GroupId = Guid.Parse("00000000-0000-0000-0000-000000000002"), UserId = "00000000-0000-0000-0000-000000000002" },
               new GroupUser { GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"), UserId = "00000000-0000-0000-0000-000000000002" },
               new GroupUser { GroupId = Guid.Parse("00000000-0000-0000-0000-000000000004"), UserId = "00000000-0000-0000-0000-000000000002" },
               new GroupUser { GroupId = Guid.Parse("00000000-0000-0000-0000-000000000005"), UserId = "00000000-0000-0000-0000-000000000003" }
               );
        }
    }
}
