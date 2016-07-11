namespace UserSystem.Web.ViewModels.Users
{
    using UserSystem.Data.Models;
    using UserSystem.Web.Infrastructure.Mapping;

    public class UserConciseViewModel : IMapFrom<User>
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string PhotoUrl { get; set; }

        public Status Status { get; set; }
    }
}