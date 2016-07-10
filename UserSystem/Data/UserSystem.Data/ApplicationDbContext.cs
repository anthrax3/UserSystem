namespace UserSystem.Data
{
    using System.Data.Entity;
    using System.Linq;

    using UserSystem.Data.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyDeletableEntityRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries().Where(e => e.Entity is User && (e.State == EntityState.Deleted)))
            {
                var entity = (User)entry.Entity;

                entity.Status = Status.Deleted;
                entry.State = EntityState.Modified;
            }
        }
    }
}