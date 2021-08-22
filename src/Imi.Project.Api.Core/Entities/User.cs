using Imi.Project.Api.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(10)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; } //Users who are interested in a certain event
        public ICollection<GroupUser> GroupUsers { get; set; }
    }
}
