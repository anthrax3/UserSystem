namespace UserSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using UserSystem.Web.ViewModels.Users;

    public class IndexPageViewModel
    {
        public IEnumerable<UserConciseViewModel> Users { get; set; }
    }
}