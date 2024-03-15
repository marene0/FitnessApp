using Microsoft.AspNetCore.Identity;

namespace Identity.Model
{
    public class UserIdentity : IdentityUser   //  , IEquatable<UserIdentity>
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
