namespace UserSystem.Web.ViewModels.Home
{
    using UserSystem.Data.Models;

    public class UserConciseViewModel
    {
        public string Username { get; set; }

        public string PhotoUrl { get; set; }

        public Status Status { get; set; }
    }
}