namespace UserSystem.Web.ViewModels.Users
{
    using UserSystem.Data.Models;
    using UserSystem.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Sex { get; set; }

        public string Telephone { get; set; }

        public string PhotoUrl { get; set; }

        public Status Status { get; set; }
    }
}