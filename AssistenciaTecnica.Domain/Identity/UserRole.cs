
using Microsoft.AspNetCore.Identity;

namespace AssistenciaTecnica.Domain.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public User user { get; set; }
        public Role role { get; set; }
    }
}