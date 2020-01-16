using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AssistenciaTecnica.Domain.Identity
{
    public class Role : IdentityRole<int>
    {
        public List<UserRole> userRoles { get; set; }
    }
}