namespace UserSystem.Data
{
    using System.Data.Entity;

    using UserSystem.Data.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<User> Users { get; set; }
    }
}