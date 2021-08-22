using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class UserEventSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEvent>().HasData(
                new UserEvent { EventId = Guid.Parse("00000000-0000-0000-0000-000000000001"), UserId = "00000000-0000-0000-0000-000000000001" },
                new UserEvent { EventId = Guid.Parse("00000000-0000-0000-0000-000000000002"), UserId = "00000000-0000-0000-0000-000000000001" },
                new UserEvent { EventId = Guid.Parse("00000000-0000-0000-0000-000000000003"), UserId = "00000000-0000-0000-0000-000000000001" },
                new UserEvent { EventId = Guid.Parse("00000000-0000-0000-0000-000000000004"), UserId = "00000000-0000-0000-0000-000000000001" },
                new UserEvent { EventId = Guid.Parse("00000000-0000-0000-0000-000000000001"), UserId = "00000000-0000-0000-0000-000000000002" },
                new UserEvent { EventId = Guid.Parse("00000000-0000-0000-0000-000000000002"), UserId = "00000000-0000-0000-0000-000000000002" },
                new UserEvent { EventId = Guid.Parse("00000000-0000-0000-0000-000000000002"), UserId = "00000000-0000-0000-0000-000000000003" },
                new UserEvent { EventId = Guid.Parse("00000000-0000-0000-0000-000000000004"), UserId = "00000000-0000-0000-0000-000000000003" },
                new UserEvent { EventId = Guid.Parse("00000000-0000-0000-0000-000000000005"), UserId = "00000000-0000-0000-0000-000000000004" },
                new UserEvent { EventId = Guid.Parse("00000000-0000-0000-0000-000000000005"), UserId = "00000000-0000-0000-0000-000000000005" }

                );
        }
    }
}
