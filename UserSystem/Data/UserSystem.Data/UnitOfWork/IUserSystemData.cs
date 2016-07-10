namespace UserSystem.Data.UnitOfWork
{
    using UserSystem.Data.Models;
    using UserSystem.Data.Repositories;

    public interface IUserSystemData
    {
        IRepository<User> Users { get; }

        int SaveChanges();
    }
}