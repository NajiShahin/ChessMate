using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            IEnumerable<User> users = new List<User>
            {
                new User { Id = "00000000-0000-0000-0000-000000000006", UserName = "Admin", FirstName = "Admin", LastName = "Istrator", CityName = "Brugge", HouseNumber = 11, StreetName = "Sint-Jorisstraat", PostalCode = "8000", Email = "Admin.Istrator@student.howest.be", DateOfBirth = DateTime.Parse("18/02/1999")},
                new User { Id = "00000000-0000-0000-0000-000000000001", UserName = "namednaji", FirstName = "Shahin", LastName = "Naji", CityName = "Brugge", HouseNumber = 71, StreetName = "Sint-Jorisstraat", PostalCode = "8000", Email = "Shahin.naji@student.howest.be", DateOfBirth = DateTime.Parse("20/11/2000")},
                new User { Id = "00000000-0000-0000-0000-000000000002", UserName = "Drieze", FirstName = "Dries", LastName = "Deboosere", CityName = "Brugge", HouseNumber = 10, StreetName = "Sint-Jorisstraat", PostalCode = "8000", Email = "DDeboosere@gmail.com", DateOfBirth = DateTime.Parse("14/05/1998") },
                new User { Id = "00000000-0000-0000-0000-000000000003", UserName = "Timmy", FirstName = "Tim", LastName = "DeBleecker", CityName = "Oostende", HouseNumber = 2, StreetName = "Beekstraat", PostalCode = "8400", Email = "Tim@gmail.com", DateOfBirth = DateTime.Parse("04/05/1992") },
                new User { Id = "00000000-0000-0000-0000-000000000004", UserName = "Sigged", FirstName = "Siegfried", LastName = "Derdeyn", CityName = "Oostkamp", HouseNumber = 8, StreetName = "Zuidstraat", PostalCode = "8020", Email = "Siegfried@gmail.com", DateOfBirth = DateTime.Parse("14/06/1989") },
                new User { Id = "00000000-0000-0000-0000-000000000005", UserName = "wilschok", FirstName = "William", LastName = "Schokkele", CityName = "Brugge", HouseNumber = 28, StreetName = "elf julistraat", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("09/05/2000") },


                new User { Id = "6121e077-ab8e-4f68-a0b1-3ed9586ec49e", UserName = "Bobdebouwer", FirstName = "Yanis", LastName = "Sahin", CityName = "Brugge", HouseNumber = 28, StreetName = "Blekersdijk", PostalCode = "8000", Email = "Yanis@gmail.com", DateOfBirth = DateTime.Parse("10/06/2000") },
                new User { Id = "98c1df59-7ced-4c3d-a5b1-7d6e2a65c959", UserName = "wistfuldrawer", FirstName = "Mathis", LastName = "Thys", CityName = "Brugge", HouseNumber = 22, StreetName = "Strepestraat", PostalCode = "8000", Email = "Mathis@gmail.com", DateOfBirth = DateTime.Parse("06/07/1975") },
                new User { Id = "54e26239-6abc-4157-9653-6fb3b3733038", UserName = "aidetwang", FirstName = "Gilles", LastName = "Verbruggen", CityName = "Brugge", HouseNumber = 16, StreetName = "Populierenstraat", PostalCode = "8000", Email = "Gilles@gmail.com", DateOfBirth = DateTime.Parse("05/08/1988") },
                new User { Id = "08c53524-6537-445e-9fb7-e4fff06b4ec9", UserName = "literallywilling", FirstName = "Alexandre", LastName = "De Meyer", CityName = "Brugge", HouseNumber = 4, StreetName = "Hauwaart", PostalCode = "8000", Email = "Alexandre@gmail.com", DateOfBirth = DateTime.Parse("04/09/1988") },

                new User { Id = "7e8b4c3f-19c0-4ca9-8243-05c857b40434", UserName = "fragilemoreover", FirstName = "Alexander", LastName = "", CityName = "Brugge", HouseNumber = 175, StreetName = "", PostalCode = "8000", Email = "@gmail.com", DateOfBirth = DateTime.Parse("11/01/1979") },
                new User { Id = "48dc43af-f72c-43d2-8bea-7fa3a005d486", UserName = "scoreencode", FirstName = "Elias", LastName = "", CityName = "Brugge", HouseNumber = 17, StreetName = "", PostalCode = "8000", Email = "@gmail.com", DateOfBirth = DateTime.Parse("10/02/2004") },
                new User { Id = "e5f375db-a859-4e80-a091-8f98a67c9f7c", UserName = "wearpeppermint", FirstName = "Niels", LastName = "", CityName = "Brugge", HouseNumber = 45, StreetName = "", PostalCode = "8000", Email = "@gmail.com", DateOfBirth = DateTime.Parse("29/03/2001") },
                new User { Id = "0a9bedb1-79c9-491a-ace9-733c90826d04", UserName = "ellipticalprotection", FirstName = "Adam", LastName = "", CityName = "Brugge", HouseNumber = 13, StreetName = "", PostalCode = "8000", Email = "@gmail.com", DateOfBirth = DateTime.Parse("28/04/2000") },
                new User { Id = "306c9605-4331-4325-9732-2ec8feb59cb3", UserName = "caponpebble", FirstName = "Romain", LastName = "", CityName = "Brugge", HouseNumber = 1, StreetName = "", PostalCode = "8000", Email = "@gmail.com", DateOfBirth = DateTime.Parse("27/05/1999") },
                new User { Id = "0d6ff7d4-48ad-458c-92a4-5e1388e0c38d", UserName = "steerinsistent", FirstName = "Gilles", LastName = "", CityName = "Brugge", HouseNumber = 28, StreetName = "", PostalCode = "8000", Email = "@gmail.com", DateOfBirth = DateTime.Parse("26/05/2007") },
                new User { Id = "aae98216-e374-4862-a8de-321c7bd1288e", UserName = "currantsfrontal", FirstName = "Mohammed", LastName = "", CityName = "Brugge", HouseNumber = 84, StreetName = "", PostalCode = "8000", Email = "@gmail.com", DateOfBirth = DateTime.Parse("25/05/1972") },
                new User { Id = "e4e5697e-123d-4248-a69a-e249b2348573", UserName = "rivershort", FirstName = "Robbe", LastName = "", CityName = "Brugge", HouseNumber = 5, StreetName = "", PostalCode = "8000", Email = "@gmail.com", DateOfBirth = DateTime.Parse("24/06/2004") },
                new User { Id = "86a77940-413b-4ee1-b5c8-3febeadc9282", UserName = "twicescallops", FirstName = "Robbe", LastName = "", CityName = "Brugge", HouseNumber = 58, StreetName = "", PostalCode = "8000", Email = "@gmail.com", DateOfBirth = DateTime.Parse("23/09/2002") },
                new User { Id = "3741790f-ac44-42a2-8af2-aab262ecb12f", UserName = "cowardicecanon", FirstName = "Guillaume", LastName = "", CityName = "Brugge", HouseNumber = 268, StreetName = "", PostalCode = "8000", Email = "@gmail.com", DateOfBirth = DateTime.Parse("22/12/2003") },
                                                                                    
                new User { Id = "7acfff53-df44-4584-ad84-d99fe3d19d66", UserName = "bruisebobcat", FirstName = "Guillaume", LastName = "", CityName = "Brugge", HouseNumber = 278, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("21/11/1999") },
                new User { Id = "6b19c124-fd82-4445-9525-05fed6de7930", UserName = "proportionredneck", FirstName = "Clément", LastName = "", CityName = "Brugge", HouseNumber = 228, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("20/11/1997") },
                new User { Id = "f66ad05d-b6cb-4392-8eda-db236dce1c01", UserName = "althoughironclad", FirstName = "Adrien", LastName = "", CityName = "Brugge", HouseNumber = 128, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("19/11/1990") },
                new User { Id = "8644071c-f297-422c-8968-1d49c234af9c", UserName = "simplycockroach", FirstName = "Axel", LastName = "", CityName = "Brugge", HouseNumber = 228, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("18/12/1995") },
                new User { Id = "b2f97011-ba4c-4659-8681-bac379a3f3c7", UserName = "bowlerlazuli", FirstName = "Victor", LastName = "", CityName = "Brugge", HouseNumber = 8, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("17/05/2000") },
                new User { Id = "3e3be02b-2396-47cb-ae67-57bf7b7b9269", UserName = "blocksratio", FirstName = "Rayan", LastName = "", CityName = "Brugge", HouseNumber = 48, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("16/05/2000") },
                new User { Id = "d78faf34-146c-4418-a6ae-2c84618b6056", UserName = "processplonk", FirstName = "Tristan", LastName = "", CityName = "Brugge", HouseNumber = 85, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("15/05/2001") },
                new User { Id = "06a7f09b-c57f-4503-af01-928c04259d6d", UserName = "informallantern", FirstName = "Tristan", LastName = "", CityName = "Brugge", HouseNumber = 18, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("14/07/2004") },
                new User { Id = "895e1207-db2a-47cf-a1d4-019ec184708d", UserName = "physicistchips", FirstName = "Hamza", LastName = "", CityName = "Brugge", HouseNumber = 228, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("13/08/1960") },
                new User { Id = "a1666cc8-80a9-4e9e-9daf-ff8b926e14b7", UserName = "gentlysecretive", FirstName = "Victor", LastName = "", CityName = "Brugge", HouseNumber = 278, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("12/09/1980") },
                                                                                    
                new User { Id = "f6123e1c-36c0-4043-af14-e89ebaa27032", UserName = "pufferfishsneak", FirstName = "Dylan", LastName = "", CityName = "Brugge", HouseNumber = 33, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("11/09/1973") },
                new User { Id = "f9b05b44-da76-48e9-9174-07740b1c2c92", UserName = "tropicalbombing", FirstName = "Janne", LastName = "", CityName = "Brugge", HouseNumber = 87, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("10/07/1992") },
                new User { Id = "4b203331-ed35-4ef8-ae59-719ab1f9d3cd", UserName = "windboundmental", FirstName = "Baptiste", LastName = "", CityName = "Brugge", HouseNumber = 64, StreetName = "", PostalCode = "8000", Email = "William@gmail.com", DateOfBirth = DateTime.Parse("19/06/1994") }
            };                                                                     
            var hasher = new PasswordHasher<User>();                               
                                                                                   
            foreach (var user in users)                                            
            {                                                                      
                user.PasswordHash = hasher.HashPassword(user, "Test123?");         
                user.NormalizedEmail = user.Email.ToUpper();                       
                user.NormalizedUserName = user.UserName.ToUpper();                 
                switch (user.UserName)                                             
                {                                                                  
                    case "Admin":                                                  
                                                                                   
                        break;                                                     
                    case "Shahinnaji":                                             
                                                                                   
                        break;                                                     
                    default:                                                       
                                                                                   
                        break;                                                     
                }                                                                  
            }                                                                      
            
            modelBuilder.Entity<User>().HasData(
                users
                );
        }

    }
}
