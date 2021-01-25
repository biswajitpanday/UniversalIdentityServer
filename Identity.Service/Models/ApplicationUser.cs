using System;
using Microsoft.AspNetCore.Identity;

namespace Identity.Service.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Guid ProfileId { get; set; }
    }
}