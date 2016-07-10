namespace UserSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using UserSystem.Data.UnitOfWork;
    using UserSystem.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        public HomeController(IUserSystemData data)
            : base(data)
        {
        }

        // GET: Home
        public ActionResult Index()
        {
            var users = this.Data.Users.All().ProjectTo<UserConciseViewModel>().ToList();

            var model = new IndexPageViewModel { Users = users };

            return this.View(model);
        }
    }
}