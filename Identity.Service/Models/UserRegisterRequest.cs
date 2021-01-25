using System;

namespace Identity.Service.Models
{
    public class UserRegisterRequest
    {
        //public string Password { get; set; }
        //public string Email { get; set; }
        
        public string UserName { get; set; }
        public string Pin { get; set; }
        public string ProfileId { get; set; }
        public string Role { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }
    }
}