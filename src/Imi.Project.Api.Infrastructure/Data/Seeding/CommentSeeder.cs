using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class CommentSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
               new Comment { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), PostId = Guid.Parse("00000000-0000-0000-0000-000000000001"), DateAdded = DateTime.Now.Date, Content = "First" },
               new Comment { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), PostId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DateAdded = DateTime.Now.Date, Content = "I really like the queens gambit" },
               new Comment { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), PostId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DateAdded = DateTime.Now.Date, Content = "My favorite opening as black is the caro kann" },
               new Comment { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), PostId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DateAdded = DateTime.Now.Date, Content = "I really like the sicilian as black" },
               new Comment { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), PostId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DateAdded = DateTime.Now.Date, Content = "I mostly play the Ruy Lopez!" }
               );
        }
    }
}
