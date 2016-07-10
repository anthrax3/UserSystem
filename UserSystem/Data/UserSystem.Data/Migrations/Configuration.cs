namespace UserSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using UserSystem.Common;
    using UserSystem.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private readonly IRandomGenerator random;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomGenerator();
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedUsers(context);
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            for (int i = 0; i < 20; i++)
            {
                var user = new User
                               {
                                   Id = i, 
                                   Username = this.random.RandomString(6, 16), 
                                   Email = $"{this.random.RandomString(6, 16)}@{this.random.RandomString(6, 16)}.com", 
                                   FirstName = this.random.RandomString(6, 16), 
                                   LastName = this.random.RandomString(6, 16), 
                                   Telephone =
                                       $"+{this.random.RandomNumber(0, 999).ToString("000")}"
                                       + $" {this.random.RandomNumber(0, 999).ToString("000")}"
                                       + $" {this.random.RandomNumber(0, 99).ToString("00")}"
                                       + $" {this.random.RandomNumber(0, 99).ToString("00")}"
                                       + $" {this.random.RandomNumber(0, 99).ToString("00")}", 
                                   Sex = (Gender)this.random.RandomNumber(0, 2), 
                                   Status = (Status)this.random.RandomNumber(0, 1)
                               };

                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}