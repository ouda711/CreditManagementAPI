using System;
using Microsoft.AspNetCore.Identity;

namespace CreditManagementTest.Entities
{
    // [Serializable]
    public class AppUserRole : IdentityUserRole<long>
    {
        public override long UserId { get; set; }
        public override long RoleId { get; set; }
        public  ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
        
    }
}