using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class GroupSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(
               new Group { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Super fun group", Description = "Super fun group for chess players", DateMade = DateTime.Parse("19/04/2021 00:00:00") },
               new Group { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Chess group", Description = "This is a chess group", DateMade = DateTime.Parse("24/04/2021 00:00") },
               new Group { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Openings group", Description = "A group for learning openings", DateMade = DateTime.Parse("27/04/2021 00:00") },
               new Group { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Endagme educators", Description = "A group for learning endgames", DateMade = DateTime.Parse("12/05/2021 00:00") },
               new Group { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Middle game chess", Description = "A group where we teach everything about the middle game", DateMade = DateTime.Parse("18/05/2021 00:00") }
               );
        }
    }
}
