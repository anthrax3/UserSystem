namespace UserSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexPageViewModel
    {
        public IEnumerable<UserConciseViewModel> Users { get; set; }
    }
}