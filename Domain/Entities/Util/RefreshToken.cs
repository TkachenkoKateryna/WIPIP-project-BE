using Domain.Entities.Base;

namespace Domain.Entities.Util
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; } = DateTime.Now.AddDays(7);
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime? Revoked { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;

        public User User { get; set; }
        public string UserId { get; set; }
    }
}
