using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Data.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        //dotnet ef migrations add "InitialMigration" -s .\Imi.Project.Api\ -p .\Imi.Project.Api.Infrastructure\
        //dotnet ef database update -s .\Imi.Project.Api\ -p .\Imi.Project.Api.Infrastructure\
        public DbSet<Event> Events { get; set; }
        public DbSet<Opening> Openings { get; set; }
        public DbSet<OpeningMove> OpeningMoves { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameMove> GamesMoves { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<Group> Groups{ get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserEvent>()
                .ToTable("UserEvent")
                .HasKey(ue => new { ue.UserId, ue.EventId });
            modelBuilder.Entity<UserEvent>()
                .HasOne(ue => ue.User)
                .WithMany(e => e.UserEvents)
                .HasForeignKey(ue => ue.UserId);
            modelBuilder.Entity<UserEvent>()
                .HasOne(ue => ue.Event)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(ue => ue.EventId);



            modelBuilder.Entity<GroupUser>()
                .ToTable("GroupUser")
                .HasKey(gu => new { gu.UserId, gu.GroupId });
            modelBuilder.Entity<GroupUser>()
                .HasOne(gu => gu.Group)
                .WithMany(e => e.GroupUsers)
                .HasForeignKey(gu => gu.GroupId);
            modelBuilder.Entity<GroupUser>()
                .HasOne(gu => gu.User)
                .WithMany(u => u.GroupUsers)
                .HasForeignKey(gu => gu.UserId);

            EventSeeder.Seed(modelBuilder);
            GroupSeeder.Seed(modelBuilder);
            UserSeeder.Seed(modelBuilder);
            ClaimSeeder.Seed(modelBuilder);
            RoleSeeder.Seed(modelBuilder);
            UserRoleSeeder.Seed(modelBuilder);
            UserEventSeeder.Seed(modelBuilder);
            OpeningSeeder.Seed(modelBuilder);
            OpeningMoveSeeder.Seed(modelBuilder);
            GameSeeder.Seed(modelBuilder);
            PostSeeder.Seed(modelBuilder);
            CommentSeeder.Seed(modelBuilder);
            
            NamedNajiMovesSeeder.Seed(modelBuilder);
            DriezeGamesSeeder.Seed(modelBuilder);
            //SiggedGamesSeeder.Seed(modelBuilder);
            //willschokGameSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }
    }
}
