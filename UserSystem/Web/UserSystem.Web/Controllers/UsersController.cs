namespace UserSystem.Web.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using UserSystem.Data.Models;
    using UserSystem.Data.UnitOfWork;
    using UserSystem.Web.ViewModels.Users;

    public class UsersController : BaseController
    {
        public UsersController(IUserSystemData data)
            : base(data)
        {
        }

        public ActionResult Profile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = this.Data.Users.Find(id);
            if (user == null)
            {
                return this.HttpNotFound();
            }

            var model = this.Data.Users.All().Where(u => u.Id == id).ProjectTo<UserViewModel>().FirstOrDefault();

            return this.View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = this.Data.Users.Find(id);
            if (user == null)
            {
                return this.HttpNotFound();
            }

            return this.View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Username,Email,FirstName,LastName,Sex,Telephone,PhotoUrl,Status")] User user)
        {
            if (this.ModelState.IsValid)
            {
                this.Data.Users.Update(user);
                this.Data.SaveChanges();

                return this.RedirectToAction("Profile", "Users", new { area = string.Empty, id = user.Id });
            }

            return this.View(user);
        }
    }
}