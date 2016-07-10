namespace UserSystem.Data
{
    using System.Data.Entity;

    using UserSystem.Data.Models;

    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<User> Users { get; set; }
    }
}