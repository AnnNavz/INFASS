namespace INFASS.Models
{
    public class LoginLogs
    {
        public string Username {  get; set; }
        public string Password { get; set; }
        public DateOnly DateIn {  get; set; }
        public TimeOnly TimeIn { get; set; }
    }
}
