namespace Allin.Admin.Infrastructure.Persistence.Entities
{
    //Table("Users", Schema = "Admin")]
    public class User : AdminBaseEntity
    {
        public long PersonId { get; set; }
        public string Username { get; set; }
        public bool IsBlocked { get; set; }
        public long BlockedReasonBaseId { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public int FailedCount { get; set; }
        public DateTime? LastOnlineTime { get; set; }
    }
}
