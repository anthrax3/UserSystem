namespace UserSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using PagedList;

    using UserSystem.Data.Models;
    using UserSystem.Data.UnitOfWork;
    using UserSystem.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private const int UsersPerPageDefaultValue = 15;

        public HomeController(IUserSystemData data)
            : base(data)
        {
        }

        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var users = this.Data.Users.All().Where(u => u.Status != Status.Deleted).ProjectTo<UserConciseViewModel>().ToList();
            var viewModel = new IndexPageViewModel { Users = users };
            var model = viewModel.Users.ToPagedList(pageNumber, UsersPerPageDefaultValue);

            return this.View(model);
        }
    }
}