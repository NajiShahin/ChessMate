using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class PostSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
               new Post { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Title = "Chessplayers", Content = "Hello everyone, who is your favorite chessplayers?", DateAdded = DateTime.Now.Date},
               new Post { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Title = "Chess openings", Content = "What openings have the best winrate", DateAdded = DateTime.Now.Date },
               new Post { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Title = "Favorite opening", Content = "Hey guys, whats your favorite openings?", DateAdded = DateTime.Now.Date },
               new Post { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Title = "Chess beginner", Content = "I'm new to chess, does anyone have any tips for me?", DateAdded = DateTime.Now.Date },
               new Post { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Title = "Endgame", Content = "Does anyone have any tips for endgames?", DateAdded = DateTime.Now.Date }
               );
        }
    }
}
