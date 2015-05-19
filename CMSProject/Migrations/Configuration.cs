namespace CMSProject.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CMSProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CMSProject.DAL.CMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CMSProject.DAL.CMSContext";
        }

        protected override void Seed(CMSProject.DAL.CMSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var users = new List<User>
            {
                new User{Username = "Test1", Email="test1@test.coom",Password=Helpers.SHA1.Encode("test"), IdRole=1},
              new User{Username = "Test2", Email="test2@test.coom",Password=Helpers.SHA1.Encode("test"), IdRole=2},
               new User{Username = "Test3", Email="test3@test.coom",Password=Helpers.SHA1.Encode("test"), IdRole=3}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            var roles = new List<Role>
            {
                new Role{Name = "Admin"},
                new Role{Name = "ContentManager"},
                new Role{Name = "Editor"},
                new Role{Name = "SimpleUser" }
            };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();
        }
    }
}
