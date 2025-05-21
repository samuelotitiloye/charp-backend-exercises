namespace InActiveLoginTracker.Models
{
    public class UserLogin
    {
        public string? UserId { get; set; }
        public DateTime LastLogin { get; set; }
    }
}