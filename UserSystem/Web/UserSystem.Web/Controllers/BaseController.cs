namespace UserSystem.Web.Controllers
{
    using System.Web.Mvc;

    using UserSystem.Data.UnitOfWork;

    public class BaseController : Controller
    {
        protected BaseController(IUserSystemData data)
        {
            this.Data = data;
        }

        public IUserSystemData Data { get; }
    }
}