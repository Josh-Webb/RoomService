using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRunnerCoordinator.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }
        public int RoleId { get; set; }
        
    }
}
