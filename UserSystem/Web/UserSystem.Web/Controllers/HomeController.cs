namespace UserSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using UserSystem.Data.UnitOfWork;

    public class HomeController : BaseController
    {
        public HomeController(IUserSystemData data)
            : base(data)
        {
        }

        // GET: Home
        public ActionResult Index()
        {
            return this.View();
        }
    }
}