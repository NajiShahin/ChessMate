using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Users
{
    public class UsersRequestDto : DtoBase
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }
    }
}
