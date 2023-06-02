using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace SpendingManagement.Models.EF
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SpendingDbContext : IdentityDbContext<ApplicationUser>
    {
        static SpendingDbContext()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            Database.SetInitializer<SpendingDbContext>(null);
        }
        // Your context has been configured to use a 'SpendingDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SpendingManagement.Models.EF.SpendingDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SpendingDbContext' 
        // connection string in the application configuration file.
        public SpendingDbContext()
            : base("name=DefaultConnection")
        {
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("aspnetusers");
            modelBuilder.Entity<IdentityRole>().ToTable("aspnetroles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("aspnetuserroles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("aspnetuserclaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("aspnetuserlogins");

            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}